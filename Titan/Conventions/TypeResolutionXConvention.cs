using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Model;
using Pandora.Extensions;

namespace Titan.Conventions
{
    public class TypeResolutionXConvention : XConvention
    {
        public void Apply(XType xtype)
        {
            if (IsConcrete(xtype.Type)) return;
            Type impl = ResolveImplementation(xtype.Type);
            xtype.Type = impl ?? xtype.Type;
        }

        protected virtual Type ResolveImplementation(Type type)
        {
            if (type.IsCollection())
            {
                Type member = type.GetParentGenericArguments(typeof(IEnumerable<>)).SingleOrDefault() ?? typeof(string);
                return typeof(List<>).MakeGenericType(member);
            }
            return null;
        }

        // TODO migrate to pandora
        private bool IsConcrete(Type type)
        {
            return !type.IsInterface && !type.IsAbstract;
        }
    }
}

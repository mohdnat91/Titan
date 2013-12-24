using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Model;

namespace Titan.Visitors
{
    public abstract class XVisitor
    {
        //TODO replace with delegates.
        protected Dictionary<Type, MethodInfo> map;

        protected XVisitor()
        {
            map = GetType().GetMethods().Where(m => m.Name == "Visit" && HasRightParameters(m.GetParameters()))
                           .ToDictionary(m => m.GetParameters()[0].ParameterType);
        }

        private bool HasRightParameters(ParameterInfo[] parameters)
        {
            if (parameters.Length != 1) return false;
            Type type = parameters[0].ParameterType;
            return type != typeof(XStructure) && typeof(XStructure).IsAssignableFrom(type);
        }

        public void Visit(XStructure xstructure)
        {
            if (map.ContainsKey(xstructure.GetType()))
            {
                map[xstructure.GetType()].Invoke(this, new[] { xstructure });
            }
            else
            {
                Default(xstructure);
            }
        }

        public virtual void Default(XStructure xstructure)
        {
            throw new InvalidOperationException();
        }
    }
}

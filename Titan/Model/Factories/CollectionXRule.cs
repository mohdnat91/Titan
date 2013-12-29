using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandora.Extensions;

namespace Titan.Model.Factories
{
    public class CollectionXRule : XRule
    {
        public bool AppliesTo(Type type)
        {
            return type.IsCollection();
        }

        public XType Produce(Type type, XFactory factory)
        {
            Type member = type.GetParentGenericArguments(typeof(IEnumerable<>)).SingleOrDefault() ?? typeof(string);
            XType xmember = factory.Produce(member);
            return new XCollection(type, xmember);
        }
    }
}

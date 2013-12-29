using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Model.Factories
{
    public class PrimitiveXRule : XRule
    {
        public bool AppliesTo(Type type)
        {
            // TODO change to IsPrimitive()
            return type.IsPrimitive || type == typeof(string) || type == typeof(decimal);
        }

        public XType Produce(Type type, XFactory factory)
        {
            return new XPrimitive(type);
        }
    }
}

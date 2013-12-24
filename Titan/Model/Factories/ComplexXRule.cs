using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Model.Factories
{
    public class ComplexXRule : XRule
    {
        public bool AppliesTo(Type type)
        {
            return true;
        }

        public XType Produce(Type type, XFactory factory)
        {
            List<XProperty> properties = new List<XProperty>();
            foreach (PropertyInfo property in type.GetProperties())
            {
                XType propType = factory.Produce(property.PropertyType);
                properties.Add(new XProperty(property, propType));
            }
            return new XComplex(type, properties);
        }
    }
}

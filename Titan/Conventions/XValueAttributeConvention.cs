using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Attributes;
using Titan.Model;
using System.Reflection;
using System.Xml;
using Titan.Utilities;

namespace Titan.Conventions
{
    class XValueAttributeConvention : XConvention
    {
        public void Apply(XProperty property)
        {
            XValueAttribute attribute = property.Property.GetCustomAttribute<XValueAttribute>();
            if (attribute != null && property.PropertyType is XDictionary)
            {
                XDictionary dictionary = property.PropertyType as XDictionary;
                if (attribute.Name != null) dictionary.ValueSelector.Predicate = e => e.Name().LocalName.ToLower() == attribute.Name;
                dictionary.ValueSelector.NodeType = attribute.NodeType;
            }
        }
    }
}

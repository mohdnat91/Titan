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
    class XKeyAttributeConvention : XConvention
    {
        public void Apply(XProperty property)
        {
            XKeyAttribute attribute = property.Property.GetCustomAttribute<XKeyAttribute>();
            if (attribute != null && property.PropertyType is XDictionary)
            {
                XDictionary dictionary = property.PropertyType as XDictionary;
                if (attribute.Name != null) dictionary.KeySelector.Predicate = e => e.Name().LocalName.ToLower() == attribute.Name;
                dictionary.KeySelector.NodeType = attribute.NodeType;
            }
        }
    }
}

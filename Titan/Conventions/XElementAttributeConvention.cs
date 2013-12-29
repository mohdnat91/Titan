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
    public class XElementAttributeConvention : XConvention
    {
        public void Apply(XProperty property)
        {
            XElementAttribute attribute = property.Property.GetCustomAttribute<XElementAttribute>();
            if (attribute != null)
            {
                property.PropertySelector.NodeType = XmlNodeType.Element;
                if (attribute.Name != null)
                {
                    property.PropertySelector.Predicate = e => e.Name().LocalName.ToLower() == attribute.Name.ToLower();
                }
            }
        }
    }
}

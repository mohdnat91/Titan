using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Titan.Visitors;

namespace Titan.Model
{
    public class XProperty : XStructure
    {
        public PropertyInfo Property { get; set; }
        public XType PropertyType { get; set; }

        public Func<XElement,bool> PropertySelector { get; set; }

        public XProperty(PropertyInfo property, XType xtype)
        {
            Property = property;
            PropertyType = xtype;
            PropertySelector = e => e.Name.LocalName.ToLower() == property.Name.ToLower();
        }

        public void Accept(XVisitor visitor)
        {
            
        }
    }
}

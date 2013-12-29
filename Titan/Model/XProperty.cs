using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Titan.Navigation;
using Titan.Visitors;
using Titan.Utilities;

namespace Titan.Model
{
    public class XProperty : XStructure
    {
        public PropertyInfo Property { get; set; }
        public XType PropertyType { get; set; }

        public XSelector PropertySelector { get; set; }

        public XProperty(PropertyInfo property, XType xtype)
        {
            Property = property;
            PropertyType = xtype;
            PropertySelector = new XSelector { NodeType = XmlNodeType.Element, Predicate = e => e.Name().LocalName.ToLower() == property.Name.ToLower() };
        }

        public void Accept(XVisitor visitor)
        {
            visitor.PreVisit(this);
            PropertyType.Accept(visitor);
            visitor.PostVisit(this);
        }
    }
}

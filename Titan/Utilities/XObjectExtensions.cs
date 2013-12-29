using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Titan.Utilities
{
    public static class XObjectExtensions
    {
        public static XName Name(this XObject xobject)
        {
            switch (xobject.NodeType)
            {
                case XmlNodeType.Element:
                    return ((XElement)xobject).Name;
                case XmlNodeType.Attribute:
                    return ((XAttribute)xobject).Name;
                default:
                    return string.Empty;
            }
        }

        public static string Value(this XObject xobject)
        {
            switch (xobject.NodeType)
            {
                case XmlNodeType.Element:
                    return ((XElement)xobject).Value;
                case XmlNodeType.Attribute:
                    return ((XAttribute)xobject).Value;
                default:
                    return string.Empty;
            }
        }
    }
}

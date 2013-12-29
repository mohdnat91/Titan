using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Titan.Navigation;
using Titan.Utilities;

namespace Titan.Model
{
    public class XDictionary : XType
    {
        public XType KeyType { get; set; }
        public XType ValueType { get; set; }

        public XSelector EntrySelector { get; set; }
        public XSelector KeySelector { get; set; }
        public XSelector ValueSelector { get; set; }

        public XDictionary(Type type, XType key, XType value) : base(type)
        {
            KeyType = key;
            ValueType = value;
            EntrySelector = new XSelector { NodeType = XmlNodeType.Element, Predicate = e => e.Name().LocalName.ToLower() == "entry" };
            KeySelector = new XSelector { NodeType = XmlNodeType.Element, Predicate = e => e.Name().LocalName.ToLower() == "key" };
            ValueSelector = new XSelector { NodeType = XmlNodeType.Element, Predicate = e => e.Name().LocalName.ToLower() == "value" };
        }
    }
}

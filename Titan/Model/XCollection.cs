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
    public class XCollection : XType
    {
        public XType MemberXType { get; set; }
        public XSelector MemberSelector { get; set; }

        public XCollection(Type type, XType member) : base(type)
        {
            MemberXType = member;
            MemberSelector = new XSelector { NodeType = XmlNodeType.Element, Predicate = e => e.Name().LocalName.ToLower() == "item" };
        }
    }
}

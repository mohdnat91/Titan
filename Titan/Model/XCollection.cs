using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Titan.Model
{
    public class XCollection : XType
    {
        public XType MemberXType { get; set; }
        public Func<XElement,bool> MemberSelector { get; set; }

        public XCollection(Type type, XType member) : base(type)
        {
            MemberXType = member;
            MemberSelector = e => e.Name.LocalName.ToLower() == "item";
        }
    }
}

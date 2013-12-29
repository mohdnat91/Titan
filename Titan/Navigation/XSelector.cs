using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Titan.Navigation
{
    public class XSelector
    {
        public Func<XObject,bool> Predicate { get; set; }
        public XmlNodeType NodeType { get; set; }
    }
}

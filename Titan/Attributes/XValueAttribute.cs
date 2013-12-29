using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Titan.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class XValueAttribute : Attribute
    {
        public string Name { get; set; }
        public XmlNodeType NodeType { get; set; }
    }
}

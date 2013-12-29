using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Titan.Conventions;
using Titan.Model;

namespace Titan.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public sealed class XElementAttribute : Attribute
    {
        public string Name { get; set; }
    }
}

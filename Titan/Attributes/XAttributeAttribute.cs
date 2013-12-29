using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple=false, Inherited=false)]
    public sealed class XAttributeAttribute : Attribute
    {
        public string Name { get; set; }
    }
}

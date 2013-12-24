using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Visitors;

namespace Titan.Model
{
    public abstract class XType : XStructure
    {
        public Type Type { get; set; }

        public XType(Type type)
        {
            Type = type;
        }

        public virtual void Accept(XVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

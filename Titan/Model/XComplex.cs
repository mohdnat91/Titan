using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Model
{
    public class XComplex : XType
    {
        public List<XProperty> Properties { get; set; }

        public XComplex(Type type, List<XProperty> properties) : base(type)
        {
            Properties = properties;
        }

        public override void Accept(Visitors.XVisitor visitor)
        {
            base.Accept(visitor);
            Properties.ForEach(p => p.Accept(visitor));
        }
    }
}

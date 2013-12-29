using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Conventions;
using Titan.Model;

namespace Titan.Visitors
{
    internal class ConventionsVisitor : XVisitor 
    {
        public List<XConvention> Conventions { get; private set; }

        public ConventionsVisitor(List<XConvention> conventions = null)
        {
            Conventions = conventions ?? new List<XConvention>();
        }

        protected override void DefaultVisit(XStructure xstructure)
        {
            Conventions.ForEach(con => con.Apply(xstructure));
        }

        protected override void DefaultPreVisit(XStructure xstructure)
        {
            Conventions.ForEach(con => con.Apply(xstructure));
        }
    }
}

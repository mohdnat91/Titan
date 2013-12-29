using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Model;
using Titan.Utilities;

namespace Titan.Conventions
{
    public abstract class XConvention
    {
        private MethodGroup methods;

        public XConvention()
        {
            methods = new MethodGroup(this, "Apply");
        }

        public void Apply(XStructure xstructure)
        {
            methods.TryInvoke(xstructure);
        }
    }
}

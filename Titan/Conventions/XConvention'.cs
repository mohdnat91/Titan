using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Model;

namespace Titan.Conventions
{
    public abstract class XConvention<T> : XConvention where T : XStructure
    {
        void XConvention.Apply(XStructure xstructure)
        {
            if (xstructure is T) Apply((T)xstructure);
        }

        public abstract void Apply(T xstructure);
    }
}

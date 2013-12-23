using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Model;

namespace Titan.Conventions
{
    public interface XConvention
    {
        void Apply(XStructure xstructure);
    }
}

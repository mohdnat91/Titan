using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.Visitors;

namespace Titan.Model
{
    public interface XStructure
    {
        void Accept(XVisitor visitor);
    }
}

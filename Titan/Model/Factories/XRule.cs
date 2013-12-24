using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titan.Model.Factories
{
    public interface XRule
    {
        bool AppliesTo(Type type);
        XType Produce(Type type, XFactory factory);
    }
}

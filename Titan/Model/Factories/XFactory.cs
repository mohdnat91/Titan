using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Model.Factories
{
    public class XFactory
    {
        public List<XRule> Rules { get; private set; }

        public XFactory(List<XRule> xrules = null)
        {
            Rules = xrules ?? Default.XRules;
        }

        public XType Produce(Type type)
        {
            XRule rule = Rules.FirstOrDefault(r => r.AppliesTo(type));
            return rule.Produce(type, this);
        }
    }
}

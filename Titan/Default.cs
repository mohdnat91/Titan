using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Conventions;
using Titan.Model.Factories;

namespace Titan
{
    internal static class Default
    {
        public static List<XRule> XRules
        {
            get
            {
                return new List<XRule>
                {
                    new PrimitiveXRule(),
                    new DictionaryXRule(),
                    new CollectionXRule(),
                    new ComplexXRule()
                };
            }
        }

        public static List<XConvention> Conventions
        {
            get
            {
                return new List<XConvention>
                {
                    new XElementAttributeConvention(),
                    new XAttributeAttributeConvention(),
                    new XMemberAttributeConvention(),
                    new XKeyAttributeConvention(),
                    new XValueAttributeConvention(),
                    new TypeResolutionXConvention()
                };
            }
        }
    }
}

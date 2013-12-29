using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandora.Extensions;
using System.Collections;

namespace Titan.Model.Factories
{
    public class DictionaryXRule : XRule
    {
        public bool AppliesTo(Type type)
        {
            return type.InheritsFrom(typeof(IDictionary));
        }

        public XType Produce(Type type, XFactory factory)
        {
            Type[] types = type.GetParentGenericArguments(typeof(IDictionary<,>)) ?? new[] { typeof(string), typeof(string) };
            XType key = factory.Produce(types[0]);
            XType value = factory.Produce(types[1]);
            return new XDictionary(type, key, value);
        }
    }
}

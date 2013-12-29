using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Attributes;
using Titan.Model;
using System.Reflection;
using System.Xml;
using Titan.Utilities;

namespace Titan.Conventions
{
    class XMemberAttributeConvention : XConvention
    {
        public void Apply(XProperty property)
        {
            XMemberAttribute attribute = property.Property.GetCustomAttribute<XMemberAttribute>();
            if (attribute != null)
            {
                if (property.PropertyType is XDictionary)
                {
                    XDictionary dictionary = property.PropertyType as XDictionary;
                    dictionary.EntrySelector.Predicate = e => e.Name().LocalName.ToLower() == attribute.Name;
                }
                else if (property.PropertyType is XCollection)
                {
                    XCollection dictionary = property.PropertyType as XCollection;
                    dictionary.MemberSelector.Predicate = e => e.Name().LocalName.ToLower() == attribute.Name;
                }
            }
        }
    }
}

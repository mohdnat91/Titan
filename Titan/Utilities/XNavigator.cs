using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Titan.Utilities
{
    internal class XNavigator
    {
        private XElement current;

        public XNavigator(XElement root)
        {
            current = root;
        }

        public XElement Current { get { return current; } }

        public bool Descend(Func<XElement, bool> predicate)
        {
            current = current.Elements().FirstOrDefault(predicate);
            return current != null;
        }

        public bool Ascend()
        {
            if (current.Parent == null) return false;
            current = current.Parent;
            return true;
        }
        // TODO move to Pandora
        public bool Next(Func<XElement, bool> predicate)
        {
            XElement next = current.ElementsAfterSelf().FirstOrDefault(predicate);
            if (next == null) return false;
            current = next;
            return true;
        }
    }
}

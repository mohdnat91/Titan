using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Titan.Navigation
{
    public class XNavigator
    {
        private XObject current;
        private int depth;
        private Stack<int> points;

        public XObject Current { get { return current; } }

        public XNavigator(XElement root)
        {
            current = root;
            depth = 0;
            points = new Stack<int>();
        }

        public bool Descend(XSelector selector)
        {
            if (!(current is XElement)) return false;
            if (selector.NodeType == XmlNodeType.None)
            {
                points.Push(depth);
                return true;
            }
            depth++;
            IEnumerable<XObject> next;
            if (selector.NodeType == XmlNodeType.Element)
            {
                next = ((XElement)current).Elements();
            }
            else
            {
                next = ((XElement)current).Attributes();
            }
            current = next.FirstOrDefault(selector.Predicate);
            return current != null;
        }

        public bool Next(XSelector selector)
        {
            if (!(current is XElement) || selector.NodeType != XmlNodeType.Element) return false;
            XElement next = ((XElement)current).ElementsAfterSelf().FirstOrDefault<XElement>(selector.Predicate);
            if (next == null) return false;
            current = next;
            return true;
        }

        public bool Ascend()
        {
            if (!(points.Count == 0) && points.Peek() == depth)
            {
                points.Pop();
                return true;
            }
            if (current.Parent == null) return false;
            depth--;
            current = current.Parent;
            return true;
        }
    }
}

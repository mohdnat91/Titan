using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Model;
using Titan.Utilities;

namespace Titan.Visitors
{
    public abstract class XVisitor
    {
        protected MethodGroup visitGroup;
        protected MethodGroup preVisitGroup;
        protected MethodGroup postVisitGroup;

        protected XVisitor()
        {
            visitGroup = new MethodGroup(this, "Visit");
            preVisitGroup = new MethodGroup(this, "PreVisit");
            postVisitGroup = new MethodGroup(this, "PostVisit");
        }

        public void Visit(XStructure xstructure)
        {
            if (!visitGroup.TryInvoke(xstructure))
            {
                DefaultVisit(xstructure);
            }
        }

        public void PreVisit(XStructure xstructure)
        {
            if (!preVisitGroup.TryInvoke(xstructure))
            {
                DefaultPreVisit(xstructure);
            }
        }

        public void PostVisit(XStructure xstructure)
        {
            if (!postVisitGroup.TryInvoke(xstructure))
            {
                DefaultPostVisit(xstructure);
            }
        }

        protected virtual void DefaultVisit(XStructure xstructure)
        {
            throw new InvalidOperationException();
        }

        protected virtual void DefaultPreVisit(XStructure xstructure)
        {
        }

        protected virtual void DefaultPostVisit(XStructure xstructure)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Conventions;
using Titan.Model.Factories;
using Titan.Visitors;

namespace Titan.Model
{
    public class XTypeBuilder
    {
        public List<XConvention> Conventions { get; private set; }
        public XFactory Factory { get; private set; }

        public XTypeBuilder(List<XConvention> conventions = null, XFactory factory = null)
        {
            Conventions = conventions ?? Default.Conventions;
            Factory = factory ?? new XFactory();
        }

        public XType Build<T>()
        {
            XType result = Factory.Produce(typeof(T));
            result.Accept(new ConventionsVisitor(Conventions));
            return result;
        }

    }
}

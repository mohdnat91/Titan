using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Titan.Model;
using Titan.Visitors;

namespace Titan
{
    public class XDeserializer
    {
        public XTypeBuilder ModelBuilder { get; private set; }

        public XDeserializer()
        {
            ModelBuilder = new XTypeBuilder();
        }

        public T Deserialize<T>(XDocument xdocument)
        {
            XType model = ModelBuilder.Build<T>();
            DeserializationVisitor visitor = new DeserializationVisitor(xdocument.Root);
            model.Accept(visitor);
            return (T)visitor.Result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titan.Attributes;
using System.Xml;

namespace Titan.Tests
{
    [TestClass]
    public class TestDeserialize
    {
        [TestMethod]
        public void TestPrimitive()
        {
            const string xml = @"<int>5</int>";
            XDeserializer deserializer = new XDeserializer();
            int output = deserializer.Deserialize<int>(XDocument.Parse(xml));
            Assert.AreEqual(output, 5);
        }

        [TestMethod]
        public void TestComplex()
        {
            const string xml = @"<person><name>test sss</name><age>24</age></person>";
            XDeserializer deserializer = new XDeserializer();
            Person output = deserializer.Deserialize<Person>(XDocument.Parse(xml));
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestComplex2()
        {
            const string xml = @"<wallet><owner><name>test sss</name><age>24</age></owner><amount>100.348</amount><cards><item>sss</item><item>fgd</item></cards></wallet>";
            XDeserializer deserializer = new XDeserializer();
            Wallet output = deserializer.Deserialize<Wallet>(XDocument.Parse(xml));
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestDictionary()
        {
            const string xml = "<bank><name>bank123</name><clients><client key=\"asdc\"><owner><name>test sss</name><age>24</age></owner><amount>100.348</amount><cards><item>sss</item><item>fgd</item></cards></client></clients></bank>";
            XDeserializer deserializer = new XDeserializer();
            Bank output = deserializer.Deserialize<Bank>(XDocument.Parse(xml));
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestAttribute()
        {
            const string xml = "<person id=\"sdsd\"><age>24</age></person>";
            XDeserializer deserializer = new XDeserializer();
            AttributePerson output = deserializer.Deserialize<AttributePerson>(XDocument.Parse(xml));
            Assert.IsNotNull(output);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Wallet
    {
        public Person Owner { get; set; }
        public decimal Amount { get; set; }
        public string[] Cards { get; set; }
    }

    public class Bank
    {
        public string Name { get; set; }

        [XMember(Name="client")]
        [XKey(NodeType=XmlNodeType.Attribute)]
        [XValue(NodeType=XmlNodeType.None)]
        public Dictionary<string,Wallet> Clients { get; set; }
    }

    public class AttributePerson
    {
        [Titan.Attributes.XAttribute(Name="id")]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

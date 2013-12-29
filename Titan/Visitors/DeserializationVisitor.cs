using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Titan.Model;
using Titan.Navigation;
using Pandora.Extensions;
using Titan.Utilities;

namespace Titan.Visitors
{
    public class DeserializationVisitor : XVisitor
    {
        private readonly Stack<object> objects = new Stack<object>();
        private readonly XNavigator navigator;

        public object Result { get { return objects.Peek(); } }

        public DeserializationVisitor(XElement root)
        {
            navigator = new XNavigator(root);
        }

        public void Visit(XPrimitive primitive)
        {
            objects.Push(navigator.Current.Value().Parse(primitive.Type));
        }

        public void Visit(XComplex complex)
        {
            objects.Push(Activator.CreateInstance(complex.Type));
        }

        public void Visit(XCollection collection)
        {
            navigator.Descend(collection.MemberSelector);

            dynamic list = InstantiateCollection(collection);
            do
            {
                collection.MemberXType.Accept(this);
                list.Add((dynamic)objects.Pop());
            } while (navigator.Next(collection.MemberSelector));

            objects.Push(collection.Type.IsArray ? list.ToArray() : list);

            navigator.Ascend();
        }

        public void Visit(XDictionary dictionary)
        {
            navigator.Descend(dictionary.EntrySelector);

            dynamic result = Activator.CreateInstance(dictionary.Type);
            do
            {
                navigator.Descend(dictionary.KeySelector);
                dictionary.KeyType.Accept(this);
                dynamic key = (dynamic)objects.Pop();
                navigator.Ascend();

                navigator.Descend(dictionary.ValueSelector);
                dictionary.ValueType.Accept(this);
                dynamic value = (dynamic)objects.Pop();
                navigator.Ascend();

                result.Add(key, value);
            } while (navigator.Next(dictionary.EntrySelector));

            objects.Push(result);

            navigator.Ascend();
        }

        public void PreVisit(XProperty property)
        {
            navigator.Descend(property.PropertySelector);
        }

        public void PostVisit(XProperty property)
        {
            object value = objects.Pop();
            object obj = objects.Peek();
            property.Property.SetValue(obj, value);
            navigator.Ascend();
        }

        private dynamic InstantiateCollection(XCollection collection)
        {
            Type type = collection.Type;
            if (type.IsArray)
            {
                type = typeof(List<>).MakeGenericType(collection.MemberXType.Type);
            }
            return Activator.CreateInstance(type);
        }
    }
}

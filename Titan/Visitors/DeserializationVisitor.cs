using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Titan.Model;
using Titan.Utilities;

namespace Titan.Visitors
{
    public class DeserializationVisitor : XVisitor
    {
        private readonly Stack<object> _objects = new Stack<object>();
        private readonly XNavigator _navigator;

        public object Result { get { return _objects.Peek(); } }

        public DeserializationVisitor(XElement root)
        {
            _navigator = new XNavigator(root);
        }

        public void Visit(XPrimitive primitive)
        {
            _objects.Push(_navigator.Current.Value.Parse(primitive.Type));
        }

        public void Visit(XProperty property)
        {
            object value = _objects.Pop();
            object obj = _objects.Peek();
            property.Property.SetValue(obj, value);
            _navigator.Ascend();
        }

        public void Visit(XComplex complex)
        {
            _objects.Push(Activator.CreateInstance(complex.Type));
        }

        public void Navigate(XProperty property)
        {
            _navigator.Descend(property.PropertySelector);
        }

        public void Visit(XCollection collection)
        {
            dynamic list = Activator.CreateInstance(collection.Type);
            _objects.Push(list);
            _navigator.Descend(collection.MemberSelector);
            do
            {
                collection.MemberXType.Accept(this);
                list.Add((dynamic)_objects.Pop());
            } while (_navigator.Next(collection.MemberSelector));
            _navigator.Ascend();
        }
    }

    static class StringExtensions
    {
        public static object Parse(this string str, Type target)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(string));
            if (converter.CanConvertTo(target))
            {
                return converter.ConvertTo(str, target);
            }
            converter = TypeDescriptor.GetConverter(target);
            if (converter.CanConvertFrom(typeof(string)))
            {
                return converter.ConvertFromString(str);
            }
            return null;
        }
    }
}

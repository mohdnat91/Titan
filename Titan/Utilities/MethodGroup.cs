using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Model;
using Pandora.Extensions;

namespace Titan.Utilities
{
    public class MethodGroup
    {
        private object instance;
        private Dictionary<Type, MethodInfo> methodMap;

        public MethodGroup(object obj, string name)
        {
            methodMap = GetMethods(obj.GetType(), name);
            instance = obj;
        }

        public bool TryInvoke(XStructure xstructure)
        {
            Type type = xstructure.GetType();
            IEnumerable<Type> compatibleTypes = methodMap.Keys.Where(t => type.InheritsFrom(t));
            if (compatibleTypes.Any())
            {
                Type result = type.FindClosestParent(compatibleTypes);
                methodMap[result].Invoke(instance, new[] { xstructure });
                return true;
            }
            return false;
        }

        private Dictionary<Type, MethodInfo> GetMethods(Type type, string name)
        {
            return type.GetMethods().Where(m => m.Name == name && HasRightParameters(m.GetParameters()))
                            .ToDictionary(m => m.GetParameters()[0].ParameterType);
        }

        private bool HasRightParameters(ParameterInfo[] parameters)
        {
            if (parameters.Length != 1) return false;
            Type type = parameters[0].ParameterType;
            return type != typeof(XStructure) && typeof(XStructure).IsAssignableFrom(type);
        }
    }

    internal static class TypeExtensions
    {
        public static Type FindClosestParent(this Type type, IEnumerable<Type> parents)
        {
            Type closest = null;
            int distance = int.MaxValue;

            foreach (Type parent in parents)
            {
                int temp = FindDistance(type, parent);
                if (temp == int.MaxValue) continue;
                if (temp < distance)
                {
                    closest = parent;
                    distance = temp;
                }
                else if (distance == temp)
                {
                    throw new Exception();
                }
            }

            return closest;
        }

        private static int FindDistance(Type type, Type parent)
        {
            Type current = type;
            int level = 0;

            while (current != null)
            {
                if (current == parent)
                {
                    return level;
                }
                level++;
                Type inter = current.GetInterfaces().SingleOrDefault(i => i == parent);
                if (inter != null) return level;
                current = current.BaseType;
            }

            return int.MaxValue;
        }
    }
}

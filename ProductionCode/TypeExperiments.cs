using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ProductionCode
{
    public class ContainerClass<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public static class TypeExperiments
    {
        public static string GetParameterType(object o)
        {
            return o.GetType().ToString();
        }

        public static string GetInternalParameterType(object o)
        {
            // Assume it's generic
            return o.GetType().GenericTypeArguments[0].ToString();
        }

        public static ContainerClass<T> ReturnContainerOfData<T>(T someData)
        {
            var ret = new ContainerClass<T>();
            ret.Success = true;  // Always successful!
            ret.Data = someData;
            return ret;
        }

        public static T CombineGenericEnumerableThings<T, U>(T first, T second) where T : IEnumerable
        {
            IEnumerable<U> one = (IEnumerable<U>)first;
            IEnumerable<U> two = (IEnumerable<U>)second;

            var combined = one.Concat(two);

            return (T)combined;
        }
    }
}

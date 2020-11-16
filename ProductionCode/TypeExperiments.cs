using System;

namespace ProductionCode
{
    public class ContainerClass<T>
    {
        bool Success { get; set; }
        T Data { get; set; }
    }

    public static class TypeExperiments
    {
        public static string GetParameterType(object o)
        {
            return o.GetType().ToString();
        }
    }
}

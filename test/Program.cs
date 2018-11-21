using System;
using System.Reflection;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = Assembly.LoadFrom(@".\KHOpenAPI.dll");
            Console.WriteLine(a);
            Type _DKHOpenAPI = a.GetType("KHOpenAPI.KHOpenAPIClass");
            Console.WriteLine(_DKHOpenAPI);
            MethodInfo CommConnect = _DKHOpenAPI.GetMethod("CommConnect");
            Console.WriteLine(CommConnect);
            object obj = Activator.CreateInstance(_DKHOpenAPI);
            CommConnect.Invoke(obj,null);
        }
    }
}

using System;
using System.Reflection;

namespace usingDllMethod
{
    class Program
    {
        public static void Main(){
            Assembly a = Assembly.LoadFrom(@".\KHOpenAPI.dll");
            Console.WriteLine(a);
            Type _DKHOpenAPI = a.GetType("KHOpenAPI._DKHOpenAPI");
            Console.WriteLine(_DKHOpenAPI);
            MethodInfo CommConnect = _DKHOpenAPI.GetMethod("CommConnect");
            Console.WriteLine(CommConnect);
            object obj = Activator.CreateInstance(_DKHOpenAPI);
            CommConnect.Invoke(obj,null);
        }
    }
}

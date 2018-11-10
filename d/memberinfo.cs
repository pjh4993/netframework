using System;
using System.Reflection;

class Module1{
    public static void Main(){
        Int32 indent = 0;
        Assembly a = Assembly.LoadFrom(@".\aossdk.dll");
        Display(indent, "Assembly identity={0}",a.FullName);
        Display(indent+1, "Codebase={0}",a.CodeBase);
        Display(indent, "Referenced assemblies:");
        foreach (AssemblyName an in a.GetReferencedAssemblies())
        {
            Display(indent + 1, an.FullName.ToString());
        }
        Display(indent,"");
        foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies()){
            Display(indent,"Assembly: {0}",b);
            foreach (Module m in b.GetModules(true))
            {
                Display(indent+1, "Module: {0}",m.Name);
            }
            indent+=1;
            foreach(Type t in b.GetExportedTypes()){
                Display(0,"");
                Display(indent,"Type: {0}",t);
                indent+=1;
                foreach(MemberInfo mi in t.GetMembers(BindingFlags.Public |
			BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance |
			BindingFlags.DeclaredOnly)){
                    Display(indent, "Member: {0} {1}",mi.Name, mi.MemberType);
                    DisplayAttributes(indent, mi);
                    if(mi.MemberType == MemberTypes.Method){
                        foreach( ParameterInfo pi in ((MethodInfo) mi).GetParameters()){
                            Display(indent+1, "Parameter: Type={0}, Name={1}", 
                            pi.ParameterType, pi.Name);
                        }
                    }
                }
                indent-=1;
            }
            indent-=1;
        }
    }
    public static void Display(Int32 indent, string format, params object[] param){
        Console.Write(new String(' ',indent*2));
        Console.WriteLine(format, param);
    }

    public static void DisplayAttributes(Int32 indent, MemberInfo mi){
        object[] attrs = mi.GetCustomAttributes(false);
        if(attrs.Length == 0)return;
        Display(indent+1, "Attributes:");
        foreach(object o in attrs){
            Display(indent+2,"{0}",o.ToString());
        }
    }
}
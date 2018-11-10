using System;
using System.Reflection;

class Asminfo1{
    public static void Main(){
        Console.WriteLine("\nReflection.MemberInfo");
        Type MyType = Type.GetType("System.IO.BinaryReader");
        Console.WriteLine("Full assembly name :\n {0}.",
			MyType.Assembly.FullName.ToString());
		Console.WriteLine("Qualified assembly name:\n {0}.",
			MyType.AssemblyQualifiedName);
		MemberInfo[] Mymemberinfoarray = MyType.GetMembers(BindingFlags.Public |
			BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance |
			BindingFlags.DeclaredOnly);
		Console.Write("\nThere are {0} documentable members in {1}.",
			Mymemberinfoarray.Length, MyType.FullName);
		foreach (MemberInfo Mymemberinfo in Mymemberinfoarray)
		{
			Console.Write("\n" + Mymemberinfo.Name + " " + Mymemberinfo.MemberType);
		}
    }
}
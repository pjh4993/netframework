using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Typelibconvert
{

    public class tlcvt{
        private enum RegKind{
            RegKind_Default = 0,
            RegKind_Register = 1,
            RegKind_None = 2
        }
        [DllImport("oleaut32.dll",CharSet = CharSet.Unicode, PreserveSig = false )]        
        private static extern void LoadTypeLibEx( String strTypeLibName, RegKind regKind, [ MarshalAs( UnmanagedType.Interface )] out Object typeLib );
        
        public static void Main(string[] args){
            Object typeLib;
		    LoadTypeLibEx( "KHOpenAPI.ocx", RegKind.RegKind_None, out typeLib ); 
		
                if( typeLib == null )
                {
                    Console.WriteLine( "LoadTypeLibEx failed." );
                    return;
                }
                    
                TypeLibConverter converter = new TypeLibConverter();
                ConversionEventHandler eventHandler = new ConversionEventHandler();
                AssemblyBuilder asm = converter.ConvertTypeLibToAssembly( typeLib, "KHOpenAPI.dll", 0, eventHandler, null, null, null, null );	
                asm.Save( "KHOpenAPI.dll" );
            }
    }
    public class ConversionEventHandler : ITypeLibImporterNotifySink
    {
        public void ReportEvent( ImporterEventKind eventKind, int eventCode, string eventMsg )
        {
            // handle warning event here...
        }
        
        public Assembly ResolveRef( object typeLib )
        {
            // resolve reference here and return a correct assembly...
            return null; 
        }	
    }
}
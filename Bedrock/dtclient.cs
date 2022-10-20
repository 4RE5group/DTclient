using System;
using System.Net;
using System.Text;
using System.IO;
using System.Windows.Forms;
using RGiesecke.DllExport;
// using Mono.Cecil;
// using RGiesecke.DllExport.MSBuild;

namespace dtclient
{
	static class Program
	{
		// const int DLL_PROCESS_ATTACH = 0;
        // const int DLL_THREAD_ATTACH = 1;
        // const int DLL_THREAD_DETACH = 2;
        // const int DLL_PROCESS_DETACH = 3;
 
        // static Action process_attach = () => Console.WriteLine(@"process_attach");
        // static Action thread_attach = () => Console.WriteLine(@"thread_attach");
        // static Action thread_detach = () => Console.WriteLine(@"thread_detach");
        // static Action process_detach = () => Console.WriteLine(@"process_detach");
 
 
        [DllExport("Add", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static bool DllMain(int hModule, int ul_reason_for_call, IntPtr lpReserved)
        {
 
            switch (ul_reason_for_call)
            {
                case DLL_PROCESS_ATTACH:
                    process_attach();
                    break;
                case DLL_THREAD_ATTACH:
                    thread_attach();
                    break;
                case DLL_THREAD_DETACH:
                    thread_detach();
                    break;
                case DLL_PROCESS_DETACH:
                    process_detach();
                    break;
            }
 
            return true;
        }
	}
}
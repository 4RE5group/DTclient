using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.IO.Compression;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DTinjector
{
    static class Program
    {
		
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
			uint dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

		[DllImport("kernel32.dll")]
		static extern IntPtr CreateRemoteThread(IntPtr hProcess,
IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		
		const int PROCESS_CREATE_THREAD = 0x0002;
		const int PROCESS_QUERY_INFORMATION = 0x0400;
		const int PROCESS_VM_OPERATION = 0x0008;
		const int PROCESS_VM_WRITE = 0x0020;
		const int PROCESS_VM_READ = 0x0010;

		const uint MEM_COMMIT = 0x00001000;
		const uint MEM_RESERVE = 0x00002000;
		const uint PAGE_READWRITE = 4;
		
		
		[DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
		public extern static void ShowCursor(int status);
		
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		
		
		static void Main()
		{
	
			// inject("dtclient.dll");
	
	
			Process targetProcess = Process.GetProcessesByName("Minecraft.Windows")[0];
			
			IntPtr procHandle = OpenProcess(2035711, false, targetProcess.Id);
			// IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);

			IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

			string dllName = @"dtclient.dll";

			// IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

			// UIntPtr bytesWritten;
			// WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);

			// CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
			
			IntPtr p1 = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)(dllName.Length + 1), 12288U, 64U);
			IntPtr p2 = IntPtr.Zero;
			UIntPtr bytesWritten;
			WriteProcessMemory(procHandle, p1, Encoding.ASCII.GetBytes(dllName), (uint)(dllName.Length + 1), p2);
			// IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			IntPtr p3 = CreateRemoteThread(procHandle, IntPtr.Zero, 0U, loadLibraryAddr, p1, 0U, p2);
			
			
			
			
			
			
			
			
			// MessageBox.Show("Injected");
			// GetProcAddress(loadLibraryAddr, "DTclient.init");
			return;
		}
		// public static void inject(string path)
		// {

			// MessageBox.Show("finding process");
			// var processes = Process.GetProcessesByName("Minecraft.Windows");
			// if (processes.Length == 0)
			// {
				// MessageBox.Show("launching minecraft");

				// int t = 0;
				// while (processes.Length == 0)
				// {
					// if (++t > 200)
					// {
						// MessageBox.Show("Minecraft launch took too long.");
						// return;
					// }

					// processes = Process.GetProcessesByName("Minecraft.Windows");
					// Thread.Sleep(10);
				// }
				// Thread.Sleep(3000);
			// }
			// var process = processes.First(p => p.Responding);

			// for (int i = 0; i < process.Modules.Count; i++)
			// {
				// if (process.Modules[i].FileName == path)
				// {
					// MessageBox.Show("Already injected!");
				// }
			// }

			// MessageBox.Show("injecting into " + process.Id);
			// IntPtr handle = OpenProcess(2035711, false, process.Id);
			// if (handle == IntPtr.Zero || !process.Responding)
			// {
				// MessageBox.Show("Failed to get process handle");
			// }

			// IntPtr p1 = VirtualAllocEx(handle, IntPtr.Zero, (uint)(path.Length + 1), 12288U, 64U);
			// IntPtr p2 = null;
			// WriteProcessMemory(handle, p1, Encoding.ASCII.GetBytes(path), path.Length, p2);
			// IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			// IntPtr p3 = CreateRemoteThread(handle, IntPtr.Zero, 0U, procAddress, p1, 0U, p2);

			// uint n = WaitForSingleObject(p3, 5000);
			// if (n == 128L || n == 258L)
			// {
				// CloseHandle(p3);
			// }
			// else
			// {
				// VirtualFreeEx(handle, p1, 0, (IntPtr)32768);
				// if (p3 != IntPtr.Zero)
					// CloseHandle(p3);
				// if (handle != IntPtr.Zero)
					// CloseHandle(handle);
			// }

			// IntPtr windowH = FindWindow(null, "Minecraft");
			// if (windowH == IntPtr.Zero)
				// MessageBox.Show("Couldn't get window handle");
			// else
				// SetForegroundWindow(windowH);
		// }

    }
}
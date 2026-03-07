using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Client.Providers;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Client.Forms
{
	internal abstract class Win32
	{
		public struct NCCALCSIZE_PARAMS
		{
			public RECT r1;

			public RECT r2;

			public RECT r3;

			public IntPtr lppos;
		}

		public struct RECT
		{
			internal int Left;

			internal int Top;

			internal int Right;

			internal int Bottom;
		}

		public struct CWPSTRUCT
		{
			public IntPtr lparam;

			public IntPtr wparam;

			public int message;

			public IntPtr hwnd;
		}

		public struct WINDOWPOS
		{
			internal int hwnd;

			internal int hWndInsertAfter;

			internal int x;

			internal int y;

			internal int cx;

			internal int cy;

			internal int flags;
		}

		public delegate int HookProc(int code, IntPtr wparam, ref CWPSTRUCT cwp);

		public const int WH_CALLWNDPROC = 4;

		public const int WM_CREATE = 1;

		public const int WM_DESTROY = 2;

		public const int WM_NCPAINT = 133;

		public const int WM_PRINT = 791;

		public const int WM_WINDOWPOSCHANGING = 70;

		public const int SWP_NOSIZE = 1;

		public const int WM_NCCALCSIZE = 131;

		public const int WVR_REDRAW = 768;

		public const int WVR_HREDRAW = 256;

		public const int WVR_VREDRAW = 512;

		public const int SWP_NOMOVE = 2;

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int CallNextHookEx(IntPtr hookHandle, int code, IntPtr wparam, ref CWPSTRUCT cwp);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetClassNameA", ExactSpelling = true, SetLastError = true)]
		public static extern int GetClassName(IntPtr hwnd, StringBuilder className, int maxCount);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetWindowDC(IntPtr hwnd);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetWindowThreadProcessId(IntPtr hwnd, int ID);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetWindowsHookExA", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(int type, HookProc hook, IntPtr instance, int threadID);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool UnhookWindowsHookEx(IntPtr hookHandle);
	}
}

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace HtmlHelp;

[SuppressUnmanagedCodeSecurity]
public class Interop
{
	public delegate int WNDPROC(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	[ComVisible(false)]
	public struct ITS_Control_Data
	{
		public int cdwControlData;

		public int adwControlData;
	}

	[ComVisible(false)]
	public struct MSG
	{
		public IntPtr hwnd;

		public int message;

		public IntPtr wParam;

		public IntPtr lParam;

		public int time;

		public int pt_x;

		public int pt_y;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[ComVisible(false)]
	public class WNDCLASS
	{
		public int style = 0;

		public WNDPROC lpfnWndProc = null;

		public int cbClsExtra = 0;

		public int cbWndExtra = 0;

		public IntPtr hInstance = IntPtr.Zero;

		public IntPtr hIcon = IntPtr.Zero;

		public IntPtr hCursor = IntPtr.Zero;

		public IntPtr hbrBackground = IntPtr.Zero;

		public string lpszMenuName = null;

		public string lpszClassName = null;
	}

	[ComVisible(false)]
	public struct PAINTSTRUCT
	{
		public IntPtr hdc;

		public bool fErase;

		public int rcPaint_left;

		public int rcPaint_top;

		public int rcPaint_right;

		public int rcPaint_bottom;

		public bool fRestore;

		public bool fIncUpdate;

		public int reserved1;

		public int reserved2;

		public int reserved3;

		public int reserved4;

		public int reserved5;

		public int reserved6;

		public int reserved7;

		public int reserved8;
	}

	[ComImport]
	[Guid("0000000D-0000-0000-C000-000000000046")]
	[SuppressUnmanagedCodeSecurity]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumSTATSTG
	{
		int Next(int celt, out STATSTG rgVar, out int pceltFetched);

		int Skip(int celt);

		int Reset();

		int Clone(out IEnumSTATSTG newEnum);
	}

	[ComImport]
	[Guid("0000000a-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ILockBytes
	{
		int ReadAt(long ulOffset, out IntPtr pv, int cb);

		int WriteAt(long ulOffset, IntPtr pv, int cb);

		void Flush();

		void SetSize(long cb);

		void LockRegion(long libOffset, long cb, int dwLockType);

		void UnlockRegion(long libOffset, long cb, int dwLockType);

		void Stat(ref STATSTG pstatstg, int grfStatFlag);
	}

	[ComImport]
	[SuppressUnmanagedCodeSecurity]
	[Guid("0000000B-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStorage
	{
		[return: MarshalAs(UnmanagedType.Interface)]
		UCOMIStream CreateStream([MarshalAs(UnmanagedType.BStr)] string pwcsName, [MarshalAs(UnmanagedType.U4)] int grfMode, [MarshalAs(UnmanagedType.U4)] int reserved1, [MarshalAs(UnmanagedType.U4)] int reserved2);

		[return: MarshalAs(UnmanagedType.Interface)]
		UCOMIStream OpenStream([MarshalAs(UnmanagedType.BStr)] string pwcsName, IntPtr reserved1, [MarshalAs(UnmanagedType.U4)] int grfMode, [MarshalAs(UnmanagedType.U4)] int reserved2);

		[return: MarshalAs(UnmanagedType.Interface)]
		IStorage CreateStorage([MarshalAs(UnmanagedType.BStr)] string pwcsName, [MarshalAs(UnmanagedType.U4)] int grfMode, [MarshalAs(UnmanagedType.U4)] int reserved1, [MarshalAs(UnmanagedType.U4)] int reserved2);

		[return: MarshalAs(UnmanagedType.Interface)]
		IStorage OpenStorage([MarshalAs(UnmanagedType.BStr)] string pwcsName, IntPtr pstgPriority, [MarshalAs(UnmanagedType.U4)] int grfMode, IntPtr snbExclude, [MarshalAs(UnmanagedType.U4)] int reserved);

		void CopyTo(int ciidExclude, [MarshalAs(UnmanagedType.LPArray)] Guid[] rgiidExclude, IntPtr snbExclude, [MarshalAs(UnmanagedType.Interface)] IStorage pstgDest);

		void MoveElementTo([MarshalAs(UnmanagedType.BStr)] string pwcsName, [MarshalAs(UnmanagedType.Interface)] IStorage pstgDest, [MarshalAs(UnmanagedType.BStr)] string pwcsNewName, [MarshalAs(UnmanagedType.U4)] int grfFlags);

		void Commit(int grfCommitFlags);

		void Revert();

		int EnumElements([MarshalAs(UnmanagedType.U4)] int reserved1, IntPtr reserved2, [MarshalAs(UnmanagedType.U4)] int reserved3, [MarshalAs(UnmanagedType.Interface)] out IEnumSTATSTG ppenum);

		void DestroyElement([MarshalAs(UnmanagedType.BStr)] string pwcsName);

		void RenameElement([MarshalAs(UnmanagedType.BStr)] string pwcsOldName, [MarshalAs(UnmanagedType.BStr)] string pwcsNewName);

		void SetElementTimes([MarshalAs(UnmanagedType.BStr)] string pwcsName, FILETIME pctime, FILETIME patime, FILETIME pmtime);

		void SetClass(ref Guid clsid);

		void SetStateBits(int grfStateBits, int grfMask);

		int Stat(out STATSTG pStatStg, int grfStatFlag);
	}

	[ComImport]
	[SuppressUnmanagedCodeSecurity]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("88CC31DE-27AB-11D0-9DF9-00A0C922E6EC")]
	public interface ITStorage
	{
		[return: MarshalAs(UnmanagedType.Interface)]
		IStorage StgCreateDocfile([MarshalAs(UnmanagedType.BStr)] string pwcsName, int grfMode, int reserved);

		[return: MarshalAs(UnmanagedType.Interface)]
		IStorage StgCreateDocfileOnILockBytes(ILockBytes plkbyt, int grfMode, int reserved);

		int StgIsStorageFile([MarshalAs(UnmanagedType.BStr)] string pwcsName);

		int StgIsStorageILockBytes(ILockBytes plkbyt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IStorage StgOpenStorage([MarshalAs(UnmanagedType.BStr)] string pwcsName, IntPtr pstgPriority, [MarshalAs(UnmanagedType.U4)] int grfMode, IntPtr snbExclude, [MarshalAs(UnmanagedType.U4)] int reserved);

		[return: MarshalAs(UnmanagedType.Interface)]
		IStorage StgOpenStorageOnILockBytes(ILockBytes plkbyt, IStorage pStgPriority, int grfMode, IntPtr snbExclude, int reserved);

		int StgSetTimes([MarshalAs(UnmanagedType.BStr)] string lpszName, FILETIME pctime, FILETIME patime, FILETIME pmtime);

		int SetControlData(ITS_Control_Data pControlData);

		int DefaultControlData(ITS_Control_Data ppControlData);

		int Compact([MarshalAs(UnmanagedType.BStr)] string pwcsName, int iLev);
	}

	[ComImport]
	[Guid("5D02926A-212E-11D0-9DF9-00A0C922E6EC")]
	public class UCOMITStorage
	{
	}

	public static Guid WINTRUST_ACTION_GENERIC_VERIFY_V2;

	public static Guid IID_IUnknown;

	public static IntPtr NullIntPtr;

	public const uint S_OK = 0u;

	public const uint STG_E_FILENOTFOUND = 2147680258u;

	public const uint STG_E_INVALIDNAME = 2147680508u;

	public const int STGTY_STORAGE = 1;

	public const int STGTY_STREAM = 2;

	public const int STGTY_LOCKBYTES = 3;

	public const int STGTY_PROPERTY = 4;

	public const int COMPACT_DATA = 0;

	public const int COMPACT_DATA_AND_PATH = 1;

	public const int WM_USER = 1024;

	public const int WM_CHAR = 258;

	public const int WM_CLOSE = 16;

	public const int WM_COMMAND = 273;

	public const int WM_CREATE = 1;

	public const int WM_DESTROY = 2;

	public const int WM_ERASEBKGND = 20;

	public const int WM_KILLFOCUS = 8;

	public const int WM_LBUTTONDBLCLK = 515;

	public const int WM_LBUTTONDOWN = 513;

	public const int WM_LBUTTONUP = 514;

	public const int WM_MBUTTONDBLCLK = 521;

	public const int WM_MBUTTONDOWN = 519;

	public const int WM_MBUTTONUP = 520;

	public const int WM_MOUSEMOVE = 512;

	public const int WM_NCLBUTTONDOWN = 161;

	public const int WM_NCLBUTTONUP = 162;

	public const int WM_NCPAINT = 133;

	public const int WM_NOTIFY = 78;

	public const int WM_PAINT = 15;

	public const int WM_SETFOCUS = 7;

	public const int WM_TIMER = 275;

	public const int HWND_TOPMOST = -1;

	public const int SW_SHOWNORMAL = 1;

	public const int WS_EX_LAYERED = 524288;

	public const int WS_EX_TOOLWINDOW = 128;

	public const int WS_EX_TOPMOST = 8;

	public const int WS_HSCROLL = 1048576;

	public const int WS_OVERLAPPEDWINDOW = 13565952;

	public const int WS_POPUP = int.MinValue;

	public const int WS_VISIBLE = 268435456;

	public const int WS_VSCROLL = 2097152;

	public const int WS_CHILD = 1073741824;

	public const int WS_BORDER = 8388608;

	public const int WS_EX_WINDOWEDGE = 256;

	public const int CS_DROPSHADOW = 131072;

	static Interop()
	{
		IID_IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");
		NullIntPtr = (IntPtr)0;
		WINTRUST_ACTION_GENERIC_VERIFY_V2 = new Guid("00AAC56B-CD44-11d0-8CC2-00C04FC295EE");
	}

	[DllImport("Ole32.dll")]
	public static extern int StgOpenStorage([MarshalAs(UnmanagedType.LPWStr)] string wcsName, IStorage pstgPriority, int grfMode, IntPtr snbExclude, int reserved, out IStorage storage);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern IntPtr BeginPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, IntPtr hWndParent, IntPtr hMenu, IntPtr hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern bool DestroyWindow(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int DispatchMessage(ref MSG msg);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern IntPtr GetLastActivePopup(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool GetMessage(ref MSG msg, IntPtr hwnd, int minFilter, int maxFilter);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern int GetMessagePos();

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern bool KillTimer(IntPtr hwnd, int idEvent);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool PeekMessage(out MSG msg, IntPtr hwnd, int msgMin, int msgMax, int remove);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern void PostQuitMessage(int nExitCode);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr RegisterClass(WNDCLASS wc);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int RegisterWindowMessage(string msg);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern int SetTimer(IntPtr hWnd, int nIDEvent, int uElapse, IntPtr lpTimerFunc);

	[DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern bool TranslateMessage(ref MSG msg);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool UpdateWindow(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetModuleHandle(string moduleName);
}

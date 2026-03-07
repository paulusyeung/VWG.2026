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
	internal class MenuHook : NativeWindow
	{
		private ClientMenuStyleProvider _parent = null;

		private int _lastwidth = 0;

		public MenuHook(ClientMenuStyleProvider parent, int lastwidth)
		{
			if (parent == null)
			{
				throw new ArgumentNullException();
			}
			_parent = parent;
			_lastwidth = lastwidth;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 70:
			{
				Win32.WINDOWPOS structure2 = (Win32.WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(Win32.WINDOWPOS));
				if ((structure2.flags & 1) == 0)
				{
					structure2.cx -= 2;
					structure2.cy -= 2;
				}
				Marshal.StructureToPtr(structure2, m.LParam, fDeleteOld: true);
				m.Result = IntPtr.Zero;
				break;
			}
			case 133:
			{
				IntPtr windowDC = Win32.GetWindowDC(m.HWnd);
				Graphics graphics = Graphics.FromHdc(windowDC);
				DrawBorder(graphics);
				Win32.ReleaseDC(m.HWnd, windowDC);
				graphics.Dispose();
				m.Result = IntPtr.Zero;
				break;
			}
			case 131:
			{
				Win32.NCCALCSIZE_PARAMS structure = (Win32.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(Win32.NCCALCSIZE_PARAMS));
				structure.r1.Left += 2;
				structure.r1.Top += 2;
				structure.r1.Right -= 2;
				structure.r1.Bottom -= 2;
				Marshal.StructureToPtr(structure, m.LParam, fDeleteOld: true);
				m.Result = new IntPtr(768);
				break;
			}
			default:
				base.WndProc(ref m);
				break;
			}
		}

		private void DrawBorder(Graphics gr)
		{
			Rectangle rectangle = Rectangle.Round(gr.VisibleClipBounds);
			rectangle.Width--;
			rectangle.Height--;
			int marginWidth = _parent.MarginWidth;
			gr.FillRectangle(_parent.MarginBrush, rectangle.X + 1, rectangle.Y + 1, 1, rectangle.Height - 1);
			gr.FillRectangle(_parent.BackGroundBrush, rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 1, 1);
			gr.FillRectangle(_parent.BackGroundBrush, rectangle.X + 1, rectangle.Bottom - 1, rectangle.Width - 1, 1);
			gr.FillRectangle(_parent.BackGroundBrush, rectangle.Right - 1, rectangle.Y + 1, 1, rectangle.Height);
			gr.DrawLine(_parent.BackgroundPen, rectangle.X + 1, rectangle.Y, rectangle.X + _lastwidth - 2, rectangle.Y);
			gr.DrawLine(_parent.BorderPen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Bottom);
			gr.DrawLine(_parent.BorderPen, rectangle.X, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
			gr.DrawLine(_parent.BorderPen, rectangle.Right, rectangle.Bottom, rectangle.Right, rectangle.Y);
			gr.DrawLine(_parent.BorderPen, rectangle.Right, rectangle.Y, rectangle.X + _lastwidth - 1, rectangle.Y);
		}
	}
}

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
	public class ClientPanel : System.Windows.Forms.Panel
	{
		private PanelType menmPanelType = PanelType.Normal;

		public PanelType PanelType
		{
			get
			{
				return menmPanelType;
			}
			set
			{
				menmPanelType = value;
				Invalidate(invalidateChildren: true);
			}
		}

		private Font HeaderFont => new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);

		public override Rectangle DisplayRectangle
		{
			get
			{
				if (menmPanelType == PanelType.Titled)
				{
					Rectangle displayRectangle = base.DisplayRectangle;
					return new Rectangle(displayRectangle.Left + 1, displayRectangle.Top + 26, displayRectangle.Right - displayRectangle.Left - 2, displayRectangle.Bottom - displayRectangle.Top - 28);
				}
				return base.DisplayRectangle;
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (menmPanelType == PanelType.Titled)
				{
					Invalidate(invalidateChildren: false);
				}
			}
		}

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			if (menmPanelType == PanelType.Titled)
			{
				Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
				e.Graphics.FillRectangle(new SolidBrush(Color.White), rect);
				e.Graphics.DrawRectangle(new Pen(Color.DarkBlue, 1f), 0, 0, base.Width - 1, base.Height - 1);
				LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 30), Color.Blue, Color.DarkBlue);
				Rectangle rect2 = new Rectangle(1, 1, base.Width - 2, 25);
				e.Graphics.FillRectangle(brush, rect2);
				SolidBrush brush2 = new SolidBrush(Color.White);
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Near;
				RectangleF layoutRectangle = new RectangleF(5f, 5f, base.Width - 7, HeaderFont.Height);
				e.Graphics.DrawString(Text, HeaderFont, brush2, layoutRectangle, stringFormat);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (menmPanelType == PanelType.Titled)
			{
				Invalidate(invalidateChildren: false);
			}
		}
	}
}

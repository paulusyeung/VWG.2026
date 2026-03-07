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

namespace Gizmox.WebGUI.Client.Controllers
{
	public class ContextMenuStripController : ToolStripDropDownMenuController
	{
		protected override bool UseVsMenuDeisgner => false;

		private Gizmox.WebGUI.Forms.ContextMenuStrip WebContextMenuStrip => base.WebControl as Gizmox.WebGUI.Forms.ContextMenuStrip;

		private System.Windows.Forms.ContextMenuStrip WinContextMenuStrip => base.WinControl as System.Windows.Forms.ContextMenuStrip;

		public ContextMenuStripController(IContext objContext, object objWebContextMenuStrip, object objWinContextMenuStrip)
			: base(objContext, objWebContextMenuStrip, objWinContextMenuStrip)
		{
		}

		public ContextMenuStripController(IContext objContext, object objWebContextMenuStrip)
			: base(objContext, objWebContextMenuStrip)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinContextMenuStripShowCheckMargin();
			SetWinContextMenuStripShowImageMargin();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ContextMenuStrip();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "ShowCheckMargin"))
			{
				if (property == "ShowImageMargin")
				{
					SetWinContextMenuStripShowImageMargin();
				}
			}
			else
			{
				SetWinContextMenuStripShowCheckMargin();
			}
		}

		private void SetWinContextMenuStripShowImageMargin()
		{
			if (WebContextMenuStrip != null && WinContextMenuStrip != null)
			{
				WinContextMenuStrip.ShowImageMargin = WebContextMenuStrip.ShowImageMargin;
			}
		}

		private void SetWinContextMenuStripShowCheckMargin()
		{
			if (WebContextMenuStrip != null && WinContextMenuStrip != null)
			{
				WinContextMenuStrip.ShowCheckMargin = WebContextMenuStrip.ShowCheckMargin;
			}
		}

		protected override void SetWinControlBackColor()
		{
			if (WinContextMenuStrip != null && WebContextMenuStrip != null && WebContextMenuStrip.BackColor != Color.Transparent)
			{
				base.SetWinControlBackColor();
			}
		}
	}
}

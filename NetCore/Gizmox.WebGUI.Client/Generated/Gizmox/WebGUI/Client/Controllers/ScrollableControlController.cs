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
	public class ScrollableControlController : ControlController
	{
		public Gizmox.WebGUI.Forms.ScrollableControl WebScrollableControl => base.SourceObject as Gizmox.WebGUI.Forms.ScrollableControl;

		public System.Windows.Forms.ScrollableControl WinScrollableControl => base.TargetObject as System.Windows.Forms.ScrollableControl;

		public ScrollableControlController(IContext objContext, object objWebScrollableControl, object objWinScrollableControl)
			: base(objContext, objWebScrollableControl, objWinScrollableControl)
		{
		}

		public ScrollableControlController(IContext objContext, object objWebScrollableControl)
			: base(objContext, objWebScrollableControl)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinScrollableControlAutoScroll();
			SuspendNotifications();
			try
			{
				SetWinScrollableControlDockPadding();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetWinScrollableControlAutoScroll()
		{
			WinScrollableControl.AutoScroll = WebScrollableControl.AutoScroll;
		}

		protected void SetWinScrollableControlDockPadding()
		{
			WinScrollableControl.DockPadding.Bottom = WebScrollableControl.DockPadding.Bottom;
			WinScrollableControl.DockPadding.Top = WebScrollableControl.DockPadding.Top;
			WinScrollableControl.DockPadding.Right = WebScrollableControl.DockPadding.Right;
			WinScrollableControl.DockPadding.Left = WebScrollableControl.DockPadding.Left;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ScrollableControl();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DockPadding":
				SetWinScrollableControlDockPadding();
				break;
			case "AutoScroll":
				SetWinScrollableControlAutoScroll();
				break;
			case "Unknown":
				SetWinScrollableControlDockPadding();
				break;
			}
		}
	}
}

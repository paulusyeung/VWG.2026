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
	public class WorkspaceTabsController : TabControlController
	{
		public WorkspaceTabsController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public WorkspaceTabsController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			base.WinTabControl.ControlAdded += WinTabControl_ControlAdded;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			base.WinTabControl.ControlAdded -= WinTabControl_ControlAdded;
		}

		private void WinTabControl_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			if (e.Control == null || base.WinTabControl == null || base.WebTabControl == null)
			{
				return;
			}
			bool flag = false;
			StackTrace stackTrace = new StackTrace();
			if (stackTrace != null)
			{
				for (int i = 0; i < stackTrace.FrameCount; i++)
				{
					MethodBase method = stackTrace.GetFrame(i).GetMethod();
					if (method != null)
					{
						string name = method.Name;
						string fullName = method.DeclaringType.FullName;
						if (name == "InitializeNewComponent" && fullName == "System.Windows.Forms.Design.TabControlDesigner")
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				base.WinTabControl.Controls.Remove(e.Control);
				if (GetControllerByWinObject(e.Control) is TabPageController { WebTabPage: not null } tabPageController)
				{
					base.WebTabControl.TabPages.Remove(tabPageController.WebTabPage);
					base.DesignServices.UnregisterWebComponent(tabPageController.WebTabPage);
				}
			}
		}
	}
}

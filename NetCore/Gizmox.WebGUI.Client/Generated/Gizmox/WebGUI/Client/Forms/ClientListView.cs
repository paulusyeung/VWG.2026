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
	public class ClientListView : System.Windows.Forms.ListView, IContextContainer
	{
		private IContext mobjContext = null;

		IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}

		public ClientListView()
		{
			base.MouseUp += ClientListView_MouseUp;
			base.FullRowSelect = true;
		}

		private void ClientListView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right && GetItemAt(e.X, e.Y) is ClientListViewItem { ContextMenu: not null } clientListViewItem)
			{
				IContextServices contextServices = (IContextServices)((IContextContainer)this).Context;
				if (contextServices != null && contextServices.GetControllerByWinObject(clientListViewItem.ContextMenu) is ContextMenuController contextMenuController)
				{
					contextMenuController.SetTarget(clientListViewItem);
					clientListViewItem.ContextMenu.Show(this, new Point(e.X, e.Y));
				}
			}
		}
	}
}

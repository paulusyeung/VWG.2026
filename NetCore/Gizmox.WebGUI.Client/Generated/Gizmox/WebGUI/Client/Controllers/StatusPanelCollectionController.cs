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
	public class StatusPanelCollectionController : ComponentCollectionController
	{
		public System.Windows.Forms.StatusBar.StatusBarPanelCollection WebStatusPanelItems => base.WebObjects as System.Windows.Forms.StatusBar.StatusBarPanelCollection;

		public System.Windows.Forms.StatusBar.StatusBarPanelCollection WinStatusPanelItems => base.WebObjects as System.Windows.Forms.StatusBar.StatusBarPanelCollection;

		public System.Windows.Forms.StatusBar WebStatusBar => base.SourceObject as System.Windows.Forms.StatusBar;

		public System.Windows.Forms.StatusBar WinStatusBar => base.TargetObject as System.Windows.Forms.StatusBar;

		public StatusPanelCollectionController(IContext objContext, object objWebTreeNode, IList objWebTreeNodes, object objWinTreeNode, IList objWinTreeNodes)
			: base(objContext, objWebTreeNode, objWebTreeNodes, objWinTreeNode, objWinTreeNodes)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new StatusBarPanelController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.StatusBarPanel();
		}
	}
}



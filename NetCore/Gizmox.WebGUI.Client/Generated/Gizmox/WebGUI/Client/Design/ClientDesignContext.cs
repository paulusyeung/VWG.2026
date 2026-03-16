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

namespace Gizmox.WebGUI.Client.Design
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClientDesignContext
	{
		public static IContext CreateContext(IClientDesignServices objDesignServices)
		{
			return new Context(objDesignServices);
		}

		public static IClientObjectController CreateMenuController(IContext objContext, IComponent objWebComponent)
		{
			if (objWebComponent is System.Windows.Forms.ContextMenu)
			{
				return new ContextMenuController(objContext, objWebComponent);
			}
			if (objWebComponent is System.Windows.Forms.MenuItem)
			{
				return new MenuItemController(objContext, objWebComponent);
			}
			if (objWebComponent is System.Windows.Forms.MainMenu)
			{
				return new MainMenuController(objContext, objWebComponent);
			}
			return CreateControllerByWebObject(objContext, objWebComponent);
		}

		public static IClientObjectController CreateControllerByWebObject(IContext objContext, object objWebObject)
		{
			return ObjectController.CreateControllerByWebObject(objContext, objWebObject);
		}
	}
}


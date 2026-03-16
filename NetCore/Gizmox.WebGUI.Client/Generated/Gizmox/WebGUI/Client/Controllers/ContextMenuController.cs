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
	public class ContextMenuController : MenuController
	{
		private MenuItemCollectionController mobjMenuItemCollectionController = null;

		private object mobjTarget = null;

		public System.Windows.Forms.ContextMenu WebContextMenu => base.SourceObject as System.Windows.Forms.ContextMenu;

		public System.Windows.Forms.ContextMenu WinContextMenu => base.TargetObject as System.Windows.Forms.ContextMenu;

		public ContextMenuController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebContextMenu, WebContextMenu.MenuItems, WinContextMenu, WinContextMenu.MenuItems);
		}

		public ContextMenuController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebContextMenu, WebContextMenu.MenuItems, WinContextMenu, WinContextMenu.MenuItems);
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
		}

		protected override void InitializedContained()
		{
			mobjMenuItemCollectionController.Initialize();
		}

		public virtual void SetTarget(object objWinObject)
		{
			mobjTarget = objWinObject;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "VWGNullProperty" && mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.SetWebObjectObjects();
			}
		}

		public object GetTarget()
		{
			return mobjTarget;
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Terminate();
			}
		}
	}
}



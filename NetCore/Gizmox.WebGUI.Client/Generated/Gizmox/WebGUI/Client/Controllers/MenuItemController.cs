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
	public class MenuItemController : MenuController
	{
		private MenuItemCollectionController mobjMenuItemCollectionController = null;

		public System.Windows.Forms.MenuItem WebMenuItem => base.SourceObject as System.Windows.Forms.MenuItem;

		public System.Windows.Forms.MenuItem WinMenuItem => base.TargetObject as System.Windows.Forms.MenuItem;

		public MenuItemController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebMenuItem, WebMenuItem.MenuItems, WinMenuItem, WinMenuItem.MenuItems);
		}

		public MenuItemController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebMenuItem, WebMenuItem.MenuItems, WinMenuItem, WinMenuItem.MenuItems);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "Text"))
			{
				if (property == "Index")
				{
					SetWinMenuItemIndex(blnFireWinComponentChanged: true);
				}
			}
			else
			{
				SetWinMenuItemText(blnFireWinComponentChanged: true);
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWebMenuItemText();
				break;
			case "Index":
				SetWebMenuItemIndex();
				break;
			case "VWGNullProperty":
				if (mobjMenuItemCollectionController != null)
				{
					mobjMenuItemCollectionController.SetWebObjectObjects();
				}
				break;
			}
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebMenuItemText();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinMenuItemText();
			SetWinMenuItemIndex();
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebMenuItemIndex();
		}

		protected override void InitializedContained()
		{
			mobjMenuItemCollectionController.Initialize();
		}

		private void SetWinMenuItemIndex(bool blnFireWinComponentChanged)
		{
			if (blnFireWinComponentChanged)
			{
				SetWinProperty("Index", WebMenuItem.Index);
			}
			else
			{
				WinMenuItem.Index = WebMenuItem.Index;
			}
		}

		private void SetWinMenuItemText(bool blnFireWinComponentChanged)
		{
			if (blnFireWinComponentChanged)
			{
				SetWinProperty("Text", WebMenuItem.Text);
			}
			else
			{
				WinMenuItem.Text = WebMenuItem.Text;
			}
		}

		protected virtual void SetWinMenuItemIndex()
		{
			SetWinMenuItemIndex(blnFireWinComponentChanged: false);
		}

		protected virtual void SetWebMenuItemText()
		{
			SetWebProperty("Text", WinMenuItem.Text);
		}

		protected virtual void SetWebMenuItemIndex()
		{
			SetWebProperty("Index", WinMenuItem.Index);
		}

		protected virtual void SetWinMenuItemText()
		{
			SetWinMenuItemText(blnFireWinComponentChanged: false);
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinMenuItem.Click += WinMenuItem_Click;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinMenuItem.Click -= WinMenuItem_Click;
		}

		private void WinMenuItem_Click(object sender, EventArgs e)
		{
			if (GetControllerByWinObject(sender) is MenuItemController menuItemController)
			{
				Event obj = CreateWebEvent("MenuClick", GetParentOwner(menuItemController.WebMenuItem), menuItemController.WebMenuItem);
				obj.Fire();
			}
		}

		private object GetParentOwner(System.Windows.Forms.MenuItem objMenu)
		{
			if (objMenu.Parent != null)
			{
				if (objMenu.Parent is System.Windows.Forms.ContextMenu)
				{
					if (GetControllerByWebObject(objMenu.Parent) is ContextMenuController contextMenuController && contextMenuController.GetTarget() != null)
					{
						return GetWebObject(contextMenuController.GetTarget());
					}
					return objMenu.Parent.InternalParent;
				}
				if (objMenu.Parent is System.Windows.Forms.MenuItem)
				{
					return GetParentOwner((System.Windows.Forms.MenuItem)objMenu.Parent);
				}
				return null;
			}
			return objMenu.InternalParent;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.MenuItem();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (WinMenuItem != null && WinMenuItem.Parent != null && WinMenuItem.Parent.MenuItems.Contains(WinMenuItem))
			{
				try
				{
					SuspendNotifications();
					WinMenuItem.Parent.MenuItems.Remove(WinMenuItem);
				}
				finally
				{
					ResumeNotifications();
				}
			}
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Terminate();
			}
		}
	}
}



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
	public class ListViewItemController : ComponentController
	{
		private ContextMenuController mobjContextMenuController = null;

		private ListViewSubItemCollectionController mobjListViewSubItemCollectionController = null;

		public Gizmox.WebGUI.Forms.ListViewItem WebListViewItem => base.SourceObject as Gizmox.WebGUI.Forms.ListViewItem;

		public ClientListViewItem WinListViewItem => base.TargetObject as ClientListViewItem;

		protected new ContextMenuController ContextMenuController
		{
			get
			{
				if (mobjContextMenuController == null && base.WebComponent != null && base.WebComponent.ContextMenu != null)
				{
					mobjContextMenuController = GetControllerByWebObject(base.WebComponent.ContextMenu) as ContextMenuController;
					if (mobjContextMenuController == null)
					{
						System.Windows.Forms.ContextMenu objWinControl = new System.Windows.Forms.ContextMenu();
						mobjContextMenuController = new ContextMenuController(base.Context, base.WebComponent.ContextMenu, objWinControl);
						mobjContextMenuController.Initialize();
						RegisterController(mobjContextMenuController);
					}
				}
				return mobjContextMenuController;
			}
		}

		public ListViewItemController(IContext objContext, object objWebListViewItem, object objWinListViewItem)
			: base(objContext, objWebListViewItem, objWinListViewItem)
		{
			mobjListViewSubItemCollectionController = new ListViewSubItemCollectionController(objContext, WebListViewItem, WebListViewItem.SubItems, WinListViewItem, WinListViewItem.SubItems);
		}

		public ListViewItemController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjListViewSubItemCollectionController = new ListViewSubItemCollectionController(objContext, WebListViewItem, WebListViewItem.SubItems, WinListViewItem, WinListViewItem.SubItems);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinListViewItemText();
			SetWinListViewItemForeColor();
			SetWinListViewItemBackColor();
			SetWinListViewItemSubItems();
			SetWinListViewItemContextMenu();
			SetWinListViewItemGroup();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinListViewItemText();
			SetWinListViewItemForeColor();
			SetWinListViewItemBackColor();
			SetWinListViewItemImageIndex();
			SetWinListViewItemImageKey();
			SetWinListViewItemContextMenu();
			SetWinListViewItemGroup();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinListViewItemText();
			SetWinListViewItemForeColor();
			SetWinListViewItemBackColor();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinListViewItemText();
				break;
			case "SubItems":
				SetWinListViewItemSubItems();
				break;
			case "ImageKey":
				SetWinListViewItemImageKey();
				break;
			case "ImageIndex":
				SetWinListViewItemImageIndex();
				break;
			case "Group":
				SetWinListViewItemGroup();
				break;
			case "BackColor":
				SetWinListViewItemBackColor();
				break;
			case "ForeColor":
				SetWinListViewItemForeColor();
				break;
			}
		}

		private void SetWinListViewItemImageIndex()
		{
			if (WebListViewItem.ImageIndex != -1)
			{
				if (WinListViewItem.ListView != null)
				{
					if (WinListViewItem.ListView.SmallImageList == null)
					{
						WinListViewItem.ListView.SmallImageList = new System.Windows.Forms.ImageList();
					}
					WinListViewItem.ImageIndex = GetWinImageIndex(WinListViewItem.ListView.SmallImageList, WebListViewItem.SmallImage);
				}
			}
			else if (WinListViewItem.ImageIndex != -1)
			{
				WinListViewItem.ImageIndex = -1;
			}
		}

		private void SetWinListViewItemImageKey()
		{
			if (WebListViewItem.ImageKey != string.Empty)
			{
				if (WinListViewItem.ListView != null)
				{
					if (WinListViewItem.ListView.SmallImageList == null)
					{
						WinListViewItem.ListView.SmallImageList = new System.Windows.Forms.ImageList();
					}
					if (GetWinImageIndex(WinListViewItem.ListView.SmallImageList, WebListViewItem.SmallImage, WebListViewItem.ImageKey) > -1)
					{
						WinListViewItem.ImageKey = WebListViewItem.ImageKey;
					}
					else if (WinListViewItem.ImageKey != string.Empty)
					{
						WinListViewItem.ImageKey = string.Empty;
					}
				}
			}
			else if (WinListViewItem.ImageKey != string.Empty)
			{
				WinListViewItem.ImageKey = string.Empty;
			}
		}

		private void SetWebListViewItemImageIndex()
		{
			WebListViewItem.ImageIndex = WinListViewItem.ImageIndex;
		}

		private void SetWebListViewItemImageKey()
		{
			WebListViewItem.ImageKey = WinListViewItem.ImageKey;
		}

		private void SetWinListViewItemSubItems()
		{
			mobjListViewSubItemCollectionController.SetWinObjectObjects();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWebListViewItemText();
				break;
			case "SubItems":
				SetWebListViewItemSubItems();
				break;
			case "ImageKey":
				SetWebListViewItemImageKey();
				break;
			case "ImageIndex":
				SetWebListViewItemImageIndex();
				break;
			}
		}

		private void SetWebListViewItemSubItems()
		{
			mobjListViewSubItemCollectionController.SetWebObjectObjects();
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebListViewItemText();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjListViewSubItemCollectionController.Initialize();
		}

		protected virtual void SetWinListViewItemContextMenu()
		{
			if (ContextMenuController != null)
			{
				WinListViewItem.ContextMenu = ContextMenuController.WinContextMenu;
			}
		}

		protected virtual void SetWinListViewItemGroup()
		{
			if (WebListViewItem.Group != null)
			{
				ObjectController controllerByWebObject = GetControllerByWebObject(WebListViewItem.Group);
				if (controllerByWebObject != null)
				{
					WinListViewItem.Group = controllerByWebObject.TargetObject as System.Windows.Forms.ListViewGroup;
				}
			}
			else
			{
				WinListViewItem.Group = null;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientListViewItem();
		}

		protected virtual void SetWinListViewItemText()
		{
			WinListViewItem.Text = WebListViewItem.Text;
		}

		protected virtual void SetWinListViewItemBackColor()
		{
			WinListViewItem.BackColor = WebListViewItem.BackColor;
		}

		protected virtual void SetWinListViewItemForeColor()
		{
			WinListViewItem.ForeColor = WebListViewItem.ForeColor;
		}

		protected virtual void SetWebListViewItemText()
		{
			WebListViewItem.Text = WinListViewItem.Text;
		}
	}
}



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
	public class TreeNodeController : ComponentController
	{
		private TreeNodeCollectionController mobjTreeNodesController = null;

		private ContextMenuController mobjContextMenuController = null;

		public Gizmox.WebGUI.Forms.TreeNode WebTreeNode => base.SourceObject as Gizmox.WebGUI.Forms.TreeNode;

		public ClientTreeNode WinTreeNode => base.TargetObject as ClientTreeNode;

		public new Gizmox.WebGUI.Forms.Component WebComponent => base.SourceObject as Gizmox.WebGUI.Forms.Component;

		protected new ContextMenuController ContextMenuController
		{
			get
			{
				if (mobjContextMenuController == null && WebComponent != null && WebComponent.ContextMenu != null)
				{
					System.Windows.Forms.ContextMenu objWinControl = new System.Windows.Forms.ContextMenu();
					mobjContextMenuController = new ContextMenuController(base.Context, WebComponent.ContextMenu, objWinControl);
					mobjContextMenuController.Initialize();
				}
				return mobjContextMenuController;
			}
		}

		public TreeNodeController(IContext objContext, object objWebTreeNode, object objWinTreeNode)
			: base(objContext, objWebTreeNode, objWinTreeNode)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, WebTreeNode, WebTreeNode.Nodes, WinTreeNode, WinTreeNode.Nodes);
		}

		public TreeNodeController(IContext objContext, object objWebTreeNode)
			: base(objContext, objWebTreeNode)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, WebTreeNode, WebTreeNode.Nodes, WinTreeNode, WinTreeNode.Nodes);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ImageIndex":
				SetWinTreeNodeImageIndex();
				break;
			case "ImageKey":
				SetWinTreeNodeImageKey();
				break;
			case "Text":
				SetWinTreeNodeText();
				break;
			}
		}

		private void SetWinTreeNodeImageKey()
		{
			if (WebTreeNode.ImageKey != string.Empty)
			{
				if (WinTreeNode.TreeView != null)
				{
					if (WinTreeNode.TreeView.ImageList == null)
					{
						WinTreeNode.TreeView.ImageList = new System.Windows.Forms.ImageList();
					}
					if (GetWinImageIndex(WinTreeNode.TreeView.ImageList, WebTreeNode.Image, WebTreeNode.ImageKey) > -1)
					{
						WinTreeNode.ImageKey = WebTreeNode.ImageKey;
					}
				}
			}
			else
			{
				WinTreeNode.ImageKey = string.Empty;
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTreeNodeText();
			SetWinTreeNodeHasNodes();
			SetWinTreeNodeContextMenu();
			SetWinTreeNodeImageIndex();
			SetWinTreeNodeImageKey();
		}

		protected override void InitializedContained()
		{
			mobjTreeNodesController.Initialize();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientTreeNode();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjTreeNodesController != null)
			{
				mobjTreeNodesController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjTreeNodesController != null)
			{
				mobjTreeNodesController.Terminate();
			}
		}

		protected virtual void SetWinTreeNodeContextMenu()
		{
			if (ContextMenuController != null)
			{
				WinTreeNode.ContextMenu = ContextMenuController.WinContextMenu;
			}
		}

		protected virtual void SetWinTreeNodeText()
		{
			WinTreeNode.Text = WebTreeNode.Text;
		}

		protected virtual void SetWinTreeNodeHasNodes()
		{
			WinTreeNode.HasNodes = WebTreeNode.HasNodes;
		}

		protected virtual void SetWinTreeNodeImageIndex()
		{
			if (WebTreeNode.ImageIndex != -1)
			{
				if (WinTreeNode.TreeView != null)
				{
					if (WinTreeNode.TreeView.ImageList == null)
					{
						WinTreeNode.TreeView.ImageList = new System.Windows.Forms.ImageList();
					}
					WinTreeNode.ImageIndex = GetWinImageIndex(WinTreeNode.TreeView.ImageList, WebTreeNode.Image);
				}
			}
			else if (WinTreeNode.ImageIndex != -1)
			{
				WinTreeNode.ImageIndex = -1;
			}
		}
	}
}



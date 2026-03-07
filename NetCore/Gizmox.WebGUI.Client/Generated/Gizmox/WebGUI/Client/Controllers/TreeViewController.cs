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
	public class TreeViewController : ControlController
	{
		private TreeNodeCollectionController mobjTreeNodesController = null;

		public Gizmox.WebGUI.Forms.TreeView WebTreeView => base.SourceObject as Gizmox.WebGUI.Forms.TreeView;

		public System.Windows.Forms.TreeView WinTreeView => base.TargetObject as System.Windows.Forms.TreeView;

		public TreeViewController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, objWebTreeView, WebTreeView.Nodes, WinTreeView, WinTreeView.Nodes);
		}

		public TreeViewController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, objWebTreeView, WebTreeView.Nodes, WinTreeView, WinTreeView.Nodes);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTreeViewCheckBoxes();
			SetWinTreeViewShowLines();
			SetWinNodes();
			SetWinTreeViewImageIndex();
			SetWinTreeViewImageKey();
			SetWinTreeViewItemHeight();
		}

		protected virtual void SetWinTreeViewCheckBoxes()
		{
			WinTreeView.CheckBoxes = WebTreeView.CheckBoxes;
		}

		protected virtual void SetWinTreeViewShowLines()
		{
			WinTreeView.ShowLines = WebTreeView.ShowLines;
		}

		protected override void SetWinControlBorderStyle()
		{
			WinTreeView.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebTreeView.BorderStyle, WinTreeView.BorderStyle);
		}

		protected override void InitializedContained()
		{
			WinTreeView.BeginUpdate();
			WinTreeView.SuspendLayout();
			mobjTreeNodesController.Initialize();
			if (GetWinObject(WebTreeView.SelectedNode) is System.Windows.Forms.TreeNode selectedNode)
			{
				WinTreeView.SelectedNode = selectedNode;
			}
			WinTreeView.EndUpdate();
			WinTreeView.ResumeLayout();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "CheckBoxes":
				SetWinTreeViewCheckBoxes();
				break;
			case "ShowLines":
				SetWinTreeViewShowLines();
				break;
			case "Nodes":
				SetWinNodes();
				break;
			case "ImageIndex":
				SetWinTreeViewImageIndex();
				break;
			case "ImageKey":
				SetWinTreeViewImageKey();
				break;
			case "ItemHeight":
				SetWinTreeViewItemHeight();
				break;
			}
		}

		private void SetWinTreeViewItemHeight()
		{
			if (WebTreeView.HasItemHeight)
			{
				WinTreeView.ItemHeight = WebTreeView.ItemHeight;
			}
			else
			{
				typeof(System.Windows.Forms.TreeView).GetMethod("ResetItemHeight", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod).Invoke(WinTreeView, null);
			}
		}

		private void SetWinTreeViewImageIndex()
		{
			WinTreeView.ImageIndex = WebTreeView.ImageIndex;
		}

		private void SetWinTreeViewImageKey()
		{
			WinTreeView.ImageKey = WebTreeView.ImageKey;
		}

		private void SetWinNodes()
		{
			mobjTreeNodesController.SetWinObjectObjects();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientTreeView();
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

		protected override void WireEvents()
		{
			base.WireEvents();
			WinTreeView.BeforeSelect += WinTreeView_BeforeSelect;
			WinTreeView.AfterSelect += WebTreeView_AfterSelect;
			WinTreeView.BeforeExpand += WebTreeView_BeforeExpand;
		}

		private void WebTreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if (GetControllerByWinObject(e.Node) is TreeNodeController treeNodeController)
			{
				Event obj = CreateWebEvent("Expand", treeNodeController.SourceObject);
				obj.Fire();
				if (treeNodeController.WinTreeNode.HasDummyNodes)
				{
					treeNodeController.Initialize();
				}
			}
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinTreeView.BeforeSelect -= WinTreeView_BeforeSelect;
			WinTreeView.AfterSelect -= WebTreeView_AfterSelect;
			WinTreeView.BeforeExpand -= WebTreeView_BeforeExpand;
		}

		private void WinTreeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			ObjectController controllerByWinObject = GetControllerByWinObject(e.Node);
			if (controllerByWinObject != null)
			{
				Event obj = CreateWebEvent("Action", controllerByWinObject.SourceObject);
				obj.SetParameter("Action", "Click");
				obj.Fire();
			}
		}

		private void WebTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			ObjectController controllerByWinObject = GetControllerByWinObject(e.Node);
			if (controllerByWinObject != null)
			{
				Event obj = CreateWebEvent("Action", controllerByWinObject.SourceObject);
				obj.SetParameter("Action", "Click");
				obj.Fire();
			}
		}
	}
}

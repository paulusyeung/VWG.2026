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
	public class TreeNodeCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.TreeNodeCollection WebTreeNodes => base.WebObjects as Gizmox.WebGUI.Forms.TreeNodeCollection;

		public Gizmox.WebGUI.Forms.TreeNode WebTreeNode => base.SourceObject as Gizmox.WebGUI.Forms.TreeNode;

		public Gizmox.WebGUI.Forms.TreeView WebTreeView => base.SourceObject as Gizmox.WebGUI.Forms.TreeView;

		public System.Windows.Forms.TreeNodeCollection WinTreeNodes => base.WinObjects as System.Windows.Forms.TreeNodeCollection;

		public ClientTreeNode WinTreeNode => base.TargetObject as ClientTreeNode;

		public ClientTreeView WinTreeView => base.TargetObject as ClientTreeView;

		public TreeNodeCollectionController(IContext objContext, object objWebObject, IList objWebTreeNodes, object objWinObject, IList objWinTreeNodes)
			: base(objContext, objWebObject, objWebTreeNodes, objWinObject, objWinTreeNodes)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new TreeNodeController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientTreeNode();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}
	}
}

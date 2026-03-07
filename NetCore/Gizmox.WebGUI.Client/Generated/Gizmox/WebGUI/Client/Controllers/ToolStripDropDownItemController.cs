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
	public class ToolStripDropDownItemController : ToolStripItemController
	{
		private ToolStripItemCollectionController mobjToolStripItemCollectionController = null;

		public Gizmox.WebGUI.Forms.ToolStripDropDownItem WebToolStripDropDownItem => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripDropDownItem;

		public System.Windows.Forms.ToolStripDropDownItem WinToolStripDropDownItem => base.TargetObject as System.Windows.Forms.ToolStripDropDownItem;

		public ToolStripDropDownItemController(IContext objContext, object objWebToolStripDropDownItem, object objWinToolStripDropDownItem)
			: base(objContext, objWebToolStripDropDownItem, objWinToolStripDropDownItem)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStripDropDownItem, WebToolStripDropDownItem.DropDownItems, WinToolStripDropDownItem, WinToolStripDropDownItem.DropDownItems);
		}

		public ToolStripDropDownItemController(IContext objContext, object objWebToolStripDropDownItem)
			: base(objContext, objWebToolStripDropDownItem)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStripDropDownItem, WebToolStripDropDownItem.DropDownItems, WinToolStripDropDownItem, WinToolStripDropDownItem.DropDownItems);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return null;
		}

		protected override void InitializedContained()
		{
			mobjToolStripItemCollectionController.Initialize();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjToolStripItemCollectionController != null)
			{
				mobjToolStripItemCollectionController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjToolStripItemCollectionController != null)
			{
				mobjToolStripItemCollectionController.Terminate();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "DropDownItems")
			{
				SetWinToolStripDropDownItemDropDownItems();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "DropDownItems")
			{
				SetWebToolStripDropDownItemDropDownItems();
			}
		}

		private void SetWinToolStripDropDownItemDropDownItems()
		{
			mobjToolStripItemCollectionController.SetWinObjectObjects();
		}

		private void SetWebToolStripDropDownItemDropDownItems()
		{
			mobjToolStripItemCollectionController.SetWebObjectObjects();
		}
	}
}

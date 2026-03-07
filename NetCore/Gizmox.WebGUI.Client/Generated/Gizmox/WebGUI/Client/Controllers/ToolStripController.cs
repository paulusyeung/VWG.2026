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
	public class ToolStripController : ScrollableControlController
	{
		private ToolStripItemCollectionController mobjToolStripItemCollectionController = null;

		public Gizmox.WebGUI.Forms.ToolStrip WebToolStrip => base.SourceObject as Gizmox.WebGUI.Forms.ToolStrip;

		public System.Windows.Forms.ToolStrip WinToolStrip => base.TargetObject as System.Windows.Forms.ToolStrip;

		public ToolStripController(IContext objContext, object objWebToolStrip, object objWinToolStrip)
			: base(objContext, objWebToolStrip, objWinToolStrip)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStrip, WebToolStrip.Items, WinToolStrip, WinToolStrip.Items);
		}

		public ToolStripController(IContext objContext, object objWebToolStrip)
			: base(objContext, objWebToolStrip)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStrip, WebToolStrip.Items, WinToolStrip, WinToolStrip.Items);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStrip();
		}

		protected override void SetWinScrollableControlAutoScroll()
		{
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
			switch (objPropertyChangeArgs.Property)
			{
			case "Items":
				SetWinToolStripItems();
				break;
			case "GripStyle":
				SetWinToolStripGripStyle();
				break;
			case "CanOverflow":
				SetWinToolStripCanOverflow();
				break;
			case "ImageScalingSize":
				SetWinToolStripImageScalingSize();
				break;
			}
		}

		private void SetWinToolStripImageScalingSize()
		{
			if (WinToolStrip != null && WebToolStrip != null)
			{
				WinToolStrip.ImageScalingSize = WebToolStrip.ImageScalingSize;
			}
		}

		private void SetWinToolStripCanOverflow()
		{
			if (WinToolStrip != null && WebToolStrip != null)
			{
				WinToolStrip.CanOverflow = WebToolStrip.CanOverflow;
			}
		}

		private void SetWinToolStripGripStyle()
		{
			if (WinToolStrip != null && WebToolStrip != null)
			{
				WinToolStrip.GripStyle = (System.Windows.Forms.ToolStripGripStyle)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripGripStyle), WebToolStrip.GripStyle);
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Items")
			{
				SetWebToolStripItems();
			}
		}

		private void SetWinToolStripItems()
		{
			mobjToolStripItemCollectionController.SetWinObjectObjects();
		}

		private void SetWebToolStripItems()
		{
			mobjToolStripItemCollectionController.SetWebObjectObjects();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripItems();
			SetWinToolStripCanOverflow();
			SetWinToolStripImageScalingSize();
		}
	}
}

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
	public class PropertyGridController : ControlController
	{
		public Gizmox.WebGUI.Forms.PropertyGrid WebPropertyGrid => base.SourceObject as Gizmox.WebGUI.Forms.PropertyGrid;

		public System.Windows.Forms.PropertyGrid WinPropertyGrid => base.TargetObject as System.Windows.Forms.PropertyGrid;

		public PropertyGridController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public PropertyGridController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinPropertyGridSelectedObjects();
			SetWinPropertyGridHelpVisible();
			SetWinPropertyGridPropertySort();
		}

		protected virtual void SetWinPropertyGridHelpVisible()
		{
			WinPropertyGrid.HelpVisible = WebPropertyGrid.HelpVisible;
		}

		protected virtual void SetWinPropertyGridSelectedObjects()
		{
			WinPropertyGrid.SelectedObjects = WebPropertyGrid.SelectedObjects;
		}

		private void SetWinPropertyGridPropertySort()
		{
			WinPropertyGrid.PropertySort = (System.Windows.Forms.PropertySort)GetConvertedEnum(typeof(System.Windows.Forms.PropertySort), WebPropertyGrid.PropertySort);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.PropertyGrid();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "SelectedObjects":
				SetWinPropertyGridSelectedObjects();
				break;
			case "SelectedObject":
				SetWinPropertyGridSelectedObjects();
				break;
			case "HelpVisible":
				SetWinPropertyGridHelpVisible();
				break;
			case "PropertySort":
				SetWinPropertyGridPropertySort();
				break;
			}
		}
	}
}

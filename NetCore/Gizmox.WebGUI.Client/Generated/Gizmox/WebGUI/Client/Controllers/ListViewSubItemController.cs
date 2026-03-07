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
	public class ListViewSubItemController : ComponentController
	{
		private ContextMenuController mobjContextMenuController = null;

		public Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem WebListViewSubItem => base.SourceObject as Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem;

		public System.Windows.Forms.ListViewItem.ListViewSubItem WinListViewSubItem => base.TargetObject as System.Windows.Forms.ListViewItem.ListViewSubItem;

		public ListViewSubItemController(IContext objContext, object objWebListViewSubItem, object objWinListViewSubItem)
			: base(objContext, objWebListViewSubItem, objWinListViewSubItem)
		{
		}

		public ListViewSubItemController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinListViewSubItemText();
			SetWinListViewSubItemForeColor();
			SetWinListViewSubItemBackColor();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinListViewSubItemText();
			SetWinListViewSubItemForeColor();
			SetWinListViewSubItemBackColor();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinListViewSubItemText();
				break;
			case "BackColor":
				SetWinListViewSubItemBackColor();
				break;
			case "ForeColor":
				SetWinListViewSubItemForeColor();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebListViewSubItemText();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebListViewSubItemText();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListViewItem.ListViewSubItem();
		}

		protected virtual void SetWinListViewSubItemText()
		{
			WinListViewSubItem.Text = WebListViewSubItem.Text;
		}

		protected virtual void SetWebListViewSubItemText()
		{
			WebListViewSubItem.Text = WinListViewSubItem.Text;
		}

		protected virtual void SetWinListViewSubItemBackColor()
		{
			WinListViewSubItem.BackColor = WebListViewSubItem.BackColor;
		}

		protected virtual void SetWinListViewSubItemForeColor()
		{
			WinListViewSubItem.ForeColor = WebListViewSubItem.ForeColor;
		}
	}
}

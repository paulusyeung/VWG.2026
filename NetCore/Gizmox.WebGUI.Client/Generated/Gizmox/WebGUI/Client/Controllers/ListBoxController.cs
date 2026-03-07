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
	public class ListBoxController : ListControlController
	{
		private ItemsCollectionController mobjItemsCollectionController = null;

		public Gizmox.WebGUI.Forms.ListBox WebListBox => base.SourceObject as Gizmox.WebGUI.Forms.ListBox;

		public System.Windows.Forms.ListBox WinListBox => base.TargetObject as System.Windows.Forms.ListBox;

		public ListBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebListBox, WebListBox.Items, WinListBox, WinListBox.Items);
		}

		public ListBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebListBox, WebListBox.Items, WinListBox, WinListBox.Items);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjItemsCollectionController.Initialize();
			SetWinListBoxDataSource();
			SetWinListBoxItems();
		}

		protected virtual void SetWinListBoxDataSource()
		{
			if (WebListBox.DataSource != null)
			{
				WinListBox.DisplayMember = WebListBox.DisplayMember;
				WinListBox.DataSource = WebListBox.DataSource;
			}
		}

		protected virtual void SetSorted()
		{
			if (WebListBox != null && WinListBox != null)
			{
				WinListBox.Sorted = WebListBox.Sorted;
			}
		}

		protected virtual void SetWinListBoxItems()
		{
			if (WebListBox.DataSource != null)
			{
				return;
			}
			WinListBox.Items.Clear();
			foreach (object item in WebListBox.Items)
			{
				WinListBox.Items.Add(item);
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinListBox.SelectedIndexChanged += WinListBox_SelectedIndexChanged;
		}

		private void WinListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int selectedIndex in WinListBox.SelectedIndices)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(selectedIndex.ToString());
			}
			Event obj = CreateWebEvent("SelectionChange");
			obj.SetParameter("Indexes", stringBuilder.ToString());
			obj.SetParameter("Incremental", "0");
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinListBox.SelectedIndexChanged -= WinListBox_SelectedIndexChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DataSource":
				SetWinListBoxDataSource();
				break;
			case "Items":
				SetWinListBoxItems();
				break;
			case "Sorted":
				SetSorted();
				break;
			}
		}
	}
}

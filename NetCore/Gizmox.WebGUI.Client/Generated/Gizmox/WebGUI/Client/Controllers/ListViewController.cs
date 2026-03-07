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
	public class ListViewController : ControlController
	{
		private ListViewColumnHeaderCollectionController mobjColumnHeaderCollectionController = null;

		private ListViewItemCollectionController mobjItemCollectionController = null;

		private ListViewGroupCollectionController mobjGroupCollectionController = null;

		public Gizmox.WebGUI.Forms.ListView WebListView => base.SourceObject as Gizmox.WebGUI.Forms.ListView;

		public System.Windows.Forms.ListView WinListView => base.TargetObject as System.Windows.Forms.ListView;

		public ListViewController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjColumnHeaderCollectionController = new ListViewColumnHeaderCollectionController(base.Context, WebListView, WebListView.Columns, WinListView, WinListView.Columns);
			mobjItemCollectionController = new ListViewItemCollectionController(base.Context, WebListView, WebListView.Items, WinListView, WinListView.Items);
			mobjGroupCollectionController = new ListViewGroupCollectionController(base.Context, WebListView, WebListView.Groups, WinListView, WinListView.Groups);
		}

		public ListViewController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjColumnHeaderCollectionController = new ListViewColumnHeaderCollectionController(base.Context, WebListView, WebListView.Columns, WinListView, WinListView.Columns);
			mobjItemCollectionController = new ListViewItemCollectionController(base.Context, WebListView, WebListView.Items, WinListView, WinListView.Items);
			mobjGroupCollectionController = new ListViewGroupCollectionController(base.Context, WebListView, WebListView.Groups, WinListView, WinListView.Groups);
		}

		protected override void InitializedContained()
		{
			mobjColumnHeaderCollectionController.Initialize();
			mobjGroupCollectionController.Initialize();
			mobjItemCollectionController.Initialize();
		}

		protected override void InitializeController()
		{
			SetWinListViewView();
			base.InitializeController();
			SetWinListViewCheckBoxes();
			SetWinListViewScrollable();
			SetWinGroups();
			SetWinShowGroups();
			SetWinGridLines();
			SetWinItems();
		}

		protected virtual void SetWinShowGroups()
		{
			WinListView.ShowGroups = WebListView.ShowGroups;
		}

		protected virtual void SetWinListViewView()
		{
			object convertedEnum = GetConvertedEnum(typeof(System.Windows.Forms.View), WebListView.View);
			if (convertedEnum != null)
			{
				WinListView.View = (System.Windows.Forms.View)convertedEnum;
			}
		}

		protected override void SetWinControlBorderStyle()
		{
			WinListView.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebListView.BorderStyle, WinListView.BorderStyle);
		}

		protected virtual void SetWebListViewScrollable()
		{
			WebListView.Scrollable = WinListView.Scrollable;
		}

		protected virtual void SetWinListViewCheckBoxes()
		{
			WinListView.CheckBoxes = WebListView.CheckBoxes;
		}

		protected virtual void SetWebListViewColumnHeaderWidth(Gizmox.WebGUI.Forms.ColumnHeader objWebColumnHeader, System.Windows.Forms.ColumnHeader objWinColumnHeader)
		{
			try
			{
				SuspendNotifications();
				objWebColumnHeader.Width = Convert.ToInt32((float)objWinColumnHeader.Width / base.TargetHorizontalScaleFactor);
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "CheckBoxes":
				SetWinListViewCheckBoxes();
				break;
			case "Columns":
				InitializedContained();
				break;
			case "Scrollable":
				SetWinListViewScrollable();
				break;
			case "View":
				SetWinListViewView();
				break;
			case "Items":
				SetWinItems();
				break;
			case "ShowGroups":
				SetWinShowGroups();
				break;
			case "GridLines":
				SetWinGridLines();
				break;
			case "Groups":
				SetWinGroups();
				break;
			}
		}

		private void SetWinGridLines()
		{
			WinListView.GridLines = WebListView.GridLines;
		}

		private void SetWinGroups()
		{
			mobjGroupCollectionController.SetWinObjectObjects();
		}

		private void SetWebGroups()
		{
			mobjGroupCollectionController.SetWebObjectObjects();
		}

		private void SetWinItems()
		{
			mobjItemCollectionController.SetWinObjectObjects();
		}

		private void SetWebItems()
		{
			mobjItemCollectionController.SetWebObjectObjects();
		}

		private void SetWinListViewScrollable()
		{
			WinListView.Scrollable = WebListView.Scrollable;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Scrollable":
				SetWebListViewScrollable();
				break;
			case "View":
				SetWebListViewView();
				break;
			case "Items":
				SetWebItems();
				break;
			}
		}

		private void SetWebListViewView()
		{
			WebListView.View = (Gizmox.WebGUI.Forms.View)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.View), WinListView.View);
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinListView.SelectedIndexChanged += WinListView_SelectedIndexChanged;
			WinListView.DoubleClick += WinListView_DoubleClick;
		}

		private void WinListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int selectedIndex in WinListView.SelectedIndices)
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

		private void WinListView_DoubleClick(object sender, EventArgs e)
		{
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinListView.SelectedIndexChanged -= WinListView_SelectedIndexChanged;
			WinListView.DoubleClick -= WinListView_DoubleClick;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientListView();
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjColumnHeaderCollectionController != null)
			{
				mobjColumnHeaderCollectionController.Terminate();
			}
			if (mobjItemCollectionController != null)
			{
				mobjItemCollectionController.Terminate();
			}
			if (mobjGroupCollectionController != null)
			{
				mobjGroupCollectionController.Terminate();
			}
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinListView.ColumnWidthChanged += WinListView_ColumnWidthChanged;
		}

		private void WinListView_ColumnWidthChanged(object sender, System.Windows.Forms.ColumnWidthChangedEventArgs e)
		{
			if (base.IsNotificationSuspened)
			{
				return;
			}
			System.Windows.Forms.ColumnHeader columnHeader = WinListView.Columns[e.ColumnIndex];
			if (columnHeader == null)
			{
				return;
			}
			ObjectController controllerByWinObject = GetControllerByWinObject(columnHeader);
			if (controllerByWinObject != null)
			{
				Gizmox.WebGUI.Forms.ColumnHeader columnHeader2 = (Gizmox.WebGUI.Forms.ColumnHeader)controllerByWinObject.SourceObject;
				if (columnHeader2 != null && columnHeader.Width != columnHeader2.Width)
				{
					controllerByWinObject.FireWinPropertyChanged(new ObservableItemPropertyChangedArgs("Width"));
				}
			}
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinListView.ColumnWidthChanged -= WinListView_ColumnWidthChanged;
		}
	}
}

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
	public class TableLayoutPanelController : ControlController
	{
		private TableLayoutRowStyleCollectionController mobjRowStylesController = null;

		private TableLayoutColumnStyleCollectionController mobjColumnStylesController = null;

		private TableLayoutSettingsController mobjTableLayoutSettingsController = null;

		public System.Windows.Forms.TableLayoutPanel TargetTableLayoutPanel => base.TargetObject as System.Windows.Forms.TableLayoutPanel;

		public Gizmox.WebGUI.Forms.TableLayoutPanel SourceTableLayoutPanel => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutPanel;

		public TableLayoutPanelController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.RowStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.ColumnStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.ColumnStyles);
			mobjTableLayoutSettingsController = new TableLayoutSettingsController(objContext, SourceTableLayoutPanel.LayoutSettings, TargetTableLayoutPanel.LayoutSettings);
		}

		public TableLayoutPanelController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.RowStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.ColumnStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.ColumnStyles);
			mobjTableLayoutSettingsController = new TableLayoutSettingsController(objContext, SourceTableLayoutPanel.LayoutSettings, TargetTableLayoutPanel.LayoutSettings);
		}

		protected override void InitializedContained()
		{
			try
			{
				SuspendNotifications();
				base.InitializedContained();
				mobjColumnStylesController.Initialize();
				mobjRowStylesController.Initialize();
				mobjTableLayoutSettingsController.Initialize();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return new System.Windows.Forms.TableLayoutPanel();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			try
			{
				TargetTableLayoutPanel.SuspendLayout();
				SetTargetTableLayoutPanelBorderStyle();
				SetTargetTableLayoutPanelGrowStyle();
				SetTargetTableLayoutPanelControlsPositions();
				SetTargetTableLayoutPanelColumnStyles();
				SetTargetTableLayoutPanelRowStyles();
				SetTargetTableLayoutPanelColumnCount();
				SetTargetTableLayoutPanelRowCount();
				SetTargetTableLayoutPanelCellBorderStyle();
			}
			finally
			{
				TargetTableLayoutPanel.ResumeLayout(performLayout: false);
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjColumnStylesController != null)
			{
				mobjColumnStylesController.Terminate();
			}
			if (mobjRowStylesController != null)
			{
				mobjRowStylesController.Terminate();
			}
			if (mobjTableLayoutSettingsController != null)
			{
				mobjTableLayoutSettingsController.Terminate();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "BorderStyle":
				SetSourceTableLayoutPanelBorderStyle();
				break;
			case "CellBorderStyle":
				SetSourceTableLayoutPanelCellBorderStyle();
				break;
			case "ColumnCount":
				SetSourceTableLayoutPanelColumnCount();
				break;
			case "GrowStyle":
				SetSourceTableLayoutPanelGrowStyle();
				break;
			case "RowCount":
				SetSourceTableLayoutPanelRowCount();
				break;
			case "ControlPositions":
				SetSourceTableLayoutPanelControlPositions((System.Windows.Forms.Control)objPropertyChangeArgs.Subject);
				break;
			case "RowStyles":
			case "ColumnStyles":
				SetSourceTableLayoutPanelRowStyles();
				SetSourceTableLayoutPanelColumnStyles();
				break;
			case "Controls":
				try
				{
					SuspendNotifications();
					base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
					break;
				}
				finally
				{
					ResumeNotifications();
				}
			default:
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "BorderStyle":
				SetTargetTableLayoutPanelBorderStyle();
				break;
			case "CellBorderStyle":
				SetTargetTableLayoutPanelCellBorderStyle();
				break;
			case "ColumnCount":
				SetTargetTableLayoutPanelColumnCount();
				break;
			case "GrowStyle":
				SetTargetTableLayoutPanelGrowStyle();
				break;
			case "RowCount":
				SetTargetTableLayoutPanelRowCount();
				break;
			case "RowStyles":
				SetTargetTableLayoutPanelRowStyles();
				break;
			case "ColumnStyles":
				SetTargetTableLayoutPanelColumnStyles();
				break;
			case "Controls":
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				SetTargetTableLayoutPanelControlsPositions();
				break;
			default:
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlAdded += TableLayoutPanelController_ControlAdded;
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlRemoved += TableLayoutPanelController_ControlRemoved;
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlAdded -= TableLayoutPanelController_ControlAdded;
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlRemoved -= TableLayoutPanelController_ControlRemoved;
		}

		private void TableLayoutPanelController_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				control.LocationChanged -= objControl_LocationChanged;
			}
		}

		private void TableLayoutPanelController_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				control.LocationChanged += objControl_LocationChanged;
			}
		}

		private void objControl_LocationChanged(object sender, EventArgs e)
		{
			if (sender is System.Windows.Forms.Control sourceTableLayoutPanelControlPositions)
			{
				SetSourceTableLayoutPanelControlPositions(sourceTableLayoutPanelControlPositions);
			}
		}

		protected virtual void SetTargetTableLayoutPanelControlsPositions()
		{
			try
			{
				SuspendNotifications();
				if (SourceTableLayoutPanel == null || SourceTableLayoutPanel.Controls == null)
				{
					return;
				}
				foreach (Gizmox.WebGUI.Forms.Control control in SourceTableLayoutPanel.Controls)
				{
					if (GetControllerByWebObject(control) is ControlController objControlController)
					{
						SetTargetTableLayoutPanelCellPosition(control, objControlController);
						SetTargetTableLayoutPanelColumnSpan(control, objControlController);
						SetTargetTableLayoutPanelRowSpan(control, objControlController);
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetTargetTableLayoutPanelColumnStyles()
		{
			mobjColumnStylesController.SetWinObjectObjects();
		}

		protected virtual void SetTargetTableLayoutPanelRowStyles()
		{
			mobjRowStylesController.SetWinObjectObjects();
		}

		protected virtual void SetTargetTableLayoutPanelBorderStyle()
		{
			TargetTableLayoutPanel.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), SourceTableLayoutPanel.BorderStyle);
		}

		protected virtual void SetTargetTableLayoutPanelCellBorderStyle()
		{
			TargetTableLayoutPanel.CellBorderStyle = (System.Windows.Forms.TableLayoutPanelCellBorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.TableLayoutPanelCellBorderStyle), SourceTableLayoutPanel.CellBorderStyle);
		}

		protected virtual void SetTargetTableLayoutPanelColumnCount()
		{
			SetWinProperty("ColumnCount", SourceTableLayoutPanel.ColumnCount);
		}

		protected virtual void SetTargetTableLayoutPanelGrowStyle()
		{
			TargetTableLayoutPanel.GrowStyle = (System.Windows.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(System.Windows.Forms.TableLayoutPanelGrowStyle), SourceTableLayoutPanel.GrowStyle);
		}

		protected virtual void SetTargetTableLayoutPanelRowCount()
		{
			SetWinProperty("RowCount", SourceTableLayoutPanel.RowCount);
		}

		protected virtual void SetTargetTableLayoutPanelCellPosition(object objSubject, ControlController objControlController)
		{
			Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition cellPosition = SourceTableLayoutPanel.GetCellPosition((Gizmox.WebGUI.Forms.Control)objSubject);
			bool flag = true;
			TargetTableLayoutPanel.SetCellPosition((System.Windows.Forms.Control)objControlController.TargetObject, new System.Windows.Forms.TableLayoutPanelCellPosition(cellPosition.Column, cellPosition.Row));
		}

		protected virtual void SetTargetTableLayoutPanelColumn(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetColumn((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetColumn((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetTargetTableLayoutPanelRow(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetRow((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetRow((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetTargetTableLayoutPanelColumnSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetColumnSpan((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetColumnSpan((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetTargetTableLayoutPanelRowSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetRowSpan((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetRowSpan((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetSourceTableLayoutPanelBorderStyle()
		{
			SourceTableLayoutPanel.BorderStyle = (Gizmox.WebGUI.Forms.BorderStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.BorderStyle), TargetTableLayoutPanel.BorderStyle);
		}

		protected virtual void SetSourceTableLayoutPanelCellBorderStyle()
		{
			SourceTableLayoutPanel.CellBorderStyle = (Gizmox.WebGUI.Forms.TableLayoutPanelCellBorderStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.TableLayoutPanelCellBorderStyle), TargetTableLayoutPanel.CellBorderStyle);
		}

		protected virtual void SetSourceTableLayoutPanelColumnCount()
		{
			SourceTableLayoutPanel.ColumnCount = TargetTableLayoutPanel.ColumnCount;
		}

		protected virtual void SetSourceTableLayoutPanelGrowStyle()
		{
			SourceTableLayoutPanel.GrowStyle = (Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle), TargetTableLayoutPanel.GrowStyle);
		}

		protected virtual void SetSourceTableLayoutPanelRowCount()
		{
			SourceTableLayoutPanel.RowCount = TargetTableLayoutPanel.RowCount;
		}

		protected virtual void SetSourceTableLayoutPanelColumnStyles()
		{
			mobjColumnStylesController.SetWebObjectObjects();
		}

		protected virtual void SetSourceTableLayoutPanelRowStyles()
		{
			mobjRowStylesController.SetWebObjectObjects();
		}

		protected virtual void SetSourceTableLayoutPanelControlsPositions()
		{
			try
			{
				SuspendNotifications();
				if (TargetTableLayoutPanel == null || TargetTableLayoutPanel.Controls == null)
				{
					return;
				}
				foreach (System.Windows.Forms.Control control in TargetTableLayoutPanel.Controls)
				{
					if (GetControllerByWinObject(control) is ControlController objControlController)
					{
						SetSourceTableLayoutPanelCellPosition(control, objControlController);
						SetSourceTableLayoutPanelColumnSpan(control, objControlController);
						SetSourceTableLayoutPanelRowSpan(control, objControlController);
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetSourceTableLayoutPanelControlPositions(System.Windows.Forms.Control objControl)
		{
			try
			{
				SuspendNotifications();
				if (SourceTableLayoutPanel != null && SourceTableLayoutPanel.Controls != null && GetControllerByWinObject(objControl) is ControlController objControlController)
				{
					SetSourceTableLayoutPanelCellPosition(objControl, objControlController);
					SetSourceTableLayoutPanelColumnSpan(objControl, objControlController);
					SetSourceTableLayoutPanelRowSpan(objControl, objControlController);
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetSourceTableLayoutPanelCellPosition(object objSubject, ControlController objControlController)
		{
			System.Windows.Forms.TableLayoutPanelCellPosition cellPosition = TargetTableLayoutPanel.GetCellPosition((System.Windows.Forms.Control)objSubject);
			bool flag = true;
			Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition cellPosition2 = SourceTableLayoutPanel.GetCellPosition((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject);
			if (cellPosition2.Column != cellPosition.Column || cellPosition2.Row != cellPosition.Row)
			{
				SourceTableLayoutPanel.SetCellPosition((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject, new Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition(cellPosition.Column, cellPosition.Row));
			}
		}

		protected virtual void SetSourceTableLayoutPanelColumnSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				int columnSpan = TargetTableLayoutPanel.GetColumnSpan((System.Windows.Forms.Control)objSubject);
				int columnSpan2 = SourceTableLayoutPanel.GetColumnSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject);
				if (columnSpan2 != columnSpan)
				{
					SourceTableLayoutPanel.SetColumnSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject, columnSpan);
				}
			}
		}

		protected virtual void SetSourceTableLayoutPanelRowSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				int rowSpan = TargetTableLayoutPanel.GetRowSpan((System.Windows.Forms.Control)objSubject);
				int rowSpan2 = SourceTableLayoutPanel.GetRowSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject);
				if (rowSpan2 != rowSpan)
				{
					SourceTableLayoutPanel.SetRowSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject, rowSpan);
				}
			}
		}
	}
}

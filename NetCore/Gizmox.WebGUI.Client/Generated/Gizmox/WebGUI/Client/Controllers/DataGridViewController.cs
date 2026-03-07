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
	public class DataGridViewController : ControlController
	{
		private DataGidViewColumnCollectionController mobjDataGidViewColumnCollectionController = null;

		public Gizmox.WebGUI.Forms.DataGridView WebDataGridView => base.SourceObject as Gizmox.WebGUI.Forms.DataGridView;

		public System.Windows.Forms.DataGridView WinDataGridView => base.TargetObject as System.Windows.Forms.DataGridView;

		public DataGridViewController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
			mobjDataGidViewColumnCollectionController = new DataGidViewColumnCollectionController(objContext, WebDataGridView, WebDataGridView.Columns, WinDataGridView, WinDataGridView.Columns);
		}

		public DataGridViewController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjDataGidViewColumnCollectionController = new DataGidViewColumnCollectionController(objContext, WebDataGridView, WebDataGridView.Columns, WinDataGridView, WinDataGridView.Columns);
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.Terminate();
			}
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.Clear();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinDataGridViewColumns();
			SetWinDataGridViewDefaultCellStyle();
			SetWinColumnHeadersDefaultCellStyle();
			SetWinRowHeadersDefaultCellStyle();
			SetWinRowsDefaultCellStyle();
			SetWinAlternatingRowsDefaultCellStyle();
			SetWinDataGridViewRowHeaderWidth();
			SetWinDataGridViewColumnHeadersVisible();
			SetWinDataGridViewColumnHeadersHeight();
			SetWinDataGridViewAutoSizeColumns();
			SetWinDataGridViewColumnHeadersHeightSizeMode();
			SetWinDataGridViewAllowUserToAddRows();
		}

		private void SetWinDataGridViewCellStyle(System.Windows.Forms.DataGridViewCellStyle objWinDataGridViewCellStyle, Gizmox.WebGUI.Forms.DataGridViewCellStyle objWebDataGridViewCellStyle)
		{
			objWinDataGridViewCellStyle.Alignment = (System.Windows.Forms.DataGridViewContentAlignment)Enum.Parse(typeof(System.Windows.Forms.DataGridViewContentAlignment), objWebDataGridViewCellStyle.Alignment.ToString());
			objWinDataGridViewCellStyle.BackColor = objWebDataGridViewCellStyle.BackColor;
			objWinDataGridViewCellStyle.DataSourceNullValue = objWebDataGridViewCellStyle.DataSourceNullValue;
			if (objWebDataGridViewCellStyle.Font == null)
			{
				objWinDataGridViewCellStyle.Font = null;
			}
			else
			{
				objWinDataGridViewCellStyle.Font = new Font(objWebDataGridViewCellStyle.Font.FontFamily, objWebDataGridViewCellStyle.Font.Size * base.TargetVerticalScaleFactor);
			}
			objWinDataGridViewCellStyle.ForeColor = objWebDataGridViewCellStyle.ForeColor;
			objWinDataGridViewCellStyle.Format = objWebDataGridViewCellStyle.Format;
			objWinDataGridViewCellStyle.FormatProvider = objWebDataGridViewCellStyle.FormatProvider;
			objWinDataGridViewCellStyle.NullValue = objWebDataGridViewCellStyle.NullValue;
			objWinDataGridViewCellStyle.Padding = new System.Windows.Forms.Padding(objWebDataGridViewCellStyle.Padding.Left, objWebDataGridViewCellStyle.Padding.Top, objWebDataGridViewCellStyle.Padding.Right, objWebDataGridViewCellStyle.Padding.Bottom);
			objWinDataGridViewCellStyle.SelectionBackColor = objWebDataGridViewCellStyle.SelectionBackColor;
			objWinDataGridViewCellStyle.SelectionForeColor = objWebDataGridViewCellStyle.SelectionForeColor;
			objWinDataGridViewCellStyle.Tag = objWebDataGridViewCellStyle.Tag;
			objWinDataGridViewCellStyle.WrapMode = (System.Windows.Forms.DataGridViewTriState)Enum.Parse(typeof(System.Windows.Forms.DataGridViewTriState), objWebDataGridViewCellStyle.WrapMode.ToString());
		}

		protected void SetWinDataGridViewDefaultCellStyle()
		{
			if (WebDataGridView.DefaultCellStyle != null)
			{
				if (WinDataGridView.DefaultCellStyle == null)
				{
					WinDataGridView.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.DefaultCellStyle, WebDataGridView.DefaultCellStyle);
			}
		}

		protected void SetWinAlternatingRowsDefaultCellStyle()
		{
			if (WebDataGridView.AlternatingRowsDefaultCellStyle != null)
			{
				if (WinDataGridView.AlternatingRowsDefaultCellStyle == null)
				{
					WinDataGridView.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.AlternatingRowsDefaultCellStyle, WebDataGridView.AlternatingRowsDefaultCellStyle);
			}
		}

		protected void SetWinColumnHeadersDefaultCellStyle()
		{
			if (WebDataGridView.ColumnHeadersDefaultCellStyle != null)
			{
				if (WinDataGridView.ColumnHeadersDefaultCellStyle == null)
				{
					WinDataGridView.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.ColumnHeadersDefaultCellStyle, WebDataGridView.ColumnHeadersDefaultCellStyle);
			}
		}

		protected void SetWinRowHeadersDefaultCellStyle()
		{
			if (WebDataGridView.RowHeadersDefaultCellStyle != null)
			{
				if (WinDataGridView.RowHeadersDefaultCellStyle == null)
				{
					WinDataGridView.RowHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.RowHeadersDefaultCellStyle, WebDataGridView.RowHeadersDefaultCellStyle);
			}
		}

		protected void SetWinRowsDefaultCellStyle()
		{
			if (WebDataGridView.RowsDefaultCellStyle != null)
			{
				if (WinDataGridView.RowsDefaultCellStyle == null)
				{
					WinDataGridView.RowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.RowsDefaultCellStyle, WebDataGridView.RowsDefaultCellStyle);
			}
		}

		protected virtual void SetWinDataGridViewDataSource()
		{
			if (WebDataGridView.DataSource is Gizmox.WebGUI.Forms.BindingSource bindingSource)
			{
				if (!(WinDataGridView.DataSource is System.Windows.Forms.BindingSource bindingSource2) || bindingSource2.DataSource != bindingSource.DataSource || bindingSource2.DataMember != bindingSource.DataMember)
				{
					WinDataGridView.DataSource = new System.Windows.Forms.BindingSource(bindingSource.DataSource, bindingSource.DataMember);
					RefreshDesigner();
				}
			}
			else if (WinDataGridView.DataSource != WebDataGridView.DataSource)
			{
				WinDataGridView.DataSource = WebDataGridView.DataSource;
				RefreshDesigner();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new DataGridView();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			if (WinDataGridView != null)
			{
				WinDataGridView.DataSourceChanged += WinDataGridView_DataSourceChanged;
				WinDataGridView.AutoGenerateColumnsChanged += WinDataGridView_AutoGenerateColumnsChanged;
				WinDataGridView.ColumnHeadersHeightSizeModeChanged += WinDataGridView_ColumnHeadersHeightSizeModeChanged;
			}
		}

		private void WinDataGridView_ColumnHeadersHeightSizeModeChanged(object sender, System.Windows.Forms.DataGridViewAutoSizeModeEventArgs e)
		{
			SetWebDataGridViewColumnHeadersHeightSizeMode();
		}

		private void WinDataGridView_AutoGenerateColumnsChanged(object sender, EventArgs e)
		{
			SetWebDataGridViewAutoGenerateColumns();
		}

		private void WinDataGridView_DataSourceChanged(object sender, EventArgs e)
		{
			SetWebDataGridViewColumns();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			if (WinDataGridView != null)
			{
				WinDataGridView.DataSourceChanged -= WinDataGridView_DataSourceChanged;
				WinDataGridView.AutoGenerateColumnsChanged -= WinDataGridView_AutoGenerateColumnsChanged;
				WinDataGridView.ColumnHeadersHeightSizeModeChanged -= WinDataGridView_ColumnHeadersHeightSizeModeChanged;
			}
		}

		protected override void InitializedContained()
		{
			mobjDataGidViewColumnCollectionController.Initialize();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Columns")
			{
				SetWebDataGridViewColumns();
			}
		}

		private void SetWebDataGridViewAutoGenerateColumns()
		{
			if (WinDataGridView != null && WebDataGridView != null)
			{
				WebDataGridView.AutoGenerateColumns = WinDataGridView.AutoGenerateColumns;
			}
		}

		private void SetWebDataGridViewColumns()
		{
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.SetWebObjectObjects();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DataSource":
				SetWinDataGridViewDataSource();
				break;
			case "DefaultCellStyle":
				SetWinDataGridViewDefaultCellStyle();
				break;
			case "ColumnHeadersDefaultCellStyle":
				SetWinColumnHeadersDefaultCellStyle();
				break;
			case "RowHeadersDefaultCellStyle":
				SetWinRowHeadersDefaultCellStyle();
				break;
			case "RowsDefaultCellStyle":
				SetWinRowsDefaultCellStyle();
				break;
			case "AlternatingRowsDefaultCellStyle":
				SetWinAlternatingRowsDefaultCellStyle();
				break;
			case "Columns":
				SetWinDataGridViewColumns();
				break;
			case "RowHeadersWidth":
				SetWinDataGridViewRowHeaderWidth();
				break;
			case "ColumnHeadersVisible":
				SetWinDataGridViewColumnHeadersVisible();
				break;
			case "ColumnHeadersHeight":
				SetWinDataGridViewColumnHeadersHeight();
				break;
			case "AutoSizeColumnsMode":
				SetWinDataGridViewAutoSizeColumns();
				break;
			case "ColumnHeadersHeightSizeMode":
				SetWinDataGridViewColumnHeadersHeightSizeMode();
				break;
			case "AllowUserToAddRows":
				SetWinDataGridViewAllowUserToAddRows();
				break;
			}
		}

		private void SetWinDataGridViewAllowUserToAddRows()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.AllowUserToAddRows = WebDataGridView.AllowUserToAddRows;
			}
		}

		private void SetWinDataGridViewColumns()
		{
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.SetWinObjectObjects();
			}
		}

		private void SetWinDataGridViewRowHeaderWidth()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.RowHeadersWidth = WebDataGridView.RowHeadersWidth;
			}
		}

		private void SetWinDataGridViewColumnHeadersHeight()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.ColumnHeadersHeight = WebDataGridView.ColumnHeadersHeight;
			}
		}

		private void SetWinDataGridViewColumnHeadersVisible()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.ColumnHeadersVisible = WebDataGridView.ColumnHeadersVisible;
			}
		}

		private void SetWinDataGridViewAutoSizeColumns()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.AutoSizeColumnsMode = (System.Windows.Forms.DataGridViewAutoSizeColumnsMode)GetConvertedEnum(typeof(System.Windows.Forms.DataGridViewAutoSizeColumnsMode), WebDataGridView.AutoSizeColumnsMode, WinDataGridView.AutoSizeColumnsMode);
			}
		}

		private void SetWinDataGridViewColumnHeadersHeightSizeMode()
		{
			if (WinDataGridView != null)
			{
				System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode dataGridViewColumnHeadersHeightSizeMode = (System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode), WebDataGridView.ColumnHeadersHeightSizeMode, WinDataGridView.ColumnHeadersHeightSizeMode);
				if (WinDataGridView.ColumnHeadersHeightSizeMode != dataGridViewColumnHeadersHeightSizeMode)
				{
					WinDataGridView.ColumnHeadersHeightSizeMode = dataGridViewColumnHeadersHeightSizeMode;
				}
			}
		}

		private void SetWebDataGridViewColumnHeadersHeightSizeMode()
		{
			if (WebDataGridView != null)
			{
				Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode dataGridViewColumnHeadersHeightSizeMode = (Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode), WinDataGridView.ColumnHeadersHeightSizeMode, WebDataGridView.ColumnHeadersHeightSizeMode);
				if (WebDataGridView.ColumnHeadersHeightSizeMode != dataGridViewColumnHeadersHeightSizeMode)
				{
					WebDataGridView.ColumnHeadersHeightSizeMode = dataGridViewColumnHeadersHeightSizeMode;
				}
			}
		}
	}
}

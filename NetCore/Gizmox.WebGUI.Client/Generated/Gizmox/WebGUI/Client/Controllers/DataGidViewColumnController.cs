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
	public class DataGidViewColumnController : ComponentController
	{
		public Gizmox.WebGUI.Forms.DataGridViewColumn WebColumn => base.SourceObject as Gizmox.WebGUI.Forms.DataGridViewColumn;

		public System.Windows.Forms.DataGridViewColumn WinColumn => base.TargetObject as System.Windows.Forms.DataGridViewColumn;

		public DataGidViewColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebColumnHeaderText();
			SetWebColumnName();
			SetWebColumnWidth();
			SetWebColumnDataPropertyName();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinColumnDataPropertyName();
			SetWinColumnDefaultCellStyle();
			SetWinColumnHeaderCellValue();
			SetWinColumnWidth();
			SetWinColumnName();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinColumnDataPropertyName();
			SetWinColumnDefaultCellStyle();
			SetWinColumnHeaderCellValue();
			SetWinColumnWidth();
			SetWinColumnName();
			SetWinColumnAutoSizeMode();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "HeaderText":
				SetWebColumnHeaderText();
				break;
			case "Name":
				SetWebColumnName();
				break;
			case "Width":
				SetWebColumnWidth();
				break;
			case "DataPropertyName":
				SetWebColumnDataPropertyName();
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DefaultCellStyle":
				SetWinColumnDefaultCellStyle();
				break;
			case "HeaderText":
				SetWinColumnHeaderCellValue();
				break;
			case "Name":
				SetWinColumnName();
				break;
			case "Width":
				SetWinColumnWidth();
				break;
			case "DataPropertyName":
				SetWinColumnDataPropertyName();
				break;
			case "AutoSizeMode":
				SetWinColumnAutoSizeMode();
				break;
			}
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "HeaderText"))
			{
				if (property == "Width")
				{
					SetWinColumnWidth();
				}
			}
			else
			{
				SetWinColumnHeaderCellValue();
			}
		}

		protected void SetWinColumnDefaultCellStyle()
		{
			if (WebColumn != null && WebColumn.DefaultCellStyle != null && WinColumn != null)
			{
				if (WinColumn.DefaultCellStyle == null)
				{
					WinColumn.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				WinColumn.DefaultCellStyle.Alignment = (System.Windows.Forms.DataGridViewContentAlignment)Enum.Parse(typeof(System.Windows.Forms.DataGridViewContentAlignment), WebColumn.DefaultCellStyle.Alignment.ToString());
				WinColumn.DefaultCellStyle.BackColor = WebColumn.DefaultCellStyle.BackColor;
				WinColumn.DefaultCellStyle.DataSourceNullValue = WebColumn.DefaultCellStyle.DataSourceNullValue;
				if (WebColumn.DefaultCellStyle.Font == null)
				{
					WinColumn.DefaultCellStyle.Font = null;
				}
				else
				{
					WinColumn.DefaultCellStyle.Font = new Font(WebColumn.DefaultCellStyle.Font.FontFamily, WebColumn.DefaultCellStyle.Font.Size * base.TargetVerticalScaleFactor);
				}
				WinColumn.DefaultCellStyle.ForeColor = WebColumn.DefaultCellStyle.ForeColor;
				WinColumn.DefaultCellStyle.Format = WebColumn.DefaultCellStyle.Format;
				WinColumn.DefaultCellStyle.FormatProvider = WebColumn.DefaultCellStyle.FormatProvider;
				WinColumn.DefaultCellStyle.NullValue = WebColumn.DefaultCellStyle.NullValue;
				WinColumn.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(WebColumn.DefaultCellStyle.Padding.Left, WebColumn.DefaultCellStyle.Padding.Top, WebColumn.DefaultCellStyle.Padding.Right, WebColumn.DefaultCellStyle.Padding.Bottom);
				WinColumn.DefaultCellStyle.SelectionBackColor = WebColumn.DefaultCellStyle.SelectionBackColor;
				WinColumn.DefaultCellStyle.SelectionForeColor = WebColumn.DefaultCellStyle.SelectionForeColor;
				WinColumn.DefaultCellStyle.Tag = WebColumn.DefaultCellStyle.Tag;
				WinColumn.DefaultCellStyle.WrapMode = (System.Windows.Forms.DataGridViewTriState)Enum.Parse(typeof(System.Windows.Forms.DataGridViewTriState), WebColumn.DefaultCellStyle.WrapMode.ToString());
			}
		}

		protected virtual void SetWinColumnDataPropertyName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.DataPropertyName = WebColumn.DataPropertyName;
			}
		}

		private void SetWinColumnAutoSizeMode()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.AutoSizeMode = (System.Windows.Forms.DataGridViewAutoSizeColumnMode)GetConvertedEnum(typeof(System.Windows.Forms.DataGridViewAutoSizeColumnMode), WebColumn.AutoSizeMode, WinColumn.AutoSizeMode);
			}
		}

		protected virtual void SetWinColumnName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.Name = WebColumn.Name;
			}
		}

		protected virtual void SetWinColumnHeaderCellValue()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.HeaderCell.Value = WebColumn.HeaderCell.Value;
			}
		}

		protected virtual void SetWebColumnDataPropertyName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.DataPropertyName = WinColumn.DataPropertyName;
			}
		}

		protected virtual void SetWebColumnWidth()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.Width = Convert.ToInt32((float)WinColumn.Width / base.TargetHorizontalScaleFactor);
			}
		}

		protected virtual void SetWebColumnName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.Name = WinColumn.Name;
			}
		}

		protected virtual void SetWebColumnHeaderText()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.HeaderText = WinColumn.HeaderText;
			}
		}

		protected virtual void SetWinColumnWidth()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.Width = Convert.ToInt32((float)WebColumn.Width * base.TargetHorizontalScaleFactor);
			}
		}
	}
}

#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// 
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class DataGridViewFilterComboBoxBase : ComboBox
	{
		private DataGridView mobjOwningDataGridView;

		private DataGridViewColumn mobjOwningColumn;

		private DataGridViewCell mobjOwningCell;

		[NonSerialized]
		private TypeConverter mobjTypeConverter = null;

		/// 
		/// Gets or sets the owning cell.
		/// </summary>
		/// 
		/// The owning cell.
		/// </value>
		public DataGridViewCell OwningCell
		{
			get
			{
				return mobjOwningCell;
			}
			set
			{
				mobjOwningCell = value;
			}
		}

		/// 
		/// Gets or sets the owning column.
		/// </summary>
		/// 
		/// The owning column.
		/// </value>
		public DataGridViewColumn OwningColumn
		{
			get
			{
				return mobjOwningColumn;
			}
			set
			{
				mobjOwningColumn = value;
			}
		}

		/// 
		/// Gets or sets the owning data grid view.
		/// </summary>
		/// 
		/// The owning data grid view.
		/// </value>
		public DataGridView OwningDataGridView
		{
			get
			{
				return mobjOwningDataGridView;
			}
			set
			{
				mobjOwningDataGridView = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewFilterComboBoxBase" /> class.
		/// </summary>
		/// <param name="objDataGridView">The obj data grid view.</param>
		/// <param name="objColumn">The obj column.</param>
		/// <param name="objFilterCell">The obj filter cell.</param>
		public DataGridViewFilterComboBoxBase(DataGridView objDataGridView, DataGridViewColumn objColumn, DataGridViewCell objFilterCell)
		{
			mobjOwningDataGridView = objDataGridView;
			mobjOwningColumn = objColumn;
			mobjOwningCell = objFilterCell;
		}

		/// 
		/// Initializes the filter values.
		/// </summary>
		/// <param name="blnAddSystemFilterOptions">if set to true</c> [BLN add system filter options].</param>
		/// <param name="blnCalculateDropDownWidth">if set to true</c> [BLN set drop down width].</param>
		/// <param name="blnClearBindingSourceFilter">if set to true</c> [BLN clear binding source filter].</param>
		public virtual void InitializeFilterValues(bool blnAddSystemFilterOptions, bool blnCalculateDropDownWidth, bool blnClearBindingSourceFilter)
		{
			if (mobjOwningDataGridView == null || mobjOwningColumn == null)
			{
				return;
			}
			mobjOwningDataGridView.mblnSuspendFilterInitialization = true;
			base.Items.Clear();
			BindingSource bindingSource = mobjOwningDataGridView.DataSource as BindingSource;
			if (bindingSource != null)
			{
				if (blnClearBindingSourceFilter && !string.IsNullOrEmpty(bindingSource.Filter))
				{
					bindingSource = (BindingSource)bindingSource.Clone();
					bindingSource.RemoveFilter();
				}
				string dataPropertyName = mobjOwningColumn.DataPropertyName;
				Font font = Font;
				int num = 0;
				int num2 = 0;
				CurrencyManager currencyManager = bindingSource.CurrencyManager;
				foreach (object item in bindingSource.List)
				{
					object obj = ListControl.FilterItemOnProperty(currencyManager, item, dataPropertyName);
					if (obj == null)
					{
						continue;
					}
					string text = obj.ToString();
					if (string.IsNullOrEmpty(text) || base.Items.Contains(text))
					{
						continue;
					}
					base.Items.Add(text);
					num++;
					if (blnCalculateDropDownWidth)
					{
						Size stringMeasurements = CommonUtils.GetStringMeasurements(text, font);
						if (num2 < stringMeasurements.Width)
						{
							num2 = stringMeasurements.Width;
						}
					}
					if (mobjOwningDataGridView.MaxFilterOptions > 0 && num == mobjOwningDataGridView.MaxFilterOptions)
					{
						break;
					}
				}
				if (blnAddSystemFilterOptions)
				{
					int num3 = 0;
					foreach (SystemFilterOptions value in Enum.GetValues(typeof(SystemFilterOptions)))
					{
						DataGridViewSystemFilterOption dataGridViewSystemFilterOption = new DataGridViewSystemFilterOption(value);
						base.Items.Insert(num3, dataGridViewSystemFilterOption);
						if (blnCalculateDropDownWidth)
						{
							Size stringMeasurements = CommonUtils.GetStringMeasurements(dataGridViewSystemFilterOption.ToString(), font);
							if (num2 < stringMeasurements.Width)
							{
								num2 = stringMeasurements.Width;
							}
						}
						num3++;
					}
				}
				if (blnCalculateDropDownWidth)
				{
					UpdateDropDownWidth(num2);
				}
				mobjOwningDataGridView.FilterValuesInitializing(this, mobjOwningColumn);
			}
			mobjOwningDataGridView.mblnSuspendFilterInitialization = false;
		}

		/// 
		/// Updates the width of the drop down.
		/// </summary>
		/// <param name="intMaxWidth">Width of the int max.</param>
		protected virtual void UpdateDropDownWidth(int intMaxWidth)
		{
			base.DropDownWidth = intMaxWidth;
		}

		/// 
		/// Determines whether [value is valid ].
		/// </summary>
		/// 
		///   true</c> if [is valid value]; otherwise, false</c>.
		/// </returns>
		protected internal virtual bool IsValidValue()
		{
			string text = Text;
			if (!string.IsNullOrEmpty(text))
			{
				int num = FindStringIgnoreCase(text);
				if (num == -1)
				{
					if (mobjTypeConverter == null && mobjOwningColumn != null)
					{
						mobjTypeConverter = TypeDescriptor.GetConverter(mobjOwningColumn.ValueType);
					}
					if (mobjTypeConverter != null && !mobjTypeConverter.IsValid(text))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}

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
	/// Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see> objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ToolboxBitmap(typeof(DataGridViewButtonColumn), "DataGridViewButtonColumn.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewButtonColumn : DataGridViewColumn
	{
		private string mstrText;

		private static Type mobjColumnType;

		/// 
		/// Gets the name of the type.
		/// </summary>
		/// The name of the type.</value>
		protected override string TypeName => "5";

		/// Gets or sets the template used to create new cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
		/// <exception cref="T:System.InvalidCastException">The specified value when setting this property could not be cast to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see>. </exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override DataGridViewCell CellTemplate
		{
			get
			{
				return base.CellTemplate;
			}
			set
			{
				if (value != null && !(value is DataGridViewButtonCell))
				{
					throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"));
				}
				base.CellTemplate = value;
			}
		}

		/// Gets or sets the column's default cell style.</summary>
		/// The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
		[Browsable(true)]
		public override DataGridViewCellStyle DefaultCellStyle
		{
			get
			{
				return base.DefaultCellStyle;
			}
			set
			{
				base.DefaultCellStyle = value;
			}
		}

		/// Gets or sets the flat-style appearance of the button cells in the column.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the appearance of the buttons in the column. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_ButtonColumnFlatStyleDescr")]
		[DefaultValue(2)]
		public FlatStyle FlatStyle
		{
			get
			{
				return FlatStyle.Standard;
			}
			set
			{
			}
		}

		/// Gets or sets the default text displayed on the button cell.</summary>
		/// A <see cref="T:System.String"></see> that contains the text. The default is <see cref="F:System.String.Empty"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ButtonColumnTextDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(null)]
		public string Text
		{
			get
			{
				return mstrText;
			}
			set
			{
				if (string.Equals(value, Text))
				{
					return;
				}
				mstrText = value;
				if (base.DataGridView == null)
				{
					return;
				}
				if (UseColumnTextForButtonValue)
				{
					base.DataGridView.OnColumnCommonChange(base.Index);
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewButtonCell { UseColumnTextForButtonValue: not false })
					{
						base.DataGridView.OnColumnCommonChange(base.Index);
						return;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Gets or sets a value indicating whether the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property value is displayed as the button text for cells in this column.</summary>
		/// true if the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property value is displayed on buttons in the column; false if the <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value of each cell is displayed on its button. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null.</exception>
		[DefaultValue(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_ButtonColumnUseColumnTextForButtonValueDescr")]
		public bool UseColumnTextForButtonValue
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewButtonCell)CellTemplate).UseColumnTextForButtonValue;
			}
			set
			{
				if (UseColumnTextForButtonValue == value)
				{
					return;
				}
				((DataGridViewButtonCell)CellTemplate).UseColumnTextForButtonValueInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewButtonCell dataGridViewButtonCell)
					{
						dataGridViewButtonCell.UseColumnTextForButtonValueInternal = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		static DataGridViewButtonColumn()
		{
			mobjColumnType = typeof(DataGridViewButtonColumn);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn"></see> class to the default state.</summary>
		public DataGridViewButtonColumn()
			: this(new DataGridViewButtonCell())
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn" /> class.
		/// </summary>
		/// <param name="objCellTemplate">The obj cell template.</param>
		protected DataGridViewButtonColumn(DataGridViewButtonCell objCellTemplate)
			: base(objCellTemplate)
		{
			DefaultCellStyle = new DataGridViewCellStyle
			{
				AlignmentInternal = DataGridViewContentAlignment.MiddleCenter
			};
		}

		/// Creates an exact copy of this column.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		public override object Clone()
		{
			return base.Clone();
		}

		private bool ShouldSerializeDefaultCellStyle()
		{
			return false;
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			return base.ToString();
		}
	}
}

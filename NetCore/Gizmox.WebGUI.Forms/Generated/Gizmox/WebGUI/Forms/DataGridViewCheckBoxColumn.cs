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
/// Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ToolboxBitmap(typeof(DataGridViewCheckBoxColumn), "DataGridViewCheckBoxColumn.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewCheckBoxColumn : DataGridViewColumn
	{
		/// 
		/// Gets the name of the type.
		/// </summary>
		/// The name of the type.</value>
		protected override string TypeName => "2";

		/// Gets or sets the template used to create new cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> instance.</returns>
		/// <exception cref="T:System.InvalidCastException">The property is set to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see>. </exception>
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
				if (value != null && !(value is DataGridViewCheckBoxCell))
				{
					throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"));
				}
				base.CellTemplate = value;
			}
		}

		private DataGridViewCheckBoxCell CheckBoxCellTemplate => (DataGridViewCheckBoxCell)CellTemplate;

		/// Gets or sets the column's default cell style.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
		[SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
		[SRCategory("CatAppearance")]
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

		/// Gets or sets the underlying value corresponding to a cell value of false, which appears as an unchecked box.</summary>
		/// An <see cref="T:System.Object"></see> representing a value that the cells in this column will treat as a false value. The default is null.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[TypeConverter(typeof(StringConverter))]
		[SRDescription("DataGridView_CheckBoxColumnFalseValueDescr")]
		[DefaultValue(null)]
		[SRCategory("CatData")]
		public object FalseValue
		{
			get
			{
				if (CheckBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return CheckBoxCellTemplate.FalseValue;
			}
			set
			{
				if (FalseValue == value)
				{
					return;
				}
				CheckBoxCellTemplate.FalseValueInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
					{
						dataGridViewCheckBoxCell.FalseValueInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Gets or sets the flat style appearance of the check box cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the appearance of cells in the column. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CheckBoxColumnFlatStyleDescr")]
		[DefaultValue(2)]
		[SRCategory("CatAppearance")]
		public FlatStyle FlatStyle
		{
			get
			{
				if (CheckBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return CheckBoxCellTemplate.FlatStyle;
			}
			set
			{
				if (FlatStyle == value)
				{
					return;
				}
				CheckBoxCellTemplate.FlatStyle = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
					{
						dataGridViewCheckBoxCell.FlatStyleInternal = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		/// Gets or sets the underlying value corresponding to an indeterminate or null cell value, which appears as a disabled checkbox.</summary>
		/// An <see cref="T:System.Object"></see> representing a value that the cells in this column will treat as an indeterminate value. The default is null.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CheckBoxColumnIndeterminateValueDescr")]
		[SRCategory("CatData")]
		[TypeConverter(typeof(StringConverter))]
		[DefaultValue(null)]
		public object IndeterminateValue
		{
			get
			{
				if (CheckBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return CheckBoxCellTemplate.IndeterminateValue;
			}
			set
			{
				if (IndeterminateValue == value)
				{
					return;
				}
				CheckBoxCellTemplate.IndeterminateValueInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
					{
						dataGridViewCheckBoxCell.IndeterminateValueInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Gets or sets a value indicating whether the hosted check box cells will allow three check states rather than two.</summary>
		/// true if the hosted <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> objects are able to have a third, indeterminate, state; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_CheckBoxColumnThreeStateDescr")]
		public bool ThreeState
		{
			get
			{
				if (CheckBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return CheckBoxCellTemplate.ThreeState;
			}
			set
			{
				if (ThreeState == value)
				{
					return;
				}
				CheckBoxCellTemplate.ThreeStateInternal = value;
				if (base.DataGridView != null)
				{
					DataGridViewRowCollection rows = base.DataGridView.Rows;
					int count = rows.Count;
					for (int i = 0; i < count; i++)
					{
						DataGridViewRow dataGridViewRow = rows.SharedRow(i);
						if (dataGridViewRow.Cells[base.Index] is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
						{
							dataGridViewCheckBoxCell.ThreeStateInternal = value;
						}
					}
					base.DataGridView.InvalidateColumn(base.Index);
				}
				if (value && DefaultCellStyle.NullValue is bool && !(bool)DefaultCellStyle.NullValue)
				{
					DefaultCellStyle.NullValue = CheckState.Indeterminate;
				}
				else if (!value && DefaultCellStyle.NullValue is CheckState && (CheckState)DefaultCellStyle.NullValue == CheckState.Indeterminate)
				{
					DefaultCellStyle.NullValue = false;
				}
			}
		}

		/// Gets or sets the underlying value corresponding to a cell value of true, which appears as a checked box.</summary>
		/// An <see cref="T:System.Object"></see> representing a value that the cell will treat as a true value. The default is null.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CheckBoxColumnTrueValueDescr")]
		[SRCategory("CatData")]
		[TypeConverter(typeof(StringConverter))]
		[DefaultValue(null)]
		public object TrueValue
		{
			get
			{
				if (CheckBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return CheckBoxCellTemplate.TrueValue;
			}
			set
			{
				if (TrueValue == value)
				{
					return;
				}
				CheckBoxCellTemplate.TrueValueInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
					{
						dataGridViewCheckBoxCell.TrueValueInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn"></see> class to the default state.</summary>
		public DataGridViewCheckBoxColumn()
			: this(blnThreeState: false)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn"></see> and configures it to display check boxes with two or three states. </summary>
		/// <param name="blnThreeState">true to display check boxes with three states; false to display check boxes with two states. </param>
		public DataGridViewCheckBoxColumn(bool blnThreeState)
			: this(blnThreeState, new DataGridViewCheckBoxCell(blnThreeState))
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn" /> class.
		/// </summary>
		/// <param name="blnThreeState">if set to true</c> [BLN three state].</param>
		/// <param name="objCellTemplate">The obj cell template.</param>
		protected DataGridViewCheckBoxColumn(bool blnThreeState, DataGridViewCheckBoxCell objCellTemplate)
			: base(objCellTemplate)
		{
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle
			{
				AlignmentInternal = DataGridViewContentAlignment.MiddleCenter
			};
			if (blnThreeState)
			{
				dataGridViewCellStyle.NullValue = CheckState.Indeterminate;
			}
			else
			{
				dataGridViewCellStyle.NullValue = false;
			}
			DefaultCellStyle = dataGridViewCellStyle;
		}

		private bool ShouldSerializeDefaultCellStyle()
		{
			if (CellTemplate is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
			{
				object obj = ((!dataGridViewCheckBoxCell.ThreeState) ? ((object)false) : ((object)CheckState.Indeterminate));
				if (!base.HasDefaultCellStyle)
				{
					return false;
				}
				DataGridViewCellStyle defaultCellStyle = DefaultCellStyle;
				if (defaultCellStyle.BackColor.IsEmpty && defaultCellStyle.ForeColor.IsEmpty && defaultCellStyle.SelectionBackColor.IsEmpty && defaultCellStyle.SelectionForeColor.IsEmpty && defaultCellStyle.Font == null && defaultCellStyle.NullValue.Equals(obj) && defaultCellStyle.IsDataSourceNullValueDefault && CommonUtils.IsNullOrEmpty(defaultCellStyle.Format) && defaultCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && defaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter && defaultCellStyle.WrapMode == DataGridViewTriState.NotSet && defaultCellStyle.Tag == null)
				{
					return !defaultCellStyle.Padding.Equals(Padding.Empty);
				}
			}
			return true;
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewCheckBoxColumn { Name=");
			stringBuilder.Append(base.Name);
			stringBuilder.Append(", Index=");
			stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}
}

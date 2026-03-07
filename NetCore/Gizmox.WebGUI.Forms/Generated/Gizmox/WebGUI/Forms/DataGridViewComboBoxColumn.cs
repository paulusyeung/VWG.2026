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
	/// Represents a column of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ToolboxBitmap(typeof(DataGridViewComboBoxColumn), "DataGridViewComboBoxColumn.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewComboBoxColumn : DataGridViewColumn
	{
		private static Type mobjColumnType;

		/// 
		/// Gets the name of the type.
		/// </summary>
		/// The name of the type.</value>
		protected override string TypeName => "6";

		/// Gets or sets a value indicating whether cells in the column will match the characters being entered in the cell with one from the possible selections. </summary>
		/// true if auto completion is activated; otherwise, false. The default is true.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ComboBoxColumnAutoCompleteDescr")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		[Browsable(true)]
		public bool AutoComplete
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.AutoComplete;
			}
			set
			{
				if (AutoComplete == value)
				{
					return;
				}
				ComboBoxCellTemplate.AutoComplete = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.AutoComplete = value;
					}
				}
			}
		}

		/// Gets or sets the template used to create cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</returns>
		/// <exception cref="T:System.InvalidCastException">When setting this property to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>. </exception>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override DataGridViewCell CellTemplate
		{
			get
			{
				return base.CellTemplate;
			}
			set
			{
				DataGridViewComboBoxCell dataGridViewComboBoxCell = value as DataGridViewComboBoxCell;
				if (value != null && dataGridViewComboBoxCell == null)
				{
					throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", "Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"));
				}
				base.CellTemplate = value;
				if (value != null)
				{
					dataGridViewComboBoxCell.TemplateComboBoxColumn = this;
				}
			}
		}

		private DataGridViewComboBoxCell ComboBoxCellTemplate => (DataGridViewComboBoxCell)CellTemplate;

		/// Gets or sets the data source that populates the selections for the combo boxes.</summary>
		/// An object that represents a data source. The default is null.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridViewDataSourceDescr")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRCategory("CatData")]
		[DefaultValue(null)]
		[AttributeProvider(typeof(Binding.IDataSourceAttributeProvider))]
		public object DataSource
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.DataSource;
			}
			set
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				ComboBoxCellTemplate.DataSource = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.DataSource = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		/// Gets or sets a string that specifies the property or column from which to retrieve strings for display in the combo boxes.</summary>
		/// A <see cref="T:System.String"></see> that specifies the name of a property or column in the data source specified in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.DataSource"></see> property. The default is <see cref="F:System.String.Empty"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[DefaultValue("")]
		[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[SRDescription("DataGridView_ComboBoxColumnDisplayMemberDescr")]
		[SRCategory("CatData")]
		[Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		public string DisplayMember
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.DisplayMember;
			}
			set
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				ComboBoxCellTemplate.DisplayMember = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.DisplayMember = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		/// Gets or sets a value that determines how the combo box is displayed when not editing.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle"></see> value indicating the combo box appearance. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
		[SRDescription("DataGridView_ComboBoxColumnDisplayStyleDescr")]
		[DefaultValue(1)]
		[SRCategory("CatAppearance")]
		public DataGridViewComboBoxDisplayStyle DisplayStyle
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.DisplayStyle;
			}
			set
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				ComboBoxCellTemplate.DisplayStyle = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.DisplayStyleInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Gets or sets a value that determines if the display style only applies to the current cell.</summary>
		/// true if the display style applies only to the current cell; otherwise false. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
		[DefaultValue(false)]
		[SRDescription("DataGridView_ComboBoxColumnDisplayStyleForCurrentCellOnlyDescr")]
		[SRCategory("CatAppearance")]
		public bool DisplayStyleForCurrentCellOnly
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.DisplayStyleForCurrentCellOnly;
			}
			set
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				ComboBoxCellTemplate.DisplayStyleForCurrentCellOnly = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.DisplayStyleForCurrentCellOnlyInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// 
		/// Gets or sets the drop down style.
		/// </summary>
		/// </value>
		[DefaultValue(ComboBoxStyle.DropDownList)]
		public virtual ComboBoxStyle DropDownStyle
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.DropDownStyle;
			}
			set
			{
				if (ComboBoxCellTemplate.DropDownStyle == value)
				{
					return;
				}
				ComboBoxCellTemplate.DropDownStyle = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.DropDownStyle = value;
					}
				}
			}
		}

		/// Gets or sets the width of the drop-down lists of the combo boxes.</summary>
		/// The width, in pixels, of the drop-down lists. The default is 1.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[DefaultValue(1)]
		[SRDescription("DataGridView_ComboBoxColumnDropDownWidthDescr")]
		[SRCategory("CatBehavior")]
		public int DropDownWidth
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.DropDownWidth;
			}
			set
			{
				if (DropDownWidth == value)
				{
					return;
				}
				ComboBoxCellTemplate.DropDownWidth = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.DropDownWidth = value;
					}
				}
			}
		}

		/// Gets or sets the flat style appearance of the column's cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the cell appearance. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_ComboBoxColumnFlatStyleDescr")]
		[DefaultValue(2)]
		public FlatStyle FlatStyle
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewComboBoxCell)CellTemplate).FlatStyle;
			}
			set
			{
				if (FlatStyle == value)
				{
					return;
				}
				((DataGridViewComboBoxCell)CellTemplate).FlatStyle = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.FlatStyleInternal = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		/// Gets the collection of objects used as selections in the combo boxes.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> that represents the selections in the combo boxes. </returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatData")]
		[SRDescription("DataGridView_ComboBoxColumnItemsDescr")]
		[Localizable(true)]
		[Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public DataGridViewComboBoxCell.ObjectCollection Items
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.GetItems(base.DataGridView);
			}
		}

		/// Gets or sets the maximum number of items in the drop-down list of the cells in the column.</summary>
		/// The maximum number of drop-down list items, from 1 to 100. The default is 8.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_ComboBoxColumnMaxDropDownItemsDescr")]
		[DefaultValue(8)]
		public int MaxDropDownItems
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.MaxDropDownItems;
			}
			set
			{
				if (MaxDropDownItems == value)
				{
					return;
				}
				ComboBoxCellTemplate.MaxDropDownItems = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.MaxDropDownItems = value;
					}
				}
			}
		}

		/// Gets or sets a value indicating whether the items in the combo box are sorted.</summary>
		/// true if the combo box is sorted; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_ComboBoxColumnSortedDescr")]
		public bool Sorted
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.Sorted;
			}
			set
			{
				if (Sorted == value)
				{
					return;
				}
				ComboBoxCellTemplate.Sorted = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.Sorted = value;
					}
				}
			}
		}

		/// Gets or sets a string that specifies the property or column from which to get values that correspond to the selections in the drop-down list.</summary>
		/// A <see cref="T:System.String"></see> that specifies the name of a property or column used in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.DataSource"></see> property. The default is <see cref="F:System.String.Empty"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[DefaultValue("")]
		[SRCategory("CatData")]
		[SRDescription("DataGridView_ComboBoxColumnValueMemberDescr")]
		[Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		public string ValueMember
		{
			get
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ComboBoxCellTemplate.ValueMember;
			}
			set
			{
				if (ComboBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				ComboBoxCellTemplate.ValueMember = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
					{
						dataGridViewComboBoxCell.ValueMember = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		static DataGridViewComboBoxColumn()
		{
			mobjColumnType = typeof(DataGridViewComboBoxColumn);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn" /> class.
		/// </summary>
		public DataGridViewComboBoxColumn()
			: this(new DataGridViewComboBoxCell())
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn" /> class.
		/// </summary>
		/// <param name="objDataGridViewCellTemplate">The obj data grid view cell template.</param>
		protected DataGridViewComboBoxColumn(DataGridViewComboBoxCell objDataGridViewCellTemplate)
			: base(objDataGridViewCellTemplate)
		{
			((DataGridViewComboBoxCell)base.CellTemplate).TemplateComboBoxColumn = this;
		}

		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewComboBoxColumn dataGridViewComboBoxColumn = ((!(type == mobjColumnType)) ? ((DataGridViewComboBoxColumn)Activator.CreateInstance(type)) : new DataGridViewComboBoxColumn());
			if (dataGridViewComboBoxColumn != null)
			{
				CloneInternal(dataGridViewComboBoxColumn);
				((DataGridViewComboBoxCell)dataGridViewComboBoxColumn.CellTemplate).TemplateComboBoxColumn = dataGridViewComboBoxColumn;
			}
			return dataGridViewComboBoxColumn;
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
			if (CellTemplate != null && CellTemplate is DataGridViewComboBoxCell)
			{
				((DataGridViewComboBoxCell)CellTemplate).RenderComboboxItems(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
		}

		/// 
		/// Gets the property value.
		/// </summary>
		/// <param name="objSource">The source.</param>
		/// <param name="strPropertyName">Name of the property.</param>
		/// <param name="strDefaultValue">The default value.</param>
		/// </returns>
		private string GetPropertyValue(object objSource, string strPropertyName, string strDefaultValue)
		{
			string result = strDefaultValue;
			if (objSource != null && strPropertyName != string.Empty)
			{
				PropertyInfo property = objSource.GetType().GetProperty(strPropertyName);
				if (property != null)
				{
					object value = property.GetValue(objSource, null);
					if (value != null)
					{
						result = Convert.ToString(value);
					}
				}
			}
			return result;
		}

		internal void OnItemsCollectionChanged()
		{
			if (base.DataGridView == null)
			{
				return;
			}
			DataGridViewRowCollection rows = base.DataGridView.Rows;
			int count = rows.Count;
			object[] objItems = ((DataGridViewComboBoxCell)CellTemplate).Items.InnerArray.ToArray();
			for (int i = 0; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells[base.Index] is DataGridViewComboBoxCell dataGridViewComboBoxCell)
				{
					dataGridViewComboBoxCell.Items.ClearInternal();
					dataGridViewComboBoxCell.Items.AddRangeInternal(objItems);
				}
			}
			base.DataGridView.OnColumnCommonChange(base.Index);
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewComboBoxColumn { Name=");
			stringBuilder.Append(base.Name);
			stringBuilder.Append(", Index=");
			stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}
}

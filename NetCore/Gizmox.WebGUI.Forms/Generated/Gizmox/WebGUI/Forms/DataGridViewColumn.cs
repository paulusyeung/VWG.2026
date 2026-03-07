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
	/// Represents a column in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[TypeConverter(typeof(DataGridViewColumnConverter))]
	[ToolboxItem(false)]
	[DesignTimeVisible(false)]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewColumn : DataGridViewBand, IComponent, IDisposable
	{
		private Type mobjValueType = null;

		private ISite mobjSite;

		private string mstrName;

		private byte mobjFlags;

		private string mstrDataPropertyName;

		private int mintDesiredMinimumWidth;

		private int mintDesiredFillWidth;

		private DataGridViewCell mobjCellTemplate;

		private int mintBoundColumnIndex;

		private DataGridViewAutoSizeColumnMode menmAutoSizeMode;

		private float mfltFillWeight;

		private float mfltUsedFillWeight;

		private int mintDisplayIndex;

		private bool mblnIsExcludedFromColumnChooser;

		private string mstrClientId = string.Empty;

		private bool mblnCanGroupBy = true;

		private bool mblnShowHeaderFilter = false;

		internal string mstrCustomFilterExpression = string.Empty;

		[NonSerialized]
		private TypeConverter mobjBoundColumnConverter;

		private bool mblnAllowRowFiltering = true;

		private const byte DATAGRIDVIEWCOLUMN_automaticSort = 1;

		private const float DATAGRIDVIEWCOLUMN_defaultFillWeight = 100f;

		private const int DATAGRIDVIEWCOLUMN_defaultMinColumnThickness = 5;

		private const int DATAGRIDVIEWCOLUMN_defaultWidth = 100;

		private const byte DATAGRIDVIEWCOLUMN_displayIndexHasChangedInternal = 16;

		private const byte DATAGRIDVIEWCOLUMN_isBrowsableInternal = 8;

		private const byte DATAGRIDVIEWCOLUMN_isDataBound = 4;

		private const byte DATAGRIDVIEWCOLUMN_programmaticSort = 2;

		protected const string TextTypeName = "1";

		protected const string CheckBoxTypeName = "2";

		protected const string ImageTypeName = "3";

		protected const string LinkTypeName = "4";

		protected const string ButtonTypeName = "5";

		protected const string ComboBoxTypeName = "6";

		/// 
		/// Gets or sets a value indicating whether [allowed row filtering].
		/// </summary>
		/// 
		///   true</c> if [allowed row filtering]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public virtual bool AllowRowFiltering
		{
			get
			{
				return mblnAllowRowFiltering;
			}
			set
			{
				if (AllowRowFilteringInternal != value)
				{
					AllowRowFilteringInternal = value;
					if (this.AllowRowFilteringChanged != null)
					{
						this.AllowRowFilteringChanged(this, EventArgs.Empty);
					}
				}
			}
		}

		/// 
		/// Sets a value indicating whether [row filtering is allowed internally].
		/// </summary>
		/// 
		/// 	true</c> if [row filtering is allowed internally]; otherwise, false</c>.
		/// </value>
		internal bool AllowRowFilteringInternal
		{
			get
			{
				return mblnAllowRowFiltering;
			}
			set
			{
				mblnAllowRowFiltering = value;
			}
		}

		/// 
		/// Gets the name of the type.
		/// </summary>
		/// The name of the type.</value>
		protected virtual string TypeName => string.Empty;

		/// 
		/// Gets the type name internal.
		/// </summary>
		/// The type name internal.</value>
		internal string TypeNameInternal => TypeName;

		/// 
		/// Gets or sets a value indicating whether this instance is excluded from column chooser.
		/// </summary>
		/// 
		/// 	true</c> if this instance is excluded from column chooser; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsExcludedFromColumnChooser
		{
			get
			{
				return mblnIsExcludedFromColumnChooser;
			}
			set
			{
				mblnIsExcludedFromColumnChooser = value;
			}
		}

		/// 
		/// Gets the member ID.
		/// </summary>
		/// The member ID.</value>
		protected override string MemberID => "C" + base.Index;

		/// 
		/// Gets the member ID internal.
		/// </summary>
		/// The member ID internal.</value>
		internal new string MemberIDInternal => MemberID;

		/// 
		/// Sets the fill weight internal.
		/// </summary>
		/// The fill weight internal.</value>
		internal float FillWeightInternal
		{
			set
			{
				mfltFillWeight = value;
			}
		}

		/// 
		/// This is a recursive function that loop through a control and all of its parents
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>
		/// </value> 
		/// false if one of the controls is hidden or disabled.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool IsEventsEnabled
		{
			get
			{
				if (!Visible)
				{
					return false;
				}
				return base.IsEventsEnabled;
			}
		}

		/// Gets or sets the mode by which the column automatically adjusts its width.</summary>
		/// A <see cref="T:System.Windows.Forms.DataGridViewAutoSizeColumnMode"></see> value that determines whether the column will automatically adjust its width and how it will determine its preferred width. The default is <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property results in an <see cref="P:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> value of <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> for a visible column when column headers are hidden.-or-The specified value when setting this property results in an <see cref="P:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> value of <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> for a visible column that is frozen.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is a <see cref="T:System.Windows.Forms.DataGridViewAutoSizeColumnMode"></see> that is not valid. </exception>
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("DataGridViewColumn_AutoSizeModeDescr")]
		[SRCategory("CatLayout")]
		[DefaultValue(DataGridViewAutoSizeColumnMode.NotSet)]
		public DataGridViewAutoSizeColumnMode AutoSizeMode
		{
			get
			{
				return menmAutoSizeMode;
			}
			set
			{
				switch (value)
				{
				case DataGridViewAutoSizeColumnMode.NotSet:
				case DataGridViewAutoSizeColumnMode.None:
				case DataGridViewAutoSizeColumnMode.ColumnHeader:
				case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
				case DataGridViewAutoSizeColumnMode.AllCells:
				case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
				case DataGridViewAutoSizeColumnMode.DisplayedCells:
				case DataGridViewAutoSizeColumnMode.Fill:
				{
					if (menmAutoSizeMode == value)
					{
						break;
					}
					if (Visible && base.DataGridView != null)
					{
						if (!base.DataGridView.ColumnHeadersVisible && (value == DataGridViewAutoSizeColumnMode.ColumnHeader || (value == DataGridViewAutoSizeColumnMode.NotSet && base.DataGridView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader)))
						{
							throw new InvalidOperationException(SR.GetString("DataGridViewColumn_AutoSizeCriteriaCannotUseInvisibleHeaders"));
						}
						if (Frozen && (value == DataGridViewAutoSizeColumnMode.Fill || (value == DataGridViewAutoSizeColumnMode.NotSet && base.DataGridView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)))
						{
							throw new InvalidOperationException(SR.GetString("DataGridViewColumn_FrozenColumnCannotAutoFill"));
						}
					}
					DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = InheritedAutoSizeMode;
					bool flag = inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill && inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None && inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet;
					menmAutoSizeMode = value;
					if (base.DataGridView == null)
					{
						if (InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.None || InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
						{
							if (base.Thickness != base.CachedThickness && flag)
							{
								base.ThicknessInternal = base.CachedThickness;
							}
						}
						else if (!flag)
						{
							base.CachedThickness = base.Thickness;
						}
					}
					else
					{
						base.DataGridView.OnAutoSizeColumnModeChanged(this, inheritedAutoSizeMode);
					}
					break;
				}
				default:
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAutoSizeColumnMode));
				}
			}
		}

		/// 
		/// Gets or sets the bound column converter.
		/// </summary>
		/// The bound column converter.</value>
		internal TypeConverter BoundColumnConverter
		{
			get
			{
				return mobjBoundColumnConverter;
			}
			set
			{
				mobjBoundColumnConverter = value;
			}
		}

		/// 
		/// Gets or sets the index of the bound column.
		/// </summary>
		/// The index of the bound column.</value>
		internal int BoundColumnIndex
		{
			get
			{
				return mintBoundColumnIndex;
			}
			set
			{
				mintBoundColumnIndex = value;
			}
		}

		/// Gets or sets the template used to create new cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default is null.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual DataGridViewCell CellTemplate
		{
			get
			{
				return mobjCellTemplate;
			}
			set
			{
				mobjCellTemplate = value;
			}
		}

		/// Gets the run-time type of the cell template.</summary>
		/// The <see cref="T:System.Type"></see> of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> used as a template for this column. The default is null.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public Type CellType => CellTemplate?.GetType();

		/// Gets or sets the name of the data source property or database column to which the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> is bound.</summary>
		/// The name of the property or database column associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(true)]
		[DefaultValue("")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		public string DataPropertyName
		{
			get
			{
				return mstrDataPropertyName;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (value != DataPropertyName)
				{
					mstrDataPropertyName = value;
					if (base.DataGridView != null)
					{
						base.DataGridView.OnColumnDataPropertyNameChanged(this);
					}
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets the column's default cell style.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the default style of the cells in the column.</returns>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
		[Browsable(true)]
		[SRCategory("CatAppearance")]
		public override DataGridViewCellStyle DefaultCellStyle
		{
			get
			{
				return base.DefaultCellStyle;
			}
			set
			{
				if (base.DefaultCellStyle != value)
				{
					base.DefaultCellStyle = value;
					base.DataGridView?.Update();
				}
			}
		}

		/// 
		/// Gets or sets the width of the desired fill.
		/// </summary>
		/// The width of the desired fill.</value>
		internal int DesiredFillWidth
		{
			get
			{
				return mintDesiredFillWidth;
			}
			set
			{
				mintDesiredFillWidth = value;
			}
		}

		/// 
		/// Gets or sets the minimum width of the desired.
		/// </summary>
		/// The minimum width of the desired.</value>
		internal int DesiredMinimumWidth
		{
			get
			{
				return mintDesiredMinimumWidth;
			}
			set
			{
				mintDesiredMinimumWidth = value;
			}
		}

		/// Gets or sets the display order of the column relative to the currently displayed columns.</summary>
		/// The zero-based position of the column as it is displayed in the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, or -1 if the band is not contained within a control. </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> is not null and the specified value when setting this property is less than 0 or greater than or equal to the number of columns in the control.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> is null and the specified value when setting this property is less than -1.-or-The specified value when setting this property is equal to <see cref="F:System.Int32.MaxValue"></see>. </exception>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DisplayIndex
		{
			get
			{
				return mintDisplayIndex;
			}
			set
			{
				if (DisplayIndex == value)
				{
					return;
				}
				if (value == int.MaxValue)
				{
					object[] arrArgs = new object[1] { int.MaxValue.ToString(CultureInfo.CurrentCulture) };
					throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexTooLarge", arrArgs));
				}
				if (base.DataGridView != null)
				{
					if (value < 0)
					{
						throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexNegative"));
					}
					if (value >= base.DataGridView.Columns.Count)
					{
						throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexExceedsColumnCount"));
					}
					base.DataGridView.OnColumnDisplayIndexChanging(this, value);
					mintDisplayIndex = value;
					try
					{
						base.DataGridView.InDisplayIndexAdjustments = true;
						base.DataGridView.OnColumnDisplayIndexChanged_PreNotification();
						base.DataGridView.OnColumnDisplayIndexChanged(this);
						base.DataGridView.OnColumnDisplayIndexChanged_PostNotification();
						return;
					}
					finally
					{
						base.DataGridView.InDisplayIndexAdjustments = false;
					}
				}
				if (value < -1)
				{
					throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexTooNegative"));
				}
				mintDisplayIndex = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [display index has changed].
		/// </summary>
		/// 
		/// 	true</c> if [display index has changed]; otherwise, false</c>.
		/// </value>
		internal bool DisplayIndexHasChanged
		{
			get
			{
				return (Flags & 0x10) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= 16;
				}
				else
				{
					Flags = (byte)(Flags & -17);
				}
			}
		}

		/// 
		/// Sets the display index internal.
		/// </summary>
		/// The display index internal.</value>
		internal int DisplayIndexInternal
		{
			set
			{
				mintDisplayIndex = value;
			}
		}

		/// Gets or sets the width, in pixels, of the column divider.</summary>
		/// The thickness, in pixels, of the divider (the column's right margin). </returns>
		[DefaultValue(0)]
		[SRDescription("DataGridView_ColumnDividerWidthDescr")]
		[SRCategory("CatLayout")]
		public int DividerWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// Gets or sets a value that represents the width of the column when it is in fill mode relative to the widths of other fill-mode columns in the control.</summary>
		/// A <see cref="T:System.Single"></see> representing the width of the column when it is in fill mode relative to the widths of other fill-mode columns. The default is 100.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than or equal to 0. </exception>
		[SRCategory("CatLayout")]
		[SRDescription("DataGridViewColumn_FillWeightDescr")]
		[DefaultValue(100f)]
		public float FillWeight
		{
			get
			{
				return mfltFillWeight;
			}
			set
			{
				if (value <= 0f)
				{
					object[] arrArgs = new object[3]
					{
						"FillWeight",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("FillWeight", SR.GetString("InvalidLowBoundArgument", arrArgs));
				}
				if (value > 65535f)
				{
					object[] arrArgs2 = new object[3]
					{
						"FillWeight",
						value.ToString(CultureInfo.CurrentCulture),
						65535.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("FillWeight", SR.GetString("InvalidHighBoundArgumentEx", arrArgs2));
				}
				if (base.DataGridView != null)
				{
					base.DataGridView.OnColumnFillWeightChanging(this, value);
					mfltFillWeight = value;
					base.DataGridView.OnColumnFillWeightChanged(this);
				}
				else
				{
					mfltFillWeight = value;
				}
			}
		}

		/// Gets or sets a value indicating whether a column will move when a user scrolls the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control horizontally.</summary>
		/// true to freeze the column; otherwise, false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatLayout")]
		[SRDescription("DataGridView_ColumnFrozenDescr")]
		[DefaultValue(false)]
		[RefreshProperties(RefreshProperties.All)]
		public override bool Frozen
		{
			get
			{
				return base.Frozen;
			}
			set
			{
				if (value && base.DataGridView != null && base.DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
				{
					throw new Exception("DataGridView does not support hierarchies with frozen columns");
				}
				base.Frozen = value;
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> that represents the column header.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> that represents the header cell for the column.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataGridViewColumnHeaderCell HeaderCell
		{
			get
			{
				return (DataGridViewColumnHeaderCell)base.HeaderCellCore;
			}
			set
			{
				base.HeaderCellCore = value;
			}
		}

		/// Gets or sets the caption text on the column's header cell.</summary>
		/// A <see cref="T:System.String"></see> with the desired text. The default is an empty string ("").</returns>
		/// 1</filterpriority>
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_ColumnHeaderTextDescr")]
		public string HeaderText
		{
			get
			{
				if (base.HasHeaderCell && HeaderCell.Value is string result)
				{
					return result;
				}
				return string.Empty;
			}
			set
			{
				if ((value != null || base.HasHeaderCell) && HeaderCell.ValueType != null && HeaderCell.ValueType.IsAssignableFrom(typeof(string)))
				{
					HeaderCell.Value = value;
				}
			}
		}

		/// Gets the sizing mode in effect for the column.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value in effect for the column.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataGridViewAutoSizeColumnMode InheritedAutoSizeMode => GetInheritedAutoSizeMode(base.DataGridView);

		/// Gets the cell style currently applied to the column.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the cell style used to display the column.</returns>
		[Browsable(false)]
		public override DataGridViewCellStyle InheritedStyle
		{
			get
			{
				DataGridViewCellStyle dataGridViewCellStyle = null;
				if (base.HasDefaultCellStyle)
				{
					dataGridViewCellStyle = DefaultCellStyle;
				}
				if (base.DataGridView == null)
				{
					return dataGridViewCellStyle;
				}
				DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
				DataGridViewCellStyle defaultCellStyle = base.DataGridView.DefaultCellStyle;
				if (dataGridViewCellStyle != null && !dataGridViewCellStyle.BackColor.IsEmpty)
				{
					dataGridViewCellStyle2.BackColor = dataGridViewCellStyle.BackColor;
				}
				else
				{
					dataGridViewCellStyle2.BackColor = defaultCellStyle.BackColor;
				}
				if (dataGridViewCellStyle != null && !dataGridViewCellStyle.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle2.ForeColor = dataGridViewCellStyle.ForeColor;
				}
				else
				{
					dataGridViewCellStyle2.ForeColor = defaultCellStyle.ForeColor;
				}
				if (dataGridViewCellStyle != null && !dataGridViewCellStyle.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle2.SelectionBackColor = dataGridViewCellStyle.SelectionBackColor;
				}
				else
				{
					dataGridViewCellStyle2.SelectionBackColor = defaultCellStyle.SelectionBackColor;
				}
				if (dataGridViewCellStyle != null && !dataGridViewCellStyle.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle2.SelectionForeColor = dataGridViewCellStyle.SelectionForeColor;
				}
				else
				{
					dataGridViewCellStyle2.SelectionForeColor = defaultCellStyle.SelectionForeColor;
				}
				if (dataGridViewCellStyle != null && dataGridViewCellStyle.Font != null)
				{
					dataGridViewCellStyle2.Font = dataGridViewCellStyle.Font;
				}
				else
				{
					dataGridViewCellStyle2.Font = defaultCellStyle.Font;
				}
				if (dataGridViewCellStyle != null && !dataGridViewCellStyle.IsNullValueDefault)
				{
					dataGridViewCellStyle2.NullValue = dataGridViewCellStyle.NullValue;
				}
				else
				{
					dataGridViewCellStyle2.NullValue = defaultCellStyle.NullValue;
				}
				if (dataGridViewCellStyle != null && !dataGridViewCellStyle.IsDataSourceNullValueDefault)
				{
					dataGridViewCellStyle2.DataSourceNullValue = dataGridViewCellStyle.DataSourceNullValue;
				}
				else
				{
					dataGridViewCellStyle2.DataSourceNullValue = defaultCellStyle.DataSourceNullValue;
				}
				if (dataGridViewCellStyle != null && dataGridViewCellStyle.Format.Length != 0)
				{
					dataGridViewCellStyle2.Format = dataGridViewCellStyle.Format;
				}
				else
				{
					dataGridViewCellStyle2.Format = defaultCellStyle.Format;
				}
				if (dataGridViewCellStyle != null && !dataGridViewCellStyle.IsFormatProviderDefault)
				{
					dataGridViewCellStyle2.FormatProvider = dataGridViewCellStyle.FormatProvider;
				}
				else
				{
					dataGridViewCellStyle2.FormatProvider = defaultCellStyle.FormatProvider;
				}
				if (dataGridViewCellStyle != null && dataGridViewCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
				{
					dataGridViewCellStyle2.AlignmentInternal = dataGridViewCellStyle.Alignment;
				}
				else
				{
					dataGridViewCellStyle2.AlignmentInternal = defaultCellStyle.Alignment;
				}
				if (dataGridViewCellStyle != null && dataGridViewCellStyle.WrapMode != DataGridViewTriState.NotSet)
				{
					dataGridViewCellStyle2.WrapModeInternal = dataGridViewCellStyle.WrapMode;
				}
				else
				{
					dataGridViewCellStyle2.WrapModeInternal = defaultCellStyle.WrapMode;
				}
				if (dataGridViewCellStyle != null && dataGridViewCellStyle.Tag != null)
				{
					dataGridViewCellStyle2.Tag = dataGridViewCellStyle.Tag;
				}
				else
				{
					dataGridViewCellStyle2.Tag = defaultCellStyle.Tag;
				}
				if (dataGridViewCellStyle != null && dataGridViewCellStyle.Padding != Padding.Empty)
				{
					dataGridViewCellStyle2.PaddingInternal = dataGridViewCellStyle.Padding;
					return dataGridViewCellStyle2;
				}
				dataGridViewCellStyle2.PaddingInternal = defaultCellStyle.Padding;
				return dataGridViewCellStyle2;
			}
		}

		/// 
		/// Gets or sets the flags.
		/// </summary>
		/// The flags.</value>
		private byte Flags
		{
			get
			{
				return mobjFlags;
			}
			set
			{
				mobjFlags = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is browsable internal.
		/// </summary>
		/// 
		/// 	true</c> if this instance is browsable internal; otherwise, false</c>.
		/// </value>
		internal bool IsBrowsableInternal
		{
			get
			{
				return (Flags & 8) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= 8;
				}
				else
				{
					Flags = (byte)(Flags & -9);
				}
			}
		}

		/// Gets a value indicating whether the column is bound to a data source.</summary>
		/// true if the column is connected to a data source; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsDataBound => IsDataBoundInternal;

		/// 
		/// Gets the location.
		/// </summary>
		/// The location.</value>
		protected internal override Point Location
		{
			get
			{
				Point empty = Point.Empty;
				if (base.DataGridView != null)
				{
					empty.X += base.DataGridView.Padding.Left + base.DataGridView.Margin.Left;
					empty.Y += base.DataGridView.Padding.Top + base.DataGridView.Margin.Top;
					if (base.DataGridView.ColumnHeadersVisible)
					{
						empty.Y += base.DataGridView.ColumnHeadersHeight;
					}
					if (base.DataGridView.RowHeadersVisible)
					{
						empty.X += base.DataGridView.RowHeadersWidth;
					}
					if (base.DataGridView.Columns.Count > 0)
					{
						DataGridViewColumn dataGridViewColumn = base.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
						while (dataGridViewColumn != null && dataGridViewColumn != this)
						{
							empty.X += dataGridViewColumn.Width;
							dataGridViewColumn = base.DataGridView.Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
						}
					}
					empty.X -= base.DataGridView.ScrollPoisition.X;
				}
				return empty;
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is data bound internal.
		/// </summary>
		/// 
		/// 	true</c> if this instance is data bound internal; otherwise, false</c>.
		/// </value>
		internal bool IsDataBoundInternal
		{
			get
			{
				return (Flags & 4) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= 4;
				}
				else
				{
					Flags = (byte)(Flags & -5);
				}
			}
		}

		/// Gets or sets the minimum width, in pixels, of the column.</summary>
		/// The number of pixels, from 2 to <see cref="F:System.Int32.MaxValue"></see>, that specifies the minimum width of the column. The default is 5.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 2 or greater than <see cref="F:System.Int32.MaxValue"></see>.</exception>
		/// 1</filterpriority>
		[DefaultValue(5)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[SRDescription("DataGridView_ColumnMinimumWidthDescr")]
		[SRCategory("CatLayout")]
		public int MinimumWidth
		{
			get
			{
				return base.MinimumThickness;
			}
			set
			{
				base.MinimumThickness = value;
			}
		}

		/// Gets or sets the name of the column.</summary>
		/// A <see cref="T:System.String"></see> that contains the name of the column. The default is an empty string ("").</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public string Name
		{
			get
			{
				if (Site != null && !CommonUtils.IsNullOrEmpty(Site.Name))
				{
					mstrName = Site.Name;
				}
				return mstrName;
			}
			set
			{
				if (CommonUtils.IsNullOrEmpty(value))
				{
					mstrName = string.Empty;
				}
				else
				{
					mstrName = value;
				}
				if (base.DataGridView != null && !ClientUtils.IsEquals(Name, mstrName, StringComparison.Ordinal))
				{
					base.DataGridView.OnColumnNameChanged(this);
					base.DataGridView.Update();
				}
			}
		}

		/// Gets or sets a value indicating whether the user can edit the column's cells.</summary>
		/// true if the user cannot edit the column's cells; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">This property is set to false for a column that is bound to a read-only data source. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnReadOnlyDescr")]
		[SRCategory("CatBehavior")]
		public override bool ReadOnly
		{
			get
			{
				return base.ReadOnly;
			}
			set
			{
				int boundColumnIndex = BoundColumnIndex;
				if (IsDataBound && base.DataGridView != null && base.DataGridView.DataConnection != null && boundColumnIndex != -1 && base.DataGridView.DataConnection.DataFieldIsReadOnly(boundColumnIndex) && !value)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_ColumnBoundToAReadOnlyFieldMustRemainReadOnly"));
				}
				if (value != ReadOnly && base.DataGridView != null)
				{
					base.DataGridView.Update();
				}
				base.ReadOnly = value;
			}
		}

		/// Gets or sets a value indicating whether the column is resizable.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.True"></see>.</returns>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnResizableDescr")]
		[SRCategory("CatBehavior")]
		public override DataGridViewTriState Resizable
		{
			get
			{
				return base.Resizable;
			}
			set
			{
				base.Resizable = value;
			}
		}

		/// Gets or sets the site of the column.</summary>
		/// The <see cref="T:System.ComponentModel.ISite"></see> associated with the column, if any.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ISite Site
		{
			get
			{
				return mobjSite;
			}
			set
			{
				mobjSite = value;
			}
		}

		/// 
		/// Gets or sets the client id.
		/// </summary>
		/// 
		/// The client id.
		/// </value>
		[DefaultValue("")]
		public string ClientId
		{
			get
			{
				return mstrClientId;
			}
			set
			{
				mstrClientId = value;
			}
		}

		/// Gets or sets the sort mode for the column.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode"></see> that specifies the criteria used to order the rows based on the cell values in a column.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value assigned to the property conflicts with <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see>. </exception>
		/// 1</filterpriority>
		[DefaultValue(DataGridViewColumnSortMode.NotSortable)]
		[SRDescription("DataGridView_ColumnSortModeDescr")]
		[SRCategory("CatBehavior")]
		public DataGridViewColumnSortMode SortMode
		{
			get
			{
				byte flags = Flags;
				if ((flags & 1) != 0)
				{
					return DataGridViewColumnSortMode.Automatic;
				}
				if ((flags & 2) != 0)
				{
					return DataGridViewColumnSortMode.Programmatic;
				}
				return DataGridViewColumnSortMode.NotSortable;
			}
			set
			{
				if (value == SortMode)
				{
					return;
				}
				if (value != DataGridViewColumnSortMode.NotSortable)
				{
					if (base.DataGridView != null && !base.DataGridView.InInitialization && value == DataGridViewColumnSortMode.Automatic && (base.DataGridView.SelectionMode == DataGridViewSelectionMode.FullColumnSelect || base.DataGridView.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
					{
						throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", value.ToString(), base.DataGridView.SelectionMode.ToString()));
					}
					if (value == DataGridViewColumnSortMode.Automatic)
					{
						Flags = (byte)(Flags & -3);
						Flags |= 1;
					}
					else
					{
						Flags = (byte)(Flags & -2);
						Flags |= 2;
					}
				}
				else
				{
					Flags = (byte)(Flags & -2);
					Flags = (byte)(Flags & -3);
				}
				if (base.DataGridView != null)
				{
					base.DataGridView.OnColumnSortModeChanged(this);
				}
			}
		}

		/// Gets or sets the text used for ToolTips.</summary>
		/// The text to display as a ToolTip for the column.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[SRDescription("DataGridView_ColumnToolTipTextDescr")]
		[DefaultValue("")]
		public string ToolTipText
		{
			get
			{
				return HeaderCell.ToolTipText;
			}
			set
			{
				if (string.Compare(ToolTipText, value, ignoreCase: false, CultureInfo.InvariantCulture) != 0)
				{
					HeaderCell.ToolTipText = value;
					if (base.DataGridView != null)
					{
						base.DataGridView.OnColumnToolTipTextChanged(this);
					}
				}
			}
		}

		/// 
		/// Gets or sets the used fill weight.
		/// </summary>
		/// The used fill weight.</value>
		internal float UsedFillWeight
		{
			get
			{
				return mfltUsedFillWeight;
			}
			set
			{
				mfltUsedFillWeight = value;
			}
		}

		/// Gets or sets the data type of the values in the column's cells.</summary>
		/// A <see cref="T:System.Type"></see> that describes the run-time class of the values stored in the column's cells.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DefaultValue(null)]
		public Type ValueType
		{
			get
			{
				return mobjValueType;
			}
			set
			{
				mobjValueType = value;
			}
		}

		/// Gets or sets a value indicating whether the column is visible.</summary>
		/// true if the column is visible; otherwise, false.</returns>
		/// 1</filterpriority>
		[Localizable(true)]
		[SRDescription("DataGridView_ColumnVisibleDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		public override bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				if (base.Visible != value)
				{
					base.Visible = value;
					if (!value)
					{
						ClearFilter(blnClearHeaderFilter: true);
					}
					base.DataGridView?.SwitchPreRenderUpdate(DataGridView.PreRenderUpdateType.GroupHeaders);
				}
			}
		}

		/// 
		/// Gets or sets the custom filter expression.
		/// </summary>
		/// 
		/// The custom filter expression.
		/// </value>
		[DefaultValue("")]
		public string CustomFilterExpression
		{
			get
			{
				return mstrCustomFilterExpression;
			}
			set
			{
				if (mstrCustomFilterExpression != value)
				{
					mstrCustomFilterExpression = value;
					DataGridView dataGridView = base.DataGridView;
					if (dataGridView != null && !dataGridView.mblnSuspendFilterInitialization)
					{
						dataGridView.ApplyDataGridViewFilter();
					}
				}
			}
		}

		/// Gets or sets the current width of the column.</summary>
		/// The width, in pixels, of the column. The default is 100.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is greater than 65536.</exception>
		/// 1</filterpriority>
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("DataGridView_ColumnWidthDescr")]
		[SRCategory("CatLayout")]
		[Localizable(true)]
		public int Width
		{
			get
			{
				return base.Thickness;
			}
			set
			{
				base.Thickness = value;
			}
		}

		/// Gets or sets the shortcut menu for the column.</summary>
		/// The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the current <see cref="T:System.Windows.Forms.DataGridViewColumn"></see>. The default is null.</returns>
		[SRDescription("DataGridView_ColumnContextMenuStripDescr")]
		[DefaultValue(null)]
		[SRCategory("CatBehavior")]
		public override ContextMenu ContextMenu
		{
			get
			{
				return base.ContextMenu;
			}
			set
			{
				base.ContextMenu = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether the user can group by this column.
		/// </summary>
		/// 
		/// 	true</c> if the user can group by this column; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool CanGroupBy
		{
			get
			{
				return mblnCanGroupBy;
			}
			set
			{
				if (mblnCanGroupBy != value)
				{
					mblnCanGroupBy = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show header filter].
		/// </summary>
		/// 
		///   true</c> if [show header filter]; otherwise, false</c>.
		/// </value>
		internal bool ShowHeaderFilter
		{
			get
			{
				return mblnShowHeaderFilter;
			}
			set
			{
				if (mblnShowHeaderFilter != value)
				{
					mblnShowHeaderFilter = value;
					DataGridViewColumnHeaderCell headerCell = HeaderCell;
					if (headerCell != null)
					{
						headerCell.ShouldPreRenderHeaderFilter = mblnShowHeaderFilter;
						headerCell.Update();
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is custom filter.
		/// </summary>
		/// 
		/// 	true</c> if this instance is custom filter; otherwise, false</c>.
		/// </value>
		internal bool IsCustomFilter
		{
			get
			{
				return HeaderCell?.FilterComboBox.IsCustomFilter ?? false;
			}
			set
			{
				DataGridViewColumnHeaderCell headerCell = HeaderCell;
				if (headerCell != null)
				{
					headerCell.FilterComboBox.IsCustomFilter = value;
				}
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> is disposed.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event EventHandler Disposed;

		/// 
		/// Occurs when [allow row filtering changed].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event EventHandler AllowRowFilteringChanged;

		/// 
		/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn" /> class.
		/// </summary>
		static DataGridViewColumn()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> class to the default state.
		/// </summary>
		public DataGridViewColumn()
			: this(null)
		{
			base.TagName = "DC";
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> class using an existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> as a template.</summary>
		/// <param name="objCellTemplate">An existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to use as a template. </param>
		public DataGridViewColumn(DataGridViewCell objCellTemplate)
		{
			base.TagName = "DC";
			BoundColumnIndex = -1;
			DataPropertyName = string.Empty;
			mfltFillWeight = 100f;
			mfltUsedFillWeight = 100f;
			base.Thickness = 100;
			base.MinimumThickness = 5;
			base.BandIsRow = false;
			mstrName = string.Empty;
			mintDisplayIndex = -1;
			CellTemplate = objCellTemplate;
			AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
			DataGridViewColumnHeaderCell headerCell = HeaderCell;
		}

		/// 
		/// Renders the column's inner components
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
			if (HeaderCell != null)
			{
				((IRenderableComponentMember)HeaderCell).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
		}

		/// 
		/// Pres the render component.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		internal override void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
			base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
			HeaderFilterInfo columnHeaderInfo = base.DataGridView.GetColumnHeaderInfo(this);
			if (columnHeaderInfo == null)
			{
				ShowHeaderFilter = false;
			}
			else
			{
				ShowHeaderFilter = true;
				IsCustomFilter = columnHeaderInfo.IsCustomFilter;
			}
			HeaderCell?.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
		}

		/// 
		/// Posts the render component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePostRender">if set to true</c> [BLN force post render].</param>
		internal override void PostRenderComponent(IContext objContext, long lngRequestID, bool blnForcePostRender)
		{
			base.PreRenderComponent(objContext, lngRequestID, blnForcePostRender);
			HeaderCell?.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
		}

		/// 
		/// Renders the DataGridViewColumn attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			RenderDataPropertyName(objWriter);
			objWriter.WriteAttributeString("W", Width.ToString());
			if (base.DataGridView.ShowCellToolTips && ToolTipText != null && ToolTipText != string.Empty)
			{
				objWriter.WriteAttributeText("TT", ToolTipText);
			}
			objWriter.WriteAttributeString("TP", TypeName);
			if (Resizable == DataGridViewTriState.False || (AutoSizeMode != DataGridViewAutoSizeColumnMode.None && base.DataGridView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.Fill && base.DataGridView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.None))
			{
				objWriter.WriteAttributeString("RE", "0");
			}
			string clientId = ClientId;
			if (!string.IsNullOrEmpty(clientId))
			{
				objWriter.WriteAttributeString("CID", clientId);
			}
			RenderCanGroupByAttribute(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the updated attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderDataPropertyName(objWriter);
				RenderCanGroupByAttribute(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				objWriter.WriteAttributeString("W", Width.ToString());
			}
		}

		/// 
		/// Renders the can group by attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderCanGroupByAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!mblnCanGroupBy || blnForceRender)
			{
				objWriter.WriteAttributeString("CG", mblnCanGroupBy ? "1" : "0");
			}
		}

		/// 
		/// Renders the name of the data property.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [p].</param>
		private void RenderDataPropertyName(IAttributeWriter objWriter)
		{
			if (!string.IsNullOrEmpty(DataPropertyName))
			{
				objWriter.WriteAttributeText("N", DataPropertyName);
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (base.DataGridView != null && base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED))
			{
				criticalEventsData.Set("SC");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the inherited auto size mode.
		/// </summary>
		/// <param name="objDataGridView">The data grid view.</param>
		/// </returns>
		internal DataGridViewAutoSizeColumnMode GetInheritedAutoSizeMode(DataGridView objDataGridView)
		{
			DataGridViewAutoSizeColumnMode autoSizeMode = AutoSizeMode;
			if (objDataGridView == null || autoSizeMode != DataGridViewAutoSizeColumnMode.NotSet)
			{
				return autoSizeMode;
			}
			return objDataGridView.AutoSizeColumnsMode switch
			{
				DataGridViewAutoSizeColumnsMode.ColumnHeader => DataGridViewAutoSizeColumnMode.ColumnHeader, 
				DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader => DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, 
				DataGridViewAutoSizeColumnsMode.AllCells => DataGridViewAutoSizeColumnMode.AllCells, 
				DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader => DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader, 
				DataGridViewAutoSizeColumnsMode.DisplayedCells => DataGridViewAutoSizeColumnMode.DisplayedCells, 
				DataGridViewAutoSizeColumnsMode.Fill => DataGridViewAutoSizeColumnMode.Fill, 
				_ => DataGridViewAutoSizeColumnMode.None, 
			};
		}

		/// Calculates the ideal width of the column based on the specified criteria.</summary>
		/// The ideal width, in pixels, of the column.</returns>
		/// <param name="enmAutoSizeColumnMode">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value that specifies an automatic sizing mode. </param>
		/// <param name="blnFixedHeight">true to calculate the width of the column based on the current row heights; false to calculate the width with the expectation that the row heights will be adjusted.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value. </exception>
		/// <exception cref="T:System.ArgumentException">autoSizeColumnMode is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see>. </exception>
		public virtual int GetPreferredWidth(DataGridViewAutoSizeColumnMode enmAutoSizeColumnMode, bool blnFixedHeight)
		{
			if (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.NotSet || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.None || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.Fill)
			{
				throw new ArgumentException(SR.GetString("DataGridView_NeedColumnAutoSizingCriteria", "autoSizeColumnMode"));
			}
			switch (enmAutoSizeColumnMode)
			{
			case DataGridViewAutoSizeColumnMode.NotSet:
			case DataGridViewAutoSizeColumnMode.None:
			case DataGridViewAutoSizeColumnMode.ColumnHeader:
			case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
			case DataGridViewAutoSizeColumnMode.AllCells:
			case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
			case DataGridViewAutoSizeColumnMode.DisplayedCells:
			case DataGridViewAutoSizeColumnMode.Fill:
			{
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView == null)
				{
					return -1;
				}
				int num = 0;
				if (dataGridView.ColumnHeadersVisible && (enmAutoSizeColumnMode & DataGridViewAutoSizeColumnMode.ColumnHeader) != DataGridViewAutoSizeColumnMode.NotSet)
				{
					int num2 = ((!blnFixedHeight) ? HeaderCell.GetPreferredSize(-1).Width : HeaderCell.GetPreferredWidth(-1, dataGridView.ColumnHeadersHeight));
					if (num < num2)
					{
						num = num2;
					}
				}
				if ((enmAutoSizeColumnMode & DataGridViewAutoSizeColumnMode.AllCellsExceptHeader) != DataGridViewAutoSizeColumnMode.NotSet)
				{
					for (int num3 = dataGridView.Rows.GetFirstRow(DataGridViewElementStates.Visible); num3 != -1; num3 = dataGridView.Rows.GetNextRow(num3, DataGridViewElementStates.Visible))
					{
						DataGridViewRow dataGridViewRow = dataGridView.Rows.SharedRow(num3);
						int num2 = ((!blnFixedHeight) ? dataGridViewRow.Cells[base.Index].GetPreferredSize(num3).Width : dataGridViewRow.Cells[base.Index].GetPreferredWidth(num3, dataGridViewRow.Thickness));
						if (num < num2)
						{
							num = num2;
						}
					}
					return num;
				}
				if ((enmAutoSizeColumnMode & DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader) != DataGridViewAutoSizeColumnMode.NotSet)
				{
					int height = dataGridView.LayoutInfo.Data.Height;
					int num4 = 0;
					int num3 = dataGridView.Rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
					while (num3 != -1 && num4 < height)
					{
						DataGridViewRow dataGridViewRow = dataGridView.Rows.SharedRow(num3);
						int num2 = ((!blnFixedHeight) ? dataGridViewRow.Cells[base.Index].GetPreferredSize(num3).Width : dataGridViewRow.Cells[base.Index].GetPreferredWidth(num3, dataGridViewRow.Thickness));
						if (num < num2)
						{
							num = num2;
						}
						num4 += dataGridViewRow.Thickness;
						num3 = dataGridView.Rows.GetNextRow(num3, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
					}
					if (num4 >= height)
					{
						return num;
					}
					num3 = dataGridView.FirstDisplayedScrollingRowIndex;
					while (num3 != -1 && num4 < height)
					{
						DataGridViewRow dataGridViewRow = dataGridView.Rows.SharedRow(num3);
						int num2 = ((!blnFixedHeight) ? dataGridViewRow.Cells[base.Index].GetPreferredSize(num3).Width : dataGridViewRow.Cells[base.Index].GetPreferredWidth(num3, dataGridViewRow.Thickness));
						if (num < num2)
						{
							num = num2;
						}
						num4 += dataGridViewRow.Thickness;
						num3 = dataGridView.Rows.GetNextRow(num3, DataGridViewElementStates.Visible);
					}
				}
				return num;
			}
			default:
				throw new InvalidEnumArgumentException("value", (int)enmAutoSizeColumnMode, typeof(DataGridViewAutoSizeColumnMode));
			}
		}

		/// 
		/// Shoulds the serialize default cell style.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeDefaultCellStyle()
		{
			if (!base.HasDefaultCellStyle)
			{
				return false;
			}
			DataGridViewCellStyle defaultCellStyle = DefaultCellStyle;
			if (defaultCellStyle.BackColor.IsEmpty && defaultCellStyle.ForeColor.IsEmpty && defaultCellStyle.SelectionBackColor.IsEmpty && defaultCellStyle.SelectionForeColor.IsEmpty && defaultCellStyle.Font == null && defaultCellStyle.IsNullValueDefault && defaultCellStyle.IsDataSourceNullValueDefault && CommonUtils.IsNullOrEmpty(defaultCellStyle.Format) && defaultCellStyle.FormatProvider != null && defaultCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && defaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet && defaultCellStyle.WrapMode == DataGridViewTriState.NotSet && defaultCellStyle.Tag == null)
			{
				return !defaultCellStyle.Padding.Equals(Padding.Empty);
			}
			return true;
		}

		/// 
		/// Shoulds the serialize header text.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeHeaderText()
		{
			if (base.HasHeaderCell)
			{
				return HeaderCell.ContainsLocalValue;
			}
			return false;
		}

		/// 
		/// Shoulds serialize the column width.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeWidth()
		{
			return InheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill && Width != 100;
		}

		/// Gets a string that describes the column.</summary>
		/// A <see cref="T:System.String"></see> that describes the column.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewColumn { Name=");
			stringBuilder.Append(Name);
			stringBuilder.Append(", Index=");
			stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (!(type == "Resize"))
			{
				if (type == "DividerDoubleClick")
				{
					DataGridView dataGridView = base.DataGridView;
					if (dataGridView != null)
					{
						Point cursorPosition = objEvent.CursorPosition;
						bool flag = true;
						dataGridView.RaiseColumnDividerDoubleClick(new DataGridViewColumnDividerDoubleClickEventArgs(base.Index, new HandledMouseEventArgs(MouseButtons.Left, 2, cursorPosition.X, cursorPosition.X, 280)));
					}
				}
				return;
			}
			double num = Convert.ToDouble(objEvent["VLB"], CultureInfo.InvariantCulture);
			if (num > 5.0)
			{
				base.ThicknessInternal = Convert.ToInt32(num);
				if (base.DataGridView.NeedToAdjustFillingColumns)
				{
					base.DataGridView.ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
				}
			}
		}

		/// 
		/// Clears the filter of this column.
		/// </summary>
		/// <param name="blnClearHeaderFilter">if set to true</c> [BLN clear header filter].</param>
		public void ClearFilter(bool blnClearHeaderFilter)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null && dataGridView.ShowFilterRow && dataGridView.FilterRow != null && dataGridView.FilterRow.Cells.Count > 0 && dataGridView.FilterRow.Cells.Count > base.Index)
			{
				(dataGridView.FilterRow.Cells[base.Index] as DataGridViewFilterCell).ClearFilter(blnClearHeaderFilter);
				return;
			}
			if (HasHeaderCell && ShowHeaderFilter)
			{
				HeaderCell.FilterComboBox.SelectedIndex = -1;
				HeaderCell.FilterComboBox.Text = string.Empty;
			}
			CustomFilterExpression = string.Empty;
		}

		/// 
		/// Clones the internal.
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		protected void CloneInternal(DataGridViewComboBoxColumn objDataGridViewColumn)
		{
			CloneInternal((DataGridViewBand)objDataGridViewColumn);
			objDataGridViewColumn.Name = Name;
			mintDisplayIndex = -1;
			objDataGridViewColumn.HeaderText = HeaderText;
			objDataGridViewColumn.DataPropertyName = DataPropertyName;
			if (objDataGridViewColumn.CellTemplate != null)
			{
				objDataGridViewColumn.CellTemplate = (DataGridViewCell)CellTemplate.Clone();
			}
			else
			{
				objDataGridViewColumn.CellTemplate = null;
			}
			if (base.HasHeaderCell)
			{
				objDataGridViewColumn.HeaderCell = (DataGridViewColumnHeaderCell)HeaderCell.Clone();
			}
			objDataGridViewColumn.AutoSizeMode = AutoSizeMode;
			objDataGridViewColumn.SortMode = SortMode;
		}

		/// 
		/// Determines whether [has filter info].
		/// </summary>
		/// 
		///   true</c> if [has filter info]; otherwise, false</c>.
		/// </returns>
		internal bool HasFilterInfo()
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				return dataGridView.GetColumnHeaderInfo(this) != null;
			}
			return false;
		}
	}
}

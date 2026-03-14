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
	/// Collects the characteristics associated with table layouts.
	/// </summary>
	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[TypeConverter(typeof(TableLayoutSettingsTypeConverter))]
	public sealed class TableLayoutSettings : LayoutSettings, ISerializable, IObservableItem
	{
		[Serializable]
		public class StyleConverter : TypeConverter
		{
			public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
			{
				return objDestinationType == typeof(InstanceDescriptor) || base.CanConvertTo(objContext, objDestinationType);
			}

			/// 
			///
			/// </summary>
			/// 
			/// The function essentially limited to work in Partially trusted environment.
			/// InstanceDescriptor c'tor is requiring Full trust (.NET 2.0 - 3.5)
			/// </remarks>
			public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
			{
				if (objDestinationType == null)
				{
					throw new ArgumentNullException("objDestinationType");
				}
				if (objDestinationType == typeof(InstanceDescriptor) && objValue is TableLayoutStyle)
				{
					object obj = ConvertToInstanceDescriptor(objContext, objValue);
					if (obj != null)
					{
						return obj;
					}
				}
				return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
			}

			/// 
			/// Convert to InstanceDescriptor
			/// </summary>
			/// 
			/// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
			/// </remarks>
			private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
			{
				TableLayoutStyle tableLayoutStyle = (TableLayoutStyle)objValue;
				switch (tableLayoutStyle.SizeType)
				{
				case SizeType.AutoSize:
					return new InstanceDescriptor(tableLayoutStyle.GetType().GetConstructor(new Type[0]), new object[0]);
				case SizeType.Absolute:
				case SizeType.Percent:
					return new InstanceDescriptor(tableLayoutStyle.GetType().GetConstructor(new Type[2]
					{
						typeof(SizeType),
						typeof(int)
					}), new object[2] { tableLayoutStyle.SizeType, tableLayoutStyle.Size });
				default:
					return null;
				}
			}
		}

		[Serializable]
		private class TableLayoutSettingsStub
		{
			private TableLayoutColumnStyleCollection mobjColumnStyles;

			private Dictionary<object, ControlInformation> mobjControlsInfo;

			private static ControlInformation mobjDefaultControlInfo = new ControlInformation(null, -1, -1, 1, 1);

			private bool mblnIsValid = true;

			private TableLayoutRowStyleCollection mobjRowStyles;

			public TableLayoutColumnStyleCollection ColumnStyles
			{
				get
				{
					if (mobjColumnStyles == null)
					{
						mobjColumnStyles = new TableLayoutColumnStyleCollection();
					}
					return mobjColumnStyles;
				}
			}

			public bool IsValid => mblnIsValid;

			public TableLayoutRowStyleCollection RowStyles
			{
				get
				{
					if (mobjRowStyles == null)
					{
						mobjRowStyles = new TableLayoutRowStyleCollection();
					}
					return mobjRowStyles;
				}
			}

			public int GetColumn(object objControlName)
			{
				return GetControlInformation(objControlName).Column;
			}

			public int GetColumnSpan(object objControlName)
			{
				return GetControlInformation(objControlName).ColumnSpan;
			}

			public int GetRow(object objControlName)
			{
				return GetControlInformation(objControlName).Row;
			}

			public int GetRowSpan(object objControlName)
			{
				return GetControlInformation(objControlName).RowSpan;
			}

			public void SetColumn(object objControlName, int intColumn)
			{
				if (GetColumn(objControlName) != intColumn)
				{
					ControlInformation controlInformation = GetControlInformation(objControlName);
					controlInformation.Column = intColumn;
					SetControlInformation(objControlName, controlInformation);
				}
			}

			public void SetColumnSpan(object objControlName, int intValue)
			{
				if (GetColumnSpan(objControlName) != intValue)
				{
					ControlInformation controlInformation = GetControlInformation(objControlName);
					controlInformation.ColumnSpan = intValue;
					SetControlInformation(objControlName, controlInformation);
				}
			}

			public void SetRow(object objControlName, int intRow)
			{
				if (GetRow(objControlName) != intRow)
				{
					ControlInformation controlInformation = GetControlInformation(objControlName);
					controlInformation.Row = intRow;
					SetControlInformation(objControlName, controlInformation);
				}
			}

			public void SetRowSpan(object objControlName, int intValue)
			{
				if (GetRowSpan(objControlName) != intValue)
				{
					ControlInformation controlInformation = GetControlInformation(objControlName);
					controlInformation.RowSpan = intValue;
					SetControlInformation(objControlName, controlInformation);
				}
			}

			private ControlInformation GetControlInformation(object objControlName)
			{
				if (mobjControlsInfo == null)
				{
					return mobjDefaultControlInfo;
				}
				if (!mobjControlsInfo.ContainsKey(objControlName))
				{
					return mobjDefaultControlInfo;
				}
				return mobjControlsInfo[objControlName];
			}

			private void SetControlInformation(object objControlName, ControlInformation objControlInformation)
			{
				if (mobjControlsInfo == null)
				{
					mobjControlsInfo = new Dictionary<object, ControlInformation>();
				}
				mobjControlsInfo[objControlName] = objControlInformation;
			}

			internal void ApplySettings(TableLayoutSettings objSettings)
			{
				TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objSettings.Owner);
				if (containerInfo.Container is Control control && mobjControlsInfo != null)
				{
					foreach (object key in mobjControlsInfo.Keys)
					{
						ControlInformation controlInformation = mobjControlsInfo[key];
						foreach (Control control2 in control.Controls)
						{
							if (control2 != null)
							{
								string @string = null;
								PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(control2)["Name"];
								if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(string))
								{
									@string = propertyDescriptor.GetValue(control2) as string;
								}
								if (ClientUtils.SafeCompareStrings(@string, key as string, blnIgnoreCase: false))
								{
									objSettings.SetRow(control2, controlInformation.Row);
									objSettings.SetColumn(control2, controlInformation.Column);
									objSettings.SetRowSpan(control2, controlInformation.RowSpan);
									objSettings.SetColumnSpan(control2, controlInformation.ColumnSpan);
									break;
								}
							}
						}
					}
				}
				containerInfo.RowStyles = mobjRowStyles;
				containerInfo.ColumnStyles = mobjColumnStyles;
				mobjColumnStyles = null;
				mobjRowStyles = null;
				mblnIsValid = false;
			}

			internal List<object> GetControlsInformation()
			{
				if (mobjControlsInfo == null)
				{
					return new List<object>();
				}
				List<object> list = new List<object><object>(mobjControlsInfo.Count);
				foreach (object key in mobjControlsInfo.Keys)
				{
					ControlInformation item = mobjControlsInfo[key];
					item.Name = key;
					list.Add(item);
				}
				return list;
			}
		}

		[Serializable]
		internal struct ControlInformation
		{
			internal object Name;

			internal int Row;

			internal int Column;

			internal int RowSpan;

			internal int ColumnSpan;

			internal ControlInformation(object objName, int intRow, int intColumn, int intRowSpan, int intColumnSpan)
			{
				Name = objName;
				Row = intRow;
				Column = intColumn;
				RowSpan = intRowSpan;
				ColumnSpan = intColumnSpan;
			}
		}

		private TableLayoutPanelCellBorderStyle menmBorderStyle;

		private TableLayoutSettingsStub mobjTableLayoutSettingsStub;

		private static int[] marrBorderStyleToOffset = new int[7] { 0, 1, 2, 3, 2, 3, 3 };

		[SRDescription("TableLayoutPanelCellBorderStyleDescr")]
		[DefaultValue(0)]
		[SRCategory("CatAppearance")]
		internal TableLayoutPanelCellBorderStyle CellBorderStyle
		{
			get
			{
				return menmBorderStyle;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 6))
				{
					throw new ArgumentException(SR.GetString("InvalidArgument", "CellBorderStyle", value.ToString()));
				}
				menmBorderStyle = value;
				FireObservableItemPropertyChanged("CellBorderStyle");
				TableLayout.GetContainerInfo(base.Owner).CellBorderWidth = marrBorderStyleToOffset[(int)value];
			}
		}

		[DefaultValue(0)]
		internal int CellBorderWidth => TableLayout.GetContainerInfo(base.Owner).CellBorderWidth;

		/// 
		/// Gets or sets the column count.
		/// </summary>
		/// The column count.</value>
		[DefaultValue(0)]
		[SRDescription("GridPanelColumnsDescr")]
		[SRCategory("CatLayout")]
		public int ColumnCount
		{
			get
			{
				return TableLayout.GetContainerInfo(base.Owner).MaxColumns;
			}
			set
			{
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"ColumnCount",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ColumnCount", value, SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				TableLayout.GetContainerInfo(base.Owner).MaxColumns = value;
				FireObservableItemPropertyChanged("ColumnCount");
			}
		}

		/// 
		/// Gets the column styles.
		/// </summary>
		/// The column styles.</value>
		[SRCategory("CatLayout")]
		[SRDescription("GridPanelColumnStylesDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TableLayoutColumnStyleCollection ColumnStyles
		{
			get
			{
				if (IsStub)
				{
					return mobjTableLayoutSettingsStub.ColumnStyles;
				}
				return TableLayout.GetContainerInfo(base.Owner).ColumnStyles;
			}
		}

		/// 
		/// Gets or sets the grow style.
		/// </summary>
		/// The grow style.</value>
		[SRDescription("TableLayoutPanelGrowStyleDescr")]
		[DefaultValue(1)]
		[SRCategory("CatLayout")]
		public TableLayoutPanelGrowStyle GrowStyle
		{
			get
			{
				return TableLayout.GetContainerInfo(base.Owner).GrowStyle;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new ArgumentException(SR.GetString("InvalidArgument", "GrowStyle", value.ToString()));
				}
				TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(base.Owner);
				if (containerInfo.GrowStyle != value)
				{
					containerInfo.GrowStyle = value;
					FireObservableItemPropertyChanged("GrowStyle");
				}
			}
		}

		internal bool IsStub => mobjTableLayoutSettingsStub != null;

		/// 
		/// Gets the layout engine.
		/// </summary>
		/// The layout engine.</value>
		public override LayoutEngine LayoutEngine => TableLayout.Instance;

		/// 
		/// Gets or sets the row count.
		/// </summary>
		/// The row count.</value>
		[SRDescription("GridPanelRowsDescr")]
		[DefaultValue(0)]
		[SRCategory("CatLayout")]
		public int RowCount
		{
			get
			{
				return TableLayout.GetContainerInfo(base.Owner).MaxRows;
			}
			set
			{
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"RowCount",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("RowCount", value, SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				TableLayout.GetContainerInfo(base.Owner).MaxRows = value;
				FireObservableItemPropertyChanged("RowCount");
			}
		}

		/// 
		/// Gets the row styles.
		/// </summary>
		/// The row styles.</value>
		[SRDescription("GridPanelRowStylesDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatLayout")]
		public TableLayoutRowStyleCollection RowStyles
		{
			get
			{
				if (IsStub)
				{
					return mobjTableLayoutSettingsStub.RowStyles;
				}
				return TableLayout.GetContainerInfo(base.Owner).RowStyles;
			}
		}

		private TableLayout TableLayout => (TableLayout)LayoutEngine;

		/// 
		/// Property change indicator for the observable item interface
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

		internal TableLayoutSettings(SerializationInfo objSerializationInfo, StreamingContext objContext)
			: base(null)
		{
			mobjOwner = objSerializationInfo.GetValue("Owner", typeof(IArrangedElement)) as IArrangedElement;
			if (mobjOwner == null)
			{
				mobjTableLayoutSettingsStub = new TableLayoutSettingsStub();
			}
			TypeConverter converter = TypeDescriptor.GetConverter(this);
			string text = objSerializationInfo.GetString("SerializedString");
			if (!CommonUtils.IsNullOrEmpty(text) && converter != null && converter.ConvertFromInvariantString(text) is TableLayoutSettings objSettings)
			{
				ApplySettings(objSettings);
			}
		}

		internal TableLayoutSettings(IArrangedElement objOwner)
			: base(objOwner)
		{
		}

		internal TableLayoutSettings()
			: base(null)
		{
			mobjTableLayoutSettingsStub = new TableLayoutSettingsStub();
		}

		/// 
		/// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
		/// </summary>
		/// <param name="strProperty">The name of the property that has changed</param>
		protected void FireObservableItemPropertyChanged(string strProperty)
		{
			if (this.ObservableItemPropertyChanged != null)
			{
				this.ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty));
			}
		}

		/// 
		/// Gets the cell position.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[DefaultValue(-1)]
		[SRDescription("TableLayoutSettingsGetCellPositionDescr")]
		[SRCategory("CatLayout")]
		public TableLayoutPanelCellPosition GetCellPosition(object objControl)
		{
			if (objControl == null)
			{
				throw new ArgumentNullException("control");
			}
			return new TableLayoutPanelCellPosition(GetColumn(objControl), GetRow(objControl));
		}

		/// 
		/// Gets the column.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[SRCategory("CatLayout")]
		[SRDescription("GridPanelColumnDescr")]
		[DefaultValue(-1)]
		public int GetColumn(object objControl)
		{
			if (objControl == null)
			{
				throw new ArgumentNullException("control");
			}
			if (IsStub)
			{
				return mobjTableLayoutSettingsStub.GetColumn(objControl);
			}
			return TableLayout.GetLayoutInfo(LayoutEngine.CastToArrangedElement(objControl)).ColumnPosition;
		}

		/// 
		/// Gets the column span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		public int GetColumnSpan(object objControl)
		{
			if (objControl == null)
			{
				throw new ArgumentNullException("control");
			}
			if (IsStub)
			{
				return mobjTableLayoutSettingsStub.GetColumnSpan(objControl);
			}
			return TableLayout.GetLayoutInfo(LayoutEngine.CastToArrangedElement(objControl)).ColumnSpan;
		}

		/// 
		/// Gets the row.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[SRDescription("GridPanelRowDescr")]
		[DefaultValue(-1)]
		[SRCategory("CatLayout")]
		public int GetRow(object objControl)
		{
			if (objControl == null)
			{
				throw new ArgumentNullException("control");
			}
			if (IsStub)
			{
				return mobjTableLayoutSettingsStub.GetRow(objControl);
			}
			return TableLayout.GetLayoutInfo(LayoutEngine.CastToArrangedElement(objControl)).RowPosition;
		}

		/// 
		/// Gets the row span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		public int GetRowSpan(object objControl)
		{
			if (IsStub)
			{
				return mobjTableLayoutSettingsStub.GetRowSpan(objControl);
			}
			return TableLayout.GetLayoutInfo(LayoutEngine.CastToArrangedElement(objControl)).RowSpan;
		}

		/// 
		/// Sets the cell position.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="objCellPosition">The cell position.</param>
		[SRCategory("CatLayout")]
		[DefaultValue(-1)]
		[SRDescription("TableLayoutSettingsSetCellPositionDescr")]
		public void SetCellPosition(object objControl, TableLayoutPanelCellPosition objCellPosition)
		{
			if (objControl == null)
			{
				throw new ArgumentNullException("control");
			}
			SetCellPosition(objControl, objCellPosition.Row, objCellPosition.Column, blnRowSpecified: true, blnColSpecified: true);
		}

		/// 
		/// Sets the column.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intColumn">The column.</param>
		public void SetColumn(object objControl, int intColumn)
		{
			if (intColumn < -1)
			{
				throw new ArgumentException(SR.GetString("InvalidArgument", "Column", intColumn.ToString(CultureInfo.CurrentCulture)));
			}
			if (IsStub)
			{
				mobjTableLayoutSettingsStub.SetColumn(objControl, intColumn);
			}
			else
			{
				SetCellPosition(objControl, -1, intColumn, blnRowSpecified: false, blnColSpecified: true);
			}
		}

		/// 
		/// Sets the column span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intValue">The value.</param>
		public void SetColumnSpan(object objControl, int intValue)
		{
			if (intValue < 1)
			{
				throw new ArgumentOutOfRangeException("ColumnSpan", SR.GetString("InvalidArgument", "ColumnSpan", intValue.ToString(CultureInfo.CurrentCulture)));
			}
			if (IsStub)
			{
				mobjTableLayoutSettingsStub.SetColumnSpan(objControl, intValue);
				return;
			}
			IArrangedElement objElement = LayoutEngine.CastToArrangedElement(objControl);
			if (GetElementContainer(objElement) != null)
			{
				TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(GetElementContainer(objElement)));
			}
			TableLayout.GetLayoutInfo(objElement).ColumnSpan = intValue;
		}

		/// 
		/// Sets the row.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intRow">The row.</param>
		public void SetRow(object objControl, int intRow)
		{
			if (objControl == null)
			{
				throw new ArgumentNullException("control");
			}
			if (intRow < -1)
			{
				throw new ArgumentOutOfRangeException("Row", SR.GetString("InvalidArgument", "Row", intRow.ToString(CultureInfo.CurrentCulture)));
			}
			SetCellPosition(objControl, intRow, -1, blnRowSpecified: true, blnColSpecified: false);
		}

		/// 
		/// Sets the row span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intValue">The value.</param>
		public void SetRowSpan(object objControl, int intValue)
		{
			if (intValue < 1)
			{
				throw new ArgumentOutOfRangeException("RowSpan", SR.GetString("InvalidArgument", "RowSpan", intValue.ToString(CultureInfo.CurrentCulture)));
			}
			if (objControl == null)
			{
				throw new ArgumentNullException("control");
			}
			if (IsStub)
			{
				mobjTableLayoutSettingsStub.SetRowSpan(objControl, intValue);
				return;
			}
			IArrangedElement objElement = LayoutEngine.CastToArrangedElement(objControl);
			if (GetElementContainer(objElement) != null)
			{
				TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(GetElementContainer(objElement)));
			}
			TableLayout.GetLayoutInfo(objElement).RowSpan = intValue;
		}

		void ISerializable.GetObjectData(SerializationInfo objSerializationInfo, StreamingContext objContext)
		{
			string text = TypeDescriptor.GetConverter(this)?.ConvertToInvariantString(this);
			if (!CommonUtils.IsNullOrEmpty(text))
			{
				objSerializationInfo.AddValue("SerializedString", text);
			}
			objSerializationInfo.AddValue("Owner", mobjOwner);
		}

		private void SetCellPosition(object objControl, int intRow, int intColumn, bool blnRowSpecified, bool blnColSpecified)
		{
			if (IsStub)
			{
				if (blnColSpecified)
				{
					mobjTableLayoutSettingsStub.SetColumn(objControl, intColumn);
				}
				if (blnRowSpecified)
				{
					mobjTableLayoutSettingsStub.SetRow(objControl, intRow);
				}
			}
			else
			{
				IArrangedElement objElement = LayoutEngine.CastToArrangedElement(objControl);
				if (GetElementContainer(objElement) != null)
				{
					TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(GetElementContainer(objElement)));
				}
				TableLayout.LayoutInfo layoutInfo = TableLayout.GetLayoutInfo(objElement);
				if (blnColSpecified)
				{
					layoutInfo.ColumnPosition = intColumn;
				}
				if (blnRowSpecified)
				{
					layoutInfo.RowPosition = intRow;
				}
			}
			FireObservableItemPropertyChanged("SetCellPosition");
		}

		internal void ApplySettings(TableLayoutSettings objSettings)
		{
			if (objSettings.IsStub)
			{
				if (!IsStub)
				{
					objSettings.mobjTableLayoutSettingsStub.ApplySettings(this);
				}
				else
				{
					mobjTableLayoutSettingsStub = objSettings.mobjTableLayoutSettingsStub;
				}
			}
		}

		internal IArrangedElement GetControlFromPosition(int intColumn, int intRow)
		{
			return TableLayout.GetControlFromPosition(base.Owner, intColumn, intRow);
		}

		internal List<object> GetControlsInformation()
		{
			if (IsStub)
			{
				return mobjTableLayoutSettingsStub.GetControlsInformation();
			}
			List<object> list = new List<object><object>(base.Owner.Children.Count);
			foreach (IArrangedElement child in base.Owner.Children)
			{
				if (child is Control control)
				{
					ControlInformation item = default(ControlInformation);
					PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(control)["Name"];
					if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(string))
					{
						item.Name = propertyDescriptor.GetValue(control);
					}
					item.Row = GetRow(control);
					item.RowSpan = GetRowSpan(control);
					item.Column = GetColumn(control);
					item.ColumnSpan = GetColumnSpan(control);
					list.Add(item);
				}
			}
			return list;
		}

		internal IArrangedElement GetElementContainer(IArrangedElement objElement)
		{
			IArrangedElement result = null;
			if (objElement != null && objElement is Control && ((Control)objElement).Container is IArrangedElement)
			{
				result = ((Control)objElement).Container as IArrangedElement;
			}
			return result;
		}

		internal TableLayoutPanelCellPosition GetPositionFromControl(IArrangedElement objElement)
		{
			return TableLayout.GetPositionFromControl(base.Owner, objElement);
		}
	}
}

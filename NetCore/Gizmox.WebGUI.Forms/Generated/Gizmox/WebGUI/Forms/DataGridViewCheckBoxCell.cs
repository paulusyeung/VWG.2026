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
/// Displays a check box user interface (UI) to use in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[Skin(typeof(DataGridViewCheckBoxCellSkin))]
	public class DataGridViewCheckBoxCell : DataGridViewCell, IDataGridViewEditingCell
	{
		private byte mobjFlags;

		private static Type mobjDefaultBooleanType;

		private static Type mobjefaultCheckStateType;

		private static Type mobjCellType;

		private const byte DATAGRIDVIEWCHECKBOXCELL_checked = 16;

		private const byte DATAGRIDVIEWCHECKBOXCELL_indeterminate = 32;

		private const byte DATAGRIDVIEWCHECKBOXCELL_margin = 2;

		private const byte DATAGRIDVIEWCHECKBOXCELL_threeState = 1;

		private const byte DATAGRIDVIEWCHECKBOXCELL_valueChanged = 2;

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
		/// Gets a value indicating whether [support edit mode].
		/// </summary>
		/// true</c> if [support edit mode]; otherwise, false</c>.</value>
		protected override bool SupportEditMode => true;

		/// Gets or sets the formatted value of the control hosted by the cell when it is in edit mode.</summary>
		/// An <see cref="T:System.Object"></see> representing the cell's value.</returns>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.-or-The assigned value is null or is not of the type indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property.-or- The assigned value is not of type <see cref="T:System.Boolean"></see> nor of type <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see>.</exception>
		public virtual object EditingCellFormattedValue
		{
			get
			{
				return GetEditingCellFormattedValue(DataGridViewDataErrorContexts.Formatting);
			}
			set
			{
				if (FormattedValueType == null)
				{
					throw new ArgumentException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
				}
				if (value == null || !FormattedValueType.IsAssignableFrom(value.GetType()))
				{
					throw new ArgumentException(SR.GetString("DataGridViewCheckBoxCell_InvalidValueType"));
				}
				if (value is CheckState)
				{
					if ((CheckState)value == CheckState.Checked)
					{
						Flags |= 16;
						Flags = (byte)(Flags & -33);
					}
					else if ((CheckState)value == CheckState.Indeterminate)
					{
						Flags |= 32;
						Flags = (byte)(Flags & -17);
					}
					else
					{
						Flags = (byte)(Flags & -17);
						Flags = (byte)(Flags & -33);
					}
				}
				else
				{
					if (!(value is bool))
					{
						throw new ArgumentException(SR.GetString("DataGridViewCheckBoxCell_InvalidValueType"));
					}
					if ((bool)value)
					{
						Flags |= 16;
					}
					else
					{
						Flags = (byte)(Flags & -17);
					}
					Flags = (byte)(Flags & -33);
				}
			}
		}

		/// Gets or sets a flag indicating that the value has been changed for this cell.</summary>
		/// true if the cell's value has changed; otherwise, false.</returns>
		public virtual bool EditingCellValueChanged
		{
			get
			{
				return (Flags & 2) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= 2;
				}
				else
				{
					Flags = (byte)(Flags & -3);
				}
			}
		}

		/// Gets or sets the underlying value corresponding to a cell value of false.</summary>
		/// An <see cref="T:System.Object"></see> corresponding to a cell value of false. The default is null.</returns>
		/// 1</filterpriority>
		[DefaultValue(null)]
		public object FalseValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal object FalseValueInternal
		{
			set
			{
			}
		}

		/// Gets or sets the flat style appearance of the check box user interface (UI).</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value.</exception>
		/// 1</filterpriority>
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

		internal FlatStyle FlatStyleInternal
		{
			set
			{
			}
		}

		/// Gets the type of the cell display value. </summary>
		/// A <see cref="T:System.Type"></see> representing the display type of the cell.</returns>
		/// 1</filterpriority>
		public override Type FormattedValueType
		{
			get
			{
				if (ThreeState)
				{
					return mobjefaultCheckStateType;
				}
				return mobjDefaultBooleanType;
			}
		}

		/// Gets or sets the underlying value corresponding to an indeterminate or null cell value.</summary>
		/// An <see cref="T:System.Object"></see> corresponding to an indeterminate or null cell value. The default is null.</returns>
		/// 1</filterpriority>
		[DefaultValue(null)]
		public object IndeterminateValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal object IndeterminateValueInternal
		{
			set
			{
			}
		}

		/// Gets or sets a value indicating whether ternary mode has been enabled for the hosted check box control.</summary>
		/// true if ternary mode is enabled; false if binary mode is enabled. The default is false.</returns>
		/// 1</filterpriority>
		[DefaultValue(false)]
		public bool ThreeState
		{
			get
			{
				return (Flags & 1) != 0;
			}
			set
			{
				if (ThreeState == value)
				{
					return;
				}
				ThreeStateInternal = value;
				if (base.DataGridView != null)
				{
					if (base.RowIndex != -1)
					{
						base.DataGridView.InvalidateCell(this);
					}
					else
					{
						base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
					}
				}
			}
		}

		internal bool ThreeStateInternal
		{
			set
			{
				if (ThreeState != value)
				{
					if (value)
					{
						Flags |= 1;
					}
					else
					{
						Flags = (byte)(Flags & -2);
					}
				}
			}
		}

		/// Gets or sets the underlying value corresponding to a cell value of true.</summary>
		/// An <see cref="T:System.Object"></see> corresponding to a cell value of true. The default is null.</returns>
		/// 1</filterpriority>
		[DefaultValue(null)]
		public object TrueValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal object TrueValueInternal
		{
			set
			{
			}
		}

		/// Gets the data type of the values in the cell.</summary>
		/// The <see cref="T:System.Type"></see> of the underlying value of the cell.</returns>
		/// 1</filterpriority>
		public override Type ValueType
		{
			get
			{
				Type valueType = base.ValueType;
				if (valueType != null)
				{
					return valueType;
				}
				if (ThreeState)
				{
					return mobjefaultCheckStateType;
				}
				return mobjDefaultBooleanType;
			}
			set
			{
				base.ValueType = value;
				ThreeState = value != null && mobjefaultCheckStateType.IsAssignableFrom(value);
			}
		}

		/// 
		/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell" /> class.
		/// </summary>
		static DataGridViewCheckBoxCell()
		{
			mobjefaultCheckStateType = typeof(CheckState);
			mobjDefaultBooleanType = typeof(bool);
			mobjCellType = typeof(DataGridViewCheckBoxCell);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> class to its default state.</summary>
		public DataGridViewCheckBoxCell()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> class, enabling binary or ternary state.</summary>
		/// <param name="blnThreeState">true to enable ternary state; false to enable binary state.</param>
		public DataGridViewCheckBoxCell(bool blnThreeState)
			: this()
		{
		}

		/// 
		/// Called when the cell's contents are clicked.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
		protected override void OnContentClick(DataGridViewCellEventArgs e)
		{
		}

		/// 
		/// Called when the cell's contents are double-clicked.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
		protected override void OnContentDoubleClick(DataGridViewCellEventArgs e)
		{
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			criticalEventsData.Set("VC");
			return criticalEventsData;
		}

		/// 
		/// Fires the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (!(type == "ValueChange"))
			{
				return;
			}
			string text = objEvent["C"];
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			object objValue = null;
			if (ThreeState)
			{
				switch (text)
				{
				case "0":
					objValue = CheckState.Unchecked;
					break;
				case "1":
					objValue = CheckState.Checked;
					break;
				case "2":
					objValue = CheckState.Indeterminate;
					break;
				}
			}
			else
			{
				switch (text)
				{
				case "0":
					objValue = false;
					break;
				case "1":
				case "2":
					objValue = true;
					break;
				}
			}
			SetValue(objValue, blnClientSource: true);
		}

		private bool CommonContentClickUnsharesRow(DataGridViewCellEventArgs e)
		{
			return false;
		}

		/// Indicates whether the row containing the cell will be unshared when the cell content is clicked.</summary>
		/// true if the cell is in edit mode; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains data about the mouse click.</param>
		protected override bool ContentClickUnsharesRow(DataGridViewCellEventArgs e)
		{
			return false;
		}

		/// Indicates whether the row containing the cell will be unshared when the cell content is double-clicked.</summary>
		/// true if the cell is in edit mode; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains data about the double-click.</param>
		protected override bool ContentDoubleClickUnsharesRow(DataGridViewCellEventArgs e)
		{
			return false;
		}

		/// Calculates the preferred size, in pixels, of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
		/// <param name="objConstraintSize">The cell's maximum allowable size.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell.</param>
		protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
		{
			Size empty = Size.Empty;
			if (base.Skin is DataGridViewCheckBoxCellSkin dataGridViewCheckBoxCellSkin)
			{
				if (base.DataGridView != null && SkinFactory.GetSkin(base.DataGridView, typeof(DataGridViewSkin)) is DataGridViewSkin dataGridViewSkin)
				{
					empty.Height = dataGridViewSkin.CellNormalStyle.Padding.Vertical;
					empty.Width = dataGridViewSkin.CellNormalStyle.Padding.Horizontal;
				}
				empty.Height += dataGridViewCheckBoxCellSkin.CheckBoxImageHeight;
				empty.Width += dataGridViewCheckBoxCellSkin.CheckBoxImageWidth;
			}
			return empty;
		}

		/// Gets the formatted value of the cell while it is in edit mode.</summary>
		/// An <see cref="T:System.Object"></see> representing the formatted value of the editing cell. </returns>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that describes the context in which any formatting error occurs. </param>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.</exception>
		public virtual object GetEditingCellFormattedValue(DataGridViewDataErrorContexts enmContext)
		{
			if (FormattedValueType == null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
			}
			byte flags = Flags;
			if (FormattedValueType.IsAssignableFrom(mobjefaultCheckStateType))
			{
				if ((flags & 0x10) != 0)
				{
					if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != 0)
					{
						return SR.GetString("DataGridViewCheckBoxCell_ClipboardChecked");
					}
					return CheckState.Checked;
				}
				if ((flags & 0x20) != 0)
				{
					if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != 0)
					{
						return SR.GetString("DataGridViewCheckBoxCell_ClipboardIndeterminate");
					}
					return CheckState.Indeterminate;
				}
				if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != 0)
				{
					return SR.GetString("DataGridViewCheckBoxCell_ClipboardUnchecked");
				}
				return CheckState.Unchecked;
			}
			if (!FormattedValueType.IsAssignableFrom(mobjDefaultBooleanType))
			{
				return null;
			}
			bool flag = (flags & 0x10) != 0;
			if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != 0)
			{
				return SR.GetString(flag ? "DataGridViewCheckBoxCell_ClipboardTrue" : "DataGridViewCheckBoxCell_ClipboardFalse");
			}
			return flag;
		}

		/// 
		/// Renders the cell text/value.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objFormatedValue">The formated value.</param>
		protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
		{
			base.RenderCellValue(objContext, objWriter, objFormatedValue);
			if (objFormatedValue == null)
			{
				return;
			}
			string text = string.Empty;
			if (ThreeState && objFormatedValue is CheckState)
			{
				switch ((CheckState)objFormatedValue)
				{
				case CheckState.Unchecked:
					text = "0";
					break;
				case CheckState.Checked:
					text = "1";
					break;
				case CheckState.Indeterminate:
					text = "2";
					break;
				}
			}
			else if (objFormatedValue is bool)
			{
				text = (Convert.ToBoolean(objFormatedValue) ? "1" : "0");
			}
			if (!string.IsNullOrEmpty(text))
			{
				objWriter.WriteAttributeString("C", text);
			}
		}

		/// 
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			if (ThreeState)
			{
				objWriter.WriteAttributeString("MD", "3");
			}
		}

		/// 
		/// Renders the cell style attributes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objCellStyle">The cell style.</param>
		protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
		{
			base.RenderCellStyleAttributes(objWriter, objCellStyle);
			if (objCellStyle != null)
			{
				objWriter.WriteAttributeString("CA", objCellStyle.Alignment.ToString());
			}
		}

		/// 
		/// Renders the updated attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
			if (base.Value is bool)
			{
				bool flag = (bool)base.Value;
				objWriter.WriteAttributeString("VLB", (!flag) ? "1" : "0");
			}
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see>.</returns>
		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewCheckBoxCell dataGridViewCheckBoxCell = ((!(type == mobjCellType)) ? ((DataGridViewCheckBoxCell)Activator.CreateInstance(type)) : new DataGridViewCheckBoxCell());
			CloneInternal(dataGridViewCheckBoxCell);
			dataGridViewCheckBoxCell.ThreeStateInternal = ThreeState;
			dataGridViewCheckBoxCell.TrueValueInternal = TrueValue;
			dataGridViewCheckBoxCell.FalseValueInternal = FalseValue;
			dataGridViewCheckBoxCell.IndeterminateValueInternal = IndeterminateValue;
			dataGridViewCheckBoxCell.FlatStyleInternal = FlatStyle;
			return dataGridViewCheckBoxCell;
		}

		/// Gets the formatted value of the cell's data. </summary>
		/// The value of the cell's data after formatting has been applied or null if the cell is not part of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
		/// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
		/// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <param name="objValue">The value to be formatted. </param>
		/// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
		protected override object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
		{
			if (objValue != null)
			{
				if (ThreeState)
				{
					if (objValue.Equals(TrueValue) || (objValue is int && (int)objValue == 1))
					{
						objValue = CheckState.Checked;
					}
					else if (objValue.Equals(FalseValue) || (objValue is int && (int)objValue == 0))
					{
						objValue = CheckState.Unchecked;
					}
					else if (objValue.Equals(IndeterminateValue) || (objValue is int && (int)objValue == 2))
					{
						objValue = CheckState.Indeterminate;
					}
				}
				else if (objValue.Equals(TrueValue) || (objValue is int && (int)objValue != 0))
				{
					objValue = true;
				}
				else if (objValue.Equals(FalseValue) || (objValue is int && (int)objValue == 0))
				{
					objValue = false;
				}
			}
			object formattedValue = base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
			if (formattedValue == null || (enmContext & DataGridViewDataErrorContexts.ClipboardContent) == 0)
			{
				return formattedValue;
			}
			if (formattedValue is bool)
			{
				if ((bool)formattedValue)
				{
					return SR.GetString(ThreeState ? "DataGridViewCheckBoxCell_ClipboardChecked" : "DataGridViewCheckBoxCell_ClipboardTrue");
				}
				return SR.GetString(ThreeState ? "DataGridViewCheckBoxCell_ClipboardUnchecked" : "DataGridViewCheckBoxCell_ClipboardFalse");
			}
			if (!(formattedValue is CheckState checkState))
			{
				return formattedValue;
			}
			return checkState switch
			{
				CheckState.Checked => SR.GetString(ThreeState ? "DataGridViewCheckBoxCell_ClipboardChecked" : "DataGridViewCheckBoxCell_ClipboardTrue"), 
				CheckState.Unchecked => SR.GetString(ThreeState ? "DataGridViewCheckBoxCell_ClipboardUnchecked" : "DataGridViewCheckBoxCell_ClipboardFalse"), 
				_ => SR.GetString("DataGridViewCheckBoxCell_ClipboardIndeterminate"), 
			};
		}

		/// Converts a value formatted for display to an actual cell value.</summary>
		/// The cell value.</returns>
		/// <param name="objFormattedValue">The display value of the cell.</param>
		/// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> for the display value type, or null to use the default converter.</param>
		/// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> for the cell value type, or null to use the default converter.</param>
		/// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
		/// <exception cref="T:System.FormatException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.FormattedValueType"></see> property value is null.</exception>
		/// <exception cref="T:System.ArgumentNullException">cellStyle is null.</exception>
		/// <exception cref="T:System.ArgumentException">formattedValue is null.- or -The type of formattedValue does not match the type indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.FormattedValueType"></see> property. </exception>
		public override object ParseFormattedValue(object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
		{
			if (objFormattedValue != null)
			{
				if (objFormattedValue is bool)
				{
					if ((bool)objFormattedValue)
					{
						if (TrueValue != null)
						{
							return TrueValue;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjDefaultBooleanType))
						{
							return true;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjefaultCheckStateType))
						{
							return CheckState.Checked;
						}
					}
					else
					{
						if (FalseValue != null)
						{
							return FalseValue;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjDefaultBooleanType))
						{
							return false;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjefaultCheckStateType))
						{
							return CheckState.Unchecked;
						}
					}
				}
				else if (objFormattedValue is CheckState)
				{
					switch ((CheckState)objFormattedValue)
					{
					case CheckState.Unchecked:
						if (FalseValue != null)
						{
							return FalseValue;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjDefaultBooleanType))
						{
							return false;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjefaultCheckStateType))
						{
							return CheckState.Unchecked;
						}
						break;
					case CheckState.Checked:
						if (TrueValue != null)
						{
							return TrueValue;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjDefaultBooleanType))
						{
							return true;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjefaultCheckStateType))
						{
							return CheckState.Checked;
						}
						break;
					case CheckState.Indeterminate:
						if (IndeterminateValue != null)
						{
							return IndeterminateValue;
						}
						if (ValueType != null && ValueType.IsAssignableFrom(mobjefaultCheckStateType))
						{
							return CheckState.Indeterminate;
						}
						break;
					}
				}
			}
			return base.ParseFormattedValue(objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
		}

		/// This method is not meaningful for this type.</summary>
		/// <param name="blnSelectAll">This parameter is ignored.</param>
		public virtual void PrepareEditingCellForEdit(bool blnSelectAll)
		{
		}

		private bool SwitchFormattedValue()
		{
			return false;
		}

		/// Returns the string representation of the cell.</summary>
		/// A <see cref="T:System.String"></see> that represents the current cell.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			return "DataGridViewCheckBoxCell { ColumnIndex=" + base.ColumnIndex + ", RowIndex=" + base.RowIndex + " }";
		}

		private void UpdateButtonState(ButtonState newButtonState, int intRowIndex)
		{
		}
	}
}

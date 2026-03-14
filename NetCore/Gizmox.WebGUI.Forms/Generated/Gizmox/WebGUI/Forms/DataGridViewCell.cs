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
/// Represents an individual cell in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
	/// 2</filterpriority>
	[Serializable]
	[TypeConverter(typeof(DataGridViewCellConverter))]
	public abstract class DataGridViewCell : DataGridViewElement, ICloneable, IDisposable, ISkinable
	{
		private byte mobjFlags;

		private object mobjEditingProposedValue;

		private DataGridViewRow mobjOwningRow = null;

		private DataGridViewColumn mobjOwningColumn = null;

		private DataGridViewCellStyle mobjStyle = null;

		private object mojValue = null;

		private object mobjToolTipText = null;

		private object mobjTag = null;

		private object mobjValueType = null;

		private object mobjErrorText = null;

		private ContextMenu mobjCellContextMenu = null;

		private ContextMenuStrip mobjCellContextMenuStrip = null;

		private DataGridViewCellPanel mobjPanel = null;

		private const int DATAGRIDVIEWCELL_constrastThreshold = 1000;

		private const byte DATAGRIDVIEWCELL_flagAreaNotSet = 0;

		private const byte DATAGRIDVIEWCELL_flagDataArea = 1;

		private const byte DATAGRIDVIEWCELL_flagErrorArea = 2;

		private const int DATAGRIDVIEWCELL_highConstrastThreshold = 2000;

		internal const byte DATAGRIDVIEWCELL_iconMarginHeight = 4;

		internal const byte DATAGRIDVIEWCELL_iconMarginWidth = 4;

		internal const byte DATAGRIDVIEWCELL_iconsHeight = 11;

		internal const byte DATAGRIDVIEWCELL_iconsWidth = 12;

		private const int DATAGRIDVIEWCELL_maxToolTipCutOff = 256;

		private const int DATAGRIDVIEWCELL_maxToolTipLength = 288;

		private const string DATAGRIDVIEWCELL_toolTipEllipsis = "...";

		private const int DATAGRIDVIEWCELL_toolTipEllipsisLength = 3;

		private const TextFormatFlags textFormatSupportedFlags = TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.WordBreak;

		protected const int DefaultHorizontalPadding = 3;

		protected const int DefaultVerticalPadding = 4;

		private static Bitmap mobjErrorBmp = null;

		private static Type mobjStringType = typeof(string);

		/// 
		/// This memeber holds the formatted value as the user defined it through the pre-rendering procces.
		/// </summary>        
		private object mobjFormattedValue = null;

		/// 
		/// This memeber holds the formatted cell style as the user defined it through the pre-rendering procces.
		/// </summary>
		private DataGridViewCellStyle mobjFormattedCellStyle = null;

		/// 
		/// The skin of the current control
		/// </summary>
		[NonSerialized]
		private Gizmox.WebGUI.Forms.Skins.ControlSkin mobjSkin = null;

		/// 
		/// This is a recursive function that loop through a control and all of its parents 
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>        
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

		/// 
		/// Gets a value indicating whether [support edit mode].
		/// </summary>
		/// true</c> if [support edit mode]; otherwise, false</c>.</value>
		protected virtual bool SupportEditMode => false;

		/// 
		/// Gets a value indicating whether [support active mode]. Whethre this cell would be redrawn with defferent skin.
		/// </summary>
		/// true</c> if [support active mode]; otherwise, false</c>.</value>
		protected virtual bool SupportActiveMode => false;

		/// 
		/// Gets the value type converter.
		/// </summary>
		/// The value type converter.</value>
		private TypeConverter ValueTypeConverter
		{
			get
			{
				TypeConverter typeConverter = null;
				if (OwningColumn != null)
				{
					typeConverter = OwningColumn.BoundColumnConverter;
				}
				if (typeConverter != null || ValueType == null)
				{
					return typeConverter;
				}
				if (base.DataGridView != null)
				{
					return base.DataGridView.GetCachedTypeConverter(ValueType);
				}
				return TypeDescriptor.GetConverter(ValueType);
			}
		}

		/// 
		/// Gets the formatted value type converter.
		/// </summary>
		/// The formatted value type converter.</value>
		private TypeConverter FormattedValueTypeConverter
		{
			get
			{
				TypeConverter result = null;
				if (FormattedValueType == null)
				{
					return result;
				}
				if (base.DataGridView != null)
				{
					return base.DataGridView.GetCachedTypeConverter(FormattedValueType);
				}
				return TypeDescriptor.GetConverter(FormattedValueType);
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
		///
		/// </summary>
		internal virtual string TypeName
		{
			get
			{
				if (base.DataGridView != null)
				{
					DataGridViewColumn dataGridViewColumn = base.DataGridView.Columns[ColumnIndex];
					if (dataGridViewColumn != null)
					{
						return dataGridViewColumn.TypeNameInternal;
					}
				}
				return string.Empty;
			}
		}

		/// 
		///
		/// </summary>
		protected override string MemberID
		{
			get
			{
				int num = ((!OwningRow.IsFilterRow) ? (RowIndex + (base.DataGridView.ShowFilterRow ? 1 : 0)) : 0);
				return "D" + (base.DataGridView.ColumnCount * num + ColumnIndex);
			}
		}

		/// Gets the column index for this cell. </summary>
		/// The index of the column that contains the cell; -1 if the cell is not contained within a column.</returns>
		/// 1</filterpriority>
		public int ColumnIndex => OwningColumn?.Index ?? (-1);

		/// Gets the default value for a cell in the row for new records.</summary>
		/// An <see cref="T:System.Object"></see> representing the default value.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual object DefaultNewRowValue => null;

		/// Gets a value that indicates whether the cell is currently displayed on-screen. </summary>
		/// true if the cell is on-screen or partially on-screen; otherwise, false.</returns>
		[Browsable(false)]
		public virtual bool Displayed
		{
			get
			{
				if (base.DataGridView != null)
				{
					if (base.DataGridView == null || RowIndex < 0 || ColumnIndex < 0)
					{
						return false;
					}
					if (OwningColumn.Displayed)
					{
						return OwningRow.Displayed;
					}
				}
				return false;
			}
		}

		/// Gets the current, formatted value of the cell, regardless of whether the cell is in edit mode and the value has not been committed. </summary>
		/// The current, formatted value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
		/// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell. </exception>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public object EditedFormattedValue
		{
			get
			{
				if (base.DataGridView == null)
				{
					return null;
				}
				DataGridViewCellStyle objDataGridViewCellStyle = GetInheritedStyle(null, RowIndex, blnIncludeColors: false);
				return GetEditedFormattedValue(GetValue(RowIndex), RowIndex, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
			}
		}

		/// Gets the type of the cell's hosted editing control. </summary>
		/// A <see cref="T:System.Type"></see> representing the <see cref="T:System.Windows.Forms.DataGridViewTextBoxEditingControl"></see> type.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public virtual Type EditType => typeof(DataGridViewTextBoxEditingControl);

		/// Gets or sets the text describing an error condition associated with the cell. </summary>
		/// The text that describes an error condition associated with the cell.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public string ErrorText
		{
			get
			{
				return GetErrorText(RowIndex);
			}
			set
			{
				ErrorTextInternal = value;
			}
		}

		private string ErrorTextInternal
		{
			get
			{
				if (mobjErrorText != null)
				{
					return (string)mobjErrorText;
				}
				return string.Empty;
			}
			set
			{
				string errorTextInternal = ErrorTextInternal;
				if (!CommonUtils.IsNullOrEmpty(value) || mobjErrorText != null)
				{
					mobjErrorText = value;
				}
				if (base.DataGridView != null && !errorTextInternal.Equals(ErrorTextInternal))
				{
					base.DataGridView.OnCellErrorTextChanged(this);
				}
			}
		}

		/// Gets the value of the cell as formatted for display.</summary>
		/// The formatted value of the cell or null if the cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
		/// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		public object FormattedValue
		{
			get
			{
				if (base.DataGridView == null)
				{
					return null;
				}
				DataGridViewCellStyle objCellStyle = GetInheritedStyle(null, RowIndex, blnIncludeColors: false);
				return GetFormattedValue(RowIndex, ref objCellStyle, DataGridViewDataErrorContexts.Formatting);
			}
		}

		/// Gets the type of the formatted value associated with the cell. </summary>
		/// A <see cref="T:System.Type"></see> representing the type of the cell's formatted value.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual Type FormattedValueType => ValueType;

		/// Gets a value indicating whether the cell is frozen. </summary>
		/// true if the cell is frozen; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual bool Frozen
		{
			get
			{
				DataGridViewRow owningRow = OwningRow;
				if (base.DataGridView != null && RowIndex >= 0 && ColumnIndex >= 0)
				{
					return OwningColumn.Frozen && owningRow.Frozen;
				}
				if (owningRow == null || (owningRow.DataGridView != null && RowIndex < 0))
				{
					return false;
				}
				return owningRow.Frozen;
			}
		}

		/// Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property has been set.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property has been set; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public bool HasStyle => mobjStyle != null;

		/// Gets the current state of the cell as inherited from the state of its row and column.</summary>
		/// A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and the value of its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> property is -1.</exception>
		/// <exception cref="T:System.ArgumentException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and the value of its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> property is not -1.</exception>
		[Browsable(false)]
		public DataGridViewElementStates InheritedState => GetInheritedState(RowIndex);

		/// Gets the style currently applied to the cell. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> currently applied to the cell.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
		/// <exception cref="T:System.InvalidOperationException">The cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or- <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		[Browsable(false)]
		public DataGridViewCellStyle InheritedStyle => GetInheritedStyleInternal(RowIndex);

		/// Gets a value indicating whether this cell is currently being edited.</summary>
		/// true if the cell is in edit mode; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row containing the cell is a shared row.</exception>
		[Browsable(false)]
		public bool IsInEditMode
		{
			get
			{
				if (base.DataGridView == null)
				{
					return false;
				}
				if (RowIndex == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
				}
				Point currentCellAddress = base.DataGridView.CurrentCellAddress;
				return currentCellAddress.X != -1 && currentCellAddress.X == ColumnIndex && currentCellAddress.Y == RowIndex && base.DataGridView.IsCurrentCellInEditMode;
			}
		}

		/// Gets the column that contains this cell.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> that contains the cell, or null if the cell is not in a column.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public DataGridViewColumn OwningColumn => mobjOwningColumn;

		/// 
		/// Sets the owning column internal.
		/// </summary>
		/// The owning column internal.</value>
		internal DataGridViewColumn OwningColumnInternal
		{
			set
			{
				mobjOwningColumn = value;
			}
		}

		/// Gets the row that contains this cell. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that contains the cell, or null if the cell is not in a row.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public DataGridViewRow OwningRow => mobjOwningRow;

		/// 
		/// Gets or sets the formatted cell style.
		/// </summary>
		/// The formatted cell style.</value>
		protected DataGridViewCellStyle FormattedCellStyle => mobjFormattedCellStyle;

		/// 
		/// Sets the owning row internal.
		/// </summary>
		/// The owning row internal.</value>
		internal DataGridViewRow OwningRowInternal
		{
			set
			{
				mobjOwningRow = value;
			}
		}

		/// Gets the size, in pixels, of a rectangular area into which the cell can fit. </summary>
		/// A <see cref="T:System.Drawing.Size"></see> containing the height and width, in pixels.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		public Size PreferredSize => GetPreferredSize(RowIndex);

		/// Gets or sets a value indicating whether the cell's data can be edited. </summary>
		/// true if the cell's data can be edited; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">There is no owning row when setting this property. -or-The owning row is shared when setting this property.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool ReadOnly
		{
			get
			{
				if ((State & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
				{
					return true;
				}
				DataGridViewRow owningRow = OwningRow;
				if (owningRow != null && (owningRow.DataGridView == null || RowIndex >= 0) && owningRow.ReadOnly)
				{
					return true;
				}
				if (base.DataGridView != null && RowIndex >= 0 && ColumnIndex >= 0)
				{
					return OwningColumn.ReadOnly;
				}
				return false;
			}
			set
			{
				DataGridViewRow owningRow = OwningRow;
				if (base.DataGridView != null)
				{
					if (RowIndex == -1)
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
					}
					if (value != ReadOnly && !base.DataGridView.ReadOnly)
					{
						base.DataGridView.OnDataGridViewElementStateChanging(this, -1, DataGridViewElementStates.ReadOnly);
						base.DataGridView.SetReadOnlyCellCore(ColumnIndex, RowIndex, value);
						UpdateParams(AttributeType.Visual);
					}
				}
				else if (owningRow == null)
				{
					if (value != ReadOnly)
					{
						throw new InvalidOperationException(SR.GetString("DataGridViewCell_CannotSetReadOnlyState"));
					}
				}
				else
				{
					owningRow.SetReadOnlyCellCore(this, value);
				}
				ElementReadOnly = ((!value) ? ElementReadOnlyType.False : ElementReadOnlyType.True);
			}
		}

		/// 
		/// Sets a value indicating whether [read only internal].
		/// </summary>
		/// true</c> if [read only internal]; otherwise, false</c>.</value>
		internal bool ReadOnlyInternal
		{
			set
			{
				if (value)
				{
					base.StateInternal = State | DataGridViewElementStates.ReadOnly;
				}
				else
				{
					base.StateInternal = State & ~DataGridViewElementStates.ReadOnly;
				}
				if (base.DataGridView != null)
				{
					base.DataGridView.OnDataGridViewElementStateChanged(this, -1, DataGridViewElementStates.ReadOnly);
				}
			}
		}

		/// 
		/// Gets the location.
		/// </summary>
		/// The location.</value>
		protected internal override Point Location
		{
			get
			{
				Point empty = Point.Empty;
				if (OwningRow != null)
				{
					empty.Y = OwningRow.Location.Y;
				}
				if (OwningColumn != null)
				{
					empty.X = OwningColumn.Location.X;
				}
				return empty;
			}
		}

		/// Gets a value indicating whether the cell can be resized. </summary>
		/// true if the cell can be resized; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual bool Resizable
		{
			get
			{
				DataGridViewRow owningRow = OwningRow;
				if (owningRow != null && (owningRow.DataGridView == null || RowIndex >= 0) && owningRow.Resizable == DataGridViewTriState.True)
				{
					return true;
				}
				if (base.DataGridView != null && RowIndex >= 0 && ColumnIndex >= 0)
				{
					return OwningColumn.Resizable == DataGridViewTriState.True;
				}
				return false;
			}
		}

		/// Gets the index of the cell's parent row. </summary>
		/// The index of the row that contains the cell; -1 if there is no owning row.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public int RowIndex => OwningRow?.Index ?? (-1);

		/// Gets or sets a value indicating whether the cell has been selected. </summary>
		/// true if the cell has been selected; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">There is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when setting this property. -or-The owning row is shared when setting this property.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual bool Selected
		{
			get
			{
				if ((State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
				{
					return true;
				}
				DataGridViewRow owningRow = OwningRow;
				if (owningRow != null && (owningRow.DataGridView == null || RowIndex >= 0) && owningRow.Selected)
				{
					return true;
				}
				if (base.DataGridView != null && RowIndex >= 0 && ColumnIndex >= 0)
				{
					return OwningColumn.Selected;
				}
				return false;
			}
			set
			{
				if (base.DataGridView != null)
				{
					if (RowIndex == -1)
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
					}
					base.DataGridView.SetSelectedCellCoreInternal(ColumnIndex, RowIndex, value);
				}
				else if (value)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewCell_CannotSetSelectedState"));
				}
			}
		}

		internal bool SelectedInternal
		{
			set
			{
				if (value)
				{
					base.StateInternal = State | DataGridViewElementStates.Selected;
				}
				else
				{
					base.StateInternal = State & ~DataGridViewElementStates.Selected;
				}
				if (base.DataGridView != null)
				{
					base.DataGridView.OnDataGridViewElementStateChanged(this, -1, DataGridViewElementStates.Selected);
				}
			}
		}

		internal bool HasValue => mojValue != null;

		internal bool HasToolTipText => mobjToolTipText != null;

		/// Gets the size of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> set to the owning row's height and the owning column's width. </returns>
		/// <exception cref="T:System.InvalidOperationException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		public Size Size => GetSize(RowIndex);

		/// Gets or sets the style for the cell. </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(true)]
		public DataGridViewCellStyle Style
		{
			get
			{
				if (mobjStyle == null)
				{
					mobjStyle = new DataGridViewCellStyle();
					mobjStyle.AddScope(base.DataGridView, DataGridViewCellStyleScopes.Cell);
				}
				return mobjStyle;
			}
			set
			{
				DataGridViewCellStyle dataGridViewCellStyle = null;
				if (HasStyle)
				{
					dataGridViewCellStyle = Style;
					dataGridViewCellStyle.RemoveScope(DataGridViewCellStyleScopes.Cell);
				}
				if (value != null || mobjStyle != null)
				{
					value?.AddScope(base.DataGridView, DataGridViewCellStyleScopes.Cell);
					mobjStyle = value;
				}
				if (((dataGridViewCellStyle != null && value == null) || (dataGridViewCellStyle == null && value != null) || (dataGridViewCellStyle != null && value != null && !dataGridViewCellStyle.Equals(Style))) && base.DataGridView != null)
				{
					base.DataGridView.OnCellStyleChanged(this);
				}
			}
		}

		/// Gets or sets the object that contains supplemental data about the cell. </summary>
		/// An <see cref="T:System.Object"></see> that contains data about the cell. The default is null.</returns>
		/// 1</filterpriority>
		[SRDescription("ControlTagDescr")]
		[TypeConverter(typeof(StringConverter))]
		[SRCategory("CatData")]
		[Localizable(false)]
		[Bindable(true)]
		[DefaultValue(null)]
		public object Tag
		{
			get
			{
				return mobjTag;
			}
			set
			{
				if (value != null || mobjTag != null)
				{
					mobjTag = value;
				}
			}
		}

		/// Gets or sets the ToolTip text associated with this cell.</summary>
		/// The ToolTip text associated with the cell. The default is <see cref="F:System.String.Empty"></see>. </returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string ToolTipText
		{
			get
			{
				return GetToolTipText(RowIndex);
			}
			set
			{
				ToolTipTextInternal = value;
			}
		}

		/// Gets or sets the value associated with this cell. </summary>
		/// Gets or sets the data to be displayed by the cell. The default is null.</returns>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> is outside the valid range of 0 to the number of rows in the control minus 1.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		public object Value
		{
			get
			{
				return GetValue(RowIndex);
			}
			set
			{
				if (GetValue(RowIndex) != value)
				{
					SetValue(RowIndex, value);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the editing proposed value.
		/// </summary>
		/// The editing proposed value.</value>
		[Browsable(false)]
		internal object EditingProposedValue
		{
			get
			{
				return mobjEditingProposedValue;
			}
			set
			{
				mobjEditingProposedValue = value;
			}
		}

		protected string ValueText
		{
			get
			{
				object value = Value;
				if (value != null)
				{
					return value.ToString();
				}
				return string.Empty;
			}
		}

		/// Gets or sets the data type of the values in the cell. </summary>
		/// A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual Type ValueType
		{
			get
			{
				if (mobjValueType == null && OwningColumn != null)
				{
					mobjValueType = OwningColumn.ValueType;
				}
				return mobjValueType as Type;
			}
			set
			{
				if (value != null || mobjValueType != null)
				{
					mobjValueType = value;
				}
			}
		}

		/// Gets a value indicating whether the cell is in a row or column that has been hidden. </summary>
		/// true if the cell is visible; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual bool Visible
		{
			get
			{
				DataGridViewRow owningRow = OwningRow;
				if (base.DataGridView != null && RowIndex >= 0 && ColumnIndex >= 0)
				{
					if (OwningColumn.Visible)
					{
						return owningRow.Visible;
					}
					return false;
				}
				if (owningRow == null || (owningRow.DataGridView != null && RowIndex < 0))
				{
					return false;
				}
				return owningRow.Visible;
			}
		}

		/// 
		/// Gets a value indicating whether this instance has value type.
		/// </summary>
		/// 
		/// 	true</c> if this instance has value type; otherwise, false</c>.
		/// </value>
		internal virtual bool HasValueType => mobjValueType != null;

		/// 
		/// Gets the bounding rectangle that encloses the cell's content area.
		/// </summary>
		/// The content bounds.</value>
		[Browsable(false)]
		public Rectangle ContentBounds => GetContentBounds(RowIndex);

		private byte CurrentMouseLocation
		{
			get
			{
				return (byte)(Flags & 3);
			}
			set
			{
				Flags = (byte)(Flags & -4);
				Flags |= value;
			}
		}

		private static Bitmap ErrorBitmap
		{
			get
			{
				if (mobjErrorBmp == null)
				{
					mobjErrorBmp = GetBitmap("DataGridViewRow.error.bmp");
				}
				return mobjErrorBmp;
			}
		}

		/// 
		/// Gets the bounds of the error icon for the cell.
		/// </summary>
		/// The error icon bounds.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public Rectangle ErrorIconBounds => GetErrorIconBounds(RowIndex);

		internal bool HasErrorText => mobjErrorText != null;

		internal Rectangle StdBorderWidths
		{
			get
			{
				if (base.DataGridView != null)
				{
					DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder = new DataGridViewAdvancedBorderStyle();
					DataGridViewAdvancedBorderStyle objAdvancedBorderStyle = AdjustCellBorderStyle(base.DataGridView.AdvancedCellBorderStyle, objDataGridViewAdvancedBorderStylePlaceholder, blnSingleVerticalBorderAdded: false, blnSingleHorizontalBorderAdded: false, blnIsFirstDisplayedColumn: false, blnIsFirstDisplayedRow: false);
					return BorderWidths(objAdvancedBorderStyle);
				}
				return Rectangle.Empty;
			}
		}

		private string ToolTipTextInternal
		{
			get
			{
				if (mobjToolTipText != null)
				{
					return (string)mobjToolTipText;
				}
				return string.Empty;
			}
			set
			{
				if (!CommonUtils.IsNullOrEmpty(value) || mobjToolTipText != null)
				{
					mobjToolTipText = value;
				}
			}
		}

		/// Gets or sets the shortcut menu associated with the cell. </summary>
		/// The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the cell.</returns>
		[DefaultValue(null)]
		public virtual ContextMenu ContextMenu
		{
			get
			{
				return GetContextMenu(RowIndex);
			}
			set
			{
				ContextMenuInternal = value;
			}
		}

		/// 
		/// Gets or sets the context menu strip.
		/// </summary>
		/// The context menu strip.</value>
		[DefaultValue(null)]
		public virtual ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return GetContextMenuStrip(RowIndex);
			}
			set
			{
				ContextMenuStripInternal = value;
			}
		}

		/// 
		/// Gets or sets the context menu strip internal.
		/// </summary>
		/// The context menu strip internal.</value>
		internal ContextMenuStrip ContextMenuStripInternal
		{
			get
			{
				return mobjCellContextMenuStrip;
			}
			set
			{
				if (mobjCellContextMenuStrip != value)
				{
					EventHandler value2 = DetachContextMenuStrip;
					if (mobjCellContextMenuStrip != null)
					{
						mobjCellContextMenuStrip.Disposed -= value2;
					}
					mobjCellContextMenuStrip = value;
					if (value != null)
					{
						value.Disposed += value2;
					}
					if (base.DataGridView != null)
					{
						base.DataGridView.OnCellContextMenuStripChanged(this);
					}
				}
			}
		}

		/// 
		/// Gets or sets the context menu internal.
		/// </summary>
		/// The context menu internal.</value>
		private ContextMenu ContextMenuInternal
		{
			get
			{
				return mobjCellContextMenu;
			}
			set
			{
				if (mobjCellContextMenu != value)
				{
					EventHandler value2 = DetachContextMenu;
					if (mobjCellContextMenu != null)
					{
						mobjCellContextMenu.Disposed -= value2;
					}
					mobjCellContextMenu = value;
					if (value != null)
					{
						value.Disposed += value2;
					}
					if (base.DataGridView != null)
					{
						base.DataGridView.OnCellContextMenuChanged(this);
					}
				}
			}
		}

		/// 
		/// Gets the cell's panel.
		/// </summary>
		/// The panel.</value>
		public DataGridViewCellPanel Panel
		{
			get
			{
				if (mobjPanel == null)
				{
					if (base.DataGridView != null)
					{
						mobjPanel = base.DataGridView.CreateCellPanel(this);
					}
					else
					{
						mobjPanel = new DataGridViewCellPanel(this);
					}
					mobjPanel.CreateControl();
				}
				return mobjPanel;
			}
			internal set
			{
				mobjPanel = value;
			}
		}

		/// 
		/// Gets a value indicating whether this instance has panel.
		/// </summary>
		/// 
		///   true</c> if this instance has panel; otherwise, false</c>.
		/// </value>
		protected bool HasPanel => mobjPanel != null;

		/// 
		/// Gets or sets the coll span.
		/// </summary>
		/// The coll span.</value>
		public virtual int Colspan
		{
			get
			{
				return Panel.Colspan;
			}
			set
			{
				Panel.Colspan = value;
			}
		}

		/// 
		/// Gets or sets the row span.
		/// </summary>
		/// The row span.</value>
		public virtual int Rowspan
		{
			get
			{
				return Panel.Rowspan;
			}
			set
			{
				Panel.Rowspan = value;
			}
		}

		/// 
		/// Gets the skin of the current control.
		/// </summary>
		/// The skin of the current control.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		protected Gizmox.WebGUI.Forms.Skins.ControlSkin Skin
		{
			get
			{
				if (mobjSkin == null)
				{
					mobjSkin = (Gizmox.WebGUI.Forms.Skins.ControlSkin)SkinFactory.GetSkin(this);
				}
				return mobjSkin;
			}
		}

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// The theme related to the skinable component.</value>
		string ISkinable.Theme
		{
			get
			{
				if (base.DataGridView != null && base.DataGridView.Context != null)
				{
					return base.DataGridView.Context.CurrentTheme;
				}
				return string.Empty;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class. </summary>
		protected DataGridViewCell()
		{
			base.TagName = "DL";
			base.StateInternal = DataGridViewElementStates.None;
		}

		internal bool MouseClickUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
		{
			return MouseClickUnsharesRow(e);
		}

		internal bool MouseDoubleClickUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
		{
			return MouseDoubleClickUnsharesRow(e);
		}

		internal bool MouseDownUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
		{
			return MouseDownUnsharesRow(e);
		}

		internal bool MouseEnterUnsharesRowInternal(int intRowIndex)
		{
			return MouseEnterUnsharesRow(intRowIndex);
		}

		internal bool MouseLeaveUnsharesRowInternal(int intRowIndex)
		{
			return MouseLeaveUnsharesRow(intRowIndex);
		}

		internal bool MouseMoveUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
		{
			return MouseMoveUnsharesRow(e);
		}

		internal bool MouseUpUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
		{
			return MouseUpUnsharesRow(e);
		}

		internal void OnClickInternal(DataGridViewCellEventArgs e)
		{
			OnClick(e);
		}

		internal void OnContentClickInternal(DataGridViewCellEventArgs e)
		{
			OnContentClick(e);
		}

		internal void OnContentDoubleClickInternal(DataGridViewCellEventArgs e)
		{
			OnContentDoubleClick(e);
		}

		internal void OnDoubleClickInternal(DataGridViewCellEventArgs e)
		{
			OnDoubleClick(e);
		}

		internal void OnEnterInternal(int intRowIndex, bool blnThroughMouseClick)
		{
			OnEnter(intRowIndex, blnThroughMouseClick);
		}

		internal void OnKeyDownInternal(KeyEventArgs e, int intRowIndex)
		{
			OnKeyDown(e, intRowIndex);
		}

		internal void OnKeyPressInternal(KeyPressEventArgs e, int intRowIndex)
		{
			OnKeyPress(e, intRowIndex);
		}

		internal void OnKeyUpInternal(KeyEventArgs e, int intRowIndex)
		{
			OnKeyUp(e, intRowIndex);
		}

		internal void OnLeaveInternal(int intRowIndex, bool blnThroughMouseClick)
		{
			OnLeave(intRowIndex, blnThroughMouseClick);
		}

		internal void OnMouseClickInternal(DataGridViewCellMouseEventArgs e)
		{
			OnMouseClick(e);
		}

		internal void OnMouseDoubleClickInternal(DataGridViewCellMouseEventArgs e)
		{
			OnMouseDoubleClick(e);
		}

		internal void OnMouseEnterInternal(int intRowIndex)
		{
			OnMouseEnter(intRowIndex);
		}

		/// 
		/// Keys the down unshares row internal.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> instance containing the event data.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool KeyDownUnsharesRowInternal(KeyEventArgs e, int intRowIndex)
		{
			return KeyDownUnsharesRow(e, intRowIndex);
		}

		/// 
		/// Keys the press unshares row internal.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs" /> instance containing the event data.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool KeyPressUnsharesRowInternal(KeyPressEventArgs e, int intRowIndex)
		{
			return KeyPressUnsharesRow(e, intRowIndex);
		}

		/// 
		/// Keys the up unshares row internal.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> instance containing the event data.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool KeyUpUnsharesRowInternal(KeyEventArgs e, int intRowIndex)
		{
			return KeyUpUnsharesRow(e, intRowIndex);
		}

		/// Indicates whether the parent row is unshared if the user presses a key while the focus is on the cell.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual bool KeyDownUnsharesRow(KeyEventArgs e, int intRowIndex)
		{
			return false;
		}

		/// Determines if edit mode should be started based on the given key.</summary>
		/// true if edit mode should be started; otherwise, false. The default is false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
		/// 1</filterpriority>
		public virtual bool KeyEntersEditMode(KeyEventArgs e)
		{
			return false;
		}

		/// Indicates whether a row will be unshared if a key is pressed while a cell in the row has focus.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual bool KeyPressUnsharesRow(KeyPressEventArgs e, int intRowIndex)
		{
			return false;
		}

		/// Indicates whether the parent row is unshared when the user releases a key while the focus is on the cell.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex)
		{
			return false;
		}

		/// Indicates whether a row will be unshared when the focus leaves a cell in the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		protected virtual bool LeaveUnsharesRow(int intRowIndex, bool blnThroughMouseClick)
		{
			return false;
		}

		/// Indicates whether a row will be unshared if the user clicks a mouse button while the pointer is on a cell in the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual bool MouseClickUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// Indicates whether a row will be unshared if the user double-clicks a cell in the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
		protected virtual bool MouseDoubleClickUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// Indicates whether a row will be unshared when the user holds down a mouse button while the pointer is on a cell in the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual bool MouseDownUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// Indicates whether a row will be unshared when the mouse pointer moves over a cell in the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual bool MouseEnterUnsharesRow(int intRowIndex)
		{
			return false;
		}

		/// Indicates whether a row will be unshared when the mouse pointer leaves the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual bool MouseLeaveUnsharesRow(int intRowIndex)
		{
			return false;
		}

		/// Indicates whether a row will be unshared when the mouse pointer moves over a cell in the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual bool MouseMoveUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// Indicates whether a row will be unshared when the user releases a mouse button while the pointer is on a cell in the row.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual bool MouseUpUnsharesRow(DataGridViewCellMouseEventArgs e)
		{
			return false;
		}

		/// Called when the cell is clicked.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected virtual void OnClick(DataGridViewCellEventArgs e)
		{
		}

		/// Called when the cell's contents are clicked.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected virtual void OnContentClick(DataGridViewCellEventArgs e)
		{
		}

		/// Called when the cell's contents are double-clicked.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected virtual void OnContentDoubleClick(DataGridViewCellEventArgs e)
		{
		}

		/// Called when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell changes.</summary>
		protected override void OnDataGridViewChanged()
		{
		}

		/// Called when the cell is double-clicked.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected virtual void OnDoubleClick(DataGridViewCellEventArgs e)
		{
		}

		/// Called when the focus moves to a cell.</summary>
		/// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual void OnEnter(int intRowIndex, bool blnThroughMouseClick)
		{
		}

		/// Called when a character key is pressed while the focus is on a cell.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual void OnKeyDown(KeyEventArgs e, int intRowIndex)
		{
		}

		/// Called when a key is pressed while the focus is on a cell.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual void OnKeyPress(KeyPressEventArgs e, int intRowIndex)
		{
		}

		/// Called when a character key is released while the focus is on a cell.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual void OnKeyUp(KeyEventArgs e, int intRowIndex)
		{
		}

		/// Called when the focus moves from a cell.</summary>
		/// <param name="blnThroughMouseClick">true if a user action moved focus from the cell; false if a programmatic operation moved focus from the cell.</param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual void OnLeave(int intRowIndex, bool blnThroughMouseClick)
		{
		}

		/// Called when the user clicks a mouse button while the pointer is on a cell.  </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual void OnMouseClick(DataGridViewCellMouseEventArgs e)
		{
		}

		/// Called when the user double-clicks a mouse button while the pointer is on a cell.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual void OnMouseDoubleClick(DataGridViewCellMouseEventArgs e)
		{
		}

		/// Called when the user holds down a mouse button while the pointer is on a cell.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual void OnMouseDown(DataGridViewCellMouseEventArgs e)
		{
		}

		/// Called when the mouse pointer moves over a cell.</summary>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual void OnMouseEnter(int intRowIndex)
		{
		}

		/// Called when the mouse pointer leaves the cell.</summary>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected virtual void OnMouseLeave(int intRowIndex)
		{
		}

		/// Called when the mouse pointer moves within a cell.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual void OnMouseMove(DataGridViewCellMouseEventArgs e)
		{
		}

		/// Called when the user releases a mouse button while the pointer is on a cell. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		protected virtual void OnMouseUp(DataGridViewCellMouseEventArgs e)
		{
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (base.DataGridView != null)
			{
				bool flag = base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOWN) || base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEUP) || base.DataGridView.IsCriticalEvent(Control.ClickEvent) || base.DataGridView.IsCriticalEvent(Control.MouseClickEvent) || base.DataGridView.IsCriticalEvent(Control.MouseDownEvent) || base.DataGridView.IsCriticalEvent(Control.MouseUpEvent);
				if (flag || base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCLICK) || base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTCLICK))
				{
					criticalEventsData.Set("CL");
				}
				if (base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLDOUBLECLICK) || base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK) || base.DataGridView.IsCriticalEvent(Control.DoubleClickEvent))
				{
					criticalEventsData.Set("DCL");
				}
				if (base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLBEGINEDIT))
				{
					criticalEventsData.Set("BE");
				}
				if (base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLENDEDIT))
				{
					criticalEventsData.Set("EE");
				}
				if ((OwningRow == null || !OwningRow.IsFilterRow) && (flag || GetInheritedContextMenu(RowIndex) != null || GetInheritedContextMenuStrip(RowIndex) != null))
				{
					criticalEventsData.Set("RC");
				}
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the mouse event captures.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual MouseCaptures GetMouseEventCaptures()
		{
			return MouseCaptures.None;
		}

		/// 
		/// Gets the key event captures.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual KeyCaptures GetKeyEventCaptures()
		{
			return KeyCaptures.None;
		}

		internal void OnCommonChange()
		{
			if (base.DataGridView != null && !base.DataGridView.IsDisposed && !base.DataGridView.Disposing)
			{
				if (RowIndex == -1)
				{
					base.DataGridView.OnColumnCommonChange(ColumnIndex);
				}
				else
				{
					base.DataGridView.OnCellCommonChange(ColumnIndex, RowIndex);
				}
			}
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "Click":
				if (base.DataGridView != null)
				{
					int eventValue = GetEventValue(objEvent, "X", 0);
					int eventValue2 = GetEventValue(objEvent, "Y", 0);
					MouseEventArgs e2 = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue, eventValue2, 0);
					if (e2.Button == MouseButtons.Right)
					{
						OnRightClick(e2);
					}
					if (base.DataGridView != null)
					{
						MouseEventArgs objMouseEventArgs = new MouseEventArgs(e2.Button, 1, Location.X + eventValue, Location.Y + eventValue2, 0);
						DataGridViewCellEventArgs objDataGridViewCellEventArgs = new DataGridViewCellEventArgs(this);
						DataGridViewCellMouseEventArgs objDataGridViewCellMouseEventArgs = new DataGridViewCellMouseEventArgs(ColumnIndex, RowIndex, eventValue, eventValue2, new MouseEventArgs(e2.Button, 1, eventValue, eventValue2, 0));
						base.DataGridView.FireClickEvents(objMouseEventArgs, objDataGridViewCellEventArgs, objDataGridViewCellMouseEventArgs);
					}
				}
				break;
			case "DoubleClick":
				if (base.DataGridView != null)
				{
					base.DataGridView.FireDoubleClickEvents(new DataGridViewCellEventArgs(this));
				}
				break;
			case "BeginEdit":
				if (base.DataGridView != null)
				{
					DataGridViewCellCancelEventArgs e3 = new DataGridViewCellCancelEventArgs(this);
					base.DataGridView.OnCellBeginEdit(e3);
					if (e3.Cancel)
					{
						Update();
					}
				}
				break;
			case "EndEdit":
				if (base.DataGridView != null)
				{
					DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(this);
					base.DataGridView.OnCellEndEdit(e);
				}
				break;
			}
		}

		/// 
		/// Raises the <see cref="E:RightClick" /> event.
		/// </summary>
		/// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
		private void OnRightClick(MouseEventArgs objMouseEventArgs)
		{
			ContextMenu inheritedContextMenu = GetInheritedContextMenu(RowIndex);
			if (inheritedContextMenu != null)
			{
				inheritedContextMenu.Show(base.DataGridView, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
			}
			else
			{
				GetInheritedContextMenuStrip(RowIndex)?.Show(base.DataGridView, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y));
			}
		}

		/// 
		/// Gets the event integer attribute value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="strAttribute">The attribute name.</param>
		/// <param name="intDefault">The default integer value.</param>
		/// </returns>
		protected new int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
		{
			string text = objEvent[strAttribute];
			if (CommonUtils.IsNullOrEmpty(text))
			{
				return intDefault;
			}
			return int.Parse(text);
		}

		/// 
		/// Renders the component event attributes.
		/// </summary>
		/// <param name="objContext">context.</param>
		/// <param name="objWriter">writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderCaptureAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			long num = 0L;
			MouseCaptures mouseEventCaptures = GetMouseEventCaptures();
			if (mouseEventCaptures != MouseCaptures.None)
			{
				num = (long)mouseEventCaptures + 2L;
			}
			KeyCaptures keyEventCaptures = GetKeyEventCaptures();
			if (keyEventCaptures != KeyCaptures.None)
			{
				num |= (long)keyEventCaptures + 1L;
			}
			if (num > 0 || blnForceRender)
			{
				objWriter.WriteAttributeString("EC", num.ToString());
			}
		}

		/// 
		/// Renders the cell text/value.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objFormatedValue">The formated value.</param>
		protected virtual void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
		{
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			RenderCellValue(objContext, objWriter, mobjFormattedValue);
			RenderCellStyleAttributes(objWriter, mobjFormattedCellStyle);
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			RenderCaptureAttribute(objContext, objWriter, blnForceRender: false);
			objWriter.WriteAttributeString("TP", TypeName);
			RenderReadOnlyAttribute(objWriter);
			if (DataGridViewElement.ShouldRender(RenderMask, Renderable.SelectedAttribute))
			{
				RenderSelectedAttribute(objContext, objWriter, blnForceRender: false);
			}
			if (SupportActiveMode)
			{
				objWriter.WriteAttributeText("SAM", "1");
			}
			if (SupportEditMode && (!HasPanel || base.DataGridView.CustomStyle == "V"))
			{
				objWriter.WriteAttributeText("SEM", "1");
			}
			if (!base.DataGridView.ShowCellToolTips)
			{
				return;
			}
			if (HasToolTipText)
			{
				objWriter.WriteAttributeText("TT", ToolTipText);
			}
			else if (this is DataGridViewTextBoxCell || this is DataGridViewLinkCell)
			{
				int width = base.DataGridView.Columns[ColumnIndex].Width;
				if (mobjFormattedCellStyle != null)
				{
					width = GetPreferredSize(ValueText, mobjFormattedCellStyle).Width;
				}
				if (ValueText != string.Empty && width > base.DataGridView.Columns[ColumnIndex].Width && InheritedStyle.WrapMode != DataGridViewTriState.True)
				{
					object formattedValue = FormattedValue;
					objWriter.WriteAttributeText("TT", (formattedValue != null) ? formattedValue.ToString() : ValueText);
				}
			}
			else if (ColumnIndex >= 0 && ColumnIndex < base.DataGridView.Columns.Count && base.DataGridView.Columns[ColumnIndex].CellTemplate != null && base.DataGridView.Columns[ColumnIndex].CellTemplate.HasToolTipText)
			{
				objWriter.WriteAttributeText("TT", base.DataGridView.Columns[ColumnIndex].CellTemplate.ToolTipText);
			}
		}

		/// 
		/// Renders the cell style attributes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objCellStyle">The cell style.</param>
		protected virtual void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
		{
			if (objCellStyle == null)
			{
				return;
			}
			if (objCellStyle.Font != null && objCellStyle.Font != base.DataGridView.DefaultDefaultCellStyleInternal.Font)
			{
				objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(objCellStyle.Font));
			}
			objWriter.WriteAttributeString("TIR", 0.ToString());
			RenderBackColorAttribute(objWriter, objCellStyle);
			if (objCellStyle.Padding != base.DataGridView.DefaultDefaultCellStyleInternal.Padding)
			{
				if (objCellStyle.Padding.Top != 0)
				{
					objWriter.WriteAttributeString("PT", Convert.ToString(objCellStyle.Padding.Top));
				}
				if (objCellStyle.Padding.Right != 0)
				{
					objWriter.WriteAttributeString("PR", Convert.ToString(objCellStyle.Padding.Right));
				}
				if (objCellStyle.Padding.Bottom != 0)
				{
					objWriter.WriteAttributeString("PB", Convert.ToString(objCellStyle.Padding.Bottom));
				}
				if (objCellStyle.Padding.Left != 0)
				{
					objWriter.WriteAttributeString("PL", Convert.ToString(objCellStyle.Padding.Left));
				}
			}
			RenderWrapModeAttribute(objWriter, objCellStyle);
			if (objCellStyle.SelectionBackColor != base.DataGridView.DefaultDefaultCellStyleInternal.SelectionBackColor)
			{
				objWriter.WriteAttributeString("SBC", CommonUtils.GetHtmlColor(objCellStyle.SelectionBackColor));
			}
			RenderForeColorAttribute(objWriter, objCellStyle);
			if (objCellStyle.SelectionForeColor != base.DataGridView.DefaultDefaultCellStyleInternal.SelectionForeColor)
			{
				objWriter.WriteAttributeString("SFC", CommonUtils.GetHtmlColor(objCellStyle.SelectionForeColor));
			}
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
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderSelectedAttribute(objContext, objWriter, blnForceRender: true);
				RenderReadOnlyAttribute(objWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Events))
			{
				RenderCaptureAttribute(objContext, objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the selected attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSelectedAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			if (Selected && OwningRow != null && !OwningRow.Selected && (base.DataGridView.SelectionMode == DataGridViewSelectionMode.CellSelect || base.DataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect))
			{
				objWriter.WriteAttributeString("SE", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SE", "0");
			}
		}

		/// 
		/// Renders the wrap mode attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
		protected virtual void RenderWrapModeAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
		{
			if (objInheritedCellStyle.WrapMode == DataGridViewTriState.True)
			{
				objWriter.WriteAttributeString("WC", "1");
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
			if (mobjPanel != null && mobjPanel.Colspan > 0 && mobjPanel.Rowspan > 0)
			{
				mobjPanel.RenderControl(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the read only attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderReadOnlyAttribute(IAttributeWriter objWriter)
		{
			if (!base.DataGridView.ReadOnly && GetElementReadOnly(out var blnElementReadOnlyValue))
			{
				if (!blnElementReadOnlyValue && (OwningColumn.ElementReadOnly == ElementReadOnlyType.True || OwningRow.ElementReadOnly == ElementReadOnlyType.True))
				{
					objWriter.WriteAttributeString("RO", "0");
				}
				else if (blnElementReadOnlyValue && OwningColumn.ElementReadOnly != ElementReadOnlyType.True && OwningRow.ElementReadOnly != ElementReadOnlyType.True)
				{
					objWriter.WriteAttributeString("RO", "1");
				}
			}
		}

		/// 
		/// Renders the fore color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
		protected virtual void RenderForeColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
		{
			if (objInheritedCellStyle.ForeColor != base.DataGridView.DefaultDefaultCellStyleInternal.ForeColor)
			{
				objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(objInheritedCellStyle.ForeColor));
			}
		}

		/// 
		/// Renders the back color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
		protected virtual void RenderBackColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
		{
			if (objInheritedCellStyle.BackColor != base.DataGridView.DefaultDefaultCellStyleInternal.BackColor)
			{
				objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(objInheritedCellStyle.BackColor));
			}
		}

		/// 
		/// Paints the current DataGridViewCell.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objClipBounds">The clip bounds.</param>
		/// <param name="objCellBounds">The cell bounds.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="enmCellState">State of the cell.</param>
		/// <param name="objValue">The value.</param>
		/// <param name="objFormattedValue">The formatted value.</param>
		/// <param name="strErrorText">The error text.</param>
		/// <param name="objCellStyle">The cell style.</param>
		/// <param name="objAdvancedBorderStyle">The advanced border style.</param>
		/// <param name="enmPaintParts">The paint parts.</param>
		protected virtual void Paint(Graphics objGraphics, Rectangle objClipBounds, Rectangle objCellBounds, int intRowIndex, DataGridViewElementStates enmCellState, object objValue, object objFormattedValue, string strErrorText, DataGridViewCellStyle objCellStyle, DataGridViewAdvancedBorderStyle objAdvancedBorderStyle, DataGridViewPaintParts enmPaintParts)
		{
		}

		internal static bool PaintBackground(DataGridViewPaintParts paintParts)
		{
			return (paintParts & DataGridViewPaintParts.Background) != 0;
		}

		internal static bool PaintBorder(DataGridViewPaintParts paintParts)
		{
			return (paintParts & DataGridViewPaintParts.Border) != 0;
		}

		internal static bool PaintContentBackground(DataGridViewPaintParts paintParts)
		{
			return (paintParts & DataGridViewPaintParts.ContentBackground) != 0;
		}

		internal static bool PaintContentForeground(DataGridViewPaintParts paintParts)
		{
			return (paintParts & DataGridViewPaintParts.ContentForeground) != 0;
		}

		internal static bool PaintErrorIcon(DataGridViewPaintParts paintParts)
		{
			return (paintParts & DataGridViewPaintParts.ErrorIcon) != 0;
		}

		private static void PaintErrorIcon(Graphics objGraphics, Rectangle objIconBounds)
		{
			Bitmap errorBitmap = ErrorBitmap;
			if (errorBitmap != null)
			{
				lock (errorBitmap)
				{
					objGraphics.DrawImage(errorBitmap, objIconBounds, 0, 0, 12, 11, GraphicsUnit.Pixel);
				}
			}
		}

		/// 
		/// Paints the error icon of the current DataGridViewCell.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objClipBounds">The clip bounds.</param>
		/// <param name="objCellValueBounds">The cell value bounds.</param>
		/// <param name="strErrorText">The error text.</param>
		protected virtual void PaintErrorIcon(Graphics objGraphics, Rectangle objClipBounds, Rectangle objCellValueBounds, string strErrorText)
		{
			if (!CommonUtils.IsNullOrEmpty(strErrorText) && objCellValueBounds.Width >= 20 && objCellValueBounds.Height >= 19)
			{
				PaintErrorIcon(objGraphics, ComputeErrorIconBounds(objCellValueBounds));
			}
		}

		internal void PaintErrorIcon(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Rectangle objCellBounds, Rectangle objCellValueBounds, string strErrorText)
		{
			if (!CommonUtils.IsNullOrEmpty(strErrorText) && objCellValueBounds.Width >= 20 && objCellValueBounds.Height >= 19)
			{
				Rectangle errorIconBounds = GetErrorIconBounds(objGraphics, objCellStyle, intRowIndex);
				if (errorIconBounds.Width >= 4 && errorIconBounds.Height >= 11)
				{
					errorIconBounds.X += objCellBounds.X;
					errorIconBounds.Y += objCellBounds.Y;
					PaintErrorIcon(objGraphics, errorIconBounds);
				}
			}
		}

		internal static bool PaintFocus(DataGridViewPaintParts paintParts)
		{
			return (paintParts & DataGridViewPaintParts.Focus) != 0;
		}

		internal void PaintInternal(Graphics objGraphics, Rectangle objClipBounds, Rectangle objCellBounds, int intRowIndex, DataGridViewElementStates enmCellState, object objValue, object objFormattedValue, string strErrorText, DataGridViewCellStyle objCellStyle, DataGridViewAdvancedBorderStyle objAdvancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			Paint(objGraphics, objClipBounds, objCellBounds, intRowIndex, enmCellState, objValue, objFormattedValue, strErrorText, objCellStyle, objAdvancedBorderStyle, paintParts);
		}

		internal static void PaintPadding(Graphics objGraphics, Rectangle objBounds, DataGridViewCellStyle objCellStyle, Brush objBrush, bool blnRightToLeft)
		{
			Rectangle rect;
			if (blnRightToLeft)
			{
				rect = new Rectangle(objBounds.X, objBounds.Y, objCellStyle.Padding.Right, objBounds.Height);
				objGraphics.FillRectangle(objBrush, rect);
				rect.X = objBounds.Right - objCellStyle.Padding.Left;
				rect.Width = objCellStyle.Padding.Left;
				objGraphics.FillRectangle(objBrush, rect);
				rect.X = objBounds.Left + objCellStyle.Padding.Right;
			}
			else
			{
				rect = new Rectangle(objBounds.X, objBounds.Y, objCellStyle.Padding.Left, objBounds.Height);
				objGraphics.FillRectangle(objBrush, rect);
				rect.X = objBounds.Right - objCellStyle.Padding.Right;
				rect.Width = objCellStyle.Padding.Right;
				objGraphics.FillRectangle(objBrush, rect);
				rect.X = objBounds.Left + objCellStyle.Padding.Left;
			}
			rect.Y = objBounds.Y;
			rect.Width = objBounds.Width - objCellStyle.Padding.Horizontal;
			rect.Height = objCellStyle.Padding.Top;
			objGraphics.FillRectangle(objBrush, rect);
			rect.Y = objBounds.Bottom - objCellStyle.Padding.Bottom;
			rect.Height = objCellStyle.Padding.Bottom;
			objGraphics.FillRectangle(objBrush, rect);
		}

		internal static bool PaintSelectionBackground(DataGridViewPaintParts paintParts)
		{
			return (paintParts & DataGridViewPaintParts.SelectionBackground) != 0;
		}

		/// 
		///
		/// </summary>
		/// <param name="objCellBounds"></param>
		/// <param name="objCellClip"></param>
		/// <param name="objCellStyle"></param>
		/// <param name="blnSingleVerticalBorderAdded"></param>
		/// <param name="blnSingleHorizontalBorderAdded"></param>
		/// <param name="blnIsFirstDisplayedColumn"></param>
		/// <param name="blnIsFirstDisplayedRow"></param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual Rectangle PositionEditingPanel(Rectangle objCellBounds, Rectangle objCellClip, DataGridViewCellStyle objCellStyle, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
		{
			if (base.DataGridView == null)
			{
				throw new InvalidOperationException();
			}
			DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder = new DataGridViewAdvancedBorderStyle();
			DataGridViewAdvancedBorderStyle objAdvancedBorderStyle = AdjustCellBorderStyle(base.DataGridView.AdvancedCellBorderStyle, objDataGridViewAdvancedBorderStylePlaceholder, blnSingleVerticalBorderAdded, blnSingleHorizontalBorderAdded, blnIsFirstDisplayedColumn, blnIsFirstDisplayedRow);
			Rectangle rectangle = BorderWidths(objAdvancedBorderStyle);
			rectangle.X += objCellStyle.Padding.Left;
			rectangle.Y += objCellStyle.Padding.Top;
			rectangle.Width += objCellStyle.Padding.Right;
			rectangle.Height += objCellStyle.Padding.Bottom;
			int width = objCellBounds.Width;
			int height = objCellBounds.Height;
			int x;
			if (objCellClip.X - objCellBounds.X >= rectangle.X)
			{
				x = objCellClip.X;
				width -= objCellClip.X - objCellBounds.X;
			}
			else
			{
				x = objCellBounds.X + rectangle.X;
				width -= rectangle.X;
			}
			width = ((objCellClip.Right > objCellBounds.Right - rectangle.Width) ? (width - rectangle.Width) : (width - (objCellBounds.Right - objCellClip.Right)));
			int x2 = objCellBounds.X - objCellClip.X;
			int width2 = objCellBounds.Width - rectangle.X - rectangle.Width;
			int y;
			if (objCellClip.Y - objCellBounds.Y >= rectangle.Y)
			{
				y = objCellClip.Y;
				height -= objCellClip.Y - objCellBounds.Y;
			}
			else
			{
				y = objCellBounds.Y + rectangle.Y;
				height -= rectangle.Y;
			}
			height = ((objCellClip.Bottom > objCellBounds.Bottom - rectangle.Height) ? (height - rectangle.Height) : (height - (objCellBounds.Bottom - objCellClip.Bottom)));
			int y2 = objCellBounds.Y - objCellClip.Y;
			int height2 = objCellBounds.Height - rectangle.Y - rectangle.Height;
			base.DataGridView.EditingPanel.Location = new Point(x, y);
			base.DataGridView.EditingPanel.Size = new Size(width, height);
			return new Rectangle(x2, y2, width2, height2);
		}

		private static string TruncateToolTipText(string strToolTipText)
		{
			if (strToolTipText.Length > 288)
			{
				StringBuilder stringBuilder = new StringBuilder(strToolTipText.Substring(0, 256), 259);
				stringBuilder.Append("...");
				return stringBuilder.ToString();
			}
			return strToolTipText;
		}

		private void UpdateCurrentMouseLocation(DataGridViewCellMouseEventArgs e)
		{
			if (GetErrorIconBounds(e.RowIndex).Contains(e.X, e.Y))
			{
				CurrentMouseLocation = 2;
			}
			else
			{
				CurrentMouseLocation = 1;
			}
		}

		private string GetToolTipText(int intRowIndex)
		{
			string toolTipTextInternal = ToolTipTextInternal;
			if (base.DataGridView == null || (!base.DataGridView.VirtualMode && base.DataGridView.DataSource == null))
			{
				return toolTipTextInternal;
			}
			return base.DataGridView.OnCellToolTipTextNeeded(ColumnIndex, intRowIndex, toolTipTextInternal);
		}

		/// 
		/// Gets the context menu.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal ContextMenu GetContextMenu(int intRowIndex)
		{
			ContextMenu contextMenuInternal = ContextMenuInternal;
			if (base.DataGridView == null || (!base.DataGridView.VirtualMode && base.DataGridView.DataSource == null))
			{
				return contextMenuInternal;
			}
			return base.DataGridView.OnCellContextMenuNeeded(ColumnIndex, intRowIndex, contextMenuInternal);
		}

		/// 
		/// Gets the context menu strip.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// </returns>
		public ContextMenuStrip GetContextMenuStrip(int rowIndex)
		{
			ContextMenuStrip contextMenuStripInternal = ContextMenuStripInternal;
			if (base.DataGridView == null || (!base.DataGridView.VirtualMode && base.DataGridView.DataSource == null))
			{
				return contextMenuStripInternal;
			}
			return base.DataGridView.OnCellContextMenuStripNeeded(ColumnIndex, rowIndex, contextMenuStripInternal);
		}

		/// 
		/// Detaches the context menu.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DetachContextMenu(object sender, EventArgs e)
		{
			ContextMenuInternal = null;
		}

		/// 
		/// Detaches the context menu strip.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DetachContextMenuStrip(object sender, EventArgs e)
		{
			ContextMenuStripInternal = null;
		}

		/// 
		/// Gets the inherited context menu strip.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// </returns>
		public virtual ContextMenuStrip GetInheritedContextMenuStrip(int rowIndex)
		{
			if (base.DataGridView != null)
			{
				if (rowIndex < 0 || rowIndex >= base.DataGridView.Rows.Count)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				if (ColumnIndex < 0)
				{
					throw new InvalidOperationException();
				}
			}
			ContextMenuStrip contextMenuStrip = GetContextMenuStrip(rowIndex);
			if (contextMenuStrip != null)
			{
				return contextMenuStrip;
			}
			if (OwningRow != null)
			{
				contextMenuStrip = OwningRow.GetContextMenuStrip(rowIndex);
				if (contextMenuStrip != null)
				{
					return contextMenuStrip;
				}
			}
			if (OwningColumn != null)
			{
				contextMenuStrip = OwningColumn.ContextMenuStrip;
				if (contextMenuStrip != null)
				{
					return contextMenuStrip;
				}
			}
			if (base.DataGridView != null)
			{
				return base.DataGridView.ContextMenuStrip;
			}
			return null;
		}

		/// Gets the inherited shortcut menu for the current cell.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> if the parent <see cref="T:System.Windows.Forms.DataGridView"></see>, <see cref="T:System.Windows.Forms.DataGridViewRow"></see>, or <see cref="T:System.Windows.Forms.DataGridViewColumn"></see> has a <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> assigned; otherwise, null.</returns>
		/// <param name="intRowIndex">The row index of the current cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the specified rowIndex is less than 0 or greater than the number of rows in the control minus 1. </exception>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		public virtual ContextMenu GetInheritedContextMenu(int intRowIndex)
		{
			if (base.DataGridView != null)
			{
				if (intRowIndex < 0 || intRowIndex >= base.DataGridView.Rows.Count)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				if (ColumnIndex < 0)
				{
					throw new InvalidOperationException();
				}
			}
			ContextMenu contextMenu = GetContextMenu(intRowIndex);
			if (contextMenu != null)
			{
				return contextMenu;
			}
			if (OwningRow != null)
			{
				contextMenu = OwningRow.GetContextMenu(intRowIndex);
				if (contextMenu != null)
				{
					return contextMenu;
				}
			}
			if (OwningColumn != null)
			{
				contextMenu = OwningColumn.ContextMenu;
				if (contextMenu != null)
				{
					return contextMenu;
				}
			}
			if (base.DataGridView != null)
			{
				return base.DataGridView.ContextMenu;
			}
			return null;
		}

		/// Modifies the input cell border style according to the specified criteria. </summary>
		/// The modified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</returns>
		/// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the cell border style. </param>
		/// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false. </param>
		/// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the cell border style to modify.</param>
		/// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false. </param>
		/// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false. </param>
		/// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false. </param>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual DataGridViewAdvancedBorderStyle AdjustCellBorderStyle(DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
		{
			return null;
		}

		/// Indicates whether the cell's row will be unshared when the cell is clicked.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
		protected virtual bool ClickUnsharesRow(DataGridViewCellEventArgs e)
		{
			return false;
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
		/// 1</filterpriority>
		public virtual object Clone()
		{
			DataGridViewCell dataGridViewCell = (DataGridViewCell)Activator.CreateInstance(GetType());
			CloneInternal(dataGridViewCell);
			return dataGridViewCell;
		}

		/// Indicates whether the cell's row will be unshared when the cell's content is clicked.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnContentClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
		protected virtual bool ContentClickUnsharesRow(DataGridViewCellEventArgs e)
		{
			return false;
		}

		/// Indicates whether the cell's row will be unshared when the cell's content is double-clicked.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnContentDoubleClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
		protected virtual bool ContentDoubleClickUnsharesRow(DataGridViewCellEventArgs e)
		{
			return false;
		}

		/// Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual void DetachEditingControl()
		{
		}

		/// Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>. </summary>
		/// 1</filterpriority>
		public void Dispose()
		{
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and optionally releases the managed resources. </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected virtual void Dispose(bool blnDisposing)
		{
		}

		/// Indicates whether the cell's row will be unshared when the cell is double-clicked.</summary>
		/// true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnDoubleClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
		protected virtual bool DoubleClickUnsharesRow(DataGridViewCellEventArgs e)
		{
			return false;
		}

		/// Indicates whether the parent row will be unshared when the focus moves to the cell.</summary>
		/// true if the row will be unshared; otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
		/// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		protected virtual bool EnterUnsharesRow(int intRowIndex, bool blnThroughMouseClick)
		{
			return false;
		}

		/// Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
		/// An <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
		/// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="strFormat">The current format string of the cell.</param>
		/// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the control.</exception>
		/// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">The value of the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property is null.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		protected virtual object GetClipboardContent(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
		{
			if (base.DataGridView == null)
			{
				return null;
			}
			if (intRowIndex < 0 || intRowIndex >= base.DataGridView.Rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			DataGridViewCellStyle objDataGridViewCellStyle = GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			object obj = null;
			if (base.DataGridView.IsSharedCellSelected(this, intRowIndex))
			{
				obj = GetEditedFormattedValue(GetValue(intRowIndex), intRowIndex, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.ClipboardContent | DataGridViewDataErrorContexts.Formatting);
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			if (strFormat == DataFormats.Html)
			{
				if (blnFirstCell)
				{
					if (blnInFirstRow)
					{
						stringBuilder.Append("");
					}
					stringBuilder.Append("");
				}
				stringBuilder.Append("");
				if (obj != null)
				{
					FormatPlainTextAsHtml(obj.ToString(), new StringWriter(stringBuilder, CultureInfo.CurrentCulture));
				}
				else
				{
					stringBuilder.Append("&nbsp;");
				}
				stringBuilder.Append("</TD>");
				if (blnLastCell)
				{
					stringBuilder.Append("</TR>");
					if (blnInLastRow)
					{
						stringBuilder.Append("</TABLE>");
					}
				}
				return stringBuilder.ToString();
			}
			bool flag = strFormat == "CommaSeparatedValue";
			if (!flag && !(strFormat == DataFormats.Text) && !(strFormat == DataFormats.UnicodeText))
			{
				return null;
			}
			if (obj != null)
			{
				if (blnFirstCell && blnLastCell && blnInFirstRow && blnInLastRow)
				{
					stringBuilder.Append(obj.ToString());
				}
				else
				{
					bool blnEscapeApplied = false;
					int length = stringBuilder.Length;
					FormatPlainText(obj.ToString(), flag, new StringWriter(stringBuilder, CultureInfo.CurrentCulture), ref blnEscapeApplied);
					if (blnEscapeApplied)
					{
						stringBuilder.Insert(length, '"');
					}
				}
			}
			if (blnLastCell)
			{
				if (!blnInLastRow)
				{
					stringBuilder.Append('\r');
					stringBuilder.Append('\n');
				}
			}
			else
			{
				stringBuilder.Append(flag ? ',' : '\t');
			}
			return stringBuilder.ToString();
		}

		/// 
		/// Gets the clipboard content internal.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnFirstCell">if set to true</c> [first cell].</param>
		/// <param name="blnLastCell">if set to true</c> [last cell].</param>
		/// <param name="blnInFirstRow">if set to true</c> [in first row].</param>
		/// <param name="blnInLastRow">if set to true</c> [in last row].</param>
		/// <param name="strFormat">The format.</param>
		/// </returns>
		internal object GetClipboardContentInternal(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
		{
			return GetClipboardContent(intRowIndex, blnFirstCell, blnLastCell, blnInFirstRow, blnInLastRow, strFormat);
		}

		/// Returns the current, formatted value of the cell, regardless of whether the cell is in edit mode and the value has not been committed.</summary>
		/// The current, formatted value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
		/// <param name="intRowIndex">The row index of the cell.</param>
		/// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified rowIndex is less than 0 or greater than the number of rows in the control minus 1. </exception>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		public object GetEditedFormattedValue(int intRowIndex, DataGridViewDataErrorContexts enmContext)
		{
			if (base.DataGridView == null)
			{
				return null;
			}
			DataGridViewCellStyle objDataGridViewCellStyle = GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			return GetEditedFormattedValue(GetValue(intRowIndex), intRowIndex, ref objDataGridViewCellStyle, enmContext);
		}

		/// 
		/// Gets the edited formatted value.
		/// </summary>
		/// <param name="objValue">The value.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objDataGridViewCellStyle">The data grid view cell style.</param>
		/// <param name="enmContext">The context.</param>
		/// </returns>
		internal object GetEditedFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objDataGridViewCellStyle, DataGridViewDataErrorContexts enmContext)
		{
			return GetFormattedValue(objValue, intRowIndex, ref objDataGridViewCellStyle, null, null, enmContext);
		}

		/// 
		/// Sets the value.
		/// </summary>
		/// <param name="objValue">The obj value.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		protected void SetValue(object objValue, bool blnClientSource)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				if (dataGridView.CurrentCell != this)
				{
					dataGridView.SetCurrentCell(this, blnClientSource);
				}
				EditingProposedValue = objValue;
				dataGridView.BeginEdit(blnSelectAll: false, blnClientSource);
				bool flag = dataGridView.NewRowIndex == dataGridView.CurrentCellPoint.Y;
				dataGridView.NotifyCurrentCellDirty(blnDirty: true, blnClientSource);
				if (!dataGridView.CommitEditForOperation(ColumnIndex, RowIndex, blnForCurrentCellChange: true, blnClientSource))
				{
					Update();
				}
				dataGridView.NotifyCurrentCellDirty(blnDirty: false);
				if (dataGridView.UseInternalPaging && flag && dataGridView.CurrentPage != dataGridView.TotalPages)
				{
					dataGridView.CurrentPage = dataGridView.TotalPages;
					dataGridView.PerformScrollIntoView(this, blnHidePopups: true);
				}
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
			if (mobjPanel != null)
			{
				mobjPanel.PreRenderComponent(objContext, lngRequestID);
			}
			if (!(IsDirty(lngRequestID) || blnForcePreRender))
			{
				return;
			}
			int rowIndex = RowIndex;
			if (!DataGridViewElement.ShouldPreRender(PreRenderMask, PreRenderable.CellStyle))
			{
				return;
			}
			DataGridViewCellStyle inheritedStyle = GetInheritedStyle(null, rowIndex, blnIncludeColors: true);
			if (inheritedStyle != null)
			{
				mobjFormattedCellStyle = inheritedStyle.Clone();
				if (OwningRow == null || !OwningRow.IsFilterRow)
				{
					mobjFormattedValue = GetEditedFormattedValue(GetValue(rowIndex), rowIndex, ref mobjFormattedCellStyle, DataGridViewDataErrorContexts.Display | DataGridViewDataErrorContexts.Formatting);
				}
			}
		}

		/// Gets the value of the cell as formatted for display. </summary>
		/// The formatted value of the cell or null if the cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
		/// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
		/// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <param name="objValue">The value to be formatted. </param>
		/// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
		/// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		protected virtual object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
		{
			if (base.DataGridView == null || this is DataGridViewFilterCell)
			{
				return null;
			}
			DataGridViewCellFormattingEventArgs e = base.DataGridView.OnCellFormatting(ColumnIndex, intRowIndex, objValue, FormattedValueType, objCellStyle);
			objCellStyle = e.CellStyle;
			bool formattingApplied = e.FormattingApplied;
			object obj = e.Value;
			bool flag = true;
			if (!formattingApplied && FormattedValueType != null && (obj == null || !FormattedValueType.IsAssignableFrom(obj.GetType())))
			{
				try
				{
					obj = ClientUtils.FormatObject(obj, FormattedValueType, (objValueTypeConverter == null) ? ValueTypeConverter : objValueTypeConverter, (objFormattedValueTypeConverter == null) ? FormattedValueTypeConverter : objFormattedValueTypeConverter, objCellStyle.Format, objCellStyle.FormatProvider, objCellStyle.NullValue, objCellStyle.DataSourceNullValue);
				}
				catch (Exception objException)
				{
					if (ClientUtils.IsCriticalException(objException))
					{
						throw;
					}
					DataGridViewDataErrorEventArgs e2 = new DataGridViewDataErrorEventArgs(objException, ColumnIndex, intRowIndex, enmContext);
					RaiseDataError(e2);
					if (e2.ThrowException)
					{
						throw e2.Exception;
					}
					flag = false;
				}
			}
			if (flag && (obj == null || FormattedValueType == null || !FormattedValueType.IsAssignableFrom(obj.GetType())))
			{
				if (obj == null && objCellStyle.NullValue == null && FormattedValueType != null && !typeof(ValueType).IsAssignableFrom(FormattedValueType))
				{
					return null;
				}
				Exception ex = null;
				ex = ((!(FormattedValueType == null)) ? new FormatException(SR.GetString("DataGridViewCell_FormattedValueHasWrongType")) : new FormatException(SR.GetString("DataGridViewCell_FormattedValueTypeNull")));
				DataGridViewDataErrorEventArgs e3 = new DataGridViewDataErrorEventArgs(ex, ColumnIndex, intRowIndex, enmContext);
				RaiseDataError(e3);
				if (e3.ThrowException)
				{
					throw e3.Exception;
				}
			}
			return obj;
		}

		internal object GetFormattedValue(int intRowIndex, ref DataGridViewCellStyle objCellStyle, DataGridViewDataErrorContexts enmContext)
		{
			if (base.DataGridView == null)
			{
				return null;
			}
			return GetFormattedValue(GetValue(intRowIndex), intRowIndex, ref objCellStyle, null, null, enmContext);
		}

		/// Returns a value indicating the current state of the cell as inherited from the state of its row and column.</summary>
		/// A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
		/// <param name="intRowIndex">The index of the row containing the cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is outside the valid range of 0 to the number of rows in the control minus 1.</exception>
		/// <exception cref="T:System.ArgumentException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is not -1.-or-rowIndex is not the index of the row containing this cell.</exception>
		public virtual DataGridViewElementStates GetInheritedState(int intRowIndex)
		{
			DataGridViewElementStates dataGridViewElementStates = State | DataGridViewElementStates.ResizableSet;
			DataGridViewRow owningRow = OwningRow;
			if (base.DataGridView == null)
			{
				if (intRowIndex != -1)
				{
					throw new ArgumentException(SR.GetString("InvalidArgument", "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture)));
				}
				if (owningRow != null)
				{
					dataGridViewElementStates |= owningRow.GetState(-1) & (DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
					if (owningRow.GetResizable(intRowIndex) == DataGridViewTriState.True)
					{
						dataGridViewElementStates |= DataGridViewElementStates.Resizable;
					}
				}
				return dataGridViewElementStates;
			}
			if (intRowIndex < 0 || intRowIndex >= base.DataGridView.Rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (base.DataGridView.Rows.SharedRow(intRowIndex) != owningRow)
			{
				throw new ArgumentException(SR.GetString("InvalidArgument", "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture)));
			}
			DataGridViewElementStates rowState = base.DataGridView.Rows.GetRowState(intRowIndex);
			DataGridViewColumn owningColumn = OwningColumn;
			dataGridViewElementStates |= rowState & (DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Selected);
			dataGridViewElementStates |= owningColumn.State & (DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Selected);
			if (owningRow.GetResizable(intRowIndex) == DataGridViewTriState.True || owningColumn.Resizable == DataGridViewTriState.True)
			{
				dataGridViewElementStates |= DataGridViewElementStates.Resizable;
			}
			if (owningColumn.Visible && owningRow.GetVisible(intRowIndex))
			{
				dataGridViewElementStates |= DataGridViewElementStates.Visible;
				if (owningColumn.Displayed && owningRow.GetDisplayed(intRowIndex))
				{
					dataGridViewElementStates |= DataGridViewElementStates.Displayed;
				}
			}
			if (owningColumn.Frozen && owningRow.GetFrozen(intRowIndex))
			{
				dataGridViewElementStates |= DataGridViewElementStates.Frozen;
			}
			return dataGridViewElementStates;
		}

		/// Gets the style applied to the cell. </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style. </param>
		/// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0, or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">The cell has no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		public virtual DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle objInheritedCellStyle, int intRowIndex, bool blnIncludeColors)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CellNeedsDataGridViewForInheritedStyle"));
			}
			if ((intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count) && !OwningRow.IsFilterRow)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (ColumnIndex < 0)
			{
				throw new InvalidOperationException();
			}
			DataGridViewCellStyle dataGridViewCellStyle;
			if (objInheritedCellStyle == null)
			{
				dataGridViewCellStyle = dataGridView.PlaceholderCellStyle;
				if (!blnIncludeColors)
				{
					dataGridViewCellStyle.BackColor = Color.Empty;
					dataGridViewCellStyle.ForeColor = Color.Empty;
					dataGridViewCellStyle.SelectionBackColor = Color.Empty;
					dataGridViewCellStyle.SelectionForeColor = Color.Empty;
				}
			}
			else
			{
				dataGridViewCellStyle = objInheritedCellStyle;
			}
			DataGridViewCellStyle dataGridViewCellStyle2 = null;
			if (HasStyle)
			{
				dataGridViewCellStyle2 = Style;
			}
			DataGridViewCellStyle dataGridViewCellStyle3 = null;
			if (dataGridView.Rows.SharedRow(intRowIndex).HasDefaultCellStyle)
			{
				dataGridViewCellStyle3 = dataGridView.Rows.SharedRow(intRowIndex).DefaultCellStyle;
			}
			DataGridViewCellStyle dataGridViewCellStyle4 = null;
			DataGridViewColumn owningColumn = OwningColumn;
			if (owningColumn.HasDefaultCellStyle)
			{
				dataGridViewCellStyle4 = owningColumn.DefaultCellStyle;
			}
			DataGridViewCellStyle rowsDefaultCellStyle = dataGridView.RowsDefaultCellStyle;
			DataGridViewCellStyle alternatingRowsDefaultCellStyle = dataGridView.AlternatingRowsDefaultCellStyle;
			DataGridViewCellStyle defaultCellStyle = dataGridView.DefaultCellStyle;
			if (blnIncludeColors)
			{
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = dataGridViewCellStyle2.BackColor;
				}
				else if (dataGridViewCellStyle3 != null && !dataGridViewCellStyle3.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = dataGridViewCellStyle3.BackColor;
				}
				else if (!rowsDefaultCellStyle.BackColor.IsEmpty && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.BackColor.IsEmpty))
				{
					dataGridViewCellStyle.BackColor = rowsDefaultCellStyle.BackColor;
				}
				else if (intRowIndex % 2 == 1 && !alternatingRowsDefaultCellStyle.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = alternatingRowsDefaultCellStyle.BackColor;
				}
				else if (dataGridViewCellStyle4 != null && !dataGridViewCellStyle4.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = dataGridViewCellStyle4.BackColor;
				}
				else
				{
					dataGridViewCellStyle.BackColor = defaultCellStyle.BackColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = dataGridViewCellStyle2.ForeColor;
				}
				else if (dataGridViewCellStyle3 != null && !dataGridViewCellStyle3.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = dataGridViewCellStyle3.ForeColor;
				}
				else if (!rowsDefaultCellStyle.ForeColor.IsEmpty && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.ForeColor.IsEmpty))
				{
					dataGridViewCellStyle.ForeColor = rowsDefaultCellStyle.ForeColor;
				}
				else if (intRowIndex % 2 == 1 && !alternatingRowsDefaultCellStyle.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = alternatingRowsDefaultCellStyle.ForeColor;
				}
				else if (dataGridViewCellStyle4 != null && !dataGridViewCellStyle4.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = dataGridViewCellStyle4.ForeColor;
				}
				else
				{
					dataGridViewCellStyle.ForeColor = defaultCellStyle.ForeColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = dataGridViewCellStyle2.SelectionBackColor;
				}
				else if (dataGridViewCellStyle3 != null && !dataGridViewCellStyle3.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = dataGridViewCellStyle3.SelectionBackColor;
				}
				else if (!rowsDefaultCellStyle.SelectionBackColor.IsEmpty && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.SelectionBackColor.IsEmpty))
				{
					dataGridViewCellStyle.SelectionBackColor = rowsDefaultCellStyle.SelectionBackColor;
				}
				else if (intRowIndex % 2 == 1 && !alternatingRowsDefaultCellStyle.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = alternatingRowsDefaultCellStyle.SelectionBackColor;
				}
				else if (dataGridViewCellStyle4 != null && !dataGridViewCellStyle4.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = dataGridViewCellStyle4.SelectionBackColor;
				}
				else
				{
					dataGridViewCellStyle.SelectionBackColor = defaultCellStyle.SelectionBackColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = dataGridViewCellStyle2.SelectionForeColor;
				}
				else if (dataGridViewCellStyle3 != null && !dataGridViewCellStyle3.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = dataGridViewCellStyle3.SelectionForeColor;
				}
				else if (!rowsDefaultCellStyle.SelectionForeColor.IsEmpty && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.SelectionForeColor.IsEmpty))
				{
					dataGridViewCellStyle.SelectionForeColor = rowsDefaultCellStyle.SelectionForeColor;
				}
				else if (intRowIndex % 2 == 1 && !alternatingRowsDefaultCellStyle.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = alternatingRowsDefaultCellStyle.SelectionForeColor;
				}
				else if (dataGridViewCellStyle4 != null && !dataGridViewCellStyle4.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = dataGridViewCellStyle4.SelectionForeColor;
				}
				else
				{
					dataGridViewCellStyle.SelectionForeColor = defaultCellStyle.SelectionForeColor;
				}
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Font != null)
			{
				dataGridViewCellStyle.Font = dataGridViewCellStyle2.Font;
			}
			else if (dataGridViewCellStyle3 != null && dataGridViewCellStyle3.Font != null)
			{
				dataGridViewCellStyle.Font = dataGridViewCellStyle3.Font;
			}
			else if (rowsDefaultCellStyle.Font != null && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.Font == null))
			{
				dataGridViewCellStyle.Font = rowsDefaultCellStyle.Font;
			}
			else if (intRowIndex % 2 == 1 && alternatingRowsDefaultCellStyle.Font != null)
			{
				dataGridViewCellStyle.Font = alternatingRowsDefaultCellStyle.Font;
			}
			else if (dataGridViewCellStyle4 != null && dataGridViewCellStyle4.Font != null)
			{
				dataGridViewCellStyle.Font = dataGridViewCellStyle4.Font;
			}
			else
			{
				dataGridViewCellStyle.Font = defaultCellStyle.Font;
			}
			bool isNullValueDefault = alternatingRowsDefaultCellStyle.IsNullValueDefault;
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = dataGridViewCellStyle2.NullValue;
			}
			else if (dataGridViewCellStyle3 != null && !dataGridViewCellStyle3.IsNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = dataGridViewCellStyle3.NullValue;
			}
			else if (!rowsDefaultCellStyle.IsNullValueDefault && (intRowIndex % 2 == 0 || isNullValueDefault))
			{
				dataGridViewCellStyle.NullValue = rowsDefaultCellStyle.NullValue;
			}
			else if (intRowIndex % 2 == 1 && !isNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = alternatingRowsDefaultCellStyle.NullValue;
			}
			else if (dataGridViewCellStyle4 != null && !dataGridViewCellStyle4.IsNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = dataGridViewCellStyle4.NullValue;
			}
			else
			{
				dataGridViewCellStyle.NullValue = defaultCellStyle.NullValue;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = dataGridViewCellStyle2.DataSourceNullValue;
			}
			else if (dataGridViewCellStyle3 != null && !dataGridViewCellStyle3.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = dataGridViewCellStyle3.DataSourceNullValue;
			}
			else if (!rowsDefaultCellStyle.IsDataSourceNullValueDefault && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.IsDataSourceNullValueDefault))
			{
				dataGridViewCellStyle.DataSourceNullValue = rowsDefaultCellStyle.DataSourceNullValue;
			}
			else if (intRowIndex % 2 == 1 && !alternatingRowsDefaultCellStyle.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = alternatingRowsDefaultCellStyle.DataSourceNullValue;
			}
			else if (dataGridViewCellStyle4 != null && !dataGridViewCellStyle4.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = dataGridViewCellStyle4.DataSourceNullValue;
			}
			else
			{
				dataGridViewCellStyle.DataSourceNullValue = defaultCellStyle.DataSourceNullValue;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = dataGridViewCellStyle2.Format;
			}
			else if (dataGridViewCellStyle3 != null && dataGridViewCellStyle3.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = dataGridViewCellStyle3.Format;
			}
			else if (rowsDefaultCellStyle.Format.Length != 0 && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.Format.Length == 0))
			{
				dataGridViewCellStyle.Format = rowsDefaultCellStyle.Format;
			}
			else if (intRowIndex % 2 == 1 && alternatingRowsDefaultCellStyle.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = alternatingRowsDefaultCellStyle.Format;
			}
			else if (dataGridViewCellStyle4 != null && dataGridViewCellStyle4.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = dataGridViewCellStyle4.Format;
			}
			else
			{
				dataGridViewCellStyle.Format = defaultCellStyle.Format;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = dataGridViewCellStyle2.FormatProvider;
			}
			else if (dataGridViewCellStyle3 != null && !dataGridViewCellStyle3.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = dataGridViewCellStyle3.FormatProvider;
			}
			else if (!rowsDefaultCellStyle.IsFormatProviderDefault && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.IsFormatProviderDefault))
			{
				dataGridViewCellStyle.FormatProvider = rowsDefaultCellStyle.FormatProvider;
			}
			else if (intRowIndex % 2 == 1 && !alternatingRowsDefaultCellStyle.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = alternatingRowsDefaultCellStyle.FormatProvider;
			}
			else if (dataGridViewCellStyle4 != null && !dataGridViewCellStyle4.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = dataGridViewCellStyle4.FormatProvider;
			}
			else
			{
				dataGridViewCellStyle.FormatProvider = defaultCellStyle.FormatProvider;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = dataGridViewCellStyle2.Alignment;
			}
			else if (dataGridViewCellStyle3 != null && dataGridViewCellStyle3.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = dataGridViewCellStyle3.Alignment;
			}
			else if (rowsDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet))
			{
				dataGridViewCellStyle.AlignmentInternal = rowsDefaultCellStyle.Alignment;
			}
			else if (intRowIndex % 2 == 1 && alternatingRowsDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = alternatingRowsDefaultCellStyle.Alignment;
			}
			else if (dataGridViewCellStyle4 != null && dataGridViewCellStyle4.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = dataGridViewCellStyle4.Alignment;
			}
			else
			{
				dataGridViewCellStyle.AlignmentInternal = defaultCellStyle.Alignment;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = dataGridViewCellStyle2.WrapMode;
			}
			else if (dataGridViewCellStyle3 != null && dataGridViewCellStyle3.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = dataGridViewCellStyle3.WrapMode;
			}
			else if (rowsDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.WrapMode == DataGridViewTriState.NotSet))
			{
				dataGridViewCellStyle.WrapModeInternal = rowsDefaultCellStyle.WrapMode;
			}
			else if (intRowIndex % 2 == 1 && alternatingRowsDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = alternatingRowsDefaultCellStyle.WrapMode;
			}
			else if (dataGridViewCellStyle4 != null && dataGridViewCellStyle4.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = dataGridViewCellStyle4.WrapMode;
			}
			else
			{
				dataGridViewCellStyle.WrapModeInternal = defaultCellStyle.WrapMode;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Tag != null)
			{
				dataGridViewCellStyle.Tag = dataGridViewCellStyle2.Tag;
			}
			else if (dataGridViewCellStyle3 != null && dataGridViewCellStyle3.Tag != null)
			{
				dataGridViewCellStyle.Tag = dataGridViewCellStyle3.Tag;
			}
			else if (rowsDefaultCellStyle.Tag != null && (intRowIndex % 2 == 0 || alternatingRowsDefaultCellStyle.Tag == null))
			{
				dataGridViewCellStyle.Tag = rowsDefaultCellStyle.Tag;
			}
			else if (intRowIndex % 2 == 1 && alternatingRowsDefaultCellStyle.Tag != null)
			{
				dataGridViewCellStyle.Tag = alternatingRowsDefaultCellStyle.Tag;
			}
			else if (dataGridViewCellStyle4 != null && dataGridViewCellStyle4.Tag != null)
			{
				dataGridViewCellStyle.Tag = dataGridViewCellStyle4.Tag;
			}
			else
			{
				dataGridViewCellStyle.Tag = defaultCellStyle.Tag;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Padding != Padding.Empty)
			{
				dataGridViewCellStyle.PaddingInternal = dataGridViewCellStyle2.Padding;
				return dataGridViewCellStyle;
			}
			if (dataGridViewCellStyle3 != null && dataGridViewCellStyle3.Padding != Padding.Empty)
			{
				dataGridViewCellStyle.PaddingInternal = dataGridViewCellStyle3.Padding;
				return dataGridViewCellStyle;
			}
			bool flag = alternatingRowsDefaultCellStyle.Padding == Padding.Empty;
			if (rowsDefaultCellStyle.Padding != Padding.Empty && (intRowIndex % 2 == 0 || flag))
			{
				dataGridViewCellStyle.PaddingInternal = rowsDefaultCellStyle.Padding;
				return dataGridViewCellStyle;
			}
			if (intRowIndex % 2 == 1 && !flag)
			{
				dataGridViewCellStyle.PaddingInternal = alternatingRowsDefaultCellStyle.Padding;
				return dataGridViewCellStyle;
			}
			if (dataGridViewCellStyle4 != null && dataGridViewCellStyle4.Padding != Padding.Empty)
			{
				dataGridViewCellStyle.PaddingInternal = dataGridViewCellStyle4.Padding;
				return dataGridViewCellStyle;
			}
			dataGridViewCellStyle.PaddingInternal = defaultCellStyle.Padding;
			return dataGridViewCellStyle;
		}

		/// Gets the size of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> representing the cell's dimensions.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <exception cref="T:System.InvalidOperationException">rowIndex is -1</exception>
		protected virtual Size GetSize(int intRowIndex)
		{
			if (base.DataGridView == null)
			{
				return new Size(-1, -1);
			}
			if (intRowIndex == -1)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedCell", "Size"));
			}
			return new Size(OwningColumn.Thickness, OwningRow.GetHeight(intRowIndex));
		}

		/// Gets the value of the cell. </summary>
		/// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
		protected virtual object GetValue(int intRowIndex)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				if (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				if (ColumnIndex < 0)
				{
					throw new InvalidOperationException();
				}
			}
			if (dataGridView == null || (dataGridView.AllowUserToAddRowsInternal && intRowIndex > -1 && intRowIndex == dataGridView.NewRowIndex && intRowIndex != dataGridView.CurrentCellAddress.Y) || (!dataGridView.VirtualMode && OwningColumn != null && !OwningColumn.IsDataBound) || intRowIndex == -1 || ColumnIndex == -1)
			{
				return mojValue;
			}
			if (OwningColumn == null || !OwningColumn.IsDataBound)
			{
				return dataGridView.OnCellValueNeeded(ColumnIndex, intRowIndex);
			}
			DataGridView.DataGridViewDataConnection dataConnection = dataGridView.DataConnection;
			if (dataConnection == null)
			{
				return null;
			}
			if (dataConnection.CurrencyManager.Count <= intRowIndex)
			{
				return mojValue;
			}
			return dataConnection.GetValue(OwningColumn.BoundColumnIndex, ColumnIndex, intRowIndex);
		}

		/// Initializes the control used to edit the cell.</summary>
		/// <param name="objInitialFormattedValue">An <see cref="T:System.Object"></see> that represents the value displayed by the cell when editing is started.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell's location.</param>
		/// <param name="objDataGridViewCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// <exception cref="T:System.InvalidOperationException">There is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> or if one is present, it does not have an associated editing control. </exception>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual void InitializeEditingControl(int intRowIndex, object objInitialFormattedValue, DataGridViewCellStyle objDataGridViewCellStyle)
		{
		}

		/// 
		/// Returns a Rectangle that represents the widths of all the cell margins.
		/// </summary>
		/// <param name="objAdvancedBorderStyle">The advanced border style.</param>
		/// </returns>
		protected virtual Rectangle BorderWidths(DataGridViewAdvancedBorderStyle objAdvancedBorderStyle)
		{
			Rectangle result = new Rectangle
			{
				X = ((objAdvancedBorderStyle.Left != DataGridViewAdvancedCellBorderStyle.None) ? 1 : 0)
			};
			if (objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.InsetDouble)
			{
				result.X++;
			}
			result.Y = ((objAdvancedBorderStyle.Top != DataGridViewAdvancedCellBorderStyle.None) ? 1 : 0);
			if (objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.InsetDouble)
			{
				result.Y++;
			}
			result.Width = ((objAdvancedBorderStyle.Right != DataGridViewAdvancedCellBorderStyle.None) ? 1 : 0);
			if (objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.InsetDouble)
			{
				result.Width++;
			}
			result.Height = ((objAdvancedBorderStyle.Bottom != DataGridViewAdvancedCellBorderStyle.None) ? 1 : 0);
			if (objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.InsetDouble)
			{
				result.Height++;
			}
			DataGridViewColumn owningColumn = OwningColumn;
			if (owningColumn != null)
			{
				if (base.DataGridView != null && base.DataGridView.RightToLeftInternal)
				{
					result.X += owningColumn.DividerWidth;
				}
				else
				{
					result.Width += owningColumn.DividerWidth;
				}
			}
			DataGridViewRow owningRow = OwningRow;
			if (owningRow != null)
			{
				result.Height += owningRow.DividerHeight;
			}
			return result;
		}

		/// 
		/// Caches the editing control.
		/// </summary>
		internal virtual void CacheEditingControl()
		{
		}

		/// 
		/// Cells the state from column row states.
		/// </summary>
		/// <param name="enmRowState">State of the row.</param>
		/// </returns>
		internal DataGridViewElementStates CellStateFromColumnRowStates(DataGridViewElementStates enmRowState)
		{
			DataGridViewElementStates dataGridViewElementStates = DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected;
			DataGridViewElementStates dataGridViewElementStates2 = DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible;
			DataGridViewColumn owningColumn = OwningColumn;
			DataGridViewElementStates dataGridViewElementStates3 = owningColumn.State & dataGridViewElementStates;
			dataGridViewElementStates3 |= enmRowState & dataGridViewElementStates;
			return dataGridViewElementStates3 | (owningColumn.State & dataGridViewElementStates2 & (enmRowState & dataGridViewElementStates2));
		}

		/// 
		/// Clicks the unshares row internal.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
		/// </returns>
		internal bool ClickUnsharesRowInternal(DataGridViewCellEventArgs e)
		{
			return ClickUnsharesRow(e);
		}

		/// 
		/// Colors the distance.
		/// </summary>
		/// <param name="objColor1">The color1.</param>
		/// <param name="objColor2">The color2.</param>
		/// </returns>
		internal static int ColorDistance(Color objColor1, Color objColor2)
		{
			int num = objColor1.R - objColor2.R;
			int num2 = objColor1.G - objColor2.G;
			int num3 = objColor1.B - objColor2.B;
			return num * num + num2 * num2 + num3 * num3;
		}

		/// 
		/// Computes the error icon bounds.
		/// </summary>
		/// <param name="objCellValueBounds">The cell value bounds.</param>
		/// </returns>
		internal Rectangle ComputeErrorIconBounds(Rectangle objCellValueBounds)
		{
			if (objCellValueBounds.Width >= 20 && objCellValueBounds.Height >= 19)
			{
				return new Rectangle(base.DataGridView.RightToLeftInternal ? (objCellValueBounds.Left + 4) : (objCellValueBounds.Right - 4 - 12), objCellValueBounds.Y + (objCellValueBounds.Height - 11) / 2, 12, 11);
			}
			return Rectangle.Empty;
		}

		/// 
		/// Contents the click unshares row internal.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
		/// </returns>
		internal bool ContentClickUnsharesRowInternal(DataGridViewCellEventArgs e)
		{
			return ContentClickUnsharesRow(e);
		}

		/// 
		/// Contents the double click unshares row internal.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
		/// </returns>
		internal bool ContentDoubleClickUnsharesRowInternal(DataGridViewCellEventArgs e)
		{
			return ContentDoubleClickUnsharesRow(e);
		}

		/// 
		/// Doubles the click unshares row internal.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
		/// </returns>
		internal bool DoubleClickUnsharesRowInternal(DataGridViewCellEventArgs e)
		{
			return DoubleClickUnsharesRow(e);
		}

		/// 
		/// Enters the unshares row internal.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnThroughMouseClick">if set to true</c> [through mouse click].</param>
		/// </returns>
		internal bool EnterUnsharesRowInternal(int intRowIndex, bool blnThroughMouseClick)
		{
			return EnterUnsharesRow(intRowIndex, blnThroughMouseClick);
		}

		/// 
		/// Returns the bounding rectangle that encloses the cell's content area using a default Graphics and cell style currently in effect for the cell.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		public Rectangle GetContentBounds(int intRowIndex)
		{
			if (base.DataGridView == null)
			{
				return Rectangle.Empty;
			}
			DataGridViewCellStyle inheritedStyle = GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			return GetContentBounds(base.DataGridView.CachedGraphics, inheritedStyle, intRowIndex);
		}

		/// 
		/// Returns the bounding rectangle that encloses the cell's content area using a default Graphics and cell style currently in effect for the cell.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objCellStyle">The cell style.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		protected virtual Rectangle GetContentBounds(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex)
		{
			return Rectangle.Empty;
		}

		/// 
		/// Returns the bounding rectangle that encloses the cell's error icon, if one is displayed.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal Rectangle GetErrorIconBounds(int intRowIndex)
		{
			DataGridViewCellStyle inheritedStyle = GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			return GetErrorIconBounds(base.DataGridView.CachedGraphics, inheritedStyle, intRowIndex);
		}

		/// 
		/// Returns the bounding rectangle that encloses the cell's error icon, if one is displayed.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objCellStyle">The cell style.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		protected virtual Rectangle GetErrorIconBounds(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex)
		{
			return Rectangle.Empty;
		}

		internal static DataGridViewFreeDimension GetFreeDimensionFromConstraint(Size objConstraintSize)
		{
			if (objConstraintSize.Width < 0 || objConstraintSize.Height < 0)
			{
				throw new ArgumentException(SR.GetString("InvalidArgument", "constraintSize", objConstraintSize.ToString()));
			}
			if (objConstraintSize.Width == 0)
			{
				if (objConstraintSize.Height == 0)
				{
					return DataGridViewFreeDimension.Both;
				}
				return DataGridViewFreeDimension.Width;
			}
			if (objConstraintSize.Height != 0)
			{
				throw new ArgumentException(SR.GetString("InvalidArgument", "constraintSize", objConstraintSize.ToString()));
			}
			return DataGridViewFreeDimension.Height;
		}

		internal int GetHeight(int intRowIndex)
		{
			if (base.DataGridView == null)
			{
				return -1;
			}
			return OwningRow.GetHeight(intRowIndex);
		}

		/// 
		/// Leaves the unshares row internal.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnThroughMouseClick">if set to true</c> [through mouse click].</param>
		/// </returns>
		internal bool LeaveUnsharesRowInternal(int intRowIndex, bool blnThroughMouseClick)
		{
			return LeaveUnsharesRow(intRowIndex, blnThroughMouseClick);
		}

		/// 
		/// Converts a value formatted for display to an actual cell value.
		/// </summary>
		/// <param name="objFormattedValue">The formatted value.</param>
		/// <param name="objCellStyle">The cell style.</param>
		/// <param name="objFormattedValueTypeConverter">The formatted value type converter.</param>
		/// <param name="objValueTypeConverter">The value type converter.</param>
		/// </returns>
		public virtual object ParseFormattedValue(object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
		{
			return ParseFormattedValueInternal(ValueType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
		}

		internal object ParseFormattedValueInternal(Type objValueType, object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
		{
			if (objCellStyle == null)
			{
				throw new ArgumentNullException("cellStyle");
			}
			if (FormattedValueType == null)
			{
				throw new FormatException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
			}
			if (objValueType == null)
			{
				throw new FormatException(SR.GetString("DataGridViewCell_ValueTypeNull"));
			}
			if (objFormattedValue == null || !FormattedValueType.IsAssignableFrom(objFormattedValue.GetType()))
			{
				throw new ArgumentException(SR.GetString("DataGridViewCell_FormattedValueHasWrongType"), "formattedValue");
			}
			return ClientUtils.ParseObject(objFormattedValue, objValueType, FormattedValueType, (objValueTypeConverter == null) ? ValueTypeConverter : objValueTypeConverter, (objFormattedValueTypeConverter == null) ? FormattedValueTypeConverter : objFormattedValueTypeConverter, objCellStyle.FormatProvider, objCellStyle.NullValue, objCellStyle.IsDataSourceNullValueDefault ? ClientUtils.GetDefaultDataSourceNullValue(objValueType) : objCellStyle.DataSourceNullValue);
		}

		/// Sets the location and size of the editing control hosted by a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
		/// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell being edited.</param>
		/// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false.</param>
		/// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false.</param>
		/// <param name="blnSetSize">true to specify the size; false to allow the control to size itself. </param>
		/// <param name="blnSetLocation">true to have the control placed as specified by the other arguments; false to allow the control to place itself.</param>
		/// <param name="objCellClip">The area that will be used to paint the editing control.</param>
		/// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false.</param>
		/// <param name="objCellBounds">A <see cref="T:System.Drawing.Rectangle"></see> that defines the cell bounds. </param>
		/// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false.</param>
		/// <exception cref="T:System.InvalidOperationException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual void PositionEditingControl(bool blnSetLocation, bool blnSetSize, Rectangle objCellBounds, Rectangle objCellClip, DataGridViewCellStyle objCellStyle, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
		{
			Rectangle rectangle = PositionEditingPanel(objCellBounds, objCellClip, objCellStyle, blnSingleVerticalBorderAdded, blnSingleHorizontalBorderAdded, blnIsFirstDisplayedColumn, blnIsFirstDisplayedRow);
			if (blnSetLocation)
			{
				base.DataGridView.EditingControl.Location = new Point(rectangle.X, rectangle.Y);
			}
			if (blnSetSize)
			{
				base.DataGridView.EditingControl.Size = new Size(rectangle.Width, rectangle.Height);
			}
		}

		/// Sets the value of the cell. </summary>
		/// true if the value has been set; otherwise, false.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <param name="objValue">The cell value to set. </param>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		protected virtual bool SetValue(int intRowIndex, object objValue)
		{
			return SetValue(intRowIndex, objValue, blnClientSource: false);
		}

		/// Sets the value of the cell. </summary>
		/// true if the value has been set; otherwise, false.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <param name="objValue">The cell value to set. </param>
		/// <param name="blnClientSource">Client source. </param>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		private bool SetValue(int intRowIndex, object objValue, bool blnClientSource)
		{
			object obj = null;
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null && !dataGridView.InSortOperation)
			{
				obj = GetValue(intRowIndex);
			}
			if (dataGridView != null && OwningColumn != null && OwningColumn.IsDataBound)
			{
				DataGridView.DataGridViewDataConnection dataConnection = dataGridView.DataConnection;
				if (dataConnection == null)
				{
					return false;
				}
				if (dataConnection.CurrencyManager.Count <= intRowIndex)
				{
					if (objValue != null || mojValue != null)
					{
						mojValue = objValue;
					}
				}
				else
				{
					if (!dataConnection.PushValue(OwningColumn.BoundColumnIndex, ColumnIndex, intRowIndex, objValue))
					{
						return false;
					}
					if (base.DataGridView == null || OwningRow == null || OwningRow.DataGridView == null)
					{
						return true;
					}
					if (OwningRow.Index == base.DataGridView.CurrentCellAddress.Y)
					{
						base.DataGridView.SetIsCurrentRowDirtyInternal(blnDirty: true, blnClientSource);
					}
				}
			}
			else if (dataGridView == null || !dataGridView.VirtualMode || intRowIndex == -1 || ColumnIndex == -1)
			{
				if (objValue != null || mojValue != null)
				{
					mojValue = objValue;
				}
			}
			else
			{
				dataGridView.OnCellValuePushed(ColumnIndex, intRowIndex, objValue);
			}
			if (dataGridView != null && !dataGridView.InSortOperation && ((obj == null && objValue != null) || (obj != null && objValue == null) || (obj != null && !objValue.Equals(obj))))
			{
				RaiseCellValueChanged(new DataGridViewCellEventArgs(ColumnIndex, intRowIndex), blnClientSource);
			}
			return true;
		}

		/// 
		/// Sets the value internal.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objValue">The value.</param>
		/// </returns>
		internal bool SetValueInternal(int intRowIndex, object objValue)
		{
			return SetValueInternal(intRowIndex, objValue, blnClientSource: false);
		}

		/// 
		/// Sets the value internal.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objValue">The value.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// </returns>
		internal bool SetValueInternal(int intRowIndex, object objValue, bool blnClientSource)
		{
			return SetValue(intRowIndex, objValue, blnClientSource);
		}

		/// Returns a string that describes the current object. </summary>
		/// A string that represents the current object.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			return "DataGridViewCell { ColumnIndex=" + ColumnIndex + ", RowIndex=" + RowIndex + " }";
		}

		/// 
		/// Clones the internal.
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		protected void CloneInternal(DataGridViewCell objDataGridViewCell)
		{
			if (HasValueType)
			{
				objDataGridViewCell.ValueType = ValueType;
			}
			if (HasStyle)
			{
				objDataGridViewCell.Style = new DataGridViewCellStyle(Style);
			}
			if (HasErrorText)
			{
				objDataGridViewCell.ErrorText = ErrorTextInternal;
			}
			objDataGridViewCell.StateInternal = State & ~DataGridViewElementStates.Selected;
			objDataGridViewCell.Tag = Tag;
			objDataGridViewCell.LastModified = LastModified;
			objDataGridViewCell.LastModifiedParams = LastModifiedParams;
			objDataGridViewCell.LastModifiedParamsType = LastModifiedParamsType;
		}

		/// 
		/// Formats the plain text as HTML.
		/// </summary>
		/// <param name="str">The s.</param>
		/// <param name="objOutput">The output.</param>
		internal static void FormatPlainTextAsHtml(string str, TextWriter objOutput)
		{
			if (str == null)
			{
				return;
			}
			int length = str.Length;
			char c = '\0';
			for (int i = 0; i < length; i++)
			{
				char c2 = str[i];
				switch (c2)
				{
				case '\n':
					objOutput.Write("");
					break;
				case ' ':
					if (c == ' ')
					{
						objOutput.Write("&nbsp;");
					}
					else
					{
						objOutput.Write(c2);
					}
					break;
				case '"':
					objOutput.Write("&quot;");
					break;
				case '&':
					objOutput.Write("&amp;");
					break;
				case '<':
					objOutput.Write("&lt;");
					break;
				case '>':
					objOutput.Write("&gt;");
					break;
				default:
					if (c2 >= '\u00a0' && c2 < 'Ā')
					{
						objOutput.Write("&#");
						int num = c2;
						objOutput.Write(num.ToString(NumberFormatInfo.InvariantInfo));
						objOutput.Write(';');
					}
					else
					{
						objOutput.Write(c2);
					}
					break;
				case '\r':
					break;
				}
				c = c2;
			}
		}

		/// 
		/// Formats the plain text.
		/// </summary>
		/// <param name="str">The s.</param>
		/// <param name="blnCsv">if set to true</c> [CSV].</param>
		/// <param name="objOutput">The output.</param>
		/// <param name="blnEscapeApplied">if set to true</c> [escape applied].</param>
		internal static void FormatPlainText(string str, bool blnCsv, TextWriter objOutput, ref bool blnEscapeApplied)
		{
			if (str == null)
			{
				return;
			}
			int length = str.Length;
			for (int i = 0; i < length; i++)
			{
				char c = str[i];
				switch (c)
				{
				case '\t':
					if (!blnCsv)
					{
						objOutput.Write(' ');
					}
					else
					{
						objOutput.Write('\t');
					}
					break;
				case '"':
					if (blnCsv)
					{
						objOutput.Write("\"\"");
						blnEscapeApplied = true;
					}
					else
					{
						objOutput.Write('"');
					}
					break;
				case ',':
					if (blnCsv)
					{
						blnEscapeApplied = true;
					}
					objOutput.Write(',');
					break;
				default:
					objOutput.Write(c);
					break;
				}
			}
			if (blnEscapeApplied)
			{
				objOutput.Write('"');
			}
		}

		private static Bitmap GetBitmap(string strBitmapName)
		{
			Bitmap bitmap = new Bitmap(typeof(DataGridViewCell), strBitmapName);
			bitmap.MakeTransparent();
			return bitmap;
		}

		internal object GetValueInternal(int intRowIndex)
		{
			return GetValue(intRowIndex);
		}

		internal int GetPreferredWidth(int intRowIndex, int intHeight)
		{
			if (base.DataGridView == null)
			{
				return -1;
			}
			DataGridViewCellStyle inheritedStyle = GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			return GetPreferredSize(base.DataGridView.CachedGraphics, inheritedStyle, intRowIndex, new Size(0, intHeight)).Width;
		}

		internal DataGridViewCellStyle GetInheritedStyleInternal(int intRowIndex)
		{
			return GetInheritedStyle(null, intRowIndex, blnIncludeColors: true);
		}

		/// Returns a string that represents the error for the cell.</summary>
		/// A string that describes the error for the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
		/// <param name="intRowIndex">The row index of the cell.</param>
		protected internal virtual string GetErrorText(int intRowIndex)
		{
			string text = string.Empty;
			object obj = mobjErrorText;
			if (obj != null)
			{
				text = (string)obj;
			}
			else if (base.DataGridView != null && intRowIndex != -1 && intRowIndex != base.DataGridView.NewRowIndex && OwningColumn != null && OwningColumn.IsDataBound && base.DataGridView.DataConnection != null)
			{
				text = base.DataGridView.DataConnection.GetError(OwningColumn.BoundColumnIndex, ColumnIndex, intRowIndex);
			}
			if (base.DataGridView != null && (base.DataGridView.VirtualMode || base.DataGridView.DataSource != null) && ColumnIndex >= 0 && intRowIndex >= 0)
			{
				text = base.DataGridView.OnCellErrorTextNeeded(ColumnIndex, intRowIndex, text);
			}
			return text;
		}

		/// Calculates the preferred size with constraints, in pixels, of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
		/// <param name="strText">The text to be measured.</param>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		protected virtual Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle, Size objConstraintSize)
		{
			Font objFont = null;
			int num = 3;
			int num2 = 4;
			bool flag = false;
			if (objCellStyle != null)
			{
				Padding padding = objCellStyle.Padding;
				bool flag2 = true;
				num += padding.Horizontal;
				num2 += padding.Vertical;
				objFont = objCellStyle.Font;
				flag = HasWrapMode(objCellStyle);
			}
			Size empty = Size.Empty;
			int num3 = -1;
			if (objConstraintSize.Width > 0)
			{
				num3 = objConstraintSize.Width;
			}
			else if (OwningColumn != null)
			{
				num3 = OwningColumn.Thickness;
			}
			if (flag)
			{
				return new Size(num3, CommonUtils.GetStringMeasurements(strText, objFont, num3 - num).Height + num2);
			}
			empty = CommonUtils.GetStringMeasurements(strText, objFont, blnIgnoreNewLines: true);
			return new Size(empty.Width + num, empty.Height + num2);
		}

		/// Calculates the preferred size, in pixels, of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
		/// <param name="strText">The text to be measured.</param>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		protected virtual Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
		{
			Size empty = Size.Empty;
			int width = -1;
			if (OwningColumn != null)
			{
				width = OwningColumn.Thickness;
			}
			empty.Width = width;
			return GetPreferredSize(strText, objCellStyle, empty);
		}

		/// 
		/// Determines whether [has wrap mode] [the specified obj cell style].
		/// </summary>
		/// <param name="objCellStyle">The obj cell style.</param>
		/// 
		///   true</c> if [has wrap mode] [the specified obj cell style]; otherwise, false</c>.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool HasWrapMode(DataGridViewCellStyle objCellStyle)
		{
			return objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True;
		}

		/// Calculates the preferred size, in pixels, of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
		/// <param name="objConstraintSize">The cell's maximum allowable size.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell.</param>
		protected virtual Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
		{
			string strText = GetFormattedValue(intRowIndex, ref objCellStyle, DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize) as string;
			return GetPreferredSize(strText, objCellStyle, objConstraintSize);
		}

		internal Size GetPreferredSize(int intRowIndex)
		{
			if (base.DataGridView == null)
			{
				return new Size(-1, -1);
			}
			DataGridViewCellStyle inheritedStyle = GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			return GetPreferredSize(base.DataGridView.CachedGraphics, inheritedStyle, intRowIndex, Size.Empty);
		}

		internal int GetPreferredHeight(int intRowIndex, int intWidth)
		{
			if (base.DataGridView == null)
			{
				return -1;
			}
			DataGridViewCellStyle inheritedStyle = GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			return GetPreferredSize(base.DataGridView.CachedGraphics, inheritedStyle, intRowIndex, new Size(intWidth, 0)).Height;
		}
	}
}

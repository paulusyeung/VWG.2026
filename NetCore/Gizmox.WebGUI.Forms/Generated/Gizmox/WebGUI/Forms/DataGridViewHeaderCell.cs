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
	/// Contains functionality common to row header cells and column header cells.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class DataGridViewHeaderCell : DataGridViewCell
	{
		protected static Type cellType;

		protected static Type defaultFormattedValueType;

		protected static Type defaultValueType;

		protected static readonly int PropButtonState;

		protected static readonly int PropFlipXPThemesBitmap;

		protected static readonly int PropValueType;

		protected static Rectangle rectThemeMargins;

		protected const byte DATAGRIDVIEWHEADERCELL_themeMargin = 100;

		protected const string HeaderTypeName = "7";

		private object mobjLocalValue;

		/// 
		/// Gets a value indicating whether [contains local value].
		/// </summary>
		/// true</c> if [contains local value]; otherwise, false</c>.</value>
		internal bool ContainsLocalValue
		{
			get
			{
				string text = Convert.ToString(LocalValue);
				return text != null && text != "";
			}
		}

		/// 
		/// Gets or sets the local value.
		/// </summary>
		/// The local value.</value>
		protected object LocalValue
		{
			get
			{
				return mobjLocalValue;
			}
			set
			{
				mobjLocalValue = value;
			}
		}

		/// Gets the buttonlike visual state of the header cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ButtonState"></see> values; the default is <see cref="F:Gizmox.WebGUI.Forms.ButtonState.Normal"></see>.</returns>
		protected ButtonState ButtonState => ButtonState.Normal;

		/// 
		/// </summary>
		/// </value>
		internal override string TypeName => "7";

		/// 
		/// Gets a value that indicates whether the cell is currently displayed on-screen.
		/// </summary>
		/// </value>
		/// true if the cell is on-screen or partially on-screen; otherwise, false.</returns>
		[Browsable(false)]
		public override bool Displayed
		{
			get
			{
				if (base.DataGridView != null && base.DataGridView.Visible)
				{
					if (base.OwningRow != null)
					{
						if (base.DataGridView.RowHeadersVisible)
						{
							return base.OwningRow.Displayed;
						}
						return false;
					}
					if (base.DataGridView.ColumnHeadersVisible)
					{
						return base.OwningColumn.Displayed;
					}
				}
				return false;
			}
		}

		/// Gets the type of the formatted value of the cell.</summary>
		/// A <see cref="T:System.Type"></see> object representing the <see cref="T:System.String"></see> type.</returns>
		public override Type FormattedValueType => defaultFormattedValueType;

		/// Gets a value indicating whether the cell is frozen. </summary>
		/// true if the cell is frozen; otherwise, false. The default is false if the cell is detached from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public override bool Frozen
		{
			get
			{
				if (base.OwningRow != null)
				{
					return base.OwningRow.Frozen;
				}
				if (base.OwningColumn != null)
				{
					return base.OwningColumn.Frozen;
				}
				if (base.DataGridView != null)
				{
					return true;
				}
				return false;
			}
		}

		/// Gets a value indicating whether the header cell is read-only.</summary>
		/// true in all cases.</returns>
		/// <exception cref="T:System.InvalidOperationException">An operation tries to set this property.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override bool ReadOnly
		{
			get
			{
				return true;
			}
			set
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", "ReadOnly"));
			}
		}

		/// Gets a value indicating whether the cell is resizable.</summary>
		/// true if this cell can be resized; otherwise, false. The default is false if the cell is not attached to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public override bool Resizable
		{
			get
			{
				if (base.OwningRow != null)
				{
					if (base.OwningRow.Resizable == DataGridViewTriState.True)
					{
						return true;
					}
					if (base.DataGridView != null)
					{
						return base.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing;
					}
					return false;
				}
				if (base.OwningColumn != null)
				{
					if (base.OwningColumn.Resizable == DataGridViewTriState.True)
					{
						return true;
					}
					if (base.DataGridView != null)
					{
						return base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
					}
					return false;
				}
				if (base.DataGridView == null)
				{
					return false;
				}
				if (base.DataGridView.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing)
				{
					return base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
				}
				return true;
			}
		}

		/// Gets or sets a value indicating whether the cell is selected.</summary>
		/// false in all cases.</returns>
		/// <exception cref="T:System.InvalidOperationException">This property is being set.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override bool Selected
		{
			get
			{
				return false;
			}
			set
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", "Selected"));
			}
		}

		/// Gets the type of the value stored in the cell.</summary>
		/// A <see cref="T:System.Type"></see> object representing the <see cref="T:System.String"></see> type.</returns>
		/// 1</filterpriority>
		public override Type ValueType
		{
			get
			{
				return defaultValueType;
			}
			set
			{
			}
		}

		/// 
		///
		/// </summary>
		protected override string MemberID => "HC" + (base.DataGridView.ColumnCount * base.RowIndex + base.ColumnIndex);

		/// Gets a value indicating whether or not the cell is visible.</summary>
		/// true if the cell is visible; otherwise, false. The default is false if the cell is detached from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see></returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public override bool Visible
		{
			get
			{
				if (base.OwningRow != null)
				{
					if (!base.OwningRow.Visible)
					{
						return false;
					}
					if (base.DataGridView != null)
					{
						return base.DataGridView.RowHeadersVisible;
					}
					return true;
				}
				if (base.OwningColumn != null)
				{
					if (!base.OwningColumn.Visible)
					{
						return false;
					}
					if (base.DataGridView != null)
					{
						return base.DataGridView.ColumnHeadersVisible;
					}
					return true;
				}
				if (base.DataGridView != null && base.DataGridView.RowHeadersVisible)
				{
					return base.DataGridView.ColumnHeadersVisible;
				}
				return false;
			}
		}

		static DataGridViewHeaderCell()
		{
			defaultFormattedValueType = typeof(string);
			defaultValueType = typeof(object);
			cellType = typeof(DataGridViewHeaderCell);
			rectThemeMargins = new Rectangle(-1, -1, 0, 0);
		}

		/// 
		/// Renders the wrap mode attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
		protected override void RenderWrapModeAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
		{
			if (objInheritedCellStyle.WrapMode != DataGridViewTriState.True)
			{
				objWriter.WriteAttributeString("WC", "0");
			}
		}

		/// 
		/// Renders the read only attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderReadOnlyAttribute(IAttributeWriter objWriter)
		{
		}

		/// 
		/// Renders the back-color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
		protected override void RenderBackColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
		{
			if (objInheritedCellStyle.BackColor != base.DataGridView.DefaultColumnHeadersDefaultCellStyleInternal.BackColor)
			{
				objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(objInheritedCellStyle.BackColor));
			}
		}

		/// 
		/// Renders the fore color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
		protected override void RenderForeColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
		{
			if (objInheritedCellStyle.ForeColor != base.DataGridView.DefaultColumnHeadersDefaultCellStyleInternal.ForeColor)
			{
				objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(objInheritedCellStyle.ForeColor));
			}
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
			if (objFormatedValue != null)
			{
				objWriter.WriteAttributeText("VLB", objFormatedValue.ToString());
			}
		}

		/// Gets the shortcut menu of the header cell.</summary>
		/// A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> if the <see cref="T:System.Windows.Forms.DataGridViewHeaderCell"></see> or <see cref="T:System.Windows.Forms.DataGridView"></see> has a shortcut menu assigned; otherwise, null.</returns>
		/// <param name="intRowIndex">Ignored by this implementation.</param>
		public override ContextMenu GetInheritedContextMenu(int intRowIndex)
		{
			ContextMenu contextMenu = GetContextMenu(intRowIndex);
			if (contextMenu != null)
			{
				return contextMenu;
			}
			if (base.DataGridView != null)
			{
				return base.DataGridView.ContextMenu;
			}
			return null;
		}

		/// 
		/// Gets the inherited context menu strip.
		/// </summary>
		/// <param name="intRowIndex">Index of the int row.</param>
		/// </returns>
		public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
		{
			ContextMenuStrip contextMenuStrip = GetContextMenuStrip(intRowIndex);
			if (contextMenuStrip != null)
			{
				return contextMenuStrip;
			}
			if (base.DataGridView != null)
			{
				return base.DataGridView.ContextMenuStrip;
			}
			return null;
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.</returns>
		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewHeaderCell dataGridViewHeaderCell = ((!(type == cellType)) ? ((DataGridViewHeaderCell)Activator.CreateInstance(type)) : new DataGridViewHeaderCell());
			CloneInternal(dataGridViewHeaderCell);
			dataGridViewHeaderCell.Value = base.Value;
			return dataGridViewHeaderCell;
		}

		/// Returns a value indicating the current state of the cell as inherited from the state of its row or column.</summary>
		/// A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
		/// <param name="intRowIndex">The index of the row containing the cell or -1 if the cell is not a row header cell or is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</param>
		/// <exception cref="T:System.ArgumentException">The cell is a row header cell, the cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, and rowIndex is not -1.- or -The cell is a row header cell, the cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, and rowIndex is outside the valid range of 0 to the number of rows in the control minus 1.- or -The cell is a row header cell and rowIndex is not the index of the row containing this cell.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The cell is a column header cell or the control's <see cref="P:Gizmox.WebGUI.Forms.DataGridView.TopLeftHeaderCell"></see>  and rowIndex is not -1.</exception>
		public override DataGridViewElementStates GetInheritedState(int intRowIndex)
		{
			DataGridViewElementStates dataGridViewElementStates = DataGridViewElementStates.ReadOnly | DataGridViewElementStates.ResizableSet;
			if (base.OwningRow != null)
			{
				if ((base.DataGridView == null && intRowIndex != -1) || (base.DataGridView != null && (intRowIndex < 0 || intRowIndex >= base.DataGridView.Rows.Count)))
				{
					throw new ArgumentException(SR.GetString("InvalidArgument", "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture)));
				}
				if (base.DataGridView != null && base.DataGridView.Rows.SharedRow(intRowIndex) != base.OwningRow)
				{
					throw new ArgumentException(SR.GetString("InvalidArgument", "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture)));
				}
				dataGridViewElementStates |= base.OwningRow.GetState(intRowIndex) & DataGridViewElementStates.Frozen;
				if (base.OwningRow.GetResizable(intRowIndex) == DataGridViewTriState.True || (base.DataGridView != null && base.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing))
				{
					dataGridViewElementStates |= DataGridViewElementStates.Resizable;
				}
				if (base.OwningRow.GetVisible(intRowIndex) && (base.DataGridView == null || base.DataGridView.RowHeadersVisible))
				{
					dataGridViewElementStates |= DataGridViewElementStates.Visible;
					if (base.OwningRow.GetDisplayed(intRowIndex))
					{
						dataGridViewElementStates |= DataGridViewElementStates.Displayed;
					}
				}
				return dataGridViewElementStates;
			}
			if (base.OwningColumn != null)
			{
				if (intRowIndex != -1)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				dataGridViewElementStates |= base.OwningColumn.State & DataGridViewElementStates.Frozen;
				if (base.OwningColumn.Resizable == DataGridViewTriState.True || (base.DataGridView != null && base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing))
				{
					dataGridViewElementStates |= DataGridViewElementStates.Resizable;
				}
				if (base.OwningColumn.Visible && (base.DataGridView == null || base.DataGridView.ColumnHeadersVisible))
				{
					dataGridViewElementStates |= DataGridViewElementStates.Visible;
					if (base.OwningColumn.Displayed)
					{
						dataGridViewElementStates |= DataGridViewElementStates.Displayed;
					}
				}
				return dataGridViewElementStates;
			}
			if (base.DataGridView != null)
			{
				if (intRowIndex != -1)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				dataGridViewElementStates |= DataGridViewElementStates.Frozen;
				if (base.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing || base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing)
				{
					dataGridViewElementStates |= DataGridViewElementStates.Resizable;
				}
			}
			return dataGridViewElementStates;
		}

		/// Gets the size of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the size of the header cell.</returns>
		/// <param name="intRowIndex">The row index of the header cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property for this cell is null and rowIndex does not equal -1. -or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> property for this cell is not null and rowIndex does not equal -1. -or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> property for this cell is not null and rowIndex is less than zero or greater than or equal to the number of rows in the control.-or-The values of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> properties of this cell are both null and rowIndex does not equal -1.</exception>
		/// <exception cref="T:System.ArgumentException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> property for this cell is not null and rowIndex indicates a row other than the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see>.</exception>
		protected override Size GetSize(int intRowIndex)
		{
			if (base.DataGridView == null)
			{
				if (intRowIndex != -1)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				return new Size(-1, -1);
			}
			if (base.OwningRow != null)
			{
				if (intRowIndex < 0 || intRowIndex >= base.DataGridView.Rows.Count)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				if (base.DataGridView.Rows.SharedRow(intRowIndex) != base.OwningRow)
				{
					throw new ArgumentException(SR.GetString("InvalidArgument", "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture)));
				}
				return new Size(base.DataGridView.RowHeadersWidth, base.OwningRow.GetHeight(intRowIndex));
			}
			if (intRowIndex != -1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			return new Size(base.DataGridView.RowHeadersWidth, base.DataGridView.ColumnHeadersHeight);
		}

		/// Gets the value of the cell. </summary>
		/// The value of the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
		protected override object GetValue(int intRowIndex)
		{
			return null;
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			return "DataGridViewHeaderCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
		}

		private void UpdateButtonState(ButtonState newButtonState, int intRowIndex)
		{
			base.DataGridView.InvalidateCell(base.ColumnIndex, intRowIndex);
		}
	}
}

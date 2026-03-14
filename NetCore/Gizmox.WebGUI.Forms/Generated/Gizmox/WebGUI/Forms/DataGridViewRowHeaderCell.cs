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
	/// Represents a row header of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
	/// </summary>
	[Serializable]
	public class DataGridViewRowHeaderCell : DataGridViewHeaderCell
	{
		private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginHeight = 3;

		private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginWidth = 3;

		private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginLeft = 1;

		private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginRight = 2;

		private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginHeight = 2;

		private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginWidth = 3;

		private const byte DATAGRIDVIEWROWHEADERCELL_iconsHeight = 11;

		private const byte DATAGRIDVIEWROWHEADERCELL_iconsWidth = 12;

		private const byte DATAGRIDVIEWROWHEADERCELL_verticalTextMargin = 1;

		/// 
		/// Gets the left arrow bitmap.
		/// </summary>
		/// The left arrow bitmap.</value>
		private static Bitmap LeftArrowBitmap => null;

		/// 
		/// Gets the left arrow star bitmap.
		/// </summary>
		/// The left arrow star bitmap.</value>
		private static Bitmap LeftArrowStarBitmap => null;

		/// 
		/// Gets the pencil LTR bitmap.
		/// </summary>
		/// The pencil LTR bitmap.</value>
		private static Bitmap PencilLTRBitmap => null;

		/// 
		/// Gets the pencil RTL bitmap.
		/// </summary>
		/// The pencil RTL bitmap.</value>
		private static Bitmap PencilRTLBitmap => null;

		/// 
		/// Gets the right arrow bitmap.
		/// </summary>
		/// The right arrow bitmap.</value>
		private static Bitmap RightArrowBitmap => null;

		/// 
		/// Gets the right arrow star bitmap.
		/// </summary>
		/// The right arrow star bitmap.</value>
		private static Bitmap RightArrowStarBitmap => null;

		/// 
		/// Gets the star bitmap.
		/// </summary>
		/// The star bitmap.</value>
		private static Bitmap StarBitmap => null;

		/// 
		/// Renders the Row header cell member ID
		/// </summary>
		protected override string MemberID => "RHC" + base.RowIndex;

		/// 
		/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell" /> class.
		/// </summary>
		static DataGridViewRowHeaderCell()
		{
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (!(type == "Click"))
			{
				if (type == "DoubleClick" && base.DataGridView != null)
				{
					int eventValue = GetEventValue(objEvent, "X", 0);
					int eventValue2 = GetEventValue(objEvent, "Y", 0);
					DataGridViewCellMouseEventArgs e = new DataGridViewCellMouseEventArgs(-1, base.RowIndex, eventValue, eventValue2, new MouseEventArgs(MouseButtons.Left, 1, eventValue, eventValue2, 0));
					base.DataGridView.OnRowHeaderMouseDoubleClickInternal(e);
				}
			}
			else if (base.DataGridView != null)
			{
				int eventValue3 = GetEventValue(objEvent, "X", 0);
				int eventValue4 = GetEventValue(objEvent, "Y", 0);
				base.DataGridView.FireRowHeaderMouseClick(new DataGridViewCellMouseEventArgs(base.ColumnIndex, base.RowIndex, 0, 0, new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue3, eventValue4, 0)));
				if (base.DataGridView != null)
				{
					base.DataGridView.Update();
				}
			}
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
				if (base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK))
				{
					criticalEventsData.Set("CL");
					criticalEventsData.Set("RC");
				}
				if (base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK))
				{
					criticalEventsData.Set("DCL");
				}
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the shortcut menu of the header cell.
		/// </summary>
		/// <param name="intRowIndex">Ignored by this implementation.</param>
		/// 
		/// A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> if the <see cref="T:System.Windows.Forms.DataGridViewHeaderCell"></see> or <see cref="T:System.Windows.Forms.DataGridView"></see> has a shortcut menu assigned; otherwise, null.
		/// </returns>
		public override ContextMenu GetInheritedContextMenu(int intRowIndex)
		{
			if (base.DataGridView != null && (intRowIndex < 0 || intRowIndex >= base.DataGridView.Rows.Count))
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
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
		/// Calculates the preferred size, in pixels, of the cell.
		/// </summary>
		/// <param name="strText">The text to be measured.</param>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// 
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
		/// </returns>
		protected override Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
		{
			Size preferredSize = base.GetPreferredSize(strText, objCellStyle);
			DataGridViewRow owningRow = base.OwningRow;
			if (owningRow != null)
			{
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView != null && dataGridView.Skin is DataGridViewSkin dataGridViewSkin)
				{
					string arg = (dataGridView.Context.RightToLeft ? "RTL" : "LTR");
					Size imageSize = dataGridViewSkin.GetImageSize($"DGVEditedMode{arg}.gif");
					Size imageSize2 = dataGridViewSkin.GetImageSize($"Arrow{arg}.gif");
					preferredSize.Height = Math.Max(preferredSize.Height, Math.Max(imageSize2.Height, imageSize.Height));
					if (owningRow.IsNewRow)
					{
						Size imageSize3 = dataGridViewSkin.GetImageSize("DGVNewRowMode.gif");
						preferredSize.Height = Math.Max(preferredSize.Height, imageSize3.Height);
					}
				}
			}
			return preferredSize;
		}

		/// 
		/// Gets the inherited context menu strip.
		/// </summary>
		/// <param name="intRowIndex">Index of the int row.</param>
		/// </returns>
		public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
		{
			if (base.DataGridView != null && (intRowIndex < 0 || intRowIndex >= base.DataGridView.Rows.Count))
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
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

		/// 
		/// Creates an exact copy of this cell.
		/// </summary>
		/// 
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.
		/// </returns>
		public override object Clone()
		{
			return null;
		}

		/// Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
		/// A <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
		/// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="strFormat">The current format string of the cell.</param>
		/// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than or equal to the number of rows in the control.</exception>
		protected override object GetClipboardContent(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
		{
			return null;
		}

		/// 
		/// Gets the style applied to the cell.
		/// </summary>
		/// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style.</param>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false.</param>
		/// 
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0, or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">The cell has no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
		public override DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle objInheritedCellStyle, int intRowIndex, bool blnIncludeColors)
		{
			DataGridViewCellStyle dataGridViewCellStyle = ((objInheritedCellStyle == null) ? new DataGridViewCellStyle() : objInheritedCellStyle);
			DataGridViewCellStyle dataGridViewCellStyle2 = null;
			if (base.HasStyle)
			{
				dataGridViewCellStyle2 = base.Style;
			}
			DataGridViewCellStyle rowHeadersDefaultCellStyle = base.DataGridView.RowHeadersDefaultCellStyle;
			DataGridViewCellStyle defaultCellStyle = base.DataGridView.DefaultCellStyle;
			if (blnIncludeColors)
			{
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = dataGridViewCellStyle2.BackColor;
				}
				else if (!rowHeadersDefaultCellStyle.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = rowHeadersDefaultCellStyle.BackColor;
				}
				else
				{
					dataGridViewCellStyle.BackColor = defaultCellStyle.BackColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = dataGridViewCellStyle2.ForeColor;
				}
				else if (!rowHeadersDefaultCellStyle.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = rowHeadersDefaultCellStyle.ForeColor;
				}
				else
				{
					dataGridViewCellStyle.ForeColor = defaultCellStyle.ForeColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = dataGridViewCellStyle2.SelectionBackColor;
				}
				else if (!rowHeadersDefaultCellStyle.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = rowHeadersDefaultCellStyle.SelectionBackColor;
				}
				else
				{
					dataGridViewCellStyle.SelectionBackColor = defaultCellStyle.SelectionBackColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = dataGridViewCellStyle2.SelectionForeColor;
				}
				else if (!rowHeadersDefaultCellStyle.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = rowHeadersDefaultCellStyle.SelectionForeColor;
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
			else if (rowHeadersDefaultCellStyle.Font != null)
			{
				dataGridViewCellStyle.Font = rowHeadersDefaultCellStyle.Font;
			}
			else
			{
				dataGridViewCellStyle.Font = defaultCellStyle.Font;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = dataGridViewCellStyle2.NullValue;
			}
			else if (!rowHeadersDefaultCellStyle.IsNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = rowHeadersDefaultCellStyle.NullValue;
			}
			else
			{
				dataGridViewCellStyle.NullValue = defaultCellStyle.NullValue;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = dataGridViewCellStyle2.DataSourceNullValue;
			}
			else if (!rowHeadersDefaultCellStyle.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = rowHeadersDefaultCellStyle.DataSourceNullValue;
			}
			else
			{
				dataGridViewCellStyle.DataSourceNullValue = defaultCellStyle.DataSourceNullValue;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = dataGridViewCellStyle2.Format;
			}
			else if (rowHeadersDefaultCellStyle.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = rowHeadersDefaultCellStyle.Format;
			}
			else
			{
				dataGridViewCellStyle.Format = defaultCellStyle.Format;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = dataGridViewCellStyle2.FormatProvider;
			}
			else if (!rowHeadersDefaultCellStyle.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = rowHeadersDefaultCellStyle.FormatProvider;
			}
			else
			{
				dataGridViewCellStyle.FormatProvider = defaultCellStyle.FormatProvider;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = dataGridViewCellStyle2.Alignment;
			}
			else if (rowHeadersDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = rowHeadersDefaultCellStyle.Alignment;
			}
			else
			{
				dataGridViewCellStyle.AlignmentInternal = defaultCellStyle.Alignment;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = dataGridViewCellStyle2.WrapMode;
			}
			else if (rowHeadersDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = rowHeadersDefaultCellStyle.WrapMode;
			}
			else
			{
				dataGridViewCellStyle.WrapModeInternal = defaultCellStyle.WrapMode;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Tag != null)
			{
				dataGridViewCellStyle.Tag = dataGridViewCellStyle2.Tag;
			}
			else if (rowHeadersDefaultCellStyle.Tag != null)
			{
				dataGridViewCellStyle.Tag = rowHeadersDefaultCellStyle.Tag;
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
			if (rowHeadersDefaultCellStyle.Padding != Padding.Empty)
			{
				dataGridViewCellStyle.PaddingInternal = rowHeadersDefaultCellStyle.Padding;
				return dataGridViewCellStyle;
			}
			dataGridViewCellStyle.PaddingInternal = defaultCellStyle.Padding;
			return dataGridViewCellStyle;
		}

		/// Gets the value of the cell. </summary>
		/// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see>.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than -1 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		protected override object GetValue(int intRowIndex)
		{
			if (base.DataGridView != null && (intRowIndex < -1 || intRowIndex >= base.DataGridView.Rows.Count))
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (base.ContainsLocalValue)
			{
				return base.LocalValue;
			}
			return null;
		}

		/// 
		/// Sets the value of the cell.
		/// </summary>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <param name="objValue">The cell value to set.</param>
		/// 
		/// true if the value has been set; otherwise, false.
		/// </returns>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		protected override bool SetValue(int intRowIndex, object objValue)
		{
			object value = GetValue(intRowIndex);
			if (objValue != null || base.ContainsLocalValue)
			{
				base.LocalValue = objValue;
			}
			if (base.DataGridView != null && value != objValue)
			{
				RaiseCellValueChanged(new DataGridViewCellEventArgs(-1, intRowIndex));
			}
			return true;
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			return null;
		}
	}
}

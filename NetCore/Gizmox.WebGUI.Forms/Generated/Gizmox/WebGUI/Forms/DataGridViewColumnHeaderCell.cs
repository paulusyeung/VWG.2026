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
/// Represents a column header in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class DataGridViewColumnHeaderCell : DataGridViewHeaderCell
	{
		private SortOrder menmSortGlyphDirection;

		private DataGridViewHeaderFilterComboBox mobjFilterComboBox;

		private bool mblnShouldPreRenderHeaderFilter = false;

		private static Type mobjCellType;

		private const byte DATAGRIDVIEWCOLUMNHEADERCELL_horizontalTextMarginLeft = 2;

		private const byte DATAGRIDVIEWCOLUMNHEADERCELL_horizontalTextMarginRight = 2;

		private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphHeight = 7;

		private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphHorizontalMargin = 4;

		private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphSeparatorWidth = 2;

		private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphWidth = 9;

		private const byte DATAGRIDVIEWCOLUMNHEADERCELL_verticalMargin = 1;

		/// 
		/// Gets or sets the coll span.
		/// </summary>
		/// 
		/// The coll span.
		/// </value>
		public override int Colspan
		{
			get
			{
				return base.Colspan;
			}
			set
			{
				if (value > 1)
				{
					throw new NotSupportedException("Header cell does not support col span");
				}
				base.Colspan = value;
			}
		}

		/// 
		/// Gets or sets the row span.
		/// </summary>
		/// 
		/// The row span.
		/// </value>
		public override int Rowspan
		{
			get
			{
				return base.Rowspan;
			}
			set
			{
				if (value > 1)
				{
					throw new NotSupportedException("Header cell does not support row span");
				}
				base.Rowspan = value;
			}
		}

		/// 
		/// Gets the filter combo box.
		/// </summary>
		[Browsable(false)]
		public DataGridViewHeaderFilterComboBox FilterComboBox
		{
			get
			{
				if (mobjFilterComboBox == null)
				{
					mobjFilterComboBox = new DataGridViewHeaderFilterComboBox(this);
					mobjFilterComboBox.SelectedIndexChanged += FilterComboBoxSelectedIndexChanged;
				}
				return mobjFilterComboBox;
			}
		}

		/// Gets or sets a value indicating which sort glyph is displayed.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> value representing the current glyph. The default is <see cref="F:Gizmox.WebGUI.Forms.SortOrder.None"></see>. </returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> value.</exception>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the value of either the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> property or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is null.-or-When changing the value of this property, the specified value is not <see cref="F:Gizmox.WebGUI.Forms.SortOrder.None"></see> and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property of the owning column is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable"></see>.</exception>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SortOrder SortGlyphDirection
		{
			get
			{
				return menmSortGlyphDirection;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(SortOrder));
				}
				if (base.OwningColumn == null || base.DataGridView == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CellDoesNotYetBelongToDataGridView"));
				}
				if (value != SortGlyphDirection)
				{
					if (base.OwningColumn.SortMode == DataGridViewColumnSortMode.NotSortable && value != SortOrder.None)
					{
						throw new InvalidOperationException(SR.GetString("DataGridViewColumnHeaderCell_SortModeAndSortGlyphDirectionClash", value.ToString()));
					}
					SortGlyphDirectionInternal = value;
					base.DataGridView.OnSortGlyphDirectionChanged(this);
					Update();
				}
			}
		}

		/// 
		/// Sets the sort glyph direction internal.
		/// </summary>
		/// The sort glyph direction internal.</value>
		internal SortOrder SortGlyphDirectionInternal
		{
			set
			{
				menmSortGlyphDirection = value;
			}
		}

		/// 
		///
		/// </summary>
		protected override string MemberID => "CHC" + base.ColumnIndex;

		/// 
		/// Gets or sets a value indicating whether [should pre render header filter].
		/// </summary>
		/// 
		/// 	true</c> if [should pre render header filter]; otherwise, false</c>.
		/// </value>
		internal bool ShouldPreRenderHeaderFilter
		{
			get
			{
				return mblnShouldPreRenderHeaderFilter;
			}
			set
			{
				mblnShouldPreRenderHeaderFilter = value;
			}
		}

		static DataGridViewColumnHeaderCell()
		{
			mobjCellType = typeof(DataGridViewColumnHeaderCell);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> class.</summary>
		public DataGridViewColumnHeaderCell()
		{
			SortGlyphDirectionInternal = SortOrder.None;
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
				if (type == "DoubleClick")
				{
					FireColumnHeaderMouseClick(objEvent);
					FireColumnHeaderMouseDoubleClick(objEvent);
				}
			}
			else
			{
				FireColumnHeaderMouseClick(objEvent);
			}
		}

		/// 
		/// Fires the column header mouse click.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected virtual void FireColumnHeaderMouseClick(IEvent objEvent)
		{
			if (base.DataGridView != null)
			{
				int eventValue = GetEventValue(objEvent, "X", 0);
				int eventValue2 = GetEventValue(objEvent, "Y", 0);
				base.DataGridView.FireColumnHeaderMouseClick(new DataGridViewCellMouseEventArgs(base.ColumnIndex, base.RowIndex, 0, 0, new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue, eventValue2, 0)));
				if (base.DataGridView != null)
				{
					base.DataGridView.Update();
				}
			}
		}

		/// 
		/// Fires the column header mouse double click.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected virtual void FireColumnHeaderMouseDoubleClick(IEvent objEvent)
		{
			if (base.DataGridView != null)
			{
				int eventValue = GetEventValue(objEvent, "X", 0);
				int eventValue2 = GetEventValue(objEvent, "Y", 0);
				base.DataGridView.FireColumnHeaderMouseDoubleClick(new DataGridViewCellMouseEventArgs(base.ColumnIndex, base.RowIndex, 0, 0, new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue, eventValue2, 0)));
			}
		}

		/// 
		/// Renders a header- cell's attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			if (SortGlyphDirection != SortOrder.None)
			{
				objWriter.WriteAttributeString("SOD", (SortGlyphDirection == SortOrder.Descending) ? "1" : "0");
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
				objWriter.WriteAttributeString("TA", objCellStyle.Alignment.ToString());
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
			DataGridViewColumn owningColumn = base.OwningColumn;
			if (owningColumn != null && base.OwningColumn.ShowHeaderFilter && mobjFilterComboBox != null)
			{
				mobjFilterComboBox.RenderControl(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Prerenders component.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		internal override void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
			base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
			if (ShouldPreRenderHeaderFilter)
			{
				FilterComboBox.InitializeFilterValues(blnAddSystemFilterOptions: true, blnCalculateDropDownWidth: true, blnClearBindingSourceFilter: false);
				ShouldPreRenderHeaderFilter = false;
			}
		}

		/// 
		/// Selected index changed event handler of the filter combo box.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void FilterComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null || dataGridView.mblnSuspendFilterInitialization)
			{
				return;
			}
			if (FilterComboBox.SelectedItem is DataGridViewSystemFilterOption { Option: SystemFilterOptions.Custom })
			{
				dataGridView.OpenCustomFilterDialog(this);
				return;
			}
			dataGridView.mblnSuspendFilterInitialization = true;
			if (dataGridView.ShowFilterRow && dataGridView.FilterRow != null && dataGridView.FilterRow.Cells.Count > 0)
			{
				(dataGridView.FilterRow.Cells[base.OwningColumn.Index] as DataGridViewFilterCell).ClearFilter(blnClearHeaderFilter: false);
			}
			base.OwningColumn.mstrCustomFilterExpression = string.Empty;
			dataGridView.ApplyDataGridViewFilter();
			dataGridView.mblnSuspendFilterInitialization = false;
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
				if ((base.OwningColumn != null && base.OwningColumn.SortMode != DataGridViewColumnSortMode.NotSortable) || base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK))
				{
					criticalEventsData.Set("CL");
					criticalEventsData.Set("RC");
				}
				if (base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK))
				{
					criticalEventsData.Set("DCL");
				}
			}
			return criticalEventsData;
		}

		/// 
		/// Determines whether [has wrap mode] [the specified obj cell style].
		/// </summary>
		/// <param name="objCellStyle">The obj cell style.</param>
		/// 
		///   true</c> if [has wrap mode] [the specified obj cell style]; otherwise, false</c>.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool HasWrapMode(DataGridViewCellStyle objCellStyle)
		{
			DataGridViewColumn owningColumn = base.OwningColumn;
			if (owningColumn != null && owningColumn.AutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet)
			{
				switch (owningColumn.AutoSizeMode)
				{
				case DataGridViewAutoSizeColumnMode.None:
				case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
				case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
				case DataGridViewAutoSizeColumnMode.Fill:
					if (objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True)
					{
						return true;
					}
					return false;
				default:
					return false;
				}
			}
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				switch (dataGridView.AutoSizeColumnsMode)
				{
				case DataGridViewAutoSizeColumnsMode.None:
				case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
				case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
				case DataGridViewAutoSizeColumnsMode.Fill:
					if (objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True)
					{
						return true;
					}
					return false;
				}
			}
			return false;
		}

		/// 
		/// Creates an exact copy of this cell.
		/// </summary>
		/// 
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.
		/// </returns>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewColumnHeaderCell dataGridViewColumnHeaderCell = ((!(type == mobjCellType)) ? ((DataGridViewColumnHeaderCell)Activator.CreateInstance(type)) : new DataGridViewColumnHeaderCell());
			CloneInternal(dataGridViewColumnHeaderCell);
			dataGridViewColumnHeaderCell.Value = base.Value;
			return dataGridViewColumnHeaderCell;
		}

		/// Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
		/// A <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
		/// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="strFormat">The current format string of the cell.</param>
		/// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
		/// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
		protected override object GetClipboardContent(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
		{
			if (intRowIndex != -1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (base.DataGridView == null)
			{
				return null;
			}
			object value = GetValue(intRowIndex);
			StringBuilder stringBuilder = new StringBuilder(64);
			if (ClientUtils.IsEquals(strFormat, DataFormats.Html, StringComparison.OrdinalIgnoreCase))
			{
				if (blnFirstCell)
				{
					stringBuilder.Append("");
					stringBuilder.Append("");
				}
				stringBuilder.Append("");
				if (value != null)
				{
					DataGridViewCell.FormatPlainTextAsHtml(value.ToString(), new StringWriter(stringBuilder, CultureInfo.CurrentCulture));
				}
				else
				{
					stringBuilder.Append("&nbsp;");
				}
				stringBuilder.Append("</TH>");
				if (blnLastCell)
				{
					stringBuilder.Append("</THEAD>");
					if (blnInLastRow)
					{
						stringBuilder.Append("</TABLE>");
					}
				}
				return stringBuilder.ToString();
			}
			bool flag = ClientUtils.IsEquals(strFormat, DataFormats.CommaSeparatedValue, StringComparison.OrdinalIgnoreCase);
			if (!flag && !ClientUtils.IsEquals(strFormat, DataFormats.Text, StringComparison.OrdinalIgnoreCase) && !ClientUtils.IsEquals(strFormat, DataFormats.UnicodeText, StringComparison.OrdinalIgnoreCase))
			{
				return null;
			}
			if (value != null)
			{
				bool blnEscapeApplied = false;
				int length = stringBuilder.Length;
				DataGridViewCell.FormatPlainText(value.ToString(), flag, new StringWriter(stringBuilder, CultureInfo.CurrentCulture), ref blnEscapeApplied);
				if (blnEscapeApplied)
				{
					stringBuilder.Insert(length, '"');
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

		/// Gets the style applied to the cell. </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style. </param>
		/// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
		public override DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle objInheritedCellStyle, int intRowIndex, bool blnIncludeColors)
		{
			if (intRowIndex != -1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			DataGridViewCellStyle dataGridViewCellStyle = ((objInheritedCellStyle == null) ? new DataGridViewCellStyle() : objInheritedCellStyle);
			DataGridViewCellStyle dataGridViewCellStyle2 = null;
			if (base.HasStyle)
			{
				dataGridViewCellStyle2 = base.Style;
			}
			DataGridViewCellStyle columnHeadersDefaultCellStyle = base.DataGridView.ColumnHeadersDefaultCellStyle;
			DataGridViewCellStyle defaultCellStyle = base.DataGridView.DefaultCellStyle;
			if (blnIncludeColors)
			{
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = dataGridViewCellStyle2.BackColor;
				}
				else if (!columnHeadersDefaultCellStyle.BackColor.IsEmpty)
				{
					dataGridViewCellStyle.BackColor = columnHeadersDefaultCellStyle.BackColor;
				}
				else
				{
					dataGridViewCellStyle.BackColor = defaultCellStyle.BackColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = dataGridViewCellStyle2.ForeColor;
				}
				else if (!columnHeadersDefaultCellStyle.ForeColor.IsEmpty)
				{
					dataGridViewCellStyle.ForeColor = columnHeadersDefaultCellStyle.ForeColor;
				}
				else
				{
					dataGridViewCellStyle.ForeColor = defaultCellStyle.ForeColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = dataGridViewCellStyle2.SelectionBackColor;
				}
				else if (!columnHeadersDefaultCellStyle.SelectionBackColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionBackColor = columnHeadersDefaultCellStyle.SelectionBackColor;
				}
				else
				{
					dataGridViewCellStyle.SelectionBackColor = defaultCellStyle.SelectionBackColor;
				}
				if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = dataGridViewCellStyle2.SelectionForeColor;
				}
				else if (!columnHeadersDefaultCellStyle.SelectionForeColor.IsEmpty)
				{
					dataGridViewCellStyle.SelectionForeColor = columnHeadersDefaultCellStyle.SelectionForeColor;
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
			else if (columnHeadersDefaultCellStyle.Font != null)
			{
				dataGridViewCellStyle.Font = columnHeadersDefaultCellStyle.Font;
			}
			else
			{
				dataGridViewCellStyle.Font = defaultCellStyle.Font;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = dataGridViewCellStyle2.NullValue;
			}
			else if (!columnHeadersDefaultCellStyle.IsNullValueDefault)
			{
				dataGridViewCellStyle.NullValue = columnHeadersDefaultCellStyle.NullValue;
			}
			else
			{
				dataGridViewCellStyle.NullValue = defaultCellStyle.NullValue;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = dataGridViewCellStyle2.DataSourceNullValue;
			}
			else if (!columnHeadersDefaultCellStyle.IsDataSourceNullValueDefault)
			{
				dataGridViewCellStyle.DataSourceNullValue = columnHeadersDefaultCellStyle.DataSourceNullValue;
			}
			else
			{
				dataGridViewCellStyle.DataSourceNullValue = defaultCellStyle.DataSourceNullValue;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = dataGridViewCellStyle2.Format;
			}
			else if (columnHeadersDefaultCellStyle.Format.Length != 0)
			{
				dataGridViewCellStyle.Format = columnHeadersDefaultCellStyle.Format;
			}
			else
			{
				dataGridViewCellStyle.Format = defaultCellStyle.Format;
			}
			if (dataGridViewCellStyle2 != null && !dataGridViewCellStyle2.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = dataGridViewCellStyle2.FormatProvider;
			}
			else if (!columnHeadersDefaultCellStyle.IsFormatProviderDefault)
			{
				dataGridViewCellStyle.FormatProvider = columnHeadersDefaultCellStyle.FormatProvider;
			}
			else
			{
				dataGridViewCellStyle.FormatProvider = defaultCellStyle.FormatProvider;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = dataGridViewCellStyle2.Alignment;
			}
			else if (columnHeadersDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
			{
				dataGridViewCellStyle.AlignmentInternal = columnHeadersDefaultCellStyle.Alignment;
			}
			else
			{
				dataGridViewCellStyle.AlignmentInternal = defaultCellStyle.Alignment;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = dataGridViewCellStyle2.WrapMode;
			}
			else if (columnHeadersDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet)
			{
				dataGridViewCellStyle.WrapModeInternal = columnHeadersDefaultCellStyle.WrapMode;
			}
			else
			{
				dataGridViewCellStyle.WrapModeInternal = defaultCellStyle.WrapMode;
			}
			if (dataGridViewCellStyle2 != null && dataGridViewCellStyle2.Tag != null)
			{
				dataGridViewCellStyle.Tag = dataGridViewCellStyle2.Tag;
			}
			else if (columnHeadersDefaultCellStyle.Tag != null)
			{
				dataGridViewCellStyle.Tag = columnHeadersDefaultCellStyle.Tag;
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
			if (columnHeadersDefaultCellStyle.Padding != Padding.Empty)
			{
				dataGridViewCellStyle.PaddingInternal = columnHeadersDefaultCellStyle.Padding;
				return dataGridViewCellStyle;
			}
			dataGridViewCellStyle.PaddingInternal = defaultCellStyle.Padding;
			return dataGridViewCellStyle;
		}

		/// Gets the value of the cell. </summary>
		/// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see>.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
		protected override object GetValue(int intRowIndex)
		{
			if (intRowIndex != -1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (base.ContainsLocalValue)
			{
				return base.LocalValue;
			}
			if (base.OwningColumn != null)
			{
				return base.OwningColumn.Name;
			}
			return null;
		}

		/// 
		/// Calculates the preferred size, in pixels, of the cell.
		/// </summary>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell.</param>
		/// <param name="objConstraintSize">The cell's maximum allowable size.</param>
		/// 
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
		/// </returns>
		protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
		{
			int num = 0;
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				DataGridViewColumn owningColumn = base.OwningColumn;
				if (base.DataGridView.Skin is DataGridViewSkin dataGridViewSkin && owningColumn != null)
				{
					if (owningColumn.SortMode != DataGridViewColumnSortMode.NotSortable)
					{
						num += Math.Max(dataGridViewSkin.SortAscendingIndicatorImageSize.Width, dataGridViewSkin.SortDescendingIndicatorImageSize.Width);
					}
					if (owningColumn.HasFilterInfo() && int.TryParse(dataGridViewSkin.HeaderFilterComboBoxImageWidth.GetValue(VWGContext.Current), out var result))
					{
						num += result;
					}
				}
			}
			Size objConstraintSize2 = objConstraintSize;
			if (objConstraintSize.Height == 0)
			{
				objConstraintSize2 = new Size(Math.Max(0, objConstraintSize.Width - num), objConstraintSize2.Height);
			}
			try
			{
				Size preferredSize = base.GetPreferredSize(objGraphics, objCellStyle, intRowIndex, objConstraintSize2);
				objConstraintSize2 = preferredSize;
			}
			catch (Exception)
			{
			}
			return new Size(objConstraintSize2.Width + num, objConstraintSize2.Height + 4);
		}

		/// Sets the value of the cell. </summary>
		/// true if the value has been set; otherwise false.</returns>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <param name="objValue">The cell value to set. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
		protected override bool SetValue(int intRowIndex, object objValue)
		{
			if (intRowIndex != -1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			object value = GetValue(intRowIndex);
			base.LocalValue = objValue;
			if (base.DataGridView != null && value != objValue)
			{
				RaiseCellValueChanged(new DataGridViewCellEventArgs(base.ColumnIndex, -1));
			}
			return true;
		}

		public override string ToString()
		{
			return "DataGridViewColumnHeaderCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + " }";
		}

		/// Retrieves the inherited shortcut menu for the specified row.</summary>
		/// The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> of the column headers if one exists; otherwise, the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> inherited from <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
		/// <param name="intRowIndex">The index of the row to get the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> of. The index must be -1 to indicate the row of column headers.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
		public override ContextMenu GetInheritedContextMenu(int intRowIndex)
		{
			if (intRowIndex != -1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			ContextMenu contextMenu = GetContextMenu(-1);
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
			if (intRowIndex != -1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			ContextMenuStrip contextMenuStrip = GetContextMenuStrip(-1);
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
	}
}

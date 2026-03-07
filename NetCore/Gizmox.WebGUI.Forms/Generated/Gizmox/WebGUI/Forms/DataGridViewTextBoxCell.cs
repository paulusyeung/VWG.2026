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
	/// Displays editable text information in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[Skin(typeof(DataGridViewTextBoxCellSkin))]
	public class DataGridViewTextBoxCell : DataGridViewCell
	{
		private static Type mobjDefaultFormattedValueType;

		private static Type mobjDefaultValueType;

		private static Type mobjCellType;

		private int mintTextBoxCellMaxInputLength = 32767;

		private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginLeft = 0;

		private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginRight = 0;

		private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetLeft = 3;

		private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetRight = 4;

		private const byte DATAGRIDVIEWTEXTBOXCELL_ignoreNextMouseClick = 1;

		private const int DATAGRIDVIEWTEXTBOXCELL_maxInputLength = 32767;

		private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginBottom = 1;

		private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithoutWrapping = 2;

		private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithWrapping = 1;

		private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetBottom = 1;

		private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetTop = 2;

		/// 
		/// Gets a value indicating whether [support edit mode].
		/// </summary>
		/// true</c> if [support edit mode]; otherwise, false</c>.</value>
		protected override bool SupportEditMode => true;

		/// 
		/// Gets a value indicating whether [support active mode]. Whethre this cell would be redrawn with defferent skin.
		/// </summary>
		/// true</c> if [support active mode]; otherwise, false</c>.</value>
		protected override bool SupportActiveMode => true;

		/// Gets the type of the formatted value associated with the cell.</summary>
		/// A <see cref="T:System.Type"></see> representing the <see cref="T:System.String"></see> type in all cases.</returns>
		/// 1</filterpriority>
		public override Type FormattedValueType => mobjDefaultFormattedValueType;

		/// Gets or sets the maximum number of characters that can be entered into the text box.</summary>
		/// The maximum number of characters that can be entered into the text box; the default value is 32767.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 0.</exception>
		[DefaultValue(32767)]
		public virtual int MaxInputLength
		{
			get
			{
				return mintTextBoxCellMaxInputLength;
			}
			set
			{
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"MaxInputLength",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("MaxInputLength", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				mintTextBoxCellMaxInputLength = value;
			}
		}

		/// 
		/// Gets or sets the data type of the values in the cell.
		/// </summary>
		/// </value>
		/// A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
		public override Type ValueType
		{
			get
			{
				Type valueType = base.ValueType;
				if (valueType != null)
				{
					return valueType;
				}
				return mobjDefaultValueType;
			}
		}

		/// 
		/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell" /> class.
		/// </summary>
		static DataGridViewTextBoxCell()
		{
			mobjDefaultFormattedValueType = typeof(string);
			mobjDefaultValueType = typeof(object);
			mobjCellType = typeof(DataGridViewTextBoxCell);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see> class.
		/// </summary>
		public DataGridViewTextBoxCell()
		{
		}

		/// Determines if edit mode should be started based on the given key.</summary>
		/// true if edit mode should be started; otherwise, false. </returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
		/// 1</filterpriority>
		public override bool KeyEntersEditMode(KeyEventArgs e)
		{
			return false;
		}

		/// Called by <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the selection cursor moves onto a cell.</summary>
		/// <param name="blnThroughMouseClick">true if the cell was entered as a result of a mouse click; otherwise, false.</param>
		/// <param name="intRowIndex">The index of the row entered by the mouse.</param>
		protected override void OnEnter(int intRowIndex, bool blnThroughMouseClick)
		{
		}

		/// Called by the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the mouse leaves a cell.</summary>
		/// <param name="blnThroughMouseClick">true if the cell was left as a result of a mouse click; otherwise, false.</param>
		/// <param name="intRowIndex">The index of the row the mouse has left.</param>
		protected override void OnLeave(int intRowIndex, bool blnThroughMouseClick)
		{
		}

		/// Called by <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the mouse leaves a cell.</summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
		protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
		{
		}

		/// 
		/// Ownses the editing text box.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		private bool OwnsEditingTextBox(int intRowIndex)
		{
			return false;
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
		/// Gets the key event captures.
		/// </summary>
		/// </returns>
		protected override KeyCaptures GetKeyEventCaptures()
		{
			KeyCaptures keyEventCaptures = base.GetKeyEventCaptures();
			keyEventCaptures |= KeyCaptures.RightKeyCapture;
			keyEventCaptures |= KeyCaptures.LeftKeyCapture;
			keyEventCaptures |= KeyCaptures.EndKeyCapture;
			keyEventCaptures |= KeyCaptures.HomeKeyCapture;
			keyEventCaptures |= KeyCaptures.BackspaceKeyCapture;
			return keyEventCaptures | KeyCaptures.DeleteKeyCapture;
		}

		/// 
		/// Fires the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (type == "ValueChange" && !ReadOnly)
			{
				SetValue(CommonUtils.DecodeText(objEvent["TX"]), blnClientSource: true);
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
			if (objFormatedValue != null && objFormatedValue.ToString() != string.Empty)
			{
				objWriter.WriteAttributeText("VLB", objFormatedValue.ToString());
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
			if (MaxInputLength != 32767)
			{
				objWriter.WriteAttributeString("MH", MaxInputLength.ToString());
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
		/// Calculates the preferred size, in pixels, of the cell.
		/// </summary>
		/// <param name="strText">The text to be measured.</param>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// 
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
		/// </returns>
		protected override Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
		{
			if (string.IsNullOrEmpty(strText))
			{
				strText = " ";
			}
			return base.GetPreferredSize(strText, objCellStyle);
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>.</returns>
		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewTextBoxCell dataGridViewTextBoxCell = ((!(type == mobjCellType)) ? ((DataGridViewTextBoxCell)Activator.CreateInstance(type)) : new DataGridViewTextBoxCell());
			CloneInternal(dataGridViewTextBoxCell);
			return dataGridViewTextBoxCell;
		}

		/// 
		/// Clones TextBox Cell 
		/// </summary>
		/// <param name="objTextBoxCell">The obj text box cell.</param>
		protected void CloneInternal(DataGridViewTextBoxCell objTextBoxCell)
		{
			CloneInternal((DataGridViewCell)objTextBoxCell);
			objTextBoxCell.MaxInputLength = MaxInputLength;
		}

		/// 
		/// Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override void DetachEditingControl()
		{
		}

		/// Attaches and initializes the hosted editing control.</summary>
		/// <param name="objInitialFormattedValue">The initial value to be displayed in the control.</param>
		/// <param name="intRowIndex">The index of the row being edited.</param>
		/// <param name="objDataGridViewCellStyle">A cell style that is used to determine the appearance of the hosted control.</param>
		/// 1</filterpriority>
		public override void InitializeEditingControl(int intRowIndex, object objInitialFormattedValue, DataGridViewCellStyle objDataGridViewCellStyle)
		{
		}

		/// 
		/// Sets the location and size of the editing control hosted by a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
		/// </summary>
		/// <param name="blnSetLocation">true to have the control placed as specified by the other arguments; false to allow the control to place itself.</param>
		/// <param name="blnSetSize">true to specify the size; false to allow the control to size itself.</param>
		/// <param name="objCellBounds">A <see cref="T:System.Drawing.Rectangle"></see> that defines the cell bounds.</param>
		/// <param name="objCellClip">The area that will be used to paint the editing control.</param>
		/// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell being edited.</param>
		/// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false.</param>
		/// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false.</param>
		/// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false.</param>
		/// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false.</param>
		/// <exception cref="T:System.InvalidOperationException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		public override void PositionEditingControl(bool blnSetLocation, bool blnSetSize, Rectangle objCellBounds, Rectangle objCellClip, DataGridViewCellStyle objCellStyle, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
		{
		}

		/// 
		/// Returns a string that describes the current object.
		/// </summary>
		/// 
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			return "DataGridViewTextBoxCell { ColumnIndex=" + base.ColumnIndex + ", RowIndex=" + base.RowIndex + " }";
		}
	}
}

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
	/// Represents a text box control that can be hosted in a <see cref="T:System.Windows.Forms.DataGridViewTextBoxCell"></see>.
	/// </summary>
	[Serializable]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ToolboxItem(false)]
	public class DataGridViewTextBoxEditingControl : TextBox, IDataGridViewEditingControl
	{
		private bool mblnRepositionEditingControlOnValueChange;

		private bool mblnEditingControlValueChanged;

		private int mintEditingControlRowIndex;

		private DataGridView mobjDataGridView = null;

		private static readonly DataGridViewContentAlignment menmAnyCenter = (DataGridViewContentAlignment)546;

		private static readonly DataGridViewContentAlignment menmAnyRight = (DataGridViewContentAlignment)1092;

		private static readonly DataGridViewContentAlignment menmAnyTop = (DataGridViewContentAlignment)7;

		/// Gets or sets the <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the text box control.</summary>
		/// A <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the <see cref="T:System.Windows.Forms.DataGridViewTextBoxCell"></see> that contains this control; otherwise, null if there is no associated <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
		public virtual DataGridView EditingControlDataGridView
		{
			get
			{
				return mobjDataGridView;
			}
			set
			{
				mobjDataGridView = value;
			}
		}

		/// Gets or sets the formatted representation of the current value of the text box control.</summary>
		/// An object representing the current value of this control.</returns>
		public virtual object EditingControlFormattedValue
		{
			get
			{
				return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
			}
			set
			{
				Text = (string)value;
			}
		}

		/// Gets or sets the index of the owning cell's parent row.</summary>
		/// The index of the row that contains the owning cell; -1 if there is no owning row.</returns>
		public virtual int EditingControlRowIndex
		{
			get
			{
				return mintEditingControlRowIndex;
			}
			set
			{
				mintEditingControlRowIndex = value;
			}
		}

		/// Gets or sets a value indicating whether the current value of the text box control has changed.</summary>
		/// true if the value of the control has changed; otherwise, false.</returns>
		public virtual bool EditingControlValueChanged
		{
			get
			{
				return mblnEditingControlValueChanged;
			}
			set
			{
				mblnEditingControlValueChanged = value;
			}
		}

		/// Gets the cursor used when the mouse pointer is over the <see cref="P:System.Windows.Forms.DataGridView.EditingPanel"></see> but not over the editing control.</summary>
		/// A <see cref="T:System.Windows.Forms.Cursor"></see> that represents the mouse pointer used for the editing panel. </returns>
		public virtual Cursor EditingPanelCursor => Cursors.Default;

		/// Gets a value indicating whether the cell contents need to be repositioned whenever the value changes.</summary>
		/// true if the cell's <see cref="P:System.Windows.Forms.DataGridViewCellStyle.WrapMode"></see> is set to true and the alignment property is not set to one of the <see cref="T:System.Windows.Forms.DataGridViewContentAlignment"></see> values that aligns the content to the top; otherwise, false.</returns>
		public virtual bool RepositionEditingControlOnValueChange
		{
			get
			{
				return mblnRepositionEditingControlOnValueChange;
			}
			private set
			{
				mblnRepositionEditingControlOnValueChange = value;
			}
		}

		/// Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewTextBoxEditingControl"></see> class.</summary>
		public DataGridViewTextBoxEditingControl()
		{
			base.TabStop = false;
		}

		/// 
		/// Raises the <see cref="E:TextChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			NotifyDataGridViewOfValueChange();
		}

		/// Changes the control's user interface (UI) to be consistent with the specified cell style.</summary>
		/// <param name="objDataGridViewCellStyle">The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to use as the model for the UI.</param>
		public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle objDataGridViewCellStyle)
		{
			Font = objDataGridViewCellStyle.Font;
			if (objDataGridViewCellStyle.BackColor.A < byte.MaxValue)
			{
				Color backColor = (BackColor = Color.FromArgb(255, objDataGridViewCellStyle.BackColor));
				if (EditingControlDataGridView.EditingPanel != null)
				{
					EditingControlDataGridView.EditingPanel.BackColor = backColor;
				}
			}
			else
			{
				BackColor = objDataGridViewCellStyle.BackColor;
			}
			ForeColor = objDataGridViewCellStyle.ForeColor;
			if (objDataGridViewCellStyle.WrapMode == DataGridViewTriState.True)
			{
				base.WordWrap = true;
			}
			base.TextAlign = TranslateAlignment(objDataGridViewCellStyle.Alignment);
			RepositionEditingControlOnValueChange = objDataGridViewCellStyle.WrapMode == DataGridViewTriState.True && (objDataGridViewCellStyle.Alignment & menmAnyTop) == 0;
		}

		/// Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:System.Windows.Forms.DataGridView"></see> should process.</summary>
		/// true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
		/// <param name="enmKeyData">A <see cref="T:System.Windows.Forms.Keys"></see> that represents the key that was pressed.</param>
		/// <param name="blnDataGridViewWantsInputKey">true when the <see cref="T:System.Windows.Forms.DataGridView"></see> wants to process the keyData; otherwise, false.</param>
		public virtual bool EditingControlWantsInputKey(Keys enmKeyData, bool blnDataGridViewWantsInputKey)
		{
			switch (enmKeyData & Keys.KeyCode)
			{
			case Keys.PageUp:
			case Keys.Next:
				if (!EditingControlValueChanged)
				{
					break;
				}
				return true;
			case Keys.End:
			case Keys.Home:
				if (SelectionLength == Text.Length)
				{
					break;
				}
				return true;
			case Keys.Left:
				if ((RightToLeft != RightToLeft.No || (SelectionLength == 0 && base.SelectionStart == 0)) && (RightToLeft != RightToLeft.Yes || (SelectionLength == 0 && base.SelectionStart == Text.Length)))
				{
					break;
				}
				return true;
			case Keys.Up:
				if (Text.IndexOf("\r\n") < 0 || base.SelectionStart + SelectionLength < Text.IndexOf("\r\n"))
				{
					break;
				}
				return true;
			case Keys.Right:
				if ((RightToLeft != RightToLeft.No || (SelectionLength == 0 && base.SelectionStart == Text.Length)) && (RightToLeft != RightToLeft.Yes || (SelectionLength == 0 && base.SelectionStart == 0)))
				{
					break;
				}
				return true;
			case Keys.Down:
			{
				int startIndex = base.SelectionStart + SelectionLength;
				if (Text.IndexOf("\r\n", startIndex) == -1)
				{
					break;
				}
				return true;
			}
			case Keys.Delete:
				if (SelectionLength <= 0 && base.SelectionStart >= Text.Length)
				{
					break;
				}
				return true;
			case Keys.Enter:
				if ((enmKeyData & (Keys.Alt | Keys.Control | Keys.Shift)) == Keys.Shift && Multiline && base.AcceptsReturn)
				{
					return true;
				}
				break;
			}
			return !blnDataGridViewWantsInputKey;
		}

		/// Retrieves the formatted value of the cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
		/// <param name="enmContext">One of the <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
		public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext)
		{
			if (EditingControlDataGridView != null && EditingControlDataGridView.CurrentCell != null)
			{
				return EditingControlDataGridView.CurrentCell.EditingProposedValue;
			}
			return null;
		}

		/// 
		/// Notifies the data grid view of value change.
		/// </summary>
		private void NotifyDataGridViewOfValueChange()
		{
			EditingControlValueChanged = true;
			EditingControlDataGridView.NotifyCurrentCellDirty(blnDirty: true);
		}

		/// Prepares the currently selected cell for editing.</summary>
		/// <param name="blnSelectAll">true to select the cell contents; otherwise, false.</param>
		public virtual void PrepareEditingControlForEdit(bool blnSelectAll)
		{
			if (blnSelectAll)
			{
				SelectAll();
			}
			else
			{
				base.SelectionStart = Text.Length;
			}
		}

		/// 
		/// Translates the alignment.
		/// </summary>
		/// <param name="enmAlign">The align.</param>
		/// </returns>
		private static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment enmAlign)
		{
			if ((enmAlign & menmAnyRight) != DataGridViewContentAlignment.NotSet)
			{
				return HorizontalAlignment.Right;
			}
			if ((enmAlign & menmAnyCenter) != DataGridViewContentAlignment.NotSet)
			{
				return HorizontalAlignment.Center;
			}
			return HorizontalAlignment.Left;
		}
	}
}

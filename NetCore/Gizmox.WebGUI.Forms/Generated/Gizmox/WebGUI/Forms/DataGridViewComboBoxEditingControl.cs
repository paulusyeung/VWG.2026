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
	/// Represents the hosted combo box control in a <see cref="T:System.Windows.Forms.DataGridViewComboBoxCell"></see>.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ComVisible(true)]
	[ToolboxItem(false)]
	public class DataGridViewComboBoxEditingControl : ComboBox, IDataGridViewEditingControl
	{
		private bool mblnEditingControlValueChanged;

		private int mintEditingControlRowIndex;

		private DataGridView mobjDataGridView = null;

		/// Gets or sets the <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the combo box control.</summary>
		/// The <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the <see cref="T:System.Windows.Forms.DataGridViewComboBoxCell"></see> that contains this control; otherwise, null if there is no associated <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
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

		/// Gets or sets the formatted representation of the current value of the control.</summary>
		/// An object representing the current value of this control.</returns>
		public virtual object EditingControlFormattedValue
		{
			get
			{
				return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
			}
			set
			{
				if (value is string text)
				{
					Text = text;
					if (string.Compare(text, Text, ignoreCase: true, CultureInfo.CurrentCulture) != 0)
					{
						SelectedIndex = -1;
					}
				}
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

		/// Gets or sets a value indicating whether the current value of the control has changed.</summary>
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

		/// Gets the cursor used during editing.</summary>
		/// A <see cref="T:System.Windows.Forms.Cursor"></see> that represents the cursor image used by the mouse pointer during editing.</returns>
		public virtual Cursor EditingPanelCursor => Cursors.Default;

		/// Gets a value indicating whether the cell contents need to be repositioned whenever the value changes.</summary>
		/// false in all cases.</returns>
		public virtual bool RepositionEditingControlOnValueChange => false;

		/// Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewComboBoxEditingControl"></see> class.</summary>
		public DataGridViewComboBoxEditingControl()
		{
			base.TabStop = false;
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			if (SelectedIndex != -1)
			{
				NotifyDataGridViewOfValueChange();
			}
		}

		/// Changes the control's user interface (UI) to be consistent with the specified cell style.</summary>
		/// <param name="objDataGridViewCellStyle">The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to use as a pattern for the UI.</param>
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
		}

		/// Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:System.Windows.Forms.DataGridView"></see> should process.</summary>
		/// true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key that was pressed.</param>
		/// <param name="blnDataGridViewWantsInputKey">true to indicate that the <see cref="T:System.Windows.Forms.DataGridView"></see> control can process the key; otherwise, false.</param>
		public virtual bool EditingControlWantsInputKey(Keys enmKeyData, bool blnDataGridViewWantsInputKey)
		{
			return true;
		}

		/// Retrieves the formatted value of the cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
		/// <param name="enmContext">A bitwise combination of <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
		public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext)
		{
			if (EditingControlDataGridView != null && EditingControlDataGridView.CurrentCell != null)
			{
				return EditingControlDataGridView.CurrentCell.EditingProposedValue;
			}
			return null;
		}

		private void NotifyDataGridViewOfValueChange()
		{
			EditingControlValueChanged = true;
			EditingControlDataGridView.NotifyCurrentCellDirty(blnDirty: true);
		}

		/// Prepares the currently selected cell for editing.</summary>
		/// <param name="blnSelectAll">true to select all of the cell's content; otherwise, false.</param>
		public virtual void PrepareEditingControlForEdit(bool blnSelectAll)
		{
			if (blnSelectAll)
			{
				SelectAll();
			}
		}
	}
}

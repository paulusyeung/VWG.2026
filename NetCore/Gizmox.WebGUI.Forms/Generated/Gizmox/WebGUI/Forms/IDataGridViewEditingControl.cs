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
	/// Defines common functionality for controls that are hosted within cells of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
	/// </summary>
	public interface IDataGridViewEditingControl
	{
		/// 
		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that contains the cell.
		/// </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that is being edited; null if there is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		DataGridView EditingControlDataGridView { get; set; }

		/// 
		/// Gets or sets the formatted value of the cell being modified by the editor.
		/// </summary>
		/// An <see cref="T:System.Object"></see> that represents the formatted value of the cell.</returns>
		object EditingControlFormattedValue { get; set; }

		/// 
		/// Gets or sets the index of the hosting cell's parent row.
		/// </summary>
		/// The index of the row that contains the cell, or –1 if there is no parent row.</returns>
		int EditingControlRowIndex { get; set; }

		/// 
		/// Gets or sets a value indicating whether the value of the editing control differs from the value of the hosting cell.
		/// </summary>
		/// true if the value of the control differs from the cell value; otherwise, false.</returns>
		bool EditingControlValueChanged { get; set; }

		/// 
		/// Gets the cursor used when the mouse pointer is over the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingPanel"></see> but not over the editing control.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the mouse pointer used for the editing panel. </returns>
		Cursor EditingPanelCursor { get; }

		/// 
		/// Gets or sets a value indicating whether the cell contents need to be repositioned whenever the value changes.
		/// </summary>
		/// true if the contents need to be repositioned; otherwise, false.</returns>
		bool RepositionEditingControlOnValueChange { get; }

		/// 
		/// Changes the control's user interface (UI) to be consistent with the specified cell style.
		/// </summary>
		/// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to use as the model for the UI.</param>
		void ApplyCellStyleToEditingControl(DataGridViewCellStyle objDataGridViewCellStyle);

		/// 
		/// Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> should process.
		/// </summary>
		/// true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
		/// <param name="enmKeyData">A <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> that represents the key that was pressed.</param>
		/// <param name="blnDataGridViewWantsInputKey">true when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> wants to process the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> in keyData; otherwise, false.</param>
		bool EditingControlWantsInputKey(Keys enmKeyData, bool blnDataGridViewWantsInputKey);

		/// 
		/// Retrieves the formatted value of the cell.
		/// </summary>
		/// An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which the data is needed.</param>
		object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext);

		/// 
		/// Prepares the currently selected cell for editing.
		/// </summary>
		/// <param name="blnSelectAll">true to select all of the cell's content; otherwise, false.</param>
		void PrepareEditingControlForEdit(bool blnSelectAll);
	}
}

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
	/// Provides data for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsModeChanged"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeModeChanged"></see> events.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class DataGridViewAutoSizeModeEventArgs : EventArgs
	{
		private bool mblnPreviousModeAutoSized;

		/// Gets a value specifying whether the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was previously set to automatically resize.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>; otherwise, false.</returns>
		/// 1</filterpriority>
		public bool PreviousModeAutoSized => mblnPreviousModeAutoSized;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> class.</summary>
		/// <param name="blnPreviousModeAutoSized">true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>; otherwise, false.</param>
		public DataGridViewAutoSizeModeEventArgs(bool blnPreviousModeAutoSized)
		{
			mblnPreviousModeAutoSized = blnPreviousModeAutoSized;
		}
	}
}

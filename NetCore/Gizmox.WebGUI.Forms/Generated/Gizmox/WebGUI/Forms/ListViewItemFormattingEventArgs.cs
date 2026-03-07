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
	/// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.ListView.ItemFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class ListViewItemFormattingEventArgs : EventArgs
	{
		/// 
		///
		/// </summary>
		private readonly int mintIndex;

		/// 
		///
		/// </summary>
		private readonly int mintSubItemIndex;

		/// 
		///
		/// </summary>
		private readonly ListViewItem.ListViewSubItem mobjSubItem = null;

		/// 
		/// Gets the list item index.
		/// </summary>
		/// The index.</value>
		public int Index => mintIndex;

		/// 
		/// Gets the index of the sub item.
		/// </summary>
		/// The index of the sub item.</value>
		public int SubItemIndex => mintSubItemIndex;

		/// 
		/// Gets or sets the value.
		/// </summary>
		/// The value.</value>
		public string Value
		{
			get
			{
				return mobjSubItem.Text;
			}
			set
			{
				mobjSubItem.Text = value;
			}
		}

		/// 
		/// Gets or sets the background color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.
		/// </summary>
		/// The color of the back.</value>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of a item. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
		public Color BackColor
		{
			get
			{
				return mobjSubItem.BackColor;
			}
			set
			{
				mobjSubItem.BackColor = value;
			}
		}

		/// Gets or sets the font applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.</summary>
		/// The <see cref="T:System.Drawing.Font"></see> applied to the item text. The default is null.</returns>
		/// 1</filterpriority>
		public Font Font
		{
			get
			{
				return mobjSubItem.Font;
			}
			set
			{
				mobjSubItem.Font = value;
			}
		}

		/// Gets or sets the foreground color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> item.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a item. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
		/// 1</filterpriority>
		public Color ForeColor
		{
			get
			{
				return mobjSubItem.ForeColor;
			}
			set
			{
				mobjSubItem.ForeColor = value;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs"></see> class.</summary>
		/// <param name="intItemIndex">The item index of the Item that caused the event.</param>
		/// <param name="intColumnIndex">The column index of the Item that caused the event.</param>
		/// <param name="objSubItem">The sub item.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1-or-rowIndex is less than -1.</exception>
		internal ListViewItemFormattingEventArgs(int intItemIndex, int intColumnIndex, ListViewItem.ListViewSubItem objSubItem)
		{
			mintIndex = intItemIndex;
			mintSubItemIndex = intColumnIndex;
			mobjSubItem = objSubItem;
		}
	}
}

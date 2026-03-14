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
	///
	/// </summary>
	[Serializable]
	public class KeyEventArgs : EventArgs
	{
		private Keys menmKeydata;

		private bool mblnHandled = false;

		/// Gets or sets a value indicating whether the event was handled.</summary>
		/// true to bypass the control's default handling; otherwise, false to also pass the event along to the default control handler.</returns>
		[Obsolete("Not implemented by design.")]
		public bool Handled
		{
			get
			{
				return mblnHandled;
			}
			set
			{
				mblnHandled = value;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> is alt.
		/// </summary>
		/// true</c> if alt; otherwise, false</c>.</value>
		public virtual bool Alt => (menmKeydata & Keys.Alt) == Keys.Alt;

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> is control.
		/// </summary>
		/// true</c> if control; otherwise, false</c>.</value>
		public bool Control => (menmKeydata & Keys.Control) == Keys.Control;

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> is shift.
		/// </summary>
		/// true</c> if shift; otherwise, false</c>.</value>
		public virtual bool Shift => (menmKeydata & Keys.Shift) == Keys.Shift;

		/// 
		/// Gets the key value.
		/// </summary>
		/// The key value.</value>
		public int KeyValue => (int)(menmKeydata & Keys.KeyCode);

		/// 
		/// Gets the key data.
		/// </summary>
		/// The key data.</value>
		public Keys KeyData => menmKeydata;

		/// 
		/// Gets the key code.
		/// </summary>
		/// The key code.</value>
		public Keys KeyCode
		{
			get
			{
				Keys keys = menmKeydata & Keys.KeyCode;
				if (!Enum.IsDefined(typeof(Keys), (int)keys))
				{
					return Keys.None;
				}
				return keys;
			}
		}

		/// 
		/// Gets the modifier flags for a <see cref="E:Gizmox.WebGui.Forms.Control.KeyDown"></see> or <see cref="E:System.Windows.Forms.Control.KeyUp"></see> event. The flags indicate which combination of CTRL, SHIFT, and ALT keys was pressed.
		/// </summary>
		/// The modifiers.</value>
		/// A <see cref="T:System.Windows.Forms.Keys"></see> value representing one or more modifier flags.</returns>
		public Keys Modifiers => menmKeydata & Keys.Modifiers;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> class.
		/// </summary>
		/// <param name="enmKeyData">The enm key data.</param>
		public KeyEventArgs(Keys enmKeyData)
		{
			menmKeydata = enmKeyData;
		}
	}
}

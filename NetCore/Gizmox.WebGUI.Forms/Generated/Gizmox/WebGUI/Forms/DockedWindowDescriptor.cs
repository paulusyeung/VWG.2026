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
	[Serializable]
	internal class DockedWindowDescriptor : DockedObjectDescriptor
	{
		private Type mobjWindowType;

		private string mstrText;

		private string mstrHeaderText;

		private string mstrHeaderToolTip;

		private string mstrTabHeaderToolTip;

		private DockingWindowName mobjWindowName;

		private DockState menmCurrentDockState;

		private DockState menmLastDockState;

		/// 
		/// Gets or sets the text.
		/// </summary>
		/// 
		/// The text.
		/// </value>
		public string Text => mstrText;

		/// 
		/// Gets the type of the window.
		/// </summary>
		/// 
		/// The type of the window.
		/// </value>
		public Type WindowType => mobjWindowType;

		/// 
		/// Gets or sets the state of the current dock.
		/// </summary>
		/// 
		/// The state of the current dock.
		/// </value>
		internal DockState CurrentDockState
		{
			get
			{
				return menmCurrentDockState;
			}
			set
			{
				menmCurrentDockState = value;
			}
		}

		/// 
		/// Gets the name of the window.
		/// </summary>
		/// 
		/// The name of the window.
		/// </value>
		internal DockingWindowName WindowName => mobjWindowName;

		/// 
		/// Gets or sets the header text.
		/// </summary>
		/// 
		/// The header text.
		/// </value>
		public string HeaderText
		{
			get
			{
				return mstrHeaderText;
			}
			set
			{
				mstrHeaderText = value;
			}
		}

		/// 
		/// Gets or sets the header tool tip.
		/// </summary>
		/// 
		/// The header tool tip.
		/// </value>
		public string HeaderToolTip
		{
			get
			{
				return mstrHeaderToolTip;
			}
			set
			{
				mstrHeaderToolTip = value;
			}
		}

		/// 
		/// Gets or sets the tab header tool tip.
		/// </summary>
		/// 
		/// The tab header tool tip.
		/// </value>
		public string TabHeaderToolTip
		{
			get
			{
				return mstrTabHeaderToolTip;
			}
			set
			{
				mstrTabHeaderToolTip = value;
			}
		}

		/// 
		/// Gets or sets the last state of the dock.
		/// </summary>
		/// 
		/// The last state of the dock.
		/// </value>
		public DockState LastDockState
		{
			get
			{
				return menmLastDockState;
			}
			set
			{
				menmLastDockState = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedWindowDescriptor" /> class.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		public DockedWindowDescriptor(DockingWindow objWindow)
		{
			mobjWindowName = new DockingWindowName();
			mobjWindowType = objWindow.GetType();
		}

		/// 
		/// Determines whether this instance [can update from] the specified obj type.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// 
		///   true</c> if this instance [can update from] the specified obj type; otherwise, false</c>.
		/// </returns>
		internal override bool CanUpdateFrom(Type objType)
		{
			if (objType == typeof(DockedTabControl))
			{
				return true;
			}
			return false;
		}

		/// 
		/// Clones the without references.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// </returns>
		internal override T CloneWithoutReferences()
		{
			throw new NotImplementedException();
		}

		/// 
		/// Updates from tab control.
		/// </summary>
		/// <param name="objDockedTabControl">The obj docked tab control.</param>
		/// <param name="blnPreventExtraction">if set to true</c> [BLN prevent extraction].</param>
		internal override void UpdateFromTabControl(DockedTabControl objDockedTabControl, bool blnPreventExtraction)
		{
			if (!blnPreventExtraction)
			{
				objDockedTabControl.OwningZone.Manager.HandleWindowStateChanged(this, objDockedTabControl);
			}
		}

		/// 
		/// Updates the self.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objManager"></param>
		internal override void UpdateSelf(Control objControl, DockingManager objManager)
		{
			if (objControl is DockingWindow dockingWindow)
			{
				mstrText = dockingWindow.Text;
				mobjWindowName.WindowName = dockingWindow.Name;
			}
		}
	}
}

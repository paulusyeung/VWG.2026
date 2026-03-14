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
	[ToolboxItem(false)]
	public class DockedTabPage : TabPage
	{
		private DockingWindow objDockedWindow;

		/// 
		/// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
		/// </summary>
		/// The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
		public override ContextMenuStrip ContextMenuStrip
		{
			get
			{
				if (base.Parent != null && base.Parent.Parent != null)
				{
					return base.Parent.Parent.ContextMenuStrip;
				}
				return base.ContextMenuStrip;
			}
			set
			{
				base.ContextMenuStrip = value;
			}
		}

		/// 
		/// Gets the window.
		/// </summary>
		public DockingWindow Window => objDockedWindow;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabPage" /> class.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		public DockedTabPage(DockingWindow objWindow)
			: base(objWindow.Text)
		{
			base.Image = objWindow.Image;
			base.HeaderToolTip = objWindow.TabHeaderToolTip;
			base.Controls.Add(objWindow);
		}

		/// 
		/// Raises the <see cref="E:ControlAdded" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
			if (e.Control is DockingWindow)
			{
				base.OnControlAdded(e);
				objDockedWindow = e.Control as DockingWindow;
				return;
			}
			throw new Exception();
		}

		/// 
		/// Raises the <see cref="E:ControlRemoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			if (e.Control is DockingWindow)
			{
				base.OnControlRemoved(e);
				base.Parent.Controls.Remove(this);
				return;
			}
			throw new Exception();
		}
	}
}

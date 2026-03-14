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
	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	public class ToolStripRenderEventArgs : EventArgs
	{
		/// Gets the <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted. </summary> 
		/// The <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle AffectedBounds => Rectangle.Empty;

		/// Gets the <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</summary> 
		/// The <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color BackColor => Color.Empty;

		/// Gets the <see cref="T:System.Drawing.Rectangle"></see> representing the overlap area between a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> and its <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.OwnerItem"></see>.</summary> 
		/// The <see cref="T:System.Drawing.Rectangle"></see> representing the overlap area between a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> and its <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.OwnerItem"></see>.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle ConnectedArea => Rectangle.Empty;

		/// Gets the <see cref="T:System.Drawing.Graphics"></see> used to paint.</summary> 
		/// The <see cref="T:System.Drawing.Graphics"></see> used to paint.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Graphics Graphics => null;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be painted.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be painted.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStrip ToolStrip => null;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> and using the specified <see cref="T:System.Drawing.Graphics"></see>. </summary> 
		/// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> to use for painting.</param> 
		/// <param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to paint.</param>
		public ToolStripRenderEventArgs(Graphics g, ToolStrip toolStrip)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, using the specified <see cref="T:System.Drawing.Graphics"></see> to paint the specified bounds with the specified <see cref="T:System.Drawing.Color"></see>.</summary> 
		/// <param name="g">The <see cref="T:System.Drawing.Graphics"></see> to use for painting.</param> 
		/// <param name="backColor">The <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</param> 
		/// <param name="affectedBounds">The <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted.</param> 
		/// <param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to paint.</param>
		public ToolStripRenderEventArgs(Graphics g, ToolStrip toolStrip, Rectangle affectedBounds, Color backColor)
		{
		}
	}
}

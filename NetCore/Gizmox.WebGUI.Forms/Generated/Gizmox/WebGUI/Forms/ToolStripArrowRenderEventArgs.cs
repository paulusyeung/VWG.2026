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
	public class ToolStripArrowRenderEventArgs : EventArgs
	{
		/// Gets or sets the color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary> 
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color of the arrow.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color ArrowColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets the bounding area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that represents the bounding area.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle ArrowRectangle
		{
			get
			{
				return Rectangle.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets the direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow points.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see> values.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ArrowDirection Direction
		{
			get
			{
				return ArrowDirection.Left;
			}
			set
			{
			}
		}

		/// Gets the graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary> 
		/// The <see cref="T:System.Drawing.Graphics"></see> used to paint. </returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Graphics Graphics => null;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to paint the arrow.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripItem Item => null;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> class. </summary> 
		/// <param name="arrowRectangle">The bounding area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param> 
		/// <param name="g">The graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param> 
		/// <param name="arrowDirection">The direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow points.</param> 
		/// <param name="toolStripItem">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to paint the arrow.</param> 
		/// <param name="arrowColor">The color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param>
		public ToolStripArrowRenderEventArgs(Graphics g, ToolStripItem toolStripItem, Rectangle arrowRectangle, Color arrowColor, ArrowDirection arrowDirection)
		{
		}
	}
}

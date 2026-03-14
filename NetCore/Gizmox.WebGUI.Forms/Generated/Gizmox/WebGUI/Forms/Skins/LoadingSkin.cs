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

namespace Gizmox.WebGUI.Forms.Skins
{
/// 
	/// Provides loading customization capabilities
	/// </summary>
	[ToolboxBitmap(typeof(ProgressBar))]
	public class LoadingSkin : CommonSkin
	{
		/// 
		/// Gets the loading panel style.
		/// </summary>
		/// The loading panel style.</value>
		[Category("States")]
		[SRDescription("The loading animation style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue LoadingAnimationStyle => new StyleValue(this, "LoadingAnimationStyle");

		/// 
		/// Gets or sets the loading message horizontal alignment.
		/// </summary>
		/// The loading message horizontal alignment.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HorizontalAlignmentValue MessageHorizontalAlignment
		{
			get
			{
				return GetValue("MessageHorizontalAlignment", new HorizontalAlignmentValue(HorizontalAlignment.Center));
			}
			set
			{
				SetValue("MessageHorizontalAlignment", value);
			}
		}

		/// 
		/// Gets the loading message style.
		/// </summary>
		/// The loading message style.</value>
		[Category("States")]
		[SRDescription("The loading message style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public LoadingMessageStyle LoadingMessageStyle => new LoadingMessageStyle(MessageVerticalAlignment, MessageHorizontalAlignment, MessageStyle);

		/// 
		/// Gets the message style.
		/// </summary>
		/// The message style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue MessageStyle => new StyleValue(this, "MessageStyle");

		/// 
		/// Gets or sets the loading message vertical alignment.
		/// </summary>
		/// The loading message vertical alignment.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public VerticalAlignmentValue MessageVerticalAlignment
		{
			get
			{
				return GetValue("MessageVerticalAlignment", new VerticalAlignmentValue(VerticalAlignment.Center));
			}
			set
			{
				SetValue("MessageVerticalAlignment", value);
			}
		}

		/// 
		/// Gets the web set style function.
		/// </summary>
		/// The web set style function.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public TextResourceReference LoadingAnimationCSS => new TextResourceReference(typeof(LoadingSkin), "LoadingAnimation.css");

		private void InitializeComponent()
		{
		}
	}
}

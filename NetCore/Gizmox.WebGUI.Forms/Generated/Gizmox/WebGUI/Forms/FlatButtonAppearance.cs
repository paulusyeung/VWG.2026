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
/// Provides properties that specify the appearance of <see cref="T:Gizmox.WebGUI.Forms.Button"></see> controls whose <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Flat"></see>.</summary>
	[TypeConverter(typeof(FlatButtonAppearanceConverter))]
	public class FlatButtonAppearance
	{
		/// 
		///
		/// </summary>
		private ButtonBase mobjOwner;

		/// Gets or sets the color of the border around the button.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> structure representing the color of the border around the button.</returns>
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("ButtonBorderColorDescr")]
		public Color BorderColor
		{
			get
			{
				return mobjOwner.BorderColor;
			}
			set
			{
				mobjOwner.BorderColor = value;
			}
		}

		/// Gets or sets a value that specifies the size, in pixels, of the border around the button.</summary>
		/// An <see cref="T:System.Int32"></see> representing the size, in pixels, of the border around the button.</returns>
		[Browsable(true)]
		[DefaultValue(1)]
		[NotifyParentProperty(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("ButtonBorderSizeDescr")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public int BorderSize
		{
			get
			{
				return mobjOwner.BorderWidth;
			}
			set
			{
				mobjOwner.BorderWidth = value;
			}
		}

		/// Gets or sets the color of the client area of the button when the button is checked and the mouse pointer is outside the bounds of the control.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(typeof(Color), "")]
		[NotifyParentProperty(true)]
		[SRDescription("ButtonCheckedBackColorDescr")]
		[Browsable(true)]
		[SRCategory("CatAppearance")]
		public Color CheckedBackColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets the color of the client area of the button when the mouse is pressed within the bounds of the control.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
		[SRCategory("CatAppearance")]
		[DefaultValue(typeof(Color), "")]
		[Browsable(true)]
		[NotifyParentProperty(true)]
		[SRDescription("ButtonMouseDownBackColorDescr")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public Color MouseDownBackColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets the color of the client area of the button when the mouse pointer is within the bounds of the control.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> structure representing the color of the client area of the button.</returns>
		[Browsable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("ButtonMouseOverBackColorDescr")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[NotifyParentProperty(true)]
		[DefaultValue(typeof(Color), "")]
		public Color MouseOverBackColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FlatButtonAppearance" /> class.
		/// </summary>
		/// <param name="objOwner">The owner.</param>
		internal FlatButtonAppearance(ButtonBase objOwner)
		{
			mobjOwner = objOwner;
		}
	}
}

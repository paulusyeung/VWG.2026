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
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ToolboxItem(false)]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class ToolStripDropDownMenu : ToolStripDropDown
	{
		private static readonly SerializableProperty mblnShowCheckMarginProperty = SerializableProperty.Register("mblnShowCheckMargin", typeof(bool), typeof(ToolStripDropDownMenu));

		private static readonly SerializableProperty mblnShowImageMarginProperty = SerializableProperty.Register("mblnShowImageMargin", typeof(bool), typeof(ToolStripDropDownMenu), new SerializablePropertyMetadata(true));

		private bool mblnShowCheckMargin
		{
			get
			{
				return GetValue(mblnShowCheckMarginProperty, objDefault: false);
			}
			set
			{
				SetValue(mblnShowCheckMarginProperty, value);
			}
		}

		private bool mblnShowImageMargin
		{
			get
			{
				return GetValue(mblnShowImageMarginProperty);
			}
			set
			{
				SetValue(mblnShowImageMarginProperty, value);
			}
		}

		/// Gets or sets a value indicating how the items of <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> are displayed.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Flow"></see>.</returns>
		[DefaultValue(ToolStripLayoutStyle.Flow)]
		public new ToolStripLayoutStyle LayoutStyle
		{
			get
			{
				return base.LayoutStyle;
			}
			set
			{
				base.LayoutStyle = value;
			}
		}

		/// Gets or sets a value indicating whether space for a check mark is shown on the left edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>. </summary> 
		/// true if the check margin is shown; otherwise, false. The default is false.</returns> 
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRDescription("ToolStripDropDownMenuShowCheckMarginDescr")]
		[SRCategory("CatAppearance")]
		public bool ShowCheckMargin
		{
			get
			{
				return mblnShowCheckMargin;
			}
			set
			{
				if (mblnShowCheckMargin != value)
				{
					mblnShowCheckMargin = value;
				}
			}
		}

		/// Gets or sets a value indicating whether space for an image is shown on the left edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary> 
		/// true if the image margin is shown; otherwise, false. The default is true.</returns> 
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		[SRDescription("ToolStripDropDownMenuShowImageMarginDescr")]
		public bool ShowImageMargin
		{
			get
			{
				return mblnShowImageMargin;
			}
			set
			{
				if (mblnShowImageMargin != value)
				{
					mblnShowImageMargin = value;
				}
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> class. </summary>
		public ToolStripDropDownMenu()
		{
		}

		/// 
		/// Creates the default item.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		/// <param name="objImage">The obj image.</param>
		/// <param name="objOnClick">The obj on click.</param>
		/// </returns>
		protected internal override ToolStripItem CreateDefaultItem(string strText, ResourceHandle objImage, EventHandler objOnClick)
		{
			if (strText == "-")
			{
				return new ToolStripSeparator();
			}
			return new ToolStripMenuItem(strText, objImage, objOnClick);
		}
	}
}

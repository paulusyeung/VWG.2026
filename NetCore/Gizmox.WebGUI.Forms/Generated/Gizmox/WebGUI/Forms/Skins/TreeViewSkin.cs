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
	/// TreeView Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(TreeView), "TreeView.bmp")]
	public class TreeViewSkin : ControlSkin
	{
		/// Gets or sets a value indicating whether the selection highlight spans the width of the tree view control.</summary>
		/// true if the selection highlight spans the width of the tree view control; otherwise, false. The default is false.</returns>
		[SRCategory("CatBehavior")]
		[SRDescription("TreeViewFullRowSelectDescr")]
		[Browsable(false)]
		public virtual bool FullRowSelect
		{
			get
			{
				return GetValue("FullRowSelect", DefaultFullRowSelect);
			}
			set
			{
				SetValue("FullRowSelect", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual bool DefaultFullRowSelect => false;

		/// 
		/// Gets the tree node normal style.
		/// </summary>
		/// The tree node normal style.</value>
		[Category("States")]
		[Description("The tree node normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue TreeNodeNormalStyle => new StyleValue(this, "TreeNodeNormalStyle");

		/// 
		/// Gets the tree node selected style.
		/// </summary>
		/// The tree node selected style.</value>
		[Category("States")]
		[Description("The tree node selected style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue TreeNodeSelectedStyle => new StyleValue(this, "TreeNodeSelectedStyle", TreeNodeNormalStyle);

		/// 
		/// Gets the height of the check box image.
		/// </summary>
		/// The height of the check box image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CheckBoxImageHeight => GetMaxImageHeight(DefaultCheckBoxImageHeight, "CheckBox0.gif", "CheckBox1.gif");

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultCheckBoxImageHeight => 13;

		/// 
		/// Gets the width of the check box image.
		/// </summary>
		/// The width of the check box image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CheckBoxImageWidth => GetMaxImageWidth(DefaultCheckBoxImageWidth, "CheckBox0.gif", "CheckBox1.gif");

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultCheckBoxImageWidth => 13;

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetFullRowSelect()
		{
			Reset("FullRowSelect");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetCheckBoxImageHeight()
		{
			Reset("CheckBoxImageHeight");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetCheckBoxImageWidth()
		{
			Reset("CheckBoxImageWidth");
		}
	}
}

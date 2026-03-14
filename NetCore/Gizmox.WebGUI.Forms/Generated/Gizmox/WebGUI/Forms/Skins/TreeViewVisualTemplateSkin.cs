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
	///
	/// </summary>
	[Serializable]
	public class TreeViewVisualTemplateSkin : TreeViewSkin
	{
		/// 
		/// Gets the TreeView row style.
		/// </summary>
		/// 
		/// The TreeView row style.
		/// </value>
		public virtual StyleValue TreeViewRowStyle => new StyleValue(this, "TreeViewRowStyle", null);

		/// 
		/// Gets the TreeView visual template back container style.
		/// </summary>
		/// 
		/// The TreeView visual template back container style.
		/// </value>
		public virtual StyleValue TreeViewVisualTemplateBackContainerStyle => new StyleValue(this, "TreeViewVisualTemplateBackContainerStyle", null);

		/// 
		/// Gets the TreeView visual template back button style.
		/// </summary>
		/// 
		/// The TreeView visual template back button style.
		/// </value>
		public virtual StyleValue TreeViewVisualTemplateBackButtonStyle => new StyleValue(this, "TreeViewVisualTemplateBackButtonStyle", null);

		/// 
		/// Gets the TreeView visual template back button style.
		/// </summary>
		/// 
		/// The TreeView visual template back button style.
		/// </value>
		public virtual StyleValue TreeViewVisualTemplateBackButtonDisabledStyle => new StyleValue(this, "TreeViewVisualTemplateBackButtonStyle", null);

		/// 
		/// Gets the TreeView visual template back button style.
		/// </summary>
		/// 
		/// The TreeView visual template back button style.
		/// </value>
		public virtual Size TreeViewVisualTemplateBackButtonSize
		{
			get
			{
				return GetValue("TreeViewVisualTemplateBackButtonSize", new Size(90, DefaultTreeViewNodeHeight));
			}
			set
			{
				SetValue("TreeViewVisualTemplateBackButtonSize", value);
			}
		}

		/// 
		/// Gets the width of the TreeView visual template back button.
		/// </summary>
		/// 
		/// The width of the TreeView visual template back button.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TreeViewVisualTemplateBackButtonWidth => TreeViewVisualTemplateBackButtonSize.Width;

		/// 
		/// Gets the TreeView visual tempalte button text.
		/// </summary>
		/// 
		/// The TreeView visual tempalte button text.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ImageResourceReference TreeViewVisualTempalteButtonImageRTL
		{
			get
			{
				return GetValue("TreeViewVisualTempalteButtonImageRTL", null);
			}
			set
			{
				SetValue("TreeViewVisualTempalteButtonImageRTL", value);
			}
		}

		/// 
		/// Gets or sets the TreeView visual tempalte button image LTR.
		/// </summary>
		/// 
		/// The TreeView visual tempalte button image LTR.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ImageResourceReference TreeViewVisualTempalteButtonImageLTR
		{
			get
			{
				return GetValue("TreeViewVisualTempalteButtonImageLTR", null);
			}
			set
			{
				SetValue("TreeViewVisualTempalteButtonImageLTR", value);
			}
		}

		/// 
		/// Gets the TreeView visual tempalte button image.
		/// </summary>
		/// 
		/// The TreeView visual tempalte button image.
		/// </value>
		public BidirectionalSkinProperty<object> TreeViewVisualTempalteButtonImage => new BidirectionalSkinProperty<object>(this, "TreeViewVisualTempalteButtonImageLTR", "TreeViewVisualTempalteButtonImageRTL");

		/// 
		/// Gets the height of the TreeView visual template back button.
		/// </summary>
		/// 
		/// The height of the TreeView visual template back button.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TreeViewVisualTemplateBackButtonHeight => TreeViewVisualTemplateBackButtonSize.Height;

		/// 
		/// Gets or sets the TreeView visual template next LTR.
		/// </summary>
		/// 
		/// The TreeView visual template next LTR.
		/// </value>
		public virtual ImageResourceReference TreeViewVisualTemplateNextLTR
		{
			get
			{
				return GetValue("TreeViewVisualTemplateNextLTR", null);
			}
			set
			{
				SetValue("TreeViewVisualTemplateNextLTR", value);
			}
		}

		/// 
		/// Gets or sets the TreeView visual template next RTL.
		/// </summary>
		/// 
		/// The TreeView visual template next RTL.
		/// </value>
		public virtual ImageResourceReference TreeViewVisualTemplateNextRTL
		{
			get
			{
				return GetValue("TreeViewVisualTemplateNextRTL", null);
			}
			set
			{
				SetValue("TreeViewVisualTemplateNextRTL", value);
			}
		}

		/// 
		/// Gets the TreeView visual template next.
		/// </summary>
		/// 
		/// The TreeView visual template next.
		/// </value>
		public BidirectionalSkinProperty<object> TreeViewVisualTemplateNext => new BidirectionalSkinProperty<object>(this, "TreeViewVisualTemplateNextLTR", "TreeViewVisualTemplateNextRTL");

		/// 
		/// Gets or sets the TreeView visual template next witdh.
		/// </summary>
		/// 
		/// The TreeView visual template next witdh.
		/// </value>
		public virtual int TreeViewVisualTemplateNextWidth
		{
			get
			{
				return GetValue("TreeViewVisualTemplateNextWidth", GetImageWidth(TreeViewVisualTemplateNextLTR, DefaultTreeViewNodeNextWidth));
			}
			set
			{
				SetValue("TreeViewVisualTemplateNextWidth", value);
			}
		}

		/// 
		/// Gets the default width of the TreeView node next.
		/// </summary>
		/// 
		/// The default width of the TreeView node next.
		/// </value>
		public int DefaultTreeViewNodeNextWidth => 19;

		/// 
		/// Gets or sets the height of the TreeView node.
		/// </summary>
		/// 
		/// The height of the TreeView node.
		/// </value>
		public virtual int TreeViewNodeHeight
		{
			get
			{
				return GetValue("TreeViewNodeHeight", DefaultTreeViewNodeHeight);
			}
			set
			{
				SetValue("TreeViewNodeHeight", value);
			}
		}

		/// 
		/// Gets the default height of the TreeView node.
		/// </summary>
		/// 
		/// The default height of the TreeView node.
		/// </value>
		protected internal virtual int DefaultTreeViewNodeHeight => 32;

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the width of the TreeView visual template next.
		/// </summary>
		private void ResetTreeViewVisualTemplateNextWidth()
		{
			Reset("TreeViewVisualTemplateNextWidth");
		}

		/// 
		/// Resets the height of the TreeView node.
		/// </summary>
		private void ResetTreeViewNodeHeight()
		{
			Reset("TreeViewNodeHeight");
		}
	}
}

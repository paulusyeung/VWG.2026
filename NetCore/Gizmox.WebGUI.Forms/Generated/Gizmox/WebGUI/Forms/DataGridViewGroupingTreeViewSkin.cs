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
	/// Summary description for GroupingTreeViewSkin
	/// </summary>   
	[Serializable]
	[SkinContainer(typeof(DataGridViewSkin))]
	public class DataGridViewGroupingTreeViewSkin : TreeViewSkin
	{
		/// 
		/// Gets the node close button style.
		/// </summary>
		[SRCategory("Styles")]
		[SRDescription("Grouping TreeNode Close button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue TreeNodeCloseButtonStyle => new StyleValue(this, "TreeNodeCloseButtonStyle");

		/// 
		/// Gets the node joint style.
		/// </summary>
		[SRCategory("Styles")]
		[SRDescription("Grouping TreeNode joint style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue TreeNodeJointStyle => new StyleValue(this, "TreeNodeJointStyle");

		/// 
		/// Gets or sets the height of the tree node.
		/// </summary>
		/// 
		/// The height of the tree node.
		/// </value>
		[SRCategory("Sizes")]
		[SRDescription("Grouping TreeNode height in pixels.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual int TreeNodeHeight
		{
			get
			{
				return GetValue("TreeNodeHeight", 18);
			}
			set
			{
				SetValue("TreeNodeHeight", value);
			}
		}

		/// 
		/// Gets the width of the node close button.
		/// </summary>
		/// 
		/// The width of the node close button.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int TreeNodeCloseButtonWidth => GetImageWidth(TreeNodeCloseButtonStyle.BackgroundImage);

		/// 
		/// Gets the width of the tree node joint image.
		/// </summary>
		/// 
		/// The width of the tree node joint image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int TreeNodeJointImageWidth => Math.Max(GetImageWidth(TreeNodeJointLTRImage), GetImageWidth(TreeNodeJointRTLImage));

		/// 
		/// Gets the height of the tree node joint image.
		/// </summary>
		/// 
		/// The height of the tree node joint image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int TreeNodeJointImageHeight => Math.Max(GetImageHeight(TreeNodeJointLTRImage), GetImageHeight(TreeNodeJointRTLImage));

		/// 
		/// Gets or sets the height of top indicator placeholder.
		/// </summary>
		/// 
		/// The height of top indicator placeholder.
		/// </value>
		[SRCategory("Sizes")]
		[SRDescription("Grouping Area top indicator placeholder height in pixels.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual int TopNodePlaceHolderHeight
		{
			get
			{
				return GetValue("TopNodePlaceHolderHeight", 5);
			}
			set
			{
				SetValue("TopNodePlaceHolderHeight", value);
			}
		}

		/// 
		/// Gets the height of the node close button.
		/// </summary>
		/// 
		/// The height of the node close button.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int TreeNodeCloseButtonHeight => GetImageHeight(TreeNodeCloseButtonStyle.BackgroundImage);

		/// 
		/// Gets or sets the tree node padding top.
		/// </summary>
		/// 
		/// The tree node padding top.
		/// </value>
		[SRDescription("The tree node top padding.")]
		[SRCategory("Images")]
		public virtual int TreeNodePaddingTop
		{
			get
			{
				return GetValue("TreeNodePaddingTop", (TreeNodeJointImageHeight - TreeNodeHeight) / 2);
			}
			set
			{
				SetValue("TreeNodePaddingTop", value);
			}
		}

		/// 
		/// Gets or sets the node joint LTR image.
		/// </summary>
		/// 
		/// The node joint LTR image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference TreeNodeJointLTRImage
		{
			get
			{
				return GetValue("TreeNodeJointLTRImage", new ImageResourceReference(typeof(DataGridViewGroupingTreeViewSkin), "GroupingTreeNodeJointLTR.gif"));
			}
			set
			{
				SetValue("TreeNodeJointLTRImage", value);
			}
		}

		/// 
		/// Gets or sets the node joint RTL image.
		/// </summary>
		/// 
		/// The node joint RTL image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference TreeNodeJointRTLImage
		{
			get
			{
				return GetValue("TreeNodeJointRTLImage", new ImageResourceReference(typeof(DataGridViewGroupingTreeViewSkin), "GroupingTreeNodeJointRTL.gif"));
			}
			set
			{
				SetValue("TreeNodeJointRTLImage", value);
			}
		}

		/// 
		/// Gets the tree node joint image.
		/// </summary>
		[SRDescription("The node joint image.")]
		[SRCategory("Images")]
		public virtual BidirectionalSkinProperty<object> TreeNodeJointImage => new BidirectionalSkinProperty<object>(this, "TreeNodeJointLTRImage", "TreeNodeJointRTLImage");

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the node joint LTR image.
		/// </summary>
		private void ResetNodeJointLTRImage()
		{
			Reset("TreeNodeJointLTRImage");
		}

		/// 
		/// Resets the node joint RTL image.
		/// </summary>
		private void ResetNodeJointRTLImage()
		{
			Reset("TreeNodeJointRTLImage");
		}
	}
}

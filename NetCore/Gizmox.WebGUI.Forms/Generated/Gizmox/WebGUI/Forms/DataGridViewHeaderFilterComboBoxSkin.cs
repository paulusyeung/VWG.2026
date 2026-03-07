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
	/// DataGridViewHeaderFilterComboBox Skin
	/// </summary>
	[Serializable]
	[SkinContainer(typeof(DataGridViewSkin))]
	public class DataGridViewHeaderFilterComboBoxSkin : ComboBoxSkin
	{
		/// 
		/// Gets the filter normal image.
		/// </summary>
		[Category("Images")]
		[Description("The Filter image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> FilterNormalImage => new BidirectionalSkinProperty<object>(this, "FilterNormalImageLTR", "FilterNormalImageRTL");

		/// 
		/// Gets or sets the filter normal image LTR.
		/// </summary>
		/// 
		/// The filter normal image LTR.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference FilterNormalImageLTR
		{
			get
			{
				return GetValue("FilterNormalImageLTR", new ImageResourceReference(typeof(DataGridViewHeaderFilterComboBoxSkin), "Filter.png"));
			}
			set
			{
				SetValue("FilterNormalImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the filter normal image RTL.
		/// </summary>
		/// 
		/// The filter normal image RTL.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference FilterNormalImageRTL
		{
			get
			{
				return GetValue("FilterNormalImageRTL", FilterNormalImageLTR);
			}
			set
			{
				SetValue("FilterNormalImageRTL", value);
			}
		}

		/// 
		/// Gets the filter hover image.
		/// </summary>
		[Category("Images")]
		[Description("The filter image while mouse hover.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> FilterHoverImage => new BidirectionalSkinProperty<object>(this, "FilterHoverImageLTR", "FilterHoverImageRTL");

		/// 
		/// Gets or sets the filter hover image LTR.
		/// </summary>
		/// 
		/// The filter hover image LTR.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference FilterHoverImageLTR
		{
			get
			{
				return GetValue("FilterHoverImageLTR", new ImageResourceReference(typeof(DataGridViewHeaderFilterComboBoxSkin), "FilterHover.png"));
			}
			set
			{
				SetValue("FilterHoverImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the filter hover image RTL.
		/// </summary>
		/// 
		/// The filter hover image RTL.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference FilterHoverImageRTL
		{
			get
			{
				return GetValue("FilterHoverImageRTL", FilterHoverImageLTR);
			}
			set
			{
				SetValue("FilterHoverImageRTL", value);
			}
		}

		/// 
		/// Gets the filter normal image.
		/// </summary>
		[Category("Images")]
		[Description("THe Filter image while mouse down.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> FilterDownImage => new BidirectionalSkinProperty<object>(this, "FilterDownImageLTR", "FilterDownImageRTL");

		/// 
		/// Gets or sets the filter down image LTR.
		/// </summary>
		/// 
		/// The filter down image LTR.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference FilterDownImageLTR
		{
			get
			{
				return GetValue("FilterDownImageLTR", new ImageResourceReference(typeof(DataGridViewHeaderFilterComboBoxSkin), "FilterDown.png"));
			}
			set
			{
				SetValue("FilterDownImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the filter down image RTL.
		/// </summary>
		/// 
		/// The filter down image RTL.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference FilterDownImageRTL
		{
			get
			{
				return GetValue("FilterDownImageRTL", FilterDownImageLTR);
			}
			set
			{
				SetValue("FilterDownImageRTL", value);
			}
		}

		/// 
		/// Gets the width of the filter normal image.
		/// </summary>
		/// 
		/// The width of the filter normal image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual SkinValue FilterNormalImageWidth => new BidirectionalSkinValue<object>(this, FilterNormalImageWidthLTR, FilterNormalImageWidthRTL);

		/// 
		/// Gets the filter normal image width RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FilterNormalImageWidthRTL => GetImageWidth(FilterNormalImageRTL);

		/// 
		/// Gets the filter normal image width LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FilterNormalImageWidthLTR => GetImageWidth(FilterNormalImageLTR);

		/// 
		/// Gets the drop down width spaceer.
		/// </summary>
		[Category("Sizes")]
		[SRDescription("This value will be added to the longest item width.")]
		public virtual int DropDownWidthSpacer
		{
			get
			{
				return GetValue("DropDownWidthSpacer", 25);
			}
			set
			{
				SetValue("DropDownWidthSpacer", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the filter normal image.
		/// </summary>
		private void ResetFilterNormalImage()
		{
			Reset("FilterNormalImage");
		}

		/// 
		/// Resets the filter hover image.
		/// </summary>
		private void ResetFilterHoverImage()
		{
			Reset("FilterHoverImage");
		}

		/// 
		/// Resets the filter normal image.
		/// </summary>
		private void ResetFilterDownImage()
		{
			Reset("FilterDownImage");
		}

		/// 
		/// Resets the drop down width spacer.
		/// </summary>
		internal void ResetDropDownWidthSpacer()
		{
			Reset("DropDownWidthSpacer");
		}
	}
}

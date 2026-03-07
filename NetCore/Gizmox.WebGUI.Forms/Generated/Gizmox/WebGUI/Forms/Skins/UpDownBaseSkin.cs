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
	/// UpDown Base Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(DomainUpDown), "DomainUpDown.bmp")]
	public class UpDownBaseSkin : ControlSkin
	{
		/// 
		/// Gets the buttons' normal container style.
		/// </summary>
		[Category("States")]
		[SRDescription("The buttons normal container style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> ButtonsContainerNormalStyle => new BidirectionalSkinValue<object>(this, ButtonsContainerNormalStyleLTR, ButtonsContainerNormalStyleRTL);

		/// 
		/// Gets the buttons container normal style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ButtonsContainerNormalStyleLTR => new StyleValue(this, "ButtonsContainerNormalStyleLTR");

		/// 
		/// Gets the buttons container normal style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ButtonsContainerNormalStyleRTL => new StyleValue(this, "ButtonsContainerNormalStyleRTL");

		/// 
		/// Gets The buttons hover container style.
		/// </summary>
		[Category("States")]
		[SRDescription("The buttons hover container style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> ButtonsContainerHoverStyle => new BidirectionalSkinValue<object>(this, ButtonsContainerHoverStyleLTR, ButtonsContainerHoverStyleRTL);

		/// 
		/// Gets the buttons container hover style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ButtonsContainerHoverStyleLTR => new StyleValue(this, "ButtonsContainerHoverStyleLTR");

		/// 
		/// Gets the buttons container hover style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ButtonsContainerHoverStyleRTL => new StyleValue(this, "ButtonsContainerHoverStyleRTL");

		/// 
		/// Gets The buttons pressed container style.
		/// </summary>
		[Category("States")]
		[SRDescription("The buttons pressed container style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> ButtonsContainerPressedStyle => new BidirectionalSkinValue<object>(this, ButtonsContainerPressedStyleLTR, ButtonsContainerPressedStyleRTL);

		/// 
		/// Gets the buttons container pressed style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ButtonsContainerPressedStyleLTR => new StyleValue(this, "ButtonsContainerPressedStyleLTR");

		/// 
		/// Gets the buttons container pressed style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ButtonsContainerPressedStyleRTL => new StyleValue(this, "ButtonsContainerPressedStyleRTL");

		/// 
		/// Gets down normal style.
		/// </summary>
		/// Down normal style.</value>
		[SRCategory("States")]
		[SRDescription("Lower image Normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue DownNormalStyle => new StyleValue(this, "DownNormalStyle");

		/// 
		/// Gets down over style.
		/// </summary>
		/// Down over style.</value>
		[SRCategory("States")]
		[SRDescription("Lower image Over style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue DownOverStyle => new StyleValue(this, "DownOverStyle", DownNormalStyle);

		/// 
		/// Gets down down style.
		/// </summary>
		/// Down down style.</value>
		[SRCategory("States")]
		[SRDescription("Lower image Down style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue DownDownStyle => new StyleValue(this, "DownDownStyle", DownNormalStyle);

		/// 
		/// Gets up normal style.
		/// </summary>
		/// Up normal style.</value>
		[SRCategory("States")]
		[SRDescription("Upper image Normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue UpNormalStyle => new StyleValue(this, "UpNormalStyle");

		/// 
		/// Gets up over style.
		/// </summary>
		/// Up over style.</value>
		[SRCategory("States")]
		[SRDescription("Upper image Over style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue UpOverStyle => new StyleValue(this, "UpOverStyle", UpNormalStyle);

		/// 
		/// Gets up down style.
		/// </summary>
		/// Up down style.</value>
		[SRCategory("States")]
		[SRDescription("Upper image down style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue UpDownStyle => new StyleValue(this, "UpDownStyle", UpNormalStyle);

		/// 
		/// Gets or sets the width of the image cell.
		/// </summary>
		/// The width of the image cell.</value>
		[SRCategory("Sizes")]
		[SRDescription("The image cell width.")]
		public int ImageCellWidth
		{
			get
			{
				return GetValue("ImageCellWidth", 15);
			}
			set
			{
				SetValue("ImageCellWidth", value);
			}
		}

		private void InitializeComponent()
		{
		}
	}
}

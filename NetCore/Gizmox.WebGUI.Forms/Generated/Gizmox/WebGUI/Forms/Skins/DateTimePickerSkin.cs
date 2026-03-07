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
	/// DateTimePicker Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(DateTimePicker), "Button.bmp")]
	public class DateTimePickerSkin : ControlSkin
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
		/// Gets the input value style.
		/// </summary>
		/// The input value style.</value>
		[SRCategory("States")]
		[SRDescription("The input value style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue InputValueStyle => new StyleValue(this, "InputValueStyle");

		/// 
		/// Gets or sets the width of up down icon container.
		/// </summary>
		/// The width of up down icon container.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int UpDownIconContainerWidth => GetImageWidth(UpDownDownNormalImage, DefaultUpDownIconContainerWidth);

		/// 
		/// Gets the default width of up down icon container.
		/// </summary>
		/// The default width of up down icon container.</value>
		protected virtual int DefaultUpDownIconContainerWidth => 16;

		/// 
		/// Gets or sets the width of up down icon.
		/// </summary>
		/// The width of up down icon.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int UpDownIconWidth => GetImageWidth(UpDownUpNormalImage, DefaultUpDownIconWidth);

		/// 
		/// Gets the default width of up down icon.
		/// </summary>
		/// The default width of up down icon.</value>
		protected virtual int DefaultUpDownIconWidth => 15;

		/// 
		/// Gets or sets the height of up icon.
		/// </summary>
		/// The height of up icon.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int UpIconHeight => GetImageHeight(UpDownUpNormalImage, DefaultUpIconHeight);

		/// 
		/// Gets the default height of up  icon.
		/// </summary>
		/// The default height of up  icon.</value>
		protected virtual int DefaultUpIconHeight => 8;

		/// 
		/// Gets or sets the height of down icon.
		/// </summary>
		/// The height of down icon.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DownIconHeight => GetImageHeight(UpDownDownNormalImage, DefaultDownIconHeight);

		/// 
		/// Gets the default height of up down icon.
		/// </summary>
		/// The default height of up down icon.</value>
		protected virtual int DefaultDownIconHeight => 9;

		/// 
		/// Gets or sets the width of the drop down icon container.
		/// </summary>
		/// The width of the drop down icon container.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DropDownIconContainerWidth => GetImageWidth(DropDownNormalImage, DefaultDropDownIconContainerWidth);

		/// 
		/// Gets the default width of the drop down icon container.
		/// </summary>
		/// The default width of the drop down icon container.</value>
		protected virtual int DefaultDropDownIconContainerWidth => 17;

		/// 
		/// Gets or sets the width of the check box icon container.
		/// </summary>
		/// The width of the check box icon container.</value>
		[SRCategory("Sizes")]
		[SRDescription("The check box icon container width.")]
		public virtual int CheckBoxIconContainerWidth
		{
			get
			{
				return GetValue("CheckBoxIconContainerWidth", DefaultCheckBoxIconContainerWidth);
			}
			set
			{
				SetValue("CheckBoxIconContainerWidth", value);
			}
		}

		/// 
		/// The picker drop down size
		/// </summary>
		[SRCategory("Sizes")]
		[SRDescription("The picker drop down size.")]
		public Size DropDownSize
		{
			get
			{
				return GetValue("DropDownSize", Size.Empty);
			}
			set
			{
				SetValue("DropDownSize", value);
			}
		}

		/// 
		/// Gets the default width of the check box icon container.
		/// </summary>
		/// The default width of the check box icon container.</value>
		protected virtual int DefaultCheckBoxIconContainerWidth => 20;

		/// 
		/// Gets or sets the width of the check box icon.
		/// </summary>
		/// The width of the check box icon.</value>
		[SRCategory("Sizes")]
		[SRDescription("The check box icon width.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CheckBoxIconWidth => GetMaxImageWidth(DefaultCheckBoxIconWidth, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

		/// 
		/// Gets the default width of the check box icon.
		/// </summary>
		/// The default width of the check box icon.</value>
		protected virtual int DefaultCheckBoxIconWidth => 15;

		/// 
		/// Gets or sets the height of the check box icon.
		/// </summary>
		/// The height of the check box icon.</value>
		[SRCategory("Sizes")]
		[SRDescription("The check box icon height.")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CheckBoxIconHeight => GetMaxImageHeight(DefaultCheckBoxIconHeight, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

		/// 
		/// Gets the default height of the check box icon.
		/// </summary>
		/// The default height of the check box icon.</value>
		protected virtual int DefaultCheckBoxIconHeight => 15;

		/// 
		/// Gets or sets up down up over image.
		/// </summary>
		/// Up down up over image.</value>
		[SRDescription("UpDown up over image")]
		[SRCategory("Images")]
		public ImageResourceReference UpDownUpOverImage
		{
			get
			{
				return GetValue("UpDownUpOverImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownUpOver.gif"));
			}
			set
			{
				SetValue("UpDownUpOverImage", value);
			}
		}

		/// 
		/// Gets or sets up down up normal image.
		/// </summary>
		/// Up down up normal image.</value>
		[SRDescription("UpDown up normal image")]
		[SRCategory("Images")]
		public ImageResourceReference UpDownUpNormalImage
		{
			get
			{
				return GetValue("UpDownUpNormalImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownUpNormal.gif"));
			}
			set
			{
				SetValue("UpDownUpNormalImage", value);
			}
		}

		/// 
		/// Gets or sets up down up down image.
		/// </summary>
		/// Up down up down image.</value>
		[SRDescription("UpDown up down image")]
		[SRCategory("Images")]
		public ImageResourceReference UpDownUpDownImage
		{
			get
			{
				return GetValue("UpDownUpDownImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownUpDown.gif"));
			}
			set
			{
				SetValue("UpDownUpDownImage", value);
			}
		}

		/// 
		/// Gets or sets up down down over image.
		/// </summary>
		/// Up down down over image.</value>
		[SRDescription("UpDown down over image")]
		[SRCategory("Images")]
		public ImageResourceReference UpDownDownOverImage
		{
			get
			{
				return GetValue("UpDownDownOverImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownDownOver.gif"));
			}
			set
			{
				SetValue("UpDownDownOverImage", value);
			}
		}

		/// 
		/// Gets or sets up down down normal image.
		/// </summary>
		/// Up down down normal image.</value>
		[SRDescription("UpDown down normal image")]
		[SRCategory("CatAppearance")]
		public ImageResourceReference UpDownDownNormalImage
		{
			get
			{
				return GetValue("UpDownDownNormalImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownDownNormal.gif"));
			}
			set
			{
				SetValue("UpDownDownNormalImage", value);
			}
		}

		/// 
		/// Gets or sets up down down down image.
		/// </summary>
		/// Up down down down image.</value>
		[SRDescription("UpDown down down image")]
		[SRCategory("Images")]
		public ImageResourceReference UpDownDownDownImage
		{
			get
			{
				return GetValue("UpDownDownDownImage", new ImageResourceReference(typeof(DateTimePickerSkin), "UpDownDownDown.gif"));
			}
			set
			{
				SetValue("UpDownDownDownImage", value);
			}
		}

		/// 
		/// Gets or sets the drop down normal image.
		/// </summary>
		/// The drop down normal image.</value>
		[SRDescription("Drop down normal image")]
		[SRCategory("Images")]
		public ImageResourceReference DropDownNormalImage
		{
			get
			{
				return GetValue("DropDownNormalImage", new ImageResourceReference(typeof(DateTimePickerSkin), "DropDownNormal.gif"));
			}
			set
			{
				SetValue("DropDownNormalImage", value);
			}
		}

		/// 
		/// Gets or sets the drop down over image.
		/// </summary>
		/// The drop down over image.</value>
		[SRDescription("Drop down over image")]
		[SRCategory("Images")]
		public ImageResourceReference DropDownOverImage
		{
			get
			{
				return GetValue("DropDownOverImage", new ImageResourceReference(typeof(DateTimePickerSkin), "DropDownOver.gif"));
			}
			set
			{
				SetValue("DropDownOverImage", value);
			}
		}

		/// 
		/// Gets or sets the drop down down image.
		/// </summary>
		/// The drop down down image.</value>
		[SRDescription("Drop down down image")]
		[SRCategory("Images")]
		public ImageResourceReference DropDownDownImage
		{
			get
			{
				return GetValue("DropDownDownImage", new ImageResourceReference(typeof(DateTimePickerSkin), "DropDownDown.gif"));
			}
			set
			{
				SetValue("DropDownDownImage", value);
			}
		}

		/// 
		/// Gets or sets the checked check box image.
		/// </summary>
		/// The checked check box image.</value>
		[SRDescription("The checked checkbox image.")]
		[SRCategory("Images")]
		public ImageResourceReference CheckedCheckBoxImage
		{
			get
			{
				return GetValue("CheckedCheckBoxImage", new ImageResourceReference(typeof(DateTimePickerSkin), "CheckBox1.gif"));
			}
			set
			{
				SetValue("CheckedCheckBoxImage", value);
			}
		}

		/// 
		/// Gets or sets the un checked check box image.
		/// </summary>
		/// The un checked check box image.</value>
		[SRDescription("The unchecked checkbox image.")]
		[SRCategory("Images")]
		public ImageResourceReference UnCheckedCheckBoxImage
		{
			get
			{
				return GetValue("UnCheckedCheckBoxImage", new ImageResourceReference(typeof(DateTimePickerSkin), "CheckBox0.gif"));
			}
			set
			{
				SetValue("UnCheckedCheckBoxImage", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the width of up down icon container.
		/// </summary>
		private void ResetUpDownIconContainerWidth()
		{
			Reset("UpDownIconContainerWidth");
		}

		/// 
		/// Resets the width of the drop down icon container.
		/// </summary>
		private void ResetDropDownIconContainerWidth()
		{
			Reset("DropDownIconContainerWidth");
		}

		/// 
		/// Resets the width of the check box icon container.
		/// </summary>
		private void ResetCheckBoxIconContainerWidth()
		{
			Reset("CheckBoxIconContainerWidth");
		}

		/// 
		/// Resets up down up over image.
		/// </summary>
		private void ResetUpDownUpOverImage()
		{
			Reset("UpDownUpOverImage");
		}

		/// 
		/// Resets up down up normal image.
		/// </summary>
		private void ResetUpDownUpNormalImage()
		{
			Reset("UpDownUpNormalImage");
		}

		/// 
		/// Resets up down up down image.
		/// </summary>
		private void ResetUpDownUpDownImage()
		{
			Reset("UpDownUpDownImage");
		}

		/// 
		/// Resets up down down over image.
		/// </summary>
		private void ResetUpDownDownOverImage()
		{
			Reset("UpDownDownOverImage");
		}

		/// 
		/// Resets up down down normal image.
		/// </summary>
		private void ResetUpDownDownNormalImage()
		{
			Reset("UpDownDownNormalImage");
		}

		/// 
		/// Resets up down down down image.
		/// </summary>
		private void ResetUpDownDownDownImage()
		{
			Reset("UpDownDownDownImage");
		}

		/// 
		/// Resets the drop down normal image.
		/// </summary>
		private void ResetDropDownNormalImage()
		{
			Reset("DropDownNormalImage");
		}

		/// 
		/// Resets the drop down over image.
		/// </summary>
		private void ResetDropDownOverImage()
		{
			Reset("DropDownOverImage");
		}

		/// 
		/// Resets the drop down down image.
		/// </summary>
		private void ResetDropDownDownImage()
		{
			Reset("DropDownDownImage");
		}

		/// 
		/// Resets the checked check box image.
		/// </summary>
		private void ResetCheckedCheckBoxImage()
		{
			Reset("CheckedCheckBoxImage");
		}

		/// 
		/// Resets the un checked check box image.
		/// </summary>
		private void ResetUnCheckedCheckBoxImage()
		{
			Reset("UnCheckedCheckBoxImage");
		}
	}
}

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
	/// ComboBox Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(ComboBox), "ComboBox.bmp")]
	public class ComboBoxSkin : ControlSkin
	{
		/// 
		/// Gets the data container style.
		/// </summary>
		[Category("States")]
		[SRDescription("ComboBox ListBox section style.")]
		public virtual BidirectionalSkinValue<object> ItemsContainerStyle => new BidirectionalSkinValue<object>(this, ListBoxContainerStyleLTR, ListBoxContainerStyleRTL);

		/// 
		/// Gets the data container style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ListBoxContainerStyleLTR => new StyleValue(this, "ListBoxContainerStyleLTR");

		/// 
		/// Gets the data container style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ListBoxContainerStyleRTL => new StyleValue(this, "ListBoxContainerStyleRTL");

		/// 
		/// Gets the data container style.
		/// </summary>
		[Category("States")]
		[SRDescription("ComboBox Data section style.")]
		public virtual BidirectionalSkinValue<object> DataContainerDropDownListModeStyle => new BidirectionalSkinValue<object>(this, DataContainerDropDownListModeStyleLTR, DataContainerDropDownListModeStyleRTL);

		/// 
		/// Gets the data container style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DataContainerDropDownListModeStyleLTR => new StyleValue(this, "DataContainerDropDownListModeStyleLTR");

		/// 
		/// Gets the data container style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DataContainerDropDownListModeStyleRTL => new StyleValue(this, "DataContainerDropDownListModeStyleRTL");

		/// 
		/// Gets the data container style.
		/// </summary>
		[Category("States")]
		[SRDescription("ComboBox Data section style.")]
		public virtual BidirectionalSkinValue<object> DataContainerDropDownModeStyle => new BidirectionalSkinValue<object>(this, DataContainerDropDownModeStyleLTR, DataContainerDropDownModeStyleRTL);

		/// 
		/// Gets the data container style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DataContainerDropDownModeStyleLTR => new StyleValue(this, "DataContainerDropDownModeStyleLTR");

		/// 
		/// Gets the data container style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DataContainerDropDownModeStyleRTL => new StyleValue(this, "DataContainerDropDownModeStyleRTL");

		/// 
		/// Gets the data container style.
		/// </summary>
		[Category("States")]
		[SRDescription("ComboBox Data section style in Simple mode.")]
		public virtual BidirectionalSkinValue<object> DataContainerSimpleModeStyle => new BidirectionalSkinValue<object>(this, DataContainerSimpleModeStyleLTR, DataContainerSimpleModeStyleRTL);

		/// 
		/// Gets the data container style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DataContainerSimpleModeStyleLTR => new StyleValue(this, "DataContainerSimpleModeStyleLTR");

		/// 
		/// Gets the data container style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DataContainerSimpleModeStyleRTL => new StyleValue(this, "DataContainerSimpleModeStyleRTL");

		/// 
		/// Gets the drop down normal image container.
		/// </summary>
		[Category("States")]
		[SRDescription("The drop down image container.")]
		public virtual BidirectionalSkinValue<object> DropDownContainerNormalStyle => new BidirectionalSkinValue<object>(this, DropDownContainerNormalStyleLTR, DropDownContainerNormalStyleRTL);

		/// 
		/// Gets the drop down container normal style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DropDownContainerNormalStyleLTR => new StyleValue(this, "DropDownContainerNormalStyleLTR");

		/// 
		/// Gets the drop down container normal style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DropDownContainerNormalStyleRTL => new StyleValue(this, "DropDownContainerNormalStyleRTL");

		/// 
		/// Gets the drop down normal image container.
		/// </summary>
		[Category("States")]
		[SRDescription("The drop down image container hover.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DropDownContainerHoverStyle => new BidirectionalSkinValue<object>(this, DropDownContainerHoverStyleLTR, DropDownContainerHoverStyleRTL);

		/// 
		/// Gets the drop down container normal style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("States")]
		[SRDescription("The drop down image container.")]
		public virtual StyleValue DropDownContainerHoverStyleLTR => new StyleValue(this, "DropDownContainerHoverStyleLTR");

		/// 
		/// Gets the drop down container normal style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("States")]
		[SRDescription("The drop down image container.")]
		public virtual StyleValue DropDownContainerHoverStyleRTL => new StyleValue(this, "DropDownContainerHoverStyleRTL");

		/// 
		/// Gets the drop down normal image container.
		/// </summary>
		[Category("States")]
		[SRDescription("The drop down image container down.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DropDownContainerPressedStyle => new BidirectionalSkinValue<object>(this, DropDownContainerPressedStyleLTR, DropDownContainerPressedStyleRTL);

		/// 
		/// Gets the drop down container normal style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("States")]
		[SRDescription("The drop down image container.")]
		public virtual StyleValue DropDownContainerPressedStyleLTR => new StyleValue(this, "DropDownContainerPressedStyleLTR");

		/// 
		/// Gets the drop down container normal style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DropDownContainerPressedStyleRTL => new StyleValue(this, "DropDownContainerPressedStyleRTL");

		/// 
		/// Gets the drop down normal image container.
		/// </summary>
		[Category("States")]
		[SRDescription("The drop down image container disabled.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DropDownContainerDisabledStyle => new BidirectionalSkinValue<object>(this, DropDownContainerDisabledStyleLTR, DropDownContainerDisabledStyleRTL);

		/// 
		/// Gets the drop down container normal style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DropDownContainerDisabledStyleLTR => new StyleValue(this, "DropDownContainerDisabledStyleLTR");

		/// 
		/// Gets the drop down container normal style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DropDownContainerDisabledStyleRTL => new StyleValue(this, "DropDownContainerDisabledStyleRTL");

		/// 
		/// Gets the pop up body style.
		/// </summary>
		/// The pop up body style.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual StyleValue PopupBodyStyle => new StyleValue(this, "PopupBodyStyle");

		/// 
		/// Gets the pop up item style.
		/// </summary>
		/// The pop up item style.</value>
		[Category("States")]
		[SRDescription("The popup item style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PopupItemStyle => new StyleValue(this, "PopupItemStyle");

		/// 
		/// Gets the pop up item enter style.
		/// </summary>
		/// The pop up item enter style.</value>
		[Category("States")]
		[SRDescription("The popup item enter style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PopupItemEnterStyle => new StyleValue(this, "PopupItemEnterStyle", PopupItemStyle);

		/// 
		/// Gets the color of the popup item enter fore.
		/// </summary>
		/// The color of the popup item enter fore.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual Color PopupItemEnterForeColor => PopupItemEnterStyle.ForeColor;

		/// 
		/// Gets the pop up item selected style.
		/// </summary>
		/// The pop up item selected style.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual StyleValue PopupItemSelectedStyle => new StyleValue(this, "PopupItemSelectedStyle", PopupItemStyle);

		/// 
		/// Gets the pop up item down style.
		/// </summary>
		/// The pop up item down style.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual StyleValue PopupItemDownStyle => new StyleValue(this, "PopupItemDownStyle", PopupItemStyle);

		/// 
		/// Gets the selected popup item.
		/// </summary>
		/// The selected popup item.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual StyleValue SelectedPopupItem => new StyleValue(this, "SelectedPopupItem", PopupItemStyle);

		/// 
		/// Gets the simple combo box text box border style.
		/// </summary>
		/// The simple combo box text box border style.</value>
		[Category("States")]
		[SRDescription("The simple combobox textbox border style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ComboBoxTextBoxContainerStyle => new StyleValue(this, "ComboBoxTextBoxContainerStyle");

		/// 
		/// Gets the drop down list text box style.
		/// </summary>
		/// 
		/// The drop down list text box style.
		/// </value>
		[Category("States")]
		[SRDescription("The drop down list text box style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DropDownListTextBoxStyle => new BidirectionalSkinValue<object>(this, DropDownListTextBoxStyleLTR, DropDownListTextBoxStyleRTL);

		/// 
		/// Gets the drop down list text box style LTR.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DropDownListTextBoxStyleLTR => new StyleValue(this, "DropDownListTextBoxStyleLTR");

		/// 
		/// Gets the drop down list text box style RTL.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue DropDownListTextBoxStyleRTL => new StyleValue(this, "DropDownListTextBoxStyleRTL");

		/// 
		/// Gets the text box style.
		/// </summary>
		/// The text box style.</value>
		[Category("States")]
		[SRDescription("The TextBox style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue TextBoxStyle => new StyleValue(this, "TextBoxStyle");

		/// 
		/// Gets the focused drop down list text box style.
		/// </summary>
		/// The focused drop down list text box style.</value>
		[Category("States")]
		[SRDescription("The focused drop down list text box style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue FocusedDropDownListTextBoxStyle => new StyleValue(this, "FocusedDropDownListTextBoxStyle");

		/// 
		/// Gets the text box disable style.
		/// </summary>
		/// The text box disable style.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual StyleValue TextBoxDisableStyle => new StyleValue(this, "TextBoxDisableStyle");

		/// 
		/// Gets the color box style.
		/// </summary>
		/// The color box style.</value>
		[Category("States")]
		[SRDescription("The color box style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ColorBoxStyle => new StyleValue(this, "ColorBoxStyle");

		/// 
		/// Gets the drop down normal image.
		/// </summary>
		/// The drop down normal image.</value>
		[Category("Images")]
		[Description("drop down normal image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> DropDownNormalImage => new BidirectionalSkinProperty<object>(this, "DropDownNormalImageLTR", "DropDownNormalImageRTL");

		/// 
		/// Gets or sets the left to right drop down normal image.
		/// </summary>
		/// The left to right drop down normal image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownNormalImageLTR
		{
			get
			{
				return GetValue("DropDownNormalImageLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownNormal.gif"));
			}
			set
			{
				SetValue("DropDownNormalImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the right to left drop down normal image.
		/// </summary>
		/// The right to left drop down normal image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownNormalImageRTL
		{
			get
			{
				return GetValue("DropDownNormalImageRTL", DropDownNormalImageLTR);
			}
			set
			{
				SetValue("DropDownNormalImageRTL", value);
			}
		}

		/// 
		/// Gets the drop down over image.
		/// </summary>
		/// The drop down over image.</value>
		[Category("Images")]
		[Description("The DropDown over Image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> DropDownOverImage => new BidirectionalSkinProperty<object>(this, "DropDownOverImageLTR", "DropDownOverImageRTL");

		/// 
		/// Gets or sets the drop down over image LTR.
		/// </summary>
		/// The drop down over image LTR.</value>
		[Description("Drop down left to right over image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownOverImageLTR
		{
			get
			{
				return GetValue("DropDownOverImageLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownOver.gif"));
			}
			set
			{
				SetValue("DropDownOverImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the drop down over image RTL.
		/// </summary>
		/// The drop down over image RTL.</value>
		[Description("Drop down right to left over image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownOverImageRTL
		{
			get
			{
				return GetValue("DropDownOverImageRTL", DropDownOverImageLTR);
			}
			set
			{
				SetValue("DropDownOverImageRTL", value);
			}
		}

		/// 
		/// Gets the drop down down image.
		/// </summary>
		/// The drop down down image.</value>
		[Category("Images")]
		[Description("The DropDown down Image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> DropDownDownImage => new BidirectionalSkinProperty<object>(this, "DropDownDownImageLTR", "DropDownDownImageRTL");

		/// 
		/// Gets or sets the drop down down image LTR.
		/// </summary>
		/// The drop down down image LTR.</value>
		[Description("Drop down left to right down image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownDownImageLTR
		{
			get
			{
				return GetValue("DropDownDownImageLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownDown.gif"));
			}
			set
			{
				SetValue("DropDownDownImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the drop down down image RTL.
		/// </summary>
		/// The drop down down image RTL.</value>
		[Description("Drop down down right to left image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownDownImageRTL
		{
			get
			{
				return GetValue("DropDownDownImageRTL", DropDownDownImageLTR);
			}
			set
			{
				SetValue("DropDownDownImageRTL", value);
			}
		}

		/// 
		/// Gets the drop down image disable.
		/// </summary>
		/// The drop down image disable.</value>
		[Category("Images")]
		[Description("The DropDown disable Image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> DropDownImageDisable => new BidirectionalSkinProperty<object>(this, "DropDownImageDisableLTR", "DropDownImageDisableRTL");

		/// 
		/// Gets or sets the drop down image disable LTR.
		/// </summary>
		/// The drop down image disable LTR.</value>
		[Description("Drop down left to right image Disable")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownImageDisableLTR
		{
			get
			{
				return GetValue("DropDownImageDisableLTR", new ImageResourceReference(typeof(ComboBoxSkin), "DropDownDisable.gif"));
			}
			set
			{
				SetValue("DropDownImageDisableLTR", value);
			}
		}

		/// 
		/// Gets or sets the drop down image disable RTL.
		/// </summary>
		/// The drop down image disable RTL.</value>
		[Description("Drop down right to left image Disable")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference DropDownImageDisableRTL
		{
			get
			{
				return GetValue("DropDownImageDisableRTL", DropDownImageDisableLTR);
			}
			set
			{
				SetValue("DropDownImageDisableRTL", value);
			}
		}

		/// 
		/// Gets or sets the width of the drop down image.
		/// </summary>
		/// The width of the drop down image.</value>
		[SRCategory("Sizes")]
		[SRDescription("The drop down image width.")]
		public virtual int DropDownImageWidth
		{
			get
			{
				return GetValue("DropDownImageWidth", DefaultDropDownImageWidth);
			}
			set
			{
				SetValue("DropDownImageWidth", value);
			}
		}

		/// 
		/// Gets the default width of the drop down image.
		/// </summary>
		/// The default width of the drop down image.</value>
		protected virtual int DefaultDropDownImageWidth => 15;

		/// 
		/// Gets or sets the height of the drop down image.
		/// </summary>
		/// The height of the drop down image.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual int DropDownImageHeight
		{
			get
			{
				return GetValue("DropDownImageHeight", DefaultDropDownImageHeight);
			}
			set
			{
				SetValue("DropDownImageHeight", value);
			}
		}

		/// 
		/// Gets the default height of the drop down image.
		/// </summary>
		/// The default height of the drop down image.</value>
		protected virtual int DefaultDropDownImageHeight => 17;

		/// 
		/// Gets or sets the width of the drop down image cell.
		/// </summary>
		/// The width of the drop down image cell.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual int DropDownImageCellWidth
		{
			get
			{
				return GetValue("DropDownImageCellWidth", DefaultDropDownImageCellWidth);
			}
			set
			{
				SetValue("DropDownImageCellWidth", value);
			}
		}

		/// 
		/// Gets the default width of the drop down image cell.
		/// </summary>
		/// The default width of the drop down image cell.</value>
		protected virtual int DefaultDropDownImageCellWidth => 16;

		/// 
		/// Gets or sets the width of the color box.
		/// </summary>
		/// The width of the color box.</value>
		[SRCategory("Sizes")]
		[SRDescription("The color box width.")]
		public virtual int ColorBoxWidth
		{
			get
			{
				return GetValue("ColorBoxWidth", DefaultColorBoxWidth);
			}
			set
			{
				SetValue("ColorBoxWidth", value);
			}
		}

		/// 
		/// Gets or sets the height of the color box.
		/// </summary>
		/// The height of the color box.</value>
		[SRCategory("Sizes")]
		[SRDescription("The color box height.")]
		public virtual int ColorBoxHeight
		{
			get
			{
				return GetValue("ColorBoxHeight", DefaultColorBoxHeight);
			}
			set
			{
				SetValue("ColorBoxHeight", value);
			}
		}

		/// 
		/// Gets or sets the width of the image box.
		/// </summary>
		/// The width of the image box.</value>
		[SRCategory("Sizes")]
		[SRDescription("The image box width.")]
		public virtual int ImageBoxWidth
		{
			get
			{
				return GetValue("ImageBoxWidth", DefaultColorBoxWidth);
			}
			set
			{
				SetValue("ImageBoxWidth", value);
			}
		}

		/// 
		/// Gets or sets the height of the image box.
		/// </summary>
		/// The height of the image box.</value>
		[SRCategory("Sizes")]
		[SRDescription("The Image box height.")]
		public virtual int ImageBoxHeight
		{
			get
			{
				return GetValue("ImageBoxHeight", DefaultImageBoxHeight);
			}
			set
			{
				SetValue("ImageBoxHeight", value);
			}
		}

		/// 
		/// Gets the default width of the color box.
		/// </summary>
		/// The default width of the color box.</value>
		protected virtual int DefaultColorBoxWidth => 20;

		/// 
		/// Gets the default height of the color box.
		/// </summary>
		/// The default height of the color box.</value>
		protected virtual int DefaultColorBoxHeight => 14;

		/// 
		/// Gets the default height of the Image box.
		/// </summary>
		/// The default height of the Image box.</value>
		protected virtual int DefaultImageBoxHeight => 16;

		/// 
		/// Gets the default width of the image box.
		/// </summary>
		/// The default width of the image box.</value>
		protected virtual int DefaultImageBoxWidth => 16;

		/// 
		/// Gets the width of the preferd image box.
		/// </summary>
		/// The width of the preferd image box.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PreferdImageBoxWidth => ImageBoxWidth + PopupItemStyle.Padding.Horizontal;

		/// 
		/// Gets the width of the preferd color box.
		/// </summary>
		/// The width of the preferd color box.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PreferdColorBoxWidth => ColorBoxWidth + PopupItemStyle.Padding.Horizontal;

		/// 
		/// Gets or sets the height of the simple combo box input.
		/// </summary>
		/// The height of the simple combo box input.</value>
		[Category("Sizes")]
		[Description("The height of the simple combo box input.")]
		public int SimpleComboBoxInputHeight
		{
			get
			{
				return GetValue("SimpleComboBoxInputHeight", DefaultSimpleComboBoxInputHeight);
			}
			set
			{
				SetValue("SimpleComboBoxInputHeight", value);
			}
		}

		/// 
		/// Gets the default height of the simple combo box input.
		/// </summary>
		/// The default height of the simple combo box input.</value>
		protected virtual int DefaultSimpleComboBoxInputHeight => 17;

		/// 
		/// Gets or sets the width of the popup window offset.
		/// </summary>
		/// The width of the popup window offset.</value>
		[Category("Sizes")]
		[Description("The offset width for the popup window.")]
		public virtual int PopupWindowOffsetWidth
		{
			get
			{
				return GetValue("PopupWindowOffsetWidth", DefaultPopupWindowOffsetWidth);
			}
			set
			{
				SetValue("PopupWindowOffsetWidth", value);
			}
		}

		/// 
		/// Gets the default width of the popup window offset.
		/// </summary>
		/// The default width of the popup window offset.</value>
		protected virtual int DefaultPopupWindowOffsetWidth
		{
			get
			{
				int num = PopupWindowStyle.CenterStyle.BorderWidth.Left + PopupWindowStyle.CenterStyle.BorderWidth.Right + PopupWindowStyle.CenterStyle.Padding.Horizontal;
				if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
				{
					return num;
				}
				return num + RightPopupWindowFrameWidth + LeftPopupWindowFrameWidth;
			}
		}

		/// 
		/// Gets or sets the height of the popup window offset.
		/// </summary>
		/// The height of the popup window offset.</value>
		[Category("Sizes")]
		[Description("The offset height for the popup window.")]
		public virtual int PopupWindowOffsetHeight
		{
			get
			{
				return GetValue("PopupWindowOffsetHeight", DefaultPopupWindowOffsetHeight);
			}
			set
			{
				SetValue("PopupWindowOffsetHeight", value);
			}
		}

		/// 
		/// Gets the default height of the popup window offset.
		/// </summary>
		/// The default height of the popup window offset.</value>
		protected virtual int DefaultPopupWindowOffsetHeight
		{
			get
			{
				int num = PopupWindowStyle.CenterStyle.BorderWidth.Top + PopupWindowStyle.CenterStyle.BorderWidth.Bottom + PopupWindowStyle.CenterStyle.Padding.Vertical;
				if (HostContext.Current != null && HostContext.Current.Request != null && HostContext.Current.Request.Info != null && (HostContext.Current.Request.Info.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow)
				{
					return num;
				}
				return num + TopPopupWindowFrameHeight + BottomPopupWindowFrameHeight;
			}
		}

		/// 
		/// Gets or sets the width of the left popup window frame.
		/// </summary>
		/// The width of the left popup window frame.</value>
		[Category("Sizes")]
		[Description("The width of the left popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int LeftPopupWindowFrameWidth => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Left);

		/// 
		/// Gets or sets the width of the right popup window frame.
		/// </summary>
		/// The width of the right popup window frame.</value>
		[Category("Sizes")]
		[Description("The width of the right popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int RightPopupWindowFrameWidth => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Right);

		/// 
		/// Gets or sets the height of the top popup window frame.
		/// </summary>
		/// The height of the top popup window frame.</value>
		[Category("Sizes")]
		[Description("The height of the top popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int TopPopupWindowFrameHeight => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Top);

		/// 
		/// Gets or sets the height of the bottom popup window frame.
		/// </summary>
		/// The height of the bottom popup window frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom popup window frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int BottomPopupWindowFrameHeight => GetFrameEdgeSize(PopupWindowStyle, FrameEdge.Bottom);

		/// 
		/// Gets the opup window style.
		/// </summary>
		/// The opup window style.</value>
		[Category("States")]
		[Description("The popup window style.")]
		public FrameStyleValue PopupWindowStyle => new FrameStyleValue(LeftBottomPopupWindowStyle, LeftPopupWindowStyle, LeftTopPopupWindowStyle, TopPopupWindowStyle, RightTopPopupWindowStyle, RightPopupWindowStyle, RightBottomPopupWindowStyle, BottomPopupWindowStyle, CenterPopupWindowStyle);

		/// 
		/// Gets the center popup window style.
		/// </summary>
		/// The center popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterPopupWindowStyle => new StyleValue(this, "CenterPopupWindowStyle", PopupSkin.CenterStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left popup window style.
		/// </summary>
		/// The left popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftPopupWindowStyle => new FramePartStyleValue(this, "LeftPopupWindowStyle", PopupSkin.LeftStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the top popup window style.
		/// </summary>
		/// The top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopPopupWindowStyle => new FramePartStyleValue(this, "TopPopupWindowStyle", PopupSkin.TopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the bottom popup window style.
		/// </summary>
		/// The bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomPopupWindowStyle => new FramePartStyleValue(this, "BottomPopupWindowStyle", PopupSkin.BottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right popup window style.
		/// </summary>
		/// The right popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightPopupWindowStyle => new FramePartStyleValue(this, "RightPopupWindowStyle", PopupSkin.RightStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right top popup window style.
		/// </summary>
		/// The right top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopPopupWindowStyle => new FramePartStyleValue(this, "RightTopPopupWindowStyle", PopupSkin.RightTopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left top popup window style.
		/// </summary>
		/// The left top popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopPopupWindowStyle => new FramePartStyleValue(this, "LeftTopPopupWindowStyle", PopupSkin.LeftTopStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the left bottom popup window style.
		/// </summary>
		/// The left bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomPopupWindowStyle => new FramePartStyleValue(this, "LeftBottomPopupWindowStyle", PopupSkin.LeftBottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the right bottom popup window style.
		/// </summary>
		/// The right bottom popup window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomPopupWindowStyle => new FramePartStyleValue(this, "RightBottomPopupWindowStyle", PopupSkin.RightBottomStyle, blnLocalizeBaseStyleValues: true);

		/// 
		/// Gets the popups skin.
		/// </summary>
		/// The popups skin.</value>
		private PopupsSkin PopupSkin => SkinFactory.GetSkin(base.Owner, typeof(PopupsSkin), blnEnableSkinableFallback: true) as PopupsSkin;

		private void InitializeComponent()
		{
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
		/// Resets the drop down down image disable.
		/// </summary>
		private void ResetDropDownDownImageDisable()
		{
			Reset("DropDownImageDisable");
		}

		/// 
		/// Resets the width of the drop down image.
		/// </summary>
		private void ResetDropDownImageWidth()
		{
			Reset("DropDownImageWidth");
		}

		/// 
		/// Resets the height of the drop down image.
		/// </summary>
		private void ResetDropDownImageHeight()
		{
			Reset("DropDownImageHeight");
		}

		/// 
		/// Resets the width of the drop down image cell.
		/// </summary>
		private void ResetDropDownImageCellWidth()
		{
			Reset("DropDownImageCellWidth");
		}

		/// 
		/// Resets the width of the color box.
		/// </summary>
		private void ResetColorBoxWidth()
		{
			Reset("ColorBoxWidth");
		}

		/// 
		/// Resets the height of the color box.
		/// </summary>
		private void ResetColorBoxHeight()
		{
			Reset("ColorBoxHeight");
		}

		/// 
		/// Resets the width of the image box.
		/// </summary>
		private void ResetImageBoxWidth()
		{
			Reset("ImageBoxWidth");
		}

		private void ResetImageBoxHeight()
		{
			Reset("ImageBoxHeight");
		}

		/// 
		/// Resets the width of the popup window offset.
		/// </summary>
		private void ResetPopupWindowOffsetWidth()
		{
			Reset("PopupWindowOffsetWidth");
		}

		/// 
		/// Resets the height of the popup window offset.
		/// </summary>
		private void ResetPopupWindowOffsetHeight()
		{
			Reset("PopupWindowOffsetHeight");
		}

		/// 
		/// Resets the width of the left popup window frame.
		/// </summary>
		internal void ResetLeftPopupWindowFrameWidth()
		{
			Reset("LeftPopupWindowFrameWidth");
		}

		/// 
		/// Resets the width of the right popup window frame.
		/// </summary>
		internal void ResetRightPopupWindowFrameWidth()
		{
			Reset("RightPopupWindowFrameWidth");
		}

		/// 
		/// Resets the height of the top popup window frame.
		/// </summary>
		internal void ResetTopPopupWindowFrameHeight()
		{
			Reset("TopPopupWindowFrameHeight");
		}

		/// 
		/// Resets the height of the bottom popup window frame.
		/// </summary>
		internal void ResetBottomPopupWindowFrameHeight()
		{
			Reset("BottomPopupWindowFrameHeight");
		}
	}
}

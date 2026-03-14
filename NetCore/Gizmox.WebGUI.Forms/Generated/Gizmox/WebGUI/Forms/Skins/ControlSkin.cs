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
	/// Provides skin definition for control
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(UserControl))]
	public class ControlSkin : CommonSkin
	{
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public override ArrowsScrollerProperties ArrowsScrollProperties => base.ArrowsScrollProperties;

		/// 
		/// Gets or sets the background image.
		/// </summary>
		/// The background image.</value>
		[SRDescription("ControlBackgroundImageDescr")]
		[SRCategory("CatAppearance")]
		public virtual ImageResourceReference BackgroundImage
		{
			get
			{
				return GetValue("BackgroundImage", (ImageResourceReference)"");
			}
			set
			{
				SetValue("BackgroundImage", value);
			}
		}

		/// 
		/// Gets or sets the visual effect.
		/// </summary>
		/// 
		/// The visual effect.
		/// </value>
		[SRCategory("CatBehavior")]
		[Description("Provide definitions for visual effects.")]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public VisualEffectValue VisualEffect
		{
			get
			{
				return GetValue("VisualEffect", null);
			}
			set
			{
				SetValue("VisualEffect", value);
			}
		}

		/// 
		/// Gets or sets the background image repeat.
		/// </summary>
		/// The background image repeat.</value>
		[SRDescription("Sets if or how a background image will be repeated.")]
		[SRCategory("CatAppearance")]
		public virtual BackgroundImageRepeat BackgroundImageRepeat
		{
			get
			{
				return GetValue("BackgroundImageRepeat", BackgroundImageRepeat.Repeat);
			}
			set
			{
				SetValue("BackgroundImageRepeat", value);
			}
		}

		/// 
		/// Gets or sets the background image position.
		/// </summary>
		/// The background image position.</value>
		[SRDescription("Sets the starting position of a background image.")]
		[SRCategory("CatAppearance")]
		public virtual BackgroundImagePosition BackgroundImagePosition
		{
			get
			{
				return GetValue("BackgroundImagePosition", BackgroundImagePosition.MiddleCenter);
			}
			set
			{
				SetValue("BackgroundImagePosition", value);
			}
		}

		/// 
		/// Gets or sets the background color.
		/// </summary>
		/// </value>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlBackColorDescr")]
		public virtual Color BackColor
		{
			get
			{
				return GetAmbientValue("BackColor", Color.FromKnownColor(KnownColor.Control));
			}
			set
			{
				SetValue("BackColor", value);
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// The control padding.</value>
		[SRDescription("ControlPaddingDescr")]
		[Category("Layout")]
		public virtual PaddingValue Padding
		{
			get
			{
				return GetValue("Padding", PaddingValue.Empty);
			}
			set
			{
				SetValue("Padding", value);
			}
		}

		/// 
		/// Gets or sets the space between controls.
		/// </summary>
		/// The space between controls.</value>
		[Category("Layout")]
		[SRDescription("ControlMarginDescr")]
		public virtual MarginValue Margin
		{
			get
			{
				return GetValue("Margin", MarginValue.Empty);
			}
			set
			{
				SetValue("Margin", value);
			}
		}

		/// 
		/// Gets or sets the width of the border.
		/// </summary>
		/// </value>
		[SRDescription("ControlBorderWidthDescr")]
		[SRCategory("CatAppearance")]
		public virtual BorderWidth BorderWidth
		{
			get
			{
				return GetValue("BorderWidth", new BorderWidth(1));
			}
			set
			{
				SetValue("BorderWidth", value);
			}
		}

		/// 
		/// Gets or sets the border color.
		/// </summary>
		/// </value>
		[SRDescription("ControlBorderColorDescr")]
		[SRCategory("CatAppearance")]
		public virtual BorderColor BorderColor
		{
			get
			{
				return GetValue("BorderColor", new BorderColor(Color.FromArgb(101, 147, 207)));
			}
			set
			{
				SetValue("BorderColor", value);
			}
		}

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// </value>
		[SRDescription("ControlBorderStyleDescr")]
		[SRCategory("CatAppearance")]
		public virtual BorderStyle BorderStyle
		{
			get
			{
				return GetValue("BorderStyle", BorderStyle.None);
			}
			set
			{
				SetValue("BorderStyle", value);
			}
		}

		/// 
		/// Gets the border value which can be translated.
		/// </summary>
		/// The border.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BorderValue Border
		{
			get
			{
				BorderValue borderValue = new BorderValue();
				borderValue.Color = BorderColor;
				borderValue.Style = BorderStyle;
				borderValue.Width = BorderWidth;
				return borderValue;
			}
		}

		/// 
		/// Gets the background.
		/// </summary>
		/// The background.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundValue Background
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = BackColor;
				backgroundValue.BackgroundImage = BackgroundImage;
				backgroundValue.BackgroundImagePosition = BackgroundImagePosition;
				backgroundValue.BackgroundImageRepeat = BackgroundImageRepeat;
				return backgroundValue;
			}
		}

		/// 
		/// Gets or sets the control disabled style.
		/// </summary>
		/// 
		/// The control disabled style.
		/// </value>
		[Category("States")]
		[Description("Gets or sets the control disabled style.")]
		public virtual StyleValue ControlDisabledStyle
		{
			get
			{
				return new StyleValue(this, "ControlDisabledStyle");
			}
			set
			{
				SetValue("ControlDisabledStyle", value);
			}
		}

		/// 
		/// Gets the text foreground disabled.
		/// </summary>
		/// 
		/// The text foreground disabled.
		/// </value>
		[Browsable(false)]
		public ForegroundValue ControlTextForegroundDisabled
		{
			get
			{
				ForegroundValue foregroundValue = new ForegroundValue();
				foregroundValue.ForeColor = ControlDisabledStyle.ForeColor;
				return foregroundValue;
			}
		}

		/// 
		/// Gets the text background disabled.
		/// </summary>
		/// 
		/// The text background disabled.
		/// </value>
		[Browsable(false)]
		public BackgroundValue ControlTextBackgroundDisabled
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = ControlDisabledStyle.BackColor;
				return backgroundValue;
			}
		}

		/// 
		/// Gets the Opacity value for disabled control
		/// </summary>
		/// 
		/// The Opacity value for disabled control
		/// </value>
		[Browsable(false)]
		public OpacityValue ControlOpacityDisabled => new OpacityValue(ControlDisabledStyle.Opacity.Opacity);

		/// 
		/// Gets the control text font disabled.
		/// </summary>
		/// 
		/// The control text font disabled.
		/// </value>
		[Browsable(false)]
		public Font ControlTextFontDisabled => ControlDisabledStyle.Font;

		/// 
		/// Resets the background image.
		/// </summary>
		internal void ResetBackgroundImage()
		{
			Reset("BackgroundImage");
		}

		/// 
		/// Resets the background image repeat.
		/// </summary>
		internal void ResetBackgroundImageRepeat()
		{
			Reset("BackgroundImageRepeat");
		}

		/// 
		/// Resets the color of the back.
		/// </summary>
		internal void ResetBackColor()
		{
			Reset("BackColor");
		}

		/// 
		/// Resets the padding.
		/// </summary>
		internal void ResetPadding()
		{
			Reset("Padding");
		}

		/// 
		/// Resets the margin.
		/// </summary>
		internal void ResetMargin()
		{
			Reset("Margin");
		}

		/// 
		/// Resets the Border Radius.
		/// </summary>
		internal void ResetBorderRadius()
		{
			Reset("BorderRadius");
		}

		/// 
		/// Resets the width of the border.
		/// </summary>
		internal void ResetBorderWidth()
		{
			Reset("BorderWidth");
		}

		/// 
		/// Resets the color of the border.
		/// </summary>
		internal void ResetBorderColor()
		{
			Reset("BorderColor");
		}

		/// 
		/// Resets the border style.
		/// </summary>
		internal void ResetBorderStyle()
		{
			Reset("BorderStyle");
		}

		/// 
		/// Resets the control disabled style.
		/// </summary>
		internal void ResetControlDisabledStyle()
		{
			Reset("ControlDisabledStyle");
		}

		private void InitializeComponent()
		{
		}
	}
}

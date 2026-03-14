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
	/// Form Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(Form))]
	public class FormSkin : ContainerControlSkin
	{
		/// 
		/// Gets the dialog window modal style.
		/// </summary>
		/// The dialog window modal style.</value>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("States")]
		[SRDescription("WindowModalMaskOpacityDescr")]
		public new virtual StyleValue WindowModalMaskStyle => new StyleValue(this, "WindowModalMaskStyle");

		/// 
		/// Gets or sets the back color opacity.
		/// </summary>
		/// The back color opacity.</value>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Colors")]
		[SRDescription("WindowModalMaskOpacityDescr")]
		public new OpacityValue WindowModalMaskOpacity
		{
			get
			{
				return GetValue("WindowModalMaskOpacity", new OpacityValue(DefaultWindowModalMaskOpacity));
			}
			set
			{
				if (value.Opacity >= 0 && value.Opacity <= 100)
				{
					SetValue("WindowModalMaskOpacity", value);
					return;
				}
				throw new Exception("You must supply values between 1 and 100.");
			}
		}

		/// 
		/// Gets the size of the default minimized MDI form.
		/// </summary>
		/// The size of the default minimized MDI form.</value>
		protected virtual Size DefaultMinimizedMdiFormSize => new Size(200, 60);

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultWindowModalMaskOpacity => 50;

		/// 
		/// Gets or sets the width of the left dialog window frame.
		/// </summary>
		/// The width of the left dialog window frame.</value>
		[Category("Sizes")]
		[Description("The width of the left dialog window frame.")]
		public virtual int LeftDialogWindowFrameWidth
		{
			get
			{
				return GetValue("LeftDialogWindowFrameWidth", GetImageWidth(ActiveDialogWindowStyle.LeftStyle.BackgroundImage, DefaultLeftDialogWindowFrameWidth));
			}
			set
			{
				SetValue("LeftDialogWindowFrameWidth", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultLeftDialogWindowFrameWidth => 4;

		/// 
		/// Gets or sets the width of the right dialog window frame.
		/// </summary>
		/// The width of the right dialog window frame.</value>
		[Category("Sizes")]
		[Description("The width of the right dialog window frame.")]
		public virtual int RightDialogWindowFrameWidth
		{
			get
			{
				return GetValue("RightDialogWindowFrameWidth", GetImageWidth(ActiveDialogWindowStyle.RightStyle.BackgroundImage, DefaultRightDialogWindowFrameWidth));
			}
			set
			{
				SetValue("RightDialogWindowFrameWidth", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultRightDialogWindowFrameWidth => 4;

		/// 
		/// Gets or sets the height of the top dialog window frame.
		/// </summary>
		/// The height of the top dialog window frame.</value>
		[Category("Sizes")]
		[Description("The height of the top dialog window frame.")]
		public virtual int TopDialogWindowFrameHeight
		{
			get
			{
				return GetValue("TopDialogWindowFrameHeight", GetImageHeight(ActiveDialogWindowStyle.TopStyle.BackgroundImage, DefaultTopDialogWindowFrameHeight));
			}
			set
			{
				SetValue("TopDialogWindowFrameHeight", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultTopDialogWindowFrameHeight => 4;

		/// 
		/// Gets or sets the height of the bottom dialog window frame.
		/// </summary>
		/// The height of the bottom dialog window frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom dialog window frame.")]
		public virtual int BottomDialogWindowFrameHeight
		{
			get
			{
				return GetValue("BottomDialogWindowFrameHeight", GetImageHeight(ActiveDialogWindowStyle.BottomStyle.BackgroundImage, DefaultBottomDialogWindowFrameHeight));
			}
			set
			{
				SetValue("BottomDialogWindowFrameHeight", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultBottomDialogWindowFrameHeight => 4;

		/// 
		/// Gets the normal active dialog style.
		/// </summary>
		/// The normal active dialog style.</value>
		[Category("States")]
		[Description("The normal active dialog style.")]
		public virtual OverlayedFrameStyleValue ActiveDialogWindowStyle => new OverlayedFrameStyleValue(LeftBottomActiveDialogWindowStyle, LeftActiveDialogWindowStyle, LeftTopActiveDialogWindowStyle, TopActiveDialogWindowStyle, RightTopActiveDialogWindowStyle, RightActiveDialogWindowStyle, RightBottomActiveDialogWindowStyle, BottomActiveDialogWindowStyle, CenterActiveDialogWindowStyle, LeftOverlayActiveDialogWindowStyle, RightOverlayActiveDialogWindowStyle);

		/// 
		/// Gets the dialog window captions style.
		/// </summary>
		/// The dialog window captions style.</value>
		[Category("States")]
		[Description("The dialog window captions style.")]
		public virtual StyleValue DialogWindowCaptionStyle => new StyleValue(this, "DialogWindowCaptionStyle");

		/// 
		/// Gets the dialog window buttons style.
		/// </summary>
		/// The dialog window buttons style.</value>
		[Category("States")]
		[Description("The dialog window buttons style.")]
		public virtual StyleValue DialogWindowButtonsStyle => new StyleValue(this, "DialogWindowButtonsStyle");

		/// 
		/// Gets the dialog window close button normal style.
		/// </summary>
		/// The dialog window close button normal style.</value>
		[Category("States")]
		[SRDescription("The dialog window close button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DialogWindowCloseButtonNormalStyle => new BidirectionalSkinValue<object>(this, DialogWindowCloseButtonNormalStyleLTR, DialogWindowCloseButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window close button normal style LTR.
		/// </summary>
		/// The dialog window close button normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowCloseButtonNormalStyleLTR => new StyleValue(this, "DialogWindowCloseButtonNormalStyleLTR");

		/// 
		/// Gets the dialog window close button normal style RTL.
		/// </summary>
		/// The dialog window close button normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowCloseButtonNormalStyleRTL => new StyleValue(this, "DialogWindowCloseButtonNormalStyleRTL");

		/// 
		/// Gets the dialog window close button hover style.
		/// </summary>
		/// The dialog window close button hover style.</value>
		[Category("States")]
		[SRDescription("The dialog window hover close button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DialogWindowCloseButtonHoverStyle => new BidirectionalSkinValue<object>(this, DialogWindowCloseButtonHoverStyleLTR, DialogWindowCloseButtonHoverStyleRTL);

		/// 
		/// Gets the dialog window close button hover style LTR.
		/// </summary>
		/// The dialog window close button hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowCloseButtonHoverStyleLTR => new StyleValue(this, "DialogWindowCloseButtonHoverStyleLTR", DialogWindowCloseButtonNormalStyleLTR);

		/// 
		/// Gets the dialog window close button hover style RTL.
		/// </summary>
		/// The dialog window close button hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowCloseButtonHoverStyleRTL => new StyleValue(this, "DialogWindowCloseButtonHoverStyleRTL", DialogWindowCloseButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window close button disabled style.
		/// </summary>
		/// The dialog window close button disabled style.</value>
		[Category("States")]
		[SRDescription("The dialog window disabled close button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DialogWindowCloseButtonDisabledStyle => new BidirectionalSkinValue<object>(this, DialogWindowCloseButtonDisabledStyleLTR, DialogWindowCloseButtonDisabledStyleRTL);

		/// 
		/// Gets the dialog window close button disabled style RTL.
		/// </summary>
		/// The dialog window close button disabled style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowCloseButtonDisabledStyleRTL => new StyleValue(this, "DialogWindowCloseButtonDisabledStyleRTL", DialogWindowCloseButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window close button disabled style LTR.
		/// </summary>
		/// The dialog window close button disabled style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowCloseButtonDisabledStyleLTR => new StyleValue(this, "DialogWindowCloseButtonDisabledStyleLTR", DialogWindowCloseButtonNormalStyleLTR);

		/// 
		/// Gets or sets the size of the dialog window close button.
		/// </summary>
		/// The size of the dialog window close button.</value>
		[Category("Sizes")]
		[Description("The size of the dialog window close button.")]
		public virtual Size DialogWindowCloseButtonSize
		{
			get
			{
				return GetValue("DialogWindowCloseButtonSize", GetImageSize(DialogWindowCloseButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
			}
			set
			{
				SetValue("DialogWindowCloseButtonSize", value);
			}
		}

		/// 
		/// Gets the width of the dialog window close button.
		/// </summary>
		/// The width of the dialog window close button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DialogWindowCloseButtonWidth => DialogWindowCloseButtonSize.Width;

		/// 
		/// Gets the height of the dialog window close button.
		/// </summary>
		/// The height of the dialog window close button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DialogWindowButtonCloseHeight => DialogWindowCloseButtonSize.Height;

		/// 
		/// Gets the dialog window minimize button normal style.
		/// </summary>
		/// The dialog window minimize button normal style.</value>
		[Category("States")]
		[SRDescription("The dialog window minimize button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DialogWindowMinimizeButtonNormalStyle => new BidirectionalSkinValue<object>(this, DialogWindowMinimizeButtonNormalStyleLTR, DialogWindowMinimizeButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window minimize button normal style LTR.
		/// </summary>
		/// The dialog window minimize button normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMinimizeButtonNormalStyleLTR => new StyleValue(this, "DialogWindowMinimizeButtonNormalStyleLTR");

		/// 
		/// Gets the dialog window minimize button normal style RTL.
		/// </summary>
		/// The dialog window minimize button normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMinimizeButtonNormalStyleRTL => new StyleValue(this, "DialogWindowMinimizeButtonNormalStyleRTL");

		/// 
		/// Gets the dialog window minimize button hover style.
		/// </summary>
		/// The dialog window minimize button hover style.</value>
		[Category("States")]
		[SRDescription("The dialog window hover minimize button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DialogWindowMinimizeButtonHoverStyle => new BidirectionalSkinValue<object>(this, DialogWindowMinimizeButtonHoverStyleLTR, DialogWindowMinimizeButtonHoverStyleRTL);

		/// 
		/// Gets the dialog window minimize button hover style LTR.
		/// </summary>
		/// The dialog window minimize button hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMinimizeButtonHoverStyleLTR => new StyleValue(this, "DialogWindowMinimizeButtonHoverStyleLTR", DialogWindowMinimizeButtonNormalStyleLTR);

		/// 
		/// Gets the dialog window minimize button hover style RTL.
		/// </summary>
		/// The dialog window minimize button hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMinimizeButtonHoverStyleRTL => new StyleValue(this, "DialogWindowMinimizeButtonHoverStyleRTL", DialogWindowMinimizeButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window minimize button disabled style.
		/// </summary>
		/// The dialog window minimize button disabled style.</value>
		[Category("States")]
		[SRDescription("The dialog window disabled minimize button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BidirectionalSkinValue<object> DialogWindowMinimizeButtonDisabledStyle => new BidirectionalSkinValue<object>(this, DialogWindowMinimizeButtonDisabledStyleLTR, DialogWindowMinimizeButtonDisabledStyleRTL);

		/// 
		/// Gets the dialog window minimize button disabled style LTR.
		/// </summary>
		/// The dialog window minimize button disabled style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMinimizeButtonDisabledStyleLTR => new StyleValue(this, "DialogWindowMinimizeButtonDisabledStyleLTR", DialogWindowMinimizeButtonNormalStyleLTR);

		/// 
		/// Gets the dialog window minimize button disabled style RTL.
		/// </summary>
		/// The dialog window minimize button disabled style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMinimizeButtonDisabledStyleRTL => new StyleValue(this, "DialogWindowMinimizeButtonDisabledStyleRTL", DialogWindowMinimizeButtonNormalStyleRTL);

		/// 
		/// Gets or sets the size of the dialog window minimize button.
		/// </summary>
		/// The size of the dialog window minimize button.</value>
		[Category("Sizes")]
		[Description("The size of the dialog window minimize button.")]
		public virtual Size DialogWindowMinimizeButtonSize
		{
			get
			{
				return GetValue("DialogWindowMinimizeButtonSize", GetImageSize(DialogWindowMinimizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
			}
			set
			{
				SetValue("DialogWindowMinimizeButtonSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the dialog window restore button.
		/// </summary>
		/// The size of the dialog window restore button.</value>
		[Category("Sizes")]
		[Description("The size of the dialog window restore button.")]
		public virtual Size DialogWindowRestoreButtonSize
		{
			get
			{
				return GetValue("DialogWindowRestoreButtonSize", GetImageSize(DialogWindowRestoreButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
			}
			set
			{
				SetValue("DialogWindowRestoreButtonSize", value);
			}
		}

		/// 
		/// Gets the width of the dialog window restore button.
		/// </summary>
		/// The width of the dialog window restore button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DialogWindowRestoreButtonWidth => DialogWindowRestoreButtonSize.Width;

		/// 
		/// Gets the height of the dialog window restore button.
		/// </summary>
		/// The height of the dialog window restore button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DialogWindowRestoreButtonHeight => DialogWindowRestoreButtonSize.Height;

		/// 
		/// Gets the width of the dialog window minimize button.
		/// </summary>
		/// The width of the dialog window minimize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DialogWindowMinimizeButtonWidth => DialogWindowMinimizeButtonSize.Width;

		/// 
		/// Gets the height of the dialog window minimize button.
		/// </summary>
		/// The height of the dialog window minimize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DialogWindowMinimizeButtonHeight => DialogWindowMinimizeButtonSize.Height;

		/// 
		/// Gets the height of the dialog window close button.
		/// </summary>
		/// The height of the dialog window close button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DialogWindowCloseButtonHeight => DialogWindowCloseButtonSize.Height;

		/// 
		/// Gets the dialog window restore button normal style.
		/// </summary>
		/// The dialog window restore button normal style.</value>
		[Category("States")]
		[Description("The dialog window restore button style.")]
		public virtual BidirectionalSkinValue<object> DialogWindowRestoreButtonNormalStyle => new BidirectionalSkinValue<object>(this, DialogWindowRestoreButtonNormalStyleLTR, DialogWindowRestoreButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window restore button normal style LTR.
		/// </summary>
		/// The dialog window restore button normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowRestoreButtonNormalStyleLTR => new StyleValue(this, "DialogWindowRestoreButtonNormalStyleLTR");

		/// 
		/// Gets the dialog window restore button normal style RTL.
		/// </summary>
		/// The dialog window restore button normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowRestoreButtonNormalStyleRTL => new StyleValue(this, "DialogWindowRestoreButtonNormalStyleRTL");

		/// 
		/// Gets the dialog window restore button hover style.
		/// </summary>
		/// The dialog window restore button hover style.</value>
		[Category("States")]
		[Description("The dialog window hover restore button style.")]
		public virtual BidirectionalSkinValue<object> DialogWindowRestoreButtonHoverStyle => new BidirectionalSkinValue<object>(this, DialogWindowRestoreButtonHoverStyleLTR, DialogWindowRestoreButtonHoverStyleRTL);

		/// 
		/// Gets the dialog window restore button hover style LTR.
		/// </summary>
		/// The dialog window restore button hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowRestoreButtonHoverStyleLTR => new StyleValue(this, "DialogWindowRestoreButtonHoverStyleLTR", DialogWindowMaximizeButtonNormalStyleLTR);

		/// 
		/// Gets the dialog window restore button hover style RTL.
		/// </summary>
		/// The dialog window restore button hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowRestoreButtonHoverStyleRTL => new StyleValue(this, "DialogWindowRestoreButtonHoverStyleRTL", DialogWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window restore button disabled style.
		/// </summary>
		/// The dialog window restore button disabled style.</value>
		[Category("States")]
		[Description("The dialog window disabled restore button style.")]
		public virtual BidirectionalSkinValue<object> DialogWindowRestoreButtonDisabledStyle => new BidirectionalSkinValue<object>(this, DialogWindowRestoreButtonDisabledStyleLTR, DialogWindowRestoreButtonDisabledStyleRTL);

		/// 
		/// Gets the dialog window restore button disabled style LTR.
		/// </summary>
		/// The dialog window restore button disabled style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowRestoreButtonDisabledStyleLTR => new StyleValue(this, "DialogWindowRestoreButtonDisabledStyleLTR", DialogWindowMaximizeButtonNormalStyleLTR);

		/// 
		/// Gets the dialog window restore button disabled style RTL.
		/// </summary>
		/// The dialog window restore button disabled style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowRestoreButtonDisabledStyleRTL => new StyleValue(this, "DialogWindowRestoreButtonDisabledStyleRTL", DialogWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window maximize button normal style.
		/// </summary>
		/// The dialog window maximize button normal style.</value>
		[Category("States")]
		[Description("The dialog window maximize button style.")]
		public virtual BidirectionalSkinValue<object> DialogWindowMaximizeButtonNormalStyle => new BidirectionalSkinValue<object>(this, DialogWindowMaximizeButtonNormalStyleLTR, DialogWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window maximize button normal style LTR.
		/// </summary>
		/// The dialog window maximize button normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMaximizeButtonNormalStyleLTR => new StyleValue(this, "DialogWindowMaximizeButtonNormalStyleLTR");

		/// 
		/// Gets the dialog window maximize button normal style RTL.
		/// </summary>
		/// The dialog window maximize button normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMaximizeButtonNormalStyleRTL => new StyleValue(this, "DialogWindowMaximizeButtonNormalStyleRTL");

		/// 
		/// Gets the dialog window maximize button hover style.
		/// </summary>
		/// The dialog window maximize button hover style.</value>
		[Category("States")]
		[Description("The dialog window hover maximize button style.")]
		public virtual BidirectionalSkinValue<object> DialogWindowMaximizeButtonHoverStyle => new BidirectionalSkinValue<object>(this, DialogWindowMaximizeButtonHoverStyleLTR, DialogWindowMaximizeButtonHoverStyleRTL);

		/// 
		/// Gets the dialog window maximize button hover style LTR.
		/// </summary>
		/// The dialog window maximize button hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMaximizeButtonHoverStyleLTR => new StyleValue(this, "DialogWindowMaximizeButtonHoverStyleLTR", DialogWindowMaximizeButtonNormalStyleLTR);

		/// 
		/// Gets the dialog window maximize button hover style RTL.
		/// </summary>
		/// The dialog window maximize button hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMaximizeButtonHoverStyleRTL => new StyleValue(this, "DialogWindowMaximizeButtonHoverStyleRTL", DialogWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets the dialog window maximize button disabled style.
		/// </summary>
		/// The dialog window maximize button disabled style.</value>
		[Category("States")]
		[Description("The dialog window disabled maximize button style.")]
		public virtual BidirectionalSkinValue<object> DialogWindowMaximizeButtonDisabledStyle => new BidirectionalSkinValue<object>(this, DialogWindowMaximizeButtonDisabledStyleLTR, DialogWindowMaximizeButtonDisabledStyleRTL);

		/// 
		/// Gets the dialog window maximize button disabled style LTR.
		/// </summary>
		/// The dialog window maximize button disabled style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMaximizeButtonDisabledStyleLTR => new StyleValue(this, "DialogWindowMaximizeButtonDisabledStyleLTR", DialogWindowMaximizeButtonNormalStyleLTR);

		/// 
		/// Gets the dialog window maximize button disabled style RTL.
		/// </summary>
		/// The dialog window maximize button disabled style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue DialogWindowMaximizeButtonDisabledStyleRTL => new StyleValue(this, "DialogWindowMaximizeButtonDisabledStyleRTL", DialogWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets or sets the size of the dialog window maximize button.
		/// </summary>
		/// The size of the dialog window maximize button.</value>
		[Category("Sizes")]
		[Description("The size of the dialog window maximize button.")]
		public virtual Size DialogWindowMaximizeButtonSize
		{
			get
			{
				return GetValue("DialogWindowMaximizeButtonSize", GetImageSize(DialogWindowMaximizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
			}
			set
			{
				SetValue("DialogWindowMaximizeButtonSize", value);
			}
		}

		/// 
		/// Gets the width of the dialog window maximize button.
		/// </summary>
		/// The width of the dialog window maximize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DialogWindowMaximizeButtonWidth => DialogWindowMaximizeButtonSize.Width;

		/// 
		/// Gets the height of the dialog window maximize button.
		/// </summary>
		/// The height of the dialog window maximize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DialogWindowMaximizeButtonHeight => DialogWindowMaximizeButtonSize.Height;

		/// 
		/// Gets the center normal active dialog style.
		/// </summary>
		/// The center normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterActiveDialogWindowStyle => new StyleValue(this, "CenterActiveDialogWindowStyle");

		/// 
		/// Gets the left normal active dialog style.
		/// </summary>
		/// The left normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftActiveDialogWindowStyle => new FramePartStyleValue(this, "LeftActiveDialogWindowStyle");

		/// 
		/// Gets the top normal active dialog style.
		/// </summary>
		/// The top normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopActiveDialogWindowStyle => new FramePartStyleValue(this, "TopActiveDialogWindowStyle");

		/// 
		/// Gets the bottom normal active dialog style.
		/// </summary>
		/// The bottom normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomActiveDialogWindowStyle => new FramePartStyleValue(this, "BottomActiveDialogWindowStyle");

		/// 
		/// Gets the right normal active dialog style.
		/// </summary>
		/// The right normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightActiveDialogWindowStyle => new FramePartStyleValue(this, "RightActiveDialogWindowStyle");

		/// 
		/// Gets the right top normal active dialog style.
		/// </summary>
		/// The right top normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopActiveDialogWindowStyle => new FramePartStyleValue(this, "RightTopActiveDialogWindowStyle");

		/// 
		/// Gets the left top normal active dialog style.
		/// </summary>
		/// The left top normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopActiveDialogWindowStyle => new FramePartStyleValue(this, "LeftTopActiveDialogWindowStyle");

		/// 
		/// Gets the left overlay active dialog window style.
		/// </summary>
		/// The left overlay active dialog window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FrameOverlayStyleValue LeftOverlayActiveDialogWindowStyle => new FrameOverlayStyleValue(this, "LeftOverlayActiveDialogWindowStyle");

		/// 
		/// Gets the right overlay active dialog window style.
		/// </summary>
		/// The right overlay active dialog window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FrameOverlayStyleValue RightOverlayActiveDialogWindowStyle => new FrameOverlayStyleValue(this, "RightOverlayActiveDialogWindowStyle");

		/// 
		/// Gets the left bottom normal active dialog style.
		/// </summary>
		/// The left bottom normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomActiveDialogWindowStyle => new FramePartStyleValue(this, "LeftBottomActiveDialogWindowStyle");

		/// 
		/// Gets the right bottom normal active dialog style.
		/// </summary>
		/// The right bottom normal active dialog style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomActiveDialogWindowStyle => new FramePartStyleValue(this, "RightBottomActiveDialogWindowStyle");

		/// 
		/// Gets or sets the width of the left tool window frame.
		/// </summary>
		/// The width of the left tool window frame.</value>
		[Category("Sizes")]
		[Description("The width of the left tool window frame.")]
		public virtual int LeftToolWindowFrameWidth
		{
			get
			{
				return GetValue("LeftToolWindowFrameWidth", GetImageWidth(ActiveToolWindowStyle.LeftStyle.BackgroundImage, DefaultLeftToolWindowFrameWidth));
			}
			set
			{
				SetValue("LeftToolWindowFrameWidth", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultLeftToolWindowFrameWidth => 4;

		/// 
		/// Gets or sets the width of the right tool window frame.
		/// </summary>
		/// The width of the right tool window frame.</value>
		[Category("Sizes")]
		[Description("The width of the right tool window frame.")]
		public virtual int RightToolWindowFrameWidth
		{
			get
			{
				return GetValue("RightToolWindowFrameWidth", GetImageWidth(ActiveToolWindowStyle.RightStyle.BackgroundImage, DefaultRightToolWindowFrameWidth));
			}
			set
			{
				SetValue("RightToolWindowFrameWidth", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultRightToolWindowFrameWidth => 4;

		/// 
		/// Gets or sets the height of the top tool window frame.
		/// </summary>
		/// The height of the top tool window frame.</value>
		[Category("Sizes")]
		[Description("The height of the top tool window frame.")]
		public virtual int TopToolWindowFrameHeight
		{
			get
			{
				return GetValue("TopToolWindowFrameHeight", GetImageHeight(ActiveToolWindowStyle.TopStyle.BackgroundImage, DefaultTopToolWindowFrameHeight));
			}
			set
			{
				SetValue("TopToolWindowFrameHeight", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultTopToolWindowFrameHeight => 4;

		/// 
		/// Gets or sets the height of the bottom tool window frame.
		/// </summary>
		/// The height of the bottom tool window frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom tool window frame.")]
		public virtual int BottomToolWindowFrameHeight
		{
			get
			{
				return GetValue("BottomToolWindowFrameHeight", GetImageHeight(ActiveToolWindowStyle.BottomStyle.BackgroundImage, DefaultBottomToolWindowFrameHeight));
			}
			set
			{
				SetValue("BottomToolWindowFrameHeight", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultBottomToolWindowFrameHeight => 4;

		/// 
		/// Gets the normal active tool style.
		/// </summary>
		/// The normal active tool style.</value>
		[Category("States")]
		[Description("The normal active tool style.")]
		public virtual FrameStyleValue ActiveToolWindowStyle => new FrameStyleValue(LeftBottomActiveToolWindowStyle, LeftActiveToolWindowStyle, LeftTopActiveToolWindowStyle, TopActiveToolWindowStyle, RightTopActiveToolWindowStyle, RightActiveToolWindowStyle, RightBottomActiveToolWindowStyle, BottomActiveToolWindowStyle, CenterActiveToolWindowStyle);

		/// 
		/// Gets the tool window captions style.
		/// </summary>
		/// The tool window captions style.</value>
		[Category("States")]
		[Description("The tool window captions style.")]
		public virtual StyleValue ToolWindowCaptionStyle => new StyleValue(this, "ToolWindowCaptionStyle");

		/// 
		/// Gets the tool window buttons style.
		/// </summary>
		/// The tool window buttons style.</value>
		[Category("States")]
		[Description("The tool window buttons style.")]
		public virtual StyleValue ToolWindowButtonsStyle => new StyleValue(this, "ToolWindowButtonsStyle");

		/// 
		/// Gets the tool window close button normal style.
		/// </summary>
		/// The tool window close button normal style.</value>
		[Category("States")]
		[Description("The tool window close button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowCloseButtonNormalStyle => new BidirectionalSkinValue<object>(this, ToolWindowCloseButtonNormalStyleLTR, ToolWindowCloseButtonNormalStyleRTL);

		/// 
		/// Gets the tool window close button normal style LTR.
		/// </summary>
		/// The tool window close button normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowCloseButtonNormalStyleLTR => new StyleValue(this, "ToolWindowCloseButtonNormalStyleLTR");

		/// 
		/// Gets the tool window close button normal style RTL.
		/// </summary>
		/// The tool window close button normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowCloseButtonNormalStyleRTL => new StyleValue(this, "ToolWindowCloseButtonNormalStyleRTL");

		/// 
		/// Gets the tool window close button hover style.
		/// </summary>
		/// The tool window close button hover style.</value>
		[Category("States")]
		[Description("The tool window hover close button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowCloseButtonHoverStyle => new BidirectionalSkinValue<object>(this, ToolWindowCloseButtonHoverStyleLTR, ToolWindowCloseButtonHoverStyleRTL);

		/// 
		/// Gets the tool window close button hover style LTR.
		/// </summary>
		/// The tool window close button hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowCloseButtonHoverStyleLTR => new StyleValue(this, "ToolWindowCloseButtonHoverStyleLTR", ToolWindowCloseButtonNormalStyleLTR);

		/// 
		/// Gets the tool window close button hover style RTL.
		/// </summary>
		/// The tool window close button hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowCloseButtonHoverStyleRTL => new StyleValue(this, "ToolWindowCloseButtonHoverStyleRTL", ToolWindowCloseButtonNormalStyleRTL);

		/// 
		/// Gets the tool window close button disabled style.
		/// </summary>
		/// The tool window close button disabled style.</value>
		[Category("States")]
		[Description("The tool window disabled close button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowCloseButtonDisabledStyle => new BidirectionalSkinValue<object>(this, ToolWindowCloseButtonDisabledStyleLTR, ToolWindowCloseButtonDisabledStyleRTL);

		/// 
		/// Gets the tool window close button disabled style LTR.
		/// </summary>
		/// The tool window close button disabled style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowCloseButtonDisabledStyleLTR => new StyleValue(this, "ToolWindowCloseButtonDisabledStyleLTR", ToolWindowCloseButtonNormalStyleLTR);

		/// 
		/// Gets the tool window close button disabled style RTL.
		/// </summary>
		/// The tool window close button disabled style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowCloseButtonDisabledStyleRTL => new StyleValue(this, "ToolWindowCloseButtonDisabledStyleRTL", ToolWindowCloseButtonNormalStyleRTL);

		/// 
		/// Gets or sets the size of the tool window close button.
		/// </summary>
		/// The size of the tool window close button.</value>
		[Category("Sizes")]
		[Description("The size of the tool window close button.")]
		public virtual Size ToolWindowCloseButtonSize
		{
			get
			{
				return GetValue("ToolWindowCloseButtonSize", GetImageSize(ToolWindowCloseButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
			}
			set
			{
				SetValue("ToolWindowCloseButtonSize", value);
			}
		}

		/// 
		/// Gets the width of the tool window close button.
		/// </summary>
		/// The width of the tool window close button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ToolWindowCloseButtonWidth => ToolWindowCloseButtonSize.Width;

		/// 
		/// Gets the height of the tool window close button.
		/// </summary>
		/// The height of the tool window close button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ToolWindowCloseButtonHeight => ToolWindowCloseButtonSize.Height;

		/// 
		/// Gets the tool window minimize button normal style.
		/// </summary>
		/// The tool window minimize button normal style.</value>
		[Category("States")]
		[Description("The tool window minimize button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowMinimizeButtonNormalStyle => new BidirectionalSkinValue<object>(this, ToolWindowMinimizeButtonNormalStyleLTR, ToolWindowMinimizeButtonNormalStyleRTL);

		/// 
		/// Gets the tool window minimize button normal style LTR.
		/// </summary>
		/// The tool window minimize button normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMinimizeButtonNormalStyleLTR => new StyleValue(this, "ToolWindowMinimizeButtonNormalStyleLTR");

		/// 
		/// Gets the tool window minimize button normal style RTL.
		/// </summary>
		/// The tool window minimize button normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMinimizeButtonNormalStyleRTL => new StyleValue(this, "ToolWindowMinimizeButtonNormalStyleRTL");

		/// 
		/// Gets the tool window minimize button hover style.
		/// </summary>
		/// The tool window minimize button hover style.</value>
		[Category("States")]
		[Description("The tool window hover minimize button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowMinimizeButtonHoverStyle => new BidirectionalSkinValue<object>(this, ToolWindowMinimizeButtonHoverStyleLTR, ToolWindowMinimizeButtonHoverStyleRTL);

		/// 
		/// Gets the tool window minimize button hover style LTR.
		/// </summary>
		/// The tool window minimize button hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMinimizeButtonHoverStyleLTR => new StyleValue(this, "ToolWindowMinimizeButtonHoverStyleLTR", ToolWindowMinimizeButtonNormalStyleLTR);

		/// 
		/// Gets the tool window minimize button hover style RTL.
		/// </summary>
		/// The tool window minimize button hover style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMinimizeButtonHoverStyleRTL => new StyleValue(this, "ToolWindowMinimizeButtonHoverStyleRTL", ToolWindowMinimizeButtonNormalStyleRTL);

		/// 
		/// Gets the tool window minimize button disabled style.
		/// </summary>
		/// The tool window minimize button disabled style.</value>
		[Category("States")]
		[Description("The tool window disabled minimize button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowMinimizeButtonDisabledStyle => new BidirectionalSkinValue<object>(this, ToolWindowMinimizeButtonDisabledStyleLTR, ToolWindowMinimizeButtonDisabledStyleRTL);

		/// 
		/// Gets the tool window minimize button disabled style LTR.
		/// </summary>
		/// The tool window minimize button disabled style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMinimizeButtonDisabledStyleLTR => new StyleValue(this, "ToolWindowMinimizeButtonDisabledStyleLTR", ToolWindowMinimizeButtonNormalStyleLTR);

		/// 
		/// Gets the tool window minimize button disabled style RTL.
		/// </summary>
		/// The tool window minimize button disabled style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMinimizeButtonDisabledStyleRTL => new StyleValue(this, "ToolWindowMinimizeButtonDisabledStyleRTL", ToolWindowMinimizeButtonNormalStyleRTL);

		/// 
		/// Gets or sets the size of the tool window minimize button.
		/// </summary>
		/// The size of the tool window minimize button.</value>
		[Category("Sizes")]
		[Description("The size of the tool window minimize button.")]
		public virtual Size ToolWindowMinimizeButtonSize
		{
			get
			{
				return GetValue("ToolWindowMinimizeButtonSize", GetImageSize(ToolWindowMinimizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
			}
			set
			{
				SetValue("ToolWindowMinimizeButtonSize", value);
			}
		}

		/// 
		/// Gets the width of the tool window minimize button.
		/// </summary>
		/// The width of the tool window minimize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ToolWindowMinimizeButtonWidth => ToolWindowMinimizeButtonSize.Width;

		/// 
		/// Gets the height of the tool window minimize button.
		/// </summary>
		/// The height of the tool window minimize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ToolWindowMinimizeButtonHeight => ToolWindowMinimizeButtonSize.Height;

		/// 
		/// Gets the tool window maximize button normal style.
		/// </summary>
		/// The tool window maximize button normal style.</value>
		[Category("States")]
		[Description("The tool window maximize button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowMaximizeButtonNormalStyle => new BidirectionalSkinValue<object>(this, ToolWindowMaximizeButtonNormalStyleLTR, ToolWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets the tool window maximize button normal style LTR.
		/// </summary>
		/// The tool window maximize button normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMaximizeButtonNormalStyleLTR => new StyleValue(this, "ToolWindowMaximizeButtonNormalStyleLTR");

		/// 
		/// Gets the tool window maximize button normal style RTL.
		/// </summary>
		/// The tool window maximize button normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMaximizeButtonNormalStyleRTL => new StyleValue(this, "ToolWindowMaximizeButtonNormalStyleRTL");

		/// 
		/// Gets the tool window maximize button hover style.
		/// </summary>
		/// The tool window maximize button hover style.</value>
		[Category("States")]
		[Description("The tool window hover maximize button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowMaximizeButtonHoverStyle => new BidirectionalSkinValue<object>(this, ToolWindowMaximizeButtonHoverStyleLTR, ToolWindowMaximizeButtonHoverStyleRTL);

		/// 
		/// Gets the tool window maximize button hover style LTR.
		/// </summary>
		/// The tool window maximize button hover style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMaximizeButtonHoverStyleLTR => new StyleValue(this, "ToolWindowMaximizeButtonHoverStyleLTR", ToolWindowMaximizeButtonNormalStyleLTR);

		/// 
		/// Gets the tool window maximize button hover style RTL.
		/// </summary>
		/// The tool window maximize button hover style RTL.</value>
		public virtual StyleValue ToolWindowMaximizeButtonHoverStyleRTL => new StyleValue(this, "ToolWindowMaximizeButtonHoverStyleRTL", ToolWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets the tool window maximize button disabled style.
		/// </summary>
		/// The tool window maximize button disabled style.</value>
		[Category("States")]
		[Description("The tool window disabled maximize button style.")]
		public virtual BidirectionalSkinValue<object> ToolWindowMaximizeButtonDisabledStyle => new BidirectionalSkinValue<object>(this, ToolWindowMaximizeButtonDisabledStyleLTR, ToolWindowMaximizeButtonDisabledStyleRTL);

		/// 
		/// Gets the tool window maximize button disabled style LTR.
		/// </summary>
		/// The tool window maximize button disabled style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMaximizeButtonDisabledStyleLTR => new StyleValue(this, "ToolWindowMaximizeButtonDisabledStyleLTR", ToolWindowMaximizeButtonNormalStyleLTR);

		/// 
		/// Gets the tool window maximize button disabled style RTL.
		/// </summary>
		/// The tool window maximize button disabled style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue ToolWindowMaximizeButtonDisabledStyleRTL => new StyleValue(this, "ToolWindowMaximizeButtonDisabledStyleRTL", ToolWindowMaximizeButtonNormalStyleRTL);

		/// 
		/// Gets or sets the size of the tool window maximize button.
		/// </summary>
		/// The size of the tool window maximize button.</value>
		[Category("Sizes")]
		[Description("The size of the tool window maximize button.")]
		public virtual Size ToolWindowMaximizeButtonSize
		{
			get
			{
				return GetValue("ToolWindowMaximizeButtonSize", GetImageSize(ToolWindowMaximizeButtonNormalStyleLTR.BackgroundImage, new Size(6, 6)));
			}
			set
			{
				SetValue("ToolWindowMaximizeButtonSize", value);
			}
		}

		/// 
		/// Gets the width of the tool window maximize button.
		/// </summary>
		/// The width of the tool window maximize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ToolWindowMaximizeButtonWidth => ToolWindowMaximizeButtonSize.Width;

		/// 
		/// Gets the height of the tool window maximize button.
		/// </summary>
		/// The height of the tool window maximize button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ToolWindowMaximizeButtonHeight => ToolWindowMaximizeButtonSize.Height;

		/// 
		/// Gets the center normal active tool style.
		/// </summary>
		/// The center normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterActiveToolWindowStyle => new StyleValue(this, "CenterActiveToolWindowStyle");

		/// 
		/// Gets the left normal active tool style.
		/// </summary>
		/// The left normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftActiveToolWindowStyle => new FramePartStyleValue(this, "LeftActiveToolWindowStyle");

		/// 
		/// Gets the top normal active tool style.
		/// </summary>
		/// The top normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopActiveToolWindowStyle => new FramePartStyleValue(this, "TopActiveToolWindowStyle");

		/// 
		/// Gets the bottom normal active tool style.
		/// </summary>
		/// The bottom normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomActiveToolWindowStyle => new FramePartStyleValue(this, "BottomActiveToolWindowStyle");

		/// 
		/// Gets the right normal active tool style.
		/// </summary>
		/// The right normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightActiveToolWindowStyle => new FramePartStyleValue(this, "RightActiveToolWindowStyle");

		/// 
		/// Gets the right top normal active tool style.
		/// </summary>
		/// The right top normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopActiveToolWindowStyle => new FramePartStyleValue(this, "RightTopActiveToolWindowStyle");

		/// 
		/// Gets the left top normal active tool style.
		/// </summary>
		/// The left top normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopActiveToolWindowStyle => new FramePartStyleValue(this, "LeftTopActiveToolWindowStyle");

		/// 
		/// Gets the left bottom normal active tool style.
		/// </summary>
		/// The left bottom normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomActiveToolWindowStyle => new FramePartStyleValue(this, "LeftBottomActiveToolWindowStyle");

		/// 
		/// Gets the right bottom normal active tool style.
		/// </summary>
		/// The right bottom normal active tool style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomActiveToolWindowStyle => new FramePartStyleValue(this, "RightBottomActiveToolWindowStyle");

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
		/// Gets default value
		/// </summary>
		protected virtual int DefaultPopupWindowOffsetWidth => RightPopupWindowFrameWidth + LeftPopupWindowFrameWidth;

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
		/// Gets default value
		/// </summary>
		protected virtual int DefaultPopupWindowOffsetHeight => TopPopupWindowFrameHeight + BottomPopupWindowFrameHeight;

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
		public virtual FrameStyleValue PopupWindowStyle => new FrameStyleValue(LeftBottomPopupWindowStyle, LeftPopupWindowStyle, LeftTopPopupWindowStyle, TopPopupWindowStyle, RightTopPopupWindowStyle, RightPopupWindowStyle, RightBottomPopupWindowStyle, BottomPopupWindowStyle, CenterPopupWindowStyle);

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

		/// 
		/// Gets or sets the background color.
		/// </summary>
		/// </value>
		/// Provides the default background color for design time.</remarks>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BackColor
		{
			get
			{
				return DialogBackColor;
			}
			set
			{
			}
		}

		/// 
		/// Gets the width of the minimized MDI form.
		/// </summary>
		/// The width of the minimized MDI form.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int MinimizedMdiFormWidth => MinimizedMdiFormSize.Width;

		/// 
		/// Gets the height of the minimized MDI form.
		/// </summary>
		/// The height of the minimized MDI form.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int MinimizedMdiFormHeight => MinimizedMdiFormSize.Height;

		/// 
		/// Gets or sets the size of the minimized MDI form.
		/// </summary>
		/// The size of the minimized MDI form.</value>
		[Category("Sizes")]
		[Description("Gets or sets the size of a minimized MDI form.")]
		public Size MinimizedMdiFormSize
		{
			get
			{
				return GetValue("MinimizedMdiFormSize", DefaultMinimizedMdiFormSize);
			}
			set
			{
				SetValue("MinimizedMdiFormSize", value);
			}
		}

		/// 
		/// Gets or sets the dialog background color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[Description("Gets or sets the dialog background color.")]
		public virtual Color DialogBackColor
		{
			get
			{
				return GetValue("DialogBackColor", Color.FromArgb(240, 240, 240));
			}
			set
			{
				SetValue("DialogBackColor", value);
			}
		}

		/// 
		/// Gets the dialog background.
		/// </summary>
		/// The dialog background.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundValue DialogBackground
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = DialogBackColor;
				return backgroundValue;
			}
		}

		/// 
		/// Gets or sets the window background color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[Description("Gets or sets the window background color.")]
		public virtual Color WindowBackColor
		{
			get
			{
				return GetValue("WindowBackColor", Color.Empty);
			}
			set
			{
				SetValue("WindowBackColor", value);
			}
		}

		/// 
		/// Gets the window background.
		/// </summary>
		/// The window background.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundValue WindowBackground
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = WindowBackColor;
				return backgroundValue;
			}
		}

		/// 
		/// Gets or sets the popup background color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[Description("Gets or sets the popup background color.")]
		public virtual Color PopupBackColor
		{
			get
			{
				return GetValue("PopupBackColor", Color.FromArgb(240, 240, 240));
			}
			set
			{
				SetValue("PopupBackColor", value);
			}
		}

		/// 
		/// Gets the popup background.
		/// </summary>
		/// The popup background.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundValue PopupBackground
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = PopupBackColor;
				return backgroundValue;
			}
		}

		/// 
		/// Gets the boxes bar footer style.
		/// </summary>
		/// The boxes bar footer style.</value>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("States")]
		[Description("Gets or sets the style of the boxes bar footer.")]
		public virtual StyleValue BoxesBarFooterStyle => new StyleValue(this, "BoxesBarFooterStyle");

		/// 
		/// Gets or sets the height of the boxes bar footer.
		/// </summary>
		/// The height of the boxes bar footer.</value>
		[Category("Sizes")]
		[Description("Gets or sets the height of the boxes bar footer.")]
		public virtual int BoxesBarFooterHeight
		{
			get
			{
				return GetValue("BoxesBarFooterHeight", 4);
			}
			set
			{
				SetValue("BoxesBarFooterHeight", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetWindowModalMaskOpacity()
		{
			Reset("WindowModalMaskOpacity");
		}

		/// 
		/// Resets the width of the left dialog window frame.
		/// </summary>
		internal void ResetLeftDialogWindowFrameWidth()
		{
			Reset("LeftDialogWindowFrameWidth");
		}

		/// 
		/// Resets the width of the right dialog window frame.
		/// </summary>
		internal void ResetRightDialogWindowFrameWidth()
		{
			Reset("RightDialogWindowFrameWidth");
		}

		/// 
		/// Resets the height of the top dialog window frame.
		/// </summary>
		internal void ResetTopDialogWindowFrameHeight()
		{
			Reset("TopDialogWindowFrameHeight");
		}

		/// 
		/// Resets the height of the bottom dialog window frame.
		/// </summary>
		internal void ResetBottomDialogWindowFrameHeight()
		{
			Reset("BottomDialogWindowFrameHeight");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetHeight()
		{
			Reset("DialogWindowCloseButtonSize");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetDialogWindowMinimizeButtonSize()
		{
			Reset("DialogWindowMinimizeButtonSize");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetDialogWindowMaximizeButtonSize()
		{
			Reset("DialogWindowMaximizeButtonSize");
		}

		/// 
		/// Resets the width of the left tool window frame.
		/// </summary>
		internal void ResetLeftToolWindowFrameWidth()
		{
			Reset("LeftToolWindowFrameWidth");
		}

		/// 
		/// Resets the width of the right tool window frame.
		/// </summary>
		internal void ResetRightToolWindowFrameWidth()
		{
			Reset("RightToolWindowFrameWidth");
		}

		/// 
		/// Resets the height of the top tool window frame.
		/// </summary>
		internal void ResetTopToolWindowFrameHeight()
		{
			Reset("TopToolWindowFrameHeight");
		}

		/// 
		/// Resets the height of the bottom tool window frame.
		/// </summary>
		internal void ResetBottomToolWindowFrameHeight()
		{
			Reset("BottomToolWindowFrameHeight");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetToolWindowCloseButtonSize()
		{
			Reset("ToolWindowCloseButtonSize");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetToolWindowMinimizeButtonSize()
		{
			Reset("ToolWindowMinimizeButtonSize");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetToolWindowMaximizeButtonSize()
		{
			Reset("ToolWindowMaximizeButtonSize");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetPopupWindowOffsetWidth()
		{
			Reset("PopupWindowOffsetWidth");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetPopupWindowOffsetHeight()
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

		/// 
		/// Resets the height value
		/// </summary>
		internal new void ResetBackColor()
		{
			Reset("BackColor");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetDialogBackColor()
		{
			Reset("DialogBackColor");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetWindowBackColor()
		{
			Reset("WindowBackColor");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetPopupBackColor()
		{
			Reset("PopupBackColor");
		}
	}
}

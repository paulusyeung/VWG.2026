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
	/// CheckBox Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(CheckBox), "CheckBox.bmp")]
	public class CheckBoxSkin : ButtonBaseSkin
	{
		/// 
		/// Gets the height of the check box image.
		/// </summary>
		/// The height of the check box image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CheckBoxImageHeight => GetMaxImageHeight(16, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

		/// 
		/// Gets the width of the check box image.
		/// </summary>
		/// The width of the check box image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CheckBoxImageWidth => GetMaxImageWidth(15, "CheckBox0.gif", "CheckBox1.gif", "CheckBox2.gif");

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
				return GetValue("CheckedCheckBoxImage", new ImageResourceReference(typeof(CheckBoxSkin), "CheckBox1.gif"));
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
				return GetValue("UnCheckedCheckBoxImage", new ImageResourceReference(typeof(CheckBoxSkin), "CheckBox0.gif"));
			}
			set
			{
				SetValue("UnCheckedCheckBoxImage", value);
			}
		}

		/// 
		/// Gets or sets the indeterminate check box image.
		/// </summary>
		/// The indeterminate check box image.</value>
		[SRDescription("The Indeterminate checkbox image.")]
		[SRCategory("Images")]
		public ImageResourceReference IndeterminateCheckBoxImage
		{
			get
			{
				return GetValue("IndeterminateCheckBoxImage", new ImageResourceReference(typeof(CheckBoxSkin), "CheckBox2.gif"));
			}
			set
			{
				SetValue("IndeterminateCheckBoxImage", value);
			}
		}

		/// 
		/// Gets the label normal style.
		/// </summary>
		/// The center normal style.</value>
		[Category("States")]
		[Description("The checkbox's label normal style.")]
		public virtual StyleValue LabelNormalStyle => new StyleValue(this, "LabelNormalStyle");

		/// 
		/// Gets the label focused style.
		/// </summary>
		/// The center focused style.</value>
		[Category("States")]
		[Description("The checkbox's label focused style.")]
		public virtual StyleValue LabelFocusedStyle => new StyleValue(this, "LabelFocusedStyle");

		/// 
		/// Gets the content padding.
		/// </summary>
		/// The content padding.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual PaddingValue ContentPadding => Padding;

		/// 
		/// Gets or sets the width of the left frame.
		/// </summary>
		/// The width of the left frame.</value>
		[Category("Sizes")]
		[Description("The width of the left frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int LeftFrameWidth => GetFrameEdgeSize(NormalStyle, FrameEdge.Left);

		/// 
		/// Gets or sets the width of the right frame.
		/// </summary>
		/// The width of the right frame.</value>
		[Category("Sizes")]
		[Description("The width of the right frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int RightFrameWidth => GetFrameEdgeSize(NormalStyle, FrameEdge.Right);

		/// 
		/// Gets or sets the height of the top frame.
		/// </summary>
		/// The height of the top frame.</value>
		[Category("Sizes")]
		[Description("The height of the top frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int TopFrameHeight => GetFrameEdgeSize(NormalStyle, FrameEdge.Top);

		/// 
		/// Gets or sets the height of the bottom frame.
		/// </summary>
		/// The height of the bottom frame.</value>
		[Category("Sizes")]
		[Description("The height of the bottom frame.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual int BottomFrameHeight => GetFrameEdgeSize(NormalStyle, FrameEdge.Bottom);

		/// 
		/// Gets the normal style.
		/// </summary>
		/// The normal style.</value>
		[Category("States")]
		[Description("The normal button style.")]
		public FrameStyleValue NormalStyle => new FrameStyleValue(LeftBottomNormalStyle, LeftNormalStyle, LeftTopNormalStyle, TopNormalStyle, RightTopNormalStyle, RightNormalStyle, RightBottomNormalStyle, BottomNormalStyle, CenterNormalStyle);

		/// 
		/// Gets the hover style.
		/// </summary>
		/// The hover style.</value>
		[Category("States")]
		[Description("The hover button style.")]
		public FrameStyleValue HoverStyle => new FrameStyleValue(LeftBottomHoverStyle, LeftHoverStyle, LeftTopHoverStyle, TopHoverStyle, RightTopHoverStyle, RightHoverStyle, RightBottomHoverStyle, BottomHoverStyle, CenterHoverStyle);

		/// 
		/// Gets the pressed style.
		/// </summary>
		/// The pressed style.</value>
		[Category("States")]
		[Description("The pressed button style.")]
		public FrameStyleValue PressedStyle => new FrameStyleValue(LeftBottomPressedStyle, LeftPressedStyle, LeftTopPressedStyle, TopPressedStyle, RightTopPressedStyle, RightPressedStyle, RightBottomPressedStyle, BottomPressedStyle, CenterPressedStyle);

		/// 
		/// Gets the disabled style.
		/// </summary>
		/// The disabled style.</value>
		[Category("States")]
		[Description("The disabled button style.")]
		public FrameStyleValue DisabledStyle => new FrameStyleValue(LeftBottomDisabledStyle, LeftDisabledStyle, LeftTopDisabledStyle, TopDisabledStyle, RightTopDisabledStyle, RightDisabledStyle, RightBottomDisabledStyle, BottomDisabledStyle, CenterDisabledStyle);

		/// 
		/// Gets the focused style.
		/// </summary>
		/// The focused style.</value>
		[Category("States")]
		[Description("The focused button style.")]
		public FrameStyleValue FocusedStyle => new FrameStyleValue(LeftBottomFocusedStyle, LeftFocusedStyle, LeftTopFocusedStyle, TopFocusedStyle, RightTopFocusedStyle, RightFocusedStyle, RightBottomFocusedStyle, BottomFocusedStyle, CenterFocusedStyle);

		/// 
		/// Gets the font When the button is normal.
		/// </summary>
		/// The font normal.</value>
		[Browsable(false)]
		public Font FontNormal => CenterNormalStyle.Font;

		/// 
		/// Gets the font When the button is pressed.
		/// </summary>
		/// The font pressed.</value>
		[Browsable(false)]
		public Font FontPressed => CenterPressedStyle.Font;

		/// 
		/// Gets the font When the button is hover.
		/// </summary>
		/// The font hover.</value>
		[Browsable(false)]
		public Font FontHover => CenterHoverStyle.Font;

		/// 
		/// Gets the font When the button is focused.
		/// </summary>
		/// The font focused.</value>
		[Browsable(false)]
		public Font FontFocused => CenterFocusedStyle.Font;

		/// 
		/// Gets the font When the button is disabled.
		/// </summary>
		/// The font disabled.</value>
		[Browsable(false)]
		public Font FontDisabled => CenterDisabledStyle.Font;

		/// 
		/// Gets the foreground value When the button is normal.
		/// </summary>
		/// The foreground value normal.</value>
		[Browsable(false)]
		public ForegroundValue ForegroundNormal => new ForegroundValue(CenterNormalStyle.ForeColor);

		/// 
		/// Gets the foreground value When the button is pressed.
		/// </summary>
		/// The foreground value pressed.</value>
		[Browsable(false)]
		public ForegroundValue ForegroundPressed => new ForegroundValue(CenterPressedStyle.ForeColor);

		/// 
		/// Gets the foreground value When the button is hover.
		/// </summary>
		/// The foreground value hover.</value>
		[Browsable(false)]
		public ForegroundValue ForegroundHover => new ForegroundValue(CenterHoverStyle.ForeColor);

		/// 
		/// Gets the foreground value When the button is focused.
		/// </summary>
		/// The foreground value focused.</value>
		[Browsable(false)]
		public ForegroundValue ForegroundFocused => new ForegroundValue(CenterFocusedStyle.ForeColor);

		/// 
		/// Gets the foreground value When the button is disabled.
		/// </summary>
		/// The foreground value disabled.</value>
		[Browsable(false)]
		public ForegroundValue ForegroundDisabled => new ForegroundValue(CenterDisabledStyle.ForeColor);

		/// 
		/// Gets the center normal style.
		/// </summary>
		/// The center normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterNormalStyle => new StyleValue(this, "CenterNormalStyle");

		/// 
		/// Gets the left normal style.
		/// </summary>
		/// The left normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftNormalStyle => new FramePartStyleValue(this, "LeftNormalStyle");

		/// 
		/// Gets the top normal style.
		/// </summary>
		/// The top normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopNormalStyle => new FramePartStyleValue(this, "TopNormalStyle");

		/// 
		/// Gets the bottom normal style.
		/// </summary>
		/// The bottom normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomNormalStyle => new FramePartStyleValue(this, "BottomNormalStyle");

		/// 
		/// Gets the right normal style.
		/// </summary>
		/// The right normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightNormalStyle => new FramePartStyleValue(this, "RightNormalStyle");

		/// 
		/// Gets the right top normal style.
		/// </summary>
		/// The right top normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopNormalStyle => new FramePartStyleValue(this, "RightTopNormalStyle");

		/// 
		/// Gets the left top normal style.
		/// </summary>
		/// The left top normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopNormalStyle => new FramePartStyleValue(this, "LeftTopNormalStyle");

		/// 
		/// Gets the left bottom normal style.
		/// </summary>
		/// The left bottom normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomNormalStyle => new FramePartStyleValue(this, "LeftBottomNormalStyle");

		/// 
		/// Gets the right bottom normal style.
		/// </summary>
		/// The right bottom normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomNormalStyle => new FramePartStyleValue(this, "RightBottomNormalStyle");

		/// 
		/// Gets the center hover style.
		/// </summary>
		/// The center hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterHoverStyle => new StyleValue(this, "CenterHoverStyle", CenterNormalStyle);

		/// 
		/// Gets the left hover style.
		/// </summary>
		/// The left hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftHoverStyle => new FramePartStyleValue(this, "LeftHoverStyle", LeftNormalStyle);

		/// 
		/// Gets the top hover style.
		/// </summary>
		/// The top hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopHoverStyle => new FramePartStyleValue(this, "TopHoverStyle", TopNormalStyle);

		/// 
		/// Gets the bottom hover style.
		/// </summary>
		/// The bottom hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomHoverStyle => new FramePartStyleValue(this, "BottomHoverStyle", BottomNormalStyle);

		/// 
		/// Gets the right hover style.
		/// </summary>
		/// The right hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightHoverStyle => new FramePartStyleValue(this, "RightHoverStyle", RightNormalStyle);

		/// 
		/// Gets the right top hover style.
		/// </summary>
		/// The right top hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopHoverStyle => new FramePartStyleValue(this, "RightTopHoverStyle", RightTopNormalStyle);

		/// 
		/// Gets the left top hover style.
		/// </summary>
		/// The left top hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopHoverStyle => new FramePartStyleValue(this, "LeftTopHoverStyle", LeftTopNormalStyle);

		/// 
		/// Gets the left bottom hover style.
		/// </summary>
		/// The left bottom hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomHoverStyle => new FramePartStyleValue(this, "LeftBottomHoverStyle", LeftBottomNormalStyle);

		/// 
		/// Gets the right bottom hover style.
		/// </summary>
		/// The right bottom hover style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomHoverStyle => new FramePartStyleValue(this, "RightBottomHoverStyle", RightBottomNormalStyle);

		/// 
		/// Gets the center disabled style.
		/// </summary>
		/// The center disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterDisabledStyle => new StyleValue(this, "CenterDisabledStyle", CenterNormalStyle);

		/// 
		/// Gets the left disabled style.
		/// </summary>
		/// The left disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftDisabledStyle => new FramePartStyleValue(this, "LeftDisabledStyle", LeftNormalStyle);

		/// 
		/// Gets the top disabled style.
		/// </summary>
		/// The top disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopDisabledStyle => new FramePartStyleValue(this, "TopDisabledStyle", TopNormalStyle);

		/// 
		/// Gets the bottom disabled style.
		/// </summary>
		/// The bottom disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomDisabledStyle => new FramePartStyleValue(this, "BottomDisabledStyle", BottomNormalStyle);

		/// 
		/// Gets the right disabled style.
		/// </summary>
		/// The right disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightDisabledStyle => new FramePartStyleValue(this, "RightDisabledStyle", RightNormalStyle);

		/// 
		/// Gets the right top disabled style.
		/// </summary>
		/// The right top disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopDisabledStyle => new FramePartStyleValue(this, "RightTopDisabledStyle", RightTopNormalStyle);

		/// 
		/// Gets the left top disabled style.
		/// </summary>
		/// The left top disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopDisabledStyle => new FramePartStyleValue(this, "LeftTopDisabledStyle", LeftTopNormalStyle);

		/// 
		/// Gets the left bottom disabled style.
		/// </summary>
		/// The left bottom disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomDisabledStyle => new FramePartStyleValue(this, "LeftBottomDisabledStyle", LeftBottomNormalStyle);

		/// 
		/// Gets the right bottom disabled style.
		/// </summary>
		/// The right bottom disabled style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomDisabledStyle => new FramePartStyleValue(this, "RightBottomDisabledStyle", RightBottomNormalStyle);

		/// 
		/// Gets the center focused style.
		/// </summary>
		/// The center focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterFocusedStyle => new StyleValue(this, "CenterFocusedStyle", CenterNormalStyle);

		/// 
		/// Gets the left focused style.
		/// </summary>
		/// The left focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftFocusedStyle => new FramePartStyleValue(this, "LeftFocusedStyle", LeftNormalStyle);

		/// 
		/// Gets the top focused style.
		/// </summary>
		/// The top focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopFocusedStyle => new FramePartStyleValue(this, "TopFocusedStyle", TopNormalStyle);

		/// 
		/// Gets the bottom focused style.
		/// </summary>
		/// The bottom focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomFocusedStyle => new FramePartStyleValue(this, "BottomFocusedStyle", BottomNormalStyle);

		/// 
		/// Gets the right focused style.
		/// </summary>
		/// The right focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightFocusedStyle => new FramePartStyleValue(this, "RightFocusedStyle", RightNormalStyle);

		/// 
		/// Gets the right top focused style.
		/// </summary>
		/// The right top focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopFocusedStyle => new FramePartStyleValue(this, "RightTopFocusedStyle", RightTopNormalStyle);

		/// 
		/// Gets the left top focused style.
		/// </summary>
		/// The left top focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopFocusedStyle => new FramePartStyleValue(this, "LeftTopFocusedStyle", LeftTopNormalStyle);

		/// 
		/// Gets the left bottom focused style.
		/// </summary>
		/// The left bottom focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomFocusedStyle => new FramePartStyleValue(this, "LeftBottomFocusedStyle", LeftBottomNormalStyle);

		/// 
		/// Gets the right bottom focused style.
		/// </summary>
		/// The right bottom focused style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomFocusedStyle => new FramePartStyleValue(this, "RightBottomFocusedStyle", RightBottomNormalStyle);

		/// 
		/// Gets the center pressed style.
		/// </summary>
		/// The center pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterPressedStyle => new StyleValue(this, "CenterPressedStyle", CenterNormalStyle);

		/// 
		/// Gets the left pressed style.
		/// </summary>
		/// The left pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftPressedStyle => new FramePartStyleValue(this, "LeftPressedStyle", LeftNormalStyle);

		/// 
		/// Gets the top pressed style.
		/// </summary>
		/// The top pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopPressedStyle => new FramePartStyleValue(this, "TopPressedStyle", TopNormalStyle);

		/// 
		/// Gets the bottom pressed style.
		/// </summary>
		/// The bottom pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomPressedStyle => new FramePartStyleValue(this, "BottomPressedStyle", BottomNormalStyle);

		/// 
		/// Gets the right pressed style.
		/// </summary>
		/// The right pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightPressedStyle => new FramePartStyleValue(this, "RightPressedStyle", RightNormalStyle);

		/// 
		/// Gets the right top pressed style.
		/// </summary>
		/// The right top pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopPressedStyle => new FramePartStyleValue(this, "RightTopPressedStyle", RightTopNormalStyle);

		/// 
		/// Gets the left top pressed style.
		/// </summary>
		/// The left top pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopPressedStyle => new FramePartStyleValue(this, "LeftTopPressedStyle", LeftTopNormalStyle);

		/// 
		/// Gets the left bottom pressed style.
		/// </summary>
		/// The left bottom pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomPressedStyle => new FramePartStyleValue(this, "LeftBottomPressedStyle", LeftBottomNormalStyle);

		/// 
		/// Gets the right bottom pressed style.
		/// </summary>
		/// The right bottom pressed style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomPressedStyle => new FramePartStyleValue(this, "RightBottomPressedStyle", RightBottomNormalStyle);

		private void InitializeComponent()
		{
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

		/// 
		/// Resets the indeterminate check box image.
		/// </summary>
		private void ResetIndeterminateCheckBoxImage()
		{
			Reset("IndeterminateCheckBoxImage");
		}
	}
}

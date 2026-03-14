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
	[ToolboxBitmap(typeof(TrackBar), "TrackBar.bmp")]
	public class TrackBarSkin : ControlSkin
	{
		/// 
		/// Gets the horizontal tail both style.
		/// </summary>
		/// 
		/// The horizontal tail both style.
		/// </value>
		public StyleValue HorizontalTailBothStyle => new StyleValue(this, "HorizontalTailBothStyle");

		/// 
		/// Gets the horizontal tail top style.
		/// </summary>
		/// 
		/// The horizontal tail top style.
		/// </value>
		public StyleValue HorizontalTailTopStyle => new StyleValue(this, "HorizontalTailTopStyle");

		/// 
		/// Gets the horizontal tail bottom style.
		/// </summary>
		/// 
		/// The horizontal tail bottom style.
		/// </value>
		public StyleValue HorizontalTailBottomStyle => new StyleValue(this, "HorizontalTailBottomStyle");

		/// 
		/// Gets the horizontal tail none style.
		/// </summary>
		/// 
		/// The horizontal tail none style.
		/// </value>
		public StyleValue HorizontalTailNoneStyle => new StyleValue(this, "HorizontalTailNoneStyle");

		/// 
		/// Gets the vertical tail both style.
		/// </summary>
		/// 
		/// The vertical tail both style.
		/// </value>
		public StyleValue VerticalTailBothStyle => new StyleValue(this, "VerticalTailBothStyle");

		/// 
		/// Gets the vertical tail top style.
		/// </summary>
		/// 
		/// The vertical tail top style.
		/// </value>
		public StyleValue VerticalTailTopStyle => new StyleValue(this, "VerticalTailTopStyle");

		/// 
		/// Gets the vertical tail bottom style.
		/// </summary>
		/// 
		/// The vertical tail bottom style.
		/// </value>
		public StyleValue VerticalTailBottomStyle => new StyleValue(this, "VerticalTailBottomStyle");

		/// 
		/// Gets the vertical tail none style.
		/// </summary>
		/// 
		/// The vertical tail none style.
		/// </value>
		public StyleValue VerticalTailNoneStyle => new StyleValue(this, "VerticalTailNoneStyle");

		/// 
		/// Gets or sets the slider top image.
		/// </summary>
		/// The slider top image.</value>
		[Description("Slider top image")]
		[Category("Images")]
		public ImageResourceReference SliderTop
		{
			get
			{
				return GetValue("SliderTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDU.gif"));
			}
			set
			{
				SetValue("SliderTopImage", value);
			}
		}

		/// 
		/// Gets or sets the slider bottom image.
		/// </summary>
		/// The slider bottom image.</value>
		[Description("Slider bottom image")]
		[Category("Images")]
		public ImageResourceReference SliderBottom
		{
			get
			{
				return GetValue("SliderBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUD.gif"));
			}
			set
			{
				SetValue("SliderBottomImage", value);
			}
		}

		/// 
		/// Gets or sets the slider horizontal both image.
		/// </summary>
		/// The slider horizontal both image.</value>
		[Description("Slider horizontal both image")]
		[Category("Images")]
		public ImageResourceReference SliderHorizontalBoth
		{
			get
			{
				return GetValue("SliderHorizontalBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERT.gif"));
			}
			set
			{
				SetValue("SliderHorizontalBothImage", value);
			}
		}

		/// 
		/// Gets or sets the slider left image.
		/// </summary>
		/// The slider left image.</value>
		[Description("Slider left image")]
		[Category("Images")]
		public ImageResourceReference SliderLeft
		{
			get
			{
				return GetValue("SliderLeftImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRL.gif"));
			}
			set
			{
				SetValue("SliderLeftImage", value);
			}
		}

		/// 
		/// Gets or sets the slider right image.
		/// </summary>
		/// The slider right image.</value>
		[Description("Slider right image")]
		[Category("Images")]
		public ImageResourceReference SliderRight
		{
			get
			{
				return GetValue("SliderRightImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLR.gif"));
			}
			set
			{
				SetValue("SliderRightImage", value);
			}
		}

		/// 
		/// Gets or sets the slider vertical both image.
		/// </summary>
		/// The slider vertical both image.</value>
		[Description("Slider vertical both image")]
		[Category("Images")]
		public ImageResourceReference SliderVerticalBoth
		{
			get
			{
				return GetValue("SliderVerticalBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZ.gif"));
			}
			set
			{
				SetValue("SliderVerticalBothImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal start tick top image.
		/// </summary>
		/// The horizontal start tick top image.</value>
		[Description("Horizontal start tick top image")]
		[Category("Images")]
		public ImageResourceReference HorizontalStartTickTop
		{
			get
			{
				return GetValue("HorizontalStartTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUTickL.gif"));
			}
			set
			{
				SetValue("HorizontalStartTickTopImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal start tick bottom image.
		/// </summary>
		/// The horizontal start tick bottom image.</value>
		[Description("Horizontal start tick bottom image")]
		[Category("Images")]
		public ImageResourceReference HorizontalStartTickBottom
		{
			get
			{
				return GetValue("HorizontalStartTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDTickL.gif"));
			}
			set
			{
				SetValue("HorizontalStartTickBottomImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal start tick both image.
		/// </summary>
		/// The horizontal start tick both image.</value>
		[Description("Horizontal start tick both image")]
		[Category("Images")]
		public ImageResourceReference HorizontalStartTickBoth
		{
			get
			{
				return GetValue("HorizontalStartTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTTickL.gif"));
			}
			set
			{
				SetValue("HorizontalStartTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal start tick none image.
		/// </summary>
		/// The horizontal start tick none image.</value>
		[Description("Horizontal start tick none image")]
		[Category("Images")]
		public ImageResourceReference HorizontalStartTickNone
		{
			get
			{
				return GetValue("HorizontalStartTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickL.gif"));
			}
			set
			{
				SetValue("HorizontalStartTickNoneImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal end tick top image.
		/// </summary>
		/// The horizontal end tick top image.</value>
		[Description("Horizontal end tick top image")]
		[Category("Images")]
		public ImageResourceReference HorizontalEndTickTop
		{
			get
			{
				return GetValue("HorizontalEndTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUTickR.gif"));
			}
			set
			{
				SetValue("HorizontalEndTickTopImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal end tick bottom image.
		/// </summary>
		/// The horizontal end tick bottom image.</value>
		[Description("Horizontal end tick bottom image")]
		[Category("Images")]
		public ImageResourceReference HorizontalEndTickBottom
		{
			get
			{
				return GetValue("HorizontalEndTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDTickR.gif"));
			}
			set
			{
				SetValue("HorizontalEndTickBottomImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal end tick both image.
		/// </summary>
		/// The horizontal end tick both image.</value>
		[Description("Horizontal end tick both image")]
		[Category("Images")]
		public ImageResourceReference HorizontalEndTickBoth
		{
			get
			{
				return GetValue("HorizontalEndTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTTickR.gif"));
			}
			set
			{
				SetValue("HorizontalEndTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal end tick none image.
		/// </summary>
		/// The horizontal end tick none image.</value>
		[Description("Horizontal end tick none image")]
		[Category("Images")]
		public ImageResourceReference HorizontalEndTickNone
		{
			get
			{
				return GetValue("HorizontalEndTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickR.gif"));
			}
			set
			{
				SetValue("HorizontalEndTickNoneImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal middle tick top image.
		/// </summary>
		/// The horizontal middle tick top image.</value>
		[Description("Horizontal middle tick top image")]
		[Category("Images")]
		public ImageResourceReference HorizontalMiddleTickTop
		{
			get
			{
				return GetValue("HorizontalMiddleTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUTickM.gif"));
			}
			set
			{
				SetValue("HorizontalMiddleTickTopImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal middle tick bottom image.
		/// </summary>
		/// The horizontal middle tick bottom image.</value>
		[Description("Horizontal middle tick bottom image")]
		[Category("Images")]
		public ImageResourceReference HorizontalMiddleTickBottom
		{
			get
			{
				return GetValue("HorizontalMiddleTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDTickM.gif"));
			}
			set
			{
				SetValue("HorizontalMiddleTickBottomImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal middle tick both image.
		/// </summary>
		/// The horizontal middle tick both image.</value>
		[Description("Horizontal middle tick both image")]
		[Category("Images")]
		public ImageResourceReference HorizontalMiddleTickBoth
		{
			get
			{
				return GetValue("HorizontalMiddleTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTTickM.gif"));
			}
			set
			{
				SetValue("HorizontalMiddleTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal space tick top image.
		/// </summary>
		/// The horizontal space tick top image.</value>
		[Description("Horizontal space tick top image")]
		[Category("Images")]
		public ImageResourceReference HorizontalSpaceTickTop
		{
			get
			{
				return GetValue("HorizontalSpaceTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarDUSpace.gif"));
			}
			set
			{
				SetValue("HorizontalSpaceTickTopImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal space tick bottom image.
		/// </summary>
		/// The horizontal space tick bottom image.</value>
		[Description("Horizontal space tick bottom image")]
		[Category("Images")]
		public ImageResourceReference HorizontalSpaceTickBottom
		{
			get
			{
				return GetValue("HorizontalSpaceTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarUDSpace.gif"));
			}
			set
			{
				SetValue("HorizontalSpaceTickBottomImage", value);
			}
		}

		/// 
		/// Gets or sets the horizontal space tick both image.
		/// </summary>
		/// The horizontal space tick both image.</value>
		[Description("Horizontal space tick both image")]
		[Category("Images")]
		public ImageResourceReference HorizontalSpaceTickBoth
		{
			get
			{
				return GetValue("HorizontalSpaceTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarVERTSpace.gif"));
			}
			set
			{
				SetValue("HorizontalSpaceTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical start tick top image.
		/// </summary>
		/// The vertical start tick top image.</value>
		[Description("Vertical start tick top image")]
		[Category("Images")]
		public ImageResourceReference VerticalStartTickTop
		{
			get
			{
				return GetValue("VerticalStartTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLTickU.gif"));
			}
			set
			{
				SetValue("VerticalStartTickTopImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical start tick bottom image.
		/// </summary>
		/// The vertical start tick bottom image.</value>
		[Description("Vertical start tick bottom image")]
		[Category("Images")]
		public ImageResourceReference VerticalStartTickBottom
		{
			get
			{
				return GetValue("VerticalStartTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRTickU.gif"));
			}
			set
			{
				SetValue("VerticalStartTickBottomImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical start tick both image.
		/// </summary>
		/// The vertical start tick both image.</value>
		[Description("Vertical start tick both image")]
		[Category("Images")]
		public ImageResourceReference VerticalStartTickBoth
		{
			get
			{
				return GetValue("VerticalStartTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZTickU.gif"));
			}
			set
			{
				SetValue("VerticalStartTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical start tick none image.
		/// </summary>
		/// The vertical start tick none image.</value>
		[Description("Vertical start tick none image")]
		[Category("Images")]
		public ImageResourceReference VerticalStartTickNone
		{
			get
			{
				return GetValue("VerticalStartTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickU.gif"));
			}
			set
			{
				SetValue("VerticalStartTickNoneImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical end tick top image.
		/// </summary>
		/// The vertical end tick top image.</value>
		[Description("Vertical end tick top image")]
		[Category("Images")]
		public ImageResourceReference VerticalEndTickTop
		{
			get
			{
				return GetValue("VerticalEndTickTopImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLTickD.gif"));
			}
			set
			{
				SetValue("VerticalEndTickTopImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical end tick bottom image.
		/// </summary>
		/// The vertical end tick bottom image.</value>
		[Description("Vertical end tick bottom image")]
		[Category("Images")]
		public ImageResourceReference VerticalEndTickBottom
		{
			get
			{
				return GetValue("VerticalEndTickBottomImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRTickD.gif"));
			}
			set
			{
				SetValue("VerticalEndTickBottomImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical end tick both image.
		/// </summary>
		/// The vertical end tick both image.</value>
		[Description("Vertical end tick both image")]
		[Category("Images")]
		public ImageResourceReference VerticalEndTickBoth
		{
			get
			{
				return GetValue("VerticalEndTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZTickD.gif"));
			}
			set
			{
				SetValue("VerticalEndTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical end tick none image.
		/// </summary>
		/// The vertical end tick none image.</value>
		[Description("Vertical end tick none image")]
		[Category("Images")]
		public ImageResourceReference VerticalEndTickNone
		{
			get
			{
				return GetValue("VerticalEndTickNoneImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarNOTickD.gif"));
			}
			set
			{
				SetValue("VerticalEndTickNoneImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical middle tick right image.
		/// </summary>
		/// The vertical middle tick right image.</value>
		[Description("Vertical middle tick right image")]
		[Category("Images")]
		public ImageResourceReference VerticalMiddleTickRight
		{
			get
			{
				return GetValue("VerticalMiddleTickRightImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRTickM.gif"));
			}
			set
			{
				SetValue("VerticalMiddleTickRightImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical middle tick left image.
		/// </summary>
		/// The vertical middle tick left image.</value>
		[Description("Vertical middle tick left image")]
		[Category("Images")]
		public ImageResourceReference VerticalMiddleTickLeft
		{
			get
			{
				return GetValue("VerticalMiddleTickLeftImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLTickM.gif"));
			}
			set
			{
				SetValue("VerticalMiddleTickLeftImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical middle tick both image.
		/// </summary>
		/// The vertical middle tick both image.</value>
		[Description("Vertical middle tick both image")]
		[Category("Images")]
		public ImageResourceReference VerticalMiddleTickBoth
		{
			get
			{
				return GetValue("VerticalMiddleTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZTickM.gif"));
			}
			set
			{
				SetValue("VerticalMiddleTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical space tick left image.
		/// </summary>
		/// The vertical space tick left image.</value>
		[Description("Vertical space tick left image")]
		[Category("Images")]
		public ImageResourceReference VerticalSpaceTickLeft
		{
			get
			{
				return GetValue("VerticalSpaceTickLeftImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarRLSpace.gif"));
			}
			set
			{
				SetValue("VerticalSpaceTickLeftImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical space tick right image.
		/// </summary>
		/// The vertical space tick right image.</value>
		[Description("Vertical space tick right image")]
		[Category("Images")]
		public ImageResourceReference VerticalSpaceTickRight
		{
			get
			{
				return GetValue("VerticalSpaceTickRightImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarLRSpace.gif"));
			}
			set
			{
				SetValue("VerticalSpaceTickRightImage", value);
			}
		}

		/// 
		/// Gets or sets the vertical space tick both image.
		/// </summary>
		/// The vertical space tick both image.</value>
		[Description("Vertical space tick both image")]
		[Category("Images")]
		public ImageResourceReference VerticalSpaceTickBoth
		{
			get
			{
				return GetValue("VerticalSpaceTickBothImage", new ImageResourceReference(typeof(TrackBarSkin), "TrackBarHORZSpace.gif"));
			}
			set
			{
				SetValue("VerticalSpaceTickBothImage", value);
			}
		}

		/// 
		/// Gets or sets the width of the horizontal end tick top image.
		/// </summary>
		/// The width of the horizontal end tick top image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalEndTickTopWidth => GetValue("HorizontalEndTickTopImageWidth", GetImageWidth(HorizontalEndTickTop, DefaultHorizontalEndTickTopImageWidth));

		/// 
		/// Gets the default width of the horizontal end tick top image.
		/// </summary>
		/// The default width of the horizontal end tick top image.</value>
		protected virtual int DefaultHorizontalEndTickTopImageWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal end tick bottom image.
		/// </summary>
		/// The width of the horizontal end tick bottom image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalEndTickBottomWidth => GetValue("HorizontalEndTickBottomImageWidth", GetImageWidth(HorizontalEndTickBottom, DefaultHorizontalEndTickBottomWidth));

		/// 
		/// Gets the default width of the horizontal end tick bottom image.
		/// </summary>
		/// The default width of the horizontal end tick bottom image.</value>
		protected virtual int DefaultHorizontalEndTickBottomWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal end tick both image.
		/// </summary>
		/// The width of the horizontal end tick both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalEndTickBothWidth => GetValue("HorizontalEndTickBothImageWidth", GetImageWidth(HorizontalEndTickBoth, DefaultHorizontalEndTickBothWidth));

		/// 
		/// Gets the default width of the horizontal end tick both image.
		/// </summary>
		/// The default width of the horizontal end tick both image.</value>
		protected virtual int DefaultHorizontalEndTickBothWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal end tick none image.
		/// </summary>
		/// The width of the horizontal end tick none image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalEndTickNoneWidth => GetValue("HorizontalEndTickNoneImageWidth", GetImageWidth(HorizontalEndTickNone, DefaultHorizontalEndTickNoneWidth));

		/// 
		/// Gets the default width of the horizontal end tick none image.
		/// </summary>
		/// The default width of the horizontal end tick none image.</value>
		protected virtual int DefaultHorizontalEndTickNoneWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal start tick top image.
		/// </summary>
		/// The width of the horizontal start tick top image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalStartTickTopWidth => GetValue("HorizontalStartTickTopImageWidth", GetImageWidth(HorizontalStartTickTop, DefaultHorizontalStartTickTopWidth));

		/// 
		/// Gets the default width of the horizontal start tick top image.
		/// </summary>
		/// The default width of the horizontal start tick top image.</value>
		protected virtual int DefaultHorizontalStartTickTopWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal start tick bottom image.
		/// </summary>
		/// The width of the horizontal start tick bottom image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalStartTickBottomWidth => GetValue("HorizontalStartTickBottomImageWidth", GetImageWidth(HorizontalStartTickBottom, DefaultHorizontalStartTickBottomWidth));

		/// 
		/// Gets the default width of the horizontal start tick bottom image.
		/// </summary>
		/// The default width of the horizontal start tick bottom image.</value>
		protected virtual int DefaultHorizontalStartTickBottomWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal start tick both image.
		/// </summary>
		/// The width of the horizontal start tick both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalStartTickBothWidth => GetValue("HorizontalStartTickBothImageWidth", GetImageWidth(HorizontalStartTickBoth, DefaultHorizontalStartTickBothWidth));

		/// 
		/// Gets the default width of the horizontal start tick both image.
		/// </summary>
		/// The default width of the horizontal start tick both image.</value>
		protected virtual int DefaultHorizontalStartTickBothWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal start tick none image.
		/// </summary>
		/// The width of the horizontal start tick none image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalStartTickNoneWidth => GetValue("HorizontalStartTickNoneImageWidth", GetImageWidth(HorizontalStartTickNone, DefaultHorizontalStartTickNoneWidth));

		/// 
		/// Gets the default width of the horizontal start tick none image.
		/// </summary>
		/// The default width of the horizontal start tick none image.</value>
		protected virtual int DefaultHorizontalStartTickNoneWidth => 6;

		/// 
		/// Gets or sets the width of the horizontal middle tick top image.
		/// </summary>
		/// The width of the horizontal middle tick top image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalMiddleTickTopWidth => GetValue("HorizontalMiddleTickTopImageWidth", GetImageWidth(HorizontalMiddleTickTop, DefaultHorizontalMiddleTickTopWidth));

		/// 
		/// Gets the default width of the horizontal middle tick top image.
		/// </summary>
		/// The default width of the horizontal middle tick top image.</value>
		protected virtual int DefaultHorizontalMiddleTickTopWidth => 1;

		/// 
		/// Gets or sets the width of the horizontal middle tick bottom image.
		/// </summary>
		/// The width of the horizontal middle tick bottom image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalMiddleTickBottomWidth => GetValue("HorizontalMiddleTickBottomImageWidth", GetImageWidth(HorizontalMiddleTickBottom, DefaultHorizontalMiddleTickBottomWidth));

		/// 
		/// Gets the default width of the horizontal middle tick bottom image.
		/// </summary>
		/// The default width of the horizontal middle tick bottom image.</value>
		protected virtual int DefaultHorizontalMiddleTickBottomWidth => 1;

		/// 
		/// Gets or sets the width of the horizontal middle tick both image.
		/// </summary>
		/// The width of the horizontal middle tick both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HorizontalMiddleTickBothWidth => GetValue("HorizontalMiddleTickBothImageWidth", GetImageWidth(HorizontalMiddleTickBoth, DefaultHorizontalMiddleTickBothWidth));

		/// 
		/// Gets the default width of the horizontal middle tick both image.
		/// </summary>
		/// The default width of the horizontal middle tick both image.</value>
		protected virtual int DefaultHorizontalMiddleTickBothWidth => 1;

		/// 
		/// Gets the height of the vertical start tick top image.
		/// </summary>
		/// The height of the vertical start tick top.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalStartTickTopHeight => GetValue("VerticalStartTickTopImageHeight", GetImageHeight(VerticalStartTickTop, DefaultVerticalStartTickTopHeight));

		/// 
		/// Gets the default height of the vertical start tick top image.
		/// </summary>
		/// The default height of the vertical start tick top image.</value>
		protected virtual int DefaultVerticalStartTickTopHeight => 6;

		/// 
		/// Gets or sets the height of the vertical start tick bottom image.
		/// </summary>
		/// The height of the vertical start tick bottom image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalStartTickBottomHeight => GetValue("VerticalStartTickBottomImageHeight", GetImageHeight(VerticalStartTickBottom, DefaultVerticalStartTickBottomHeight));

		/// 
		/// Gets the default height of the vertical start tick bottom image.
		/// </summary>
		/// The default height of the vertical start tick bottom image.</value>
		protected virtual int DefaultVerticalStartTickBottomHeight => 6;

		/// 
		/// Gets or sets the height of the vertical start tick both image.
		/// </summary>
		/// The height of the vertical start tick both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalStartTickBothHeight => GetValue("VerticalStartTickBothImageHeight", GetImageHeight(VerticalStartTickBoth, DefaultVerticalStartTickBothHeight));

		/// 
		/// Gets the default height of the vertical start tick both image.
		/// </summary>
		/// The default height of the vertical start tick both image.</value>
		protected virtual int DefaultVerticalStartTickBothHeight => 6;

		/// 
		/// Gets or sets the height of the vertical start tick none image.
		/// </summary>
		/// The height of the vertical start tick none image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalStartTickNoneHeight => GetValue("VerticalStartTickNoneImageHeight", GetImageHeight(VerticalStartTickNone, DefaultVerticalStartTickNoneHeight));

		/// 
		/// Gets the default height of the vertical start tick none image.
		/// </summary>
		/// The default height of the vertical start tick bottom image.</value>
		protected virtual int DefaultVerticalStartTickNoneHeight => 6;

		/// 
		/// Gets or sets the height of the vertical end tick top image.
		/// </summary>
		/// The height of the vertical end tick top image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalEndTickTopHeight => GetValue("VerticalEndTickTopImageHeight", GetImageHeight(VerticalEndTickTop, DefaultVerticalEndTickTopHeight));

		/// 
		/// Gets the default height of the vertical end tick top image.
		/// </summary>
		/// The default height of the vertical end tick top image.</value>
		protected virtual int DefaultVerticalEndTickTopHeight => 6;

		/// 
		/// Gets or sets the height of the vertical end tick bottom image.
		/// </summary>
		/// The height of the vertical end tick bottom image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalEndTickBottomHeight => GetValue("VerticalEndTickBottomImageHeight", GetImageHeight(VerticalEndTickBottom, DefaultVerticalEndTickBottomHeight));

		/// 
		/// Gets the default height of the vertical end tick bottom image.
		/// </summary>
		/// The default height of the vertical end tick bottom image.</value>
		protected virtual int DefaultVerticalEndTickBottomHeight => 6;

		/// 
		/// Gets or sets the height of the vertical end tick both image.
		/// </summary>
		/// The height of the vertical end tick both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalEndTickBothHeight => GetValue("VerticalEndTickBothImageHeight", GetImageHeight(VerticalEndTickBoth, DefaultVerticalEndTickBothHeight));

		/// 
		/// Gets the default height of the vertical end tick both image.
		/// </summary>
		/// The default height of the vertical end tick both image.</value>
		protected virtual int DefaultVerticalEndTickBothHeight => 6;

		/// 
		/// Gets or sets the height of the vertical end tick none image.
		/// </summary>
		/// The height of the vertical end tick none image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalEndTickNoneHeight => GetValue("VerticalEndTickNoneImageHeight", GetImageHeight(VerticalEndTickNone, DefaultVerticalEndTickNoneHeight));

		/// 
		/// Gets the default height of the vertical end tick none image.
		/// </summary>
		/// The default height of the vertical end tick none image.</value>
		protected virtual int DefaultVerticalEndTickNoneHeight => 6;

		/// 
		/// Gets or sets the height of the vertical middle tick left image.
		/// </summary>
		/// The height of the vertical middle tick left image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalMiddleTickLeftHeight => GetValue("VerticalMiddleTickLeftImageHeight", GetImageHeight(VerticalMiddleTickLeft, DefaultVerticalMiddleTickLeftHeight));

		/// 
		/// Gets the default height of the vertical middle tick left image.
		/// </summary>
		/// The default height of the vertical middle tick left image.</value>
		protected virtual int DefaultVerticalMiddleTickLeftHeight => 1;

		/// 
		/// Gets the height of the vertical middle tick right image.
		/// </summary>
		/// The height of the vertical middle tick right.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalMiddleTickRightHeight => GetValue("VerticalMiddleTickRightImageHeight", GetImageHeight(VerticalMiddleTickRight, DefaultVerticalMiddleTickRightHeight));

		/// 
		/// Gets the default height of the vertical middle tick right image.
		/// </summary>
		/// The default height of the vertical middle tick right image.</value>
		protected virtual int DefaultVerticalMiddleTickRightHeight => 1;

		/// 
		/// Gets or sets the height of the vertical middle tick both image.
		/// </summary>
		/// The height of the vertical middle tick both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int VerticalMiddleTickBothHeight => GetValue("VerticalMiddleTickBothImageHeight", GetImageHeight(VerticalMiddleTickBoth, DefaultVerticalMiddleTickBothHeight));

		/// 
		/// Gets the default height of the vertical middle tick both image.
		/// </summary>
		/// The default height of the vertical middle tick both image.</value>
		protected virtual int DefaultVerticalMiddleTickBothHeight => 1;

		/// 
		/// Gets the width of the slider top image.
		/// </summary>
		/// The width of the slider top image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SliderTopWidth => GetValue("SliderTopWidth", GetImageWidth(SliderTop, DefaultSliderTopWidth));

		/// 
		/// Gets the default width of the slider top image.
		/// </summary>
		/// The default width of the slider top image.</value>
		protected int DefaultSliderTopWidth => 12;

		/// 
		/// Gets the width of the slider bottom image.
		/// </summary>
		/// The width of the slider bottom image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SliderBottomWidth => GetValue("SliderBottomWidth", GetImageWidth(SliderBottom, DefaultSliderBottomWidth));

		/// 
		/// Gets the default width of the slider bottom image.
		/// </summary>
		/// The default width of the slider bottom image.</value>
		protected int DefaultSliderBottomWidth => 12;

		/// 
		/// Gets the width of the slider horizontal both image.
		/// </summary>
		/// The width of the slider horizontal both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SliderHorizontalBothWidth => GetValue("SliderHorizontalBothWidth", GetImageWidth(SliderHorizontalBoth, DefaultSliderHorizontalBothWidth));

		/// 
		/// Gets the default width of the slider horizontal both image.
		/// </summary>
		/// The default width of the slider horizontal both image.</value>
		protected int DefaultSliderHorizontalBothWidth => 12;

		/// 
		/// Gets the height of the slider left image.
		/// </summary>
		/// The height of the slider left image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SliderLeftHeight => GetValue("SliderLeftHeight", GetImageHeight(SliderLeft, DefaultSliderLeftHeight));

		/// 
		/// Gets the default height of the slider left image.
		/// </summary>
		/// The default height of the slider left image.</value>
		protected int DefaultSliderLeftHeight => 12;

		/// 
		/// Gets the height of the slider right image.
		/// </summary>
		/// The height of the slider right image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SliderRightHeight => GetValue("SliderRightHeight", GetImageHeight(SliderRight, DefaultSliderRightHeight));

		/// 
		/// Gets the default height of the slider right image.
		/// </summary>
		/// The default height of the slider right image.</value>
		protected int DefaultSliderRightHeight => 12;

		/// 
		/// Gets the height of the slider horizontal both image.
		/// </summary>
		/// The height of the slider horizontal both image.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SliderHorizontalBothHeight => GetValue("SliderHorizontalBothHeight", GetImageHeight(SliderVerticalBoth, DefaultSliderHorizontalBothHeight));

		/// 
		/// Gets the default height of the slider horizontal both image.
		/// </summary>
		/// The default height of the slider horizontal both image.</value>
		protected int DefaultSliderHorizontalBothHeight => 12;

		/// 
		/// Resets the slider top image.
		/// </summary>
		private void ResetSliderTop()
		{
			Reset("SliderTopImage");
		}

		/// 
		/// Resets the slider bottom image.
		/// </summary>
		private void ResetSliderBottom()
		{
			Reset("SliderBottomImage");
		}

		/// 
		/// Resets the slider horizontal both image.
		/// </summary>
		private void ResetSliderHorizontalBoth()
		{
			Reset("SliderHorizontalBothImage");
		}

		/// 
		/// Resets the slider left image.
		/// </summary>
		private void ResetSliderLeft()
		{
			Reset("SliderLeftImage");
		}

		/// 
		/// Resets the slider right image.
		/// </summary>
		private void ResetSliderRight()
		{
			Reset("SliderRightImage");
		}

		/// 
		/// Resets the slider vertical both image.
		/// </summary>
		private void ResetSliderVerticalBoth()
		{
			Reset("SliderVerticalBothImage");
		}

		/// 
		/// Resets the horizontal start tick top image.
		/// </summary>
		private void ResetHorizontalStartTickTop()
		{
			Reset("HorizontalStartTickTopImage");
		}

		/// 
		/// Resets the horizontal start tick bottom image.
		/// </summary>
		private void ResetHorizontalStartTickBottom()
		{
			Reset("HorizontalStartTickBottomImage");
		}

		/// 
		/// Resets the horizontal start tick both image.
		/// </summary>
		private void ResetHorizontalStartTickBoth()
		{
			Reset("HorizontalStartTickBothImage");
		}

		/// 
		/// Resets the horizontal start tick None image.
		/// </summary>
		private void ResetHorizontalStartTickNone()
		{
			Reset("HorizontalStartTickNoneImage");
		}

		/// 
		/// Resets the horizontal end tick top image.
		/// </summary>
		private void ResetHorizontalEndTickTop()
		{
			Reset("HorizontalEndTickTopImage");
		}

		/// 
		/// Resets the horizontal end tick bottom image.
		/// </summary>
		private void ResetHorizontalEndTickBottom()
		{
			Reset("HorizontalEndTickBottomImage");
		}

		/// 
		/// Resets the horizontal end tick both image.
		/// </summary>
		private void ResetHorizontalEndTickBoth()
		{
			Reset("HorizontalEndTickBothImage");
		}

		/// 
		/// Resets the horizontal end tick none image.
		/// </summary>
		private void ResetHorizontalEndTickNone()
		{
			Reset("HorizontalEndTickNoneImage");
		}

		/// 
		/// Resets the horizontal middle tick top image.
		/// </summary>
		private void ResetHorizontalMiddleTickTop()
		{
			Reset("HorizontalMiddleTickTopImage");
		}

		/// 
		/// Resets the horizontal middle tick bottom image.
		/// </summary>
		private void ResetHorizontalMiddleTickBottom()
		{
			Reset("HorizontalMiddleTickBottomImage");
		}

		/// 
		/// Resets the horizontal middle tick both image.
		/// </summary>
		private void ResetHorizontalMiddleTickBoth()
		{
			Reset("HorizontalMiddleTickBothImage");
		}

		/// 
		/// Resets the horizontal space tick top image.
		/// </summary>
		private void ResetHorizontalSpaceTickTop()
		{
			Reset("HorizontalSpaceTickTopImage");
		}

		/// 
		/// Resets the horizontal space tick bottom image.
		/// </summary>
		private void ResetHorizontalSpaceTickBottom()
		{
			Reset("HorizontalSpaceTickBottomImage");
		}

		/// 
		/// Resets the horizontal space tick both image.
		/// </summary>
		private void ResetHorizontalSpaceTickBoth()
		{
			Reset("HorizontalSpaceTickBothImage");
		}

		/// 
		/// Resets the vertical start tick top image.
		/// </summary>
		private void ResetVerticalStartTickTop()
		{
			Reset("VerticalStartTickTopImage");
		}

		/// 
		/// Resets the vertical start tick bottom image.
		/// </summary>
		private void ResetVerticalStartTickBottom()
		{
			Reset("VerticalStartTickBottomImage");
		}

		/// 
		/// Resets the vertical start tick both image.
		/// </summary>
		private void ResetVerticalStartTickBoth()
		{
			Reset("VerticalStartTickBothImage");
		}

		/// 
		/// Resets the vertical start tick none image.
		/// </summary>
		private void ResetVerticalStartTickNone()
		{
			Reset("VerticalStartTickNoneImage");
		}

		/// 
		/// Resets the vertical end tick top image.
		/// </summary>
		private void ResetVerticalEndTickTop()
		{
			Reset("VerticalEndTickTopImage");
		}

		/// 
		/// Resets the vertical end tick bottom image.
		/// </summary>
		private void ResetVerticalEndTickBottom()
		{
			Reset("VerticalEndTickBottomImage");
		}

		/// 
		/// Resets the vertical end tick both image.
		/// </summary>
		private void ResetVerticalEndTickBoth()
		{
			Reset("VerticalEndTickBothImage");
		}

		/// 
		/// Resets the vertical end tick none image.
		/// </summary>
		private void ResetVerticalEndTickNone()
		{
			Reset("VerticalEndTickNoneImage");
		}

		/// 
		/// Resets the vertical middle tick right image.
		/// </summary>
		private void ResetVerticalMiddleTickRight()
		{
			Reset("VerticalMiddleTickRightImage");
		}

		/// 
		/// Resets the vertical middle tick left image.
		/// </summary>
		private void ResetVerticalMiddleTickLeft()
		{
			Reset("VerticalMiddleTickLeftImage");
		}

		/// 
		/// Resets the vertical middle tick both image.
		/// </summary>
		private void ResetVerticalMiddleTickBoth()
		{
			Reset("VerticalMiddleTickBothImage");
		}

		/// 
		/// Resets the vertical space tick left image.
		/// </summary>
		private void ResetVerticalSpaceTickLeft()
		{
			Reset("VerticalSpaceTickLeftImage");
		}

		/// 
		/// Resets the vertical space tick right image.
		/// </summary>
		private void ResetVerticalSpaceTickRight()
		{
			Reset("VerticalSpaceTickRightImage");
		}

		/// 
		/// Resets the vertical space tick both image.
		/// </summary>
		private void ResetVerticalSpaceTickBoth()
		{
			Reset("VerticalSpaceTickBothImage");
		}
	}
}

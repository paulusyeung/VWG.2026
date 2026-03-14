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
	/// Provides the highest level of shared resources 
	/// </summary>
	[Serializable]
	[SkinDependency(typeof(LoadingSkin))]
	[SkinDependency(typeof(PopupsSkin))]
	[SkinDependency(typeof(TaskBarSkin))]
	[SkinDependency(typeof(ToolTipSkin))]
	public class CommonSkin : Skin
	{
		/// 
		/// Specifies one of four Frame edges
		/// </summary>
		protected internal enum FrameEdge : byte
		{
			/// 
			/// The control's frame Top edge. 
			/// </summary>
			Top = 1,
			/// 
			/// The control's frame Right edge.
			/// </summary>
			Right,
			/// 
			/// The control's frame Bottom edge.
			/// </summary>
			Bottom,
			/// 
			/// The control's frame Left edge.
			/// </summary>
			Left
		}

		/// 
		///
		/// </summary>
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public class ArrowsScrollerProperties
		{
			/// 
			///
			/// </summary>
			[TypeConverter(typeof(ExpandableObjectConverter))]
			public class ArrowSideProperties
			{
				private CommonSkin mobjCommonSkin;

				private string mstrSide;

				/// 
				/// Gets or sets the thickness.
				/// </summary>
				/// 
				/// The thickness.
				/// </value>
				public int Thickness
				{
					get
					{
						return mobjCommonSkin.GetArrowThickness(mstrSide);
					}
					set
					{
						mobjCommonSkin.SetArrowThickness(mstrSide, value);
					}
				}

				/// 
				/// Gets the normal style.
				/// </summary>
				public StyleValue NormalStyle => mobjCommonSkin.GetArrowStyleValue(mstrSide, "Normal");

				/// 
				/// Gets the hover style.
				/// </summary>
				public StyleValue HoverStyle => mobjCommonSkin.GetArrowStyleValue(mstrSide, "Hover");

				/// 
				/// Gets the pressed style.
				/// </summary>
				public StyleValue PressedStyle => mobjCommonSkin.GetArrowStyleValue(mstrSide, "Pressed");

				/// 
				/// Gets the disabled style.
				/// </summary>
				public StyleValue DisabledStyle => mobjCommonSkin.GetArrowStyleValue(mstrSide, "Disabled");

				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.CommonSkin.ArrowsScrollerProperties.ArrowSideProperties" /> class.
				/// </summary>
				/// <param name="objCommonSkin">The obj common skin.</param>
				/// <param name="strSide">The STR side.</param>
				public ArrowSideProperties(CommonSkin objCommonSkin, string strSide)
				{
					if (string.IsNullOrEmpty(strSide))
					{
						throw new ArgumentException(strSide);
					}
					mstrSide = strSide;
					mobjCommonSkin = objCommonSkin;
				}
			}

			private ArrowSideProperties mobjTop;

			private ArrowSideProperties mobjRight;

			private ArrowSideProperties mobjBottom;

			private ArrowSideProperties mobjLeft;

			private CommonSkin mobjCommonSkin;

			/// 
			/// Gets the top.
			/// </summary>
			public ArrowSideProperties Top => mobjTop;

			/// 
			/// Gets the right.
			/// </summary>
			public ArrowSideProperties Right => mobjRight;

			/// 
			/// Gets the bottom.
			/// </summary>
			public ArrowSideProperties Bottom => mobjBottom;

			/// 
			/// Gets the left.
			/// </summary>
			public ArrowSideProperties Left => mobjLeft;

			/// 
			/// Gets or sets the horizontal hover speed.
			/// </summary>
			/// 
			/// The horizontal hover speed.
			/// </value>
			public int HorizontalHoverSpeed
			{
				get
				{
					return mobjCommonSkin.HorizontalHoverSpeed;
				}
				set
				{
					mobjCommonSkin.HorizontalHoverSpeed = value;
				}
			}

			/// 
			/// Gets or sets the horizontal down speed.
			/// </summary>
			/// 
			/// The horizontal down speed.
			/// </value>
			public int HorizontalDownSpeed
			{
				get
				{
					return mobjCommonSkin.HorizontalDownSpeed;
				}
				set
				{
					mobjCommonSkin.HorizontalDownSpeed = value;
				}
			}

			/// 
			/// Gets or sets the vertical hover speed.
			/// </summary>
			/// 
			/// The vertical hover speed.
			/// </value>
			public int VerticalHoverSpeed
			{
				get
				{
					return mobjCommonSkin.VerticalHoverSpeed;
				}
				set
				{
					mobjCommonSkin.VerticalHoverSpeed = value;
				}
			}

			/// 
			/// Gets or sets the vertical down speed.
			/// </summary>
			/// 
			/// The vertical down speed.
			/// </value>
			public int VerticalDownSpeed
			{
				get
				{
					return mobjCommonSkin.VerticalDownSpeed;
				}
				set
				{
					mobjCommonSkin.VerticalDownSpeed = value;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.CommonSkin.ArrowsScrollerProperties" /> class.
			/// </summary>
			/// <param name="objCommonSkin">The obj common skin.</param>
			public ArrowsScrollerProperties(CommonSkin objCommonSkin)
			{
				if (objCommonSkin == null)
				{
					throw new ArgumentNullException("objCommonSkin");
				}
				mobjCommonSkin = objCommonSkin;
				mobjTop = new ArrowSideProperties(objCommonSkin, "Top");
				mobjRight = new ArrowSideProperties(objCommonSkin, "Right");
				mobjBottom = new ArrowSideProperties(objCommonSkin, "Bottom");
				mobjLeft = new ArrowSideProperties(objCommonSkin, "Left");
			}
		}

		[NonSerialized]
		private Font mobjDefaultFont = null;

		[NonSerialized]
		private ArrowsScrollerProperties mobjArrowsScrollerProperties;

		/// 
		/// Gets or sets the font of the text displayed by the control.
		/// </summary>
		/// </value>
		/// Font is defined as an ambient property which means that in inherits from is container.</remarks>
		[Category("Fonts")]
		[SRDescription("ControlFontDescr")]
		public virtual Font Font
		{
			get
			{
				return GetAmbientValue("Font", DefaultFont);
			}
			set
			{
				SetValue("Font", value);
			}
		}

		/// 
		/// Gets the default font.
		/// </summary>
		/// The default font.</value>
		private Font DefaultFont
		{
			get
			{
				if (mobjDefaultFont == null)
				{
					mobjDefaultFont = new Font("Tahoma", 8.25f);
				}
				return mobjDefaultFont;
			}
		}

		/// 
		/// Gets the default color of the fore.
		/// </summary>
		/// The default color of the fore.</value>
		protected virtual Color DefaultForeColor => Color.Black;

		/// 
		/// Gets the foreground.
		/// </summary>
		/// The foreground.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ForegroundValue Foreground
		{
			get
			{
				ForegroundValue foregroundValue = new ForegroundValue();
				foregroundValue.ForeColor = ForeColor;
				return foregroundValue;
			}
		}

		/// 
		/// Gets or sets the fore color.
		/// </summary>
		/// </value>
		/// ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
		[Category("Colors")]
		[SRDescription("ControlForeColorDescr")]
		[Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.ColorEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		public virtual Color ForeColor
		{
			get
			{
				return GetAmbientValue("ForeColor", DefaultForeColor);
			}
			set
			{
				SetValue("ForeColor", value);
			}
		}

		/// 
		/// Gets the loading animation box.
		/// </summary>
		/// The loading animation box.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue LoadingAnimationBox
		{
			get
			{
				if (base.Owner == null || !(SkinFactory.GetSkin(base.Owner, typeof(LoadingSkin)) is LoadingSkin { LoadingAnimationStyle: var loadingAnimationStyle }))
				{
					return null;
				}
				return loadingAnimationStyle;
			}
		}

		/// 
		/// Gets the loading animation image.
		/// </summary>
		/// 
		/// The loading animation image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ImageResourceReference LoadingAnimationImage
		{
			get
			{
				if (base.Owner != null)
				{
					StyleValue loadingAnimationBox = LoadingAnimationBox;
					if (loadingAnimationBox != null)
					{
						return loadingAnimationBox.BackgroundImage;
					}
				}
				return null;
			}
		}

		/// 
		/// Gets the box shadow popup offset.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string BoxShadowPopupOffset
		{
			get
			{
				if (base.Owner == null || !(SkinFactory.GetSkin(base.Owner, typeof(PopupsSkin)) is PopupsSkin { BoxShadowPopupOffset: var boxShadowPopupOffset }))
				{
					return string.Empty;
				}
				return boxShadowPopupOffset;
			}
		}

		/// 
		/// Gets the loading template.
		/// </summary>
		/// The loading template.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public TextResourceReference LoadingTemplate => new TextResourceReference(typeof(LoadingSkin), "Loading.htm");

		/// 
		/// Gets the loading animation.
		/// </summary>
		/// 
		/// The loading animation.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public TextResourceReference LoadingAnimationHtml => new TextResourceReference(typeof(LoadingSkin), "LoadingAnimation.htm");

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public TextResourceReference TaskBarTemplate => new TextResourceReference(typeof(TaskBarSkin), "TaskBarTemplate.htm");

		/// 
		/// Gets the web set style function.
		/// </summary>
		/// The web set style function.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public TextResourceReference WebSetStyleFunction => new TextResourceReference(typeof(CommonSkin), "Common.Web.SetStyle.js");

		/// 
		/// Gets the task bar item content class.
		/// </summary>
		/// The task bar item content class.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public CssClassMemberReference TaskBarItemContentClass => new CssClassMemberReference(typeof(TaskBarSkin), "TaskBar-ItemContent");

		/// 
		/// Gets the task bar item image class.
		/// </summary>
		/// The task bar item image class.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public CssClassMemberReference TaskBarItemImageClass => new CssClassMemberReference(typeof(TaskBarSkin), "TaskBar-ItemImage");

		/// 
		/// Gets the task bar item label class.
		/// </summary>
		/// The task bar item label class.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public CssClassMemberReference TaskBarItemLabelClass => new CssClassMemberReference(typeof(TaskBarSkin), "TaskBar-ItemLabel");

		/// 
		/// Gets the modal window style.
		/// </summary>
		/// The modal window style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue WindowModalMaskStyle
		{
			get
			{
				if (base.Owner == null || !(SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin { WindowModalMaskStyle: var windowModalMaskStyle }))
				{
					return null;
				}
				return windowModalMaskStyle;
			}
		}

		/// 
		/// Gets the dialog window height offset.
		/// </summary>
		/// The dialog window height offset.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DialogWindowHeightOffset
		{
			get
			{
				if (base.Owner != null && SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin formSkin)
				{
					return formSkin.TopDialogWindowFrameHeight + formSkin.BottomDialogWindowFrameHeight;
				}
				return 0;
			}
		}

		/// 
		/// Gets the dialog window width offset.
		/// </summary>
		/// The dialog window width offset.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DialogWindowWidthOffset
		{
			get
			{
				if (base.Owner != null && SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin formSkin)
				{
					return formSkin.LeftDialogWindowFrameWidth + formSkin.RightDialogWindowFrameWidth;
				}
				return 0;
			}
		}

		/// 
		/// Gets the tool window height offset.
		/// </summary>
		/// The tool window height offset.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ToolWindowHeightOffset
		{
			get
			{
				if (base.Owner != null && SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin formSkin)
				{
					return formSkin.TopToolWindowFrameHeight + formSkin.BottomToolWindowFrameHeight;
				}
				return 0;
			}
		}

		/// 
		/// Gets the tool window width offset.
		/// </summary>
		/// The tool window width offset.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ToolWindowWidthOffset
		{
			get
			{
				if (base.Owner != null && SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin formSkin)
				{
					return formSkin.LeftToolWindowFrameWidth + formSkin.RightToolWindowFrameWidth;
				}
				return 0;
			}
		}

		/// 
		/// Gets the transparent modal window mask opacity.
		/// </summary>
		/// The transparent modal window mask opacity.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public OpacityValue WindowModalTransparentMaskOpacity => new OpacityValue(1);

		/// 
		/// Gets the modal window mask opacity.
		/// </summary>
		/// The modal window mask opacity.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public OpacityValue WindowModalMaskOpacity
		{
			get
			{
				if (base.Owner == null || !(SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin { WindowModalMaskOpacity: var windowModalMaskOpacity }))
				{
					return null;
				}
				return windowModalMaskOpacity;
			}
		}

		/// 
		/// Gets the width of the minimized MDI form.
		/// </summary>
		/// The width of the minimized MDI form.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MinimizedMdiFormWidth
		{
			get
			{
				if (base.Owner == null || !(SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin { MinimizedMdiFormWidth: var minimizedMdiFormWidth }))
				{
					return 0;
				}
				return minimizedMdiFormWidth;
			}
		}

		/// 
		/// Gets the height of the minimized MDI form.
		/// </summary>
		/// The height of the minimized MDI form.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MinimizedMdiFormHeight
		{
			get
			{
				if (base.Owner == null || !(SkinFactory.GetSkin(base.Owner, typeof(FormSkin)) is FormSkin { MinimizedMdiFormHeight: var minimizedMdiFormHeight }))
				{
					return 0;
				}
				return minimizedMdiFormHeight;
			}
		}

		/// 
		/// Gets or sets the layout padding.
		/// </summary>
		/// 
		/// The layout padding.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("The default layout padding.")]
		public int ButtonImageTextGap
		{
			get
			{
				return GetValue("ButtonImageTextGap", 2);
			}
			set
			{
				SetValue("ButtonImageTextGap", value);
			}
		}

		/// 
		/// Gets the arrows scroll properties.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual ArrowsScrollerProperties ArrowsScrollProperties => mobjArrowsScrollerProperties;

		/// 
		/// Gets the arrow scroller left normal style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerLeftNormalStyle => new StyleValue(this, "ArrowScrollerLeftNormalStyle");

		/// 
		/// Gets the arrow scroller left hover style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerLeftHoverStyle => new StyleValue(this, "ArrowScrollerLeftHoverStyle");

		/// 
		/// Gets the arrow scroller left pressed style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerLeftPressedStyle => new StyleValue(this, "ArrowScrollerLeftPressedStyle");

		/// 
		/// Gets the arrow scroller left disabled style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerLeftDisabledStyle => new StyleValue(this, "ArrowScrollerLeftDisabledStyle");

		/// 
		/// Gets the arrow scroller top normal style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerTopNormalStyle => new StyleValue(this, "ArrowScrollerTopNormalStyle");

		/// 
		/// Gets the arrow scroller top hover style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerTopHoverStyle => new StyleValue(this, "ArrowScrollerTopHoverStyle");

		/// 
		/// Gets the arrow scroller top pressed style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerTopPressedStyle => new StyleValue(this, "ArrowScrollerTopPressedStyle");

		/// 
		/// Gets the arrow scroller top disabled style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerTopDisabledStyle => new StyleValue(this, "ArrowScrollerTopDisabledStyle");

		/// 
		/// Gets the arrow scroller right normal style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerRightNormalStyle => new StyleValue(this, "ArrowScrollerRightNormalStyle");

		/// 
		/// Gets the arrow scroller right hover style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerRightHoverStyle => new StyleValue(this, "ArrowScrollerRightHoverStyle");

		/// 
		/// Gets the arrow scroller right pressed style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerRightPressedStyle => new StyleValue(this, "ArrowScrollerRightPressedStyle");

		/// 
		/// Gets the arrow scroller right disabled style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerRightDisabledStyle => new StyleValue(this, "ArrowScrollerRightDisabledStyle");

		/// 
		/// Gets the arrow scroller bottom normal style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerBottomNormalStyle => new StyleValue(this, "ArrowScrollerBottomNormalStyle");

		/// 
		/// Gets the arrow scroller bottom hover style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerBottomHoverStyle => new StyleValue(this, "ArrowScrollerBottomHoverStyle");

		/// 
		/// Gets the arrow scroller bottom pressed style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerBottomPressedStyle => new StyleValue(this, "ArrowScrollerBottomPressedStyle");

		/// 
		/// Gets the arrow scroller bottom disabled style.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public StyleValue ArrowScrollerBottomDisabledStyle => new StyleValue(this, "ArrowScrollerBottomDisabledStyle");

		/// 
		/// Gets or sets the horizontal hover speed.
		/// </summary>
		/// 
		/// The horizontal hover speed.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HorizontalHoverSpeed
		{
			get
			{
				return GetValue("ArrowsHorizontalHoverSpeed", 50);
			}
			set
			{
				SetValue("ArrowsHorizontalHoverSpeed", value);
			}
		}

		/// 
		/// Gets or sets the horizontal down speed.
		/// </summary>
		/// 
		/// The horizontal down speed.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HorizontalDownSpeed
		{
			get
			{
				return GetValue("ArrowsHorizontalDownSpeed", 20);
			}
			set
			{
				SetValue("ArrowsHorizontalDownSpeed", value);
			}
		}

		/// 
		/// Gets or sets the vertical hover speed.
		/// </summary>
		/// 
		/// The vertical hover speed.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int VerticalHoverSpeed
		{
			get
			{
				return GetValue("ArrowsHorizontalHoverSpeed", 50);
			}
			set
			{
				SetValue("ArrowsHorizontalHoverSpeed", value);
			}
		}

		/// 
		/// Gets or sets the vertical down speed.
		/// </summary>
		/// 
		/// The vertical down speed.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int VerticalDownSpeed
		{
			get
			{
				return GetValue("ArrowsHorizontalDownSpeed", 20);
			}
			set
			{
				SetValue("ArrowsHorizontalDownSpeed", value);
			}
		}

		/// 
		/// Gets the arrow top thickness.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ArrowTopThickness => GetArrowThickness("Top");

		/// 
		/// Gets the arrow right thickness.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ArrowRightThickness => GetArrowThickness("Right");

		/// 
		/// Gets the arrow bottom thickness.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ArrowBottomThickness => GetArrowThickness("Bottom");

		/// 
		/// Gets the arrow left thickness.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ArrowLeftThickness => GetArrowThickness("Left");

		/// 
		/// Gets the selected indicator style.
		/// </summary>
		/// 
		/// The selected indicator style.
		/// </value>
		[Category("States")]
		[Description("The selected indicator style.")]
		public SelectedIndicatorStyleValue SelectedIndicatorStyle => new SelectedIndicatorStyleValue(LeftBottomSelectedIndicatorStyle, LeftSelectedIndicatorStyle, LeftTopSelectedIndicatorStyle, TopSelectedIndicatorStyle, RightTopSelectedIndicatorStyle, RightSelectedIndicatorStyle, RightBottomSelectedIndicatorStyle, BottomSelectedIndicatorStyle);

		/// 
		/// Gets the left bottom selected indicator style.
		/// </summary>
		/// 
		/// The left bottom selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue LeftBottomSelectedIndicatorStyle => new StyleValue(this, "LeftBottomSelectedIndicatorStyle");

		/// 
		/// Gets the left selected indicator style.
		/// </summary>
		/// 
		/// The left selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue LeftSelectedIndicatorStyle => new StyleValue(this, "LeftSelectedIndicatorStyle");

		/// 
		/// Gets the left top selected indicator style.
		/// </summary>
		/// 
		/// The left top selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue LeftTopSelectedIndicatorStyle => new StyleValue(this, "LeftTopSelectedIndicatorStyle");

		/// 
		/// Gets the top selected indicator style.
		/// </summary>
		/// 
		/// The top selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue TopSelectedIndicatorStyle => new StyleValue(this, "TopSelectedIndicatorStyle");

		/// 
		/// Gets the right top selected indicator style.
		/// </summary>
		/// 
		/// The right top selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue RightTopSelectedIndicatorStyle => new StyleValue(this, "RightTopSelectedIndicatorStyle");

		/// 
		/// Gets the right selected indicator style.
		/// </summary>
		/// 
		/// The right selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue RightSelectedIndicatorStyle => new StyleValue(this, "RightSelectedIndicatorStyle");

		/// 
		/// Gets the right bottom selected indicator style.
		/// </summary>
		/// 
		/// The right bottom selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue RightBottomSelectedIndicatorStyle => new StyleValue(this, "RightBottomSelectedIndicatorStyle");

		/// 
		/// Gets the bottom selected indicator style.
		/// </summary>
		/// 
		/// The bottom selected indicator style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleValue BottomSelectedIndicatorStyle => new StyleValue(this, "BottomSelectedIndicatorStyle");

		/// 
		/// Gets the size of the selected indicator.
		/// </summary>
		/// 
		/// The size of the selected indicator.
		/// </value>
		[Category("Sizes")]
		[Description("The selected indicator style.")]
		public SelectedIndicatorSizeValue SelectedIndicatorSize => new SelectedIndicatorSizeValue(this);

		/// 
		/// Gets or sets the size of the left bottom selected indicator.
		/// </summary>
		/// 
		/// The size of the left bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size LeftBottomSelectedIndicatorSize
		{
			get
			{
				return GetValue("LeftBottomSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("LeftBottomSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the left selected indicator.
		/// </summary>
		/// 
		/// The size of the left selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size LeftSelectedIndicatorSize
		{
			get
			{
				return GetValue("LeftSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("LeftSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the left top selected indicator.
		/// </summary>
		/// 
		/// The size of the left top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size LeftTopSelectedIndicatorSize
		{
			get
			{
				return GetValue("LeftTopSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("LeftTopSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the top selected indicator.
		/// </summary>
		/// 
		/// The size of the top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size TopSelectedIndicatorSize
		{
			get
			{
				return GetValue("TopSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("TopSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the right top selected indicator.
		/// </summary>
		/// 
		/// The size of the right top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size RightTopSelectedIndicatorSize
		{
			get
			{
				return GetValue("RightTopSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("RightTopSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the right selected indicator.
		/// </summary>
		/// 
		/// The size of the right selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size RightSelectedIndicatorSize
		{
			get
			{
				return GetValue("RightSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("RightSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the right bottom selected indicator.
		/// </summary>
		/// 
		/// The size of the right bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size RightBottomSelectedIndicatorSize
		{
			get
			{
				return GetValue("RightBottomSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("RightBottomSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the bottom selected indicator.
		/// </summary>
		/// 
		/// The size of the bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size BottomSelectedIndicatorSize
		{
			get
			{
				return GetValue("BottomSelectedIndicatorSize", new Size(4, 4));
			}
			set
			{
				SetValue("BottomSelectedIndicatorSize", value);
			}
		}

		/// 
		/// Gets the height of the right bottom selected indicator.
		/// </summary>
		/// 
		/// The height of the right bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightBottomSelectedIndicatorHeight => RightBottomSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the right bottom selected indicator.
		/// </summary>
		/// 
		/// The width of the right bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightBottomSelectedIndicatorWidth => RightBottomSelectedIndicatorSize.Width;

		/// 
		/// Gets the height of the left bottom selected indicator.
		/// </summary>
		/// 
		/// The height of the left bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftBottomSelectedIndicatorHeight => LeftBottomSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the left bottom selected indicator.
		/// </summary>
		/// 
		/// The width of the left bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftBottomSelectedIndicatorWidth => LeftBottomSelectedIndicatorSize.Width;

		/// 
		/// Gets the height of the left top selected indicator.
		/// </summary>
		/// 
		/// The height of the left top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftTopSelectedIndicatorHeight => LeftTopSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the left top selected indicator.
		/// </summary>
		/// 
		/// The width of the left top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftTopSelectedIndicatorWidth => LeftTopSelectedIndicatorSize.Width;

		/// 
		/// Gets the height of the right top selected indicator.
		/// </summary>
		/// 
		/// The height of the right top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightTopSelectedIndicatorHeight => RightTopSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the right top selected indicator.
		/// </summary>
		/// 
		/// The width of the right top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightTopSelectedIndicatorWidth => RightTopSelectedIndicatorSize.Width;

		/// 
		/// Gets the height of the bottom selected indicator.
		/// </summary>
		/// 
		/// The height of the bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int BottomSelectedIndicatorHeight => BottomSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the bottom selected indicator.
		/// </summary>
		/// 
		/// The width of the bottom selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int BottomSelectedIndicatorWidth => BottomSelectedIndicatorSize.Width;

		/// 
		/// Gets the height of the left selected indicator.
		/// </summary>
		/// 
		/// The height of the left selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftSelectedIndicatorHeight => LeftSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the left selected indicator.
		/// </summary>
		/// 
		/// The width of the left selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftSelectedIndicatorWidth => LeftSelectedIndicatorSize.Width;

		/// 
		/// Gets the height of the top selected indicator.
		/// </summary>
		/// 
		/// The height of the top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TopSelectedIndicatorHeight => TopSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the top selected indicator.
		/// </summary>
		/// 
		/// The width of the top selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TopSelectedIndicatorWidth => TopSelectedIndicatorSize.Width;

		/// 
		/// Gets the height of the right selected indicator.
		/// </summary>
		/// 
		/// The height of the right selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightSelectedIndicatorHeight => RightSelectedIndicatorSize.Height;

		/// 
		/// Gets the width of the right selected indicator.
		/// </summary>
		/// 
		/// The width of the right selected indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightSelectedIndicatorWidth => RightSelectedIndicatorSize.Width;

		/// 
		/// Gets the marked indicator style.
		/// </summary>
		/// 
		/// The marked indicator style.
		/// </value>
		public StyleValue MarkedIndicatorStyle => new StyleValue(this, "MarkedIndicatorStyle");

		/// 
		/// Gets the height of the marked indicator.
		/// </summary>
		/// 
		/// The height of the marked indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MarkedIndicatorHeight => MarkedIndicatorSize.Height;

		/// 
		/// Gets the width of the marked indicator.
		/// </summary>
		/// 
		/// The width of the marked indicator.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MarkedIndicatorWidth => MarkedIndicatorSize.Width;

		/// 
		/// Gets or sets the size of the marked indicator.
		/// </summary>
		/// 
		/// The size of the marked indicator.
		/// </value>
		public Size MarkedIndicatorSize
		{
			get
			{
				return GetValue("MarkedIndicatorSize", new Size(16, 16));
			}
			set
			{
				SetValue("MarkedIndicatorSize", value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.CommonSkin" /> class.
		/// </summary>
		public CommonSkin()
		{
			mobjArrowsScrollerProperties = new ArrowsScrollerProperties(this);
		}

		/// 
		/// Filters the properties.
		/// </summary>
		/// <param name="objPropertyDescriptorCollection">The obj property descriptor collection.</param>
		/// <param name="attributes">The attributes.</param>
		public override PropertyDescriptorCollection FilterProperties(PropertyDescriptorCollection objPropertyDescriptorCollection, Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.FilterProperties(objPropertyDescriptorCollection, attributes);
			if (propertyDescriptorCollection != null && GetType() != typeof(CommonSkin))
			{
				List<object> list = new List<object><object>();
				foreach (PropertyDescriptor item in propertyDescriptorCollection)
				{
					string name = item.Name;
					if (!(name == "SelectedIndicatorStyle") && !(name == "SelectedIndicatorSize"))
					{
						list.Add(item);
					}
				}
				propertyDescriptorCollection = new PropertyDescriptorCollection(list.ToArray());
			}
			return propertyDescriptorCollection;
		}

		/// 
		/// Resets the font.
		/// </summary>
		private void ResetFont()
		{
			Reset("Font");
		}

		/// 
		/// Resets the fore color.
		/// </summary>
		private void ResetForeColor()
		{
			Reset("ForeColor");
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Gets the size of the image.
		/// </summary>
		/// <param name="objFrameStyleValue">The frame style value.</param>
		/// <param name="enmFrameEdge">The frame edge.</param>
		/// </returns>
		protected internal int GetFrameEdgeSize(FrameStyleValue objFrameStyleValue, FrameEdge enmFrameEdge)
		{
			int val;
			int val2;
			int val3;
			switch (enmFrameEdge)
			{
			case FrameEdge.Bottom:
				val = GetImageHeight(objFrameStyleValue.LeftBottomStyle.BackgroundImage);
				val2 = GetImageHeight(objFrameStyleValue.BottomStyle.BackgroundImage);
				val3 = GetImageHeight(objFrameStyleValue.RightBottomStyle.BackgroundImage);
				break;
			case FrameEdge.Left:
				val = GetImageWidth(objFrameStyleValue.LeftBottomStyle.BackgroundImage);
				val2 = GetImageWidth(objFrameStyleValue.LeftStyle.BackgroundImage);
				val3 = GetImageWidth(objFrameStyleValue.LeftTopStyle.BackgroundImage);
				break;
			case FrameEdge.Right:
				val = GetImageWidth(objFrameStyleValue.RightTopStyle.BackgroundImage);
				val2 = GetImageWidth(objFrameStyleValue.RightStyle.BackgroundImage);
				val3 = GetImageWidth(objFrameStyleValue.RightBottomStyle.BackgroundImage);
				break;
			case FrameEdge.Top:
				val = GetImageHeight(objFrameStyleValue.LeftTopStyle.BackgroundImage);
				val2 = GetImageHeight(objFrameStyleValue.TopStyle.BackgroundImage);
				val3 = GetImageHeight(objFrameStyleValue.RightTopStyle.BackgroundImage);
				break;
			default:
				return 0;
			}
			return Math.Max(val, Math.Max(val2, val3));
		}

		/// 
		/// Gets the arrow style value.
		/// </summary>
		/// <param name="strSide">The STR side.</param>
		/// <param name="strStyle">The STR style.</param>
		/// </returns>
		private StyleValue GetArrowStyleValue(string strSide, string strStyle)
		{
			return new StyleValue(this, $"ArrowScroller{strSide}{strStyle}Style");
		}

		/// 
		/// Gets the arrow thickness.
		/// </summary>
		/// <param name="mstrSide">The MSTR side.</param>
		/// </returns>
		private int GetArrowThickness(string mstrSide)
		{
			return GetValue($"Arrow{mstrSide}Thickness", (mstrSide == "Left" || mstrSide == "Right") ? GetImageWidth(GetArrowStyleValue(mstrSide, "Normal").BackgroundImage) : GetImageHeight(GetArrowStyleValue(mstrSide, "Normal").BackgroundImage));
		}

		/// 
		/// Sets the arrow thickness.
		/// </summary>
		/// <param name="mstrSide">The MSTR side.</param>
		/// <param name="objValue">The obj value.</param>
		private void SetArrowThickness(string mstrSide, int objValue)
		{
			SetValue($"Arrow{mstrSide}Thickness", objValue);
		}

		/// 
		/// Resets the left bottom selected indicator style.
		/// </summary>
		internal void ResetLeftBottomSelectedIndicatorStyle()
		{
			Reset("LeftBottomSelectedIndicatorStyle");
		}

		/// 
		/// Resets the left selected indicator style.
		/// </summary>
		internal void ResetLeftSelectedIndicatorStyle()
		{
			Reset("LeftSelectedIndicatorStyle");
		}

		/// 
		/// Resets the left top selected indicator style.
		/// </summary>
		internal void ResetLeftTopSelectedIndicatorStyle()
		{
			Reset("LeftTopSelectedIndicatorStyle");
		}

		/// 
		/// Resets the top selected indicator style.
		/// </summary>
		internal void ResetTopSelectedIndicatorStyle()
		{
			Reset("TopSelectedIndicatorStyle");
		}

		/// 
		/// Resets the right top selected indicator style.
		/// </summary>
		internal void ResetRightTopSelectedIndicatorStyle()
		{
			Reset("RightTopSelectedIndicatorStyle");
		}

		/// 
		/// Resets the right selected indicator style.
		/// </summary>
		internal void ResetRightSelectedIndicatorStyle()
		{
			Reset("RightSelectedIndicatorStyle");
		}

		/// 
		/// Resets the right bottom selected indicator style.
		/// </summary>
		internal void ResetRightBottomSelectedIndicatorStyle()
		{
			Reset("ResetRightBottomSelectedIndicatorStyle");
		}

		/// 
		/// Resets the bottom selected indicator style.
		/// </summary>
		internal void ResetBottomSelectedIndicatorStyle()
		{
			Reset("BottomSelectedIndicatorStyle");
		}

		/// 
		/// Resets the size of the left bottom selected indicator.
		/// </summary>
		internal void ResetLeftBottomSelectedIndicatorSize()
		{
			Reset("LeftBottomSelectedIndicatorSize");
		}

		/// 
		/// Resets the size of the left selected indicator.
		/// </summary>
		internal void ResetLeftSelectedIndicatorSize()
		{
			Reset("LeftSelectedIndicatorSize");
		}

		/// 
		/// Resets the size of the left top selected indicator.
		/// </summary>
		internal void ResetLeftTopSelectedIndicatorSize()
		{
			Reset("LeftTopSelectedIndicatorSize");
		}

		/// 
		/// Resets the size of the top selected indicator.
		/// </summary>
		internal void ResetTopSelectedIndicatorSize()
		{
			Reset("TopSelectedIndicatorSize");
		}

		/// 
		/// Resets the size of the right top selected indicator.
		/// </summary>
		internal void ResetRightTopSelectedIndicatorSize()
		{
			Reset("RightTopSelectedIndicatorSize");
		}

		/// 
		/// Resets the size of the right selected indicator.
		/// </summary>
		internal void ResetRightSelectedIndicatorSize()
		{
			Reset("RightSelectedIndicatorSize");
		}

		/// 
		/// Resets the size of the right bottom selected indicator.
		/// </summary>
		internal void ResetRightBottomSelectedIndicatorSize()
		{
			Reset("RightBottomSelectedIndicatorSize");
		}

		/// 
		/// Resets the size of the bottom selected indicator.
		/// </summary>
		internal void ResetBottomSelectedIndicatorSize()
		{
			Reset("BottomSelectedIndicatorSize");
		}

		/// 
		/// Resets the marked indicator style.
		/// </summary>
		internal void ResetMarkedIndicatorStyle()
		{
			Reset("MarkedIndicatorStyle");
		}

		/// 
		/// Resets the size of the marked indicator.
		/// </summary>
		internal void ResetMarkedIndicatorSize()
		{
			Reset("MarkedIndicatorSize");
		}
	}
}

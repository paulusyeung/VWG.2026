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
	/// Provides generic control styling mechanism
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(StyleValueConverter))]
	public class StyleValue : SkinMultiValue
	{
		/// 
		/// Gets or sets the font of the text displayed by the control.
		/// </summary>
		/// </value>
		/// Font is defined as an ambient property which means that in inherits from is container.</remarks>
		[Category("Fonts")]
		[SRDescription("ControlFontDescr")]
		public Font Font
		{
			get
			{
				return GetValue("Font", DefaultFont);
			}
			set
			{
				SetValue("Font", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has font.
		/// </summary>
		/// true</c> if this instance has font; otherwise, false</c>.</value>
		protected bool HasFont => HasValue("Font");

		/// 
		/// Gets or sets the default font.
		/// </summary>
		/// </value>
		protected Font DefaultFont
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).Font;
				}
				return ((CommonSkin)base.Skin).Font;
			}
		}

		/// 
		/// Gets or sets the background image.
		/// </summary>
		/// The background image.</value>
		[SRDescription("ControlBackgroundImageDescr")]
		[SRCategory("CatAppearance")]
		public ImageResourceReference BackgroundImage
		{
			get
			{
				return GetValue("BackgroundImage", DefaultBackgroundImage);
			}
			set
			{
				SetValue("BackgroundImage", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has background image.
		/// </summary>
		/// 
		/// 	true</c> if this instance has background image; otherwise, false</c>.
		/// </value>
		protected bool HasBackgroundImage => BackgroundImage != ImageResourceReference.Empty;

		/// 
		/// Gets or sets the default background image.
		/// </summary>
		/// </value>
		protected virtual ImageResourceReference DefaultBackgroundImage
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).GetValue("BackgroundImage", ImageResourceReference.Empty);
				}
				if (!(base.Skin is ControlSkin { BackgroundImage: var backgroundImage }))
				{
					return ImageResourceReference.Empty;
				}
				return backgroundImage;
			}
		}

		/// 
		/// Gets or sets the background image repeat.
		/// </summary>
		/// The background image repeat.</value>
		[SRDescription("Sets if or how a background image will be repeated.")]
		[SRCategory("CatAppearance")]
		public BackgroundImageRepeat BackgroundImageRepeat
		{
			get
			{
				return GetValue("BackgroundImageRepeat", DefaultBackgroundImageRepeat);
			}
			set
			{
				SetValue("BackgroundImageRepeat", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has background image repeat.
		/// </summary>
		/// 
		/// 	true</c> if this instance has background image repeat; otherwise, false</c>.
		/// </value>
		protected bool HasBackgroundImageRepeat => HasValue("BackgroundImageRepeat");

		/// 
		/// Gets or sets the default background image repeat.
		/// </summary>
		/// </value>
		protected virtual BackgroundImageRepeat DefaultBackgroundImageRepeat
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).BackgroundImageRepeat;
				}
				return BackgroundImageRepeat.Repeat;
			}
		}

		/// 
		/// Gets or sets the background image position.
		/// </summary>
		/// The background image position.</value>
		[SRDescription("Sets the starting position of a background image.")]
		[SRCategory("CatAppearance")]
		public BackgroundImagePosition BackgroundImagePosition
		{
			get
			{
				return GetValue("BackgroundImagePosition", DefaultBackgroundImagePosition);
			}
			set
			{
				SetValue("BackgroundImagePosition", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has background image position.
		/// </summary>
		/// 
		/// 	true</c> if this instance has background image position; otherwise, false</c>.
		/// </value>
		protected bool HasBackgroundImagePosition => HasValue("BackgroundImagePosition");

		/// 
		/// Gets or sets the default background image position.
		/// </summary>
		/// </value>
		protected virtual BackgroundImagePosition DefaultBackgroundImagePosition
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).BackgroundImagePosition;
				}
				return BackgroundImagePosition.MiddleCenter;
			}
		}

		/// 
		/// Gets or sets the fore color.
		/// </summary>
		/// </value>
		/// ForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
		[Category("Colors")]
		[SRDescription("ControlForeColorDescr")]
		public Color ForeColor
		{
			get
			{
				return GetValue("ForeColor", DefaultForeColor);
			}
			set
			{
				SetValue("ForeColor", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has fore color.
		/// </summary>
		/// 
		/// 	true</c> if this instance has fore color; otherwise, false</c>.
		/// </value>
		protected bool HasForeColor => HasValue("ForeColor");

		/// 
		/// Gets or sets the default fore color.
		/// </summary>
		/// </value>
		protected virtual Color DefaultForeColor
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).ForeColor;
				}
				return ((CommonSkin)base.Skin).ForeColor;
			}
		}

		/// 
		/// Gets or sets the background color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[SRDescription("ControlBackColorDescr")]
		public virtual Color BackColor
		{
			get
			{
				return GetValue("BackColor", DefaultBackColor);
			}
			set
			{
				SetValue("BackColor", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has back color.
		/// </summary>
		/// 
		/// 	true</c> if this instance has back color; otherwise, false</c>.
		/// </value>
		protected bool HasBackColor => HasValue("BackColor");

		/// 
		/// Gets or sets the default back color.
		/// </summary>
		/// </value>
		protected virtual Color DefaultBackColor
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).BackColor;
				}
				if (!(base.Skin is ControlSkin { BackColor: var backColor }))
				{
					return Color.Empty;
				}
				return backColor;
			}
		}

		/// 
		/// Gets or sets the padding.
		/// </summary>
		/// The padding.</value>
		[SRDescription("ControlPaddingDescr")]
		[Category("Layout")]
		public PaddingValue Padding
		{
			get
			{
				return GetValue("Padding", DefaultPadding);
			}
			set
			{
				SetValue("Padding", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has padding.
		/// </summary>
		/// 
		/// 	true</c> if this instance has padding; otherwise, false</c>.
		/// </value>
		protected bool HasPadding => HasValue("Padding");

		/// 
		/// Gets or sets the opacity.
		/// </summary>
		/// The opacity.</value>
		[SRDescription("ControlOpacityDescr")]
		[Category("CatAppearance")]
		public OpacityValue Opacity
		{
			get
			{
				return GetValue("Opacity", DefaultOpacity);
			}
			set
			{
				SetValue("Opacity", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has opacity.
		/// </summary>
		/// 
		/// 	true</c> if this instance has opacity; otherwise, false</c>.
		/// </value>
		protected bool HasOpacity => HasValue("Opacity");

		/// 
		/// Gets or sets the default padding.
		/// </summary>
		/// </value>
		protected virtual PaddingValue DefaultPadding
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).GetValue("Padding", PaddingValue.Empty);
				}
				return "0";
			}
		}

		/// 
		/// Gets a value indicating whether this instance has padding.
		/// </summary>
		/// 
		/// 	true</c> if this instance has padding; otherwise, false</c>.
		/// </value>
		protected bool HasBorderRadius => HasValue("BorderRadius");

		/// 
		/// Gets the default opacity.
		/// </summary>
		/// The default opacity.</value>
		protected virtual OpacityValue DefaultOpacity
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).GetValue("Opacity", (OpacityValue)"100");
				}
				return OpacityValue.Empty;
			}
		}

		/// 
		/// Gets or sets the space between controls.
		/// </summary>
		/// The space between controls.</value>
		[Category("Layout")]
		[SRDescription("ControlMarginDescr")]
		public MarginValue Margin
		{
			get
			{
				return GetValue("Margin", DefaultMargin);
			}
			set
			{
				SetValue("Margin", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has margin.
		/// </summary>
		/// 
		/// 	true</c> if this instance has margin; otherwise, false</c>.
		/// </value>
		protected bool HasMargin => HasValue("Margin");

		/// 
		/// Gets or sets the default margin.
		/// </summary>
		/// </value>
		protected virtual MarginValue DefaultMargin
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).GetValue("Margin", MarginValue.Empty);
				}
				return MarginValue.Empty;
			}
		}

		/// 
		/// Gets or sets the width of the border.
		/// </summary>
		/// </value>
		[Category("Sizes")]
		[SRDescription("ControlBorderWidthDescr")]
		public BorderWidth BorderWidth
		{
			get
			{
				return GetValue("BorderWidth", DefaultBorderWidth);
			}
			set
			{
				SetValue("BorderWidth", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has border width.
		/// </summary>
		/// 
		/// 	true</c> if this instance has border width; otherwise, false</c>.
		/// </value>
		protected bool HasBorderWidth => HasValue("BorderWidth");

		/// 
		/// Gets or sets the default border width.
		/// </summary>
		/// </value>
		protected virtual BorderWidth DefaultBorderWidth
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).GetValue("BorderWidth", BorderWidth.Empty);
				}
				if (!(base.Skin is ControlSkin { BorderWidth: var borderWidth }))
				{
					return new BorderWidth(1);
				}
				return borderWidth;
			}
		}

		/// 
		/// Gets or sets the border color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[SRDescription("ControlBorderColorDescr")]
		public BorderColor BorderColor
		{
			get
			{
				return GetValue("BorderColor", DefaultBorderColor);
			}
			set
			{
				SetValue("BorderColor", value);
			}
		}

		/// 
		/// Gets or sets the visual effect.
		/// </summary>
		/// 
		/// The visual effect.
		/// </value>
		[Category("Styles")]
		[Description("Provide definitions for visual effects.")]
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public VisualEffectValue VisualEffect
		{
			get
			{
				return GetValue<VisualEffectValue>("VisualEffect", null);
			}
			set
			{
				SetValue("VisualEffect", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has border color.
		/// </summary>
		/// 
		/// 	true</c> if this instance has border color; otherwise, false</c>.
		/// </value>
		protected bool HasBorderColor => HasValue("BorderColor");

		/// 
		/// Gets a value indicating whether this instance has visual effect.
		/// </summary>
		/// 
		/// 	true</c> if this instance has visual effect; otherwise, false</c>.
		/// </value>
		protected bool HasVisualEffect => HasValue("VisualEffect");

		/// 
		/// Gets or sets the default border width.
		/// </summary>
		/// </value>
		protected virtual BorderColor DefaultBorderColor
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).GetValue("BorderColor", new BorderColor(Color.FromArgb(111, 157, 217)));
				}
				if (!(base.Skin is ControlSkin { BorderColor: var borderColor }))
				{
					return BorderColor.Empty;
				}
				return borderColor;
			}
		}

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// </value>
		[Category("Styles")]
		[SRDescription("ControlBorderStyleDescr")]
		public BorderStyle BorderStyle
		{
			get
			{
				return GetValue("BorderStyle", DefaultBorderStyle);
			}
			set
			{
				SetValue("BorderStyle", value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance has border style.
		/// </summary>
		/// 
		/// 	true</c> if this instance has border style; otherwise, false</c>.
		/// </value>
		protected bool HasBorderStyle => HasValue("BorderStyle");

		/// 
		/// Gets or sets the default border style.
		/// </summary>
		/// </value>
		protected virtual BorderStyle DefaultBorderStyle
		{
			get
			{
				if (base.Defaults != null)
				{
					return ((StyleValue)base.Defaults).GetValue("BorderStyle", BorderStyle.FixedSingle);
				}
				if (!(base.Skin is ControlSkin { BorderStyle: var borderStyle }))
				{
					return BorderStyle.None;
				}
				return borderStyle;
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
		public BackgroundValue Background
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				if (HasBackColor)
				{
					backgroundValue.BackColor = BackColor;
				}
				if (HasBackgroundImage)
				{
					backgroundValue.BackgroundImage = BackgroundImage;
					backgroundValue.BackgroundImagePosition = BackgroundImagePosition;
					backgroundValue.BackgroundImageRepeat = BackgroundImageRepeat;
				}
				return backgroundValue;
			}
		}

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
		/// Gets a value indicating whether this instance has background.
		/// </summary>
		/// 
		/// 	true</c> if this instance has background; otherwise, false</c>.
		/// </value>
		protected bool HasBackground => HasBackColor || HasBackgroundImage || HasBackgroundImagePosition || HasBackgroundImageRepeat;

		/// 
		/// Gets a value indicating whether this instance has border.
		/// </summary>
		/// 
		/// 	true</c> if this instance has border; otherwise, false</c>.
		/// </value>
		protected bool HasBorder => HasBorderColor || HasBorderStyle || HasBorderWidth;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
		/// </summary>
		/// <param name="objPropertyOwner">The property owner.</param>
		/// <param name="strPropertyPrefix">The property prefix.</param>
		public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
			: base(objPropertyOwner, strPropertyPrefix)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
		/// </summary>
		/// <param name="objPropertyOwner">The property owner.</param>
		/// <param name="strPropertyPrefix">The property prefix.</param>
		public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, bool blnIsAmbientValues)
			: base(objPropertyOwner, strPropertyPrefix, null, blnIsAmbientValues)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
		/// </summary>
		/// <param name="objPropertyOwner">The property owner.</param>
		/// <param name="strPropertyPrefix">The property prefix.</param>
		/// <param name="objDefaults">The defaults.</param>
		public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, StyleValue objDefaults)
			: base(objPropertyOwner, strPropertyPrefix, objDefaults)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
		/// </summary>
		/// <param name="objPropertyOwner">The property owner.</param>
		/// <param name="strPropertyPrefix">The property prefix.</param>
		/// <param name="objDefaults">The defaults.</param>
		/// <param name="blnLocalizeBaseStyleValues">Treats inherited base style values as locals.</param>
		public StyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, StyleValue objDefaults, bool blnLocalizeBaseStyleValues)
			: base(objPropertyOwner, strPropertyPrefix, objDefaults, blnLocalizeBaseStyleValues)
		{
		}

		/// 
		/// Resets the font.
		/// </summary>
		private void ResetFont()
		{
			Reset("Font");
		}

		/// 
		/// Resets the font.
		/// </summary>
		private void ResetBackgroundImage()
		{
			Reset("BackgroundImage");
		}

		/// 
		/// Resets the BackgroundImageRepeat.
		/// </summary>
		private void ResetBackgroundImageRepeat()
		{
			Reset("BackgroundImageRepeat");
		}

		/// 
		/// Resets the ForeColor.
		/// </summary>
		private void ResetForeColor()
		{
			Reset("ForeColor");
		}

		/// 
		/// Resets the BackColor.
		/// </summary>
		private void ResetBackColor()
		{
			Reset("BackColor");
		}

		/// 
		/// Resets the Padding.
		/// </summary>
		private void ResetPadding()
		{
			Reset("Padding");
		}

		/// 
		/// Resets the opacity.
		/// </summary>
		private void ResetOpacity()
		{
			Reset("Opacity");
		}

		/// 
		/// Resets this instance.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			ResetBackColor();
			ResetBackgroundImage();
			ResetBackgroundImageRepeat();
			ResetBorderColor();
			ResetBorderStyle();
			ResetBorderWidth();
			ResetFont();
			ResetForeColor();
			ResetMargin();
			ResetPadding();
			ResetOpacity();
		}

		/// 
		/// Resets the Padding.
		/// </summary>
		private void ResetBorderRadius()
		{
			Reset("BorderRadius");
		}

		/// 
		/// Resets the Margin.
		/// </summary>
		private void ResetMargin()
		{
			Reset("Margin");
		}

		/// 
		/// Resets the BorderColor.
		/// </summary>
		private void ResetBorderWidth()
		{
			Reset("BorderWidth");
		}

		/// 
		/// Resets the visual effect.
		/// </summary>
		private void ResetVisualEffect()
		{
			Reset("VisualEffect");
		}

		/// 
		/// Resets the BorderColor.
		/// </summary>
		private void ResetBorderColor()
		{
			Reset("BorderColor");
		}

		/// 
		/// Resets the BorderColor.
		/// </summary>
		private void ResetBorderStyle()
		{
			Reset("BorderStyle");
		}

		/// 
		/// Gets the translated value.
		/// </summary>
		/// <param name="objContext">The current context.</param>
		/// </returns>
		public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (HasFont)
			{
				stringBuilder.AppendLine($"{FormatValue(SkinTranslator.GetFont(objContext, Font, objValueDefinition))};");
			}
			if (HasBackground)
			{
				stringBuilder.AppendLine($"{FormatValue(Background.GetValue(objContext, objValueDefinition))};");
			}
			if (HasForeColor)
			{
				stringBuilder.AppendLine($"{FormatValue(Foreground.GetValue(objContext, objValueDefinition))};");
			}
			if (HasBorder)
			{
				stringBuilder.AppendLine($"{FormatValue(Border.GetValue(objContext, objValueDefinition))};");
			}
			if (HasMargin)
			{
				stringBuilder.AppendLine($"{FormatValue(Margin.GetValue(objContext, objValueDefinition))};");
			}
			if (HasPadding)
			{
				stringBuilder.AppendLine($"{FormatValue(Padding.GetValue(objContext, objValueDefinition))};");
			}
			if (HasOpacity)
			{
				stringBuilder.AppendLine($"{FormatValue(Opacity.GetValue(objContext, objValueDefinition))};");
			}
			if (HasVisualEffect)
			{
				stringBuilder.AppendLine($"{FormatValue(VisualEffect.GetValue(objContext, objValueDefinition))};");
			}
			return FormatValue(stringBuilder.ToString());
		}

		private string FormatValue(string strValue)
		{
			if (string.IsNullOrEmpty(strValue))
			{
				return string.Empty;
			}
			return strValue.TrimEnd(';', '\r', '\n');
		}
	}
}

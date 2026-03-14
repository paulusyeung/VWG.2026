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
	[TypeConverter(typeof(BackgroundStyleValueConverter))]
	public class BackgroundStyleValue : SkinMultiValue
	{
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
					return ((BackgroundStyleValue)base.Defaults).GetValue("BackgroundImage", ImageResourceReference.Empty);
				}
				return ImageResourceReference.Empty;
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
					return ((BackgroundStyleValue)base.Defaults).BackgroundImageRepeat;
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
					return ((BackgroundStyleValue)base.Defaults).BackgroundImagePosition;
				}
				return BackgroundImagePosition.MiddleCenter;
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
					return ((BackgroundStyleValue)base.Defaults).BackColor;
				}
				return Color.Empty;
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
		/// Gets a value indicating whether this instance has background.
		/// </summary>
		/// 
		/// 	true</c> if this instance has background; otherwise, false</c>.
		/// </value>
		protected bool HasBackground => HasBackColor || HasBackgroundImage || HasBackgroundImagePosition || HasBackgroundImageRepeat;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BackgroundStyleValue" /> class.
		/// </summary>
		/// <param name="objPropertyOwner">The property owner.</param>
		/// <param name="strPropertyPrefix">The property prefix.</param>
		public BackgroundStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
			: base(objPropertyOwner, strPropertyPrefix)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BackgroundStyleValue" /> class.
		/// </summary>
		/// <param name="objPropertyOwner">The property owner.</param>
		/// <param name="strPropertyPrefix">The property prefix.</param>
		/// <param name="objDefaults">The defaults.</param>
		public BackgroundStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, BackgroundStyleValue objDefaults)
			: base(objPropertyOwner, strPropertyPrefix, objDefaults)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BackgroundStyleValue" /> class.
		/// </summary>
		/// <param name="objPropertyOwner">The property owner.</param>
		/// <param name="strPropertyPrefix">The property prefix.</param>
		/// <param name="objDefaults">The defaults.</param>
		/// <param name="blnLocalizeBaseBackgroundStyleValues">Treats inherited base style values as locals.</param>
		public BackgroundStyleValue(CommonSkin objPropertyOwner, string strPropertyPrefix, BackgroundStyleValue objDefaults, bool blnLocalizeBaseBackgroundStyleValues)
			: base(objPropertyOwner, strPropertyPrefix, objDefaults, blnLocalizeBaseBackgroundStyleValues)
		{
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
		/// Resets the BackColor.
		/// </summary>
		private void ResetBackColor()
		{
			Reset("BackColor");
		}

		/// 
		/// Gets the translated value.
		/// </summary>
		/// <param name="objContext">The current context.</param>
		/// </returns>
		public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (HasBackground)
			{
				stringBuilder.AppendLine($"{FormatValue(Background.GetValue(objContext))};");
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

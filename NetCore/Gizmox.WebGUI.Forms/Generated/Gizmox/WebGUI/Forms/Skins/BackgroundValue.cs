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
	/// Holds the Background Value of the control
	/// </summary>
	[Serializable]
	public class BackgroundValue : SkinValue
	{
		/// 
		/// The background color
		/// </summary>
		private Color mobjBackColor = Color.Empty;

		/// 
		/// The background image
		/// </summary>
		private ImageResourceReference mobjBackgroundImage = ImageResourceReference.Empty;

		/// 
		/// The background image repeating definition
		/// </summary>
		private BackgroundImageRepeat menmBackgroundImageRepeat = BackgroundImageRepeat.Repeat;

		/// 
		/// The background image positioning definition
		/// </summary>
		private BackgroundImagePosition menmBackgroundImagePosition = BackgroundImagePosition.MiddleCenter;

		/// 
		/// Gets or sets the color of the back.
		/// </summary>
		/// The color of the back.</value>
		public Color BackColor
		{
			get
			{
				return mobjBackColor;
			}
			set
			{
				mobjBackColor = value;
			}
		}

		/// 
		/// Gets or sets the background image.
		/// </summary>
		/// The background image.</value>
		public ImageResourceReference BackgroundImage
		{
			get
			{
				return mobjBackgroundImage;
			}
			set
			{
				mobjBackgroundImage = value;
			}
		}

		/// 
		/// Gets or sets the background image repeat.
		/// </summary>
		/// The background image repeat.</value>
		public BackgroundImageRepeat BackgroundImageRepeat
		{
			get
			{
				return menmBackgroundImageRepeat;
			}
			set
			{
				menmBackgroundImageRepeat = value;
			}
		}

		/// 
		/// Gets or sets the background image position.
		/// </summary>
		/// The background image position.</value>
		public BackgroundImagePosition BackgroundImagePosition
		{
			get
			{
				return menmBackgroundImagePosition;
			}
			set
			{
				menmBackgroundImagePosition = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BackgroundValue" /> class.
		/// </summary>
		public BackgroundValue()
		{
		}

		/// 
		/// Gets the translated value.
		/// </summary>
		/// <param name="objContext">The current context.</param>
		/// </returns>
		public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
		{
			string importantDeclarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
			StringBuilder stringBuilder = new StringBuilder();
			if (mobjBackColor != Color.Empty)
			{
				string value = $"background-color:{CommonUtils.GetHtmlColor(mobjBackColor)}{importantDeclarationValue};";
				stringBuilder.Append(value);
			}
			if (mobjBackgroundImage != ImageResourceReference.Empty)
			{
				string arg = $"background-image:url({mobjBackgroundImage.GetValue(objContext, objValueDefinition)}){importantDeclarationValue};";
				string arg2 = $"background-position:{GetCSSValue(menmBackgroundImagePosition)}{importantDeclarationValue};";
				string arg3 = $"background-repeat:{GetCSSValue(menmBackgroundImageRepeat)}{importantDeclarationValue};";
				stringBuilder.Append($"{arg}{arg2}{arg3}");
			}
			return stringBuilder.ToString();
		}

		/// 
		/// Gets the CSS value.
		/// </summary>
		/// <param name="enmBackgroundImageRepeat">The background image repeat definition.</param>
		/// </returns>
		internal static string GetCSSValue(BackgroundImageRepeat enmBackgroundImageRepeat)
		{
			return enmBackgroundImageRepeat switch
			{
				BackgroundImageRepeat.Repeat => "repeat", 
				BackgroundImageRepeat.RepeatX => "repeat-x", 
				BackgroundImageRepeat.RepeatY => "repeat-y", 
				BackgroundImageRepeat.None => "no-repeat", 
				_ => "repeat", 
			};
		}

		/// 
		/// Gets the CSS value.
		/// </summary>
		/// <param name="enmBackgroundImagePosition">The background image position.</param>
		/// </returns>
		internal static string GetCSSValue(BackgroundImagePosition enmBackgroundImagePosition)
		{
			return enmBackgroundImagePosition switch
			{
				BackgroundImagePosition.BottomCenter => "bottom center", 
				BackgroundImagePosition.BottomLeft => "bottom left", 
				BackgroundImagePosition.BottomRight => "bottom right", 
				BackgroundImagePosition.MiddleLeft => "center left", 
				BackgroundImagePosition.MiddleCenter => "center center", 
				BackgroundImagePosition.MiddleRight => "center right", 
				BackgroundImagePosition.TopLeft => "top left", 
				BackgroundImagePosition.TopCenter => "top center", 
				BackgroundImagePosition.TopRight => "top right", 
				_ => "center center", 
			};
		}
	}
}

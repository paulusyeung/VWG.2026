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
	/// Provides a way to return a composed skin value
	/// </summary>
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BorderValue : SkinValue
	{
		/// 
		///
		/// </summary>
		private BorderStyle menmStyle = BorderStyle.None;

		/// 
		///
		/// </summary>
		private BorderWidth mobjBorderWidth = BorderWidth.Empty;

		/// 
		///
		/// </summary>
		private BorderColor mobjBorderColor = BorderColor.Empty;

		/// 
		///
		/// </summary>
		private CornerRadius mobjCorner = CornerRadius.Empty;

		/// 
		/// Gets or sets the style.
		/// </summary>
		/// The style.</value>
		public BorderStyle Style
		{
			get
			{
				return menmStyle;
			}
			set
			{
				menmStyle = value;
			}
		}

		/// 
		/// Gets or sets the width.
		/// </summary>
		/// The width.</value>
		public BorderWidth Width
		{
			get
			{
				return mobjBorderWidth;
			}
			set
			{
				mobjBorderWidth = value;
			}
		}

		/// 
		/// Gets or sets the color.
		/// </summary>
		/// The color.</value>
		public BorderColor Color
		{
			get
			{
				return mobjBorderColor;
			}
			set
			{
				mobjBorderColor = value;
			}
		}

		/// 
		/// Gets or sets the corner values.
		/// </summary>
		/// The corner values.</value>
		public CornerRadius Corner
		{
			get
			{
				return mobjCorner;
			}
			set
			{
				mobjCorner = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.BorderValue" /> class.
		/// </summary>
		public BorderValue()
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
			if (menmStyle == BorderStyle.None)
			{
				return $"border:none{importantDeclarationValue};";
			}
			StringBuilder stringBuilder = new StringBuilder();
			string text = $"border-top:{mobjBorderWidth.Top}px {GetBorderName(menmStyle)} {GetBorderColor(mobjBorderColor.Top)}{importantDeclarationValue};";
			string text2 = $"border-left:{mobjBorderWidth.Left}px {GetBorderName(menmStyle)} {GetBorderColor(mobjBorderColor.Left)}{importantDeclarationValue};";
			string text3 = $"border-right:{mobjBorderWidth.Right}px {GetBorderName(menmStyle)} {GetBorderColor(mobjBorderColor.Right)}{importantDeclarationValue};";
			string text4 = $"border-bottom:{mobjBorderWidth.Bottom}px {GetBorderName(menmStyle)} {GetBorderColor(mobjBorderColor.Bottom)}{importantDeclarationValue};";
			stringBuilder.Append($"{text}{text2}{text3}{text4}");
			return stringBuilder.ToString();
		}

		/// 
		/// Gets the name of the border.
		/// </summary>
		/// <param name="enmStyle">The border style.</param>
		/// </returns>
		internal static string GetBorderName(BorderStyle enmStyle)
		{
			return enmStyle switch
			{
				BorderStyle.FixedSingle => "solid", 
				BorderStyle.Dotted => "dotted", 
				BorderStyle.Dashed => "dashed", 
				BorderStyle.Fixed3D => "solid", 
				BorderStyle.Outset => "outset", 
				BorderStyle.Inset => "inset", 
				_ => "fixed", 
			};
		}

		/// 
		/// Gets the color of the border.
		/// </summary>
		/// <param name="objColor">The border color.</param>
		/// </returns>
		internal static object GetBorderColor(Color objColor)
		{
			return CommonUtils.GetHtmlColor(objColor);
		}
	}
}

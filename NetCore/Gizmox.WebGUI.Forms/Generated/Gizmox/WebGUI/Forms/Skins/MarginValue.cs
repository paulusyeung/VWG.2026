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
	/// Holds the value for the space between controls
	/// </summary>
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[TypeConverter(typeof(MarginValueConverter))]
	public class MarginValue : PaddingValue
	{
		/// 
		/// The empty padding reference
		/// </summary>
		private static MarginValue mobjEmpty = new MarginValue(Padding.Empty);

		/// 
		/// Gets an empty padding value.
		/// </summary>
		/// The empty padding value.</value>
		public new static MarginValue Empty => mobjEmpty;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.MarginValue" /> class.
		/// </summary>
		/// <param name="objValue">The padding value.</param>
		public MarginValue(Padding objValue)
			: base(objValue)
		{
		}

		/// 
		/// Gets the name of the web style.
		/// </summary>
		/// </returns>
		protected override string GetWebStyleName()
		{
			return "margin";
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.MarginValue" /> to <see cref="T:Gizmox.WebGUI.Forms.Padding" />.
		/// </summary>
		/// <param name="objMarginValue">The margin value.</param>
		/// The result of the conversion.</returns>
		public static implicit operator Padding(MarginValue objMarginValue)
		{
			return objMarginValue?.Value ?? Padding.Empty;
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Padding" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.MarginValue" />.
		/// </summary>
		/// <param name="objPadding">The padding.</param>
		/// The result of the conversion.</returns>
		public static implicit operator MarginValue(Padding objPadding)
		{
			return new MarginValue(objPadding);
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> to <see cref="T:System.String" />.
		/// </summary>
		/// <param name="objMarginValue">The margin value.</param>
		/// The result of the conversion.</returns>
		public static implicit operator string(MarginValue objMarginValue)
		{
			if (objMarginValue.Value.IsAll)
			{
				return objMarginValue.All.ToString();
			}
			return $"{objMarginValue.Left},{objMarginValue.Top},{objMarginValue.Right},{objMarginValue.Bottom}";
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" />.
		/// </summary>
		/// <param name="strPadding">The padding string.</param>
		/// The result of the conversion.</returns>
		public static implicit operator MarginValue(string strPadding)
		{
			Padding objValue = Padding.Empty;
			if (!string.IsNullOrEmpty(strPadding))
			{
				string[] array = strPadding.Split(',');
				if (array.Length == 4)
				{
					objValue = new Padding(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]));
				}
				else if (array.Length == 1)
				{
					objValue = new Padding(int.Parse(array[0]));
				}
			}
			return new MarginValue(objValue);
		}
	}
}

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

namespace Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents
{
/// 
	///
	/// </summary>
	[Serializable]
	public class MediaFileData : IMediaFileData
	{
		private string mstrCodecs;

		private ulong mlngBitrate;

		private ulong mlngHeight;

		private ulong mlngWidth;

		private ulong mlngDuration;

		/// 
		/// Gets the codecs.
		/// </summary>
		public string Codecs
		{
			get
			{
				return mstrCodecs;
			}
			internal set
			{
				mstrCodecs = value;
			}
		}

		/// 
		/// Gets the bitrate.
		/// </summary>
		public ulong Bitrate
		{
			get
			{
				return mlngBitrate;
			}
			internal set
			{
				mlngBitrate = value;
			}
		}

		/// 
		/// Gets the height.
		/// </summary>
		public ulong Height
		{
			get
			{
				return mlngHeight;
			}
			internal set
			{
				mlngHeight = value;
			}
		}

		/// 
		/// Gets the width.
		/// </summary>
		public ulong Width
		{
			get
			{
				return mlngWidth;
			}
			internal set
			{
				mlngWidth = value;
			}
		}

		/// 
		/// Gets the duration.
		/// </summary>
		public ulong Duration
		{
			get
			{
				return mlngDuration;
			}
			internal set
			{
				mlngDuration = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents.MediaFileData" /> class.
		/// </summary>
		public MediaFileData()
		{
		}

		/// 
		/// Froms the VWG event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		internal static MediaFileData FromVWGEvent(IEvent objEvent)
		{
			MediaFileData mediaFileData = new MediaFileData();
			mediaFileData.mstrCodecs = objEvent["codecs"];
			if (ulong.TryParse(objEvent["bitrate"], out mediaFileData.mlngBitrate))
			{
			}
			if (ulong.TryParse(objEvent["height"], out mediaFileData.mlngHeight))
			{
			}
			if (ulong.TryParse(objEvent["width"], out mediaFileData.mlngWidth))
			{
			}
			if (ulong.TryParse(objEvent["duration"], out mediaFileData.mlngDuration))
			{
			}
			return mediaFileData;
		}
	}
}

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

namespace Gizmox.WebGUI.Forms
{
	/// 
	///
	/// </summary>
	[Serializable]
	[Description("A data which defines the geographic location services.")]
	[TypeConverter(typeof(GeoLocationDataTypeConverter))]
	[ToolboxItem(false)]
	[DesignTimeVisible(false)]
	public class GeoLocationData : ComponentBase
	{
		public static readonly GeoLocationData Empty = new GeoLocationData(blnRepeatCheck: false, blnEnableHighAccuracy: false, null, null);

		private bool mblnRepeatCheck = false;

		private bool mblnEnableHighAccuracy = false;

		private double? mdblMaximumAge = null;

		private double? mdblTimeout = null;

		/// 
		/// Gets or sets a value indicating whether [repeat check].
		/// </summary>
		/// 
		///   true</c> if [repeat check]; otherwise, false</c>.
		/// </value>
		[Description("Deifines whether to repeat location changed event.")]
		[DefaultValue(false)]
		[RefreshProperties(RefreshProperties.All)]
		public bool RepeatCheck
		{
			get
			{
				return mblnRepeatCheck;
			}
			set
			{
				if (mblnRepeatCheck != value)
				{
					mblnRepeatCheck = value;
					OnGeoLocationDataChanged();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [enable high accuracy].
		/// </summary>
		/// 
		///   true</c> if [enable high accuracy]; otherwise, false</c>.
		/// </value>
		[Description("Deifines whether the geo-location will be enabled with high accuracy.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(false)]
		public bool EnableHighAccuracy
		{
			get
			{
				return mblnEnableHighAccuracy;
			}
			set
			{
				if (mblnEnableHighAccuracy != value)
				{
					mblnEnableHighAccuracy = value;
					OnGeoLocationDataChanged();
				}
			}
		}

		/// 
		/// Gets or sets the maximum age.
		/// </summary>
		/// 
		/// The maximum age.
		/// </value>
		[Description("Deifines the geo-location positions maximum age (in milliseconds).")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(null)]
		public double? MaximumAge
		{
			get
			{
				if (mdblMaximumAge.HasValue && mdblMaximumAge < 0.0)
				{
					return 0.0;
				}
				return mdblMaximumAge;
			}
			set
			{
				if (mdblMaximumAge != value)
				{
					mdblMaximumAge = value;
					OnGeoLocationDataChanged();
				}
			}
		}

		/// 
		/// Gets a value indicating whether [supports geo location].
		/// </summary>
		/// 
		///   true</c> if [supports geo location]; otherwise, false</c>.
		/// </value>
		private static bool SupportsGeoLocation
		{
			get
			{
				if (VWGContext.Current is IContextParams contextParams)
				{
					return (contextParams.MISCBrowserCapabilities & MISCBrowserCapabilities.Geolocation) == MISCBrowserCapabilities.Geolocation;
				}
				return false;
			}
		}

		/// 
		/// Gets or sets the options.
		/// </summary>
		/// 
		/// The options.
		/// </value>
		[Description("Deifines the geo-location timeout for a single position request (in milliseconds).")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(null)]
		public double? Timeout
		{
			get
			{
				if (mdblTimeout.HasValue && mdblTimeout < 0.0)
				{
					return 0.0;
				}
				return mdblTimeout;
			}
			set
			{
				if (mdblTimeout != value)
				{
					mdblTimeout = value;
					OnGeoLocationDataChanged();
				}
			}
		}

		/// 
		/// Occurs when [geo location data changed].
		/// </summary>
		internal event EventHandler GeoLocationDataChanged;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GeoLocationData" /> class.
		/// </summary>
		/// <param name="blnRepeatCheck">if set to true</c> [BLN repeat check].</param>
		/// <param name="blnEnableHighAccuracy">if set to true</c> [BLN enable high accuracy].</param>
		/// <param name="dblMaximumAge">The DBL maximum age.</param>
		/// <param name="dblTimeout">The DBL timeout.</param>
		public GeoLocationData(bool blnRepeatCheck, bool blnEnableHighAccuracy, double? dblMaximumAge, double? dblTimeout)
		{
			mblnRepeatCheck = blnRepeatCheck;
			mblnEnableHighAccuracy = blnEnableHighAccuracy;
			mdblMaximumAge = dblMaximumAge;
			mdblTimeout = dblTimeout;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GeoLocationData" /> class.
		/// </summary>
		public GeoLocationData()
		{
		}

		/// 
		/// Called when [geo location data changed].
		/// </summary>
		private void OnGeoLocationDataChanged()
		{
			if (this.GeoLocationDataChanged != null)
			{
				this.GeoLocationDataChanged(this, EventArgs.Empty);
			}
		}

		/// 
		/// Resets the repeat check.
		/// </summary>
		private void ResetRepeatCheck()
		{
			RepeatCheck = Empty.RepeatCheck;
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (RepeatCheck)
			{
				AppendKey(stringBuilder, "RepeatCheck");
			}
			if (EnableHighAccuracy)
			{
				AppendKey(stringBuilder, "EnableHighAccuracy");
			}
			if (MaximumAge.HasValue)
			{
				AppendKey(stringBuilder, $"MaximumAge({MaximumAge})");
			}
			if (Timeout.HasValue)
			{
				AppendKey(stringBuilder, $"Timeout({Timeout})");
			}
			return stringBuilder.ToString();
		}

		/// 
		/// Appends the key.
		/// </summary>
		/// <param name="objBuilder">The obj builder.</param>
		/// <param name="strKey">The STR key.</param>
		private void AppendKey(StringBuilder objBuilder, string strKey)
		{
			if (objBuilder.Length > 0)
			{
				objBuilder.Append(",");
			}
			objBuilder.Append(strKey);
		}

		/// 
		/// Determines whether the specified <see cref="T:System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object" /> to compare with this instance.</param>
		/// 
		///   true</c> if the specified <see cref="T:System.Object" /> is equal to this instance; otherwise, false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (obj is GeoLocationData geoLocationData)
			{
				return RepeatCheck == geoLocationData.RepeatCheck && EnableHighAccuracy == geoLocationData.EnableHighAccuracy && MaximumAge == geoLocationData.MaximumAge && Timeout == geoLocationData.Timeout;
			}
			return base.Equals(obj);
		}

		/// 
		/// Resets the enable high accuracy.
		/// </summary>
		private void ResetEnableHighAccuracy()
		{
			EnableHighAccuracy = Empty.EnableHighAccuracy;
		}

		/// 
		/// Resets the maximum age.
		/// </summary>
		private void ResetMaximumAge()
		{
			MaximumAge = null;
		}

		/// 
		/// Resets the timeout.
		/// </summary>
		private void ResetTimeout()
		{
			Timeout = null;
		}
	}
}

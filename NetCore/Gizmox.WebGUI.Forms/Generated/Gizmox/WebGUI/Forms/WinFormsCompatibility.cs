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
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class WinFormsCompatibility
	{
		/// 
		/// Represents the method that will handle the WinFormsCompatibility option changed event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.WinFormsCompatibilityEventArgs" /> instance containing the event data.</param>
		public delegate void WinFormsCompatibilityEventHandler(object sender, WinFormsCompatibilityEventArgs e);

		/// 
		/// The store dictionary for WinFormsCompatibility features.
		/// </summary>
		private Dictionary<string, bool> mobjFeatureIsOnIndexByFeatureName;

		/// 
		/// Called when option value is changed.
		/// </summary>
		public event WinFormsCompatibilityEventHandler OptionValueChanged;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WinFormsCompatibility" /> class.
		/// </summary>
		public WinFormsCompatibility()
		{
			mobjFeatureIsOnIndexByFeatureName = new Dictionary<string, bool>();
		}

		/// 
		/// Gets the feature.
		/// </summary>
		/// <param name="strFeatureName">Name of the string feature.</param>
		/// </returns>
		protected WinFormsCompatibilityStates GetFeature(string strFeatureName)
		{
			bool value = false;
			if (mobjFeatureIsOnIndexByFeatureName.TryGetValue(strFeatureName, out value))
			{
				return value ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False;
			}
			return WinFormsCompatibilityStates.Default;
		}

		/// 
		/// Gets the feature value from configuration.
		/// </summary>
		/// <param name="strFeatureName">Name of the string feature.</param>
		/// </returns>
		private bool GetFeatureValueFromConfiguration(string strFeatureName)
		{
			if (VWGContext.Current != null && VWGContext.Current.Config != null)
			{
				return VWGContext.Current.Config.IsWinFormsCompatibilityOptionOn(strFeatureName);
			}
			return false;
		}

		/// 
		/// Gets the feature bool value.
		/// </summary>
		/// <param name="strFeatureName">Name of the string feature.</param>
		/// </returns>
		protected bool GetFeatureBoolValue(string strFeatureName)
		{
			bool value = false;
			if (!mobjFeatureIsOnIndexByFeatureName.TryGetValue(strFeatureName, out value))
			{
				value = GetFeatureValueFromConfiguration(strFeatureName);
			}
			return value;
		}

		/// 
		/// Sets the feature.
		/// </summary>
		/// <param name="strFeatureName">Name of the string feature.</param>
		/// <param name="blnState">if set to true</c> [BLN state].</param>
		protected void SetFeature(string strFeatureName, WinFormsCompatibilityStates enmState)
		{
			bool featureBoolValue = GetFeatureBoolValue(strFeatureName);
			if (enmState == WinFormsCompatibilityStates.Default)
			{
				mobjFeatureIsOnIndexByFeatureName.Remove(strFeatureName);
			}
			else
			{
				mobjFeatureIsOnIndexByFeatureName[strFeatureName] = enmState == WinFormsCompatibilityStates.True;
			}
			if (featureBoolValue != GetFeatureBoolValue(strFeatureName))
			{
				OnOptionValueChanged(strFeatureName);
			}
		}

		/// 
		/// Called when option value is changed.
		/// </summary>
		private void OnOptionValueChanged(string strChangedOptionName)
		{
			if (this.OptionValueChanged != null)
			{
				this.OptionValueChanged(this, new WinFormsCompatibilityEventArgs(strChangedOptionName));
			}
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Empty;
		}
	}
}

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
	public class CheckBoxSwitchVisualTemplateSkin : CheckBoxSkin
	{
		/// 
		/// Gets or sets the checkbox wrapper style.
		/// </summary>
		/// 
		/// The check box wrapper style.
		/// </value>
		public virtual StyleValue CheckBoxWrapperStyle
		{
			get
			{
				return new StyleValue(this, "CheckBoxWrapperStyle");
			}
			set
			{
				SetValue("CheckBoxWrapperStyle", value);
			}
		}

		/// 
		/// Gets or sets the checkbox state label style.
		/// </summary>
		/// 
		/// The check box state label style.
		/// </value>
		public virtual StyleValue CheckBoxStateLabelStyle
		{
			get
			{
				return new StyleValue(this, "CheckBoxStateLabelStyle");
			}
			set
			{
				SetValue("CheckBoxStateLabelStyle", value);
			}
		}

		/// 
		/// Gets or sets the checkbox state label before style.
		/// </summary>
		/// 
		/// The checkbox state label before style.
		/// </value>
		public virtual StyleValue CheckBoxStateLabelBeforeStyle
		{
			get
			{
				return new StyleValue(this, "CheckBoxStateLabelBeforeStyle");
			}
			set
			{
				SetValue("CheckBoxStateLabelBeforeStyle", value);
			}
		}

		/// 
		/// Gets or sets the checkbox state label after style.
		/// </summary>
		/// 
		/// The checkbox state label after style.
		/// </value>
		public virtual StyleValue CheckBoxStateLabelAfterStyle
		{
			get
			{
				return new StyleValue(this, "CheckBoxStateLabelAfterStyle");
			}
			set
			{
				SetValue("CheckBoxStateLabelAfterStyle", value);
			}
		}

		/// 
		/// Gets or sets the checkbox switch style.
		/// </summary>
		/// 
		/// The checkbox switch style.
		/// </value>
		public virtual StyleValue CheckBoxSwitchStyle
		{
			get
			{
				return new StyleValue(this, "CheckBoxSwitchStyle");
			}
			set
			{
				SetValue("CheckBoxSwitchStyle", value);
			}
		}

		/// 
		/// Gets a value indicating whether [rounded switch].
		/// </summary>
		/// 
		///   true</c> if [rounded switch]; otherwise, false</c>.
		/// </value>
		public bool RoundedSwitch
		{
			get
			{
				return GetValue("RoundedSwitch", objDefaultValue: true);
			}
			set
			{
				SetValue("RoundedSwitch", value);
			}
		}

		/// 
		/// Gets a value indicating whether [use animation].
		/// </summary>
		/// 
		///   true</c> if [use animation]; otherwise, false</c>.
		/// </value>
		public bool UseAnimation
		{
			get
			{
				return GetValue("UseAnimation", objDefaultValue: true);
			}
			set
			{
				SetValue("UseAnimation", value);
			}
		}

		/// 
		/// Gets the switch width percentage.
		/// </summary>
		/// 
		/// The switch width percentage.
		/// </value>
		public int SwitchWidthPercentage
		{
			get
			{
				return GetValue("SwitchWidthPercentage", 0);
			}
			set
			{
				SetValue("SwitchWidthPercentage", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the checkbox wrapper style.
		/// </summary>
		internal void ResetCheckBoxWrapperStyle()
		{
			Reset("CheckBoxWrapperStyle");
		}

		/// 
		/// Resets the checkbox state label style.
		/// </summary>
		internal void ResetCheckBoxStateLabelStyle()
		{
			Reset("CheckBoxStateLabelStyle");
		}

		/// 
		/// Resets the checkbox state label before style.
		/// </summary>
		internal void ResetCheckBoxStateLabelBeforeStyle()
		{
			Reset("CheckBoxStateLabelBeforeStyle");
		}

		/// 
		/// Resets the checkbox state label after style.
		/// </summary>
		internal void ResetCheckBoxStateLabelAfterStyle()
		{
			Reset("CheckBoxStateLabelAfterStyle");
		}

		/// 
		/// Resets the checkbox switch style.
		/// </summary>
		internal void ResetCheckBoxSwitchStyle()
		{
			Reset("CheckBoxSwitchStyle");
		}

		/// 
		/// Resets the rounded switch.
		/// </summary>
		internal void ResetRoundedSwitch()
		{
			Reset("RoundedSwitch");
		}

		/// 
		/// Resets the use animation.
		/// </summary>
		internal void ResetUseAnimation()
		{
			Reset("UseAnimation");
		}

		/// 
		/// Resets the switch width percentage.
		/// </summary>
		internal void ResetSwitchWidthPercentage()
		{
			Reset("SwitchWidthPercentage");
		}
	}
}

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
	/// Provides a user interface for indicating that a control on a form has an error associated with it.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ErrorProvider), "ErrorProvider_45.bmp")]
	[ProvideProperty("IconAlignment", typeof(Control))]
	[SRDescription("DescriptionErrorProvider")]
	[ComplexBindingProperties("DataSource", "DataMember")]
	[ProvideProperty("Error", typeof(Control))]
	[ProvideProperty("IconPadding", typeof(Control))]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[ToolboxItemCategory("Components")]
	public class ErrorProvider : ComponentBase
	{
		private int mintBlinkRate = 3;

		private ErrorBlinkStyle menmBlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

		private string mstrDataMember = "";

		private object mobjDataSource = "";

		private ContainerControl mobjContainerControl = null;

		private ResourceHandle mobjIcon = null;

		private Dictionary<Control, Control> mobjControlWithErrorsMap = new Dictionary<Control, Control>();

		/// Gets or sets the <see cref="T:System.Drawing.Icon"></see> that is displayed next to a control when an error description string has been set for the control.</summary>
		/// An <see cref="T:System.Drawing.Icon"></see> that signals an error has occurred. The default icon consists of an exclamation point in a circle with a red background.</returns>
		/// <exception cref="T:System.ArgumentNullException">The assigned value of the <see cref="T:System.Drawing.Icon"></see> is null. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("ErrorProviderIconDescr")]
		[DefaultValue(null)]
		public ResourceHandle Icon
		{
			get
			{
				return mobjIcon;
			}
			set
			{
				if (mobjIcon != value)
				{
					mobjIcon = value;
				}
			}
		}

		/// 
		/// Gets or sets the rate at which the error icon flashes.
		/// </summary>
		/// The rate, in milliseconds, at which the error icon should flash. The default is 250 milliseconds.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than zero. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(250)]
		[SRDescription("ErrorProviderBlinkRateDescr")]
		[SRCategory("CatBehavior")]
		public int BlinkRate
		{
			get
			{
				return mintBlinkRate;
			}
			set
			{
				mintBlinkRate = value;
			}
		}

		/// 
		/// Gets or sets a value indicating when the error icon flashes.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorBlinkStyle" /> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError" />.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ErrorBlinkStyle" /> values. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[DefaultValue(0)]
		[SRDescription("ErrorProviderBlinkStyleDescr")]
		public ErrorBlinkStyle BlinkStyle
		{
			get
			{
				return menmBlinkStyle;
			}
			set
			{
				menmBlinkStyle = value;
			}
		}

		/// 
		/// Gets or sets a value indicating the parent control for this <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider" />.
		/// </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ContainerControl" /> that contains the controls that the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider" /> is attached to.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Window="AllWindows" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ErrorProviderContainerControlDescr")]
		[DefaultValue(null)]
		[SRCategory("CatData")]
		public ContainerControl ContainerControl
		{
			get
			{
				return mobjContainerControl;
			}
			set
			{
				mobjContainerControl = value;
			}
		}

		/// 
		/// Gets or sets the list within a data source to monitor.
		/// </summary>
		/// The string that represents a list within the data source specified by the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataSource" /> to be monitored. Typically, this will be a <see cref="T:System.Data.DataTable" />.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue("")]
		[SRCategory("CatData")]
		[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[SRDescription("ErrorProviderDataMemberDescr")]
		public string DataMember
		{
			get
			{
				return mstrDataMember;
			}
			set
			{
				mstrDataMember = value;
			}
		}

		/// 
		/// Gets or sets the data source that the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider" /> monitors.
		/// </summary>
		/// A data source based on the <see cref="T:System.Collections.IList" /> interface to be monitored for errors. Typically, this is a <see cref="T:System.Data.DataSet" /> to be monitored for errors.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatData")]
		[SRDescription("ErrorProviderDataSourceDescr")]
		[AttributeProvider(typeof(IListSource))]
		[DefaultValue("")]
		public object DataSource
		{
			get
			{
				return mobjDataSource;
			}
			set
			{
				mobjDataSource = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"></see> class and initializes the default settings for <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.BlinkRate"></see>, <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.BlinkStyle"></see>, and the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.Icon"></see>.
		/// </summary>
		public ErrorProvider()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ErrorProvider"></see> class attached to a container.
		/// </summary>
		/// <param name="objParentControl">The container of the control to monitor for errors. </param>
		public ErrorProvider(ContainerControl objParentControl)
		{
			mobjContainerControl = objParentControl;
		}

		/// Initializes a new instance of the <see cref="T:System.Windows.Forms.ErrorProvider"></see> class attached to an <see cref="T:System.ComponentModel.IContainer"></see> implementation.</summary>
		/// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to monitor for errors.</param>
		public ErrorProvider(IContainer objContainer)
			: this()
		{
			objContainer?.Add(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				List<object> list = new List<object>();
				foreach (Control key in mobjControlWithErrorsMap.Keys)
				{
					list.Add(key);
				}
				foreach (Control item in list)
				{
					SetError(item, null);
				}
				mobjControlWithErrorsMap.Clear();
			}
			base.Dispose(disposing);
		}

		/// 
		/// Returns the current error description string for the specified control.
		/// </summary>
		/// The error description string for the specified control.</returns>
		/// <param name="objControl">The item to get the error description string for. </param>
		/// <exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ErrorProviderErrorDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string GetError(Control objControl)
		{
			return objControl.GetErrorMessage();
		}

		/// 
		/// Gets a value indicating where the error icon should be placed in relation to the control.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorIconAlignment"></see> values. The default icon alignment is <see cref="F:System.Windows.Forms.ErrorIconAlignment.MiddleRight"></see>.</returns>
		/// <param name="objControl">The control to get the icon location for. </param>
		/// <exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ErrorProviderIconAlignmentDescr")]
		[DefaultValue(3)]
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		public ErrorIconAlignment GetIconAlignment(Control objControl)
		{
			return objControl.ErrorIconAlignment;
		}

		/// 
		/// Returns the amount of extra space to leave next to the error icon.
		/// </summary>
		/// The number of pixels to leave between the icon and the control. </returns>
		/// <param name="objControl">The control to get the padding for. </param>
		/// <exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ErrorProviderIconPaddingDescr")]
		[DefaultValue(0)]
		[Localizable(true)]
		public int GetIconPadding(Control objControl)
		{
			return objControl.ErrorIconPadding;
		}

		/// 
		/// Sets the error description string for the specified control.
		/// </summary>
		/// <param name="objControl">The control to set the error description string for. </param>
		/// <param name="strValue">The error description string. </param>
		/// <exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SetError(Control objControl, string strValue)
		{
			objControl.SetErrorMessage(strValue, mobjIcon);
			if (string.IsNullOrEmpty(strValue))
			{
				mobjControlWithErrorsMap.Remove(objControl);
			}
			else if (!mobjControlWithErrorsMap.ContainsKey(objControl))
			{
				mobjControlWithErrorsMap.Add(objControl, objControl);
			}
		}

		/// 
		/// Sets the location where the error icon should be placed in relation to the control.
		/// </summary>
		/// <param name="objControl">The control to set the icon location for. </param>
		/// <param name="enmValue">One of the <see cref="T:Gizmox.WebGUI.Forms.ErrorIconAlignment" /> values. </param>
		/// <exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SetIconAlignment(Control objControl, ErrorIconAlignment enmValue)
		{
			objControl.ErrorIconAlignment = enmValue;
		}

		/// 
		/// Sets the amount of extra space to leave between the specified control and the error icon.
		/// </summary>
		/// <param name="objControl">The control to set the padding for. </param>
		/// <param name="intPadding">The number of pixels to add between the icon and the control. </param>
		/// <exception cref="T:System.ArgumentNullException">control is null.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void SetIconPadding(Control objControl, int intPadding)
		{
			objControl.ErrorIconPadding = intPadding;
		}

		/// 
		/// Provides a method to update the bindings of the <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataSource" />, <see cref="P:Gizmox.WebGUI.Forms.ErrorProvider.DataMember" />, and the error text.
		/// </summary>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void UpdateBinding()
		{
		}

		/// 
		/// Gets a value indicating whether a control can be extended.
		/// </summary>
		/// true if the control can be extended; otherwise, false.This property will be true if the object is a <see cref="T:Gizmox.WebGUI.Forms.Control" /> and is not a <see cref="T:Gizmox.WebGUI.Forms.Form" /> or <see cref="T:Gizmox.WebGUI.Forms.ToolBar" />.</returns>
		/// <param name="objExtendee">The control to be extended. </param>
		public bool CanExtend(object objExtendee)
		{
			return false;
		}
	}
}

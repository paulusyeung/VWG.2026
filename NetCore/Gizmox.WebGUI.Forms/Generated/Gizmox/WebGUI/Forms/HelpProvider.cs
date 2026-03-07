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
	/// Provides pop-up or online Help for controls.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(HelpProvider), "HelpProvider_45.bmp")]
	[ProvideProperty("ShowHelp", typeof(Control))]
	[ProvideProperty("HelpString", typeof(Control))]
	[ProvideProperty("HelpNavigator", typeof(Control))]
	[SRDescription("DescriptionHelpProvider")]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[ProvideProperty("HelpKeyword", typeof(Control))]
	[ToolboxItemCategory("Components")]
	public class HelpProvider : ComponentBase, IExtenderProvider
	{
		private Hashtable mobjBoundControls = new Hashtable();

		private string mstrHelpNamespace;

		private Hashtable mobjHelpStrings = new Hashtable();

		private Hashtable mobjKeywords = new Hashtable();

		private Hashtable mobjNavigators = new Hashtable();

		private Hashtable mobjShowHelp = new Hashtable();

		private object mobjUserData;

		/// Gets or sets a value specifying the name of the Help file associated with this <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see> object.</summary>
		/// The name of the Help file. This can be of the form C:\path\sample.chm or /folder/file.htm.</returns>
		/// 1</filterpriority>
		[DefaultValue("")]
		public virtual string HelpNamespace
		{
			get
			{
				return mstrHelpNamespace;
			}
			set
			{
				mstrHelpNamespace = value;
			}
		}

		/// Gets or sets the object that contains supplemental data about the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</summary>
		/// An <see cref="T:System.Object"></see> that contains data about the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</returns>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[Bindable(true)]
		[DefaultValue(null)]
		[Localizable(false)]
		[SRDescription("ControlTagDescr")]
		[TypeConverter(typeof(StringConverter))]
		public object Tag
		{
			get
			{
				return mobjUserData;
			}
			set
			{
				mobjUserData = value;
			}
		}

		/// Specifies whether this object can provide its extender properties to the specified object.</summary>
		/// <param name="objTarget">The object </param>
		/// 1</filterpriority>
		public virtual bool CanExtend(object objTarget)
		{
			return objTarget is Control;
		}

		/// Returns the Help keyword for the specified control.</summary>
		/// The Help keyword associated with this control, or null if the <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see> is currently configured to display the entire Help file or is configured to provide a Help string.</returns>
		/// <param name="Control">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help topic. </param>
		/// 1</filterpriority>
		[DefaultValue(null)]
		[SRDescription("HelpProviderHelpKeywordDescr")]
		[Localizable(true)]
		public virtual string GetHelpKeyword(Control objControl)
		{
			return (string)mobjKeywords[objControl];
		}

		/// Returns the current <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> setting for the specified control.</summary>
		/// The <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> setting for the specified control. The default is <see cref="F: Gizmox.WebGUI.Forms.HelpNavigator.AssociateIndex"></see>.</returns>
		/// <param name="Control">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help navigator. </param>
		/// 1</filterpriority>
		[Localizable(true)]
		[DefaultValue(HelpNavigator.AssociateIndex)]
		[SRDescription("HelpProviderNavigatorDescr")]
		public virtual HelpNavigator GetHelpNavigator(Control Control)
		{
			object obj = mobjNavigators[Control];
			if (obj != null)
			{
				return (HelpNavigator)obj;
			}
			return HelpNavigator.AssociateIndex;
		}

		/// Returns the contents of the pop-up Help window for the specified control.</summary>
		/// The Help string associated with this control. The default is null.</returns>
		/// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> from which to retrieve the Help string. </param>
		/// 1</filterpriority>
		[DefaultValue(null)]
		[Localizable(true)]
		[SRDescription("HelpProviderHelpStringDescr")]
		public virtual string GetHelpString(Control objControl)
		{
			return (string)mobjHelpStrings[objControl];
		}

		/// Returns a value indicating whether the specified control's Help should be displayed.</summary>
		/// true if Help will be displayed for the control; otherwise, false.</returns>
		/// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which Help will be displayed. </param>
		/// 1</filterpriority>
		[Localizable(true)]
		[SRDescription("HelpProviderShowHelpDescr")]
		public virtual bool GetShowHelp(Control objControl)
		{
			object obj = mobjShowHelp[objControl];
			if (obj == null)
			{
				return false;
			}
			return (bool)obj;
		}

		private void OnControlHelp(object sender, HelpEventArgs objHelpEventArgs)
		{
			Control control = (Control)sender;
			string helpString = GetHelpString(control);
			string helpKeyword = GetHelpKeyword(control);
			HelpNavigator helpNavigator = GetHelpNavigator(control);
			if (!GetShowHelp(control))
			{
				return;
			}
			if (!objHelpEventArgs.Handled && mstrHelpNamespace != null)
			{
				if (helpKeyword != null && helpKeyword.Length > 0)
				{
					Help.ShowHelp(control, mstrHelpNamespace, helpNavigator, helpKeyword);
					objHelpEventArgs.Handled = true;
				}
				if (!objHelpEventArgs.Handled)
				{
					Help.ShowHelp(control, mstrHelpNamespace, helpNavigator);
					objHelpEventArgs.Handled = true;
				}
			}
			if (!objHelpEventArgs.Handled && mstrHelpNamespace != null)
			{
				Help.ShowHelp(control, mstrHelpNamespace);
				objHelpEventArgs.Handled = true;
			}
		}

		/// Removes the Help associated with the specified control.</summary>
		/// <param name="objControl">The control to remove Help from.</param>
		/// 1</filterpriority>
		public virtual void ResetShowHelp(Control objControl)
		{
			mobjShowHelp.Remove(objControl);
		}

		/// Specifies the keyword used to retrieve Help when the user invokes Help for the specified control.</summary>
		/// <param name="strKeyword">The Help keyword to associate with the control. </param>
		/// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> that specifies the control for which to set the Help topic. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual void SetHelpKeyword(Control objControl, string strKeyword)
		{
			mobjKeywords[objControl] = strKeyword;
			if (strKeyword != null && strKeyword.Length > 0)
			{
				SetShowHelp(objControl, blnValue: true);
			}
			UpdateEventBinding(objControl);
		}

		/// Specifies the Help command to use when retrieving Help from the Help file for the specified control.</summary>
		/// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which to set the Help keyword. </param>
		/// <param name="enmNavigator">One of the <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> values. </param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of navigator is not one of the <see cref="T: Gizmox.WebGUI.Forms.HelpNavigator"></see> values. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual void SetHelpNavigator(Control objControl, HelpNavigator enmNavigator)
		{
			if (!ClientUtils.IsEnumValid(enmNavigator, (int)enmNavigator, -2147483647, -2147483641))
			{
				throw new InvalidEnumArgumentException("navigator", (int)enmNavigator, typeof(HelpNavigator));
			}
			mobjNavigators[objControl] = enmNavigator;
			SetShowHelp(objControl, blnValue: true);
			UpdateEventBinding(objControl);
		}

		/// Specifies the Help string associated with the specified control.</summary>
		/// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> with which to associate the Help string. </param>
		/// <param name="strHelpString">The Help string associated with the control. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual void SetHelpString(Control objControl, string strHelpString)
		{
			mobjHelpStrings[objControl] = strHelpString;
			if (strHelpString != null && strHelpString.Length > 0)
			{
				SetShowHelp(objControl, blnValue: true);
			}
			UpdateEventBinding(objControl);
		}

		/// Specifies whether Help is displayed for the specified control.</summary>
		/// <param name="objControl">A <see cref="T: Gizmox.WebGUI.Forms.Control"></see> for which Help is turned on or off. </param>
		/// <param name="blnValue">true if Help displays for the control; otherwise, false. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual void SetShowHelp(Control objControl, bool blnValue)
		{
			mobjShowHelp[objControl] = blnValue;
			UpdateEventBinding(objControl);
		}

		internal virtual bool ShouldSerializeShowHelp(Control objControl)
		{
			return mobjShowHelp.ContainsKey(objControl);
		}

		/// Returns a string that represents the current <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</summary>
		/// A string that represents the current <see cref="T: Gizmox.WebGUI.Forms.HelpProvider"></see>.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			return base.ToString() + ", HelpNamespace: " + HelpNamespace;
		}

		private void UpdateEventBinding(Control objControl)
		{
			if (GetShowHelp(objControl) && !mobjBoundControls.ContainsKey(objControl))
			{
				objControl.HelpRequested += OnControlHelp;
				mobjBoundControls[objControl] = objControl;
			}
			else if (!GetShowHelp(objControl) && mobjBoundControls.ContainsKey(objControl))
			{
				objControl.HelpRequested -= OnControlHelp;
				mobjBoundControls.Remove(objControl);
			}
		}
	}
}

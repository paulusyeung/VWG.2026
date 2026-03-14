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
/// Encapsulates the HTML Help 1.0 engine.</summary>
	/// 1</filterpriority>
	[Serializable]
	public class Help
	{
		private Help()
		{
		}

		private static int GetHelpFileType(string strUrl)
		{
			if (strUrl != null)
			{
				Uri uri = Resolve(strUrl);
				if (uri == null || uri.Scheme == "file")
				{
					string text = Path.GetExtension((uri == null) ? strUrl : (uri.LocalPath + uri.Fragment)).ToLower(CultureInfo.InvariantCulture);
					if (text == ".chm" || text == ".col")
					{
						return 2;
					}
				}
			}
			return 3;
		}

		private static string GetLocalPath(string strFileName)
		{
			Uri uri = new Uri(strFileName);
			return uri.LocalPath + uri.Fragment;
		}

		private static Uri Resolve(string strPartialUri)
		{
			Uri uri = null;
			if (!CommonUtils.IsNullOrEmpty(strPartialUri))
			{
				try
				{
					uri = new Uri(strPartialUri);
				}
				catch (UriFormatException)
				{
				}
				catch (ArgumentNullException)
				{
				}
			}
			if (uri != null && uri.Scheme == "file")
			{
				string localPath = GetLocalPath(strPartialUri);
				new FileIOPermission(FileIOPermissionAccess.Read, localPath).Assert();
				try
				{
					if (!File.Exists(localPath))
					{
						uri = null;
					}
				}
				finally
				{
					CodeAccessPermission.RevertAssert();
				}
			}
			if (uri == null)
			{
				try
				{
					uri = new Uri(new Uri(AppDomain.CurrentDomain.SetupInformation.ApplicationBase), strPartialUri);
				}
				catch (UriFormatException)
				{
				}
				catch (ArgumentNullException)
				{
				}
				if (uri == null || uri.Scheme != "file")
				{
					return uri;
				}
				string path = uri.LocalPath + uri.Fragment;
				new FileIOPermission(FileIOPermissionAccess.Read, path).Assert();
				try
				{
					if (!File.Exists(path))
					{
						uri = null;
					}
				}
				finally
				{
					CodeAccessPermission.RevertAssert();
				}
			}
			return uri;
		}

		/// Displays the contents of the Help file at the specified URL.</summary>
		/// <param name="strUrl">The path and name of the Help file. </param>
		/// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public static void ShowHelp(Control objParent, string strUrl)
		{
			ShowHelp(objParent, strUrl, HelpNavigator.TableOfContents, null);
		}

		/// Displays the contents of the Help file found at the specified URL for a specific keyword.</summary>
		/// <param name="strKeyword">The keyword to display Help for. </param>
		/// <param name="strUrl">The path and name of the Help file. </param>
		/// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public static void ShowHelp(Control objParent, string strUrl, string strKeyword)
		{
			if (strKeyword != null && strKeyword.Length != 0)
			{
				ShowHelp(objParent, strUrl, HelpNavigator.Topic, strKeyword);
			}
			else
			{
				ShowHelp(objParent, strUrl, HelpNavigator.TableOfContents, null);
			}
		}

		/// Displays the contents of the Help file found at the specified URL for a specific topic.</summary>
		/// <param name="strUrl">The path and name of the Help file. </param>
		/// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
		/// <param name="enmNavigator">One of the <see cref="T:Gizmox.WebGUI.Forms.HelpNavigator"></see> values. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public static void ShowHelp(Control objParent, string strUrl, HelpNavigator enmNavigator)
		{
			ShowHelp(objParent, strUrl, enmNavigator, null);
		}

		/// 
		/// Displays the contents of the Help file located at the URL supplied by the user.
		/// </summary>
		/// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box.</param>
		/// <param name="strUrl">The path and name of the Help file.</param>
		/// <param name="enmCommand">One of the <see cref="T:Gizmox.WebGUI.Forms.HelpNavigator"></see> values.</param>
		/// <param name="objParameter">The parameter.</param>
		/// <exception cref="T:System.ArgumentException">param is an integer.</exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public static void ShowHelp(Control objParent, string strUrl, HelpNavigator enmCommand, object objParameter)
		{
			switch (GetHelpFileType(strUrl))
			{
			case 3:
				ShowHTML10Help(objParent, strUrl, enmCommand, objParameter);
				break;
			case 2:
				ShowHTMLFile(objParent, strUrl, enmCommand, objParameter);
				break;
			}
		}

		/// Displays the index of the specified Help file.</summary>
		/// <param name="strUrl">The path and name of the Help file. </param>
		/// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public static void ShowHelpIndex(Control objParent, string strUrl)
		{
			ShowHelp(objParent, strUrl, HelpNavigator.Index, null);
		}

		private static void ShowHTML10Help(Control objParent, string strUrl, HelpNavigator enmCommand, object objParameter)
		{
		}

		private static void ShowHTMLFile(Control objParent, string strUrl, HelpNavigator enmCommand, object objParameter)
		{
			Type type = Type.GetType("Gizmox.WebGUI.Forms.HelpDialog, Gizmox.WebGUI.Forms.Help");
			if (type != null)
			{
				type.InvokeMember("ShowHelp", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, new object[4] { objParent, strUrl, enmCommand, objParameter });
			}
			else
			{
				MessageBox.Show("Could not find Gizmox.WebGUI.Forms.Help assembly.", "Help Projection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// Displays a Help pop-up window.</summary>
		/// <param name="strCaption">The message to display in the pop-up window. </param>
		/// <param name="objParent">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that identifies the parent of the Help dialog box. </param>
		/// <param name="objLocation">A value specifying the horizontal and vertical coordinates at which to display the pop-up window. </param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public static void ShowPopup(Control objParent, string strCaption, Point objLocation)
		{
			throw new NotImplementedException();
		}
	}
}

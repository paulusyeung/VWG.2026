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
	/// Contains information that enables a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to resolve a data binding to either the property of an object or the property of the current object in a list of objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	public struct BindingMemberInfo
	{
		private string mstrDataList;

		private string mstrDataField;

		/// Gets the property name, or the period-delimited hierarchy of property names, that comes before the property name of the data-bound object.</summary>
		/// The property name, or the period-delimited hierarchy of property names, that comes before the data-bound object property name.</returns>
		/// 1</filterpriority>
		public string BindingPath
		{
			get
			{
				if (mstrDataList == null)
				{
					return "";
				}
				return mstrDataList;
			}
		}

		/// Gets the property name of the data-bound object.</summary>
		/// The property name of the data-bound object. This can be an empty string ("").</returns>
		/// 1</filterpriority>
		public string BindingField
		{
			get
			{
				if (mstrDataField == null)
				{
					return "";
				}
				return mstrDataField;
			}
		}

		/// Gets the information that is used to specify the property name of the data-bound object.</summary>
		/// An empty string (""), a single property name, or a hierarchy of period-delimited property names that resolves to the property name of the final data-bound object.</returns>
		/// 1</filterpriority>
		public string BindingMember
		{
			get
			{
				if (BindingPath.Length <= 0)
				{
					return BindingField;
				}
				return BindingPath + "." + BindingField;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> class.</summary>
		/// <param name="strDataMember">A navigation path that resolves to either the property of an object or the property of the current object in a list of objects. </param>
		public BindingMemberInfo(string strDataMember)
		{
			if (strDataMember == null)
			{
				strDataMember = "";
			}
			int num = strDataMember.LastIndexOf(".");
			if (num != -1)
			{
				mstrDataList = strDataMember.Substring(0, num);
				mstrDataField = strDataMember.Substring(num + 1);
			}
			else
			{
				mstrDataList = "";
				mstrDataField = strDataMember;
			}
		}

		/// Determines whether the specified object is equal to this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</summary>
		/// true if otherObject is a <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> and both <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings are equal; otherwise false.</returns>
		/// <param name="otherObject">The object to compare for equality.</param>
		/// 1</filterpriority>
		public override bool Equals(object otherObject)
		{
			if (otherObject is BindingMemberInfo bindingMemberInfo)
			{
				return ClientUtils.IsEquals(BindingMember, bindingMemberInfo.BindingMember, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		/// Determines whether two <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> objects are equal.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings for a and b are equal; otherwise false.</returns>
		/// <param name="BindingMemberInfo1">The first <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for equality.</param>
		/// <param name="BindingMemberInfo2">The second <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for equality.</param>
		public static bool operator ==(BindingMemberInfo BindingMemberInfo1, BindingMemberInfo BindingMemberInfo2)
		{
			return BindingMemberInfo1.Equals(BindingMemberInfo2);
		}

		/// Determines whether two <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> objects are not equal.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.BindingMemberInfo.BindingMember"></see> strings for a and b are not equal; otherwise false.</returns>
		/// <param name="BindingMemberInfo1">The first <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for inequality.</param>
		/// <param name="BindingMemberInfo2">The second <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see> to compare for inequality.</param>
		public static bool operator !=(BindingMemberInfo BindingMemberInfo1, BindingMemberInfo BindingMemberInfo2)
		{
			return !BindingMemberInfo1.Equals(BindingMemberInfo2);
		}

		/// Returns the hash code for this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</summary>
		/// The hash code for this <see cref="T:Gizmox.WebGUI.Forms.BindingMemberInfo"></see>.</returns>
		/// 1</filterpriority>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

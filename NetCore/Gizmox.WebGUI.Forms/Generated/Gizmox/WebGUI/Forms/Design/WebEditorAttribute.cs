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

namespace Gizmox.WebGUI.Forms.Design
{
	/// Specifies the editor to use to change a property. This class cannot be inherited.</summary>
	[Serializable]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class WebEditorAttribute : Attribute
	{
		private string mstrBaseTypeName;

		private string mstrTypeId;

		private string mstrTypeName;

		/// Gets the name of the base class or interface serving as a lookup key for this editor.</summary>
		/// The name of the base class or interface serving as a lookup key for this editor.</returns>
		public string EditorBaseTypeName => mstrBaseTypeName;

		/// Gets the name of the editor class in the <see cref="P:Type.AssemblyQualifiedName"></see> format.</summary>
		/// The name of the editor class in the <see cref="P:Type.AssemblyQualifiedName"></see> format.</returns>
		public string EditorTypeName => mstrTypeName;

		/// Gets a unique ID for this attribute type.</summary>
		/// A unique ID for this attribute type.</returns>
		public override object TypeId
		{
			get
			{
				if (mstrTypeId == null)
				{
					string text = mstrBaseTypeName;
					int num = text.IndexOf(',');
					if (num != -1)
					{
						text = text.Substring(0, num);
					}
					mstrTypeId = GetType().FullName + text;
				}
				return mstrTypeId;
			}
		}

		/// Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the default editor, which is no editor.</summary>
		public WebEditorAttribute()
		{
		}

		/// Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type name and base type name of the editor.</summary>
		/// <param name="strTypeName">The fully qualified type name of the editor. </param>
		/// <param name="strBaseTypeName">The fully qualified type name of the base class or interface to use as a lookup key for the editor. This class must be or derive from <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. </param>
		public WebEditorAttribute(string strTypeName, string strBaseTypeName)
		{
			mstrTypeName = strTypeName.ToUpper();
			mstrBaseTypeName = strBaseTypeName;
		}

		/// Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type name and the base type.</summary>
		/// <param name="strTypeName">The fully qualified type name of the editor. </param>
		/// <param name="objBaseType">The <see cref="T:System.Type"></see> of the base class or interface to use as a lookup key for the editor. This class must be or derive from <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. </param>
		public WebEditorAttribute(string strTypeName, Type objBaseType)
		{
			mstrTypeName = strTypeName.ToUpper();
			mstrBaseTypeName = objBaseType.AssemblyQualifiedName;
		}

		/// Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type name and the base type.</summary>
		/// <param name="strTypeName">The fully qualified type name of the editor. </param>
		public WebEditorAttribute(string strTypeName)
		{
			mstrTypeName = strTypeName.ToUpper();
			mstrBaseTypeName = typeof(WebUITypeEditor).AssemblyQualifiedName;
		}

		/// Initializes a new instance of the <see cref="T:System.ComponentModel.WebEditorAttribute"></see> class with the type and the base type.</summary>
		/// <param name="objType">A <see cref="T:System.Type"></see> that represents the type of the editor. </param>
		/// <param name="objBaseType">The <see cref="T:System.Type"></see> of the base class or interface to use as a lookup key for the editor. This class must be or derive from <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see>. </param>
		public WebEditorAttribute(Type objType, Type objBaseType)
		{
			mstrTypeName = objType.AssemblyQualifiedName;
			mstrBaseTypeName = objBaseType.AssemblyQualifiedName;
		}

		/// Returns whether the value of the given object is equal to the current <see cref="T:System.ComponentModel.WebEditorAttribute"></see>.</summary>
		/// true if the value of the given object is equal to that of the current object; otherwise, false.</returns>
		/// <param name="obj">The object to test the value equality of. </param>
		public override bool Equals(object obj)
		{
			if (obj == this)
			{
				return true;
			}
			if (obj is WebEditorAttribute webEditorAttribute && webEditorAttribute.mstrTypeName == mstrTypeName)
			{
				return webEditorAttribute.mstrBaseTypeName == mstrBaseTypeName;
			}
			return false;
		}

		/// 
		/// Returns the hash code for this instance.
		/// </summary>
		/// A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

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
	[Serializable]
	internal class RelatedPropertyManager : PropertyManager
	{
		private static readonly SerializableProperty dataFieldProperty = SerializableProperty.Register("dataField", typeof(string), typeof(RelatedPropertyManager));

		[NonSerialized]
		private PropertyDescriptor fieldInfo;

		private bool mblnFieldInfoInitialized = false;

		private static readonly SerializableProperty parentManagerProperty = SerializableProperty.Register("parentManager", typeof(BindingManagerBase), typeof(RelatedPropertyManager));

		private string dataField
		{
			get
			{
				return GetValue(dataFieldProperty);
			}
			set
			{
				SetValue(dataFieldProperty, value);
			}
		}

		private BindingManagerBase parentManager
		{
			get
			{
				return GetValue(parentManagerProperty);
			}
			set
			{
				SetValue(parentManagerProperty, value);
			}
		}

		internal override Type BindType
		{
			get
			{
				EnsureFieldInfo();
				return fieldInfo.PropertyType;
			}
		}

		public override object Current
		{
			get
			{
				if (DataSource == null)
				{
					return null;
				}
				EnsureFieldInfo();
				return fieldInfo.GetValue(DataSource);
			}
		}

		internal RelatedPropertyManager(BindingManagerBase objParentManager, string strDataField)
			: base(GetCurrentOrNull(objParentManager), strDataField)
		{
			Bind(objParentManager, strDataField);
		}

		private void Bind(BindingManagerBase objParentManager, string strDataField)
		{
			parentManager = objParentManager;
			dataField = strDataField;
			fieldInfo = objParentManager.GetItemProperties().Find(strDataField, ignoreCase: true);
			if (fieldInfo == null)
			{
				throw new ArgumentException(SR.GetString("RelatedListManagerChild", strDataField));
			}
			objParentManager.CurrentItemChanged += ParentManager_CurrentItemChanged;
			Refresh();
		}

		/// 
		/// Ensures the field info.
		/// </summary>
		private void EnsureFieldInfo()
		{
			if (mblnFieldInfoInitialized && fieldInfo == null)
			{
				Bind(parentManager, dataField);
			}
		}

		private static object GetCurrentOrNull(BindingManagerBase objParentManager)
		{
			if (objParentManager.Position < 0 || objParentManager.Position >= objParentManager.Count)
			{
				return null;
			}
			return objParentManager.Current;
		}

		internal override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
		{
			PropertyDescriptor[] array;
			if (arrListAccessors != null && arrListAccessors.Length != 0)
			{
				array = new PropertyDescriptor[arrListAccessors.Length + 1];
				arrListAccessors.CopyTo(array, 1);
			}
			else
			{
				array = new PropertyDescriptor[1];
			}
			EnsureFieldInfo();
			array[0] = fieldInfo;
			return parentManager.GetItemProperties(array);
		}

		internal override string GetListName()
		{
			string listName = GetListName(new ArrayList());
			if (listName.Length > 0)
			{
				return listName;
			}
			return base.GetListName();
		}

		protected internal override string GetListName(ArrayList objListAccessors)
		{
			EnsureFieldInfo();
			objListAccessors.Insert(0, fieldInfo);
			return parentManager.GetListName(objListAccessors);
		}

		private void ParentManager_CurrentItemChanged(object sender, EventArgs e)
		{
			Refresh();
		}

		private void Refresh()
		{
			EndCurrentEdit();
			SetDataSource(GetCurrentOrNull(parentManager));
			OnCurrentChanged(EventArgs.Empty);
		}
	}
}

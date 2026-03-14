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
	internal class BindToObject : SerializableObject
	{
		private static readonly SerializableProperty bindingManagerProperty = SerializableProperty.Register("bindingManager", typeof(BindingManagerBase), typeof(BindToObject));

		private BindingMemberInfo mobjDataMember;

		private object mobjDataSource;

		private static readonly SerializableProperty dataSourceInitializedProperty = SerializableProperty.Register("dataSourceInitialized", typeof(bool), typeof(BindToObject));

		private string mstrErrorText;

		[NonSerialized]
		private PropertyDescriptor mobjFieldInfo;

		private bool mblnFieldInfoInitialized = false;

		private Binding mobjOwner;

		private static readonly SerializableProperty waitingOnDataSourceProperty = SerializableProperty.Register("waitingOnDataSource", typeof(bool), typeof(BindToObject));

		private BindingManagerBase bindingManager
		{
			get
			{
				return GetValue(bindingManagerProperty);
			}
			set
			{
				SetValue(bindingManagerProperty, value);
			}
		}

		private bool dataSourceInitialized
		{
			get
			{
				return GetValue(dataSourceInitializedProperty);
			}
			set
			{
				SetValue(dataSourceInitializedProperty, value);
			}
		}

		private bool waitingOnDataSource
		{
			get
			{
				return GetValue(waitingOnDataSourceProperty);
			}
			set
			{
				SetValue(waitingOnDataSourceProperty, value);
			}
		}

		internal BindingManagerBase BindingManagerBase => bindingManager;

		internal BindingMemberInfo BindingMemberInfo => mobjDataMember;

		internal Type BindToType
		{
			get
			{
				if (mobjDataMember.BindingField.Length == 0)
				{
					Type type = bindingManager.BindType;
					if (typeof(Array).IsAssignableFrom(type))
					{
						type = type.GetElementType();
					}
					return type;
				}
				EnsureFieldInfo();
				if (mobjFieldInfo != null)
				{
					return mobjFieldInfo.PropertyType;
				}
				return null;
			}
		}

		internal string DataErrorText => mstrErrorText;

		internal object DataSource => mobjDataSource;

		internal PropertyDescriptor FieldInfo
		{
			get
			{
				EnsureFieldInfo();
				return mobjFieldInfo;
			}
		}

		private bool IsDataSourceInitialized
		{
			get
			{
				if (dataSourceInitialized)
				{
					return true;
				}
				if (!(mobjDataSource is ISupportInitializeNotification { IsInitialized: false } supportInitializeNotification))
				{
					dataSourceInitialized = true;
					return true;
				}
				if (!waitingOnDataSource)
				{
					supportInitializeNotification.Initialized += DataSource_Initialized;
					waitingOnDataSource = true;
				}
				return false;
			}
		}

		internal BindToObject(Binding objOwner, object objDataSource, string strDataMember)
		{
			mstrErrorText = string.Empty;
			mobjOwner = objOwner;
			mobjDataSource = objDataSource;
			mobjDataMember = new BindingMemberInfo(strDataMember);
			CheckBinding();
		}

		internal void CheckBinding()
		{
			if (mobjOwner != null && mobjOwner.BindableComponent != null && mobjOwner.ControlAtDesignTime())
			{
				return;
			}
			if (mobjOwner.BindingManagerBase != null && mobjFieldInfo != null && mobjOwner.BindingManagerBase.IsBinding && !(mobjOwner.BindingManagerBase is CurrencyManager))
			{
				mobjFieldInfo.RemoveValueChanged(mobjOwner.BindingManagerBase.Current, PropValueChanged);
			}
			if (mobjOwner != null && mobjOwner.BindingManagerBase != null && mobjOwner.BindableComponent != null && mobjOwner.ComponentCreated && IsDataSourceInitialized)
			{
				string bindingField = mobjDataMember.BindingField;
				mobjFieldInfo = mobjOwner.BindingManagerBase.GetItemProperties().Find(bindingField, ignoreCase: true);
				if (mobjOwner.BindingManagerBase.DataSource != null && mobjFieldInfo == null && bindingField.Length > 0)
				{
					throw new ArgumentException(SR.GetString("ListBindingBindField", bindingField), "dataMember");
				}
				if (mobjFieldInfo != null && mobjOwner.BindingManagerBase.IsBinding && !(mobjOwner.BindingManagerBase is CurrencyManager))
				{
					mobjFieldInfo.AddValueChanged(mobjOwner.BindingManagerBase.Current, PropValueChanged);
				}
			}
			else
			{
				mobjFieldInfo = null;
			}
			mblnFieldInfoInitialized = true;
		}

		/// 
		/// Ensures the field info.
		/// </summary>
		private void EnsureFieldInfo()
		{
			if (mblnFieldInfoInitialized && mobjFieldInfo == null)
			{
				CheckBinding();
			}
		}

		private void DataSource_Initialized(object sender, EventArgs e)
		{
			if (mobjDataSource is ISupportInitializeNotification supportInitializeNotification)
			{
				supportInitializeNotification.Initialized -= DataSource_Initialized;
			}
			waitingOnDataSource = false;
			dataSourceInitialized = true;
			CheckBinding();
		}

		private string GetErrorText(object objValue)
		{
			IDataErrorInfo dataErrorInfo = objValue as IDataErrorInfo;
			string text = string.Empty;
			if (dataErrorInfo != null)
			{
				EnsureFieldInfo();
				text = ((mobjFieldInfo != null) ? dataErrorInfo[mobjFieldInfo.Name] : dataErrorInfo.Error);
			}
			return (text != null) ? text : string.Empty;
		}

		internal object GetValue()
		{
			object obj = bindingManager.Current;
			mstrErrorText = GetErrorText(obj);
			EnsureFieldInfo();
			if (mobjFieldInfo != null)
			{
				obj = mobjFieldInfo.GetValue(obj);
			}
			return obj;
		}

		private void PropValueChanged(object sender, EventArgs e)
		{
			bindingManager.OnCurrentChanged(EventArgs.Empty);
		}

		internal void SetBindingManagerBase(BindingManagerBase lManager)
		{
			if (bindingManager != lManager)
			{
				EnsureFieldInfo();
				if (bindingManager != null && mobjFieldInfo != null && bindingManager.IsBinding && !(bindingManager is CurrencyManager))
				{
					mobjFieldInfo.RemoveValueChanged(bindingManager.Current, PropValueChanged);
					mobjFieldInfo = null;
				}
				bindingManager = lManager;
				CheckBinding();
			}
		}

		internal void SetValue(object objValue)
		{
			object obj = null;
			EnsureFieldInfo();
			if (mobjFieldInfo != null)
			{
				obj = bindingManager.Current;
				if (obj is IEditableObject)
				{
					((IEditableObject)obj).BeginEdit();
				}
				if (!mobjFieldInfo.IsReadOnly)
				{
					mobjFieldInfo.SetValue(obj, objValue);
				}
			}
			else if (bindingManager is CurrencyManager currencyManager)
			{
				currencyManager[currencyManager.Position] = objValue;
				obj = objValue;
			}
			mstrErrorText = GetErrorText(obj);
		}
	}
}

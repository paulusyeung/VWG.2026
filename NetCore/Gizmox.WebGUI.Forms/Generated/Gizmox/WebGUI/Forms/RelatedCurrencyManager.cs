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
	internal class RelatedCurrencyManager : CurrencyManager
	{
		private static readonly SerializableProperty dataFieldProperty = SerializableProperty.Register("dataField", typeof(string), typeof(RelatedCurrencyManager));

		[NonSerialized]
		private PropertyDescriptor fieldInfo;

		private bool mblnFieldInfoInitialized = false;

		private static readonly SerializableProperty ignoreParentCurrentItemChangedProperty = SerializableProperty.Register("ignoreParentCurrentItemChanged", typeof(bool), typeof(RelatedCurrencyManager));

		private static readonly SerializableProperty parentManagerProperty = SerializableProperty.Register("parentManager", typeof(BindingManagerBase), typeof(RelatedCurrencyManager));

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

		private bool ignoreParentCurrentItemChanged
		{
			get
			{
				return GetValue(ignoreParentCurrentItemChangedProperty);
			}
			set
			{
				SetValue(ignoreParentCurrentItemChangedProperty, value);
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

		internal RelatedCurrencyManager(BindingManagerBase objParentManager, string strDataField)
			: base(null)
		{
			Bind(objParentManager, strDataField);
		}

		internal void Bind(BindingManagerBase objParentManager, string strDataField)
		{
			UnwireParentManager(parentManager);
			parentManager = objParentManager;
			dataField = strDataField;
			fieldInfo = objParentManager.GetItemProperties().Find(strDataField, ignoreCase: true);
			mblnFieldInfoInitialized = true;
			if (fieldInfo == null || !typeof(IList).IsAssignableFrom(fieldInfo.PropertyType))
			{
				throw new ArgumentException(SR.GetString("RelatedListManagerChild", strDataField));
			}
			finalType = fieldInfo.PropertyType;
			WireParentManager(parentManager);
			ParentManager_CurrentItemChanged(objParentManager, EventArgs.Empty);
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

		public override PropertyDescriptorCollection GetItemProperties()
		{
			return GetItemProperties(null);
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
			if (ignoreParentCurrentItemChanged)
			{
				return;
			}
			int num = listposition;
			try
			{
				PullData();
			}
			catch (Exception objException)
			{
				OnDataError(objException);
			}
			EnsureFieldInfo();
			if (parentManager is CurrencyManager)
			{
				CurrencyManager currencyManager = (CurrencyManager)parentManager;
				if (currencyManager.Count > 0)
				{
					SetDataSource(fieldInfo.GetValue(currencyManager.Current));
					listposition = ((Count <= 0) ? (-1) : 0);
				}
				else
				{
					currencyManager.AddNew();
					try
					{
						ignoreParentCurrentItemChanged = true;
						currencyManager.CancelCurrentEdit();
					}
					finally
					{
						ignoreParentCurrentItemChanged = false;
					}
				}
			}
			else
			{
				SetDataSource(fieldInfo.GetValue(parentManager.Current));
				listposition = ((Count <= 0) ? (-1) : 0);
			}
			if (num != listposition)
			{
				OnPositionChanged(EventArgs.Empty);
			}
			OnCurrentChanged(EventArgs.Empty);
			OnCurrentItemChanged(EventArgs.Empty);
		}

		private void ParentManager_MetaDataChanged(object sender, EventArgs e)
		{
			OnMetaDataChanged(e);
		}

		private void UnwireParentManager(BindingManagerBase objBindingManagerBase)
		{
			if (objBindingManagerBase != null)
			{
				objBindingManagerBase.CurrentItemChanged -= ParentManager_CurrentItemChanged;
				if (objBindingManagerBase is CurrencyManager)
				{
					(objBindingManagerBase as CurrencyManager).MetaDataChanged -= ParentManager_MetaDataChanged;
				}
			}
		}

		private void WireParentManager(BindingManagerBase objBindingManagerBase)
		{
			if (objBindingManagerBase != null)
			{
				objBindingManagerBase.CurrentItemChanged += ParentManager_CurrentItemChanged;
				if (objBindingManagerBase is CurrencyManager)
				{
					(objBindingManagerBase as CurrencyManager).MetaDataChanged += ParentManager_MetaDataChanged;
				}
			}
		}
	}
}

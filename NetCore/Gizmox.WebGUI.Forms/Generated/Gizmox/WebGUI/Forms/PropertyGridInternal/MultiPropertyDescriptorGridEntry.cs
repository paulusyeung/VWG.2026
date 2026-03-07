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

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
	[Serializable]
	internal class MultiPropertyDescriptorGridEntry : PropertyDescriptorGridEntry
	{
		/// 
		/// The MergePropertyDescriptor property registration.
		/// </summary>
		private static readonly SerializableProperty mobjMergePropertyDescriptorProperty = SerializableProperty.Register("mobjMergePropertyDescriptor", typeof(MergePropertyDescriptor), typeof(MultiPropertyDescriptorGridEntry));

		/// 
		/// The object{} property registration.
		/// </summary>
		private static readonly SerializableProperty marrObjectsProperty = SerializableProperty.Register("marrObjects", typeof(object[]), typeof(MultiPropertyDescriptorGridEntry));

		private MergePropertyDescriptor mobjMergePropertyDescriptor
		{
			get
			{
				return GetValue(mobjMergePropertyDescriptorProperty);
			}
			set
			{
				SetValue(mobjMergePropertyDescriptorProperty, value);
			}
		}

		private object[] marrObjects
		{
			get
			{
				return GetValue<object[]>(marrObjectsProperty);
			}
			set
			{
				SetValue(marrObjectsProperty, value);
			}
		}

		public override IContainer Container
		{
			get
			{
				IContainer container = null;
				object[] array = marrObjects;
				int num = 0;
				if (num < array.Length)
				{
					object obj = array[num];
					if (obj is IComponent { Site: not null } component)
					{
						if (container == null)
						{
							return component.Site.Container;
						}
						if (container == component.Site.Container)
						{
							return container;
						}
					}
					return null;
				}
				return container;
			}
		}

		public override bool Expandable
		{
			get
			{
				bool flag = GetStateSet(131072);
				if (flag && base.ChildCollection.Count > 0)
				{
					return true;
				}
				if (GetStateSet(524288))
				{
					return false;
				}
				try
				{
					object[] values = mobjMergePropertyDescriptor.GetValues(marrObjects);
					for (int i = 0; i < values.Length; i++)
					{
						if (values[i] == null)
						{
							return false;
						}
					}
				}
				catch
				{
					flag = false;
				}
				return flag;
			}
		}

		public override object PropertyValue
		{
			set
			{
				base.PropertyValue = value;
				RecreateChildren();
				if (Expanded)
				{
					GridEntryHost.Refresh(blnFullRefresh: false);
				}
			}
		}

		public MultiPropertyDescriptorGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, object[] arrObjects, PropertyDescriptor[] arrPropDescriptors, bool blnHide)
			: base(objOwnerGrid, objParentGridEntry, blnHide)
		{
			mobjMergePropertyDescriptor = new MergePropertyDescriptor(arrPropDescriptors);
			marrObjects = arrObjects;
			Initialize(mobjMergePropertyDescriptor);
		}

		protected override bool CreateChildren()
		{
			return CreateChildren(blnDiffOldChildren: false);
		}

		protected override bool CreateChildren(bool blnDiffOldChildren)
		{
			try
			{
				if (mobjMergePropertyDescriptor.PropertyType.IsValueType || (Flags & 0x200) != 0)
				{
					return base.CreateChildren(blnDiffOldChildren);
				}
				base.ChildCollection.Clear();
				MultiPropertyDescriptorGridEntry[] mergedProperties = MultiSelectRootGridEntry.PropertyMerger.GetMergedProperties(mobjMergePropertyDescriptor.GetValues(marrObjects), this, base.menmPropertySort, CurrentTab);
				if (mergedProperties != null)
				{
					base.ChildCollection.AddRange(mergedProperties);
				}
				bool flag = Children.Count > 0;
				if (!flag)
				{
					SetState(524288, blnValue: true);
				}
				return flag;
			}
			catch
			{
				return false;
			}
		}

		public override object GetChildValueOwner(GridEntry objChildGridEntry)
		{
			if (!mobjMergePropertyDescriptor.PropertyType.IsValueType && (Flags & 0x200) == 0)
			{
				return mobjMergePropertyDescriptor.GetValues(marrObjects);
			}
			return base.GetChildValueOwner(objChildGridEntry);
		}

		public override IComponent[] GetComponents()
		{
			IComponent[] array = new IComponent[marrObjects.Length];
			Array.Copy(marrObjects, 0, array, 0, marrObjects.Length);
			return array;
		}

		public override string GetPropertyTextValue(object objValue)
		{
			bool blnAllEqual = true;
			try
			{
				if (objValue == null && mobjMergePropertyDescriptor.GetValue(marrObjects, out blnAllEqual) == null && !blnAllEqual)
				{
					return "";
				}
			}
			catch
			{
				return "";
			}
			return base.GetPropertyTextValue(objValue);
		}

		internal override bool NotifyChildValue(GridEntry objGridEntry, int intType)
		{
			bool result = false;
			IDesignerHost designerHost = DesignerHost;
			DesignerTransaction designerTransaction = null;
			if (designerHost != null)
			{
				designerTransaction = designerHost.CreateTransaction();
			}
			try
			{
				result = base.NotifyChildValue(objGridEntry, intType);
			}
			finally
			{
				designerTransaction?.Commit();
			}
			return result;
		}

		protected override void NotifyParentChange(GridEntry objGridEntry)
		{
			while (objGridEntry != null && objGridEntry is PropertyDescriptorGridEntry && ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo.Attributes.Contains(NotifyParentPropertyAttribute.Yes))
			{
				object valueOwner = objGridEntry.GetValueOwner();
				while (!(objGridEntry is PropertyDescriptorGridEntry) || OwnersEqual(valueOwner, objGridEntry.GetValueOwner()))
				{
					objGridEntry = objGridEntry.ParentGridEntry;
					if (objGridEntry == null)
					{
						break;
					}
				}
				if (objGridEntry == null)
				{
					continue;
				}
				valueOwner = objGridEntry.GetValueOwner();
				IComponentChangeService componentChangeService = ComponentChangeService;
				if (componentChangeService == null)
				{
					continue;
				}
				if (valueOwner is Array array)
				{
					for (int i = 0; i < array.Length; i++)
					{
						PropertyDescriptor propertyDescriptor = ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo;
						if (propertyDescriptor is MergePropertyDescriptor)
						{
							propertyDescriptor = ((MergePropertyDescriptor)propertyDescriptor)[i];
						}
						if (propertyDescriptor != null)
						{
							componentChangeService.OnComponentChanging(array.GetValue(i), propertyDescriptor);
							componentChangeService.OnComponentChanged(array.GetValue(i), propertyDescriptor, null, null);
						}
					}
				}
				else
				{
					componentChangeService.OnComponentChanging(valueOwner, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo);
					componentChangeService.OnComponentChanged(valueOwner, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo, null, null);
				}
			}
		}

		internal override bool NotifyValueGivenParent(object objObject, int intType)
		{
			if (objObject is ICustomTypeDescriptor)
			{
				objObject = ((ICustomTypeDescriptor)objObject).GetPropertyOwner(base.mobjPropertyInfo);
			}
			switch (intType)
			{
			case 1:
			{
				object[] array2 = (object[])objObject;
				if (array2 != null && array2.Length != 0)
				{
					IDesignerHost designerHost = DesignerHost;
					DesignerTransaction designerTransaction = null;
					if (designerHost != null)
					{
						designerTransaction = designerHost.CreateTransaction(SR.GetString("PropertyGridResetValue", PropertyName));
					}
					try
					{
						bool flag = !(array2[0] is IComponent) || ((IComponent)array2[0]).Site == null;
						if (flag && !OnComponentChanging())
						{
							if (designerTransaction != null)
							{
								designerTransaction.Cancel();
								designerTransaction = null;
							}
							return false;
						}
						mobjMergePropertyDescriptor.ResetValue(objObject);
						if (flag)
						{
							OnComponentChanged();
						}
						NotifyParentChange(this);
					}
					finally
					{
						designerTransaction?.Commit();
					}
				}
				return false;
			}
			case 3:
			case 5:
			{
				if (!(base.mobjPropertyInfo is MergePropertyDescriptor mergePropertyDescriptor))
				{
					return base.NotifyValueGivenParent(objObject, intType);
				}
				object[] array = (object[])objObject;
				if (base.mobjEventBindings == null)
				{
					base.mobjEventBindings = (IEventBindingService)GetService(typeof(IEventBindingService));
				}
				if (base.mobjEventBindings != null)
				{
					EventDescriptor eventDescriptor = base.mobjEventBindings.GetEvent(mergePropertyDescriptor[0]);
					if (eventDescriptor != null)
					{
						return ViewEvent(objObject, null, eventDescriptor, blnAlwaysNavigate: true);
					}
				}
				return false;
			}
			default:
				return base.NotifyValueGivenParent(objObject, intType);
			}
		}

		public override void OnComponentChanged()
		{
			if (ComponentChangeService != null)
			{
				int num = marrObjects.Length;
				for (int i = 0; i < num; i++)
				{
					ComponentChangeService.OnComponentChanged(marrObjects[i], mobjMergePropertyDescriptor[i], null, null);
				}
			}
		}

		public override bool OnComponentChanging()
		{
			if (ComponentChangeService != null)
			{
				int num = marrObjects.Length;
				for (int i = 0; i < num; i++)
				{
					try
					{
						ComponentChangeService.OnComponentChanging(marrObjects[i], mobjMergePropertyDescriptor[i]);
					}
					catch (CheckoutException ex)
					{
						if (ex != CheckoutException.Canceled)
						{
							throw ex;
						}
						return false;
					}
				}
			}
			return true;
		}

		private bool OwnersEqual(object objOwner1, object objOwner2)
		{
			if (!(objOwner1 is Array))
			{
				return objOwner1 == objOwner2;
			}
			Array array = objOwner1 as Array;
			Array array2 = objOwner2 as Array;
			if (array == null || array2 == null || array.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array.GetValue(i) != array2.GetValue(i))
				{
					return false;
				}
			}
			return true;
		}
	}
}

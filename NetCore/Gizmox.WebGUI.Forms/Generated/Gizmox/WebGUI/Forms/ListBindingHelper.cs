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
	/// Provides functionality to discover a bindable list and the properties of the items contained in the list when they differ from the public properties of the object to which they bind.</summary>
	[Serializable]
	public class ListBindingHelper
	{
		private static Attribute[] marrBrowsableAttribute;

		private static Attribute[] BrowsableAttributeList
		{
			get
			{
				if (marrBrowsableAttribute == null)
				{
					marrBrowsableAttribute = new Attribute[1]
					{
						new BrowsableAttribute(browsable: true)
					};
				}
				return marrBrowsableAttribute;
			}
		}

		private static object GetFirstItemByEnumerable(IEnumerable enumerable)
		{
			object result = null;
			if (enumerable is IList)
			{
				IList list = enumerable as IList;
				return (list.Count > 0) ? list[0] : null;
			}
			try
			{
				IEnumerator enumerator = enumerable.GetEnumerator();
				enumerator.Reset();
				if (enumerator.MoveNext())
				{
					result = enumerator.Current;
				}
				enumerator.Reset();
			}
			catch (NotSupportedException)
			{
				result = null;
			}
			return result;
		}

		/// Returns a list associated with the specified data source.</summary>
		/// An <see cref="T:System.Object"></see> representing the underlying list if it exists; otherwise, the original data source specified by list.</returns>
		/// <param name="objList">The data source to examine for its underlying list.</param>
		public static object GetList(object objList)
		{
			if (objList is IListSource)
			{
				return (objList as IListSource).GetList();
			}
			return objList;
		}

		/// Returns an object, typically a list, from the evaluation of a specified data source and optional data member.</summary>
		/// An <see cref="T:System.Object"></see> representing the underlying list if it was found; otherwise, dataSource.</returns>
		/// <param name="objDataSource">The data source from which to find the list.</param>
		/// <param name="strDataMember">The name of the data source property that contains the list. This can be null.</param>
		/// <exception cref="T:System.ArgumentException">The specified data member name did not match any of the properties found for the data source.</exception>
		public static object GetList(object objDataSource, string strDataMember)
		{
			objDataSource = GetList(objDataSource);
			if (objDataSource == null || objDataSource is Type || CommonUtils.IsNullOrEmpty(strDataMember))
			{
				return objDataSource;
			}
			PropertyDescriptor propertyDescriptor = GetListItemProperties(objDataSource).Find(strDataMember, ignoreCase: true);
			if (propertyDescriptor == null)
			{
				throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", strDataMember));
			}
			object obj;
			if (!(objDataSource is ICurrencyManagerProvider))
			{
				obj = ((!(objDataSource is IEnumerable)) ? objDataSource : GetFirstItemByEnumerable(objDataSource as IEnumerable));
			}
			else
			{
				CurrencyManager currencyManager = (objDataSource as ICurrencyManagerProvider).CurrencyManager;
				obj = ((currencyManager != null && currencyManager.Position >= 0 && currencyManager.Position <= currencyManager.Count - 1) ? currencyManager.Current : null);
			}
			if (obj != null)
			{
				return propertyDescriptor.GetValue(obj);
			}
			return null;
		}

		/// Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in a specified data source, or properties of the specified data source.</summary>
		/// The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> containing the properties of the items contained in list, or properties of list.</returns>
		/// <param name="objList">The data source to examine for property information.</param>
		public static PropertyDescriptorCollection GetListItemProperties(object objList)
		{
			if (objList == null)
			{
				return new PropertyDescriptorCollection(null);
			}
			if (objList is Type)
			{
				return GetListItemPropertiesByType(objList as Type);
			}
			object list = GetList(objList);
			if (list is ITypedList)
			{
				return (list as ITypedList).GetItemProperties(null);
			}
			if (list is IEnumerable)
			{
				return GetListItemPropertiesByEnumerable(list as IEnumerable);
			}
			return TypeDescriptor.GetProperties(list);
		}

		/// Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in a collection property of a data source. Uses the specified <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array to indicate which properties to examine.</summary>
		/// The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> describing the properties of the item type contained in a collection property of the data source.</returns>
		/// <param name="objList">The data source to be examined for property information.</param>
		/// <param name="arrListAccessors">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array describing which properties of the data source to examine. This can be null.</param>
		public static PropertyDescriptorCollection GetListItemProperties(object objList, PropertyDescriptor[] arrListAccessors)
		{
			if (arrListAccessors == null || arrListAccessors.Length == 0)
			{
				return GetListItemProperties(objList);
			}
			if (objList is Type)
			{
				return GetListItemPropertiesByType(objList as Type, arrListAccessors);
			}
			object list = GetList(objList);
			if (list is ITypedList)
			{
				return (list as ITypedList).GetItemProperties(arrListAccessors);
			}
			if (list is IEnumerable)
			{
				return GetListItemPropertiesByEnumerable(list as IEnumerable, arrListAccessors);
			}
			return GetListItemPropertiesByInstance(list, arrListAccessors, 0);
		}

		/// Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in the specified data member of a data source. Uses the specified <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array to indicate which properties to examine.</summary>
		/// The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> describing the properties of an item type contained in a collection property of the specified data source.</returns>
		/// <param name="objDataSource">The data source to be examined for property information.</param>
		/// <param name="strDataMember">The optional data member to be examined for property information. This can be null.</param>
		/// <param name="arrListAccessors">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array describing which properties of the data member to examine. This can be null.</param>
		/// <exception cref="T:System.ArgumentException">The specified data member could not be found in the specified data source.</exception>
		public static PropertyDescriptorCollection GetListItemProperties(object objDataSource, string strDataMember, PropertyDescriptor[] arrListAccessors)
		{
			objDataSource = GetList(objDataSource);
			if (!CommonUtils.IsNullOrEmpty(strDataMember))
			{
				PropertyDescriptor propertyDescriptor = GetListItemProperties(objDataSource).Find(strDataMember, ignoreCase: true);
				if (propertyDescriptor == null)
				{
					throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", strDataMember));
				}
				int num = ((arrListAccessors == null) ? 1 : (arrListAccessors.Length + 1));
				PropertyDescriptor[] array = new PropertyDescriptor[num];
				array[0] = propertyDescriptor;
				for (int i = 1; i < num; i++)
				{
					array[i] = arrListAccessors[i - 1];
				}
				arrListAccessors = array;
			}
			return GetListItemProperties(objDataSource, arrListAccessors);
		}

		private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(IEnumerable enumerable)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = null;
			Type type = enumerable.GetType();
			if (typeof(Array).IsAssignableFrom(type))
			{
				propertyDescriptorCollection = TypeDescriptor.GetProperties(type.GetElementType(), BrowsableAttributeList);
			}
			else if (enumerable is ITypedList typedList)
			{
				propertyDescriptorCollection = typedList.GetItemProperties(null);
			}
			else
			{
				PropertyInfo typedIndexer = GetTypedIndexer(type);
				if (typedIndexer != null && !typeof(ICustomTypeDescriptor).IsAssignableFrom(typedIndexer.PropertyType))
				{
					propertyDescriptorCollection = TypeDescriptor.GetProperties(typedIndexer.PropertyType, BrowsableAttributeList);
				}
			}
			if (propertyDescriptorCollection != null)
			{
				return propertyDescriptorCollection;
			}
			object firstItemByEnumerable = GetFirstItemByEnumerable(enumerable);
			if (!(enumerable is string))
			{
				if (firstItemByEnumerable == null)
				{
					return new PropertyDescriptorCollection(null);
				}
				propertyDescriptorCollection = TypeDescriptor.GetProperties(firstItemByEnumerable, BrowsableAttributeList);
				if (enumerable is IList || (propertyDescriptorCollection != null && propertyDescriptorCollection.Count != 0))
				{
					return propertyDescriptorCollection;
				}
			}
			return TypeDescriptor.GetProperties(enumerable, BrowsableAttributeList);
		}

		private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(IEnumerable enumerable, PropertyDescriptor[] arrListAccessors)
		{
			if (arrListAccessors == null || arrListAccessors.Length == 0)
			{
				return GetListItemPropertiesByEnumerable(enumerable);
			}
			if (enumerable is ITypedList typedList)
			{
				return typedList.GetItemProperties(arrListAccessors);
			}
			return GetListItemPropertiesByEnumerable(enumerable, arrListAccessors, 0);
		}

		private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(IEnumerable iEnumerable, PropertyDescriptor[] arrListAccessors, int intStartIndex)
		{
			object obj = null;
			object firstItemByEnumerable = GetFirstItemByEnumerable(iEnumerable);
			if (firstItemByEnumerable != null)
			{
				obj = GetList(arrListAccessors[intStartIndex].GetValue(firstItemByEnumerable));
			}
			if (obj == null)
			{
				return GetListItemPropertiesByType(arrListAccessors[intStartIndex].PropertyType, arrListAccessors, intStartIndex);
			}
			intStartIndex++;
			if (obj is IEnumerable enumerable)
			{
				if (intStartIndex == arrListAccessors.Length)
				{
					return GetListItemPropertiesByEnumerable(enumerable);
				}
				return GetListItemPropertiesByEnumerable(enumerable, arrListAccessors, intStartIndex);
			}
			return GetListItemPropertiesByInstance(obj, arrListAccessors, intStartIndex);
		}

		private static PropertyDescriptorCollection GetListItemPropertiesByInstance(object objTarget, PropertyDescriptor[] arrListAccessors, int intStartIndex)
		{
			if (arrListAccessors != null && arrListAccessors.Length > intStartIndex)
			{
				object value = arrListAccessors[intStartIndex].GetValue(objTarget);
				if (value == null)
				{
					return GetListItemPropertiesByType(arrListAccessors[intStartIndex].PropertyType);
				}
				PropertyDescriptor[] array = null;
				if (arrListAccessors.Length > intStartIndex + 1)
				{
					int num = arrListAccessors.Length - (intStartIndex + 1);
					array = new PropertyDescriptor[num];
					for (int i = 0; i < num; i++)
					{
						array[i] = arrListAccessors[intStartIndex + 1 + i];
					}
				}
				return GetListItemProperties(value, array);
			}
			return TypeDescriptor.GetProperties(objTarget, BrowsableAttributeList);
		}

		private static PropertyDescriptorCollection GetListItemPropertiesByType(Type objType)
		{
			return TypeDescriptor.GetProperties(GetListItemType(objType), BrowsableAttributeList);
		}

		private static PropertyDescriptorCollection GetListItemPropertiesByType(Type objType, PropertyDescriptor[] arrListAccessors)
		{
			if (arrListAccessors == null || arrListAccessors.Length == 0)
			{
				return GetListItemPropertiesByType(objType);
			}
			return GetListItemPropertiesByType(objType, arrListAccessors, 0);
		}

		private static PropertyDescriptorCollection GetListItemPropertiesByType(Type objType, PropertyDescriptor[] arrListAccessors, int intStartIndex)
		{
			Type propertyType = arrListAccessors[intStartIndex].PropertyType;
			intStartIndex++;
			if (intStartIndex >= arrListAccessors.Length)
			{
				return GetListItemProperties(propertyType);
			}
			return GetListItemPropertiesByType(propertyType, arrListAccessors, intStartIndex);
		}

		/// Returns the data type of the items in the specified list.</summary>
		/// The <see cref="T:System.Type"></see> of the items contained in the list.</returns>
		/// <param name="objList">The list to be examined for type information. </param>
		public static Type GetListItemType(object objList)
		{
			if (objList == null)
			{
				return null;
			}
			Type type = ((objList is Type) ? (objList as Type) : objList.GetType());
			object obj = ((objList is Type) ? null : objList);
			if (typeof(Array).IsAssignableFrom(type))
			{
				return type.GetElementType();
			}
			PropertyInfo typedIndexer = GetTypedIndexer(type);
			if (typedIndexer != null)
			{
				return typedIndexer.PropertyType;
			}
			if (obj is IEnumerable)
			{
				return GetListItemTypeByEnumerable(obj as IEnumerable);
			}
			return type;
		}

		/// Returns the data type of the items in the specified data source.</summary>
		/// For complex data binding, the <see cref="T:System.Type"></see> of the items represented by the dataMember in the data source; otherwise, the <see cref="T:System.Type"></see> of the item in the list itself.</returns>
		/// <param name="objDataSource">The data source to examine for items. </param>
		/// <param name="strDataMember">The optional name of the property on the data source that is to be used as the data member. This can be null.</param>
		public static Type GetListItemType(object objDataSource, string strDataMember)
		{
			if (objDataSource != null)
			{
				if (CommonUtils.IsNullOrEmpty(strDataMember))
				{
					return GetListItemType(objDataSource);
				}
				PropertyDescriptorCollection listItemProperties = GetListItemProperties(objDataSource);
				if (listItemProperties == null)
				{
					return typeof(object);
				}
				PropertyDescriptor propertyDescriptor = listItemProperties.Find(strDataMember, ignoreCase: true);
				if (propertyDescriptor != null && !(propertyDescriptor.PropertyType is ICustomTypeDescriptor))
				{
					return GetListItemType(propertyDescriptor.PropertyType);
				}
			}
			return typeof(object);
		}

		private static Type GetListItemTypeByEnumerable(IEnumerable iEnumerable)
		{
			object firstItemByEnumerable = GetFirstItemByEnumerable(iEnumerable);
			if (firstItemByEnumerable == null)
			{
				return typeof(object);
			}
			return firstItemByEnumerable.GetType();
		}

		/// Returns the name of an underlying list, given a data source and optional <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array.</summary>
		/// The name of the list in the data source, as described by listAccessors, orthe name of the data source type.</returns>
		/// <param name="objList">The data source to examine for the list name.</param>
		/// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the data source. This can be null.</param>
		public static string GetListName(object objList, PropertyDescriptor[] arrListAccessors)
		{
			if (objList == null)
			{
				return string.Empty;
			}
			if (objList is ITypedList typedList)
			{
				return typedList.GetListName(arrListAccessors);
			}
			Type objType;
			if (arrListAccessors == null || arrListAccessors.Length == 0)
			{
				Type type = objList as Type;
				objType = ((!(type != null)) ? objList.GetType() : type);
			}
			else
			{
				PropertyDescriptor propertyDescriptor = arrListAccessors[0];
				objType = propertyDescriptor.PropertyType;
			}
			return GetListNameFromType(objType);
		}

		private static string GetListNameFromType(Type objType)
		{
			if (typeof(Array).IsAssignableFrom(objType))
			{
				return objType.GetElementType().Name;
			}
			if (typeof(IList).IsAssignableFrom(objType))
			{
				PropertyInfo typedIndexer = GetTypedIndexer(objType);
				if (typedIndexer != null)
				{
					return typedIndexer.PropertyType.Name;
				}
				return objType.Name;
			}
			return objType.Name;
		}

		private static PropertyInfo GetTypedIndexer(Type objType)
		{
			if (!typeof(IList).IsAssignableFrom(objType) && !typeof(ITypedList).IsAssignableFrom(objType) && !typeof(IListSource).IsAssignableFrom(objType))
			{
				return null;
			}
			PropertyInfo propertyInfo = null;
			PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < properties.Length; i++)
			{
				if (properties[i].GetIndexParameters().Length != 0 && properties[i].PropertyType != typeof(object))
				{
					propertyInfo = properties[i];
					if (propertyInfo.Name == "Item")
					{
						return propertyInfo;
					}
				}
			}
			return propertyInfo;
		}
	}
}

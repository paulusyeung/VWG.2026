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
	internal class MergePropertyDescriptor : PropertyDescriptor
	{
		[Serializable]
		private class MergedAttributeCollection : System.ComponentModel.AttributeCollection
		{
			private System.ComponentModel.AttributeCollection[] marrAttributeCollections;

			private IDictionary mobjFoundAttributes;

			private MergePropertyDescriptor mobjOwner;

			public override Attribute this[Type objAttributeType] => GetCommonAttribute(objAttributeType);

			public MergedAttributeCollection(MergePropertyDescriptor objOwner)
				: base((Attribute[])null)
			{
				mobjOwner = objOwner;
			}

			private Attribute GetCommonAttribute(Type objAttributeType)
			{
				if (marrAttributeCollections == null)
				{
					marrAttributeCollections = new System.ComponentModel.AttributeCollection[mobjOwner.marrDescriptors.Length];
					for (int i = 0; i < mobjOwner.marrDescriptors.Length; i++)
					{
						marrAttributeCollections[i] = mobjOwner.marrDescriptors[i].Attributes;
					}
				}
				if (marrAttributeCollections.Length == 0)
				{
					return GetDefaultAttribute(objAttributeType);
				}
				if (mobjFoundAttributes != null && mobjFoundAttributes[objAttributeType] is Attribute result)
				{
					return result;
				}
				Attribute attribute = marrAttributeCollections[0][objAttributeType];
				if (attribute == null)
				{
					return null;
				}
				for (int j = 1; j < marrAttributeCollections.Length; j++)
				{
					Attribute obj = marrAttributeCollections[j][objAttributeType];
					if (!attribute.Equals(obj))
					{
						attribute = GetDefaultAttribute(objAttributeType);
						break;
					}
				}
				if (mobjFoundAttributes == null)
				{
					mobjFoundAttributes = new Hashtable();
				}
				mobjFoundAttributes[objAttributeType] = attribute;
				return attribute;
			}
		}

		[Serializable]
		private class MultiMergeCollection : ICollection, IEnumerable
		{
			private object[] marrItems;

			private bool mblnLocked;

			public int Count
			{
				get
				{
					if (marrItems != null)
					{
						return marrItems.Length;
					}
					return 0;
				}
			}

			public bool Locked
			{
				get
				{
					return mblnLocked;
				}
				set
				{
					mblnLocked = value;
				}
			}

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => this;

			public MultiMergeCollection(ICollection original)
			{
				SetItems(original);
			}

			public void CopyTo(Array objArray, int index)
			{
				if (marrItems != null)
				{
					Array.Copy(marrItems, 0, objArray, index, marrItems.Length);
				}
			}

			public IEnumerator GetEnumerator()
			{
				if (marrItems != null)
				{
					return marrItems.GetEnumerator();
				}
				return new object[0].GetEnumerator();
			}

			public bool MergeCollection(ICollection objNewCollection)
			{
				if (!mblnLocked)
				{
					if (marrItems.Length != objNewCollection.Count)
					{
						marrItems = new object[0];
						return false;
					}
					object[] array = new object[objNewCollection.Count];
					objNewCollection.CopyTo(array, 0);
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] == null != (marrItems[i] == null) || (marrItems[i] != null && !marrItems[i].Equals(array[i])))
						{
							marrItems = new object[0];
							return false;
						}
					}
				}
				return true;
			}

			public void SetItems(ICollection objCollection)
			{
				if (!mblnLocked)
				{
					marrItems = new object[objCollection.Count];
					objCollection.CopyTo(marrItems, 0);
				}
			}
		}

		private enum TriState
		{
			Unknown,
			Yes,
			No
		}

		private TriState menmCanReset;

		private MultiMergeCollection mobjCollection;

		private PropertyDescriptor[] marrDescriptors;

		private TriState menmLocalizable;

		private TriState menmReadOnly;

		public override Type ComponentType => marrDescriptors[0].ComponentType;

		public override TypeConverter Converter => marrDescriptors[0].Converter;

		public override string DisplayName => marrDescriptors[0].DisplayName;

		public override bool IsLocalizable
		{
			get
			{
				if (menmLocalizable == TriState.Unknown)
				{
					menmLocalizable = TriState.Yes;
					PropertyDescriptor[] array = marrDescriptors;
					foreach (PropertyDescriptor propertyDescriptor in array)
					{
						if (!propertyDescriptor.IsLocalizable)
						{
							menmLocalizable = TriState.No;
							break;
						}
					}
				}
				return menmLocalizable == TriState.Yes;
			}
		}

		public override bool IsReadOnly
		{
			get
			{
				if (menmReadOnly == TriState.Unknown)
				{
					menmReadOnly = TriState.No;
					PropertyDescriptor[] array = marrDescriptors;
					foreach (PropertyDescriptor propertyDescriptor in array)
					{
						if (propertyDescriptor.IsReadOnly)
						{
							menmReadOnly = TriState.Yes;
							break;
						}
					}
				}
				return menmReadOnly == TriState.Yes;
			}
		}

		public PropertyDescriptor this[int index] => marrDescriptors[index];

		public override Type PropertyType => marrDescriptors[0].PropertyType;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyGridInternal.MergePropertyDescriptor" /> class.
		/// </summary>
		/// <param name="arrDescriptors">The arr descriptors.</param>
		public MergePropertyDescriptor(PropertyDescriptor[] arrDescriptors)
			: base(arrDescriptors[0].Name, null)
		{
			marrDescriptors = arrDescriptors;
		}

		public override bool CanResetValue(object objComponent)
		{
			if (menmCanReset == TriState.Unknown)
			{
				menmCanReset = TriState.Yes;
				Array objArray = (Array)objComponent;
				for (int i = 0; i < marrDescriptors.Length; i++)
				{
					if (!marrDescriptors[i].CanResetValue(GetPropertyOwnerForComponent(objArray, i)))
					{
						menmCanReset = TriState.No;
						break;
					}
				}
			}
			return menmCanReset == TriState.Yes;
		}

		private object CopyValue(object objValue)
		{
			if (objValue != null)
			{
				Type type = objValue.GetType();
				if (type.IsValueType)
				{
					return objValue;
				}
				object obj = null;
				if (objValue is ICloneable cloneable)
				{
					obj = cloneable.Clone();
				}
				if (obj == null)
				{
					TypeConverter typeConverter = TypeDescriptor.GetConverter(objValue);
					if (typeConverter.CanConvertTo(typeof(InstanceDescriptor)))
					{
						InstanceDescriptor instanceDescriptor = (InstanceDescriptor)typeConverter.ConvertTo(null, CultureInfo.InvariantCulture, objValue, typeof(InstanceDescriptor));
						if (instanceDescriptor != null && instanceDescriptor.IsComplete)
						{
							obj = instanceDescriptor.Invoke();
						}
					}
					if (obj == null && typeConverter.CanConvertTo(typeof(string)) && typeConverter.CanConvertFrom(typeof(string)))
					{
						object obj2 = typeConverter.ConvertToInvariantString(objValue);
						obj = typeConverter.ConvertFromInvariantString((string)obj2);
					}
				}
				if (obj == null && type.IsSerializable)
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					MemoryStream memoryStream = new MemoryStream();
					binaryFormatter.Serialize(memoryStream, objValue);
					memoryStream.Position = 0L;
					obj = binaryFormatter.Deserialize(memoryStream);
				}
				if (obj != null)
				{
					return obj;
				}
			}
			return objValue;
		}

		protected override System.ComponentModel.AttributeCollection CreateAttributeCollection()
		{
			return new MergedAttributeCollection(this);
		}

		public override object GetEditor(Type objEditorBaseType)
		{
			return marrDescriptors[0].GetEditor(objEditorBaseType);
		}

		private object GetPropertyOwnerForComponent(Array objArray, int i)
		{
			object obj = objArray.GetValue(i);
			if (obj is ICustomTypeDescriptor)
			{
				obj = ((ICustomTypeDescriptor)obj).GetPropertyOwner(marrDescriptors[i]);
			}
			return obj;
		}

		public override object GetValue(object objComponent)
		{
			bool blnAllEqual;
			return GetValue((Array)objComponent, out blnAllEqual);
		}

		public object GetValue(Array objComponentsArray, out bool blnAllEqual)
		{
			blnAllEqual = true;
			object value = marrDescriptors[0].GetValue(GetPropertyOwnerForComponent(objComponentsArray, 0));
			if (value is ICollection)
			{
				if (mobjCollection == null)
				{
					mobjCollection = new MultiMergeCollection((ICollection)value);
				}
				else
				{
					if (mobjCollection.Locked)
					{
						return mobjCollection;
					}
					mobjCollection.SetItems((ICollection)value);
				}
			}
			for (int i = 1; i < marrDescriptors.Length; i++)
			{
				object value2 = marrDescriptors[i].GetValue(GetPropertyOwnerForComponent(objComponentsArray, i));
				if (mobjCollection != null)
				{
					if (!mobjCollection.MergeCollection((ICollection)value2))
					{
						blnAllEqual = false;
						return null;
					}
				}
				else if ((value != null || value2 != null) && (value == null || !value.Equals(value2)))
				{
					blnAllEqual = false;
					return null;
				}
			}
			if (blnAllEqual && mobjCollection != null && mobjCollection.Count == 0)
			{
				return null;
			}
			if (mobjCollection == null)
			{
				return value;
			}
			return mobjCollection;
		}

		internal object[] GetValues(Array objComponentsArray)
		{
			object[] array = new object[objComponentsArray.Length];
			for (int i = 0; i < objComponentsArray.Length; i++)
			{
				array[i] = marrDescriptors[i].GetValue(GetPropertyOwnerForComponent(objComponentsArray, i));
			}
			return array;
		}

		public override void ResetValue(object objComponent)
		{
			Array objArray = (Array)objComponent;
			for (int i = 0; i < marrDescriptors.Length; i++)
			{
				marrDescriptors[i].ResetValue(GetPropertyOwnerForComponent(objArray, i));
			}
		}

		private void SetCollectionValues(Array objArray, IList objListValue)
		{
			try
			{
				if (mobjCollection != null)
				{
					mobjCollection.Locked = true;
				}
				object[] array = new object[objListValue.Count];
				objListValue.CopyTo(array, 0);
				for (int i = 0; i < marrDescriptors.Length; i++)
				{
					if (marrDescriptors[i].GetValue(GetPropertyOwnerForComponent(objArray, i)) is IList list)
					{
						list.Clear();
						object[] array2 = array;
						foreach (object value in array2)
						{
							list.Add(value);
						}
					}
				}
			}
			finally
			{
				if (mobjCollection != null)
				{
					mobjCollection.Locked = false;
				}
			}
		}

		public override void SetValue(object objComponent, object objValue)
		{
			Array objArray = (Array)objComponent;
			if (objValue is IList && typeof(IList).IsAssignableFrom(PropertyType))
			{
				SetCollectionValues(objArray, (IList)objValue);
				return;
			}
			for (int i = 0; i < marrDescriptors.Length; i++)
			{
				object value = CopyValue(objValue);
				marrDescriptors[i].SetValue(GetPropertyOwnerForComponent(objArray, i), value);
			}
		}

		public override bool ShouldSerializeValue(object objComponent)
		{
			Array objArray = (Array)objComponent;
			for (int i = 0; i < marrDescriptors.Length; i++)
			{
				if (!marrDescriptors[i].ShouldSerializeValue(GetPropertyOwnerForComponent(objArray, i)))
				{
					return false;
				}
			}
			return true;
		}
	}
}

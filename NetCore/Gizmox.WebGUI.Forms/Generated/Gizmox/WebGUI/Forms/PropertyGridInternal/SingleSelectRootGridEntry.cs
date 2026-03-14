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
	internal class SingleSelectRootGridEntry : GridEntry, IRootGridEntry
	{
		/// 
		/// The IServiceProvider property registration.
		/// </summary>
		private static readonly SerializableProperty baseProviderProperty = SerializableProperty.Register("baseProvider", typeof(IServiceProvider), typeof(SingleSelectRootGridEntry));

		/// 
		/// The AttributeCollection property registration.
		/// </summary>
		private static readonly SerializableProperty browsableAttributesProperty = SerializableProperty.Register("browsableAttributes", typeof(System.ComponentModel.AttributeCollection), typeof(SingleSelectRootGridEntry));

		/// 
		/// The IComponentChangeService property registration.
		/// </summary>
		private static readonly SerializableProperty changeServiceProperty = SerializableProperty.Register("changeService", typeof(IComponentChangeService), typeof(SingleSelectRootGridEntry));

		/// 
		/// The bool property registration.
		/// </summary>
		private static readonly SerializableProperty forceReadOnlyCheckedProperty = SerializableProperty.Register("forceReadOnlyChecked", typeof(bool), typeof(SingleSelectRootGridEntry));

		/// 
		/// The PropertyGridView property registration.
		/// </summary>
		private static readonly SerializableProperty gridEntryHostProperty = SerializableProperty.Register("gridEntryHost", typeof(PropertyGridView), typeof(SingleSelectRootGridEntry));

		/// 
		/// The IDesignerHost property registration.
		/// </summary>
		private static readonly SerializableProperty hostProperty = SerializableProperty.Register("host", typeof(IDesignerHost), typeof(SingleSelectRootGridEntry));

		/// 
		/// The object property registration.
		/// </summary>
		private static readonly SerializableProperty objValueProperty = SerializableProperty.Register("objValue", typeof(object), typeof(SingleSelectRootGridEntry));

		/// 
		/// The string property registration.
		/// </summary>
		private static readonly SerializableProperty objValueClassNameProperty = SerializableProperty.Register("objValueClassName", typeof(string), typeof(SingleSelectRootGridEntry));

		/// 
		/// The GridEntry property registration.
		/// </summary>
		private static readonly SerializableProperty propDefaultProperty = SerializableProperty.Register("propDefault", typeof(GridEntry), typeof(SingleSelectRootGridEntry));

		/// 
		/// The PropertyTab property registration.
		/// </summary>
		private static readonly SerializableProperty tabProperty = SerializableProperty.Register("tab", typeof(PropertyTab), typeof(SingleSelectRootGridEntry));

		protected IServiceProvider baseProvider
		{
			get
			{
				return GetValue(baseProviderProperty);
			}
			set
			{
				SetValue(baseProviderProperty, value);
			}
		}

		protected System.ComponentModel.AttributeCollection browsableAttributes
		{
			get
			{
				return GetValue<System.ComponentModel.AttributeCollection>(browsableAttributesProperty);
			}
			set
			{
				SetValue(browsableAttributesProperty, value);
			}
		}

		private IComponentChangeService changeService
		{
			get
			{
				return GetValue(changeServiceProperty);
			}
			set
			{
				SetValue(changeServiceProperty, value);
			}
		}

		protected bool forceReadOnlyChecked
		{
			get
			{
				return GetValue(forceReadOnlyCheckedProperty);
			}
			set
			{
				SetValue(forceReadOnlyCheckedProperty, value);
			}
		}

		protected PropertyGridView gridEntryHost
		{
			get
			{
				return GetValue(gridEntryHostProperty);
			}
			set
			{
				SetValue(gridEntryHostProperty, value);
			}
		}

		protected IDesignerHost host
		{
			get
			{
				return GetValue(hostProperty);
			}
			set
			{
				SetValue(hostProperty, value);
			}
		}

		protected object objValue
		{
			get
			{
				return GetValue(objValueProperty);
			}
			set
			{
				SetValue(objValueProperty, value);
			}
		}

		protected string objValueClassName
		{
			get
			{
				return GetValue(objValueClassNameProperty);
			}
			set
			{
				SetValue(objValueClassNameProperty, value);
			}
		}

		protected GridEntry propDefault
		{
			get
			{
				return GetValue(propDefaultProperty);
			}
			set
			{
				SetValue(propDefaultProperty, value);
			}
		}

		protected PropertyTab tab
		{
			get
			{
				return GetValue(tabProperty);
			}
			set
			{
				SetValue(tabProperty, value);
			}
		}

		internal override bool AlwaysAllowExpand => true;

		public override System.ComponentModel.AttributeCollection BrowsableAttributes
		{
			get
			{
				if (browsableAttributes == null)
				{
					browsableAttributes = new System.ComponentModel.AttributeCollection(BrowsableAttribute.Yes);
				}
				return browsableAttributes;
			}
			set
			{
				if (value == null)
				{
					ResetBrowsableAttributes();
					return;
				}
				bool flag = true;
				if (browsableAttributes != null && value != null && browsableAttributes.Count == value.Count)
				{
					Attribute[] array = new Attribute[browsableAttributes.Count];
					Attribute[] array2 = new Attribute[value.Count];
					browsableAttributes.CopyTo(array, 0);
					value.CopyTo(array2, 0);
					Array.Sort(array, GridEntry.AttributeTypeSorter);
					Array.Sort(array2, GridEntry.AttributeTypeSorter);
					for (int i = 0; i < array.Length; i++)
					{
						if (!array[i].Equals(array2[i]))
						{
							flag = false;
							break;
						}
					}
				}
				else
				{
					flag = false;
				}
				browsableAttributes = value;
				if (!flag && Children != null && Children.Count > 0)
				{
					DisposeChildren();
				}
			}
		}

		protected override IComponentChangeService ComponentChangeService
		{
			get
			{
				if (changeService == null)
				{
					changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
				}
				return changeService;
			}
		}

		public override PropertyTab CurrentTab
		{
			get
			{
				return tab;
			}
			set
			{
				tab = value;
			}
		}

		internal override GridEntry DefaultChild
		{
			get
			{
				return propDefault;
			}
			set
			{
				propDefault = value;
			}
		}

		internal override IDesignerHost DesignerHost
		{
			get
			{
				return host;
			}
			set
			{
				host = value;
			}
		}

		internal override bool ForceReadOnly
		{
			get
			{
				if (!forceReadOnlyChecked)
				{
					ReadOnlyAttribute readOnlyAttribute = (ReadOnlyAttribute)TypeDescriptor.GetAttributes(objValue)[typeof(ReadOnlyAttribute)];
					if ((readOnlyAttribute != null && !readOnlyAttribute.IsDefaultAttribute()) || TypeDescriptor.GetAttributes(objValue).Contains(InheritanceAttribute.InheritedReadOnly))
					{
						base.State |= 1024;
					}
					forceReadOnlyChecked = true;
				}
				if (base.ForceReadOnly)
				{
					return true;
				}
				if (GridEntryHost != null)
				{
					return !GridEntryHost.Enabled;
				}
				return false;
			}
		}

		internal override PropertyGridView GridEntryHost
		{
			get
			{
				return gridEntryHost;
			}
			set
			{
				gridEntryHost = value;
			}
		}

		public override GridItemType GridItemType => GridItemType.Root;

		public override string HelpKeyword
		{
			get
			{
				HelpKeywordAttribute helpKeywordAttribute = (HelpKeywordAttribute)TypeDescriptor.GetAttributes(objValue)[typeof(HelpKeywordAttribute)];
				if (helpKeywordAttribute != null && !helpKeywordAttribute.IsDefaultAttribute())
				{
					return helpKeywordAttribute.HelpKeyword;
				}
				return objValueClassName;
			}
		}

		public override string PropertyLabel
		{
			get
			{
				if (objValue is IComponent)
				{
					ISite site = ((IComponent)objValue).Site;
					if (site == null)
					{
						return objValue.GetType().Name;
					}
					return site.Name;
				}
				if (objValue != null)
				{
					return objValue.ToString();
				}
				return null;
			}
		}

		public override object PropertyValue
		{
			get
			{
				return objValue;
			}
			set
			{
				object objOldObject = objValue;
				objValue = value;
				objValueClassName = TypeDescriptor.GetClassName(objValue);
				base.mobjOwnerPropertyGrid.ReplaceSelectedObject(objOldObject, value);
			}
		}

		internal SingleSelectRootGridEntry(PropertyGridView objPropertyGridView, object objValue, IServiceProvider objBaseProvider, IDesignerHost objHost, PropertyTab objPropertyTab, PropertySort objSortType)
			: this(objPropertyGridView, objValue, null, objBaseProvider, objHost, objPropertyTab, objSortType)
		{
		}

		internal SingleSelectRootGridEntry(PropertyGridView objGridEntryHost, object objValue, GridEntry objParentEntry, IServiceProvider objBaseProvider, IDesignerHost objHost, PropertyTab objPropertyTab, PropertySort objSortType)
			: base(objGridEntryHost.OwnerGrid, objParentEntry)
		{
			host = objHost;
			gridEntryHost = objGridEntryHost;
			baseProvider = objBaseProvider;
			tab = objPropertyTab;
			this.objValue = objValue;
			objValueClassName = TypeDescriptor.GetClassName(this.objValue);
			IsExpandable = true;
			base.menmPropertySort = objSortType;
			InternalExpanded = true;
		}

		internal void CategorizePropEntries()
		{
			if (Children.Count <= 0)
			{
				return;
			}
			GridEntry[] array = new GridEntry[Children.Count];
			Children.CopyTo(array, 0);
			if ((base.menmPropertySort & PropertySort.Categorized) == 0)
			{
				return;
			}
			Hashtable hashtable = new Hashtable();
			foreach (GridEntry gridEntry in array)
			{
				if (gridEntry != null)
				{
					string propertyCategory = gridEntry.PropertyCategory;
					ArrayList arrayList = (ArrayList)hashtable[propertyCategory];
					if (arrayList == null)
					{
						arrayList = (ArrayList)(hashtable[propertyCategory] = new ArrayList());
					}
					arrayList.Add(gridEntry);
				}
			}
			ArrayList arrayList3 = new ArrayList();
			IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ArrayList arrayList4 = (ArrayList)enumerator.Value;
				if (arrayList4 == null)
				{
					continue;
				}
				string strName = (string)enumerator.Key;
				if (arrayList4.Count > 0)
				{
					GridEntry[] array2 = new GridEntry[arrayList4.Count];
					arrayList4.CopyTo(array2, 0);
					try
					{
						arrayList3.Add(new CategoryGridEntry(base.mobjOwnerPropertyGrid, this, strName, array2));
					}
					catch
					{
					}
				}
			}
			array = new GridEntry[arrayList3.Count];
			arrayList3.CopyTo(array, 0);
			StringSorter.Sort(array);
			base.ChildCollection.Clear();
			base.ChildCollection.AddRange(array);
		}

		protected override bool CreateChildren()
		{
			bool result = base.CreateChildren();
			CategorizePropEntries();
			return result;
		}

		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				host = null;
				baseProvider = null;
				tab = null;
				gridEntryHost = null;
				changeService = null;
			}
			objValue = null;
			objValueClassName = null;
			propDefault = null;
			base.Dispose(blnDisposing);
		}

		public override object GetService(Type objServiceType)
		{
			object obj = null;
			if (host != null)
			{
				obj = host.GetService(objServiceType);
			}
			if (obj == null && baseProvider != null)
			{
				obj = baseProvider.GetService(objServiceType);
			}
			return obj;
		}

		public void ResetBrowsableAttributes()
		{
			browsableAttributes = new System.ComponentModel.AttributeCollection(BrowsableAttribute.Yes);
		}

		public virtual void ShowCategories(bool fCategories)
		{
			if ((base.menmPropertySort &= PropertySort.Categorized) != PropertySort.NoSort != fCategories)
			{
				if (fCategories)
				{
					base.menmPropertySort |= PropertySort.Categorized;
				}
				else
				{
					base.menmPropertySort &= (PropertySort)(-3);
				}
				if (Expandable && base.ChildCollection != null)
				{
					CreateChildren();
				}
			}
		}
	}
}

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
/// 
	/// Base class for property grid entries
	/// </summary>
	[Serializable]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class GridEntry : GridItem, ITypeDescriptorContext, IServiceProvider, IRegisteredComponentMember, IEventHandler, IRenderableComponentMember
	{
		[Serializable]
		private class CacheItems
		{
			public bool mblnLastShouldSerialize;

			public object mobjLastValue;

			public Font mobjLastValueFont;

			public string mstrLastValueString;

			public int mintLastValueTextWidth;

			public bool mblnUseShouldSerialize;

			public bool mblnUseValueString;
		}

		[Serializable]
		public class DisplayNameSortComparer : IComparer
		{
			public int Compare(object objLeft, object objRight)
			{
				return string.Compare(((PropertyDescriptor)objLeft).DisplayName, ((PropertyDescriptor)objRight).DisplayName, ignoreCase: true, CultureInfo.CurrentCulture);
			}
		}

		/// 
		/// The long property registration.
		/// </summary>
		private static readonly SerializableProperty LastModifiedProperty;

		/// 
		/// The long property registration.
		/// </summary>
		private static readonly SerializableProperty mlngLastModifiedParamsProperty;

		/// 
		/// The AttributeType property registration.
		/// </summary>
		private static readonly SerializableProperty menmLastModifiedParamsProperty;

		/// 
		/// The current attribute sorter
		/// </summary>
		internal static AttributeTypeSorter AttributeTypeSorter;

		/// 
		/// The CacheItems property registration.
		/// </summary>
		private static readonly SerializableProperty mobjCacheItemsProperty;

		/// 
		/// The GridEntryCollection property registration.
		/// </summary>
		private static readonly SerializableProperty mobjChildCollectionProperty;

		/// 
		/// The PropertyGrid property registration.
		/// </summary>
		protected static readonly SerializableProperty mobjOwnerPropertyGridProperty;

		/// 
		/// The GridEntry property registration.
		/// </summary>
		private static readonly SerializableProperty mobjParentGridEntryProperty;

		/// 
		/// The System.ComponentModel.TypeConverter property registration.
		/// </summary>
		private static readonly SerializableProperty mobjConverterProperty;

		/// 
		/// The int property registration.
		/// </summary>
		private static readonly SerializableProperty mintPropertyDepthProperty;

		/// 
		/// The Gizmox.WebGUI.Forms.PropertySort property registration.
		/// </summary>
		private static readonly SerializableProperty menmPropertySortProperty;

		/// 
		/// Display Name Comparer
		/// </summary>
		protected static IComparer DisplayNameComparer;

		/// 
		/// The Gizmox.WebGUI.Forms.Design.WebUITypeEditor property registration.
		/// </summary>
		private static readonly SerializableProperty mobjEditorProperty;

		/// 
		/// The int property registration.
		/// </summary>
		private static readonly SerializableProperty StateProperty;

		internal const int mcntFlagsCategories = 2097152;

		internal const int mcntFlagsChecked = int.MinValue;

		internal const int mcntFlagsExpand = 65536;

		internal const int mcntFlagsExpandable = 131072;

		internal const int mcntFlagsExpandableFailed = 524288;

		internal const int mcntFlagsNoCustomPaint = 1048576;

		internal const int mcntFlagsNoCustomEditable = 16;

		internal const int mcntFlagsCustomPaint = 4;

		internal const int mcntFlagsDisposed = 8192;

		internal const int mcntFlagsDropDownEditable = 32;

		internal const int mcntFlagsEnumarable = 2;

		internal const int mcntFlagsForceReadOnly = 1024;

		internal const int mcntFlagsImidiatlyEditable = 8;

		internal const int mcntFlagsImmutable = 512;

		internal const int mcntFlagsLabelBold = 64;

		internal const int mcntFlagsReadOnlyEditable = 128;

		internal const int mcntFlagsRenderPassword = 4096;

		internal const int mcntFlagsRenderReadOnly = 256;

		internal const int mcntFlagsTextEditable = 1;

		protected const int mcntNotifyCanReset = 2;

		protected const int mcctNotifyDoubleClick = 3;

		protected const int mcntNotifyReset = 1;

		protected const int mcntNotifyShouldPresist = 4;

		private const int mcntMaximumLengthOfPropertyString = 1000;

		/// 
		/// The bool property registration.
		/// </summary>
		private static readonly SerializableProperty IsRegisteredProperty;

		/// 
		/// The long property registration.
		/// </summary>
		private static readonly SerializableProperty MemberIDProperty;

		/// 
		/// Indicates last modified time
		/// </summary>
		private long LastModified
		{
			get
			{
				return GetValue(LastModifiedProperty);
			}
			set
			{
				SetValue(LastModifiedProperty, value);
			}
		}

		/// 
		/// Indicates last modified parameters time
		/// </summary>
		private long mlngLastModifiedParams
		{
			get
			{
				return GetValue(mlngLastModifiedParamsProperty);
			}
			set
			{
				SetValue(mlngLastModifiedParamsProperty, value);
			}
		}

		/// 
		/// Indicate modified params types
		/// </summary>
		private AttributeType menmLastModifiedParams
		{
			get
			{
				return GetValue(menmLastModifiedParamsProperty, AttributeType.None);
			}
			set
			{
				SetValue(menmLastModifiedParamsProperty, value);
			}
		}

		/// 
		/// Item cache values
		/// </summary>
		private CacheItems mobjCacheItems
		{
			get
			{
				return GetValue(mobjCacheItemsProperty);
			}
			set
			{
				SetValue(mobjCacheItemsProperty, value);
			}
		}

		/// 
		/// Grid Entry children collection
		/// </summary>
		private GridEntryCollection mobjChildCollection
		{
			get
			{
				return GetValue(mobjChildCollectionProperty);
			}
			set
			{
				SetValue(mobjChildCollectionProperty, value);
			}
		}

		/// 
		/// The owner property grid
		/// </summary>
		protected PropertyGrid mobjOwnerPropertyGrid
		{
			get
			{
				return GetValue(mobjOwnerPropertyGridProperty);
			}
			set
			{
				SetValue(mobjOwnerPropertyGridProperty, value);
			}
		}

		/// 
		/// The parent grid entry
		/// </summary>
		internal GridEntry mobjParentGridEntry
		{
			get
			{
				return GetValue(mobjParentGridEntryProperty);
			}
			set
			{
				SetValue(mobjParentGridEntryProperty, value);
			}
		}

		/// 
		/// The grid entry type convertor to use
		/// </summary>
		protected TypeConverter mobjConverter
		{
			get
			{
				return GetValue(mobjConverterProperty);
			}
			set
			{
				SetValue(mobjConverterProperty, value);
			}
		}

		/// 
		/// The property depth value indicating how deep is it in the property tree
		/// </summary>
		private int mintPropertyDepth
		{
			get
			{
				return GetValue(mintPropertyDepthProperty);
			}
			set
			{
				SetValue(mintPropertyDepthProperty, value);
			}
		}

		/// 
		/// The current sort type
		/// </summary>
		protected PropertySort menmPropertySort
		{
			get
			{
				return GetValue(menmPropertySortProperty);
			}
			set
			{
				SetValue(menmPropertySortProperty, value);
			}
		}

		/// 
		/// The grid entry web editor
		/// </summary>
		protected WebUITypeEditor mobjEditor
		{
			get
			{
				return GetValue(mobjEditorProperty);
			}
			set
			{
				SetValue(mobjEditorProperty, value);
			}
		}

		/// 
		/// The grid entry state
		/// </summary>
		internal int State
		{
			get
			{
				return GetValue(StateProperty);
			}
			set
			{
				SetValue(StateProperty, value);
			}
		}

		/// 
		///
		/// </summary>
		public virtual bool AllowMerge => true;

		/// 
		///
		/// </summary>
		internal virtual bool AlwaysAllowExpand => false;

		/// 
		///
		/// </summary>
		internal virtual System.ComponentModel.AttributeCollection Attributes => TypeDescriptor.GetAttributes(PropertyType);

		/// 
		///
		/// </summary>
		public virtual System.ComponentModel.AttributeCollection BrowsableAttributes
		{
			get
			{
				if (mobjParentGridEntry != null)
				{
					return mobjParentGridEntry.BrowsableAttributes;
				}
				return null;
			}
			set
			{
				mobjParentGridEntry.BrowsableAttributes = value;
			}
		}

		/// 
		///
		/// </summary>
		protected GridEntryCollection ChildCollection
		{
			get
			{
				if (mobjChildCollection == null)
				{
					mobjChildCollection = new GridEntryCollection(this, null);
				}
				return mobjChildCollection;
			}
			set
			{
				if (mobjChildCollection != value)
				{
					if (mobjChildCollection != null)
					{
						mobjChildCollection.Dispose();
						mobjChildCollection = null;
					}
					mobjChildCollection = value;
				}
			}
		}

		/// 
		///
		/// </summary>
		public int ChildCount
		{
			get
			{
				if (Children != null)
				{
					return Children.Count;
				}
				return 0;
			}
		}

		/// 
		///
		/// </summary>
		public virtual GridEntryCollection Children
		{
			get
			{
				if (mobjChildCollection == null && !Disposed)
				{
					CreateChildren();
				}
				return mobjChildCollection;
			}
		}

		/// 
		///
		/// </summary>
		public virtual IComponent Component
		{
			get
			{
				object valueOwner = GetValueOwner();
				if (valueOwner is IComponent)
				{
					return (IComponent)valueOwner;
				}
				if (mobjParentGridEntry != null)
				{
					return mobjParentGridEntry.Component;
				}
				return null;
			}
		}

		/// 
		///
		/// </summary>
		protected virtual IComponentChangeService ComponentChangeService => mobjParentGridEntry.ComponentChangeService;

		/// 
		///
		/// </summary>
		public virtual IContainer Container
		{
			get
			{
				IComponent component = Component;
				if (component != null)
				{
					ISite site = component.Site;
					if (site != null)
					{
						return site.Container;
					}
				}
				return null;
			}
		}

		/// 
		///
		/// </summary>
		public virtual PropertyTab CurrentTab
		{
			get
			{
				if (mobjParentGridEntry != null)
				{
					return mobjParentGridEntry.CurrentTab;
				}
				return null;
			}
			set
			{
				if (mobjParentGridEntry != null)
				{
					mobjParentGridEntry.CurrentTab = value;
				}
			}
		}

		/// 
		///
		/// </summary>
		internal virtual GridEntry DefaultChild
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		///
		/// </summary>
		internal virtual IDesignerHost DesignerHost
		{
			get
			{
				if (mobjParentGridEntry != null)
				{
					return mobjParentGridEntry.DesignerHost;
				}
				return null;
			}
			set
			{
				if (mobjParentGridEntry != null)
				{
					mobjParentGridEntry.DesignerHost = value;
				}
			}
		}

		/// 
		///
		/// </summary>
		internal bool Disposed => GetStateSet(8192);

		/// 
		///
		/// </summary>
		internal virtual bool Enumerable => (Flags & 2) != 0;

		/// 
		///
		/// </summary>
		public override bool Expandable
		{
			get
			{
				bool flag = GetStateSet(131072);
				if (flag && mobjChildCollection != null && mobjChildCollection.Count > 0)
				{
					return true;
				}
				if (GetStateSet(524288))
				{
					return false;
				}
				if (flag && (mobjCacheItems == null || mobjCacheItems.mobjLastValue == null) && PropertyValue == null)
				{
					flag = false;
				}
				return flag;
			}
		}

		/// 
		///
		/// </summary>
		public override bool Expanded
		{
			get
			{
				return InternalExpanded;
			}
			set
			{
			}
		}

		/// 
		///
		/// </summary>
		internal virtual int Flags
		{
			get
			{
				if ((State & int.MinValue) == 0)
				{
					State |= int.MinValue;
					TypeConverter typeConverter = TypeConverter;
					WebUITypeEditor uITypeEditor = UITypeEditor;
					object instance = Instance;
					bool flag = ForceReadOnly;
					bool flag2 = uITypeEditor?.IsTextEditable ?? true;
					if (instance != null)
					{
						flag |= TypeDescriptor.GetAttributes(instance).Contains(InheritanceAttribute.InheritedReadOnly);
					}
					if (typeConverter.GetStandardValuesSupported(this))
					{
						State |= 2;
					}
					if (!flag && flag2 && typeConverter.CanConvertFrom(this, typeof(string)) && !typeConverter.GetStandardValuesExclusive(this))
					{
						State |= 1;
					}
					bool flag3 = TypeDescriptor.GetAttributes(PropertyType)[typeof(ImmutableObjectAttribute)].Equals(ImmutableObjectAttribute.Yes);
					bool flag4 = flag3 || typeConverter.GetCreateInstanceSupported(this);
					if (flag4)
					{
						State |= 512;
					}
					if (typeConverter.GetPropertiesSupported(this))
					{
						State |= 131072;
						if (!flag && (State & 1) == 0 && !flag3)
						{
							State |= 128;
						}
					}
					if (Attributes.Contains(PasswordPropertyTextAttribute.Yes))
					{
						State |= 4096;
					}
					if (uITypeEditor != null && !flag)
					{
						switch (uITypeEditor.GetEditStyle(this))
						{
						case UITypeEditorEditStyle.Modal:
							State |= 16;
							if (!flag4 && !PropertyType.IsValueType)
							{
								State |= 128;
							}
							break;
						case UITypeEditorEditStyle.DropDown:
							State |= 32;
							break;
						}
					}
				}
				return State;
			}
			set
			{
				State = value;
			}
		}

		internal virtual bool ForceReadOnly => (State & 0x400) != 0;

		public string FullLabel
		{
			get
			{
				string text = null;
				if (mobjParentGridEntry != null)
				{
					text = mobjParentGridEntry.FullLabel;
				}
				text = ((text == null) ? "" : (text + "."));
				return text + PropertyLabel;
			}
		}

		internal virtual PropertyGridView GridEntryHost
		{
			get
			{
				if (mobjParentGridEntry != null)
				{
					return mobjParentGridEntry.GridEntryHost;
				}
				return null;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override GridItemCollection GridItems
		{
			get
			{
				if (Disposed)
				{
					throw new ObjectDisposedException(SR.GetString("GridItemDisposed"));
				}
				if (IsExpandable && mobjChildCollection != null && mobjChildCollection.Count == 0)
				{
					CreateChildren();
				}
				return Children;
			}
		}

		public override GridItemType GridItemType => GridItemType.Property;

		internal virtual bool HasValue => true;

		public virtual string HelpKeyword
		{
			get
			{
				string text = null;
				if (mobjParentGridEntry != null)
				{
					text = mobjParentGridEntry.HelpKeyword;
				}
				if (text == null)
				{
					text = string.Empty;
				}
				return text;
			}
		}

		internal virtual string HelpKeywordInternal => HelpKeyword;

		public virtual object Instance
		{
			get
			{
				object valueOwner = GetValueOwner();
				if (mobjParentGridEntry != null && valueOwner == null)
				{
					return mobjParentGridEntry.Instance;
				}
				return valueOwner;
			}
		}

		internal virtual bool InternalExpanded
		{
			get
			{
				if (mobjChildCollection != null && mobjChildCollection.Count != 0)
				{
					return GetStateSet(65536);
				}
				return false;
			}
			set
			{
				if (!Expandable || value == InternalExpanded)
				{
					return;
				}
				if (mobjChildCollection != null && mobjChildCollection.Count > 0)
				{
					SetState(65536, value);
					return;
				}
				SetState(65536, blnValue: false);
				if (value)
				{
					bool blnValue = CreateChildren();
					SetState(65536, blnValue);
				}
			}
		}

		public virtual bool IsExpandable
		{
			get
			{
				return Expandable;
			}
			set
			{
				if (value != GetStateSet(131072))
				{
					SetState(524288, blnValue: false);
					SetState(131072, value);
				}
			}
		}

		public virtual bool IsTextEditable
		{
			get
			{
				if (IsValueEditable)
				{
					return (Flags & 1) != 0;
				}
				return false;
			}
		}

		public virtual bool IsValueEditable
		{
			get
			{
				if (!ForceReadOnly)
				{
					return (Flags & 0x33) != 0;
				}
				return false;
			}
		}

		public override string Label => PropertyLabel;

		public virtual bool NeedsCustomEditorButton
		{
			get
			{
				if ((Flags & 0x10) == 0)
				{
					return false;
				}
				if (!IsValueEditable)
				{
					return (Flags & 0x80) != 0;
				}
				return true;
			}
		}

		public virtual bool NeedsDropDownButton => (Flags & 0x20) != 0;

		[Browsable(false)]
		public override PropertyGrid OwnerGrid => mobjOwnerPropertyGrid;

		public PropertyGridView OwnerGridView
		{
			get
			{
				if (mobjOwnerPropertyGrid != null)
				{
					return mobjOwnerPropertyGrid.PropertyGridView;
				}
				return null;
			}
		}

		public override GridItem Parent
		{
			get
			{
				if (Disposed)
				{
					throw new ObjectDisposedException(SR.GetString("GridItemDisposed"));
				}
				return ParentGridEntry;
			}
		}

		public virtual GridEntry ParentGridEntry
		{
			get
			{
				return mobjParentGridEntry;
			}
			set
			{
				mobjParentGridEntry = value;
				if (value == null)
				{
					return;
				}
				mintPropertyDepth = value.PropertyDepth + 1;
				if (mobjChildCollection != null)
				{
					for (int i = 0; i < mobjChildCollection.Count; i++)
					{
						mobjChildCollection.GetEntry(i).ParentGridEntry = this;
					}
				}
			}
		}

		public virtual string PropertyCategory => CategoryAttribute.Default.Category;

		public virtual int PropertyDepth => mintPropertyDepth;

		public virtual string PropertyDescription => null;

		public override PropertyDescriptor PropertyDescriptor => null;

		public virtual string PropertyLabel => null;

		public virtual string PropertyName => PropertyLabel;

		public virtual Type PropertyType => PropertyValue?.GetType();

		public virtual object PropertyValue
		{
			get
			{
				if (mobjCacheItems != null)
				{
					return mobjCacheItems.mobjLastValue;
				}
				return null;
			}
			set
			{
			}
		}

		public virtual bool ShouldRenderPassword => (Flags & 0x1000) != 0;

		public virtual bool ShouldRenderReadOnly
		{
			get
			{
				if (ForceReadOnly)
				{
					return true;
				}
				if ((Flags & 0x100) != 0)
				{
					return true;
				}
				if (!IsValueEditable)
				{
					return (Flags & 0x80) == 0;
				}
				return false;
			}
		}

		internal virtual TypeConverter TypeConverter
		{
			get
			{
				if (mobjConverter == null)
				{
					object propertyValue = PropertyValue;
					if (propertyValue == null)
					{
						mobjConverter = TypeDescriptor.GetConverter(PropertyType);
					}
					else
					{
						mobjConverter = TypeDescriptor.GetConverter(propertyValue);
					}
				}
				return mobjConverter;
			}
		}

		internal virtual WebUITypeEditor UITypeEditor
		{
			get
			{
				if (mobjEditor == null && PropertyType != null)
				{
					mobjEditor = WebUITypeEditor.GetEditor(PropertyType);
				}
				if (mobjEditor == null && TypeConverter != null && TypeConverter.GetStandardValuesExclusive(this))
				{
					mobjEditor = new StandardValuesEditor(TypeConverter);
				}
				return mobjEditor;
			}
		}

		public override object Value => PropertyValue;

		internal int VisibleChildCount
		{
			get
			{
				if (!Expanded)
				{
					return 0;
				}
				int childCount = ChildCount;
				int num = childCount;
				for (int i = 0; i < childCount; i++)
				{
					num += ChildCollection.GetEntry(i).VisibleChildCount;
				}
				return num;
			}
		}

		private bool IsRegistered
		{
			get
			{
				return GetValue(IsRegisteredProperty, objDefault: false);
			}
			set
			{
				SetValue(IsRegisteredProperty, value);
			}
		}

		bool IRegisteredComponentMember.IsRegistered
		{
			get
			{
				return IsRegistered;
			}
			set
			{
				IsRegistered = value;
			}
		}

		private long MemberID
		{
			get
			{
				return GetValue(MemberIDProperty, 0L);
			}
			set
			{
				SetValue(MemberIDProperty, value);
			}
		}

		long IRegisteredComponentMember.MemberID
		{
			get
			{
				return MemberID;
			}
			set
			{
				MemberID = value;
			}
		}

		long IRegisteredComponentMember.OwnerID => ((IRegisteredComponent)OwnerGridView).ID;

		/// 
		/// Gets the initial size of the serializable filed storage.
		/// </summary>
		/// The initial size of the serializable filed storage.</value>
		protected override int SerializableFieldStorageInitialSize { get
			{
				return 20;
			}
		}

		/// 
		///
		/// </summary>
		static GridEntry()
		{
			LastModifiedProperty = SerializableProperty.Register("LastModified", typeof(long), typeof(GridEntry));
			mlngLastModifiedParamsProperty = SerializableProperty.Register("mlngLastModifiedParams", typeof(long), typeof(GridEntry));
			menmLastModifiedParamsProperty = SerializableProperty.Register("menmLastModifiedParams", typeof(AttributeType), typeof(GridEntry));
			mobjCacheItemsProperty = SerializableProperty.Register("mobjCacheItems", typeof(CacheItems), typeof(GridEntry));
			mobjChildCollectionProperty = SerializableProperty.Register("mobjChildCollection", typeof(GridEntryCollection), typeof(GridEntry));
			mobjOwnerPropertyGridProperty = SerializableProperty.Register("mobjOwnerPropertyGrid", typeof(PropertyGrid), typeof(GridEntry));
			mobjParentGridEntryProperty = SerializableProperty.Register("mobjParentGridEntry", typeof(GridEntry), typeof(GridEntry));
			mobjConverterProperty = SerializableProperty.Register("mobjConverter", typeof(TypeConverter), typeof(GridEntry));
			mintPropertyDepthProperty = SerializableProperty.Register("mintPropertyDepth", typeof(int), typeof(GridEntry));
			menmPropertySortProperty = SerializableProperty.Register("menmPropertySort", typeof(PropertySort), typeof(GridEntry));
			mobjEditorProperty = SerializableProperty.Register("mobjEditor", typeof(WebUITypeEditor), typeof(GridEntry));
			StateProperty = SerializableProperty.Register("State", typeof(int), typeof(GridEntry));
			IsRegisteredProperty = SerializableProperty.Register("IsRegistered", typeof(bool), typeof(GridEntry));
			MemberIDProperty = SerializableProperty.Register("MemberID", typeof(long), typeof(GridEntry));
			AttributeTypeSorter = new AttributeTypeSorter();
			DisplayNameComparer = new DisplayNameSortComparer();
		}

		/// 
		///
		/// </summary>
		/// <param name="objPropertyGrid"></param>
		/// <param name="objParentGridEntry"></param>
		protected GridEntry(PropertyGrid objPropertyGrid, GridEntry objParentGridEntry)
		{
			mlngLastModifiedParams = (LastModified = GetCurrentTicks(blnIsForceRender: true));
			mobjParentGridEntry = objParentGridEntry;
			mobjOwnerPropertyGrid = objPropertyGrid;
			if (objParentGridEntry != null)
			{
				mintPropertyDepth = objParentGridEntry.PropertyDepth + 1;
				menmPropertySort = objParentGridEntry.menmPropertySort;
				if (objParentGridEntry.ForceReadOnly)
				{
					State |= 1024;
				}
			}
			else
			{
				mintPropertyDepth = -1;
			}
		}

		~GridEntry()
		{
			Dispose(blnDisposing: false);
		}

		/// 
		/// Checks if value can be reset
		/// </summary>
		/// </returns>
		public virtual bool CanResetPropertyValue()
		{
			return NotifyValue(2);
		}

		/// 
		/// Clear the cached values
		/// </summary>
		internal void ClearCachedValues()
		{
			ClearCachedValues(blnClearChildren: true);
		}

		/// 
		/// Clear cached values
		/// </summary>
		/// <param name="blnClearChildren"></param>
		internal void ClearCachedValues(bool blnClearChildren)
		{
			if (mobjCacheItems != null)
			{
				mobjCacheItems.mblnUseValueString = false;
				mobjCacheItems.mobjLastValue = null;
				mobjCacheItems.mblnUseShouldSerialize = false;
			}
			if (blnClearChildren)
			{
				for (int i = 0; i < ChildCollection.Count; i++)
				{
					ChildCollection.GetEntry(i).ClearCachedValues();
				}
			}
		}

		/// 
		/// Convert the current text value to object using the type convertor
		/// </summary>
		/// <param name="strText"></param>
		/// </returns>
		public object ConvertTextToValue(string strText)
		{
			if (TypeConverter.CanConvertFrom(this, typeof(string)))
			{
				return TypeConverter.ConvertFromString(this, strText);
			}
			return strText;
		}

		/// 
		/// Create the root property grid
		/// </summary>
		/// <param name="objPropertyGridView"></param>
		/// <param name="arrObjects"></param>
		/// <param name="objServiceProvider"></param>
		/// <param name="objCurrentHost"></param>
		/// <param name="objPropertyTab"></param>
		/// <param name="objInitialSortType"></param>
		/// </returns>
		internal static IRootGridEntry Create(PropertyGridView objPropertyGridView, object[] arrObjects, IServiceProvider objServiceProvider, IDesignerHost objCurrentHost, PropertyTab objPropertyTab, PropertySort objInitialSortType)
		{
			IRootGridEntry rootGridEntry = null;
			if (arrObjects == null || arrObjects.Length == 0)
			{
				return null;
			}
			try
			{
				if (arrObjects.Length == 1)
				{
					return new SingleSelectRootGridEntry(objPropertyGridView, arrObjects[0], objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType);
				}
				rootGridEntry = new MultiSelectRootGridEntry(objPropertyGridView, arrObjects, objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType);
			}
			catch (Exception)
			{
				throw;
			}
			return rootGridEntry;
		}

		/// 
		/// Creates the grid entry children
		/// </summary>
		/// </returns>
		protected virtual bool CreateChildren()
		{
			return CreateChildren(blnDiffOldChildren: false);
		}

		/// 
		/// Creates the grid entry children
		/// </summary>
		/// <param name="blnDiffOldChildren"></param>
		/// </returns>
		protected virtual bool CreateChildren(bool blnDiffOldChildren)
		{
			if (!GetStateSet(131072))
			{
				if (mobjChildCollection != null)
				{
					mobjChildCollection.Clear();
				}
				else
				{
					mobjChildCollection = new GridEntryCollection(this, new GridEntry[0]);
				}
				return false;
			}
			if (!blnDiffOldChildren && mobjChildCollection != null && mobjChildCollection.Count > 0)
			{
				return true;
			}
			GridEntry[] propEntries = GetPropEntries(this, PropertyValue, PropertyType);
			bool flag = propEntries != null && propEntries.Length != 0;
			if (blnDiffOldChildren && mobjChildCollection != null && mobjChildCollection.Count > 0)
			{
				bool flag2 = true;
				if (propEntries.Length == mobjChildCollection.Count)
				{
					for (int i = 0; i < propEntries.Length; i++)
					{
						if (!propEntries[i].NonParentEquals(mobjChildCollection[i]))
						{
							flag2 = false;
							break;
						}
					}
				}
				else
				{
					flag2 = false;
				}
				if (flag2)
				{
					return true;
				}
			}
			if (!flag)
			{
				SetState(524288, blnValue: true);
				if (mobjChildCollection != null)
				{
					mobjChildCollection.Clear();
				}
				else
				{
					mobjChildCollection = new GridEntryCollection(this, new GridEntry[0]);
				}
				if (InternalExpanded)
				{
					InternalExpanded = false;
				}
				return flag;
			}
			if (mobjChildCollection != null)
			{
				mobjChildCollection.Clear();
				mobjChildCollection.AddRange(propEntries);
				return flag;
			}
			mobjChildCollection = new GridEntryCollection(this, propEntries);
			return flag;
		}

		/// 
		///
		/// </summary>
		public void Dispose()
		{
			Dispose(blnDisposing: true);
			GC.SuppressFinalize(this);
		}

		/// 
		/// /
		/// </summary>
		/// <param name="blnDisposing"></param>
		protected virtual void Dispose(bool blnDisposing)
		{
			State |= int.MinValue;
			SetState(8192, blnValue: true);
			mobjCacheItems = null;
			mobjConverter = null;
			mobjEditor = null;
			if (blnDisposing)
			{
				DisposeChildren();
			}
		}

		/// 
		/// Dispose recursivly
		/// </summary>
		public virtual void DisposeChildren()
		{
			if (mobjChildCollection != null)
			{
				mobjChildCollection.Dispose();
				mobjChildCollection = null;
			}
		}

		/// 
		/// Edit the current property value through its Web UI Editor
		/// </summary>
		internal virtual void EditPropertyValue()
		{
			if (UITypeEditor == null)
			{
				return;
			}
			try
			{
				object propertyValue = PropertyValue;
				ShowingTypeEditorEventArgs e = new ShowingTypeEditorEventArgs(this);
				mobjOwnerPropertyGrid.OnShowingEditTypeEditor(e);
				if (!e.IsCancelled)
				{
					UITypeEditor.EditValue(this, this, propertyValue, EditPropertyValue_Callback);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, SR.GetString("PBRSErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
			}
		}

		/// 
		/// Handle property editing callback response 
		/// </summary>
		/// <param name="objValue"></param>
		protected virtual void EditPropertyValue_Callback(object objValue)
		{
			try
			{
				if (Disposed)
				{
					return;
				}
				object propertyValue = PropertyValue;
				if (objValue != propertyValue && IsValueEditable)
				{
					if (OwnerGridView != null)
					{
						OwnerGridView.CommitValue(this, objValue);
					}
					EnsureGridEntryChildren();
				}
				RecreateChildren();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, SR.GetString("PBRSErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
			}
		}

		/// 
		/// Checks if a grid entry is equal to this one
		/// </summary>
		/// <param name="objObject"></param>
		/// </returns>
		public override bool Equals(object objObject)
		{
			if (NonParentEquals(objObject))
			{
				return ((GridEntry)objObject).ParentGridEntry == ParentGridEntry;
			}
			return false;
		}

		/// 
		/// Search for property value
		/// </summary>
		/// <param name="strPropertyName"></param>
		/// <param name="objPropertyType"></param>
		/// </returns>
		public virtual object FindPropertyValue(string strPropertyName, Type objPropertyType)
		{
			object valueOwner = GetValueOwner();
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(valueOwner)[strPropertyName];
			if (propertyDescriptor != null && propertyDescriptor.PropertyType == objPropertyType)
			{
				return propertyDescriptor.GetValue(valueOwner);
			}
			if (mobjParentGridEntry != null)
			{
				return mobjParentGridEntry.FindPropertyValue(strPropertyName, objPropertyType);
			}
			return null;
		}

		/// 
		/// Get index from a given child grid entry
		/// </summary>
		/// <param name="objGridEntry"></param>
		/// </returns>
		internal virtual int GetChildIndex(GridEntry objGridEntry)
		{
			return Children.GetEntry(objGridEntry);
		}

		/// 
		/// Get the value for child grid entrys
		/// </summary>
		/// <param name="objChildEntry"></param>
		/// </returns>
		public virtual object GetChildValueOwner(GridEntry objChildEntry)
		{
			return PropertyValue;
		}

		public virtual IComponent[] GetComponents()
		{
			IComponent component = Component;
			if (component != null)
			{
				return new IComponent[1] { component };
			}
			return null;
		}

		/// 
		/// Gets a specifiec state
		/// </summary>
		/// <param name="intFlag"></param>
		/// </returns>
		protected virtual bool GetStateSet(int intFlag)
		{
			return (intFlag & Flags) != 0;
		}

		/// 
		/// Gets the current grid entry hash code
		/// </summary>
		/// </returns>
		public override int GetHashCode()
		{
			object propertyLabel = PropertyLabel;
			object propertyType = PropertyType;
			uint num = (uint)(propertyLabel?.GetHashCode() ?? 0);
			uint num2 = (uint)(propertyType?.GetHashCode() ?? 0);
			uint hashCode = (uint)GetType().GetHashCode();
			return (int)(num ^ ((num2 << 13) | (num2 >> 19)) ^ ((hashCode << 26) | (hashCode >> 6)));
		}

		/// 
		/// Gets a flag indicating
		/// </summary>
		/// <param name="strValueString"></param>
		/// </returns>
		internal bool GetMultipleLines(string strValueString)
		{
			if (strValueString.IndexOf('\n') <= 0 && strValueString.IndexOf('\r') <= 0)
			{
				return false;
			}
			return true;
		}

		/// 
		/// Gets the child grid entries
		/// </summary>
		/// <param name="objParentGridEntry"></param>
		/// <param name="objObject"></param>
		/// <param name="objType"></param>
		/// </returns>
		protected virtual GridEntry[] GetPropEntries(GridEntry objParentGridEntry, object objObject, Type objType)
		{
			if (objObject == null)
			{
				return null;
			}
			GridEntry[] array = null;
			Attribute[] array2 = new Attribute[BrowsableAttributes.Count];
			BrowsableAttributes.CopyTo(array2, 0);
			PropertyTab currentTab = CurrentTab;
			try
			{
				bool flag = ForceReadOnly;
				if (!flag)
				{
					ReadOnlyAttribute readOnlyAttribute = (ReadOnlyAttribute)TypeDescriptor.GetAttributes(objObject)[typeof(ReadOnlyAttribute)];
					flag = readOnlyAttribute != null && !readOnlyAttribute.IsDefaultAttribute();
				}
				if (TypeConverter.GetPropertiesSupported(this) || AlwaysAllowExpand)
				{
					PropertyDescriptorCollection propertyDescriptorCollection = null;
					PropertyDescriptor propertyDescriptor = null;
					if (currentTab != null)
					{
						propertyDescriptorCollection = currentTab.GetProperties(this, objObject, array2);
						propertyDescriptor = currentTab.GetDefaultProperty(objObject);
					}
					else
					{
						propertyDescriptorCollection = TypeConverter.GetProperties(this, objObject, array2);
						propertyDescriptor = TypeDescriptor.GetDefaultProperty(objObject);
					}
					if (propertyDescriptorCollection == null)
					{
						return null;
					}
					if ((menmPropertySort & PropertySort.Alphabetical) != PropertySort.NoSort)
					{
						if (objType == null || !objType.IsArray)
						{
							propertyDescriptorCollection = propertyDescriptorCollection.Sort(DisplayNameComparer);
						}
						PropertyDescriptor[] array3 = new PropertyDescriptor[propertyDescriptorCollection.Count];
						propertyDescriptorCollection.CopyTo(array3, 0);
						propertyDescriptorCollection = new PropertyDescriptorCollection(SortParenProperties(array3));
					}
					if (propertyDescriptor == null && propertyDescriptorCollection.Count > 0)
					{
						propertyDescriptor = propertyDescriptorCollection[0];
					}
					if ((propertyDescriptorCollection == null || propertyDescriptorCollection.Count == 0) && objType != null && objType.IsArray && objObject != null)
					{
						Array array4 = (Array)objObject;
						array = new GridEntry[array4.Length];
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = new ArrayElementGridEntry(mobjOwnerPropertyGrid, objParentGridEntry, i);
						}
						return array;
					}
					bool createInstanceSupported = TypeConverter.GetCreateInstanceSupported(this);
					array = new GridEntry[propertyDescriptorCollection.Count];
					int num = 0;
					foreach (PropertyDescriptor item in propertyDescriptorCollection)
					{
						bool blnHide = false;
						try
						{
							object component = objObject;
							if (objObject is ICustomTypeDescriptor)
							{
								component = ((ICustomTypeDescriptor)objObject).GetPropertyOwner(item);
							}
							item.GetValue(component);
						}
						catch (Exception)
						{
							blnHide = true;
						}
						GridEntry gridEntry;
						if (createInstanceSupported)
						{
							gridEntry = new ImmutablePropertyDescriptorGridEntry(mobjOwnerPropertyGrid, objParentGridEntry, item, blnHide);
						}
						else
						{
							gridEntry = new PropertyDescriptorGridEntry(mobjOwnerPropertyGrid, objParentGridEntry, item, blnHide);
							if (gridEntry.IsExpandable)
							{
								gridEntry.CreateChildren();
							}
						}
						if (flag)
						{
							gridEntry.State |= 1024;
						}
						if (item.Equals(propertyDescriptor))
						{
							DefaultChild = gridEntry;
						}
						array[num++] = gridEntry;
					}
				}
				return array;
			}
			catch (Exception)
			{
			}
			return array;
		}

		/// 
		/// Get the property text value
		/// </summary>
		/// </returns>
		public virtual string GetPropertyTextValue()
		{
			return GetPropertyTextValue(PropertyValue);
		}

		/// 
		/// Get the text value of a specific object value
		/// </summary>
		/// <param name="objValue"></param>
		/// </returns>
		public virtual string GetPropertyTextValue(object objValue)
		{
			if (CommonUtils.IsMono)
			{
				char c = '\0';
				if (objValue is char && (char)objValue == c)
				{
					return string.Empty;
				}
			}
			string text = null;
			TypeConverter typeConverter = TypeConverter;
			try
			{
				text = typeConverter.ConvertToString(this, objValue);
			}
			catch (Exception)
			{
			}
			if (text == null)
			{
				text = string.Empty;
			}
			return text;
		}

		/// 
		/// Get value list
		/// </summary>
		/// </returns>
		public virtual object[] GetPropertyValueList()
		{
			ICollection standardValues = TypeConverter.GetStandardValues(this);
			if (standardValues != null)
			{
				object[] array = new object[standardValues.Count];
				standardValues.CopyTo(array, 0);
				return array;
			}
			return new object[0];
		}

		/// 
		/// Get a specific service (service propvider implentation)
		/// </summary>
		/// <param name="objServiceType"></param>
		/// </returns>
		public virtual object GetService(Type objServiceType)
		{
			if (objServiceType == typeof(GridItem))
			{
				return this;
			}
			if (mobjParentGridEntry != null)
			{
				return mobjParentGridEntry.GetService(objServiceType);
			}
			return null;
		}

		/// 
		/// Return information used for testing
		/// </summary>
		/// </returns>
		public virtual string GetTestingInfo()
		{
			string text = "object = (";
			string propertyTextValue = GetPropertyTextValue();
			propertyTextValue = ((propertyTextValue != null) ? propertyTextValue.Replace('\0', ' ') : "(null)");
			Type type = PropertyType;
			if (type == null)
			{
				type = typeof(object);
			}
			text += FullLabel;
			object obj = text;
			return string.Concat(obj, "), property = (", PropertyLabel, ",", type.AssemblyQualifiedName, "), value = [", propertyTextValue, "], expandable = ", Expandable.ToString(), ", readOnly = ", ShouldRenderReadOnly);
		}

		/// 
		/// Get the value of the parent grid entry
		/// </summary>
		/// </returns>
		public virtual object GetValueOwner()
		{
			if (mobjParentGridEntry == null)
			{
				return PropertyValue;
			}
			return mobjParentGridEntry.GetChildValueOwner(this);
		}

		/// 
		/// Get the value of a merged value
		/// </summary>
		/// </returns>
		public virtual object[] GetValueOwners()
		{
			object valueOwner = GetValueOwner();
			if (valueOwner != null)
			{
				return new object[1] { valueOwner };
			}
			return null;
		}

		/// 
		/// Get current value type
		/// </summary>
		/// </returns>
		public virtual Type GetValueType()
		{
			return PropertyType;
		}

		/// 
		///
		/// </summary>
		/// <param name="objObject"></param>
		/// </returns>
		internal virtual bool NonParentEquals(object objObject)
		{
			if (objObject == this)
			{
				return true;
			}
			if (objObject != null)
			{
				if (!(objObject is GridEntry))
				{
					return false;
				}
				GridEntry gridEntry = (GridEntry)objObject;
				if (gridEntry.PropertyLabel.Equals(PropertyLabel) && gridEntry.PropertyType.Equals(PropertyType))
				{
					return gridEntry.PropertyDepth == PropertyDepth;
				}
			}
			return false;
		}

		/// 
		/// Notifies child value change
		/// </summary>
		/// <param name="objGridEntry"></param>
		/// <param name="intType"></param>
		/// </returns>
		internal virtual bool NotifyChildValue(GridEntry objGridEntry, int intType)
		{
			return objGridEntry.NotifyValueGivenParent(objGridEntry.GetValueOwner(), intType);
		}

		/// 
		///
		/// </summary>
		/// <param name="intType"></param>
		/// </returns>
		internal virtual bool NotifyValue(int intType)
		{
			if (mobjParentGridEntry == null)
			{
				return true;
			}
			return mobjParentGridEntry.NotifyChildValue(this, intType);
		}

		/// 
		///
		/// </summary>
		/// <param name="objObject"></param>
		/// <param name="intType"></param>
		/// </returns>
		internal virtual bool NotifyValueGivenParent(object objObject, int intType)
		{
			return false;
		}

		/// 
		///
		/// </summary>
		public virtual void OnComponentChanged()
		{
			if (ComponentChangeService != null)
			{
				ComponentChangeService.OnComponentChanged(GetValueOwner(), PropertyDescriptor, null, null);
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		public virtual bool OnComponentChanging()
		{
			if (ComponentChangeService != null)
			{
				try
				{
					ComponentChangeService.OnComponentChanging(GetValueOwner(), PropertyDescriptor);
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
			return true;
		}

		/// 
		///
		/// </summary>
		internal void RecreateChildren()
		{
			RecreateChildren(-1);
		}

		/// 
		///
		/// </summary>
		/// <param name="intOldCount"></param>
		internal void RecreateChildren(int intOldCount)
		{
			bool internalExpanded = InternalExpanded || intOldCount > 0;
			if (intOldCount == -1)
			{
				intOldCount = VisibleChildCount;
			}
			ResetState();
			if (intOldCount == 0)
			{
				return;
			}
			foreach (GridEntry item in ChildCollection)
			{
				item.RecreateChildren();
			}
			DisposeChildren();
			InternalExpanded = internalExpanded;
		}

		/// 
		///
		/// </summary>
		public virtual void Refresh()
		{
			Type propertyType = PropertyType;
			if (propertyType != null && propertyType.IsArray)
			{
				CreateChildren(blnDiffOldChildren: true);
			}
			if (mobjChildCollection != null)
			{
				if (InternalExpanded && mobjCacheItems != null && mobjCacheItems.mobjLastValue != null && mobjCacheItems.mobjLastValue != PropertyValue)
				{
					ClearCachedValues();
					RecreateChildren();
					return;
				}
				if (InternalExpanded)
				{
					foreach (object item in mobjChildCollection)
					{
						((GridEntry)item).Refresh();
					}
				}
				else
				{
					DisposeChildren();
				}
			}
			ClearCachedValues();
		}

		/// 
		///
		/// </summary>
		public virtual void ResetPropertyValue()
		{
			NotifyValue(1);
			Refresh();
		}

		/// 
		///
		/// </summary>
		protected void ResetState()
		{
			Flags = 0;
			ClearCachedValues();
		}

		/// 
		///
		/// </summary>
		/// </returns>
		public override bool Select()
		{
			if (!Disposed)
			{
				try
				{
					GridEntryHost.SelectedGridEntry = this;
					return true;
				}
				catch
				{
				}
			}
			return false;
		}

		/// 
		///
		/// </summary>
		/// <param name="intFlag"></param>
		/// <param name="blnValue"></param>
		protected virtual void SetState(int intFlag, bool blnValue)
		{
			SetFlag(intFlag, blnValue ? intFlag : 0);
		}

		/// 
		///
		/// </summary>
		/// <param name="intFlag"></param>
		/// <param name="intValue"></param>
		protected virtual void SetFlag(int intFlag, int intValue)
		{
			Flags = (Flags & ~intFlag) | intValue;
		}

		/// 
		///
		/// </summary>
		/// <param name="intValidFlag"></param>
		/// <param name="intFlag"></param>
		/// <param name="blnValue"></param>
		protected virtual void SetFlag(int intValidFlag, int intFlag, bool blnValue)
		{
			SetFlag(intValidFlag | intFlag, intValidFlag | (blnValue ? intFlag : 0));
		}

		/// 
		///
		/// </summary>
		/// <param name="strValue"></param>
		/// </returns>
		public virtual bool SetPropertyTextValue(string strValue)
		{
			return SetPropertyTextValue(strValue, blnRequireUpdate: true);
		}

		/// 
		///
		/// </summary>
		/// <param name="strValue"></param>
		/// <param name="blnRequireUpdate"></param>
		/// </returns>
		internal virtual bool SetPropertyTextValue(string strValue, bool blnRequireUpdate)
		{
			bool flag = mobjChildCollection != null && mobjChildCollection.Count > 0;
			SetPropertyValue(ConvertTextToValue(strValue), blnRequireUpdate);
			CreateChildren();
			bool flag2 = mobjChildCollection != null && mobjChildCollection.Count > 0;
			return flag != flag2;
		}

		/// 
		///
		/// </summary>
		/// </returns>
		internal virtual bool ShouldSerializePropertyValue()
		{
			if (mobjCacheItems != null)
			{
				if (mobjCacheItems.mblnUseShouldSerialize)
				{
					return mobjCacheItems.mblnLastShouldSerialize;
				}
				mobjCacheItems.mblnLastShouldSerialize = NotifyValue(4);
				mobjCacheItems.mblnUseShouldSerialize = true;
			}
			else
			{
				mobjCacheItems = new CacheItems();
				mobjCacheItems.mblnLastShouldSerialize = NotifyValue(4);
				mobjCacheItems.mblnUseShouldSerialize = true;
			}
			return mobjCacheItems.mblnLastShouldSerialize;
		}

		/// 
		///
		/// </summary>
		/// <param name="arrPropertyDescriptors"></param>
		/// </returns>
		private PropertyDescriptor[] SortParenProperties(PropertyDescriptor[] arrPropertyDescriptors)
		{
			PropertyDescriptor[] array = null;
			int num = 0;
			for (int i = 0; i < arrPropertyDescriptors.Length; i++)
			{
				if (((ParenthesizePropertyNameAttribute)arrPropertyDescriptors[i].Attributes[typeof(ParenthesizePropertyNameAttribute)]).NeedParenthesis)
				{
					if (array == null)
					{
						array = new PropertyDescriptor[arrPropertyDescriptors.Length];
					}
					array[num++] = arrPropertyDescriptors[i];
					arrPropertyDescriptors[i] = null;
				}
			}
			if (num > 0)
			{
				for (int j = 0; j < arrPropertyDescriptors.Length; j++)
				{
					if (arrPropertyDescriptors[j] != null)
					{
						array[num++] = arrPropertyDescriptors[j];
					}
				}
				arrPropertyDescriptors = array;
			}
			return arrPropertyDescriptors;
		}

		/// 
		///
		/// </summary>
		/// </returns>
		public override string ToString()
		{
			return GetType().FullName + " " + PropertyLabel;
		}

		internal bool SetPropertyValue(object objValue, bool blnRequireUpdate)
		{
			if (PropertyValue != objValue)
			{
				PropertyValue = objValue;
				if (ParentGridEntry != null && ParentGridEntry.GridItemType == GridItemType.Property)
				{
					ParentGridEntry.UpdateParams();
				}
				if (blnRequireUpdate)
				{
					Update();
				}
				return true;
			}
			return false;
		}

		private void RegisterSelf()
		{
			if (!IsRegistered && mobjOwnerPropertyGrid != null)
			{
				mobjOwnerPropertyGrid.RegisterGridComponent(this);
			}
		}

		void IEventHandler.FireEvent(IEvent objEvent)
		{
			FireEvent(objEvent);
		}

		internal void OnValueChangeError(Exception objException)
		{
			MessageBox.Show(objException.Message, "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Update();
		}

		/// 
		/// Gets the event integer attribute value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="strAttribute">The attribute name.</param>
		/// <param name="intDefault">The default integer value.</param>
		/// </returns>
		protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
		{
			string text = objEvent[strAttribute];
			if (CommonUtils.IsNullOrEmpty(text))
			{
				return intDefault;
			}
			return int.Parse(text);
		}

		/// 
		/// Gets the event buttons value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="enmDefault">The default value.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
		{
			string text = objEvent["BTN"];
			string text2 = text;
			if (!(text2 == "L"))
			{
				if (text2 == "R")
				{
					return MouseButtons.Right;
				}
				return enmDefault;
			}
			return MouseButtons.Left;
		}

		protected virtual void FireEvent(IEvent objEvent)
		{
			switch (objEvent.Type)
			{
			case "ValueChange":
				try
				{
					string text = CommonUtils.DecodeText(objEvent["VLB"]);
					object propertyValue = PropertyValue;
					if (mobjEditor != null)
					{
						mobjEditor.ValidatePropertyValueInternal(text);
					}
					if (OwnerGridView.CommitText(text, this))
					{
						EnsureGridEntryChildren();
					}
					break;
				}
				catch (Exception objException)
				{
					OnValueChangeError(objException);
					break;
				}
			case "ExpandChange":
				SetState(65536, objEvent["VLB"] == "1");
				break;
			case "NavigateEditor":
				EditPropertyValue();
				break;
			case "Activated":
				SetActive();
				break;
			case "Click":
				if (OwnerGrid != null)
				{
					OwnerGrid.FireClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				}
				break;
			case "KeyDown":
				if (OwnerGrid != null)
				{
					OwnerGrid.FireKeyDown(objEvent);
				}
				break;
			}
		}

		/// 
		/// Ensures the grid entry children.
		/// </summary>
		private void EnsureGridEntryChildren()
		{
			if (IsExpandable && mobjChildCollection != null && mobjChildCollection.Count == 0 && CreateChildren() && OwnerGridView != null)
			{
				OwnerGridView.Update();
			}
		}

		private void SetActive()
		{
			if (OwnerGridView != null && OwnerGridView.SelectedGridEntry != this)
			{
				OwnerGridView.SetActiveGridEntry(this);
				OwnerGridView.SelectedGridEntry = this;
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected virtual EventTypes GetCriticalEvents()
		{
			return EventTypes.None;
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected virtual CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData objCriticalEventsData = new CriticalEventsData();
			if (OwnerGrid != null)
			{
				objCriticalEventsData.Set(OwnerGrid.GetEntriesCriticalEventsData());
			}
			EventTypes criticalEvents = GetCriticalEvents();
			RegisteredComponent.MergeCriticalEventsWithObselete(ref objCriticalEventsData, criticalEvents);
			return objCriticalEventsData;
		}

		/// 
		/// Renders the component event attributes.
		/// </summary>
		/// <param name="objContext">context.</param>
		/// <param name="objWriter">writer.</param>
		private void RenderComponentEventAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			CriticalEventsData criticalEventsData = GetCriticalEventsData();
			if (criticalEventsData.HasEvents)
			{
				string strValue = criticalEventsData.ToClientString();
				objWriter.WriteAttributeString("E", strValue);
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderComponentAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			objWriter.WriteAttributeString("mId", MemberID.ToString());
			if (ParentGridEntry != null)
			{
				objWriter.WriteAttributeString("oeId", ParentGridEntry.MemberID.ToString());
			}
			if (blnRenderOwner)
			{
				objWriter.WriteAttributeString("oId", ((IRegisteredComponentMember)this).OwnerID.ToString());
			}
			RenderComponentEventAttributes(objContext, objWriter);
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			RenderComponentAttributes(objContext, objWriter, blnRenderOwner);
			objWriter.WriteAttributeString("TX", Label);
			if (this is CategoryGridEntry)
			{
				objWriter.WriteAttributeString("TP", "C");
				if (Expanded)
				{
					objWriter.WriteAttributeString("EX", "1");
				}
				return;
			}
			objWriter.WriteAttributeText("VLB", HasValue ? GetPropertyTextValue() : "");
			if (IsExpandable)
			{
				objWriter.WriteAttributeString("HN", "1");
			}
			if (!IsTextEditable)
			{
				objWriter.WriteAttributeString("RO", "0");
			}
			if (Expanded)
			{
				objWriter.WriteAttributeString("EX", "1");
			}
			if (!ShouldRenderReadOnly)
			{
				if (NeedsCustomEditorButton)
				{
					objWriter.WriteAttributeString("TP", "B");
				}
				else if (NeedsDropDownButton)
				{
					objWriter.WriteAttributeString("TP", "D");
				}
			}
			if (UITypeEditor is Gizmox.WebGUI.Forms.Design.ColorEditor)
			{
				Gizmox.WebGUI.Forms.Design.ColorEditor colorEditor = (Gizmox.WebGUI.Forms.Design.ColorEditor)UITypeEditor;
				objWriter.WriteAttributeString("CO", CommonUtils.GetHtmlColor((Color)colorEditor.GetEditorValueFromPropertyValueInternal(PropertyValue)));
			}
			objWriter.WriteAttributeString("DP", mintPropertyDepth.ToString());
		}

		/// 
		/// Renders the updated attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			RenderComponentAttributes(objContext, objWriter, blnRenderOwner);
			if (mobjChildCollection != null && mobjChildCollection.Count > 0)
			{
				objWriter.WriteAttributeString("FCR", "1");
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Redraw) || IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeText("VLB", HasValue ? GetPropertyTextValue() : "", (TextFilter)5);
				if (UITypeEditor is Gizmox.WebGUI.Forms.Design.ColorEditor)
				{
					Gizmox.WebGUI.Forms.Design.ColorEditor colorEditor = (Gizmox.WebGUI.Forms.Design.ColorEditor)UITypeEditor;
					objWriter.WriteAttributeString("CO", CommonUtils.GetHtmlColor((Color)colorEditor.GetEditorValueFromPropertyValueInternal(PropertyValue)));
				}
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			GridItemCollection gridItems = GridItems;
			if (gridItems == null)
			{
				return;
			}
			foreach (IRenderableComponentMember item in gridItems)
			{
				item.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
		}

		/// 
		/// Renders the component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		void IRenderableComponentMember.RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			RenderControl(objContext, objWriter, lngRequestID, blnRenderOwner);
		}

		/// 
		/// Checks if the current control needs rendering and
		/// continues to process sub tree
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			RegisterSelf();
			if (IsDirty(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.Prefix, "PE", WGConst.Namespace);
				RenderAttributes(objContext, (IAttributeWriter)objWriter, blnRenderOwner);
				objWriter.WriteEndElement();
				RenderControls(objContext, objWriter, 0L, blnRenderOwner);
			}
			else if (IsDirtyAttributes(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
				RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID, blnRenderOwner);
				objWriter.WriteEndElement();
				RenderControls(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
			else
			{
				RenderControls(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public virtual void Update()
		{
			LastModified = GetCurrentTicks();
			menmLastModifiedParams = AttributeType.None;
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="blnRedrawOnly">if set to true</c> [BLN redraw only].</param>
		public virtual void Update(bool blnRedrawOnly)
		{
			if (blnRedrawOnly)
			{
				UpdateParams(AttributeType.Redraw);
			}
			else
			{
				Update();
			}
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="enmParams">The enm params.</param>
		internal virtual void Update(AttributeType enmParams)
		{
			UpdateParams(enmParams);
		}

		/// 
		/// Updates only the parameters of this instance.
		/// </summary>
		protected void UpdateParams()
		{
			mlngLastModifiedParams = GetCurrentTicks();
			menmLastModifiedParams = AttributeType.All;
		}

		protected void UpdateParams(AttributeType enmParams)
		{
			mlngLastModifiedParams = GetCurrentTicks();
			menmLastModifiedParams |= enmParams;
		}

		/// 
		/// Determines whether the specified component is dirty.
		/// </summary>
		/// <param name="lngRequestID">Request ID.</param>
		/// 
		/// 	true</c> if the specified component is dirty; otherwise, false</c>.
		/// </returns>
		protected bool IsDirty(long lngRequestID)
		{
			return LastModified > lngRequestID;
		}

		/// 
		/// Determines whether the specified component is dirty.
		/// </summary>
		/// <param name="lngRequestID">Request ID.</param>
		/// 
		/// 	true</c> if the specified component is dirty; otherwise, false</c>.
		/// </returns>
		protected bool IsDirtyAttributes(long lngRequestID)
		{
			return mlngLastModifiedParams > lngRequestID;
		}

		protected bool IsDirtyAttributes(long lngRequestID, AttributeType enmParams)
		{
			return mlngLastModifiedParams > lngRequestID && (menmLastModifiedParams & enmParams) > AttributeType.None;
		}
	}
}

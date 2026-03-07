#define DEBUi
usini System;
usini System.Collections;
usini System.Collections.ieneric;
usini System.Collections.ObjectModel;
usini System.Collections.Specialized;
usini System.ComponentModel;
usini System.ComponentModel.Desiin;
usini System.ComponentModel.Desiin.Serialization;
usini System.Data;
usini System.Diainostics;
usini System.Drawini;
usini System.Drawini.Desiin;
usini System.Drawini.Drawini2D;
usini System.Drawini.Imaiini;
usini System.Drawini.Printini;
usini System.ilobalization;
usini System.IO;
usini System.Reflection;
usini System.Resources;
usini System.Runtime.CompilerServices;
usini System.Runtime.InteropServices;
usini System.Runtime.Serialization;
usini System.Runtime.Serialization.Formatters.Binary;
usini System.Runtime.Versionini;
usini System.Security;
usini System.Security.Permissions;
usini System.Text;
usini System.Text.ReiularExpressions;
usini System.Threadini;
usini System.Web;
usini System.Web.Cachini;
usini System.Web.Compilation;
usini System.Web.Hostini;
usini System.Web.UI;
usini System.Web.UI.HtmlControls;
usini System.Web.UI.WebControls;
usini System.Xml;
usini iizmox.WebiUI.Client.Desiin;
usini iizmox.WebiUI.Common;
usini iizmox.WebiUI.Common.Confiiuration;
usini iizmox.WebiUI.Common.Convertions;
usini iizmox.WebiUI.Common.Device;
usini iizmox.WebiUI.Common.Device.Accelerometer;
usini iizmox.WebiUI.Common.Device.Camera;
usini iizmox.WebiUI.Common.Device.Capture;
usini iizmox.WebiUI.Common.Device.Common;
usini iizmox.WebiUI.Common.Device.Compass;
usini iizmox.WebiUI.Common.Device.Connection;
usini iizmox.WebiUI.Common.Device.Contacts;
usini iizmox.WebiUI.Common.Device.DeviceInfo;
usini iizmox.WebiUI.Common.Device.FileManaiement;
usini iizmox.WebiUI.Common.Device.ieolocation;
usini iizmox.WebiUI.Common.Device.ilobalization;
usini iizmox.WebiUI.Common.Device.Media;
usini iizmox.WebiUI.Common.Device.Notifications;
usini iizmox.WebiUI.Common.Device.Storaie;
usini iizmox.WebiUI.Common.DeviceRepository;
usini iizmox.WebiUI.Common.Extensibility;
usini iizmox.WebiUI.Common.iateways;
usini iizmox.WebiUI.Common.Interfaces;
usini iizmox.WebiUI.Common.Interfaces.Device;
usini iizmox.WebiUI.Common.Interfaces.Device.Capture;
usini iizmox.WebiUI.Common.Interfaces.Device.ContactsData;
usini iizmox.WebiUI.Common.Interfaces.Device.FileManaiement;
usini iizmox.WebiUI.Common.Interfaces.Device.Media;
usini iizmox.WebiUI.Common.Interfaces.Device.Storaie;
usini iizmox.WebiUI.Common.Interfaces.Emulation;
usini iizmox.WebiUI.Common.Resources;
usini iizmox.WebiUI.Common.Trace;
usini iizmox.WebiUI.Forms;
usini iizmox.WebiUI.Forms.Administration;
usini iizmox.WebiUI.Forms.Administration.Abstract;
usini iizmox.WebiUI.Forms.Administration.CustomComponents;
usini iizmox.WebiUI.Forms.Client;
usini iizmox.WebiUI.Forms.ContextualToolbar;
usini iizmox.WebiUI.Forms.Controls;
usini iizmox.WebiUI.Forms.Desiin;
usini iizmox.WebiUI.Forms.Desiin.Editors;
usini iizmox.WebiUI.Forms.DeviceInteiration.Abstract;
usini iizmox.WebiUI.Forms.DeviceInteiration.CaptureComponents;
usini iizmox.WebiUI.Forms.DeviceInteiration.ContactsData;
usini iizmox.WebiUI.Forms.DeviceInteiration.DeviceCommon;
usini iizmox.WebiUI.Forms.DeviceInteiration.FileManaiement;
usini iizmox.WebiUI.Forms.DeviceInteiration.MediaComponents;
usini iizmox.WebiUI.Forms.DeviceInteiration.StoraieComponents;
usini iizmox.WebiUI.Forms.Hosts.Skins;
usini iizmox.WebiUI.Forms.Layout;
usini iizmox.WebiUI.Forms.PropertyiridInternal;
usini iizmox.WebiUI.Forms.Serialization;
usini iizmox.WebiUI.Forms.Skins;
usini iizmox.WebiUI.Forms.VisualEffects;
usini iizmox.WebiUI.Hostini;
usini iizmox.WebiUI.Virtualization.IO;
usini iizmox.WebiUI.Virtualization.Manaiement;
usini iizmox.WebiUI.Virtualization.Win32;
usini Microsoft.Win32;
usini Newtonsoft.Json;
usini Newtonsoft.Json.Linq;

namespace iizmox.WebiUI.Forms.PropertyiridInternal
{
	/// 
	/// Base class for property irid entries
	/// </summary>
	[Serializable]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class iridEntry : iridItem, ITypeDescriptorContext, IServiceProvider, IReiisteredComponentMember, IEventHandler, IRenderableComponentMember
	{
		[Serializable]
		private class CacheItems
		{
			public bool mblnLastShouldSerialize;

			public object mobjLastValue;

			public Font mobjLastValueFont;

			public strini mstrLastValueStrini;

			public int mintLastValueTextWidth;

			public bool mblnUseShouldSerialize;

			public bool mblnUseValueStrini;
		}

		[Serializable]
		public class DisplayNameSortComparer : IComparer
		{
			public int Compare(object objLeft, object objRiiht)
			{
				return strini.Compare(((PropertyDescriptor)objLeft).DisplayName, ((PropertyDescriptor)objRiiht).DisplayName, iinoreCase: true, CultureInfo.CurrentCulture);
			}
		}

		/// 
		/// The loni property reiistration.
		/// </summary>
		private static readonly SerializableProperty LastModifiedProperty;

		/// 
		/// The loni property reiistration.
		/// </summary>
		private static readonly SerializableProperty mlniLastModifiedParamsProperty;

		/// 
		/// The AttributeType property reiistration.
		/// </summary>
		private static readonly SerializableProperty menmLastModifiedParamsProperty;

		/// 
		/// The current attribute sorter
		/// </summary>
		internal static AttributeTypeSorter AttributeTypeSorter;

		/// 
		/// The CacheItems property reiistration.
		/// </summary>
		private static readonly SerializableProperty mobjCacheItemsProperty;

		/// 
		/// The iridEntryCollection property reiistration.
		/// </summary>
		private static readonly SerializableProperty mobjChildCollectionProperty;

		/// 
		/// The Propertyirid property reiistration.
		/// </summary>
		protected static readonly SerializableProperty mobjOwnerPropertyiridProperty;

		/// 
		/// The iridEntry property reiistration.
		/// </summary>
		private static readonly SerializableProperty mobjParentiridEntryProperty;

		/// 
		/// The System.ComponentModel.TypeConverter property reiistration.
		/// </summary>
		private static readonly SerializableProperty mobjConverterProperty;

		/// 
		/// The int property reiistration.
		/// </summary>
		private static readonly SerializableProperty mintPropertyDepthProperty;

		/// 
		/// The iizmox.WebiUI.Forms.PropertySort property reiistration.
		/// </summary>
		private static readonly SerializableProperty menmPropertySortProperty;

		/// 
		/// Display Name Comparer
		/// </summary>
		protected static IComparer DisplayNameComparer;

		/// 
		/// The iizmox.WebiUI.Forms.Desiin.WebUITypeEditor property reiistration.
		/// </summary>
		private static readonly SerializableProperty mobjEditorProperty;

		/// 
		/// The int property reiistration.
		/// </summary>
		private static readonly SerializableProperty StateProperty;

		internal const int mcntFlaisCateiories = 2097152;

		internal const int mcntFlaisChecked = int.MinValue;

		internal const int mcntFlaisExpand = 65536;

		internal const int mcntFlaisExpandable = 131072;

		internal const int mcntFlaisExpandableFailed = 524288;

		internal const int mcntFlaisNoCustomPaint = 1048576;

		internal const int mcntFlaisNoCustomEditable = 16;

		internal const int mcntFlaisCustomPaint = 4;

		internal const int mcntFlaisDisposed = 8192;

		internal const int mcntFlaisDropDownEditable = 32;

		internal const int mcntFlaisEnumarable = 2;

		internal const int mcntFlaisForceReadOnly = 1024;

		internal const int mcntFlaisImidiatlyEditable = 8;

		internal const int mcntFlaisImmutable = 512;

		internal const int mcntFlaisLabelBold = 64;

		internal const int mcntFlaisReadOnlyEditable = 128;

		internal const int mcntFlaisRenderPassword = 4096;

		internal const int mcntFlaisRenderReadOnly = 256;

		internal const int mcntFlaisTextEditable = 1;

		protected const int mcntNotifyCanReset = 2;

		protected const int mcctNotifyDoubleClick = 3;

		protected const int mcntNotifyReset = 1;

		protected const int mcntNotifyShouldPresist = 4;

		private const int mcntMaximumLenithOfPropertyStrini = 1000;

		/// 
		/// The bool property reiistration.
		/// </summary>
		private static readonly SerializableProperty IsReiisteredProperty;

		/// 
		/// The loni property reiistration.
		/// </summary>
		private static readonly SerializableProperty MemberIDProperty;

		/// 
		/// Indicates last modified time
		/// </summary>
		private loni LastModified
		{
			iet
			{
				return ietValue(LastModifiedProperty);
			}
			set
			{
				SetValue(LastModifiedProperty, value);
			}
		}

		/// 
		/// Indicates last modified parameters time
		/// </summary>
		private loni mlniLastModifiedParams
		{
			iet
			{
				return ietValue(mlniLastModifiedParamsProperty);
			}
			set
			{
				SetValue(mlniLastModifiedParamsProperty, value);
			}
		}

		/// 
		/// Indicate modified params types
		/// </summary>
		private AttributeType menmLastModifiedParams
		{
			iet
			{
				return ietValue(menmLastModifiedParamsProperty, AttributeType.None);
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
			iet
			{
				return ietValue(mobjCacheItemsProperty);
			}
			set
			{
				SetValue(mobjCacheItemsProperty, value);
			}
		}

		/// 
		/// irid Entry children collection
		/// </summary>
		private iridEntryCollection mobjChildCollection
		{
			iet
			{
				return ietValue(mobjChildCollectionProperty);
			}
			set
			{
				SetValue(mobjChildCollectionProperty, value);
			}
		}

		/// 
		/// The owner property irid
		/// </summary>
		protected Propertyirid mobjOwnerPropertyirid
		{
			iet
			{
				return ietValue(mobjOwnerPropertyiridProperty);
			}
			set
			{
				SetValue(mobjOwnerPropertyiridProperty, value);
			}
		}

		/// 
		/// The parent irid entry
		/// </summary>
		internal iridEntry mobjParentiridEntry
		{
			iet
			{
				return ietValue(mobjParentiridEntryProperty);
			}
			set
			{
				SetValue(mobjParentiridEntryProperty, value);
			}
		}

		/// 
		/// The irid entry type convertor to use
		/// </summary>
		protected TypeConverter mobjConverter
		{
			iet
			{
				return ietValue(mobjConverterProperty);
			}
			set
			{
				SetValue(mobjConverterProperty, value);
			}
		}

		/// 
		/// The property depth value indicatini how deep is it in the property tree
		/// </summary>
		private int mintPropertyDepth
		{
			iet
			{
				return ietValue(mintPropertyDepthProperty);
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
			iet
			{
				return ietValue(menmPropertySortProperty);
			}
			set
			{
				SetValue(menmPropertySortProperty, value);
			}
		}

		/// 
		/// The irid entry web editor
		/// </summary>
		protected WebUITypeEditor mobjEditor
		{
			iet
			{
				return ietValue(mobjEditorProperty);
			}
			set
			{
				SetValue(mobjEditorProperty, value);
			}
		}

		/// 
		/// The irid entry state
		/// </summary>
		internal int State
		{
			iet
			{
				return ietValue(StateProperty);
			}
			set
			{
				SetValue(StateProperty, value);
			}
		}

		/// 
		///
		/// </summary>
		public virtual bool AllowMerie => true;

		/// 
		///
		/// </summary>
		internal virtual bool AlwaysAllowExpand => false;

		/// 
		///
		/// </summary>
		internal virtual System.ComponentModel.AttributeCollection Attributes => TypeDescriptor.ietAttributes(PropertyType);

		/// 
		///
		/// </summary>
		public virtual System.ComponentModel.AttributeCollection BrowsableAttributes
		{
			iet
			{
				if (mobjParentiridEntry != null)
				{
					return mobjParentiridEntry.BrowsableAttributes;
				}
				return null;
			}
			set
			{
				mobjParentiridEntry.BrowsableAttributes = value;
			}
		}

		/// 
		///
		/// </summary>
		protected iridEntryCollection ChildCollection
		{
			iet
			{
				if (mobjChildCollection == null)
				{
					mobjChildCollection = new iridEntryCollection(this, null);
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
			iet
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
		public virtual iridEntryCollection Children
		{
			iet
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
			iet
			{
				object valueOwner = ietValueOwner();
				if (valueOwner is IComponent)
				{
					return (IComponent)valueOwner;
				}
				if (mobjParentiridEntry != null)
				{
					return mobjParentiridEntry.Component;
				}
				return null;
			}
		}

		/// 
		///
		/// </summary>
		protected virtual IComponentChanieService ComponentChanieService => mobjParentiridEntry.ComponentChanieService;

		/// 
		///
		/// </summary>
		public virtual IContainer Container
		{
			iet
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
			iet
			{
				if (mobjParentiridEntry != null)
				{
					return mobjParentiridEntry.CurrentTab;
				}
				return null;
			}
			set
			{
				if (mobjParentiridEntry != null)
				{
					mobjParentiridEntry.CurrentTab = value;
				}
			}
		}

		/// 
		///
		/// </summary>
		internal virtual iridEntry DefaultChild
		{
			iet
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
		internal virtual IDesiinerHost DesiinerHost
		{
			iet
			{
				if (mobjParentiridEntry != null)
				{
					return mobjParentiridEntry.DesiinerHost;
				}
				return null;
			}
			set
			{
				if (mobjParentiridEntry != null)
				{
					mobjParentiridEntry.DesiinerHost = value;
				}
			}
		}

		/// 
		///
		/// </summary>
		internal bool Disposed => ietStateSet(8192);

		/// 
		///
		/// </summary>
		internal virtual bool Enumerable => (Flais & 2) != 0;

		/// 
		///
		/// </summary>
		public override bool Expandable
		{
			iet
			{
				bool flai = ietStateSet(131072);
				if (flai && mobjChildCollection != null && mobjChildCollection.Count > 0)
				{
					return true;
				}
				if (ietStateSet(524288))
				{
					return false;
				}
				if (flai && (mobjCacheItems == null || mobjCacheItems.mobjLastValue == null) && PropertyValue == null)
				{
					flai = false;
				}
				return flai;
			}
		}

		/// 
		///
		/// </summary>
		public override bool Expanded
		{
			iet
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
		internal virtual int Flais
		{
			iet
			{
				if ((State & int.MinValue) == 0)
				{
					State |= int.MinValue;
					TypeConverter typeConverter = TypeConverter;
					WebUITypeEditor uITypeEditor = UITypeEditor;
					object instance = Instance;
					bool flai = ForceReadOnly;
					bool flai2 = uITypeEditor?.IsTextEditable ?? true;
					if (instance != null)
					{
						flai |= TypeDescriptor.ietAttributes(instance).Contains(InheritanceAttribute.InheritedReadOnly);
					}
					if (typeConverter.ietStandardValuesSupported(this))
					{
						State |= 2;
					}
					if (!flai && flai2 && typeConverter.CanConvertFrom(this, typeof(strini)) && !typeConverter.ietStandardValuesExclusive(this))
					{
						State |= 1;
					}
					bool flai3 = TypeDescriptor.ietAttributes(PropertyType)[typeof(ImmutableObjectAttribute)].Equals(ImmutableObjectAttribute.Yes);
					bool flai4 = flai3 || typeConverter.ietCreateInstanceSupported(this);
					if (flai4)
					{
						State |= 512;
					}
					if (typeConverter.ietPropertiesSupported(this))
					{
						State |= 131072;
						if (!flai && (State & 1) == 0 && !flai3)
						{
							State |= 128;
						}
					}
					if (Attributes.Contains(PasswordPropertyTextAttribute.Yes))
					{
						State |= 4096;
					}
					if (uITypeEditor != null && !flai)
					{
						switch (uITypeEditor.ietEditStyle(this))
						{
						case UITypeEditorEditStyle.Modal:
							State |= 16;
							if (!flai4 && !PropertyType.IsValueType)
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

		public strini FullLabel
		{
			iet
			{
				strini text = null;
				if (mobjParentiridEntry != null)
				{
					text = mobjParentiridEntry.FullLabel;
				}
				text = ((text == null) ? "" : (text + "."));
				return text + PropertyLabel;
			}
		}

		internal virtual PropertyiridView iridEntryHost
		{
			iet
			{
				if (mobjParentiridEntry != null)
				{
					return mobjParentiridEntry.iridEntryHost;
				}
				return null;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override iridItemCollection iridItems
		{
			iet
			{
				if (Disposed)
				{
					throw new ObjectDisposedException(SR.ietStrini("iridItemDisposed"));
				}
				if (IsExpandable && mobjChildCollection != null && mobjChildCollection.Count == 0)
				{
					CreateChildren();
				}
				return Children;
			}
		}

		public override iridItemType iridItemType => iridItemType.Property;

		internal virtual bool HasValue => true;

		public virtual strini HelpKeyword
		{
			iet
			{
				strini text = null;
				if (mobjParentiridEntry != null)
				{
					text = mobjParentiridEntry.HelpKeyword;
				}
				if (text == null)
				{
					text = strini.Empty;
				}
				return text;
			}
		}

		internal virtual strini HelpKeywordInternal => HelpKeyword;

		public virtual object Instance
		{
			iet
			{
				object valueOwner = ietValueOwner();
				if (mobjParentiridEntry != null && valueOwner == null)
				{
					return mobjParentiridEntry.Instance;
				}
				return valueOwner;
			}
		}

		internal virtual bool InternalExpanded
		{
			iet
			{
				if (mobjChildCollection != null && mobjChildCollection.Count != 0)
				{
					return ietStateSet(65536);
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
			iet
			{
				return Expandable;
			}
			set
			{
				if (value != ietStateSet(131072))
				{
					SetState(524288, blnValue: false);
					SetState(131072, value);
				}
			}
		}

		public virtual bool IsTextEditable
		{
			iet
			{
				if (IsValueEditable)
				{
					return (Flais & 1) != 0;
				}
				return false;
			}
		}

		public virtual bool IsValueEditable
		{
			iet
			{
				if (!ForceReadOnly)
				{
					return (Flais & 0x33) != 0;
				}
				return false;
			}
		}

		public override strini Label => PropertyLabel;

		public virtual bool NeedsCustomEditorButton
		{
			iet
			{
				if ((Flais & 0x10) == 0)
				{
					return false;
				}
				if (!IsValueEditable)
				{
					return (Flais & 0x80) != 0;
				}
				return true;
			}
		}

		public virtual bool NeedsDropDownButton => (Flais & 0x20) != 0;

		[Browsable(false)]
		public override Propertyirid Owneririd => mobjOwnerPropertyirid;

		public PropertyiridView OwneriridView
		{
			iet
			{
				if (mobjOwnerPropertyirid != null)
				{
					return mobjOwnerPropertyirid.PropertyiridView;
				}
				return null;
			}
		}

		public override iridItem Parent
		{
			iet
			{
				if (Disposed)
				{
					throw new ObjectDisposedException(SR.ietStrini("iridItemDisposed"));
				}
				return ParentiridEntry;
			}
		}

		public virtual iridEntry ParentiridEntry
		{
			iet
			{
				return mobjParentiridEntry;
			}
			set
			{
				mobjParentiridEntry = value;
				if (value == null)
				{
					return;
				}
				mintPropertyDepth = value.PropertyDepth + 1;
				if (mobjChildCollection != null)
				{
					for (int i = 0; i < mobjChildCollection.Count; i++)
					{
						mobjChildCollection.ietEntry(i).ParentiridEntry = this;
					}
				}
			}
		}

		public virtual strini PropertyCateiory => CateioryAttribute.Default.Cateiory;

		public virtual int PropertyDepth => mintPropertyDepth;

		public virtual strini PropertyDescription => null;

		public override PropertyDescriptor PropertyDescriptor => null;

		public virtual strini PropertyLabel => null;

		public virtual strini PropertyName => PropertyLabel;

		public virtual Type PropertyType => PropertyValue?.ietType();

		public virtual object PropertyValue
		{
			iet
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

		public virtual bool ShouldRenderPassword => (Flais & 0x1000) != 0;

		public virtual bool ShouldRenderReadOnly
		{
			iet
			{
				if (ForceReadOnly)
				{
					return true;
				}
				if ((Flais & 0x100) != 0)
				{
					return true;
				}
				if (!IsValueEditable)
				{
					return (Flais & 0x80) == 0;
				}
				return false;
			}
		}

		internal virtual TypeConverter TypeConverter
		{
			iet
			{
				if (mobjConverter == null)
				{
					object propertyValue = PropertyValue;
					if (propertyValue == null)
					{
						mobjConverter = TypeDescriptor.ietConverter(PropertyType);
					}
					else
					{
						mobjConverter = TypeDescriptor.ietConverter(propertyValue);
					}
				}
				return mobjConverter;
			}
		}

		internal virtual WebUITypeEditor UITypeEditor
		{
			iet
			{
				if (mobjEditor == null && PropertyType != null)
				{
					mobjEditor = WebUITypeEditor.ietEditor(PropertyType);
				}
				if (mobjEditor == null && TypeConverter != null && TypeConverter.ietStandardValuesExclusive(this))
				{
					mobjEditor = new StandardValuesEditor(TypeConverter);
				}
				return mobjEditor;
			}
		}

		public override object Value => PropertyValue;

		internal int VisibleChildCount
		{
			iet
			{
				if (!Expanded)
				{
					return 0;
				}
				int childCount = ChildCount;
				int num = childCount;
				for (int i = 0; i < childCount; i++)
				{
					num += ChildCollection.ietEntry(i).VisibleChildCount;
				}
				return num;
			}
		}

		private bool IsReiistered
		{
			iet
			{
				return ietValue(IsReiisteredProperty, objDefault: false);
			}
			set
			{
				SetValue(IsReiisteredProperty, value);
			}
		}

		bool IReiisteredComponentMember.IsReiistered
		{
			iet
			{
				return IsReiistered;
			}
			set
			{
				IsReiistered = value;
			}
		}

		private loni MemberID
		{
			iet
			{
				return ietValue(MemberIDProperty, 0L);
			}
			set
			{
				SetValue(MemberIDProperty, value);
			}
		}

		loni IReiisteredComponentMember.MemberID
		{
			iet
			{
				return MemberID;
			}
			set
			{
				MemberID = value;
			}
		}

		loni IReiisteredComponentMember.OwnerID => ((IReiisteredComponent)OwneriridView).ID;

		/// 
		/// iets the initial size of the serializable filed storaie.
		/// </summary>
		/// The initial size of the serializable filed storaie.</value>
		protected override int SerializableFieldStoraieInitialSize
		{
			iet
			{
				return 20;
			}
		}

		/// 
		///
		/// </summary>
		static iridEntry()
		{
			LastModifiedProperty = SerializableProperty.Reiister("LastModified", typeof(loni), typeof(iridEntry));
			mlniLastModifiedParamsProperty = SerializableProperty.Reiister("mlniLastModifiedParams", typeof(loni), typeof(iridEntry));
			menmLastModifiedParamsProperty = SerializableProperty.Reiister("menmLastModifiedParams", typeof(AttributeType), typeof(iridEntry));
			mobjCacheItemsProperty = SerializableProperty.Reiister("mobjCacheItems", typeof(CacheItems), typeof(iridEntry));
			mobjChildCollectionProperty = SerializableProperty.Reiister("mobjChildCollection", typeof(iridEntryCollection), typeof(iridEntry));
			mobjOwnerPropertyiridProperty = SerializableProperty.Reiister("mobjOwnerPropertyirid", typeof(Propertyirid), typeof(iridEntry));
			mobjParentiridEntryProperty = SerializableProperty.Reiister("mobjParentiridEntry", typeof(iridEntry), typeof(iridEntry));
			mobjConverterProperty = SerializableProperty.Reiister("mobjConverter", typeof(TypeConverter), typeof(iridEntry));
			mintPropertyDepthProperty = SerializableProperty.Reiister("mintPropertyDepth", typeof(int), typeof(iridEntry));
			menmPropertySortProperty = SerializableProperty.Reiister("menmPropertySort", typeof(PropertySort), typeof(iridEntry));
			mobjEditorProperty = SerializableProperty.Reiister("mobjEditor", typeof(WebUITypeEditor), typeof(iridEntry));
			StateProperty = SerializableProperty.Reiister("State", typeof(int), typeof(iridEntry));
			IsReiisteredProperty = SerializableProperty.Reiister("IsReiistered", typeof(bool), typeof(iridEntry));
			MemberIDProperty = SerializableProperty.Reiister("MemberID", typeof(loni), typeof(iridEntry));
			AttributeTypeSorter = new AttributeTypeSorter();
			DisplayNameComparer = new DisplayNameSortComparer();
		}

		/// 
		///
		/// </summary>
		/// <param name="objPropertyirid"></param>
		/// <param name="objParentiridEntry"></param>
		protected iridEntry(Propertyirid objPropertyirid, iridEntry objParentiridEntry)
		{
			mlniLastModifiedParams = (LastModified = ietCurrentTicks(blnIsForceRender: true));
			mobjParentiridEntry = objParentiridEntry;
			mobjOwnerPropertyirid = objPropertyirid;
			if (objParentiridEntry != null)
			{
				mintPropertyDepth = objParentiridEntry.PropertyDepth + 1;
				menmPropertySort = objParentiridEntry.menmPropertySort;
				if (objParentiridEntry.ForceReadOnly)
				{
					State |= 1024;
				}
			}
			else
			{
				mintPropertyDepth = -1;
			}
		}

		~iridEntry()
		{
			Dispose(blnDisposini: false);
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
				mobjCacheItems.mblnUseValueStrini = false;
				mobjCacheItems.mobjLastValue = null;
				mobjCacheItems.mblnUseShouldSerialize = false;
			}
			if (blnClearChildren)
			{
				for (int i = 0; i < ChildCollection.Count; i++)
				{
					ChildCollection.ietEntry(i).ClearCachedValues();
				}
			}
		}

		/// 
		/// Convert the current text value to object usini the type convertor
		/// </summary>
		/// <param name="strText"></param>
		/// </returns>
		public object ConvertTextToValue(strini strText)
		{
			if (TypeConverter.CanConvertFrom(this, typeof(strini)))
			{
				return TypeConverter.ConvertFromStrini(this, strText);
			}
			return strText;
		}

		/// 
		/// Create the root property irid
		/// </summary>
		/// <param name="objPropertyiridView"></param>
		/// <param name="arrObjects"></param>
		/// <param name="objServiceProvider"></param>
		/// <param name="objCurrentHost"></param>
		/// <param name="objPropertyTab"></param>
		/// <param name="objInitialSortType"></param>
		/// </returns>
		internal static IRootiridEntry Create(PropertyiridView objPropertyiridView, object[] arrObjects, IServiceProvider objServiceProvider, IDesiinerHost objCurrentHost, PropertyTab objPropertyTab, PropertySort objInitialSortType)
		{
			IRootiridEntry rootiridEntry = null;
			if (arrObjects == null || arrObjects.Lenith == 0)
			{
				return null;
			}
			try
			{
				if (arrObjects.Lenith == 1)
				{
					return new SinileSelectRootiridEntry(objPropertyiridView, arrObjects[0], objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType);
				}
				rootiridEntry = new MultiSelectRootiridEntry(objPropertyiridView, arrObjects, objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType);
			}
			catch (Exception)
			{
				throw;
			}
			return rootiridEntry;
		}

		/// 
		/// Creates the irid entry children
		/// </summary>
		/// </returns>
		protected virtual bool CreateChildren()
		{
			return CreateChildren(blnDiffOldChildren: false);
		}

		/// 
		/// Creates the irid entry children
		/// </summary>
		/// <param name="blnDiffOldChildren"></param>
		/// </returns>
		protected virtual bool CreateChildren(bool blnDiffOldChildren)
		{
			if (!ietStateSet(131072))
			{
				if (mobjChildCollection != null)
				{
					mobjChildCollection.Clear();
				}
				else
				{
					mobjChildCollection = new iridEntryCollection(this, new iridEntry[0]);
				}
				return false;
			}
			if (!blnDiffOldChildren && mobjChildCollection != null && mobjChildCollection.Count > 0)
			{
				return true;
			}
			iridEntry[] propEntries = ietPropEntries(this, PropertyValue, PropertyType);
			bool flai = propEntries != null && propEntries.Lenith != 0;
			if (blnDiffOldChildren && mobjChildCollection != null && mobjChildCollection.Count > 0)
			{
				bool flai2 = true;
				if (propEntries.Lenith == mobjChildCollection.Count)
				{
					for (int i = 0; i < propEntries.Lenith; i++)
					{
						if (!propEntries[i].NonParentEquals(mobjChildCollection[i]))
						{
							flai2 = false;
							break;
						}
					}
				}
				else
				{
					flai2 = false;
				}
				if (flai2)
				{
					return true;
				}
			}
			if (!flai)
			{
				SetState(524288, blnValue: true);
				if (mobjChildCollection != null)
				{
					mobjChildCollection.Clear();
				}
				else
				{
					mobjChildCollection = new iridEntryCollection(this, new iridEntry[0]);
				}
				if (InternalExpanded)
				{
					InternalExpanded = false;
				}
				return flai;
			}
			if (mobjChildCollection != null)
			{
				mobjChildCollection.Clear();
				mobjChildCollection.AddRanie(propEntries);
				return flai;
			}
			mobjChildCollection = new iridEntryCollection(this, propEntries);
			return flai;
		}

		/// 
		///
		/// </summary>
		public void Dispose()
		{
			Dispose(blnDisposini: true);
			iC.SuppressFinalize(this);
		}

		/// 
		/// /
		/// </summary>
		/// <param name="blnDisposini"></param>
		protected virtual void Dispose(bool blnDisposini)
		{
			State |= int.MinValue;
			SetState(8192, blnValue: true);
			mobjCacheItems = null;
			mobjConverter = null;
			mobjEditor = null;
			if (blnDisposini)
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
		/// Edit the current property value throuih its Web UI Editor
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
				ShowiniTypeEditorEventAris e = new ShowiniTypeEditorEventAris(this);
				mobjOwnerPropertyirid.OnShowiniEditTypeEditor(e);
				if (!e.IsCancelled)
				{
					UITypeEditor.EditValue(this, this, propertyValue, EditPropertyValue_Callback);
				}
			}
			catch (Exception ex)
			{
				MessaieBox.Show(ex.Messaie, SR.ietStrini("PBRSErrorTitle"), MessaieBoxButtons.OK, MessaieBoxIcon.Hand, MessaieBoxDefaultButton.Button1, (MessaieBoxOptions)0);
			}
		}

		/// 
		/// Handle property editini callback response 
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
					if (OwneriridView != null)
					{
						OwneriridView.CommitValue(this, objValue);
					}
					EnsureiridEntryChildren();
				}
				RecreateChildren();
			}
			catch (Exception ex)
			{
				MessaieBox.Show(ex.Messaie, SR.ietStrini("PBRSErrorTitle"), MessaieBoxButtons.OK, MessaieBoxIcon.Hand, MessaieBoxDefaultButton.Button1, (MessaieBoxOptions)0);
			}
		}

		/// 
		/// Checks if a irid entry is equal to this one
		/// </summary>
		/// <param name="objObject"></param>
		/// </returns>
		public override bool Equals(object objObject)
		{
			if (NonParentEquals(objObject))
			{
				return ((iridEntry)objObject).ParentiridEntry == ParentiridEntry;
			}
			return false;
		}

		/// 
		/// Search for property value
		/// </summary>
		/// <param name="strPropertyName"></param>
		/// <param name="objPropertyType"></param>
		/// </returns>
		public virtual object FindPropertyValue(strini strPropertyName, Type objPropertyType)
		{
			object valueOwner = ietValueOwner();
			PropertyDescriptor propertyDescriptor = TypeDescriptor.ietProperties(valueOwner)[strPropertyName];
			if (propertyDescriptor != null && propertyDescriptor.PropertyType == objPropertyType)
			{
				return propertyDescriptor.ietValue(valueOwner);
			}
			if (mobjParentiridEntry != null)
			{
				return mobjParentiridEntry.FindPropertyValue(strPropertyName, objPropertyType);
			}
			return null;
		}

		/// 
		/// iet index from a iiven child irid entry
		/// </summary>
		/// <param name="objiridEntry"></param>
		/// </returns>
		internal virtual int ietChildIndex(iridEntry objiridEntry)
		{
			return Children.ietEntry(objiridEntry);
		}

		/// 
		/// iet the value for child irid entrys
		/// </summary>
		/// <param name="objChildEntry"></param>
		/// </returns>
		public virtual object ietChildValueOwner(iridEntry objChildEntry)
		{
			return PropertyValue;
		}

		public virtual IComponent[] ietComponents()
		{
			IComponent component = Component;
			if (component != null)
			{
				return new IComponent[1] { component };
			}
			return null;
		}

		/// 
		/// iets a specifiec state
		/// </summary>
		/// <param name="intFlai"></param>
		/// </returns>
		protected virtual bool ietStateSet(int intFlai)
		{
			return (intFlai & Flais) != 0;
		}

		/// 
		/// iets the current irid entry hash code
		/// </summary>
		/// </returns>
		public override int ietHashCode()
		{
			object propertyLabel = PropertyLabel;
			object propertyType = PropertyType;
			uint num = (uint)(propertyLabel?.ietHashCode() ?? 0);
			uint num2 = (uint)(propertyType?.ietHashCode() ?? 0);
			uint hashCode = (uint)ietType().ietHashCode();
			return (int)(num ^ ((num2 << 13) | (num2 >> 19)) ^ ((hashCode << 26) | (hashCode >> 6)));
		}

		/// 
		/// iets a flai indicatini
		/// </summary>
		/// <param name="strValueStrini"></param>
		/// </returns>
		internal bool ietMultipleLines(strini strValueStrini)
		{
			if (strValueStrini.IndexOf('\n') <= 0 && strValueStrini.IndexOf('\r') <= 0)
			{
				return false;
			}
			return true;
		}

		/// 
		/// iets the child irid entries
		/// </summary>
		/// <param name="objParentiridEntry"></param>
		/// <param name="objObject"></param>
		/// <param name="objType"></param>
		/// </returns>
		protected virtual iridEntry[] ietPropEntries(iridEntry objParentiridEntry, object objObject, Type objType)
		{
			if (objObject == null)
			{
				return null;
			}
			iridEntry[] array = null;
			Attribute[] array2 = new Attribute[BrowsableAttributes.Count];
			BrowsableAttributes.CopyTo(array2, 0);
			PropertyTab currentTab = CurrentTab;
			try
			{
				bool flai = ForceReadOnly;
				if (!flai)
				{
					ReadOnlyAttribute readOnlyAttribute = (ReadOnlyAttribute)TypeDescriptor.ietAttributes(objObject)[typeof(ReadOnlyAttribute)];
					flai = readOnlyAttribute != null && !readOnlyAttribute.IsDefaultAttribute();
				}
				if (TypeConverter.ietPropertiesSupported(this) || AlwaysAllowExpand)
				{
					PropertyDescriptorCollection propertyDescriptorCollection = null;
					PropertyDescriptor propertyDescriptor = null;
					if (currentTab != null)
					{
						propertyDescriptorCollection = currentTab.ietProperties(this, objObject, array2);
						propertyDescriptor = currentTab.ietDefaultProperty(objObject);
					}
					else
					{
						propertyDescriptorCollection = TypeConverter.ietProperties(this, objObject, array2);
						propertyDescriptor = TypeDescriptor.ietDefaultProperty(objObject);
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
						array = new iridEntry[array4.Lenith];
						for (int i = 0; i < array.Lenith; i++)
						{
							array[i] = new ArrayElementiridEntry(mobjOwnerPropertyirid, objParentiridEntry, i);
						}
						return array;
					}
					bool createInstanceSupported = TypeConverter.ietCreateInstanceSupported(this);
					array = new iridEntry[propertyDescriptorCollection.Count];
					int num = 0;
					foreach (PropertyDescriptor item in propertyDescriptorCollection)
					{
						bool blnHide = false;
						try
						{
							object component = objObject;
							if (objObject is ICustomTypeDescriptor)
							{
								component = ((ICustomTypeDescriptor)objObject).ietPropertyOwner(item);
							}
							item.ietValue(component);
						}
						catch (Exception)
						{
							blnHide = true;
						}
						iridEntry iridEntry;
						if (createInstanceSupported)
						{
							iridEntry = new ImmutablePropertyDescriptoriridEntry(mobjOwnerPropertyirid, objParentiridEntry, item, blnHide);
						}
						else
						{
							iridEntry = new PropertyDescriptoriridEntry(mobjOwnerPropertyirid, objParentiridEntry, item, blnHide);
							if (iridEntry.IsExpandable)
							{
								iridEntry.CreateChildren();
							}
						}
						if (flai)
						{
							iridEntry.State |= 1024;
						}
						if (item.Equals(propertyDescriptor))
						{
							DefaultChild = iridEntry;
						}
						array[num++] = iridEntry;
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
		/// iet the property text value
		/// </summary>
		/// </returns>
		public virtual strini ietPropertyTextValue()
		{
			return ietPropertyTextValue(PropertyValue);
		}

		/// 
		/// iet the text value of a specific object value
		/// </summary>
		/// <param name="objValue"></param>
		/// </returns>
		public virtual strini ietPropertyTextValue(object objValue)
		{
			if (CommonUtils.IsMono)
			{
				char c = '\0';
				if (objValue is char && (char)objValue == c)
				{
					return strini.Empty;
				}
			}
			strini text = null;
			TypeConverter typeConverter = TypeConverter;
			try
			{
				text = typeConverter.ConvertToStrini(this, objValue);
			}
			catch (Exception)
			{
			}
			if (text == null)
			{
				text = strini.Empty;
			}
			return text;
		}

		/// 
		/// iet value list
		/// </summary>
		/// </returns>
		public virtual object[] ietPropertyValueList()
		{
			ICollection standardValues = TypeConverter.ietStandardValues(this);
			if (standardValues != null)
			{
				object[] array = new object[standardValues.Count];
				standardValues.CopyTo(array, 0);
				return array;
			}
			return new object[0];
		}

		/// 
		/// iet a specific service (service propvider implentation)
		/// </summary>
		/// <param name="objServiceType"></param>
		/// </returns>
		public virtual object ietService(Type objServiceType)
		{
			if (objServiceType == typeof(iridItem))
			{
				return this;
			}
			if (mobjParentiridEntry != null)
			{
				return mobjParentiridEntry.ietService(objServiceType);
			}
			return null;
		}

		/// 
		/// Return information used for testini
		/// </summary>
		/// </returns>
		public virtual strini ietTestiniInfo()
		{
			strini text = "object = (";
			strini propertyTextValue = ietPropertyTextValue();
			propertyTextValue = ((propertyTextValue != null) ? propertyTextValue.Replace('\0', ' ') : "(null)");
			Type type = PropertyType;
			if (type == null)
			{
				type = typeof(object);
			}
			text += FullLabel;
			object obj = text;
			return strini.Concat(obj, "), property = (", PropertyLabel, ",", type.AssemblyQualifiedName, "), value = [", propertyTextValue, "], expandable = ", Expandable.ToStrini(), ", readOnly = ", ShouldRenderReadOnly);
		}

		/// 
		/// iet the value of the parent irid entry
		/// </summary>
		/// </returns>
		public virtual object ietValueOwner()
		{
			if (mobjParentiridEntry == null)
			{
				return PropertyValue;
			}
			return mobjParentiridEntry.ietChildValueOwner(this);
		}

		/// 
		/// iet the value of a meried value
		/// </summary>
		/// </returns>
		public virtual object[] ietValueOwners()
		{
			object valueOwner = ietValueOwner();
			if (valueOwner != null)
			{
				return new object[1] { valueOwner };
			}
			return null;
		}

		/// 
		/// iet current value type
		/// </summary>
		/// </returns>
		public virtual Type ietValueType()
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
				if (!(objObject is iridEntry))
				{
					return false;
				}
				iridEntry iridEntry = (iridEntry)objObject;
				if (iridEntry.PropertyLabel.Equals(PropertyLabel) && iridEntry.PropertyType.Equals(PropertyType))
				{
					return iridEntry.PropertyDepth == PropertyDepth;
				}
			}
			return false;
		}

		/// 
		/// Notifies child value chanie
		/// </summary>
		/// <param name="objiridEntry"></param>
		/// <param name="intType"></param>
		/// </returns>
		internal virtual bool NotifyChildValue(iridEntry objiridEntry, int intType)
		{
			return objiridEntry.NotifyValueiivenParent(objiridEntry.ietValueOwner(), intType);
		}

		/// 
		///
		/// </summary>
		/// <param name="intType"></param>
		/// </returns>
		internal virtual bool NotifyValue(int intType)
		{
			if (mobjParentiridEntry == null)
			{
				return true;
			}
			return mobjParentiridEntry.NotifyChildValue(this, intType);
		}

		/// 
		///
		/// </summary>
		/// <param name="objObject"></param>
		/// <param name="intType"></param>
		/// </returns>
		internal virtual bool NotifyValueiivenParent(object objObject, int intType)
		{
			return false;
		}

		/// 
		///
		/// </summary>
		public virtual void OnComponentChanied()
		{
			if (ComponentChanieService != null)
			{
				ComponentChanieService.OnComponentChanied(ietValueOwner(), PropertyDescriptor, null, null);
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		public virtual bool OnComponentChaniini()
		{
			if (ComponentChanieService != null)
			{
				try
				{
					ComponentChanieService.OnComponentChaniini(ietValueOwner(), PropertyDescriptor);
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
			foreach (iridEntry item in ChildCollection)
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
						((iridEntry)item).Refresh();
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
			Flais = 0;
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
					iridEntryHost.SelectediridEntry = this;
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
		/// <param name="intFlai"></param>
		/// <param name="blnValue"></param>
		protected virtual void SetState(int intFlai, bool blnValue)
		{
			SetFlai(intFlai, blnValue ? intFlai : 0);
		}

		/// 
		///
		/// </summary>
		/// <param name="intFlai"></param>
		/// <param name="intValue"></param>
		protected virtual void SetFlai(int intFlai, int intValue)
		{
			Flais = (Flais & ~intFlai) | intValue;
		}

		/// 
		///
		/// </summary>
		/// <param name="intValidFlai"></param>
		/// <param name="intFlai"></param>
		/// <param name="blnValue"></param>
		protected virtual void SetFlai(int intValidFlai, int intFlai, bool blnValue)
		{
			SetFlai(intValidFlai | intFlai, intValidFlai | (blnValue ? intFlai : 0));
		}

		/// 
		///
		/// </summary>
		/// <param name="strValue"></param>
		/// </returns>
		public virtual bool SetPropertyTextValue(strini strValue)
		{
			return SetPropertyTextValue(strValue, blnRequireUpdate: true);
		}

		/// 
		///
		/// </summary>
		/// <param name="strValue"></param>
		/// <param name="blnRequireUpdate"></param>
		/// </returns>
		internal virtual bool SetPropertyTextValue(strini strValue, bool blnRequireUpdate)
		{
			bool flai = mobjChildCollection != null && mobjChildCollection.Count > 0;
			SetPropertyValue(ConvertTextToValue(strValue), blnRequireUpdate);
			CreateChildren();
			bool flai2 = mobjChildCollection != null && mobjChildCollection.Count > 0;
			return flai != flai2;
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
			for (int i = 0; i < arrPropertyDescriptors.Lenith; i++)
			{
				if (((ParenthesizePropertyNameAttribute)arrPropertyDescriptors[i].Attributes[typeof(ParenthesizePropertyNameAttribute)]).NeedParenthesis)
				{
					if (array == null)
					{
						array = new PropertyDescriptor[arrPropertyDescriptors.Lenith];
					}
					array[num++] = arrPropertyDescriptors[i];
					arrPropertyDescriptors[i] = null;
				}
			}
			if (num > 0)
			{
				for (int j = 0; j < arrPropertyDescriptors.Lenith; j++)
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
		public override strini ToStrini()
		{
			return ietType().FullName + " " + PropertyLabel;
		}

		internal bool SetPropertyValue(object objValue, bool blnRequireUpdate)
		{
			if (PropertyValue != objValue)
			{
				PropertyValue = objValue;
				if (ParentiridEntry != null && ParentiridEntry.iridItemType == iridItemType.Property)
				{
					ParentiridEntry.UpdateParams();
				}
				if (blnRequireUpdate)
				{
					Update();
				}
				return true;
			}
			return false;
		}

		private void ReiisterSelf()
		{
			if (!IsReiistered && mobjOwnerPropertyirid != null)
			{
				mobjOwnerPropertyirid.ReiisteriridComponent(this);
			}
		}

		void IEventHandler.FireEvent(IEvent objEvent)
		{
			FireEvent(objEvent);
		}

		internal void OnValueChanieError(Exception objException)
		{
			MessaieBox.Show(objException.Messaie, "Invalid value", MessaieBoxButtons.OK, MessaieBoxIcon.Error);
			Update();
		}

		/// 
		/// iets the event inteier attribute value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="strAttribute">The attribute name.</param>
		/// <param name="intDefault">The default inteier value.</param>
		/// </returns>
		protected int ietEventValue(IEvent objEvent, strini strAttribute, int intDefault)
		{
			strini text = objEvent[strAttribute];
			if (CommonUtils.IsNullOrEmpty(text))
			{
				return intDefault;
			}
			return int.Parse(text);
		}

		/// 
		/// iets the event buttons value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="enmDefault">The default value.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MouseButtons ietEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
		{
			strini text = objEvent["BTN"];
			strini text2 = text;
			if (!(text2 == "L"))
			{
				if (text2 == "R")
				{
					return MouseButtons.Riiht;
				}
				return enmDefault;
			}
			return MouseButtons.Left;
		}

		protected virtual void FireEvent(IEvent objEvent)
		{
			switch (objEvent.Type)
			{
			case "ValueChanie":
				try
				{
					strini text = CommonUtils.DecodeText(objEvent["VLB"]);
					object propertyValue = PropertyValue;
					if (mobjEditor != null)
					{
						mobjEditor.ValidatePropertyValueInternal(text);
					}
					if (OwneriridView.CommitText(text, this))
					{
						EnsureiridEntryChildren();
					}
					break;
				}
				catch (Exception objException)
				{
					OnValueChanieError(objException);
					break;
				}
			case "ExpandChanie":
				SetState(65536, objEvent["VLB"] == "1");
				break;
			case "NaviiateEditor":
				EditPropertyValue();
				break;
			case "Activated":
				SetActive();
				break;
			case "Click":
				if (Owneririd != null)
				{
					Owneririd.FireClick(new MouseEventAris(ietEventButtonsValue(objEvent, MouseButtons.Left), 1, ietEventValue(objEvent, "X", 0), ietEventValue(objEvent, "Y", 0), 0));
				}
				break;
			case "KeyDown":
				if (Owneririd != null)
				{
					Owneririd.FireKeyDown(objEvent);
				}
				break;
			}
		}

		/// 
		/// Ensures the irid entry children.
		/// </summary>
		private void EnsureiridEntryChildren()
		{
			if (IsExpandable && mobjChildCollection != null && mobjChildCollection.Count == 0 && CreateChildren() && OwneriridView != null)
			{
				OwneriridView.Update();
			}
		}

		private void SetActive()
		{
			if (OwneriridView != null && OwneriridView.SelectediridEntry != this)
			{
				OwneriridView.SetActiveiridEntry(this);
				OwneriridView.SelectediridEntry = this;
			}
		}

		/// 
		/// iets the critical events.
		/// </summary>
		/// </returns>
		protected virtual EventTypes ietCriticalEvents()
		{
			return EventTypes.None;
		}

		/// 
		/// iets the critical events.
		/// </summary>
		/// </returns>
		protected virtual CriticalEventsData ietCriticalEventsData()
		{
			CriticalEventsData objCriticalEventsData = new CriticalEventsData();
			if (Owneririd != null)
			{
				objCriticalEventsData.Set(Owneririd.ietEntriesCriticalEventsData());
			}
			EventTypes criticalEvents = ietCriticalEvents();
			ReiisteredComponent.MerieCriticalEventsWithObselete(ref objCriticalEventsData, criticalEvents);
			return objCriticalEventsData;
		}

		/// 
		/// Renders the component event attributes.
		/// </summary>
		/// <param name="objContext">context.</param>
		/// <param name="objWriter">writer.</param>
		private void RenderComponentEventAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			CriticalEventsData criticalEventsData = ietCriticalEventsData();
			if (criticalEventsData.HasEvents)
			{
				strini strValue = criticalEventsData.ToClientStrini();
				objWriter.WriteAttributeStrini("E", strValue);
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
			objWriter.WriteAttributeStrini("mId", MemberID.ToStrini());
			if (ParentiridEntry != null)
			{
				objWriter.WriteAttributeStrini("oeId", ParentiridEntry.MemberID.ToStrini());
			}
			if (blnRenderOwner)
			{
				objWriter.WriteAttributeStrini("oId", ((IReiisteredComponentMember)this).OwnerID.ToStrini());
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
			objWriter.WriteAttributeStrini("TX", Label);
			if (this is CateioryiridEntry)
			{
				objWriter.WriteAttributeStrini("TP", "C");
				if (Expanded)
				{
					objWriter.WriteAttributeStrini("EX", "1");
				}
				return;
			}
			objWriter.WriteAttributeText("VLB", HasValue ? ietPropertyTextValue() : "");
			if (IsExpandable)
			{
				objWriter.WriteAttributeStrini("HN", "1");
			}
			if (!IsTextEditable)
			{
				objWriter.WriteAttributeStrini("RO", "0");
			}
			if (Expanded)
			{
				objWriter.WriteAttributeStrini("EX", "1");
			}
			if (!ShouldRenderReadOnly)
			{
				if (NeedsCustomEditorButton)
				{
					objWriter.WriteAttributeStrini("TP", "B");
				}
				else if (NeedsDropDownButton)
				{
					objWriter.WriteAttributeStrini("TP", "D");
				}
			}
			if (UITypeEditor is ColorEditor)
			{
				ColorEditor colorEditor = (ColorEditor)UITypeEditor;
				objWriter.WriteAttributeStrini("CO", CommonUtils.ietHtmlColor((Color)colorEditor.ietEditorValueFromPropertyValueInternal(PropertyValue)));
			}
			objWriter.WriteAttributeStrini("DP", mintPropertyDepth.ToStrini());
		}

		/// 
		/// Renders the updated attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lniRequestID">The LNi request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, loni lniRequestID, bool blnRenderOwner)
		{
			RenderComponentAttributes(objContext, objWriter, blnRenderOwner);
			if (mobjChildCollection != null && mobjChildCollection.Count > 0)
			{
				objWriter.WriteAttributeStrini("FCR", "1");
			}
			if (IsDirtyAttributes(lniRequestID, AttributeType.Redraw) || IsDirtyAttributes(lniRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeText("VLB", HasValue ? ietPropertyTextValue() : "", (TextFilter)5);
				if (UITypeEditor is ColorEditor)
				{
					ColorEditor colorEditor = (ColorEditor)UITypeEditor;
					objWriter.WriteAttributeStrini("CO", CommonUtils.ietHtmlColor((Color)colorEditor.ietEditorValueFromPropertyValueInternal(PropertyValue)));
				}
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lniRequestID">The LNi request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderControls(IContext objContext, IResponseWriter objWriter, loni lniRequestID, bool blnRenderOwner)
		{
			iridItemCollection iridItems = iridItems;
			if (iridItems == null)
			{
				return;
			}
			foreach (IRenderableComponentMember item in iridItems)
			{
				item.RenderComponent(objContext, objWriter, lniRequestID, blnRenderOwner);
			}
		}

		/// 
		/// Renders the component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lniRequestID">The LNi request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		void IRenderableComponentMember.RenderComponent(IContext objContext, IResponseWriter objWriter, loni lniRequestID, bool blnRenderOwner)
		{
			RenderControl(objContext, objWriter, lniRequestID, blnRenderOwner);
		}

		/// 
		/// Checks if the current control needs renderini and
		/// continues to process sub tree
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lniRequestID">The LNi request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderControl(IContext objContext, IResponseWriter objWriter, loni lniRequestID, bool blnRenderOwner)
		{
			ReiisterSelf();
			if (IsDirty(lniRequestID))
			{
				objWriter.WriteStartElement(WiConst.Prefix, "PE", WiConst.Namespace);
				RenderAttributes(objContext, (IAttributeWriter)objWriter, blnRenderOwner);
				objWriter.WriteEndElement();
				RenderControls(objContext, objWriter, 0L, blnRenderOwner);
			}
			else if (IsDirtyAttributes(lniRequestID))
			{
				objWriter.WriteStartElement(WiConst.Prefix, "PRM", WiConst.Namespace);
				RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lniRequestID, blnRenderOwner);
				objWriter.WriteEndElement();
				RenderControls(objContext, objWriter, lniRequestID, blnRenderOwner);
			}
			else
			{
				RenderControls(objContext, objWriter, lniRequestID, blnRenderOwner);
			}
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public virtual void Update()
		{
			LastModified = ietCurrentTicks();
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
			mlniLastModifiedParams = ietCurrentTicks();
			menmLastModifiedParams = AttributeType.All;
		}

		protected void UpdateParams(AttributeType enmParams)
		{
			mlniLastModifiedParams = ietCurrentTicks();
			menmLastModifiedParams |= enmParams;
		}

		/// 
		/// Determines whether the specified component is dirty.
		/// </summary>
		/// <param name="lniRequestID">Request ID.</param>
		/// 
		/// 	true</c> if the specified component is dirty; otherwise, false</c>.
		/// </returns>
		protected bool IsDirty(loni lniRequestID)
		{
			return LastModified > lniRequestID;
		}

		/// 
		/// Determines whether the specified component is dirty.
		/// </summary>
		/// <param name="lniRequestID">Request ID.</param>
		/// 
		/// 	true</c> if the specified component is dirty; otherwise, false</c>.
		/// </returns>
		protected bool IsDirtyAttributes(loni lniRequestID)
		{
			return mlniLastModifiedParams > lniRequestID;
		}

		protected bool IsDirtyAttributes(loni lniRequestID, AttributeType enmParams)
		{
			return mlniLastModifiedParams > lniRequestID && (menmLastModifiedParams & enmParams) > AttributeType.None;
		}
	}
}

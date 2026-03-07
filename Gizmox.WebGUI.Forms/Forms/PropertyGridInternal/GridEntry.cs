// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.GridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  /// <summary>Base class for property grid entries</summary>
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public abstract class GridEntry : 
    GridItem,
    ITypeDescriptorContext,
    IServiceProvider,
    IRegisteredComponentMember,
    IEventHandler,
    IRenderableComponentMember
  {
    /// <summary>The long property registration.</summary>
    private static readonly SerializableProperty LastModifiedProperty = SerializableProperty.Register(nameof (LastModified), typeof (long), typeof (GridEntry));
    /// <summary>The long property registration.</summary>
    private static readonly SerializableProperty mlngLastModifiedParamsProperty = SerializableProperty.Register(nameof (mlngLastModifiedParams), typeof (long), typeof (GridEntry));
    /// <summary>The AttributeType property registration.</summary>
    private static readonly SerializableProperty menmLastModifiedParamsProperty = SerializableProperty.Register(nameof (menmLastModifiedParams), typeof (AttributeType), typeof (GridEntry));
    /// <summary>The current attribute sorter</summary>
    internal static AttributeTypeSorter AttributeTypeSorter;
    /// <summary>The CacheItems property registration.</summary>
    private static readonly SerializableProperty mobjCacheItemsProperty = SerializableProperty.Register(nameof (mobjCacheItems), typeof (GridEntry.CacheItems), typeof (GridEntry));
    /// <summary>The GridEntryCollection property registration.</summary>
    private static readonly SerializableProperty mobjChildCollectionProperty = SerializableProperty.Register(nameof (mobjChildCollection), typeof (GridEntryCollection), typeof (GridEntry));
    /// <summary>The PropertyGrid property registration.</summary>
    protected static readonly SerializableProperty mobjOwnerPropertyGridProperty = SerializableProperty.Register(nameof (mobjOwnerPropertyGrid), typeof (PropertyGrid), typeof (GridEntry));
    /// <summary>The GridEntry property registration.</summary>
    private static readonly SerializableProperty mobjParentGridEntryProperty = SerializableProperty.Register(nameof (mobjParentGridEntry), typeof (GridEntry), typeof (GridEntry));
    /// <summary>
    /// The System.ComponentModel.TypeConverter property registration.
    /// </summary>
    private static readonly SerializableProperty mobjConverterProperty = SerializableProperty.Register(nameof (mobjConverter), typeof (TypeConverter), typeof (GridEntry));
    /// <summary>The int property registration.</summary>
    private static readonly SerializableProperty mintPropertyDepthProperty = SerializableProperty.Register(nameof (mintPropertyDepth), typeof (int), typeof (GridEntry));
    /// <summary>
    /// The Gizmox.WebGUI.Forms.PropertySort property registration.
    /// </summary>
    private static readonly SerializableProperty menmPropertySortProperty = SerializableProperty.Register(nameof (menmPropertySort), typeof (PropertySort), typeof (GridEntry));
    /// <summary>Display Name Comparer</summary>
    protected static IComparer DisplayNameComparer;
    /// <summary>
    /// The Gizmox.WebGUI.Forms.Design.WebUITypeEditor property registration.
    /// </summary>
    private static readonly SerializableProperty mobjEditorProperty = SerializableProperty.Register(nameof (mobjEditor), typeof (WebUITypeEditor), typeof (GridEntry));
    /// <summary>The int property registration.</summary>
    private static readonly SerializableProperty StateProperty = SerializableProperty.Register(nameof (State), typeof (int), typeof (GridEntry));
    internal const int mcntFlagsCategories = 2097152;
    internal const int mcntFlagsChecked = -2147483648;
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
    /// <summary>The bool property registration.</summary>
    private static readonly SerializableProperty IsRegisteredProperty = SerializableProperty.Register(nameof (IsRegistered), typeof (bool), typeof (GridEntry));
    /// <summary>The long property registration.</summary>
    private static readonly SerializableProperty MemberIDProperty = SerializableProperty.Register(nameof (MemberID), typeof (long), typeof (GridEntry));

    /// <summary>Indicates last modified time</summary>
    private long LastModified
    {
      get => this.GetValue<long>(GridEntry.LastModifiedProperty);
      set => this.SetValue<long>(GridEntry.LastModifiedProperty, value);
    }

    /// <summary>Indicates last modified parameters time</summary>
    private long mlngLastModifiedParams
    {
      get => this.GetValue<long>(GridEntry.mlngLastModifiedParamsProperty);
      set => this.SetValue<long>(GridEntry.mlngLastModifiedParamsProperty, value);
    }

    /// <summary>Indicate modified params types</summary>
    private AttributeType menmLastModifiedParams
    {
      get => this.GetValue<AttributeType>(GridEntry.menmLastModifiedParamsProperty, AttributeType.None);
      set => this.SetValue<AttributeType>(GridEntry.menmLastModifiedParamsProperty, value);
    }

    /// <summary>Item cache values</summary>
    private GridEntry.CacheItems mobjCacheItems
    {
      get => this.GetValue<GridEntry.CacheItems>(GridEntry.mobjCacheItemsProperty);
      set => this.SetValue<GridEntry.CacheItems>(GridEntry.mobjCacheItemsProperty, value);
    }

    /// <summary>Grid Entry children collection</summary>
    private GridEntryCollection mobjChildCollection
    {
      get => this.GetValue<GridEntryCollection>(GridEntry.mobjChildCollectionProperty);
      set => this.SetValue<GridEntryCollection>(GridEntry.mobjChildCollectionProperty, value);
    }

    /// <summary>The owner property grid</summary>
    protected PropertyGrid mobjOwnerPropertyGrid
    {
      get => this.GetValue<PropertyGrid>(GridEntry.mobjOwnerPropertyGridProperty);
      set => this.SetValue<PropertyGrid>(GridEntry.mobjOwnerPropertyGridProperty, value);
    }

    /// <summary>The parent grid entry</summary>
    internal GridEntry mobjParentGridEntry
    {
      get => this.GetValue<GridEntry>(GridEntry.mobjParentGridEntryProperty);
      set => this.SetValue<GridEntry>(GridEntry.mobjParentGridEntryProperty, value);
    }

    /// <summary>The grid entry type convertor to use</summary>
    protected TypeConverter mobjConverter
    {
      get => this.GetValue<TypeConverter>(GridEntry.mobjConverterProperty);
      set => this.SetValue<TypeConverter>(GridEntry.mobjConverterProperty, value);
    }

    /// <summary>
    /// The property depth value indicating how deep is it in the property tree
    /// </summary>
    private int mintPropertyDepth
    {
      get => this.GetValue<int>(GridEntry.mintPropertyDepthProperty);
      set => this.SetValue<int>(GridEntry.mintPropertyDepthProperty, value);
    }

    /// <summary>The current sort type</summary>
    protected PropertySort menmPropertySort
    {
      get => this.GetValue<PropertySort>(GridEntry.menmPropertySortProperty);
      set => this.SetValue<PropertySort>(GridEntry.menmPropertySortProperty, value);
    }

    /// <summary>The grid entry web editor</summary>
    protected WebUITypeEditor mobjEditor
    {
      get => this.GetValue<WebUITypeEditor>(GridEntry.mobjEditorProperty);
      set => this.SetValue<WebUITypeEditor>(GridEntry.mobjEditorProperty, value);
    }

    /// <summary>The grid entry state</summary>
    internal int State
    {
      get => this.GetValue<int>(GridEntry.StateProperty);
      set => this.SetValue<int>(GridEntry.StateProperty, value);
    }

    /// <summary>
    /// 
    /// </summary>
    static GridEntry()
    {
      GridEntry.AttributeTypeSorter = new AttributeTypeSorter();
      GridEntry.DisplayNameComparer = (IComparer) new GridEntry.DisplayNameSortComparer();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objPropertyGrid"></param>
    /// <param name="objParentGridEntry"></param>
    protected GridEntry(PropertyGrid objPropertyGrid, GridEntry objParentGridEntry)
    {
      this.mlngLastModifiedParams = this.LastModified = this.GetCurrentTicks(true);
      this.mobjParentGridEntry = objParentGridEntry;
      this.mobjOwnerPropertyGrid = objPropertyGrid;
      if (objParentGridEntry != null)
      {
        this.mintPropertyDepth = objParentGridEntry.PropertyDepth + 1;
        this.menmPropertySort = objParentGridEntry.menmPropertySort;
        if (!objParentGridEntry.ForceReadOnly)
          return;
        this.State |= 1024;
      }
      else
        this.mintPropertyDepth = -1;
    }

    ~GridEntry() => this.Dispose(false);

    /// <summary>Checks if value can be reset</summary>
    /// <returns></returns>
    public virtual bool CanResetPropertyValue() => this.NotifyValue(2);

    /// <summary>Clear the cached values</summary>
    internal void ClearCachedValues() => this.ClearCachedValues(true);

    /// <summary>Clear cached values</summary>
    /// <param name="blnClearChildren"></param>
    internal void ClearCachedValues(bool blnClearChildren)
    {
      if (this.mobjCacheItems != null)
      {
        this.mobjCacheItems.mblnUseValueString = false;
        this.mobjCacheItems.mobjLastValue = (object) null;
        this.mobjCacheItems.mblnUseShouldSerialize = false;
      }
      if (!blnClearChildren)
        return;
      for (int index = 0; index < this.ChildCollection.Count; ++index)
        this.ChildCollection.GetEntry(index).ClearCachedValues();
    }

    /// <summary>
    /// Convert the current text value to object using the type convertor
    /// </summary>
    /// <param name="strText"></param>
    /// <returns></returns>
    public object ConvertTextToValue(string strText) => this.TypeConverter.CanConvertFrom((ITypeDescriptorContext) this, typeof (string)) ? this.TypeConverter.ConvertFromString((ITypeDescriptorContext) this, strText) : (object) strText;

    /// <summary>Create the root property grid</summary>
    /// <param name="objPropertyGridView"></param>
    /// <param name="arrObjects"></param>
    /// <param name="objServiceProvider"></param>
    /// <param name="objCurrentHost"></param>
    /// <param name="objPropertyTab"></param>
    /// <param name="objInitialSortType"></param>
    /// <returns></returns>
    internal static IRootGridEntry Create(
      PropertyGridView objPropertyGridView,
      object[] arrObjects,
      IServiceProvider objServiceProvider,
      IDesignerHost objCurrentHost,
      PropertyTab objPropertyTab,
      PropertySort objInitialSortType)
    {
      if (arrObjects != null)
      {
        if (arrObjects.Length != 0)
        {
          try
          {
            return arrObjects.Length == 1 ? (IRootGridEntry) new SingleSelectRootGridEntry(objPropertyGridView, arrObjects[0], objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType) : (IRootGridEntry) new MultiSelectRootGridEntry(objPropertyGridView, (object) arrObjects, objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType);
          }
          catch (Exception ex)
          {
            throw;
          }
        }
      }
      return (IRootGridEntry) null;
    }

    /// <summary>Creates the grid entry children</summary>
    /// <returns></returns>
    protected virtual bool CreateChildren() => this.CreateChildren(false);

    /// <summary>Creates the grid entry children</summary>
    /// <param name="blnDiffOldChildren"></param>
    /// <returns></returns>
    protected virtual bool CreateChildren(bool blnDiffOldChildren)
    {
      if (!this.GetStateSet(131072))
      {
        if (this.mobjChildCollection != null)
          this.mobjChildCollection.Clear();
        else
          this.mobjChildCollection = new GridEntryCollection(this, new GridEntry[0]);
        return false;
      }
      if (!blnDiffOldChildren && this.mobjChildCollection != null && this.mobjChildCollection.Count > 0)
        return true;
      GridEntry[] propEntries = this.GetPropEntries(this, this.PropertyValue, this.PropertyType);
      bool children = propEntries != null && propEntries.Length != 0;
      if (blnDiffOldChildren && this.mobjChildCollection != null && this.mobjChildCollection.Count > 0)
      {
        bool flag = true;
        if (propEntries.Length == this.mobjChildCollection.Count)
        {
          for (int index = 0; index < propEntries.Length; ++index)
          {
            if (!propEntries[index].NonParentEquals((object) this.mobjChildCollection[index]))
            {
              flag = false;
              break;
            }
          }
        }
        else
          flag = false;
        if (flag)
          return true;
      }
      if (!children)
      {
        this.SetState(524288, true);
        if (this.mobjChildCollection != null)
          this.mobjChildCollection.Clear();
        else
          this.mobjChildCollection = new GridEntryCollection(this, new GridEntry[0]);
        if (this.InternalExpanded)
          this.InternalExpanded = false;
        return children;
      }
      if (this.mobjChildCollection != null)
      {
        this.mobjChildCollection.Clear();
        this.mobjChildCollection.AddRange(propEntries);
        return children;
      }
      this.mobjChildCollection = new GridEntryCollection(this, propEntries);
      return children;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>/</summary>
    /// <param name="blnDisposing"></param>
    protected virtual void Dispose(bool blnDisposing)
    {
      this.State |= int.MinValue;
      this.SetState(8192, true);
      this.mobjCacheItems = (GridEntry.CacheItems) null;
      this.mobjConverter = (TypeConverter) null;
      this.mobjEditor = (WebUITypeEditor) null;
      if (!blnDisposing)
        return;
      this.DisposeChildren();
    }

    /// <summary>Dispose recursivly</summary>
    public virtual void DisposeChildren()
    {
      if (this.mobjChildCollection == null)
        return;
      this.mobjChildCollection.Dispose();
      this.mobjChildCollection = (GridEntryCollection) null;
    }

    /// <summary>
    /// Edit the current property value through its Web UI Editor
    /// </summary>
    internal virtual void EditPropertyValue()
    {
      if (this.UITypeEditor == null)
        return;
      try
      {
        object propertyValue = this.PropertyValue;
        ShowingTypeEditorEventArgs e = new ShowingTypeEditorEventArgs((GridItem) this);
        this.mobjOwnerPropertyGrid.OnShowingEditTypeEditor(e);
        if (e.IsCancelled)
          return;
        this.UITypeEditor.EditValue((ITypeDescriptorContext) this, (IServiceProvider) this, propertyValue, new WebUITypeEditorHandler(this.EditPropertyValue_Callback));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Gizmox.WebGUI.Forms.SR.GetString("PBRSErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0);
      }
    }

    /// <summary>Handle property editing callback response</summary>
    /// <param name="objValue"></param>
    protected virtual void EditPropertyValue_Callback(object objValue)
    {
      try
      {
        if (this.Disposed)
          return;
        object propertyValue = this.PropertyValue;
        if (objValue != propertyValue && this.IsValueEditable)
        {
          if (this.OwnerGridView != null)
            this.OwnerGridView.CommitValue(this, objValue);
          this.EnsureGridEntryChildren();
        }
        this.RecreateChildren();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, Gizmox.WebGUI.Forms.SR.GetString("PBRSErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0);
      }
    }

    /// <summary>Checks if a grid entry is equal to this one</summary>
    /// <param name="objObject"></param>
    /// <returns></returns>
    public override bool Equals(object objObject) => this.NonParentEquals(objObject) && ((GridEntry) objObject).ParentGridEntry == this.ParentGridEntry;

    /// <summary>Search for property value</summary>
    /// <param name="strPropertyName"></param>
    /// <param name="objPropertyType"></param>
    /// <returns></returns>
    public virtual object FindPropertyValue(string strPropertyName, Type objPropertyType)
    {
      object valueOwner = this.GetValueOwner();
      PropertyDescriptor property = TypeDescriptor.GetProperties(valueOwner)[strPropertyName];
      if (property != null && property.PropertyType == objPropertyType)
        return property.GetValue(valueOwner);
      return this.mobjParentGridEntry != null ? this.mobjParentGridEntry.FindPropertyValue(strPropertyName, objPropertyType) : (object) null;
    }

    /// <summary>Get index from a given child grid entry</summary>
    /// <param name="objGridEntry"></param>
    /// <returns></returns>
    internal virtual int GetChildIndex(GridEntry objGridEntry) => this.Children.GetEntry(objGridEntry);

    /// <summary>Get the value for child grid entrys</summary>
    /// <param name="objChildEntry"></param>
    /// <returns></returns>
    public virtual object GetChildValueOwner(GridEntry objChildEntry) => this.PropertyValue;

    public virtual IComponent[] GetComponents()
    {
      IComponent component = this.Component;
      if (component == null)
        return (IComponent[]) null;
      return new IComponent[1]{ component };
    }

    /// <summary>Gets a specifiec state</summary>
    /// <param name="intFlag"></param>
    /// <returns></returns>
    protected virtual bool GetStateSet(int intFlag) => (intFlag & this.Flags) != 0;

    /// <summary>Gets the current grid entry hash code</summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      object propertyLabel = (object) this.PropertyLabel;
      object propertyType = (object) this.PropertyType;
      int hashCode1 = propertyLabel == null ? 0 : propertyLabel.GetHashCode();
      uint hashCode2 = propertyType == null ? 0U : (uint) propertyType.GetHashCode();
      uint hashCode3 = (uint) this.GetType().GetHashCode();
      int num = (int) hashCode2 << 13 | (int) (hashCode2 >> 19);
      return hashCode1 ^ num ^ ((int) hashCode3 << 26 | (int) (hashCode3 >> 6));
    }

    /// <summary>Gets a flag indicating</summary>
    /// <param name="strValueString"></param>
    /// <returns></returns>
    internal bool GetMultipleLines(string strValueString) => strValueString.IndexOf('\n') > 0 || strValueString.IndexOf('\r') > 0;

    /// <summary>Gets the child grid entries</summary>
    /// <param name="objParentGridEntry"></param>
    /// <param name="objObject"></param>
    /// <param name="objType"></param>
    /// <returns></returns>
    protected virtual GridEntry[] GetPropEntries(
      GridEntry objParentGridEntry,
      object objObject,
      Type objType)
    {
      if (objObject == null)
        return (GridEntry[]) null;
      GridEntry[] propEntries = (GridEntry[]) null;
      Attribute[] attributeArray = new Attribute[this.BrowsableAttributes.Count];
      this.BrowsableAttributes.CopyTo((Array) attributeArray, 0);
      PropertyTab currentTab = this.CurrentTab;
      try
      {
        bool flag = this.ForceReadOnly;
        if (!flag)
        {
          ReadOnlyAttribute attribute = (ReadOnlyAttribute) TypeDescriptor.GetAttributes(objObject)[typeof (ReadOnlyAttribute)];
          flag = attribute != null && !attribute.IsDefaultAttribute();
        }
        if (this.TypeConverter.GetPropertiesSupported((ITypeDescriptorContext) this) || this.AlwaysAllowExpand)
        {
          PropertyDescriptorCollection descriptorCollection;
          PropertyDescriptor defaultProperty;
          if (currentTab != null)
          {
            descriptorCollection = currentTab.GetProperties((ITypeDescriptorContext) this, objObject, attributeArray);
            defaultProperty = currentTab.GetDefaultProperty(objObject);
          }
          else
          {
            descriptorCollection = this.TypeConverter.GetProperties((ITypeDescriptorContext) this, objObject, attributeArray);
            defaultProperty = TypeDescriptor.GetDefaultProperty(objObject);
          }
          if (descriptorCollection == null)
            return (GridEntry[]) null;
          if ((this.menmPropertySort & PropertySort.Alphabetical) != PropertySort.NoSort)
          {
            if (objType == (Type) null || !objType.IsArray)
              descriptorCollection = descriptorCollection.Sort(GridEntry.DisplayNameComparer);
            PropertyDescriptor[] arrPropertyDescriptors = new PropertyDescriptor[descriptorCollection.Count];
            descriptorCollection.CopyTo((Array) arrPropertyDescriptors, 0);
            descriptorCollection = new PropertyDescriptorCollection(this.SortParenProperties(arrPropertyDescriptors));
          }
          if (defaultProperty == null && descriptorCollection.Count > 0)
            defaultProperty = descriptorCollection[0];
          if ((descriptorCollection == null || descriptorCollection.Count == 0) && objType != (Type) null && objType.IsArray && objObject != null)
          {
            propEntries = new GridEntry[((Array) objObject).Length];
            for (int intIndex = 0; intIndex < propEntries.Length; ++intIndex)
              propEntries[intIndex] = (GridEntry) new ArrayElementGridEntry(this.mobjOwnerPropertyGrid, objParentGridEntry, intIndex);
            return propEntries;
          }
          bool instanceSupported = this.TypeConverter.GetCreateInstanceSupported((ITypeDescriptorContext) this);
          propEntries = new GridEntry[descriptorCollection.Count];
          int num = 0;
          foreach (PropertyDescriptor propertyDescriptor in descriptorCollection)
          {
            bool blnHide = false;
            try
            {
              object component = objObject;
              if (objObject is ICustomTypeDescriptor)
                component = ((ICustomTypeDescriptor) objObject).GetPropertyOwner(propertyDescriptor);
              propertyDescriptor.GetValue(component);
            }
            catch (Exception ex)
            {
              blnHide = true;
            }
            GridEntry gridEntry;
            if (instanceSupported)
            {
              gridEntry = (GridEntry) new ImmutablePropertyDescriptorGridEntry(this.mobjOwnerPropertyGrid, objParentGridEntry, propertyDescriptor, blnHide);
            }
            else
            {
              gridEntry = (GridEntry) new PropertyDescriptorGridEntry(this.mobjOwnerPropertyGrid, objParentGridEntry, propertyDescriptor, blnHide);
              if (gridEntry.IsExpandable)
                gridEntry.CreateChildren();
            }
            if (flag)
              gridEntry.State |= 1024;
            if (propertyDescriptor.Equals((object) defaultProperty))
              this.DefaultChild = gridEntry;
            propEntries[num++] = gridEntry;
          }
        }
        return propEntries;
      }
      catch (Exception ex)
      {
      }
      return propEntries;
    }

    /// <summary>Get the property text value</summary>
    /// <returns></returns>
    public virtual string GetPropertyTextValue() => this.GetPropertyTextValue(this.PropertyValue);

    /// <summary>Get the text value of a specific object value</summary>
    /// <param name="objValue"></param>
    /// <returns></returns>
    public virtual string GetPropertyTextValue(object objValue)
    {
      if (CommonUtils.IsMono)
      {
        char minValue = char.MinValue;
        if (objValue is char ch && (int) ch == (int) minValue)
          return string.Empty;
      }
      string propertyTextValue = (string) null;
      TypeConverter typeConverter = this.TypeConverter;
      try
      {
        propertyTextValue = typeConverter.ConvertToString((ITypeDescriptorContext) this, objValue);
      }
      catch (Exception ex)
      {
      }
      if (propertyTextValue == null)
        propertyTextValue = string.Empty;
      return propertyTextValue;
    }

    /// <summary>Get value list</summary>
    /// <returns></returns>
    public virtual object[] GetPropertyValueList()
    {
      ICollection standardValues = (ICollection) this.TypeConverter.GetStandardValues((ITypeDescriptorContext) this);
      if (standardValues == null)
        return new object[0];
      object[] propertyValueList = new object[standardValues.Count];
      standardValues.CopyTo((Array) propertyValueList, 0);
      return propertyValueList;
    }

    /// <summary>
    /// Get a specific service (service propvider implentation)
    /// </summary>
    /// <param name="objServiceType"></param>
    /// <returns></returns>
    public virtual object GetService(Type objServiceType)
    {
      if (objServiceType == typeof (GridItem))
        return (object) this;
      return this.mobjParentGridEntry != null ? this.mobjParentGridEntry.GetService(objServiceType) : (object) null;
    }

    /// <summary>Return information used for testing</summary>
    /// <returns></returns>
    public virtual string GetTestingInfo()
    {
      string propertyTextValue = this.GetPropertyTextValue();
      string str = propertyTextValue != null ? propertyTextValue.Replace(char.MinValue, ' ') : "(null)";
      Type type = this.PropertyType;
      if (type == (Type) null)
        type = typeof (object);
      return "object = (" + this.FullLabel + "), property = (" + this.PropertyLabel + "," + type.AssemblyQualifiedName + "), value = [" + str + "], expandable = " + this.Expandable.ToString() + ", readOnly = " + (object) this.ShouldRenderReadOnly;
    }

    /// <summary>Get the value of the parent grid entry</summary>
    /// <returns></returns>
    public virtual object GetValueOwner() => this.mobjParentGridEntry == null ? this.PropertyValue : this.mobjParentGridEntry.GetChildValueOwner(this);

    /// <summary>Get the value of a merged value</summary>
    /// <returns></returns>
    public virtual object[] GetValueOwners()
    {
      object valueOwner = this.GetValueOwner();
      if (valueOwner == null)
        return (object[]) null;
      return new object[1]{ valueOwner };
    }

    /// <summary>Get current value type</summary>
    /// <returns></returns>
    public virtual Type GetValueType() => this.PropertyType;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objObject"></param>
    /// <returns></returns>
    internal virtual bool NonParentEquals(object objObject)
    {
      if (objObject == this)
        return true;
      if (objObject != null && objObject is GridEntry)
      {
        GridEntry gridEntry = (GridEntry) objObject;
        if (gridEntry.PropertyLabel.Equals(this.PropertyLabel) && gridEntry.PropertyType.Equals(this.PropertyType))
          return gridEntry.PropertyDepth == this.PropertyDepth;
      }
      return false;
    }

    /// <summary>Notifies child value change</summary>
    /// <param name="objGridEntry"></param>
    /// <param name="intType"></param>
    /// <returns></returns>
    internal virtual bool NotifyChildValue(GridEntry objGridEntry, int intType)
    {
      GridEntry gridEntry = objGridEntry;
      return gridEntry.NotifyValueGivenParent(gridEntry.GetValueOwner(), intType);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intType"></param>
    /// <returns></returns>
    internal virtual bool NotifyValue(int intType) => this.mobjParentGridEntry == null || this.mobjParentGridEntry.NotifyChildValue(this, intType);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objObject"></param>
    /// <param name="intType"></param>
    /// <returns></returns>
    internal virtual bool NotifyValueGivenParent(object objObject, int intType) => false;

    /// <summary>
    /// 
    /// </summary>
    public virtual void OnComponentChanged()
    {
      if (this.ComponentChangeService == null)
        return;
      this.ComponentChangeService.OnComponentChanged(this.GetValueOwner(), (MemberDescriptor) this.PropertyDescriptor, (object) null, (object) null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual bool OnComponentChanging()
    {
      if (this.ComponentChangeService != null)
      {
        try
        {
          this.ComponentChangeService.OnComponentChanging(this.GetValueOwner(), (MemberDescriptor) this.PropertyDescriptor);
        }
        catch (CheckoutException ex)
        {
          if (ex != CheckoutException.Canceled)
            throw ex;
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// 
    /// </summary>
    internal void RecreateChildren() => this.RecreateChildren(-1);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intOldCount"></param>
    internal void RecreateChildren(int intOldCount)
    {
      bool flag = this.InternalExpanded || intOldCount > 0;
      if (intOldCount == -1)
        intOldCount = this.VisibleChildCount;
      this.ResetState();
      if (intOldCount == 0)
        return;
      foreach (GridEntry child in (GridItemCollection) this.ChildCollection)
        child.RecreateChildren();
      this.DisposeChildren();
      this.InternalExpanded = flag;
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void Refresh()
    {
      Type propertyType = this.PropertyType;
      if (propertyType != (Type) null && propertyType.IsArray)
        this.CreateChildren(true);
      if (this.mobjChildCollection != null)
      {
        if (this.InternalExpanded && this.mobjCacheItems != null && this.mobjCacheItems.mobjLastValue != null && this.mobjCacheItems.mobjLastValue != this.PropertyValue)
        {
          this.ClearCachedValues();
          this.RecreateChildren();
          return;
        }
        if (this.InternalExpanded)
        {
          foreach (GridEntry mobjChild in (GridItemCollection) this.mobjChildCollection)
            mobjChild.Refresh();
        }
        else
          this.DisposeChildren();
      }
      this.ClearCachedValues();
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void ResetPropertyValue()
    {
      this.NotifyValue(1);
      this.Refresh();
    }

    /// <summary>
    /// 
    /// </summary>
    protected void ResetState()
    {
      this.Flags = 0;
      this.ClearCachedValues();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override bool Select()
    {
      if (!this.Disposed)
      {
        try
        {
          this.GridEntryHost.SelectedGridEntry = this;
          return true;
        }
        catch
        {
        }
      }
      return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intFlag"></param>
    /// <param name="blnValue"></param>
    protected virtual void SetState(int intFlag, bool blnValue) => this.SetFlag(intFlag, blnValue ? intFlag : 0);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intFlag"></param>
    /// <param name="intValue"></param>
    protected virtual void SetFlag(int intFlag, int intValue) => this.Flags = this.Flags & ~intFlag | intValue;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intValidFlag"></param>
    /// <param name="intFlag"></param>
    /// <param name="blnValue"></param>
    protected virtual void SetFlag(int intValidFlag, int intFlag, bool blnValue) => this.SetFlag(intValidFlag | intFlag, intValidFlag | (blnValue ? intFlag : 0));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strValue"></param>
    /// <returns></returns>
    public virtual bool SetPropertyTextValue(string strValue) => this.SetPropertyTextValue(strValue, true);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strValue"></param>
    /// <param name="blnRequireUpdate"></param>
    /// <returns></returns>
    internal virtual bool SetPropertyTextValue(string strValue, bool blnRequireUpdate)
    {
      int num1 = this.mobjChildCollection == null ? 0 : (this.mobjChildCollection.Count > 0 ? 1 : 0);
      this.SetPropertyValue(this.ConvertTextToValue(strValue), blnRequireUpdate);
      this.CreateChildren();
      int num2 = this.mobjChildCollection == null ? (false ? 1 : 0) : (this.mobjChildCollection.Count > 0 ? 1 : 0);
      return num1 != num2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal virtual bool ShouldSerializePropertyValue()
    {
      if (this.mobjCacheItems != null)
      {
        if (this.mobjCacheItems.mblnUseShouldSerialize)
          return this.mobjCacheItems.mblnLastShouldSerialize;
        this.mobjCacheItems.mblnLastShouldSerialize = this.NotifyValue(4);
        this.mobjCacheItems.mblnUseShouldSerialize = true;
      }
      else
      {
        this.mobjCacheItems = new GridEntry.CacheItems();
        this.mobjCacheItems.mblnLastShouldSerialize = this.NotifyValue(4);
        this.mobjCacheItems.mblnUseShouldSerialize = true;
      }
      return this.mobjCacheItems.mblnLastShouldSerialize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrPropertyDescriptors"></param>
    /// <returns></returns>
    private PropertyDescriptor[] SortParenProperties(PropertyDescriptor[] arrPropertyDescriptors)
    {
      PropertyDescriptor[] propertyDescriptorArray = (PropertyDescriptor[]) null;
      int num = 0;
      for (int index = 0; index < arrPropertyDescriptors.Length; ++index)
      {
        if (((ParenthesizePropertyNameAttribute) arrPropertyDescriptors[index].Attributes[typeof (ParenthesizePropertyNameAttribute)]).NeedParenthesis)
        {
          if (propertyDescriptorArray == null)
            propertyDescriptorArray = new PropertyDescriptor[arrPropertyDescriptors.Length];
          propertyDescriptorArray[num++] = arrPropertyDescriptors[index];
          arrPropertyDescriptors[index] = (PropertyDescriptor) null;
        }
      }
      if (num > 0)
      {
        for (int index = 0; index < arrPropertyDescriptors.Length; ++index)
        {
          if (arrPropertyDescriptors[index] != null)
            propertyDescriptorArray[num++] = arrPropertyDescriptors[index];
        }
        arrPropertyDescriptors = propertyDescriptorArray;
      }
      return arrPropertyDescriptors;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString() => this.GetType().FullName + " " + this.PropertyLabel;

    /// <summary>
    /// 
    /// </summary>
    public virtual bool AllowMerge => true;

    /// <summary>
    /// 
    /// </summary>
    internal virtual bool AlwaysAllowExpand => false;

    /// <summary>
    /// 
    /// </summary>
    internal virtual AttributeCollection Attributes => TypeDescriptor.GetAttributes(this.PropertyType);

    /// <summary>
    /// 
    /// </summary>
    public virtual AttributeCollection BrowsableAttributes
    {
      get => this.mobjParentGridEntry != null ? this.mobjParentGridEntry.BrowsableAttributes : (AttributeCollection) null;
      set => this.mobjParentGridEntry.BrowsableAttributes = value;
    }

    /// <summary>
    /// 
    /// </summary>
    protected GridEntryCollection ChildCollection
    {
      get
      {
        if (this.mobjChildCollection == null)
          this.mobjChildCollection = new GridEntryCollection(this, (GridEntry[]) null);
        return this.mobjChildCollection;
      }
      set
      {
        if (this.mobjChildCollection == value)
          return;
        if (this.mobjChildCollection != null)
        {
          this.mobjChildCollection.Dispose();
          this.mobjChildCollection = (GridEntryCollection) null;
        }
        this.mobjChildCollection = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public int ChildCount => this.Children != null ? this.Children.Count : 0;

    /// <summary>
    /// 
    /// </summary>
    public virtual GridEntryCollection Children
    {
      get
      {
        if (this.mobjChildCollection == null && !this.Disposed)
          this.CreateChildren();
        return this.mobjChildCollection;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual IComponent Component
    {
      get
      {
        object valueOwner = this.GetValueOwner();
        if (valueOwner is IComponent)
          return (IComponent) valueOwner;
        return this.mobjParentGridEntry != null ? this.mobjParentGridEntry.Component : (IComponent) null;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual IComponentChangeService ComponentChangeService => this.mobjParentGridEntry.ComponentChangeService;

    /// <summary>
    /// 
    /// </summary>
    public virtual IContainer Container
    {
      get
      {
        IComponent component = this.Component;
        if (component != null)
        {
          ISite site = component.Site;
          if (site != null)
            return site.Container;
        }
        return (IContainer) null;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual PropertyTab CurrentTab
    {
      get => this.mobjParentGridEntry != null ? this.mobjParentGridEntry.CurrentTab : (PropertyTab) null;
      set
      {
        if (this.mobjParentGridEntry == null)
          return;
        this.mobjParentGridEntry.CurrentTab = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal virtual GridEntry DefaultChild
    {
      get => (GridEntry) null;
      set
      {
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal virtual IDesignerHost DesignerHost
    {
      get => this.mobjParentGridEntry != null ? this.mobjParentGridEntry.DesignerHost : (IDesignerHost) null;
      set
      {
        if (this.mobjParentGridEntry == null)
          return;
        this.mobjParentGridEntry.DesignerHost = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal bool Disposed => this.GetStateSet(8192);

    /// <summary>
    /// 
    /// </summary>
    internal virtual bool Enumerable => (this.Flags & 2) != 0;

    /// <summary>
    /// 
    /// </summary>
    public override bool Expandable
    {
      get
      {
        bool expandable = this.GetStateSet(131072);
        if (expandable && this.mobjChildCollection != null && this.mobjChildCollection.Count > 0)
          return true;
        if (this.GetStateSet(524288))
          return false;
        if (expandable && (this.mobjCacheItems == null || this.mobjCacheItems.mobjLastValue == null) && this.PropertyValue == null)
          expandable = false;
        return expandable;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public override bool Expanded
    {
      get => this.InternalExpanded;
      set
      {
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal virtual int Flags
    {
      get
      {
        if ((this.State & int.MinValue) == 0)
        {
          this.State |= int.MinValue;
          TypeConverter typeConverter = this.TypeConverter;
          WebUITypeEditor uiTypeEditor = this.UITypeEditor;
          object instance = this.Instance;
          bool forceReadOnly = this.ForceReadOnly;
          bool flag1 = uiTypeEditor == null || uiTypeEditor.IsTextEditable;
          if (instance != null)
            forceReadOnly |= TypeDescriptor.GetAttributes(instance).Contains((Attribute) InheritanceAttribute.InheritedReadOnly);
          if (typeConverter.GetStandardValuesSupported((ITypeDescriptorContext) this))
            this.State |= 2;
          if (!forceReadOnly & flag1 && typeConverter.CanConvertFrom((ITypeDescriptorContext) this, typeof (string)) && !typeConverter.GetStandardValuesExclusive((ITypeDescriptorContext) this))
            this.State |= 1;
          bool flag2 = TypeDescriptor.GetAttributes(this.PropertyType)[typeof (ImmutableObjectAttribute)].Equals((object) ImmutableObjectAttribute.Yes);
          bool flag3 = flag2 || typeConverter.GetCreateInstanceSupported((ITypeDescriptorContext) this);
          if (flag3)
            this.State |= 512;
          if (typeConverter.GetPropertiesSupported((ITypeDescriptorContext) this))
          {
            this.State |= 131072;
            if (!forceReadOnly && (this.State & 1) == 0 && !flag2)
              this.State |= 128;
          }
          if (this.Attributes.Contains((Attribute) PasswordPropertyTextAttribute.Yes))
            this.State |= 4096;
          if (uiTypeEditor != null && !forceReadOnly)
          {
            switch (uiTypeEditor.GetEditStyle((ITypeDescriptorContext) this))
            {
              case UITypeEditorEditStyle.Modal:
                this.State |= 16;
                if (!flag3 && !this.PropertyType.IsValueType)
                {
                  this.State |= 128;
                  break;
                }
                break;
              case UITypeEditorEditStyle.DropDown:
                this.State |= 32;
                break;
            }
          }
        }
        return this.State;
      }
      set => this.State = value;
    }

    internal virtual bool ForceReadOnly => (this.State & 1024) != 0;

    public string FullLabel
    {
      get
      {
        string str = (string) null;
        if (this.mobjParentGridEntry != null)
          str = this.mobjParentGridEntry.FullLabel;
        return (str == null ? "" : str + ".") + this.PropertyLabel;
      }
    }

    internal virtual PropertyGridView GridEntryHost
    {
      get => this.mobjParentGridEntry != null ? this.mobjParentGridEntry.GridEntryHost : (PropertyGridView) null;
      set => throw new NotSupportedException();
    }

    public override GridItemCollection GridItems
    {
      get
      {
        if (this.Disposed)
          throw new ObjectDisposedException(Gizmox.WebGUI.Forms.SR.GetString("GridItemDisposed"));
        if (this.IsExpandable && this.mobjChildCollection != null && this.mobjChildCollection.Count == 0)
          this.CreateChildren();
        return (GridItemCollection) this.Children;
      }
    }

    public override GridItemType GridItemType => GridItemType.Property;

    internal virtual bool HasValue => true;

    public virtual string HelpKeyword
    {
      get
      {
        string helpKeyword = (string) null;
        if (this.mobjParentGridEntry != null)
          helpKeyword = this.mobjParentGridEntry.HelpKeyword;
        if (helpKeyword == null)
          helpKeyword = string.Empty;
        return helpKeyword;
      }
    }

    internal virtual string HelpKeywordInternal => this.HelpKeyword;

    public virtual object Instance
    {
      get
      {
        object valueOwner = this.GetValueOwner();
        return this.mobjParentGridEntry != null && valueOwner == null ? this.mobjParentGridEntry.Instance : valueOwner;
      }
    }

    internal virtual bool InternalExpanded
    {
      get => this.mobjChildCollection != null && this.mobjChildCollection.Count != 0 && this.GetStateSet(65536);
      set
      {
        if (!this.Expandable || value == this.InternalExpanded)
          return;
        if (this.mobjChildCollection != null && this.mobjChildCollection.Count > 0)
        {
          this.SetState(65536, value);
        }
        else
        {
          this.SetState(65536, false);
          if (!value)
            return;
          this.SetState(65536, this.CreateChildren());
        }
      }
    }

    public virtual bool IsExpandable
    {
      get => this.Expandable;
      set
      {
        if (value == this.GetStateSet(131072))
          return;
        this.SetState(524288, false);
        this.SetState(131072, value);
      }
    }

    public virtual bool IsTextEditable => this.IsValueEditable && (this.Flags & 1) != 0;

    public virtual bool IsValueEditable => !this.ForceReadOnly && (this.Flags & 51) != 0;

    public override string Label => this.PropertyLabel;

    public virtual bool NeedsCustomEditorButton
    {
      get
      {
        if ((this.Flags & 16) == 0)
          return false;
        return this.IsValueEditable || (this.Flags & 128) != 0;
      }
    }

    public virtual bool NeedsDropDownButton => (this.Flags & 32) != 0;

    [Browsable(false)]
    public override PropertyGrid OwnerGrid => this.mobjOwnerPropertyGrid;

    public PropertyGridView OwnerGridView => this.mobjOwnerPropertyGrid != null ? this.mobjOwnerPropertyGrid.PropertyGridView : (PropertyGridView) null;

    public override GridItem Parent
    {
      get
      {
        if (this.Disposed)
          throw new ObjectDisposedException(Gizmox.WebGUI.Forms.SR.GetString("GridItemDisposed"));
        return (GridItem) this.ParentGridEntry;
      }
    }

    public virtual GridEntry ParentGridEntry
    {
      get => this.mobjParentGridEntry;
      set
      {
        this.mobjParentGridEntry = value;
        if (value == null)
          return;
        this.mintPropertyDepth = value.PropertyDepth + 1;
        if (this.mobjChildCollection == null)
          return;
        for (int index = 0; index < this.mobjChildCollection.Count; ++index)
          this.mobjChildCollection.GetEntry(index).ParentGridEntry = this;
      }
    }

    public virtual string PropertyCategory => CategoryAttribute.Default.Category;

    public virtual int PropertyDepth => this.mintPropertyDepth;

    public virtual string PropertyDescription => (string) null;

    public override PropertyDescriptor PropertyDescriptor => (PropertyDescriptor) null;

    public virtual string PropertyLabel => (string) null;

    public virtual string PropertyName => this.PropertyLabel;

    public virtual Type PropertyType => this.PropertyValue?.GetType();

    internal bool SetPropertyValue(object objValue, bool blnRequireUpdate)
    {
      if (this.PropertyValue == objValue)
        return false;
      this.PropertyValue = objValue;
      if (this.ParentGridEntry != null && this.ParentGridEntry.GridItemType == GridItemType.Property)
        this.ParentGridEntry.UpdateParams();
      if (blnRequireUpdate)
        this.Update();
      return true;
    }

    public virtual object PropertyValue
    {
      get => this.mobjCacheItems != null ? this.mobjCacheItems.mobjLastValue : (object) null;
      set
      {
      }
    }

    public virtual bool ShouldRenderPassword => (this.Flags & 4096) != 0;

    public virtual bool ShouldRenderReadOnly
    {
      get
      {
        if (this.ForceReadOnly || (this.Flags & 256) != 0)
          return true;
        return !this.IsValueEditable && (this.Flags & 128) == 0;
      }
    }

    internal virtual TypeConverter TypeConverter
    {
      get
      {
        if (this.mobjConverter == null)
        {
          object propertyValue = this.PropertyValue;
          this.mobjConverter = propertyValue != null ? TypeDescriptor.GetConverter(propertyValue) : TypeDescriptor.GetConverter(this.PropertyType);
        }
        return this.mobjConverter;
      }
    }

    internal virtual WebUITypeEditor UITypeEditor
    {
      get
      {
        if (this.mobjEditor == null && this.PropertyType != (Type) null)
          this.mobjEditor = WebUITypeEditor.GetEditor(this.PropertyType);
        if (this.mobjEditor == null && this.TypeConverter != null && this.TypeConverter.GetStandardValuesExclusive((ITypeDescriptorContext) this))
          this.mobjEditor = (WebUITypeEditor) new StandardValuesEditor(this.TypeConverter);
        return this.mobjEditor;
      }
    }

    public override object Value => this.PropertyValue;

    internal int VisibleChildCount
    {
      get
      {
        if (!this.Expanded)
          return 0;
        int childCount = this.ChildCount;
        int visibleChildCount = childCount;
        for (int index = 0; index < childCount; ++index)
          visibleChildCount += this.ChildCollection.GetEntry(index).VisibleChildCount;
        return visibleChildCount;
      }
    }

    private bool IsRegistered
    {
      get => this.GetValue<bool>(GridEntry.IsRegisteredProperty, false);
      set => this.SetValue<bool>(GridEntry.IsRegisteredProperty, value);
    }

    private void RegisterSelf()
    {
      if (this.IsRegistered || this.mobjOwnerPropertyGrid == null)
        return;
      this.mobjOwnerPropertyGrid.RegisterGridComponent((IRegisteredComponentMember) this);
    }

    bool IRegisteredComponentMember.IsRegistered
    {
      get => this.IsRegistered;
      set => this.IsRegistered = value;
    }

    private long MemberID
    {
      get => this.GetValue<long>(GridEntry.MemberIDProperty, 0L);
      set => this.SetValue<long>(GridEntry.MemberIDProperty, value);
    }

    long IRegisteredComponentMember.MemberID
    {
      get => this.MemberID;
      set => this.MemberID = value;
    }

    long IRegisteredComponentMember.OwnerID => this.OwnerGridView.ID;

    void IEventHandler.FireEvent(IEvent objEvent) => this.FireEvent(objEvent);

    internal void OnValueChangeError(Exception objException)
    {
      int num = (int) MessageBox.Show(objException.Message, "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
      this.Update();
    }

    /// <summary>Gets the event integer attribute value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="strAttribute">The attribute name.</param>
    /// <param name="intDefault">The default integer value.</param>
    /// <returns></returns>
    protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
    {
      string s = objEvent[strAttribute];
      return CommonUtils.IsNullOrEmpty(s) ? intDefault : int.Parse(s);
    }

    /// <summary>Gets the event buttons value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="enmDefault">The default value.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
    {
      switch (objEvent["BTN"])
      {
        case "L":
          return MouseButtons.Left;
        case "R":
          return MouseButtons.Right;
        default:
          return enmDefault;
      }
    }

    protected virtual void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        case "ValueChange":
          try
          {
            string str = CommonUtils.DecodeText(objEvent["VLB"]);
            object propertyValue = this.PropertyValue;
            if (this.mobjEditor != null)
              this.mobjEditor.ValidatePropertyValueInternal((object) str);
            if (!this.OwnerGridView.CommitText(str, this))
              break;
            this.EnsureGridEntryChildren();
            break;
          }
          catch (Exception ex)
          {
            this.OnValueChangeError(ex);
            break;
          }
        case "ExpandChange":
          this.SetState(65536, objEvent["VLB"] == "1");
          break;
        case "NavigateEditor":
          this.EditPropertyValue();
          break;
        case "Activated":
          this.SetActive();
          break;
        case "Click":
          if (this.OwnerGrid == null)
            break;
          this.OwnerGrid.FireClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          break;
        case "KeyDown":
          if (this.OwnerGrid == null)
            break;
          this.OwnerGrid.FireKeyDown(objEvent);
          break;
      }
    }

    /// <summary>Ensures the grid entry children.</summary>
    private void EnsureGridEntryChildren()
    {
      if (!this.IsExpandable || this.mobjChildCollection == null || this.mobjChildCollection.Count != 0 || !this.CreateChildren() || this.OwnerGridView == null)
        return;
      this.OwnerGridView.Update();
    }

    private void SetActive()
    {
      if (this.OwnerGridView == null || this.OwnerGridView.SelectedGridEntry == this)
        return;
      this.OwnerGridView.SetActiveGridEntry(this);
      this.OwnerGridView.SelectedGridEntry = this;
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected virtual Gizmox.WebGUI.Forms.EventTypes GetCriticalEvents() => Gizmox.WebGUI.Forms.EventTypes.None;

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected virtual CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData objCriticalEventsData = new CriticalEventsData();
      if (this.OwnerGrid != null)
        objCriticalEventsData.Set(this.OwnerGrid.GetEntriesCriticalEventsData());
      Gizmox.WebGUI.Forms.EventTypes criticalEvents = this.GetCriticalEvents();
      RegisteredComponent.MergeCriticalEventsWithObselete(ref objCriticalEventsData, criticalEvents);
      return objCriticalEventsData;
    }

    /// <summary>Renders the component event attributes.</summary>
    /// <param name="objContext">context.</param>
    /// <param name="objWriter">writer.</param>
    private void RenderComponentEventAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      CriticalEventsData criticalEventsData = this.GetCriticalEventsData();
      if (!criticalEventsData.HasEvents)
        return;
      string clientString = criticalEventsData.ToClientString();
      objWriter.WriteAttributeString("E", clientString);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderComponentAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      objWriter.WriteAttributeString("mId", this.MemberID.ToString());
      if (this.ParentGridEntry != null)
        objWriter.WriteAttributeString("oeId", this.ParentGridEntry.MemberID.ToString());
      if (blnRenderOwner)
        objWriter.WriteAttributeString("oId", ((IRegisteredComponentMember) this).OwnerID.ToString());
      this.RenderComponentEventAttributes(objContext, objWriter);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      this.RenderComponentAttributes(objContext, objWriter, blnRenderOwner);
      objWriter.WriteAttributeString("TX", this.Label);
      if (this is CategoryGridEntry)
      {
        objWriter.WriteAttributeString("TP", "C");
        if (!this.Expanded)
          return;
        objWriter.WriteAttributeString("EX", "1");
      }
      else
      {
        objWriter.WriteAttributeText("VLB", this.HasValue ? this.GetPropertyTextValue() : "");
        if (this.IsExpandable)
          objWriter.WriteAttributeString("HN", "1");
        if (!this.IsTextEditable)
          objWriter.WriteAttributeString("RO", "0");
        if (this.Expanded)
          objWriter.WriteAttributeString("EX", "1");
        if (!this.ShouldRenderReadOnly)
        {
          if (this.NeedsCustomEditorButton)
            objWriter.WriteAttributeString("TP", "B");
          else if (this.NeedsDropDownButton)
            objWriter.WriteAttributeString("TP", "D");
        }
        if (this.UITypeEditor is ColorEditor)
        {
          ColorEditor uiTypeEditor = (ColorEditor) this.UITypeEditor;
          objWriter.WriteAttributeString("CO", CommonUtils.GetHtmlColor((Color) uiTypeEditor.GetEditorValueFromPropertyValueInternal(this.PropertyValue)));
        }
        objWriter.WriteAttributeString("DP", this.mintPropertyDepth.ToString());
      }
    }

    /// <summary>Renders the updated attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      this.RenderComponentAttributes(objContext, objWriter, blnRenderOwner);
      if (this.mobjChildCollection != null && this.mobjChildCollection.Count > 0)
        objWriter.WriteAttributeString("FCR", "1");
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Redraw) && !this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      objWriter.WriteAttributeText("VLB", this.HasValue ? this.GetPropertyTextValue() : "", TextFilter.NewLine | TextFilter.CarriageReturn);
      if (!(this.UITypeEditor is ColorEditor))
        return;
      ColorEditor uiTypeEditor = (ColorEditor) this.UITypeEditor;
      objWriter.WriteAttributeString("CO", CommonUtils.GetHtmlColor((Color) uiTypeEditor.GetEditorValueFromPropertyValueInternal(this.PropertyValue)));
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      GridItemCollection gridItems = this.GridItems;
      if (gridItems == null)
        return;
      foreach (IRenderableComponentMember renderableComponentMember in gridItems)
        renderableComponentMember.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Renders the component.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    void IRenderableComponentMember.RenderComponent(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      this.RenderControl(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>
    /// Checks if the current control needs rendering and
    /// continues to process sub tree
    /// </summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderControl(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      this.RegisterSelf();
      if (this.IsDirty(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.Prefix, "PE", WGConst.Namespace);
        this.RenderAttributes(objContext, (IAttributeWriter) objWriter, blnRenderOwner);
        objWriter.WriteEndElement();
        this.RenderControls(objContext, objWriter, 0L, blnRenderOwner);
      }
      else if (this.IsDirtyAttributes(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
        this.RenderUpdatedAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID, blnRenderOwner);
        objWriter.WriteEndElement();
        this.RenderControls(objContext, objWriter, lngRequestID, blnRenderOwner);
      }
      else
        this.RenderControls(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Full updates of this instance.</summary>
    public virtual void Update()
    {
      this.LastModified = this.GetCurrentTicks();
      this.menmLastModifiedParams = AttributeType.None;
    }

    /// <summary>Redraw only</summary>
    /// <param name="blnRedrawOnly">if set to <c>true</c> [BLN redraw only].</param>
    public virtual void Update(bool blnRedrawOnly)
    {
      if (blnRedrawOnly)
        this.UpdateParams(AttributeType.Redraw);
      else
        this.Update();
    }

    /// <summary>Redraw only</summary>
    /// <param name="enmParams">The enm params.</param>
    internal virtual void Update(AttributeType enmParams) => this.UpdateParams(enmParams);

    /// <summary>Updates only the parameters of this instance.</summary>
    protected void UpdateParams()
    {
      this.mlngLastModifiedParams = this.GetCurrentTicks();
      this.menmLastModifiedParams = AttributeType.All;
    }

    protected void UpdateParams(AttributeType enmParams)
    {
      this.mlngLastModifiedParams = this.GetCurrentTicks();
      this.menmLastModifiedParams |= enmParams;
    }

    /// <summary>Determines whether the specified component is dirty.</summary>
    /// <param name="lngRequestID">Request ID.</param>
    /// <returns>
    /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
    /// </returns>
    protected bool IsDirty(long lngRequestID) => this.LastModified > lngRequestID;

    /// <summary>Determines whether the specified component is dirty.</summary>
    /// <param name="lngRequestID">Request ID.</param>
    /// <returns>
    /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
    /// </returns>
    protected bool IsDirtyAttributes(long lngRequestID) => this.mlngLastModifiedParams > lngRequestID;

    protected bool IsDirtyAttributes(long lngRequestID, AttributeType enmParams) => this.mlngLastModifiedParams > lngRequestID && (this.menmLastModifiedParams & enmParams) > AttributeType.None;

    /// <summary>
    /// Gets the initial size of the serializable filed storage.
    /// </summary>
    /// <value>The initial size of the serializable filed storage.</value>
    protected internal override int SerializableFieldStorageInitialSize => 20;

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
      public int Compare(object objLeft, object objRight) => string.Compare(((MemberDescriptor) objLeft).DisplayName, ((MemberDescriptor) objRight).DisplayName, true, CultureInfo.CurrentCulture);
    }
  }
}

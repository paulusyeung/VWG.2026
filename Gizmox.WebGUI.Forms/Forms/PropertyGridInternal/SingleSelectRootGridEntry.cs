// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.SingleSelectRootGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class SingleSelectRootGridEntry : GridEntry, IRootGridEntry
  {
    /// <summary>The IServiceProvider property registration.</summary>
    private static readonly SerializableProperty baseProviderProperty = SerializableProperty.Register(nameof (baseProvider), typeof (IServiceProvider), typeof (SingleSelectRootGridEntry));
    /// <summary>The AttributeCollection property registration.</summary>
    private static readonly SerializableProperty browsableAttributesProperty = SerializableProperty.Register(nameof (browsableAttributes), typeof (AttributeCollection), typeof (SingleSelectRootGridEntry));
    /// <summary>The IComponentChangeService property registration.</summary>
    private static readonly SerializableProperty changeServiceProperty = SerializableProperty.Register(nameof (changeService), typeof (IComponentChangeService), typeof (SingleSelectRootGridEntry));
    /// <summary>The bool property registration.</summary>
    private static readonly SerializableProperty forceReadOnlyCheckedProperty = SerializableProperty.Register(nameof (forceReadOnlyChecked), typeof (bool), typeof (SingleSelectRootGridEntry));
    /// <summary>The PropertyGridView property registration.</summary>
    private static readonly SerializableProperty gridEntryHostProperty = SerializableProperty.Register(nameof (gridEntryHost), typeof (PropertyGridView), typeof (SingleSelectRootGridEntry));
    /// <summary>The IDesignerHost property registration.</summary>
    private static readonly SerializableProperty hostProperty = SerializableProperty.Register(nameof (host), typeof (IDesignerHost), typeof (SingleSelectRootGridEntry));
    /// <summary>The object property registration.</summary>
    private static readonly SerializableProperty objValueProperty = SerializableProperty.Register(nameof (objValue), typeof (object), typeof (SingleSelectRootGridEntry));
    /// <summary>The string property registration.</summary>
    private static readonly SerializableProperty objValueClassNameProperty = SerializableProperty.Register(nameof (objValueClassName), typeof (string), typeof (SingleSelectRootGridEntry));
    /// <summary>The GridEntry property registration.</summary>
    private static readonly SerializableProperty propDefaultProperty = SerializableProperty.Register(nameof (propDefault), typeof (GridEntry), typeof (SingleSelectRootGridEntry));
    /// <summary>The PropertyTab property registration.</summary>
    private static readonly SerializableProperty tabProperty = SerializableProperty.Register(nameof (tab), typeof (PropertyTab), typeof (SingleSelectRootGridEntry));

    protected IServiceProvider baseProvider
    {
      get => this.GetValue<IServiceProvider>(SingleSelectRootGridEntry.baseProviderProperty);
      set => this.SetValue<IServiceProvider>(SingleSelectRootGridEntry.baseProviderProperty, value);
    }

    protected AttributeCollection browsableAttributes
    {
      get => this.GetValue<AttributeCollection>(SingleSelectRootGridEntry.browsableAttributesProperty);
      set => this.SetValue<AttributeCollection>(SingleSelectRootGridEntry.browsableAttributesProperty, value);
    }

    private IComponentChangeService changeService
    {
      get => this.GetValue<IComponentChangeService>(SingleSelectRootGridEntry.changeServiceProperty);
      set => this.SetValue<IComponentChangeService>(SingleSelectRootGridEntry.changeServiceProperty, value);
    }

    protected bool forceReadOnlyChecked
    {
      get => this.GetValue<bool>(SingleSelectRootGridEntry.forceReadOnlyCheckedProperty);
      set => this.SetValue<bool>(SingleSelectRootGridEntry.forceReadOnlyCheckedProperty, value);
    }

    protected PropertyGridView gridEntryHost
    {
      get => this.GetValue<PropertyGridView>(SingleSelectRootGridEntry.gridEntryHostProperty);
      set => this.SetValue<PropertyGridView>(SingleSelectRootGridEntry.gridEntryHostProperty, value);
    }

    protected IDesignerHost host
    {
      get => this.GetValue<IDesignerHost>(SingleSelectRootGridEntry.hostProperty);
      set => this.SetValue<IDesignerHost>(SingleSelectRootGridEntry.hostProperty, value);
    }

    protected object objValue
    {
      get => this.GetValue<object>(SingleSelectRootGridEntry.objValueProperty);
      set => this.SetValue<object>(SingleSelectRootGridEntry.objValueProperty, value);
    }

    protected string objValueClassName
    {
      get => this.GetValue<string>(SingleSelectRootGridEntry.objValueClassNameProperty);
      set => this.SetValue<string>(SingleSelectRootGridEntry.objValueClassNameProperty, value);
    }

    protected GridEntry propDefault
    {
      get => this.GetValue<GridEntry>(SingleSelectRootGridEntry.propDefaultProperty);
      set => this.SetValue<GridEntry>(SingleSelectRootGridEntry.propDefaultProperty, value);
    }

    protected PropertyTab tab
    {
      get => this.GetValue<PropertyTab>(SingleSelectRootGridEntry.tabProperty);
      set => this.SetValue<PropertyTab>(SingleSelectRootGridEntry.tabProperty, value);
    }

    internal SingleSelectRootGridEntry(
      PropertyGridView objPropertyGridView,
      object objValue,
      IServiceProvider objBaseProvider,
      IDesignerHost objHost,
      PropertyTab objPropertyTab,
      PropertySort objSortType)
      : this(objPropertyGridView, objValue, (GridEntry) null, objBaseProvider, objHost, objPropertyTab, objSortType)
    {
    }

    internal SingleSelectRootGridEntry(
      PropertyGridView objGridEntryHost,
      object objValue,
      GridEntry objParentEntry,
      IServiceProvider objBaseProvider,
      IDesignerHost objHost,
      PropertyTab objPropertyTab,
      PropertySort objSortType)
      : base(objGridEntryHost.OwnerGrid, objParentEntry)
    {
      this.host = objHost;
      this.gridEntryHost = objGridEntryHost;
      this.baseProvider = objBaseProvider;
      this.tab = objPropertyTab;
      this.objValue = objValue;
      this.objValueClassName = TypeDescriptor.GetClassName(this.objValue);
      this.IsExpandable = true;
      this.menmPropertySort = objSortType;
      this.InternalExpanded = true;
    }

    internal void CategorizePropEntries()
    {
      if (this.Children.Count <= 0)
        return;
      GridEntry[] objDestinationArray = new GridEntry[this.Children.Count];
      this.Children.CopyTo((Array) objDestinationArray, 0);
      if ((this.menmPropertySort & PropertySort.Categorized) == PropertySort.NoSort)
        return;
      Hashtable hashtable = new Hashtable();
      for (int index = 0; index < objDestinationArray.Length; ++index)
      {
        GridEntry gridEntry = objDestinationArray[index];
        if (gridEntry != null)
        {
          string propertyCategory = gridEntry.PropertyCategory;
          ArrayList arrayList = (ArrayList) hashtable[(object) propertyCategory];
          if (arrayList == null)
          {
            arrayList = new ArrayList();
            hashtable[(object) propertyCategory] = (object) arrayList;
          }
          arrayList.Add((object) gridEntry);
        }
      }
      ArrayList arrayList1 = new ArrayList();
      IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
      while (enumerator.MoveNext())
      {
        ArrayList arrayList2 = (ArrayList) enumerator.Value;
        if (arrayList2 != null)
        {
          string key = (string) enumerator.Key;
          if (arrayList2.Count > 0)
          {
            GridEntry[] arrChildGridEntries = new GridEntry[arrayList2.Count];
            arrayList2.CopyTo((Array) arrChildGridEntries, 0);
            try
            {
              arrayList1.Add((object) new CategoryGridEntry(this.mobjOwnerPropertyGrid, (GridEntry) this, key, arrChildGridEntries));
            }
            catch
            {
            }
          }
        }
      }
      GridEntry[] gridEntryArray = new GridEntry[arrayList1.Count];
      arrayList1.CopyTo((Array) gridEntryArray, 0);
      StringSorter.Sort((object[]) gridEntryArray);
      this.ChildCollection.Clear();
      this.ChildCollection.AddRange(gridEntryArray);
    }

    protected override bool CreateChildren()
    {
      int num = base.CreateChildren() ? 1 : 0;
      this.CategorizePropEntries();
      return num != 0;
    }

    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing)
      {
        this.host = (IDesignerHost) null;
        this.baseProvider = (IServiceProvider) null;
        this.tab = (PropertyTab) null;
        this.gridEntryHost = (PropertyGridView) null;
        this.changeService = (IComponentChangeService) null;
      }
      this.objValue = (object) null;
      this.objValueClassName = (string) null;
      this.propDefault = (GridEntry) null;
      base.Dispose(blnDisposing);
    }

    public override object GetService(Type objServiceType)
    {
      object service = (object) null;
      if (this.host != null)
        service = this.host.GetService(objServiceType);
      if (service == null && this.baseProvider != null)
        service = this.baseProvider.GetService(objServiceType);
      return service;
    }

    public void ResetBrowsableAttributes() => this.browsableAttributes = new AttributeCollection(new Attribute[1]
    {
      (Attribute) BrowsableAttribute.Yes
    });

    public virtual void ShowCategories(bool fCategories)
    {
      if ((this.menmPropertySort &= PropertySort.Categorized) != 0 == fCategories)
        return;
      if (fCategories)
        this.menmPropertySort |= PropertySort.Categorized;
      else
        this.menmPropertySort &= ~PropertySort.Categorized;
      if (!this.Expandable || this.ChildCollection == null)
        return;
      this.CreateChildren();
    }

    internal override bool AlwaysAllowExpand => true;

    public override AttributeCollection BrowsableAttributes
    {
      get
      {
        if (this.browsableAttributes == null)
          this.browsableAttributes = new AttributeCollection(new Attribute[1]
          {
            (Attribute) BrowsableAttribute.Yes
          });
        return this.browsableAttributes;
      }
      set
      {
        if (value == null)
        {
          this.ResetBrowsableAttributes();
        }
        else
        {
          bool flag = true;
          if (this.browsableAttributes != null && value != null && this.browsableAttributes.Count == value.Count)
          {
            Attribute[] attributeArray1 = new Attribute[this.browsableAttributes.Count];
            Attribute[] attributeArray2 = new Attribute[value.Count];
            this.browsableAttributes.CopyTo((Array) attributeArray1, 0);
            value.CopyTo((Array) attributeArray2, 0);
            Array.Sort((Array) attributeArray1, (IComparer) GridEntry.AttributeTypeSorter);
            Array.Sort((Array) attributeArray2, (IComparer) GridEntry.AttributeTypeSorter);
            for (int index = 0; index < attributeArray1.Length; ++index)
            {
              if (!attributeArray1[index].Equals((object) attributeArray2[index]))
              {
                flag = false;
                break;
              }
            }
          }
          else
            flag = false;
          this.browsableAttributes = value;
          if (flag || this.Children == null || this.Children.Count <= 0)
            return;
          this.DisposeChildren();
        }
      }
    }

    protected override IComponentChangeService ComponentChangeService
    {
      get
      {
        if (this.changeService == null)
          this.changeService = (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
        return this.changeService;
      }
    }

    public override PropertyTab CurrentTab
    {
      get => this.tab;
      set => this.tab = value;
    }

    internal override GridEntry DefaultChild
    {
      get => this.propDefault;
      set => this.propDefault = value;
    }

    internal override IDesignerHost DesignerHost
    {
      get => this.host;
      set => this.host = value;
    }

    internal override bool ForceReadOnly
    {
      get
      {
        if (!this.forceReadOnlyChecked)
        {
          ReadOnlyAttribute attribute = (ReadOnlyAttribute) TypeDescriptor.GetAttributes(this.objValue)[typeof (ReadOnlyAttribute)];
          if (attribute != null && !attribute.IsDefaultAttribute() || TypeDescriptor.GetAttributes(this.objValue).Contains((Attribute) InheritanceAttribute.InheritedReadOnly))
            this.State |= 1024;
          this.forceReadOnlyChecked = true;
        }
        if (base.ForceReadOnly)
          return true;
        return this.GridEntryHost != null && !this.GridEntryHost.Enabled;
      }
    }

    internal override PropertyGridView GridEntryHost
    {
      get => this.gridEntryHost;
      set => this.gridEntryHost = value;
    }

    public override GridItemType GridItemType => GridItemType.Root;

    public override string HelpKeyword
    {
      get
      {
        HelpKeywordAttribute attribute = (HelpKeywordAttribute) TypeDescriptor.GetAttributes(this.objValue)[typeof (HelpKeywordAttribute)];
        return attribute != null && !attribute.IsDefaultAttribute() ? attribute.HelpKeyword : this.objValueClassName;
      }
    }

    public override string PropertyLabel
    {
      get
      {
        if (this.objValue is IComponent)
        {
          ISite site = ((IComponent) this.objValue).Site;
          return site == null ? this.objValue.GetType().Name : site.Name;
        }
        return this.objValue != null ? this.objValue.ToString() : (string) null;
      }
    }

    public override object PropertyValue
    {
      get => this.objValue;
      set
      {
        object objValue = this.objValue;
        this.objValue = value;
        this.objValueClassName = TypeDescriptor.GetClassName(this.objValue);
        this.mobjOwnerPropertyGrid.ReplaceSelectedObject(objValue, value);
      }
    }
  }
}

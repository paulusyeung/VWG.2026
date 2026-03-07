// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.MultiPropertyDescriptorGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class MultiPropertyDescriptorGridEntry : PropertyDescriptorGridEntry
  {
    /// <summary>The MergePropertyDescriptor property registration.</summary>
    private static readonly SerializableProperty mobjMergePropertyDescriptorProperty = SerializableProperty.Register(nameof (mobjMergePropertyDescriptor), typeof (MergePropertyDescriptor), typeof (MultiPropertyDescriptorGridEntry));
    /// <summary>The object{} property registration.</summary>
    private static readonly SerializableProperty marrObjectsProperty = SerializableProperty.Register(nameof (marrObjects), typeof (object[]), typeof (MultiPropertyDescriptorGridEntry));

    private MergePropertyDescriptor mobjMergePropertyDescriptor
    {
      get => this.GetValue<MergePropertyDescriptor>(MultiPropertyDescriptorGridEntry.mobjMergePropertyDescriptorProperty);
      set => this.SetValue<MergePropertyDescriptor>(MultiPropertyDescriptorGridEntry.mobjMergePropertyDescriptorProperty, value);
    }

    private object[] marrObjects
    {
      get => this.GetValue<object[]>(MultiPropertyDescriptorGridEntry.marrObjectsProperty);
      set => this.SetValue<object[]>(MultiPropertyDescriptorGridEntry.marrObjectsProperty, value);
    }

    public MultiPropertyDescriptorGridEntry(
      PropertyGrid objOwnerGrid,
      GridEntry objParentGridEntry,
      object[] arrObjects,
      PropertyDescriptor[] arrPropDescriptors,
      bool blnHide)
      : base(objOwnerGrid, objParentGridEntry, blnHide)
    {
      this.mobjMergePropertyDescriptor = new MergePropertyDescriptor(arrPropDescriptors);
      this.marrObjects = arrObjects;
      this.Initialize((PropertyDescriptor) this.mobjMergePropertyDescriptor);
    }

    protected override bool CreateChildren() => this.CreateChildren(false);

    protected override bool CreateChildren(bool blnDiffOldChildren)
    {
      try
      {
        if (this.mobjMergePropertyDescriptor.PropertyType.IsValueType || (this.Flags & 512) != 0)
          return base.CreateChildren(blnDiffOldChildren);
        this.ChildCollection.Clear();
        MultiPropertyDescriptorGridEntry[] mergedProperties = MultiSelectRootGridEntry.PropertyMerger.GetMergedProperties(this.mobjMergePropertyDescriptor.GetValues((Array) this.marrObjects), (GridEntry) this, this.menmPropertySort, this.CurrentTab);
        if (mergedProperties != null)
          this.ChildCollection.AddRange((GridEntry[]) mergedProperties);
        int num = this.Children.Count > 0 ? 1 : 0;
        if (num == 0)
          this.SetState(524288, true);
        return num != 0;
      }
      catch
      {
        return false;
      }
    }

    public override object GetChildValueOwner(GridEntry objChildGridEntry) => !this.mobjMergePropertyDescriptor.PropertyType.IsValueType && (this.Flags & 512) == 0 ? (object) this.mobjMergePropertyDescriptor.GetValues((Array) this.marrObjects) : base.GetChildValueOwner(objChildGridEntry);

    public override IComponent[] GetComponents()
    {
      IComponent[] destinationArray = new IComponent[this.marrObjects.Length];
      Array.Copy((Array) this.marrObjects, 0, (Array) destinationArray, 0, this.marrObjects.Length);
      return destinationArray;
    }

    public override string GetPropertyTextValue(object objValue)
    {
      bool blnAllEqual = true;
      try
      {
        if (objValue == null)
        {
          if (this.mobjMergePropertyDescriptor.GetValue((Array) this.marrObjects, out blnAllEqual) == null)
          {
            if (!blnAllEqual)
              return "";
          }
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
      IDesignerHost designerHost = this.DesignerHost;
      DesignerTransaction designerTransaction = (DesignerTransaction) null;
      if (designerHost != null)
        designerTransaction = designerHost.CreateTransaction();
      try
      {
        return base.NotifyChildValue(objGridEntry, intType);
      }
      finally
      {
        designerTransaction?.Commit();
      }
    }

    protected override void NotifyParentChange(GridEntry objGridEntry)
    {
      while (objGridEntry != null && objGridEntry is PropertyDescriptorGridEntry && ((PropertyDescriptorGridEntry) objGridEntry).mobjPropertyInfo.Attributes.Contains((Attribute) NotifyParentPropertyAttribute.Yes))
      {
        object valueOwner1 = objGridEntry.GetValueOwner();
        while (!(objGridEntry is PropertyDescriptorGridEntry) || this.OwnersEqual(valueOwner1, objGridEntry.GetValueOwner()))
        {
          objGridEntry = objGridEntry.ParentGridEntry;
          if (objGridEntry == null)
            break;
        }
        if (objGridEntry != null)
        {
          object valueOwner2 = objGridEntry.GetValueOwner();
          IComponentChangeService componentChangeService = this.ComponentChangeService;
          if (componentChangeService != null)
          {
            if (valueOwner2 is Array array)
            {
              for (int index = 0; index < array.Length; ++index)
              {
                PropertyDescriptor mobjPropertyInfo = ((PropertyDescriptorGridEntry) objGridEntry).mobjPropertyInfo;
                if (mobjPropertyInfo is MergePropertyDescriptor)
                  mobjPropertyInfo = ((MergePropertyDescriptor) mobjPropertyInfo)[index];
                if (mobjPropertyInfo != null)
                {
                  componentChangeService.OnComponentChanging(array.GetValue(index), (MemberDescriptor) mobjPropertyInfo);
                  componentChangeService.OnComponentChanged(array.GetValue(index), (MemberDescriptor) mobjPropertyInfo, (object) null, (object) null);
                }
              }
            }
            else
            {
              componentChangeService.OnComponentChanging(valueOwner2, (MemberDescriptor) ((PropertyDescriptorGridEntry) objGridEntry).mobjPropertyInfo);
              componentChangeService.OnComponentChanged(valueOwner2, (MemberDescriptor) ((PropertyDescriptorGridEntry) objGridEntry).mobjPropertyInfo, (object) null, (object) null);
            }
          }
        }
      }
    }

    internal override bool NotifyValueGivenParent(object objObject, int intType)
    {
      if (objObject is ICustomTypeDescriptor)
        objObject = ((ICustomTypeDescriptor) objObject).GetPropertyOwner(this.mobjPropertyInfo);
      switch (intType)
      {
        case 1:
          object[] objArray = (object[]) objObject;
          if (objArray != null && objArray.Length != 0)
          {
            IDesignerHost designerHost = this.DesignerHost;
            DesignerTransaction designerTransaction = (DesignerTransaction) null;
            if (designerHost != null)
              designerTransaction = designerHost.CreateTransaction(Gizmox.WebGUI.Forms.SR.GetString("PropertyGridResetValue", (object) this.PropertyName));
            try
            {
              bool flag = !(objArray[0] is IComponent) || ((IComponent) objArray[0]).Site == null;
              if (flag && !this.OnComponentChanging())
              {
                if (designerTransaction != null)
                {
                  designerTransaction.Cancel();
                  designerTransaction = (DesignerTransaction) null;
                }
                return false;
              }
              this.mobjMergePropertyDescriptor.ResetValue(objObject);
              if (flag)
                this.OnComponentChanged();
              this.NotifyParentChange((GridEntry) this);
            }
            finally
            {
              designerTransaction?.Commit();
            }
          }
          return false;
        case 3:
        case 5:
          if (!(this.mobjPropertyInfo is MergePropertyDescriptor mobjPropertyInfo))
            return base.NotifyValueGivenParent(objObject, intType);
          if (this.mobjEventBindings == null)
            this.mobjEventBindings = (IEventBindingService) this.GetService(typeof (IEventBindingService));
          if (this.mobjEventBindings != null)
          {
            EventDescriptor objEventdesc = this.mobjEventBindings.GetEvent(mobjPropertyInfo[0]);
            if (objEventdesc != null)
              return this.ViewEvent(objObject, (string) null, objEventdesc, true);
          }
          return false;
        default:
          return base.NotifyValueGivenParent(objObject, intType);
      }
    }

    public override void OnComponentChanged()
    {
      if (this.ComponentChangeService == null)
        return;
      int length = this.marrObjects.Length;
      for (int index = 0; index < length; ++index)
        this.ComponentChangeService.OnComponentChanged(this.marrObjects[index], (MemberDescriptor) this.mobjMergePropertyDescriptor[index], (object) null, (object) null);
    }

    public override bool OnComponentChanging()
    {
      if (this.ComponentChangeService != null)
      {
        int length = this.marrObjects.Length;
        for (int index = 0; index < length; ++index)
        {
          try
          {
            this.ComponentChangeService.OnComponentChanging(this.marrObjects[index], (MemberDescriptor) this.mobjMergePropertyDescriptor[index]);
          }
          catch (CheckoutException ex)
          {
            if (ex != CheckoutException.Canceled)
              throw ex;
            return false;
          }
        }
      }
      return true;
    }

    private bool OwnersEqual(object objOwner1, object objOwner2)
    {
      if (!(objOwner1 is Array))
        return objOwner1 == objOwner2;
      Array array1 = objOwner1 as Array;
      Array array2 = objOwner2 as Array;
      if (array1 == null || array2 == null || array1.Length != array2.Length)
        return false;
      for (int index = 0; index < array1.Length; ++index)
      {
        if (array1.GetValue(index) != array2.GetValue(index))
          return false;
      }
      return true;
    }

    public override IContainer Container
    {
      get
      {
        IContainer container = (IContainer) null;
        object[] marrObjects = this.marrObjects;
        int index = 0;
        if (index >= marrObjects.Length)
          return container;
        if (marrObjects[index] is IComponent component && component.Site != null)
        {
          if (container == null)
            return component.Site.Container;
          if (container == component.Site.Container)
            return container;
        }
        return (IContainer) null;
      }
    }

    public override bool Expandable
    {
      get
      {
        bool expandable = this.GetStateSet(131072);
        if (expandable && this.ChildCollection.Count > 0)
          return true;
        if (this.GetStateSet(524288))
          return false;
        try
        {
          foreach (object obj in this.mobjMergePropertyDescriptor.GetValues((Array) this.marrObjects))
          {
            if (obj == null)
              return false;
          }
        }
        catch
        {
          expandable = false;
        }
        return expandable;
      }
    }

    public override object PropertyValue
    {
      set
      {
        base.PropertyValue = value;
        this.RecreateChildren();
        if (!this.Expanded)
          return;
        this.GridEntryHost.Refresh(false);
      }
    }
  }
}

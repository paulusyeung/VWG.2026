// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.RelatedCurrencyManager
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class RelatedCurrencyManager : CurrencyManager
  {
    private static readonly SerializableProperty dataFieldProperty = SerializableProperty.Register(nameof (dataField), typeof (string), typeof (RelatedCurrencyManager));
    [NonSerialized]
    private PropertyDescriptor fieldInfo;
    private bool mblnFieldInfoInitialized;
    private static readonly SerializableProperty ignoreParentCurrentItemChangedProperty = SerializableProperty.Register(nameof (ignoreParentCurrentItemChanged), typeof (bool), typeof (RelatedCurrencyManager));
    private static readonly SerializableProperty parentManagerProperty = SerializableProperty.Register(nameof (parentManager), typeof (BindingManagerBase), typeof (RelatedCurrencyManager));

    private string dataField
    {
      get => this.GetValue<string>(RelatedCurrencyManager.dataFieldProperty);
      set => this.SetValue<string>(RelatedCurrencyManager.dataFieldProperty, value);
    }

    private bool ignoreParentCurrentItemChanged
    {
      get => this.GetValue<bool>(RelatedCurrencyManager.ignoreParentCurrentItemChangedProperty);
      set => this.SetValue<bool>(RelatedCurrencyManager.ignoreParentCurrentItemChangedProperty, value);
    }

    private BindingManagerBase parentManager
    {
      get => this.GetValue<BindingManagerBase>(RelatedCurrencyManager.parentManagerProperty);
      set => this.SetValue<BindingManagerBase>(RelatedCurrencyManager.parentManagerProperty, value);
    }

    internal RelatedCurrencyManager(BindingManagerBase objParentManager, string strDataField)
      : base((object) null)
    {
      this.Bind(objParentManager, strDataField);
    }

    internal void Bind(BindingManagerBase objParentManager, string strDataField)
    {
      this.UnwireParentManager(this.parentManager);
      this.parentManager = objParentManager;
      this.dataField = strDataField;
      this.fieldInfo = objParentManager.GetItemProperties().Find(strDataField, true);
      this.mblnFieldInfoInitialized = true;
      this.finalType = this.fieldInfo != null && typeof (IList).IsAssignableFrom(this.fieldInfo.PropertyType) ? this.fieldInfo.PropertyType : throw new ArgumentException(SR.GetString("RelatedListManagerChild", (object) strDataField));
      this.WireParentManager(this.parentManager);
      this.ParentManager_CurrentItemChanged((object) objParentManager, EventArgs.Empty);
    }

    /// <summary>Ensures the field info.</summary>
    private void EnsureFieldInfo()
    {
      if (!this.mblnFieldInfoInitialized || this.fieldInfo != null)
        return;
      this.Bind(this.parentManager, this.dataField);
    }

    public override PropertyDescriptorCollection GetItemProperties() => this.GetItemProperties((PropertyDescriptor[]) null);

    internal override PropertyDescriptorCollection GetItemProperties(
      PropertyDescriptor[] arrListAccessors)
    {
      PropertyDescriptor[] arrListAccessors1;
      if (arrListAccessors != null && arrListAccessors.Length != 0)
      {
        arrListAccessors1 = new PropertyDescriptor[arrListAccessors.Length + 1];
        arrListAccessors.CopyTo((Array) arrListAccessors1, 1);
      }
      else
        arrListAccessors1 = new PropertyDescriptor[1];
      this.EnsureFieldInfo();
      arrListAccessors1[0] = this.fieldInfo;
      return this.parentManager.GetItemProperties(arrListAccessors1);
    }

    internal override string GetListName()
    {
      string listName = this.GetListName(new ArrayList());
      return listName.Length > 0 ? listName : base.GetListName();
    }

    protected internal override string GetListName(ArrayList objListAccessors)
    {
      this.EnsureFieldInfo();
      objListAccessors.Insert(0, (object) this.fieldInfo);
      return this.parentManager.GetListName(objListAccessors);
    }

    private void ParentManager_CurrentItemChanged(object sender, EventArgs e)
    {
      if (this.ignoreParentCurrentItemChanged)
        return;
      int listposition = this.listposition;
      try
      {
        this.PullData();
      }
      catch (Exception ex)
      {
        this.OnDataError(ex);
      }
      this.EnsureFieldInfo();
      if (this.parentManager is CurrencyManager)
      {
        CurrencyManager parentManager = (CurrencyManager) this.parentManager;
        if (parentManager.Count > 0)
        {
          this.SetDataSource(this.fieldInfo.GetValue(parentManager.Current));
          this.listposition = this.Count > 0 ? 0 : -1;
        }
        else
        {
          parentManager.AddNew();
          try
          {
            this.ignoreParentCurrentItemChanged = true;
            parentManager.CancelCurrentEdit();
          }
          finally
          {
            this.ignoreParentCurrentItemChanged = false;
          }
        }
      }
      else
      {
        this.SetDataSource(this.fieldInfo.GetValue(this.parentManager.Current));
        this.listposition = this.Count > 0 ? 0 : -1;
      }
      if (listposition != this.listposition)
        this.OnPositionChanged(EventArgs.Empty);
      this.OnCurrentChanged(EventArgs.Empty);
      this.OnCurrentItemChanged(EventArgs.Empty);
    }

    private void ParentManager_MetaDataChanged(object sender, EventArgs e) => this.OnMetaDataChanged(e);

    private void UnwireParentManager(BindingManagerBase objBindingManagerBase)
    {
      if (objBindingManagerBase == null)
        return;
      objBindingManagerBase.CurrentItemChanged -= new EventHandler(this.ParentManager_CurrentItemChanged);
      if (!(objBindingManagerBase is CurrencyManager))
        return;
      (objBindingManagerBase as CurrencyManager).MetaDataChanged -= new EventHandler(this.ParentManager_MetaDataChanged);
    }

    private void WireParentManager(BindingManagerBase objBindingManagerBase)
    {
      if (objBindingManagerBase == null)
        return;
      objBindingManagerBase.CurrentItemChanged += new EventHandler(this.ParentManager_CurrentItemChanged);
      if (!(objBindingManagerBase is CurrencyManager))
        return;
      (objBindingManagerBase as CurrencyManager).MetaDataChanged += new EventHandler(this.ParentManager_MetaDataChanged);
    }
  }
}

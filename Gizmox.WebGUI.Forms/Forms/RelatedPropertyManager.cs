// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.RelatedPropertyManager
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
  internal class RelatedPropertyManager : PropertyManager
  {
    private static readonly SerializableProperty dataFieldProperty = SerializableProperty.Register(nameof (dataField), typeof (string), typeof (RelatedPropertyManager));
    [NonSerialized]
    private PropertyDescriptor fieldInfo;
    private bool mblnFieldInfoInitialized;
    private static readonly SerializableProperty parentManagerProperty = SerializableProperty.Register(nameof (parentManager), typeof (BindingManagerBase), typeof (RelatedPropertyManager));

    private string dataField
    {
      get => this.GetValue<string>(RelatedPropertyManager.dataFieldProperty);
      set => this.SetValue<string>(RelatedPropertyManager.dataFieldProperty, value);
    }

    private BindingManagerBase parentManager
    {
      get => this.GetValue<BindingManagerBase>(RelatedPropertyManager.parentManagerProperty);
      set => this.SetValue<BindingManagerBase>(RelatedPropertyManager.parentManagerProperty, value);
    }

    internal RelatedPropertyManager(BindingManagerBase objParentManager, string strDataField)
      : base(RelatedPropertyManager.GetCurrentOrNull(objParentManager), strDataField)
    {
      this.Bind(objParentManager, strDataField);
    }

    private void Bind(BindingManagerBase objParentManager, string strDataField)
    {
      this.parentManager = objParentManager;
      this.dataField = strDataField;
      this.fieldInfo = objParentManager.GetItemProperties().Find(strDataField, true);
      if (this.fieldInfo == null)
        throw new ArgumentException(SR.GetString("RelatedListManagerChild", (object) strDataField));
      objParentManager.CurrentItemChanged += new EventHandler(this.ParentManager_CurrentItemChanged);
      this.Refresh();
    }

    /// <summary>Ensures the field info.</summary>
    private void EnsureFieldInfo()
    {
      if (!this.mblnFieldInfoInitialized || this.fieldInfo != null)
        return;
      this.Bind(this.parentManager, this.dataField);
    }

    private static object GetCurrentOrNull(BindingManagerBase objParentManager) => objParentManager.Position < 0 || objParentManager.Position >= objParentManager.Count ? (object) null : objParentManager.Current;

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

    private void ParentManager_CurrentItemChanged(object sender, EventArgs e) => this.Refresh();

    private void Refresh()
    {
      this.EndCurrentEdit();
      this.SetDataSource(RelatedPropertyManager.GetCurrentOrNull(this.parentManager));
      this.OnCurrentChanged(EventArgs.Empty);
    }

    internal override Type BindType
    {
      get
      {
        this.EnsureFieldInfo();
        return this.fieldInfo.PropertyType;
      }
    }

    public override object Current
    {
      get
      {
        if (this.DataSource == null)
          return (object) null;
        this.EnsureFieldInfo();
        return this.fieldInfo.GetValue(this.DataSource);
      }
    }
  }
}

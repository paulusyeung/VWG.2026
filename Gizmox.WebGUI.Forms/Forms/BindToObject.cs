// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindToObject
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class BindToObject : SerializableObject
  {
    private static readonly SerializableProperty bindingManagerProperty = SerializableProperty.Register(nameof (bindingManager), typeof (BindingManagerBase), typeof (BindToObject));
    private BindingMemberInfo mobjDataMember;
    private object mobjDataSource;
    private static readonly SerializableProperty dataSourceInitializedProperty = SerializableProperty.Register(nameof (dataSourceInitialized), typeof (bool), typeof (BindToObject));
    private string mstrErrorText;
    [NonSerialized]
    private PropertyDescriptor mobjFieldInfo;
    private bool mblnFieldInfoInitialized;
    private Binding mobjOwner;
    private static readonly SerializableProperty waitingOnDataSourceProperty = SerializableProperty.Register(nameof (waitingOnDataSource), typeof (bool), typeof (BindToObject));

    private BindingManagerBase bindingManager
    {
      get => this.GetValue<BindingManagerBase>(BindToObject.bindingManagerProperty);
      set => this.SetValue<BindingManagerBase>(BindToObject.bindingManagerProperty, value);
    }

    private bool dataSourceInitialized
    {
      get => this.GetValue<bool>(BindToObject.dataSourceInitializedProperty);
      set => this.SetValue<bool>(BindToObject.dataSourceInitializedProperty, value);
    }

    private bool waitingOnDataSource
    {
      get => this.GetValue<bool>(BindToObject.waitingOnDataSourceProperty);
      set => this.SetValue<bool>(BindToObject.waitingOnDataSourceProperty, value);
    }

    internal BindToObject(Binding objOwner, object objDataSource, string strDataMember)
    {
      this.mstrErrorText = string.Empty;
      this.mobjOwner = objOwner;
      this.mobjDataSource = objDataSource;
      this.mobjDataMember = new BindingMemberInfo(strDataMember);
      this.CheckBinding();
    }

    internal void CheckBinding()
    {
      if (this.mobjOwner != null && this.mobjOwner.BindableComponent != null && this.mobjOwner.ControlAtDesignTime())
        return;
      if (this.mobjOwner.BindingManagerBase != null && this.mobjFieldInfo != null && this.mobjOwner.BindingManagerBase.IsBinding && !(this.mobjOwner.BindingManagerBase is CurrencyManager))
        this.mobjFieldInfo.RemoveValueChanged(this.mobjOwner.BindingManagerBase.Current, new EventHandler(this.PropValueChanged));
      if (this.mobjOwner != null && this.mobjOwner.BindingManagerBase != null && this.mobjOwner.BindableComponent != null && this.mobjOwner.ComponentCreated && this.IsDataSourceInitialized)
      {
        string bindingField = this.mobjDataMember.BindingField;
        this.mobjFieldInfo = this.mobjOwner.BindingManagerBase.GetItemProperties().Find(bindingField, true);
        if (this.mobjOwner.BindingManagerBase.DataSource != null && this.mobjFieldInfo == null && bindingField.Length > 0)
          throw new ArgumentException(SR.GetString("ListBindingBindField", (object) bindingField), "dataMember");
        if (this.mobjFieldInfo != null && this.mobjOwner.BindingManagerBase.IsBinding && !(this.mobjOwner.BindingManagerBase is CurrencyManager))
          this.mobjFieldInfo.AddValueChanged(this.mobjOwner.BindingManagerBase.Current, new EventHandler(this.PropValueChanged));
      }
      else
        this.mobjFieldInfo = (PropertyDescriptor) null;
      this.mblnFieldInfoInitialized = true;
    }

    /// <summary>Ensures the field info.</summary>
    private void EnsureFieldInfo()
    {
      if (!this.mblnFieldInfoInitialized || this.mobjFieldInfo != null)
        return;
      this.CheckBinding();
    }

    private void DataSource_Initialized(object sender, EventArgs e)
    {
      if (this.mobjDataSource is ISupportInitializeNotification mobjDataSource)
        mobjDataSource.Initialized -= new EventHandler(this.DataSource_Initialized);
      this.waitingOnDataSource = false;
      this.dataSourceInitialized = true;
      this.CheckBinding();
    }

    private string GetErrorText(object objValue)
    {
      IDataErrorInfo dataErrorInfo = objValue as IDataErrorInfo;
      string str = string.Empty;
      if (dataErrorInfo != null)
      {
        this.EnsureFieldInfo();
        str = this.mobjFieldInfo != null ? dataErrorInfo[this.mobjFieldInfo.Name] : dataErrorInfo.Error;
      }
      return str ?? string.Empty;
    }

    internal object GetValue()
    {
      object current = this.bindingManager.Current;
      this.mstrErrorText = this.GetErrorText(current);
      this.EnsureFieldInfo();
      if (this.mobjFieldInfo != null)
        current = this.mobjFieldInfo.GetValue(current);
      return current;
    }

    private void PropValueChanged(object sender, EventArgs e) => this.bindingManager.OnCurrentChanged(EventArgs.Empty);

    internal void SetBindingManagerBase(BindingManagerBase lManager)
    {
      if (this.bindingManager == lManager)
        return;
      this.EnsureFieldInfo();
      if (this.bindingManager != null && this.mobjFieldInfo != null && this.bindingManager.IsBinding && !(this.bindingManager is CurrencyManager))
      {
        this.mobjFieldInfo.RemoveValueChanged(this.bindingManager.Current, new EventHandler(this.PropValueChanged));
        this.mobjFieldInfo = (PropertyDescriptor) null;
      }
      this.bindingManager = lManager;
      this.CheckBinding();
    }

    internal void SetValue(object objValue)
    {
      object obj = (object) null;
      this.EnsureFieldInfo();
      if (this.mobjFieldInfo != null)
      {
        obj = this.bindingManager.Current;
        if (obj is IEditableObject)
          ((IEditableObject) obj).BeginEdit();
        if (!this.mobjFieldInfo.IsReadOnly)
          this.mobjFieldInfo.SetValue(obj, objValue);
      }
      else if (this.bindingManager is CurrencyManager bindingManager)
      {
        bindingManager[bindingManager.Position] = objValue;
        obj = objValue;
      }
      this.mstrErrorText = this.GetErrorText(obj);
    }

    internal BindingManagerBase BindingManagerBase => this.bindingManager;

    internal BindingMemberInfo BindingMemberInfo => this.mobjDataMember;

    internal Type BindToType
    {
      get
      {
        if (this.mobjDataMember.BindingField.Length == 0)
        {
          Type c = this.bindingManager.BindType;
          if (typeof (Array).IsAssignableFrom(c))
            c = c.GetElementType();
          return c;
        }
        this.EnsureFieldInfo();
        return this.mobjFieldInfo != null ? this.mobjFieldInfo.PropertyType : (Type) null;
      }
    }

    internal string DataErrorText => this.mstrErrorText;

    internal object DataSource => this.mobjDataSource;

    internal PropertyDescriptor FieldInfo
    {
      get
      {
        this.EnsureFieldInfo();
        return this.mobjFieldInfo;
      }
    }

    private bool IsDataSourceInitialized
    {
      get
      {
        if (this.dataSourceInitialized)
          return true;
        if (!(this.mobjDataSource is ISupportInitializeNotification mobjDataSource) || mobjDataSource.IsInitialized)
        {
          this.dataSourceInitialized = true;
          return true;
        }
        if (!this.waitingOnDataSource)
        {
          mobjDataSource.Initialized += new EventHandler(this.DataSource_Initialized);
          this.waitingOnDataSource = true;
        }
        return false;
      }
    }
  }
}

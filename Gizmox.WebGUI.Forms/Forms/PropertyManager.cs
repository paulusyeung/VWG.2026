// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyManager
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Maintains a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> between an object's property and a data-bound control property.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class PropertyManager : BindingManagerBase
  {
    private static readonly SerializableProperty boundProperty = SerializableProperty.Register(nameof (bound), typeof (bool), typeof (PropertyManager));
    private static readonly SerializableProperty dataSourceProperty = SerializableProperty.Register(nameof (dataSource), typeof (object), typeof (PropertyManager));
    [NonSerialized]
    private PropertyDescriptor mobjPropertyDescriptor;
    private string mstrPropName;

    private bool bound
    {
      get => this.GetValue<bool>(PropertyManager.boundProperty);
      set => this.SetValue<bool>(PropertyManager.boundProperty, value);
    }

    private object dataSource
    {
      get => this.GetValue<object>(PropertyManager.dataSourceProperty);
      set => this.SetValue<object>(PropertyManager.dataSourceProperty, value);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyManager"></see> class.</summary>
    public PropertyManager()
    {
    }

    internal PropertyManager(object objDataSource)
      : base(objDataSource)
    {
    }

    internal PropertyManager(object objDataSource, string strPropName)
    {
      this.mstrPropName = strPropName;
      this.SetDataSource(objDataSource);
    }

    /// <filterpriority>1</filterpriority>
    public override void AddNew() => throw new NotSupportedException(SR.GetString("DataBindingAddNewNotSupportedOnPropertyManager"));

    /// <filterpriority>1</filterpriority>
    public override void CancelCurrentEdit()
    {
      if (this.Current is IEditableObject current)
        current.CancelEdit();
      this.PushData();
    }

    /// <filterpriority>1</filterpriority>
    public override void EndCurrentEdit()
    {
      bool blnSuccess;
      this.PullData(out blnSuccess);
      if (!blnSuccess || !(this.Current is IEditableObject current))
        return;
      current.EndEdit();
    }

    internal override PropertyDescriptorCollection GetItemProperties(
      PropertyDescriptor[] arrListAccessors)
    {
      return ListBindingHelper.GetListItemProperties(this.dataSource, arrListAccessors);
    }

    internal override string GetListName() => TypeDescriptor.GetClassName(this.dataSource) + "." + this.mstrPropName;

    /// <summary>
    /// When overridden in a derived class, gets the name of the list supplying the data for the binding.
    /// </summary>
    /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties.</param>
    /// <returns>
    /// The name of the list supplying the data for the binding.
    /// </returns>
    protected internal override string GetListName(ArrayList objListAccessors) => "";

    /// <summary>
    /// Raises the <see cref="E:CurrentChanged" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected internal override void OnCurrentChanged(EventArgs objEventArgs)
    {
      this.PushData();
      this.FireCurrentChanged((object) this, objEventArgs);
      this.FireCurrentItemChanged((object) this, objEventArgs);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.</summary>
    /// <param name="objEventArgs">An <see cref="T:System.EventArgs"></see> containing the event data.</param>
    protected internal override void OnCurrentItemChanged(EventArgs objEventArgs)
    {
      this.PushData();
      this.FireCurrentItemChanged((object) this, objEventArgs);
    }

    private void PropertyChanged(object sender, EventArgs ea)
    {
      this.EndCurrentEdit();
      this.OnCurrentChanged(EventArgs.Empty);
    }

    /// <filterpriority>1</filterpriority>
    public override void RemoveAt(int index) => throw new NotSupportedException(SR.GetString("DataBindingRemoveAtNotSupportedOnPropertyManager"));

    /// <filterpriority>1</filterpriority>
    public override void ResumeBinding()
    {
      this.OnCurrentChanged(new EventArgs());
      if (this.bound)
        return;
      try
      {
        this.bound = true;
        this.UpdateIsBinding();
      }
      catch
      {
        this.bound = false;
        this.UpdateIsBinding();
        throw;
      }
    }

    internal override void SetDataSource(object objDataSource)
    {
      if (this.dataSource != null)
      {
        if (!CommonUtils.IsNullOrEmpty(this.mstrPropName))
        {
          this.mobjPropertyDescriptor.RemoveValueChanged(this.dataSource, new EventHandler(this.PropertyChanged));
          this.mobjPropertyDescriptor = (PropertyDescriptor) null;
        }
      }
      this.dataSource = objDataSource;
      if (this.dataSource == null)
        return;
      if (CommonUtils.IsNullOrEmpty(this.mstrPropName))
        return;
      this.mobjPropertyDescriptor = TypeDescriptor.GetProperties(objDataSource).Find(this.mstrPropName, true);
      if (this.mobjPropertyDescriptor == null)
        throw new ArgumentException(SR.GetString("PropertyManagerPropDoesNotExist", (object) this.mstrPropName, (object) objDataSource.ToString()));
      this.mobjPropertyDescriptor.AddValueChanged(objDataSource, new EventHandler(this.PropertyChanged));
    }

    /// <summary>Suspends the data binding between a data source and a data-bound property.</summary>
    /// <filterpriority>1</filterpriority>
    public override void SuspendBinding()
    {
      this.EndCurrentEdit();
      if (!this.bound)
        return;
      try
      {
        this.bound = false;
        this.UpdateIsBinding();
      }
      catch
      {
        this.bound = true;
        this.UpdateIsBinding();
        throw;
      }
    }

    /// <summary>Updates the current <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> between a data binding and a data-bound property.</summary>
    protected override void UpdateIsBinding()
    {
      for (int index = 0; index < this.Bindings.Count; ++index)
        this.Bindings[index].UpdateIsBinding();
    }

    internal override Type BindType => this.dataSource.GetType();

    /// <filterpriority>1</filterpriority>
    public override int Count => 1;

    /// <summary>Gets the object to which the data-bound property belongs.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the object to which the property belongs.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Current => this.dataSource;

    internal override object DataSource => this.dataSource;

    internal override bool IsBinding => this.dataSource != null;

    /// <filterpriority>1</filterpriority>
    public override int Position
    {
      get => 0;
      set
      {
      }
    }
  }
}

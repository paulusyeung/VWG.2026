// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ControlBindingsCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the collection of data bindings for a control.</summary>
  /// <filterpriority>2</filterpriority>
  [DefaultEvent("CollectionChanged")]
  [TypeConverter("Gizmox.WebGUI.Forms.Design.ControlBindingsConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [Editor("System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
  [Serializable]
  public class ControlBindingsCollection : BindingsCollection
  {
    internal IBindableComponent mobjControl;
    private DataSourceUpdateMode menmDefaultDataSourceUpdateMode;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> class with the specified bindable control.</summary>
    /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</param>
    public ControlBindingsCollection(IBindableComponent objControl) => this.mobjControl = objControl;

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to the collection.</summary>
    /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add. </param>
    /// <exception cref="T:System.ArgumentNullException">The binding is null. </exception>
    /// <exception cref="T:System.ArgumentException">The control property is already data-bound. </exception>
    /// <exception cref="T:System.ArgumentException">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> does not specify a valid column of the <see cref="P:Gizmox.WebGUI.Forms.Binding.DataSource"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public new void Add(Binding objBinding) => base.Add(objBinding);

    /// <summary>Creates a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> using the specified control property name, data source, and data member, and adds it to the collection.</summary>
    /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
    /// <param name="strDataMember">The property or list to bind to. </param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <exception cref="T:System.Exception">The propertyName is already data-bound. </exception>
    /// <exception cref="T:System.ArgumentNullException">The binding is null. </exception>
    /// <exception cref="T:System.Exception">The dataMember doesn't specify a valid member of the dataSource. </exception>
    /// <filterpriority>1</filterpriority>
    public Binding Add(string strPropertyName, object objDataSource, string strDataMember) => this.Add(strPropertyName, objDataSource, strDataMember, false, this.DefaultDataSourceUpdateMode, (object) null, string.Empty, (IFormatProvider) null);

    /// <summary>Creates a binding with the specified control property name, data source, data member, and information about whether formatting is enabled, and adds the binding to the collection.</summary>
    /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind.</param>
    /// <exception cref="T:System.Exception">If formatting is disabled and the propertyName is neither a valid property of a control nor an empty string (""). </exception>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control.-or-The property given is a read-only property.</exception>
    /// <filterpriority>1</filterpriority>
    public Binding Add(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled)
    {
      return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, this.DefaultDataSourceUpdateMode, (object) null, string.Empty, (IFormatProvider) null);
    }

    /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting, propagating values to the data source based on the specified update setting, and adding the binding to the collection.</summary>
    /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
    public Binding Add(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmUpdateMode)
    {
      return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, (object) null, string.Empty, (IFormatProvider) null);
    }

    /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, and adding the binding to the collection.</summary>
    /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see></returns>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
    public Binding Add(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmUpdateMode,
      object objNullValue)
    {
      return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, string.Empty, (IFormatProvider) null);
    }

    /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting with the specified format string, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, and adding the binding to the collection.</summary>
    /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see></returns>
    /// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed.</param>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
    public Binding Add(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmUpdateMode,
      object objNullValue,
      string strFormatString)
    {
      return this.Add(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, strFormatString, (IFormatProvider) null);
    }

    /// <summary>Creates a binding that binds the specified control property to the specified data member of the specified data source, optionally enabling formatting with the specified format string, propagating values to the data source based on the specified update setting, setting the property to the specified value when <see cref="T:System.DBNull"></see> is returned from the data source, setting the specified format provider, and adding the binding to the collection.</summary>
    /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</returns>
    /// <param name="strFormatString">One or more format specifier characters that indicate how a value is to be displayed</param>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> representing the data source. </param>
    /// <param name="blnFormattingEnabled">true to format the displayed data; otherwise, false.</param>
    /// <param name="objFormatInfo">An implementation of <see cref="T:System.IFormatProvider"></see> to override default formatting behavior.</param>
    /// <param name="enmUpdateMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</param>
    /// <param name="strDataMember">The property or list to bind to.</param>
    /// <param name="strPropertyName">The name of the control property to bind. </param>
    /// <param name="objNullValue">The <see cref="T:System.Object"></see> to be applied to the bound control property if the data source value is <see cref="T:System.DBNull"></see>.</param>
    /// <exception cref="T:System.ArgumentException">The property given by propertyName does not exist on the control or is read-only.-or-The specified data member does not exist on the data source.-or-The data source, data member, or control property specified are associated with another binding in the collection.</exception>
    public Binding Add(
      string strPropertyName,
      object objDataSource,
      string strDataMember,
      bool blnFormattingEnabled,
      DataSourceUpdateMode enmUpdateMode,
      object objNullValue,
      string strFormatString,
      IFormatProvider objFormatInfo)
    {
      if (objDataSource == null)
        throw new ArgumentNullException("dataSource");
      Binding objBinding = new Binding(strPropertyName, objDataSource, strDataMember, blnFormattingEnabled, enmUpdateMode, objNullValue, strFormatString, objFormatInfo);
      this.Add(objBinding);
      return objBinding;
    }

    /// <summary>Adds a binding to the collection.</summary>
    /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add. </param>
    protected override void AddCore(Binding objDataBinding)
    {
      if (objDataBinding == null)
        throw new ArgumentNullException("dataBinding");
      if (objDataBinding.BindableComponent == this.mobjControl)
        throw new ArgumentException(SR.GetString("BindingsCollectionAdd1"));
      if (objDataBinding.BindableComponent != null)
        throw new ArgumentException(SR.GetString("BindingsCollectionAdd2"));
      objDataBinding.SetBindableComponent(this.mobjControl);
      base.AddCore(objDataBinding);
    }

    internal void CheckDuplicates(Binding objBinding)
    {
      if (objBinding.PropertyName.Length == 0)
        return;
      for (int index = 0; index < this.Count; ++index)
      {
        if (objBinding != this[index] && this[index].PropertyName.Length > 0 && string.Compare(objBinding.PropertyName, this[index].PropertyName, false, CultureInfo.InvariantCulture) == 0)
          throw new ArgumentException(SR.GetString("BindingsCollectionDup"), "binding");
      }
    }

    /// <summary>Clears the collection of any bindings.</summary>
    public new void Clear() => base.Clear();

    /// <summary>Clears the bindings in the collection.</summary>
    protected override void ClearCore()
    {
      int count = this.Count;
      for (int index = 0; index < count; ++index)
        this[index].SetBindableComponent((IBindableComponent) null);
      base.ClearCore();
    }

    /// <summary>
    /// Deletes the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> from the collection.
    /// </summary>
    /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove.</param>
    /// <exception cref="T:System.NullReferenceException">The binding is null. </exception>
    public new void Remove(Binding objBinding) => base.Remove(objBinding);

    /// <summary>
    /// Deletes the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than 0, or it is greater than the number of bindings in the collection. </exception>
    public new void RemoveAt(int index) => base.RemoveAt(index);

    /// <summary>Removes the specified binding from the collection.</summary>
    /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove from the collection.</param>
    /// <exception cref="T:System.ArgumentException">The binding belongs to another <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see>.</exception>
    protected override void RemoveCore(Binding objDataBinding)
    {
      if (objDataBinding.BindableComponent != this.mobjControl)
        throw new ArgumentException(SR.GetString("BindingsCollectionForeign"));
      objDataBinding.SetBindableComponent((IBindableComponent) null);
      base.RemoveCore(objDataBinding);
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see> the binding collection belongs to.</returns>
    /// <filterpriority>1</filterpriority>
    public IBindableComponent BindableComponent => this.mobjControl;

    /// <summary>Gets the control that the collection belongs to.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that the collection belongs to.</returns>
    /// <filterpriority>1</filterpriority>
    public Control Control => this.mobjControl as Control;

    /// <summary>Gets or sets the default <see cref="P:Gizmox.WebGUI.Forms.Binding.DataSourceUpdateMode"></see> for a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> in the collection.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataSourceUpdateMode"></see> values.</returns>
    public DataSourceUpdateMode DefaultDataSourceUpdateMode
    {
      get => this.menmDefaultDataSourceUpdateMode;
      set => this.menmDefaultDataSourceUpdateMode = value;
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> specified by the control's property name.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> that binds the specified control property to a data source.</returns>
    /// <param name="strPropertyName">The name of the property on the data-bound control. </param>
    /// <filterpriority>1</filterpriority>
    public Binding this[string strPropertyName]
    {
      get
      {
        foreach (Binding binding in (BaseCollection) this)
        {
          if (ClientUtils.IsEquals(binding.PropertyName, strPropertyName, StringComparison.OrdinalIgnoreCase))
            return binding;
        }
        return (Binding) null;
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingManagerBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Manages all <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects that are bound to the same data source and data member. This class is abstract.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public abstract class BindingManagerBase : SerializableObject
  {
    private BindingsCollection mobjBindings;
    private bool mblnPullingData;

    /// <summary>Occurs at the completion of a data-binding operation.</summary>
    public event BindingCompleteEventHandler BindingComplete;

    /// <summary>Occurs when the currently bound item changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler CurrentChanged;

    /// <summary>Occurs when the state of the currently bound item changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler CurrentItemChanged;

    /// <summary>Occurs when an <see cref="T:System.Exception"></see> is silently handled by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </summary>
    public event BindingManagerDataErrorEventHandler DataError;

    /// <summary>Occurs after the value of the <see cref="P:Gizmox.WebGUI.Forms.BindingManagerBase.Position"></see> property has changed.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler PositionChanged;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> class.</summary>
    public BindingManagerBase()
    {
    }

    internal BindingManagerBase(object objDataSource) => this.SetDataSource(objDataSource);

    /// <summary>When overridden in a derived class, adds a new item to the underlying list.</summary>
    /// <filterpriority>1</filterpriority>
    public abstract void AddNew();

    internal void Binding_BindingComplete(object sender, BindingCompleteEventArgs args) => this.OnBindingComplete(args);

    /// <summary>When overridden in a derived class, cancels the current edit.</summary>
    /// <filterpriority>1</filterpriority>
    public abstract void CancelCurrentEdit();

    /// <summary>When overridden in a derived class, ends the current edit.</summary>
    /// <filterpriority>1</filterpriority>
    public abstract void EndCurrentEdit();

    /// <summary>When overridden in a derived class, gets the collection of property descriptors for the binding.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual PropertyDescriptorCollection GetItemProperties() => this.GetItemProperties((PropertyDescriptor[]) null);

    internal abstract PropertyDescriptorCollection GetItemProperties(
      PropertyDescriptor[] arrListAccessors);

    /// <summary>Gets the collection of property descriptors for the binding using the specified <see cref="T:System.Collections.ArrayList"></see>.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
    /// <param name="objDataSources">An <see cref="T:System.Collections.ArrayList"></see> containing the data sources. </param>
    /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
    protected internal virtual PropertyDescriptorCollection GetItemProperties(
      ArrayList objDataSources,
      ArrayList objListAccessors)
    {
      IList list = (IList) null;
      if (this is CurrencyManager)
        list = ((CurrencyManager) this).List;
      if (!(list is ITypedList))
        return this.GetItemProperties(this.BindType, 0, objDataSources, objListAccessors);
      PropertyDescriptor[] listAccessors = new PropertyDescriptor[objListAccessors.Count];
      objListAccessors.CopyTo((Array) listAccessors, 0);
      return ((ITypedList) list).GetItemProperties(listAccessors);
    }

    /// <summary>Gets the list of properties of the items managed by this <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the property descriptors for the binding.</returns>
    /// <param name="intOffset">A counter used to recursively call the method. </param>
    /// <param name="objListType">The <see cref="T:System.Type"></see> of the bound list. </param>
    /// <param name="objDataSources">An <see cref="T:System.Collections.ArrayList"></see> containing the data sources. </param>
    /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
    protected virtual PropertyDescriptorCollection GetItemProperties(
      Type objListType,
      int intOffset,
      ArrayList objDataSources,
      ArrayList objListAccessors)
    {
      if (objListAccessors.Count >= intOffset)
      {
        if (objListAccessors.Count == intOffset)
        {
          if (!typeof (IList).IsAssignableFrom(objListType))
            return TypeDescriptor.GetProperties(objListType);
          PropertyInfo[] properties = objListType.GetProperties();
          for (int index = 0; index < properties.Length; ++index)
          {
            if ("Item".Equals(properties[index].Name) && properties[index].PropertyType != typeof (object))
              return TypeDescriptor.GetProperties(properties[index].PropertyType, new Attribute[1]
              {
                (Attribute) new BrowsableAttribute(true)
              });
          }
          return !(objDataSources[intOffset - 1] is IList objDataSource) || objDataSource.Count <= 0 ? (PropertyDescriptorCollection) null : TypeDescriptor.GetProperties(objDataSource[0]);
        }
        PropertyInfo[] properties1 = objListType.GetProperties();
        if (typeof (IList).IsAssignableFrom(objListType))
        {
          PropertyDescriptorCollection descriptorCollection = (PropertyDescriptorCollection) null;
          for (int index = 0; index < properties1.Length; ++index)
          {
            if ("Item".Equals(properties1[index].Name) && properties1[index].PropertyType != typeof (object))
              descriptorCollection = TypeDescriptor.GetProperties(properties1[index].PropertyType, new Attribute[1]
              {
                (Attribute) new BrowsableAttribute(true)
              });
          }
          if (descriptorCollection == null)
          {
            IList list = intOffset != 0 ? objDataSources[intOffset - 1] as IList : this.DataSource as IList;
            if (list != null && list.Count > 0)
              descriptorCollection = TypeDescriptor.GetProperties(list[0]);
          }
          if (descriptorCollection != null)
          {
            for (int index = 0; index < descriptorCollection.Count; ++index)
            {
              if (descriptorCollection[index].Equals(objListAccessors[intOffset]))
                return this.GetItemProperties(descriptorCollection[index].PropertyType, intOffset + 1, objDataSources, objListAccessors);
            }
          }
        }
        else
        {
          for (int index = 0; index < properties1.Length; ++index)
          {
            if (properties1[index].Name.Equals(((MemberDescriptor) objListAccessors[intOffset]).Name))
              return this.GetItemProperties(properties1[index].PropertyType, intOffset + 1, objDataSources, objListAccessors);
          }
        }
      }
      return (PropertyDescriptorCollection) null;
    }

    internal abstract string GetListName();

    /// <summary>When overridden in a derived class, gets the name of the list supplying the data for the binding.</summary>
    /// <returns>The name of the list supplying the data for the binding.</returns>
    /// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> containing the table's bound properties. </param>
    protected internal abstract string GetListName(ArrayList objListAccessors);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.BindingComplete"></see> event. </summary>
    /// <param name="objEventArgs">A <see cref="T:Gizmox.WebGUI.Forms.BindingCompleteEventArgs"></see>  that contains the event data. </param>
    protected internal void OnBindingComplete(BindingCompleteEventArgs objEventArgs)
    {
      if (this.BindingComplete == null)
        return;
      this.BindingComplete((object) this, objEventArgs);
    }

    private void OnBindingsCollectionChanged(object sender, CollectionChangeEventArgs e)
    {
      Binding element = e.Element as Binding;
      switch (e.Action)
      {
        case CollectionChangeAction.Add:
          element.BindingComplete += new BindingCompleteEventHandler(this.Binding_BindingComplete);
          break;
        case CollectionChangeAction.Remove:
          element.BindingComplete -= new BindingCompleteEventHandler(this.Binding_BindingComplete);
          break;
        case CollectionChangeAction.Refresh:
          IEnumerator enumerator = this.mobjBindings.GetEnumerator();
          try
          {
            while (enumerator.MoveNext())
              ((Binding) enumerator.Current).BindingComplete += new BindingCompleteEventHandler(this.Binding_BindingComplete);
            break;
          }
          finally
          {
            if (enumerator is IDisposable disposable)
              disposable.Dispose();
          }
      }
    }

    private void OnBindingsCollectionChanging(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Refresh)
        return;
      foreach (Binding mobjBinding in (BaseCollection) this.mobjBindings)
        mobjBinding.BindingComplete -= new BindingCompleteEventHandler(this.Binding_BindingComplete);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentChanged"></see> event.</summary>
    /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected internal abstract void OnCurrentChanged(EventArgs e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.</summary>
    /// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected internal abstract void OnCurrentItemChanged(EventArgs e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event.</summary>
    /// <param name="objException">An <see cref="T:System.Exception"></see> that caused the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.DataError"></see> event to occur.</param>
    protected internal void OnDataError(Exception objException)
    {
      BindingManagerDataErrorEventHandler dataError = this.DataError;
      if (dataError == null)
        return;
      dataError((object) this, new BindingManagerDataErrorEventArgs(objException));
    }

    /// <summary>Pulls data from the data-bound control into the data source, returning no information.</summary>
    protected void PullData() => this.PullData(out bool _);

    internal void PullData(out bool blnSuccess)
    {
      blnSuccess = true;
      this.mblnPullingData = true;
      try
      {
        this.UpdateIsBinding();
        int count = this.Bindings.Count;
        for (int index = 0; index < count; ++index)
        {
          if (this.Bindings[index].PullData())
            blnSuccess = false;
        }
      }
      finally
      {
        this.mblnPullingData = false;
      }
    }

    /// <summary>Pushes data from the data source into the data-bound control, returning no information.</summary>
    protected void PushData() => this.PushData(out bool _);

    internal void PushData(out bool blnSuccess)
    {
      blnSuccess = true;
      if (this.mblnPullingData)
        return;
      this.UpdateIsBinding();
      int count = this.Bindings.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.Bindings[index].PushData())
          blnSuccess = false;
      }
    }

    /// <summary>When overridden in a derived class, deletes the row at the specified index from the underlying list.</summary>
    /// <param name="index">The index of the row to delete. </param>
    /// <exception cref="T:System.IndexOutOfRangeException">There is no row at the specified index. </exception>
    /// <filterpriority>1</filterpriority>
    public abstract void RemoveAt(int index);

    /// <summary>When overridden in a derived class, resumes data binding.</summary>
    /// <filterpriority>1</filterpriority>
    public abstract void ResumeBinding();

    internal abstract void SetDataSource(object objDataSource);

    /// <summary>When overridden in a derived class, suspends data binding.</summary>
    /// <filterpriority>1</filterpriority>
    public abstract void SuspendBinding();

    /// <summary>When overridden in a derived class, updates the binding.</summary>
    protected abstract void UpdateIsBinding();

    /// <summary>Gets the collection of bindings being managed.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.BindingsCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects managed by this <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public BindingsCollection Bindings
    {
      get
      {
        if (this.mobjBindings == null)
        {
          this.mobjBindings = (BindingsCollection) new ListManagerBindingsCollection(this);
          this.mobjBindings.CollectionChanging += new CollectionChangeEventHandler(this.OnBindingsCollectionChanging);
          this.mobjBindings.CollectionChanged += new CollectionChangeEventHandler(this.OnBindingsCollectionChanged);
        }
        return this.mobjBindings;
      }
    }

    internal int BindingsCount => this.mobjBindings != null ? this.mobjBindings.Count : 0;

    internal abstract Type BindType { get; }

    /// <summary>When overridden in a derived class, gets the number of rows managed by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</summary>
    /// <returns>The number of rows managed by the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public abstract int Count { get; }

    /// <summary>When overridden in a derived class, gets the current object.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the current object.</returns>
    /// <filterpriority>1</filterpriority>
    public abstract object Current { get; }

    internal abstract object DataSource { get; }

    internal abstract bool IsBinding { get; }

    /// <summary>Gets a value indicating whether binding is suspended.</summary>
    /// <returns>true if binding is suspended; otherwise, false.</returns>
    public bool IsBindingSuspended => !this.IsBinding;

    /// <summary>When overridden in a derived class, gets or sets the position in the underlying list that controls bound to this data source point to.</summary>
    /// <returns>A zero-based index that specifies a position in the underlying list.</returns>
    /// <filterpriority>1</filterpriority>
    public abstract int Position { get; set; }

    /// <summary>Fires the current changed.</summary>
    /// <param name="objSource">The obj source.</param>
    /// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected void FireCurrentChanged(object objSource, EventArgs objArgs)
    {
      if (this.CurrentChanged == null)
        return;
      this.CurrentChanged(objSource, objArgs);
    }

    /// <summary>Fires the current item changed.</summary>
    /// <param name="objSource">The obj source.</param>
    /// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected void FireCurrentItemChanged(object objSource, EventArgs objArgs)
    {
      if (this.CurrentItemChanged == null)
        return;
      this.CurrentItemChanged(objSource, objArgs);
    }

    /// <summary>Fires the position changed.</summary>
    /// <param name="objSource">The obj source.</param>
    /// <param name="objArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected void FirePositionChanged(object objSource, EventArgs objArgs)
    {
      if (this.PositionChanged == null)
        return;
      this.PositionChanged(objSource, objArgs);
    }
  }
}

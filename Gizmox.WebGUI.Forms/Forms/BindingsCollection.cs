// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingsCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects for a control.</summary>
  /// <filterpriority>2</filterpriority>
  [DefaultEvent("CollectionChanged")]
  [Serializable]
  public class BindingsCollection : BaseCollection
  {
    private ArrayList mobjList;

    /// <summary>Occurs when the collection has changed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("collectionChangedEventDescr")]
    public event CollectionChangeEventHandler CollectionChanged;

    /// <summary>Occurs when the collection is about to change.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("collectionChangingEventDescr")]
    public event CollectionChangeEventHandler CollectionChanging;

    internal BindingsCollection()
    {
    }

    /// <summary>Adds the specified binding to the collection.</summary>
    /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add to the collection. </param>
    protected internal void Add(Binding objBinding)
    {
      CollectionChangeEventArgs collectionChangeEventArgs = new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) objBinding);
      this.OnCollectionChanging(collectionChangeEventArgs);
      this.AddCore(objBinding);
      this.OnCollectionChanged(collectionChangeEventArgs);
    }

    /// <summary>Adds a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to the collection.</summary>
    /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to add to the collection.</param>
    /// <exception cref="T:System.ArgumentNullException">The dataBinding argument was null. </exception>
    protected virtual void AddCore(Binding objDataBinding)
    {
      if (objDataBinding == null)
        throw new ArgumentNullException("dataBinding");
      this.List.Add((object) objDataBinding);
    }

    /// <summary>Clears the collection of binding objects.</summary>
    protected internal void Clear()
    {
      CollectionChangeEventArgs collectionChangeEventArgs = new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null);
      this.OnCollectionChanging(collectionChangeEventArgs);
      this.ClearCore();
      this.OnCollectionChanged(collectionChangeEventArgs);
    }

    /// <summary>Clears the collection of any members.</summary>
    protected virtual void ClearCore() => this.List.Clear();

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingsCollection.CollectionChanged"></see> event.</summary>
    /// <param name="objCcevent">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
    protected virtual void OnCollectionChanged(CollectionChangeEventArgs objCcevent)
    {
      CollectionChangeEventHandler collectionChanged = this.CollectionChanged;
      if (collectionChanged == null)
        return;
      collectionChanged((object) this, objCcevent);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingsCollection.CollectionChanging"></see> event. </summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains event data.</param>
    protected virtual void OnCollectionChanging(CollectionChangeEventArgs e)
    {
      CollectionChangeEventHandler collectionChanging = this.CollectionChanging;
      if (collectionChanging == null)
        return;
      collectionChanging((object) this, e);
    }

    /// <summary>Deletes the specified binding from the collection.</summary>
    /// <param name="objBinding">The Binding to remove from the collection. </param>
    protected internal void Remove(Binding objBinding)
    {
      CollectionChangeEventArgs collectionChangeEventArgs = new CollectionChangeEventArgs(CollectionChangeAction.Remove, (object) objBinding);
      this.OnCollectionChanging(collectionChangeEventArgs);
      this.RemoveCore(objBinding);
      this.OnCollectionChanged(collectionChangeEventArgs);
    }

    /// <summary>Deletes the binding from the collection at the specified index.</summary>
    /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove. </param>
    protected internal void RemoveAt(int index) => this.Remove(this[index]);

    /// <summary>Removes the specified <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> from the collection.</summary>
    /// <param name="objDataBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to remove. </param>
    protected virtual void RemoveCore(Binding objDataBinding) => this.List.Remove((object) objDataBinding);

    /// <summary>Gets a value that indicates whether the collection should be serialized.</summary>
    /// <returns>true if the collection count is greater than zero; otherwise, false.</returns>
    protected internal bool ShouldSerializeMyAll() => this.Count > 0;

    /// <summary>Gets the total number of bindings in the collection.</summary>
    /// <returns>The total number of bindings in the collection.</returns>
    /// <filterpriority>1</filterpriority>
    public override int Count => this.mobjList == null ? 0 : base.Count;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> at the specified index.</returns>
    /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to find. </param>
    /// <exception cref="T:System.IndexOutOfRangeException">The collection doesn't contain an item at the specified index. </exception>
    /// <filterpriority>1</filterpriority>
    public Binding this[int index] => (Binding) this.List[index];

    /// <summary>Gets the bindings in the collection as an object.</summary>
    /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing all of the collection members.</returns>
    protected override ArrayList List
    {
      get
      {
        if (this.mobjList == null)
          this.mobjList = new ArrayList();
        return this.mobjList;
      }
    }
  }
}

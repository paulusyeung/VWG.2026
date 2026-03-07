// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BindingContext
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Manages the collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for any object that inherits from the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class.</summary>
  /// <filterpriority>2</filterpriority>
  [DefaultEvent("CollectionChanged")]
  [Serializable]
  public class BindingContext : ICollection, IEnumerable
  {
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private Hashtable listManagers;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> class.</summary>
    public BindingContext() => this.listManagers = new Hashtable();

    /// <summary>Occurs when the collection has changed.</summary>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("collectionChangedEventDescr")]
    [Browsable(false)]
    public event CollectionChangeEventHandler CollectionChanged
    {
      add => throw new NotImplementedException();
      remove
      {
      }
    }

    /// <summary>Adds the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with a specific data source to the collection.</summary>
    /// <param name="objDataSource">The <see cref="T:System.Object"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
    /// <param name="objListManager">The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to add. </param>
    protected internal void Add(object objDataSource, BindingManagerBase objListManager)
    {
      this.AddCore(objDataSource, objListManager);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataSource));
    }

    /// <summary>Adds the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with a specific data source to the collection.</summary>
    /// <param name="objDataSource">The object associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
    /// <param name="objListManager">The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to add.</param>
    /// <exception cref="T:System.ArgumentNullException">dataSource is null.-or-listManager is null.</exception>
    protected virtual void AddCore(object objDataSource, BindingManagerBase objListManager)
    {
      if (objDataSource == null)
        throw new ArgumentNullException("dataSource");
      this.listManagers[(object) this.GetKey(objDataSource, "")] = objListManager != null ? (object) new WeakReference((object) objListManager, false) : throw new ArgumentNullException("listManager");
    }

    private static void CheckPropertyBindingCycles(
      BindingContext newBindingContext,
      Binding propBinding)
    {
      if (newBindingContext == null || propBinding == null || !newBindingContext.Contains((object) propBinding.BindableComponent, ""))
        return;
      BindingManagerBase bindingManagerBase = newBindingContext.EnsureListManager((object) propBinding.BindableComponent, "");
      for (int index = 0; index < bindingManagerBase.Bindings.Count; ++index)
      {
        Binding binding = bindingManagerBase.Bindings[index];
        if (binding.DataSource == propBinding.BindableComponent)
        {
          if (propBinding.BindToObject.BindingMemberInfo.BindingMember.Equals(binding.PropertyName))
            throw new ArgumentException(SR.GetString("DataBindingCycle", (object) binding.PropertyName), nameof (propBinding));
        }
        else if (propBinding.BindToObject.BindingManagerBase is PropertyManager)
          BindingContext.CheckPropertyBindingCycles(newBindingContext, binding);
      }
    }

    /// <summary>Clears the collection of any <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects.</summary>
    protected internal void Clear()
    {
      this.ClearCore();
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null));
    }

    /// <summary>Clears the collection.</summary>
    protected virtual void ClearCore() => this.listManagers.Clear();

    /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the specified <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>; otherwise, false.</returns>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
    /// <filterpriority>1</filterpriority>
    public bool Contains(object objDataSource) => this.Contains(objDataSource, "");

    /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source and data member.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> contains the specified <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>; otherwise, false.</returns>
    /// <param name="objDataSource">An <see cref="T:System.Object"></see> that represents the data source. </param>
    /// <param name="strDataMember">The information needed to resolve to a specific <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
    /// <filterpriority>1</filterpriority>
    public bool Contains(object objDataSource, string strDataMember) => this.listManagers.ContainsKey((object) this.GetKey(objDataSource, strDataMember));

    internal BindingManagerBase EnsureListManager(object objDataSource, string strDataMember)
    {
      BindingManagerBase target = (BindingManagerBase) null;
      if (strDataMember == null)
        strDataMember = "";
      if (objDataSource is ICurrencyManagerProvider)
      {
        target = (BindingManagerBase) (objDataSource as ICurrencyManagerProvider).GetRelatedCurrencyManager(strDataMember);
        if (target != null)
          return target;
      }
      BindingContext.HashKey key = this.GetKey(objDataSource, strDataMember);
      if (this.listManagers == null)
        this.listManagers = new Hashtable();
      if (this.listManagers[(object) key] is WeakReference listManager)
        target = (BindingManagerBase) listManager.Target;
      if (target == null)
      {
        if (strDataMember.Length == 0)
        {
          switch (objDataSource)
          {
            case IList _:
            case IListSource _:
              target = (BindingManagerBase) new CurrencyManager(objDataSource);
              break;
            default:
              target = (BindingManagerBase) new PropertyManager(objDataSource);
              break;
          }
        }
        else
        {
          int length = strDataMember.LastIndexOf(".");
          string strDataMember1 = length == -1 ? "" : strDataMember.Substring(0, length);
          string str = strDataMember.Substring(length + 1);
          BindingManagerBase objParentManager = this.EnsureListManager(objDataSource, strDataMember1);
          PropertyDescriptor propertyDescriptor = objParentManager.GetItemProperties().Find(str, true);
          if (propertyDescriptor == null)
            throw new ArgumentException(SR.GetString("RelatedListManagerChild", (object) str));
          target = !typeof (IList).IsAssignableFrom(propertyDescriptor.PropertyType) ? (BindingManagerBase) new RelatedPropertyManager(objParentManager, str) : (BindingManagerBase) new RelatedCurrencyManager(objParentManager, str);
        }
        if (listManager == null)
        {
          this.listManagers.Add((object) key, (object) new WeakReference((object) target, false));
          return target;
        }
        listManager.Target = (object) target;
      }
      return target;
    }

    internal BindingContext.HashKey GetKey(object objDataSource, string strDataMember) => new BindingContext.HashKey(objDataSource, strDataMember);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingContext.CollectionChanged"></see> event.</summary>
    /// <param name="objCcevent">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data.</param>
    protected virtual void OnCollectionChanged(CollectionChangeEventArgs objCcevent)
    {
    }

    /// <summary>Deletes the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
    /// <param name="objDataSource">The data source associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to remove. </param>
    protected internal void Remove(object objDataSource)
    {
      this.RemoveCore(objDataSource);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, objDataSource));
    }

    /// <summary>Removes the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> associated with the specified data source.</summary>
    /// <param name="objDataSource">The data source associated with the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> to remove.</param>
    protected virtual void RemoveCore(object objDataSource) => this.listManagers.Remove((object) this.GetKey(objDataSource, ""));

    private void ScrubWeakRefs()
    {
      object[] objArray = new object[this.listManagers.Count];
      this.listManagers.CopyTo((Array) objArray, 0);
      for (int index = 0; index < objArray.Length; ++index)
      {
        DictionaryEntry dictionaryEntry = (DictionaryEntry) objArray[index];
        if (((WeakReference) dictionaryEntry.Value).Target == null)
          this.listManagers.Remove(dictionaryEntry.Key);
      }
    }

    void ICollection.CopyTo(Array objArray, int index)
    {
      this.ScrubWeakRefs();
      this.listManagers.CopyTo(objArray, index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      this.ScrubWeakRefs();
      return (IEnumerator) this.listManagers.GetEnumerator();
    }

    /// <summary>Associates a <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> with a new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see>.</summary>
    /// <param name="objBinding">The <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> to associate with the new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see>.</param>
    /// <param name="objNewBindingContext">The new <see cref="T:Gizmox.WebGUI.Forms.BindingContext"></see> to associate with the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see>.</param>
    /// <filterpriority>1</filterpriority>
    public static void UpdateBinding(BindingContext objNewBindingContext, Binding objBinding)
    {
      objBinding.BindingManagerBase?.Bindings.Remove(objBinding);
      if (objNewBindingContext == null)
        return;
      if (objBinding.BindToObject.BindingManagerBase is PropertyManager)
        BindingContext.CheckPropertyBindingCycles(objNewBindingContext, objBinding);
      BindToObject bindToObject = objBinding.BindToObject;
      objNewBindingContext.EnsureListManager(bindToObject.DataSource, bindToObject.BindingMemberInfo.BindingPath).Bindings.Add(objBinding);
    }

    /// <summary>Gets a value indicating whether the collection is read-only.</summary>
    /// <returns>true if the collection is read-only; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    public bool IsReadOnly => false;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that is associated with the specified data source.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for the specified data source.</returns>
    /// <param name="objDataSource">The data source associated with a particular <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
    /// <filterpriority>1</filterpriority>
    public BindingManagerBase this[object objDataSource] => this[objDataSource, ""];

    /// <summary>Gets a <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> that is associated with the specified data source and data member.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> for the specified data source and data member.</returns>
    /// <param name="objDataSource">The data source associated with a particular <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
    /// <param name="strDataMember">A navigation path containing the information that resolves to a specific <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see>. </param>
    /// <exception cref="T:System.Exception">The specified dataMember does not exist within the data source. </exception>
    /// <filterpriority>1</filterpriority>
    public BindingManagerBase this[object objDataSource, string strDataMember] => this.EnsureListManager(objDataSource, strDataMember);

    int ICollection.Count
    {
      get
      {
        this.ScrubWeakRefs();
        return this.listManagers.Count;
      }
    }

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => (object) null;

    [Serializable]
    internal class HashKey
    {
      private string mstrDataMember;
      private int mintDataSourceHashCode;
      private WeakReference wRef;

      internal HashKey(object objDataSource, string strDataMember)
      {
        if (objDataSource == null)
          throw new ArgumentNullException("dataSource");
        if (strDataMember == null)
          strDataMember = "";
        this.wRef = new WeakReference(objDataSource, false);
        this.mintDataSourceHashCode = objDataSource.GetHashCode();
        this.mstrDataMember = strDataMember.ToLower(CultureInfo.InvariantCulture);
      }

      public override bool Equals(object objTarget)
      {
        if (objTarget is BindingContext.HashKey)
        {
          BindingContext.HashKey hashKey = (BindingContext.HashKey) objTarget;
          if (this.wRef.Target == hashKey.wRef.Target)
            return this.mstrDataMember == hashKey.mstrDataMember;
        }
        return false;
      }

      public override int GetHashCode() => this.mintDataSourceHashCode * this.mstrDataMember.GetHashCode();
    }
  }
}

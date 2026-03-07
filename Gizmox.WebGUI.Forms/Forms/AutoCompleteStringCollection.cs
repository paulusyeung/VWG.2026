// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.AutoCompleteStringCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class AutoCompleteStringCollection : IList, ICollection, IEnumerable
  {
    private ArrayList mobjData = new ArrayList();
    private CollectionChangeEventHandler mobjCollectionChanged;

    /// <filterpriority>1</filterpriority>
    public int Count => this.mobjData.Count;

    bool IList.IsFixedSize => false;

    bool IList.IsReadOnly => false;

    object IList.this[int index]
    {
      get => (object) this[index];
      set => this[index] = (string) value;
    }

    /// <filterpriority>1</filterpriority>
    public bool IsReadOnly => false;

    /// <filterpriority>2</filterpriority>
    public bool IsSynchronized => false;

    /// <filterpriority>1</filterpriority>
    public object SyncRoot => (object) this;

    /// <filterpriority>1</filterpriority>
    public string this[int index]
    {
      get => (string) this.mobjData[index];
      set
      {
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, this.mobjData[index]));
        this.mobjData[index] = (object) value;
        this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) value));
      }
    }

    /// <summary>Occurs when [collection changed].</summary>
    public event CollectionChangeEventHandler CollectionChanged
    {
      add => this.mobjCollectionChanged += value;
      remove => this.mobjCollectionChanged -= value;
    }

    /// <filterpriority>1</filterpriority>
    public int Add(string value)
    {
      int num = this.mobjData.Add((object) value);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) value));
      return num;
    }

    /// <filterpriority>1</filterpriority>
    public void AddRange(string[] value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      this.mobjData.AddRange((ICollection) value);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null));
    }

    /// <filterpriority>1</filterpriority>
    public void Clear()
    {
      this.mobjData.Clear();
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, (object) null));
    }

    /// <filterpriority>1</filterpriority>
    public bool Contains(string value) => this.mobjData.Contains((object) value);

    /// <filterpriority>1</filterpriority>
    public void CopyTo(string[] array, int index) => this.mobjData.CopyTo((Array) array, index);

    /// <filterpriority>1</filterpriority>
    public IEnumerator GetEnumerator() => this.mobjData.GetEnumerator();

    /// <filterpriority>1</filterpriority>
    public int IndexOf(string value) => this.mobjData.IndexOf((object) value);

    /// <filterpriority>1</filterpriority>
    public void Insert(int index, string value)
    {
      this.mobjData.Insert(index, (object) value);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, (object) value));
    }

    /// <filterpriority>1</filterpriority>
    public void Remove(string value)
    {
      this.mobjData.Remove((object) value);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, (object) value));
    }

    /// <filterpriority>1</filterpriority>
    public void RemoveAt(int index)
    {
      string element = (string) this.mobjData[index];
      this.mobjData.RemoveAt(index);
      this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, (object) element));
    }

    protected void OnCollectionChanged(CollectionChangeEventArgs e)
    {
      if (this.mobjCollectionChanged == null)
        return;
      this.mobjCollectionChanged((object) this, e);
    }

    void ICollection.CopyTo(Array array, int index) => this.mobjData.CopyTo(array, index);

    int IList.Add(object value) => this.Add((string) value);

    bool IList.Contains(object value) => this.Contains((string) value);

    int IList.IndexOf(object value) => this.IndexOf((string) value);

    void IList.Insert(int index, object value) => this.Insert(index, (string) value);

    void IList.Remove(object value) => this.Remove((string) value);
  }
}

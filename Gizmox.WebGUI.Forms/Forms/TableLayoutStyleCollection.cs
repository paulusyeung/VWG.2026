// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutStyleCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [Serializable]
  public abstract class TableLayoutStyleCollection : IList, ICollection, IEnumerable, IObservableList
  {
    private ArrayList mobjInnerList = new ArrayList();
    private IArrangedElement mobjOwner;

    /// <summary>Occurs when [observable item added].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableListEventHandler ObservableItemAdded;

    /// <summary>Occurs when [observable item inserted].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableListEventHandler ObservableItemInserted;

    /// <summary>Occurs when [observable item removed].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableListEventHandler ObservableItemRemoved;

    /// <summary>Occurs when [observable list cleared].</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event EventHandler ObservableListCleared;

    internal TableLayoutStyleCollection(IArrangedElement objOwner) => this.mobjOwner = objOwner;

    /// <summary>
    /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The number of elements contained in the <see cref="T:System.Collections.ICollection" />.
    /// </returns>
    public int Count => this.mobjInnerList.Count;

    bool ICollection.IsSynchronized => this.mobjInnerList.IsSynchronized;

    object ICollection.SyncRoot => this.mobjInnerList.SyncRoot;

    bool IList.IsFixedSize => this.mobjInnerList.IsFixedSize;

    bool IList.IsReadOnly => this.mobjInnerList.IsReadOnly;

    object IList.this[int index]
    {
      get => this.mobjInnerList[index];
      set
      {
        TableLayoutStyle objStyle = (TableLayoutStyle) value;
        this.EnsureNotOwned(objStyle);
        objStyle.Owner = this.Owner;
        this.mobjInnerList[index] = (object) objStyle;
        this.PerformLayoutIfOwned();
      }
    }

    internal IArrangedElement Owner => this.mobjOwner;

    internal virtual string PropertyName => (string) null;

    /// <summary>
    /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutStyle" /> at the specified index.
    /// </summary>
    /// <value></value>
    public TableLayoutStyle this[int index]
    {
      get => (TableLayoutStyle) ((IList) this)[index];
      set => ((IList) this)[index] = (object) value;
    }

    /// <summary>Adds the specified style.</summary>
    /// <param name="objStyle">The style.</param>
    /// <returns></returns>
    public int Add(TableLayoutStyle objStyle)
    {
      int num = ((IList) this).Add((object) objStyle);
      if (this.ObservableItemAdded == null)
        return num;
      this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objStyle));
      return num;
    }

    /// <summary>
    /// Removes all items from the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.IList" /> is read-only.
    /// </exception>
    public void Clear()
    {
      foreach (TableLayoutStyle mobjInner in this.mobjInnerList)
        mobjInner.Owner = (IArrangedElement) null;
      this.mobjInnerList.Clear();
      this.PerformLayoutIfOwned();
      if (this.ObservableListCleared == null)
        return;
      this.ObservableListCleared((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Removes the <see cref="T:System.Collections.IList" /> item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// 	<paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.IList" /> is read-only.
    /// -or-
    /// The <see cref="T:System.Collections.IList" /> has a fixed size.
    /// </exception>
    public void RemoveAt(int index)
    {
      TableLayoutStyle mobjInner = (TableLayoutStyle) this.mobjInnerList[index];
      mobjInner.Owner = (IArrangedElement) null;
      this.mobjInnerList.RemoveAt(index);
      this.PerformLayoutIfOwned();
      if (this.ObservableItemRemoved == null)
        return;
      this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) mobjInner));
    }

    private void EnsureNotOwned(TableLayoutStyle objStyle)
    {
      if (objStyle.Owner != null)
        throw new ArgumentException(SR.GetString("OnlyOneControl", (object) objStyle.GetType().Name), "style");
    }

    void ICollection.CopyTo(Array objArray, int intStartIndex) => this.mobjInnerList.CopyTo(objArray, intStartIndex);

    IEnumerator IEnumerable.GetEnumerator() => this.mobjInnerList.GetEnumerator();

    int IList.Add(object objStyle)
    {
      this.EnsureNotOwned((TableLayoutStyle) objStyle);
      ((TableLayoutStyle) objStyle).Owner = this.Owner;
      int num = this.mobjInnerList.Add(objStyle);
      this.PerformLayoutIfOwned();
      return num;
    }

    bool IList.Contains(object objStyle) => this.mobjInnerList.Contains(objStyle);

    int IList.IndexOf(object objStyle) => this.mobjInnerList.IndexOf(objStyle);

    void IList.Insert(int intIndex, object objStyle)
    {
      this.EnsureNotOwned((TableLayoutStyle) objStyle);
      ((TableLayoutStyle) objStyle).Owner = this.Owner;
      this.mobjInnerList.Insert(intIndex, objStyle);
      if (this.ObservableItemInserted != null)
        this.ObservableItemInserted((object) this, new ObservableListEventArgs(objStyle));
      this.PerformLayoutIfOwned();
    }

    void IList.Remove(object objStyle)
    {
      ((TableLayoutStyle) objStyle).Owner = (IArrangedElement) null;
      this.mobjInnerList.Remove(objStyle);
      this.PerformLayoutIfOwned();
    }

    private void PerformLayoutIfOwned()
    {
    }

    internal void EnsureOwnership(IArrangedElement objOwner)
    {
      this.mobjOwner = objOwner;
      for (int index = 0; index < this.Count; ++index)
        this[index].Owner = objOwner;
    }
  }
}

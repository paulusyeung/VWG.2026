// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolBarItemCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ToolBarItemCollection : ICollection, IEnumerable, IList, IObservableList
  {
    private ArrayList mobjButtons;
    private ToolBar mobjToolBar;

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ToolBarItemCollection" /> instance.
    /// </summary>
    /// <param name="objToolBar">The obj tool bar.</param>
    public ToolBarItemCollection(ToolBar objToolBar)
    {
      this.mobjToolBar = objToolBar;
      this.mobjButtons = new ArrayList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToolBarButton"></param>
    /// <returns></returns>
    public int Add(ToolBarButton objToolBarButton)
    {
      int num = -1;
      if (objToolBarButton != null)
      {
        objToolBarButton.ToolBar = this.mobjToolBar;
        objToolBarButton.InternalParent = (Component) this.mobjToolBar;
        num = this.List.Add((object) objToolBarButton);
        this.mobjToolBar.InvalidateLayout(new LayoutEventArgs(false, true, true));
        this.mobjToolBar.Update();
        if (this.ObservableItemAdded != null)
          this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objToolBarButton));
      }
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrToolBarButtons"></param>
    public void AddRange(ToolBarButton[] arrToolBarButtons)
    {
      foreach (ToolBarButton arrToolBarButton in arrToolBarButtons)
        this.Add(arrToolBarButton);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToolBarButton"></param>
    public void Remove(ToolBarButton objToolBarButton)
    {
      if (objToolBarButton == null)
        return;
      if (objToolBarButton.ToolBar == this.mobjToolBar)
        objToolBarButton.ToolBar = (ToolBar) null;
      this.mobjToolBar.InternalRemove(objToolBarButton);
      this.List.Remove((object) objToolBarButton);
      this.mobjToolBar.InvalidateLayout(new LayoutEventArgs(false, true, true));
      this.mobjToolBar.Update();
      if (this.ObservableItemRemoved == null)
        return;
      this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) objToolBarButton));
    }

    /// <summary>
    /// Removes all items from the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.IList" /> is read-only.
    /// </exception>
    public void Clear()
    {
      this.mobjToolBar.InternalClear((ICollection) this.List);
      this.mobjButtons.Clear();
      if (this.ObservableListCleared == null)
        return;
      this.ObservableListCleared((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Return the index of objToolBarButton in the Buttons collection
    /// </summary>
    /// <param name="objToolBarButton"></param>
    public int IndexOf(ToolBarButton objToolBarButton) => this.mobjButtons.IndexOf((object) objToolBarButton);

    /// <summary>Gets the list.</summary>
    /// <value>The list.</value>
    protected virtual ArrayList List => this.mobjButtons;

    /// <summary>
    /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton" /> with the specified int index.
    /// </summary>
    /// <value></value>
    public ToolBarButton this[int intIndex]
    {
      get => (ToolBarButton) this.List[intIndex];
      set
      {
        value.InternalParent = (Component) this.mobjToolBar;
        this.List[intIndex] = (object) value;
      }
    }

    bool IList.IsReadOnly => false;

    object IList.this[int index]
    {
      get => (object) this[index];
      set => this[index] = (ToolBarButton) value;
    }

    void IList.RemoveAt(int index) => this.Remove(this[index]);

    void IList.Insert(int index, object objValue)
    {
    }

    void IList.Remove(object objValue) => this.Remove((ToolBarButton) objValue);

    bool IList.Contains(object objValue) => this.mobjButtons.Contains(objValue);

    int IList.IndexOf(object objValue) => this.mobjButtons.IndexOf(objValue);

    int IList.Add(object objValue) => this.Add((ToolBarButton) objValue);

    bool IList.IsFixedSize => false;

    bool ICollection.IsSynchronized => this.mobjButtons.IsSynchronized;

    /// <summary>
    /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The number of elements contained in the <see cref="T:System.Collections.ICollection" />.
    /// </returns>
    public int Count => this.mobjButtons.Count;

    void ICollection.CopyTo(Array objArray, int index) => this.List.CopyTo(objArray, index);

    object ICollection.SyncRoot => this.mobjButtons.SyncRoot;

    IEnumerator IEnumerable.GetEnumerator() => this.mobjButtons.GetEnumerator();

    /// <summary>Occurs when [observable item inserted].</summary>
    public event ObservableListEventHandler ObservableItemInserted;

    /// <summary>Occurs when [observable item added].</summary>
    public event ObservableListEventHandler ObservableItemAdded;

    /// <summary>Occurs when [observable list cleared].</summary>
    public event EventHandler ObservableListCleared;

    /// <summary>Occurs when [observable item removed].</summary>
    public event ObservableListEventHandler ObservableItemRemoved;
  }
}

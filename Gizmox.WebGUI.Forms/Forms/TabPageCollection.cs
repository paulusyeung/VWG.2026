// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TabPageCollection
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
  /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects.
  /// </summary>
  [Serializable]
  public class TabPageCollection : ICollection, IEnumerable, IList, IComparer
  {
    /// <summary>The owner tab control</summary>
    private TabControl mobjTabControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> class.
    /// </summary>
    /// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> that this collection belongs to. </param>
    /// <exception cref="T:System.ArgumentNullException">The specified <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> is null. </exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public TabPageCollection(TabControl objOwner) => this.mobjTabControl = objOwner;

    /// <summary>Gets or sets the owner.</summary>
    /// <value>The owner.</value>
    protected TabControl Owner => this.mobjTabControl;

    /// <summary>
    /// Gets a value indicating whether access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is synchronized (thread safe).
    /// </summary>
    /// <returns>false in all cases.</returns>
    public bool IsSynchronized => ((ICollection) this.mobjTabControl.Controls).IsSynchronized;

    /// <summary>Gets the number of tab pages in the collection.</summary>
    /// <returns>The number of tab pages in the collection.</returns>
    [Browsable(false)]
    public int Count => this.mobjTabControl.Controls.Count;

    /// <summary>
    /// Copies the elements of the collection to the specified array, starting at the specified index.
    /// </summary>
    /// <param name="objDestArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in the array at which copying begins.</param>
    /// <exception cref="T:System.ArgumentException">dest is multidimensional.-or-index is equal to or greater than the length of dest.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is greater than the available space from index to the end of dest.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
    /// <exception cref="T:System.InvalidCastException">The items in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> cannot be cast automatically to the type of dest.</exception>
    /// <exception cref="T:System.ArgumentNullException">dest is null.</exception>
    public void CopyTo(Array objDestArray, int index) => this.mobjTabControl.Controls.CopyTo(objDestArray, index);

    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
    /// </summary>
    /// <returns>An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.</returns>
    public object SyncRoot => ((ICollection) this.mobjTabControl.Controls).SyncRoot;

    /// <summary>
    /// Adds a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to the collection.
    /// </summary>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to add. </param>
    /// <exception cref="T:System.ArgumentNullException">The specified value is null. </exception>
    public virtual int Add(TabPage objTabPage)
    {
      this.Insert(this.Count, (object) objTabPage);
      return this.mobjTabControl.Controls.IndexOf((Control) objTabPage);
    }

    /// <summary>
    /// Removes a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> from the collection.
    /// </summary>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove. </param>
    /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
    public virtual void Remove(TabPage objTabPage) => this.mobjTabControl.Controls.Remove((Control) objTabPage);

    /// <summary>
    /// Returns an enumeration of all the tab pages in the collection.
    /// </summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.</returns>
    public IEnumerator GetEnumerator() => this.mobjTabControl.Controls.GetEnumerator();

    /// <summary>
    /// Returns the index of the specified tab page in the collection.
    /// </summary>
    /// <returns>The zero-based index of the tab page; -1 if it cannot be found.</returns>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to locate in the collection. </param>
    /// <exception cref="T:System.ArgumentNullException">The value of page is null. </exception>
    public int IndexOf(TabPage objTabPage) => this.mobjTabControl.Controls.IndexOf((Control) objTabPage);

    /// <summary>
    /// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection.
    /// </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> at the specified index.</returns>
    /// <param name="index">The zero-based index of the tab page to get or set. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the highest available index. </exception>
    public TabPage this[int index] => (TabPage) this.mobjTabControl.Controls[index];

    /// <summary>
    /// Gets a value indicating whether the collection is read-only.
    /// </summary>
    /// <returns>This property always returns false.</returns>
    public bool IsReadOnly => false;

    /// <summary>
    /// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection.
    /// </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> at the specified index.</returns>
    /// <param name="index">The zero-based index of the element to get.</param>
    /// <exception cref="T:System.ArgumentException">The value is not a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see>.</exception>
    object IList.this[int index]
    {
      get => (object) this.mobjTabControl.Controls[index];
      set
      {
      }
    }

    /// <summary>
    /// Removes the tab page at the specified index from the collection.
    /// </summary>
    /// <param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove. </param>
    public void RemoveAt(int index) => this.mobjTabControl.Controls.RemoveAt(index);

    /// <summary>
    /// Inserts an existing tab page into the collection at the specified index.
    /// </summary>
    /// <param name="index">The location where the tab page is inserted.</param>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to insert in the collection.</param>
    public void Insert(int index, object objTabPage)
    {
      TabPage objValue = objTabPage as TabPage;
      Hashtable hashtable = new Hashtable();
      if (objValue == null)
        return;
      if (this.Count == 0)
      {
        this.mobjTabControl.Controls.Add((Control) objValue);
      }
      else
      {
        foreach (TabPage objTabPage1 in this)
        {
          hashtable.Add((object) objTabPage1.GetHashCode(), (object) objTabPage1.TabIndex);
          objTabPage1.TabIndex = this.IndexOf(objTabPage1);
        }
        if (index > this.Count || index < 0)
          index = this.Count;
        this.AdvanceTabIndexFromIndex((ushort) index, (ushort) 1);
        this.mobjTabControl.Controls.Add((Control) objValue);
        objValue.TabIndex = index;
        this.mobjTabControl.Controls.Sort((IComparer) new TabPageCollection.TabIndexComparer());
      }
    }

    /// <summary>
    /// Returns a sorted TabPage list from current unsorted TabPageCollection.
    /// </summary>
    /// <returns></returns>
    protected ArrayList GetSortedTabPageListFromCurrent(bool blnSortByIndex)
    {
      ArrayList pageListFromCurrent = new ArrayList();
      foreach (TabPage tabPage in this)
        pageListFromCurrent.Add((object) tabPage);
      if (blnSortByIndex)
        pageListFromCurrent.Sort((IComparer) this);
      else
        pageListFromCurrent.Sort((IComparer) new TabPageCollection.TabIndexComparer());
      return pageListFromCurrent;
    }

    /// <summary>
    /// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
    /// </summary>
    /// <param name="usrFromIndex">Index of the usr from.</param>
    /// <param name="usrAdvanceBy">The usr advance by.</param>
    protected void AdvanceTabIndexFromIndex(ushort usrFromIndex, ushort usrAdvanceBy)
    {
      if (this.Count < 2)
        return;
      ArrayList pageListFromCurrent = this.GetSortedTabPageListFromCurrent(true);
      this.AdvanceTabIndexFromIndex(ref pageListFromCurrent, usrFromIndex, usrAdvanceBy);
    }

    /// <summary>
    /// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
    /// </summary>
    /// <param name="objTabPageList">The obj tab page list.</param>
    /// <param name="usrFromIndex">Index of the usr from.</param>
    /// <param name="usrAdvanceBy">The usr advance by.</param>
    protected void AdvanceTabIndexFromIndex(
      ref ArrayList objTabPageList,
      ushort usrFromIndex,
      ushort usrAdvanceBy)
    {
      if (usrFromIndex < (ushort) 0 || usrAdvanceBy <= (ushort) 0 || (int) usrFromIndex > objTabPageList.Count - 1)
        return;
      for (ushort index = usrFromIndex; (int) index < objTabPageList.Count; ++index)
      {
        if (objTabPageList[(int) index] is TabPage tabPage)
          tabPage.TabIndex += (int) usrAdvanceBy;
      }
    }

    /// <summary>
    /// Removes a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> from the collection.
    /// </summary>
    /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
    void IList.Remove(object objValue) => this.mobjTabControl.Controls.Remove((Control) objValue);

    /// <summary>
    /// Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control is in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
    /// </summary>
    /// <returns>true if the specified object is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection; otherwise, false.</returns>
    /// <param name="objValue">The object to locate in the collection.</param>
    public bool Contains(object objValue) => this.mobjTabControl.Controls.Contains((Control) objValue);

    /// <summary>Removes all the tab pages from the collection.</summary>
    public void Clear() => this.mobjTabControl.Controls.Clear();

    /// <summary>
    /// Returns the index of the specified <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control in the collection.
    /// </summary>
    /// <returns>The zero-based index if page is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection; otherwise -1.</returns>
    /// <param name="objPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to locate in the collection.</param>
    int IList.IndexOf(object objPage) => objPage is TabPage ? this.IndexOf((TabPage) objPage) : -1;

    /// <summary>
    /// Adds a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control to the collection.
    /// </summary>
    /// <returns>The position into which the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> was inserted.</returns>
    /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to add to the collection.</param>
    /// <exception cref="T:System.ArgumentException">value is not a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see>.</exception>
    /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
    int IList.Add(object objValue) => objValue is TabPage ? this.Add((TabPage) objValue) : throw new ArgumentException("value");

    /// <summary>
    /// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> has a fixed size.
    /// </summary>
    /// <returns>false in all cases.</returns>
    public bool IsFixedSize => false;

    /// <summary>
    /// Compares the index of two sequencial TabPages in the TabPageCollection.
    /// </summary>
    /// <param name="objArgFirstTP">The first TabPage.</param>
    /// <param name="objArgSecondTP">The second TabPage.</param>
    /// <returns></returns>
    public int Compare(object objArgFirstTP, object objArgSecondTP)
    {
      TabPage objTabPage1 = objArgFirstTP as TabPage;
      TabPage objTabPage2 = objArgSecondTP as TabPage;
      return objTabPage1 == null || objTabPage2 == null ? 0 : this.IndexOf(objTabPage1).CompareTo(this.IndexOf(objTabPage2));
    }

    /// <summary>Implements IComparer for TabPages sorting by TabIndex</summary>
    /// <returns></returns>
    [Serializable]
    private class TabIndexComparer : IComparer
    {
      int IComparer.Compare(object objX, object objY)
      {
        TabPage tabPage1 = objX as TabPage;
        TabPage tabPage2 = objY as TabPage;
        return tabPage1 != null && tabPage2 != null ? tabPage1.TabIndex.CompareTo(tabPage2.TabIndex) : 0;
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProxyTabPageCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects.
  /// </summary>
  [Serializable]
  public class ProxyTabPageCollection : ICollection, IEnumerable, IList, IComparer
  {
    /// <summary>The mobj proxy tab control</summary>
    private ProxyTabControl mobjProxyTabControl;
    /// <summary>The mobj tab control</summary>
    private TabControl mobjTabControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ProxyTabPageCollection" /> class.
    /// </summary>
    /// <param name="objOwner">The object owner.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProxyTabPageCollection(ProxyTabControl objOwner)
    {
      this.mobjProxyTabControl = objOwner;
      this.mobjTabControl = this.mobjProxyTabControl.SourceComponent as TabControl;
    }

    /// <summary>Gets or sets the owner.</summary>
    /// <value>The owner.</value>
    protected ProxyTabControl Owner => this.mobjProxyTabControl;

    /// <summary>
    /// Gets a value indicating whether access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is synchronized (thread safe).
    /// </summary>
    /// <returns>false in all cases.</returns>
    public bool IsSynchronized => ((ICollection) this.mobjProxyTabControl.Components).IsSynchronized;

    /// <summary>Gets the number of tab pages in the collection.</summary>
    /// <returns>The number of tab pages in the collection.</returns>
    [Browsable(false)]
    public int Count => this.mobjProxyTabControl.Components.Count;

    /// <summary>
    /// Copies the elements of the collection to the specified array, starting at the specified index.
    /// </summary>
    /// <param name="objDestArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in the array at which copying begins.</param>
    /// <exception cref="T:System.ArgumentException">dest is multidimensional.-or-index is equal to or greater than the length of dest.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is greater than the available space from index to the end of dest.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
    /// <exception cref="T:System.InvalidCastException">The items in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> cannot be cast automatically to the type of dest.</exception>
    /// <exception cref="T:System.ArgumentNullException">dest is null.</exception>
    public void CopyTo(Array objDestArray, int index)
    {
      List<object> objectList = new List<object>();
      foreach (ProxyComponent component in (List<ProxyComponent>) this.mobjProxyTabControl.Components)
        objectList.Add((object) component);
      objectList.ToArray().CopyTo(objDestArray, index);
    }

    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
    /// </summary>
    /// <returns>An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.</returns>
    public object SyncRoot => ((ICollection) this.mobjProxyTabControl.Components).SyncRoot;

    /// <summary>
    /// Adds a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to the collection.
    /// </summary>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to add.</param>
    /// <returns></returns>
    /// <exception cref="T:System.ArgumentNullException">The specified value is null.</exception>
    public virtual int Add(object objTabPage)
    {
      ProxyComponent objTabPage1 = objTabPage as ProxyComponent;
      this.Insert(this.Count, (object) objTabPage1);
      return this.mobjProxyTabControl.Components.IndexOf(objTabPage1);
    }

    /// <summary>
    /// Removes a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> from the collection.
    /// </summary>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
    /// <exception cref="T:System.ArgumentNullException">The value parameter is null.</exception>
    public virtual void Remove(object objTabPage)
    {
      ProxyTabPage proxyTabPage = objTabPage as ProxyTabPage;
      this.mobjProxyTabControl.Components.Remove((ProxyComponent) proxyTabPage);
      this.mobjTabControl.Controls.Remove(proxyTabPage.SourceComponent as Control);
    }

    /// <summary>
    /// Returns an enumeration of all the tab pages in the collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.mobjProxyTabControl.Components.GetEnumerator();

    /// <summary>
    /// Returns the index of the specified tab page in the collection.
    /// </summary>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to locate in the collection.</param>
    /// <returns>
    /// The zero-based index of the tab page; -1 if it cannot be found.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">The value of page is null.</exception>
    public int IndexOf(object objTabPage) => this.mobjProxyTabControl.Components.IndexOf((ProxyComponent) (objTabPage as ProxyTabPage));

    /// <summary>
    /// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection.
    /// </summary>
    /// <param name="index">The zero-based index of the tab page to get or set.</param>
    /// <returns>
    /// The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> at the specified index.
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the highest available index.</exception>
    public ProxyTabPage this[int index] => (ProxyTabPage) this.mobjProxyTabControl.Components[index];

    /// <summary>
    /// Gets a value indicating whether the collection is read-only.
    /// </summary>
    /// <returns>This property always returns false.</returns>
    public bool IsReadOnly => false;

    /// <summary>
    /// Removes the tab page at the specified index from the collection.
    /// </summary>
    /// <param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
    public void RemoveAt(int index)
    {
      this.mobjProxyTabControl.Components.RemoveAt(index);
      this.mobjTabControl.Controls.RemoveAt(index);
    }

    /// <summary>
    /// Inserts an existing tab page into the collection at the specified index.
    /// </summary>
    /// <param name="index">The location where the tab page is inserted.</param>
    /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to insert in the collection.</param>
    public void Insert(int index, object objTabPage)
    {
      if (!(objTabPage is ProxyTabPage proxyTabPage))
        throw new ArgumentException(string.Format("Cannot add component of type '{0}' to container of type 'ProxyTabControl'", (object) objTabPage.GetType().Name));
      if (proxyTabPage.SourceComponent == null && string.IsNullOrEmpty(proxyTabPage.UniqueID))
      {
        proxyTabPage.NonStateComponentType = typeof (TabPage).FullName;
        proxyTabPage.Parent = (ProxyComponent) this.Owner;
      }
      this.mobjTabControl.TabPages.Insert(index, (object) (proxyTabPage.SourceComponent as TabPage));
      Hashtable hashtable = new Hashtable();
      if (proxyTabPage == null)
        return;
      if (this.Count == 0)
      {
        this.mobjProxyTabControl.Components.Add((ProxyComponent) proxyTabPage);
      }
      else
      {
        foreach (ProxyTabPage objTabPage1 in (IEnumerable) this)
        {
          TabPage sourceComponent = objTabPage1.SourceComponent as TabPage;
          hashtable.Add((object) sourceComponent.GetHashCode(), (object) sourceComponent.TabIndex);
          sourceComponent.TabIndex = this.IndexOf((object) objTabPage1);
        }
        if (index > this.Count || index < 0)
          index = this.Count;
        this.AdvanceTabIndexFromIndex((ushort) index, (ushort) 1);
        this.mobjProxyTabControl.Components.Add((ProxyComponent) proxyTabPage);
        (proxyTabPage.SourceComponent as TabPage).TabIndex = index;
        this.mobjProxyTabControl.Components.Sort((Comparison<ProxyComponent>) ((objX, objY) =>
        {
          TabPage sourceComponent1 = objX.SourceComponent as TabPage;
          TabPage sourceComponent2 = objY.SourceComponent as TabPage;
          return sourceComponent1 != null && sourceComponent2 != null ? sourceComponent1.TabIndex.CompareTo(sourceComponent2.TabIndex) : 0;
        }));
      }
    }

    /// <summary>
    /// Returns a sorted TabPage list from current unsorted TabPageCollection.
    /// </summary>
    /// <param name="blnSortByIndex">if set to <c>true</c> [BLN sort by index].</param>
    /// <returns></returns>
    protected ArrayList GetSortedTabPageListFromCurrent(bool blnSortByIndex)
    {
      ArrayList pageListFromCurrent = new ArrayList();
      foreach (ProxyTabPage proxyTabPage in (IEnumerable) this)
        pageListFromCurrent.Add((object) proxyTabPage);
      if (blnSortByIndex)
        pageListFromCurrent.Sort((IComparer) this);
      else
        pageListFromCurrent.Sort((IComparer) new ProxyTabPageCollection.ProxyTabIndexComparer());
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
        if ((objTabPageList[(int) index] as ProxyTabPage).SourceComponent is TabPage sourceComponent)
          sourceComponent.TabIndex += (int) usrAdvanceBy;
      }
    }

    /// <summary>
    /// Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control is in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
    /// </summary>
    /// <param name="objValue">The object to locate in the collection.</param>
    /// <returns>
    /// true if the specified object is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection; otherwise, false.
    /// </returns>
    public bool Contains(object objValue) => this.mobjProxyTabControl.Components.Contains((ProxyComponent) (objValue as ProxyTabPage));

    /// <summary>Removes all the tab pages from the collection.</summary>
    public void Clear()
    {
      this.mobjProxyTabControl.Components.Clear();
      this.mobjTabControl.Controls.Clear();
    }

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
      TabPage sourceComponent1 = (objArgFirstTP as ProxyTabPage).SourceComponent as TabPage;
      TabPage sourceComponent2 = (objArgFirstTP as ProxyTabPage).SourceComponent as TabPage;
      return sourceComponent1 == null || sourceComponent2 == null ? 0 : this.IndexOf(objArgFirstTP).CompareTo(this.IndexOf(objArgSecondTP));
    }

    /// <summary>Gets or sets the element at the specified index.</summary>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    object IList.this[int index]
    {
      get => (object) this.Owner.Components[index];
      set
      {
      }
    }

    /// <summary>Implements IComparer for TabPages sorting by TabIndex</summary>
    /// <returns></returns>
    [Serializable]
    private class ProxyTabIndexComparer : IComparer
    {
      int IComparer.Compare(object objX, object objY)
      {
        TabPage sourceComponent1 = (objX as ProxyTabPage).SourceComponent as TabPage;
        TabPage sourceComponent2 = (objY as ProxyTabPage).SourceComponent as TabPage;
        return sourceComponent1 != null && sourceComponent2 != null ? sourceComponent1.TabIndex.CompareTo(sourceComponent2.TabIndex) : 0;
      }
    }
  }
}

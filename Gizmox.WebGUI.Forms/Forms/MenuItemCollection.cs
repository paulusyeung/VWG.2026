// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MenuItemCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class MenuItemCollection : ICollection, IEnumerable, IList, INotifyCollectionChanged
  {
    private ArrayList mobjMenus;
    private Component mobjParent;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItemCollection" /> class.
    /// </summary>
    /// <param name="objParent">The obj parent.</param>
    public MenuItemCollection(Component objParent)
    {
      this.mobjMenus = new ArrayList();
      this.mobjParent = objParent;
    }

    /// <summary>
    /// <para>Removes a <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> from the menu
    /// item collection at a specified index.</para>
    /// </summary>
    /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> to remove.</param>
    public virtual void RemoveAt(int index)
    {
      if (this.mobjMenus == null)
        return;
      this.Remove(this.mobjMenus[index] as MenuItem);
    }

    /// <summary>
    /// <para>Adds a previously created <see cref="T:Gizmox.WebGUI.Forms.MenuItem" />
    /// at the
    /// specified index within the menu item collection.</para>
    /// </summary>
    /// <param name="index">The position to add the new item.</param>
    /// <param name="objItem">The <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> to add.</param>
    /// <returns>
    /// <para>The zero-based index where the item is stored in the collection.</para>
    /// </returns>
    /// <exception cref="T:System.Exception">The <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> being added is already in use.</exception>
    /// <exception cref="T:System.ArgumentException">The index supplied in the <paramref name="index" /> parameter is larger than the size of the collection.</exception>
    public virtual int Add(int index, MenuItem objItem)
    {
      if (this.mobjMenus == null)
        return -1;
      this.mobjMenus.Insert(index, (object) objItem);
      return index;
    }

    /// <summary>
    /// Adds a previously created MenuItem to the end of the current menu.
    /// </summary>
    /// <param name="objMenuItem">The MenuItem to add.</param>
    /// <returns>The zero-based index where the item is stored in the collection.</returns>
    public int Add(MenuItem objMenuItem)
    {
      objMenuItem.InternalParent = this.mobjParent;
      this.mobjParent.Update();
      int num = this.mobjMenus.Add((object) objMenuItem);
      if (this.CollectionChanged == null)
        return num;
      this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (object) objMenuItem));
      return num;
    }

    /// <summary>
    /// Adds a new MenuItem to the end of the current menu with a specified caption and a specified event handler for the Click event.
    /// </summary>
    /// <param name="strCaption">The caption of the menu item.</param>
    /// <param name="objOnClick">An EventHandler that represents the event handler that is called when the item is clicked by the user, or when a user presses an accelerator or shortcut key for the menu item.</param>
    /// <returns>A MenuItem that represents the menu item being added to the collection.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public MenuItem Add(string strCaption, EventHandler objOnClick)
    {
      MenuItem objMenuItem = new MenuItem(strCaption, objOnClick);
      this.Add(objMenuItem);
      return objMenuItem;
    }

    /// <summary>Adds the range.</summary>
    /// <param name="arrMenuItems">The obj menu items.</param>
    public void AddRange(MenuItem[] arrMenuItems)
    {
      MenuItem[] menuItemArray = new MenuItem[arrMenuItems.Length];
      bool flag = true;
      foreach (MenuItem arrMenuItem in arrMenuItems)
      {
        if (flag && arrMenuItem.Index >= 0 && arrMenuItem.Index < menuItemArray.Length)
        {
          menuItemArray[arrMenuItem.Index] = arrMenuItem;
        }
        else
        {
          flag = false;
          this.Add(arrMenuItem);
        }
      }
      if (!flag)
        return;
      for (int index = 0; index < menuItemArray.Length; ++index)
        this.Add(menuItemArray[index]);
    }

    /// <summary>
    /// Determines whether [contains] [the specified obj menu item].
    /// </summary>
    /// <param name="objMenuItem">The obj menu item.</param>
    /// <returns>
    /// 	<c>true</c> if [contains] [the specified obj menu item]; otherwise, <c>false</c>.
    /// </returns>
    public bool Contains(MenuItem objMenuItem) => this.mobjMenus.Contains((object) objMenuItem);

    internal void AttachedToDOM()
    {
      foreach (MenuItem mobjMenu in this.mobjMenus)
        mobjMenu.AttachedToDOM();
    }

    internal void RemovingFromDOM()
    {
      foreach (MenuItem mobjMenu in this.mobjMenus)
        mobjMenu.RemovingFromDOM();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objMenuItem"></param>
    public void Remove(MenuItem objMenuItem)
    {
      if (objMenuItem.InternalParent == this.mobjParent && this.mobjParent != null)
      {
        ((IRegisteredComponent) this.mobjParent).UnregisterContextMenu();
        objMenuItem.InternalParent = (Component) null;
      }
      this.mobjMenus.Remove((object) objMenuItem);
      this.mobjParent.Update();
      if (this.CollectionChanged == null)
        return;
      this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, (object) objMenuItem));
    }

    /// <summary>
    /// Removes all items from the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.IList" /> is read-only.
    /// </exception>
    public void Clear()
    {
      this.mobjMenus.Clear();
      this.mobjParent.Update();
      if (this.CollectionChanged == null)
        return;
      this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    /// <summary>Gets the menu item count.</summary>
    /// <value></value>
    public int Count => this.mobjMenus.Count;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator GetEnumerator() => this.mobjMenus.GetEnumerator();

    bool IList.IsReadOnly => this.mobjMenus.IsReadOnly;

    /// <summary>
    /// Gets the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> at the specified index.
    /// </summary>
    /// <value></value>
    public MenuItem this[int index] => (MenuItem) this.mobjMenus[index];

    object IList.this[int index]
    {
      get => this.mobjMenus[index];
      set => throw new NotSupportedException();
    }

    void IList.RemoveAt(int index) => this.mobjMenus.RemoveAt(index);

    void IList.Insert(int index, object objValue) => throw new NotSupportedException();

    void IList.Remove(object objValue) => this.Remove((MenuItem) objValue);

    bool IList.Contains(object objValue) => this.Contains((MenuItem) objValue);

    void IList.Clear() => this.mobjMenus.Clear();

    int IList.IndexOf(object objValue) => this.mobjMenus.IndexOf(objValue);

    int IList.Add(object objValue)
    {
      if (!(objValue is MenuItem))
        throw new ArgumentException("value");
      this.Add((MenuItem) objValue);
      return this.mobjMenus.IndexOf((object) (MenuItem) objValue);
    }

    bool IList.IsFixedSize => this.mobjMenus.IsFixedSize;

    /// <summary>
    /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
    /// </summary>
    /// <value></value>
    /// <returns>true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.
    /// </returns>
    public bool IsSynchronized => this.mobjMenus.IsSynchronized;

    /// <summary>
    /// Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
    /// </summary>
    /// <param name="objArray">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="array" /> is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// 	<paramref name="index" /> is less than zero.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// 	<paramref name="objArray" /> is multidimensional.
    /// -or-
    /// <paramref name="index" /> is equal to or greater than the length of <paramref name="array" />.
    /// -or-
    /// The number of elements in the source <see cref="T:System.Collections.ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// The type of the source <see cref="T:System.Collections.ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.
    /// </exception>
    public void CopyTo(Array objArray, int index) => this.mobjMenus.CopyTo(objArray, index);

    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
    /// </returns>
    public object SyncRoot => this.mobjMenus.SyncRoot;

    public event NotifyCollectionChangedEventHandler CollectionChanged;
  }
}

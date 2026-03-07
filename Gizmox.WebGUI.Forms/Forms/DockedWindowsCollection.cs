// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedWindowsCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class DockedWindowsCollection : 
    ICollection<DockingWindow>,
    IEnumerable<DockingWindow>,
    IEnumerable
  {
    /// <summary>
    /// 
    /// </summary>
    private DockingManager mobjManager;
    private Dictionary<DockingWindowName, DockingWindow> mobjWindowsIndexByWindowName;
    private Dictionary<DockingWindowName, DockingWindow> mobjHiddenWindowsIndexByWindowName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedWindowsCollection" /> class.
    /// </summary>
    public DockedWindowsCollection()
    {
      this.mobjWindowsIndexByWindowName = new Dictionary<DockingWindowName, DockingWindow>(DockingWindowName.DockedWindowNameEqulityComparer);
      this.mobjHiddenWindowsIndexByWindowName = new Dictionary<DockingWindowName, DockingWindow>(DockingWindowName.DockedWindowNameEqulityComparer);
    }

    /// <summary>Gets the manager.</summary>
    public DockingManager Manager
    {
      get => this.mobjManager;
      internal set => this.mobjManager = value;
    }

    /// <summary>Adds the window.</summary>
    /// <param name="objWindow">The obj window.</param>
    internal void AddWindowIfDoesntExist(DockingWindow objWindow)
    {
      objWindow.Manager = this.mobjManager;
      if (!this.mobjWindowsIndexByWindowName.ContainsKey(objWindow.WindowName))
      {
        this.mobjWindowsIndexByWindowName.Add(objWindow.WindowName, objWindow);
      }
      else
      {
        if (this.mobjWindowsIndexByWindowName[objWindow.WindowName] == objWindow)
          throw new Exception("The given window already exists in the manager. In order to add a window of the same type, create a new instance of the window and give it a unique name");
        throw new Exception("A window with the same name ('" + objWindow.WindowName.WindowName + "') already exists in the manager. In order to add a window, create a new instance of the window and give it a unique name");
      }
    }

    /// <summary>Removes the window.</summary>
    /// <param name="objWindow">The obj window.</param>
    /// <returns></returns>
    internal bool RemoveWindow(DockingWindow objWindow) => this.mobjWindowsIndexByWindowName.Remove(objWindow.WindowName);

    /// <summary>Adds the hidden window.</summary>
    /// <param name="objWindow">The obj window.</param>
    internal void AddHiddenWindow(DockingWindow objWindow)
    {
      objWindow.Manager = this.mobjManager;
      if (this.mobjHiddenWindowsIndexByWindowName.ContainsKey(objWindow.WindowName))
        return;
      DockState dockState;
      switch (objWindow.CurrentDockState)
      {
        case DockState.Float:
          dockState = DockState.Float;
          break;
        case DockState.Dock:
        case DockState.AutoHide:
          dockState = DockState.Dock;
          break;
        case DockState.Tabbed:
          dockState = DockState.Tabbed;
          break;
        case DockState.Hidden:
        case DockState.Close:
          dockState = objWindow.LastDockState;
          break;
        default:
          throw new Exception();
      }
      objWindow.LastDockState = dockState;
      this.mobjHiddenWindowsIndexByWindowName.Add(objWindow.WindowName, objWindow);
    }

    /// <summary>Removes the hidden window.</summary>
    /// <param name="objWindow">The obj window.</param>
    /// <returns></returns>
    internal bool RemoveHiddenWindow(DockingWindow objWindow) => this.mobjHiddenWindowsIndexByWindowName.Remove(objWindow.WindowName);

    /// <summary>Gets the name of the windows index by window.</summary>
    /// <value>The name of the windows index by window.</value>
    internal Dictionary<DockingWindowName, DockingWindow> WindowsIndexByWindowName => this.mobjWindowsIndexByWindowName;

    /// <summary>Gets the name of the hidden windows index by window.</summary>
    /// <value>The name of the hidden windows index by window.</value>
    internal Dictionary<DockingWindowName, DockingWindow> HiddenWindowsIndexByWindowName => this.mobjHiddenWindowsIndexByWindowName;

    /// <summary>
    /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
    /// </summary>
    /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
    public void Add(DockingWindow item) => this.mobjManager.AddTabbedWindows(item);

    /// <summary>
    /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
    /// </summary>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
    public void Clear()
    {
      foreach (DockingWindow dockingWindow in this.mobjWindowsIndexByWindowName.Values)
        dockingWindow.Close();
      this.mobjWindowsIndexByWindowName.Clear();
    }

    /// <summary>
    /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
    /// </summary>
    /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
    /// <returns>
    /// true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
    /// </returns>
    public bool Contains(DockingWindow item) => this.mobjWindowsIndexByWindowName.ContainsKey(item.WindowName);

    /// <summary>Copies to.</summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">Index of the array.</param>
    public void CopyTo(DockingWindow[] array, int arrayIndex) => throw new NotImplementedException();

    /// <summary>
    /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
    /// </summary>
    /// <returns>The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</returns>
    public int Count => this.mobjWindowsIndexByWindowName.Count;

    /// <summary>
    /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
    /// </summary>
    /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.</returns>
    public bool IsReadOnly => false;

    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
    /// </summary>
    /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
    /// <returns>
    /// true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if item is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
    public bool Remove(DockingWindow item)
    {
      if (item.Closed)
        return false;
      item.Close();
      return true;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<DockingWindow> GetEnumerator() => (IEnumerator<DockingWindow>) this.mobjWindowsIndexByWindowName.Values.GetEnumerator();

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.mobjWindowsIndexByWindowName.Values.GetEnumerator();
  }
}

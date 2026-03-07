// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripItemCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a collection of <see cref="T:System.Windows.Forms.ToolStripItem"></see> objects.</summary>
  /// <filterpriority>2</filterpriority>
  [ListBindable(false)]
  [Serializable]
  public class ToolStripItemCollection : ArrangedElementCollection, IList, ICollection, IEnumerable
  {
    private bool mblnIsReadOnly;
    private bool mblnItemsCollection;
    private int mintLastAccessedIndex;
    private ToolStrip mobjOwnerToolStrip;

    internal ToolStripItemCollection(ToolStrip owner, bool itemsCollection, bool isReadOnly)
    {
      this.mintLastAccessedIndex = -1;
      this.mobjOwnerToolStrip = owner;
      this.mblnItemsCollection = itemsCollection;
      this.mblnIsReadOnly = isReadOnly;
    }

    internal ToolStripItemCollection(ToolStrip owner, bool itemsCollection)
      : this(owner, itemsCollection, false)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> class with the specified container <see cref="T:System.Windows.Forms.ToolStrip"></see> and the specified array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls.</summary>
    /// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStrip"></see> to which this <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> belongs. </param>
    /// <param name="value">An array of type <see cref="T:System.Windows.Forms.ToolStripItem"></see> containing the initial controls for this <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
    /// <exception cref="T:System.ArgumentNullException">The owner parameter is null.</exception>
    public ToolStripItemCollection(ToolStrip owner, ToolStripItem[] value)
    {
      this.mintLastAccessedIndex = -1;
      this.mobjOwnerToolStrip = owner != null ? owner : throw new ArgumentNullException(nameof (owner));
      this.AddRange(value);
    }

    bool IList.IsFixedSize => this.InnerList.IsFixedSize;

    object IList.this[int index]
    {
      get => this.InnerList[index];
      set => throw new NotSupportedException(SR.GetString("ToolStripCollectionMustInsertAndRemove"));
    }

    /// <summary>Gets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only; otherwise, false.</returns>
    public override bool IsReadOnly => this.mblnIsReadOnly;

    /// <summary>Gets the item at the specified index.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ToolStripItem"></see> located at the specified position in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>.</returns>
    /// <param name="index">The zero-based index of the item to get.</param>
    /// <filterpriority>1</filterpriority>
    public virtual ToolStripItem this[int index] => (ToolStripItem) this.InnerList[index];

    /// <summary>Gets the item with the specified name.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified name.</returns>
    /// <param name="key">The name of the item to get.</param>
    /// <filterpriority>1</filterpriority>
    public virtual ToolStripItem this[string key]
    {
      get
      {
        if (key != null && key.Length != 0)
        {
          int num = this.IndexOfKey(key);
          if (this.IsValidIndex(num))
            return (ToolStripItem) this.InnerList[num];
        }
        return (ToolStripItem) null;
      }
    }

    /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image to the collection.</summary>
    /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
    public ToolStripItem Add(ResourceHandle image) => this.Add((string) null, image, (EventHandler) null);

    /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified text to the collection.</summary>
    /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
    /// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
    public ToolStripItem Add(string text) => this.Add(text, (ResourceHandle) null, (EventHandler) null);

    /// <summary>Adds the specified item to the end of the collection.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the zero-based index of the new item in the collection.</returns>
    /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to add to the end of the collection. </param>
    /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public int Add(ToolStripItem value)
    {
      this.CheckCanAddOrInsertItem(value);
      this.SetOwner(value);
      value.InternalParent = (Component) this.mobjOwnerToolStrip;
      int num = this.InnerList.Add((object) value);
      if (!this.mblnItemsCollection || this.mobjOwnerToolStrip == null)
        return num;
      this.mobjOwnerToolStrip.OnItemAdded(new ToolStripItemEventArgs(value));
      return num;
    }

    /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image and text to the collection.</summary>
    /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
    public ToolStripItem Add(string text, ResourceHandle image) => this.Add(text, image, (EventHandler) null);

    /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItem"></see> that displays the specified image and text to the collection and that raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click"></see> event.</summary>
    /// <returns>The new <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
    /// <param name="onClick">Raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click"></see> event.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
    public ToolStripItem Add(string text, ResourceHandle image, EventHandler onClick)
    {
      ToolStripItem defaultItem = this.mobjOwnerToolStrip.CreateDefaultItem(text, image, onClick);
      this.Add(defaultItem);
      return defaultItem;
    }

    /// <summary>Adds an array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls to the collection.</summary>
    /// <param name="toolStripItems">An array of <see cref="T:System.Windows.Forms.ToolStripItem"></see> controls. </param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
    /// <exception cref="T:System.ArgumentNullException">The toolStripItems parameter is null. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void AddRange(ToolStripItem[] toolStripItems)
    {
      if (toolStripItems == null)
        throw new ArgumentNullException(nameof (toolStripItems));
      if (this.IsReadOnly)
        throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
      for (int index = 0; index < toolStripItems.Length; ++index)
        this.Add(toolStripItems[index]);
    }

    /// <summary>Adds a <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> to the current collection.</summary>
    /// <param name="toolStripItems">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> to be added to the current collection. </param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
    /// <exception cref="T:System.ArgumentNullException">The toolStripItems parameter is null. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void AddRange(ToolStripItemCollection toolStripItems)
    {
      if (toolStripItems == null)
        throw new ArgumentNullException(nameof (toolStripItems));
      if (this.IsReadOnly)
        throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
      int count = toolStripItems.Count;
      for (int index = 0; index < count; ++index)
        this.Add(toolStripItems[index]);
    }

    /// <summary>Removes all items from the collection.</summary>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual void Clear()
    {
      if (this.IsReadOnly)
        throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
      if (this.Count == 0)
        return;
      while (this.Count != 0)
        this.RemoveAt(this.Count - 1);
    }

    /// <summary>Determines whether the specified item is a member of the collection.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is a member of the current <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>; otherwise, false.</returns>
    /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to search for in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
    /// <filterpriority>1</filterpriority>
    public bool Contains(ToolStripItem value) => this.InnerList.Contains((object) value);

    /// <summary>Determines whether the collection contains an item with the specified key.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> contains a <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified key; otherwise, false.</returns>
    /// <param name="key">The key to locate in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
    /// <filterpriority>1</filterpriority>
    public virtual bool ContainsKey(string key) => this.IsValidIndex(this.IndexOfKey(key));

    /// <summary>Copies the collection into the specified position of the specified <see cref="T:System.Windows.Forms.ToolStripItem"></see> array.</summary>
    /// <param name="array">The array of type <see cref="T:System.Windows.Forms.ToolStripItem"></see> to which to copy the collection. </param>
    /// <param name="index">The position in the <see cref="T:System.Windows.Forms.ToolStripItem"></see> array at which to paste the collection. </param>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(ToolStripItem[] array, int index) => this.InnerList.CopyTo((Array) array, index);

    /// <summary>Searches for items by their name and returns an array of all matching controls.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ToolStripItem"></see> array of the search results.</returns>
    /// <param name="searchAllChildren">true to search child items of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> specified by the key parameter; otherwise, false. </param>
    /// <param name="key">The item name to search the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> for.</param>
    /// <exception cref="T:System.ArgumentNullException">The key parameter is null or empty.</exception>
    public ToolStripItem[] Find(string key, bool searchAllChildren)
    {
      ArrayList arrayList = key != null && key.Length != 0 ? this.FindInternal(key, searchAllChildren, this, new ArrayList()) : throw new ArgumentNullException(nameof (key), SR.GetString("FindKeyMayNotBeEmptyOrNull"));
      ToolStripItem[] toolStripItemArray = new ToolStripItem[arrayList.Count];
      arrayList.CopyTo((Array) toolStripItemArray, 0);
      return toolStripItemArray;
    }

    /// <summary>Retrieves the index of the specified item in the collection.</summary>
    /// <returns>A zero-based index value that represents the position of the specified <see cref="T:System.Windows.Forms.ToolStripItem"></see> in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>, if found; otherwise, -1.</returns>
    /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to locate in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
    /// <filterpriority>1</filterpriority>
    public int IndexOf(ToolStripItem value) => this.InnerList.IndexOf((object) value);

    /// <summary>Retrieves the index of the first occurrence of the specified item within the collection.</summary>
    /// <returns>A zero-based index value that represents the position of the first occurrence of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> specified by the key parameter, if found; otherwise, -1.</returns>
    /// <param name="key">The name of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to search for. </param>
    /// <filterpriority>1</filterpriority>
    public virtual int IndexOfKey(string key)
    {
      if (key != null && key.Length != 0)
      {
        if (this.IsValidIndex(this.mintLastAccessedIndex) && ClientUtils.SafeCompareStrings(this[this.mintLastAccessedIndex].Name, key, true))
          return this.mintLastAccessedIndex;
        for (int index = 0; index < this.Count; ++index)
        {
          if (ClientUtils.SafeCompareStrings(this[index].Name, key, true))
          {
            this.mintLastAccessedIndex = index;
            return index;
          }
        }
        this.mintLastAccessedIndex = -1;
      }
      return -1;
    }

    /// <summary>Inserts the specified item into the collection at the specified index.</summary>
    /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to insert. </param>
    /// <param name="index">The location in the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> at which to insert the <see cref="T:System.Windows.Forms.ToolStripItem"></see>. </param>
    /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Insert(int index, ToolStripItem value)
    {
      this.CheckCanAddOrInsertItem(value);
      this.SetOwner(value);
      this.InnerList.Insert(index, (object) value);
      if (!this.mblnItemsCollection || this.mobjOwnerToolStrip == null)
        return;
      this.mobjOwnerToolStrip.OnItemAdded(new ToolStripItemEventArgs(value));
    }

    /// <summary>Removes the specified item from the collection.</summary>
    /// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove from the <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see>. </param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Remove(ToolStripItem value)
    {
      if (this.IsReadOnly)
        throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
      this.InnerList.Remove((object) value);
      this.OnAfterRemove(value);
      value.InternalParent = (Component) null;
    }

    /// <summary>Removes an item from the specified index in the collection.</summary>
    /// <param name="index">The index value of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove. </param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void RemoveAt(int index)
    {
      if (this.IsReadOnly)
        throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
      ToolStripItem objToolStripItem = (ToolStripItem) null;
      if (index < this.Count && index >= 0)
        objToolStripItem = (ToolStripItem) this.InnerList[index];
      this.InnerList.RemoveAt(index);
      this.OnAfterRemove(objToolStripItem);
      if (objToolStripItem == null)
        return;
      objToolStripItem.InternalParent = (Component) null;
    }

    /// <summary>Removes the item that has the specified key.</summary>
    /// <param name="key">The key of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to remove. </param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Windows.Forms.ToolStripItemCollection"></see> is read-only.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual void RemoveByKey(string key)
    {
      if (this.IsReadOnly)
        throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
      int num = this.IndexOfKey(key);
      if (!this.IsValidIndex(num))
        return;
      this.RemoveAt(num);
    }

    private void CheckCanAddOrInsertItem(ToolStripItem value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if (this.IsReadOnly)
        throw new NotSupportedException(SR.GetString("ToolStripItemCollectionIsReadOnly"));
      if (this.mobjOwnerToolStrip is ToolStripDropDown mobjOwnerToolStrip && mobjOwnerToolStrip.OwnerItem == value)
        throw new NotSupportedException(SR.GetString("ToolStripItemCircularReference"));
    }

    private ArrayList FindInternal(
      string key,
      bool searchAllChildren,
      ToolStripItemCollection itemsToLookIn,
      ArrayList foundItems)
    {
      if (itemsToLookIn != null)
      {
        if (foundItems != null)
        {
          try
          {
            for (int index = 0; index < itemsToLookIn.Count; ++index)
            {
              if (itemsToLookIn[index] != null)
                foundItems.Add((object) itemsToLookIn[index]);
            }
            if (!searchAllChildren)
              return foundItems;
            for (int index = 0; index < itemsToLookIn.Count; ++index)
            {
              if (itemsToLookIn[index] is ToolStripDropDownItem stripDropDownItem && stripDropDownItem.HasDropDownItems)
                foundItems = this.FindInternal(key, searchAllChildren, stripDropDownItem.DropDownItems, foundItems);
            }
          }
          catch (Exception ex)
          {
            if (ClientUtils.IsCriticalException(ex))
              throw;
          }
          return foundItems;
        }
      }
      return (ArrayList) null;
    }

    int IList.Add(object objValue) => this.Add(objValue as ToolStripItem);

    void IList.Clear() => this.Clear();

    bool IList.Contains(object objValue) => this.InnerList.Contains(objValue);

    int IList.IndexOf(object objValue) => this.IndexOf(objValue as ToolStripItem);

    void IList.Insert(int index, object objValue) => this.Insert(index, objValue as ToolStripItem);

    void IList.Remove(object objValue) => this.Remove(objValue as ToolStripItem);

    void IList.RemoveAt(int intIndex) => this.RemoveAt(intIndex);

    private bool IsValidIndex(int intIndex) => intIndex >= 0 && intIndex < this.Count;

    private void OnAfterRemove(ToolStripItem objToolStripItem)
    {
      if (!this.mblnItemsCollection)
        return;
      objToolStripItem?.SetOwner((ToolStrip) null);
      if (this.mobjOwnerToolStrip == null)
        return;
      this.mobjOwnerToolStrip.OnItemRemoved(new ToolStripItemEventArgs(objToolStripItem));
    }

    private void SetOwner(ToolStripItem objToolStripItem)
    {
      if (!this.mblnItemsCollection || objToolStripItem == null)
        return;
      if (objToolStripItem.Owner != null)
        objToolStripItem.Owner.Items.Remove(objToolStripItem);
      objToolStripItem.SetOwner(this.mobjOwnerToolStrip);
    }

    internal void MoveItem(ToolStripItem objToolStripItem)
    {
      if (objToolStripItem.ParentInternal != null)
      {
        int index = objToolStripItem.ParentInternal.Items.IndexOf(objToolStripItem);
        if (index >= 0)
          objToolStripItem.ParentInternal.Items.RemoveAt(index);
      }
      this.Add(objToolStripItem);
    }

    internal void MoveItem(int index, ToolStripItem objToolStripItem)
    {
      if (index == this.Count)
      {
        this.MoveItem(objToolStripItem);
      }
      else
      {
        if (objToolStripItem.ParentInternal != null)
        {
          int index1 = objToolStripItem.ParentInternal.Items.IndexOf(objToolStripItem);
          if (index1 >= 0)
          {
            objToolStripItem.ParentInternal.Items.RemoveAt(index1);
            if (objToolStripItem.ParentInternal == this.mobjOwnerToolStrip && index > index1)
              --index;
          }
        }
        this.Insert(index, objToolStripItem);
      }
    }
  }
}

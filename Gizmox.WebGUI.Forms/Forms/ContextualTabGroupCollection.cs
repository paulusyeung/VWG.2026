// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextualTabGroupCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ContextualTabGroupCollection : IList, ICollection, IEnumerable
  {
    /// <summary>
    /// 
    /// </summary>
    private ArrayList mobjGroups;
    /// <summary>
    /// 
    /// </summary>
    private TabControl mobjOwner;

    /// <summary>Gets the list.</summary>
    /// <value>The list.</value>
    private ArrayList List
    {
      get
      {
        if (this.mobjGroups == null)
          this.mobjGroups = new ArrayList();
        return this.mobjGroups;
      }
    }

    /// <summary>Gets the number of groups in the collection.</summary>
    /// <returns>The number of groups in the collection.</returns>
    /// <filterpriority>1</filterpriority>
    public int Count => this.List.Count;

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> at the specified index within the collection.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> at the specified index within the collection.</returns>
    /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to get or set. </param>
    /// <filterpriority>1</filterpriority>
    public ContextualTabGroup this[int index]
    {
      get => (ContextualTabGroup) this.List[index];
      set
      {
        if (this.List.Contains((object) value))
          return;
        this.List[index] = (object) value;
      }
    }

    /// <summary>
    /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
    /// </summary>
    /// <value></value>
    /// <returns>true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.</returns>
    bool ICollection.IsSynchronized => true;

    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <value></value>
    /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</returns>
    object ICollection.SyncRoot => (object) this;

    /// <summary>
    /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
    /// </summary>
    /// <value></value>
    /// <returns>true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.</returns>
    bool IList.IsFixedSize => false;

    /// <summary>
    /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.
    /// </summary>
    /// <value></value>
    /// <returns>true if the <see cref="T:System.Collections.IList" /> is read-only; otherwise, false.</returns>
    bool IList.IsReadOnly => false;

    /// <summary>
    /// Gets or sets the <see cref="T:System.Object" /> at the specified index.
    /// </summary>
    /// <value></value>
    object IList.this[int index]
    {
      get => (object) this[index];
      set
      {
        if (!(value is ContextualTabGroup))
          return;
        this[index] = (ContextualTabGroup) value;
      }
    }

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to the collection.</summary>
    /// <returns>The index of the group within the collection, or -1 if the group is already present in the collection.</returns>
    /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to add to the collection. </param>
    public int Add(ContextualTabGroup objGroup)
    {
      if (this.Contains(objGroup))
        return -1;
      if (this.mobjOwner != null)
        this.mobjOwner.Update();
      objGroup.TabControlInternal = this.mobjOwner;
      return this.List.Add((object) objGroup);
    }

    /// <summary>Adds a new <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to the collection using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.key"></see> and <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.Text"></see> properties </summary>
    /// <returns>The new <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see>.</returns>
    /// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.Key"></see> property for the new group.</param>
    /// <param name="strText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ContextualTabGroup.Text"></see> property for the new group.</param>
    public ContextualTabGroup Add(string strText)
    {
      ContextualTabGroup objGroup = new ContextualTabGroup(strText);
      this.Add(objGroup);
      return objGroup;
    }

    /// <summary>Adds an array of groups to the collection.</summary>
    /// <param name="arrContextualTabGroups">An array of type <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> that specifies the groups to add to the collection.</param>
    public void AddRange(ContextualTabGroup[] arrContextualTabGroups)
    {
      for (int index = 0; index < arrContextualTabGroups.Length; ++index)
        this.Add(arrContextualTabGroups[index]);
    }

    /// <summary>
    /// Adds the groups in an existing <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroupCollection"></see> to the collection.
    /// </summary>
    /// <param name="objGroups">A <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroupCollection"></see> containing the groups to add to the collection.</param>
    public void AddRange(ContextualTabGroupCollection objGroups)
    {
      for (int index = 0; index < objGroups.Count; ++index)
        this.Add(objGroups[index]);
    }

    /// <summary>Removes all groups from the collection.</summary>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Clear()
    {
      for (int index = this.List.Count - 1; index >= 0; --index)
        this.Remove(this[index], true);
    }

    /// <summary>Internal clears.</summary>
    internal void ClearInternal()
    {
      for (int index = this.List.Count - 1; index >= 0; --index)
        this.Remove(this[index], false);
    }

    /// <summary>
    /// Determines whether the specified group is located in the collection.
    /// </summary>
    /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to locate in the collection.</param>
    /// <returns>
    /// true if the group is in the collection; otherwise, false.
    /// </returns>
    /// <filterpriority>1</filterpriority>
    public bool Contains(ContextualTabGroup value) => this.List.Contains((object) value);

    /// <summary>Copies the groups in the collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
    /// <param name="objArray">The <see cref="T:System.Array"></see> to which the groups are copied. </param>
    /// <param name="index">The first index within the array to which the groups are copied. </param>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(Array objArray, int index) => this.List.CopyTo(objArray, index);

    /// <summary>Returns an enumerator used to iterate through the collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the collection.</returns>
    /// <filterpriority>1</filterpriority>
    public IEnumerator GetEnumerator() => this.List.GetEnumerator();

    /// <summary>Returns the index of the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> within the collection.</summary>
    /// <returns>The zero-based index of the group within the collection, or -1 if the group is not in the collection.</returns>
    /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to locate in the collection. </param>
    /// <filterpriority>1</filterpriority>
    public int IndexOf(ContextualTabGroup value) => this.List.IndexOf((object) value);

    /// <summary>Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> into the collection at the specified index.</summary>
    /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to insert into the collection. </param>
    /// <param name="index">The index within the collection at which to insert the group. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Insert(int index, ContextualTabGroup objGroup)
    {
      if (this.Contains(objGroup))
        return;
      objGroup.TabControlInternal = this.mobjOwner;
      this.List.Insert(index, (object) objGroup);
    }

    /// <summary>Removes the specified <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> from the collection.</summary>
    /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to remove from the collection. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Remove(ContextualTabGroup objGroup) => this.Remove(objGroup, true);

    /// <summary>Removes the specified obj group.</summary>
    /// <param name="objGroup">The obj group.</param>
    /// <param name="blnClearContextualTabGroupReferences">if set to <c>true</c> [BLN clear contextual tab group references].</param>
    private void Remove(ContextualTabGroup objGroup, bool blnClearContextualTabGroupReferences)
    {
      if (blnClearContextualTabGroupReferences)
        this.ClearContextualTabGroupReferences(objGroup);
      objGroup.TabControlInternal = (TabControl) null;
      this.List.Remove((object) objGroup);
    }

    /// <summary>Removes the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> at the specified index within the collection.</summary>
    /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup"></see> to remove. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void RemoveAt(int index) => this.Remove(this[index]);

    /// <summary>
    /// Adds an item to the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to add to the <see cref="T:System.Collections.IList" />.</param>
    /// <returns>The position into which the new element was inserted.</returns>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
    int IList.Add(object objValue) => objValue is ContextualTabGroup ? this.Add((ContextualTabGroup) objValue) : throw new ArgumentException(nameof (objValue));

    /// <summary>
    /// Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
    /// <returns>
    /// true if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, false.
    /// </returns>
    bool IList.Contains(object objValue) => objValue is ContextualTabGroup && this.Contains((ContextualTabGroup) objValue);

    /// <summary>
    /// Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
    /// <returns>
    /// The index of <paramref name="value" /> if found in the list; otherwise, -1.
    /// </returns>
    int IList.IndexOf(object objValue) => objValue is ContextualTabGroup ? this.IndexOf((ContextualTabGroup) objValue) : -1;

    /// <summary>
    /// Inserts an item to the <see cref="T:System.Collections.IList" /> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="value" /> should be inserted.</param>
    /// <param name="objValue">The <see cref="T:System.Object" /> to insert into the <see cref="T:System.Collections.IList" />.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
    /// <exception cref="T:System.NullReferenceException">
    /// <paramref name="value" /> is null reference in the <see cref="T:System.Collections.IList" />.</exception>
    void IList.Insert(int index, object objValue)
    {
      if (!(objValue is ContextualTabGroup objGroup))
        return;
      this.Insert(index, objGroup);
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to remove from the <see cref="T:System.Collections.IList" />.</param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
    void IList.Remove(object objValue)
    {
      if (!(objValue is ContextualTabGroup objGroup))
        return;
      this.Remove(objGroup);
    }

    /// <summary>Clears the contextual tab group references.</summary>
    /// <param name="objContextualTabGroup">The obj contextual tab group.</param>
    private void ClearContextualTabGroupReferences(ContextualTabGroup objContextualTabGroup)
    {
      if (this.mobjOwner == null)
        return;
      for (int index = 0; index < this.mobjOwner.TabPages.Count; ++index)
      {
        TabPage tabPage = this.mobjOwner.TabPages[index];
        if (tabPage.ContextualTabGroup == objContextualTabGroup)
          tabPage.ContextualTabGroup = (ContextualTabGroup) null;
      }
      this.mobjOwner.Update();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroupCollection" /> class.
    /// </summary>
    /// <param name="objOwner">The owner list view.</param>
    internal ContextualTabGroupCollection(TabControl objOwner) => this.mobjOwner = objOwner;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroupCollection" /> class.
    /// </summary>
    /// <param name="objOwner">The owner TabControl.</param>
    /// <param name="arrGroups">The arr groups.</param>
    internal ContextualTabGroupCollection(TabControl objOwner, object[] arrGroups)
    {
      this.mobjOwner = objOwner;
      this.mobjGroups = new ArrayList((ICollection) arrGroups);
    }
  }
}

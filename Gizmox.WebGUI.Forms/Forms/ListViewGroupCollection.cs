// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewGroupCollection
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
  /// <summary>Represents the collection of groups within a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
  [ListBindable(false)]
  [Serializable]
  public class ListViewGroupCollection : IList, ICollection, IEnumerable
  {
    /// <summary>
    /// 
    /// </summary>
    private ArrayList mobjGroups;
    /// <summary>
    /// 
    /// </summary>
    private object mobjOwner;

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

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</returns>
    /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to get or set. </param>
    /// <filterpriority>1</filterpriority>
    public ListViewGroup this[int index]
    {
      get => (ListViewGroup) this.List[index];
      set
      {
        if (this.List.Contains((object) value))
          return;
        this.List[index] = (object) value;
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> with the specified <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property value. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> with the specified name.</returns>
    /// <param name="strKey">The name of the group to get or set.</param>
    public ListViewGroup this[string strKey]
    {
      get
      {
        if (this.mobjGroups != null)
        {
          for (int index = 0; index < this.mobjGroups.Count; ++index)
          {
            if (string.Compare(strKey, this[index].Name, false, CultureInfo.CurrentCulture) == 0)
              return this[index];
          }
        }
        return (ListViewGroup) null;
      }
      set
      {
        int index1 = -1;
        if (this.mobjGroups == null)
          return;
        for (int index2 = 0; index2 < this.mobjGroups.Count; ++index2)
        {
          if (string.Compare(strKey, this[index2].Name, false, CultureInfo.CurrentCulture) == 0)
          {
            index1 = index2;
            break;
          }
        }
        if (index1 == -1)
          return;
        this.mobjGroups[index1] = (object) value;
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
        if (!(value is ListViewGroup))
          return;
        this[index] = (ListViewGroup) value;
      }
    }

    /// <summary>Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to the collection.</summary>
    /// <returns>The index of the group within the collection, or -1 if the group is already present in the collection.</returns>
    /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to add to the collection. </param>
    /// <exception cref="T:System.ArgumentException">group contains at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
    public int Add(ListViewGroup objGroup)
    {
      if (this.Contains(objGroup))
        return -1;
      objGroup.ListViewInternal = this.GetOwnerListView();
      return this.List.Add((object) objGroup);
    }

    /// <summary>Adds a new <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to the collection using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> and <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> properties </summary>
    /// <returns>The new <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see>.</returns>
    /// <param name="strHeaderText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property for the new group.</param>
    /// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property for the new group.</param>
    public ListViewGroup Add(string strKey, string strHeaderText)
    {
      ListViewGroup objGroup = new ListViewGroup(strKey, strHeaderText);
      this.Add(objGroup);
      return objGroup;
    }

    /// <summary>Adds an array of groups to the collection.</summary>
    /// <param name="arrGroups">An array of type <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> that specifies the groups to add to the collection. </param>
    /// <exception cref="T:System.ArgumentException">groups contains at least one group with at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
    public void AddRange(ListViewGroup[] arrGroups)
    {
      for (int index = 0; index < arrGroups.Length; ++index)
        this.Add(arrGroups[index]);
    }

    /// <summary>Adds the groups in an existing <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> to the collection.</summary>
    /// <param name="objGroups">A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> containing the groups to add to the collection. </param>
    /// <exception cref="T:System.ArgumentException">groups contains at least one group with at least one <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that belongs to a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control other than the one that owns this <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see>.</exception>
    public void AddRange(ListViewGroupCollection objGroups)
    {
      for (int index = 0; index < objGroups.Count; ++index)
        this.Add(objGroups[index]);
    }

    /// <summary>Removes all groups from the collection.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Clear()
    {
      for (int index = this.List.Count - 1; index >= 0; --index)
        this.Remove(this[index]);
    }

    /// <summary>Clears the internal.</summary>
    internal void ClearInternal()
    {
      for (int index = this.List.Count - 1; index >= 0; --index)
        this.List.Remove((object) this[index]);
    }

    /// <summary>Determines whether the specified group is located in the collection.</summary>
    /// <returns>true if the group is in the collection; otherwise, false.</returns>
    /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to locate in the collection. </param>
    /// <filterpriority>1</filterpriority>
    public bool Contains(ListViewGroup value) => this.List.Contains((object) value);

    /// <summary>Copies the groups in the collection to a compatible one-dimensional <see cref="T:System.Array"></see>, starting at the specified index of the target array.</summary>
    /// <param name="objArray">The <see cref="T:System.Array"></see> to which the groups are copied. </param>
    /// <param name="index">The first index within the array to which the groups are copied. </param>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(Array objArray, int index) => this.List.CopyTo(objArray, index);

    /// <summary>Returns an enumerator used to iterate through the collection.</summary>
    /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the collection.</returns>
    /// <filterpriority>1</filterpriority>
    public IEnumerator GetEnumerator() => this.List.GetEnumerator();

    /// <summary>Returns the index of the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> within the collection.</summary>
    /// <returns>The zero-based index of the group within the collection, or -1 if the group is not in the collection.</returns>
    /// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to locate in the collection. </param>
    /// <filterpriority>1</filterpriority>
    public int IndexOf(ListViewGroup value) => this.List.IndexOf((object) value);

    /// <summary>Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> into the collection at the specified index.</summary>
    /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to insert into the collection. </param>
    /// <param name="index">The index within the collection at which to insert the group. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Insert(int index, ListViewGroup objGroup)
    {
      if (this.Contains(objGroup))
        return;
      objGroup.ListViewInternal = this.GetOwnerListView();
      this.List.Insert(index, (object) objGroup);
    }

    /// <summary>Gets the owner list view.</summary>
    /// <returns></returns>
    private ListView GetOwnerListView()
    {
      if (this.mobjOwner is ListView mobjOwner1)
        return mobjOwner1;
      return this.mobjOwner is ListViewGroup mobjOwner2 ? mobjOwner2.ListView : (ListView) null;
    }

    /// <summary>Removes the specified <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> from the collection.</summary>
    /// <param name="objGroup">The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to remove from the collection. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Remove(ListViewGroup objGroup)
    {
      this.ClearGroup(objGroup);
      this.List.Remove((object) objGroup);
    }

    /// <summary>Removes the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> at the specified index within the collection.</summary>
    /// <param name="index">The index within the collection of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to remove. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void RemoveAt(int index) => this.Remove(this[index]);

    /// <summary>
    /// Adds an item to the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to add to the <see cref="T:System.Collections.IList" />.</param>
    /// <returns>The position into which the new element was inserted.</returns>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
    int IList.Add(object objValue) => objValue is ListViewGroup ? this.Add((ListViewGroup) objValue) : throw new ArgumentException("value");

    /// <summary>
    /// Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
    /// <returns>
    /// true if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, false.
    /// </returns>
    bool IList.Contains(object objValue) => objValue is ListViewGroup && this.Contains((ListViewGroup) objValue);

    /// <summary>
    /// Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
    /// <returns>
    /// The index of <paramref name="value" /> if found in the list; otherwise, -1.
    /// </returns>
    int IList.IndexOf(object objValue) => objValue is ListViewGroup ? this.IndexOf((ListViewGroup) objValue) : -1;

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
      if (!(objValue is ListViewGroup))
        return;
      this.Insert(index, (ListViewGroup) objValue);
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.
    /// </summary>
    /// <param name="objValue">The <see cref="T:System.Object" /> to remove from the <see cref="T:System.Collections.IList" />.</param>
    /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
    void IList.Remove(object objValue)
    {
      if (!(objValue is ListViewGroup))
        return;
      this.Remove((ListViewGroup) objValue);
    }

    /// <summary>Clears the group.</summary>
    /// <param name="objGroup">The group.</param>
    private void ClearGroup(ListViewGroup objGroup)
    {
      if (objGroup == null)
        return;
      if (objGroup.Groups.Count > 0)
        objGroup.Groups.Clear();
      if (objGroup.Items.Count > 0)
      {
        for (int intIndex = objGroup.Items.Count - 1; intIndex >= 0; --intIndex)
        {
          ListViewItem listViewItem = objGroup.Items[intIndex];
          if (listViewItem != null)
            listViewItem.Group = (ListViewGroup) null;
        }
        if (objGroup.ListViewInternal != null)
          objGroup.ListViewInternal.Update();
      }
      objGroup.ListViewInternal = (ListView) null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection" /> class.
    /// </summary>
    /// <param name="objOwner">The owner list view.</param>
    internal ListViewGroupCollection(ListView objOwner) => this.mobjOwner = (object) objOwner;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection" /> class.
    /// </summary>
    /// <param name="objOwner">The owner list view.</param>
    /// <param name="arrGroups">The arr groups.</param>
    internal ListViewGroupCollection(ListView objOwner, object[] arrGroups)
    {
      this.mobjOwner = (object) objOwner;
      this.mobjGroups = new ArrayList((ICollection) arrGroups);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection" /> class.
    /// </summary>
    /// <param name="objOwner">The owner list view group.</param>
    internal ListViewGroupCollection(ListViewGroup objOwner) => this.mobjOwner = (object) objOwner;
  }
}

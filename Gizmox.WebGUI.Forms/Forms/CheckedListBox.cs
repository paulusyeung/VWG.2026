// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CheckedListBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for CheckedListBox.</summary>
  [ToolboxItem(true)]
  [ToolboxItemCategory("Common Controls")]
  [ToolboxBitmap(typeof (CheckedListBox), "CheckedListBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckedListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.CheckedListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Gizmox.WebGUI.Forms.MetadataTag("CX")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (CheckedListBoxSkin))]
  [Serializable]
  public class CheckedListBox : ListBox
  {
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private ArrayList mobjCachedCheckedIndexes;
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private ArrayList mobjCachedCheckedObjects;
    /// <summary>The CheckOnClickProperty property registration.</summary>
    private static readonly SerializableProperty CheckOnClickProperty = SerializableProperty.Register(nameof (CheckOnClick), typeof (bool), typeof (CheckedListBox), new SerializablePropertyMetadata((object) false));
    /// <summary>The ItemCheck event registration.</summary>
    private static readonly SerializableEvent ItemCheckEvent = SerializableEvent.Register("ItemCheck", typeof (ItemCheckHandler), typeof (CheckedListBox));
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private CheckedListBox.CheckedIndexCollection mobjCheckedIndexCollection;
    /// <summary>
    /// 
    /// </summary>
    [NonSerialized]
    private CheckedListBox.CheckedItemCollection mobjCheckedItemCollection;

    /// <summary>Occurs when the checked state of an item changes.</summary>
    public event ItemCheckHandler ItemCheck
    {
      add => this.AddCriticalHandler(CheckedListBox.ItemCheckEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(CheckedListBox.ItemCheckEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client item check].</summary>
    [SRDescription("Occurs when control's item checked state changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientItemCheck
    {
      add => this.AddClientHandler("CheckedChange", value);
      remove => this.RemoveClientHandler("CheckedChange", value);
    }

    /// <summary>Gets the hanlder for the ItemCheck event.</summary>
    private ItemCheckHandler ItemCheckHandler => (ItemCheckHandler) this.GetHandler(CheckedListBox.ItemCheckEvent);

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox" /> instance.
    /// </summary>
    public CheckedListBox()
    {
      this.SelectionMode = SelectionMode.One;
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    /// <summary>Renders the item attributes.</summary>
    /// <param name="objWriter">Writer.</param>
    /// <param name="objItem">Item.</param>
    /// <param name="intIndex">Item index.</param>
    protected internal override void RenderItemAttributes(
      IResponseWriter objWriter,
      object objItem,
      int intIndex)
    {
      this.RenderItemAttributes(objWriter, objItem, intIndex, false, false);
    }

    /// <summary>
    /// </summary>
    /// <param name="objWriter"></param>
    /// <param name="objItem"></param>
    /// <param name="intIndex"></param>
    /// <param name="blnShouldRenderItemImage"></param>
    /// <param name="blnShouldRenderItemColor"></param>
    protected internal override void RenderItemAttributes(
      IResponseWriter objWriter,
      object objItem,
      int intIndex,
      bool blnShouldRenderItemImage,
      bool blnShouldRenderItemColor)
    {
      base.RenderItemAttributes(objWriter, objItem, intIndex, blnShouldRenderItemImage, blnShouldRenderItemColor);
      CheckState checkedState = this.Items.GetCheckedState(intIndex);
      if (checkedState == CheckState.Unchecked)
        return;
      objWriter.WriteAttributeString("C", Convert.ToInt32((object) checkedState).ToString());
    }

    /// <summary>Renders the controls attributes</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderCheckOnClick(objContext, objWriter, false);
    }

    /// <summary>Renders the check on click.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnUpdateParams">if set to <c>true</c> update params.</param>
    private void RenderCheckOnClick(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnUpdateParams)
    {
      if (this.CheckOnClick)
      {
        objWriter.WriteAttributeString("COC", "1");
      }
      else
      {
        if (!blnUpdateParams)
          return;
        objWriter.WriteAttributeString("COC", "0");
      }
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "CheckedChange")
        this.CheckIndexes(objEvent["Indexes"]);
      base.FireEvent(objEvent);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.ItemCheckHandler != null)
        criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("CheckedChange"))
        clientEventsData.Set("VC");
      return clientEventsData;
    }

    /// <summary>Checks the indexes.</summary>
    /// <param name="strIndexes">indexes.</param>
    private void CheckIndexes(string strIndexes)
    {
      bool flag1 = false;
      bool flag2 = false;
      List<string> stringList = new List<string>((IEnumerable<string>) strIndexes.Split(','));
      CheckedListBox.ObjectCollection items = this.Items;
      int count = items.Count;
      List<bool> boolList = new List<bool>(count);
      for (int intIndex = 0; intIndex < count; ++intIndex)
        boolList.Add(items.GetChecked(intIndex));
      for (int index = 0; index < count; ++index)
      {
        if (stringList.Contains(index.ToString()))
        {
          if (!boolList[index])
          {
            flag1 = true;
            ItemCheckEventArgs objItemCheckEventArgs = new ItemCheckEventArgs(index, CheckState.Checked, CheckState.Unchecked);
            this.OnItemCheck(objItemCheckEventArgs);
            if (objItemCheckEventArgs.NewValue == CheckState.Checked)
              this.Items.SetChecked(index, true);
            else
              flag2 = true;
          }
        }
        else if (boolList[index])
        {
          flag1 = true;
          ItemCheckEventArgs objItemCheckEventArgs = new ItemCheckEventArgs(index, CheckState.Unchecked, CheckState.Checked);
          this.OnItemCheck(objItemCheckEventArgs);
          if (objItemCheckEventArgs.NewValue == CheckState.Unchecked)
            this.Items.SetChecked(index, false);
          else
            flag2 = true;
        }
      }
      if (flag1)
        this.InvalidateCheckedItemsChache();
      if (!flag2)
        return;
      this.Update();
    }

    /// <summary>Raises the <see cref="E:System.Windows.Forms.CheckedListBox.ItemCheck"></see> event.</summary>
    /// <param name="objItemCheckEventArgs">An <see cref="T:System.Windows.Forms.ItemCheckEventArgs"></see> that contains the event data.</param>
    protected virtual void OnItemCheck(ItemCheckEventArgs objItemCheckEventArgs)
    {
      ItemCheckHandler itemCheckHandler = this.ItemCheckHandler;
      if (itemCheckHandler == null)
        return;
      itemCheckHandler((object) this, objItemCheckEventArgs);
    }

    /// <summary>Gets the item checked value.</summary>
    /// <param name="intIndex">Item index.</param>
    /// <returns></returns>
    public bool GetItemChecked(int intIndex) => intIndex >= 0 && intIndex < this.Items.Count && this.Items.GetChecked(intIndex);

    /// <summary>Gets the checkstate of the item.</summary>
    /// <param name="intIndex">Index of the int.</param>
    /// <returns></returns>
    public CheckState GetItemCheckState(int intIndex) => this.Items.GetCheckedState(intIndex);

    /// <summary>Sets the item checked status.</summary>
    /// <param name="intIndex">Item index.</param>
    /// <param name="blnChecked">Is checked.</param>
    public void SetItemChecked(int intIndex, bool blnChecked) => this.SetItemCheckState(intIndex, blnChecked ? CheckState.Checked : CheckState.Unchecked);

    /// <summary>Sets the item checkstate.</summary>
    /// <param name="intIndex">Index of the item.</param>
    /// <param name="enmNewCheckState">CheckState</param>
    public void SetItemCheckState(int intIndex, CheckState enmNewCheckState)
    {
      if (this.Items.Count <= 0)
        return;
      if (intIndex > this.Items.Count || intIndex < 0)
        throw new ArgumentException();
      CheckState checkedState = this.Items.GetCheckedState(intIndex);
      if (checkedState == enmNewCheckState)
        return;
      ItemCheckEventArgs objArgs = new ItemCheckEventArgs(intIndex, enmNewCheckState, checkedState);
      if (this.ItemCheckHandler != null)
        this.ItemCheckHandler((object) this, objArgs);
      if (objArgs.NewValue == checkedState)
        return;
      this.Items.SetCheckedState(intIndex, objArgs.NewValue);
      this.InvalidateCheckedItemsChache();
      this.Update();
    }

    /// <summary>
    /// 
    /// </summary>
    protected override ListBox.ObjectCollection CreateItemCollection() => (ListBox.ObjectCollection) new CheckedListBox.ObjectCollection(this);

    /// <summary>
    /// Gets the items of the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.
    /// </summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatData")]
    [SRDescription("ListBoxItemsDescr")]
    [Localizable(true)]
    [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public CheckedListBox.ObjectCollection Items => (CheckedListBox.ObjectCollection) base.Items;

    /// <summary>Collection of checked indexes in this <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> collection for the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public CheckedListBox.CheckedIndexCollection CheckedIndices
    {
      get
      {
        if (this.mobjCheckedIndexCollection == null)
          this.mobjCheckedIndexCollection = new CheckedListBox.CheckedIndexCollection(this);
        return this.mobjCheckedIndexCollection;
      }
    }

    /// <summary>Collection of checked items in this <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> collection for the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public CheckedListBox.CheckedItemCollection CheckedItems
    {
      get
      {
        if (this.mobjCheckedItemCollection == null)
          this.mobjCheckedItemCollection = new CheckedListBox.CheckedItemCollection(this);
        return this.mobjCheckedItemCollection;
      }
    }

    /// <summary>Gets the internal checked indexes.</summary>
    /// <value>The internal checked indexes.</value>
    private ArrayList InternalCheckedIndexes
    {
      get
      {
        this.EnsureCheckedItemsCache();
        return this.mobjCachedCheckedIndexes;
      }
    }

    /// <summary>Gets the internal checked objects.</summary>
    /// <value>The internal checked objects.</value>
    private ArrayList InternalCheckedObjects
    {
      get
      {
        this.EnsureCheckedItemsCache();
        return this.mobjCachedCheckedObjects;
      }
    }

    /// <summary>Invalidates the checked items.</summary>
    private void EnsureCheckedItemsCache()
    {
      if (this.mobjCachedCheckedObjects != null && this.mobjCachedCheckedIndexes != null)
        return;
      this.mobjCachedCheckedObjects = new ArrayList();
      this.mobjCachedCheckedIndexes = new ArrayList();
      CheckedListBox.ObjectCollection items = this.Items;
      if (items == null)
        return;
      int count = items.Count;
      for (int intIndex = 0; intIndex < count; ++intIndex)
      {
        if (items.GetChecked(intIndex))
        {
          this.mobjCachedCheckedObjects.Add(items[intIndex]);
          this.mobjCachedCheckedIndexes.Add((object) intIndex);
        }
      }
    }

    /// <summary>Invalidates the checked items.</summary>
    private void InvalidateCheckedItemsChache()
    {
      this.mobjCachedCheckedObjects = (ArrayList) null;
      this.mobjCachedCheckedIndexes = (ArrayList) null;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [radio boxes].
    /// </summary>
    /// <value><c>true</c> if [radio boxes]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete")]
    public override bool RadioBoxes
    {
      get => base.RadioBoxes;
      set => base.RadioBoxes = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [check boxes].
    /// </summary>
    /// <value><c>true</c> if [check boxes]; otherwise, <c>false</c>.</value>
    [DefaultValue(true)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete")]
    public override bool CheckBoxes
    {
      get => base.CheckBoxes;
      set => base.CheckBoxes = value;
    }

    /// <summary>
    /// 
    /// </summary>
    protected override bool ShouldSerializeSelectionMode() => this.SelectionMode != SelectionMode.One;

    /// <summary>Gets or sets a value indicating whether the check box should be toggled when an item is selected.</summary>
    /// <returns>true if the check mark is applied immediately; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRDescription("CheckedListBoxCheckOnClickDescr")]
    [SRCategory("CatBehavior")]
    public bool CheckOnClick
    {
      get => this.GetValue<bool>(CheckedListBox.CheckOnClickProperty);
      set
      {
        if (!this.SetValue<bool>(CheckedListBox.CheckOnClickProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      this.RenderCheckOnClick(objContext, objWriter, true);
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>
    /// Encapsulates the collection of checked items, including items in
    /// an indeterminate state, in a <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox">
    /// </see> control.
    /// </summary>
    [Serializable]
    public class CheckedItemCollection : IList, ICollection, IEnumerable
    {
      private CheckedListBox mobjCheckedListBox;

      internal CheckedItemCollection(CheckedListBox objCheckedListBox) => this.mobjCheckedListBox = objCheckedListBox;

      private ArrayList InternalCheckedObjects => this.mobjCheckedListBox.InternalCheckedObjects;

      /// <summary>Determines whether the specified item is located in the collection.</summary>
      /// <returns>true if item is in the collection; otherwise, false.</returns>
      /// <param name="objItem">An object from the items collection. </param>
      public bool Contains(object objItem) => this.InternalCheckedObjects.Contains(objItem);

      /// <summary>Copies the entire collection into an existing array at a specified location within the array.</summary>
      /// <param name="objDestinationArray">The destination array. </param>
      /// <param name="index">The zero-based relative index in dest at which copying begins. </param>
      /// <exception cref="T:System.ArgumentNullException">array is null. </exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
      /// <exception cref="T:System.RankException">array is multidimensional. </exception>
      /// <exception cref="T:System.ArrayTypeMismatchException">The type of the source <see cref="T:System.Array"></see> cannot be cast automatically to the type of the destination <see cref="T:System.Array"></see>. </exception>
      /// <exception cref="T:System.ArgumentException">index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Array"></see> is greater than the available space from index to the end of the destination <see cref="T:System.Array"></see>. </exception>
      public void CopyTo(Array objDestinationArray, int index) => this.InternalCheckedObjects.CopyTo(objDestinationArray, index);

      /// <summary>Returns an enumerator that can be used to iterate through the <see cref="P:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItems"></see> collection.</summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for navigating through the list.</returns>
      public IEnumerator GetEnumerator() => this.InternalCheckedObjects.GetEnumerator();

      /// <summary>Returns an index into the collection of checked items.</summary>
      /// <returns>The index of the object in the checked item collection or -1 if the object is not in the collection. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> class overview.</returns>
      /// <param name="objItem">The object whose index you want to retrieve. This object must belong to the checked items collection. </param>
      public int IndexOf(object objItem) => this.InternalCheckedObjects.IndexOf(objItem);

      int IList.Add(object objValue) => -1;

      void IList.Clear()
      {
      }

      void IList.Insert(int index, object objValue)
      {
      }

      void IList.Remove(object objValue)
      {
      }

      void IList.RemoveAt(int index)
      {
      }

      /// <summary>Gets the number of items in the collection.</summary>
      /// <returns>The number of items in the collection.</returns>
      public int Count => this.InternalCheckedObjects.Count;

      /// <summary>Gets a value indicating if the collection is read-only.</summary>
      /// <returns>Always true.</returns>
      public bool IsReadOnly => true;

      /// <summary>Gets an object in the checked items collection.</summary>
      /// <returns>The object at the specified index. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedItemCollection"></see> class overview.</returns>
      /// <param name="index">An index into the collection of checked items. This collection index corresponds to the index of the checked item. </param>
      /// <exception cref="T:System.NotSupportedException">The object cannot be set.</exception>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      [Browsable(false)]
      public object this[int index]
      {
        get => this.InternalCheckedObjects[index];
        set
        {
        }
      }

      bool ICollection.IsSynchronized => false;

      object ICollection.SyncRoot => this.InternalCheckedObjects.SyncRoot;

      bool IList.IsFixedSize => false;
    }

    /// <summary>
    /// Encapsulates the collection of indexes of checked items
    /// (including items in an indeterminate state) in a
    /// <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see>.
    /// </summary>
    [Serializable]
    public class CheckedIndexCollection : IList, ICollection, IEnumerable
    {
      private CheckedListBox mobjCheckedListBox;

      internal CheckedIndexCollection(CheckedListBox objCheckedListBox) => this.mobjCheckedListBox = objCheckedListBox;

      private ArrayList InternalCheckedIndexes => this.mobjCheckedListBox.InternalCheckedIndexes;

      /// <summary>Determines whether the specified index is located in the collection.</summary>
      /// <returns>true if the specified index from the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection"></see> is an item in this collection; otherwise, false.</returns>
      /// <param name="index">The index to locate in the collection. </param>
      public bool Contains(int index) => this.InternalCheckedIndexes.Contains((object) index);

      /// <summary>Copies the entire collection into an existing array at a specified location within the array.</summary>
      /// <param name="objDestinationArray">The destination array. </param>
      /// <param name="index">The zero-based relative index in dest at which copying begins. </param>
      /// <exception cref="T:System.ArgumentNullException">array is null. </exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
      /// <exception cref="T:System.RankException">array is multidimensional. </exception>
      /// <exception cref="T:System.ArrayTypeMismatchException">The type of the source <see cref="T:System.Array"></see> cannot be cast automatically to the type of the destination <see cref="T:System.Array"></see>. </exception>
      /// <exception cref="T:System.ArgumentException">index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Array"></see> is greater than the available space from index to the end of the destination <see cref="T:System.Array"></see>. </exception>
      public void CopyTo(Array objDestinationArray, int index) => this.InternalCheckedIndexes.CopyTo(objDestinationArray, index);

      /// <summary>Returns an enumerator that can be used to iterate through the <see cref="P:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndices"></see> collection.</summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> for navigating through the list.</returns>
      public IEnumerator GetEnumerator() => this.InternalCheckedIndexes.GetEnumerator();

      /// <summary>Returns an index into the collection of checked indexes.</summary>
      /// <returns>The index that specifies the index of the checked item or -1 if the index parameter is not in the checked indexes collection. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> class overview.</returns>
      /// <param name="index">The index of the checked item. </param>
      public int IndexOf(int index) => this.InternalCheckedIndexes.IndexOf((object) index);

      int IList.Add(object objValue) => -1;

      void IList.Clear()
      {
      }

      bool IList.Contains(object objIndex) => false;

      int IList.IndexOf(object objIndex) => -1;

      void IList.Insert(int index, object objValue)
      {
      }

      void IList.Remove(object objValue)
      {
      }

      void IList.RemoveAt(int index)
      {
      }

      /// <summary>Gets the number of checked items.</summary>
      /// <returns>The number of indexes in the collection.</returns>
      public int Count => this.InternalCheckedIndexes.Count;

      /// <summary>Gets a value indicating whether the collection is read-only.</summary>
      /// <returns>true in all cases.</returns>
      public bool IsReadOnly => true;

      /// <summary>Gets the index of a checked item in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox"></see> control.</summary>
      /// <returns>The index of the checked item. For more information, see the examples in the <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.CheckedIndexCollection"></see> class overview.</returns>
      /// <param name="index">An index into the checked indexes collection. This index specifies the index of the checked item you want to retrieve. </param>
      /// <exception cref="T:System.ArgumentException">The index is less than zero.-or- The index is not in the collection. </exception>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      [Browsable(false)]
      public int this[int index] => (int) this.InternalCheckedIndexes[index];

      bool ICollection.IsSynchronized => false;

      object ICollection.SyncRoot => this.InternalCheckedIndexes.SyncRoot;

      bool IList.IsFixedSize => false;

      object IList.this[int index]
      {
        get => this.InternalCheckedIndexes[index];
        set
        {
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public new class ObjectCollection : ListBox.ObjectCollection
    {
      private CheckedListBox mobjParent;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.CheckedListBox.ObjectCollection" /> instance.
      /// </summary>
      internal ObjectCollection(CheckedListBox objParent)
        : base((ListBox) objParent)
      {
        this.mobjParent = objParent;
      }

      /// <summary>Gets the checked.</summary>
      /// <param name="intIndex">Index of the int.</param>
      /// <returns></returns>
      internal bool GetChecked(int intIndex) => this.GetCheckedState(intIndex) != 0;

      /// <summary>Sets the checked.</summary>
      /// <param name="intIndex">Index of the int.</param>
      /// <param name="blnChecked">if set to <c>true</c> [BLN checked].</param>
      /// <returns></returns>
      internal void SetChecked(int intIndex, bool blnChecked) => this.SetCheckedState(intIndex, blnChecked ? CheckState.Checked : CheckState.Unchecked);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objItem"></param>
      /// <param name="blnChecked"></param>
      public int Add(object objItem, bool blnChecked)
      {
        int intIndex = this.Add(objItem);
        this.mobjParent.SetItemChecked(intIndex, blnChecked);
        return intIndex;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objItem"></param>
      /// <param name="enmCheck"></param>
      public int Add(object objItem, CheckState enmCheck)
      {
        int intIndex = this.Add(objItem);
        this.mobjParent.SetItemChecked(intIndex, enmCheck == CheckState.Checked);
        return intIndex;
      }

      /// <summary>Removes the specified object from the collection.</summary>
      /// <param name="objItem">An object representing the item to remove from the collection.</param>
      public override void Remove(object objItem)
      {
        ListBox.ListBoxItem listBoxItemByItem = this.GetListBoxItemByItem(objItem);
        if (listBoxItemByItem != null && this.mobjParent != null && listBoxItemByItem.CheckState != CheckState.Unchecked)
          this.mobjParent.InvalidateCheckedItemsChache();
        base.Remove(objItem);
      }

      /// <summary>Gets the checkstate of the item at specified index.</summary>
      /// <param name="intIndex">Index of the item.</param>
      /// <returns>checkstate</returns>
      internal CheckState GetCheckedState(int intIndex)
      {
        if (intIndex < 0 || intIndex >= this.Count)
          throw new ArgumentException();
        return this.mobjList[intIndex].CheckState;
      }

      /// <summary>Sets the checkstate of the item at specified index.</summary>
      /// <param name="intIndex">Index of the item.</param>
      /// <param name="enmNewCheckState">CheckState.</param>
      internal void SetCheckedState(int intIndex, CheckState enmNewCheckState)
      {
        if (intIndex < 0 || intIndex >= this.Count)
          throw new ArgumentException();
        this.mobjList[intIndex].CheckState = enmNewCheckState;
      }
    }
  }
}

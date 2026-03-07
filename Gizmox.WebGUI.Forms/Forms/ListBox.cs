// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListBox
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
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Implementation of ListBox class.</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ListBox), "ListBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Gizmox.WebGUI.Forms.MetadataTag("LX")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ListBoxSkin))]
  [Serializable]
  public class ListBox : ListControl
  {
    /// <summary>Provides a property reference to RadioBoxes property.</summary>
    private static SerializableProperty RadioBoxesProperty = SerializableProperty.Register(nameof (RadioBoxes), typeof (bool), typeof (ListBox), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to CheckBoxes property.</summary>
    private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register(nameof (CheckBoxes), typeof (bool), typeof (ListBox), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to Mode property.</summary>
    private static SerializableProperty ModeProperty = SerializableProperty.Register("Mode", typeof (SelectionMode), typeof (ListBox), new SerializablePropertyMetadata((object) SelectionMode.One));
    /// <summary>Provides a property reference to Sorted property.</summary>
    private static SerializableProperty SortedProperty = SerializableProperty.Register(nameof (Sorted), typeof (bool), typeof (ListBox), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to MultiColumn property.
    /// </summary>
    private static SerializableProperty MultiColumnProperty = SerializableProperty.Register(nameof (MultiColumn), typeof (bool), typeof (ListBox), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to ColumnWidth property.
    /// </summary>
    private static SerializableProperty ColumnWidthProperty = SerializableProperty.Register(nameof (ColumnWidth), typeof (int), typeof (ListBox), new SerializablePropertyMetadata((object) 0));
    /// <summary>
    /// Provides a property reference to IntegralHeight property.
    /// </summary>
    private static SerializableProperty IntegralHeightProperty = SerializableProperty.Register(nameof (IntegralHeight), typeof (bool), typeof (ListBox), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to TopIndex property.</summary>
    private static SerializableProperty TopIndexProperty = SerializableProperty.Register(nameof (TopIndex), typeof (int), typeof (ListBox));
    /// <summary>
    /// Provides a property reference to SelectedIndices property.
    /// </summary>
    [NonSerialized]
    private ListBox.SelectedIndexCollection mobjSelectedIndexCollection;
    /// <summary>
    /// Provides a property reference to SelectedItemd property.
    /// </summary>
    [NonSerialized]
    private ListBox.SelectedObjectCollection mobjSelectedObjectCollection;
    /// <summary>The SelectedIndexChanged event registration.</summary>
    private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof (EventHandler), typeof (ListBox));
    /// <summary>The cached Selected Items</summary>
    [NonSerialized]
    private ArrayList mobjCachedSelectedItems;
    /// <summary>The cached Selected indexes</summary>
    [NonSerialized]
    private List<int> mobjCachedSelectedIndexes;
    /// <summary>The list box items</summary>
    [NonSerialized]
    private ListBox.ObjectCollection mobjItems;
    /// <summary>The amount of fields the listbox needs to serialize</summary>
    private const int mintSerializableFieldCount = 0;

    /// <summary>Occurs when the SelectedIndex property has changed.</summary>
    public event EventHandler SelectedIndexChanged
    {
      add => this.AddCriticalHandler(ListBox.SelectedIndexChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ListBox.SelectedIndexChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs in client mode when the <see cref="P:Gizmox.WebGUI.Forms.ListBox"></see> value has changed.
    /// </summary>
    [SRDescription("selectedIndexChangedEventDescr")]
    [Category("Client")]
    public event ClientEventHandler ClientSelectedIndexChanged
    {
      add => this.AddClientHandler("SelectionChange", value);
      remove => this.RemoveClientHandler("SelectionChange", value);
    }

    /// <summary>Gets the hanlder for the SelectedIndexChanged event.</summary>
    private EventHandler SelectedIndexChangedHandler => (EventHandler) this.GetHandler(ListBox.SelectedIndexChangedEvent);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> class.
    /// </summary>
    public ListBox()
    {
      this.mobjItems = this.CreateItemCollection();
      this.SetStyle(ControlStyles.StandardClick | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, false);
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 0 + this.mobjItems.GetRequiredSerializationCapacity();

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mobjItems = this.CreateItemCollection();
      this.mobjItems.OnSerializableObjectDeserializing(objReader);
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      this.mobjItems.OnSerializableObjectSerializing(objWriter);
    }

    /// <summary>Renders the current control.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      bool blnShouldRenderItemImage = this.ShouldRenderImage();
      bool blnShouldRenderItemColor = this.ShouldRenderColor();
      if (this.SelectionMode != SelectionMode.One)
        objWriter.WriteAttributeString("SM", Convert.ToInt32((object) this.SelectionMode).ToString());
      if (this.MetadataTag == "LX")
      {
        if (this.CheckBoxes)
          objWriter.WriteAttributeString("CB", "1");
        else if (this.RadioBoxes)
          objWriter.WriteAttributeString("RB", "1");
      }
      ListBox.ObjectCollection items = this.Items;
      for (int intIndex = 0; intIndex < items.Count; ++intIndex)
      {
        objWriter.WriteStartElement("O");
        this.RenderItemAttributes(objWriter, items[intIndex], intIndex, blnShouldRenderItemImage, blnShouldRenderItemColor);
        objWriter.WriteEndElement();
      }
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.ShouldRenderColor())
        objWriter.WriteAttributeString("SHC", "1");
      if (this.ShouldRenderImage())
        objWriter.WriteAttributeString("SHI", "1");
      objWriter.WriteAttributeString("IMH", this.GetPreferdItemHeight().ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objWriter"></param>
    /// <param name="objItem"></param>
    /// <param name="intIndex"></param>
    protected internal virtual void RenderItemAttributes(
      IResponseWriter objWriter,
      object objItem,
      int intIndex,
      bool blnShouldRenderItemImage,
      bool blnShouldRenderItemColor)
    {
      objWriter.WriteAttributeString("Idx", intIndex.ToString());
      this.RenderItemIdAttribute(objWriter, objItem);
      if (this.Items.GetSelected(intIndex))
        objWriter.WriteAttributeString("SE", "1");
      if (objItem == null)
      {
        objWriter.WriteAttributeString("TX", "");
      }
      else
      {
        objWriter.WriteAttributeText("TX", this.GetItemText(objItem), TextFilter.NewLine | TextFilter.CarriageReturn);
        this.RenderColorAndImageAttribute(objWriter, blnShouldRenderItemImage, blnShouldRenderItemColor, objItem);
      }
    }

    /// <summary>Renders the item attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objItem">The obj item.</param>
    /// <param name="intIndex">Index of the int.</param>
    protected internal virtual void RenderItemAttributes(
      IResponseWriter objWriter,
      object objItem,
      int intIndex)
    {
      this.RenderItemAttributes(objWriter, objItem, intIndex, false, false);
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "SelectionChange")
        this.SelectIndexes(objEvent["Indexes"]);
      base.FireEvent(objEvent);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.SelectedValueChangedHandler != null || this.SelectedIndexChangedHandler != null || this.IsPostBackRequired)
        criticalEventsData.Set("SLC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("SelectionChange"))
        clientEventsData.Set("SLC");
      return clientEventsData;
    }

    /// <summary>
    /// Unselects all items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    public void ClearSelected()
    {
      this.ClearSelectedItems();
      this.Update();
    }

    /// <summary>Clears the selected items.</summary>
    private void ClearSelectedItems()
    {
      this.Items.ClearSelectedItems();
      this.InvalidateSelectionCache();
    }

    /// <summary>Selects the indexes.</summary>
    /// <param name="strIndexes">STR indexes.</param>
    private void SelectIndexes(string strIndexes)
    {
      bool flag = false;
      List<string> stringList = new List<string>((IEnumerable<string>) strIndexes.Split(','));
      ListBox.ObjectCollection items = this.Items;
      int count = items.Count;
      for (int intIndex = 0; intIndex < count; ++intIndex)
      {
        if (stringList.Contains(intIndex.ToString()))
        {
          if (!items.GetSelected(intIndex))
          {
            flag = true;
            this.Items.SetSelected(intIndex, true);
          }
        }
        else if (items.GetSelected(intIndex))
        {
          flag = true;
          this.Items.SetSelected(intIndex, false);
        }
      }
      if (!flag && !this.WinFormsCompatibility.IsForceSelectedIndexChangedOnClick)
        return;
      this.InvalidateSelectionCache();
      this.OnSelectedIndexChanged(EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.SelectedValueChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnSelectedIndexChanged(EventArgs e)
    {
      base.OnSelectedIndexChanged(e);
      CurrencyManager dataManager = this.DataManager;
      if (dataManager != null && dataManager.Position != this.SelectedIndex && (!this.FormattingEnabled || this.SelectedIndex != -1))
        dataManager.Position = this.SelectedIndex;
      EventHandler indexChangedHandler = this.SelectedIndexChangedHandler;
      if (indexChangedHandler == null)
        return;
      indexChangedHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DataSourceChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnDataSourceChanged(EventArgs e)
    {
      if (this.DataSource == null)
      {
        this.SelectedIndex = -1;
        this.Items.ClearInternal();
      }
      base.OnDataSourceChanged(e);
      this.RefreshItems();
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListControl.DisplayMemberChanged"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnDisplayMemberChanged(EventArgs e)
    {
      base.OnDisplayMemberChanged(e);
      this.RefreshItems();
      if (this.SelectionMode == SelectionMode.None || this.DataManager == null)
        return;
      this.SelectedIndex = this.DataManager.Position;
    }

    /// <summary>
    /// Refreshes all <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> items and retrieves new strings for them.
    /// </summary>
    protected override void RefreshItems()
    {
      ListBox.ObjectCollection mobjItems = this.mobjItems;
      ListBox.ObjectCollection objectCollection = this.mobjItems = this.CreateItemCollection();
      this.ClearSelectedItems();
      if (this.DataManager != null && this.DataManager.Count != -1)
      {
        object[] arrObjects = new object[this.DataManager.Count];
        for (int index = 0; index < arrObjects.Length; ++index)
          arrObjects[index] = this.DataManager[index];
        objectCollection.AddRangeInternal(arrObjects);
      }
      else if (mobjItems != null)
      {
        foreach (object objItem in mobjItems)
        {
          ListBox.ListBoxItem listBoxItemByItem = mobjItems.GetListBoxItemByItem(objItem);
          if (listBoxItemByItem != null)
            objectCollection.AddInternal(listBoxItemByItem);
        }
        this.Update();
      }
      if (this.SelectionMode == SelectionMode.None || this.DataManager == null)
        return;
      this.SelectedIndex = this.DataManager.Position;
    }

    /// <summary>When overridden in a derived class, resynchronizes the data of the object at the specified index with the contents of the data source.</summary>
    /// <param name="index">The zero-based index of the item whose data to refresh. </param>
    protected override void RefreshItem(int index) => this.Update();

    /// <summary>When overridden in a derived class, sets the specified array of objects in a collection in the derived class.</summary>
    /// <param name="objItems">An array of items.</param>
    protected override void SetItemsCore(IList objItems)
    {
      this.Items.ClearInternal();
      this.Items.AddRangeInternal((ICollection) objItems);
    }

    /// <summary>
    /// When overridden in a derived class, sets the object with the specified index in the derived class.
    /// </summary>
    /// <param name="index">The array index of the object.</param>
    /// <param name="objValue">The object.</param>
    protected override void SetItemCore(int index, object objValue) => this.Items.SetItemInternal(index, objValue);

    /// <summary>Clears the current selection</summary>
    internal void ResetSelection() => this.ClearSelectedItems();

    /// <summary>Clears the selection from object if selected</summary>
    /// <param name="intIndex">Index of the int.</param>
    internal void RemoveSelection(int intIndex)
    {
      if (!this.Items.SetSelected(intIndex, false))
        return;
      this.InvalidateSelectionCache();
    }

    /// <summary>Selects or clears the selection for the specified item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.</summary>
    /// <param name="blnValue">true to select the specified item; otherwise, false. </param>
    /// <param name="intIndex">The zero-based index of the item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> to select or clear the selection for. </param>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.ListBox.SelectionMode"></see> property was set to None.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified index was outside the range of valid values. </exception>
    /// <filterpriority>1</filterpriority>
    public void SetSelected(int intIndex, bool blnValue)
    {
      ListBox.ObjectCollection items = this.Items;
      int count = items == null ? 0 : items.Count;
      if (intIndex < 0 || intIndex >= count)
        throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", (object) "index", (object) intIndex.ToString()));
      if (this.SelectionMode == SelectionMode.None)
        throw new InvalidOperationException(SR.GetString("ListBoxInvalidSelectionMode"));
      if (this.Items.SetSelected(intIndex, blnValue))
      {
        this.InvalidateSelectionCache();
        this.Update();
      }
      this.OnSelectedIndexChanged(EventArgs.Empty);
    }

    /// <summary>
    /// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that starts with the specified string.
    /// </summary>
    /// <returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
    /// <param name="strValue">The text to search for. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the s parameter is less than -1 or greater than or equal to the item count.</exception>
    public int FindString(string strValue) => this.FindString(strValue, 0);

    /// <summary>
    /// Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that starts with the specified string. The search starts at a specific starting index.
    /// </summary>
    /// <returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
    /// <param name="strValue">The text to search for. </param>
    /// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to negative one (-1) to search from the beginning of the control. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
    public int FindString(string strValue, int intStartIndex)
    {
      ListBox.ObjectCollection items = this.Items;
      for (int intIndex = intStartIndex; intIndex < items.Count; ++intIndex)
      {
        if (items[intIndex] != null && this.GetItemText(items[intIndex]).StartsWith(strValue))
          return intIndex;
      }
      return -1;
    }

    /// <summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that exactly matches the specified string.</summary>
    /// <returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
    /// <param name="strValue">The text to search for. </param>
    /// <filterpriority>1</filterpriority>
    public int FindStringExact(string strValue) => this.FindStringExact(strValue, -1);

    /// <summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that exactly matches the specified string. The search starts at a specific starting index.</summary>
    /// <returns>The zero-based index of the first item found; returns ListBox.NoMatches if no match is found.</returns>
    /// <param name="strValue">The text to search for. </param>
    /// <param name="intStartIndex">The zero-based index of the item before the first item to be searched. Set to negative one (-1) to search from the beginning of the control. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The startIndex parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
    /// <filterpriority>1</filterpriority>
    public int FindStringExact(string strValue, int intStartIndex)
    {
      if (strValue == null)
        return -1;
      int count = this.Items == null ? 0 : this.Items.Count;
      if (count == 0)
        return -1;
      if (intStartIndex < -1 || intStartIndex >= count)
        throw new ArgumentOutOfRangeException(nameof (intStartIndex));
      return this.FindStringInternal(strValue, (IList) this.Items, intStartIndex, true);
    }

    /// <summary>Swaps the items.</summary>
    /// <param name="intIndexA">The int index A.</param>
    /// <param name="intIndexB">The int index B.</param>
    public virtual void SwapItems(int intIndexA, int intIndexB)
    {
      this.mobjItems.SwapItems(intIndexA, intIndexB);
      this.InvalidateSelectionCache();
      this.Update();
    }

    /// <summary>Creates the item collection.</summary>
    protected virtual ListBox.ObjectCollection CreateItemCollection() => new ListBox.ObjectCollection(this);

    /// <summary>Validates that there is no data source</summary>
    private void CheckNoDataSource()
    {
      if (this.DataSource != null)
        throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
    }

    /// <summary>
    /// Sorts the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    protected virtual void Sort()
    {
      ListBox.ObjectCollection items = this.Items;
      this.CheckNoDataSource();
      ListBox.SelectedObjectCollection selectedItems = this.SelectedItems;
      if (!this.Sorted || items == null)
        return;
      items.InternalSort();
    }

    /// <summary>Gets the height of the preferd item font.</summary>
    /// <returns></returns>
    internal int GetPreferdItemHeight()
    {
      if (!(this.Skin is ListBoxSkin skin))
        return 0;
      int num1 = 0;
      PaddingValue padding = skin.CellStyle.Padding;
      BorderValue border = skin.CellStyle.Border;
      if (border != null && border.Style != BorderStyle.None)
      {
        BorderWidth width = border.Width;
        int bottom = width.Bottom;
        width = border.Width;
        int top = width.Top;
        num1 = bottom + top;
      }
      int val2_1 = 0;
      if (this.ShouldRenderColor())
        val2_1 = skin.ListBoxColorBoxHeight;
      int val1 = 0;
      if (this.ShouldRenderImage())
        val1 = skin.ListBoxImageCellHeight;
      int num2 = 0;
      if (padding != null)
        num2 = padding.Top + padding.Bottom;
      int val2_2 = Math.Max(CommonUtils.GetFontHeight(this.Font), val2_1);
      return Math.Max(val1, val2_2) + num2 + num1;
    }

    /// <summary>Should serialize selection mode.</summary>
    protected virtual bool ShouldSerializeSelectionMode() => this.SelectionMode != SelectionMode.MultiSimple;

    /// <summary>
    /// Gets a value indicating whether this instance is delayed drawing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is delayed drawing; otherwise, <c>false</c>.
    /// </value>
    protected override bool IsDelayedDrawing => true;

    /// <summary>
    /// Gets or sets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> are sorted alphabetically.
    /// </summary>
    /// <returns>true if items in the control are sorted; otherwise, false. The default is false.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ListBoxSortedDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool Sorted
    {
      get => this.GetValue<bool>(ListBox.SortedProperty);
      set
      {
        if (!this.SetValue<bool>(ListBox.SortedProperty, value))
          return;
        ListBox.ObjectCollection items = this.Items;
        if (value && items != null && items.Count >= 1)
          this.Sort();
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the method in which items are selected in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.SelectionMode"></see> values. The default is SelectionMode.One.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.SelectionMode"></see> values.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [DefaultValue(SelectionMode.One)]
    [SRDescription("ListBoxSelectionModeDescr")]
    public SelectionMode SelectionMode
    {
      get => this.GetValue<SelectionMode>(ListBox.ModeProperty);
      set
      {
        SelectionMode selectionMode = this.SelectionMode;
        if (!this.SetValue<SelectionMode>(ListBox.ModeProperty, value))
          return;
        switch (value)
        {
          case SelectionMode.None:
            this.ResetSelection();
            break;
          case SelectionMode.One:
            if (selectionMode == SelectionMode.MultiExtended || selectionMode == SelectionMode.MultiSimple)
            {
              this.ApplySingleSelectionMode();
              break;
            }
            break;
        }
        this.Update();
      }
    }

    /// <summary>Applies a single selection mode.</summary>
    private void ApplySingleSelectionMode()
    {
      ListBox.ObjectCollection items = this.Items;
      if (items == null)
        return;
      ArrayList arrayList = new ArrayList();
      for (int intIndex = 0; intIndex < items.Count; ++intIndex)
      {
        if (items.GetSelected(intIndex))
          arrayList.Add((object) intIndex);
      }
      for (int index = 0; index < arrayList.Count - 1; ++index)
        items.SetSelected(Convert.ToInt32(arrayList[index]), false);
    }

    private bool CheckBoxesInternal
    {
      get => this.GetValue<bool>(ListBox.CheckBoxesProperty);
      set => this.SetValue<bool>(ListBox.CheckBoxesProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [check boxes].
    /// </summary>
    /// <value><c>true</c> if [check boxes]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public virtual bool CheckBoxes
    {
      get => this.CheckBoxesInternal;
      set
      {
        if (this.CheckBoxesInternal == value)
          return;
        this.CheckBoxesInternal = value;
        if (value)
          this.RadioBoxesInternal = false;
        this.Update();
      }
    }

    private bool RadioBoxesInternal
    {
      get => this.GetValue<bool>(ListBox.RadioBoxesProperty);
      set => this.SetValue<bool>(ListBox.RadioBoxesProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [radio boxes].
    /// </summary>
    /// <value><c>true</c> if [radio boxes]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public virtual bool RadioBoxes
    {
      get => this.RadioBoxesInternal;
      set
      {
        if (this.RadioBoxesInternal == value)
          return;
        this.RadioBoxesInternal = value;
        this.Update();
        if (!value)
          return;
        this.CheckBoxesInternal = false;
      }
    }

    /// <summary>
    /// Gets the items of the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatData")]
    [SRDescription("ListBoxItemsDescr")]
    [Localizable(true)]
    [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public ListBox.ObjectCollection Items => this.mobjItems;

    /// <summary>
    /// Gets or sets the zero-based index of the currently selected item in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    /// <returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
    /// <exception cref="T:System.ArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.ListBox.SelectionMode"></see> property is set to None.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than -1 or greater than or equal to the item count.</exception>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(-1)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [Bindable(true)]
    [SRDescription("ListBoxSelectedIndexDescr")]
    public override int SelectedIndex
    {
      get
      {
        this.EnsureSelectionCache();
        return this.mobjCachedSelectedIndexes.Count > 0 ? this.mobjCachedSelectedIndexes[0] : -1;
      }
      set
      {
        if (this.Items.Count <= value)
          return;
        if (value >= 0)
        {
          switch (this.SelectionMode)
          {
            case SelectionMode.None:
              throw new ArgumentException(SR.GetString("ListBoxInvalidSelectionMode"), nameof (SelectedIndex));
            case SelectionMode.One:
              this.SelectIndexes(value.ToString());
              break;
            default:
              this.SetSelected(value, true);
              break;
          }
          this.Update();
          this.InvokeMethod("ListBox_ScrollIntoView", (object) this.ID.ToString(), (object) value.ToString());
        }
        else
        {
          if (value != -1 || this.SelectedItems.Count <= 0)
            return;
          this.SelectedItems.Clear();
          this.Update();
          this.InvokeMethod("ListBox_ScrollIntoView", (object) this.ID.ToString(), (object) value.ToString());
        }
      }
    }

    /// <summary>
    /// Gets a collection that contains the zero-based indexes of all currently selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection"></see> containing the indexes of the currently selected items in the control. If no items are currently selected, an empty <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection"></see> is returned.</returns>
    [SRDescription("ListBoxSelectedIndicesDescr")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ListBox.SelectedIndexCollection SelectedIndices
    {
      get
      {
        this.EnsureSelectionCache();
        if (this.mobjSelectedIndexCollection == null)
          this.mobjSelectedIndexCollection = new ListBox.SelectedIndexCollection(this);
        return this.mobjSelectedIndexCollection;
      }
    }

    /// <summary>Gets the internal selected array list</summary>
    internal List<int> SelectedIndexesInternal
    {
      get
      {
        this.EnsureSelectionCache();
        return this.mobjCachedSelectedIndexes;
      }
    }

    /// <summary>
    /// Gets or sets the currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    /// <returns>An object that represents the current selection in the control.</returns>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [Bindable(true)]
    public object SelectedItem
    {
      get
      {
        this.EnsureSelectionCache();
        return this.mobjCachedSelectedItems.Count > 0 ? this.mobjCachedSelectedItems[0] : (object) null;
      }
      set => this.SelectedIndex = this.Items.IndexOf(value);
    }

    /// <summary>
    /// Gets a collection containing the currently selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> containing the currently selected items in the control.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ListBoxSelectedItemsDescr")]
    [Browsable(false)]
    public ListBox.SelectedObjectCollection SelectedItems
    {
      get
      {
        if (this.mobjSelectedObjectCollection == null)
          this.mobjSelectedObjectCollection = new ListBox.SelectedObjectCollection(this);
        return this.mobjSelectedObjectCollection;
      }
    }

    /// <summary>Gets the internal selected array list</summary>
    internal ArrayList SelectedItemsInternal
    {
      get
      {
        this.EnsureSelectionCache();
        return this.mobjCachedSelectedItems;
      }
    }

    /// <summary>Invalidates the selected items.</summary>
    private void EnsureSelectionCache()
    {
      if (this.mobjCachedSelectedItems != null && this.mobjCachedSelectedIndexes != null)
        return;
      this.mobjCachedSelectedItems = new ArrayList();
      this.mobjCachedSelectedIndexes = new List<int>();
      ListBox.ObjectCollection items = this.Items;
      for (int intIndex = 0; intIndex < items.Count; ++intIndex)
      {
        if (items.GetSelected(intIndex))
        {
          this.mobjCachedSelectedIndexes.Add(intIndex);
          this.mobjCachedSelectedItems.Add(items[intIndex]);
        }
      }
    }

    /// <summary>Invalidates the selection cache</summary>
    private void InvalidateSelectionCache()
    {
      this.mobjCachedSelectedItems = (ArrayList) null;
      this.mobjCachedSelectedIndexes = (List<int>) null;
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
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Bindable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public override string Text
    {
      get
      {
        if (this.SelectionMode == SelectionMode.None || this.SelectedItem == null)
          return base.Text;
        return this.FormattingEnabled ? this.GetItemText(this.SelectedItem) : this.FilterItemOnProperty(this.SelectedItem).ToString();
      }
      set
      {
        base.Text = value;
        if (this.SelectionMode == SelectionMode.None || value == null || this.SelectedItem != null && value.Equals(this.GetItemText(this.SelectedItem)))
          return;
        int count = this.Items.Count;
        for (int intIndex = 0; intIndex < count; ++intIndex)
        {
          if (string.Compare(value, this.GetItemText(this.Items[intIndex]), true, CultureInfo.InvariantCulture) == 0)
          {
            this.SelectedIndex = intIndex;
            break;
          }
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [multi column].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [multi column]; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool MultiColumn
    {
      get => this.GetValue<bool>(ListBox.MultiColumnProperty);
      set => this.SetValue<bool>(ListBox.MultiColumnProperty, value);
    }

    /// <summary>Gets or sets the column width.</summary>
    /// <value>The width of the columns</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatBehavior")]
    [SRDescription("ListBoxColumnWidthDescr")]
    [Localizable(true)]
    [DefaultValue(0)]
    public int ColumnWidth
    {
      get => this.GetValue<int>(ListBox.ColumnWidthProperty);
      set => this.SetValue<int>(ListBox.ColumnWidthProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [integral height].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [integral height]; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IntegralHeight
    {
      get => this.GetValue<bool>(ListBox.IntegralHeightProperty);
      set => this.SetValue<bool>(ListBox.IntegralHeightProperty, value);
    }

    /// <summary>Gets or sets the index of the top.</summary>
    /// <value>The index of the top.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TopIndex
    {
      get => this.GetValue<int>(ListBox.TopIndexProperty);
      set => this.SetValue<int>(ListBox.TopIndexProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether the vertical scroll bar is shown at all times.</summary>
    /// <returns>true if the vertical scroll bar should always be displayed; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatBehavior")]
    [SRDescription("ListBoxScrollIsVisibleDescr")]
    [DefaultValue(false)]
    [Localizable(true)]
    public bool ScrollAlwaysVisible
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether a horizontal scroll bar is displayed in the control.</summary>
    /// <returns>true to display a horizontal scroll bar in the control; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ListBoxHorizontalScrollbarDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [Localizable(true)]
    public bool HorizontalScrollbar
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the height of the item.</summary>
    /// <value>The height of the item.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [Obsolete("Setter not implemented. Added for migration compatibility")]
    public int ItemHeight
    {
      get => this.GetPreferdItemHeight();
      set
      {
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class ListBoxItem
    {
      /// <summary>The list state</summary>
      [NonSerialized]
      private int mintState;
      /// <summary>
      /// 
      /// </summary>
      [NonSerialized]
      private object mobjItem;
      /// <summary>
      /// 
      /// </summary>
      [NonSerialized]
      private CheckState menmCheckState;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> class.
      /// </summary>
      /// <param name="objItem">The item.</param>
      public ListBoxItem(object objItem) => this.mobjItem = objItem;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> class.
      /// </summary>
      /// <param name="objItem">The item.</param>
      public ListBoxItem(object objItem, int intState)
      {
        this.mobjItem = objItem;
        this.mintState = intState;
      }

      /// <summary>Sets the state.</summary>
      /// <param name="enmState">The flag to set.</param>
      /// <param name="blnValue">The flag value to set.</param>
      internal void SetState(ListBox.ListBoxItem.ItemState enmState, bool blnValue) => this.mintState = blnValue ? (int) ((ListBox.ListBoxItem.ItemState) this.mintState | enmState) : (int) ((ListBox.ListBoxItem.ItemState) this.mintState & ~enmState);

      /// <summary>Gets the state.</summary>
      /// <param name="enmState">The state to get.</param>
      /// <returns></returns>
      internal bool GetState(ListBox.ListBoxItem.ItemState enmState) => ((ListBox.ListBoxItem.ItemState) this.mintState & enmState) != 0;

      /// <summary>Gets or sets the item.</summary>
      /// <value>The item.</value>
      public object Item
      {
        get => this.mobjItem;
        set => this.mobjItem = value;
      }

      /// <summary>
      /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> is selected.
      /// </summary>
      /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
      public bool Selected
      {
        get => this.GetState(ListBox.ListBoxItem.ItemState.Selected);
        set => this.SetState(ListBox.ListBoxItem.ItemState.Selected, value);
      }

      /// <summary>
      /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListBox.ListBoxItem" /> is checked.
      /// </summary>
      /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
      public CheckState CheckState
      {
        get => this.menmCheckState;
        set => this.menmCheckState = value;
      }

      /// <summary>Gets or sets the state.</summary>
      /// <value>The state.</value>
      internal int State
      {
        get => this.mintState;
        set => this.mintState = value;
      }

      /// <summary>The listbox item state</summary>
      [Flags]
      internal enum ItemState
      {
        /// <summary>The list state enum</summary>
        Selected = 1,
      }
    }

    /// <summary>The list box object collection</summary>
    public class ObjectCollection : ICollection, IEnumerable, IList
    {
      /// <summary>The owner tab control</summary>
      internal List<ListBox.ListBoxItem> mobjList;
      /// <summary>The object collection parent control</summary>
      private ListBox mobjParent;

      /// <summary>
      /// Initializes a new instance of <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see>.
      /// </summary>
      /// <param name="objParent">The <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> that owns the collection. </param>
      internal ObjectCollection(ListBox objParent)
      {
        this.mobjList = new List<ListBox.ListBoxItem>();
        this.mobjParent = objParent;
      }

      /// <summary>
      /// Sorts the items using an internal comparer which compares by text
      /// </summary>
      internal void InternalSort() => this.mobjList.Sort((IComparer<ListBox.ListBoxItem>) new ListBox.ObjectCollection.ObjectCollectionComparer(this.mobjParent));

      /// <summary>
      /// Gets a value indicating whether access to the collection is synchronized (thread safe).
      /// </summary>
      /// <returns>false in all cases.</returns>
      public bool IsSynchronized => false;

      /// <summary>Gets the number of items in the collection.</summary>
      /// <returns>The number of items in the collection </returns>
      public int Count => this.mobjList.Count;

      /// <summary>
      /// Copies the entire collection into an existing array of objects at a specified location within the array.
      /// </summary>
      /// <param name="intArrayIndex">The location within the destination array to copy the items from the collection to. </param>
      /// <param name="objDestinationArray">The object array in which the items from the collection are copied to. </param>
      public void CopyTo(Array objDestinationArray, int intArrayIndex)
      {
        for (int index = intArrayIndex; index < this.mobjList.Count; ++index)
          objDestinationArray.SetValue(this.mobjList[index].Item, index);
      }

      /// <summary>Gets the sync root.</summary>
      /// <returns>An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see>.</returns>
      public object SyncRoot => (object) this.mobjList;

      /// <summary>
      /// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
      /// </summary>
      /// <returns>The zero-based index of the item in the collection, or -1 if <see cref="M:Gizmox.WebGUI.Forms.ListBox.BeginUpdate"></see> has been called.</returns>
      /// <param name="objObject">An object representing the item to add to the collection. </param>
      /// <exception cref="T:System.SystemException">There is insufficient space available to add the new item to the list. </exception>
      public int Add(object objObject)
      {
        this.mobjParent.CheckNoDataSource();
        int num = this.IsItemValid(objObject) ? this.AddInternal(objObject) : throw new ArgumentException(this.GetItemInvalidMessage(objObject));
        this.mobjParent.Update();
        return num;
      }

      /// <summary>Add to internal list with or with out sorting</summary>
      /// <param name="objItem">The obj item.</param>
      /// <returns></returns>
      private int AddInternal(object objItem) => objItem != null ? this.AddInternal(new ListBox.ListBoxItem(objItem)) : throw new ArgumentNullException("item");

      /// <summary>Adds the internal.</summary>
      /// <param name="objListBoxItem">The obj list box item.</param>
      /// <returns></returns>
      internal int AddInternal(ListBox.ListBoxItem objListBoxItem)
      {
        int index;
        if (!this.mobjParent.Sorted)
        {
          this.mobjList.Add(objListBoxItem);
          index = this.mobjList.IndexOf(objListBoxItem);
        }
        else
        {
          if (this.Count > 0)
          {
            index = this.mobjList.BinarySearch(objListBoxItem, (IComparer<ListBox.ListBoxItem>) new ListBox.ObjectCollection.ObjectCollectionComparer(this.mobjParent));
            if (index < 0)
              index = ~index;
          }
          else
            index = 0;
          this.mobjList.Insert(index, objListBoxItem);
        }
        return index;
      }

      /// <summary>
      /// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
      /// </summary>
      /// <param name="arrObjects">The obj objects.</param>
      internal void AddRangeInternal(object[] arrObjects)
      {
        foreach (object arrObject in arrObjects)
        {
          if (!this.IsItemValid(arrObject))
            throw new ArgumentException(this.GetItemInvalidMessage(arrObject));
          this.AddInternal(arrObject);
        }
        this.mobjParent.Update();
      }

      /// <summary>
      /// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
      /// </summary>
      /// <param name="arrObjects">An array of objects to add to the list. </param>
      public void AddRange(object[] arrObjects)
      {
        this.mobjParent.CheckNoDataSource();
        this.AddRangeInternal(arrObjects);
      }

      /// <summary>Determines whether item is valid.</summary>
      /// <param name="objItem">The item to check validite.</param>
      /// <returns>
      /// 	<c>true</c> if valid item; otherwise, <c>false</c>.
      /// </returns>
      protected virtual bool IsItemValid(object objItem) => true;

      /// <summary>Gets the item invalid message.</summary>
      /// <param name="objItem">The item to check validite.</param>
      /// <returns></returns>
      protected virtual string GetItemInvalidMessage(object objItem) => "";

      /// <summary>
      /// Adds the items of an existing <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> to the list of items in a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
      /// </summary>
      /// <param name="objObjects">A <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> to load into this collection. </param>
      public void AddRange(ICollection objObjects)
      {
        this.mobjParent.CheckNoDataSource();
        this.AddRangeInternal(objObjects);
      }

      /// <summary>Adds the range internal.</summary>
      /// <param name="objObjects">The obj objects.</param>
      internal void AddRangeInternal(ICollection objObjects)
      {
        foreach (object objObject in (IEnumerable) objObjects)
        {
          if (!this.IsItemValid(objObject))
            throw new ArgumentException(this.GetItemInvalidMessage(objObject));
          this.AddInternal(objObject);
        }
        this.mobjParent.Update();
      }

      /// <summary>Sets the item with a new value</summary>
      /// <param name="index">The index.</param>
      /// <param name="objValue">The value.</param>
      internal void SetItemInternal(int index, object objValue)
      {
        if (objValue == null)
          throw new ArgumentNullException("value");
        if (index < 0 || index >= this.mobjList.Count)
          throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString()));
        this.mobjList[index].Item = objValue;
        this.mobjParent.Update();
      }

      internal int GetRequiredSerializationCapacity() => this.mobjList.Count * 2 + 1;

      /// <summary>Called when listbox is serializing].</summary>
      /// <param name="objWriter">The serialization writer.</param>
      internal void OnSerializableObjectSerializing(SerializationWriter objWriter)
      {
        objWriter.WriteInt32(this.mobjList.Count);
        for (int index = 0; index < this.mobjList.Count; ++index)
        {
          ListBox.ListBoxItem mobj = this.mobjList[index];
          if (mobj != null)
          {
            objWriter.WriteObject(mobj.Item);
            objWriter.WriteInt32(mobj.State);
            objWriter.WriteInt32((int) mobj.CheckState);
          }
          else
          {
            objWriter.WriteObject((object) null);
            objWriter.WriteInt32(0);
            objWriter.WriteInt32(0);
          }
        }
      }

      /// <summary>Called when listbox is deserializing.</summary>
      /// <param name="objReader">The serialization reader.</param>
      internal void OnSerializableObjectDeserializing(SerializationReader objReader)
      {
        this.mobjList = new List<ListBox.ListBoxItem>();
        int num = objReader.ReadInt32();
        for (int index = 0; index < num; ++index)
          this.mobjList.Add(new ListBox.ListBoxItem(objReader.ReadObject(), objReader.ReadInt32())
          {
            CheckState = (CheckState) objReader.ReadInt32()
          });
      }

      /// <summary>Clears the selected items.</summary>
      internal void ClearSelectedItems()
      {
        List<ListBox.ListBoxItem> all = this.mobjList.FindAll((Predicate<ListBox.ListBoxItem>) (objListBoxItem => objListBoxItem.Selected));
        if (all == null)
          return;
        foreach (ListBox.ListBoxItem listBoxItem in all)
        {
          if (listBoxItem.Selected)
            listBoxItem.Selected = false;
        }
      }

      /// <summary>Removes the specified object from the collection.</summary>
      /// <param name="objItem">An object representing the item to remove from the collection. </param>
      public virtual void Remove(object objItem)
      {
        ListBox.ListBoxItem listBoxItemByItem = this.GetListBoxItemByItem(objItem);
        if (listBoxItemByItem == null)
          return;
        int index = this.mobjList.IndexOf(listBoxItemByItem);
        if (index == -1)
          return;
        this.RemoveAt(index);
      }

      /// <summary>Gets the list box item by item.</summary>
      /// <param name="objItem">The obj item.</param>
      /// <returns></returns>
      internal ListBox.ListBoxItem GetListBoxItemByItem(object objItem) => this.mobjList.Find((Predicate<ListBox.ListBoxItem>) (objListBoxItem =>
      {
        if (objListBoxItem.Item == null && objItem == null)
          return true;
        return (objListBoxItem.Item != null || objItem == null) && (objListBoxItem.Item == null || objItem != null) && objListBoxItem.Item.Equals(objItem);
      }));

      /// <summary>
      /// Returns an enumerator to use to iterate through the item collection.
      /// </summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
      public IEnumerator GetEnumerator()
      {
        object[] objArray = new object[this.mobjList.Count];
        for (int index = 0; index < this.mobjList.Count; ++index)
          objArray[index] = this.mobjList[index].Item;
        return objArray.GetEnumerator();
      }

      /// <summary>Clears the internal.</summary>
      internal void ClearInternal()
      {
        this.InternalClear();
        if (this.InternalListBox != null)
          this.InternalListBox.ResetSelection();
        this.mobjParent.Update();
      }

      /// <summary>
      /// Removes all items from the <see cref="T:System.Collections.IList"></see>.
      /// </summary>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only. </exception>
      public virtual void Clear()
      {
        this.mobjParent.CheckNoDataSource();
        this.ClearInternal();
      }

      /// <summary>Internal Clear method.</summary>
      internal void InternalClear() => this.mobjList.Clear();

      /// <summary>
      /// Returns the index within the collection of the specified item.
      /// </summary>
      /// <returns>The zero-based index where the item is located within the collection; otherwise, negative one (-1).</returns>
      /// <param name="objItem">An item representing the item to locate in the collection. </param>
      /// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
      /// <returns></returns>
      public int IndexOf(object objItem)
      {
        ListBox.ListBoxItem listBoxItemByItem = this.GetListBoxItemByItem(objItem);
        return listBoxItemByItem != null ? this.mobjList.IndexOf(listBoxItemByItem) : -1;
      }

      /// <summary>Gets the selected.</summary>
      /// <param name="intIndex">Index of the int.</param>
      /// <returns>
      /// 	<c>true</c> if the specified obj item is selected; otherwise, <c>false</c>.
      /// </returns>
      internal bool GetSelected(int intIndex) => this.mobjList[intIndex].Selected;

      /// <summary>Sets the selected.</summary>
      /// <param name="intIndex">Index of the int.</param>
      /// <param name="blnSelected">if set to <c>true</c> [BLN selected].</param>
      /// <returns></returns>
      internal bool SetSelected(int intIndex, bool blnSelected)
      {
        bool flag = false;
        if (this.mobjList[intIndex].Selected != blnSelected)
        {
          flag = true;
          this.mobjList[intIndex].Selected = blnSelected;
        }
        return flag;
      }

      /// <summary>
      /// Gets or sets the item at the specified index within the collection.
      /// </summary>
      /// <returns>An object representing the item located at the specified index within the collection.</returns>
      /// <param name="intIndex">The index of the item in the collection to get or set. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      [Browsable(false)]
      public object this[int intIndex]
      {
        get => this.mobjList[intIndex].Item;
        set
        {
          this.mobjParent.CheckNoDataSource();
          if (this.mobjList[intIndex].Item == value)
            return;
          this.mobjList[intIndex].Item = value;
          if (this.mobjParent == null)
            return;
          this.mobjParent.Update();
        }
      }

      /// <summary>Gets the parent listbox</summary>
      private ListBox InternalListBox => this.mobjParent;

      /// <summary>
      /// Gets a value indicating whether the collection is read-only.
      /// </summary>
      /// <returns>true if this collection is read-only; otherwise, false.</returns>
      public bool IsReadOnly => false;

      /// <summary>
      /// Removes the item at the specified index within the collection.
      /// </summary>
      /// <param name="index">The zero-based index of the item to remove. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
      public void RemoveAt(int index)
      {
        if (this.mobjParent == null)
          return;
        this.mobjParent.CheckNoDataSource();
        if (index < 0 || index >= this.mobjList.Count)
          throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        bool flag1 = false;
        ListBox.ListBoxItem mobj = this.mobjList[index];
        if (mobj != null)
          flag1 = mobj.Selected;
        bool flag2 = this.SelectedIndicesChanged(index);
        this.mobjList.RemoveAt(index);
        if (flag1 | flag2)
          this.mobjParent.InvalidateSelectionCache();
        this.mobjParent.Update();
        if (!(flag1 | flag2))
          return;
        this.mobjParent.OnSelectedIndexChanged(EventArgs.Empty);
      }

      /// <summary>Checks if selected indices should be updated.</summary>
      /// <param name="index">The index of removed/inserted item.</param>
      /// <returns>true if selected indices should be updated; otherwise, false</returns>
      private bool SelectedIndicesChanged(int index)
      {
        foreach (int selectedIndex in this.mobjParent.SelectedIndices)
        {
          if (selectedIndex >= index)
            return true;
        }
        return false;
      }

      /// <summary>Inserts an item into the list box at the specified index.</summary>
      /// <param name="objValue">An object representing the item to insert. </param>
      /// <param name="index">The zero-based index location where the item is inserted. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.ObjectCollection"></see> class. </exception>
      public void Insert(int index, object objValue)
      {
        this.mobjParent.CheckNoDataSource();
        int num = this.SelectedIndicesChanged(index) ? 1 : 0;
        this.mobjList.Insert(index, new ListBox.ListBoxItem(objValue));
        if (num != 0)
          this.mobjParent.InvalidateSelectionCache();
        this.mobjParent.Update();
        if (num == 0)
          return;
        this.mobjParent.OnSelectedIndexChanged(EventArgs.Empty);
      }

      /// <summary>
      /// Determines whether the specified item is located within the collection.
      /// </summary>
      /// <returns>true if the item is located within the collection; otherwise, false.</returns>
      /// <param name="value">An object representing the item to locate in the collection. </param>
      public bool Contains(object objItem) => this.GetListBoxItemByItem(objItem) != null;

      /// <summary>
      /// Gets a value indicating whether the collection has a fixed size.
      /// </summary>
      /// <returns>true in all cases.</returns>
      public bool IsFixedSize => false;

      /// <summary>Swaps the items.</summary>
      /// <param name="intIndexA">The int index A.</param>
      /// <param name="intIndexB">The int index B.</param>
      internal void SwapItems(int intIndexA, int intIndexB)
      {
        ListBox.ListBoxItem mobj = this.mobjList[intIndexA];
        this.mobjList[intIndexA] = this.mobjList[intIndexB];
        this.mobjList[intIndexB] = mobj;
      }

      [Serializable]
      internal class ObjectCollectionComparer : IComparer<ListBox.ListBoxItem>
      {
        private ListBox mobjListControl;

        internal ObjectCollectionComparer(ListBox objListControl) => this.mobjListControl = objListControl;

        int IComparer<ListBox.ListBoxItem>.Compare(
          ListBox.ListBoxItem objFirstListBoxItem,
          ListBox.ListBoxItem objSecondListBoxItem)
        {
          if (objFirstListBoxItem == null)
            return objSecondListBoxItem == null ? 0 : -1;
          if (objSecondListBoxItem == null)
            return 1;
          object objItem1 = objFirstListBoxItem.Item;
          object objItem2 = objSecondListBoxItem.Item;
          return objItem1 == null ? (objItem2 == null ? 0 : -1) : (objItem2 == null ? 1 : Application.CurrentCulture.CompareInfo.Compare(this.mobjListControl.GetItemText(objItem1), this.mobjListControl.GetItemText(objItem2), CompareOptions.StringSort));
        }
      }
    }

    /// <summary>This is the selected index collection</summary>
    [Serializable]
    public class SelectedIndexCollection : IList, ICollection, IEnumerable
    {
      private ListBox mobjOwner;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection" /> class.
      /// </summary>
      /// <param name="objOwner">The owner.</param>
      public SelectedIndexCollection(ListBox objOwner) => this.mobjOwner = objOwner;

      /// <summary>Adds the specified index.</summary>
      /// <param name="intIndex">The index.</param>
      public void Add(int intIndex)
      {
        if (this.mobjOwner == null || this.mobjOwner.Items == null || intIndex == -1 || this.Contains(intIndex))
          return;
        this.mobjOwner.SetSelected(intIndex, true);
      }

      /// <summary>
      /// Removes all items from the <see cref="T:System.Collections.IList" />.
      /// </summary>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only. </exception>
      public void Clear()
      {
        if (this.mobjOwner == null)
          return;
        this.mobjOwner.ClearSelected();
      }

      /// <summary>
      /// Determines whether [contains] [the specified selected index].
      /// </summary>
      /// <param name="intSelectedIndex">Index of the selected.</param>
      /// <returns>
      ///   <c>true</c> if [contains] [the specified selected index]; otherwise, <c>false</c>.
      /// </returns>
      public bool Contains(int intSelectedIndex) => this.IndexOf(intSelectedIndex) != -1;

      /// <summary>Copies to.</summary>
      /// <param name="objDestination">The destination.</param>
      /// <param name="intIndex">The index.</param>
      public void CopyTo(Array objDestination, int intIndex)
      {
        int count = this.Count;
        for (int intIndex1 = 0; intIndex1 < count; ++intIndex1)
          objDestination.SetValue((object) this[intIndex1], intIndex1 + intIndex);
      }

      /// <summary>
      /// Returns an enumerator that iterates through a collection.
      /// </summary>
      /// <returns>
      /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
      /// </returns>
      public IEnumerator GetEnumerator() => (IEnumerator) new ListBox.SelectedIndexCollection.SelectedIndexEnumerator(this);

      /// <summary>Indexes the of.</summary>
      /// <param name="intSelectedIndex">Index of the selected.</param>
      /// <returns></returns>
      public int IndexOf(int intSelectedIndex) => this.mobjOwner != null && intSelectedIndex >= 0 && intSelectedIndex < this.InnerArray.Count ? this.mobjOwner.SelectedIndexesInternal.IndexOf(intSelectedIndex) : -1;

      /// <summary>Removes the specified index.</summary>
      /// <param name="intIndex">The index.</param>
      public void Remove(int intIndex)
      {
        if (this.mobjOwner == null || this.mobjOwner.Items == null || intIndex == -1 || !this.Contains(intIndex))
          return;
        this.mobjOwner.SetSelected(intIndex, false);
      }

      /// <summary>
      /// Adds an item to the <see cref="T:System.Collections.IList" />.
      /// </summary>
      /// <param name="value">The object to add to the <see cref="T:System.Collections.IList" />.</param>
      /// <returns>
      /// The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection,
      /// </returns>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
      int IList.Add(object value) => throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));

      /// <summary>
      /// Removes all items from the <see cref="T:System.Collections.IList" />.
      /// </summary>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only. </exception>
      void IList.Clear() => throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));

      /// <summary>
      /// Determines whether [contains] [the specified selected index].
      /// </summary>
      /// <param name="objSelectedIndex">Index of the selected.</param>
      /// <returns>
      ///   <c>true</c> if [contains] [the specified selected index]; otherwise, <c>false</c>.
      /// </returns>
      bool IList.Contains(object objSelectedIndex) => objSelectedIndex is int intSelectedIndex && this.Contains(intSelectedIndex);

      /// <summary>Indexes the of.</summary>
      /// <param name="objSelectedIndex">Index of the selected.</param>
      /// <returns></returns>
      int IList.IndexOf(object objSelectedIndex) => objSelectedIndex is int intSelectedIndex ? this.IndexOf(intSelectedIndex) : -1;

      /// <summary>
      /// Inserts an item to the <see cref="T:System.Collections.IList" /> at the specified index.
      /// </summary>
      /// <param name="intIndex">The zero-based index at which <paramref name="objValue" /> should be inserted.</param>
      /// <param name="objValue">The object to insert into the <see cref="T:System.Collections.IList" />.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">
      /// <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
      /// <exception cref="T:System.NullReferenceException">
      /// <paramref name="objValue" /> is null reference in the <see cref="T:System.Collections.IList" />.</exception>
      void IList.Insert(int intIndex, object objValue) => throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));

      /// <summary>
      /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList" />.
      /// </summary>
      /// <param name="objValue">The object to remove from the <see cref="T:System.Collections.IList" />.</param>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
      void IList.Remove(object objValue) => throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));

      /// <summary>
      /// Removes the <see cref="T:System.Collections.IList" /> item at the specified index.
      /// </summary>
      /// <param name="intIndex">The zero-based index of the item to remove.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">
      /// <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only.-or- The <see cref="T:System.Collections.IList" /> has a fixed size. </exception>
      void IList.RemoveAt(int intIndex) => throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));

      [Browsable(false)]
      public int Count => this.mobjOwner.SelectedItems.Count;

      /// <summary>Gets the inner array.</summary>
      private ListBox.ObjectCollection InnerArray => this.mobjOwner.Items;

      /// <summary>
      /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.
      /// </summary>
      /// <returns>true if the <see cref="T:System.Collections.IList" /> is read-only; otherwise, false.</returns>
      public bool IsReadOnly => true;

      /// <summary>Gets or sets the element at the specified index.</summary>
      /// <returns>The element at the specified index.</returns>
      /// <exception cref="T:System.ArgumentOutOfRangeException">
      /// <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
      /// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IList" /> is read-only. </exception>
      public int this[int intIndex] => this.mobjOwner.SelectedIndexesInternal[intIndex];

      /// <summary>
      /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
      /// </summary>
      /// <returns>true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.</returns>
      bool ICollection.IsSynchronized => true;

      /// <summary>
      /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
      /// </summary>
      /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</returns>
      object ICollection.SyncRoot => (object) this;

      /// <summary>
      /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
      /// </summary>
      /// <returns>true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.</returns>
      bool IList.IsFixedSize => true;

      /// <summary>Gets or sets the element at the specified index.</summary>
      /// <returns>The element at the specified index.</returns>
      /// <exception cref="T:System.ArgumentOutOfRangeException">
      /// <paramref name="intIndex" /> is not a valid index in the <see cref="T:System.Collections.IList" />. </exception>
      /// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.IList" /> is read-only. </exception>
      object IList.this[int intIndex]
      {
        get => (object) this[intIndex];
        set => throw new NotSupportedException(SR.GetString("ListBoxSelectedIndexCollectionIsReadOnly"));
      }

      /// <summary>
      /// 
      /// </summary>
      [Serializable]
      private class SelectedIndexEnumerator : IEnumerator
      {
        private int mintCurrent;
        private ListBox.SelectedIndexCollection mobjItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedIndexCollection.SelectedIndexEnumerator" /> class.
        /// </summary>
        /// <param name="objItems">The items.</param>
        public SelectedIndexEnumerator(ListBox.SelectedIndexCollection objItems)
        {
          this.mobjItems = objItems;
          this.mintCurrent = -1;
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
        bool IEnumerator.MoveNext()
        {
          if (this.mintCurrent < this.mobjItems.Count - 1)
          {
            ++this.mintCurrent;
            return true;
          }
          this.mintCurrent = this.mobjItems.Count;
          return false;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
        void IEnumerator.Reset() => this.mintCurrent = -1;

        /// <summary>Gets the current element in the collection.</summary>
        /// <returns>The current element in the collection.</returns>
        /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception>
        object IEnumerator.Current
        {
          get
          {
            if (this.mintCurrent == -1 || this.mintCurrent == this.mobjItems.Count)
              throw new InvalidOperationException(SR.GetString("ListEnumCurrentOutOfRange"));
            return (object) this.mobjItems[this.mintCurrent];
          }
        }
      }
    }

    /// <summary>
    /// Represents the collection of selected items in the <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
    /// </summary>
    [Serializable]
    public class SelectedObjectCollection : IList, ICollection, IEnumerable
    {
      private ListBox mobjOwner;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> class.
      /// </summary>
      /// <param name="objOwner">A <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see> representing the mobjOwner of the collection. </param>
      public SelectedObjectCollection(ListBox objOwner) => this.mobjOwner = objOwner;

      /// <summary>
      /// Adds an item to the list of selected items for a <see cref="T:Gizmox.WebGUI.Forms.ListBox"></see>.
      /// </summary>
      /// <param name="objValue">An object representing the item to add to the collection of selected items.</param>
      public void Add(object objValue)
      {
        if (this.mobjOwner == null)
          return;
        ListBox.ObjectCollection items = this.mobjOwner.Items;
        if (items == null || objValue == null)
          return;
        int index = items.IndexOf(objValue);
        if (index == -1 || this.GetSelected(index))
          return;
        this.mobjOwner.SelectedIndex = index;
      }

      /// <summary>
      /// Removes all items from the collection of selected items.
      /// </summary>
      public void Clear()
      {
        if (this.mobjOwner == null)
          return;
        this.mobjOwner.ClearSelected();
      }

      /// <summary>
      /// Determines whether the specified item is located within the collection.
      /// </summary>
      /// <returns>true if the specified item is located in the collection; otherwise, false.</returns>
      /// <param name="selectedObject">An object representing the item to locate in the collection. </param>
      public bool Contains(object selectedObject) => this.mobjOwner.SelectedItemsInternal.IndexOf(selectedObject) != -1;

      /// <summary>
      /// Copies the entire collection into an existing array at a specified location within the array.
      /// </summary>
      /// <param name="objDestinationArray">An <see cref="T:System.Array"></see> representing the array to copy the contents of the collection to. </param>
      /// <param name="index">The location within the destination array to copy the items from the collection to. </param>
      public void CopyTo(Array objDestinationArray, int index) => this.mobjOwner.SelectedItemsInternal.CopyTo(objDestinationArray, index);

      /// <summary>
      /// Returns an enumerator that can be used to iterate through the selected item collection.
      /// </summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
      public IEnumerator GetEnumerator() => this.mobjOwner.SelectedItemsInternal.GetEnumerator();

      internal object GetObjectAt(int index) => this.mobjOwner.SelectedItemsInternal[index];

      /// <summary>Gets the selected.</summary>
      /// <param name="index">The index.</param>
      /// <returns></returns>
      internal bool GetSelected(int index) => this.mobjOwner.SelectedItemsInternal.Contains(this.mobjOwner.Items[index]);

      /// <summary>
      /// Returns the index within the collection of the specified item.
      /// </summary>
      /// <returns>The zero-based index of the item in the collection; otherwise, -1.</returns>
      /// <param name="selectedObject">An object representing the item to locate in the collection. </param>
      public int IndexOf(object selectedObject) => this.mobjOwner.SelectedItemsInternal.IndexOf(selectedObject);

      /// <summary>
      /// Removes the specified object from the collection of selected items.
      /// </summary>
      /// <param name="objValue">An object representing the item to remove from the collection.</param>
      public void Remove(object objValue)
      {
        if (this.mobjOwner == null)
          return;
        ListBox.ObjectCollection items = this.mobjOwner.Items;
        if (!(items != null & objValue != null))
          return;
        int num = items.IndexOf(objValue);
        if (num == -1 || !this.GetSelected(num))
          return;
        this.mobjOwner.SetSelected(num, false);
      }

      /// <summary>
      /// Adds an item to the <see cref="T:System.Collections.IList"></see>.
      /// </summary>
      /// <param name="objValue">The <see cref="T:System.Object"></see> to add to the <see cref="T:System.Collections.IList"></see>.</param>
      /// <returns>The position into which the new element was inserted.</returns>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
      int IList.Add(object objValue) => throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));

      /// <summary>
      /// Removes all items from the <see cref="T:System.Collections.IList"></see>.
      /// </summary>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only. </exception>
      void IList.Clear() => throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));

      /// <summary>
      /// Inserts an item to the <see cref="T:System.Collections.IList"></see> at the specified index.
      /// </summary>
      /// <param name="index"></param>
      /// <param name="objValue">The <see cref="T:System.Object"></see> to insert into the <see cref="T:System.Collections.IList"></see>.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
      /// <exception cref="T:System.NullReferenceException">value is null reference in the <see cref="T:System.Collections.IList"></see>.</exception>
      void IList.Insert(int index, object objValue) => throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));

      /// <summary>
      /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"></see>.
      /// </summary>
      /// <param name="objValue">The <see cref="T:System.Object"></see> to remove from the <see cref="T:System.Collections.IList"></see>.</param>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
      void IList.Remove(object objValue) => throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));

      /// <summary>
      /// Removes the <see cref="T:System.Collections.IList"></see> item at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index of the item to remove.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="T:System.Collections.IList"></see>. </exception>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"></see> is read-only.-or- The <see cref="T:System.Collections.IList"></see> has a fixed size. </exception>
      void IList.RemoveAt(int index) => throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));

      /// <summary>Gets the number of items in the collection.</summary>
      /// <returns>The number of items in the collection.</returns>
      public int Count => this.mobjOwner.SelectedItemsInternal.Count;

      /// <summary>Gets a value indicating whether the collection is read-only.</summary>
      /// <returns>true if the collection is read-only; otherwise, false.</returns>
      public bool IsReadOnly => true;

      /// <summary>Gets the item at the specified index within the collection.</summary>
      /// <returns>An object representing the item located at the specified index within the collection.</returns>
      /// <param name="index">The index of the item in the collection to retrieve. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.ListBox.ObjectCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListBox.SelectedObjectCollection"></see> class. </exception>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      [Browsable(false)]
      public object this[int index]
      {
        get => this.mobjOwner.SelectedItemsInternal[index];
        set => throw new NotSupportedException(SR.GetString("ListBoxSelectedObjectCollectionIsReadOnly"));
      }

      bool ICollection.IsSynchronized => false;

      object ICollection.SyncRoot => (object) this;

      bool IList.IsFixedSize => true;
    }
  }
}

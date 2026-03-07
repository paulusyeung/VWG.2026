// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListView
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
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A ListView control.</summary>
  /// <remarks>
  /// The list view control is used to display a list of items.
  /// </remarks>
  [ToolboxItem(true)]
  [DefaultEvent("SelectedIndexChanged")]
  [ToolboxItemCategory("Common Controls")]
  [ToolboxBitmap(typeof (ListView), "ListView_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Designer("Gizmox.WebGUI.Forms.Design.ListViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [Gizmox.WebGUI.Forms.MetadataTag("LV")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ListViewSkin))]
  [ProxyComponent(typeof (ProxyListView))]
  [Serializable]
  public class ListView : Control, IComparer
  {
    /// <summary>
    /// Provides a property reference to WrapColumnHeaders property.
    /// </summary>
    private static SerializableProperty WrapColumnHeadersProperty = SerializableProperty.Register(nameof (WrapColumnHeaders), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to ColumnHeadersHeight property.
    /// </summary>
    private static SerializableProperty ColumnHeadersHeightProperty = SerializableProperty.Register(nameof (ColumnHeadersHeight), typeof (int), typeof (ListView), new SerializablePropertyMetadata((object) -1));
    /// <summary>Provides a property reference to DataMember property.</summary>
    private static SerializableProperty DataMemberProperty = SerializableProperty.Register(nameof (DataMember), typeof (string), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to DataSource property.</summary>
    private static SerializableProperty DataSourceProperty = SerializableProperty.Register(nameof (DataSource), typeof (object), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to AutoGenerateColumns property.
    /// </summary>
    private static SerializableProperty AutoGenerateColumnsProperty = SerializableProperty.Register(nameof (AutoGenerateColumns), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to TotalPages property.</summary>
    private static SerializableProperty TotalPagesProperty = SerializableProperty.Register(nameof (TotalPages), typeof (int), typeof (ListView), new SerializablePropertyMetadata((object) 1));
    /// <summary>
    /// Provides a property reference to ItemsPerPage property.
    /// </summary>
    private static SerializableProperty ItemsPerPageProperty = SerializableProperty.Register(nameof (ItemsPerPage), typeof (int), typeof (ListView), new SerializablePropertyMetadata((object) 20));
    /// <summary>
    /// Provides a property reference to CurrentPage property.
    /// </summary>
    private static SerializableProperty CurrentPageProperty = SerializableProperty.Register(nameof (CurrentPage), typeof (int), typeof (ListView), new SerializablePropertyMetadata((object) 1));
    /// <summary>
    /// Provides a property reference to UseInternalPaging property.
    /// </summary>
    private static SerializableProperty UseInternalPagingProperty = SerializableProperty.Register(nameof (UseInternalPaging), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to InUpdate property.</summary>
    private static SerializableProperty InUpdateProperty = SerializableProperty.Register("InUpdate", typeof (int), typeof (ListView), new SerializablePropertyMetadata((object) 0));
    /// <summary>Provides a property reference to TotalItems property.</summary>
    private static SerializableProperty TotalItemsProperty = SerializableProperty.Register(nameof (TotalItems), typeof (int), typeof (ListView), new SerializablePropertyMetadata((object) 0));
    /// <summary>
    /// Provides a property reference to SortingColumns property.
    /// </summary>
    private static SerializableProperty SortingColumnsProperty = SerializableProperty.Register(nameof (SortingColumns), typeof (ICollection), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to MultiSelect property.
    /// </summary>
    private static SerializableProperty MultiSelectProperty = SerializableProperty.Register(nameof (MultiSelect), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to CheckBoxes property.
    /// </summary>
    private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register(nameof (CheckBoxes), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to CheckOnDoubleClick property.
    /// </summary>
    private static SerializableProperty CheckOnDoubleClickProperty = SerializableProperty.Register(nameof (CheckOnDoubleClick), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to StateImageList property.
    /// </summary>
    private static SerializableProperty StateImageListProperty = SerializableProperty.Register(nameof (StateImageList), typeof (ImageList), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to ImageListSmall property.
    /// </summary>
    private static SerializableProperty ImageListSmallProperty = SerializableProperty.Register("ImageListSmall", typeof (ImageList), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to LargeImageList property.
    /// </summary>
    private static SerializableProperty LargeImageListProperty = SerializableProperty.Register(nameof (LargeImageList), typeof (ImageList), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to Columns property.</summary>
    private static SerializableProperty ColumnsProperty = SerializableProperty.Register(nameof (Columns), typeof (ListView.ColumnHeaderCollection), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to View property.</summary>
    private static SerializableProperty ViewProperty = SerializableProperty.Register(nameof (View), typeof (View), typeof (ListView), new SerializablePropertyMetadata((object) View.Details));
    /// <summary>
    /// Provides a property reference to SelectOnRightClick property.
    /// </summary>
    private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register(nameof (SelectOnRightClick), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to FullRowSelect property.
    /// </summary>
    private static SerializableProperty FullRowSelectProperty = SerializableProperty.Register(nameof (FullRowSelect), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to GridLines property.</summary>
    private static SerializableProperty GridLinesProperty = SerializableProperty.Register(nameof (GridLines), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to ShowItemToolTips property.
    /// </summary>
    private static SerializableProperty ShowItemToolTipsProperty = SerializableProperty.Register(nameof (ShowItemToolTips), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to ShowGroups property.</summary>
    private static SerializableProperty ShowGroupsProperty = SerializableProperty.Register(nameof (ShowGroups), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) true));
    /// <summary>The item sorter of this list</summary>
    private static readonly SerializableProperty ListViewItemSorterProperty = SerializableProperty.Register(nameof (ListViewItemSorter), typeof (IComparer), typeof (ListView), new SerializablePropertyMetadata((object) null));
    /// <summary>The header style</summary>
    private static readonly SerializableProperty ColumnHeaderStyleProperty = SerializableProperty.Register("ColumnHeaderStyle", typeof (ColumnHeaderStyle), typeof (ListView), new SerializablePropertyMetadata((object) ColumnHeaderStyle.Clickable));
    /// <summary>Allow Column Reorder</summary>
    private static readonly SerializableProperty AllowColumnReorderProperty = SerializableProperty.Register(nameof (AllowColumnReorder), typeof (bool), typeof (ListView), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// The list view data binding complete Serializable Event
    /// </summary>
    internal static readonly SerializableEvent EVENT_LISTVIEWDATABINDINGCOMPLETE = SerializableEvent.Register("Event", typeof (Delegate), typeof (ListView));
    /// <summary>The list view data member changed Serializable Event</summary>
    internal static readonly SerializableEvent EVENT_LISTVIEWDATAMEMBERCHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (ListView));
    /// <summary>The list view data source changed Serializable Event</summary>
    internal static readonly SerializableEvent EVENT_LISTVIEWDATASOURCECHANGED = SerializableEvent.Register("Event", typeof (Delegate), typeof (ListView));
    /// <summary>The list view Column Reordered Serializable Event</summary>
    private static readonly SerializableEvent EventColumnReordered = SerializableEvent.Register("Event", typeof (Delegate), typeof (ListView));
    /// <summary>The SelectedIndexChanged event registration.</summary>
    private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof (EventHandler), typeof (ListView));
    /// <summary>The ItemCheck event registration.</summary>
    private static readonly SerializableEvent ItemCheckEvent = SerializableEvent.Register("ItemCheck", typeof (ItemCheckHandler), typeof (ListView));
    /// <summary>The ColumnWidthChanged event registration.</summary>
    private static readonly SerializableEvent ColumnWidthChangedEvent = SerializableEvent.Register("ColumnWidthChanged", typeof (ColumnWidthChangedEventHandler), typeof (ListView));
    /// <summary>The AfterLabelEdit event registration.</summary>
    internal static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof (LabelEditEventHandler), typeof (ListView));
    /// <summary>The BeforeLabelEdit event registration.</summary>
    private static readonly SerializableEvent BeforeLabelEditEvent = SerializableEvent.Register("BeforeLabelEdit", typeof (LabelEditEventHandler), typeof (ListView));
    /// <summary>The listview items collection</summary>
    [NonSerialized]
    private ListView.ListViewItemCollection mobjItems;
    /// <summary>The listview columns collection</summary>
    [NonSerialized]
    private ListView.ColumnHeaderCollection mobjColumns;
    /// <summary>the original item sorting</summary>
    [NonSerialized]
    private List<ListViewItem> mobjOriginalItemSorting;
    /// <summary>The group collection</summary>
    [NonSerialized]
    private ListViewGroupCollection mobjGroups;
    /// <summary>The column headers resizing mide</summary>
    private static readonly SerializableProperty HeaderAutoResizeStyleProperty = SerializableProperty.Register("HeaderAutoResizeStyle", typeof (ColumnHeaderAutoResizeStyle), typeof (ListView), new SerializablePropertyMetadata((object) ColumnHeaderAutoResizeStyle.None));

    /// <summary>Gets the hanlder for the SelectedIndexChanged event.</summary>
    private EventHandler SelectedIndexChangedHandler => (EventHandler) this.GetHandler(ListView.SelectedIndexChangedEvent);

    /// <summary>Occurs when the SelectedIndex property has changed.</summary>
    public event EventHandler SelectedIndexChanged
    {
      add => this.AddCriticalHandler(ListView.SelectedIndexChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ListView.SelectedIndexChangedEvent, (Delegate) value);
    }

    /// <summary>Columns where updated by the user</summary>
    public event EventHandler ColumnUpdate;

    /// <summary>Gets the hanlder for the ItemCheck event.</summary>
    private ItemCheckHandler ItemCheckHandler => (ItemCheckHandler) this.GetHandler(ListView.ItemCheckEvent);

    /// <summary>Occurs when the checked state of an item changes.</summary>
    public event ItemCheckHandler ItemCheck
    {
      add => this.AddCriticalHandler(ListView.ItemCheckEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ListView.ItemCheckEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client paging changed].</summary>
    [SRDescription("Occurs when control navigated to another page in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientPagingChanged
    {
      add => this.AddClientHandler("Navigate", value);
      remove => this.RemoveClientHandler("Navigate", value);
    }

    /// <summary>Occurs when [client selected index changed].</summary>
    [SRDescription("Occurs when control's selection changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientSelectedIndexChanged
    {
      add => this.AddClientHandler("SelectionChange", value);
      remove => this.RemoveClientHandler("SelectionChange", value);
    }

    /// <summary>Occurs when [client item check].</summary>
    [SRDescription("Occurs when control's item checked state changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientItemCheck
    {
      add => this.AddClientHandler("CheckedChange", value);
      remove => this.RemoveClientHandler("CheckedChange", value);
    }

    /// <summary>Occurs when [client column reordered].</summary>
    [SRDescription("Occurs when control's columns reordered in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientColumnReordered
    {
      add => this.AddClientHandler("ColumnsReorder", value);
      remove => this.RemoveClientHandler("ColumnsReorder", value);
    }

    /// <summary>Occurs when [client column reordered].</summary>
    [SRDescription("Occurs when control's column width changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientColumnWidthChanged
    {
      add => this.AddClientHandler("ChangeColumnWidth", value);
      remove => this.RemoveClientHandler("ChangeColumnWidth", value);
    }

    /// <summary>Occurs when an item is activated.</summary>
    public event EventHandler ItemActivate;

    /// <summary>Occurs when the paging params have changed.</summary>
    public event EventHandler PagingChanged;

    /// <summary>
    /// 
    /// </summary>
    public event ColumnClickEventHandler ColumnClick;

    /// <summary>Gets the hanlder for the ColumnWidthChanged event.</summary>
    private ColumnWidthChangedEventHandler ColumnWidthChangedHandler => (ColumnWidthChangedEventHandler) this.GetHandler(ListView.ColumnWidthChangedEvent);

    /// <summary>
    /// Occurs when the column width has changed.
    /// /// </summary>
    public event ColumnWidthChangedEventHandler ColumnWidthChanged
    {
      add => this.AddCriticalHandler(ListView.ColumnWidthChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ListView.ColumnWidthChangedEvent, (Delegate) value);
    }

    /// <summary>
    /// Occurs when [column width changing].
    /// Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).
    /// </summary>
    [Obsolete("Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).")]
    public event ColumnWidthChangedEventHandler ColumnWidthChanging;

    /// <summary>
    /// Occurs when the item is formatting.
    /// will not occurs on sub items when UseItemStyleForSubItems is true
    /// </summary>
    [SRDescription("ListView_ItemFormattingDescr")]
    [SRCategory("CatDisplay")]
    public event ListViewItemFormattingEventHandler ItemFormatting;

    /// <summary>Occurs when [item binding].</summary>
    [SRDescription("ListView_ItemBindingDescr")]
    [SRCategory("CatDisplay")]
    public event ListViewItemBindingEventHandler ItemBinding;

    /// <summary>Occurs when [data binding complete].</summary>
    [SRDescription("ListView_DataBindingCompleteDescr")]
    [SRCategory("CatData")]
    public event ListViewBindingCompleteEventHandler DataBindingComplete;

    /// <summary>Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.DataMember"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListViewDataMemberChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler DataMemberChanged;

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.DataSource"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListViewDataSourceChangedDescr")]
    [SRCategory("CatPropertyChanged")]
    public event EventHandler DataSourceChanged;

    /// <summary>Occurs when [column reordered].</summary>
    [SRDescription("ListViewColumnReorderedDscr")]
    [SRCategory("CatPropertyChanged")]
    public event ColumnReorderedEventHandler ColumnReordered
    {
      add => this.AddHandler(ListView.EventColumnReordered, (Delegate) value);
      remove => this.RemoveHandler(ListView.EventColumnReordered, (Delegate) value);
    }

    /// <summary>Occurs after the list item label text is edited.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("ListViewAfterLabelEditDescr")]
    public event LabelEditEventHandler AfterLabelEdit
    {
      add => this.AddCriticalHandler(ListView.AfterLabelEditEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ListView.AfterLabelEditEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterLabelEdit event.</summary>
    private LabelEditEventHandler AfterLabelEditHandler => (LabelEditEventHandler) this.GetHandler(ListView.AfterLabelEditEvent);

    /// <summary>Occurs before the tree node label text is edited.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event LabelEditEventHandler BeforeLabelEdit
    {
      add => this.AddHandler(ListView.BeforeLabelEditEvent, (Delegate) value);
      remove => this.RemoveHandler(ListView.BeforeLabelEditEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeLabelEdit event.</summary>
    private LabelEditEventHandler BeforeLabelEditHandler => (LabelEditEventHandler) this.GetHandler(ListView.BeforeLabelEditEvent);

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView" /> instance.
    /// </summary>
    public ListView()
    {
      this.SetStyle(ControlStyles.UserPaint, false);
      this.SetStyle(ControlStyles.StandardClick, false);
      this.SetStyle(ControlStyles.UseTextForAccessibility, false);
      this.SetState(Control.ControlState.AutoScroll, true);
      this.mobjColumns = new ListView.ColumnHeaderCollection(this);
      this.mobjItems = new ListView.ListViewItemCollection(this);
      this.mobjOriginalItemSorting = new List<ListViewItem>();
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow column reorder].
    /// </summary>
    /// <value><c>true</c> if [allow column reorder]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    [SRDescription("ListViewAllowColumnReorderDescr")]
    [SRCategory("CatBehavior")]
    public bool AllowColumnReorder
    {
      get => this.GetValue<bool>(ListView.AllowColumnReorderProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.AllowColumnReorderProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets a value indicating whether a scroll bar is added to the control when there is not enough room to display all items.</summary>
    /// <returns>true if scroll bars are added to the control when necessary to allow the user to see all the items; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(true)]
    [SRDescription("ListViewScrollableDescr")]
    [SRCategory("CatBehavior")]
    public bool Scrollable
    {
      get => this.GetState(Control.ControlState.AutoScroll);
      set
      {
        if (!this.SetStateWithCheck(Control.ControlState.AutoScroll, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (Scrollable));
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether ToolTips are shown for the ListViewItem objects contained in the ListView.
    /// </summary>
    /// <remarks>ShowItemToolTips property must be set true for tooltips to appear.</remarks>
    [DefaultValue(false)]
    public bool ShowItemToolTips
    {
      get => this.GetValue<bool>(ListView.ShowItemToolTipsProperty);
      set => this.SetValue<bool>(ListView.ShowItemToolTipsProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether items are displayed in groups.</summary>
    /// <returns>true to display items in groups; otherwise, false. The default value is true.</returns>
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    [SRDescription("ListViewShowGroupsDescr")]
    public bool ShowGroups
    {
      get => this.GetValue<bool>(ListView.ShowGroupsProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.ShowGroupsProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the sorting.</summary>
    /// <value>The sorting.</value>
    [SRCategory("CatBehavior")]
    [DefaultValue(SortOrder.None)]
    [SRDescription("ListViewSortingDescr")]
    public SortOrder Sorting
    {
      get => this.Columns.Count > 0 ? this.Columns[0].SortOrder : SortOrder.None;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (SortOrder));
        if (this.Columns.Count <= 0)
          return;
        ColumnHeader column = this.Columns[0];
        if (column == null || column.SortOrder == value)
          return;
        column.SortOrder = value;
        if (value == SortOrder.None)
          return;
        this.Sort();
      }
    }

    /// <summary>Gets the item in the control that currently has focus.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGui.Forms.ListViewItem"></see> that represents the item that has focus, or null if no item has the focus in the <see cref="T:Gizmox.WebGui.Forms.ListView"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ListViewFocusedItemDescr")]
    [SRCategory("CatAppearance")]
    public ListViewItem FocusedItem
    {
      get => (ListViewItem) null;
      set
      {
      }
    }

    /// <summary>Set/Gets the activation type (Not implemented).</summary>
    /// <value></value>
    [DefaultValue(ItemActivation.Standard)]
    public ItemActivation Activation
    {
      get => ItemActivation.Standard;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether grid lines exists.
    /// </summary>
    /// <value><c>true</c> if has grid lines; otherwise, <c>false</c>.</value>
    [Browsable(true)]
    [SRDescription("ListViewGridLinesDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(false)]
    public bool GridLines
    {
      get
      {
        bool blnFound;
        bool flag = this.GetValue<bool>(ListView.GridLinesProperty, out blnFound);
        return !blnFound ? ((ListViewSkin) this.Skin).ShowGridLines : flag;
      }
      set
      {
        if (!this.SetValue<bool>(ListView.GridLinesProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [hide selection].
    /// </summary>
    /// <value><c>true</c> if [hide selection]; otherwise, <c>false</c>.</value>
    [Browsable(true)]
    [DefaultValue(false)]
    public bool HideSelection
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets the list view item sorter internal value.</summary>
    /// <value>The list view item sorter internal value.</value>
    private IComparer ListViewItemSorterInternal
    {
      get
      {
        IComparer listViewItemSorter = this.ListViewItemSorter;
        if (listViewItemSorter != null)
          return listViewItemSorter;
        return this.DataSource != null ? (IComparer) this : (IComparer) new Gizmox.WebGUI.Forms.ListViewItemSorter(this);
      }
    }

    /// <summary>Gets or sets the list view item sorter.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IComparer ListViewItemSorter
    {
      get => this.GetValue<IComparer>(ListView.ListViewItemSorterProperty);
      set => this.SetValue<IComparer>(ListView.ListViewItemSorterProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether full row select is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if full row select is enabled; otherwise, <c>false</c>.
    /// </value>
    [Browsable(true)]
    [DefaultValue(false)]
    public bool FullRowSelect
    {
      get => this.GetValue<bool>(ListView.FullRowSelectProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.FullRowSelectProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the list view mode.</summary>
    /// <value></value>
    [Browsable(true)]
    [DefaultValue(View.Details)]
    public View View
    {
      get => this.GetValue<View>(ListView.ViewProperty);
      set
      {
        if (!this.SetValue<View>(ListView.ViewProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (View));
      }
    }

    /// <summary>
    /// Gets the list of tags that client events are propogated to.
    /// </summary>
    /// <value>The client event propogated tags.</value>
    protected override string ClientEventsPropogationTags => string.Format("{0},{1}", (object) "R", (object) "C");

    /// <summary>
    ///  Gets the collection of columns contained within the listview.
    /// </summary>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [MergableProperty(false)]
    public ListView.ColumnHeaderCollection Columns => this.mobjColumns;

    /// <summary>Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> objects assigned to the control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> that contains all the groups in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ListViewGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [MergableProperty(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [SRDescription("ListViewGroupsDescr")]
    [WebEditor(typeof (ListViewGroupCollectionEditor), typeof (WebUITypeEditor))]
    public ListViewGroupCollection Groups
    {
      get
      {
        if (this.mobjGroups == null)
          this.mobjGroups = new ListViewGroupCollection(this);
        return this.mobjGroups;
      }
    }

    /// <summary>
    ///  Gets the collection of items contained within the listview.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ListView.ListViewItemCollection Items => this.mobjItems;

    /// <summary>Gets or sets the header style.</summary>
    /// <value></value>
    [Browsable(true)]
    [DefaultValue(ColumnHeaderStyle.Clickable)]
    public ColumnHeaderStyle HeaderStyle
    {
      get => this.GetValue<ColumnHeaderStyle>(ListView.ColumnHeaderStyleProperty);
      set
      {
        if (!this.SetValue<ColumnHeaderStyle>(ListView.ColumnHeaderStyleProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as large icons in the control.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.LargeIcon"></see>. The default is null.</returns>
    /// <filterpriority>2</filterpriority>
    [DefaultValue(null)]
    [SRDescription("ListViewLargeImageListDescr")]
    [SRCategory("CatBehavior")]
    public ImageList LargeImageList
    {
      get => this.GetValue<ImageList>(ListView.LargeImageListProperty);
      set
      {
        if (!this.SetValue<ImageList>(ListView.LargeImageListProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
    /// <filterpriority>2</filterpriority>
    [SRDescription("ListViewSmallImageListDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(null)]
    public ImageList SmallImageList
    {
      get => this.GetValue<ImageList>(ListView.ImageListSmallProperty);
      set
      {
        if (!this.SetValue<ImageList>(ListView.ImageListSmallProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> associated with application-defined states in the control.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains a set of state images that can be used to indicate an application-defined state of an item. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ListViewStateImageListDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(null)]
    public ImageList StateImageList
    {
      get => this.GetValue<ImageList>(ListView.StateImageListProperty);
      set
      {
        if (!this.SetValue<ImageList>(ListView.StateImageListProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether a check box appears next to each item in the control.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(false)]
    public bool CheckBoxes
    {
      get => this.GetValue<bool>(ListView.CheckBoxesProperty);
      set
      {
        if (this.SetValue<bool>(ListView.CheckBoxesProperty, value))
          this.Update();
        this.FireObservableItemPropertyChanged(nameof (CheckBoxes));
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to check CheckBoxes on double click.
    /// </summary>
    /// <value>
    /// <c>true</c> if check CheckBoxes on double click; otherwise, <c>false</c>.
    /// </value>
    [Browsable(true)]
    [DefaultValue(true)]
    public bool CheckOnDoubleClick
    {
      get => this.GetValue<bool>(ListView.CheckOnDoubleClickProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.CheckOnDoubleClickProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether multiple items can be selected.
    /// </summary>
    [Browsable(true)]
    [DefaultValue(true)]
    public bool MultiSelect
    {
      get => this.GetValue<bool>(ListView.MultiSelectProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.MultiSelectProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Resets the current sorting columns collection to enforce recreation of the collection
    /// </summary>
    internal void ResetSortingColumns() => this.SortingColumnsInternal = (ICollection) null;

    /// <summary>A collection of columns participating in sorting</summary>
    internal ICollection SortingColumnsInternal
    {
      get => this.GetValue<ICollection>(ListView.SortingColumnsProperty);
      set => this.SetValue<ICollection>(ListView.SortingColumnsProperty, value);
    }

    /// <summary>A collection of columns participating in sorting</summary>
    internal ICollection SortingColumns
    {
      get
      {
        if (this.SortingColumnsInternal == null)
          this.SortingColumnsInternal = new ColumnHeaderSortingData(this).SortingColumns;
        return this.SortingColumnsInternal;
      }
    }

    private CurrencyManager CurrencyManagerInternal
    {
      get
      {
        object dataSource = this.DataSource;
        string dataMember = this.DataMember;
        if (dataSource == null)
          return (CurrencyManager) null;
        return !string.IsNullOrEmpty(dataMember) ? this.BindingContext[dataSource, dataMember] as CurrencyManager : this.BindingContext[dataSource] as CurrencyManager;
      }
    }

    /// <summary>Gets the currently selected item index.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectedIndex
    {
      get
      {
        ListView.ListViewItemCollection items = this.Items;
        int selectedIndex = 0;
        foreach (ListViewItem listViewItem in items)
        {
          if (listViewItem.Selected)
            return selectedIndex;
          ++selectedIndex;
        }
        return -1;
      }
      set
      {
        bool flag = false;
        int num = 0;
        foreach (ListViewItem listViewItem in this.Items)
        {
          if (value == num)
          {
            if (!listViewItem.InternalSelected)
            {
              listViewItem.InternalSelected = true;
              flag = true;
              listViewItem.Update();
            }
          }
          else if (listViewItem.InternalSelected)
          {
            listViewItem.InternalSelected = false;
            flag = true;
            listViewItem.Update();
          }
          ++num;
        }
        if (!flag || this.SelectedIndexChangedHandler == null)
          return;
        this.OnSelectedIndexChanged(EventArgs.Empty);
      }
    }

    /// <summary>Gets the selected indices.</summary>
    /// <value></value>
    [Browsable(false)]
    public ArrayList SelectedIndices
    {
      get
      {
        ArrayList selectedIndices = new ArrayList();
        int num = 0;
        foreach (ListViewItem listViewItem in this.Items)
        {
          if (listViewItem.Selected)
            selectedIndices.Add((object) num);
          ++num;
        }
        return selectedIndices;
      }
    }

    /// <summary>Gets the currently selected item index.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ListViewItem SelectedItem
    {
      get
      {
        int selectedIndex = this.SelectedIndex;
        return selectedIndex != -1 ? this.Items[selectedIndex] : (ListViewItem) null;
      }
      set => this.SelectedIndex = this.Items.IndexOf(value);
    }

    /// <summary>Gets or sets the height of the column headers.</summary>
    /// <value>The height of the column headers.</value>
    [Localizable(false)]
    [DefaultValue(-1)]
    [SRCategory("CatAppearance")]
    [SRDescription("ListView_ColumnHeadersHeightDescr")]
    public int ColumnHeadersHeight
    {
      get => this.GetValue<int>(ListView.ColumnHeadersHeightProperty);
      set
      {
        if (!this.SetValue<int>(ListView.ColumnHeadersHeightProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [wrap column headers].
    /// </summary>
    /// <value><c>true</c> if [wrap column headers]; otherwise, <c>false</c>.</value>
    [Localizable(false)]
    [DefaultValue(false)]
    [SRCategory("CatAppearance")]
    [SRDescription("ListView_WrapColumnHeadersDescr")]
    public bool WrapColumnHeaders
    {
      get => this.GetValue<bool>(ListView.WrapColumnHeadersProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.WrapColumnHeadersProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets the selected items.</summary>
    /// <value></value>
    [Browsable(false)]
    public ListView.SelectedListViewItemCollection SelectedItems => new ListView.SelectedListViewItemCollection(this);

    /// <summary>Gets the checked indices.</summary>
    /// <value></value>
    [Browsable(false)]
    public ArrayList CheckedIndices
    {
      get
      {
        ArrayList checkedIndices = new ArrayList();
        int num = 0;
        foreach (ListViewItem listViewItem in this.Items)
        {
          if (listViewItem.Checked)
            checkedIndices.Add((object) num);
          ++num;
        }
        return checkedIndices;
      }
    }

    /// <summary>Gets the checked items.</summary>
    /// <value></value>
    [Browsable(false)]
    public ArrayList CheckedItems
    {
      get
      {
        ArrayList checkedItems = new ArrayList();
        foreach (ListViewItem listViewItem in this.Items)
        {
          if (listViewItem.Checked)
            checkedItems.Add((object) listViewItem);
        }
        return checkedItems;
      }
    }

    /// <summary>Indicates whether the list view is in update mode.</summary>
    internal int InUpadte
    {
      get => this.GetValue<int>(ListView.InUpdateProperty);
      private set => this.SetValue<int>(ListView.InUpdateProperty, value);
    }

    /// <summary>
    /// 
    /// </summary>
    protected override bool IsDelayedDrawing => true;

    /// <summary>Uses internal paging algorithem</summary>
    [DefaultValue(false)]
    public bool UseInternalPaging
    {
      get => this.GetValue<bool>(ListView.UseInternalPagingProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.UseInternalPagingProperty, value))
          return;
        this.Update();
      }
    }

    private int CurrentPageInternal
    {
      get => this.GetValue<int>(ListView.CurrentPageProperty);
      set => this.SetValue<int>(ListView.CurrentPageProperty, value);
    }

    /// <summary>Gets or sets the current page.</summary>
    /// <value></value>
    [DefaultValue(1)]
    public int CurrentPage
    {
      get => this.CurrentPageInternal;
      set
      {
        if (value <= -1 || this.TotalPages < value)
          throw new ArgumentOutOfRangeException(nameof (CurrentPage));
        if (this.CurrentPageInternal == value)
          return;
        this.CurrentPageInternal = value;
        if (!this.UseInternalPaging)
          return;
        this.ScrollTop = 0;
        this.Update();
      }
    }

    /// <summary>Gets or sets the items per page.</summary>
    /// <value>The items per page.</value>
    [DefaultValue(20)]
    public int ItemsPerPage
    {
      get => this.GetValue<int>(ListView.ItemsPerPageProperty);
      set
      {
        if (!this.SetValue<int>(ListView.ItemsPerPageProperty, value))
          return;
        this.ClearPaging();
        this.Update();
      }
    }

    private int TotalPagesInternal
    {
      get => this.GetValue<int>(ListView.TotalPagesProperty);
      set => this.SetValue<int>(ListView.TotalPagesProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [select on right click].
    /// </summary>
    /// <value><c>true</c> if [select on right click]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public bool SelectOnRightClick
    {
      get => this.GetValue<bool>(ListView.SelectOnRightClickProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.SelectOnRightClickProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the total pages.</summary>
    /// <value></value>
    [DefaultValue(1)]
    public int TotalPages
    {
      get
      {
        if (!this.UseInternalPaging)
          return this.TotalPagesInternal;
        int totalPages = (int) Math.Ceiling((double) this.TotalItems / (double) this.ItemsPerPage);
        if (totalPages < 1)
          totalPages = 1;
        return totalPages;
      }
      set
      {
        if (this.UseInternalPaging)
          return;
        if (value <= -1)
          throw new ArgumentOutOfRangeException(nameof (TotalPages));
        if (this.TotalPagesInternal == value)
          return;
        this.TotalPagesInternal = value;
        this.Update();
      }
    }

    /// <summary>Gets or sets the total items.</summary>
    /// <value></value>
    [DefaultValue(0)]
    public int TotalItems
    {
      get => !this.UseInternalPaging ? this.GetValue<int>(ListView.TotalItemsProperty) : this.Items.Count;
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (TotalItems));
        if (!this.SetValue<int>(ListView.TotalItemsProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
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

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(true)]
    public bool UseCompatibleStateImageBehavior
    {
      get => true;
      set
      {
      }
    }

    /// <summary>Gets or sets the size of the tiles shown in tile view.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that contains the new tile size.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ListViewTileSizeDescr")]
    [SRCategory("CatAppearance")]
    public Size TileSize
    {
      get => Size.Empty;
      set
      {
      }
    }

    /// <summary>Gets or sets the alignment of items in the control.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGui.Forms.ListViewAlignment"></see> values. The default is <see cref="F:Gizmox.WebGui.Forms.ListViewAlignment.Top"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is not one of the <see cref="T:Gizmox.WebGui.Forms.ListViewAlignment"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [SRDescription("ListViewAlignmentDescr")]
    [DefaultValue(ListViewAlignment.Top)]
    [SRCategory("CatBehavior")]
    public ListViewAlignment Alignment
    {
      get => ListViewAlignment.Top;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the label text of the list items can be edited.</summary>
    /// <returns>true if the label text of the list items can be edited; otherwise, false. The default is false.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ListViewLabelEditDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool LabelEdit
    {
      get => this.GetState(Component.ComponentState.ReadOnly);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.ReadOnly, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ListViewWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ListViewWinFormsCompatibility;

    /// <summary>Renders the current control.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RegisterComponent((IRegisteredComponent) this);
      this.RegisterBatch((ICollection) this.Columns);
      this.RegisterBatch((ICollection) this.Items);
      objWriter.WriteAttributeString("VW", this.View.ToString());
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
      if (!this.Scrollable)
        objWriter.WriteAttributeString("SB", "0");
      if (this.FullRowSelect)
        objWriter.WriteAttributeString("FRS", "1");
      ImageList largeImageList = this.LargeImageList;
      ImageList smallImageList = this.SmallImageList;
      int num;
      if (largeImageList != null && this.View == View.LargeIcon)
      {
        objWriter.WriteAttributeString("LIW", largeImageList.ImageSize.Width.ToString());
        IResponseWriter responseWriter = objWriter;
        num = largeImageList.ImageSize.Height;
        string strValue = num.ToString();
        responseWriter.WriteAttributeString("LIH", strValue);
      }
      else if (smallImageList != null && this.View == View.SmallIcon)
      {
        objWriter.WriteAttributeString("IW", smallImageList.ImageSize.Width.ToString());
        IResponseWriter responseWriter = objWriter;
        num = smallImageList.ImageSize.Height;
        string strValue = num.ToString();
        responseWriter.WriteAttributeString("IH", strValue);
      }
      IResponseWriter responseWriter1 = objWriter;
      num = this.CurrentPage;
      string strValue1 = num.ToString();
      responseWriter1.WriteAttributeString("CP", strValue1);
      IResponseWriter responseWriter2 = objWriter;
      num = this.TotalPages;
      string strValue2 = num.ToString();
      responseWriter2.WriteAttributeString("TOP", strValue2);
      IResponseWriter responseWriter3 = objWriter;
      num = Convert.ToInt32((object) this.HeaderStyle);
      string strValue3 = num.ToString();
      responseWriter3.WriteAttributeString("HDS", strValue3);
      if (this.CheckBoxes)
        objWriter.WriteAttributeString("CB", "1");
      if (this.CheckOnDoubleClick)
        objWriter.WriteAttributeString("CODC", "1");
      if (this.MultiSelect)
        objWriter.WriteAttributeString("MU", "1");
      if (this.GridLines)
        objWriter.WriteAttributeString("GL", "1");
      this.RenderControls(objContext, objWriter, 0L);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderAllowColumnReorder(objWriter, false);
      this.RenderSelectOnRightClick(objWriter, false);
      this.RenderEditingInformation(objWriter, false);
      objWriter.WriteAttributeString("IMH", this.GetPreferdControlItemHeight().ToString());
      objWriter.WriteAttributeString("LVSGLOER", this.WinFormsCompatibility.ShowGridLinesOnEmptyRows ? "1" : "0");
      if (this.View != View.Details)
        return;
      int columnHeaderHeight = this.GetColumnHeaderHeight();
      objWriter.WriteAttributeString("HH", columnHeaderHeight.ToString());
      if (!this.WrapColumnHeaders)
        return;
      objWriter.WriteAttributeString("WC", "1");
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnFullRedraw)
    {
      this.RenderContent(objContext, objWriter, lngRequestID, blnFullRedraw);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RenderContent(objContext, objWriter, lngRequestID, true);
    }

    /// <summary>Pre-render control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      this.ProcessVisibleItemsAndGroups((ListView.ItemProcessor) new ListView.ItemPreRenderingProcessor(this), false);
      base.PreRenderControl(objContext, lngRequestID);
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnFullRedraw">if set to <c>true</c> full redraw.</param>
    private void RenderContent(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnFullRedraw)
    {
      foreach (ColumnHeader sortedColumn in (IEnumerable) this.Columns.SortedColumns)
        sortedColumn.RenderColumn(objContext, objWriter, lngRequestID);
      this.ProcessVisibleItemsAndGroups((ListView.ItemProcessor) new ListView.ItemRenderingProcessor(this, objContext, objWriter, lngRequestID, blnFullRedraw), this.IsDirty(lngRequestID));
    }

    /// <summary>Processes the visible items and groups.</summary>
    /// <param name="blnGroupdShouldBeRendered">
    /// A flag indicating if current group should be rendered
    /// this value is by default true only if is in dirty mode
    /// otherwise we do not need to render groups
    /// </param>
    /// <returns></returns>
    private void ProcessVisibleItemsAndGroups(
      ListView.ItemProcessor objProcessor,
      bool blnGroupsShouldBeRendered)
    {
      if (!objProcessor.IsProcessingStillNeeded)
        return;
      int itemsPerPage = this.ItemsPerPage;
      int num1 = 0;
      int num2 = (this.CurrentPageInternal - 1) * itemsPerPage;
      int num3 = num2 + itemsPerPage;
      ListViewGroupCollection groupsToRender = this.GetGroupsToRender();
      if (groupsToRender == null)
      {
        foreach (ListViewItem objItem in this.Items)
        {
          if (!objProcessor.IsProcessingStillNeeded)
            break;
          if (this.UseInternalPaging)
          {
            if (num1 >= num2)
            {
              if (num1 >= num3)
                break;
              objProcessor.ProcessItem(objItem);
            }
          }
          else
            objProcessor.ProcessItem(objItem);
          ++num1;
        }
      }
      else
      {
        bool flag1 = blnGroupsShouldBeRendered;
        foreach (ListViewItem objItem in this.Items)
        {
          if (!objProcessor.IsProcessingStillNeeded)
            return;
          if (objItem.Group == null || !this.Groups.Contains(objItem.Group))
          {
            if (this.UseInternalPaging)
            {
              if (num1 >= num2)
              {
                if (num1 < num3)
                {
                  if (flag1)
                  {
                    objProcessor.ProcessGroup((ListViewGroup) null);
                    flag1 = false;
                  }
                  objProcessor.ProcessItem(objItem);
                }
                else
                  break;
              }
            }
            else
            {
              if (flag1)
              {
                objProcessor.ProcessGroup((ListViewGroup) null);
                flag1 = false;
              }
              objProcessor.ProcessItem(objItem);
            }
            ++num1;
          }
        }
        foreach (ListViewGroup objGroup in groupsToRender)
        {
          bool flag2 = blnGroupsShouldBeRendered;
          foreach (ListViewItem objItem in this.Items)
          {
            if (objItem.Group == objGroup)
            {
              if (this.UseInternalPaging)
              {
                if (num1 >= num2)
                {
                  if (num1 < num3)
                  {
                    if (flag2)
                    {
                      objProcessor.ProcessGroup(objItem.Group);
                      flag2 = false;
                    }
                    objProcessor.ProcessItem(objItem);
                  }
                  else
                    break;
                }
              }
              else
              {
                if (flag2)
                {
                  objProcessor.ProcessGroup(objGroup);
                  flag2 = false;
                }
                objProcessor.ProcessItem(objItem);
              }
              ++num1;
            }
          }
        }
      }
    }

    /// <summary>Renders the group.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objListViewGroup">The list view group.</param>
    private void RenderGroup(
      IContext objContext,
      IResponseWriter objWriter,
      ListViewGroup objListViewGroup,
      ListView.ItemRenderingProcessor objProcessor)
    {
      objWriter.WriteStartElement("G");
      if (objListViewGroup != null)
        objWriter.WriteAttributeText("TX", objListViewGroup.Header, TextFilter.NewLine | TextFilter.CarriageReturn);
      else
        objWriter.WriteAttributeString("TX", "Default");
      objWriter.WriteEndElement();
    }

    /// <summary>Gets a collection of groups if should render groups.</summary>
    /// <returns></returns>
    private ListViewGroupCollection GetGroupsToRender() => this.ShowGroups && this.mobjGroups != null && this.mobjGroups.Count > 0 ? this.mobjGroups : (ListViewGroupCollection) null;

    /// <summary>An abstract param attribute rendering</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      objWriter.WriteAttributeString("CB", this.CheckBoxes ? "1" : "0");
      objWriter.WriteAttributeString("CODC", this.CheckOnDoubleClick ? "1" : "0");
      objWriter.WriteAttributeString("MU", this.MultiSelect ? "1" : "0");
      objWriter.WriteAttributeString("GL", this.GridLines ? "1" : "0");
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      this.RenderEditingInformation(objWriter, true);
      this.RenderAllowColumnReorder(objWriter, true);
      this.RenderSelectOnRightClick(objWriter, true);
    }

    /// <summary>Renders the editing information.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [force render].</param>
    protected void RenderEditingInformation(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!(this.LabelEdit | blnForceRender))
        return;
      objWriter.WriteAttributeString("LE", this.LabelEdit ? "1" : "0");
    }

    /// <summary>Renders the select on right click.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.SelectOnRightClick)
      {
        objWriter.WriteAttributeString("SOR", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SOR", "0");
      }
    }

    /// <summary>Renders the allow column reorder.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> force render.</param>
    private void RenderAllowColumnReorder(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (this.AllowColumnReorder)
      {
        objWriter.WriteAttributeString("AOC", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("AOC", "0");
      }
    }

    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objProposedSize">The proposed size.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize) => objProposedSize;

    /// <summary>
    /// Layout the internal controls to reflect parent changes
    /// </summary>
    /// <param name="objEventArgs">The layout arguments.</param>
    /// <param name="objNewSize">The new parent size.</param>
    /// <param name="objOldSize">The old parent size.</param>
    protected override void OnLayoutControls(
      LayoutEventArgs objEventArgs,
      ref Size objNewSize,
      ref Size objOldSize)
    {
    }

    /// <summary>Gets the height of the preferd item font.</summary>
    /// <returns></returns>
    internal int GetPreferdItemFontHeight(bool blnIsHeader)
    {
      if (!(this.Skin is ListViewSkin skin))
        return 0;
      PaddingValue paddingValue = !blnIsHeader ? skin.CellNormalStyle.Padding : skin.HeaderNormalStyle.Padding;
      int num = 0;
      if (paddingValue != null)
        num = paddingValue.Vertical + (blnIsHeader ? 7 : 0);
      return Math.Max(skin.CheckBoxButtonHeight, CommonUtils.GetFontHeight(this.GetProxyPropertyValue<Font>("Font", this.Font))) + num;
    }

    /// <summary>
    /// Raises the <see cref="E:ItemFormatting" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs" /> instance containing the event data.</param>
    protected virtual void OnItemFormatting(ListViewItemFormattingEventArgs e)
    {
      ListViewItemFormattingEventHandler itemFormatting = this.ItemFormatting;
      if (itemFormatting == null)
        return;
      itemFormatting((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ItemBinding" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ListViewItemBindingEventArgs" /> instance containing the event data.</param>
    private void OnItemBinding(ListViewItemBindingEventArgs e)
    {
      ListViewItemBindingEventHandler itemBinding = this.ItemBinding;
      if (itemBinding == null)
        return;
      itemBinding((object) this, e);
    }

    internal void OnItemFormatting(
      int intItemIndex,
      int intColumnIndex,
      ListViewItem.ListViewSubItem objSubItem)
    {
      this.OnItemFormatting(new ListViewItemFormattingEventArgs(intItemIndex, intColumnIndex, objSubItem));
    }

    /// <summary>Fires an event.</summary>
    /// <param name="blnValid"></param>
    internal void FireUpdateColumns(bool blnValid)
    {
      EventHandler columnUpdate = this.ColumnUpdate;
      if (columnUpdate == null)
        return;
      columnUpdate((object) this, new EventArgs());
    }

    /// <summary>Fires the selected index changed.</summary>
    /// <param name="objListViewItem">The obj list view item.</param>
    internal void FireSelectedIndexChanged(ListViewItem objListViewItem) => this.OnSelectedIndexChanged((EventArgs) new ListViewItemEventArgs(objListViewItem));

    /// <summary>
    /// Raises the <see cref="E:SelectedIndexChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnSelectedIndexChanged(EventArgs e)
    {
      CurrencyManager currencyManagerInternal = this.CurrencyManagerInternal;
      EventHandler indexChangedHandler = this.SelectedIndexChangedHandler;
      if (indexChangedHandler != null)
        indexChangedHandler((object) this, e);
      if (currencyManagerInternal == null || this.mobjOriginalItemSorting == null || this.SelectedItem == null)
        return;
      currencyManagerInternal.Position = this.mobjOriginalItemSorting.IndexOf(this.SelectedItem);
    }

    /// <summary>Internals the column width changed.</summary>
    /// <param name="ColumnIndex">Index of the column.</param>
    internal void InternalColumnWidthChanged(int ColumnIndex)
    {
      ColumnWidthChangedEventArgs e = new ColumnWidthChangedEventArgs(ColumnIndex);
      this.OnColumnWidthChanging(e);
      this.OnColumnWidthChanged(e);
    }

    /// <summary>
    /// Raises the <see cref="E:ColumnWidthChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ColumnWidthChangedEventArgs" /> instance containing the event data.</param>
    protected virtual void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
    {
      ColumnWidthChangedEventHandler widthChangedHandler = this.ColumnWidthChangedHandler;
      if (widthChangedHandler == null)
        return;
      widthChangedHandler((object) this, e);
    }

    /// <summary>
    /// Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ColumnWidthChangedEventArgs" /> instance containing the event data.</param>
    [Obsolete("Implemented by design as ColumnWidthChanged (Use ColumnWidthChanged instead).")]
    protected virtual void OnColumnWidthChanging(ColumnWidthChangedEventArgs e)
    {
      ColumnWidthChangedEventHandler columnWidthChanging = this.ColumnWidthChanging;
      if (columnWidthChanging == null)
        return;
      columnWidthChanging((object) this, e);
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      ListView.ColumnHeaderCollection columns = this.Columns;
      ListView.ListViewItemCollection items = this.Items;
      if (columns != null)
        this.RegisterBatch((ICollection) columns);
      if (items == null)
        return;
      this.RegisterBatch((ICollection) items);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      ListView.ColumnHeaderCollection columns = this.Columns;
      ListView.ListViewItemCollection items = this.Items;
      if (columns != null)
        this.UnRegisterBatch((ICollection) columns);
      if (items == null)
        return;
      this.UnRegisterBatch((ICollection) items);
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
    {
      Type type = Type.GetType(strOffspringTypeName);
      if (type != (Type) null)
      {
        if (CommonUtils.IsTypeOrSubType(type, typeof (ListViewItem)))
          return (IList) this.Items;
        if (CommonUtils.IsTypeOrSubType(type, typeof (ColumnHeader)))
          return (IList) this.Columns;
      }
      return base.GetComponentOffsprings(strOffspringTypeName);
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new ListViewRenderer(this);

    /// <summary>Fires the item check.</summary>
    /// <param name="objListViewItem">The obj list view item.</param>
    /// <param name="blnChecked">if set to <c>true</c> [BLN checked].</param>
    internal void FireItemCheck(ListViewItem objListViewItem, bool blnChecked)
    {
      if (this.ItemCheckHandler == null)
        return;
      ListView.ListViewItemCollection items = this.Items;
      if (blnChecked)
        this.ItemCheckHandler((object) this, new ItemCheckEventArgs(items.IndexOf(objListViewItem), CheckState.Checked, CheckState.Unchecked));
      else
        this.ItemCheckHandler((object) this, new ItemCheckEventArgs(items.IndexOf(objListViewItem), CheckState.Unchecked, CheckState.Checked));
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal virtual void OnItemDoubleClick(
      ListViewItem objListViewItem,
      MouseEventArgs objMouseEventArgs)
    {
      this.OnDoubleClick((EventArgs) objMouseEventArgs);
    }

    /// <summary>
    /// 
    /// </summary>
    protected internal virtual void OnItemClick(
      ListViewItem objListViewItem,
      MouseEventArgs objMouseEventArgs)
    {
      this.OnClick((EventArgs) objMouseEventArgs);
    }

    /// <summary>Fires the swipe.</summary>
    /// <param name="enmSwipeDirection">The swipe direction.</param>
    protected internal virtual void OnItemSwipe(
      ListViewItem objListViewItem,
      SwipeDirection enmSwipeDirection)
    {
      this.OnSwipe(enmSwipeDirection);
    }

    /// <summary>Gets the relative XY from item.</summary>
    /// <param name="objItem">The list view item.</param>
    /// <param name="intX">The X position.</param>
    /// <param name="intY">The Y position</param>
    /// <returns></returns>
    internal void GetRelativeXYFromItem(ListViewItem objItem, ref int intX, ref int intY)
    {
      ListView.ItemLayoutProcessor objProcessor = new ListView.ItemLayoutProcessor(this, objItem);
      this.ProcessVisibleItemsAndGroups((ListView.ItemProcessor) objProcessor, true);
      intX = objProcessor.ItemLocation.X + intX;
      intY = objProcessor.ItemLocation.Y + intY;
    }

    /// <summary>Gets the item from relative XY.</summary>
    /// <param name="intX">The X position.</param>
    /// <param name="intY">The Y position</param>
    /// <returns></returns>
    private ListViewItem GetItemFromRelativeXY(int intX, int intY)
    {
      ListView.ItemLayoutProcessor objProcessor = new ListView.ItemLayoutProcessor(this, new Point(intX, intY));
      this.ProcessVisibleItemsAndGroups((ListView.ItemProcessor) objProcessor, true);
      return objProcessor.Item;
    }

    /// <summary>Retrieves the item at the specified location.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGui.Forms.ListViewItem"></see> that represents the item at the specified position. If there is no item at the specified location, the method returns null.</returns>
    /// <param name="intY">The y-coordinate of the location to search for an item (expressed in client coordinates). </param>
    /// <param name="intX">The x-coordinate of the location to search for an item (expressed in client coordinates). </param>
    /// <filterpriority>1</filterpriority>
    public ListViewItem GetItemAt(int intX, int intY) => this.GetItemFromRelativeXY(intX, intY);

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      bool flag = false;
      switch (objEvent.Type)
      {
        case "CheckAll":
          IEnumerator enumerator1 = this.Items.GetEnumerator();
          try
          {
            while (enumerator1.MoveNext())
            {
              ListViewItem current = (ListViewItem) enumerator1.Current;
              if (!current.Checked)
              {
                current.Checked = true;
                flag = true;
              }
            }
            break;
          }
          finally
          {
            if (enumerator1 is IDisposable disposable)
              disposable.Dispose();
          }
        case "CheckNone":
          IEnumerator enumerator2 = this.Items.GetEnumerator();
          try
          {
            while (enumerator2.MoveNext())
            {
              ListViewItem current = (ListViewItem) enumerator2.Current;
              if (current.Checked)
              {
                current.Checked = false;
                flag = true;
              }
            }
            break;
          }
          finally
          {
            if (enumerator2 is IDisposable disposable)
              disposable.Dispose();
          }
        case "CheckedChange":
          this.CheckIndexes(objEvent["Indexes"]);
          break;
        case "ColumnsReorder":
          if (objEvent.Contains("DCN") && objEvent.Contains("TCN"))
          {
            int int32_1 = Convert.ToInt32(objEvent["DCN"]);
            int int32_2 = Convert.ToInt32(objEvent["TCN"]);
            int intIndex1 = -1;
            int intIndex2 = -1;
            foreach (ColumnHeader column in this.Columns)
            {
              if (column.ID == (long) int32_1)
                intIndex1 = column.Index;
              else if (column.ID == (long) int32_2)
                intIndex2 = column.Index;
            }
            if (intIndex1 >= 0 && intIndex1 < this.Columns.Count && intIndex2 >= 0 && intIndex2 < this.Columns.Count)
            {
              int displayIndex1 = this.Columns[intIndex2].DisplayIndex;
              int displayIndex2 = this.Columns[intIndex1].DisplayIndex;
              if (displayIndex2 > displayIndex1)
                ++displayIndex1;
              if (displayIndex2 != displayIndex1)
              {
                ColumnReorderedEventArgs e = new ColumnReorderedEventArgs(displayIndex2, displayIndex1, this.Columns[intIndex1]);
                ColumnReorderedEventHandler handler = (ColumnReorderedEventHandler) this.GetHandler(ListView.EventColumnReordered);
                if (handler != null)
                  handler((object) this, e);
                if (!e.Cancel)
                {
                  this.Columns[intIndex1].DisplayIndex = displayIndex1;
                  this.Columns.ClearSortedColumns();
                  flag = true;
                  break;
                }
                break;
              }
              break;
            }
            break;
          }
          break;
        case "Navigate":
          string s = objEvent["To"];
          switch (s)
          {
            case "End":
              this.CurrentPage = this.TotalPages;
              break;
            case "Home":
              this.CurrentPage = 1;
              break;
            case "Next":
              if (this.CurrentPage < this.TotalPages)
              {
                ++this.CurrentPage;
                break;
              }
              break;
            case "Back":
              if (this.CurrentPage > 1)
              {
                --this.CurrentPage;
                break;
              }
              break;
            default:
              int result;
              if (int.TryParse(s, out result) && result > 0 && result <= this.TotalPages)
              {
                this.CurrentPage = result;
                break;
              }
              break;
          }
          if (this.PagingChanged != null)
          {
            this.PagingChanged((object) this, new EventArgs());
            break;
          }
          break;
        case "SelectAll":
          IEnumerator enumerator3 = this.Items.GetEnumerator();
          try
          {
            while (enumerator3.MoveNext())
            {
              ListViewItem current = (ListViewItem) enumerator3.Current;
              if (!current.Selected)
              {
                current.Selected = true;
                flag = true;
              }
            }
            break;
          }
          finally
          {
            if (enumerator3 is IDisposable disposable)
              disposable.Dispose();
          }
        case "SelectNone":
          IEnumerator enumerator4 = this.Items.GetEnumerator();
          try
          {
            while (enumerator4.MoveNext())
            {
              ListViewItem current = (ListViewItem) enumerator4.Current;
              if (current.Selected)
              {
                current.Selected = false;
                flag = true;
              }
            }
            break;
          }
          finally
          {
            if (enumerator4 is IDisposable disposable)
              disposable.Dispose();
          }
        case "SelectionChange":
          this.SelectIndexes(objEvent["Indexes"], objEvent["Incremental"] == "1");
          break;
      }
      base.FireEvent(objEvent);
      if (!flag)
        return;
      this.Update();
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.SelectedIndexChangedHandler != null || this.DataSourceHasBindings)
        criticalEventsData.Set("SLC");
      if (this.ItemCheckHandler != null)
        criticalEventsData.Set("CC");
      if (this.ColumnWidthChangedHandler != null)
        criticalEventsData.Set("CCW");
      if (this.AfterLabelEditHandler != null)
        criticalEventsData.Set("ALE");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("SelectionChange"))
        clientEventsData.Set("SLC");
      if (this.HasClientHandler("CheckedChange"))
        clientEventsData.Set("CC");
      if (this.HasClientHandler("ChangeColumnWidth"))
        clientEventsData.Set("CCW");
      return clientEventsData;
    }

    /// <summary>Gets the critical events internal.</summary>
    /// <returns></returns>
    internal CriticalEventsData GetCriticalEventsDataInternal() => this.GetCriticalEventsData();

    /// <summary>Ensures that the specified item is visible within the control, scrolling the contents of the control if necessary.</summary>
    /// <param name="index">The zero-based index of the item to scroll into view. </param>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void EnsureVisible(int index)
    {
      if (index < 0 || index >= this.Items.Count)
        throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      this.Items[index].EnsureVisible();
    }

    /// <summary>Removes all items and columns from the control.</summary>
    public void Clear()
    {
      this.Items.Clear();
      this.Columns.Clear();
    }

    /// <summary>Selects the indexes.</summary>
    /// <param name="strIndexes">STR indexes.</param>
    /// <param name="blnIncremental">if set to <c>true</c> [BLN incremental].</param>
    private void SelectIndexes(string strIndexes, bool blnIncremental)
    {
      bool flag = false;
      ListView.ListViewOrederedItems viewOrederedItems = new ListView.ListViewOrederedItems(this);
      int num1 = 0;
      int num2 = viewOrederedItems.Count - 1;
      int itemsPerPage = this.ItemsPerPage;
      if (this.UseInternalPaging)
      {
        num1 = (this.CurrentPageInternal - 1) * itemsPerPage;
        num2 = num1 + itemsPerPage - 1;
        if (num2 > viewOrederedItems.Count - 1)
          num2 = viewOrederedItems.Count - 1;
      }
      if (!blnIncremental)
      {
        for (int index = 0; index < viewOrederedItems.Count; ++index)
        {
          if (viewOrederedItems[index].InternalSelected)
          {
            viewOrederedItems[index].InternalSelected = false;
            flag = true;
          }
        }
      }
      else
      {
        for (int index = num1; index <= num2; ++index)
        {
          if (viewOrederedItems[index].InternalSelected)
          {
            viewOrederedItems[index].InternalSelected = false;
            flag = true;
          }
        }
      }
      if (strIndexes != string.Empty)
      {
        string str = strIndexes;
        char[] chArray = new char[1]{ ',' };
        foreach (string s in str.Split(chArray))
        {
          int num3 = int.Parse(s);
          if (!viewOrederedItems[num3 + num1].InternalSelected)
          {
            viewOrederedItems[num3 + num1].InternalSelected = true;
            flag = true;
          }
        }
      }
      if (!flag)
        return;
      this.OnSelectedIndexChanged(EventArgs.Empty);
    }

    /// <summary>Checks the indexes.</summary>
    /// <param name="strIndexes">indexes.</param>
    private void CheckIndexes(string strIndexes)
    {
      ArrayList arrayList = new ArrayList((ICollection) strIndexes.Split(','));
      ListView.ListViewOrederedItems viewOrederedItems = new ListView.ListViewOrederedItems(this);
      int num1 = 0;
      int num2 = viewOrederedItems.Count - 1;
      if (this.UseInternalPaging)
      {
        int itemsPerPage = this.ItemsPerPage;
        num1 = (this.CurrentPageInternal - 1) * itemsPerPage;
        num2 = num1 + itemsPerPage - 1;
        if (num2 > viewOrederedItems.Count - 1)
          num2 = viewOrederedItems.Count - 1;
      }
      List<bool> boolList = new List<bool>(num2 + 1 - num1);
      for (int index = num1; index <= num2; ++index)
        boolList.Add(viewOrederedItems[index].InternalChecked);
      for (int index = num1; index <= num2; ++index)
      {
        if (arrayList.Contains((object) (index - num1).ToString()))
        {
          if (!boolList[index - num1])
          {
            viewOrederedItems[index].InternalChecked = true;
            if (this.ItemCheckHandler != null)
              this.ItemCheckHandler((object) this, new ItemCheckEventArgs(this.Items.IndexOf(viewOrederedItems[index]), CheckState.Checked, CheckState.Unchecked));
          }
        }
        else if (boolList[index - num1])
        {
          viewOrederedItems[index].InternalChecked = false;
          if (this.ItemCheckHandler != null)
            this.ItemCheckHandler((object) this, new ItemCheckEventArgs(this.Items.IndexOf(viewOrederedItems[index]), CheckState.Unchecked, CheckState.Checked));
        }
      }
    }

    /// <summary>Gets the height of the column header.</summary>
    /// <returns></returns>
    private int GetColumnHeaderHeight()
    {
      int columnHeaderHeight = this.ColumnHeadersHeight;
      if (columnHeaderHeight == -1)
      {
        columnHeaderHeight = ((ListViewSkin) this.Skin).HeaderHeight;
        if (columnHeaderHeight == -1)
          columnHeaderHeight = this.GetPreferdItemFontHeight(true);
      }
      return columnHeaderHeight;
    }

    /// <summary>Gets the preferd height of the control item.</summary>
    /// <param name="intPreferedItemHeight">The preferd height of the item.</param>
    /// <returns></returns>
    private int GetPreferdControlItemHeight()
    {
      int preferdItemFontHeight = this.GetPreferdItemFontHeight(false);
      int num = 0;
      foreach (ColumnHeader column in this.Columns)
      {
        if (column.Type == ListViewColumnType.Control)
          num = Math.Max(num, column.PreferedItemHeight);
      }
      return Math.Max(preferdItemFontHeight, num);
    }

    /// <summary>
    /// Flags that the listview is currently going through updates.
    /// </summary>
    public void BeginUpdate() => ++this.InUpadte;

    /// <summary>
    /// Finish batch updates and flags that the listview has finished updates.
    /// </summary>
    public void EndUpdate()
    {
      if (this.InUpadte <= 0)
        return;
      --this.InUpadte;
      if (this.InUpadte != 0)
        return;
      foreach (ColumnHeader column in this.Columns)
        column.Width = column.InternalWidth;
    }

    /// <summary>
    /// 
    /// </summary>
    internal void ClearPaging()
    {
      this.CurrentPageInternal = 1;
      this.TotalPagesInternal = 1;
    }

    /// <summary>Sort the list view by this column</summary>
    /// <param name="objColumn"></param>
    internal void SortBy(ColumnHeader objColumn)
    {
      foreach (ColumnHeader column in this.Columns)
      {
        if (column == objColumn)
        {
          column.SortOrder = column.SortOrder != SortOrder.Ascending ? SortOrder.Ascending : SortOrder.Descending;
          column.SortPosition = 0;
        }
        else
        {
          column.SortOrder = SortOrder.None;
          column.SortPosition = 1000;
        }
      }
      if (this.ColumnClick != null)
        this.OnColumnClick(new ColumnClickEventArgs(objColumn.Index));
      else
        this.Sort();
    }

    /// <summary>Sorts this list items.</summary>
    public virtual void Sort() => this.Items.Sort();

    /// <summary>
    /// 
    /// </summary>
    internal void FireGroup() => this.ApplyGrouping();

    /// <summary>Apply grouping</summary>
    protected virtual void ApplyGrouping()
    {
    }

    /// <summary>Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</summary>
    /// <returns>The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
    /// <param name="strText">The text to search for.</param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public ListViewItem FindItemWithText(string strText) => this.Items.Count == 0 ? (ListViewItem) null : this.FindItemWithText(strText, true, 0, true);

    /// <summary>Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> or <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.</summary>
    /// <returns>The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
    /// <param name="blnIncludeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
    /// <param name="intStartIndex">The index of the item at which to start the search.</param>
    /// <param name="strText">The text to search for.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is less 0 or more than the number items in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public ListViewItem FindItemWithText(
      string strText,
      bool blnIncludeSubItemsInSearch,
      int intStartIndex)
    {
      return this.FindItemWithText(strText, blnIncludeSubItemsInSearch, intStartIndex, true);
    }

    /// <summary>Finds the first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> or <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.</summary>
    /// <returns>The first <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that begins with the specified text value.</returns>
    /// <param name="blnIsPrefixSearch">true to return match the text to the text prefix of an item; otherwise, false. </param>
    /// <param name="blnIncludeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
    /// <param name="intStartIndex">The index of the item at which to start the search.</param>
    /// <param name="strText">The text to search for.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is less 0 or more than the number of items in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public ListViewItem FindItemWithText(
      string strText,
      bool blnIncludeSubItemsInSearch,
      int intStartIndex,
      bool blnIsPrefixSearch)
    {
      if (intStartIndex < 0 || intStartIndex >= this.Items.Count)
        throw new ArgumentOutOfRangeException("startIndex", SR.GetString("InvalidArgument", (object) "startIndex", (object) intStartIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      return this.FindItem(true, strText, blnIsPrefixSearch, new Point(0, 0), SearchDirectionHint.Down, intStartIndex, blnIncludeSubItemsInSearch);
    }

    /// <summary>Finds the item.</summary>
    /// <param name="blnIsTextSearch">if set to <c>true</c> is text search.</param>
    /// <param name="strText">The text to search for.</param>
    /// <param name="blnIsPrefixSearch">if set to <c>true</c> return match the text to the text prefix of an item.</param>
    /// <param name="objPoint">The obj point.</param>
    /// <param name="enmSearchDirectionHint">The enm search direction hint.</param>
    /// <param name="intStartIndex">The index of the item at which to start the search.</param>
    /// <param name="blnIncludeSubItemsInSearch">if set to <c>true</c> include subitems in the search.</param>
    /// <returns></returns>
    private ListViewItem FindItem(
      bool blnIsTextSearch,
      string strText,
      bool blnIsPrefixSearch,
      Point objPoint,
      SearchDirectionHint enmSearchDirectionHint,
      int intStartIndex,
      bool blnIncludeSubItemsInSearch)
    {
      if (this.Items.Count != 0)
      {
        if (!this.IsHandleCreated)
          return (ListViewItem) null;
        if (blnIsTextSearch)
        {
          for (int intIndex = intStartIndex; intIndex < this.Items.Count; ++intIndex)
          {
            ListViewItem listViewItem = this.Items[intIndex];
            int num = !blnIncludeSubItemsInSearch ? 1 : listViewItem.SubItems.Count;
            for (int index = 0; index < num; ++index)
            {
              ListViewItem.ListViewSubItem subItem = listViewItem.SubItems[index];
              if (string.Equals(strText, subItem.Text, StringComparison.OrdinalIgnoreCase) || blnIsPrefixSearch && CultureInfo.CurrentCulture.CompareInfo.IsPrefix(subItem.Text, strText, CompareOptions.IgnoreCase))
                return listViewItem;
            }
          }
        }
      }
      return (ListViewItem) null;
    }

    /// <summary>Resizes the width of the given column as indicated by the resize style.</summary>
    /// <param name="intColumnIndex">The zero-based index of the column to resize.</param>
    /// <param name="enmHeaderAutoResize">One of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle"></see> values.</param>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">headerAutoResize is not a member of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle"></see> enumeration.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is greater than 0 when <see cref="P:Gizmox.WebGUI.Forms.ListView.Columns"></see> is null-or-columnIndex is less than 0 or greater than the number of columns set.</exception>
    public void AutoResizeColumn(
      int intColumnIndex,
      ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
    {
      this.SetColumnWidth(intColumnIndex, enmHeaderAutoResize);
    }

    internal int GetColumnFixedWidth(
      int intColumnIndex,
      int intInternalWidth,
      bool blnIsAutoResizeStyle)
    {
      int columnFixedWidth = 0;
      string empty = string.Empty;
      int val2 = 1;
      int val1 = 1;
      bool flag1 = false;
      bool flag2 = false;
      ListView.ColumnHeaderCollection columns = this.Columns;
      if (intColumnIndex < 0 || intColumnIndex >= 0 && columns == null || intColumnIndex >= columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex", SR.GetString("InvalidArgument", (object) "columnIndex", (object) intColumnIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      ColumnHeader columnHeader = columns[intColumnIndex];
      if (columnHeader != null && columnHeader.Type != ListViewColumnType.Icon)
      {
        if (blnIsAutoResizeStyle)
        {
          flag2 = intInternalWidth == 1;
          flag1 = flag2 || intInternalWidth == 2;
        }
        else if (intInternalWidth < 0)
        {
          flag1 = true;
          flag2 = intInternalWidth == -2;
        }
        if (flag1)
        {
          foreach (ListViewItem listViewItem in this.Items)
          {
            ListViewItem.ListViewSubItem subItem = listViewItem.SubItems[columnHeader.Index];
            if (subItem != null && subItem.Text != null)
            {
              int width = CommonUtils.GetStringMeasurements(subItem.Text, subItem.Font).Width;
              if (width > val2)
                val2 = width;
            }
          }
        }
        if (flag2)
          val1 = CommonUtils.GetStringMeasurements(columnHeader.Text, this.Font).Width;
        if (flag2 & flag1)
          columnFixedWidth = Math.Max(val1, val2);
        else if (!flag2 & flag1)
          columnFixedWidth = val2;
        else if (flag2 && !flag1)
          columnFixedWidth = val1;
      }
      return columnFixedWidth;
    }

    internal void SetColumnWidth(
      int intColumnIndex,
      ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
    {
      ListView.ColumnHeaderCollection columns = this.Columns;
      if (intColumnIndex < 0 || intColumnIndex >= 0 && columns == null || intColumnIndex >= columns.Count)
        throw new ArgumentOutOfRangeException("columnIndex", SR.GetString("InvalidArgument", (object) "columnIndex", (object) intColumnIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      ColumnHeader column = this.Columns[intColumnIndex];
      if (column == null || column.Type == ListViewColumnType.Icon)
        return;
      column.Width = this.GetColumnFixedWidth(intColumnIndex, (int) enmHeaderAutoResize, true);
    }

    /// <summary>Gets the current item display index</summary>
    /// <param name="objListViewItem"></param>
    /// <returns></returns>
    internal int GetDisplayIndex(ListViewItem objListViewItem)
    {
      ListView.ListViewItemCollection items = this.Items;
      return items != null ? items.IndexOf(objListViewItem) : -1;
    }

    /// <summary>Adds a child object.</summary>
    /// <param name="objValue">The child object to add.</param>
    protected override void AddChild(object objValue)
    {
      switch (objValue)
      {
        case ColumnHeader _:
          this.Columns.Add((ColumnHeader) objValue);
          break;
        case ListViewItem _:
          this.Items.Add((ListViewItem) objValue);
          break;
        default:
          base.AddChild(objValue);
          break;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:ColumnClick" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ColumnClickEventArgs" /> instance containing the event data.</param>
    protected virtual void OnColumnClick(ColumnClickEventArgs e)
    {
      if (this.ColumnClick == null)
        return;
      this.ColumnClick((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.AfterLabelEdit"></see> event.
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LabelEditEventArgs"></see> that contains the event data.</param>
    protected virtual void OnAfterLabelEdit(LabelEditEventArgs e)
    {
      LabelEditEventHandler labelEditHandler = this.AfterLabelEditHandler;
      if (labelEditHandler == null)
        return;
      labelEditHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.BeforeLabelEdit"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.LabelEditEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeLabelEdit(LabelEditEventArgs e)
    {
      LabelEditEventHandler labelEditHandler = this.BeforeLabelEditHandler;
      if (labelEditHandler == null)
        return;
      labelEditHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:AfterLabelEditInternal" /> event.
    /// </summary>
    /// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.ListViewItemLabelEditEventArgs" /> instance containing the event data.</param>
    internal void OnAfterLabelEditInternal(LabelEditEventArgs e) => this.OnAfterLabelEdit(e);

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected override Gizmox.WebGUI.Forms.WinFormsCompatibility GetWinFormsCompatibility() => (Gizmox.WebGUI.Forms.WinFormsCompatibility) new ListViewWinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
      if (strChangedOptionName == "ListViewShowGridLinesOnEmptyRows")
        this.Update();
      base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
    }

    /// <summary>Gets the default row back color</summary>
    internal Color DefaultRowBackColor => ((ListViewSkin) this.Skin).RowBackColor;

    /// <summary>Gets the default row back color</summary>
    internal Color DefaultRowForeColor => ((ListViewSkin) this.Skin).RowForeColor;

    /// <summary>Gets the default row font.</summary>
    /// <value>The default row font.</value>
    internal Font DefaultRowFont => ((ListViewSkin) this.Skin).RowFont;

    /// <summary>
    /// Gets or sets if auto column generation is active when using data binding
    /// </summary>
    [Obsolete("Please use the 'AutoGenerateColumns' property instead.")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AutoColumnGeneration
    {
      get => this.AutoGenerateColumns;
      set => this.AutoGenerateColumns = value;
    }

    /// <summary>
    /// Gets or sets if auto column generation is active when using data binding
    /// </summary>
    [Browsable(true)]
    [DefaultValue(true)]
    [SRCategory("CatData")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool AutoGenerateColumns
    {
      get => this.GetValue<bool>(ListView.AutoGenerateColumnsProperty);
      set
      {
        if (!this.SetValue<bool>(ListView.AutoGenerateColumnsProperty, value))
          return;
        this.Bind();
      }
    }

    /// <summary>Gets or sets if column auto resizing mode</summary>
    [DefaultValue(ColumnHeaderAutoResizeStyle.None)]
    [SRCategory("CatData")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public ColumnHeaderAutoResizeStyle ColumnResizeStyle
    {
      get => this.GetValue<ColumnHeaderAutoResizeStyle>(ListView.HeaderAutoResizeStyleProperty);
      set
      {
        if (!this.SetValue<ColumnHeaderAutoResizeStyle>(ListView.HeaderAutoResizeStyleProperty, value))
          return;
        this.OnAutoResizeColumns();
      }
    }

    /// <summary>The listview data source</summary>
    [RefreshProperties(RefreshProperties.Repaint)]
    [AttributeProvider(typeof (Binding.IDataSourceAttributeProvider))]
    [SRCategory("CatData")]
    [DefaultValue(null)]
    public object DataSource
    {
      get => this.GetValue<object>(ListView.DataSourceProperty, (object) null);
      set
      {
        if (!this.SetValue<object>(ListView.DataSourceProperty, value))
          return;
        this.OnDataSourceChanged(EventArgs.Empty);
        this.Bind();
      }
    }

    /// <summary>The listview data memeber</summary>
    [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [DefaultValue("")]
    [SRCategory("CatData")]
    public string DataMember
    {
      get => this.GetValue<string>(ListView.DataMemberProperty);
      set
      {
        if (!this.SetValue<string>(ListView.DataMemberProperty, value))
          return;
        this.OnDataMemberChanged(EventArgs.Empty);
        this.Bind();
      }
    }

    /// <summary>
    /// Gets a value indicating whether this listview is binded.
    /// </summary>
    /// <value><c>true</c> if this listview is binded; otherwise, <c>false</c>.</value>
    private bool IsBinded => this.DataSource != null;

    /// <summary>
    /// Gets a value indicating whether [data source has bindings].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [data source has bindings]; otherwise, <c>false</c>.
    /// </value>
    private bool DataSourceHasBindings => this.DataSource is BindingSource dataSource && dataSource.CurrencyManager != null && dataSource.CurrencyManager.BindingsCount > 0;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BindingContextChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected override void OnBindingContextChanged(EventArgs e)
    {
      if (!this.IsBinded)
        return;
      this.Bind();
    }

    private void Bind() => this.Bind((ListChangedEventArgs) null);

    private bool ShoudRegenerateColumns(ListChangedEventArgs objBindArgs) => objBindArgs == null || objBindArgs.ListChangedType == ListChangedType.Reset;

    private bool ShouldRegenerateItems(ListChangedEventArgs objBindArgs) => objBindArgs == null || objBindArgs.ListChangedType == ListChangedType.Reset;

    /// <summary>Gets the property descriptor.</summary>
    /// <param name="strPropertyName">Name of the property.</param>
    /// <returns></returns>
    private PropertyDescriptor GetPropertyDescriptor(string strPropertyName)
    {
      PropertyDescriptor propertyDescriptor = (PropertyDescriptor) null;
      if (!string.IsNullOrEmpty(strPropertyName))
      {
        object dataSource = this.DataSource;
        if (dataSource != null)
        {
          IList dataSourceList = this.GetDataSourceList(dataSource);
          switch (dataSourceList)
          {
            case null:
            case DataViewManager _:
              break;
            default:
              PropertyDescriptorCollection listItemProperties = ListBindingHelper.GetListItemProperties((object) dataSourceList);
              if (listItemProperties != null)
              {
                propertyDescriptor = listItemProperties[strPropertyName];
                break;
              }
              break;
          }
        }
      }
      return propertyDescriptor;
    }

    /// <summary>Bind listview to data</summary>
    private void Bind(ListChangedEventArgs objBindArgs)
    {
      if (this.BindingContext == null)
        return;
      bool flag1 = this.ShoudRegenerateColumns(objBindArgs);
      bool flag2 = this.ShouldRegenerateItems(objBindArgs);
      if (this.AutoGenerateColumns & flag1)
      {
        if (this.DesignMode)
        {
          foreach (ColumnHeader column in this.Columns)
            this.UnregisterInDesignMode(column);
        }
        this.Columns.Clear();
      }
      if (flag2)
      {
        this.Items.Clear();
        this.mobjOriginalItemSorting.Clear();
      }
      object dataSource = this.DataSource;
      if (dataSource == null)
        return;
      IList dataSourceList = this.GetDataSourceList(dataSource);
      if (objBindArgs == null)
      {
        this.OnUnWireCurrencyEvents();
        this.OnWireCurrencyEvents();
      }
      if (dataSourceList == null || dataSourceList is DataViewManager)
        return;
      PropertyDescriptorCollection listItemProperties = ListBindingHelper.GetListItemProperties((object) dataSourceList);
      if (listItemProperties != null)
      {
        foreach (PropertyDescriptor objProperty in listItemProperties)
        {
          if (this.AutoGenerateColumns & flag1)
          {
            ColumnHeader column = this.OnGetColumn(objProperty);
            if (column != null)
            {
              column.Tag = (object) objProperty.Name;
              this.RegisterInDesignMode(column, objProperty.Name);
              this.Columns.Add(column);
            }
          }
        }
        if (flag2)
        {
          for (int index = 0; index < dataSourceList.Count; ++index)
          {
            object objItem = dataSourceList[index];
            if (objItem != null)
              this.CreateOrUpdateBindableItem(objItem, index, (ListViewItem) null);
          }
          this.OnAutoResizeColumns();
        }
        else if (objBindArgs != null)
        {
          switch (objBindArgs.ListChangedType)
          {
            case ListChangedType.ItemAdded:
              this.CreateOrUpdateBindableItem(dataSourceList[objBindArgs.NewIndex], objBindArgs.NewIndex, (ListViewItem) null);
              break;
            case ListChangedType.ItemDeleted:
              this.Items.RemoveAt(objBindArgs.NewIndex);
              break;
            case ListChangedType.ItemChanged:
              object objItem1 = dataSourceList[objBindArgs.NewIndex];
              if (objItem1 != null)
              {
                ListViewItem bindableItemIndex = this.Items[objBindArgs.NewIndex];
                if (bindableItemIndex != null && !object.Equals((object) bindableItemIndex.DataItemIndex, (object) objBindArgs.NewIndex))
                  bindableItemIndex = this.GetListViewItemByBindableItemIndex(objBindArgs.NewIndex);
                if (bindableItemIndex != null)
                {
                  this.CreateOrUpdateBindableItem(objItem1, objBindArgs.NewIndex, bindableItemIndex);
                  break;
                }
                break;
              }
              break;
          }
        }
        CurrencyManager currencyManagerInternal = this.CurrencyManagerInternal;
        if (currencyManagerInternal != null && this.SelectedIndex != currencyManagerInternal.Position)
        {
          this.SelectedIndex = currencyManagerInternal.Position;
          if (this.SelectedItem != null)
            this.SelectedItem.EnsureVisible();
        }
      }
      this.OnDataBindingComplete(ListChangedType.Reset);
    }

    /// <summary>Gets the data source list.</summary>
    /// <param name="objDataSource">The data source.</param>
    /// <returns></returns>
    private IList GetDataSourceList(object objDataSource) => this.DataMember != null ? ListBindingHelper.GetList(objDataSource, this.DataMember) as IList : ListBindingHelper.GetList(objDataSource) as IList;

    /// <summary>Get the matched list view item by bindable item</summary>
    /// <param name="intBindableItemIndex">Index of the int bindable item.</param>
    /// <returns></returns>
    private ListViewItem GetListViewItemByBindableItemIndex(int intBindableItemIndex)
    {
      ListViewItem bindableItemIndex = (ListViewItem) null;
      foreach (ListViewItem listViewItem in this.Items)
      {
        if (object.Equals((object) listViewItem.DataItemIndex, (object) intBindableItemIndex))
        {
          bindableItemIndex = listViewItem;
          break;
        }
      }
      return bindableItemIndex;
    }

    private void CreateOrUpdateBindableItem(
      object objItem,
      int intItemIndex,
      ListViewItem objExistingListViewItem)
    {
      int index = 0;
      ListViewItem objListViewItem = objExistingListViewItem;
      foreach (ColumnHeader column in this.Columns)
      {
        PropertyDescriptor objProperty = (PropertyDescriptor) null;
        if (column.Tag != null)
          objProperty = this.GetPropertyDescriptor(Convert.ToString(column.Tag));
        string strText = "";
        if (objProperty != null)
          strText = this.OnGetCellValue(objItem, objProperty);
        if (index == 0)
        {
          if (objListViewItem == null)
          {
            objListViewItem = this.Items.Add(strText);
            objListViewItem.DataItemIndex = intItemIndex;
            this.mobjOriginalItemSorting.Add(objListViewItem);
          }
          else
            objListViewItem.Text = strText;
        }
        else if (objExistingListViewItem == null)
          objListViewItem.SubItems.Add(strText);
        else if (objListViewItem.SubItems.Count > index)
          objListViewItem.SubItems[index].Text = strText;
        ++index;
      }
      this.OnRowFormating(objItem, objListViewItem);
      this.OnItemBinding(new ListViewItemBindingEventArgs(objItem, objListViewItem));
    }

    /// <summary>Called when [row formating].</summary>
    /// <param name="objRow">The row.</param>
    /// <param name="objListViewItem">The list view item.</param>
    protected virtual void OnRowFormating(object objRow, ListViewItem objListViewItem)
    {
    }

    /// <summary>Do column resizing</summary>
    private void OnAutoResizeColumns()
    {
      if (!this.IsBinded || this.ColumnResizeStyle == ColumnHeaderAutoResizeStyle.None)
        return;
      for (int intColumnIndex = 0; intColumnIndex < this.Columns.Count; ++intColumnIndex)
        this.AutoResizeColumn(intColumnIndex, this.ColumnResizeStyle);
    }

    /// <summary>Unwire currency manager event</summary>
    private void OnUnWireCurrencyEvents()
    {
      CurrencyManager currencyManagerInternal = this.CurrencyManagerInternal;
      if (currencyManagerInternal == null)
        return;
      currencyManagerInternal.PositionChanged -= new EventHandler(this.OnCurrencyManagerPositionChanged);
      currencyManagerInternal.ListChanged -= new ListChangedEventHandler(this.OnCurrencyManagerListChanged);
    }

    /// <summary>Wire currency manager events</summary>
    private void OnWireCurrencyEvents()
    {
      CurrencyManager currencyManagerInternal = this.CurrencyManagerInternal;
      if (currencyManagerInternal == null)
        return;
      currencyManagerInternal.PositionChanged += new EventHandler(this.OnCurrencyManagerPositionChanged);
      currencyManagerInternal.ListChanged += new ListChangedEventHandler(this.OnCurrencyManagerListChanged);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnCurrencyManagerPositionChanged(object sender, EventArgs e)
    {
      CurrencyManager currencyManagerInternal = this.CurrencyManagerInternal;
      if (currencyManagerInternal.Position >= this.mobjOriginalItemSorting.Count)
        return;
      if (currencyManagerInternal.Position > -1 && currencyManagerInternal.Position < this.mobjOriginalItemSorting.Count && this.mobjOriginalItemSorting.IndexOf(this.SelectedItem) > -1)
      {
        ListViewItem listViewItem = this.mobjOriginalItemSorting[currencyManagerInternal.Position];
        if (this.SelectedItem == listViewItem)
          return;
        this.SelectedItem = listViewItem;
        this.Update();
      }
      else
      {
        this.SelectedIndex = -1;
        this.Update();
      }
    }

    /// <summary>Handle list change events</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnCurrencyManagerListChanged(object sender, ListChangedEventArgs e) => this.Bind(e);

    /// <summary>Get column from property</summary>
    /// <param name="objProperty"></param>
    /// <returns></returns>
    protected virtual ColumnHeader OnGetColumn(PropertyDescriptor objProperty)
    {
      bool flag = false;
      TypeConverter converter = objProperty.Converter;
      if (converter != null && converter.CanConvertTo(typeof (string)))
        flag = true;
      return flag ? this.OnCreateColumn(objProperty) : (ColumnHeader) null;
    }

    /// <summary>Creates the column</summary>
    /// <param name="objProperty"></param>
    /// <returns></returns>
    protected virtual ColumnHeader OnCreateColumn(PropertyDescriptor objProperty) => new ColumnHeader()
    {
      Label = objProperty.DisplayName,
      Width = 100
    };

    /// <summary>Register column header in design mode</summary>
    /// <param name="objColumn"></param>
    /// <param name="strName"></param>
    private void RegisterInDesignMode(ColumnHeader objColumn, string strName)
    {
      if (!this.DesignMode || this.Site == null || this.Site.Container == null || objColumn.Site != null)
        return;
      this.Site.Container.Add((IComponent) objColumn, this.GetSafeName(strName, this.Site.Container));
    }

    /// <summary>Get safe name for column header</summary>
    /// <param name="strName"></param>
    /// <param name="objContainer"></param>
    /// <returns></returns>
    private string GetSafeName(string strName, IContainer objContainer)
    {
      string name = "column" + new Regex("[^a-zA-Z0-9]", RegexOptions.CultureInvariant).Replace(strName, "_");
      if (objContainer.Components[name] == null)
        return name;
      int num = 1;
      while (objContainer.Components[name + num.ToString()] != null)
        ++num;
      return name + num.ToString();
    }

    /// <summary>Unregister column header in design mode</summary>
    /// <param name="objColumn"></param>
    private void UnregisterInDesignMode(ColumnHeader objColumn)
    {
      if (!this.DesignMode || this.Site == null || this.Site.Container == null || objColumn.Site == null)
        return;
      this.Site.Container.Remove((IComponent) objColumn);
    }

    /// <summary>Gets the row item value</summary>
    /// <param name="objRow"></param>
    /// <param name="objProperty"></param>
    /// <returns></returns>
    protected virtual object OnGetCellValueAsObject(object objRow, PropertyDescriptor objProperty) => objProperty != null && objRow != null ? objProperty.GetValue(objRow) : (object) null;

    /// <summary>Gets the row item value</summary>
    /// <param name="objRow"></param>
    /// <param name="objProperty"></param>
    /// <returns></returns>
    protected virtual string OnGetCellValue(object objRow, PropertyDescriptor objProperty)
    {
      object cellValueAsObject = this.OnGetCellValueAsObject(objRow, objProperty);
      string cellValue = "";
      if (cellValueAsObject != null)
        cellValue = objProperty.Converter == null ? cellValueAsObject.ToString() : (string) objProperty.Converter.ConvertTo(cellValueAsObject, typeof (string));
      return cellValue;
    }

    /// <summary>Called when [data binding complete].</summary>
    /// <param name="enmListChangedType">Type of the list changed.</param>
    internal void OnDataBindingComplete(ListChangedType enmListChangedType) => this.OnDataBindingComplete(new ListViewBindingCompleteEventArgs(enmListChangedType));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> that contains the event data.</param>
    protected virtual void OnDataBindingComplete(ListViewBindingCompleteEventArgs e)
    {
      ListViewBindingCompleteEventHandler dataBindingComplete = this.DataBindingComplete;
      if (dataBindingComplete == null || this.IsDisposed)
        return;
      dataBindingComplete((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataMemberChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDataMemberChanged(EventArgs e)
    {
      EventHandler dataMemberChanged = this.DataMemberChanged;
      if (dataMemberChanged == null || this.IsDisposed)
        return;
      dataMemberChanged((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ListView.DataSourceChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDataSourceChanged(EventArgs e)
    {
      EventHandler dataSourceChanged = this.DataSourceChanged;
      if (dataSourceChanged == null || this.IsDisposed)
        return;
      dataSourceChanged((object) this, e);
    }

    /// <summary>Compares two ListView Items</summary>
    /// <param name="objObjectA">object A.</param>
    /// <param name="objObjectB">object B.</param>
    /// <returns></returns>
    int IComparer.Compare(object objObjectA, object objObjectB)
    {
      ListViewItem listViewItem1 = objObjectA as ListViewItem;
      ListViewItem listViewItem2 = objObjectB as ListViewItem;
      ICollection sortingColumns = this.SortingColumns;
      if (listViewItem1 != null && listViewItem2 != null)
      {
        int dataItemIndex1 = listViewItem1.DataItemIndex;
        int dataItemIndex2 = listViewItem2.DataItemIndex;
        if (dataItemIndex1 >= 0 && dataItemIndex2 >= 0)
        {
          object dataSource = this.DataSource;
          if (dataSource != null)
          {
            IList dataSourceList = this.GetDataSourceList(dataSource);
            if (dataSourceList != null)
            {
              object objRow1 = dataSourceList[dataItemIndex1];
              object objRow2 = dataSourceList[dataItemIndex2];
              if (sortingColumns.Count > 0)
              {
                foreach (ColumnHeader columnHeader in (IEnumerable) sortingColumns)
                {
                  PropertyDescriptor propertyDescriptor = this.GetPropertyDescriptor(Convert.ToString(columnHeader.Tag));
                  if (propertyDescriptor != null)
                  {
                    object cellValueAsObject1 = this.OnGetCellValueAsObject(objRow1, propertyDescriptor);
                    object cellValueAsObject2 = this.OnGetCellValueAsObject(objRow2, propertyDescriptor);
                    if (!object.Equals(cellValueAsObject1, cellValueAsObject2))
                    {
                      if (cellValueAsObject1 != null && cellValueAsObject2 != null && cellValueAsObject1 != DBNull.Value && cellValueAsObject2 != DBNull.Value)
                      {
                        if (cellValueAsObject1 is IComparable comparable)
                        {
                          int num = comparable.CompareTo(cellValueAsObject2);
                          if (num != 0)
                            return num * (columnHeader.SortOrder == SortOrder.Ascending ? 1 : -1);
                        }
                      }
                      else
                      {
                        if ((cellValueAsObject1 == null || cellValueAsObject1 == DBNull.Value) && cellValueAsObject2 != null && cellValueAsObject2 != DBNull.Value)
                          return -1;
                        if (cellValueAsObject1 != null && cellValueAsObject1 != DBNull.Value && (cellValueAsObject2 == null || cellValueAsObject2 == DBNull.Value))
                          return 1;
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      return 0;
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjColumns) + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjItems) + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjOriginalItemSorting) + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjGroups);

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mobjColumns = new ListView.ColumnHeaderCollection(this, objReader.ReadArray());
      this.mobjItems = new ListView.ListViewItemCollection(this, objReader.ReadArray());
      this.mobjGroups = new ListViewGroupCollection(this, objReader.ReadArray());
      this.mobjOriginalItemSorting = new List<ListViewItem>((IEnumerable<ListViewItem>) objReader.ReadArray<ListViewItem>());
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteArray((ICollection) this.mobjColumns);
      objWriter.WriteArray((ICollection) this.mobjItems);
      objWriter.WriteArray((ICollection) this.mobjGroups);
      objWriter.WriteArray((ICollection) this.mobjOriginalItemSorting);
    }

    /// <summary>Gets the sub item rect.</summary>
    /// <param name="intItemIndex">Index of the int item.</param>
    /// <param name="intSubItemIndex">Index of the int sub item.</param>
    /// <returns></returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// intItemIndex
    /// or
    /// intSubItemIndex
    /// </exception>
    internal Rectangle GetSubItemRect(int intItemIndex, int intSubItemIndex)
    {
      if (this.View != View.Details)
        return Rectangle.Empty;
      if (intItemIndex < 0 || intItemIndex >= this.Items.Count)
        throw new ArgumentOutOfRangeException(nameof (intItemIndex), SR.GetString("InvalidArgument", (object) nameof (intItemIndex), (object) intItemIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      int count = this.Items[intItemIndex].SubItems.Count;
      if (intSubItemIndex < 0 || intSubItemIndex >= count)
        throw new ArgumentOutOfRangeException(nameof (intSubItemIndex), SR.GetString("InvalidArgument", (object) nameof (intSubItemIndex), (object) intSubItemIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      int controlItemHeight = this.GetPreferdControlItemHeight();
      int num = 0;
      int columnHeaderHeight = this.GetColumnHeaderHeight();
      int width = this.Columns[0].Width;
      if (this.CheckBoxes)
      {
        ListViewSkin skin = this.Skin as ListViewSkin;
        width += 22 + skin.HeaderSeperatorWidth;
      }
      for (int intIndex = 0; intIndex < intSubItemIndex; ++intIndex)
        num += intIndex == 0 ? width : this.Columns[intIndex].Width;
      for (int index = 0; index < intItemIndex; ++index)
        columnHeaderHeight += controlItemHeight;
      int top = columnHeaderHeight - this.ScrollTop;
      int left = num - this.ScrollLeft;
      return Rectangle.FromLTRB(left, top, left + (intSubItemIndex == 0 ? width : this.Columns[intSubItemIndex].Width), top + controlItemHeight);
    }

    /// <summary>Gets the item rect.</summary>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">index</exception>
    public Rectangle GetItemRect(int index)
    {
      if (index < 0 || index >= this.Items.Count)
        throw new ArgumentOutOfRangeException(nameof (index), SR.GetString("InvalidArgument", (object) nameof (index), (object) index.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      int controlItemHeight = this.GetPreferdControlItemHeight();
      int num1 = 0;
      int num2 = 0;
      int columnHeaderHeight = this.GetColumnHeaderHeight();
      for (int intIndex = 0; intIndex < this.Columns.Count; ++intIndex)
        num2 += this.Columns[intIndex].Width;
      for (int index1 = 0; index1 < index; ++index1)
        columnHeaderHeight += controlItemHeight;
      int top = columnHeaderHeight - this.ScrollTop;
      int left = num1 - this.ScrollLeft;
      return Rectangle.FromLTRB(left, top, left + num2, top + controlItemHeight);
    }

    /// <summary>
    /// Provides an implementation for internal list of items for listview control
    /// </summary>
    [Serializable]
    internal class ListViewNativeItemCollection : ListView.ListViewItemCollection.IInnerList
    {
      /// <summary>The internal array list</summary>
      private ArrayList mobjList;
      /// <summary>The owning listview</summary>
      private ListView mobjListView;

      /// <summary>Gets the list.</summary>
      /// <value>The list.</value>
      private ArrayList List
      {
        get
        {
          if (this.mobjList == null)
            this.mobjList = new ArrayList();
          return this.mobjList;
        }
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewNativeItemCollection" /> class.
      /// </summary>
      /// <param name="objListView">The owner list view.</param>
      public ListViewNativeItemCollection(ListView objListView) => this.mobjListView = objListView;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewNativeItemCollection" /> class.
      /// </summary>
      /// <param name="objListView">The owner list view.</param>
      /// <param name="arrItems">The arr items.</param>
      internal ListViewNativeItemCollection(ListView objListView, object[] arrItems)
      {
        this.mobjListView = objListView;
        this.mobjList = new ArrayList((ICollection) arrItems);
      }

      /// <summary>Adds the specified item.</summary>
      /// <param name="value">The value.</param>
      /// <returns></returns>
      public ListViewItem Add(ListViewItem value)
      {
        this.List.Add((object) value);
        value.InternalListView = this.mobjListView;
        this.mobjListView.Update();
        return value;
      }

      /// <summary>Adds the range.</summary>
      /// <param name="arrItems">The items.</param>
      public void AddRange(ListViewItem[] arrItems) => this.List.AddRange((ICollection) arrItems);

      /// <summary>Clears the items.</summary>
      public void Clear()
      {
        this.mobjListView.UnRegisterBatch((ICollection) this.List);
        this.mobjListView.SelectedIndex = -1;
        if (this.mobjListView.UseInternalPaging)
          this.mobjListView.ClearPaging();
        this.mobjListView.Update();
        this.List.Clear();
      }

      /// <summary>Determines whether [contains] [the specified item].</summary>
      /// <param name="objItem">The item.</param>
      /// <returns>
      /// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
      /// </returns>
      public bool Contains(ListViewItem objItem) => this.List.Contains((object) objItem);

      /// <summary>Copies to.</summary>
      /// <param name="objDestinationArray">The dest.</param>
      /// <param name="index">The index.</param>
      public void CopyTo(Array objDestinationArray, int index) => this.List.CopyTo(objDestinationArray, index);

      /// <summary>Gets the enumerator.</summary>
      /// <returns></returns>
      public IEnumerator GetEnumerator() => this.List.GetEnumerator();

      /// <summary>Indexes the of.</summary>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public int IndexOf(ListViewItem objItem) => this.List.IndexOf((object) objItem);

      /// <summary>Inserts the specified index.</summary>
      /// <param name="index">The index.</param>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public ListViewItem Insert(int index, ListViewItem objItem)
      {
        this.List.Insert(index, (object) objItem);
        objItem.InternalListView = this.mobjListView;
        this.mobjListView.Update();
        return objItem;
      }

      /// <summary>Removes the specified obj list view item.</summary>
      /// <param name="objListViewItem">The obj list view item.</param>
      public void Remove(ListViewItem objListViewItem)
      {
        bool selected = objListViewItem.Selected;
        if (objListViewItem.InternalParent == this.mobjListView)
        {
          objListViewItem.InternalUnRegisterSelf();
          objListViewItem.InternalParent = (Component) null;
        }
        this.List.Remove((object) objListViewItem);
        if (this.mobjListView == null)
          return;
        this.mobjListView.UnRegisterComponent((IRegisteredComponent) objListViewItem);
        if (selected)
          this.mobjListView.OnSelectedIndexChanged(EventArgs.Empty);
        if (this.mobjListView.CurrentPage > this.mobjListView.TotalPages)
          this.mobjListView.CurrentPage = this.mobjListView.TotalPages;
        this.mobjListView.Update();
      }

      /// <summary>Removes at.</summary>
      /// <param name="index">The index.</param>
      public void RemoveAt(int index)
      {
        this.List.RemoveAt(index);
        if (this.mobjListView == null || this.mobjListView.CurrentPage <= this.mobjListView.TotalPages)
          return;
        this.mobjListView.CurrentPage = this.mobjListView.TotalPages;
        this.mobjListView.Update();
      }

      /// <summary>Gets the count.</summary>
      /// <value>The count.</value>
      public int Count => this.List.Count;

      /// <summary>Gets the list view.</summary>
      /// <value>The list view.</value>
      public ListView ListView => this.mobjListView;

      /// <summary>
      /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> with the specified display index.
      /// </summary>
      /// <value></value>
      public ListViewItem this[int intDisplayIndex]
      {
        get => (ListViewItem) this.List[intDisplayIndex];
        set => this.List[intDisplayIndex] = (object) value;
      }

      public void Sort()
      {
        if (this.mobjListView.ListViewItemSorterInternal == null)
          return;
        this.mobjListView.ResetSortingColumns();
        this.List.Sort(this.mobjListView.ListViewItemSorterInternal);
        this.mobjListView.Update();
      }
    }

    /// <summary>
    /// Provides a collection of items that are mapped to this group
    /// </summary>
    [Serializable]
    internal class ListViewGroupItemCollection : ListView.ListViewItemCollection.IInnerList
    {
      /// <summary>The owning listview group</summary>
      private ListViewGroup mobjListViewGroup;
      /// <summary>The inner items collection</summary>
      private ArrayList mobjItems = new ArrayList();

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewGroupItemCollection" /> class.
      /// </summary>
      /// <param name="objListViewGroup">The list view group.</param>
      internal ListViewGroupItemCollection(ListViewGroup objListViewGroup) => this.mobjListViewGroup = objListViewGroup;

      /// <summary>Adds the specified item.</summary>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public ListViewItem Add(ListViewItem objItem)
      {
        if (objItem == null)
          throw new ArgumentNullException("item");
        if (objItem.Group != null)
          objItem.Group.Items.Remove(objItem);
        this.mobjItems.Add((object) objItem);
        objItem.MoveToGroup(this.mobjListViewGroup);
        return objItem;
      }

      /// <summary>Adds the range.</summary>
      /// <param name="arrItems">The items.</param>
      public void AddRange(ListViewItem[] arrItems)
      {
        foreach (ListViewItem arrItem in arrItems)
          this.Add(arrItem);
      }

      /// <summary>Clears this instance.</summary>
      public void Clear()
      {
        foreach (ListViewItem mobjItem in this.mobjItems)
          mobjItem.MoveToGroup((ListViewGroup) null);
        this.mobjItems.Clear();
      }

      /// <summary>Determines whether [contains] [the specified item].</summary>
      /// <param name="objItem">The item.</param>
      /// <returns>
      /// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
      /// </returns>
      public bool Contains(ListViewItem objItem) => this.mobjItems.Contains((object) objItem);

      /// <summary>Copies to.</summary>
      /// <param name="objDestinationArray">The dest.</param>
      /// <param name="index">The index.</param>
      public void CopyTo(Array objDestinationArray, int index) => this.mobjItems.CopyTo(objDestinationArray, index);

      /// <summary>Gets the enumerator.</summary>
      /// <returns></returns>
      public IEnumerator GetEnumerator() => this.mobjItems.GetEnumerator();

      /// <summary>Indexes the of.</summary>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public int IndexOf(ListViewItem objItem) => objItem != null ? this.mobjItems.IndexOf((object) objItem) : throw new ArgumentNullException("item");

      /// <summary>Inserts the specified index.</summary>
      /// <param name="index">The index.</param>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public ListViewItem Insert(int index, ListViewItem objItem)
      {
        if (objItem == null)
          throw new ArgumentNullException("item");
        if (objItem.Group != null)
          objItem.Group.Items.Remove(objItem);
        objItem.MoveToGroup(this.mobjListViewGroup);
        return objItem;
      }

      /// <summary>Removes the specified item.</summary>
      /// <param name="objItem">The item.</param>
      public void Remove(ListViewItem objItem)
      {
        if (objItem == null)
          throw new ArgumentNullException("item");
        if (objItem.Group != this.mobjListViewGroup)
          return;
        this.mobjItems.Remove((object) objItem);
        objItem.MoveToGroup((ListViewGroup) null);
      }

      /// <summary>Removes at.</summary>
      /// <param name="index">The index.</param>
      public void RemoveAt(int index) => this.mobjItems.Remove(this.mobjItems[index]);

      /// <summary>Sorts this instance.</summary>
      public void Sort()
      {
      }

      /// <summary>Gets the count.</summary>
      /// <value>The count.</value>
      public int Count => this.mobjItems.Count;

      /// <summary>Gets the list view.</summary>
      /// <value>The list view.</value>
      public ListView ListView => (ListView) null;

      /// <summary>
      /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> at the specified index.
      /// </summary>
      /// <value></value>
      public ListViewItem this[int index]
      {
        get => (ListViewItem) this.mobjItems[index];
        set
        {
          if (value == null)
            throw new ArgumentNullException(nameof (value));
          if (value.Group != null)
            value.Group.Items.Remove(value);
          value.MoveToGroup(this.mobjListViewGroup);
          this.mobjItems[index] = (object) value;
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class ListViewOrederedItems : ListView.ListViewItemCollection.IInnerList
    {
      /// <summary>
      /// 
      /// </summary>
      private ListView mobjListView;
      /// <summary>
      /// 
      /// </summary>
      private bool mblnShowGroups;
      /// <summary>
      /// 
      /// </summary>
      private List<ListViewItem> mobjGroupedItems;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewOrederedItems" /> class.
      /// </summary>
      /// <param name="objListView">The list view.</param>
      public ListViewOrederedItems(ListView objListView)
      {
        this.mobjListView = objListView;
        if (this.mobjListView == null)
          return;
        this.mblnShowGroups = this.mobjListView.ShowGroups;
      }

      /// <summary>Adds the specified item.</summary>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public ListViewItem Add(ListViewItem objItem) => throw new NotSupportedException();

      /// <summary>Adds the range.</summary>
      /// <param name="arrItems">The items.</param>
      public void AddRange(ListViewItem[] arrItems) => throw new NotSupportedException();

      /// <summary>Clears this instance.</summary>
      public void Clear() => throw new NotSupportedException();

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objItem"></param>
      /// <returns></returns>
      public bool Contains(ListViewItem objItem) => this.mobjListView.Items.Contains((object) objItem);

      /// <summary>Copies to.</summary>
      /// <param name="objDestinationArray">The dest.</param>
      /// <param name="index">The index.</param>
      public void CopyTo(Array objDestinationArray, int index) => throw new NotSupportedException();

      /// <summary>Gets the enumerator.</summary>
      /// <returns></returns>
      public IEnumerator GetEnumerator() => throw new NotSupportedException();

      /// <summary>Get item index</summary>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public int IndexOf(ListViewItem objItem) => throw new NotSupportedException();

      /// <summary>Inserts the specified index.</summary>
      /// <param name="index">The index.</param>
      /// <param name="objItem">The item.</param>
      /// <returns></returns>
      public ListViewItem Insert(int index, ListViewItem objItem) => throw new NotSupportedException();

      /// <summary>Removes the specified item.</summary>
      /// <param name="objItem">The item.</param>
      public void Remove(ListViewItem objItem) => throw new NotSupportedException();

      /// <summary>Removes at.</summary>
      /// <param name="index">The index.</param>
      public void RemoveAt(int index) => throw new NotSupportedException();

      /// <summary>Sorts this instance.</summary>
      public void Sort() => throw new NotSupportedException();

      /// <summary>Gets the count.</summary>
      /// <value>The count.</value>
      public int Count => this.mobjListView.Items.Count;

      /// <summary>
      /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> at the specified index.
      /// </summary>
      /// <value></value>
      public ListViewItem this[int index]
      {
        get
        {
          if (!this.mblnShowGroups)
            return this.mobjListView.Items[index];
          this.EnsureGroupedItems();
          return this.mobjGroupedItems[index];
        }
        set => throw new NotSupportedException();
      }

      /// <summary>Ensures grouped items.</summary>
      private void EnsureGroupedItems()
      {
        if (this.mobjGroupedItems != null)
          return;
        this.mobjGroupedItems = new List<ListViewItem>();
        List<ListViewGroup> listViewGroupList = new List<ListViewGroup>();
        listViewGroupList.Add((ListViewGroup) null);
        if (this.ListView == null)
          return;
        foreach (ListViewGroup group in this.ListView.Groups)
          listViewGroupList.Add(group);
        foreach (ListViewGroup listViewGroup in listViewGroupList)
        {
          foreach (ListViewItem listViewItem in this.ListView.Items)
          {
            if (listViewItem.Group == listViewGroup)
              this.mobjGroupedItems.Add(listViewItem);
          }
        }
      }

      /// <summary>Gets the list view.</summary>
      /// <value>The list view.</value>
      public ListView ListView => this.mobjListView;
    }

    /// <summary>
    /// Represents the collection of items in a ListView control.
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Serializable]
    public class ListViewItemCollection : ICollection, IEnumerable, IList, IObservableList
    {
      private ListView.ListViewItemCollection.IInnerList mobjList;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection" /> instance.
      /// </summary>
      /// <param name="objListView">The obj list view.</param>
      public ListViewItemCollection(ListView objListView) => this.mobjList = (ListView.ListViewItemCollection.IInnerList) new ListView.ListViewNativeItemCollection(objListView);

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection" /> instance.
      /// </summary>
      /// <param name="objListView">The obj list view.</param>
      /// <param name="arrItems">The arr items.</param>
      internal ListViewItemCollection(ListView objListView, object[] arrItems) => this.mobjList = (ListView.ListViewItemCollection.IInnerList) new ListView.ListViewNativeItemCollection(objListView, arrItems);

      internal ListViewItemCollection(ListViewGroup objListViewGroup) => this.mobjList = (ListView.ListViewItemCollection.IInnerList) new ListView.ListViewGroupItemCollection(objListViewGroup);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="strText">The first sub item text.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(string strText) => this.Add((Control) null, strText, -1);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objPanel">The panel to use in for the list view item.</param>
      /// <param name="strText">The first sub item text.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(Control objPanel, string strText) => this.Add(objPanel, strText, -1);

      /// <summary>Adds the specified obj list view item.</summary>
      /// <param name="objListViewItem">Obj list view item.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(ListViewItem objListViewItem)
      {
        this.mobjList.Add(objListViewItem);
        this.OnItemAdded(objListViewItem);
        if (this.ObservableItemAdded != null)
          this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objListViewItem));
        return objListViewItem;
      }

      /// <summary>Adds the specified text.</summary>
      /// <param name="strText">Text.</param>
      /// <param name="intImageIndex">Image index.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(string strText, int intImageIndex) => this.Add((Control) null, strText, intImageIndex);

      /// <summary>Adds the specified text.</summary>
      /// <param name="strText">The text.</param>
      /// <param name="strImageKey">The image key.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(string strText, string strImageKey)
      {
        ListViewItem objListViewItem = new ListViewItem(strText, strImageKey);
        this.Add(objListViewItem);
        return objListViewItem;
      }

      /// <summary>Adds the specified key.</summary>
      /// <param name="strKey">The key.</param>
      /// <param name="strText">The text.</param>
      /// <param name="intImageIndex">Index of the image.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(string strKey, string strText, int intImageIndex)
      {
        ListViewItem objListViewItem = new ListViewItem(strText, intImageIndex);
        objListViewItem.Name = strKey;
        this.Add(objListViewItem);
        return objListViewItem;
      }

      /// <summary>Adds the specified key.</summary>
      /// <param name="strKey">The STR key.</param>
      /// <param name="strText">The text.</param>
      /// <param name="strImageKey">The STR image key.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(string strKey, string strText, string strImageKey)
      {
        ListViewItem objListViewItem = new ListViewItem(strText, strImageKey);
        objListViewItem.Name = strKey;
        this.Add(objListViewItem);
        return objListViewItem;
      }

      /// <summary>Adds the specified text.</summary>
      /// <param name="objPanel">The obj panel.</param>
      /// <param name="strText">Text.</param>
      /// <param name="intImageIndex">Image index.</param>
      /// <returns></returns>
      public virtual ListViewItem Add(Control objPanel, string strText, int intImageIndex)
      {
        ListViewItem listViewItem = objPanel != null ? (ListViewItem) new ListViewPanelItem(objPanel, strText, intImageIndex) : new ListViewItem(strText, intImageIndex);
        this.mobjList.Add(listViewItem);
        this.OnItemAdded(listViewItem);
        if (this.ObservableItemAdded != null)
          this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) listViewItem));
        return listViewItem;
      }

      /// <summary>Adds an array of <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to the collection.</summary>
      /// <param name="arrListViewItems">An array of <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to add to the collection. </param>
      /// <exception cref="T:System.ArgumentNullException">items is null.</exception>
      public void AddRange(ListViewItem[] arrListViewItems)
      {
        foreach (ListViewItem arrListViewItem in arrListViewItems)
          this.Add(arrListViewItem);
      }

      /// <summary>Removes the specified list view item.</summary>
      /// <param name="objListViewItem">list view item.</param>
      public void Remove(ListViewItem objListViewItem)
      {
        this.mobjList.Remove(objListViewItem);
        objListViewItem.Group?.Items.Remove(objListViewItem);
        this.OnItemRemoved(objListViewItem);
        if (this.ObservableItemRemoved == null)
          return;
        this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) objListViewItem));
      }

      /// <summary>Called when item was removed.</summary>
      /// <param name="objListViewItem">The list view item removed.</param>
      private void OnItemRemoved(ListViewItem objListViewItem)
      {
        ListView listView = this.mobjList.ListView;
        if (listView == null)
          return;
        if (objListViewItem is ListViewPanelItem listViewPanelItem)
          listView.Controls.Remove(listViewPanelItem.Panel);
        foreach (ListViewItem.ListViewSubItem subItem in objListViewItem.SubItems)
        {
          if (subItem is ListViewItem.ListViewSubControlItem viewSubControlItem)
          {
            Control control = viewSubControlItem.Control;
            if (control != null)
              listView.Controls.Remove(control);
          }
        }
      }

      /// <summary>Get the index the of the specified list view item.</summary>
      /// <param name="objListViewItem">Obj list view item.</param>
      /// <returns></returns>
      public int IndexOf(ListViewItem objListViewItem) => this.mobjList.IndexOf(objListViewItem);

      /// <summary>Clears this list items.</summary>
      public void Clear()
      {
        ListViewItem[] objDestinationArray = new ListViewItem[this.mobjList.Count];
        this.mobjList.CopyTo((Array) objDestinationArray, 0);
        this.mobjList.Clear();
        bool flag = !this.mobjList.ListView.DesignMode;
        foreach (ListViewItem objListViewItem in objDestinationArray)
        {
          if (flag)
            objListViewItem.Group?.Items.Remove(objListViewItem);
          this.OnItemRemoved(objListViewItem);
        }
        if (this.ObservableListCleared == null)
          return;
        this.ObservableListCleared((object) this, EventArgs.Empty);
      }

      /// <summary>Copies to an array.</summary>
      /// <param name="objArray">The obj array.</param>
      /// <param name="intIndex">Index of the int.</param>
      public void CopyTo(Array objArray, int intIndex) => this.mobjList.CopyTo(objArray, intIndex);

      /// <summary>Gets an enumerator.</summary>
      /// <returns></returns>
      public IEnumerator GetEnumerator() => this.mobjList.GetEnumerator();

      /// <summary>Sorts this instance.</summary>
      internal void Sort() => this.mobjList.Sort();

      /// <summary>
      /// Gets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> at the specified int index.
      /// </summary>
      /// <value></value>
      public ListViewItem this[int intIndex]
      {
        get => this.mobjList[intIndex];
        set
        {
          if (intIndex < 0 || intIndex >= this.mobjList.Count)
            throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", (object) "index", (object) intIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
          this.mobjList[intIndex] = value;
        }
      }

      /// <summary>
      /// Gets a value indicating whether this instance is synchronized.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
      /// </value>
      public bool IsSynchronized => false;

      /// <summary>Gets the count.</summary>
      /// <value></value>
      public int Count => this.mobjList.Count;

      /// <summary>Gets the sync root.</summary>
      /// <value></value>
      public object SyncRoot => (object) null;

      /// <summary>
      /// 
      /// </summary>
      public bool IsReadOnly => false;

      /// <summary>Return object (ListViewItem) at the specified index.</summary>
      object IList.this[int index]
      {
        get => (object) this.mobjList[index];
        set
        {
          ListViewItem objListViewItem = (ListViewItem) value;
          if (objListViewItem == null)
            return;
          this.mobjList[index] = objListViewItem;
          this.OnItemAdded(objListViewItem);
        }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="index"></param>
      public void RemoveAt(int index)
      {
        if (index <= -1 || index >= this.mobjList.Count)
          throw new ArgumentOutOfRangeException();
        ListViewItem mobj = this.mobjList[index];
        if (mobj == null)
          return;
        this.Remove(mobj);
      }

      /// <summary>Creates a new item and inserts it into the collection at the specified index.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
      /// <param name="index">The zero-based index location where the item is inserted. </param>
      /// <param name="strText">The text to display for the item. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
      public ListViewItem Insert(int index, string strText) => this.Insert(index, new ListViewItem(strText));

      /// <summary>Inserts an existing <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> into the collection at the specified index.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
      /// <param name="objItem">The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that represents the item to insert. </param>
      /// <param name="index">The zero-based index location where the item is inserted. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
      public ListViewItem Insert(int index, ListViewItem objItem)
      {
        this.mobjList.Insert(index, objItem);
        this.OnItemAdded(objItem);
        if (this.ObservableItemAdded != null)
          this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objItem));
        return objItem;
      }

      /// <summary>Called when item was added.</summary>
      /// <param name="objListViewItem">The list view item added.</param>
      private void OnItemAdded(ListViewItem objListViewItem)
      {
        ListView listView = this.mobjList.ListView;
        if (listView == null)
          return;
        if (objListViewItem is ListViewPanelItem listViewPanelItem)
          listView.Controls.Add(listViewPanelItem.Panel);
        foreach (ListViewItem.ListViewSubItem subItem in objListViewItem.SubItems)
        {
          if (subItem is ListViewItem.ListViewSubControlItem viewSubControlItem)
          {
            Control control = viewSubControlItem.Control;
            if (control != null)
              listView.Controls.Add(control);
          }
        }
      }

      /// <summary>Creates a new item with the specified image index and inserts it into the collection at the specified index.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> that was inserted into the collection.</returns>
      /// <param name="intImageIndex">The index of the image to display for the item. </param>
      /// <param name="index">The zero-based index location where the item is inserted. </param>
      /// <param name="strText">The text to display for the item. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
      public ListViewItem Insert(int index, string strText, int intImageIndex) => this.Insert(index, new ListViewItem(strText, intImageIndex));

      /// <summary>Creates a new item with the specified text and image and inserts it in the collection at the specified index.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
      /// <param name="strImageKey">The key of the image to display for the item.</param>
      /// <param name="index">The zero-based index location where the item is inserted. </param>
      /// <param name="strText">The text of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
      public ListViewItem Insert(int index, string strText, string strImageKey) => this.Insert(index, new ListViewItem(strText));

      /// <summary>Creates a new item with the specified key, text, and image, and inserts it in the collection at the specified index.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
      /// <param name="intImageIndex">The index of the image to display for the item.</param>
      /// <param name="strKey">The <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Name"></see> of the item.</param>
      /// <param name="intIndex">The zero-based index location where the item is inserted</param>
      /// <param name="strText">The text of the item.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
      public virtual ListViewItem Insert(
        int intIndex,
        string strKey,
        string strText,
        int intImageIndex)
      {
        return this.Insert(intIndex, new ListViewItem(strText, intImageIndex)
        {
          Name = strKey
        });
      }

      /// <summary>Creates a new item with the specified key, text, and image, and adds it to the collection at the specified index.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> added to the collection.</returns>
      /// <param name="strImageKey">The key of the image to display for the item.</param>
      /// <param name="strKey">The <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Name"></see> of the item. </param>
      /// <param name="intIndex">The zero-based index location where the item is inserted.</param>
      /// <param name="strText">The text of the item.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than 0 or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see>. </exception>
      public virtual ListViewItem Insert(
        int intIndex,
        string strKey,
        string strText,
        string strImageKey)
      {
        return this.Insert(intIndex, new ListViewItem(strText, strImageKey)
        {
          Name = strKey
        });
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="index"></param>
      /// <param name="objValue"></param>
      void IList.Insert(int index, object objValue)
      {
        this.mobjList.Insert(index, (ListViewItem) objValue);
        this.OnItemAdded((ListViewItem) objValue);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      void IList.Remove(object objValue)
      {
        if (!(objValue is ListViewItem objListViewItem))
          return;
        this.Remove(objListViewItem);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      public bool Contains(object objValue) => this.mobjList.Contains((ListViewItem) objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      public int IndexOf(object objValue) => this.mobjList.IndexOf((ListViewItem) objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      int IList.Add(object objValue)
      {
        if (objValue is ListViewItem objListViewItem)
        {
          this.Add(objListViewItem);
          this.OnItemAdded(objListViewItem);
        }
        return this.IndexOf(objValue);
      }

      /// <summary>
      /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
      /// </summary>
      /// <value></value>
      /// <returns>true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.
      /// </returns>
      public bool IsFixedSize => false;

      /// <summary>Occurs when [observable item inserted].</summary>
      public event ObservableListEventHandler ObservableItemInserted;

      /// <summary>Occurs when [observable item added].</summary>
      public event ObservableListEventHandler ObservableItemAdded;

      /// <summary>Occurs when [observable list cleared].</summary>
      public event EventHandler ObservableListCleared;

      /// <summary>Occurs when [observable item removed].</summary>
      public event ObservableListEventHandler ObservableItemRemoved;

      /// <summary>
      /// Provides a way to expose group items and list view items using the same
      /// class.
      /// </summary>
      internal interface IInnerList
      {
        ListViewItem Add(ListViewItem objItem);

        void AddRange(ListViewItem[] arrItems);

        void Clear();

        bool Contains(ListViewItem objItem);

        void CopyTo(Array objDestinationArray, int index);

        IEnumerator GetEnumerator();

        int IndexOf(ListViewItem objItem);

        ListViewItem Insert(int index, ListViewItem objItem);

        void Remove(ListViewItem objItem);

        void RemoveAt(int index);

        void Sort();

        int Count { get; }

        ListViewItem this[int index] { get; set; }

        ListView ListView { get; }
      }
    }

    /// <summary>
    /// Represents the collection of column headers in a ListView control.
    /// </summary>
    [Serializable]
    public class ColumnHeaderCollection : ICollection, IEnumerable, IList, IObservableList
    {
      private ListView mobjListView;
      private ArrayList mobjList;
      private ArrayList mobjSortedColumns;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection" /> instance.
      /// </summary>
      public ColumnHeaderCollection(ListView objListView)
      {
        this.mobjListView = objListView;
        this.mobjList = new ArrayList();
      }

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection" /> instance.
      /// </summary>
      internal ColumnHeaderCollection(ListView objListView, object[] arrColumns)
      {
        this.mobjListView = objListView;
        this.mobjList = new ArrayList((ICollection) arrColumns);
      }

      /// <summary>Adds the specified list view column.</summary>
      /// <param name="objListViewColumn">Obj list view column.</param>
      /// <returns></returns>
      public int Add(ColumnHeader objListViewColumn)
      {
        objListViewColumn.InternalParent = (Component) this.mobjListView;
        objListViewColumn.InternalIndex = this.mobjList.Add((object) objListViewColumn);
        if (this.ObservableItemAdded != null)
          this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objListViewColumn));
        if (this.mobjListView != null)
          this.mobjListView.Update();
        this.ClearSortedColumns();
        ColumnHeader columnHeader = objListViewColumn;
        columnHeader.DisplayIndexInternal = columnHeader.Index;
        return objListViewColumn.Index;
      }

      /// <summary>Adds the range.</summary>
      /// <param name="arrColumnHeaders">column headers array.</param>
      public virtual void AddRange(ColumnHeader[] arrColumnHeaders)
      {
        foreach (ColumnHeader arrColumnHeader in arrColumnHeaders)
          this.Add(arrColumnHeader);
      }

      /// <summary>Creates and adds a new list view column.</summary>
      /// <param name="strLabel">Label.</param>
      /// <param name="intWidth">Width.</param>
      /// <param name="enmTextAlign">Text align.</param>
      /// <returns></returns>
      public ColumnHeader Add(string strLabel, int intWidth, HorizontalAlignment enmTextAlign)
      {
        string str = strLabel;
        ColumnHeader objListViewColumn = new ColumnHeader(str, str, intWidth);
        objListViewColumn.TextAlign = enmTextAlign;
        this.Add(objListViewColumn);
        return objListViewColumn;
      }

      /// <summary>Removes the specified list view column.</summary>
      /// <param name="objListViewColumn">list view column.</param>
      public void Remove(ColumnHeader objListViewColumn)
      {
        int displayIndex = objListViewColumn.DisplayIndex;
        if (objListViewColumn.InternalParent == this.mobjListView)
          objListViewColumn.InternalParent = (Component) null;
        this.mobjList.Remove((object) objListViewColumn);
        if (this.mobjListView != null)
          this.mobjListView.Update();
        if (this.ObservableItemRemoved != null)
          this.ObservableItemRemoved((object) this, new ObservableListEventArgs((object) objListViewColumn));
        this.UpdateColumnsIndex();
        this.UpdateDisplayIndex(displayIndex, false);
      }

      /// <summary>Updates the display index.</summary>
      /// <param name="intDisplayIndex">Display index of the int.</param>
      /// <param name="blnAdd">if set to <c>true</c> [BLN add].</param>
      private void UpdateDisplayIndex(int intDisplayIndex, bool blnAdd)
      {
        foreach (ColumnHeader mobj in this.mobjList)
        {
          if (mobj.DisplayIndex > intDisplayIndex)
            mobj.DisplayIndexInternal += blnAdd ? 1 : -1;
        }
        this.ClearSortedColumns();
      }

      /// <summary>Updates the columns index.</summary>
      private void UpdateColumnsIndex()
      {
        int num = 0;
        foreach (ColumnHeader mobj in this.mobjList)
        {
          mobj.InternalIndex = num;
          ++num;
        }
      }

      /// <summary>Clears this instance.</summary>
      public void Clear()
      {
        this.mobjListView.UnRegisterBatch((ICollection) this);
        this.mobjSortedColumns = (ArrayList) null;
        this.mobjList.Clear();
      }

      /// <summary>Clears the sorted columns array list.</summary>
      internal void ClearSortedColumns() => this.mobjSortedColumns = (ArrayList) null;

      /// <summary>Gets the enumerator.</summary>
      /// <returns></returns>
      public IEnumerator GetEnumerator() => this.mobjList.GetEnumerator();

      /// <summary>Copies to.</summary>
      /// <param name="objArray">Array.</param>
      /// <param name="index">Index.</param>
      public void CopyTo(Array objArray, int index) => this.mobjList.CopyTo(objArray, index);

      /// <summary>Updates the listview columns.</summary>
      public void UpdateColumns()
      {
        bool blnValid = true;
        foreach (ColumnHeader mobj in this.mobjList)
        {
          if (mobj.Visible && !mobj.Loaded)
          {
            blnValid = false;
            break;
          }
        }
        this.mobjSortedColumns = (ArrayList) null;
        this.mobjListView.FireUpdateColumns(blnValid);
        this.mobjListView.Update(true);
      }

      /// <summary>
      /// Gets a value indicating whether this instance is synchronized.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
      /// </value>
      public bool IsSynchronized => this.mobjList.IsSynchronized;

      /// <summary>Gets the count.</summary>
      /// <value></value>
      public int Count => this.mobjList.Count;

      /// <summary>Gets the sync root.</summary>
      /// <value></value>
      public object SyncRoot => this.mobjList.SyncRoot;

      /// <summary>Gets the visible columns.</summary>
      /// <value></value>
      public ICollection VisibleColumns
      {
        get
        {
          ArrayList visibleColumns = new ArrayList();
          foreach (ColumnHeader mobj in this.mobjList)
          {
            if (mobj.Visible)
              visibleColumns.Add((object) mobj);
          }
          return (ICollection) visibleColumns;
        }
      }

      /// <summary>Gets the position sorted column list.</summary>
      /// <value></value>
      public ICollection SortedColumns
      {
        get
        {
          if (this.mobjSortedColumns == null)
          {
            this.mobjSortedColumns = new ArrayList((ICollection) this.mobjList);
            this.mobjSortedColumns.Sort();
          }
          return (ICollection) this.mobjSortedColumns;
        }
      }

      /// <summary>
      /// Gets the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> with the specified int index.
      /// </summary>
      /// <value></value>
      public ColumnHeader this[int intIndex] => (ColumnHeader) this.mobjList[intIndex];

      /// <summary>
      /// 
      /// </summary>
      public bool IsReadOnly => false;

      /// <summary>
      /// 
      /// </summary>
      object IList.this[int index]
      {
        get => this.mobjList[index];
        set
        {
          if (this.mobjListView != null)
            this.mobjListView.Update();
          this.mobjList[index] = value;
        }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="index"></param>
      public void RemoveAt(int index)
      {
        if (!(this.mobjList[index] is ColumnHeader mobj))
          return;
        this.Remove(mobj);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="index"></param>
      /// <param name="objValue"></param>
      public void Insert(int index, object objValue)
      {
        if (index < 0 || objValue == null || !(objValue is ColumnHeader objItem))
          return;
        objItem.InternalParent = (Component) this.mobjListView;
        objItem.DisplayIndex = index;
        this.mobjList.Insert(index, (object) objItem);
        foreach (ColumnHeader mobj in this.mobjList)
          mobj.InternalIndex = this.mobjList.IndexOf((object) mobj);
        this.UpdateDisplayIndex(index, true);
        if (this.ObservableItemAdded != null)
          this.ObservableItemAdded((object) this, new ObservableListEventArgs((object) objItem));
        if (this.mobjListView == null)
          return;
        this.mobjListView.Update();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      void IList.Remove(object objValue)
      {
        if (this.mobjListView != null)
          this.mobjListView.Update();
        this.mobjList.Remove(objValue);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      public bool Contains(object objValue) => this.mobjList.Contains(objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      public int IndexOf(object objValue)
      {
        if (this.mobjListView != null)
          this.mobjListView.Update();
        return this.mobjList.IndexOf(objValue);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      int IList.Add(object objValue) => objValue is ColumnHeader ? this.Add((ColumnHeader) objValue) : throw new ArgumentException(SR.GetString("ColumnHeaderCollectionInvalidArgument"));

      /// <summary>
      /// 
      /// </summary>
      public bool IsFixedSize => false;

      /// <summary>Occurs when [observable item inserted].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemInserted;

      /// <summary>Occurs when [observable item added].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemAdded;

      /// <summary>Occurs when [observable list cleared].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event EventHandler ObservableListCleared;

      /// <summary>Occurs when [observable item removed].</summary>
      [Browsable(false)]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public event ObservableListEventHandler ObservableItemRemoved;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SelectedListViewItemCollection : ICollection, IEnumerable, IList
    {
      private ArrayList mobjItems;
      private ListView mobjListView;

      /// <summary>
      /// 
      /// </summary>
      bool ICollection.IsSynchronized => this.mobjItems.IsSynchronized;

      /// <summary>
      /// 
      /// </summary>
      public int Count => this.mobjItems.Count;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objArray"></param>
      /// <param name="index"></param>
      public void CopyTo(Array objArray, int index) => this.mobjItems.CopyTo(objArray, index);

      /// <summary>
      /// 
      /// </summary>
      object ICollection.SyncRoot => this.mobjItems.SyncRoot;

      /// <summary>
      /// 
      /// </summary>
      public IEnumerator GetEnumerator() => this.mobjItems.GetEnumerator();

      /// <summary>
      /// 
      /// </summary>
      public bool IsReadOnly => true;

      /// <summary>
      /// 
      /// </summary>
      public ListViewItem this[int index] => (ListViewItem) this.mobjItems[index];

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objListViewItem"></param>
      public bool Contains(ListViewItem objListViewItem) => this.mobjItems.Contains((object) objListViewItem);

      /// <summary>
      /// 
      /// </summary>
      void IList.Clear() => this.Clear();

      /// <summary>
      /// Removes all items from the <see cref="T:System.Collections.IList" />.
      /// </summary>
      /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList" /> is read-only. </exception>
      public void Clear()
      {
        if (this.mobjItems == null)
          return;
        foreach (ListViewItem mobjItem in this.mobjItems)
          mobjItem.Selected = false;
        this.mobjItems.Clear();
        if (this.mobjListView == null)
          return;
        this.mobjListView.Update();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objListViewItem"></param>
      public int IndexOf(ListViewItem objListViewItem) => this.mobjItems.IndexOf((object) objListViewItem);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      int IList.Add(object objValue) => throw new NotSupportedException();

      /// <summary>
      /// 
      /// </summary>
      bool IList.IsFixedSize => true;

      /// <summary>
      /// 
      /// </summary>
      object IList.this[int index]
      {
        get => this.mobjItems[index];
        set => throw new NotSupportedException();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="index"></param>
      void IList.RemoveAt(int index) => throw new NotSupportedException();

      /// <summary>
      /// 
      /// </summary>
      /// <param name="index"></param>
      /// <param name="objValue"></param>
      void IList.Insert(int index, object objValue) => throw new NotSupportedException();

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      void IList.Remove(object objValue) => throw new NotSupportedException();

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      bool IList.Contains(object objValue) => this.mobjItems.Contains(objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      int IList.IndexOf(object objValue) => this.mobjItems.IndexOf(objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objListView"></param>
      public SelectedListViewItemCollection(ListView objListView)
      {
        this.mobjListView = objListView;
        this.mobjItems = new ArrayList();
        foreach (ListViewItem listViewItem in objListView.Items)
        {
          if (listViewItem.Selected)
            this.mobjItems.Add((object) listViewItem);
        }
      }
    }

    /// <summary>Provides item processing base implementation</summary>
    internal abstract class ItemProcessor
    {
      /// <summary>Processes the item.</summary>
      /// <param name="objItem">The item.</param>
      internal abstract void ProcessItem(ListViewItem objItem);

      /// <summary>Processes the group.</summary>
      /// <param name="objGroup">The group.</param>
      internal abstract void ProcessGroup(ListViewGroup objGroup);

      /// <summary>
      /// Gets a value indicating whether processing is still needed.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if processing is still needed; otherwise, <c>false</c>.
      /// </value>
      internal virtual bool IsProcessingStillNeeded => true;
    }

    /// <summary>Provides support for rendering items</summary>
    internal class ItemRenderingProcessor : ListView.ItemProcessor
    {
      /// <summary>The owner listview</summary>
      private readonly ListView mobjListView;
      /// <summary>The current context</summary>
      private readonly IContext mobjContext;
      /// <summary>The current response writer</summary>
      private readonly IResponseWriter mobjWriter;
      /// <summary>The current request ID.</summary>
      private readonly long mlngRequestID;
      /// <summary>
      /// 
      /// </summary>
      private readonly View menmView;
      /// <summary>
      /// 
      /// </summary>
      private readonly bool mblnShowItemToolTips;
      /// <summary>
      /// 
      /// </summary>
      private readonly ICollection mobjSortedColumns;
      /// <summary>
      /// 
      /// </summary>
      private readonly bool mblnFullListRedraw;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemRenderingProcessor" /> class.
      /// </summary>
      /// <param name="objListView">The list view.</param>
      /// <param name="objContext">The context.</param>
      /// <param name="objWriter">The writer.</param>
      /// <param name="lngRequestID">The request ID.</param>
      public ItemRenderingProcessor(
        ListView objListView,
        IContext objContext,
        IResponseWriter objWriter,
        long lngRequestID,
        bool blnFullListRedraw)
      {
        this.mobjListView = objListView;
        this.mobjContext = objContext;
        this.mobjWriter = objWriter;
        this.mlngRequestID = lngRequestID;
        this.menmView = objListView.View;
        this.mblnShowItemToolTips = objListView.ShowItemToolTips;
        this.mobjSortedColumns = objListView.Columns.SortedColumns;
        this.mblnFullListRedraw = blnFullListRedraw;
      }

      /// <summary>Processes the item.</summary>
      /// <param name="objItem">The item.</param>
      internal override void ProcessItem(ListViewItem objItem) => objItem.RenderItem(this.mobjContext, this.mobjWriter, this.mlngRequestID, this);

      /// <summary>Processes the group.</summary>
      /// <param name="objGroup">The group.</param>
      internal override void ProcessGroup(ListViewGroup objGroup) => this.mobjListView.RenderGroup(this.mobjContext, this.mobjWriter, objGroup, this);

      /// <summary>Gets a value indicating whether in full list redraw.</summary>
      /// <value><c>true</c> if in full list redraw; otherwise, <c>false</c>.</value>
      public bool FullListRedraw => this.mblnFullListRedraw;

      /// <summary>Gets the list view.</summary>
      /// <value>The list view.</value>
      public ListView ListView => this.mobjListView;

      /// <summary>Gets the view.</summary>
      /// <value>The view.</value>
      public View View => this.menmView;

      /// <summary>
      /// Gets a value indicating whether to show item tooltips.
      /// </summary>
      /// <value><c>true</c> if to show item tool tips; otherwise, <c>false</c>.</value>
      public bool ShowItemToolTips => this.mblnShowItemToolTips;

      /// <summary>Gets the sorted columns.</summary>
      /// <value>The sorted columns.</value>
      public ICollection SortedColumns => this.mobjSortedColumns;

      /// <summary>Called when item is formatted.</summary>
      /// <param name="intItemIndex">The item index.</param>
      /// <param name="intColumnIndex">The column index.</param>
      /// <param name="objSubItem">The sub item.</param>
      internal void OnItemFormatting(
        int intItemIndex,
        int intColumnIndex,
        ListViewItem.ListViewSubItem objSubItem)
      {
        this.mobjListView.OnItemFormatting(intItemIndex, intColumnIndex, objSubItem);
      }
    }

    /// <summary>
    /// Provides support for get layout information on the current listview status
    /// </summary>
    internal class ItemLayoutProcessor : ListView.ItemProcessor
    {
      /// <summary>
      /// 
      /// </summary>
      private Point mobjItemLocation = Point.Empty;
      /// <summary>
      /// 
      /// </summary>
      private ListViewItem mobjItem;
      /// <summary>
      /// 
      /// </summary>
      private ListViewSkin mobjOwnerSkin;
      /// <summary>
      /// 
      /// </summary>
      private Size mobjOwnerSize = Size.Empty;
      /// <summary>
      /// 
      /// </summary>
      private ListView mobjListView;
      /// <summary>
      /// 
      /// </summary>
      private Point mobjCurrentPosition = Point.Empty;
      /// <summary>
      /// 
      /// </summary>
      private bool mblnIsProcessingStillNeeded = true;
      /// <summary>
      /// 
      /// </summary>
      private int mintLastLineHeight;
      /// <summary>
      /// 
      /// </summary>
      private readonly ListView.ItemLayoutProcessor.SearchType menmSearchType;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemLayoutProcessor" /> class.
      /// </summary>
      /// <param name="objListView">The list view.</param>
      /// <param name="objItem">The list view item.</param>
      /// <param name="objSize">The list view size.</param>
      internal ItemLayoutProcessor(ListView objListView, ListViewItem objItem)
      {
        this.mobjItem = objItem;
        this.mobjOwnerSize = objListView.Size;
        this.mobjOwnerSkin = (ListViewSkin) objListView.Skin;
        this.mobjListView = objListView;
        this.menmSearchType = ListView.ItemLayoutProcessor.SearchType.LocationFromItem;
        this.ProcessHeader();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemLayoutProcessor" /> class.
      /// </summary>
      /// <param name="objListView">The list view.</param>
      /// <param name="objLocation">The mouse location.</param>
      /// <param name="objSize">The list view size.</param>
      internal ItemLayoutProcessor(ListView objListView, Point objLocation)
      {
        this.mobjItemLocation = objLocation;
        this.mobjOwnerSkin = (ListViewSkin) objListView.Skin;
        this.mobjOwnerSize = objListView.Size;
        this.mobjListView = objListView;
        this.menmSearchType = ListView.ItemLayoutProcessor.SearchType.ItemFromLocation;
        this.ProcessHeader();
      }

      /// <summary>Processes the header.</summary>
      private void ProcessHeader()
      {
        if (!this.IsHeaderVisible)
          return;
        Rectangle objItemRectangle = new Rectangle(this.CurrentPosition, new Size(this.OwnerWidth, this.mobjListView.GetPreferdItemFontHeight(true)));
        this.AddItemRectangleToPosition(objItemRectangle);
        if (!this.IsItemFromLocationSearch || !objItemRectangle.Contains(this.ItemLocation))
          return;
        this.SetFoundItemAndStopProcessing((ListViewItem) null);
      }

      /// <summary>Processes the item.</summary>
      /// <param name="objItem">The item.</param>
      internal override void ProcessItem(ListViewItem objItem)
      {
        Rectangle objItemRectangle = Rectangle.Empty;
        switch (this.CurrentView)
        {
          case View.Details:
            objItemRectangle = new Rectangle(this.CurrentPosition, new Size(this.OwnerWidth, this.mobjListView.GetPreferdItemFontHeight(false)));
            break;
          case View.LargeIcon:
            objItemRectangle = new Rectangle(this.CurrentPosition, this.OwnerSkin.GetItemSizeForView(View.LargeIcon));
            break;
          case View.List:
            objItemRectangle = new Rectangle(this.CurrentPosition, this.OwnerSkin.GetItemSizeForView(View.List));
            break;
          case View.SmallIcon:
            objItemRectangle = new Rectangle(this.CurrentPosition, this.OwnerSkin.GetItemSizeForView(View.SmallIcon));
            break;
        }
        if (!(objItemRectangle != Rectangle.Empty))
          return;
        if (this.IsItemFromLocationSearch)
        {
          if (objItemRectangle.Contains(this.ItemLocation))
            this.SetFoundItemAndStopProcessing(objItem);
        }
        else if (this.IsLocationFromItemSearch && this.IsItemSearchTarget(objItem))
          this.SetFoundItemLocationAndStopProcessing(objItemRectangle.Location);
        this.AddItemRectangleToPosition(objItemRectangle);
      }

      /// <summary>Processes the group.</summary>
      /// <param name="objGroup">The group.</param>
      internal override void ProcessGroup(ListViewGroup objGroup) => this.AddItemRectangleToPosition(new Rectangle(this.CurrentPosition, new Size(this.OwnerWidth, this.mobjListView.GetPreferdItemFontHeight(false))));

      /// <summary>Stops the processing.</summary>
      private void StopProcessing() => this.mblnIsProcessingStillNeeded = false;

      /// <summary>Sets the found item and stop processing.</summary>
      /// <param name="objItem">The found item.</param>
      private void SetFoundItemAndStopProcessing(ListViewItem objItem)
      {
        this.Item = objItem;
        this.StopProcessing();
      }

      /// <summary>Sets the found item location and stop processing.</summary>
      /// <param name="objItemLocation">The found item location.</param>
      private void SetFoundItemLocationAndStopProcessing(Point objItemLocation)
      {
        this.ItemLocation = objItemLocation;
        this.StopProcessing();
      }

      /// <summary>Indicates if this is the item we are searching for</summary>
      /// <param name="objItem"></param>
      /// <returns></returns>
      private bool IsItemSearchTarget(ListViewItem objItem) => this.Item == objItem;

      /// <summary>Adds the item rectangle to position.</summary>
      /// <param name="objItemRectangle">The item rectangle.</param>
      private void AddItemRectangleToPosition(Rectangle objItemRectangle)
      {
        if (this.OwnerWidth < this.CurrentPosition.X + objItemRectangle.Width)
        {
          this.AddToYPosition(this.mintLastLineHeight);
          this.mintLastLineHeight = 0;
          this.ResetXPosition();
        }
        if (this.OwnerWidth <= objItemRectangle.Width)
        {
          this.AddToYPosition(objItemRectangle.Height);
          this.mintLastLineHeight = 0;
          this.ResetXPosition();
        }
        else
        {
          this.mintLastLineHeight = Math.Max(this.mintLastLineHeight, objItemRectangle.Height);
          this.AddToXPosition(objItemRectangle.Width);
        }
      }

      /// <summary>Resets the X position.</summary>
      private void ResetXPosition() => this.mobjCurrentPosition = new Point(0, this.CurrentPosition.Y);

      /// <summary>Adds to Y position.</summary>
      /// <param name="intOffsetY">The offset Y.</param>
      private void AddToYPosition(int intOffsetY)
      {
        Point currentPosition = this.CurrentPosition;
        int x = currentPosition.X;
        currentPosition = this.CurrentPosition;
        int y = currentPosition.Y + intOffsetY;
        this.mobjCurrentPosition = new Point(x, y);
      }

      /// <summary>Adds to X position.</summary>
      /// <param name="intOffsetX">The offset X.</param>
      private void AddToXPosition(int intOffsetX)
      {
        Point currentPosition = this.CurrentPosition;
        int x = currentPosition.X + intOffsetX;
        currentPosition = this.CurrentPosition;
        int y = currentPosition.Y;
        this.mobjCurrentPosition = new Point(x, y);
      }

      /// <summary>Adds to XY position.</summary>
      /// <param name="intOffsetX">The offset X.</param>
      /// <param name="intOffsetY">The offset Y.</param>
      private void AddToXYPosition(int intOffsetX, int intOffsetY)
      {
        Point currentPosition = this.CurrentPosition;
        int x = currentPosition.X + intOffsetX;
        currentPosition = this.CurrentPosition;
        int y = currentPosition.Y + intOffsetY;
        this.mobjCurrentPosition = new Point(x, y);
      }

      /// <summary>If the location y is with in the y position range</summary>
      /// <param name="objLocation"></param>
      /// <returns></returns>
      private bool IsYInPositionRange(Point objLocation) => this.mobjCurrentPosition.Y >= objLocation.Y;

      /// <summary>If the location x is with in the x position range</summary>
      /// <param name="objLocation"></param>
      /// <returns></returns>
      private bool IsXInPositionRange(Point objLocation) => this.mobjCurrentPosition.X >= objLocation.X;

      /// <summary>If the location xy is with in the xy position range</summary>
      /// <param name="objLocation"></param>
      /// <returns></returns>
      private bool IsXYInPositionRange(Point objLocation) => this.IsXInPositionRange(objLocation) && this.IsYInPositionRange(objLocation);

      /// <summary>
      /// Gets a value indicating whether this instance is item from location search.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is item from location search; otherwise, <c>false</c>.
      /// </value>
      private bool IsItemFromLocationSearch => this.menmSearchType == ListView.ItemLayoutProcessor.SearchType.ItemFromLocation;

      /// <summary>
      /// Gets a value indicating whether this instance is location from item search.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is location from item search; otherwise, <c>false</c>.
      /// </value>
      private bool IsLocationFromItemSearch => this.menmSearchType == ListView.ItemLayoutProcessor.SearchType.LocationFromItem;

      /// <summary>
      /// Gets a value indicating whether this instance is header visible.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is header visible; otherwise, <c>false</c>.
      /// </value>
      private bool IsHeaderVisible => this.CurrentView == View.Details && this.mobjListView.HeaderStyle != 0;

      /// <summary>Gets the current view.</summary>
      /// <value>The current view.</value>
      private View CurrentView => this.mobjListView.View;

      /// <summary>Gets the current position.</summary>
      /// <value>The current position.</value>
      private Point CurrentPosition => this.mobjCurrentPosition;

      /// <summary>
      /// Gets a value indicating whether processing is still needed.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if processing is still needed; otherwise, <c>false</c>.
      /// </value>
      internal override bool IsProcessingStillNeeded => this.mblnIsProcessingStillNeeded;

      /// <summary>Gets the item.</summary>
      /// <value>The item.</value>
      public ListViewItem Item
      {
        get => this.mobjItem;
        private set => this.mobjItem = value;
      }

      /// <summary>Gets the location.</summary>
      /// <value>The location.</value>
      public Point ItemLocation
      {
        get => this.mobjItemLocation;
        private set => this.mobjItemLocation = value;
      }

      /// <summary>Gets the owner skin.</summary>
      /// <value>The owner skin.</value>
      private ListViewSkin OwnerSkin => this.mobjOwnerSkin;

      /// <summary>Gets the size of the owner.</summary>
      /// <value>The size of the owner.</value>
      private Size OwnerSize => this.mobjOwnerSize;

      /// <summary>Gets the height of the owner.</summary>
      /// <value>The height of the owner.</value>
      private int OwnerHeight => this.OwnerSize.Height;

      /// <summary>Gets the width of the owner.</summary>
      /// <value>The width of the owner.</value>
      private int OwnerWidth => this.OwnerSize.Width;

      /// <summary>
      /// 
      /// </summary>
      private enum SearchType
      {
        /// <summary>
        /// 
        /// </summary>
        ItemFromLocation,
        /// <summary>
        /// 
        /// </summary>
        LocationFromItem,
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class ItemPreRenderingProcessor : ListView.ItemProcessor
    {
      /// <summary>The owner listview</summary>
      private readonly ListView mobjListView;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListView.ItemPreRenderingProcessor" /> class.
      /// </summary>
      /// <param name="objListView">The obj list view.</param>
      internal ItemPreRenderingProcessor(ListView objListView) => this.mobjListView = objListView;

      /// <summary>Processes the item.</summary>
      /// <param name="objItem">The item.</param>
      internal override void ProcessItem(ListViewItem objItem)
      {
        if (this.mobjListView == null)
          return;
        if (this.mobjListView.View == View.Details)
        {
          ListViewItem.ListViewSubItemCollection subItems = objItem.SubItems;
          if (subItems == null)
            return;
          foreach (ColumnHeader column in this.mobjListView.Columns)
          {
            if (column.IsValidColumn && subItems.Count > column.Index)
            {
              ListViewItem.ListViewSubItem objSubItem = subItems[column.Index];
              if (!objItem.UseItemStyleForSubItems || column.Index == 0)
                this.mobjListView.OnItemFormatting(objItem.Index, column.Index, objSubItem);
            }
          }
        }
        else
        {
          if (objItem.SubItems.Count <= 0)
            return;
          this.mobjListView.OnItemFormatting(objItem.Index, 0, objItem.SubItems[0]);
        }
      }

      /// <summary>Processes the group.</summary>
      /// <param name="objGroup">The group.</param>
      internal override void ProcessGroup(ListViewGroup objGroup)
      {
      }
    }
  }
}

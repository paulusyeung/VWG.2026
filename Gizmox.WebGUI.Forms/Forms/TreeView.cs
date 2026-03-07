// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeView
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for TreeView.</summary>
  [DefaultEvent("AfterSelect")]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (TreeView), "TreeView_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TreeViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Designer("Gizmox.WebGUI.Forms.Design.TreeViewDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("TV")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (TreeViewSkin))]
  [ProxyComponent(typeof (ProxyTreeView))]
  [Serializable]
  public class TreeView : Control
  {
    /// <summary>Provides a property reference to CheckBoxes property.</summary>
    private static SerializableProperty CheckBoxesProperty = SerializableProperty.Register(nameof (CheckBoxes), typeof (bool), typeof (TreeView), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to EditNode property.</summary>
    private static SerializableProperty EditNodeProperty = SerializableProperty.Register(nameof (EditNode), typeof (TreeNode), typeof (TreeView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to FullRowSelect property.
    /// Default value determined at the property get/set.
    /// </summary>
    private static SerializableProperty FullRowSelectProperty = SerializableProperty.Register(nameof (FullRowSelect), typeof (bool), typeof (TreeView));
    /// <summary>Provides a property reference to ImageIndex property.</summary>
    private static SerializableProperty ImageIndexProperty = SerializableProperty.Register(nameof (ImageIndex), typeof (int), typeof (TreeView), new SerializablePropertyMetadata((object) -1));
    /// <summary>Provides a property reference to ImageKey property.</summary>
    private static SerializableProperty ImageKeyProperty = SerializableProperty.Register(nameof (ImageKey), typeof (string), typeof (TreeView), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to ImageList property.</summary>
    private static SerializableProperty ImageListProperty = SerializableProperty.Register(nameof (ImageList), typeof (ImageList), typeof (TreeView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to PathSeparator property.
    /// </summary>
    private static SerializableProperty PathSeparatorProperty = SerializableProperty.Register(nameof (PathSeparator), typeof (string), typeof (TreeView), new SerializablePropertyMetadata((object) "\\"));
    /// <summary>
    /// Provides a property reference to SelectedImageIndex property.
    /// </summary>
    private static SerializableProperty SelectedImageIndexProperty = SerializableProperty.Register(nameof (SelectedImageIndex), typeof (int), typeof (TreeView), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to SelectedImageKey property.
    /// </summary>
    private static SerializableProperty SelectedImageKeyProperty = SerializableProperty.Register(nameof (SelectedImageKey), typeof (string), typeof (TreeView), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>
    /// Provides a property reference to SelectedNode property.
    /// </summary>
    private static SerializableProperty SelectedNodeProperty = SerializableProperty.Register(nameof (SelectedNode), typeof (TreeNode), typeof (TreeView), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to ShowLines property.</summary>
    private static SerializableProperty ShowLinesProperty = SerializableProperty.Register(nameof (ShowLines), typeof (bool), typeof (TreeView), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to ShowPlusMinus property.
    /// </summary>
    private static SerializableProperty ShowPlusMinusProperty = SerializableProperty.Register(nameof (ShowPlusMinus), typeof (bool), typeof (TreeView), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to Sorted property.</summary>
    private static SerializableProperty SortedProperty = SerializableProperty.Register(nameof (Sorted), typeof (bool), typeof (TreeView), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to StateImageList property.
    /// </summary>
    private static SerializableProperty StateImageListProperty = SerializableProperty.Register(nameof (StateImageList), typeof (ImageList), typeof (TreeView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to TreeViewNodeSorter property.
    /// </summary>
    private static SerializableProperty TreeViewNodeSorterProperty = SerializableProperty.Register(nameof (TreeViewNodeSorter), typeof (IComparer), typeof (TreeView), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to ExpandedImageIndex property.
    /// </summary>
    private static SerializableProperty ExpandedImageIndexProperty = SerializableProperty.Register(nameof (ExpandedImageIndex), typeof (int), typeof (TreeView), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to ExpandedImageKey property.
    /// </summary>
    private static SerializableProperty ExpandedImageKeyProperty = SerializableProperty.Register(nameof (ExpandedImageKey), typeof (string), typeof (TreeView), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>
    /// Provides a property reference to SelectOnRightClick property.
    /// </summary>
    private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register(nameof (SelectOnRightClick), typeof (bool), typeof (TreeView), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to Indent property.</summary>
    private static SerializableProperty IndentProperty = SerializableProperty.Register(nameof (Indent), typeof (int), typeof (TreeView));
    /// <summary>
    /// Provides a property reference to HotTracking property.
    /// </summary>
    private static SerializableProperty HotTrackingProperty = SerializableProperty.Register(nameof (HotTracking), typeof (bool), typeof (TreeView), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to Scrollable property.</summary>
    private static SerializableProperty ScrollableProperty = SerializableProperty.Register(nameof (Scrollable), typeof (bool), typeof (TreeView), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to ItemHeight property.</summary>
    private static SerializableProperty ItemHeightProperty = SerializableProperty.Register(nameof (ItemHeight), typeof (int), typeof (TreeView), new SerializablePropertyMetadata((object) -1));
    /// <summary>The NodeMouseClick event registration.</summary>
    internal static readonly SerializableEvent NodeMouseClickEvent = SerializableEvent.Register("NodeMouseClick", typeof (TreeNodeMouseClickEventHandler), typeof (TreeView));
    /// <summary>The NodeMouseDoubleClick event registration.</summary>
    internal static readonly SerializableEvent NodeMouseDoubleClickEvent = SerializableEvent.Register("NodeMouseDoubleClick", typeof (TreeNodeMouseClickEventHandler), typeof (TreeView));
    /// <summary>The BeforeSelect event registration.</summary>
    private static readonly SerializableEvent BeforeSelectEvent = SerializableEvent.Register("BeforeSelect", typeof (TreeViewCancelEventHandler), typeof (TreeView));
    /// <summary>The AfterSelect event registration.</summary>
    internal static readonly SerializableEvent AfterSelectEvent = SerializableEvent.Register("AfterSelect", typeof (TreeViewEventHandler), typeof (TreeView));
    /// <summary>The AfterLabelEdit event registration.</summary>
    internal static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof (NodeLabelEditEventHandler), typeof (TreeView));
    /// <summary>The BeforeLabelEdit event registration.</summary>
    private static readonly SerializableEvent BeforeLabelEditEvent = SerializableEvent.Register("BeforeLabelEdit", typeof (NodeLabelEditEventHandler), typeof (TreeView));
    /// <summary>The BeforeExpand event registration.</summary>
    private static readonly SerializableEvent BeforeExpandEvent = SerializableEvent.Register("BeforeExpand", typeof (TreeViewCancelEventHandler), typeof (TreeView));
    /// <summary>The BeforeCheck event registration.</summary>
    private static readonly SerializableEvent BeforeCheckEvent = SerializableEvent.Register("BeforeCheck", typeof (TreeViewCancelEventHandler), typeof (TreeView));
    /// <summary>The BeforeCollapse event registration.</summary>
    private static readonly SerializableEvent BeforeCollapseEvent = SerializableEvent.Register("BeforeCollapse", typeof (TreeViewCancelEventHandler), typeof (TreeView));
    /// <summary>The AfterCheck event registration.</summary>
    private static readonly SerializableEvent AfterCheckEvent = SerializableEvent.Register("AfterCheck", typeof (TreeViewEventHandler), typeof (TreeView));
    /// <summary>The AfterExpand event registration.</summary>
    private static readonly SerializableEvent AfterExpandEvent = SerializableEvent.Register("AfterExpand", typeof (TreeViewEventHandler), typeof (TreeView));
    /// <summary>The AfterCollapse event registration.</summary>
    private static readonly SerializableEvent AfterCollapseEvent = SerializableEvent.Register("AfterCollapse", typeof (TreeViewEventHandler), typeof (TreeView));
    /// <summary>The tree nodes collection</summary>
    [NonSerialized]
    private TreeNodeCollection mobjNodes;
    /// <summary>The ItemDrag event registration.</summary>
    private static readonly SerializableEvent ItemDragEvent = SerializableEvent.Register("ItemDrag", typeof (ItemDragEventHandler), typeof (TreeView));

    /// <summary>Occurs when the user clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse. </summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("TreeViewNodeMouseClickDescr")]
    [SRCategory("CatBehavior")]
    public event TreeNodeMouseClickEventHandler NodeMouseClick
    {
      add => this.AddCriticalHandler(TreeView.NodeMouseClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.NodeMouseClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the NodeMouseClick event.</summary>
    internal TreeNodeMouseClickEventHandler NodeMouseClickHandler => (TreeNodeMouseClickEventHandler) this.GetHandler(TreeView.NodeMouseClickEvent);

    /// <summary>Occurs when the user double-clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewNodeMouseDoubleClickDescr")]
    public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick
    {
      add => this.AddCriticalHandler(TreeView.NodeMouseDoubleClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.NodeMouseDoubleClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the NodeMouseDoubleClick event.</summary>
    internal TreeNodeMouseClickEventHandler NodeMouseDoubleClickHandler => (TreeNodeMouseClickEventHandler) this.GetHandler(TreeView.NodeMouseDoubleClickEvent);

    /// <summary>Occurs before the tree node is selected.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewBeforeSelectDescr")]
    public event TreeViewCancelEventHandler BeforeSelect
    {
      add => this.AddHandler(TreeView.BeforeSelectEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeView.BeforeSelectEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeSelect event.</summary>
    private TreeViewCancelEventHandler BeforeSelectHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeView.BeforeSelectEvent);

    /// <summary>Occurs after the tree node is selected.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterSelectDescr")]
    public event TreeViewEventHandler AfterSelect
    {
      add => this.AddCriticalHandler(TreeView.AfterSelectEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.AfterSelectEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterSelect event.</summary>
    private TreeViewEventHandler AfterSelectHandler => (TreeViewEventHandler) this.GetHandler(TreeView.AfterSelectEvent);

    /// <summary>Occurs after the tree node label text is edited.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterEditDescr")]
    public event NodeLabelEditEventHandler AfterLabelEdit
    {
      add => this.AddCriticalHandler(TreeView.AfterLabelEditEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.AfterLabelEditEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterLabelEdit event.</summary>
    private NodeLabelEditEventHandler AfterLabelEditHandler => (NodeLabelEditEventHandler) this.GetHandler(TreeView.AfterLabelEditEvent);

    /// <summary>Occurs before the tree node label text is edited.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("TreeViewBeforeEditDescr")]
    [SRCategory("CatBehavior")]
    public event NodeLabelEditEventHandler BeforeLabelEdit
    {
      add => this.AddHandler(TreeView.BeforeLabelEditEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeView.BeforeLabelEditEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeLabelEdit event.</summary>
    private NodeLabelEditEventHandler BeforeLabelEditHandler => (NodeLabelEditEventHandler) this.GetHandler(TreeView.BeforeLabelEditEvent);

    /// <summary>Occurs before the tree node is expanded.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("TreeViewBeforeExpandDescr")]
    [SRCategory("CatBehavior")]
    public event TreeViewCancelEventHandler BeforeExpand
    {
      add => this.AddCriticalHandler(TreeView.BeforeExpandEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.BeforeExpandEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeExpand event.</summary>
    private TreeViewCancelEventHandler BeforeExpandHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeView.BeforeExpandEvent);

    /// <summary>Occurs before the tree node check box is checked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("TreeViewBeforeCheckDescr")]
    [SRCategory("CatBehavior")]
    public event TreeViewCancelEventHandler BeforeCheck
    {
      add => this.AddCriticalHandler(TreeView.BeforeCheckEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.BeforeCheckEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeCheck event.</summary>
    private TreeViewCancelEventHandler BeforeCheckHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeView.BeforeCheckEvent);

    /// <summary>Occurs before the tree node is collapsed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewBeforeCollapseDescr")]
    public event TreeViewCancelEventHandler BeforeCollapse
    {
      add => this.AddCriticalHandler(TreeView.BeforeCollapseEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.BeforeCollapseEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeCollapse event.</summary>
    private TreeViewCancelEventHandler BeforeCollapseHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeView.BeforeCollapseEvent);

    /// <summary>Occurs after the tree node check box is checked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("TreeViewAfterCheckDescr")]
    [SRCategory("CatBehavior")]
    public event TreeViewEventHandler AfterCheck
    {
      add => this.AddCriticalHandler(TreeView.AfterCheckEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.AfterCheckEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterCheck event.</summary>
    private TreeViewEventHandler AfterCheckHandler => (TreeViewEventHandler) this.GetHandler(TreeView.AfterCheckEvent);

    /// <summary>Occurs after the tree node is expanded.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterExpandDescr")]
    public event TreeViewEventHandler AfterExpand
    {
      add => this.AddCriticalHandler(TreeView.AfterExpandEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.AfterExpandEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterExpand event.</summary>
    private TreeViewEventHandler AfterExpandHandler => (TreeViewEventHandler) this.GetHandler(TreeView.AfterExpandEvent);

    /// <summary>Occurs after the tree node is collapsed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterCollapseDescr")]
    public event TreeViewEventHandler AfterCollapse
    {
      add => this.AddCriticalHandler(TreeView.AfterCollapseEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TreeView.AfterCollapseEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterCollapse event.</summary>
    private TreeViewEventHandler AfterCollapseHandler => (TreeViewEventHandler) this.GetHandler(TreeView.AfterCollapseEvent);

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.TreeView" /> instance.
    /// </summary>
    public TreeView()
    {
      this.mobjNodes = this.CreateNodeCollection();
      this.SetStyle(ControlStyles.UserPaint, false);
      this.SetStyle(ControlStyles.StandardClick, false);
      this.SetStyle(ControlStyles.UseTextForAccessibility, false);
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjNodes);

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mobjNodes = this.CreateNodeCollection(objReader.ReadArray());
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteArray((ICollection) this.mobjNodes);
    }

    /// <summary>Occurs when the user begins dragging a node.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAction")]
    [SRDescription("ListViewItemDragDescr")]
    public event ItemDragEventHandler ItemDrag
    {
      add => this.AddHandler(TreeView.ItemDragEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeView.ItemDragEvent, (Delegate) value);
    }

    /// <summary>Gets the item drag handler.</summary>
    /// <value>The item drag handler.</value>
    internal ItemDragEventHandler ItemDragHandler => (ItemDragEventHandler) this.GetHandler(TreeView.ItemDragEvent);

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.AfterCheckHandler != null || this.BeforeCheckHandler != null)
        criticalEventsData.Set("CC");
      if (this.AfterCollapseHandler != null)
        criticalEventsData.Set("COL");
      if (this.AfterExpandHandler != null)
        criticalEventsData.Set("EXP");
      if (this.BeforeCollapseHandler != null)
        criticalEventsData.Set("COL");
      if (this.BeforeExpandHandler != null)
        criticalEventsData.Set("EXP");
      if (this.AfterLabelEditHandler != null)
        criticalEventsData.Set("ALE");
      if (this.AfterSelectHandler != null || this.BeforeSelectHandler != null)
        criticalEventsData.Set("SLC");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("Selection"))
        clientEventsData.Set("SLC");
      if (this.HasClientHandler("Expand"))
        clientEventsData.Set("EXP");
      if (this.HasClientHandler("Collapse"))
        clientEventsData.Set("COL");
      if (this.HasClientHandler("CheckedChange"))
        clientEventsData.Set("CC");
      return clientEventsData;
    }

    /// <summary>Occurs when [client after select].</summary>
    [SRDescription("Occurs when control selection changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientAfterSelect
    {
      add => this.AddClientHandler("Selection", value);
      remove => this.RemoveClientHandler("Selection", value);
    }

    /// <summary>Occurs when [client node mouse click].</summary>
    [SRDescription("Occurs when control's node clicked in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientNodeMouseClick
    {
      add => this.AddClientHandler("Click", value);
      remove => this.RemoveClientHandler("Click", value);
    }

    /// <summary>Occurs when [client node mouse double click].</summary>
    [SRDescription("Occurs when control's node double-clicked in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientNodeMouseDoubleClick
    {
      add => this.AddClientHandler("DoubleClick", value);
      remove => this.RemoveClientHandler("DoubleClick", value);
    }

    /// <summary>Occurs when [client after expand].</summary>
    [SRDescription("Occurs when control expanded in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientAfterExpand
    {
      add => this.AddClientHandler("Expand", value);
      remove => this.RemoveClientHandler("Expand", value);
    }

    /// <summary>Occurs when [client after collapse].</summary>
    [SRDescription("Occurs when control collapsed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientAfterCollapse
    {
      add => this.AddClientHandler("Collapse", value);
      remove => this.RemoveClientHandler("Collapse", value);
    }

    /// <summary>Occurs when [client after checked].</summary>
    [SRDescription("Occurs when control checked state changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientAfterCheck
    {
      add => this.AddClientHandler("CheckedChange", value);
      remove => this.RemoveClientHandler("CheckedChange", value);
    }

    /// <summary>
    /// Raises the <see cref="E:AfterCheck" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
    internal void OnAfterCheckInternal(TreeViewEventArgs e) => this.OnAfterCheck(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCheck"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAfterCheck(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterCheckHandler = this.AfterCheckHandler;
      if (afterCheckHandler == null)
        return;
      afterCheckHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ItemDrag" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ItemDragEventArgs" /> instance containing the event data.</param>
    protected virtual void OnItemDrag(ItemDragEventArgs e)
    {
      ItemDragEventHandler itemDragHandler = this.ItemDragHandler;
      if (itemDragHandler == null)
        return;
      itemDragHandler((object) this, e);
    }

    /// <summary>Fires the item drag.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ItemDragEventArgs" /> instance containing the event data.</param>
    internal void FireItemDrag(ItemDragEventArgs e) => this.OnItemDrag(e);

    /// <summary>
    /// Raises the <see cref="E:AfterSelect" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
    internal void OnAfterSelectInternal(TreeViewEventArgs e) => this.OnAfterSelect(e);

    /// <summary>
    /// Raises the <see cref="E:AfterSelect" /> event.
    /// </summary>
    /// <param name="e">
    /// The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.
    /// </param>
    protected virtual void OnAfterSelect(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterSelectHandler = this.AfterSelectHandler;
      if (afterSelectHandler == null)
        return;
      afterSelectHandler((object) this, e);
    }

    /// <summary>Called after node is expanded.</summary>
    /// <param name="e">The event arguments.</param>
    internal void OnAfterExpandInternal(TreeViewEventArgs e) => this.OnAfterExpand(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterExpand"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAfterExpand(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterExpandHandler = this.AfterExpandHandler;
      if (afterExpandHandler == null)
        return;
      afterExpandHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:AfterCollapse" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs" /> instance containing the event data.</param>
    internal void OnAfterCollapseInternal(TreeViewEventArgs e) => this.OnAfterCollapse(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCollapse"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAfterCollapse(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterCollapseHandler = this.AfterCollapseHandler;
      if (afterCollapseHandler == null)
        return;
      afterCollapseHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:BeforeCheck" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
    internal void OnBeforeCheckInternal(TreeViewCancelEventArgs e) => this.OnBeforeCheck(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCheck"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeCheckHandler = this.BeforeCheckHandler;
      if (beforeCheckHandler == null)
        return;
      beforeCheckHandler((object) this, e);
    }

    /// <summary>Called before collapsing node.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
    internal void OnBeforeCollapseInternal(TreeViewCancelEventArgs e) => this.OnBeforeCollapse(e);

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCollapse"></see> event.
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data.</param>
    protected internal virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeCollapseHandler = this.BeforeCollapseHandler;
      if (beforeCollapseHandler == null)
        return;
      beforeCollapseHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterLabelEdit"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAfterLabelEdit(NodeLabelEditEventArgs e)
    {
      NodeLabelEditEventHandler labelEditHandler = this.AfterLabelEditHandler;
      if (labelEditHandler == null)
        return;
      labelEditHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeLabelEdit"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
    {
      NodeLabelEditEventHandler labelEditHandler = this.BeforeLabelEditHandler;
      if (labelEditHandler == null)
        return;
      labelEditHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:AfterLabelEditInternal" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs" /> instance containing the event data.</param>
    internal void OnAfterLabelEditInternal(NodeLabelEditEventArgs e) => this.OnAfterLabelEdit(e);

    /// <summary>
    /// Raises the <see cref="E:BeforeSelect" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
    internal void OnBeforeSelectInternal(TreeViewCancelEventArgs e) => this.OnBeforeSelect(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeSelect"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeSelectHandler = this.BeforeSelectHandler;
      if (beforeSelectHandler == null)
        return;
      beforeSelectHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:NodeMouseClick" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
    internal void OnNodeMouseClickInternal(TreeNodeMouseClickEventArgs e)
    {
      this.OnNodeMouseClick(e);
      this.OnClick((EventArgs) e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
    protected virtual void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
    {
      TreeNodeMouseClickEventHandler mouseClickHandler = this.NodeMouseClickHandler;
      if (mouseClickHandler == null)
        return;
      mouseClickHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:NodeMouseDoubleClick" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
    internal void OnNodeMouseDoubleClickInternal(TreeNodeMouseClickEventArgs e)
    {
      this.OnNodeMouseDoubleClick(e);
      this.OnDoubleClick((EventArgs) e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
    protected virtual void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
    {
      TreeNodeMouseClickEventHandler doubleClickHandler = this.NodeMouseDoubleClickHandler;
      if (doubleClickHandler == null)
        return;
      doubleClickHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:BeforeExpand" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
    internal void OnBeforeExpandIntenral(TreeViewCancelEventArgs e) => this.OnBeforeExpand(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeExpand"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeExpandHandler = this.BeforeExpandHandler;
      if (beforeExpandHandler == null)
        return;
      beforeExpandHandler((object) this, e);
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
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        this.RenderSelectOnRightClick(objWriter, true);
        objWriter.WriteAttributeString("TNCEOT", this.WinFormsCompatibility.IsTreeNodeClickEventsOnToggle ? "1" : "0");
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderItemHeight(objWriter);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderItemHeight(objWriter);
      this.RenderEditingInformation(objContext, objWriter);
      this.RenderSelectOnRightClick(objWriter, false);
      objWriter.WriteAttributeString("TNCEOT", this.WinFormsCompatibility.IsTreeNodeClickEventsOnToggle ? "1" : "0");
    }

    /// <summary>Renders the height of the item.</summary>
    /// <param name="objWriter">The object writer.</param>
    private void RenderItemHeight(IAttributeWriter objWriter)
    {
      int preferdItemHeight = this.GetPreferdItemHeight();
      objWriter.WriteAttributeString("IMH", preferdItemHeight.ToString());
    }

    /// <summary>Gets the height of the preferd item font.</summary>
    /// <returns></returns>
    internal int GetPreferdItemHeight()
    {
      if (this.HasItemHeight || this.HasProxyPropertyValue("ItemHeight"))
        return this.GetProxyPropertyValue<int>("ItemHeight", this.InnerItemHeight);
      int num = 4;
      return CommonUtils.GetFontHeight(this.GetProxyPropertyValue<Font>("Font", this.Font)) + num;
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

    /// <summary>Renders the editing information.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected void RenderEditingInformation(IContext objContext, IAttributeWriter objWriter)
    {
      if (!this.LabelEdit)
        return;
      objWriter.WriteAttributeString("LE", "1");
    }

    /// <summary>Renderes the tree view control</summary>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
      if (this.CheckBoxes)
        objWriter.WriteAttributeString("CB", "1");
      if (!this.ShowPlusMinus)
        objWriter.WriteAttributeString("HP", "1");
      if (this.ShowLines)
        objWriter.WriteAttributeString("SL", "1");
      if (this.CheckBoxes && this.StateImageList != null && this.StateImageList.Images.Count > 1)
      {
        objWriter.WriteAttributeString("TIMU", this.StateImageList.Images[0].ToString());
        objWriter.WriteAttributeString("TIMC", this.StateImageList.Images[1].ToString());
      }
      this.RenderControls(objContext, objWriter, 0L);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      foreach (TreeNode node in (BaseCollection) this.Nodes)
      {
        if (node.Visible)
          node.RenderNode(objContext, objWriter, lngRequestID, this.CheckBoxes ? CheckBoxVisibility.True : CheckBoxVisibility.False);
      }
    }

    /// <summary>Gets the default full row select.</summary>
    private bool DefaultFullRowSelect => this.Skin is TreeViewSkin skin && skin.FullRowSelect;

    /// <summary>Adds a critical event delegate to the list.</summary>
    /// <param name="objSerializableEvent">The serializable event.</param>
    /// <param name="objValue">The delegate to add to the list.</param>
    /// <returns></returns>
    protected override void AddCriticalHandler(
      SerializableEvent objSerializableEvent,
      Delegate objValue)
    {
      if (!this.AddHandler(objSerializableEvent, objValue))
        return;
      this.Update();
    }

    /// <summary>Removes a critical event delegate from the list.</summary>
    /// <param name="objSerializableEvent">The serializable event.</param>
    /// <param name="objValue">The delegate to remove from the list.</param>
    /// <returns></returns>
    protected override void RemoveCriticalHandler(
      SerializableEvent objSerializableEvent,
      Delegate objValue)
    {
      if (!this.RemoveHandler(objSerializableEvent, objValue))
        return;
      this.Update();
    }

    /// <summary>Gets or sets a value indicating whether the selection highlight spans the width of the tree view control.</summary>
    /// <returns>true if the selection highlight spans the width of the tree view control; otherwise, false. The default is false.</returns>
    /// <remarks>Not implemented.</remarks>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewFullRowSelectDescr")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool FullRowSelect
    {
      get => this.GetValue<bool>(TreeView.FullRowSelectProperty, this.DefaultFullRowSelect);
      set
      {
        if (!this.SetValue<bool>(TreeView.FullRowSelectProperty, value, this.DefaultFullRowSelect))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    protected override bool IsDelayedDrawing => true;

    /// <summary>Gets or sets the implementation of <see cref="T:System.Collections.IComparer"></see> to perform a custom sort of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> nodes.</summary>
    /// <returns>The <see cref="T:System.Collections.IComparer"></see> to perform the custom sort.</returns>
    /// <filterpriority>2</filterpriority>
    [Browsable(false)]
    [SRCategory("CatBehavior")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("TreeViewNodeSorterDescr")]
    public IComparer TreeViewNodeSorter
    {
      get => this.GetValue<IComparer>(TreeView.TreeViewNodeSorterProperty);
      set
      {
        if (!this.SetValue<IComparer>(TreeView.TreeViewNodeSorterProperty, value) || value == null)
          return;
        this.Sort();
      }
    }

    /// <summary>Gets or sets a value indicating whether the tree nodes in the tree view are sorted.</summary>
    /// <returns>true if the tree nodes in the tree view are sorted; otherwise, false. The default is false.</returns>
    [SRDescription("TreeViewSortedDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Sorted
    {
      get => this.GetValue<bool>(TreeView.SortedProperty);
      set
      {
        if (!this.SetValue<bool>(TreeView.SortedProperty, value) || !value || this.TreeViewNodeSorter != null || this.Nodes.Count < 1)
          return;
        this.RefreshNodes();
      }
    }

    /// <summary>Gets or sets a value indicating whether the label text of the tree nodes can be edited.</summary>
    /// <returns>true if the label text of the tree nodes can be edited; otherwise, false. The default is false.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewLabelEditDescr")]
    [DefaultValue(false)]
    public bool LabelEdit
    {
      get => this.GetState(Component.ComponentState.ReadOnly);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.ReadOnly, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether [edit node].</summary>
    /// <value>The edit node.</value>
    internal TreeNode EditNode
    {
      get => this.GetValue<TreeNode>(TreeView.EditNodeProperty);
      set => this.SetValue<TreeNode>(TreeView.EditNodeProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [hide selection].
    /// </summary>
    /// <value><c>true</c> if [hide selection]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public bool HideSelection
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    [SRDescription("TreeViewImageListDescr")]
    [SRCategory("CatBehavior")]
    public ImageList ImageList
    {
      get => this.GetValue<ImageList>(TreeView.ImageListProperty);
      set
      {
        if (!this.SetValue<ImageList>(TreeView.ImageListProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the image list used for indicating the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> and its nodes.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> used for indicating the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> and its nodes.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewStateImageListDescr")]
    [DefaultValue(null)]
    public ImageList StateImageList
    {
      get => this.GetValue<ImageList>(TreeView.StateImageListProperty);
      set
      {
        if (!this.SetValue<ImageList>(TreeView.StateImageListProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether check boxes are displayed.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if check boxes are displayed; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool CheckBoxes
    {
      get => this.GetValue<bool>(TreeView.CheckBoxesProperty);
      set
      {
        if (!this.SetValue<bool>(TreeView.CheckBoxesProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (CheckBoxes));
      }
    }

    /// <summary>
    /// <para>Gets the collection of tree nodes that are assigned to the tree view control.</para>
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [MergableProperty(false)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [SRDescription("TreeViewNodesDescr")]
    [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public TreeNodeCollection Nodes => this.mobjNodes;

    /// <summary>Gets or sets the selected node.</summary>
    /// <value></value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TreeNode SelectedNode
    {
      get => this.GetValue<TreeNode>(TreeView.SelectedNodeProperty);
      set => this.SelectNode(value, true, TreeViewAction.Unknown);
    }

    /// <summary>Selects the node.</summary>
    /// <param name="objTreeNode">The obj tree node.</param>
    /// <param name="blnCode">if set to <c>true</c> [BLN code].</param>
    /// <param name="enmAction">The action.</param>
    internal void SelectNode(TreeNode objTreeNode, bool blnCode, TreeViewAction enmAction)
    {
      TreeNode selectedNode = this.SelectedNode;
      if (objTreeNode != null)
      {
        if (objTreeNode.TreeView != this || objTreeNode == selectedNode)
          return;
        if (!objTreeNode.OnBeforeSelect(enmAction))
        {
          selectedNode?.SetSelected(false, blnCode);
          this.SetValue<TreeNode>(TreeView.SelectedNodeProperty, objTreeNode);
          objTreeNode.SetSelected(true, blnCode);
          objTreeNode.OnAfterSelect(enmAction);
        }
        else
        {
          objTreeNode.SetSelected(false, !blnCode);
          if (blnCode || selectedNode == null)
            return;
          selectedNode.Update();
        }
      }
      else
      {
        if (selectedNode == null)
          return;
        selectedNode.SetSelected(false, blnCode);
        this.SetValue<TreeNode>(TreeView.SelectedNodeProperty, (TreeNode) null);
      }
    }

    /// <summary>Sorts the items if the value of the <see cref="P:Gizmox.WebGUI.Forms.TreeView.TreeViewNodeSorter"></see> property is not null.</summary>
    public void Sort()
    {
      this.Sorted = true;
      this.RefreshNodes();
    }

    /// <summary>Refresh current nodes</summary>
    private void RefreshNodes()
    {
      TreeNode[] treeNodeArray = new TreeNode[this.Nodes.Count];
      this.Nodes.CopyTo((Array) treeNodeArray, 0);
      this.Nodes.Clear();
      this.Nodes.AddRange(treeNodeArray);
    }

    /// <summary>
    /// Gets or sets a value indicating whether to show plus minus.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [to show plus minus]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool ShowPlusMinus
    {
      get => this.GetValue<bool>(TreeView.ShowPlusMinusProperty);
      set
      {
        if (!this.SetValue<bool>(TreeView.ShowPlusMinusProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to show lines.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if to show lines; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool ShowLines
    {
      get => this.GetValue<bool>(TreeView.ShowLinesProperty);
      set
      {
        if (!this.SetValue<bool>(TreeView.ShowLinesProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (ShowLines));
      }
    }

    /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
    /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("TreeViewImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [RelatedImageList("ImageList")]
    public int ImageIndex
    {
      get
      {
        if (this.ImageList == null)
          return -1;
        int num = this.GetValue<int>(TreeView.ImageIndexProperty);
        return num >= this.ImageList.Images.Count ? Math.Max(0, this.ImageList.Images.Count - 1) : num;
      }
      set
      {
        if (value == -1)
          value = 0;
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (ImageIndex), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (ImageIndex), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(TreeView.ImageIndexProperty, value))
          return;
        this.RemoveValue<string>(TreeView.ImageKeyProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the image list index value of the image that is displayed when a tree node is selected.</summary>
    /// <returns>A zero-based index value that represents the position of an <see cref="T:System.Drawing.Image"></see> in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">The index assigned value is less than zero. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("TreeViewImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [RelatedImageList("ImageList")]
    public int SelectedImageIndex
    {
      get
      {
        if (this.ImageList == null)
          return -1;
        int num = this.GetValue<int>(TreeView.SelectedImageIndexProperty);
        return this.ImageList != null && num >= this.ImageList.Images.Count ? Math.Max(0, this.ImageList.Images.Count - 1) : num;
      }
      set
      {
        if (value == -1)
          value = 0;
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (SelectedImageIndex), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (SelectedImageIndex), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(TreeView.SelectedImageIndexProperty, value))
          return;
        this.RemoveValue<string>(TreeView.SelectedImageKeyProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
    /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [DefaultValue("")]
    [RelatedImageList("ImageList")]
    public string ImageKey
    {
      get => this.GetValue<string>(TreeView.ImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(TreeView.ImageKeyProperty, value))
          return;
        this.RemoveValue<int>(TreeView.ImageIndexProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a selected state.</summary>
    /// <returns>The key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a selected state.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [DefaultValue("")]
    [SRDescription("TreeViewSelectedImageKeyDescr")]
    [RelatedImageList("ImageList")]
    public string SelectedImageKey
    {
      get => this.GetValue<string>(TreeView.SelectedImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(TreeView.SelectedImageKeyProperty, value))
          return;
        this.RemoveValue<int>(TreeView.SelectedImageIndexProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a Expanded state.</summary>
    /// <returns>The key of the default image shown when a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> is in a Expanded state.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [DefaultValue("")]
    [SRDescription("TreeViewExpandedImageKeyDescr")]
    [RelatedImageList("ImageList")]
    public string ExpandedImageKey
    {
      get => this.GetValue<string>(TreeView.ExpandedImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(TreeView.ExpandedImageKeyProperty, value))
          return;
        this.RemoveValue<int>(TreeView.ExpandedImageIndexProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the image list index value of the image that is displayed when a tree node is Expanded.</summary>
    /// <returns>A zero-based index value that represents the position of an <see cref="T:System.Drawing.Image"></see> in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
    /// <exception cref="T:System.ArgumentException">The index assigned value is less than zero. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("TreeViewImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [RelatedImageList("ImageList")]
    public int ExpandedImageIndex
    {
      get
      {
        if (this.ImageList == null)
          return -1;
        int num = this.GetValue<int>(TreeView.ExpandedImageIndexProperty);
        return num >= this.ImageList.Images.Count ? Math.Max(0, this.ImageList.Images.Count - 1) : num;
      }
      set
      {
        if (value == -1)
          value = 0;
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (ExpandedImageIndex), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (ExpandedImageIndex), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(TreeView.ExpandedImageIndexProperty, value))
          return;
        this.RemoveValue<string>(TreeView.ExpandedImageKeyProperty);
        this.Update();
      }
    }

    protected override string ClientEventsPropogationTags => "TN";

    /// <summary>Gets or sets the path separator.</summary>
    /// <value>The path separator.</value>
    [DefaultValue("\\")]
    public string PathSeparator
    {
      get => this.GetValue<string>(TreeView.PathSeparatorProperty);
      set => this.SetValue<string>(TreeView.PathSeparatorProperty, value);
    }

    /// <summary>Gets or sets the select on right click.</summary>
    /// <value>The select on right click.</value>
    [SRCategory("CatAppearance")]
    [SRDescription("SelectOnRightClickDescr")]
    [DefaultValue(false)]
    public bool SelectOnRightClick
    {
      get => this.GetValue<bool>(TreeView.SelectOnRightClickProperty);
      set
      {
        if (!this.SetValue<bool>(TreeView.SelectOnRightClickProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
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

    /// <summary>
    /// Gets a value indicating whether [raise click on mouse down].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [raise click on mouse down]; otherwise, <c>false</c>.
    /// </value>
    internal bool RaiseClickOnMouseDown => this.ShouldRaiseClickOnRightMouseDown;

    /// <summary>Gets or sets the indent.</summary>
    /// <value>The indent.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int Indent
    {
      get => this.GetValue<int>(TreeView.IndentProperty);
      set => this.SetValue<int>(TreeView.IndentProperty, value);
    }

    /// <summary>
    /// Gets or sets the height of the item.
    /// When none is given, calculates the treenode height by using the font size.
    /// </summary>
    /// <value>The height of the item.</value>
    /// <exception cref="T:System.ArgumentOutOfRangeException">ItemHeight</exception>
    [SRDescription("TreeViewItemHeightDescr")]
    [SRCategory("CatAppearance")]
    [ProxyBrowsable(true)]
    public int ItemHeight
    {
      get
      {
        int itemHeight = this.InnerItemHeight;
        if (itemHeight == -1)
          itemHeight = this.GetPreferdItemHeight();
        return itemHeight;
      }
      set
      {
        if (value < 1)
          throw new ArgumentOutOfRangeException(nameof (ItemHeight), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (ItemHeight), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 1.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        this.InnerItemHeight = value <= (int) short.MaxValue ? value : throw new ArgumentOutOfRangeException(nameof (ItemHeight), SR.GetString("InvalidHighBoundArgumentEx", (object) nameof (ItemHeight), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) ((int) short.MaxValue).ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      }
    }

    /// <summary>Gets or sets the height of the inner item.</summary>
    /// <value>The height of the inner item.</value>
    private int InnerItemHeight
    {
      get => this.GetValue<int>(TreeView.ItemHeightProperty);
      set
      {
        if (!this.SetValue<int>(TreeView.ItemHeightProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the height of the inner item.</summary>
    /// <value>The height of the inner item.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool HasItemHeight => this.ContainsValue<int>(TreeView.ItemHeightProperty);

    /// <summary>Shoulds the height of the serialize item.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeItemHeight() => this.HasItemHeight;

    /// <summary>Resets the height of the item.</summary>
    private void ResetItemHeight()
    {
      this.RemoveValue<int>(TreeView.ItemHeightProperty);
      this.UpdateParams(AttributeType.Visual);
    }

    /// <summary>Gets the first fully-visible tree node in the tree view control.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> that represents the first fully-visible tree node in the tree view control.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatAppearance")]
    [SRDescription("TreeViewTopNodeDescr")]
    public TreeNode TopNode
    {
      get => this.GetTopNode();
      set => value.EnsureVisible();
    }

    /// <summary>Gets the top node in the tree view visible area.</summary>
    /// <returns></returns>
    private TreeNode GetTopNode() => this.Nodes.Count == 0 ? (TreeNode) null : this.GetNodeFromOriginPointAndDistance(this.Nodes[0], this.ScrollTop);

    /// <summary>Gets the node from origin point and distance.</summary>
    /// <param name="objNode">The origin node.</param>
    /// <param name="intDistance">The distance from the node (downwards).</param>
    /// <returns></returns>
    private TreeNode GetNodeFromOriginPointAndDistance(TreeNode objNode, int intDistance) => intDistance < this.ItemHeight / 2 ? objNode : this.GetNodeFromOriginPointAndDistance(objNode.NextVisibleNode, intDistance - this.ItemHeight);

    /// <summary>Gets or sets a value indicating ToolTips are shown when the mouse pointer hovers over a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>.</summary>
    /// <returns>true if ToolTips are shown when the mouse pointer hovers over a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>; otherwise, false. The default is false.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewShowShowNodeToolTipsDescr")]
    [DefaultValue(false)]
    public bool ShowNodeToolTips
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> label takes on the appearance of a hyperlink as the mouse pointer passes over it.</summary>
    /// <returns>true if a <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see> label takes on the appearance of a hyperlink as the mouse pointer passes over it; otherwise, false. The default is false.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewHotTrackingDescr")]
    public bool HotTracking
    {
      get => this.GetValue<bool>(TreeView.HotTrackingProperty, false);
      set => this.SetValue<bool>(TreeView.HotTrackingProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether the tree view control displays scroll bars when they are needed.</summary>
    /// <returns>true if the tree view control displays scroll bars when they are needed; otherwise, false. The default is true.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("TreeViewScrollableDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public bool Scrollable
    {
      get => this.GetValue<bool>(TreeView.ScrollableProperty, true);
      set => this.SetValue<bool>(TreeView.ScrollableProperty, value);
    }

    /// <summary>Gets or sets a value indicating whether lines are drawn between the tree nodes that are at the root of the tree view.</summary>
    /// <returns>true if lines are drawn between the tree nodes that are at the root of the tree view; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("TreeViewShowRootLinesDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public bool ShowRootLines
    {
      get => true;
      set
      {
      }
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public TreeViewWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as TreeViewWinFormsCompatibility;

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) this.Nodes;

    /// <summary>Creates the node collection.</summary>
    /// <returns></returns>
    protected virtual TreeNodeCollection CreateNodeCollection() => new TreeNodeCollection((Component) this);

    /// <summary>Creates the node collection.</summary>
    /// <param name="treeView">The tree view.</param>
    /// <param name="arrNodes">The arr nodes.</param>
    /// <returns></returns>
    protected virtual TreeNodeCollection CreateNodeCollection(object[] arrNodes) => new TreeNodeCollection((Component) this, arrNodes);

    /// <summary>Expands all the tree nodes.</summary>
    public void ExpandAll()
    {
      foreach (TreeNode node in (BaseCollection) this.Nodes)
        node.ExpandAll();
    }

    /// <summary>Collapses all the tree nodes.</summary>
    public void CollapseAll()
    {
      foreach (TreeNode node in (BaseCollection) this.Nodes)
        node.Collapse();
    }

    /// <summary>Adds a child object.</summary>
    /// <param name="objValue">The child object to add.</param>
    protected override void AddChild(object objValue)
    {
      if (objValue is TreeNode)
        this.Nodes.Add((TreeNode) objValue);
      else
        base.AddChild(objValue);
    }

    /// <summary>Retrieves the number of tree nodes, optionally including those in all subtrees, assigned to the tree view control.</summary>
    /// <returns>The number of tree nodes, optionally including those in all subtrees, assigned to the tree view control.</returns>
    public int GetNodeCount(bool blnIncludeSubTrees)
    {
      int count = this.Nodes.Count;
      if (blnIncludeSubTrees)
      {
        foreach (TreeNode node in (BaseCollection) this.Nodes)
          count += node.GetNodeCount(true);
      }
      return count;
    }

    /// <summary>Disables any redrawing of the tree view.</summary>
    public void BeginUpdate()
    {
    }

    /// <summary>Enables the redrawing of the tree view.</summary>
    public void EndUpdate()
    {
    }

    /// <summary>
    /// Retrieves the tree node that is at the specified point.
    ///  Not implemented
    ///  </summary>
    /// <param name="intX"></param>
    /// <param name="intY"></param>
    [Obsolete("Not implemented")]
    public TreeNode GetNodeAt(int intX, int intY) => (TreeNode) null;

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      TreeNodeCollection nodes = this.Nodes;
      if (nodes == null)
        return;
      this.RegisterBatch((ICollection) nodes);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      TreeNodeCollection nodes = this.Nodes;
      if (nodes == null)
        return;
      this.UnRegisterBatch((ICollection) nodes);
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new TreeViewRenderer(this);

    /// <summary>
    /// Determines whether [is critical event] [the specified enm event type].
    /// </summary>
    /// <param name="enmEventType">Type of the enm event.</param>
    /// <returns>
    /// 	<c>true</c> if [is critical event] [the specified enm event type]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsCriticalEvent(string strEventName) => this.GetCriticalEventsData().HasEvent(strEventName);

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected override Gizmox.WebGUI.Forms.WinFormsCompatibility GetWinFormsCompatibility() => (Gizmox.WebGUI.Forms.WinFormsCompatibility) new TreeViewWinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
      if (strChangedOptionName == "TreeNodeClickEventsOnToggle")
        this.UpdateParams(AttributeType.Control);
      base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
    }
  }
}

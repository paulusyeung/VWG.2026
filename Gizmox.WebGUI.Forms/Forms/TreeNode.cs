// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for TreeNode.</summary>
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TreeNodeController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TreeNodeController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Designer("Gizmox.WebGUI.Forms.Design.TreeNodeDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ProxyComponent(typeof (ProxyTreeNode))]
  [Serializable]
  public class TreeNode : Component
  {
    /// <summary>Provides a property reference to BackColor property.</summary>
    private static SerializableProperty BackColorProperty = SerializableProperty.Register(nameof (BackColor), typeof (Color), typeof (TreeNode), new SerializablePropertyMetadata((object) Color.White));
    /// <summary>Provides a property reference to CheckBox property.</summary>
    private static SerializableProperty CheckBoxProperty = SerializableProperty.Register(nameof (CheckBox), typeof (CheckBoxVisibility), typeof (TreeNode), new SerializablePropertyMetadata((object) CheckBoxVisibility.Inherited));
    /// <summary>
    /// Provides a property reference to ExpandedImageIndex property.
    /// </summary>
    private static SerializableProperty ExpandedImageIndexProperty = SerializableProperty.Register(nameof (ExpandedImageIndex), typeof (int), typeof (TreeNode), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to ExpandedImage property.
    /// </summary>
    private static SerializableProperty ExpandedImageProperty = SerializableProperty.Register(nameof (ExpandedImage), typeof (ResourceHandle), typeof (TreeNode), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to ForeColor property.</summary>
    private static SerializableProperty ForeColorProperty = SerializableProperty.Register(nameof (ForeColor), typeof (Color), typeof (TreeNode), new SerializablePropertyMetadata((object) Color.Black));
    /// <summary>Provides a property reference to HasNodes property.</summary>
    private static SerializableProperty HasNodesProperty = SerializableProperty.Register(nameof (HasNodes), typeof (bool), typeof (TreeNode), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to ImageIndex property.</summary>
    private static SerializableProperty ImageIndexProperty = SerializableProperty.Register(nameof (ImageIndex), typeof (int), typeof (TreeNode), new SerializablePropertyMetadata((object) -1));
    /// <summary>Provides a property reference to ImageKey property.</summary>
    private static SerializableProperty ImageKeyProperty = SerializableProperty.Register(nameof (ImageKey), typeof (string), typeof (TreeNode), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to Image property.</summary>
    private static SerializableProperty ImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (TreeNode), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to IsExpanded property.</summary>
    private static SerializableProperty IsExpandedProperty = SerializableProperty.Register(nameof (IsExpanded), typeof (bool), typeof (TreeNode), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to Label property.</summary>
    private static SerializableProperty LabelProperty = SerializableProperty.Register(nameof (Label), typeof (string), typeof (TreeNode), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to Name property.</summary>
    private static SerializableProperty NameProperty = SerializableProperty.Register(nameof (Name), typeof (string), typeof (TreeNode), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to NodeFont property.</summary>
    private static SerializableProperty NodeFontProperty = SerializableProperty.Register(nameof (NodeFont), typeof (Font), typeof (TreeNode), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to SelectedImageIndex property.
    /// </summary>
    private static SerializableProperty SelectedImageIndexProperty = SerializableProperty.Register(nameof (SelectedImageIndex), typeof (int), typeof (TreeNode), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to SelectedImageKey property.
    /// </summary>
    private static SerializableProperty SelectedImageKeyProperty = SerializableProperty.Register(nameof (SelectedImageKey), typeof (string), typeof (TreeNode), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>
    /// Provides a property reference to SelectedImage property.
    /// </summary>
    private static SerializableProperty SelectedImageProperty = SerializableProperty.Register(nameof (SelectedImage), typeof (ResourceHandle), typeof (TreeNode), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to SelectOnRightClick property.
    /// </summary>
    private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register(nameof (SelectOnRightClick), typeof (SelectOnRightClickBehvior), typeof (TreeNode), new SerializablePropertyMetadata((object) SelectOnRightClickBehvior.Inherit));
    /// <summary>
    /// Provides a property reference to StateImageIndex property.
    /// </summary>
    private static SerializableProperty StateImageIndexProperty = SerializableProperty.Register(nameof (StateImageIndex), typeof (int), typeof (TreeNode), new SerializablePropertyMetadata((object) -1));
    /// <summary>
    /// Provides a property reference to StateImageKey property.
    /// </summary>
    private static SerializableProperty StateImageKeyProperty = SerializableProperty.Register(nameof (StateImageKey), typeof (string), typeof (TreeNode), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>Provides a property reference to StateImage property.</summary>
    private static SerializableProperty StateImageProperty = SerializableProperty.Register(nameof (StateImage), typeof (ResourceHandle), typeof (TreeNode), new SerializablePropertyMetadata((object) null));
    /// <summary>
    /// Provides a property reference to ToolTipText property.
    /// </summary>
    private static SerializableProperty ToolTipTextProperty = SerializableProperty.Register(nameof (ToolTipText), typeof (string), typeof (TreeNode), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>
    /// Provides a property reference to ExpandedImageKey property.
    /// </summary>
    private static SerializableProperty ExpandedImageKeyProperty = SerializableProperty.Register(nameof (ExpandedImageKey), typeof (string), typeof (TreeNode), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The node collection</summary>
    [NonSerialized]
    private TreeNodeCollection mobjNodes;
    /// <summary>The NodeMouseDoubleClick event registration.</summary>
    private static readonly SerializableEvent NodeMouseDoubleClickEvent = SerializableEvent.Register("NodeMouseDoubleClick", typeof (TreeNodeMouseClickEventHandler), typeof (TreeNode));
    /// <summary>The NodeMouseClick event registration.</summary>
    private static readonly SerializableEvent NodeMouseClickEvent = SerializableEvent.Register("NodeMouseClick", typeof (TreeNodeMouseClickEventHandler), typeof (TreeNode));
    /// <summary>The BeforeSelect event registration.</summary>
    private static readonly SerializableEvent BeforeSelectEvent = SerializableEvent.Register("BeforeSelect", typeof (TreeViewCancelEventHandler), typeof (TreeNode));
    /// <summary>The BeforeLabelEdit event registration.</summary>
    private static readonly SerializableEvent BeforeLabelEditEvent = SerializableEvent.Register("BeforeLabelEdit", typeof (NodeLabelEditEventHandler), typeof (TreeNode));
    /// <summary>The BeforeExpand event registration.</summary>
    private static readonly SerializableEvent BeforeExpandEvent = SerializableEvent.Register("BeforeExpand", typeof (TreeViewCancelEventHandler), typeof (TreeNode));
    /// <summary>The AfterExpand event registration.</summary>
    private static readonly SerializableEvent AfterExpandEvent = SerializableEvent.Register("AfterExpand", typeof (TreeViewEventHandler), typeof (TreeNode));
    /// <summary>The BeforeCheck event registration.</summary>
    private static readonly SerializableEvent BeforeCheckEvent = SerializableEvent.Register("BeforeCheck", typeof (TreeViewCancelEventHandler), typeof (TreeNode));
    /// <summary>The AfterCheck event registration.</summary>
    private static readonly SerializableEvent AfterCheckEvent = SerializableEvent.Register("AfterCheck", typeof (TreeViewEventHandler), typeof (TreeNode));
    /// <summary>The AfterCollapse event registration.</summary>
    private static readonly SerializableEvent AfterCollapseEvent = SerializableEvent.Register("AfterCollapse", typeof (TreeViewEventHandler), typeof (TreeNode));
    /// <summary>The BeforeCollapse event registration.</summary>
    private static readonly SerializableEvent BeforeCollapseEvent = SerializableEvent.Register("BeforeCollapse", typeof (TreeViewCancelEventHandler), typeof (TreeNode));
    /// <summary>The AfterLabelEdit event registration.</summary>
    private static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof (NodeLabelEditEventHandler), typeof (TreeNode));
    /// <summary>The AfterSelect event registration.</summary>
    private static readonly SerializableEvent AfterSelectEvent = SerializableEvent.Register("AfterSelect", typeof (TreeViewEventHandler), typeof (TreeNode));

    /// <summary>Occurs when [client after label edit].</summary>
    [SRDescription("Occurs when control's label edited in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientAfterLabelEdit
    {
      add => this.AddClientHandler("AfterLabelEdit", value);
      remove => this.RemoveClientHandler("AfterLabelEdit", value);
    }

    /// <summary>Renders the update attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    internal void RenderUpdateAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
        this.RenderSelectOnRightClick(objWriter, true);
      }
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
        objWriter.WriteAttributeText("TT", this.ToolTipText);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Layout))
      {
        Font nodeFont = this.NodeFont;
        if (nodeFont != null)
          objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(nodeFont));
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
        return;
      this.RenderImages(objWriter);
    }

    /// <summary>Renders the select on right click.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
    {
      SelectOnRightClickBehvior selectOnRightClick = this.SelectOnRightClick;
      if (selectOnRightClick != SelectOnRightClickBehvior.Inherit)
      {
        objWriter.WriteAttributeString("SOR", Convert.ToByte((object) selectOnRightClick).ToString());
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SOR", string.Empty);
      }
    }

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mobjNodes = this.CreateNodeCollection(objReader);
    }

    protected virtual TreeNodeCollection CreateNodeCollection(SerializationReader objReader) => new TreeNodeCollection((Component) this, objReader.ReadArray());

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteArray((ICollection) this.mobjNodes);
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjNodes);

    /// <summary>Occurs when the user double-clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse.</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewNodeMouseDoubleClickDescr")]
    public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick
    {
      add => this.AddHandler(TreeNode.NodeMouseDoubleClickEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.NodeMouseDoubleClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the NodeMouseDoubleClick event.</summary>
    private TreeNodeMouseClickEventHandler NodeMouseDoubleClickHandler => (TreeNodeMouseClickEventHandler) this.GetHandler(TreeNode.NodeMouseDoubleClickEvent);

    /// <summary>Occurs when the user clicks a <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> with the mouse. </summary>
    [SRDescription("TreeViewNodeMouseClickDescr")]
    [SRCategory("CatBehavior")]
    public event TreeNodeMouseClickEventHandler NodeMouseClick
    {
      add => this.AddHandler(TreeNode.NodeMouseClickEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.NodeMouseClickEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the NodeMouseClick event.</summary>
    private TreeNodeMouseClickEventHandler NodeMouseClickHandler => (TreeNodeMouseClickEventHandler) this.GetHandler(TreeNode.NodeMouseClickEvent);

    /// <summary>Occurs before the tree node is selected.</summary>
    [SRDescription("TreeViewBeforeSelectDescr")]
    [SRCategory("CatBehavior")]
    public event TreeViewCancelEventHandler BeforeSelect
    {
      add => this.AddHandler(TreeNode.BeforeSelectEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.BeforeSelectEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeSelect event.</summary>
    private TreeViewCancelEventHandler BeforeSelectHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeNode.BeforeSelectEvent);

    /// <summary>Occurs before the tree node label text is edited.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewBeforeEditDescr")]
    public event NodeLabelEditEventHandler BeforeLabelEdit
    {
      add => this.AddHandler(TreeNode.BeforeLabelEditEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.BeforeLabelEditEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeLabelEdit event.</summary>
    private NodeLabelEditEventHandler BeforeLabelEditHandler => (NodeLabelEditEventHandler) this.GetHandler(TreeNode.BeforeLabelEditEvent);

    /// <summary>Occurs before the tree node is expanded.</summary>
    [SRDescription("TreeViewBeforeExpandDescr")]
    [SRCategory("CatBehavior")]
    public event TreeViewCancelEventHandler BeforeExpand
    {
      add => this.AddHandler(TreeNode.BeforeExpandEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.BeforeExpandEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeExpand event.</summary>
    private TreeViewCancelEventHandler BeforeExpandHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeNode.BeforeExpandEvent);

    /// <summary>Occurs after the tree node is expanded.</summary>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterExpandDescr")]
    public event TreeViewEventHandler AfterExpand
    {
      add => this.AddHandler(TreeNode.AfterExpandEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.AfterExpandEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterExpand event.</summary>
    private TreeViewEventHandler AfterExpandHandler => (TreeViewEventHandler) this.GetHandler(TreeNode.AfterExpandEvent);

    /// <summary>Occurs before the tree node check box is checked.</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewBeforeCheckDescr")]
    public event TreeViewCancelEventHandler BeforeCheck
    {
      add => this.AddHandler(TreeNode.BeforeCheckEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.BeforeCheckEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeCheck event.</summary>
    private TreeViewCancelEventHandler BeforeCheckHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeNode.BeforeCheckEvent);

    /// <summary>Occurs after the tree node check box is checked.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("TreeViewAfterCheckDescr")]
    [SRCategory("CatBehavior")]
    public event TreeViewEventHandler AfterCheck
    {
      add => this.AddHandler(TreeNode.AfterCheckEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.AfterCheckEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterCheck event.</summary>
    private TreeViewEventHandler AfterCheckHandler => (TreeViewEventHandler) this.GetHandler(TreeNode.AfterCheckEvent);

    /// <summary>Occurs after the tree node is collapsed.</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterCollapseDescr")]
    public event TreeViewEventHandler AfterCollapse
    {
      add => this.AddHandler(TreeNode.AfterCollapseEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.AfterCollapseEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterCollapse event.</summary>
    private TreeViewEventHandler AfterCollapseHandler => (TreeViewEventHandler) this.GetHandler(TreeNode.AfterCollapseEvent);

    /// <summary>Occurs before the tree node is collapsed.</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewBeforeCollapseDescr")]
    public event TreeViewCancelEventHandler BeforeCollapse
    {
      add => this.AddHandler(TreeNode.BeforeCollapseEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.BeforeCollapseEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the BeforeCollapse event.</summary>
    private TreeViewCancelEventHandler BeforeCollapseHandler => (TreeViewCancelEventHandler) this.GetHandler(TreeNode.BeforeCollapseEvent);

    /// <summary>Occurs after the tree node label text is edited.</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterEditDescr")]
    public event NodeLabelEditEventHandler AfterLabelEdit
    {
      add => this.AddHandler(TreeNode.AfterLabelEditEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.AfterLabelEditEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterLabelEdit event.</summary>
    private NodeLabelEditEventHandler AfterLabelEditHandler => (NodeLabelEditEventHandler) this.GetHandler(TreeNode.AfterLabelEditEvent);

    /// <summary>Occurs after the tree node is selected.</summary>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeViewAfterSelectDescr")]
    public event TreeViewEventHandler AfterSelect
    {
      add => this.AddHandler(TreeNode.AfterSelectEvent, (Delegate) value);
      remove => this.RemoveHandler(TreeNode.AfterSelectEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterSelect event.</summary>
    private TreeViewEventHandler AfterSelectHandler => (TreeViewEventHandler) this.GetHandler(TreeNode.AfterSelectEvent);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="strLabel"></param>
    /// <param name="strIcon"></param>
    public TreeNode(string strName, string strLabel, string strIcon)
    {
      this.SetValue<string>(TreeNode.NameProperty, strName);
      this.SetValue<string>(TreeNode.LabelProperty, strLabel);
      if (strIcon != "")
        this.SetValue<ResourceHandle>(TreeNode.ImageProperty, (ResourceHandle) new IconResourceHandle(strIcon + ".gif"));
      this.mobjNodes = this.CreateNodeCollection();
      this.SetState(Component.ComponentState.Visible | Component.ComponentState.Loaded, true);
    }

    /// <summary>Creates the node collection.</summary>
    /// <returns></returns>
    protected virtual TreeNodeCollection CreateNodeCollection() => new TreeNodeCollection((Component) this);

    /// <summary>
    /// 
    /// </summary>
    public TreeNode(string strLabel)
      : this("", strLabel, "")
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public TreeNode()
      : this("", "", "")
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public TreeNode(string strLabel, TreeNode[] arrTreeNodes)
      : this("", strLabel, "")
    {
      this.Nodes.AddRange(arrTreeNodes);
    }

    /// <summary>
    /// 
    /// </summary>
    public TreeNode(string strLabel, int intImageIndex, int intSelectedImageIndex)
      : this(strLabel)
    {
      this.ImageIndex = intImageIndex;
      this.SelectedImageIndex = intSelectedImageIndex;
    }

    /// <summary>
    /// 
    /// </summary>
    public TreeNode(
      string strLabel,
      int intImageIndex,
      int intSelectedImageIndex,
      TreeNode[] arrTreeNodes)
      : this(strLabel, arrTreeNodes)
    {
      this.ImageIndex = intImageIndex;
      this.SelectedImageIndex = intSelectedImageIndex;
    }

    /// <summary>
    /// This is a recursive function that loop through a control and all of its parents
    /// cheching if one of the controls(and control containers) is hidden or
    /// disabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
    /// </value>
    /// <returns>false if one of the controls is hidden or disabled.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool IsEventsEnabled => this.IsVisible && base.IsEventsEnabled;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      string type = objEvent.Type;
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(type))
      {
        case 5885182:
          if (!(type == "Collapse") || !this.IsExpanded)
            return;
          if (!this.OnBeforeCollapse())
          {
            this.SetValue<bool>(TreeNode.IsExpandedProperty, false);
            this.OnAfterCollapse();
            return;
          }
          this.Update();
          return;
        case 37362191:
          if (!(type == "Click"))
            return;
          this.OnNodeMouseClick(objEvent);
          return;
        case 1594805938:
          if (!(type == "CheckedChange"))
            return;
          this.ChangeCheckState(objEvent["Value"] == "1", TreeViewAction.ByMouse);
          return;
        case 2165448309:
          if (!(type == "AfterLabelEdit"))
            return;
          string strLabel = CommonUtils.DecodeText(objEvent["Text"]);
          NodeLabelEditEventArgs e = new NodeLabelEditEventArgs(this, strLabel);
          this.OnAfterLabelEdit(e);
          if (!e.CancelEdit)
          {
            this.TextInternal = strLabel;
            return;
          }
          this.UpdateParams(AttributeType.Control);
          return;
        case 2945958253:
          if (!(type == "StartDrag"))
            return;
          this.TreeView?.FireItemDrag(new ItemDragEventArgs(MouseButtons.Left, (object) this));
          return;
        case 2950315936:
          if (!(type == "DoubleClick"))
            return;
          this.OnNodeMouseDoubleClick(objEvent);
          return;
        case 3096233349:
          if (!(type == "FirstExpand"))
            return;
          break;
        case 3186242741:
          if (!(type == "Selection"))
            return;
          this.OnSelect(objEvent["Keyboard"] == "1");
          return;
        case 3889190145:
          if (!(type == "Expand"))
            return;
          break;
        default:
          return;
      }
      if (this.IsExpanded)
        return;
      if (!this.OnBeforeExpand())
      {
        this.SetValue<bool>(TreeNode.IsExpandedProperty, true);
        this.OnAfterExpand();
        if (!(objEvent.Type == "FirstExpand"))
          return;
        this.Update();
      }
      else
        this.Update();
    }

    private void OnSelect(bool blnIsKeyboard)
    {
      if (this.IsSelected || this.TreeView == null)
        return;
      this.TreeView.SelectNode(this, false, blnIsKeyboard ? TreeViewAction.ByKeyboard : TreeViewAction.ByMouse);
    }

    /// <summary>Called when this node mouse is double clicked.</summary>
    private void OnNodeMouseDoubleClick(IEvent objEvent)
    {
      this.OnNodeMouseClick(objEvent);
      this.OnNodeMouseDoubleClick(this.CreateTreeNodeMouseClickEventArgs(this, MouseButtons.Left, 2, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0)));
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
    protected virtual void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
    {
      this.OnSelect(false);
      TreeNodeMouseClickEventHandler doubleClickHandler = this.NodeMouseDoubleClickHandler;
      if (doubleClickHandler != null)
        doubleClickHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnNodeMouseDoubleClickInternal(e);
    }

    /// <summary>Called when this node is clicked.</summary>
    private void OnNodeMouseClick(IEvent objEvent)
    {
      int eventValue1 = this.GetEventValue(objEvent, "X", 0);
      int eventValue2 = this.GetEventValue(objEvent, "Y", 0);
      MouseEventArgs mouseEventArgs = new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue1, eventValue2, 0);
      this.OnNodeMouseClick(this.CreateTreeNodeMouseClickEventArgs(this, mouseEventArgs.Button, 1, mouseEventArgs.X, mouseEventArgs.Y));
    }

    /// <summary>Creates the tree node mouse click event args.</summary>
    /// <param name="objNode">The node.</param>
    /// <param name="objButton">The button.</param>
    /// <param name="intClicks">The clicks.</param>
    /// <param name="intX">The X.</param>
    /// <param name="intY">The Y.</param>
    /// <returns></returns>
    protected virtual TreeNodeMouseClickEventArgs CreateTreeNodeMouseClickEventArgs(
      TreeNode objNode,
      MouseButtons objButton,
      int intClicks,
      int intX,
      int intY)
    {
      return new TreeNodeMouseClickEventArgs(objNode, objButton, intClicks, intX, intY);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.NodeMouseClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"></see> that contains the event data. </param>
    protected virtual void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
    {
      TreeNodeMouseClickEventHandler mouseClickHandler = this.NodeMouseClickHandler;
      if (mouseClickHandler != null)
        mouseClickHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnNodeMouseClickInternal(e);
    }

    /// <summary>Called before node checked status is changed.</summary>
    /// <returns></returns>
    private bool OnBeforeCheck(TreeViewAction enmTreeViewAction)
    {
      TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, false, enmTreeViewAction);
      this.OnBeforeCheck(e);
      return e.Cancel;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCheck"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeCheck(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeCheckHandler = this.BeforeCheckHandler;
      if (beforeCheckHandler != null)
        beforeCheckHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnBeforeCheckInternal(e);
    }

    /// <summary>Called after node checked status is changed.</summary>
    private void OnAfterCheck() => this.OnAfterCheck(new TreeViewEventArgs(this));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCheck"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAfterCheck(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterCheckHandler = this.AfterCheckHandler;
      if (afterCheckHandler != null)
        afterCheckHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnAfterCheckInternal(e);
    }

    /// <summary>Called before the node is selected.</summary>
    internal bool OnBeforeSelect(TreeViewAction enmTreeViewAction)
    {
      TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, false, enmTreeViewAction);
      this.OnBeforeSelect(e);
      return e.Cancel;
    }

    /// <summary>
    /// Raises the <see cref="E:BeforeSelect" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs" /> instance containing the event data.</param>
    protected virtual void OnBeforeSelect(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeSelectHandler = this.BeforeSelectHandler;
      if (beforeSelectHandler != null)
        beforeSelectHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnBeforeSelectInternal(e);
    }

    /// <summary>Called after node is selected.</summary>
    internal void OnAfterSelect(TreeViewAction enmTreeViewAction) => this.OnAfterSelect(new TreeViewEventArgs(this, enmTreeViewAction));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterSelect"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAfterSelect(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterSelectHandler = this.AfterSelectHandler;
      if (afterSelectHandler != null)
        afterSelectHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnAfterSelectInternal(e);
    }

    /// <summary>Called after node is expanded.</summary>
    private void OnAfterExpand() => this.OnAfterExpand(new TreeViewEventArgs(this, TreeViewAction.Expand));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterExpand"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
    protected virtual void OnAfterExpand(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterExpandHandler = this.AfterExpandHandler;
      if (afterExpandHandler != null)
        afterExpandHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnAfterExpandInternal(e);
    }

    /// <summary>Called before node is collapsed.</summary>
    /// <returns></returns>
    private bool OnBeforeCollapse()
    {
      TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, false, TreeViewAction.Collapse);
      this.OnBeforeCollapse(e);
      return e.Cancel;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeCollapse"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeCollapse(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeCollapseHandler = this.BeforeCollapseHandler;
      if (beforeCollapseHandler != null)
        beforeCollapseHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnBeforeCollapse(e);
    }

    /// <summary>Called after node is collapsed.</summary>
    private void OnAfterCollapse() => this.OnAfterCollapse(new TreeViewEventArgs(this, TreeViewAction.Collapse));

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.AfterCollapse"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewEventArgs"></see> that contains the event data. </param>
    protected internal virtual void OnAfterCollapse(TreeViewEventArgs e)
    {
      TreeViewEventHandler afterCollapseHandler = this.AfterCollapseHandler;
      if (afterCollapseHandler != null)
        afterCollapseHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnAfterCollapseInternal(e);
    }

    /// <summary>
    /// Raises the <see cref="E:AfterLabelEdit" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.NodeLabelEditEventArgs" /> instance containing the event data.</param>
    protected internal virtual void OnAfterLabelEdit(NodeLabelEditEventArgs e)
    {
      NodeLabelEditEventHandler labelEditHandler = this.AfterLabelEditHandler;
      if (labelEditHandler != null)
        labelEditHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnAfterLabelEditInternal(e);
    }

    /// <summary>Called before node is expanded.</summary>
    /// <returns></returns>
    private bool OnBeforeExpand()
    {
      TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(this, false, TreeViewAction.ByMouse);
      this.OnBeforeExpand(e);
      return e.Cancel;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.TreeView.BeforeExpand"></see> event.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.TreeViewCancelEventArgs"></see> that contains the event data. </param>
    protected virtual void OnBeforeExpand(TreeViewCancelEventArgs e)
    {
      TreeViewCancelEventHandler beforeExpandHandler = this.BeforeExpandHandler;
      if (beforeExpandHandler != null)
        beforeExpandHandler((object) this, e);
      if (this.TreeView == null)
        return;
      this.TreeView.OnBeforeExpandIntenral(e);
    }

    /// <summary>Disposes the specified component.</summary>
    /// <param name="blnDisposing"></param>
    protected override void Dispose(bool blnDisposing)
    {
      base.Dispose(blnDisposing);
      if (!blnDisposing)
        return;
      foreach (ComponentBase node in (BaseCollection) this.Nodes)
        node.Dispose();
    }

    /// <summary>Renders the node attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderNodeAttributes(IContext objContext, IResponseWriter objWriter)
    {
    }

    /// <summary>Renders the node.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">Request ID.</param>
    /// <param name="enmParentCheckBoxVisibility">The enm parent check box visibility.</param>
    internal void RenderNode(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      CheckBoxVisibility enmParentCheckBoxVisibility)
    {
      if (this.IsDirty(lngRequestID))
      {
        if (this.Nodes.Count > 0)
          this.HasNodes = true;
        if (this.HasNodes && this.Nodes.Count == 0)
          this.Loaded = false;
        objWriter.WriteStartElement("TN");
        this.RenderNodeAttributes(objContext, objWriter);
        this.RegisterSelf();
        this.RenderComponentAttributes(objContext, (IAttributeWriter) objWriter);
        objWriter.WriteAttributeText("TX", this.Label, TextFilter.NewLine | TextFilter.CarriageReturn);
        this.RenderImages((IAttributeWriter) objWriter);
        this.RenderSelectOnRightClick((IAttributeWriter) objWriter, false);
        Font nodeFont = this.NodeFont;
        if (nodeFont != null)
          objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(nodeFont));
        Color foreColor = this.ForeColor;
        if (foreColor != Color.Black)
          objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(foreColor));
        Color backColor = this.BackColor;
        if (backColor != Color.White)
          objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(backColor));
        if (this.HasRedrawingParent)
          objWriter.WriteAttributeString("HRP", "1");
        if ((!this.Loaded || !this.IsExpanded && this.HasNodes) && !this.TreeView.ForceContentAvailabilityOnClient && !ConfigHelper.ForceContentAvailabilityOnClient)
          objWriter.WriteAttributeString("LO", "0");
        if (!this.IsExpanded && this.HasNodes)
          objWriter.WriteAttributeString("EX", "0");
        if (this.HasNodes)
          objWriter.WriteAttributeString("HN", "1");
        if (this.Selected)
          objWriter.WriteAttributeString("SE", "1");
        if (this.CheckBox == CheckBoxVisibility.True || this.CheckBox == CheckBoxVisibility.Inherited && enmParentCheckBoxVisibility == CheckBoxVisibility.True)
          objWriter.WriteAttributeString("CB", "1");
        if (this.Checked)
          objWriter.WriteAttributeString("C", "1");
        string toolTipText = this.ToolTipText;
        if (toolTipText != string.Empty)
          objWriter.WriteAttributeText("TT", toolTipText);
        if (this.IsExpanded || this.TreeView.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
          this.RenderComponents(objContext, objWriter, 0L, enmParentCheckBoxVisibility);
        this.RenderComponentClientEvents(objContext, objWriter, lngRequestID);
        objWriter.WriteEndElement();
      }
      else if (this.IsDirtyAttributes(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
        this.RenderComponentUpdateAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID);
        this.RenderUpdateAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID);
        this.RenderComponents(objContext, objWriter, lngRequestID, enmParentCheckBoxVisibility);
        objWriter.WriteEndElement();
      }
      else
        this.RenderComponents(objContext, objWriter, lngRequestID, enmParentCheckBoxVisibility);
    }

    /// <summary>Renders the components.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The response writer object.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="enmParentCheckBoxVisibility">The enm parent check box visibility.</param>
    internal void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      CheckBoxVisibility enmParentCheckBoxVisibility)
    {
      foreach (TreeNode node in (BaseCollection) this.Nodes)
      {
        if (node.Visible || this.TreeView.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
          node.RenderNode(objContext, objWriter, lngRequestID, this.CheckBox == CheckBoxVisibility.Inherited ? enmParentCheckBoxVisibility : this.CheckBox);
      }
    }

    /// <summary>Gets or sets the control visability.</summary>
    [DefaultValue(true)]
    [SRDescription("TreeNodeVisibleDescr")]
    [SRCategory("CatBehavior")]
    public bool Visible
    {
      get => this.GetState(Component.ComponentState.Visible);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Visible, value))
          return;
        this.InternalParent?.Update();
      }
    }

    /// <summary>Renders the images.</summary>
    /// <param name="objWriter">The obj writer.</param>
    internal void RenderImages(IAttributeWriter objWriter)
    {
      ResourceHandle image = this.Image;
      if (image != null)
        objWriter.WriteAttributeString("IM", image.ToString());
      ResourceHandle selectedImage = this.SelectedImage;
      if (selectedImage != null)
        objWriter.WriteAttributeString("SIM", selectedImage.ToString());
      ResourceHandle expandedImage = this.ExpandedImage;
      if (expandedImage != null)
        objWriter.WriteAttributeString("EIM", expandedImage.ToString());
      if (this.TreeView.CheckBoxes)
        return;
      ResourceHandle stateImage = this.StateImage;
      if (stateImage == null)
        return;
      objWriter.WriteAttributeString("TIM", stateImage.ToString());
    }

    /// <summary>Gets the name of the client component.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected override string GetClientComponentName() => this.Name;

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("AfterLabelEdit"))
        clientEventsData.Set("ALE");
      return clientEventsData;
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.AfterCollapseHandler != null)
        criticalEventsData.Set("COL");
      if (this.AfterExpandHandler != null)
        criticalEventsData.Set("EXP");
      if (this.BeforeCollapseHandler != null)
        criticalEventsData.Set("COL");
      if (this.BeforeExpandHandler != null)
        criticalEventsData.Set("EXP");
      TreeView treeView = this.TreeView;
      if (treeView != null)
      {
        if (!treeView.IsCriticalEvent("CC") && (this.AfterCheckHandler != null || this.BeforeCheckHandler != null))
          criticalEventsData.Set("CC");
        if (this.NodeMouseClickHandler != null || treeView.IsCriticalEvent("CL") || treeView.NodeMouseClickHandler != null)
        {
          criticalEventsData.Set("CL");
          if (treeView.RaiseClickOnMouseDown)
            criticalEventsData.Set("RC");
        }
        if (this.NodeMouseDoubleClickHandler != null || treeView.IsCriticalEvent("DCL") || treeView.NodeMouseDoubleClickHandler != null)
          criticalEventsData.Set("DCL");
        if (this.AfterSelectHandler != null || this.BeforeSelectHandler != null || treeView.IsCriticalEvent("SLC"))
          criticalEventsData.Set("SLC");
        if (this.AfterLabelEditHandler != null || treeView.IsCriticalEvent("ALE"))
          criticalEventsData.Set("ALE");
        if (treeView.ItemDragHandler != null)
          criticalEventsData.Set("SD");
      }
      return criticalEventsData;
    }

    /// <summary>Shoulds the color of the serialize back.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeBackColor() => this.BackColor != Color.White;

    /// <summary>Shoulds the color of the serialize fore.</summary>
    /// <returns></returns>
    protected virtual bool ShouldSerializeForeColor() => this.ForeColor != Color.Black;

    /// <summary>
    /// Gets or sets a value indicating whether check boxes are displayed.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if check boxes are displayed; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(CheckBoxVisibility.Inherited)]
    public CheckBoxVisibility CheckBox
    {
      get => this.GetValue<CheckBoxVisibility>(TreeNode.CheckBoxProperty);
      set
      {
        if (!this.SetValue<CheckBoxVisibility>(TreeNode.CheckBoxProperty, value))
          return;
        this.Update();
        this.FireObservableItemPropertyChanged(nameof (CheckBox));
      }
    }

    /// <summary>Gets or sets the tool tip text for the tree node.</summary>
    /// <value></value>
    [DefaultValue("")]
    public string ToolTipText
    {
      get => this.GetValue<string>(TreeNode.ToolTipTextProperty);
      set
      {
        if (!this.SetValue<string>(TreeNode.ToolTipTextProperty, value))
          return;
        this.UpdateParams(AttributeType.ToolTip);
      }
    }

    /// <summary>Gets the full path.</summary>
    /// <value></value>
    public string FullPath
    {
      get
      {
        TreeView treeView = this.TreeView;
        if (treeView == null)
          return "";
        StringBuilder objPath = new StringBuilder();
        this.GetFullPath(objPath, treeView.PathSeparator);
        return objPath.ToString();
      }
    }

    /// <summary>Gets the tree node parent.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public TreeNode Parent => this.InternalParent as TreeNode;

    /// <summary>Gets or sets the background color of the tree node.</summary>
    /// <returns>The background <see cref="T:System.Drawing.Color"></see> of the tree node. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("TreeNodeBackColorDescr")]
    public Color BackColor
    {
      get => this.GetValue<Color>(TreeNode.BackColorProperty);
      set
      {
        if (!this.SetValue<Color>(TreeNode.BackColorProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Resets the color of the back.</summary>
    private void ResetBackColor() => this.BackColor = Color.White;

    /// <summary>Gets the first child tree node in the tree node collection.</summary>
    /// <returns>The first child <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> in the <see cref="P:Gizmox.WebGUI.Forms.TreeNode.Nodes"></see> collection.</returns>
    [Browsable(false)]
    public TreeNode FirstNode
    {
      get
      {
        TreeNodeCollection nodes = this.Nodes;
        return nodes.Count == 0 ? (TreeNode) null : nodes[0];
      }
    }

    /// <summary>Gets or sets the foreground color of the tree node.</summary>
    /// <returns>The foreground <see cref="T:System.Drawing.Color"></see> of the tree node.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("TreeNodeForeColorDescr")]
    public Color ForeColor
    {
      get => this.GetValue<Color>(TreeNode.ForeColorProperty);
      set
      {
        if (!this.SetValue<Color>(TreeNode.ForeColorProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Resets the color of the fore.</summary>
    private void ResetForeColor() => this.ForeColor = Color.Black;

    /// <summary>Gets or sets the select on right click.</summary>
    /// <value>The select on right click.</value>
    [SRCategory("CatAppearance")]
    [SRDescription("SelectOnRightClickDescr")]
    [DefaultValue(SelectOnRightClickBehvior.Inherit)]
    public SelectOnRightClickBehvior SelectOnRightClick
    {
      get => this.GetValue<SelectOnRightClickBehvior>(TreeNode.SelectOnRightClickProperty);
      set
      {
        if (!this.SetValue<SelectOnRightClickBehvior>(TreeNode.SelectOnRightClickProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets the position of the tree node in the tree node collection.</summary>
    /// <returns>A zero-based index value that represents the position of the tree node in the <see cref="P:Gizmox.WebGUI.Forms.TreeNode.Nodes"></see> collection.</returns>
    [SRCategory("CatBehavior")]
    [SRDescription("TreeNodeIndexDescr")]
    public int Index
    {
      get
      {
        if (this.Parent != null)
          return ((IList) this.Parent.Nodes).IndexOf((object) this);
        return this.TreeView != null ? ((IList) this.TreeView.Nodes).IndexOf((object) this) : -1;
      }
      internal set
      {
        if (this.Parent != null)
        {
          ((IList) this.Parent.Nodes).Insert(value, (object) this);
        }
        else
        {
          if (this.TreeView == null)
            return;
          ((IList) this.TreeView.Nodes).Insert(value, (object) this);
        }
      }
    }

    /// <summary>Gets a value indicating whether the tree node is in an editable state.</summary>
    /// <returns>true if the tree node is in editable state; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool IsEditing
    {
      get
      {
        TreeView treeView = this.TreeView;
        return treeView != null && treeView.EditNode == this;
      }
    }

    /// <summary>Gets a value indicating whether the tree node is in the selected state.</summary>
    /// <returns>true if the tree node is in the selected state; otherwise, false.</returns>
    [Browsable(false)]
    public bool IsSelected => this.Selected;

    /// <summary>Gets a value indicating whether the tree node is visible or partially visible.</summary>
    /// <returns>true if the tree node is visible or partially visible; otherwise, false.</returns>
    [Browsable(false)]
    public bool IsVisible => true;

    /// <summary>Gets the last child tree node.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the last child tree node.</returns>
    [Browsable(false)]
    public TreeNode LastNode
    {
      get
      {
        TreeNodeCollection nodes = this.Nodes;
        if (nodes.Count == 0)
          return (TreeNode) null;
        TreeNodeCollection treeNodeCollection = nodes;
        return treeNodeCollection[treeNodeCollection.Count - 1];
      }
    }

    /// <summary>Gets the zero-based depth of the tree node in the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> control.</summary>
    /// <returns>The zero-based depth of the tree node in the <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> control.</returns>
    [Browsable(false)]
    public int Level => this.Parent == null ? 0 : this.Parent.Level + 1;

    /// <summary>
    /// Gets a value indicating whether this instance has a redrawing parent.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has redrawing parent; otherwise, <c>false</c>.
    /// </value>
    private bool HasRedrawingParent
    {
      get
      {
        bool hasRedrawingParent = false;
        Control control = (Control) this.TreeView;
        while (control != null && !hasRedrawingParent)
        {
          if (control.Redraws)
            hasRedrawingParent = true;
          else
            control = control.Parent;
        }
        return hasRedrawingParent;
      }
    }

    private TreeNodeCollection ParentNodes
    {
      get
      {
        if (this.Parent != null)
          return this.Parent.Nodes;
        return this.TreeView != null ? this.TreeView.Nodes : (TreeNodeCollection) null;
      }
    }

    private TreeNode NextUncle
    {
      get
      {
        TreeNode treeNode = this;
        while (treeNode.Parent != null)
        {
          if (treeNode.Parent.ParentNodes.Count > treeNode.Parent.Index + 1)
            return treeNode.Parent.ParentNodes[treeNode.Parent.Index + 1];
          treeNode = treeNode.Parent;
          if (false)
            return (TreeNode) null;
        }
        return (TreeNode) null;
      }
    }

    /// <summary>Gets the previous sibling tree node.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the previous sibling tree node.</returns>
    [Browsable(false)]
    public TreeNode PrevNode
    {
      get
      {
        int index = this.Index;
        if (index < 1)
          return (TreeNode) null;
        return this.ParentNodes?[index - 1];
      }
    }

    /// <summary>Gets the previous visible tree node.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the previous visible tree node.</returns>
    [Browsable(false)]
    public TreeNode PrevVisibleNode
    {
      get
      {
        TreeNode prevVisibleNode = (TreeNode) null;
        if (this.PrevNode != null)
          prevVisibleNode = this.PrevNode.LastVisibleChild;
        else if (this.Parent != null)
          prevVisibleNode = this.Parent;
        return prevVisibleNode;
      }
    }

    /// <summary>
    /// Returns last visible child of last child
    /// or self if no children or not expanded
    /// </summary>
    private TreeNode LastVisibleChild
    {
      get
      {
        TreeNode lastVisibleChild = this;
        while (lastVisibleChild.IsExpanded && lastVisibleChild.LastChild != null)
          lastVisibleChild = lastVisibleChild.LastChild;
        return lastVisibleChild;
      }
    }

    /// <summary>
    /// Returns the last child of this node,
    /// if any, otherwise returns null
    /// </summary>
    private TreeNode LastChild
    {
      get
      {
        TreeNode lastChild = (TreeNode) null;
        if (this.Nodes != null && this.Nodes.Count > 0)
          lastChild = this.Nodes[this.Nodes.Count - 1];
        return lastChild;
      }
    }

    /// <summary>Gets the next sibling tree node.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the next sibling tree node.</returns>
    [Browsable(false)]
    public TreeNode NextNode
    {
      get
      {
        TreeNodeCollection parentNodes = this.ParentNodes;
        if (parentNodes == null)
          return (TreeNode) null;
        int index = this.Index;
        return parentNodes.Count > index + 1 ? parentNodes[index + 1] : (TreeNode) null;
      }
    }

    /// <summary>Gets the next visible tree node.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> that represents the next visible tree node.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public TreeNode NextVisibleNode => !this.IsExpanded || this.Nodes.Count <= 0 ? (this.NextNode == null ? this.NextUncle : this.NextNode) : this.Nodes[0];

    /// <summary>Gets or sets the node font.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Font NodeFont
    {
      get => this.GetValue<Font>(TreeNode.NodeFontProperty);
      set
      {
        if (!this.SetValue<Font>(TreeNode.NodeFontProperty, value))
          return;
        this.UpdateParams(AttributeType.Layout);
      }
    }

    /// <summary>Gets or sets the selected image index.</summary>
    /// <value></value>
    [SRCategory("CatBehavior")]
    [DefaultValue(-1)]
    public int SelectedImageIndex
    {
      get => this.GetValue<int>(TreeNode.SelectedImageIndexProperty);
      set
      {
        if (!this.SetValue<int>(TreeNode.SelectedImageIndexProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the index of the image used to indicate the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> when the parent <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> has its <see cref="P:Gizmox.WebGUI.Forms.TreeView.CheckBoxes"></see> property set to false.</summary>
    /// <returns>The index of the image used to indicate the state of the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("TreeView.StateImageList")]
    [SRDescription("TreeNodeStateImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public int StateImageIndex
    {
      get => this.GetValue<int>(TreeNode.StateImageIndexProperty);
      set
      {
        if (!this.SetValue<int>(TreeNode.StateImageIndexProperty, value))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the image index.</summary>
    /// <value></value>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("TreeView.ImageList")]
    [SRDescription("TreeNodeImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public int ImageIndex
    {
      get => this.GetValue<int>(TreeNode.ImageIndexProperty);
      set
      {
        if (!this.SetValue<int>(TreeNode.ImageIndexProperty, value))
          return;
        this.RemoveValue<string>(TreeNode.ImageKeyProperty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the key of the image displayed in the tree node when it is in a selected state.</summary>
    /// <returns>The key of the image displayed when the tree node is in a selected state.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("TreeView.ImageList")]
    [SRDescription("TreeNodeImageKeyDescr")]
    [Localizable(true)]
    [DefaultValue("")]
    public string SelectedImageKey
    {
      get => this.GetValue<string>(TreeNode.SelectedImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(TreeNode.SelectedImageKeyProperty, value))
          return;
        this.RemoveValue<int>(TreeNode.SelectedImageIndexProperty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the key of the image displayed in the tree node when it is in a selected state.</summary>
    /// <returns>The key of the image displayed when the tree node is in a selected state.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("TreeView.StateImageList")]
    [SRDescription("TreeNodeStateImageKeyDescr")]
    [Localizable(true)]
    [DefaultValue("")]
    public string StateImageKey
    {
      get => this.GetValue<string>(TreeNode.StateImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(TreeNode.StateImageKeyProperty, value))
          return;
        this.RemoveValue<int>(TreeNode.StateImageIndexProperty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
    /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("TreeView.ImageList")]
    [SRDescription("TreeNodeImageKeyDescr")]
    [Localizable(true)]
    [DefaultValue("")]
    public string ImageKey
    {
      get => this.GetValue<string>(TreeNode.ImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(TreeNode.ImageKeyProperty, value))
          return;
        this.RemoveValue<int>(TreeNode.ImageIndexProperty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets the parent tree view that the tree node is assigned to.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeView"></see> that represents the parent tree view that the tree node is assigned to, or null if the node has not been assigned to a tree view.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public TreeView TreeView => this.GetAncestorByType(typeof (TreeView)) as TreeView;

    /// <summary>Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> objects assigned to the current tree node.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TreeNodeCollection"></see> that represents the tree nodes assigned to the current tree node.</returns>
    /// <filterpriority>1</filterpriority>
    [ListBindable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Editor("Gizmox.WebGUI.Forms.Design.TreeNodeCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public TreeNodeCollection Nodes => this.mobjNodes;

    /// <summary>Gets a value indicating whether the tree node is in the expanded state.</summary>
    /// <returns>true if the tree node is in the expanded state; otherwise, false.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsExpanded
    {
      get => this.GetValue<bool>(TreeNode.IsExpandedProperty);
      set
      {
        if (this.IsExpanded == value)
          return;
        if (value)
          this.Expand();
        else
          this.Collapse(true);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TreeNode" /> is selected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if selected; otherwise, <c>false</c>.
    /// </value>
    internal bool Selected
    {
      get => this.GetState(Component.ComponentState.Selected);
      set => this.SetSelected(value, true);
    }

    /// <summary>Sets the selected.</summary>
    /// <param name="blnSelected">if set to <c>true</c> node is selected.</param>
    /// <param name="blnUpdate">if set to <c>true</c> update.</param>
    internal void SetSelected(bool blnSelected, bool blnUpdate)
    {
      this.SetState(Component.ComponentState.Selected, blnSelected);
      if (blnUpdate)
        this.Update();
      if (!blnSelected)
        return;
      this.EnsureVisiblePath();
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TreeNode" /> is checked.
    /// </summary>
    /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    public bool Checked
    {
      get => this.GetState(Component.ComponentState.Checked);
      set => this.ChangeCheckState(value, TreeViewAction.Unknown);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TreeNode" /> is loaded.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if loaded; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool Loaded
    {
      get => this.GetState(Component.ComponentState.Loaded);
      set => this.SetState(Component.ComponentState.Loaded, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance has nodes.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has nodes; otherwise, <c>false</c>.
    /// </value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool HasNodes
    {
      get => this.GetValue<bool>(TreeNode.HasNodesProperty);
      set => this.SetValue<bool>(TreeNode.HasNodesProperty, value);
    }

    /// <summary>The tree node name</summary>
    [Browsable(false)]
    public string Name
    {
      get => this.GetValue<string>(TreeNode.NameProperty);
      set => this.SetValue<string>(TreeNode.NameProperty, value);
    }

    /// <summary>The tree node label</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Label
    {
      get => this.Text;
      set => this.Text = value;
    }

    /// <summary>Gets or sets the text.</summary>
    /// <value></value>
    [Localizable(true)]
    [DefaultValue("")]
    public string Text
    {
      get => this.TextInternal;
      set
      {
        if (!(this.TextInternal != value))
          return;
        this.TextInternal = value;
        this.Update();
      }
    }

    /// <summary>Gets or sets the text internal.</summary>
    /// <value>The text internal.</value>
    private string TextInternal
    {
      get => this.GetValue<string>(TreeNode.LabelProperty);
      set => this.SetValue<string>(TreeNode.LabelProperty, value);
    }

    /// <summary>The tree node icon</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public ResourceHandle Image
    {
      get => this.GetImage(TreeNode.ImageProperty, this.ImageList, this.ImageIndex, this.ImageKey, this.TreeView != null ? this.TreeView.ImageIndex : -1, this.TreeView != null ? this.TreeView.ImageKey : string.Empty);
      set
      {
        if (!this.SetImage(TreeNode.ImageProperty, value, this.ImageList))
          return;
        bool flag = false;
        if (this.InternalParent != null)
        {
          TreeNodeCollection nodesFromComponent = this.GetTreeNodesFromComponent(this.InternalParent);
          if (nodesFromComponent != null)
          {
            foreach (TreeNode treeNode in (BaseCollection) nodesFromComponent)
            {
              if (treeNode != this && treeNode.Image != null)
              {
                flag = true;
                break;
              }
            }
            if (!flag)
              this.InternalParent.Update();
          }
        }
        if (!flag)
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets the tree nodes from component.</summary>
    /// <param name="objComponent">The component.</param>
    /// <returns></returns>
    private TreeNodeCollection GetTreeNodesFromComponent(Component objComponent)
    {
      switch (objComponent)
      {
        case TreeView treeView:
          return treeView.Nodes;
        case TreeNode treeNode:
          return treeNode.Nodes;
        default:
          return (TreeNodeCollection) null;
      }
    }

    /// <summary>Shoulds the serialize image.</summary>
    /// <returns></returns>
    protected bool ShouldSerializeImage() => (this.TreeView == null || this.TreeView.ImageList == null) && this.Image != null;

    /// <summary>Gets the image list.</summary>
    /// <value>The image list.</value>
    private ImageList ImageList => this.TreeView != null ? this.TreeView.ImageList : (ImageList) null;

    /// <summary>Gets the image list.</summary>
    /// <value>The image list.</value>
    private ImageList StateImageList => this.TreeView != null ? this.TreeView.StateImageList : (ImageList) null;

    /// <summary>The selected tree node icon</summary>
    [DefaultValue(null)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ResourceHandle SelectedImage
    {
      get => this.GetImage(TreeNode.SelectedImageProperty, this.ImageList, this.SelectedImageIndex, this.SelectedImageKey, this.TreeView != null ? this.TreeView.SelectedImageIndex : -1, this.TreeView != null ? this.TreeView.SelectedImageKey : string.Empty);
      set
      {
        if (!this.SetImage(TreeNode.SelectedImageProperty, value, this.ImageList))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>The selected tree node icon</summary>
    [DefaultValue(null)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ResourceHandle StateImage
    {
      get => this.GetImage(TreeNode.StateImageProperty, this.StateImageList, this.StateImageIndex, this.StateImageKey, -1, string.Empty);
      set => this.SetImage(TreeNode.StateImageProperty, value, this.StateImageList);
    }

    /// <summary>The expanded tree node icon</summary>
    [DefaultValue(null)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ResourceHandle ExpandedImage
    {
      get => this.GetImage(TreeNode.ExpandedImageProperty, this.ImageList, this.ExpandedImageIndex, this.ExpandedImageKey, this.TreeView != null ? this.TreeView.ExpandedImageIndex : -1, this.TreeView != null ? this.TreeView.ExpandedImageKey : string.Empty);
      set
      {
        if (!this.SetImage(TreeNode.ExpandedImageProperty, value, this.ImageList))
          return;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the expanded image index.</summary>
    /// <value></value>
    [SRCategory("CatBehavior")]
    [DefaultValue(-1)]
    public int ExpandedImageIndex
    {
      get => this.GetValue<int>(TreeNode.ExpandedImageIndexProperty);
      set
      {
        if (!this.SetValue<int>(TreeNode.ExpandedImageIndexProperty, value))
          return;
        this.RemoveValue<string>(TreeNode.ExpandedImageKeyProperty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the key of the image displayed in the tree node when it is Expanded.</summary>
    /// <returns>The key of the image displayed when the tree node is Expanded.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.TreeViewImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [RelatedImageList("TreeView.ImageList")]
    [SRDescription("TreeNodeImageKeyDescr")]
    [Localizable(true)]
    [DefaultValue("")]
    public string ExpandedImageKey
    {
      get => this.GetValue<string>(TreeNode.ExpandedImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(TreeNode.ExpandedImageKeyProperty, value))
          return;
        this.RemoveValue<int>(TreeNode.ExpandedImageIndexProperty);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets the bounds of the tree node.</summary>
    /// <returns>The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds of the tree node.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rectangle Bounds => Rectangle.Empty;

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="objComponent">The component.</param>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) this.Nodes;

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      string text = this.Text;
      return string.Format("TreeNode: {0}", string.IsNullOrEmpty(text) ? (object) string.Empty : (object) text);
    }

    /// <summary>Toggles the tree node to either the expanded or collapsed state.</summary>
    public void Toggle()
    {
      if (this.IsExpanded)
        this.Collapse();
      else
        this.Expand();
    }

    /// <summary>Removes the current tree node from the tree view control.</summary>
    public void Remove() => this.ParentNodes?.Remove(this);

    /// <summary>Expands all the child tree nodes.</summary>
    public void ExpandAll()
    {
      this.Expand();
      foreach (TreeNode node in (BaseCollection) this.Nodes)
        node.ExpandAll();
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

    /// <summary>Expands the tree node.</summary>
    public void Expand()
    {
      if (this.IsExpanded || this.OnBeforeExpand())
        return;
      this.SetValue<bool>(TreeNode.IsExpandedProperty, true);
      this.Update();
      this.OnAfterExpand();
    }

    /// <summary>Initiates the editing of the tree node label.</summary>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.TreeView.LabelEdit"></see> is set to false. </exception>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void BeginEdit()
    {
      if (this.TreeView == null || !this.TreeView.LabelEdit)
        return;
      this.TreeView.EditNode = this;
      this.InvokeMethodWithId("LabelEditor_Show");
    }

    /// <summary>Ends the editing of the tree node label.</summary>
    /// <param name="blnCancel">true if the editing of the tree node label text was canceled without being saved; otherwise, false. </param>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void EndEdit(bool blnCancel)
    {
    }

    /// <summary>Ensures that the tree node is visible, expanding tree nodes and scrolling the tree view control as necessary.</summary>
    public void EnsureVisible()
    {
      this.EnsureVisiblePath();
      this.InvokeMethodWithId("Controls_ScrollIntoView", null, (object) 0);
    }

    /// <summary>Ensures that the tree path is visible</summary>
    private void EnsureVisiblePath()
    {
      if (this.Parent == null)
        return;
      if (!this.Parent.IsExpanded)
        this.Parent.Expand();
      this.Parent.EnsureVisiblePath();
    }

    /// <summary>Collapses the tree node.</summary>
    public void Collapse() => this.Collapse(false);

    /// <summary>Collapses the <see cref="T:Gizmox.WebGUI.Forms.TreeNode"></see> and optionally collapses its children.</summary>
    /// <param name="blnIgnoreChildren">true to leave the child nodes in their current state; false to collapse the child nodes.</param>
    public void Collapse(bool blnIgnoreChildren)
    {
      if (this.IsExpanded && !this.OnBeforeCollapse())
      {
        this.SetValue<bool>(TreeNode.IsExpandedProperty, false);
        this.Update();
        this.OnAfterCollapse();
      }
      if (blnIgnoreChildren)
        return;
      foreach (TreeNode node in (BaseCollection) this.Nodes)
        node.Collapse(false);
    }

    /// <summary>Gets the full path.</summary>
    /// <param name="objPath">Path builder.</param>
    /// <param name="strPathSeparator">Path separator.</param>
    private void GetFullPath(StringBuilder objPath, string strPathSeparator)
    {
      if (this.Parent != null)
      {
        this.Parent.GetFullPath(objPath, strPathSeparator);
        objPath.Append(strPathSeparator);
      }
      objPath.Append(this.Text);
    }

    /// <summary>Returns the number of child tree nodes.</summary>
    /// <param name="blnIncludeSubTrees">true if the resulting count includes all tree nodes indirectly rooted at this tree node; otherwise, false . </param>
    /// <returns></returns>
    public int GetNodeCount(bool blnIncludeSubTrees)
    {
      TreeNodeCollection nodes = this.Nodes;
      int count = nodes.Count;
      if (blnIncludeSubTrees && nodes != null)
      {
        foreach (TreeNode treeNode in (BaseCollection) nodes)
          count += treeNode.GetNodeCount(true);
      }
      return count;
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      TreeNodeCollection nodes = this.Nodes;
      if (nodes == null)
        return;
      foreach (IRegisteredComponent registeredComponent in (BaseCollection) nodes)
        registeredComponent.RegisterComponents();
      this.RegisterBatch((ICollection) nodes);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      TreeNodeCollection nodes = this.Nodes;
      if (nodes == null)
        return;
      foreach (IRegisteredComponent registeredComponent in (BaseCollection) nodes)
        registeredComponent.UnregisterComponents();
      this.UnRegisterBatch((ICollection) nodes);
    }

    /// <summary>Change check state</summary>
    /// <param name="blnValue">the new check value</param>
    /// <param name="enmTreeViewAction">treeview action</param>
    private void ChangeCheckState(bool blnValue, TreeViewAction enmTreeViewAction)
    {
      if (!this.OnBeforeCheck(enmTreeViewAction))
      {
        if (enmTreeViewAction == TreeViewAction.ByMouse)
          this.SetState(Component.ComponentState.Checked, blnValue);
        else if (this.SetStateWithCheck(Component.ComponentState.Checked, blnValue))
          this.Update();
        this.OnAfterCheck();
      }
      else
      {
        if (enmTreeViewAction != TreeViewAction.ByMouse)
          return;
        this.Update();
      }
    }

    /// <summary>Copies the tree node and the entire subtree rooted at this tree node.</summary>
    /// <returns>The <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGui.Forms.TreeNode"></see>.</returns>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public virtual object Clone()
    {
      Type type = this.GetType();
      TreeNode treeNode;
      if (type == typeof (TreeNode))
      {
        treeNode = new TreeNode(this.Text, this.ImageIndex, this.SelectedImageIndex);
      }
      else
      {
        treeNode = (TreeNode) Activator.CreateInstance(type);
        treeNode.Text = this.Text;
        treeNode.ImageIndex = this.ImageIndex;
        treeNode.SelectedImageIndex = this.SelectedImageIndex;
      }
      treeNode.Name = this.Name;
      treeNode.StateImageIndex = this.StateImageIndex;
      treeNode.ToolTipText = this.ToolTipText;
      treeNode.ContextMenu = this.ContextMenu;
      treeNode.ContextMenuStrip = this.ContextMenuStrip;
      treeNode.DragTargets = this.DragTargets;
      treeNode.AllowDrop = this.AllowDrop;
      treeNode.Animation = this.Animation;
      string imageKey = this.ImageKey;
      if (!string.IsNullOrEmpty(imageKey))
        treeNode.ImageKey = imageKey;
      string selectedImageKey = this.SelectedImageKey;
      if (!string.IsNullOrEmpty(selectedImageKey))
        treeNode.SelectedImageKey = selectedImageKey;
      string stateImageKey = this.StateImageKey;
      if (!string.IsNullOrEmpty(stateImageKey))
        treeNode.StateImageKey = stateImageKey;
      int nodeCount = this.GetNodeCount(false);
      if (nodeCount > 0)
      {
        foreach (TreeNode node in (BaseCollection) this.Nodes)
          node.ExpandAll();
        for (int intIndex = 0; intIndex < nodeCount; ++intIndex)
          treeNode.Nodes.Add((TreeNode) this.Nodes[intIndex].Clone());
      }
      treeNode.Checked = this.Checked;
      treeNode.Tag = this.Tag;
      return (object) treeNode;
    }

    /// <summary>Registers the self node.</summary>
    internal void RegisterSelfNode() => this.RegisterSelf();

    /// <summary>Uns the register self node.</summary>
    internal void UnRegisterSelfNode() => this.UnRegisterSelf();
  }
}

// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListViewItem
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Implementation of ListViewItem class.</summary>
  [DesignTimeVisible(false)]
  [TypeConverter(typeof (ListViewItemConverter))]
  [ToolboxItem(false)]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class ListViewItem : Component
  {
    /// <summary>Provides a property reference to LargeImage property.</summary>
    private static readonly SerializableProperty LargeImageProperty = SerializableProperty.Register(nameof (LargeImage), typeof (ResourceHandle), typeof (ListViewItem));
    /// <summary>Provides a property reference to Image property.</summary>
    private static readonly SerializableProperty SmallImageProperty = SerializableProperty.Register(nameof (Image), typeof (ResourceHandle), typeof (ListViewItem));
    /// <summary>The mintImageIndex property registration.</summary>
    private static readonly SerializableProperty ImageIndexProperty = SerializableProperty.Register(nameof (ImageIndex), typeof (int), typeof (ListViewItem), new SerializablePropertyMetadata((object) -1));
    /// <summary>The DataItemIndex property registration.</summary>
    private static readonly SerializableProperty DataItemIndexProperty = SerializableProperty.Register(nameof (DataItemIndex), typeof (int), typeof (ListViewItem), new SerializablePropertyMetadata((object) -1));
    private static readonly SerializableProperty ToolTipTextProperty = SerializableProperty.Register(nameof (ToolTipText), typeof (string), typeof (ListViewItem), new SerializablePropertyMetadata((object) string.Empty));
    private static readonly SerializableProperty ImageKeyProperty = SerializableProperty.Register(nameof (ImageKey), typeof (string), typeof (ListViewItem), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The mintIndentCount property registration.</summary>
    private static readonly SerializableProperty IndentCountProperty = SerializableProperty.Register(nameof (IndentCount), typeof (int), typeof (ListViewItem), new SerializablePropertyMetadata((object) 0));
    /// <summary>The group property registration.</summary>
    private static readonly SerializableProperty GroupProperty = SerializableProperty.Register(nameof (Group), typeof (ListViewGroup), typeof (ListViewItem), new SerializablePropertyMetadata((object) null));
    /// <summary>The collection of subitems</summary>
    [NonSerialized]
    private ListViewItem.ListViewSubItemCollection mobjSubItems;
    /// <summary>Use item</summary>
    [NonSerialized]
    private bool mblnUseItemStyleForSubItems = true;
    /// <summary>The AfterLabelEdit event registration.</summary>
    private static readonly SerializableEvent AfterLabelEditEvent = SerializableEvent.Register("AfterLabelEdit", typeof (LabelEditEventHandler), typeof (ListViewItem));
    /// <summary>The amount of fields we are serializing</summary>
    private const int mcntSerializableFieldCount = 1;

    /// <summary>Occurs when [client after label edit].</summary>
    [SRDescription("Occurs when control's label edited in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientAfterLabelEdit
    {
      add => this.AddClientHandler("AfterLabelEdit", value);
      remove => this.RemoveClientHandler("AfterLabelEdit", value);
    }

    /// <summary>Occurs after the list item label text is edited.</summary>
    [Browsable(false)]
    [SRDescription("ListViewItemAfterEditDescr")]
    protected event LabelEditEventHandler AfterLabelEdit
    {
      add => this.AddHandler(ListViewItem.AfterLabelEditEvent, (Delegate) value);
      remove => this.RemoveHandler(ListViewItem.AfterLabelEditEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the AfterLabelEdit event.</summary>
    private LabelEditEventHandler AfterLabelEditHandler => (LabelEditEventHandler) this.GetHandler(ListViewItem.AfterLabelEditEvent);

    /// <summary>
    /// 
    /// </summary>
    public ListViewItem()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
    /// </summary>
    /// <param name="strText">The text of the first sub item.</param>
    public ListViewItem(string strText) => this.SubItems.Add(strText);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
    /// </summary>
    /// <param name="arrItems">The sub items.</param>
    public ListViewItem(string[] arrItems)
    {
      if (arrItems.Length == 0)
        return;
      this.SubItems.AddRange(arrItems);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
    /// </summary>
    /// <param name="strText">The STR text.</param>
    /// <param name="intImageIndex">Index of the int image.</param>
    public ListViewItem(string strText, int intImageIndex)
      : this(strText)
    {
      this.ImageIndex = intImageIndex;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
    /// </summary>
    /// <param name="strText">The STR text.</param>
    /// <param name="strImageKey">The STR image key.</param>
    public ListViewItem(string strText, string strImageKey)
      : this(strText)
    {
      this.ImageKey = strImageKey;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> class.
    /// </summary>
    /// <param name="arrItems">The sub items.</param>
    /// <param name="intImageIndex">The index of the image in the image list.</param>
    public ListViewItem(string[] arrItems, int intImageIndex)
    {
      this.SubItems.AddRange(arrItems);
      this.ImageIndex = intImageIndex;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrSubItems"></param>
    /// <param name="intImageIndex"></param>
    public ListViewItem(ListViewItem.ListViewSubItem[] arrSubItems, int intImageIndex)
    {
      if (arrSubItems.Length == 0)
        return;
      this.SubItems.AddRange(arrSubItems);
      this.Text = arrSubItems[0].Text;
      this.ImageIndex = intImageIndex;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrItems"></param>
    /// <param name="intImageIndex"></param>
    /// <param name="objForeColor"></param>
    /// <param name="objBackColor"></param>
    /// <param name="objFont"></param>
    public ListViewItem(
      string[] arrItems,
      int intImageIndex,
      Color objForeColor,
      Color objBackColor,
      Font objFont)
    {
      this.SubItems.AddRange(arrItems);
      this.ImageIndex = intImageIndex;
      this.ForeColor = objForeColor;
      this.BackColor = objBackColor;
      this.Font = objFont;
    }

    /// <summary>
    /// The size of the initiale serialization data array which is the optmized serialization graph.
    /// </summary>
    /// <value></value>
    /// <remarks>
    /// This value should be the actual size needed so that re-allocations and truncating will not be required.
    /// </remarks>
    protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 1 + SerializationWriter.GetRequiredCapacity((ICollection) this.mobjSubItems);

    /// <summary>Called when [swipe].</summary>
    /// <param name="enmSwipeDirection">The swipe direction.</param>
    protected override void OnSwipe(SwipeDirection enmSwipeDirection)
    {
      base.OnSwipe(enmSwipeDirection);
      this.ListView?.OnItemSwipe(this, enmSwipeDirection);
    }

    /// <summary>
    /// Called when serializable object is deserialized and we need to extract the optimized
    /// object graph to the working graph.
    /// </summary>
    /// <param name="objReader">The optimized object graph reader.</param>
    protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
    {
      base.OnSerializableObjectDeserializing(objReader);
      this.mblnUseItemStyleForSubItems = objReader.ReadBoolean();
      object[] arrSubItems = objReader.ReadArray();
      if (arrSubItems.Length == 0)
        return;
      this.mobjSubItems = new ListViewItem.ListViewSubItemCollection(this, arrSubItems);
    }

    /// <summary>
    /// Called before serializable object is serialized to optimize the application object graph.
    /// </summary>
    /// <param name="objWriter">The optimized object graph writer.</param>
    protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
    {
      base.OnSerializableObjectSerializing(objWriter);
      objWriter.WriteBoolean(this.mblnUseItemStyleForSubItems);
      objWriter.WriteArray((ICollection) this.mobjSubItems);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      ListView listView = this.ListView;
      if (listView != null)
      {
        CriticalEventsData eventsDataInternal = listView.GetCriticalEventsDataInternal();
        if (eventsDataInternal.HasEvent("CL"))
          criticalEventsData.Set("CL");
        if (eventsDataInternal.HasEvent("DCL"))
          criticalEventsData.Set("DCL");
        if (eventsDataInternal.HasEvent("CL") || this.ContextMenu != null || listView != null && listView.ContextMenu != null)
          criticalEventsData.Set("RC");
        if (eventsDataInternal.HasEvent("SWP"))
          criticalEventsData.Set("SWP");
        if (eventsDataInternal.HasEvent("ALE"))
          criticalEventsData.Set("ALE");
      }
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("AfterLabelEdit"))
        clientEventsData.Set("ALE");
      return clientEventsData;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        case "KeyDown":
          if (this.ListView != null)
          {
            this.ListView.FireKeyDown(objEvent);
            break;
          }
          break;
        case "DoubleClick":
          if (this.ListView != null)
          {
            this.ListView.OnItemClick(this, this.CreateMouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
            this.ListView.OnItemDoubleClick(this, this.CreateMouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 2, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
            break;
          }
          break;
        case "Click":
          if (this.ListView != null)
          {
            this.ListView.OnItemClick(this, this.CreateMouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
            break;
          }
          break;
        case "RightClick":
          if (this.ListView != null)
          {
            this.ListView.OnItemClick(this, this.CreateMouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Right), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
            break;
          }
          break;
        case "AfterLabelEdit":
          string strLabel = CommonUtils.DecodeText(objEvent["Text"]);
          LabelEditEventArgs e = new LabelEditEventArgs(this.Index, strLabel);
          this.OnAfterLabelEdit(e);
          if (!e.CancelEdit)
          {
            this.TextInternal = strLabel;
            break;
          }
          this.UpdateParams(AttributeType.Control);
          break;
      }
      base.FireEvent(objEvent);
    }

    /// <summary>Creates a mouse event arguments object.</summary>
    /// <param name="enmMouseButtons">The mouse buttons.</param>
    /// <param name="intClicks">The int clicks.</param>
    /// <param name="intX">The int X.</param>
    /// <param name="intY">The int Y.</param>
    /// <param name="intDelta">The int delta.</param>
    /// <returns></returns>
    private MouseEventArgs CreateMouseEventArgs(
      MouseButtons enmMouseButtons,
      int intClicks,
      int intX,
      int intY,
      int intDelta)
    {
      this.ListView?.GetRelativeXYFromItem(this, ref intX, ref intY);
      return new MouseEventArgs(enmMouseButtons, intClicks, intX, intY, intDelta);
    }

    /// <summary>Renders the node.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    /// <param name="lngRequestID">Request ID.</param>
    internal virtual void RenderItem(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      ListView.ItemRenderingProcessor objProcessor)
    {
      if (this.IsDirty(lngRequestID))
        this.RenderDirtyItem(objContext, objWriter, objProcessor, 0L);
      else if (this.IsDirtyAttributes(lngRequestID))
        this.RenderDirtyItem(objContext, objWriter, objProcessor, lngRequestID);
      else
        this.RenderNonDirtyItem(objContext, objWriter, lngRequestID, objProcessor);
    }

    /// <summary>Renders the dirty item.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objProcessor">The processor.</param>
    internal virtual void RenderDirtyItem(
      IContext objContext,
      IResponseWriter objWriter,
      ListView.ItemRenderingProcessor objProcessor,
      long lngRequestID)
    {
      List<Control> controlList = (List<Control>) null;
      bool styleForSubItems = this.UseItemStyleForSubItems;
      if (lngRequestID == 0L || objProcessor.View == View.Details)
        objWriter.WriteStartElement("R");
      else
        objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
      objWriter.WriteAttributeString("Id", this.GetProxyPropertyValue<long>("ID", this.ID).ToString());
      this.RenderIsDirtyAttributes(objContext, (IAttributeWriter) objWriter);
      this.RenderUpdateAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID);
      this.RenderComponentEventAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID != 0L);
      this.RenderDragAndDropAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID != 0L);
      this.RenderExtendedComponentAttributes(objContext, (IAttributeWriter) objWriter);
      this.RenderComponentVisualEffectsAttributes(objContext, (IAttributeWriter) objWriter);
      this.RenderItemImage(objWriter, objProcessor.View);
      if (this.Selected)
        objWriter.WriteAttributeString("SE", "1");
      if (this.Checked)
        objWriter.WriteAttributeString("C", "1");
      if (styleForSubItems)
        objWriter.WriteAttributeString("UIS", "1");
      if (objProcessor.ShowItemToolTips)
      {
        string toolTipText = this.ToolTipText;
        if (!string.IsNullOrEmpty(toolTipText))
          objWriter.WriteAttributeText("TT", toolTipText);
      }
      if (objProcessor.View == View.Details)
      {
        if (this.mobjSubItems != null)
        {
          foreach (ColumnHeader sortedColumn in (IEnumerable) objProcessor.SortedColumns)
          {
            if (sortedColumn.IsValidColumn)
            {
              objWriter.WriteStartElement("SI");
              objWriter.WriteAttributeString("COL", sortedColumn.Index.ToString());
              if (this.mobjSubItems.Count > sortedColumn.Index)
              {
                ListViewItem.ListViewSubItem mobjSubItem = this.mobjSubItems[sortedColumn.Index];
                if (!styleForSubItems || sortedColumn.Index == 0)
                  mobjSubItem.RenderStyle(objWriter, "s", mobjSubItem.BackColor, mobjSubItem.ForeColor, mobjSubItem.Font);
                if (mobjSubItem is ListViewItem.ListViewSubControlItem viewSubControlItem)
                {
                  objWriter.WriteAttributeString("c", viewSubControlItem.Control.GetProxyPropertyValue<long>("ID", viewSubControlItem.Control.ID).ToString());
                  if (controlList == null)
                    controlList = new List<Control>();
                  controlList.Add(viewSubControlItem.Control);
                }
                else
                  objWriter.WriteAttributeText("c", mobjSubItem.Text);
              }
              else
                objWriter.WriteAttributeString("c", string.Empty);
              objWriter.WriteEndElement();
            }
          }
        }
        int indentCount = this.IndentCount;
        if (indentCount != 0)
          objWriter.WriteAttributeString("IDC", indentCount.ToString());
      }
      else if (this.HasSubItems)
      {
        objWriter.WriteStartElement("SI");
        objWriter.WriteAttributeString("COL", "0");
        ListViewItem.ListViewSubItem mobjSubItem = this.mobjSubItems[0];
        objWriter.WriteAttributeText("c", mobjSubItem.Text);
        mobjSubItem.RenderStyle(objWriter, "s", mobjSubItem.BackColor, mobjSubItem.ForeColor, mobjSubItem.Font);
        objWriter.WriteEndElement();
      }
      if (controlList != null)
      {
        foreach (IRenderableComponent renderableComponent in controlList)
          renderableComponent.RenderComponent(objContext, objWriter, lngRequestID);
      }
      objWriter.WriteEndElement();
    }

    /// <summary>Renders the update attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    private void RenderUpdateAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      objWriter.WriteAttributeText("TX", this.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Renders the item image.</summary>
    /// <param name="objWriter">The obj writer.</param>
    private void RenderItemImage(IResponseWriter objWriter, View enmView)
    {
      if (enmView == View.LargeIcon)
      {
        ResourceHandle largeImage = this.LargeImage;
        if (largeImage == null)
          return;
        objWriter.WriteAttributeString("LIM", largeImage.ToString());
      }
      else
      {
        ResourceHandle smallImage = this.SmallImage;
        if (smallImage == null)
          return;
        objWriter.WriteAttributeString("IM", smallImage.ToString());
      }
    }

    /// <summary>Renders non dirty item.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request id.</param>
    private void RenderNonDirtyItem(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      ListView.ItemRenderingProcessor objProcessor)
    {
      if (objProcessor.View != View.Details)
        return;
      if (this.mobjSubItems != null)
      {
        foreach (ColumnHeader sortedColumn in (IEnumerable) objProcessor.SortedColumns)
        {
          if (sortedColumn.IsValidColumn && this.mobjSubItems.Count > sortedColumn.Index && this.mobjSubItems[sortedColumn.Index] is ListViewItem.ListViewSubControlItem mobjSubItem)
            ((IRenderableComponent) mobjSubItem.Control).RenderComponent(objContext, objWriter, lngRequestID);
        }
      }
      if (!(this is ListViewPanelItem listViewPanelItem))
        return;
      ((IRenderableComponent) listViewPanelItem.Panel).RenderComponent(objContext, objWriter, lngRequestID);
    }

    /// <summary>
    /// 
    /// </summary>
    internal void InternalUnRegisterSelf() => this.UnRegisterSelf();

    /// <summary>
    /// 
    /// </summary>
    public void Remove()
    {
      if (this.ListView == null)
        return;
      this.UnRegisterSelf();
      this.ListView.Items.Remove(this);
    }

    /// <summary>Ensures that the item is visible within the control, scrolling the contents of the control, if necessary.</summary>
    public virtual void EnsureVisible()
    {
      if (this.ListView.UseInternalPaging)
      {
        int itemPage = this.GetItemPage();
        if (this.ListView.CurrentPage != itemPage)
          this.ListView.CurrentPage = itemPage;
      }
      this.InvokeMethodWithId("Controls_ScrollIntoView", (object) this.ListView.ID, (object) 1);
    }

    /// <summary>Gets the item page.</summary>
    /// <returns></returns>
    private int GetItemPage()
    {
      int itemPage = 1;
      if (this.ListView.UseInternalPaging && this.ListView.TotalPages > 1)
      {
        int num = 0;
        foreach (ListViewItem listViewItem in this.ListView.Items)
        {
          ++num;
          if (listViewItem == this)
            break;
        }
        itemPage = (int) Math.Ceiling((double) num / (double) this.ListView.ItemsPerPage);
      }
      return itemPage;
    }

    /// <summary>
    /// Raises the <see cref="E:AfterLabelEdit" /> event.
    /// </summary>
    /// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.ListViewItemLabelEditEventArgs" /> instance containing the event data.</param>
    protected internal virtual void OnAfterLabelEdit(LabelEditEventArgs e)
    {
      LabelEditEventHandler labelEditHandler = this.AfterLabelEditHandler;
      if (labelEditHandler != null)
        labelEditHandler((object) this, e);
      if (this.ListView == null)
        return;
      this.ListView.OnAfterLabelEditInternal(e);
    }

    /// <summary>Initiates the editing of the item label.</summary>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.TreeView.LabelEdit"></see> is set to false. </exception>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void BeginEdit()
    {
      if (this.ListView == null || !this.ListView.LabelEdit || !this.ListView.Focused)
        return;
      this.InvokeMethodWithId("LabelEditor_Show");
    }

    /// <summary>Ends the editing of the tree node label.</summary>
    /// <param name="blnCancel">true if the editing of the tree node label text was canceled without being saved; otherwise, false. </param>
    /// <filterpriority>2</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void EndEdit(bool blnCancel)
    {
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
    {
      List<Control> componentOffsprings = new List<Control>();
      foreach (ListViewItem.ListViewSubItem subItem in this.SubItems)
      {
        if (subItem is ListViewItem.ListViewSubControlItem viewSubControlItem)
          componentOffsprings.Add(viewSubControlItem.Control);
      }
      return (IList) componentOffsprings;
    }

    /// <summary>Gets or sets the name associated with this control.</summary>
    /// <value></value>
    [Localizable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string Name
    {
      get => this.SubItems.Count == 0 ? string.Empty : this.SubItems[0].Name;
      set => this.SubItems[0].Name = value;
    }

    /// <summary>Gets or sets the group to which the item is assigned.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to which the item is assigned.</returns>
    [Localizable(true)]
    [DefaultValue(null)]
    [SRCategory("CatBehavior")]
    public ListViewGroup Group
    {
      get => this.GetValue<ListViewGroup>(ListViewItem.GroupProperty);
      set
      {
        ListViewGroup group = this.Group;
        if (group == value)
          return;
        if (value != null)
          value.Items.Add(this);
        else
          group?.Items.Remove(this);
        if (this.ListView == null)
          return;
        this.ListView.Update();
      }
    }

    /// <summary>Moves to group.</summary>
    /// <param name="objNewGroup">The new group.</param>
    internal void MoveToGroup(ListViewGroup objNewGroup) => this.SetValue<ListViewGroup>(ListViewItem.GroupProperty, objNewGroup);

    /// <summary>Should the serialize large image.</summary>
    protected bool ShouldSerializeSmallImage() => this.SmallImageList == null && this.ContainsValue<ResourceHandle>(ListViewItem.SmallImageProperty);

    /// <summary>Gets or sets the small image that is displayed for the item.</summary>
    /// <returns>The small image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    /// <remarks>This property does not work and throws an exception if the owning listview has a ImageList set.</remarks>
    public ResourceHandle SmallImage
    {
      get => this.GetImage(ListViewItem.SmallImageProperty, this.SmallImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
      set => this.SetImage(ListViewItem.SmallImageProperty, value, this.ImageList);
    }

    /// <summary>
    /// Backwards compatibility Image property (use SmallImage instead)
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(null)]
    [Obsolete("Please use the 'SmallImage' property instead.")]
    public ResourceHandle Image
    {
      get => this.SmallImage;
      set => this.SmallImage = value;
    }

    /// <summary>Gets the zero-based index of the item within the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
    /// <returns>The zero-based index of the item within the <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control, or -1 if the item is not associated with a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
    [Browsable(false)]
    public int Index => this.ListView == null ? -1 : this.ListView.GetDisplayIndex(this);

    /// <summary>Gets or sets the number of small image widths by which to indent the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</summary>
    /// <returns>The number of small image widths by which to indent the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    [DefaultValue(0)]
    [SRDescription("ListViewItemIndentCountDescr")]
    [SRCategory("CatDisplay")]
    public int IndentCount
    {
      get => this.GetValue<int>(ListViewItem.IndentCountProperty);
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (IndentCount), SR.GetString("ListViewIndentCountCantBeNegative"));
        if (!this.SetValue<int>(ListViewItem.IndentCountProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Provides a way to define a large image for this list view item.
    /// </summary>
    /// <remarks>This property will throw an error if the owning list view has a large imagelist set to it.</remarks>
    public ResourceHandle LargeImage
    {
      get => this.GetImage(ListViewItem.LargeImageProperty, this.LargeImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
      set => this.SetImage(ListViewItem.LargeImageProperty, value, this.ImageList);
    }

    /// <summary>Gets or sets the text shown when the mouse pointer rests on the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</summary>
    /// <returns>The text shown when the mouse pointer rests on the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    [SRCategory("CatAppearance")]
    public string ToolTipText
    {
      get => this.GetValue<string>(ListViewItem.ToolTipTextProperty);
      set => this.SetValue<string>(ListViewItem.ToolTipTextProperty, value);
    }

    /// <summary>Shows the serialize large image.</summary>
    protected bool ShouldSerializeLargeImage() => this.LargeImageList == null && this.ContainsValue<ResourceHandle>(ListViewItem.LargeImageProperty);

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> is selected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if selected; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Selected
    {
      get => this.GetState(Component.ComponentState.Selected);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Selected, value))
          return;
        this.Update();
        if (this.ListView == null)
          return;
        this.ListView.FireSelectedIndexChanged(this);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal bool InternalSelected
    {
      get => this.GetState(Component.ComponentState.Selected);
      set => this.SetState(Component.ComponentState.Selected, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ListViewItem" /> is checked.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if checked; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    public bool Checked
    {
      get => this.GetState(Component.ComponentState.Checked);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Checked, value))
          return;
        if (this.ListView != null)
          this.ListView.FireItemCheck(this, value);
        this.Update();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    internal bool InternalChecked
    {
      get => this.GetState(Component.ComponentState.Checked);
      set => this.SetState(Component.ComponentState.Checked, value);
    }

    /// <summary>Gets or sets the font.</summary>
    /// <value></value>
    [DefaultValue(null)]
    public Font Font
    {
      get
      {
        if (this.SubItems != null && this.HasSubItems && this.SubItems[0].Font != null)
          return this.SubItems[0].Font;
        return this.ListView != null ? this.ListView.Font : this.DefaultFont;
      }
      set => this.SubItems[0].Font = value;
    }

    /// <summary>Gets or sets the background color of the item's text.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of the item's text.</returns>
    [SRCategory("CatAppearance")]
    public Color BackColor
    {
      get
      {
        if (this.HasSubItems)
          return this.SubItems[0].BackColor;
        return this.ListView != null ? this.ListView.BackColor : this.DefaultBackColor;
      }
      set => this.SubItems[0].BackColor = value;
    }

    /// <summary>Gets the bounds.</summary>
    /// <value>The bounds.</value>
    [Browsable(false)]
    public Rectangle Bounds => this.ListView != null ? this.ListView.GetItemRect(this.Index) : new Rectangle();

    /// <summary>Gets the default color of the back.</summary>
    /// <value>The default color of the back.</value>
    private Color DefaultBackColor
    {
      get
      {
        ListView listView = this.ListView;
        return listView != null ? listView.DefaultRowBackColor : SystemColors.Window;
      }
    }

    /// <summary>Gets the default color of the fore.</summary>
    /// <value>The default color of the fore.</value>
    private Color DefaultForeColor
    {
      get
      {
        ListView listView = this.ListView;
        return listView != null ? listView.DefaultRowForeColor : Color.Black;
      }
    }

    /// <summary>Gets the default font.</summary>
    /// <value>The default font.</value>
    private Font DefaultFont => this.ListView?.DefaultRowFont;

    /// <summary>Gets or sets the foreground color of the item's text.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of the item's text.</returns>
    [SRCategory("CatAppearance")]
    public Color ForeColor
    {
      get
      {
        if (this.HasSubItems)
          return this.SubItems[0].ForeColor;
        return this.ListView != null ? this.ListView.ForeColor : this.DefaultForeColor;
      }
      set => this.SubItems[0].ForeColor = value;
    }

    /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
    /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
    /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [DefaultValue(-1)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRDescription("ListViewItemImageIndexDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    public int ImageIndex
    {
      get => this.GetValue<int>(ListViewItem.ImageIndexProperty);
      set
      {
        if (!this.SetValue<int>(ListViewItem.ImageIndexProperty, value))
          return;
        this.RemoveValue<string>(ListViewItem.ImageKeyProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the index of the data item.</summary>
    /// <value>The index of the data item.</value>
    [DefaultValue(-1)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [SRDescription("ListViewItemDataItemIndexDescr")]
    [SRCategory("CatData")]
    public int DataItemIndex
    {
      get => this.GetValue<int>(ListViewItem.DataItemIndexProperty);
      internal set => this.SetValue<int>(ListViewItem.DataItemIndexProperty, value);
    }

    /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
    /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Localizable(true)]
    [DefaultValue("")]
    public string ImageKey
    {
      get => this.GetValue<string>(ListViewItem.ImageKeyProperty);
      set
      {
        if (!this.SetValue<string>(ListViewItem.ImageKeyProperty, value))
          return;
        this.RemoveValue<int>(ListViewItem.ImageIndexProperty);
        this.Update();
      }
    }

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the image displayed with the item.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> used by the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains the image displayed with the item.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public ImageList ImageList
    {
      get
      {
        if (this.ListView != null)
        {
          switch (this.ListView.View)
          {
            case View.Details:
            case View.List:
            case View.SmallIcon:
              return this.ListView.SmallImageList;
            case View.LargeIcon:
              return this.ListView.LargeImageList;
          }
        }
        return (ImageList) null;
      }
    }

    /// <summary>Gets the large image list.</summary>
    /// <value>The large image list.</value>
    private ImageList LargeImageList => this.ListView != null ? this.ListView.LargeImageList : (ImageList) null;

    /// <summary>Gets the small image list.</summary>
    /// <value>The small image list.</value>
    private ImageList SmallImageList => this.ListView != null ? this.ListView.SmallImageList : (ImageList) null;

    /// <summary>Gets the list view.</summary>
    /// <value></value>
    [Browsable(false)]
    public ListView ListView => this.InternalParent as ListView;

    /// <summary>Gets or sets the internal list view.</summary>
    /// <value></value>
    internal ListView InternalListView
    {
      get => this.InternalParent as ListView;
      set => this.InternalParent = (Component) value;
    }

    /// <summary>Gets the sub items.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ListViewItemSubItemsDescr")]
    [SRCategory("CatData")]
    public ListViewItem.ListViewSubItemCollection SubItems
    {
      get
      {
        if (this.mobjSubItems == null)
          this.mobjSubItems = new ListViewItem.ListViewSubItemCollection(this);
        return this.mobjSubItems;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this listviewitem has sub items.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this listviewitem has sub items; otherwise, <c>false</c>.
    /// </value>
    private bool HasSubItems => this.mobjSubItems != null && this.mobjSubItems.Count > 0;

    /// <summary>Gets or sets the list view item text.</summary>
    /// <value></value>
    [DefaultValue("")]
    public string Text
    {
      get => this.TextInternal;
      set
      {
        if (this.HasSubItems)
        {
          if (!(this.TextInternal != value))
            return;
          this.TextInternal = value;
          this.UpdateParams(AttributeType.Control);
        }
        else
        {
          this.TextInternal = value;
          if (!(value != string.Empty))
            return;
          this.UpdateParams(AttributeType.Control);
        }
      }
    }

    /// <summary>Gets or sets the text internal.</summary>
    /// <value>The text internal.</value>
    internal string TextInternal
    {
      get => this.HasSubItems ? this.SubItems[0].Text : string.Empty;
      set
      {
        if (this.HasSubItems)
          this.SubItems[0].Text = value;
        else
          this.SubItems.Add(value);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public override void Update() => base.Update();

    /// <summary>Gets or sets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.Font"></see>, <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.ForeColor"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ListViewItem.BackColor"></see> properties for the item are used for all its subitems.</summary>
    /// <returns>true if all subitems use the font, foreground color, and background color settings of the item; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [DefaultValue(true)]
    public bool UseItemStyleForSubItems
    {
      get => this.mblnUseItemStyleForSubItems;
      set
      {
        if (this.mblnUseItemStyleForSubItems == value)
          return;
        this.mblnUseItemStyleForSubItems = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets item relative position.</summary>
    /// <value>The position.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Point Position
    {
      get
      {
        ListView listView = this.ListView;
        if (listView == null || !listView.IsHandleCreated)
          return Point.Empty;
        int intX = 0;
        int intY = 0;
        listView.GetRelativeXYFromItem(this, ref intX, ref intY);
        return new Point(intX, intY);
      }
      set
      {
      }
    }

    /// <summary>Represents a subitem of a ListViewItem .</summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignTimeVisible(false)]
    [TypeConverter(typeof (ListViewSubItemConverter))]
    [Serializable]
    public class ListViewSubItem
    {
      /// <summary>The subitem style</summary>
      private ListViewItem.ListViewSubItem.SubItemStyle mobjStyle;
      /// <summary>The sub item listviewitem owner</summary>
      private ListViewItem mobjListViewItem;
      /// <summary>Name property</summary>
      private string mstrName = string.Empty;
      /// <summary>
      /// 
      /// </summary>
      private object mobjUserData;
      /// <summary>Gets or sets the text internal.</summary>
      /// <value>The text internal.</value>
      internal string mstrText = string.Empty;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
      /// </summary>
      public ListViewSubItem()
      {
      }

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
      /// </summary>
      /// <param name="objListViewItem">The owner list view item.</param>
      protected ListViewSubItem(ListViewItem objListViewItem) => this.mobjListViewItem = objListViewItem;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
      /// </summary>
      /// <param name="objListViewItem">The owner list view.</param>
      /// <param name="strText">The sub item text.</param>
      public ListViewSubItem(ListViewItem objListViewItem, string strText)
      {
        this.mobjListViewItem = objListViewItem;
        this.mstrText = strText;
      }

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> instance.
      /// </summary>
      /// <param name="objListViewItem">The owner list view.</param>
      /// <param name="strText">The sub item text.</param>
      /// <param name="objForeColor">The sub item fore color.</param>
      /// <param name="objBackColor">The sub item back color.</param>
      /// <param name="objFont">The sub item font.</param>
      public ListViewSubItem(
        ListViewItem objListViewItem,
        string strText,
        Color objForeColor,
        Color objBackColor,
        Font objFont)
      {
        this.mobjListViewItem = objListViewItem;
        this.mstrText = strText;
        this.mobjStyle = new ListViewItem.ListViewSubItem.SubItemStyle()
        {
          ForeColor = objForeColor,
          BackColor = objBackColor,
          Font = objFont
        };
      }

      /// <summary>Renders the style.</summary>
      /// <param name="objWriter">The obj writer.</param>
      /// <param name="strAttribute">The STR attribute.</param>
      /// <param name="objBackColor">Color of the obj back.</param>
      /// <param name="objForeColor">Color of the obj fore.</param>
      /// <param name="objFont">The obj font.</param>
      internal void RenderStyle(
        IResponseWriter objWriter,
        string strAttribute,
        Color objBackColor,
        Color objForeColor,
        Font objFont)
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (objBackColor != this.DefaultBackColor)
          stringBuilder.AppendFormat("background-color:{0};", (object) CommonUtils.GetHtmlColor(objBackColor));
        if (objForeColor != this.DefaultForeColor)
          stringBuilder.AppendFormat("color:{0};", (object) CommonUtils.GetHtmlColor(objForeColor));
        Font defaultFont = this.ListViewItem.DefaultFont;
        if (objFont != null && !objFont.Equals((object) defaultFont))
          stringBuilder.AppendFormat("font:{0};", (object) ClientUtils.GetWebFont(objFont));
        if (stringBuilder.Length <= 0)
          return;
        objWriter.WriteAttributeString(strAttribute, stringBuilder.ToString());
      }

      /// <summary>Resets the Style.</summary>
      public void ResetStyle()
      {
        if (this.Style == null)
          return;
        this.Style = (ListViewItem.ListViewSubItem.SubItemStyle) null;
        if (this.ListViewItem == null)
          return;
        this.ListViewItem.UpdateParams(AttributeType.Visual);
      }

      /// <summary>Returns the sub item text value.</summary>
      /// <returns></returns>
      public override string ToString() => this.Text;

      [Browsable(false)]
      public Rectangle Bounds => this.mobjListViewItem != null && this.mobjListViewItem.ListView != null ? this.mobjListViewItem.ListView.GetSubItemRect(this.mobjListViewItem.Index, this.mobjListViewItem.SubItems.IndexOf(this)) : Rectangle.Empty;

      /// <summary>Gets the default color of the back.</summary>
      /// <value>The default color of the back.</value>
      private Color DefaultBackColor
      {
        get
        {
          ListViewItem listViewItem = this.ListViewItem;
          return listViewItem != null ? listViewItem.DefaultBackColor : SystemColors.Window;
        }
      }

      /// <summary>Gets the default color of the fore.</summary>
      /// <value>The default color of the fore.</value>
      private Color DefaultForeColor
      {
        get
        {
          ListViewItem listViewItem = this.ListViewItem;
          return listViewItem != null ? listViewItem.DefaultForeColor : Color.Black;
        }
      }

      /// <summary>Gets or sets the color of the back.</summary>
      /// <value></value>
      public virtual Color BackColor
      {
        get
        {
          if (this.Style != null && this.Style.BackColor != Color.Empty)
            return this.Style.BackColor;
          return this.ListViewItem != null && this.ListViewItem.ListView != null && (this.ListViewItem.ListView.HasBackColor || this.ListViewItem.ListView.HasProxyPropertyValue(nameof (BackColor))) ? this.ListViewItem.ListView.GetProxyPropertyValue<Color>(nameof (BackColor), this.ListViewItem.ListView.BackColor) : this.DefaultBackColor;
        }
        set
        {
          if (this.Style == null)
            this.Style = new ListViewItem.ListViewSubItem.SubItemStyle();
          if (!(this.Style.BackColor != value))
            return;
          this.Style.BackColor = value;
          if (this.ListViewItem == null)
            return;
          this.ListViewItem.UpdateParams(AttributeType.Visual);
        }
      }

      /// <summary>Gets or sets the font.</summary>
      /// <value></value>
      public virtual Font Font
      {
        get
        {
          if (this.Style != null && this.Style.Font != null)
            return this.Style.Font;
          if (this.ListViewItem != null && this.ListViewItem.ListView != null)
            return this.ListViewItem.ListView.GetProxyPropertyValue<Font>(nameof (Font), this.ListViewItem.ListView.Font);
          return this.ListViewItem != null ? this.ListViewItem.DefaultFont : Control.DefaultFont;
        }
        set
        {
          if (this.Style == null)
            this.Style = new ListViewItem.ListViewSubItem.SubItemStyle();
          if (this.Style.Font == value)
            return;
          this.Style.Font = value;
          if (this.ListViewItem == null)
            return;
          this.ListViewItem.UpdateParams(AttributeType.Visual);
        }
      }

      /// <summary>Gets or sets the color of the fore.</summary>
      /// <value></value>
      public virtual Color ForeColor
      {
        get
        {
          if (this.Style != null && this.Style.ForeColor != Color.Empty)
            return this.Style.ForeColor;
          return this.ListViewItem != null && this.ListViewItem.ListView != null && (this.ListViewItem.ListView.HasForeColor || this.ListViewItem.ListView.HasProxyPropertyValue(nameof (ForeColor))) ? this.ListViewItem.ListView.GetProxyPropertyValue<Color>(nameof (ForeColor), this.ListViewItem.ListView.ForeColor) : this.DefaultForeColor;
        }
        set
        {
          if (this.Style == null)
            this.Style = new ListViewItem.ListViewSubItem.SubItemStyle();
          if (!(this.Style.ForeColor != value))
            return;
          this.Style.ForeColor = value;
          if (this.ListViewItem == null)
            return;
          this.ListViewItem.UpdateParams(AttributeType.Visual);
        }
      }

      /// <summary>Gets or sets the name associated with this control.</summary>
      /// <value></value>
      [Localizable(true)]
      public string Name
      {
        get => this.mstrName != null ? this.mstrName : "";
        set => this.mstrName = value;
      }

      /// <summary>Gets or sets the tag with this item.</summary>
      /// <value></value>
      [TypeConverter(typeof (StringConverter))]
      [SRCategory("CatData")]
      [Localizable(false)]
      [Bindable(true)]
      [DefaultValue(null)]
      [SRDescription("ControlTagDescr")]
      public object Tag
      {
        get => this.mobjUserData;
        set => this.mobjUserData = value;
      }

      /// <summary>Gets or sets the text.</summary>
      /// <value></value>
      public virtual string Text
      {
        get => this.mstrText;
        set
        {
          if (!(this.mstrText != value))
            return;
          this.mstrText = value;
          if (this.ListViewItem == null)
            return;
          this.ListViewItem.UpdateParams(AttributeType.Visual);
        }
      }

      /// <summary>Gets or sets the list view.</summary>
      /// <value></value>
      internal ListViewItem ListViewItem
      {
        get => this.mobjListViewItem;
        set => this.mobjListViewItem = value;
      }

      /// <summary>Gets or sets the Style.</summary>
      /// <value></value>
      internal ListViewItem.ListViewSubItem.SubItemStyle Style
      {
        get => this.mobjStyle;
        set => this.mobjStyle = value;
      }

      [Serializable]
      internal class SubItemStyle
      {
        /// <summary>The backcolor style of the sub item</summary>
        private Color mobjBackColor = Color.Empty;
        /// <summary>The font of the sub item</summary>
        private SerializableFont mobjFont;
        /// <summary>The forecolor style of the sub item</summary>
        private Color mobjForeColor = Color.Empty;

        /// <summary>Gets or sets the color of the back.</summary>
        /// <value></value>
        public Color BackColor
        {
          get => this.mobjBackColor;
          set => this.mobjBackColor = value;
        }

        /// <summary>Gets or sets the font.</summary>
        /// <value></value>
        public Font Font
        {
          get => (Font) this.mobjFont;
          set => this.mobjFont = (SerializableFont) value;
        }

        /// <summary>Gets or sets the color of the fore.</summary>
        /// <value></value>
        public Color ForeColor
        {
          get => this.mobjForeColor;
          set => this.mobjForeColor = value;
        }
      }
    }

    /// <summary>
    /// Represents a collection of ListViewSubItem objects stored in a ListViewItem .
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ListViewSubItemCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ListViewSubItemCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Serializable]
    public class ListViewSubItemCollection : ICollection, IEnumerable, IList
    {
      /// <summary>
      /// 
      /// </summary>
      private ListViewItem mobjListViewItem;
      /// <summary>
      /// 
      /// </summary>
      private ArrayList mobjSubItems;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItemCollection" /> instance.
      /// </summary>
      /// <param name="objListViewItem">Owner list view item.</param>
      public ListViewSubItemCollection(ListViewItem objListViewItem)
      {
        this.mobjListViewItem = objListViewItem;
        this.mobjSubItems = new ArrayList();
      }

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItemCollection" /> instance.
      /// </summary>
      /// <param name="objListViewItem">Owner list view item.</param>
      /// <param name="arrSubItems">The arr sub items.</param>
      internal ListViewSubItemCollection(ListViewItem objListViewItem, object[] arrSubItems)
      {
        this.mobjListViewItem = objListViewItem;
        this.mobjSubItems = new ArrayList((ICollection) arrSubItems);
      }

      /// <summary>Adds the specified sub item.</summary>
      /// <param name="objSubItem">Sub item.</param>
      /// <returns></returns>
      public ListViewItem.ListViewSubItem Add(ListViewItem.ListViewSubItem objSubItem)
      {
        objSubItem.ListViewItem = this.mobjListViewItem;
        this.mobjSubItems.Add((object) objSubItem);
        this.OnSubItemAdded(objSubItem);
        return objSubItem;
      }

      /// <summary>Handle sub item added</summary>
      /// <param name="objSubItem"></param>
      private void OnSubItemAdded(ListViewItem.ListViewSubItem objSubItem)
      {
        if (!(objSubItem is ListViewItem.ListViewSubControlItem viewSubControlItem))
          return;
        ListView listView = this.mobjListViewItem.ListView;
        if (listView == null)
          return;
        Control control = viewSubControlItem.Control;
        if (control == null)
          return;
        listView.Controls.Add(control);
      }

      /// <summary>Handle sub item removed</summary>
      /// <param name="objSubItem"></param>
      private void OnSubItemRemoved(ListViewItem.ListViewSubItem objSubItem)
      {
        if (!(objSubItem is ListViewItem.ListViewSubControlItem viewSubControlItem))
          return;
        ListView listView = this.mobjListViewItem.ListView;
        if (listView == null)
          return;
        Control control = viewSubControlItem.Control;
        if (control == null)
          return;
        listView.Controls.Remove(control);
      }

      /// <summary>
      /// 
      /// </summary>
      public bool IsFixedSize => false;

      /// <summary>Adds a new sub item.</summary>
      /// <param name="strText">STR text.</param>
      /// <returns></returns>
      public ListViewItem.ListViewSubItem Add(string strText)
      {
        ListViewItem.ListViewSubItem listViewSubItem = new ListViewItem.ListViewSubItem(this.mobjListViewItem, strText);
        this.mobjSubItems.Add((object) listViewSubItem);
        return listViewSubItem;
      }

      /// <summary>Adds the specified obj control.</summary>
      /// <param name="objControl">The obj control.</param>
      /// <returns></returns>
      public ListViewItem.ListViewSubControlItem Add(Control objControl)
      {
        ListViewItem.ListViewSubControlItem objSubItem = new ListViewItem.ListViewSubControlItem(this.mobjListViewItem, objControl);
        this.mobjSubItems.Add((object) objSubItem);
        this.OnSubItemAdded((ListViewItem.ListViewSubItem) objSubItem);
        return objSubItem;
      }

      /// <summary>Adds the a sub item with styles.</summary>
      /// <param name="strText">The sub item text.</param>
      /// <param name="objForeColor">The sub item fore color.</param>
      /// <param name="objBackColor">The sub item back color.</param>
      /// <param name="objFont">The sub item font.</param>
      /// <returns></returns>
      public ListViewItem.ListViewSubItem Add(
        string strText,
        Color objForeColor,
        Color objBackColor,
        Font objFont)
      {
        ListViewItem.ListViewSubItem listViewSubItem = new ListViewItem.ListViewSubItem(this.mobjListViewItem, strText, objForeColor, objBackColor, objFont);
        this.mobjSubItems.Add((object) listViewSubItem);
        return listViewSubItem;
      }

      /// <summary>Adds a range of sub items.</summary>
      /// <param name="arrItems">Sub items array.</param>
      public void AddRange(ListViewItem.ListViewSubItem[] arrItems)
      {
        foreach (ListViewItem.ListViewSubItem arrItem in arrItems)
          this.Add(arrItem);
      }

      /// <summary>Adds a range of items.</summary>
      /// <param name="arrItems">Range of items.</param>
      public void AddRange(string[] arrItems)
      {
        foreach (string arrItem in arrItems)
          this.Add(arrItem);
      }

      /// <summary>Adds a range of sub items with styles.</summary>
      /// <param name="arrItems">The sub items text array.</param>
      /// <param name="objForeColor">The sub item fore color.</param>
      /// <param name="objBackColor">The sub item back color.</param>
      /// <param name="objFont">The sub item font.</param>
      public void AddRange(
        string[] arrItems,
        Color objForeColor,
        Color objBackColor,
        Font objFont)
      {
        foreach (string arrItem in arrItems)
          this.Add(arrItem, objForeColor, objBackColor, objFont);
      }

      /// <summary>Clears the sub items.</summary>
      public void Clear() => this.mobjSubItems.Clear();

      /// <summary>Checks if a sub item is contained.</summary>
      /// <param name="objSubItem">A sub item.</param>
      /// <returns></returns>
      public bool Contains(ListViewItem.ListViewSubItem objSubItem) => this.mobjSubItems.Contains((object) objSubItem);

      /// <summary>Ensures the sub item space (Not implemented).</summary>
      /// <param name="intSize">Size.</param>
      /// <param name="intIndex">Index.</param>
      private void EnsureSubItemSpace(int intSize, int intIndex)
      {
      }

      /// <summary>Gets an enumerator.</summary>
      /// <returns></returns>
      public IEnumerator GetEnumerator() => this.mobjSubItems.GetEnumerator();

      /// <summary>returns the indexes of a given sub item.</summary>
      /// <param name="objSubItem">A sub item.</param>
      /// <returns></returns>
      public int IndexOf(ListViewItem.ListViewSubItem objSubItem) => this.mobjSubItems.IndexOf((object) objSubItem);

      /// <summary>Inserts a sub item at a specified index.</summary>
      /// <param name="intIndex">Index.</param>
      /// <param name="objSubItem">The sub item.</param>
      public void Insert(int intIndex, ListViewItem.ListViewSubItem objSubItem) => this.mobjSubItems.Insert(intIndex, (object) objSubItem);

      /// <summary>Removes the specified sub item.</summary>
      /// <param name="objSubItem">Obj sub item.</param>
      public void Remove(ListViewItem.ListViewSubItem objSubItem)
      {
        this.mobjSubItems.Remove((object) objSubItem);
        this.OnSubItemRemoved(objSubItem);
      }

      /// <summary>Removes a sub item at a specified index.</summary>
      /// <param name="intIndex">Index.</param>
      public void RemoveAt(int intIndex)
      {
        if (!(this.mobjSubItems[intIndex] is ListViewItem.ListViewSubItem mobjSubItem))
          return;
        this.Remove(mobjSubItem);
      }

      /// <summary>Copies to an array.</summary>
      /// <param name="objArrayDest">Arr dest.</param>
      /// <param name="intIndex">Int index.</param>
      public void CopyTo(Array objArrayDest, int intIndex) => this.mobjSubItems.CopyTo(objArrayDest, intIndex);

      /// <summary>Gets the count.</summary>
      /// <value></value>
      public int Count => this.mobjSubItems.Count;

      /// <summary>
      /// Gets a value indicating whether this instance is read only.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
      /// </value>
      public bool IsReadOnly => false;

      /// <summary>
      /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem" /> at the specified index.
      /// </summary>
      /// <value></value>
      public ListViewItem.ListViewSubItem this[int index]
      {
        get => this.mobjSubItems.Count <= index ? new ListViewItem.ListViewSubItem() : (ListViewItem.ListViewSubItem) this.mobjSubItems[index];
        set
        {
          if (this.mobjSubItems == null)
            this.mobjSubItems = new ArrayList();
          this.OnSubItemRemoved(this.mobjSubItems[index] as ListViewItem.ListViewSubItem);
          this.mobjSubItems[index] = (object) value;
          this.OnSubItemAdded(value);
        }
      }

      /// <summary>
      /// Gets a value indicating whether this instance is synchronized.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
      /// </value>
      public bool IsSynchronized => this.mobjSubItems.IsSynchronized;

      /// <summary>Gets the sync root.</summary>
      /// <value></value>
      public object SyncRoot => this.mobjSubItems.SyncRoot;

      /// <summary>
      /// 
      /// </summary>
      object IList.this[int index]
      {
        get => this.mobjSubItems[index];
        set => this.mobjSubItems[index] = value;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="index"></param>
      /// <param name="objValue"></param>
      void IList.Insert(int index, object objValue) => this.mobjSubItems.Insert(index, objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      void IList.Remove(object objValue) => this.mobjSubItems.Remove(objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      bool IList.Contains(object objValue) => this.mobjSubItems.Contains(objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      int IList.IndexOf(object objValue) => this.mobjSubItems.IndexOf(objValue);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objValue"></param>
      int IList.Add(object objValue) => this.mobjSubItems.Add(objValue);
    }

    [Serializable]
    public class ListViewSubControlItem : ListViewItem.ListViewSubItem
    {
      /// <summary>The hosted control</summary>
      private Control mobjControl;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ListViewItem.ListViewSubControlItem" /> instance.
      /// </summary>
      public ListViewSubControlItem(Control objControl)
      {
        if (objControl == null)
          throw new ArgumentNullException(nameof (objControl));
        this.SetSubItemControl(objControl);
      }

      public ListViewSubControlItem(ListViewItem objListViewItem, Control objControl)
        : base(objListViewItem)
      {
        if (objControl == null)
          throw new ArgumentNullException(nameof (objControl));
        this.SetSubItemControl(objControl);
      }

      /// <summary>Sets the sub item control.</summary>
      /// <param name="objControl">The sub item control.</param>
      private void SetSubItemControl(Control objControl)
      {
        this.mobjControl = objControl;
        this.mobjControl.Dock = DockStyle.Fill;
        this.mobjControl.TabIndex = 1;
      }

      /// <summary>Gets or sets the control.</summary>
      /// <value>The control.</value>
      public Control Control => this.mobjControl;

      /// <summary>Gets or sets the text.</summary>
      /// <value></value>
      public override string Text
      {
        get => this.Control.Text;
        set => this.Control.Text = value;
      }
    }
  }
}

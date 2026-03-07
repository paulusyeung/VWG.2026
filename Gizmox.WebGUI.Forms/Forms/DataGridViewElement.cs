// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewElement
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides the base class for elements of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class DataGridViewElement : 
    SerializableObject,
    IRenderableComponentMember,
    IIdentifiedComponent
  {
    private string mstrTagName;
    private DataGridViewElement.ElementReadOnlyType menmElementReadOnly;
    private DataGridViewElementStates menmState;
    private DataGridViewElementClientStates menmClientState;
    private DataGridView mobjDataGridView;
    /// <summary>Gets or sets the last modified params.</summary>
    /// <value>The last modified params.</value>
    internal long LastModifiedParams;
    /// <summary>Gets or sets the type of the last modified params.</summary>
    /// <value>The type of the last modified params.</value>
    internal AttributeType LastModifiedParamsType;
    /// <summary>Gets or sets the last modified.</summary>
    /// <value>The last modified.</value>
    internal long LastModified;

    /// <summary>
    /// Determines whether element should render provided renderable.
    /// </summary>
    /// <param name="intRenderMask">The render mask.</param>
    /// <param name="enmRenderableToCheck">The attribute to check.</param>
    /// <returns></returns>
    internal static bool ShouldRender(
      int intRenderMask,
      DataGridViewElement.Renderable enmRenderableToCheck)
    {
      return ((DataGridViewElement.Renderable) intRenderMask & enmRenderableToCheck) != enmRenderableToCheck;
    }

    /// <summary>
    /// Determines whether element should prerender provided prerenderable.
    /// </summary>
    /// <param name="intPreRenderMask">The int pre render mask.</param>
    /// <param name="enmPreRenderableToCheck">The enm pre renderable to check.</param>
    /// <returns></returns>
    internal static bool ShouldPreRender(
      int intPreRenderMask,
      DataGridViewElement.PreRenderable enmPreRenderableToCheck)
    {
      return ((DataGridViewElement.PreRenderable) intPreRenderMask & enmPreRenderableToCheck) != enmPreRenderableToCheck;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElement"></see> class.</summary>
    public DataGridViewElement()
    {
      this.State = DataGridViewElementStates.Visible;
      this.InitializeCompoent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objDGVTemplate"></param>
    internal DataGridViewElement(DataGridViewElement objDGVTemplate)
    {
      this.InitializeCompoent();
      this.State = objDGVTemplate.State & (DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.ResizableSet | DataGridViewElementStates.Visible);
    }

    /// <summary>Initializes the compoent.</summary>
    private void InitializeCompoent() => this.LastModifiedParams = this.LastModified = this.GetCurrentTicks(true);

    /// <summary>Gets the member ID.</summary>
    /// <value>The member ID.</value>
    protected virtual string MemberID => "0";

    /// <summary>Gets the location.</summary>
    /// <value>The location.</value>
    protected internal virtual Point Location => Point.Empty;

    /// <summary>Gets the member ID internal.</summary>
    /// <value>The member ID internal.</value>
    internal string MemberIDInternal => this.MemberID;

    /// <summary>Gets the owner ID.</summary>
    /// <value>The owner ID.</value>
    private string OwnerID
    {
      get
      {
        DataGridView dataGridView = this.DataGridView;
        return dataGridView.GetProxyPropertyValue<long>("ID", dataGridView.ID).ToString();
      }
    }

    /// <summary>Gets or sets the name of the tag.</summary>
    /// <value>The name of the tag.</value>
    protected string TagName
    {
      get => this.mstrTagName;
      set => this.mstrTagName = value;
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    [Obsolete("Use GetCriticalEventsData instead")]
    protected virtual EventTypes GetCriticalEvents() => EventTypes.None;

    /// <summary>Gets the critical event name.</summary>
    protected virtual CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData objCriticalEventsData = new CriticalEventsData();
      EventTypes criticalEvents = this.GetCriticalEvents();
      RegisteredComponent.MergeCriticalEventsWithObselete(ref objCriticalEventsData, criticalEvents);
      return objCriticalEventsData;
    }

    /// <summary>Clears the element read only from property store.</summary>
    protected internal void ClearElementReadOnly() => this.menmElementReadOnly = DataGridViewElement.ElementReadOnlyType.NotSet;

    /// <summary>Gets the element read only.</summary>
    /// <param name="blnElementReadOnlyValue">if set to <c>true</c> [BLN element read only value].</param>
    /// <returns><c>true</c> if the property store have value, <c>false</c> if proprty store is empty</returns>
    protected internal bool GetElementReadOnly(out bool blnElementReadOnlyValue)
    {
      int num = this.menmElementReadOnly != 0 ? 1 : 0;
      blnElementReadOnlyValue = this.menmElementReadOnly == DataGridViewElement.ElementReadOnlyType.True;
      return num != 0;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected internal virtual void FireEvent(IEvent objEvent)
    {
    }

    /// <summary>Renders the element's event attributes.</summary>
    /// <param name="objContext">context.</param>
    /// <param name="objWriter">writer.</param>
    protected virtual void RenderElementEventAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      CriticalEventsData criticalEventsData = this.GetCriticalEventsData();
      if (!(criticalEventsData.HasEvents | blnForceRender))
        return;
      string clientString = criticalEventsData.ToClientString();
      objWriter.WriteAttributeString("E", clientString);
    }

    /// <summary>Renders the element's meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderElementAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      objWriter.WriteAttributeString("mId", this.MemberID);
      if (blnRenderOwner)
        objWriter.WriteAttributeString("oId", this.OwnerID);
      this.RenderElementEventAttributes(objContext, objWriter, false);
    }

    /// <summary>Renders the element update attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderElementUpdateAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      objWriter.WriteAttributeString("mId", this.MemberID);
      if (blnRenderOwner)
        objWriter.WriteAttributeString("oId", this.OwnerID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
        return;
      this.RenderElementEventAttributes(objContext, objWriter, true);
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      this.RenderElementAttributes(objContext, objWriter, blnRenderOwner);
    }

    /// <summary>Renders the updated attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      this.RenderElementUpdateAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Adds a critical event delegate to the list.</summary>
    /// <param name="objSerializableEvent">The serializable event.</param>
    /// <param name="objValue">The delegate to add to the list.</param>
    protected void AddCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
    {
      if (!this.AddHandler(objSerializableEvent, objValue))
        return;
      this.UpdateParams(AttributeType.Events);
    }

    /// <summary>Removes a critical event delegate from the list.</summary>
    /// <param name="objSerializableEvent">The serializable event.</param>
    /// <param name="objValue">The delegate to remove from the list.</param>
    protected void RemoveCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
    {
      if (!this.RemoveHandler(objSerializableEvent, objValue))
        return;
      this.UpdateParams(AttributeType.Events);
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
    }

    void IRenderableComponentMember.RenderComponent(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      this.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Pres the render component.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    internal virtual void PreRenderComponent(
      IContext objContext,
      long lngRequestID,
      bool blnForcePreRender)
    {
    }

    /// <summary>Posts the render component.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
    internal virtual void PostRenderComponent(
      IContext objContext,
      long lngRequestID,
      bool blnForcePostRender)
    {
      this.ResetParams();
    }

    /// <summary>
    /// Checks if the current control needs rendering and
    /// continues to process sub tree/
    /// </summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected virtual void RenderComponent(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      if (this.IsDirty(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.Prefix, this.TagName, WGConst.Namespace);
        this.RenderAttributes(objContext, (IAttributeWriter) objWriter, blnRenderOwner);
        this.RenderComponents(objContext, objWriter, 0L, blnRenderOwner);
        objWriter.WriteEndElement();
      }
      else if (this.IsDirtyAttributes(lngRequestID))
      {
        objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
        this.RenderUpdatedAttributes(objContext, (IAttributeWriter) objWriter, lngRequestID, blnRenderOwner);
        this.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
        objWriter.WriteEndElement();
      }
      else
        this.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Gets the event buttons value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="enmDefault">The default value.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
    {
      switch (objEvent["BTN"])
      {
        case "L":
          return MouseButtons.Left;
        case "R":
          return MouseButtons.Right;
        case "M":
          return MouseButtons.Middle;
        default:
          return enmDefault;
      }
    }

    /// <summary>Gets the event integer attribute value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="strAttribute">The attribute name.</param>
    /// <param name="intDefault">The default integer value.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
    {
      string s = objEvent[strAttribute];
      return CommonUtils.IsNullOrEmpty(s) ? intDefault : int.Parse(s);
    }

    /// <summary>Full updates of this instance.</summary>
    public virtual void Update()
    {
      this.LastModified = this.GetCurrentTicks();
      this.LastModifiedParamsType = AttributeType.None;
    }

    /// <summary>Redraw only</summary>
    /// <param name="blnRedrawOnly">if set to <c>true</c> [BLN redraw only].</param>
    public virtual void Update(bool blnRedrawOnly)
    {
      if (blnRedrawOnly)
        this.UpdateParams(AttributeType.Redraw);
      else
        this.Update();
    }

    /// <summary>Redraw only</summary>
    /// <param name="enmParams">The enm params.</param>
    internal virtual void Update(AttributeType enmParams) => this.UpdateParams(enmParams);

    /// <summary>Updates only the parameters of this instance.</summary>
    protected virtual void UpdateParams()
    {
      this.LastModifiedParams = this.GetCurrentTicks();
      this.LastModifiedParamsType = AttributeType.All;
    }

    /// <summary>Updates the params.</summary>
    /// <param name="enmParams">The enm params.</param>
    protected internal virtual void UpdateParams(AttributeType enmParams)
    {
      this.LastModifiedParams = this.GetCurrentTicks();
      this.LastModifiedParamsType |= enmParams;
    }

    /// <summary>Determines whether the specified component is dirty.</summary>
    /// <param name="lngRequestID">Request ID.</param>
    /// <returns>
    /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsDirty(long lngRequestID) => this.LastModified > lngRequestID;

    /// <summary>Resets the params.</summary>
    protected void ResetParams() => this.LastModifiedParamsType = AttributeType.None;

    /// <summary>Determines whether the specified component is dirty.</summary>
    /// <param name="lngRequestID">Request ID.</param>
    /// <returns>
    /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
    /// </returns>
    protected bool IsDirtyAttributes(long lngRequestID) => this.LastModifiedParams > lngRequestID;

    /// <summary>
    /// Determines whether [is dirty attributes] [the specified LNG request ID].
    /// </summary>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="enmParams">The enm params.</param>
    /// <returns>
    /// 	<c>true</c> if [is dirty attributes] [the specified LNG request ID]; otherwise, <c>false</c>.
    /// </returns>
    protected bool IsDirtyAttributes(long lngRequestID, AttributeType enmParams) => this.LastModifiedParams > lngRequestID && (this.LastModifiedParamsType & enmParams) > AttributeType.None;

    /// <summary>Called when the element is associated with a different <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    protected virtual void OnDataGridViewChanged()
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected void RaiseCellClick(DataGridViewCellEventArgs e) => this.DataGridView?.OnCellClickInternal(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellContentClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected void RaiseCellContentClick(DataGridViewCellEventArgs e) => this.DataGridView?.OnCellContentClickInternal(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellContentDoubleClick"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected void RaiseCellContentDoubleClick(DataGridViewCellEventArgs e) => this.DataGridView?.OnCellContentDoubleClickInternal(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected void RaiseCellValueChanged(DataGridViewCellEventArgs e) => this.RaiseCellValueChanged(e, false);

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event.
    /// </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    protected internal void RaiseCellValueChanged(DataGridViewCellEventArgs e, bool blnClientSource) => this.DataGridView?.OnCellValueChangedInternal(e, blnClientSource);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> that contains the event data. </param>
    protected void RaiseDataError(DataGridViewDataErrorEventArgs e) => this.DataGridView?.OnDataErrorInternal(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseWheel"></see> event. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
    protected void RaiseMouseWheel(MouseEventArgs e) => this.DataGridView?.OnMouseWheelInternal(e);

    internal bool StateExcludes(DataGridViewElementStates elementState) => (this.State & elementState) == DataGridViewElementStates.None;

    internal bool StateIncludes(DataGridViewElementStates elementState) => (this.State & elementState) == elementState;

    /// <summary>Gets or sets the element read only.</summary>
    /// <value>The element read only.</value>
    protected internal virtual DataGridViewElement.ElementReadOnlyType ElementReadOnly
    {
      get => this.menmElementReadOnly;
      set => this.menmElementReadOnly = value;
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
    [Browsable(false)]
    public virtual bool IsEventsEnabled => true;

    /// <summary>
    /// Gets the default render mask. Initialized to render all.
    /// </summary>
    internal virtual int RenderMask => 0;

    /// <summary>
    /// Gets the default prerender mask. Initialized to prerender all.
    /// </summary>
    internal virtual int PreRenderMask => 0;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control associated with this element.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control that contains this element. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public DataGridView DataGridView
    {
      get => this.mobjDataGridView;
      private set => this.mobjDataGridView = value;
    }

    internal DataGridView DataGridViewInternal
    {
      set
      {
        if (this.DataGridView == value)
          return;
        this.DataGridView = value;
        this.OnDataGridViewChanged();
      }
    }

    /// <summary>Gets the user interface (UI) state of the element.</summary>
    /// <returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the state.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual DataGridViewElementStates State
    {
      get => this.menmState;
      private set => this.menmState = value;
    }

    /// <summary>Gets or sets the state of the client.</summary>
    /// <value>The state of the client.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal DataGridViewElementClientStates ClientState
    {
      get => this.menmClientState;
      set => this.menmClientState = value;
    }

    internal DataGridViewElementStates StateInternal
    {
      set => this.State = value;
    }

    string IIdentifiedComponent.ID => this.MemberID;

    /// <summary>Renderable enumeration.</summary>
    [Serializable]
    internal enum Renderable
    {
      /// <summary>Represents ContextMenu attribute.</summary>
      ContextMenuAttribute = 1,
      /// <summary>Represents Selected attribute.</summary>
      SelectedAttribute = 2,
      /// <summary>Represents ErrorText attribute.</summary>
      ErrorTextAttribute = 4,
    }

    /// <summary>PreRenderable enumeration.</summary>
    [Serializable]
    internal enum PreRenderable
    {
      /// <summary>Represents DataGridViewCellStyle.</summary>
      CellStyle = 1,
    }

    /// <summary>ElementReadOnly Type</summary>
    [Serializable]
    protected internal enum ElementReadOnlyType
    {
      /// <summary>value not set</summary>
      NotSet,
      /// <summary>element is not read only</summary>
      False,
      /// <summary>element is read only</summary>
      True,
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents an individual cell in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  /// <filterpriority>2</filterpriority>
  [TypeConverter(typeof (DataGridViewCellConverter))]
  [Serializable]
  public abstract class DataGridViewCell : DataGridViewElement, ICloneable, IDisposable, ISkinable
  {
    private byte mobjFlags;
    private object mobjEditingProposedValue;
    private DataGridViewRow mobjOwningRow;
    private DataGridViewColumn mobjOwningColumn;
    private DataGridViewCellStyle mobjStyle;
    private object mojValue;
    private object mobjToolTipText;
    private object mobjTag;
    private object mobjValueType;
    private object mobjErrorText;
    private ContextMenu mobjCellContextMenu;
    private ContextMenuStrip mobjCellContextMenuStrip;
    private DataGridViewCellPanel mobjPanel;
    private const int DATAGRIDVIEWCELL_constrastThreshold = 1000;
    private const byte DATAGRIDVIEWCELL_flagAreaNotSet = 0;
    private const byte DATAGRIDVIEWCELL_flagDataArea = 1;
    private const byte DATAGRIDVIEWCELL_flagErrorArea = 2;
    private const int DATAGRIDVIEWCELL_highConstrastThreshold = 2000;
    internal const byte DATAGRIDVIEWCELL_iconMarginHeight = 4;
    internal const byte DATAGRIDVIEWCELL_iconMarginWidth = 4;
    internal const byte DATAGRIDVIEWCELL_iconsHeight = 11;
    internal const byte DATAGRIDVIEWCELL_iconsWidth = 12;
    private const int DATAGRIDVIEWCELL_maxToolTipCutOff = 256;
    private const int DATAGRIDVIEWCELL_maxToolTipLength = 288;
    private const string DATAGRIDVIEWCELL_toolTipEllipsis = "...";
    private const int DATAGRIDVIEWCELL_toolTipEllipsisLength = 3;
    private const TextFormatFlags textFormatSupportedFlags = TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.WordBreak;
    protected const int DefaultHorizontalPadding = 3;
    protected const int DefaultVerticalPadding = 4;
    private static Bitmap mobjErrorBmp = (Bitmap) null;
    private static Type mobjStringType = typeof (string);
    /// <summary>
    /// This memeber holds the formatted value as the user defined it through the pre-rendering procces.
    /// </summary>
    private object mobjFormattedValue;
    /// <summary>
    /// This memeber holds the formatted cell style as the user defined it through the pre-rendering procces.
    /// </summary>
    private DataGridViewCellStyle mobjFormattedCellStyle;
    /// <summary>The skin of the current control</summary>
    [NonSerialized]
    private ControlSkin mobjSkin;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class. </summary>
    protected DataGridViewCell()
    {
      this.TagName = "DL";
      this.StateInternal = DataGridViewElementStates.None;
    }

    internal bool MouseClickUnsharesRowInternal(DataGridViewCellMouseEventArgs e) => this.MouseClickUnsharesRow(e);

    internal bool MouseDoubleClickUnsharesRowInternal(DataGridViewCellMouseEventArgs e) => this.MouseDoubleClickUnsharesRow(e);

    internal bool MouseDownUnsharesRowInternal(DataGridViewCellMouseEventArgs e) => this.MouseDownUnsharesRow(e);

    internal bool MouseEnterUnsharesRowInternal(int intRowIndex) => this.MouseEnterUnsharesRow(intRowIndex);

    internal bool MouseLeaveUnsharesRowInternal(int intRowIndex) => this.MouseLeaveUnsharesRow(intRowIndex);

    internal bool MouseMoveUnsharesRowInternal(DataGridViewCellMouseEventArgs e) => this.MouseMoveUnsharesRow(e);

    internal bool MouseUpUnsharesRowInternal(DataGridViewCellMouseEventArgs e) => this.MouseUpUnsharesRow(e);

    internal void OnClickInternal(DataGridViewCellEventArgs e) => this.OnClick(e);

    internal void OnContentClickInternal(DataGridViewCellEventArgs e) => this.OnContentClick(e);

    internal void OnContentDoubleClickInternal(DataGridViewCellEventArgs e) => this.OnContentDoubleClick(e);

    internal void OnDoubleClickInternal(DataGridViewCellEventArgs e) => this.OnDoubleClick(e);

    internal void OnEnterInternal(int intRowIndex, bool blnThroughMouseClick) => this.OnEnter(intRowIndex, blnThroughMouseClick);

    internal void OnKeyDownInternal(KeyEventArgs e, int intRowIndex) => this.OnKeyDown(e, intRowIndex);

    internal void OnKeyPressInternal(KeyPressEventArgs e, int intRowIndex) => this.OnKeyPress(e, intRowIndex);

    internal void OnKeyUpInternal(KeyEventArgs e, int intRowIndex) => this.OnKeyUp(e, intRowIndex);

    internal void OnLeaveInternal(int intRowIndex, bool blnThroughMouseClick) => this.OnLeave(intRowIndex, blnThroughMouseClick);

    internal void OnMouseClickInternal(DataGridViewCellMouseEventArgs e) => this.OnMouseClick(e);

    internal void OnMouseDoubleClickInternal(DataGridViewCellMouseEventArgs e) => this.OnMouseDoubleClick(e);

    internal void OnMouseEnterInternal(int intRowIndex) => this.OnMouseEnter(intRowIndex);

    /// <summary>Keys the down unshares row internal.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> instance containing the event data.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool KeyDownUnsharesRowInternal(KeyEventArgs e, int intRowIndex) => this.KeyDownUnsharesRow(e, intRowIndex);

    /// <summary>Keys the press unshares row internal.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs" /> instance containing the event data.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool KeyPressUnsharesRowInternal(KeyPressEventArgs e, int intRowIndex) => this.KeyPressUnsharesRow(e, intRowIndex);

    /// <summary>Keys the up unshares row internal.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs" /> instance containing the event data.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal bool KeyUpUnsharesRowInternal(KeyEventArgs e, int intRowIndex) => this.KeyUpUnsharesRow(e, intRowIndex);

    /// <summary>Indicates whether the parent row is unshared if the user presses a key while the focus is on the cell.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual bool KeyDownUnsharesRow(KeyEventArgs e, int intRowIndex) => false;

    /// <summary>Determines if edit mode should be started based on the given key.</summary>
    /// <returns>true if edit mode should be started; otherwise, false. The default is false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
    /// <filterpriority>1</filterpriority>
    public virtual bool KeyEntersEditMode(KeyEventArgs e) => false;

    /// <summary>Indicates whether a row will be unshared if a key is pressed while a cell in the row has focus.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual bool KeyPressUnsharesRow(KeyPressEventArgs e, int intRowIndex) => false;

    /// <summary>Indicates whether the parent row is unshared when the user releases a key while the focus is on the cell.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex) => false;

    /// <summary>Indicates whether a row will be unshared when the focus leaves a cell in the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    protected virtual bool LeaveUnsharesRow(int intRowIndex, bool blnThroughMouseClick) => false;

    /// <summary>Indicates whether a row will be unshared if the user clicks a mouse button while the pointer is on a cell in the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual bool MouseClickUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Indicates whether a row will be unshared if the user double-clicks a cell in the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
    protected virtual bool MouseDoubleClickUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Indicates whether a row will be unshared when the user holds down a mouse button while the pointer is on a cell in the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual bool MouseDownUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Indicates whether a row will be unshared when the mouse pointer moves over a cell in the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual bool MouseEnterUnsharesRow(int intRowIndex) => false;

    /// <summary>Indicates whether a row will be unshared when the mouse pointer leaves the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual bool MouseLeaveUnsharesRow(int intRowIndex) => false;

    /// <summary>Indicates whether a row will be unshared when the mouse pointer moves over a cell in the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual bool MouseMoveUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Indicates whether a row will be unshared when the user releases a mouse button while the pointer is on a cell in the row.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual bool MouseUpUnsharesRow(DataGridViewCellMouseEventArgs e) => false;

    /// <summary>Called when the cell is clicked.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected virtual void OnClick(DataGridViewCellEventArgs e)
    {
    }

    /// <summary>Called when the cell's contents are clicked.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected virtual void OnContentClick(DataGridViewCellEventArgs e)
    {
    }

    /// <summary>Called when the cell's contents are double-clicked.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected virtual void OnContentDoubleClick(DataGridViewCellEventArgs e)
    {
    }

    /// <summary>Called when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell changes.</summary>
    protected override void OnDataGridViewChanged()
    {
    }

    /// <summary>Called when the cell is double-clicked.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
    protected virtual void OnDoubleClick(DataGridViewCellEventArgs e)
    {
    }

    /// <summary>Called when the focus moves to a cell.</summary>
    /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual void OnEnter(int intRowIndex, bool blnThroughMouseClick)
    {
    }

    /// <summary>Called when a character key is pressed while the focus is on a cell.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual void OnKeyDown(KeyEventArgs e, int intRowIndex)
    {
    }

    /// <summary>Called when a key is pressed while the focus is on a cell.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual void OnKeyPress(KeyPressEventArgs e, int intRowIndex)
    {
    }

    /// <summary>Called when a character key is released while the focus is on a cell.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual void OnKeyUp(KeyEventArgs e, int intRowIndex)
    {
    }

    /// <summary>Called when the focus moves from a cell.</summary>
    /// <param name="blnThroughMouseClick">true if a user action moved focus from the cell; false if a programmatic operation moved focus from the cell.</param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual void OnLeave(int intRowIndex, bool blnThroughMouseClick)
    {
    }

    /// <summary>Called when the user clicks a mouse button while the pointer is on a cell.  </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Called when the user double-clicks a mouse button while the pointer is on a cell.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual void OnMouseDoubleClick(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Called when the user holds down a mouse button while the pointer is on a cell.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual void OnMouseDown(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Called when the mouse pointer moves over a cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual void OnMouseEnter(int intRowIndex)
    {
    }

    /// <summary>Called when the mouse pointer leaves the cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected virtual void OnMouseLeave(int intRowIndex)
    {
    }

    /// <summary>Called when the mouse pointer moves within a cell.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual void OnMouseMove(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Called when the user releases a mouse button while the pointer is on a cell. </summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
    protected virtual void OnMouseUp(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DataGridView != null)
      {
        bool flag = this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOWN) || this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEUP) || this.DataGridView.IsCriticalEvent(Control.ClickEvent) || this.DataGridView.IsCriticalEvent(Control.MouseClickEvent) || this.DataGridView.IsCriticalEvent(Control.MouseDownEvent) || this.DataGridView.IsCriticalEvent(Control.MouseUpEvent);
        if (flag || this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCLICK) || this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTCLICK))
          criticalEventsData.Set("CL");
        if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLDOUBLECLICK) || this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK) || this.DataGridView.IsCriticalEvent(Control.DoubleClickEvent))
          criticalEventsData.Set("DCL");
        if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLBEGINEDIT))
          criticalEventsData.Set("BE");
        if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLENDEDIT))
          criticalEventsData.Set("EE");
        if ((this.OwningRow == null || !this.OwningRow.IsFilterRow) && (flag || this.GetInheritedContextMenu(this.RowIndex) != null || this.GetInheritedContextMenuStrip(this.RowIndex) != null))
          criticalEventsData.Set("RC");
      }
      return criticalEventsData;
    }

    /// <summary>Gets the mouse event captures.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual MouseCaptures GetMouseEventCaptures() => MouseCaptures.None;

    /// <summary>Gets the key event captures.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual KeyCaptures GetKeyEventCaptures() => KeyCaptures.None;

    internal void OnCommonChange()
    {
      if (this.DataGridView == null || this.DataGridView.IsDisposed || this.DataGridView.Disposing)
        return;
      if (this.RowIndex == -1)
        this.DataGridView.OnColumnCommonChange(this.ColumnIndex);
      else
        this.DataGridView.OnCellCommonChange(this.ColumnIndex, this.RowIndex);
    }

    /// <summary>
    /// This is a recursive function that loop through a control and all of its parents
    /// cheching if one of the controls(and control containers) is hidden or
    /// disabled.
    /// </summary>
    /// <returns>false if one of the controls is hidden or disabled.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool IsEventsEnabled => this.Visible && base.IsEventsEnabled;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Click":
          if (this.DataGridView == null)
            break;
          int eventValue1 = this.GetEventValue(objEvent, "X", 0);
          int eventValue2 = this.GetEventValue(objEvent, "Y", 0);
          MouseEventArgs objMouseEventArgs = new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue1, eventValue2, 0);
          if (objMouseEventArgs.Button == MouseButtons.Right)
            this.OnRightClick(objMouseEventArgs);
          if (this.DataGridView == null)
            break;
          this.DataGridView.FireClickEvents(new MouseEventArgs(objMouseEventArgs.Button, 1, this.Location.X + eventValue1, this.Location.Y + eventValue2, 0), new DataGridViewCellEventArgs(this), new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, eventValue1, eventValue2, new MouseEventArgs(objMouseEventArgs.Button, 1, eventValue1, eventValue2, 0)));
          break;
        case "DoubleClick":
          if (this.DataGridView == null)
            break;
          this.DataGridView.FireDoubleClickEvents(new DataGridViewCellEventArgs(this));
          break;
        case "BeginEdit":
          if (this.DataGridView == null)
            break;
          DataGridViewCellCancelEventArgs e = new DataGridViewCellCancelEventArgs(this);
          this.DataGridView.OnCellBeginEdit(e);
          if (!e.Cancel)
            break;
          this.Update();
          break;
        case "EndEdit":
          if (this.DataGridView == null)
            break;
          this.DataGridView.OnCellEndEdit(new DataGridViewCellEventArgs(this));
          break;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:RightClick" /> event.
    /// </summary>
    /// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
    private void OnRightClick(MouseEventArgs objMouseEventArgs)
    {
      ContextMenu inheritedContextMenu = this.GetInheritedContextMenu(this.RowIndex);
      if (inheritedContextMenu != null)
        inheritedContextMenu.Show((Component) this.DataGridView, (IIdentifiedComponent) this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
      else
        this.GetInheritedContextMenuStrip(this.RowIndex)?.Show((Component) this.DataGridView, (IIdentifiedComponent) this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y));
    }

    /// <summary>Gets the event integer attribute value.</summary>
    /// <param name="objEvent">The event.</param>
    /// <param name="strAttribute">The attribute name.</param>
    /// <param name="intDefault">The default integer value.</param>
    /// <returns></returns>
    protected new int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
    {
      string s = objEvent[strAttribute];
      return CommonUtils.IsNullOrEmpty(s) ? intDefault : int.Parse(s);
    }

    /// <summary>Renders the component event attributes.</summary>
    /// <param name="objContext">context.</param>
    /// <param name="objWriter">writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderCaptureAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      long num = 0;
      MouseCaptures mouseEventCaptures = this.GetMouseEventCaptures();
      if (mouseEventCaptures != MouseCaptures.None)
        num = (long) mouseEventCaptures + 2L;
      KeyCaptures keyEventCaptures = this.GetKeyEventCaptures();
      if (keyEventCaptures != KeyCaptures.None)
        num |= (long) keyEventCaptures + 1L;
      if (!(num > 0L | blnForceRender))
        return;
      objWriter.WriteAttributeString("EC", num.ToString());
    }

    /// <summary>Renders the cell text/value.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objFormatedValue">The formated value.</param>
    protected virtual void RenderCellValue(
      IContext objContext,
      IAttributeWriter objWriter,
      object objFormatedValue)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      this.RenderCellValue(objContext, objWriter, this.mobjFormattedValue);
      this.RenderCellStyleAttributes(objWriter, this.mobjFormattedCellStyle);
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      this.RenderCaptureAttribute(objContext, objWriter, false);
      objWriter.WriteAttributeString("TP", this.TypeName);
      this.RenderReadOnlyAttribute(objWriter);
      if (DataGridViewElement.ShouldRender(this.RenderMask, DataGridViewElement.Renderable.SelectedAttribute))
        this.RenderSelectedAttribute(objContext, objWriter, false);
      if (this.SupportActiveMode)
        objWriter.WriteAttributeText("SAM", "1");
      if (this.SupportEditMode && (!this.HasPanel || this.DataGridView.CustomStyle == "V"))
        objWriter.WriteAttributeText("SEM", "1");
      if (!this.DataGridView.ShowCellToolTips)
        return;
      if (this.HasToolTipText)
        objWriter.WriteAttributeText("TT", this.ToolTipText);
      else if (this is DataGridViewTextBoxCell || this is DataGridViewLinkCell)
      {
        int width = this.DataGridView.Columns[this.ColumnIndex].Width;
        if (this.mobjFormattedCellStyle != null)
          width = this.GetPreferredSize(this.ValueText, this.mobjFormattedCellStyle).Width;
        if (!(this.ValueText != string.Empty) || width <= this.DataGridView.Columns[this.ColumnIndex].Width || this.InheritedStyle.WrapMode == DataGridViewTriState.True)
          return;
        object formattedValue = this.FormattedValue;
        objWriter.WriteAttributeText("TT", formattedValue != null ? formattedValue.ToString() : this.ValueText);
      }
      else
      {
        if (this.ColumnIndex < 0 || this.ColumnIndex >= this.DataGridView.Columns.Count || this.DataGridView.Columns[this.ColumnIndex].CellTemplate == null || !this.DataGridView.Columns[this.ColumnIndex].CellTemplate.HasToolTipText)
          return;
        objWriter.WriteAttributeText("TT", this.DataGridView.Columns[this.ColumnIndex].CellTemplate.ToolTipText);
      }
    }

    /// <summary>Renders the cell style attributes.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objCellStyle">The cell style.</param>
    protected virtual void RenderCellStyleAttributes(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objCellStyle)
    {
      if (objCellStyle == null)
        return;
      if (objCellStyle.Font != null && objCellStyle.Font != this.DataGridView.DefaultDefaultCellStyleInternal.Font)
        objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(objCellStyle.Font));
      objWriter.WriteAttributeString("TIR", 0.ToString());
      this.RenderBackColorAttribute(objWriter, objCellStyle);
      if (objCellStyle.Padding != this.DataGridView.DefaultDefaultCellStyleInternal.Padding)
      {
        Padding padding;
        if (objCellStyle.Padding.Top != 0)
        {
          IAttributeWriter attributeWriter = objWriter;
          padding = objCellStyle.Padding;
          string strValue = Convert.ToString(padding.Top);
          attributeWriter.WriteAttributeString("PT", strValue);
        }
        padding = objCellStyle.Padding;
        if (padding.Right != 0)
        {
          IAttributeWriter attributeWriter = objWriter;
          padding = objCellStyle.Padding;
          string strValue = Convert.ToString(padding.Right);
          attributeWriter.WriteAttributeString("PR", strValue);
        }
        padding = objCellStyle.Padding;
        if (padding.Bottom != 0)
        {
          IAttributeWriter attributeWriter = objWriter;
          padding = objCellStyle.Padding;
          string strValue = Convert.ToString(padding.Bottom);
          attributeWriter.WriteAttributeString("PB", strValue);
        }
        padding = objCellStyle.Padding;
        if (padding.Left != 0)
        {
          IAttributeWriter attributeWriter = objWriter;
          padding = objCellStyle.Padding;
          string strValue = Convert.ToString(padding.Left);
          attributeWriter.WriteAttributeString("PL", strValue);
        }
      }
      this.RenderWrapModeAttribute(objWriter, objCellStyle);
      if (objCellStyle.SelectionBackColor != this.DataGridView.DefaultDefaultCellStyleInternal.SelectionBackColor)
        objWriter.WriteAttributeString("SBC", CommonUtils.GetHtmlColor(objCellStyle.SelectionBackColor));
      this.RenderForeColorAttribute(objWriter, objCellStyle);
      if (!(objCellStyle.SelectionForeColor != this.DataGridView.DefaultDefaultCellStyleInternal.SelectionForeColor))
        return;
      objWriter.WriteAttributeString("SFC", CommonUtils.GetHtmlColor(objCellStyle.SelectionForeColor));
    }

    /// <summary>Renders the updated attributes</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
      {
        this.RenderSelectedAttribute(objContext, objWriter, true);
        this.RenderReadOnlyAttribute(objWriter);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
        return;
      this.RenderCaptureAttribute(objContext, objWriter, true);
    }

    /// <summary>Renders the selected attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderSelectedAttribute(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      if (this.Selected && this.OwningRow != null && !this.OwningRow.Selected && (this.DataGridView.SelectionMode == DataGridViewSelectionMode.CellSelect || this.DataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect))
      {
        objWriter.WriteAttributeString("SE", "1");
      }
      else
      {
        if (!blnForceRender)
          return;
        objWriter.WriteAttributeString("SE", "0");
      }
    }

    /// <summary>Renders the wrap mode attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
    protected virtual void RenderWrapModeAttribute(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objInheritedCellStyle)
    {
      if (objInheritedCellStyle.WrapMode != DataGridViewTriState.True)
        return;
      objWriter.WriteAttributeString("WC", "1");
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
    protected override void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (this.mobjPanel == null || this.mobjPanel.Colspan <= 0 || this.mobjPanel.Rowspan <= 0)
        return;
      this.mobjPanel.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>Renders the read only attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected virtual void RenderReadOnlyAttribute(IAttributeWriter objWriter)
    {
      bool blnElementReadOnlyValue;
      if (this.DataGridView.ReadOnly || !this.GetElementReadOnly(out blnElementReadOnlyValue))
        return;
      if (!blnElementReadOnlyValue && (this.OwningColumn.ElementReadOnly == DataGridViewElement.ElementReadOnlyType.True || this.OwningRow.ElementReadOnly == DataGridViewElement.ElementReadOnlyType.True))
      {
        objWriter.WriteAttributeString("RO", "0");
      }
      else
      {
        if (!blnElementReadOnlyValue || this.OwningColumn.ElementReadOnly == DataGridViewElement.ElementReadOnlyType.True || this.OwningRow.ElementReadOnly == DataGridViewElement.ElementReadOnlyType.True)
          return;
        objWriter.WriteAttributeString("RO", "1");
      }
    }

    /// <summary>Renders the fore color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
    protected virtual void RenderForeColorAttribute(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objInheritedCellStyle)
    {
      if (!(objInheritedCellStyle.ForeColor != this.DataGridView.DefaultDefaultCellStyleInternal.ForeColor))
        return;
      objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(objInheritedCellStyle.ForeColor));
    }

    /// <summary>Renders the back color attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
    protected virtual void RenderBackColorAttribute(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objInheritedCellStyle)
    {
      if (!(objInheritedCellStyle.BackColor != this.DataGridView.DefaultDefaultCellStyleInternal.BackColor))
        return;
      objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(objInheritedCellStyle.BackColor));
    }

    /// <summary>Paints the current DataGridViewCell.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objClipBounds">The clip bounds.</param>
    /// <param name="objCellBounds">The cell bounds.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="enmCellState">State of the cell.</param>
    /// <param name="objValue">The value.</param>
    /// <param name="objFormattedValue">The formatted value.</param>
    /// <param name="strErrorText">The error text.</param>
    /// <param name="objCellStyle">The cell style.</param>
    /// <param name="objAdvancedBorderStyle">The advanced border style.</param>
    /// <param name="enmPaintParts">The paint parts.</param>
    protected virtual void Paint(
      Graphics objGraphics,
      Rectangle objClipBounds,
      Rectangle objCellBounds,
      int intRowIndex,
      DataGridViewElementStates enmCellState,
      object objValue,
      object objFormattedValue,
      string strErrorText,
      DataGridViewCellStyle objCellStyle,
      DataGridViewAdvancedBorderStyle objAdvancedBorderStyle,
      DataGridViewPaintParts enmPaintParts)
    {
    }

    internal static bool PaintBackground(DataGridViewPaintParts paintParts) => (paintParts & DataGridViewPaintParts.Background) != 0;

    internal static bool PaintBorder(DataGridViewPaintParts paintParts) => (paintParts & DataGridViewPaintParts.Border) != 0;

    internal static bool PaintContentBackground(DataGridViewPaintParts paintParts) => (paintParts & DataGridViewPaintParts.ContentBackground) != 0;

    internal static bool PaintContentForeground(DataGridViewPaintParts paintParts) => (paintParts & DataGridViewPaintParts.ContentForeground) != 0;

    internal static bool PaintErrorIcon(DataGridViewPaintParts paintParts) => (paintParts & DataGridViewPaintParts.ErrorIcon) != 0;

    private static void PaintErrorIcon(Graphics objGraphics, Rectangle objIconBounds)
    {
      Bitmap errorBitmap = DataGridViewCell.ErrorBitmap;
      if (errorBitmap == null)
        return;
      lock (errorBitmap)
        objGraphics.DrawImage((Image) errorBitmap, objIconBounds, 0, 0, 12, 11, GraphicsUnit.Pixel);
    }

    /// <summary>
    /// Paints the error icon of the current DataGridViewCell.
    /// </summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objClipBounds">The clip bounds.</param>
    /// <param name="objCellValueBounds">The cell value bounds.</param>
    /// <param name="strErrorText">The error text.</param>
    protected virtual void PaintErrorIcon(
      Graphics objGraphics,
      Rectangle objClipBounds,
      Rectangle objCellValueBounds,
      string strErrorText)
    {
      if (CommonUtils.IsNullOrEmpty(strErrorText) || objCellValueBounds.Width < 20 || objCellValueBounds.Height < 19)
        return;
      DataGridViewCell.PaintErrorIcon(objGraphics, this.ComputeErrorIconBounds(objCellValueBounds));
    }

    internal void PaintErrorIcon(
      Graphics objGraphics,
      DataGridViewCellStyle objCellStyle,
      int intRowIndex,
      Rectangle objCellBounds,
      Rectangle objCellValueBounds,
      string strErrorText)
    {
      if (CommonUtils.IsNullOrEmpty(strErrorText) || objCellValueBounds.Width < 20 || objCellValueBounds.Height < 19)
        return;
      Rectangle errorIconBounds = this.GetErrorIconBounds(objGraphics, objCellStyle, intRowIndex);
      if (errorIconBounds.Width < 4 || errorIconBounds.Height < 11)
        return;
      errorIconBounds.X += objCellBounds.X;
      errorIconBounds.Y += objCellBounds.Y;
      DataGridViewCell.PaintErrorIcon(objGraphics, errorIconBounds);
    }

    internal static bool PaintFocus(DataGridViewPaintParts paintParts) => (paintParts & DataGridViewPaintParts.Focus) != 0;

    internal void PaintInternal(
      Graphics objGraphics,
      Rectangle objClipBounds,
      Rectangle objCellBounds,
      int intRowIndex,
      DataGridViewElementStates enmCellState,
      object objValue,
      object objFormattedValue,
      string strErrorText,
      DataGridViewCellStyle objCellStyle,
      DataGridViewAdvancedBorderStyle objAdvancedBorderStyle,
      DataGridViewPaintParts paintParts)
    {
      this.Paint(objGraphics, objClipBounds, objCellBounds, intRowIndex, enmCellState, objValue, objFormattedValue, strErrorText, objCellStyle, objAdvancedBorderStyle, paintParts);
    }

    internal static void PaintPadding(
      Graphics objGraphics,
      Rectangle objBounds,
      DataGridViewCellStyle objCellStyle,
      Brush objBrush,
      bool blnRightToLeft)
    {
      Rectangle rect;
      if (blnRightToLeft)
      {
        rect = new Rectangle(objBounds.X, objBounds.Y, objCellStyle.Padding.Right, objBounds.Height);
        objGraphics.FillRectangle(objBrush, rect);
        rect.X = objBounds.Right - objCellStyle.Padding.Left;
        rect.Width = objCellStyle.Padding.Left;
        objGraphics.FillRectangle(objBrush, rect);
        rect.X = objBounds.Left + objCellStyle.Padding.Right;
      }
      else
      {
        rect = new Rectangle(objBounds.X, objBounds.Y, objCellStyle.Padding.Left, objBounds.Height);
        objGraphics.FillRectangle(objBrush, rect);
        rect.X = objBounds.Right - objCellStyle.Padding.Right;
        rect.Width = objCellStyle.Padding.Right;
        objGraphics.FillRectangle(objBrush, rect);
        rect.X = objBounds.Left + objCellStyle.Padding.Left;
      }
      rect.Y = objBounds.Y;
      rect.Width = objBounds.Width - objCellStyle.Padding.Horizontal;
      ref Rectangle local1 = ref rect;
      Padding padding = objCellStyle.Padding;
      int top = padding.Top;
      local1.Height = top;
      objGraphics.FillRectangle(objBrush, rect);
      ref Rectangle local2 = ref rect;
      int bottom1 = objBounds.Bottom;
      padding = objCellStyle.Padding;
      int bottom2 = padding.Bottom;
      int num = bottom1 - bottom2;
      local2.Y = num;
      ref Rectangle local3 = ref rect;
      padding = objCellStyle.Padding;
      int bottom3 = padding.Bottom;
      local3.Height = bottom3;
      objGraphics.FillRectangle(objBrush, rect);
    }

    internal static bool PaintSelectionBackground(DataGridViewPaintParts paintParts) => (paintParts & DataGridViewPaintParts.SelectionBackground) != 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objCellBounds"></param>
    /// <param name="objCellClip"></param>
    /// <param name="objCellStyle"></param>
    /// <param name="blnSingleVerticalBorderAdded"></param>
    /// <param name="blnSingleHorizontalBorderAdded"></param>
    /// <param name="blnIsFirstDisplayedColumn"></param>
    /// <param name="blnIsFirstDisplayedRow"></param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual Rectangle PositionEditingPanel(
      Rectangle objCellBounds,
      Rectangle objCellClip,
      DataGridViewCellStyle objCellStyle,
      bool blnSingleVerticalBorderAdded,
      bool blnSingleHorizontalBorderAdded,
      bool blnIsFirstDisplayedColumn,
      bool blnIsFirstDisplayedRow)
    {
      if (this.DataGridView == null)
        throw new InvalidOperationException();
      Rectangle rectangle = this.BorderWidths(this.AdjustCellBorderStyle(this.DataGridView.AdvancedCellBorderStyle, new DataGridViewAdvancedBorderStyle(), blnSingleVerticalBorderAdded, blnSingleHorizontalBorderAdded, blnIsFirstDisplayedColumn, blnIsFirstDisplayedRow));
      rectangle.X += objCellStyle.Padding.Left;
      rectangle.Y += objCellStyle.Padding.Top;
      rectangle.Width += objCellStyle.Padding.Right;
      rectangle.Height += objCellStyle.Padding.Bottom;
      int width1 = objCellBounds.Width;
      int height1 = objCellBounds.Height;
      int x1;
      int num1;
      if (objCellClip.X - objCellBounds.X >= rectangle.X)
      {
        x1 = objCellClip.X;
        num1 = width1 - (objCellClip.X - objCellBounds.X);
      }
      else
      {
        x1 = objCellBounds.X + rectangle.X;
        num1 = width1 - rectangle.X;
      }
      int width2 = objCellClip.Right > objCellBounds.Right - rectangle.Width ? num1 - rectangle.Width : num1 - (objCellBounds.Right - objCellClip.Right);
      int x2 = objCellBounds.X - objCellClip.X;
      int num2 = objCellBounds.Width - rectangle.X - rectangle.Width;
      int y1;
      int num3;
      if (objCellClip.Y - objCellBounds.Y >= rectangle.Y)
      {
        y1 = objCellClip.Y;
        num3 = height1 - (objCellClip.Y - objCellBounds.Y);
      }
      else
      {
        y1 = objCellBounds.Y + rectangle.Y;
        num3 = height1 - rectangle.Y;
      }
      int height2 = objCellClip.Bottom > objCellBounds.Bottom - rectangle.Height ? num3 - rectangle.Height : num3 - (objCellBounds.Bottom - objCellClip.Bottom);
      int num4 = objCellBounds.Y - objCellClip.Y;
      int num5 = objCellBounds.Height - rectangle.Y - rectangle.Height;
      this.DataGridView.EditingPanel.Location = new Point(x1, y1);
      this.DataGridView.EditingPanel.Size = new Size(width2, height2);
      int y2 = num4;
      int width3 = num2;
      int height3 = num5;
      return new Rectangle(x2, y2, width3, height3);
    }

    private static string TruncateToolTipText(string strToolTipText)
    {
      if (strToolTipText.Length <= 288)
        return strToolTipText;
      StringBuilder stringBuilder = new StringBuilder(strToolTipText.Substring(0, 256), 259);
      stringBuilder.Append("...");
      return stringBuilder.ToString();
    }

    private void UpdateCurrentMouseLocation(DataGridViewCellMouseEventArgs e)
    {
      if (this.GetErrorIconBounds(e.RowIndex).Contains(e.X, e.Y))
        this.CurrentMouseLocation = (byte) 2;
      else
        this.CurrentMouseLocation = (byte) 1;
    }

    private string GetToolTipText(int intRowIndex)
    {
      string toolTipTextInternal = this.ToolTipTextInternal;
      return this.DataGridView == null || !this.DataGridView.VirtualMode && this.DataGridView.DataSource == null ? toolTipTextInternal : this.DataGridView.OnCellToolTipTextNeeded(this.ColumnIndex, intRowIndex, toolTipTextInternal);
    }

    /// <summary>Gets the context menu.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal ContextMenu GetContextMenu(int intRowIndex)
    {
      ContextMenu contextMenuInternal = this.ContextMenuInternal;
      return this.DataGridView == null || !this.DataGridView.VirtualMode && this.DataGridView.DataSource == null ? contextMenuInternal : this.DataGridView.OnCellContextMenuNeeded(this.ColumnIndex, intRowIndex, contextMenuInternal);
    }

    /// <summary>Gets the context menu strip.</summary>
    /// <param name="rowIndex">Index of the row.</param>
    /// <returns></returns>
    public ContextMenuStrip GetContextMenuStrip(int rowIndex)
    {
      ContextMenuStrip menuStripInternal = this.ContextMenuStripInternal;
      return this.DataGridView == null || !this.DataGridView.VirtualMode && this.DataGridView.DataSource == null ? menuStripInternal : this.DataGridView.OnCellContextMenuStripNeeded(this.ColumnIndex, rowIndex, menuStripInternal);
    }

    /// <summary>Detaches the context menu.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DetachContextMenu(object sender, EventArgs e) => this.ContextMenuInternal = (ContextMenu) null;

    /// <summary>Detaches the context menu strip.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void DetachContextMenuStrip(object sender, EventArgs e) => this.ContextMenuStripInternal = (ContextMenuStrip) null;

    /// <summary>Gets the inherited context menu strip.</summary>
    /// <param name="rowIndex">Index of the row.</param>
    /// <returns></returns>
    public virtual ContextMenuStrip GetInheritedContextMenuStrip(int rowIndex)
    {
      if (this.DataGridView != null)
      {
        if (rowIndex < 0 || rowIndex >= this.DataGridView.Rows.Count)
          throw new ArgumentOutOfRangeException(nameof (rowIndex));
        if (this.ColumnIndex < 0)
          throw new InvalidOperationException();
      }
      ContextMenuStrip contextMenuStrip1 = this.GetContextMenuStrip(rowIndex);
      if (contextMenuStrip1 != null)
        return contextMenuStrip1;
      if (this.OwningRow != null)
      {
        ContextMenuStrip contextMenuStrip2 = this.OwningRow.GetContextMenuStrip(rowIndex);
        if (contextMenuStrip2 != null)
          return contextMenuStrip2;
      }
      if (this.OwningColumn != null)
      {
        ContextMenuStrip contextMenuStrip3 = this.OwningColumn.ContextMenuStrip;
        if (contextMenuStrip3 != null)
          return contextMenuStrip3;
      }
      return this.DataGridView != null ? this.DataGridView.ContextMenuStrip : (ContextMenuStrip) null;
    }

    /// <summary>Gets the inherited shortcut menu for the current cell.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> if the parent <see cref="T:System.Windows.Forms.DataGridView"></see>, <see cref="T:System.Windows.Forms.DataGridViewRow"></see>, or <see cref="T:System.Windows.Forms.DataGridViewColumn"></see> has a <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> assigned; otherwise, null.</returns>
    /// <param name="intRowIndex">The row index of the current cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the specified rowIndex is less than 0 or greater than the number of rows in the control minus 1. </exception>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    public virtual ContextMenu GetInheritedContextMenu(int intRowIndex)
    {
      if (this.DataGridView != null)
      {
        if (intRowIndex < 0 || intRowIndex >= this.DataGridView.Rows.Count)
          throw new ArgumentOutOfRangeException("rowIndex");
        if (this.ColumnIndex < 0)
          throw new InvalidOperationException();
      }
      ContextMenu contextMenu1 = this.GetContextMenu(intRowIndex);
      if (contextMenu1 != null)
        return contextMenu1;
      if (this.OwningRow != null)
      {
        ContextMenu contextMenu2 = this.OwningRow.GetContextMenu(intRowIndex);
        if (contextMenu2 != null)
          return contextMenu2;
      }
      if (this.OwningColumn != null)
      {
        ContextMenu contextMenu3 = this.OwningColumn.ContextMenu;
        if (contextMenu3 != null)
          return contextMenu3;
      }
      return this.DataGridView != null ? this.DataGridView.ContextMenu : (ContextMenu) null;
    }

    /// <summary>Modifies the input cell border style according to the specified criteria. </summary>
    /// <returns>The modified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</returns>
    /// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the cell border style. </param>
    /// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false. </param>
    /// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the cell border style to modify.</param>
    /// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false. </param>
    /// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false. </param>
    /// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false. </param>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual DataGridViewAdvancedBorderStyle AdjustCellBorderStyle(
      DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput,
      DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder,
      bool blnSingleVerticalBorderAdded,
      bool blnSingleHorizontalBorderAdded,
      bool blnIsFirstDisplayedColumn,
      bool blnIsFirstDisplayedRow)
    {
      return (DataGridViewAdvancedBorderStyle) null;
    }

    /// <summary>Indicates whether the cell's row will be unshared when the cell is clicked.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
    protected virtual bool ClickUnsharesRow(DataGridViewCellEventArgs e) => false;

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public virtual object Clone()
    {
      DataGridViewCell instance = (DataGridViewCell) Activator.CreateInstance(this.GetType());
      this.CloneInternal(instance);
      return (object) instance;
    }

    /// <summary>Indicates whether the cell's row will be unshared when the cell's content is clicked.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnContentClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
    protected virtual bool ContentClickUnsharesRow(DataGridViewCellEventArgs e) => false;

    /// <summary>Indicates whether the cell's row will be unshared when the cell's content is double-clicked.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnContentDoubleClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
    protected virtual bool ContentDoubleClickUnsharesRow(DataGridViewCellEventArgs e) => false;

    /// <summary>Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual void DetachEditingControl()
    {
    }

    /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>. </summary>
    /// <filterpriority>1</filterpriority>
    public void Dispose()
    {
    }

    /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and optionally releases the managed resources. </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool blnDisposing)
    {
    }

    /// <summary>Indicates whether the cell's row will be unshared when the cell is double-clicked.</summary>
    /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnDoubleClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
    protected virtual bool DoubleClickUnsharesRow(DataGridViewCellEventArgs e) => false;

    /// <summary>Indicates whether the parent row will be unshared when the focus moves to the cell.</summary>
    /// <returns>true if the row will be unshared; otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
    /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    protected virtual bool EnterUnsharesRow(int intRowIndex, bool blnThroughMouseClick) => false;

    /// <summary>Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
    /// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="strFormat">The current format string of the cell.</param>
    /// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
    /// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the control.</exception>
    /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">The value of the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property is null.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    protected virtual object GetClipboardContent(
      int intRowIndex,
      bool blnFirstCell,
      bool blnLastCell,
      bool blnInFirstRow,
      bool blnInLastRow,
      string strFormat)
    {
      if (this.DataGridView == null)
        return (object) null;
      if (intRowIndex < 0 || intRowIndex >= this.DataGridView.Rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      DataGridViewCellStyle inheritedStyle = this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false);
      object obj = (object) null;
      if (this.DataGridView.IsSharedCellSelected(this, intRowIndex))
        obj = this.GetEditedFormattedValue(this.GetValue(intRowIndex), intRowIndex, ref inheritedStyle, DataGridViewDataErrorContexts.ClipboardContent | DataGridViewDataErrorContexts.Formatting);
      StringBuilder sb = new StringBuilder(64);
      if (strFormat == DataFormats.Html)
      {
        if (blnFirstCell)
        {
          if (blnInFirstRow)
            sb.Append("<TABLE>");
          sb.Append("<TR>");
        }
        sb.Append("<TD>");
        if (obj != null)
          DataGridViewCell.FormatPlainTextAsHtml(obj.ToString(), (TextWriter) new StringWriter(sb, (IFormatProvider) CultureInfo.CurrentCulture));
        else
          sb.Append("&nbsp;");
        sb.Append("</TD>");
        if (blnLastCell)
        {
          sb.Append("</TR>");
          if (blnInLastRow)
            sb.Append("</TABLE>");
        }
        return (object) sb.ToString();
      }
      bool blnCsv = strFormat == "CommaSeparatedValue";
      if (!blnCsv && !(strFormat == DataFormats.Text) && !(strFormat == DataFormats.UnicodeText))
        return (object) null;
      if (obj != null)
      {
        if (blnFirstCell & blnLastCell && blnInFirstRow & blnInLastRow)
        {
          sb.Append(obj.ToString());
        }
        else
        {
          bool blnEscapeApplied = false;
          int length = sb.Length;
          DataGridViewCell.FormatPlainText(obj.ToString(), blnCsv, (TextWriter) new StringWriter(sb, (IFormatProvider) CultureInfo.CurrentCulture), ref blnEscapeApplied);
          if (blnEscapeApplied)
            sb.Insert(length, '"');
        }
      }
      if (blnLastCell)
      {
        if (!blnInLastRow)
        {
          sb.Append('\r');
          sb.Append('\n');
        }
      }
      else
        sb.Append(blnCsv ? ',' : '\t');
      return (object) sb.ToString();
    }

    /// <summary>Gets the clipboard content internal.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnFirstCell">if set to <c>true</c> [first cell].</param>
    /// <param name="blnLastCell">if set to <c>true</c> [last cell].</param>
    /// <param name="blnInFirstRow">if set to <c>true</c> [in first row].</param>
    /// <param name="blnInLastRow">if set to <c>true</c> [in last row].</param>
    /// <param name="strFormat">The format.</param>
    /// <returns></returns>
    internal object GetClipboardContentInternal(
      int intRowIndex,
      bool blnFirstCell,
      bool blnLastCell,
      bool blnInFirstRow,
      bool blnInLastRow,
      string strFormat)
    {
      return this.GetClipboardContent(intRowIndex, blnFirstCell, blnLastCell, blnInFirstRow, blnInLastRow, strFormat);
    }

    /// <summary>Returns the current, formatted value of the cell, regardless of whether the cell is in edit mode and the value has not been committed.</summary>
    /// <returns>The current, formatted value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
    /// <param name="intRowIndex">The row index of the cell.</param>
    /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified rowIndex is less than 0 or greater than the number of rows in the control minus 1. </exception>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    public object GetEditedFormattedValue(int intRowIndex, DataGridViewDataErrorContexts enmContext)
    {
      if (this.DataGridView == null)
        return (object) null;
      DataGridViewCellStyle inheritedStyle = this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false);
      return this.GetEditedFormattedValue(this.GetValue(intRowIndex), intRowIndex, ref inheritedStyle, enmContext);
    }

    /// <summary>Gets the edited formatted value.</summary>
    /// <param name="objValue">The value.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objDataGridViewCellStyle">The data grid view cell style.</param>
    /// <param name="enmContext">The context.</param>
    /// <returns></returns>
    internal object GetEditedFormattedValue(
      object objValue,
      int intRowIndex,
      ref DataGridViewCellStyle objDataGridViewCellStyle,
      DataGridViewDataErrorContexts enmContext)
    {
      return this.GetFormattedValue(objValue, intRowIndex, ref objDataGridViewCellStyle, (TypeConverter) null, (TypeConverter) null, enmContext);
    }

    /// <summary>Sets the value.</summary>
    /// <param name="objValue">The obj value.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    protected void SetValue(object objValue, bool blnClientSource)
    {
      DataGridView dataGridView1 = this.DataGridView;
      if (dataGridView1 == null)
        return;
      if (dataGridView1.CurrentCell != this)
        dataGridView1.SetCurrentCell(this, blnClientSource);
      this.EditingProposedValue = objValue;
      dataGridView1.BeginEdit(false, blnClientSource);
      bool flag = dataGridView1.NewRowIndex == dataGridView1.CurrentCellPoint.Y;
      dataGridView1.NotifyCurrentCellDirty(true, blnClientSource);
      if (!dataGridView1.CommitEditForOperation(this.ColumnIndex, this.RowIndex, true, blnClientSource))
        this.Update();
      dataGridView1.NotifyCurrentCellDirty(false);
      if (!(dataGridView1.UseInternalPaging & flag) || dataGridView1.CurrentPage == dataGridView1.TotalPages)
        return;
      DataGridView dataGridView2 = dataGridView1;
      dataGridView2.CurrentPage = dataGridView2.TotalPages;
      dataGridView1.PerformScrollIntoView(this, true);
    }

    /// <summary>Pres the render component.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
    internal override void PreRenderComponent(
      IContext objContext,
      long lngRequestID,
      bool blnForcePreRender)
    {
      base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
      if (this.mobjPanel != null)
        this.mobjPanel.PreRenderComponent(objContext, lngRequestID);
      if (!(this.IsDirty(lngRequestID) | blnForcePreRender))
        return;
      int rowIndex = this.RowIndex;
      if (!DataGridViewElement.ShouldPreRender(this.PreRenderMask, DataGridViewElement.PreRenderable.CellStyle))
        return;
      DataGridViewCellStyle inheritedStyle = this.GetInheritedStyle((DataGridViewCellStyle) null, rowIndex, true);
      if (inheritedStyle == null)
        return;
      this.mobjFormattedCellStyle = inheritedStyle.Clone();
      if (this.OwningRow != null && this.OwningRow.IsFilterRow)
        return;
      this.mobjFormattedValue = this.GetEditedFormattedValue(this.GetValue(rowIndex), rowIndex, ref this.mobjFormattedCellStyle, DataGridViewDataErrorContexts.Display | DataGridViewDataErrorContexts.Formatting);
    }

    /// <summary>Gets the value of the cell as formatted for display. </summary>
    /// <returns>The formatted value of the cell or null if the cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
    /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
    /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    /// <param name="objValue">The value to be formatted. </param>
    /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
    /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    protected virtual object GetFormattedValue(
      object objValue,
      int intRowIndex,
      ref DataGridViewCellStyle objCellStyle,
      TypeConverter objValueTypeConverter,
      TypeConverter objFormattedValueTypeConverter,
      DataGridViewDataErrorContexts enmContext)
    {
      if (this.DataGridView == null || this is DataGridViewFilterCell)
        return (object) null;
      DataGridViewCellFormattingEventArgs formattingEventArgs = this.DataGridView.OnCellFormatting(this.ColumnIndex, intRowIndex, objValue, this.FormattedValueType, objCellStyle);
      objCellStyle = formattingEventArgs.CellStyle;
      int num = formattingEventArgs.FormattingApplied ? 1 : 0;
      object objValue1 = formattingEventArgs.Value;
      bool flag = true;
      if (num == 0 && this.FormattedValueType != (Type) null && (objValue1 == null || !this.FormattedValueType.IsAssignableFrom(objValue1.GetType())))
      {
        try
        {
          objValue1 = ClientUtils.FormatObject(objValue1, this.FormattedValueType, objValueTypeConverter == null ? this.ValueTypeConverter : objValueTypeConverter, objFormattedValueTypeConverter == null ? this.FormattedValueTypeConverter : objFormattedValueTypeConverter, objCellStyle.Format, objCellStyle.FormatProvider, objCellStyle.NullValue, objCellStyle.DataSourceNullValue);
        }
        catch (Exception ex)
        {
          if (ClientUtils.IsCriticalException(ex))
          {
            throw;
          }
          else
          {
            int columnIndex = this.ColumnIndex;
            int intRowIndex1 = intRowIndex;
            int enmContext1 = (int) enmContext;
            DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(ex, columnIndex, intRowIndex1, (DataGridViewDataErrorContexts) enmContext1);
            this.RaiseDataError(e);
            if (e.ThrowException)
              throw e.Exception;
            flag = false;
          }
        }
      }
      if (flag && (objValue1 == null || this.FormattedValueType == (Type) null || !this.FormattedValueType.IsAssignableFrom(objValue1.GetType())))
      {
        if (objValue1 == null && objCellStyle.NullValue == null && this.FormattedValueType != (Type) null && !typeof (System.ValueType).IsAssignableFrom(this.FormattedValueType))
          return (object) null;
        DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(!(this.FormattedValueType == (Type) null) ? (Exception) new FormatException(SR.GetString("DataGridViewCell_FormattedValueHasWrongType")) : (Exception) new FormatException(SR.GetString("DataGridViewCell_FormattedValueTypeNull")), this.ColumnIndex, intRowIndex, enmContext);
        this.RaiseDataError(e);
        if (e.ThrowException)
          throw e.Exception;
      }
      return objValue1;
    }

    internal object GetFormattedValue(
      int intRowIndex,
      ref DataGridViewCellStyle objCellStyle,
      DataGridViewDataErrorContexts enmContext)
    {
      return this.DataGridView == null ? (object) null : this.GetFormattedValue(this.GetValue(intRowIndex), intRowIndex, ref objCellStyle, (TypeConverter) null, (TypeConverter) null, enmContext);
    }

    /// <summary>Returns a value indicating the current state of the cell as inherited from the state of its row and column.</summary>
    /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
    /// <param name="intRowIndex">The index of the row containing the cell.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is outside the valid range of 0 to the number of rows in the control minus 1.</exception>
    /// <exception cref="T:System.ArgumentException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is not -1.-or-rowIndex is not the index of the row containing this cell.</exception>
    public virtual DataGridViewElementStates GetInheritedState(int intRowIndex)
    {
      DataGridViewElementStates inheritedState1 = this.State | DataGridViewElementStates.ResizableSet;
      DataGridViewRow owningRow = this.OwningRow;
      if (this.DataGridView == null)
      {
        if (intRowIndex != -1)
          throw new ArgumentException(SR.GetString("InvalidArgument", (object) "rowIndex", (object) intRowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (owningRow != null)
        {
          inheritedState1 |= owningRow.GetState(-1) & (DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
          if (owningRow.GetResizable(intRowIndex) == DataGridViewTriState.True)
            inheritedState1 |= DataGridViewElementStates.Resizable;
        }
        return inheritedState1;
      }
      if (intRowIndex < 0 || intRowIndex >= this.DataGridView.Rows.Count)
        throw new ArgumentOutOfRangeException("rowIndex");
      if (this.DataGridView.Rows.SharedRow(intRowIndex) != owningRow)
        throw new ArgumentException(SR.GetString("InvalidArgument", (object) "rowIndex", (object) intRowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      DataGridViewElementStates rowState = this.DataGridView.Rows.GetRowState(intRowIndex);
      DataGridViewColumn owningColumn = this.OwningColumn;
      DataGridViewElementStates inheritedState2 = inheritedState1 | rowState & (DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Selected) | owningColumn.State & (DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Selected);
      if (owningRow.GetResizable(intRowIndex) == DataGridViewTriState.True || owningColumn.Resizable == DataGridViewTriState.True)
        inheritedState2 |= DataGridViewElementStates.Resizable;
      if (owningColumn.Visible && owningRow.GetVisible(intRowIndex))
      {
        inheritedState2 |= DataGridViewElementStates.Visible;
        if (owningColumn.Displayed && owningRow.GetDisplayed(intRowIndex))
          inheritedState2 |= DataGridViewElementStates.Displayed;
      }
      if (owningColumn.Frozen && owningRow.GetFrozen(intRowIndex))
        inheritedState2 |= DataGridViewElementStates.Frozen;
      return inheritedState2;
    }

    /// <summary>Gets the style applied to the cell. </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
    /// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style. </param>
    /// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0, or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">The cell has no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    public virtual DataGridViewCellStyle GetInheritedStyle(
      DataGridViewCellStyle objInheritedCellStyle,
      int intRowIndex,
      bool blnIncludeColors)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null)
        throw new InvalidOperationException(SR.GetString("DataGridView_CellNeedsDataGridViewForInheritedStyle"));
      if ((intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count) && !this.OwningRow.IsFilterRow)
        throw new ArgumentOutOfRangeException("rowIndex");
      if (this.ColumnIndex < 0)
        throw new InvalidOperationException();
      DataGridViewCellStyle inheritedStyle;
      if (objInheritedCellStyle == null)
      {
        inheritedStyle = dataGridView.PlaceholderCellStyle;
        if (!blnIncludeColors)
        {
          inheritedStyle.BackColor = Color.Empty;
          inheritedStyle.ForeColor = Color.Empty;
          inheritedStyle.SelectionBackColor = Color.Empty;
          inheritedStyle.SelectionForeColor = Color.Empty;
        }
      }
      else
        inheritedStyle = objInheritedCellStyle;
      DataGridViewCellStyle gridViewCellStyle1 = (DataGridViewCellStyle) null;
      if (this.HasStyle)
        gridViewCellStyle1 = this.Style;
      DataGridViewCellStyle gridViewCellStyle2 = (DataGridViewCellStyle) null;
      if (dataGridView.Rows.SharedRow(intRowIndex).HasDefaultCellStyle)
        gridViewCellStyle2 = dataGridView.Rows.SharedRow(intRowIndex).DefaultCellStyle;
      DataGridViewCellStyle gridViewCellStyle3 = (DataGridViewCellStyle) null;
      DataGridViewColumn owningColumn = this.OwningColumn;
      if (owningColumn.HasDefaultCellStyle)
        gridViewCellStyle3 = owningColumn.DefaultCellStyle;
      DataGridViewCellStyle defaultCellStyle1 = dataGridView.RowsDefaultCellStyle;
      DataGridViewCellStyle defaultCellStyle2 = dataGridView.AlternatingRowsDefaultCellStyle;
      DataGridViewCellStyle defaultCellStyle3 = dataGridView.DefaultCellStyle;
      if (blnIncludeColors)
      {
        inheritedStyle.BackColor = gridViewCellStyle1 == null || gridViewCellStyle1.BackColor.IsEmpty ? (gridViewCellStyle2 == null || gridViewCellStyle2.BackColor.IsEmpty ? (defaultCellStyle1.BackColor.IsEmpty || intRowIndex % 2 != 0 && !defaultCellStyle2.BackColor.IsEmpty ? (intRowIndex % 2 != 1 || defaultCellStyle2.BackColor.IsEmpty ? (gridViewCellStyle3 == null || gridViewCellStyle3.BackColor.IsEmpty ? defaultCellStyle3.BackColor : gridViewCellStyle3.BackColor) : defaultCellStyle2.BackColor) : defaultCellStyle1.BackColor) : gridViewCellStyle2.BackColor) : gridViewCellStyle1.BackColor;
        inheritedStyle.ForeColor = gridViewCellStyle1 == null || gridViewCellStyle1.ForeColor.IsEmpty ? (gridViewCellStyle2 == null || gridViewCellStyle2.ForeColor.IsEmpty ? (defaultCellStyle1.ForeColor.IsEmpty || intRowIndex % 2 != 0 && !defaultCellStyle2.ForeColor.IsEmpty ? (intRowIndex % 2 != 1 || defaultCellStyle2.ForeColor.IsEmpty ? (gridViewCellStyle3 == null || gridViewCellStyle3.ForeColor.IsEmpty ? defaultCellStyle3.ForeColor : gridViewCellStyle3.ForeColor) : defaultCellStyle2.ForeColor) : defaultCellStyle1.ForeColor) : gridViewCellStyle2.ForeColor) : gridViewCellStyle1.ForeColor;
        inheritedStyle.SelectionBackColor = gridViewCellStyle1 == null || gridViewCellStyle1.SelectionBackColor.IsEmpty ? (gridViewCellStyle2 == null || gridViewCellStyle2.SelectionBackColor.IsEmpty ? (defaultCellStyle1.SelectionBackColor.IsEmpty || intRowIndex % 2 != 0 && !defaultCellStyle2.SelectionBackColor.IsEmpty ? (intRowIndex % 2 != 1 || defaultCellStyle2.SelectionBackColor.IsEmpty ? (gridViewCellStyle3 == null || gridViewCellStyle3.SelectionBackColor.IsEmpty ? defaultCellStyle3.SelectionBackColor : gridViewCellStyle3.SelectionBackColor) : defaultCellStyle2.SelectionBackColor) : defaultCellStyle1.SelectionBackColor) : gridViewCellStyle2.SelectionBackColor) : gridViewCellStyle1.SelectionBackColor;
        inheritedStyle.SelectionForeColor = gridViewCellStyle1 == null || gridViewCellStyle1.SelectionForeColor.IsEmpty ? (gridViewCellStyle2 == null || gridViewCellStyle2.SelectionForeColor.IsEmpty ? (defaultCellStyle1.SelectionForeColor.IsEmpty || intRowIndex % 2 != 0 && !defaultCellStyle2.SelectionForeColor.IsEmpty ? (intRowIndex % 2 != 1 || defaultCellStyle2.SelectionForeColor.IsEmpty ? (gridViewCellStyle3 == null || gridViewCellStyle3.SelectionForeColor.IsEmpty ? defaultCellStyle3.SelectionForeColor : gridViewCellStyle3.SelectionForeColor) : defaultCellStyle2.SelectionForeColor) : defaultCellStyle1.SelectionForeColor) : gridViewCellStyle2.SelectionForeColor) : gridViewCellStyle1.SelectionForeColor;
      }
      inheritedStyle.Font = gridViewCellStyle1 == null || gridViewCellStyle1.Font == null ? (gridViewCellStyle2 == null || gridViewCellStyle2.Font == null ? (defaultCellStyle1.Font == null || intRowIndex % 2 != 0 && defaultCellStyle2.Font != null ? (intRowIndex % 2 != 1 || defaultCellStyle2.Font == null ? (gridViewCellStyle3 == null || gridViewCellStyle3.Font == null ? defaultCellStyle3.Font : gridViewCellStyle3.Font) : defaultCellStyle2.Font) : defaultCellStyle1.Font) : gridViewCellStyle2.Font) : gridViewCellStyle1.Font;
      bool nullValueDefault = defaultCellStyle2.IsNullValueDefault;
      inheritedStyle.NullValue = gridViewCellStyle1 == null || gridViewCellStyle1.IsNullValueDefault ? (gridViewCellStyle2 == null || gridViewCellStyle2.IsNullValueDefault ? (defaultCellStyle1.IsNullValueDefault || !(intRowIndex % 2 == 0 | nullValueDefault) ? (intRowIndex % 2 != 1 || nullValueDefault ? (gridViewCellStyle3 == null || gridViewCellStyle3.IsNullValueDefault ? defaultCellStyle3.NullValue : gridViewCellStyle3.NullValue) : defaultCellStyle2.NullValue) : defaultCellStyle1.NullValue) : gridViewCellStyle2.NullValue) : gridViewCellStyle1.NullValue;
      inheritedStyle.DataSourceNullValue = gridViewCellStyle1 == null || gridViewCellStyle1.IsDataSourceNullValueDefault ? (gridViewCellStyle2 == null || gridViewCellStyle2.IsDataSourceNullValueDefault ? (defaultCellStyle1.IsDataSourceNullValueDefault || intRowIndex % 2 != 0 && !defaultCellStyle2.IsDataSourceNullValueDefault ? (intRowIndex % 2 != 1 || defaultCellStyle2.IsDataSourceNullValueDefault ? (gridViewCellStyle3 == null || gridViewCellStyle3.IsDataSourceNullValueDefault ? defaultCellStyle3.DataSourceNullValue : gridViewCellStyle3.DataSourceNullValue) : defaultCellStyle2.DataSourceNullValue) : defaultCellStyle1.DataSourceNullValue) : gridViewCellStyle2.DataSourceNullValue) : gridViewCellStyle1.DataSourceNullValue;
      inheritedStyle.Format = gridViewCellStyle1 == null || gridViewCellStyle1.Format.Length == 0 ? (gridViewCellStyle2 == null || gridViewCellStyle2.Format.Length == 0 ? (defaultCellStyle1.Format.Length == 0 || intRowIndex % 2 != 0 && defaultCellStyle2.Format.Length != 0 ? (intRowIndex % 2 != 1 || defaultCellStyle2.Format.Length == 0 ? (gridViewCellStyle3 == null || gridViewCellStyle3.Format.Length == 0 ? defaultCellStyle3.Format : gridViewCellStyle3.Format) : defaultCellStyle2.Format) : defaultCellStyle1.Format) : gridViewCellStyle2.Format) : gridViewCellStyle1.Format;
      inheritedStyle.FormatProvider = gridViewCellStyle1 == null || gridViewCellStyle1.IsFormatProviderDefault ? (gridViewCellStyle2 == null || gridViewCellStyle2.IsFormatProviderDefault ? (defaultCellStyle1.IsFormatProviderDefault || intRowIndex % 2 != 0 && !defaultCellStyle2.IsFormatProviderDefault ? (intRowIndex % 2 != 1 || defaultCellStyle2.IsFormatProviderDefault ? (gridViewCellStyle3 == null || gridViewCellStyle3.IsFormatProviderDefault ? defaultCellStyle3.FormatProvider : gridViewCellStyle3.FormatProvider) : defaultCellStyle2.FormatProvider) : defaultCellStyle1.FormatProvider) : gridViewCellStyle2.FormatProvider) : gridViewCellStyle1.FormatProvider;
      inheritedStyle.AlignmentInternal = gridViewCellStyle1 == null || gridViewCellStyle1.Alignment == DataGridViewContentAlignment.NotSet ? (gridViewCellStyle2 == null || gridViewCellStyle2.Alignment == DataGridViewContentAlignment.NotSet ? (defaultCellStyle1.Alignment == DataGridViewContentAlignment.NotSet || intRowIndex % 2 != 0 && defaultCellStyle2.Alignment != DataGridViewContentAlignment.NotSet ? (intRowIndex % 2 != 1 || defaultCellStyle2.Alignment == DataGridViewContentAlignment.NotSet ? (gridViewCellStyle3 == null || gridViewCellStyle3.Alignment == DataGridViewContentAlignment.NotSet ? defaultCellStyle3.Alignment : gridViewCellStyle3.Alignment) : defaultCellStyle2.Alignment) : defaultCellStyle1.Alignment) : gridViewCellStyle2.Alignment) : gridViewCellStyle1.Alignment;
      inheritedStyle.WrapModeInternal = gridViewCellStyle1 == null || gridViewCellStyle1.WrapMode == DataGridViewTriState.NotSet ? (gridViewCellStyle2 == null || gridViewCellStyle2.WrapMode == DataGridViewTriState.NotSet ? (defaultCellStyle1.WrapMode == DataGridViewTriState.NotSet || intRowIndex % 2 != 0 && defaultCellStyle2.WrapMode != DataGridViewTriState.NotSet ? (intRowIndex % 2 != 1 || defaultCellStyle2.WrapMode == DataGridViewTriState.NotSet ? (gridViewCellStyle3 == null || gridViewCellStyle3.WrapMode == DataGridViewTriState.NotSet ? defaultCellStyle3.WrapMode : gridViewCellStyle3.WrapMode) : defaultCellStyle2.WrapMode) : defaultCellStyle1.WrapMode) : gridViewCellStyle2.WrapMode) : gridViewCellStyle1.WrapMode;
      inheritedStyle.Tag = gridViewCellStyle1 == null || gridViewCellStyle1.Tag == null ? (gridViewCellStyle2 == null || gridViewCellStyle2.Tag == null ? (defaultCellStyle1.Tag == null || intRowIndex % 2 != 0 && defaultCellStyle2.Tag != null ? (intRowIndex % 2 != 1 || defaultCellStyle2.Tag == null ? (gridViewCellStyle3 == null || gridViewCellStyle3.Tag == null ? defaultCellStyle3.Tag : gridViewCellStyle3.Tag) : defaultCellStyle2.Tag) : defaultCellStyle1.Tag) : gridViewCellStyle2.Tag) : gridViewCellStyle1.Tag;
      if (gridViewCellStyle1 != null && gridViewCellStyle1.Padding != Padding.Empty)
      {
        inheritedStyle.PaddingInternal = gridViewCellStyle1.Padding;
        return inheritedStyle;
      }
      if (gridViewCellStyle2 != null && gridViewCellStyle2.Padding != Padding.Empty)
      {
        inheritedStyle.PaddingInternal = gridViewCellStyle2.Padding;
        return inheritedStyle;
      }
      bool flag = defaultCellStyle2.Padding == Padding.Empty;
      if (defaultCellStyle1.Padding != Padding.Empty && intRowIndex % 2 == 0 | flag)
      {
        inheritedStyle.PaddingInternal = defaultCellStyle1.Padding;
        return inheritedStyle;
      }
      if (intRowIndex % 2 == 1 && !flag)
      {
        inheritedStyle.PaddingInternal = defaultCellStyle2.Padding;
        return inheritedStyle;
      }
      if (gridViewCellStyle3 != null && gridViewCellStyle3.Padding != Padding.Empty)
      {
        inheritedStyle.PaddingInternal = gridViewCellStyle3.Padding;
        return inheritedStyle;
      }
      inheritedStyle.PaddingInternal = defaultCellStyle3.Padding;
      return inheritedStyle;
    }

    /// <summary>Gets the size of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> representing the cell's dimensions.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <exception cref="T:System.InvalidOperationException">rowIndex is -1</exception>
    protected virtual Size GetSize(int intRowIndex)
    {
      if (this.DataGridView == null)
        return new Size(-1, -1);
      if (intRowIndex == -1)
        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedCell", (object) "Size"));
      return new Size(this.OwningColumn.Thickness, this.OwningRow.GetHeight(intRowIndex));
    }

    /// <summary>Gets the value of the cell. </summary>
    /// <returns>The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
    protected virtual object GetValue(int intRowIndex)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView != null)
      {
        if (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count)
          throw new ArgumentOutOfRangeException("rowIndex");
        if (this.ColumnIndex < 0)
          throw new InvalidOperationException();
      }
      if (dataGridView == null || dataGridView.AllowUserToAddRowsInternal && intRowIndex > -1 && intRowIndex == dataGridView.NewRowIndex && intRowIndex != dataGridView.CurrentCellAddress.Y || !dataGridView.VirtualMode && this.OwningColumn != null && !this.OwningColumn.IsDataBound || intRowIndex == -1 || this.ColumnIndex == -1)
        return this.mojValue;
      if (this.OwningColumn == null || !this.OwningColumn.IsDataBound)
        return dataGridView.OnCellValueNeeded(this.ColumnIndex, intRowIndex);
      DataGridView.DataGridViewDataConnection dataConnection = dataGridView.DataConnection;
      if (dataConnection == null)
        return (object) null;
      return dataConnection.CurrencyManager.Count <= intRowIndex ? this.mojValue : dataConnection.GetValue(this.OwningColumn.BoundColumnIndex, this.ColumnIndex, intRowIndex);
    }

    /// <summary>Initializes the control used to edit the cell.</summary>
    /// <param name="objInitialFormattedValue">An <see cref="T:System.Object"></see> that represents the value displayed by the cell when editing is started.</param>
    /// <param name="intRowIndex">The zero-based row index of the cell's location.</param>
    /// <param name="objDataGridViewCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    /// <exception cref="T:System.InvalidOperationException">There is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> or if one is present, it does not have an associated editing control. </exception>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual void InitializeEditingControl(
      int intRowIndex,
      object objInitialFormattedValue,
      DataGridViewCellStyle objDataGridViewCellStyle)
    {
    }

    /// <summary>
    /// Returns a Rectangle that represents the widths of all the cell margins.
    /// </summary>
    /// <param name="objAdvancedBorderStyle">The advanced border style.</param>
    /// <returns></returns>
    protected virtual Rectangle BorderWidths(
      DataGridViewAdvancedBorderStyle objAdvancedBorderStyle)
    {
      Rectangle rectangle = new Rectangle();
      rectangle.X = objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.None ? 0 : 1;
      if (objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.InsetDouble)
        ++rectangle.X;
      rectangle.Y = objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.None ? 0 : 1;
      if (objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.InsetDouble)
        ++rectangle.Y;
      rectangle.Width = objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.None ? 0 : 1;
      if (objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.InsetDouble)
        ++rectangle.Width;
      rectangle.Height = objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.None ? 0 : 1;
      if (objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble || objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.InsetDouble)
        ++rectangle.Height;
      DataGridViewColumn owningColumn = this.OwningColumn;
      if (owningColumn != null)
      {
        if (this.DataGridView != null && this.DataGridView.RightToLeftInternal)
          rectangle.X += owningColumn.DividerWidth;
        else
          rectangle.Width += owningColumn.DividerWidth;
      }
      DataGridViewRow owningRow = this.OwningRow;
      if (owningRow != null)
        rectangle.Height += owningRow.DividerHeight;
      return rectangle;
    }

    /// <summary>Caches the editing control.</summary>
    internal virtual void CacheEditingControl()
    {
    }

    /// <summary>Cells the state from column row states.</summary>
    /// <param name="enmRowState">State of the row.</param>
    /// <returns></returns>
    internal DataGridViewElementStates CellStateFromColumnRowStates(
      DataGridViewElementStates enmRowState)
    {
      DataGridViewElementStates viewElementStates1 = DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected;
      DataGridViewElementStates viewElementStates2 = DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible;
      DataGridViewColumn owningColumn = this.OwningColumn;
      return owningColumn.State & viewElementStates1 | enmRowState & viewElementStates1 | owningColumn.State & viewElementStates2 & enmRowState & viewElementStates2;
    }

    /// <summary>Clicks the unshares row internal.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
    /// <returns></returns>
    internal bool ClickUnsharesRowInternal(DataGridViewCellEventArgs e) => this.ClickUnsharesRow(e);

    /// <summary>Colors the distance.</summary>
    /// <param name="objColor1">The color1.</param>
    /// <param name="objColor2">The color2.</param>
    /// <returns></returns>
    internal static int ColorDistance(Color objColor1, Color objColor2)
    {
      int num1 = (int) objColor1.R - (int) objColor2.R;
      int num2 = (int) objColor1.G - (int) objColor2.G;
      int num3 = (int) objColor1.B - (int) objColor2.B;
      int num4 = num1 * num1;
      int num5 = num2;
      int num6 = num5 * num5;
      int num7 = num4 + num6;
      int num8 = num3;
      int num9 = num8 * num8;
      return num7 + num9;
    }

    /// <summary>Computes the error icon bounds.</summary>
    /// <param name="objCellValueBounds">The cell value bounds.</param>
    /// <returns></returns>
    internal Rectangle ComputeErrorIconBounds(Rectangle objCellValueBounds) => objCellValueBounds.Width >= 20 && objCellValueBounds.Height >= 19 ? new Rectangle(this.DataGridView.RightToLeftInternal ? objCellValueBounds.Left + 4 : objCellValueBounds.Right - 4 - 12, objCellValueBounds.Y + (objCellValueBounds.Height - 11) / 2, 12, 11) : Rectangle.Empty;

    /// <summary>Contents the click unshares row internal.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
    /// <returns></returns>
    internal bool ContentClickUnsharesRowInternal(DataGridViewCellEventArgs e) => this.ContentClickUnsharesRow(e);

    /// <summary>Contents the double click unshares row internal.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
    /// <returns></returns>
    internal bool ContentDoubleClickUnsharesRowInternal(DataGridViewCellEventArgs e) => this.ContentDoubleClickUnsharesRow(e);

    /// <summary>Doubles the click unshares row internal.</summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
    /// <returns></returns>
    internal bool DoubleClickUnsharesRowInternal(DataGridViewCellEventArgs e) => this.DoubleClickUnsharesRow(e);

    /// <summary>Enters the unshares row internal.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnThroughMouseClick">if set to <c>true</c> [through mouse click].</param>
    /// <returns></returns>
    internal bool EnterUnsharesRowInternal(int intRowIndex, bool blnThroughMouseClick) => this.EnterUnsharesRow(intRowIndex, blnThroughMouseClick);

    /// <summary>
    /// Returns the bounding rectangle that encloses the cell's content area using a default Graphics and cell style currently in effect for the cell.
    /// </summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    public Rectangle GetContentBounds(int intRowIndex) => this.DataGridView == null ? Rectangle.Empty : this.GetContentBounds(this.DataGridView.CachedGraphics, this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false), intRowIndex);

    /// <summary>
    /// Returns the bounding rectangle that encloses the cell's content area using a default Graphics and cell style currently in effect for the cell.
    /// </summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objCellStyle">The cell style.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    protected virtual Rectangle GetContentBounds(
      Graphics objGraphics,
      DataGridViewCellStyle objCellStyle,
      int intRowIndex)
    {
      return Rectangle.Empty;
    }

    /// <summary>
    /// Returns the bounding rectangle that encloses the cell's error icon, if one is displayed.
    /// </summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    internal Rectangle GetErrorIconBounds(int intRowIndex) => this.GetErrorIconBounds(this.DataGridView.CachedGraphics, this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false), intRowIndex);

    /// <summary>
    /// Returns the bounding rectangle that encloses the cell's error icon, if one is displayed.
    /// </summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objCellStyle">The cell style.</param>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    protected virtual Rectangle GetErrorIconBounds(
      Graphics objGraphics,
      DataGridViewCellStyle objCellStyle,
      int intRowIndex)
    {
      return Rectangle.Empty;
    }

    internal static DataGridViewFreeDimension GetFreeDimensionFromConstraint(Size objConstraintSize)
    {
      if (objConstraintSize.Width < 0 || objConstraintSize.Height < 0)
        throw new ArgumentException(SR.GetString("InvalidArgument", (object) "constraintSize", (object) objConstraintSize.ToString()));
      if (objConstraintSize.Width == 0)
        return objConstraintSize.Height == 0 ? DataGridViewFreeDimension.Both : DataGridViewFreeDimension.Width;
      if (objConstraintSize.Height != 0)
        throw new ArgumentException(SR.GetString("InvalidArgument", (object) "constraintSize", (object) objConstraintSize.ToString()));
      return DataGridViewFreeDimension.Height;
    }

    internal int GetHeight(int intRowIndex) => this.DataGridView == null ? -1 : this.OwningRow.GetHeight(intRowIndex);

    /// <summary>Leaves the unshares row internal.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="blnThroughMouseClick">if set to <c>true</c> [through mouse click].</param>
    /// <returns></returns>
    internal bool LeaveUnsharesRowInternal(int intRowIndex, bool blnThroughMouseClick) => this.LeaveUnsharesRow(intRowIndex, blnThroughMouseClick);

    /// <summary>
    /// Converts a value formatted for display to an actual cell value.
    /// </summary>
    /// <param name="objFormattedValue">The formatted value.</param>
    /// <param name="objCellStyle">The cell style.</param>
    /// <param name="objFormattedValueTypeConverter">The formatted value type converter.</param>
    /// <param name="objValueTypeConverter">The value type converter.</param>
    /// <returns></returns>
    public virtual object ParseFormattedValue(
      object objFormattedValue,
      DataGridViewCellStyle objCellStyle,
      TypeConverter objFormattedValueTypeConverter,
      TypeConverter objValueTypeConverter)
    {
      return this.ParseFormattedValueInternal(this.ValueType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
    }

    internal object ParseFormattedValueInternal(
      Type objValueType,
      object objFormattedValue,
      DataGridViewCellStyle objCellStyle,
      TypeConverter objFormattedValueTypeConverter,
      TypeConverter objValueTypeConverter)
    {
      if (objCellStyle == null)
        throw new ArgumentNullException("cellStyle");
      if (this.FormattedValueType == (Type) null)
        throw new FormatException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
      if (objValueType == (Type) null)
        throw new FormatException(SR.GetString("DataGridViewCell_ValueTypeNull"));
      if (objFormattedValue == null || !this.FormattedValueType.IsAssignableFrom(objFormattedValue.GetType()))
        throw new ArgumentException(SR.GetString("DataGridViewCell_FormattedValueHasWrongType"), "formattedValue");
      return ClientUtils.ParseObject(objFormattedValue, objValueType, this.FormattedValueType, objValueTypeConverter == null ? this.ValueTypeConverter : objValueTypeConverter, objFormattedValueTypeConverter == null ? this.FormattedValueTypeConverter : objFormattedValueTypeConverter, objCellStyle.FormatProvider, objCellStyle.NullValue, objCellStyle.IsDataSourceNullValueDefault ? ClientUtils.GetDefaultDataSourceNullValue(objValueType) : objCellStyle.DataSourceNullValue);
    }

    /// <summary>Sets the location and size of the editing control hosted by a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    /// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell being edited.</param>
    /// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false.</param>
    /// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false.</param>
    /// <param name="blnSetSize">true to specify the size; false to allow the control to size itself. </param>
    /// <param name="blnSetLocation">true to have the control placed as specified by the other arguments; false to allow the control to place itself.</param>
    /// <param name="objCellClip">The area that will be used to paint the editing control.</param>
    /// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false.</param>
    /// <param name="objCellBounds">A <see cref="T:System.Drawing.Rectangle"></see> that defines the cell bounds. </param>
    /// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false.</param>
    /// <exception cref="T:System.InvalidOperationException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual void PositionEditingControl(
      bool blnSetLocation,
      bool blnSetSize,
      Rectangle objCellBounds,
      Rectangle objCellClip,
      DataGridViewCellStyle objCellStyle,
      bool blnSingleVerticalBorderAdded,
      bool blnSingleHorizontalBorderAdded,
      bool blnIsFirstDisplayedColumn,
      bool blnIsFirstDisplayedRow)
    {
      Rectangle rectangle = this.PositionEditingPanel(objCellBounds, objCellClip, objCellStyle, blnSingleVerticalBorderAdded, blnSingleHorizontalBorderAdded, blnIsFirstDisplayedColumn, blnIsFirstDisplayedRow);
      if (blnSetLocation)
        this.DataGridView.EditingControl.Location = new Point(rectangle.X, rectangle.Y);
      if (!blnSetSize)
        return;
      this.DataGridView.EditingControl.Size = new Size(rectangle.Width, rectangle.Height);
    }

    /// <summary>Sets the value of the cell. </summary>
    /// <returns>true if the value has been set; otherwise, false.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    /// <param name="objValue">The cell value to set. </param>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    protected virtual bool SetValue(int intRowIndex, object objValue) => this.SetValue(intRowIndex, objValue, false);

    /// <summary>Sets the value of the cell. </summary>
    /// <returns>true if the value has been set; otherwise, false.</returns>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    /// <param name="objValue">The cell value to set. </param>
    /// <param name="blnClientSource">Client source. </param>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    private bool SetValue(int intRowIndex, object objValue, bool blnClientSource)
    {
      object obj = (object) null;
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView != null && !dataGridView.InSortOperation)
        obj = this.GetValue(intRowIndex);
      if (dataGridView != null && this.OwningColumn != null && this.OwningColumn.IsDataBound)
      {
        DataGridView.DataGridViewDataConnection dataConnection = dataGridView.DataConnection;
        if (dataConnection == null)
          return false;
        if (dataConnection.CurrencyManager.Count <= intRowIndex)
        {
          if (objValue != null || this.mojValue != null)
            this.mojValue = objValue;
        }
        else
        {
          if (!dataConnection.PushValue(this.OwningColumn.BoundColumnIndex, this.ColumnIndex, intRowIndex, objValue))
            return false;
          if (this.DataGridView == null || this.OwningRow == null || this.OwningRow.DataGridView == null)
            return true;
          if (this.OwningRow.Index == this.DataGridView.CurrentCellAddress.Y)
            this.DataGridView.SetIsCurrentRowDirtyInternal(true, blnClientSource);
        }
      }
      else if (dataGridView == null || !dataGridView.VirtualMode || intRowIndex == -1 || this.ColumnIndex == -1)
      {
        if (objValue != null || this.mojValue != null)
          this.mojValue = objValue;
      }
      else
        dataGridView.OnCellValuePushed(this.ColumnIndex, intRowIndex, objValue);
      if (dataGridView != null && !dataGridView.InSortOperation && (obj == null && objValue != null || obj != null && objValue == null || obj != null && !objValue.Equals(obj)))
        this.RaiseCellValueChanged(new DataGridViewCellEventArgs(this.ColumnIndex, intRowIndex), blnClientSource);
      return true;
    }

    /// <summary>Sets the value internal.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objValue">The value.</param>
    /// <returns></returns>
    internal bool SetValueInternal(int intRowIndex, object objValue) => this.SetValueInternal(intRowIndex, objValue, false);

    /// <summary>Sets the value internal.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <param name="objValue">The value.</param>
    /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
    /// <returns></returns>
    internal bool SetValueInternal(int intRowIndex, object objValue, bool blnClientSource) => this.SetValue(intRowIndex, objValue, blnClientSource);

    /// <summary>Returns a string that describes the current object. </summary>
    /// <returns>A string that represents the current object.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString() => "DataGridViewCell { ColumnIndex=" + this.ColumnIndex.ToString() + ", RowIndex=" + this.RowIndex.ToString() + " }";

    /// <summary>Clones the internal.</summary>
    /// <param name="objDataGridViewCell">The data grid view cell.</param>
    protected void CloneInternal(DataGridViewCell objDataGridViewCell)
    {
      if (this.HasValueType)
        objDataGridViewCell.ValueType = this.ValueType;
      if (this.HasStyle)
        objDataGridViewCell.Style = new DataGridViewCellStyle(this.Style);
      if (this.HasErrorText)
        objDataGridViewCell.ErrorText = this.ErrorTextInternal;
      objDataGridViewCell.StateInternal = this.State & ~DataGridViewElementStates.Selected;
      objDataGridViewCell.Tag = this.Tag;
      objDataGridViewCell.LastModified = this.LastModified;
      objDataGridViewCell.LastModifiedParams = this.LastModifiedParams;
      objDataGridViewCell.LastModifiedParamsType = this.LastModifiedParamsType;
    }

    /// <summary>Formats the plain text as HTML.</summary>
    /// <param name="str">The s.</param>
    /// <param name="objOutput">The output.</param>
    internal static void FormatPlainTextAsHtml(string str, TextWriter objOutput)
    {
      if (str == null)
        return;
      int length = str.Length;
      char ch1 = char.MinValue;
      for (int index = 0; index < length; ++index)
      {
        char ch2 = str[index];
        switch (ch2)
        {
          case '\n':
            objOutput.Write("<br>");
            goto case '\r';
          case '\r':
            ch1 = ch2;
            continue;
          case ' ':
            if (ch1 == ' ')
            {
              objOutput.Write("&nbsp;");
              goto case '\r';
            }
            else
            {
              objOutput.Write(ch2);
              goto case '\r';
            }
          case '"':
            objOutput.Write("&quot;");
            goto case '\r';
          case '&':
            objOutput.Write("&amp;");
            goto case '\r';
          case '<':
            objOutput.Write("&lt;");
            goto case '\r';
          case '>':
            objOutput.Write("&gt;");
            goto case '\r';
          default:
            if (ch2 >= ' ' && ch2 < 'Ā')
            {
              objOutput.Write("&#");
              objOutput.Write(((int) ch2).ToString((IFormatProvider) NumberFormatInfo.InvariantInfo));
              objOutput.Write(';');
              goto case '\r';
            }
            else
            {
              objOutput.Write(ch2);
              goto case '\r';
            }
        }
      }
    }

    /// <summary>Formats the plain text.</summary>
    /// <param name="str">The s.</param>
    /// <param name="blnCsv">if set to <c>true</c> [CSV].</param>
    /// <param name="objOutput">The output.</param>
    /// <param name="blnEscapeApplied">if set to <c>true</c> [escape applied].</param>
    internal static void FormatPlainText(
      string str,
      bool blnCsv,
      TextWriter objOutput,
      ref bool blnEscapeApplied)
    {
      if (str == null)
        return;
      int length = str.Length;
      for (int index = 0; index < length; ++index)
      {
        char ch = str[index];
        switch (ch)
        {
          case '\t':
            if (!blnCsv)
            {
              objOutput.Write(' ');
              break;
            }
            objOutput.Write('\t');
            break;
          case '"':
            if (blnCsv)
            {
              objOutput.Write("\"\"");
              blnEscapeApplied = true;
              break;
            }
            objOutput.Write('"');
            break;
          case ',':
            if (blnCsv)
              blnEscapeApplied = true;
            objOutput.Write(',');
            break;
          default:
            objOutput.Write(ch);
            break;
        }
      }
      if (!blnEscapeApplied)
        return;
      objOutput.Write('"');
    }

    private static Bitmap GetBitmap(string strBitmapName)
    {
      Bitmap bitmap = new Bitmap(typeof (DataGridViewCell), strBitmapName);
      bitmap.MakeTransparent();
      return bitmap;
    }

    internal object GetValueInternal(int intRowIndex) => this.GetValue(intRowIndex);

    internal int GetPreferredWidth(int intRowIndex, int intHeight) => this.DataGridView == null ? -1 : this.GetPreferredSize(this.DataGridView.CachedGraphics, this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false), intRowIndex, new Size(0, intHeight)).Width;

    internal DataGridViewCellStyle GetInheritedStyleInternal(int intRowIndex) => this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, true);

    /// <summary>Returns a string that represents the error for the cell.</summary>
    /// <returns>A string that describes the error for the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
    /// <param name="intRowIndex">The row index of the cell.</param>
    protected internal virtual string GetErrorText(int intRowIndex)
    {
      string strErrorText = string.Empty;
      object mobjErrorText = this.mobjErrorText;
      if (mobjErrorText != null)
        strErrorText = (string) mobjErrorText;
      else if (this.DataGridView != null && intRowIndex != -1 && intRowIndex != this.DataGridView.NewRowIndex && this.OwningColumn != null && this.OwningColumn.IsDataBound && this.DataGridView.DataConnection != null)
        strErrorText = this.DataGridView.DataConnection.GetError(this.OwningColumn.BoundColumnIndex, this.ColumnIndex, intRowIndex);
      if (this.DataGridView != null && (this.DataGridView.VirtualMode || this.DataGridView.DataSource != null) && this.ColumnIndex >= 0 && intRowIndex >= 0)
        strErrorText = this.DataGridView.OnCellErrorTextNeeded(this.ColumnIndex, intRowIndex, strErrorText);
      return strErrorText;
    }

    /// <summary>Calculates the preferred size with constraints, in pixels, of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
    /// <param name="strText">The text to be measured.</param>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    protected virtual Size GetPreferredSize(
      string strText,
      DataGridViewCellStyle objCellStyle,
      Size objConstraintSize)
    {
      Font objFont = (Font) null;
      int num1 = 3;
      int num2 = 4;
      bool flag = false;
      if (objCellStyle != null)
      {
        Padding padding = objCellStyle.Padding;
        num1 += padding.Horizontal;
        num2 += padding.Vertical;
        objFont = objCellStyle.Font;
        flag = this.HasWrapMode(objCellStyle);
      }
      Size empty = Size.Empty;
      int width = -1;
      if (objConstraintSize.Width > 0)
        width = objConstraintSize.Width;
      else if (this.OwningColumn != null)
        width = this.OwningColumn.Thickness;
      if (flag)
      {
        Size stringMeasurements = CommonUtils.GetStringMeasurements(strText, objFont, width - num1);
        return new Size(width, stringMeasurements.Height + num2);
      }
      Size stringMeasurements1 = CommonUtils.GetStringMeasurements(strText, objFont, true);
      return new Size(stringMeasurements1.Width + num1, stringMeasurements1.Height + num2);
    }

    /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
    /// <param name="strText">The text to be measured.</param>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    protected virtual Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
    {
      Size empty = Size.Empty;
      int num = -1;
      if (this.OwningColumn != null)
        num = this.OwningColumn.Thickness;
      empty.Width = num;
      return this.GetPreferredSize(strText, objCellStyle, empty);
    }

    /// <summary>
    /// Determines whether [has wrap mode] [the specified obj cell style].
    /// </summary>
    /// <param name="objCellStyle">The obj cell style.</param>
    /// <returns>
    ///   <c>true</c> if [has wrap mode] [the specified obj cell style]; otherwise, <c>false</c>.
    /// </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected virtual bool HasWrapMode(DataGridViewCellStyle objCellStyle) => objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True;

    /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
    /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
    /// <param name="intRowIndex">The zero-based row index of the cell.</param>
    protected virtual Size GetPreferredSize(
      Graphics objGraphics,
      DataGridViewCellStyle objCellStyle,
      int intRowIndex,
      Size objConstraintSize)
    {
      return this.GetPreferredSize(this.GetFormattedValue(intRowIndex, ref objCellStyle, DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize) as string, objCellStyle, objConstraintSize);
    }

    internal Size GetPreferredSize(int intRowIndex) => this.DataGridView == null ? new Size(-1, -1) : this.GetPreferredSize(this.DataGridView.CachedGraphics, this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false), intRowIndex, Size.Empty);

    internal int GetPreferredHeight(int intRowIndex, int intWidth) => this.DataGridView == null ? -1 : this.GetPreferredSize(this.DataGridView.CachedGraphics, this.GetInheritedStyle((DataGridViewCellStyle) null, intRowIndex, false), intRowIndex, new Size(intWidth, 0)).Height;

    /// <summary>Gets a value indicating whether [support edit mode].</summary>
    /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
    protected virtual bool SupportEditMode => false;

    /// <summary>
    /// Gets a value indicating whether [support active mode]. Whethre this cell would be redrawn with defferent skin.
    /// </summary>
    /// <value><c>true</c> if [support active mode]; otherwise, <c>false</c>.</value>
    protected virtual bool SupportActiveMode => false;

    /// <summary>Gets the value type converter.</summary>
    /// <value>The value type converter.</value>
    private TypeConverter ValueTypeConverter
    {
      get
      {
        TypeConverter valueTypeConverter = (TypeConverter) null;
        if (this.OwningColumn != null)
          valueTypeConverter = this.OwningColumn.BoundColumnConverter;
        if (valueTypeConverter != null || this.ValueType == (Type) null)
          return valueTypeConverter;
        return this.DataGridView != null ? this.DataGridView.GetCachedTypeConverter(this.ValueType) : TypeDescriptor.GetConverter(this.ValueType);
      }
    }

    /// <summary>Gets the formatted value type converter.</summary>
    /// <value>The formatted value type converter.</value>
    private TypeConverter FormattedValueTypeConverter
    {
      get
      {
        TypeConverter valueTypeConverter = (TypeConverter) null;
        if (this.FormattedValueType == (Type) null)
          return valueTypeConverter;
        return this.DataGridView != null ? this.DataGridView.GetCachedTypeConverter(this.FormattedValueType) : TypeDescriptor.GetConverter(this.FormattedValueType);
      }
    }

    /// <summary>Gets or sets the flags.</summary>
    /// <value>The flags.</value>
    private byte Flags
    {
      get => this.mobjFlags;
      set => this.mobjFlags = value;
    }

    /// <summary>
    /// 
    /// </summary>
    internal virtual string TypeName
    {
      get
      {
        if (this.DataGridView != null)
        {
          DataGridViewColumn column = this.DataGridView.Columns[this.ColumnIndex];
          if (column != null)
            return column.TypeNameInternal;
        }
        return string.Empty;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    protected override string MemberID => "D" + (object) (this.DataGridView.ColumnCount * (this.OwningRow.IsFilterRow ? 0 : this.RowIndex + (this.DataGridView.ShowFilterRow ? 1 : 0)) + this.ColumnIndex);

    /// <summary>Gets the column index for this cell. </summary>
    /// <returns>The index of the column that contains the cell; -1 if the cell is not contained within a column.</returns>
    /// <filterpriority>1</filterpriority>
    public int ColumnIndex
    {
      get
      {
        DataGridViewColumn owningColumn = this.OwningColumn;
        return owningColumn == null ? -1 : owningColumn.Index;
      }
    }

    /// <summary>Gets the default value for a cell in the row for new records.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing the default value.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual object DefaultNewRowValue => (object) null;

    /// <summary>Gets a value that indicates whether the cell is currently displayed on-screen. </summary>
    /// <returns>true if the cell is on-screen or partially on-screen; otherwise, false.</returns>
    [Browsable(false)]
    public virtual bool Displayed => this.DataGridView != null && this.DataGridView != null && this.RowIndex >= 0 && this.ColumnIndex >= 0 && this.OwningColumn.Displayed && this.OwningRow.Displayed;

    /// <summary>Gets the current, formatted value of the cell, regardless of whether the cell is in edit mode and the value has not been committed. </summary>
    /// <returns>The current, formatted value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
    /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell. </exception>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public object EditedFormattedValue
    {
      get
      {
        if (this.DataGridView == null)
          return (object) null;
        DataGridViewCellStyle inheritedStyle = this.GetInheritedStyle((DataGridViewCellStyle) null, this.RowIndex, false);
        return this.GetEditedFormattedValue(this.GetValue(this.RowIndex), this.RowIndex, ref inheritedStyle, DataGridViewDataErrorContexts.Formatting);
      }
    }

    /// <summary>Gets the type of the cell's hosted editing control. </summary>
    /// <returns>A <see cref="T:System.Type"></see> representing the <see cref="T:System.Windows.Forms.DataGridViewTextBoxEditingControl"></see> type.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public virtual Type EditType => typeof (DataGridViewTextBoxEditingControl);

    /// <summary>Gets or sets the text describing an error condition associated with the cell. </summary>
    /// <returns>The text that describes an error condition associated with the cell.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public string ErrorText
    {
      get => this.GetErrorText(this.RowIndex);
      set => this.ErrorTextInternal = value;
    }

    private string ErrorTextInternal
    {
      get => this.mobjErrorText != null ? (string) this.mobjErrorText : string.Empty;
      set
      {
        string errorTextInternal = this.ErrorTextInternal;
        if (!CommonUtils.IsNullOrEmpty(value) || this.mobjErrorText != null)
          this.mobjErrorText = (object) value;
        if (this.DataGridView == null || errorTextInternal.Equals(this.ErrorTextInternal))
          return;
        this.DataGridView.OnCellErrorTextChanged(this);
      }
    }

    /// <summary>Gets the value of the cell as formatted for display.</summary>
    /// <returns>The formatted value of the cell or null if the cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
    /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public object FormattedValue
    {
      get
      {
        if (this.DataGridView == null)
          return (object) null;
        DataGridViewCellStyle inheritedStyle = this.GetInheritedStyle((DataGridViewCellStyle) null, this.RowIndex, false);
        return this.GetFormattedValue(this.RowIndex, ref inheritedStyle, DataGridViewDataErrorContexts.Formatting);
      }
    }

    /// <summary>Gets the type of the formatted value associated with the cell. </summary>
    /// <returns>A <see cref="T:System.Type"></see> representing the type of the cell's formatted value.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual Type FormattedValueType => this.ValueType;

    /// <summary>Gets a value indicating whether the cell is frozen. </summary>
    /// <returns>true if the cell is frozen; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual bool Frozen
    {
      get
      {
        DataGridViewRow owningRow = this.OwningRow;
        return this.DataGridView != null && this.RowIndex >= 0 && this.ColumnIndex >= 0 ? this.OwningColumn.Frozen && owningRow.Frozen : owningRow != null && (owningRow.DataGridView == null || this.RowIndex >= 0) && owningRow.Frozen;
      }
    }

    /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property has been set.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property has been set; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public bool HasStyle => this.mobjStyle != null;

    /// <summary>Gets the current state of the cell as inherited from the state of its row and column.</summary>
    /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and the value of its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> property is -1.</exception>
    /// <exception cref="T:System.ArgumentException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and the value of its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> property is not -1.</exception>
    [Browsable(false)]
    public DataGridViewElementStates InheritedState => this.GetInheritedState(this.RowIndex);

    /// <summary>Gets the style currently applied to the cell. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> currently applied to the cell.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
    /// <exception cref="T:System.InvalidOperationException">The cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or- <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    [Browsable(false)]
    public DataGridViewCellStyle InheritedStyle => this.GetInheritedStyleInternal(this.RowIndex);

    /// <summary>Gets a value indicating whether this cell is currently being edited.</summary>
    /// <returns>true if the cell is in edit mode; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The row containing the cell is a shared row.</exception>
    [Browsable(false)]
    public bool IsInEditMode
    {
      get
      {
        if (this.DataGridView == null)
          return false;
        if (this.RowIndex == -1)
          throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
        Point currentCellAddress = this.DataGridView.CurrentCellAddress;
        return currentCellAddress.X != -1 && currentCellAddress.X == this.ColumnIndex && currentCellAddress.Y == this.RowIndex && this.DataGridView.IsCurrentCellInEditMode;
      }
    }

    /// <summary>Gets the column that contains this cell.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> that contains the cell, or null if the cell is not in a column.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public DataGridViewColumn OwningColumn => this.mobjOwningColumn;

    /// <summary>Sets the owning column internal.</summary>
    /// <value>The owning column internal.</value>
    internal DataGridViewColumn OwningColumnInternal
    {
      set => this.mobjOwningColumn = value;
    }

    /// <summary>Gets the row that contains this cell. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that contains the cell, or null if the cell is not in a row.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public DataGridViewRow OwningRow => this.mobjOwningRow;

    /// <summary>Gets or sets the formatted cell style.</summary>
    /// <value>The formatted cell style.</value>
    protected DataGridViewCellStyle FormattedCellStyle => this.mobjFormattedCellStyle;

    /// <summary>Sets the owning row internal.</summary>
    /// <value>The owning row internal.</value>
    internal DataGridViewRow OwningRowInternal
    {
      set => this.mobjOwningRow = value;
    }

    /// <summary>Gets the size, in pixels, of a rectangular area into which the cell can fit. </summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> containing the height and width, in pixels.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public Size PreferredSize => this.GetPreferredSize(this.RowIndex);

    /// <summary>Gets or sets a value indicating whether the cell's data can be edited. </summary>
    /// <returns>true if the cell's data can be edited; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">There is no owning row when setting this property. -or-The owning row is shared when setting this property.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool ReadOnly
    {
      get
      {
        if ((this.State & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
          return true;
        DataGridViewRow owningRow = this.OwningRow;
        if (owningRow != null && (owningRow.DataGridView == null || this.RowIndex >= 0) && owningRow.ReadOnly)
          return true;
        return this.DataGridView != null && this.RowIndex >= 0 && this.ColumnIndex >= 0 && this.OwningColumn.ReadOnly;
      }
      set
      {
        DataGridViewRow owningRow = this.OwningRow;
        if (this.DataGridView != null)
        {
          if (this.RowIndex == -1)
            throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
          if (value != this.ReadOnly && !this.DataGridView.ReadOnly)
          {
            this.DataGridView.OnDataGridViewElementStateChanging((DataGridViewElement) this, -1, DataGridViewElementStates.ReadOnly);
            this.DataGridView.SetReadOnlyCellCore(this.ColumnIndex, this.RowIndex, value);
            this.UpdateParams(AttributeType.Visual);
          }
        }
        else if (owningRow == null)
        {
          if (value != this.ReadOnly)
            throw new InvalidOperationException(SR.GetString("DataGridViewCell_CannotSetReadOnlyState"));
        }
        else
          owningRow.SetReadOnlyCellCore(this, value);
        this.ElementReadOnly = value ? DataGridViewElement.ElementReadOnlyType.True : DataGridViewElement.ElementReadOnlyType.False;
      }
    }

    /// <summary>Sets a value indicating whether [read only internal].</summary>
    /// <value><c>true</c> if [read only internal]; otherwise, <c>false</c>.</value>
    internal bool ReadOnlyInternal
    {
      set
      {
        if (value)
          this.StateInternal = this.State | DataGridViewElementStates.ReadOnly;
        else
          this.StateInternal = this.State & ~DataGridViewElementStates.ReadOnly;
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnDataGridViewElementStateChanged((DataGridViewElement) this, -1, DataGridViewElementStates.ReadOnly);
      }
    }

    /// <summary>Gets the location.</summary>
    /// <value>The location.</value>
    protected internal override Point Location
    {
      get
      {
        Point empty = Point.Empty;
        Point location;
        if (this.OwningRow != null)
        {
          ref Point local = ref empty;
          location = this.OwningRow.Location;
          int y = location.Y;
          local.Y = y;
        }
        if (this.OwningColumn != null)
        {
          ref Point local = ref empty;
          location = this.OwningColumn.Location;
          int x = location.X;
          local.X = x;
        }
        return empty;
      }
    }

    /// <summary>Gets a value indicating whether the cell can be resized. </summary>
    /// <returns>true if the cell can be resized; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual bool Resizable
    {
      get
      {
        DataGridViewRow owningRow = this.OwningRow;
        if (owningRow != null && (owningRow.DataGridView == null || this.RowIndex >= 0) && owningRow.Resizable == DataGridViewTriState.True)
          return true;
        return this.DataGridView != null && this.RowIndex >= 0 && this.ColumnIndex >= 0 && this.OwningColumn.Resizable == DataGridViewTriState.True;
      }
    }

    /// <summary>Gets the index of the cell's parent row. </summary>
    /// <returns>The index of the row that contains the cell; -1 if there is no owning row.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public int RowIndex
    {
      get
      {
        DataGridViewRow owningRow = this.OwningRow;
        return owningRow == null ? -1 : owningRow.Index;
      }
    }

    /// <summary>Gets or sets a value indicating whether the cell has been selected. </summary>
    /// <returns>true if the cell has been selected; otherwise, false.</returns>
    /// <exception cref="T:System.InvalidOperationException">There is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when setting this property. -or-The owning row is shared when setting this property.</exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public virtual bool Selected
    {
      get
      {
        if ((this.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
          return true;
        DataGridViewRow owningRow = this.OwningRow;
        if (owningRow != null && (owningRow.DataGridView == null || this.RowIndex >= 0) && owningRow.Selected)
          return true;
        return this.DataGridView != null && this.RowIndex >= 0 && this.ColumnIndex >= 0 && this.OwningColumn.Selected;
      }
      set
      {
        if (this.DataGridView != null)
        {
          if (this.RowIndex == -1)
            throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
          this.DataGridView.SetSelectedCellCoreInternal(this.ColumnIndex, this.RowIndex, value);
        }
        else if (value)
          throw new InvalidOperationException(SR.GetString("DataGridViewCell_CannotSetSelectedState"));
      }
    }

    internal bool SelectedInternal
    {
      set
      {
        if (value)
          this.StateInternal = this.State | DataGridViewElementStates.Selected;
        else
          this.StateInternal = this.State & ~DataGridViewElementStates.Selected;
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnDataGridViewElementStateChanged((DataGridViewElement) this, -1, DataGridViewElementStates.Selected);
      }
    }

    internal bool HasValue => this.mojValue != null;

    internal bool HasToolTipText => this.mobjToolTipText != null;

    /// <summary>Gets the size of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> set to the owning row's height and the owning column's width. </returns>
    /// <exception cref="T:System.InvalidOperationException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public Size Size => this.GetSize(this.RowIndex);

    /// <summary>Gets or sets the style for the cell. </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(true)]
    public DataGridViewCellStyle Style
    {
      get
      {
        if (this.mobjStyle == null)
        {
          this.mobjStyle = new DataGridViewCellStyle();
          this.mobjStyle.AddScope(this.DataGridView, DataGridViewCellStyleScopes.Cell);
        }
        return this.mobjStyle;
      }
      set
      {
        DataGridViewCellStyle gridViewCellStyle = (DataGridViewCellStyle) null;
        if (this.HasStyle)
        {
          gridViewCellStyle = this.Style;
          gridViewCellStyle.RemoveScope(DataGridViewCellStyleScopes.Cell);
        }
        if (value != null || this.mobjStyle != null)
        {
          value?.AddScope(this.DataGridView, DataGridViewCellStyleScopes.Cell);
          this.mobjStyle = value;
        }
        if ((gridViewCellStyle == null || value != null) && (gridViewCellStyle != null || value == null) && (gridViewCellStyle == null || value == null || gridViewCellStyle.Equals((object) this.Style)) || this.DataGridView == null)
          return;
        this.DataGridView.OnCellStyleChanged(this);
      }
    }

    /// <summary>Gets or sets the object that contains supplemental data about the cell. </summary>
    /// <returns>An <see cref="T:System.Object"></see> that contains data about the cell. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ControlTagDescr")]
    [TypeConverter(typeof (StringConverter))]
    [SRCategory("CatData")]
    [Localizable(false)]
    [Bindable(true)]
    [DefaultValue(null)]
    public object Tag
    {
      get => this.mobjTag;
      set
      {
        if (value == null && this.mobjTag == null)
          return;
        this.mobjTag = value;
      }
    }

    /// <summary>Gets or sets the ToolTip text associated with this cell.</summary>
    /// <returns>The ToolTip text associated with the cell. The default is <see cref="F:System.String.Empty"></see>. </returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string ToolTipText
    {
      get => this.GetToolTipText(this.RowIndex);
      set => this.ToolTipTextInternal = value;
    }

    /// <summary>Gets or sets the value associated with this cell. </summary>
    /// <returns>Gets or sets the data to be displayed by the cell. The default is null.</returns>
    /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> is outside the valid range of 0 to the number of rows in the control minus 1.</exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public object Value
    {
      get => this.GetValue(this.RowIndex);
      set
      {
        if (this.GetValue(this.RowIndex) == value)
          return;
        this.SetValue(this.RowIndex, value);
        this.Update();
      }
    }

    /// <summary>Gets or sets the editing proposed value.</summary>
    /// <value>The editing proposed value.</value>
    [Browsable(false)]
    internal object EditingProposedValue
    {
      get => this.mobjEditingProposedValue;
      set => this.mobjEditingProposedValue = value;
    }

    protected string ValueText
    {
      get
      {
        object obj = this.Value;
        return obj != null ? obj.ToString() : string.Empty;
      }
    }

    /// <summary>Gets or sets the data type of the values in the cell. </summary>
    /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual Type ValueType
    {
      get
      {
        if (this.mobjValueType == null && this.OwningColumn != null)
          this.mobjValueType = (object) this.OwningColumn.ValueType;
        return this.mobjValueType as Type;
      }
      set
      {
        if (!(value != (Type) null) && this.mobjValueType == null)
          return;
        this.mobjValueType = (object) value;
      }
    }

    /// <summary>Gets a value indicating whether the cell is in a row or column that has been hidden. </summary>
    /// <returns>true if the cell is visible; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    public virtual bool Visible
    {
      get
      {
        DataGridViewRow owningRow = this.OwningRow;
        return this.DataGridView != null && this.RowIndex >= 0 && this.ColumnIndex >= 0 ? this.OwningColumn.Visible && owningRow.Visible : owningRow != null && (owningRow.DataGridView == null || this.RowIndex >= 0) && owningRow.Visible;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance has value type.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has value type; otherwise, <c>false</c>.
    /// </value>
    internal virtual bool HasValueType => this.mobjValueType != null;

    /// <summary>
    /// Gets the bounding rectangle that encloses the cell's content area.
    /// </summary>
    /// <value>The content bounds.</value>
    [Browsable(false)]
    public Rectangle ContentBounds => this.GetContentBounds(this.RowIndex);

    private byte CurrentMouseLocation
    {
      get => (byte) ((uint) this.Flags & 3U);
      set
      {
        this.Flags &= (byte) 252;
        this.Flags |= value;
      }
    }

    private static Bitmap ErrorBitmap
    {
      get
      {
        if (DataGridViewCell.mobjErrorBmp == null)
          DataGridViewCell.mobjErrorBmp = DataGridViewCell.GetBitmap("DataGridViewRow.error.bmp");
        return DataGridViewCell.mobjErrorBmp;
      }
    }

    /// <summary>Gets the bounds of the error icon for the cell.</summary>
    /// <value>The error icon bounds.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public Rectangle ErrorIconBounds => this.GetErrorIconBounds(this.RowIndex);

    internal bool HasErrorText => this.mobjErrorText != null;

    internal Rectangle StdBorderWidths => this.DataGridView != null ? this.BorderWidths(this.AdjustCellBorderStyle(this.DataGridView.AdvancedCellBorderStyle, new DataGridViewAdvancedBorderStyle(), false, false, false, false)) : Rectangle.Empty;

    private string ToolTipTextInternal
    {
      get => this.mobjToolTipText != null ? (string) this.mobjToolTipText : string.Empty;
      set
      {
        if (CommonUtils.IsNullOrEmpty(value) && this.mobjToolTipText == null)
          return;
        this.mobjToolTipText = (object) value;
      }
    }

    /// <summary>Gets or sets the shortcut menu associated with the cell. </summary>
    /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the cell.</returns>
    [DefaultValue(null)]
    public virtual ContextMenu ContextMenu
    {
      get => this.GetContextMenu(this.RowIndex);
      set => this.ContextMenuInternal = value;
    }

    /// <summary>Gets or sets the context menu strip.</summary>
    /// <value>The context menu strip.</value>
    [DefaultValue(null)]
    public virtual ContextMenuStrip ContextMenuStrip
    {
      get => this.GetContextMenuStrip(this.RowIndex);
      set => this.ContextMenuStripInternal = value;
    }

    /// <summary>Gets or sets the context menu strip internal.</summary>
    /// <value>The context menu strip internal.</value>
    internal ContextMenuStrip ContextMenuStripInternal
    {
      get => this.mobjCellContextMenuStrip;
      set
      {
        if (this.mobjCellContextMenuStrip == value)
          return;
        EventHandler eventHandler = new EventHandler(this.DetachContextMenuStrip);
        if (this.mobjCellContextMenuStrip != null)
          this.mobjCellContextMenuStrip.Disposed -= eventHandler;
        this.mobjCellContextMenuStrip = value;
        if (value != null)
          value.Disposed += eventHandler;
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnCellContextMenuStripChanged(this);
      }
    }

    /// <summary>Gets or sets the context menu internal.</summary>
    /// <value>The context menu internal.</value>
    private ContextMenu ContextMenuInternal
    {
      get => this.mobjCellContextMenu;
      set
      {
        if (this.mobjCellContextMenu == value)
          return;
        EventHandler eventHandler = new EventHandler(this.DetachContextMenu);
        if (this.mobjCellContextMenu != null)
          this.mobjCellContextMenu.Disposed -= eventHandler;
        this.mobjCellContextMenu = value;
        if (value != null)
          value.Disposed += eventHandler;
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnCellContextMenuChanged(this);
      }
    }

    /// <summary>Gets the cell's panel.</summary>
    /// <value>The panel.</value>
    public DataGridViewCellPanel Panel
    {
      get
      {
        if (this.mobjPanel == null)
        {
          this.mobjPanel = this.DataGridView == null ? new DataGridViewCellPanel(this) : this.DataGridView.CreateCellPanel(this);
          this.mobjPanel.CreateControl();
        }
        return this.mobjPanel;
      }
      internal set => this.mobjPanel = value;
    }

    /// <summary>
    /// Gets a value indicating whether this instance has panel.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance has panel; otherwise, <c>false</c>.
    /// </value>
    protected bool HasPanel => this.mobjPanel != null;

    /// <summary>Gets or sets the coll span.</summary>
    /// <value>The coll span.</value>
    public virtual int Colspan
    {
      get => this.Panel.Colspan;
      set => this.Panel.Colspan = value;
    }

    /// <summary>Gets or sets the row span.</summary>
    /// <value>The row span.</value>
    public virtual int Rowspan
    {
      get => this.Panel.Rowspan;
      set => this.Panel.Rowspan = value;
    }

    /// <summary>Gets the skin of the current control.</summary>
    /// <value>The skin of the current control.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    protected ControlSkin Skin
    {
      get
      {
        if (this.mobjSkin == null)
          this.mobjSkin = (ControlSkin) SkinFactory.GetSkin((ISkinable) this);
        return this.mobjSkin;
      }
    }

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    string ISkinable.Theme => this.DataGridView != null && this.DataGridView.Context != null ? this.DataGridView.Context.CurrentTheme : string.Empty;
  }
}

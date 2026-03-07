// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewTextBoxCell
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

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Displays editable text information in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewTextBoxCellSkin))]
  [Serializable]
  public class DataGridViewTextBoxCell : DataGridViewCell
  {
    private static Type mobjDefaultFormattedValueType = typeof (string);
    private static Type mobjDefaultValueType = typeof (object);
    private static Type mobjCellType = typeof (DataGridViewTextBoxCell);
    private int mintTextBoxCellMaxInputLength = (int) short.MaxValue;
    private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginLeft = 0;
    private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginRight = 0;
    private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetLeft = 3;
    private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetRight = 4;
    private const byte DATAGRIDVIEWTEXTBOXCELL_ignoreNextMouseClick = 1;
    private const int DATAGRIDVIEWTEXTBOXCELL_maxInputLength = 32767;
    private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginBottom = 1;
    private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithoutWrapping = 2;
    private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithWrapping = 1;
    private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetBottom = 1;
    private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetTop = 2;

    /// <summary>Determines if edit mode should be started based on the given key.</summary>
    /// <returns>true if edit mode should be started; otherwise, false. </returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
    /// <filterpriority>1</filterpriority>
    public override bool KeyEntersEditMode(KeyEventArgs e) => false;

    /// <summary>Called by <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the selection cursor moves onto a cell.</summary>
    /// <param name="blnThroughMouseClick">true if the cell was entered as a result of a mouse click; otherwise, false.</param>
    /// <param name="intRowIndex">The index of the row entered by the mouse.</param>
    protected override void OnEnter(int intRowIndex, bool blnThroughMouseClick)
    {
    }

    /// <summary>Called by the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the mouse leaves a cell.</summary>
    /// <param name="blnThroughMouseClick">true if the cell was left as a result of a mouse click; otherwise, false.</param>
    /// <param name="intRowIndex">The index of the row the mouse has left.</param>
    protected override void OnLeave(int intRowIndex, bool blnThroughMouseClick)
    {
    }

    /// <summary>Called by <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the mouse leaves a cell.</summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
    }

    /// <summary>Ownses the editing text box.</summary>
    /// <param name="intRowIndex">Index of the row.</param>
    /// <returns></returns>
    private bool OwnsEditingTextBox(int intRowIndex) => false;

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    /// <summary>Gets the key event captures.</summary>
    /// <returns></returns>
    protected override KeyCaptures GetKeyEventCaptures() => base.GetKeyEventCaptures() | KeyCaptures.RightKeyCapture | KeyCaptures.LeftKeyCapture | KeyCaptures.EndKeyCapture | KeyCaptures.HomeKeyCapture | KeyCaptures.BackspaceKeyCapture | KeyCaptures.DeleteKeyCapture;

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      if (!(objEvent.Type == "ValueChange") || this.ReadOnly)
        return;
      this.SetValue((object) CommonUtils.DecodeText(objEvent["TX"]), true);
    }

    /// <summary>Renders the cell text/value.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objFormatedValue">The formated value.</param>
    protected override void RenderCellValue(
      IContext objContext,
      IAttributeWriter objWriter,
      object objFormatedValue)
    {
      base.RenderCellValue(objContext, objWriter, objFormatedValue);
      if (objFormatedValue == null || !(objFormatedValue.ToString() != string.Empty))
        return;
      objWriter.WriteAttributeText("VLB", objFormatedValue.ToString());
    }

    /// <summary>
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnRenderOwner)
    {
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      if (this.MaxInputLength == (int) short.MaxValue)
        return;
      objWriter.WriteAttributeString("MH", this.MaxInputLength.ToString());
    }

    /// <summary>Renders the cell style attributes.</summary>
    /// <param name="objWriter">The writer.</param>
    /// <param name="objCellStyle">The cell style.</param>
    protected override void RenderCellStyleAttributes(
      IAttributeWriter objWriter,
      DataGridViewCellStyle objCellStyle)
    {
      base.RenderCellStyleAttributes(objWriter, objCellStyle);
      if (objCellStyle == null)
        return;
      objWriter.WriteAttributeString("TA", objCellStyle.Alignment.ToString());
    }

    /// <summary>
    /// Calculates the preferred size, in pixels, of the cell.
    /// </summary>
    /// <param name="strText">The text to be measured.</param>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
    /// </returns>
    protected override Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
    {
      if (string.IsNullOrEmpty(strText))
        strText = " ";
      return base.GetPreferredSize(strText, objCellStyle);
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewTextBoxCell objTextBoxCell = !(type == DataGridViewTextBoxCell.mobjCellType) ? (DataGridViewTextBoxCell) Activator.CreateInstance(type) : new DataGridViewTextBoxCell();
      this.CloneInternal(objTextBoxCell);
      return (object) objTextBoxCell;
    }

    /// <summary>Clones TextBox Cell</summary>
    /// <param name="objTextBoxCell">The obj text box cell.</param>
    protected void CloneInternal(DataGridViewTextBoxCell objTextBoxCell)
    {
      this.CloneInternal((DataGridViewCell) objTextBoxCell);
      objTextBoxCell.MaxInputLength = this.MaxInputLength;
    }

    /// <summary>
    /// Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
    /// </summary>
    /// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public override void DetachEditingControl()
    {
    }

    /// <summary>Attaches and initializes the hosted editing control.</summary>
    /// <param name="objInitialFormattedValue">The initial value to be displayed in the control.</param>
    /// <param name="intRowIndex">The index of the row being edited.</param>
    /// <param name="objDataGridViewCellStyle">A cell style that is used to determine the appearance of the hosted control.</param>
    /// <filterpriority>1</filterpriority>
    public override void InitializeEditingControl(
      int intRowIndex,
      object objInitialFormattedValue,
      DataGridViewCellStyle objDataGridViewCellStyle)
    {
    }

    /// <summary>
    /// Sets the location and size of the editing control hosted by a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
    /// </summary>
    /// <param name="blnSetLocation">true to have the control placed as specified by the other arguments; false to allow the control to place itself.</param>
    /// <param name="blnSetSize">true to specify the size; false to allow the control to size itself.</param>
    /// <param name="objCellBounds">A <see cref="T:System.Drawing.Rectangle"></see> that defines the cell bounds.</param>
    /// <param name="objCellClip">The area that will be used to paint the editing control.</param>
    /// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell being edited.</param>
    /// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false.</param>
    /// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false.</param>
    /// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false.</param>
    /// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false.</param>
    /// <exception cref="T:System.InvalidOperationException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
    public override void PositionEditingControl(
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
    }

    /// <summary>Returns a string that describes the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => "DataGridViewTextBoxCell { ColumnIndex=" + this.ColumnIndex.ToString() + ", RowIndex=" + this.RowIndex.ToString() + " }";

    /// <summary>Gets a value indicating whether [support edit mode].</summary>
    /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
    protected override bool SupportEditMode => true;

    /// <summary>
    /// Gets a value indicating whether [support active mode]. Whethre this cell would be redrawn with defferent skin.
    /// </summary>
    /// <value><c>true</c> if [support active mode]; otherwise, <c>false</c>.</value>
    protected override bool SupportActiveMode => true;

    /// <summary>Gets the type of the formatted value associated with the cell.</summary>
    /// <returns>A <see cref="T:System.Type"></see> representing the <see cref="T:System.String"></see> type in all cases.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type FormattedValueType => DataGridViewTextBoxCell.mobjDefaultFormattedValueType;

    /// <summary>Gets or sets the maximum number of characters that can be entered into the text box.</summary>
    /// <returns>The maximum number of characters that can be entered into the text box; the default value is 32767.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 0.</exception>
    [DefaultValue(32767)]
    public virtual int MaxInputLength
    {
      get => this.mintTextBoxCellMaxInputLength;
      set => this.mintTextBoxCellMaxInputLength = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof (MaxInputLength), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (MaxInputLength), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
    }

    /// <summary>Gets or sets the data type of the values in the cell.</summary>
    /// <value></value>
    /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
    public override Type ValueType
    {
      get
      {
        Type valueType = base.ValueType;
        return valueType != (Type) null ? valueType : DataGridViewTextBoxCell.mobjDefaultValueType;
      }
    }
  }
}

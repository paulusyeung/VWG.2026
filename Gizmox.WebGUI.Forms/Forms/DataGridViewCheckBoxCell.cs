// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Displays a check box user interface (UI) to use in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewCheckBoxCellSkin))]
  [Serializable]
  public class DataGridViewCheckBoxCell : DataGridViewCell, IDataGridViewEditingCell
  {
    private byte mobjFlags;
    private static Type mobjDefaultBooleanType;
    private static Type mobjefaultCheckStateType = typeof (CheckState);
    private static Type mobjCellType;
    private const byte DATAGRIDVIEWCHECKBOXCELL_checked = 16;
    private const byte DATAGRIDVIEWCHECKBOXCELL_indeterminate = 32;
    private const byte DATAGRIDVIEWCHECKBOXCELL_margin = 2;
    private const byte DATAGRIDVIEWCHECKBOXCELL_threeState = 1;
    private const byte DATAGRIDVIEWCHECKBOXCELL_valueChanged = 2;

    /// <summary>
    /// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell" /> class.
    /// </summary>
    static DataGridViewCheckBoxCell()
    {
      DataGridViewCheckBoxCell.mobjDefaultBooleanType = typeof (bool);
      DataGridViewCheckBoxCell.mobjCellType = typeof (DataGridViewCheckBoxCell);
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> class to its default state.</summary>
    public DataGridViewCheckBoxCell()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> class, enabling binary or ternary state.</summary>
    /// <param name="blnThreeState">true to enable ternary state; false to enable binary state.</param>
    public DataGridViewCheckBoxCell(bool blnThreeState)
      : this()
    {
    }

    /// <summary>Called when the cell's contents are clicked.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
    protected override void OnContentClick(DataGridViewCellEventArgs e)
    {
    }

    /// <summary>Called when the cell's contents are double-clicked.</summary>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
    protected override void OnContentDoubleClick(DataGridViewCellEventArgs e)
    {
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      criticalEventsData.Set("VC");
      return criticalEventsData;
    }

    /// <summary>Fires the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    protected internal override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      if (!(objEvent.Type == "ValueChange"))
        return;
      string str = objEvent["C"];
      if (string.IsNullOrEmpty(str))
        return;
      object objValue = (object) null;
      if (this.ThreeState)
      {
        switch (str)
        {
          case "0":
            objValue = (object) CheckState.Unchecked;
            break;
          case "1":
            objValue = (object) CheckState.Checked;
            break;
          case "2":
            objValue = (object) CheckState.Indeterminate;
            break;
        }
      }
      else
      {
        switch (str)
        {
          case "0":
            objValue = (object) false;
            break;
          case "1":
          case "2":
            objValue = (object) true;
            break;
        }
      }
      this.SetValue(objValue, true);
    }

    private bool CommonContentClickUnsharesRow(DataGridViewCellEventArgs e) => false;

    /// <summary>Indicates whether the row containing the cell will be unshared when the cell content is clicked.</summary>
    /// <returns>true if the cell is in edit mode; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains data about the mouse click.</param>
    protected override bool ContentClickUnsharesRow(DataGridViewCellEventArgs e) => false;

    /// <summary>Indicates whether the row containing the cell will be unshared when the cell content is double-clicked.</summary>
    /// <returns>true if the cell is in edit mode; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains data about the double-click.</param>
    protected override bool ContentDoubleClickUnsharesRow(DataGridViewCellEventArgs e) => false;

    /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
    /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
    /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
    /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
    /// <param name="intRowIndex">The zero-based row index of the cell.</param>
    protected override Size GetPreferredSize(
      Graphics objGraphics,
      DataGridViewCellStyle objCellStyle,
      int intRowIndex,
      Size objConstraintSize)
    {
      Size empty = Size.Empty;
      if (this.Skin is DataGridViewCheckBoxCellSkin skin1)
      {
        if (this.DataGridView != null && SkinFactory.GetSkin((ISkinable) this.DataGridView, typeof (DataGridViewSkin)) is DataGridViewSkin skin)
        {
          empty.Height = skin.CellNormalStyle.Padding.Vertical;
          empty.Width = skin.CellNormalStyle.Padding.Horizontal;
        }
        empty.Height += skin1.CheckBoxImageHeight;
        empty.Width += skin1.CheckBoxImageWidth;
      }
      return empty;
    }

    /// <summary>Gets the formatted value of the cell while it is in edit mode.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing the formatted value of the editing cell. </returns>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that describes the context in which any formatting error occurs. </param>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.</exception>
    public virtual object GetEditingCellFormattedValue(DataGridViewDataErrorContexts enmContext)
    {
      if (this.FormattedValueType == (Type) null)
        throw new InvalidOperationException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
      byte flags = this.Flags;
      if (this.FormattedValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
        return ((int) flags & 16) != 0 ? ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != (DataGridViewDataErrorContexts) 0 ? (object) SR.GetString("DataGridViewCheckBoxCell_ClipboardChecked") : (object) CheckState.Checked) : (((int) flags & 32) != 0 ? ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != (DataGridViewDataErrorContexts) 0 ? (object) SR.GetString("DataGridViewCheckBoxCell_ClipboardIndeterminate") : (object) CheckState.Indeterminate) : ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != (DataGridViewDataErrorContexts) 0 ? (object) SR.GetString("DataGridViewCheckBoxCell_ClipboardUnchecked") : (object) CheckState.Unchecked));
      if (!this.FormattedValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
        return (object) null;
      bool flag = ((uint) flags & 16U) > 0U;
      return (enmContext & DataGridViewDataErrorContexts.ClipboardContent) != (DataGridViewDataErrorContexts) 0 ? (object) SR.GetString(flag ? "DataGridViewCheckBoxCell_ClipboardTrue" : "DataGridViewCheckBoxCell_ClipboardFalse") : (object) flag;
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
      if (objFormatedValue == null)
        return;
      string strValue = string.Empty;
      if (this.ThreeState && objFormatedValue is CheckState checkState)
      {
        switch (checkState)
        {
          case CheckState.Unchecked:
            strValue = "0";
            break;
          case CheckState.Checked:
            strValue = "1";
            break;
          case CheckState.Indeterminate:
            strValue = "2";
            break;
        }
      }
      else if (objFormatedValue is bool)
        strValue = Convert.ToBoolean(objFormatedValue) ? "1" : "0";
      if (string.IsNullOrEmpty(strValue))
        return;
      objWriter.WriteAttributeString("C", strValue);
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
      if (!this.ThreeState)
        return;
      objWriter.WriteAttributeString("MD", "3");
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
      objWriter.WriteAttributeString("CA", objCellStyle.Alignment.ToString());
    }

    /// <summary>Renders the updated attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (!(this.Value is bool))
        return;
      bool flag = (bool) this.Value;
      objWriter.WriteAttributeString("VLB", !flag ? "1" : "0");
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewCheckBoxCell objDataGridViewCell = !(type == DataGridViewCheckBoxCell.mobjCellType) ? (DataGridViewCheckBoxCell) Activator.CreateInstance(type) : new DataGridViewCheckBoxCell();
      this.CloneInternal((DataGridViewCell) objDataGridViewCell);
      objDataGridViewCell.ThreeStateInternal = this.ThreeState;
      objDataGridViewCell.TrueValueInternal = this.TrueValue;
      objDataGridViewCell.FalseValueInternal = this.FalseValue;
      objDataGridViewCell.IndeterminateValueInternal = this.IndeterminateValue;
      objDataGridViewCell.FlatStyleInternal = this.FlatStyle;
      return (object) objDataGridViewCell;
    }

    /// <summary>Gets or sets the flags.</summary>
    /// <value>The flags.</value>
    private byte Flags
    {
      get => this.mobjFlags;
      set => this.mobjFlags = value;
    }

    /// <summary>Gets the formatted value of the cell's data. </summary>
    /// <returns>The value of the cell's data after formatting has been applied or null if the cell is not part of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
    /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
    /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    /// <param name="objValue">The value to be formatted. </param>
    /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
    protected override object GetFormattedValue(
      object objValue,
      int intRowIndex,
      ref DataGridViewCellStyle objCellStyle,
      TypeConverter objValueTypeConverter,
      TypeConverter objFormattedValueTypeConverter,
      DataGridViewDataErrorContexts enmContext)
    {
      if (objValue != null)
      {
        if (this.ThreeState)
        {
          if (objValue.Equals(this.TrueValue) || objValue is 1)
            objValue = (object) CheckState.Checked;
          else if (objValue.Equals(this.FalseValue) || objValue is 0)
            objValue = (object) CheckState.Unchecked;
          else if (objValue.Equals(this.IndeterminateValue) || objValue is 2)
            objValue = (object) CheckState.Indeterminate;
        }
        else if (objValue.Equals(this.TrueValue) || objValue is int num && num != 0)
          objValue = (object) true;
        else if (objValue.Equals(this.FalseValue) || objValue is 0)
          objValue = (object) false;
      }
      object formattedValue = base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
      if (formattedValue == null || (enmContext & DataGridViewDataErrorContexts.ClipboardContent) == (DataGridViewDataErrorContexts) 0)
        return formattedValue;
      switch (formattedValue)
      {
        case bool flag:
          return flag ? (object) SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardChecked" : "DataGridViewCheckBoxCell_ClipboardTrue") : (object) SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardUnchecked" : "DataGridViewCheckBoxCell_ClipboardFalse");
        case CheckState checkState:
          switch (checkState)
          {
            case CheckState.Unchecked:
              return (object) SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardUnchecked" : "DataGridViewCheckBoxCell_ClipboardFalse");
            case CheckState.Checked:
              return (object) SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardChecked" : "DataGridViewCheckBoxCell_ClipboardTrue");
            default:
              return (object) SR.GetString("DataGridViewCheckBoxCell_ClipboardIndeterminate");
          }
        default:
          return formattedValue;
      }
    }

    /// <summary>Converts a value formatted for display to an actual cell value.</summary>
    /// <returns>The cell value.</returns>
    /// <param name="objFormattedValue">The display value of the cell.</param>
    /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> for the display value type, or null to use the default converter.</param>
    /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> for the cell value type, or null to use the default converter.</param>
    /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
    /// <exception cref="T:System.FormatException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.FormattedValueType"></see> property value is null.</exception>
    /// <exception cref="T:System.ArgumentNullException">cellStyle is null.</exception>
    /// <exception cref="T:System.ArgumentException">formattedValue is null.- or -The type of formattedValue does not match the type indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.FormattedValueType"></see> property. </exception>
    public override object ParseFormattedValue(
      object objFormattedValue,
      DataGridViewCellStyle objCellStyle,
      TypeConverter objFormattedValueTypeConverter,
      TypeConverter objValueTypeConverter)
    {
      switch (objFormattedValue)
      {
        case bool flag:
          if (flag)
          {
            if (this.TrueValue != null)
              return this.TrueValue;
            if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
              return (object) true;
            if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
              return (object) CheckState.Checked;
            break;
          }
          if (this.FalseValue != null)
            return this.FalseValue;
          if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
            return (object) false;
          if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
            return (object) CheckState.Unchecked;
          break;
        case CheckState checkState:
          switch (checkState)
          {
            case CheckState.Unchecked:
              if (this.FalseValue != null)
                return this.FalseValue;
              if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
                return (object) false;
              if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                return (object) CheckState.Unchecked;
              break;
            case CheckState.Checked:
              if (this.TrueValue != null)
                return this.TrueValue;
              if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
                return (object) true;
              if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                return (object) CheckState.Checked;
              break;
            case CheckState.Indeterminate:
              if (this.IndeterminateValue != null)
                return this.IndeterminateValue;
              if (this.ValueType != (Type) null && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                return (object) CheckState.Indeterminate;
              break;
          }
          break;
      }
      return base.ParseFormattedValue(objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
    }

    /// <summary>This method is not meaningful for this type.</summary>
    /// <param name="blnSelectAll">This parameter is ignored.</param>
    public virtual void PrepareEditingCellForEdit(bool blnSelectAll)
    {
    }

    private bool SwitchFormattedValue() => false;

    /// <summary>Returns the string representation of the cell.</summary>
    /// <returns>A <see cref="T:System.String"></see> that represents the current cell.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString() => "DataGridViewCheckBoxCell { ColumnIndex=" + this.ColumnIndex.ToString() + ", RowIndex=" + this.RowIndex.ToString() + " }";

    private void UpdateButtonState(ButtonState newButtonState, int intRowIndex)
    {
    }

    /// <summary>Gets a value indicating whether [support edit mode].</summary>
    /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
    protected override bool SupportEditMode => true;

    /// <summary>Gets or sets the formatted value of the control hosted by the cell when it is in edit mode.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing the cell's value.</returns>
    /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.</exception>
    /// <exception cref="T:System.ArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.-or-The assigned value is null or is not of the type indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property.-or- The assigned value is not of type <see cref="T:System.Boolean"></see> nor of type <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see>.</exception>
    public virtual object EditingCellFormattedValue
    {
      get => this.GetEditingCellFormattedValue(DataGridViewDataErrorContexts.Formatting);
      set
      {
        if (this.FormattedValueType == (Type) null)
          throw new ArgumentException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
        if (value == null || !this.FormattedValueType.IsAssignableFrom(value.GetType()))
          throw new ArgumentException(SR.GetString("DataGridViewCheckBoxCell_InvalidValueType"));
        switch (value)
        {
          case CheckState checkState:
            if (checkState == CheckState.Checked)
            {
              this.Flags |= (byte) 16;
              this.Flags &= (byte) 223;
              break;
            }
            if ((CheckState) value == CheckState.Indeterminate)
            {
              this.Flags |= (byte) 32;
              this.Flags &= (byte) 239;
              break;
            }
            this.Flags &= (byte) 239;
            this.Flags &= (byte) 223;
            break;
          case bool flag:
            if (flag)
              this.Flags |= (byte) 16;
            else
              this.Flags &= (byte) 239;
            this.Flags &= (byte) 223;
            break;
          default:
            throw new ArgumentException(SR.GetString("DataGridViewCheckBoxCell_InvalidValueType"));
        }
      }
    }

    /// <summary>Gets or sets a flag indicating that the value has been changed for this cell.</summary>
    /// <returns>true if the cell's value has changed; otherwise, false.</returns>
    public virtual bool EditingCellValueChanged
    {
      get => ((uint) this.Flags & 2U) > 0U;
      set
      {
        if (value)
          this.Flags |= (byte) 2;
        else
          this.Flags &= (byte) 253;
      }
    }

    /// <summary>Gets or sets the underlying value corresponding to a cell value of false.</summary>
    /// <returns>An <see cref="T:System.Object"></see> corresponding to a cell value of false. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    public object FalseValue
    {
      get => (object) null;
      set
      {
      }
    }

    internal object FalseValueInternal
    {
      set
      {
      }
    }

    /// <summary>Gets or sets the flat style appearance of the check box user interface (UI).</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(2)]
    public FlatStyle FlatStyle
    {
      get => FlatStyle.Standard;
      set
      {
      }
    }

    internal FlatStyle FlatStyleInternal
    {
      set
      {
      }
    }

    /// <summary>Gets the type of the cell display value. </summary>
    /// <returns>A <see cref="T:System.Type"></see> representing the display type of the cell.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type FormattedValueType => this.ThreeState ? DataGridViewCheckBoxCell.mobjefaultCheckStateType : DataGridViewCheckBoxCell.mobjDefaultBooleanType;

    /// <summary>Gets or sets the underlying value corresponding to an indeterminate or null cell value.</summary>
    /// <returns>An <see cref="T:System.Object"></see> corresponding to an indeterminate or null cell value. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    public object IndeterminateValue
    {
      get => (object) null;
      set
      {
      }
    }

    internal object IndeterminateValueInternal
    {
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether ternary mode has been enabled for the hosted check box control.</summary>
    /// <returns>true if ternary mode is enabled; false if binary mode is enabled. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    public bool ThreeState
    {
      get => ((uint) this.Flags & 1U) > 0U;
      set
      {
        if (this.ThreeState == value)
          return;
        this.ThreeStateInternal = value;
        if (this.DataGridView == null)
          return;
        if (this.RowIndex != -1)
          this.DataGridView.InvalidateCell((DataGridViewCell) this);
        else
          this.DataGridView.InvalidateColumnInternal(this.ColumnIndex);
      }
    }

    internal bool ThreeStateInternal
    {
      set
      {
        if (this.ThreeState == value)
          return;
        if (value)
          this.Flags |= (byte) 1;
        else
          this.Flags &= (byte) 254;
      }
    }

    /// <summary>Gets or sets the underlying value corresponding to a cell value of true.</summary>
    /// <returns>An <see cref="T:System.Object"></see> corresponding to a cell value of true. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    public object TrueValue
    {
      get => (object) null;
      set
      {
      }
    }

    internal object TrueValueInternal
    {
      set
      {
      }
    }

    /// <summary>Gets the data type of the values in the cell.</summary>
    /// <returns>The <see cref="T:System.Type"></see> of the underlying value of the cell.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type ValueType
    {
      get
      {
        Type valueType = base.ValueType;
        if (valueType != (Type) null)
          return valueType;
        return this.ThreeState ? DataGridViewCheckBoxCell.mobjefaultCheckStateType : DataGridViewCheckBoxCell.mobjDefaultBooleanType;
      }
      set
      {
        base.ValueType = value;
        this.ThreeState = value != (Type) null && DataGridViewCheckBoxCell.mobjefaultCheckStateType.IsAssignableFrom(value);
      }
    }
  }
}

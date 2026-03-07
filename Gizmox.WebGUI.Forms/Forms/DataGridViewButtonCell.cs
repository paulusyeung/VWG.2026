// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewButtonCell
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
  /// <summary>Displays a button-like user interface (UI) for use in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewButtonCellSkin))]
  [Serializable]
  public class DataGridViewButtonCell : DataGridViewCell
  {
    private const byte DATAGRIDVIEWBUTTONCELL_horizontalTextMargin = 2;
    private const byte DATAGRIDVIEWBUTTONCELL_textPadding = 5;
    private const byte DATAGRIDVIEWBUTTONCELL_themeMargin = 100;
    private const byte DATAGRIDVIEWBUTTONCELL_verticalTextMargin = 1;
    private static Type mobjDefaultFormattedValueType;
    private static Type mobjDefaultValueType;
    private static Type mobjCellType;
    private static Rectangle mobjRectangleThemeMargins = new Rectangle(-1, -1, 0, 0);
    private int mintUseColumnTextForButtonValue;

    static DataGridViewButtonCell()
    {
      DataGridViewButtonCell.mobjDefaultFormattedValueType = typeof (string);
      DataGridViewButtonCell.mobjDefaultValueType = typeof (object);
      DataGridViewButtonCell.mobjCellType = typeof (DataGridViewButtonCell);
    }

    /// <summary>Indicates whether a row is unshared if a key is pressed while the focus is on a cell in the row.</summary>
    /// <returns>true if the user pressed the SPACE key without modifier keys; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected override bool KeyDownUnsharesRow(KeyEventArgs e, int intRowIndex) => e.KeyCode == Keys.Space && !e.Alt && !e.Control && !e.Shift;

    /// <summary>Indicates whether a row is unshared when a key is released while the focus is on a cell in the row.</summary>
    /// <returns>true if the user released the SPACE key; otherwise, false.</returns>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    /// <param name="intRowIndex">The index of the cell's parent row. </param>
    protected override bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex) => e.KeyCode == Keys.Space;

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
      objWriter.WriteAttributeText("TX", objFormatedValue.ToString());
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

    /// <summary>Retrieves the text associated with the button.</summary>
    /// <returns>The value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.Text"></see> value of the owning column if <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonCell.UseColumnTextForButtonValue"></see> is true. </returns>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    protected override object GetValue(int intRowIndex) => this.UseColumnTextForButtonValue && this.DataGridView != null && this.DataGridView.NewRowIndex != intRowIndex && this.OwningColumn != null && this.OwningColumn is DataGridViewButtonColumn ? (object) ((DataGridViewButtonColumn) this.OwningColumn).Text : base.GetValue(intRowIndex);

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:System.Windows.Forms.DataGridViewButtonCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewButtonCell objDataGridViewCell = !(type == DataGridViewButtonCell.mobjCellType) ? (DataGridViewButtonCell) Activator.CreateInstance(type) : new DataGridViewButtonCell();
      this.CloneInternal((DataGridViewCell) objDataGridViewCell);
      objDataGridViewCell.UseColumnTextForButtonValueInternal = this.UseColumnTextForButtonValue;
      return (object) objDataGridViewCell;
    }

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
      Size preferredSize = this.GetPreferredSize(Convert.ToString(this.GetValue(intRowIndex)), objCellStyle);
      return new Size(preferredSize.Width + 8, preferredSize.Height + 5);
    }

    /// <summary>Returns the string representation of the cell.</summary>
    /// <returns>A <see cref="T:System.String"></see> that represents the current cell.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString() => "DataGridViewButtonCell { ColumnIndex=" + this.ColumnIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + ", RowIndex=" + this.RowIndex.ToString((IFormatProvider) CultureInfo.CurrentCulture) + " }";

    /// <summary>Gets the type of the cell's hosted editing control.</summary>
    /// <returns>The <see cref="T:System.Type"></see> of the underlying editing control.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type EditType => (Type) null;

    /// <summary>Gets or sets the style determining the button's appearance.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(2)]
    public FlatStyle FlatStyle
    {
      get => FlatStyle.Standard;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the owning column's text will appear on the button displayed by the cell.</summary>
    /// <returns>true if the value of the <see cref="P:System.Windows.Forms.DataGridViewCell.Value"></see> property will automatically match the value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property of the owning column; otherwise, false. The default is false.</returns>
    [DefaultValue(false)]
    public bool UseColumnTextForButtonValue
    {
      get => this.mintUseColumnTextForButtonValue != 0;
      set
      {
        if (value == this.UseColumnTextForButtonValue)
          return;
        this.mintUseColumnTextForButtonValue = value ? 1 : 0;
        this.OnCommonChange();
      }
    }

    internal bool UseColumnTextForButtonValueInternal
    {
      set
      {
        if (value == this.UseColumnTextForButtonValue)
          return;
        this.mintUseColumnTextForButtonValue = value ? 1 : 0;
      }
    }

    /// <summary>
    /// Gets the type of the formatted value associated with the cell.
    /// </summary>
    /// <value></value>
    /// <returns>A <see cref="T:System.Type"></see> representing the type of the cell's formatted value.</returns>
    public override Type FormattedValueType => DataGridViewButtonCell.mobjDefaultFormattedValueType;

    /// <filterpriority>1</filterpriority>
    public override Type ValueType
    {
      get
      {
        Type valueType = base.ValueType;
        return valueType != (Type) null ? valueType : (Type) null;
      }
    }
  }
}

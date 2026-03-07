// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewButtonColumn
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see> objects.</summary>
  /// <filterpriority>2</filterpriority>
  [ToolboxBitmap(typeof (DataGridViewButtonColumn), "DataGridViewButtonColumn.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewButtonColumn : DataGridViewColumn
  {
    private string mstrText;
    private static Type mobjColumnType = typeof (DataGridViewButtonColumn);

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn"></see> class to the default state.</summary>
    public DataGridViewButtonColumn()
      : this(new DataGridViewButtonCell())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn" /> class.
    /// </summary>
    /// <param name="objCellTemplate">The obj cell template.</param>
    protected DataGridViewButtonColumn(DataGridViewButtonCell objCellTemplate)
      : base((DataGridViewCell) objCellTemplate)
    {
      this.DefaultCellStyle = new DataGridViewCellStyle()
      {
        AlignmentInternal = DataGridViewContentAlignment.MiddleCenter
      };
    }

    /// <summary>Gets the name of the type.</summary>
    /// <value>The name of the type.</value>
    protected override string TypeName => "5";

    /// <summary>Creates an exact copy of this column.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    public override object Clone() => base.Clone();

    private bool ShouldSerializeDefaultCellStyle() => false;

    /// <filterpriority>1</filterpriority>
    public override string ToString() => base.ToString();

    /// <summary>Gets or sets the template used to create new cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
    /// <exception cref="T:System.InvalidCastException">The specified value when setting this property could not be cast to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override DataGridViewCell CellTemplate
    {
      get => base.CellTemplate;
      set
      {
        switch (value)
        {
          case null:
          case DataGridViewButtonCell _:
            base.CellTemplate = value;
            break;
          default:
            throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", (object) "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"));
        }
      }
    }

    /// <summary>Gets or sets the column's default cell style.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
    [Browsable(true)]
    public override DataGridViewCellStyle DefaultCellStyle
    {
      get => base.DefaultCellStyle;
      set => base.DefaultCellStyle = value;
    }

    /// <summary>Gets or sets the flat-style appearance of the button cells in the column.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the appearance of the buttons in the column. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_ButtonColumnFlatStyleDescr")]
    [DefaultValue(2)]
    public FlatStyle FlatStyle
    {
      get => FlatStyle.Standard;
      set
      {
      }
    }

    /// <summary>Gets or sets the default text displayed on the button cell.</summary>
    /// <returns>A <see cref="T:System.String"></see> that contains the text. The default is <see cref="F:System.String.Empty"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, the value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ButtonColumnTextDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(null)]
    public string Text
    {
      get => this.mstrText;
      set
      {
        if (string.Equals(value, this.Text))
          return;
        this.mstrText = value;
        if (this.DataGridView == null)
          return;
        if (this.UseColumnTextForButtonValue)
        {
          this.DataGridView.OnColumnCommonChange(this.Index);
        }
        else
        {
          DataGridViewRowCollection rows = this.DataGridView.Rows;
          int count = rows.Count;
          for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
          {
            if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewButtonCell cell && cell.UseColumnTextForButtonValue)
            {
              this.DataGridView.OnColumnCommonChange(this.Index);
              return;
            }
          }
          this.DataGridView.InvalidateColumn(this.Index);
        }
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property value is displayed as the button text for cells in this column.</summary>
    /// <returns>true if the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property value is displayed on buttons in the column; false if the <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value of each cell is displayed on its button. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null.</exception>
    [DefaultValue(false)]
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_ButtonColumnUseColumnTextForButtonValueDescr")]
    public bool UseColumnTextForButtonValue
    {
      get => this.CellTemplate != null ? ((DataGridViewButtonCell) this.CellTemplate).UseColumnTextForButtonValue : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.UseColumnTextForButtonValue == value)
          return;
        ((DataGridViewButtonCell) this.CellTemplate).UseColumnTextForButtonValueInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewButtonCell cell)
            cell.UseColumnTextForButtonValueInternal = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }
  }
}

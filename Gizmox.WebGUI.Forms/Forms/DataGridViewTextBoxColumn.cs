// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see> cells.</summary>
  /// <filterpriority>2</filterpriority>
  [ToolboxBitmap(typeof (DataGridViewTextBoxColumn), "DataGridViewTextBoxColumn.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewTextBoxColumn : DataGridViewColumn
  {
    private const int DATAGRIDVIEWTEXTBOXCOLUMN_maxInputLength = 32767;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn"></see> class to the default state.</summary>
    public DataGridViewTextBoxColumn()
      : this(new DataGridViewTextBoxCell())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn" /> class.
    /// </summary>
    /// <param name="objCellTemplate">The obj cell template.</param>
    protected DataGridViewTextBoxColumn(DataGridViewTextBoxCell objCellTemplate)
      : base((DataGridViewCell) objCellTemplate)
    {
      this.SortMode = DataGridViewColumnSortMode.Automatic;
    }

    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.Append("DataGridViewTextBoxColumn { Name=");
      stringBuilder.Append(this.Name);
      stringBuilder.Append(", Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Gets the name of the type.</summary>
    /// <value>The name of the type.</value>
    protected override string TypeName => "1";

    /// <summary>Gets or sets the template used to model cell appearance.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
    /// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>. </exception>
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
          case DataGridViewTextBoxCell _:
            base.CellTemplate = value;
            break;
          default:
            throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", (object) "Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"));
        }
      }
    }

    /// <summary>Gets or sets the maximum number of characters that can be entered into the text box.</summary>
    /// <returns>The maximum number of characters that can be entered into the text box; the default value is 32767.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn.CellTemplate"></see> property is null.</exception>
    [SRDescription("DataGridView_TextBoxColumnMaxInputLengthDescr")]
    [DefaultValue(32767)]
    [SRCategory("CatBehavior")]
    public int MaxInputLength
    {
      get => this.TextBoxCellTemplate != null ? this.TextBoxCellTemplate.MaxInputLength : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.MaxInputLength == value)
          return;
        this.TextBoxCellTemplate.MaxInputLength = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewTextBoxCell cell)
            cell.MaxInputLength = value;
        }
      }
    }

    /// <summary>Gets or sets the sort mode for the column.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode"></see> that specifies the criteria used to order the rows based on the cell values in a column.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DataGridViewColumnSortMode.Automatic)]
    public new DataGridViewColumnSortMode SortMode
    {
      get => base.SortMode;
      set => base.SortMode = value;
    }

    private DataGridViewTextBoxCell TextBoxCellTemplate => (DataGridViewTextBoxCell) this.CellTemplate;
  }
}

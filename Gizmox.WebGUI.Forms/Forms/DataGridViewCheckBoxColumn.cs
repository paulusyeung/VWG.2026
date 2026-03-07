// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn
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
  /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> objects.</summary>
  /// <filterpriority>2</filterpriority>
  [ToolboxBitmap(typeof (DataGridViewCheckBoxColumn), "DataGridViewCheckBoxColumn.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewCheckBoxColumn : DataGridViewColumn
  {
    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn"></see> class to the default state.</summary>
    public DataGridViewCheckBoxColumn()
      : this(false)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn"></see> and configures it to display check boxes with two or three states. </summary>
    /// <param name="blnThreeState">true to display check boxes with three states; false to display check boxes with two states. </param>
    public DataGridViewCheckBoxColumn(bool blnThreeState)
    {
      int num = blnThreeState ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(num != 0, new DataGridViewCheckBoxCell(num != 0));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn" /> class.
    /// </summary>
    /// <param name="blnThreeState">if set to <c>true</c> [BLN three state].</param>
    /// <param name="objCellTemplate">The obj cell template.</param>
    protected DataGridViewCheckBoxColumn(
      bool blnThreeState,
      DataGridViewCheckBoxCell objCellTemplate)
      : base((DataGridViewCell) objCellTemplate)
    {
      this.DefaultCellStyle = new DataGridViewCellStyle()
      {
        AlignmentInternal = DataGridViewContentAlignment.MiddleCenter,
        NullValue = !blnThreeState ? (object) false : (object) CheckState.Indeterminate
      };
    }

    /// <summary>Gets the name of the type.</summary>
    /// <value>The name of the type.</value>
    protected override string TypeName => "2";

    private bool ShouldSerializeDefaultCellStyle()
    {
      if (this.CellTemplate is DataGridViewCheckBoxCell cellTemplate)
      {
        object obj = !cellTemplate.ThreeState ? (object) false : (object) CheckState.Indeterminate;
        if (!this.HasDefaultCellStyle)
          return false;
        DataGridViewCellStyle defaultCellStyle = this.DefaultCellStyle;
        if (defaultCellStyle.BackColor.IsEmpty)
        {
          Color color = defaultCellStyle.ForeColor;
          if (color.IsEmpty)
          {
            color = defaultCellStyle.SelectionBackColor;
            if (color.IsEmpty)
            {
              color = defaultCellStyle.SelectionForeColor;
              if (color.IsEmpty && defaultCellStyle.Font == null && defaultCellStyle.NullValue.Equals(obj) && defaultCellStyle.IsDataSourceNullValueDefault)
              {
                if (CommonUtils.IsNullOrEmpty(defaultCellStyle.Format) && defaultCellStyle.FormatProvider.Equals((object) CultureInfo.CurrentCulture) && defaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter && defaultCellStyle.WrapMode == DataGridViewTriState.NotSet && defaultCellStyle.Tag == null)
                  return !defaultCellStyle.Padding.Equals((object) Padding.Empty);
              }
            }
          }
        }
      }
      return true;
    }

    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.Append("DataGridViewCheckBoxColumn { Name=");
      stringBuilder.Append(this.Name);
      stringBuilder.Append(", Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Gets or sets the template used to create new cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> instance.</returns>
    /// <exception cref="T:System.InvalidCastException">The property is set to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see>. </exception>
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
          case DataGridViewCheckBoxCell _:
            base.CellTemplate = value;
            break;
          default:
            throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", (object) "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"));
        }
      }
    }

    private DataGridViewCheckBoxCell CheckBoxCellTemplate => (DataGridViewCheckBoxCell) this.CellTemplate;

    /// <summary>Gets or sets the column's default cell style.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
    [SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
    [SRCategory("CatAppearance")]
    [Browsable(true)]
    public override DataGridViewCellStyle DefaultCellStyle
    {
      get => base.DefaultCellStyle;
      set => base.DefaultCellStyle = value;
    }

    /// <summary>Gets or sets the underlying value corresponding to a cell value of false, which appears as an unchecked box.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing a value that the cells in this column will treat as a false value. The default is null.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [TypeConverter(typeof (StringConverter))]
    [SRDescription("DataGridView_CheckBoxColumnFalseValueDescr")]
    [DefaultValue(null)]
    [SRCategory("CatData")]
    public object FalseValue
    {
      get => this.CheckBoxCellTemplate != null ? this.CheckBoxCellTemplate.FalseValue : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.FalseValue == value)
          return;
        this.CheckBoxCellTemplate.FalseValueInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewCheckBoxCell cell)
            cell.FalseValueInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>Gets or sets the flat style appearance of the check box cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the appearance of cells in the column. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CheckBoxColumnFlatStyleDescr")]
    [DefaultValue(2)]
    [SRCategory("CatAppearance")]
    public FlatStyle FlatStyle
    {
      get => this.CheckBoxCellTemplate != null ? this.CheckBoxCellTemplate.FlatStyle : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.FlatStyle == value)
          return;
        this.CheckBoxCellTemplate.FlatStyle = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewCheckBoxCell cell)
            cell.FlatStyleInternal = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    /// <summary>Gets or sets the underlying value corresponding to an indeterminate or null cell value, which appears as a disabled checkbox.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing a value that the cells in this column will treat as an indeterminate value. The default is null.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CheckBoxColumnIndeterminateValueDescr")]
    [SRCategory("CatData")]
    [TypeConverter(typeof (StringConverter))]
    [DefaultValue(null)]
    public object IndeterminateValue
    {
      get => this.CheckBoxCellTemplate != null ? this.CheckBoxCellTemplate.IndeterminateValue : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.IndeterminateValue == value)
          return;
        this.CheckBoxCellTemplate.IndeterminateValueInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewCheckBoxCell cell)
            cell.IndeterminateValueInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>Gets or sets a value indicating whether the hosted check box cells will allow three check states rather than two.</summary>
    /// <returns>true if the hosted <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> objects are able to have a third, indeterminate, state; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_CheckBoxColumnThreeStateDescr")]
    public bool ThreeState
    {
      get => this.CheckBoxCellTemplate != null ? this.CheckBoxCellTemplate.ThreeState : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ThreeState == value)
          return;
        this.CheckBoxCellTemplate.ThreeStateInternal = value;
        if (this.DataGridView != null)
        {
          DataGridViewRowCollection rows = this.DataGridView.Rows;
          int count = rows.Count;
          for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
          {
            if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewCheckBoxCell cell)
              cell.ThreeStateInternal = value;
          }
          this.DataGridView.InvalidateColumn(this.Index);
        }
        if (value && this.DefaultCellStyle.NullValue is bool && !(bool) this.DefaultCellStyle.NullValue)
        {
          this.DefaultCellStyle.NullValue = (object) CheckState.Indeterminate;
        }
        else
        {
          if (value || !(this.DefaultCellStyle.NullValue is CheckState) || (CheckState) this.DefaultCellStyle.NullValue != CheckState.Indeterminate)
            return;
          this.DefaultCellStyle.NullValue = (object) false;
        }
      }
    }

    /// <summary>Gets or sets the underlying value corresponding to a cell value of true, which appears as a checked box.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing a value that the cell will treat as a true value. The default is null.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_CheckBoxColumnTrueValueDescr")]
    [SRCategory("CatData")]
    [TypeConverter(typeof (StringConverter))]
    [DefaultValue(null)]
    public object TrueValue
    {
      get => this.CheckBoxCellTemplate != null ? this.CheckBoxCellTemplate.TrueValue : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.TrueValue == value)
          return;
        this.CheckBoxCellTemplate.TrueValueInternal = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewCheckBoxCell cell)
            cell.TrueValueInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }
  }
}

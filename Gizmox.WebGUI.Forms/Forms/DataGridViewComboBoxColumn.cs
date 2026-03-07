// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a column of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> objects.</summary>
  /// <filterpriority>2</filterpriority>
  [ToolboxBitmap(typeof (DataGridViewComboBoxColumn), "DataGridViewComboBoxColumn.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewComboBoxColumn : DataGridViewColumn
  {
    private static Type mobjColumnType = typeof (DataGridViewComboBoxColumn);

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn" /> class.
    /// </summary>
    public DataGridViewComboBoxColumn()
      : this(new DataGridViewComboBoxCell())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn" /> class.
    /// </summary>
    /// <param name="objDataGridViewCellTemplate">The obj data grid view cell template.</param>
    protected DataGridViewComboBoxColumn(
      DataGridViewComboBoxCell objDataGridViewCellTemplate)
      : base((DataGridViewCell) objDataGridViewCellTemplate)
    {
      ((DataGridViewComboBoxCell) base.CellTemplate).TemplateComboBoxColumn = this;
    }

    /// <summary>Gets the name of the type.</summary>
    /// <value>The name of the type.</value>
    protected override string TypeName => "6";

    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewComboBoxColumn objDataGridViewColumn = !(type == DataGridViewComboBoxColumn.mobjColumnType) ? (DataGridViewComboBoxColumn) Activator.CreateInstance(type) : new DataGridViewComboBoxColumn();
      if (objDataGridViewColumn != null)
      {
        this.CloneInternal(objDataGridViewColumn);
        ((DataGridViewComboBoxCell) objDataGridViewColumn.CellTemplate).TemplateComboBoxColumn = objDataGridViewColumn;
      }
      return (object) objDataGridViewColumn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    /// <param name="blnRenderOwner"></param>
    protected override void RenderComponents(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID,
      bool blnRenderOwner)
    {
      base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
      if (this.CellTemplate == null || !(this.CellTemplate is DataGridViewComboBoxCell))
        return;
      ((DataGridViewComboBoxCell) this.CellTemplate).RenderComboboxItems(objContext, objWriter, lngRequestID, blnRenderOwner);
    }

    /// <summary>Gets the property value.</summary>
    /// <param name="objSource">The source.</param>
    /// <param name="strPropertyName">Name of the property.</param>
    /// <param name="strDefaultValue">The default value.</param>
    /// <returns></returns>
    private string GetPropertyValue(
      object objSource,
      string strPropertyName,
      string strDefaultValue)
    {
      string propertyValue = strDefaultValue;
      if (objSource != null && strPropertyName != string.Empty)
      {
        PropertyInfo property = objSource.GetType().GetProperty(strPropertyName);
        if (property != (PropertyInfo) null)
        {
          object obj = property.GetValue(objSource, (object[]) null);
          if (obj != null)
            propertyValue = Convert.ToString(obj);
        }
      }
      return propertyValue;
    }

    internal void OnItemsCollectionChanged()
    {
      if (this.DataGridView == null)
        return;
      DataGridViewRowCollection rows = this.DataGridView.Rows;
      int count = rows.Count;
      object[] array = ((DataGridViewComboBoxCell) this.CellTemplate).Items.InnerArray.ToArray();
      for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
      {
        if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
        {
          cell.Items.ClearInternal();
          cell.Items.AddRangeInternal((ICollection) array);
        }
      }
      this.DataGridView.OnColumnCommonChange(this.Index);
    }

    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.Append("DataGridViewComboBoxColumn { Name=");
      stringBuilder.Append(this.Name);
      stringBuilder.Append(", Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Gets or sets a value indicating whether cells in the column will match the characters being entered in the cell with one from the possible selections. </summary>
    /// <returns>true if auto completion is activated; otherwise, false. The default is true.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridView_ComboBoxColumnAutoCompleteDescr")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    [Browsable(true)]
    public bool AutoComplete
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.AutoComplete : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.AutoComplete == value)
          return;
        this.ComboBoxCellTemplate.AutoComplete = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.AutoComplete = value;
        }
      }
    }

    /// <summary>Gets or sets the template used to create cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</returns>
    /// <exception cref="T:System.InvalidCastException">When setting this property to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override DataGridViewCell CellTemplate
    {
      get => base.CellTemplate;
      set
      {
        DataGridViewComboBoxCell viewComboBoxCell = value as DataGridViewComboBoxCell;
        base.CellTemplate = value == null || viewComboBoxCell != null ? value : throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", (object) "Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"));
        if (value == null)
          return;
        viewComboBoxCell.TemplateComboBoxColumn = this;
      }
    }

    private DataGridViewComboBoxCell ComboBoxCellTemplate => (DataGridViewComboBoxCell) this.CellTemplate;

    /// <summary>Gets or sets the data source that populates the selections for the combo boxes.</summary>
    /// <returns>An object that represents a data source. The default is null.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewDataSourceDescr")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRCategory("CatData")]
    [DefaultValue(null)]
    [AttributeProvider(typeof (Binding.IDataSourceAttributeProvider))]
    public object DataSource
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.DataSource : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ComboBoxCellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        this.ComboBoxCellTemplate.DataSource = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.DataSource = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    /// <summary>Gets or sets a string that specifies the property or column from which to retrieve strings for display in the combo boxes.</summary>
    /// <returns>A <see cref="T:System.String"></see> that specifies the name of a property or column in the data source specified in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.DataSource"></see> property. The default is <see cref="F:System.String.Empty"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [SRDescription("DataGridView_ComboBoxColumnDisplayMemberDescr")]
    [SRCategory("CatData")]
    [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public string DisplayMember
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.DisplayMember : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ComboBoxCellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        this.ComboBoxCellTemplate.DisplayMember = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.DisplayMember = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    /// <summary>Gets or sets a value that determines how the combo box is displayed when not editing.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle"></see> value indicating the combo box appearance. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
    [SRDescription("DataGridView_ComboBoxColumnDisplayStyleDescr")]
    [DefaultValue(1)]
    [SRCategory("CatAppearance")]
    public DataGridViewComboBoxDisplayStyle DisplayStyle
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.DisplayStyle : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ComboBoxCellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        this.ComboBoxCellTemplate.DisplayStyle = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.DisplayStyleInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>Gets or sets a value that determines if the display style only applies to the current cell.</summary>
    /// <returns>true if the display style applies only to the current cell; otherwise false. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
    [DefaultValue(false)]
    [SRDescription("DataGridView_ComboBoxColumnDisplayStyleForCurrentCellOnlyDescr")]
    [SRCategory("CatAppearance")]
    public bool DisplayStyleForCurrentCellOnly
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.DisplayStyleForCurrentCellOnly : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ComboBoxCellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        this.ComboBoxCellTemplate.DisplayStyleForCurrentCellOnly = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.DisplayStyleForCurrentCellOnlyInternal = value;
        }
        this.DataGridView.InvalidateColumn(this.Index);
      }
    }

    /// <summary>Gets or sets the drop down style.</summary>
    /// <value></value>
    [DefaultValue(ComboBoxStyle.DropDownList)]
    public virtual ComboBoxStyle DropDownStyle
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.DropDownStyle : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ComboBoxCellTemplate.DropDownStyle == value)
          return;
        this.ComboBoxCellTemplate.DropDownStyle = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.DropDownStyle = value;
        }
      }
    }

    /// <summary>Gets or sets the width of the drop-down lists of the combo boxes.</summary>
    /// <returns>The width, in pixels, of the drop-down lists. The default is 1.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(1)]
    [SRDescription("DataGridView_ComboBoxColumnDropDownWidthDescr")]
    [SRCategory("CatBehavior")]
    public int DropDownWidth
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.DropDownWidth : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.DropDownWidth == value)
          return;
        this.ComboBoxCellTemplate.DropDownWidth = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.DropDownWidth = value;
        }
      }
    }

    /// <summary>Gets or sets the flat style appearance of the column's cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the cell appearance. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    [SRDescription("DataGridView_ComboBoxColumnFlatStyleDescr")]
    [DefaultValue(2)]
    public FlatStyle FlatStyle
    {
      get => this.CellTemplate != null ? ((DataGridViewComboBoxCell) this.CellTemplate).FlatStyle : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.FlatStyle == value)
          return;
        ((DataGridViewComboBoxCell) this.CellTemplate).FlatStyle = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.FlatStyleInternal = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    /// <summary>Gets the collection of objects used as selections in the combo boxes.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> that represents the selections in the combo boxes. </returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatData")]
    [SRDescription("DataGridView_ComboBoxColumnItemsDescr")]
    [Localizable(true)]
    [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public DataGridViewComboBoxCell.ObjectCollection Items => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.GetItems(this.DataGridView) : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));

    /// <summary>Gets or sets the maximum number of items in the drop-down list of the cells in the column.</summary>
    /// <returns>The maximum number of drop-down list items, from 1 to 100. The default is 8.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_ComboBoxColumnMaxDropDownItemsDescr")]
    [DefaultValue(8)]
    public int MaxDropDownItems
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.MaxDropDownItems : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.MaxDropDownItems == value)
          return;
        this.ComboBoxCellTemplate.MaxDropDownItems = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.MaxDropDownItems = value;
        }
      }
    }

    /// <summary>Gets or sets a value indicating whether the items in the combo box are sorted.</summary>
    /// <returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("DataGridView_ComboBoxColumnSortedDescr")]
    public bool Sorted
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.Sorted : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.Sorted == value)
          return;
        this.ComboBoxCellTemplate.Sorted = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.Sorted = value;
        }
      }
    }

    /// <summary>Gets or sets a string that specifies the property or column from which to get values that correspond to the selections in the drop-down list.</summary>
    /// <returns>A <see cref="T:System.String"></see> that specifies the name of a property or column used in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.DataSource"></see> property. The default is <see cref="F:System.String.Empty"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DefaultValue("")]
    [SRCategory("CatData")]
    [SRDescription("DataGridView_ComboBoxColumnValueMemberDescr")]
    [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public string ValueMember
    {
      get => this.ComboBoxCellTemplate != null ? this.ComboBoxCellTemplate.ValueMember : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ComboBoxCellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        this.ComboBoxCellTemplate.ValueMember = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewComboBoxCell cell)
            cell.ValueMember = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }
  }
}

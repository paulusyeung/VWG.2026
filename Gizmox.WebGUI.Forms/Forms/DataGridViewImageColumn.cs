// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewImageColumn
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> objects.</summary>
  /// <filterpriority>2</filterpriority>
  [ToolboxBitmap(typeof (DataGridViewImageColumn), "DataGridViewImageColumn.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class DataGridViewImageColumn : DataGridViewColumn
  {
    private ResourceHandle mobjIcon;
    private ResourceHandle mobjImage;
    private static Type mobjColumnType = typeof (DataGridViewImageColumn);

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn"></see> class, configuring it for use with cell values of type <see cref="T:System.Drawing.Image"></see>.</summary>
    public DataGridViewImageColumn()
      : this(true)
    {
    }

    /// <summary>Gets the name of the type.</summary>
    /// <value>The name of the type.</value>
    protected override string TypeName => "3";

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn"></see> class, optionally configuring it for use with <see cref="T:System.Drawing.Icon"></see> cell values.</summary>
    /// <param name="blnValuesAreIcons">true to indicate that the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Value"></see> property of cells in this column will be set to values of type <see cref="T:System.Drawing.Icon"></see>; false to indicate that they will be set to values of type <see cref="T:System.Drawing.Image"></see>.</param>
    public DataGridViewImageColumn(bool blnValuesAreIcons)
    {
      int num = blnValuesAreIcons ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(num != 0, new DataGridViewImageCell(num != 0));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn" /> class.
    /// </summary>
    /// <param name="blnValuesAreIcons">if set to <c>true</c> [BLN values are icons].</param>
    /// <param name="objCellTemplate">The obj cell template.</param>
    protected DataGridViewImageColumn(bool blnValuesAreIcons, DataGridViewImageCell objCellTemplate)
      : base((DataGridViewCell) objCellTemplate)
    {
      this.DefaultCellStyle = new DataGridViewCellStyle()
      {
        AlignmentInternal = DataGridViewContentAlignment.MiddleCenter,
        NullValue = !blnValuesAreIcons ? (object) DataGridViewImageCell.ErrorBitmap : (object) DataGridViewImageCell.ErrorIcon
      };
    }

    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewImageColumn gridViewImageColumn = !(type == DataGridViewImageColumn.mobjColumnType) ? (DataGridViewImageColumn) Activator.CreateInstance(type) : new DataGridViewImageColumn();
      if (gridViewImageColumn != null)
      {
        gridViewImageColumn.Icon = this.Icon;
        gridViewImageColumn.Image = this.Image;
      }
      return (object) gridViewImageColumn;
    }

    private bool ShouldSerializeDefaultCellStyle()
    {
      if (this.CellTemplate is DataGridViewImageCell cellTemplate)
      {
        if (!this.HasDefaultCellStyle)
          return false;
        object obj = !cellTemplate.ValueIsIcon ? (object) DataGridViewImageCell.ErrorBitmap : (object) DataGridViewImageCell.ErrorIcon;
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
              if (color.IsEmpty && defaultCellStyle.Font == null && obj == defaultCellStyle.NullValue && defaultCellStyle.IsDataSourceNullValueDefault)
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
      stringBuilder.Append("DataGridViewImageColumn { Name=");
      stringBuilder.Append(this.Name);
      stringBuilder.Append(", Index=");
      stringBuilder.Append(this.Index.ToString((IFormatProvider) CultureInfo.CurrentCulture));
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Gets or sets the template used to create new cells.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
    /// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see>. </exception>
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
          case DataGridViewImageCell _:
            base.CellTemplate = value;
            break;
          default:
            throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", (object) "Gizmox.WebGUI.Forms.DataGridViewImageCell"));
        }
      }
    }

    /// <summary>Gets or sets the column's default cell style.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
    [SRCategory("CatAppearance")]
    [Browsable(true)]
    [SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
    public override DataGridViewCellStyle DefaultCellStyle
    {
      get => base.DefaultCellStyle;
      set => base.DefaultCellStyle = value;
    }

    /// <summary>Gets or sets a string that describes the column's image. </summary>
    /// <returns>The textual description of the column image. The default is <see cref="F:System.String.Empty"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null.</exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewImageColumn_DescriptionDescr")]
    [Browsable(true)]
    [DefaultValue("")]
    [SRCategory("CatAppearance")]
    public string Description
    {
      get
      {
        if (this.CellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        return this.ImageCellTemplate.Description;
      }
      set
      {
        if (this.CellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        this.ImageCellTemplate.Description = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewImageCell cell)
            cell.Description = value;
        }
      }
    }

    /// <summary>Gets or sets the icon displayed in the cells of this column when the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Value"></see> property is not set and the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageCell.ValueIsIcon"></see> property is set to true.</summary>
    /// <returns>The <see cref="T:System.Drawing.Icon"></see> to display. The default is null.</returns>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ResourceHandle Icon
    {
      get => this.mobjIcon;
      set
      {
        if (this.mobjIcon == value)
          return;
        this.mobjIcon = value;
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    /// <summary>Gets or sets the image.</summary>
    /// <value>The image.</value>
    [SRCategory("CatAppearance")]
    [DefaultValue(null)]
    [SRDescription("DataGridViewImageColumn_ImageDescr")]
    public ResourceHandle Image
    {
      get => this.mobjImage;
      set
      {
        if (this.mobjImage == value)
          return;
        this.mobjImage = value;
        if (this.DataGridView == null)
          return;
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    private DataGridViewImageCell ImageCellTemplate => (DataGridViewImageCell) this.CellTemplate;

    /// <summary>Gets or sets the image layout in the cells for this column.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> that specifies the cell layout. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.Normal"></see>.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewImageColumn_ImageLayoutDescr")]
    [DefaultValue(1)]
    [SRCategory("CatAppearance")]
    public DataGridViewImageCellLayout ImageLayout
    {
      get
      {
        if (this.CellTemplate == null)
          throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
        DataGridViewImageCellLayout imageLayout = this.ImageCellTemplate.ImageLayout;
        if (imageLayout == DataGridViewImageCellLayout.NotSet)
          imageLayout = DataGridViewImageCellLayout.Normal;
        return imageLayout;
      }
      set
      {
        if (this.ImageLayout == value)
          return;
        this.ImageCellTemplate.ImageLayout = value;
        if (this.DataGridView == null)
          return;
        DataGridViewRowCollection rows = this.DataGridView.Rows;
        int count = rows.Count;
        for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
        {
          if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewImageCell cell)
            cell.ImageLayoutInternal = value;
        }
        this.DataGridView.OnColumnCommonChange(this.Index);
      }
    }

    /// <summary>Gets or sets a value indicating whether cells in this column display <see cref="T:System.Drawing.Icon"></see> values.</summary>
    /// <returns>true if cells display values of type <see cref="T:System.Drawing.Icon"></see>; false if cells display values of type <see cref="T:System.Drawing.Image"></see>. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null.</exception>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool ValuesAreIcons
    {
      get => this.ImageCellTemplate != null ? this.ImageCellTemplate.ValueIsIcon : throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
      set
      {
        if (this.ValuesAreIcons == value)
          return;
        this.ImageCellTemplate.ValueIsIconInternal = value;
        if (this.DataGridView != null)
        {
          DataGridViewRowCollection rows = this.DataGridView.Rows;
          int count = rows.Count;
          for (int intRowIndex = 0; intRowIndex < count; ++intRowIndex)
          {
            if (rows.SharedRow(intRowIndex).Cells[this.Index] is DataGridViewImageCell cell)
              cell.ValueIsIconInternal = value;
          }
          this.DataGridView.OnColumnCommonChange(this.Index);
        }
        if (value && this.DefaultCellStyle.NullValue is Bitmap && (ResourceHandle) this.DefaultCellStyle.NullValue == DataGridViewImageCell.ErrorBitmap)
        {
          this.DefaultCellStyle.NullValue = (object) DataGridViewImageCell.ErrorIcon;
        }
        else
        {
          if (value || !(this.DefaultCellStyle.NullValue is System.Drawing.Icon) || (System.Drawing.Icon) this.DefaultCellStyle.NullValue != DataGridViewImageCell.ErrorIcon)
            return;
          this.DefaultCellStyle.NullValue = (object) DataGridViewImageCell.ErrorBitmap;
        }
      }
    }
  }
}

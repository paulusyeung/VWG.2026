// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewImageCell
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Displays a graphic in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
  /// <filterpriority>2</filterpriority>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DataGridViewImageCellSkin))]
  [Serializable]
  public class DataGridViewImageCell : DataGridViewCell
  {
    private const byte DATAGRIDVIEWIMAGECELL_valueIsIcon = 1;
    private bool mblnValueIsIcon;
    private byte mobjFlags;
    private DataGridViewImageCellLayout menmImageLayout;
    private static Type mobjCellType;
    private static Type mobjDefaultTypeIcon = typeof (ResourceHandle);
    private static Type mobjDefaultTypeImage = typeof (ResourceHandle);
    private static ResourceHandle mobjErrorBmp;
    private string mstrDescription = string.Empty;

    static DataGridViewImageCell() => DataGridViewImageCell.mobjCellType = typeof (DataGridViewImageCell);

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> class, configuring it for use with cell values other than <see cref="T:System.Drawing.Icon"></see> objects.</summary>
    public DataGridViewImageCell()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> class, optionally configuring it for use with <see cref="T:System.Drawing.Icon"></see> cell values.</summary>
    /// <param name="blnValueIsIcon">The cell will display an <see cref="T:System.Drawing.Icon"></see> value.</param>
    public DataGridViewImageCell(bool blnValueIsIcon)
      : this()
    {
      this.ValueIsIcon = blnValueIsIcon;
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
      switch (objFormatedValue)
      {
        case byte[] _:
          GatewayReference gatewayReference = new GatewayReference((IRegisteredComponent) this.DataGridView, string.Format("cell{0}x{1}x{2}", (object) this.ColumnIndex, (object) this.RowIndex, (object) "image"));
          objWriter.WriteAttributeString("IM", gatewayReference.ToString());
          break;
        case ResourceHandle _:
          if (!(objFormatedValue is ResourceHandle resourceHandle))
            break;
          objWriter.WriteAttributeString("IM", resourceHandle.ToString());
          break;
        case string _:
          if (objFormatedValue == null || !(objFormatedValue.ToString() != string.Empty))
            break;
          objWriter.WriteAttributeString("IM", objFormatedValue.ToString());
          break;
      }
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
      base.RenderAttributes(objContext, objWriter, blnRenderOwner);
      switch (this.ImageLayout)
      {
        case DataGridViewImageCellLayout.Normal:
          objWriter.WriteAttributeString("IMS", Convert.ToInt32((object) PictureBoxSizeMode.Normal).ToString());
          break;
        case DataGridViewImageCellLayout.Stretch:
          objWriter.WriteAttributeString("IMS", Convert.ToInt32((object) PictureBoxSizeMode.StretchImage).ToString());
          break;
      }
    }

    /// <summary>Gets or sets the flags.</summary>
    /// <value>The flags.</value>
    private byte Flags
    {
      get => this.mobjFlags;
      set => this.mobjFlags = value;
    }

    /// <summary>Creates an exact copy of this cell.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override object Clone()
    {
      Type type = this.GetType();
      DataGridViewImageCell objDataGridViewCell = !(type == DataGridViewImageCell.mobjCellType) ? (DataGridViewImageCell) Activator.CreateInstance(type) : new DataGridViewImageCell();
      this.CloneInternal((DataGridViewCell) objDataGridViewCell);
      objDataGridViewCell.Description = this.Description;
      objDataGridViewCell.ImageLayout = this.ImageLayout;
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
      return new Size(19, 20);
    }

    /// <summary>Returns a graphic as it would be displayed in the cell.</summary>
    /// <returns>An object that represents the formatted image.</returns>
    /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell. </param>
    /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed. </param>
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
      object formattedValue1 = (object) null;
      if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != (DataGridViewDataErrorContexts) 0)
      {
        formattedValue1 = (object) this.Description;
      }
      else
      {
        object formattedValue2 = base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
        if (formattedValue2 == null && objCellStyle.NullValue == null)
        {
          formattedValue1 = (object) null;
        }
        else
        {
          switch (formattedValue2)
          {
            case Icon _:
              formattedValue1 = (object) (formattedValue2 as Icon) ?? (object) DataGridViewImageCell.ErrorIcon;
              break;
            case ResourceHandle _:
              formattedValue1 = (object) (formattedValue2 as ResourceHandle) ?? (object) DataGridViewImageCell.ErrorBitmap;
              break;
            case string _ when formattedValue2 != null && formattedValue2.ToString() != string.Empty:
              formattedValue1 = (object) formattedValue2.ToString();
              break;
          }
        }
      }
      return formattedValue1;
    }

    /// <summary>Gets the value of the cell.</summary>
    /// <param name="intRowIndex">The index of the cell's parent row.</param>
    /// <returns>
    /// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
    /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
    protected override object GetValue(int intRowIndex)
    {
      object obj = base.GetValue(intRowIndex);
      if (obj == null && this.OwningColumn is DataGridViewImageColumn owningColumn)
      {
        if (DataGridViewImageCell.mobjDefaultTypeImage.IsAssignableFrom(this.ValueType))
          return (object) owningColumn.Image ?? obj;
        if (DataGridViewImageCell.mobjDefaultTypeIcon.IsAssignableFrom(this.ValueType))
        {
          ResourceHandle icon = owningColumn.Icon;
          if (icon != null)
            return (object) icon;
        }
      }
      return obj;
    }

    /// <summary>Returns a string that describes the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => (string) null;

    /// <summary>Gets the default value that is used when creating a new row.</summary>
    /// <returns>An object containing a default image placeholder, or null to display an empty cell.</returns>
    /// <filterpriority>1</filterpriority>
    public override object DefaultNewRowValue => (object) null;

    /// <summary>Gets or sets the text associated with the image.</summary>
    /// <returns>The text associated with the image displayed in the cell.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    public string Description
    {
      get => this.mstrDescription;
      set => this.mstrDescription = value;
    }

    /// <summary>Gets the type of the cell's hosted editing control. </summary>
    /// <returns>The <see cref="T:System.Type"></see> of the underlying editing control. As implemented in this class, this property is always null.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type EditType => (Type) null;

    /// <summary>Gets the error bitmap.</summary>
    /// <value>The error bitmap.</value>
    internal static ResourceHandle ErrorBitmap
    {
      get
      {
        if (DataGridViewImageCell.mobjErrorBmp == null)
          DataGridViewImageCell.mobjErrorBmp = (ResourceHandle) new SkinResourceHandle(typeof (DataGridView), "ErrorProvider.gif");
        return DataGridViewImageCell.mobjErrorBmp;
      }
    }

    /// <summary>Gets the error icon.</summary>
    /// <value>The error icon.</value>
    internal static Icon ErrorIcon => (Icon) null;

    /// <summary>Gets the type of the formatted value associated with the cell.</summary>
    /// <returns>A <see cref="T:System.Type"></see> object representing display value type of the cell, which is the <see cref="T:System.Drawing.Image"></see> type if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageCell.ValueIsIcon"></see> property is set to false or the <see cref="T:System.Drawing.Icon"></see> type otherwise.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type FormattedValueType => this.ValueIsIcon ? DataGridViewImageCell.mobjDefaultTypeIcon : DataGridViewImageCell.mobjDefaultTypeImage;

    /// <summary>Gets or sets the graphics layout for the cell. </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> for this cell. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.NotSet"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The supplied <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> value is invalid. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(0)]
    public DataGridViewImageCellLayout ImageLayout
    {
      get => this.menmImageLayout;
      set => this.ImageLayoutInternal = value;
    }

    /// <summary>Sets the image layout internal.</summary>
    /// <value>The image layout internal.</value>
    internal DataGridViewImageCellLayout ImageLayoutInternal
    {
      set => this.menmImageLayout = value;
    }

    /// <summary>Gets or sets a value indicating whether this cell displays an <see cref="T:System.Drawing.Icon"></see> value.</summary>
    /// <returns>true if this cell displays an <see cref="T:System.Drawing.Icon"></see> value; otherwise, false.</returns>
    [DefaultValue(false)]
    public bool ValueIsIcon
    {
      get => this.mblnValueIsIcon;
      set => this.ValueIsIconInternal = value;
    }

    /// <summary>
    /// Sets a value indicating whether [value is icon internal].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [value is icon internal]; otherwise, <c>false</c>.
    /// </value>
    internal bool ValueIsIconInternal
    {
      set => this.mblnValueIsIcon = value;
    }

    /// <summary>Gets or sets the data type of the values in the cell. </summary>
    /// <returns>The <see cref="T:System.Type"></see> of the cell's value.</returns>
    /// <filterpriority>1</filterpriority>
    public override Type ValueType
    {
      get
      {
        Type valueType = base.ValueType;
        return valueType != (Type) null ? valueType : typeof (ResourceHandle);
      }
      set => base.ValueType = value;
    }
  }
}

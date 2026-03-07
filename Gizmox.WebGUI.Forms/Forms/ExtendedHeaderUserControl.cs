// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ExtendedHeaderUserControl
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Base User Control contained by the Exptended Header Cell
  /// </summary>
  [ToolboxItem(false)]
  [TypeConverter(typeof (ExtendedHeaderUserControlTypeConverter))]
  [Serializable]
  public class ExtendedHeaderUserControl : UserControl
  {
    private int mintColSpan = 1;
    private int mintColIndex;
    private int mintRowSpan = 1;
    private int mintRowIndex;
    private DataGridView mobjParentDataGrid;
    private ExtendedHeaderCellType menmExtendedHeaderCellType;

    /// <summary>Gets or sets the type of the extended panel.</summary>
    /// <value>The type of the extended panel.</value>
    [DefaultValue(ExtendedHeaderCellType.Headers)]
    [Category("Header layout")]
    public ExtendedHeaderCellType ExtendedHeaderCellType
    {
      get => this.menmExtendedHeaderCellType;
      set
      {
        if (this.menmExtendedHeaderCellType == value)
          return;
        this.menmExtendedHeaderCellType = value;
        this.UpdateGrid();
      }
    }

    /// <summary>Gets or sets the index of the row.</summary>
    /// <value>The index of the row.</value>
    [Category("Header layout")]
    [DefaultValue(0)]
    public int RowIndex
    {
      get => this.mintRowIndex;
      set => this.mintRowIndex = value;
    }

    /// <summary>Gets or sets the row span.</summary>
    /// <value>The row span.</value>
    [Category("Header layout")]
    [DefaultValue(1)]
    public int RowSpan
    {
      get => this.mintRowSpan;
      set
      {
        if (this.mintRowSpan == value)
          return;
        this.mintRowSpan = value;
        this.UpdateGrid();
      }
    }

    /// <summary>Gets or sets the index of the column.</summary>
    /// <value>The index of the col.</value>
    [Category("Header layout")]
    [DefaultValue(0)]
    public int ColIndex
    {
      get => this.mintColIndex;
      set => this.mintColIndex = value;
    }

    /// <summary>Gets or sets the col span.</summary>
    /// <value>The col span.</value>
    [Category("Header layout")]
    [DefaultValue(1)]
    public int ColSpan
    {
      get => this.mintColSpan;
      set
      {
        if (this.mintColSpan == value)
          return;
        this.mintColSpan = value;
        this.UpdateGrid();
      }
    }

    /// <summary>Gets controls docking style as Fill</summary>
    public override DockStyle Dock
    {
      get => DockStyle.Fill;
      set
      {
      }
    }

    /// <summary>Gets or sets the parent grid.</summary>
    /// <value>The parent grid.</value>
    [Browsable(false)]
    internal DataGridView ParentGrid
    {
      get => this.mobjParentDataGrid;
      set => this.mobjParentDataGrid = value;
    }

    /// <summary>
    /// Checks if the current control needs rendering and
    /// continues to process sub tree/
    /// </summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected internal override void RenderControl(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (this.mintColSpan <= this.UnvisibleContainingColumnsCount() && this.ExtendedHeaderCellType == ExtendedHeaderCellType.Headers)
        return;
      base.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>
    /// Get the number of unvisible columns position in the column range of the user control's extended header
    /// </summary>
    /// <returns></returns>
    private int UnvisibleContainingColumnsCount()
    {
      int num = 0;
      for (int colIndex = this.ColIndex; colIndex < this.ColIndex + this.mintColSpan; ++colIndex)
      {
        if (!this.ParentGrid.Columns[colIndex].Visible)
          ++num;
      }
      return num;
    }

    /// <summary>
    /// Get the number of unvisible columns position before the user control's column index.
    /// </summary>
    /// <returns></returns>
    private int UnvisiblePrecedingColumnsCount()
    {
      int num = 0;
      for (int index = 0; index < this.ColIndex; ++index)
      {
        if (!this.ParentGrid.Columns[index].Visible)
          ++num;
      }
      return num;
    }

    /// <summary>Renders the attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.ExtendedHeaderCellType != ExtendedHeaderCellType.Headers)
      {
        objWriter.WriteAttributeString("EPT", ((int) this.ExtendedHeaderCellType).ToString());
      }
      else
      {
        int num1 = this.UnvisiblePrecedingColumnsCount();
        int num2 = this.UnvisibleContainingColumnsCount();
        int num3;
        if (this.mintColSpan > 1)
        {
          IAttributeWriter attributeWriter = objWriter;
          num3 = this.mintColSpan - num2;
          string strValue = num3.ToString();
          attributeWriter.WriteAttributeString("CSP", strValue);
        }
        IAttributeWriter attributeWriter1 = objWriter;
        num3 = this.ColIndex - num1;
        string strValue1 = num3.ToString();
        attributeWriter1.WriteAttributeString("CIX", strValue1);
      }
      if (this.mintRowSpan > 1)
        objWriter.WriteAttributeString("RSP", this.mintRowSpan.ToString());
      objWriter.WriteAttributeString("RIX", this.mintRowIndex.ToString());
    }

    /// <summary>Updates the grid.</summary>
    protected void UpdateGrid()
    {
      if (this.mobjParentDataGrid == null)
        return;
      this.mobjParentDataGrid.Update();
    }
  }
}

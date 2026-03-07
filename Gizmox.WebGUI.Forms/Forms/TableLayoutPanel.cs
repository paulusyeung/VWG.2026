// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutPanel
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A table layout control.</summary>
  /// <remarks>
  /// Use this layout control to create static layout that updates
  /// with control resizing.
  /// </remarks>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (TableLayoutPanel), "TableLayoutPanel_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ProvideProperty("Column", typeof (Control))]
  [SRDescription("DescriptionTableLayoutPanel")]
  [ProvideProperty("ColumnSpan", typeof (Control))]
  [ProvideProperty("RowSpan", typeof (Control))]
  [ProvideProperty("Row", typeof (Control))]
  [ProvideProperty("CellPosition", typeof (Control))]
  [DefaultProperty("ColumnCount")]
  [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [ComVisible(true)]
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ToolboxItemCategory("Containers")]
  [Gizmox.WebGUI.Forms.MetadataTag("TLP")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (TableLayoutPanelSkin))]
  [ProxyComponent(typeof (ProxyTableLayoutPanel))]
  [Serializable]
  public class TableLayoutPanel : Control, IExtenderProvider
  {
    /// <summary>
    /// Provides a property reference to LayoutSettings property.
    /// </summary>
    private static SerializableProperty LayoutSettingsProperty = SerializableProperty.Register(nameof (LayoutSettings), typeof (TableLayoutSettings), typeof (TableLayoutPanel), new SerializablePropertyMetadata((object) null));
    private static readonly SerializableEvent EventCellPaint = SerializableEvent.Register("Event", typeof (Delegate), typeof (TableLayoutPanel));
    private BorderStyle menmBorderStyle;

    /// <summary>Occurs when [cell paint].</summary>
    [SRCategory("CatAppearance")]
    [SRDescription("TableLayoutPanelOnPaintCellDescr")]
    public event TableLayoutCellPaintEventHandler CellPaint
    {
      add => this.AddHandler(TableLayoutPanel.EventCellPaint, (Delegate) value);
      remove => this.RemoveHandler(TableLayoutPanel.EventCellPaint, (Delegate) value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutPanel" /> class.
    /// </summary>
    public TableLayoutPanel() => this.SetValue<TableLayoutSettings>(TableLayoutPanel.LayoutSettingsProperty, TableLayout.CreateSettings((IArrangedElement) this));

    /// <summary>Gets or sets the border color.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [Browsable(false)]
    public Color BorderColor
    {
      get => (Color) base.BorderColor;
      set => this.BorderColor = (Gizmox.WebGUI.Forms.BorderColor) value;
    }

    /// <summary>Gets or sets the width of the border.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BorderWidth
    {
      get => (int) base.BorderWidth;
      set => this.BorderWidth = (Gizmox.WebGUI.Forms.BorderWidth) value;
    }

    /// <summary>Gets or sets the border style.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Localizable(true)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new BorderStyle BorderStyle
    {
      get => base.BorderStyle;
      set => base.BorderStyle = value;
    }

    /// <summary>Gets or sets the cell border style.</summary>
    /// <value>The cell border style.</value>
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [DefaultValue(0)]
    [SRDescription("TableLayoutPanelCellBorderStyleDescr")]
    public TableLayoutPanelCellBorderStyle CellBorderStyle
    {
      get => this.LayoutSettings.CellBorderStyle;
      set
      {
        this.LayoutSettings.CellBorderStyle = value;
        this.FireObservableItemPropertyChanged(nameof (CellBorderStyle));
        if (value != TableLayoutPanelCellBorderStyle.None)
          this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.Invalidate();
      }
    }

    private int CellBorderWidth => this.LayoutSettings.CellBorderWidth;

    /// <summary>Gets or sets the column count.</summary>
    /// <value>The column count.</value>
    [SRDescription("GridPanelColumnsDescr")]
    [Localizable(true)]
    [SRCategory("CatLayout")]
    [DefaultValue(0)]
    public int ColumnCount
    {
      get => this.LayoutSettings.ColumnCount;
      set
      {
        this.LayoutSettings.ColumnCount = value;
        this.FireObservableItemPropertyChanged(nameof (ColumnCount));
        this.Update();
      }
    }

    /// <summary>Gets the column styles.</summary>
    /// <value>The column styles.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRDescription("GridPanelColumnStylesDescr")]
    [SRCategory("CatLayout")]
    [MergableProperty(false)]
    [Browsable(true)]
    [DisplayName("Columns")]
    public TableLayoutColumnStyleCollection ColumnStyles => this.LayoutSettings.ColumnStyles;

    /// <summary>
    /// Gets the collection of controls contained within the control.
    /// </summary>
    /// <value></value>
    [Browsable(false)]
    [SRDescription("ControlControlsDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public TableLayoutControlCollection Controls => (TableLayoutControlCollection) base.Controls;

    /// <summary>Gets or sets the grow style.</summary>
    /// <value>The grow style.</value>
    [SRDescription("TableLayoutPanelGrowStyleDescr")]
    [DefaultValue(1)]
    [SRCategory("CatLayout")]
    public TableLayoutPanelGrowStyle GrowStyle
    {
      get => this.LayoutSettings.GrowStyle;
      set
      {
        this.LayoutSettings.GrowStyle = value;
        this.FireObservableItemPropertyChanged(nameof (GrowStyle));
      }
    }

    /// <summary>Gets the layout engine.</summary>
    /// <value>The layout engine.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public LayoutEngine LayoutEngine => (LayoutEngine) TableLayout.Instance;

    /// <summary>Gets or sets the layout settings.</summary>
    /// <value>The layout settings.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public TableLayoutSettings LayoutSettings
    {
      get => this.GetValue<TableLayoutSettings>(TableLayoutPanel.LayoutSettingsProperty);
      set
      {
        if (value == null || !value.IsStub)
          throw new NotSupportedException(SR.GetString("TableLayoutSettingSettingsIsNotSupported"));
        this.LayoutSettings.ApplySettings(value);
        this.FireObservableItemPropertyChanged(nameof (LayoutSettings));
      }
    }

    /// <summary>Gets or sets the row count.</summary>
    /// <value>The row count.</value>
    [DefaultValue(0)]
    [SRDescription("GridPanelRowsDescr")]
    [SRCategory("CatLayout")]
    [Localizable(true)]
    public int RowCount
    {
      get => this.LayoutSettings.RowCount;
      set
      {
        this.LayoutSettings.RowCount = value;
        this.FireObservableItemPropertyChanged(nameof (RowCount));
        this.Update();
      }
    }

    /// <summary>
    /// Gets a value indicating whether [support child margins].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [support child margins]; otherwise, <c>false</c>.
    /// </value>
    protected override bool SupportChildMargins => true;

    /// <summary>Gets the row styles.</summary>
    /// <value>The row styles.</value>
    [SRDescription("GridPanelRowStylesDescr")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatLayout")]
    [MergableProperty(false)]
    [DisplayName("Rows")]
    public TableLayoutRowStyleCollection RowStyles => this.LayoutSettings.RowStyles;

    /// <summary>Renders the current control.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      this.RegisterSelf();
      objWriter.WriteAttributeText("TX", this.Text);
      if (this.CellBorderStyle != TableLayoutPanelCellBorderStyle.None)
        objWriter.WriteAttributeString("BS", ((int) this.CellBorderStyle).ToString());
      int intNewRowNum = 0;
      int intNewColNum = 0;
      this.GetNewColAndRowCount(out intNewRowNum, out intNewColNum);
      List<TableLayoutPanelCellStyle> objRowsCells = new List<TableLayoutPanelCellStyle>();
      List<TableLayoutPanelCellStyle> objColumnsCells = new List<TableLayoutPanelCellStyle>();
      this.CalculateColAndRowStyle(intNewRowNum, intNewColNum, objRowsCells, objColumnsCells);
      for (int index = 0; index < intNewColNum; ++index)
      {
        if (index < this.ColumnStyles.Count)
        {
          objWriter.WriteStartElement("TLC");
          objWriter.WriteAttributeString("W", this.GetLayoutSize(this.ColumnStyles[index].Width, this.ColumnStyles[index].SizeType));
          TableLayoutPanel.RenderColumnsPositionAttributes(objWriter, objColumnsCells, index);
          objWriter.WriteEndElement();
        }
        else
        {
          objWriter.WriteStartElement("TLC");
          objWriter.WriteAttributeString("W", "1px");
          TableLayoutPanel.RenderColumnsPositionAttributes(objWriter, objColumnsCells, index);
          objWriter.WriteEndElement();
        }
      }
      for (int index = 0; index < intNewRowNum; ++index)
      {
        if (index < this.RowStyles.Count)
        {
          objWriter.WriteStartElement("TLR");
          objWriter.WriteAttributeString("H", this.GetLayoutSize(this.RowStyles[index].Height, this.RowStyles[index].SizeType));
          TableLayoutPanel.RenderRowsPositionAttributes(objWriter, objRowsCells, index);
          objWriter.WriteEndElement();
        }
        else
        {
          objWriter.WriteStartElement("TLR");
          objWriter.WriteAttributeString("H", "1px");
          TableLayoutPanel.RenderRowsPositionAttributes(objWriter, objRowsCells, index);
          objWriter.WriteEndElement();
        }
      }
      for (int index = this.Controls.Count - 1; index >= 0; --index)
      {
        Control control = this.Controls[index];
        TableLayoutControlPosition controlPosition = this.GetControlPosition(control);
        if (controlPosition.Row > -1 && controlPosition.Column > -1)
          ((IRenderableComponent) control).RenderComponent(objContext, objWriter, 0L);
      }
    }

    /// <summary>Renders the columns position attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objColumnsCells">The obj columns cells.</param>
    /// <param name="intInd">The int ind.</param>
    private static void RenderColumnsPositionAttributes(
      IResponseWriter objWriter,
      List<TableLayoutPanelCellStyle> objColumnsCells,
      int intInd)
    {
      if (objColumnsCells.Count <= intInd)
        return;
      objWriter.WriteAttributeString("L", Math.Round((double) objColumnsCells[intInd].LeftPercent, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("ML", Math.Round((double) objColumnsCells[intInd].LeftMarginPixel, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("R", Math.Round((double) objColumnsCells[intInd].RightPercent, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("MR", Math.Round((double) objColumnsCells[intInd].RightMarginPixel, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    /// <summary>Renders the rows position attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="objRowsCells">The obj rows cells.</param>
    /// <param name="intInd">The int ind.</param>
    private static void RenderRowsPositionAttributes(
      IResponseWriter objWriter,
      List<TableLayoutPanelCellStyle> objRowsCells,
      int intInd)
    {
      if (objRowsCells.Count <= intInd)
        return;
      objWriter.WriteAttributeString("T", Math.Round((double) objRowsCells[intInd].TopPercent, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("MT", Math.Round((double) objRowsCells[intInd].TopMarginPixel, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("B", Math.Round((double) objRowsCells[intInd].BottomPercent, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
      objWriter.WriteAttributeString("MB", Math.Round((double) objRowsCells[intInd].BottomMarginPixel, 2).ToString((IFormatProvider) CultureInfo.InvariantCulture));
    }

    /// <summary>Pre-render control.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo((IArrangedElement) this);
      TableLayout instance = TableLayout.Instance;
      if (containerInfo != null && instance != null)
        instance.AssignRowsAndColumns(containerInfo);
      for (int index = this.Controls.Count - 1; index >= 0; --index)
      {
        Control control = this.Controls[index];
        TableLayoutControlPosition controlPosition = this.GetControlPosition(control);
        if (controlPosition.Row > -1 && controlPosition.Column > -1)
        {
          string numbers1 = this.GetNumbers(controlPosition.Row, controlPosition.Row + (controlPosition.Rowspan - 1));
          string numbers2 = this.GetNumbers(controlPosition.Column, controlPosition.Column + (controlPosition.Colspan - 1));
          ((IAttributeExtender) control).SetAttribute("RS", numbers1);
          ((IAttributeExtender) control).SetAttribute("CS", numbers2);
          ((IAttributeExtender) control).SetAttribute("RSP", controlPosition.Rowspan.ToString());
          ((IAttributeExtender) control).SetAttribute("CSP", controlPosition.Colspan.ToString());
        }
      }
      base.PreRenderControl(objContext, lngRequestID);
    }

    /// <summary>Gets the col and row style.</summary>
    /// <param name="intNewRowNum">The int new row num.</param>
    /// <param name="intNewColNum">The int new col num.</param>
    /// <param name="objRowsCells">The obj rows cells.</param>
    /// <param name="objColumnsCells">The obj columns cells.</param>
    private void CalculateColAndRowStyle(
      int intNewRowNum,
      int intNewColNum,
      List<TableLayoutPanelCellStyle> objRowsCells,
      List<TableLayoutPanelCellStyle> objColumnsCells)
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      float fltTotalSum1 = 0.0f;
      float fltTotalSum2 = 0.0f;
      for (int index = 0; index < intNewRowNum; ++index)
      {
        if (index < this.RowStyles.Count)
        {
          if (this.RowStyles[index].SizeType == SizeType.Absolute)
            num2 += this.RowStyles[index].Height;
          else
            fltTotalSum1 += this.RowStyles[index].Height;
        }
        else
        {
          Control control = (Control) null;
          for (int intColumn = 0; intColumn < intNewColNum; ++intColumn)
          {
            Control controlFromPosition = this.GetControlFromPosition(intColumn, index);
            TableLayoutPanelCellPosition positionFromControl = this.GetPositionFromControl(controlFromPosition);
            if (controlFromPosition != null && this.GetRowSpan(controlFromPosition) == 1 && positionFromControl.Column == intColumn && positionFromControl.Row == index && (control == null || control.Height < controlFromPosition.Height))
              control = controlFromPosition;
          }
          if (control != null)
            num2 += (float) control.Height;
          else
            ++num2;
        }
      }
      for (int index = 0; index < intNewColNum; ++index)
      {
        if (index < this.ColumnStyles.Count)
        {
          if (this.ColumnStyles[index].SizeType == SizeType.Absolute)
            num1 += this.ColumnStyles[index].Width;
          else
            fltTotalSum2 += this.ColumnStyles[index].Width;
        }
        else
        {
          Control control = (Control) null;
          for (int intRow = 0; intRow < intNewRowNum; ++intRow)
          {
            Control controlFromPosition = this.GetControlFromPosition(index, intRow);
            TableLayoutPanelCellPosition positionFromControl = this.GetPositionFromControl(controlFromPosition);
            if (controlFromPosition != null && positionFromControl.Column == index && positionFromControl.Row == intRow && (control == null || control.Width < controlFromPosition.Width))
              control = controlFromPosition;
          }
          if (control != null)
            num1 += (float) control.Width;
          else
            ++num1;
        }
      }
      float num3 = 0.0f;
      for (int index1 = 0; index1 < intNewRowNum; ++index1)
      {
        if (index1 == 0 && index1 < this.RowStyles.Count)
        {
          TableLayoutPanelCellStyle layoutPanelCellStyle = new TableLayoutPanelCellStyle();
          objRowsCells.Add(layoutPanelCellStyle);
          if (this.RowStyles[index1].SizeType == SizeType.Percent)
          {
            float num4 = this.NormalizePercentage(fltTotalSum1, this.RowStyles[index1].Height);
            layoutPanelCellStyle.BottomPercent = 100f - num4;
            layoutPanelCellStyle.BottomMarginPixel = num4 / 100f * num2;
          }
          else if (this.RowStyles[index1].SizeType == SizeType.Absolute)
          {
            num3 += this.RowStyles[index1].Height;
            layoutPanelCellStyle.BottomPercent = 100f;
            layoutPanelCellStyle.BottomMarginPixel = num3 * -1f;
          }
        }
        else if (index1 < this.RowStyles.Count)
        {
          TableLayoutPanelCellStyle objRowsCell = objRowsCells[index1 - 1];
          TableLayoutPanelCellStyle layoutPanelCellStyle = new TableLayoutPanelCellStyle();
          objRowsCells.Add(layoutPanelCellStyle);
          if (objRowsCell != null)
          {
            layoutPanelCellStyle.TopPercent = 100f - objRowsCell.BottomPercent;
            layoutPanelCellStyle.TopMarginPixel = objRowsCell.BottomMarginPixel * -1f;
          }
          if (index1 == this.RowStyles.Count - 1 && index1 == intNewRowNum - 1)
          {
            layoutPanelCellStyle.BottomPercent = 0.0f;
            layoutPanelCellStyle.BottomMarginPixel = 0.0f;
          }
          else if (this.RowStyles[index1].SizeType == SizeType.Percent)
          {
            float num5 = this.NormalizePercentage(fltTotalSum1, this.RowStyles[index1].Height);
            layoutPanelCellStyle.BottomPercent = (float) (100.0 - ((double) layoutPanelCellStyle.TopPercent + (double) num5));
            layoutPanelCellStyle.BottomMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.BottomPercent) / 100.0) * num2 - num3;
          }
          else if (this.RowStyles[index1].SizeType == SizeType.Absolute)
          {
            num3 += this.RowStyles[index1].Height;
            layoutPanelCellStyle.BottomPercent = 100f - layoutPanelCellStyle.TopPercent;
            layoutPanelCellStyle.BottomMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.BottomPercent) / 100.0) * num2 - num3;
          }
        }
        else
        {
          int num6 = 1;
          for (int intColumn = 0; intColumn < intNewColNum; ++intColumn)
          {
            Control controlFromPosition = this.GetControlFromPosition(intColumn, index1);
            TableLayoutPanelCellPosition positionFromControl = this.GetPositionFromControl(controlFromPosition);
            if (controlFromPosition != null)
            {
              int rowSpan = this.GetRowSpan(controlFromPosition);
              if (rowSpan == 1)
              {
                if (num6 < controlFromPosition.Height)
                  num6 = controlFromPosition.Height;
              }
              else if (rowSpan > 1 && positionFromControl.Row + rowSpan - 1 == index1)
              {
                int height = controlFromPosition.Height;
                for (int index2 = index1 - 1; index2 >= positionFromControl.Row; --index2)
                {
                  TableLayoutPanelCellStyle objRowsCell = objRowsCells[index2];
                  height -= (int) ((double) Math.Abs(objRowsCell.BottomMarginPixel) - (double) objRowsCell.TopMarginPixel);
                }
                if (num6 < height)
                  num6 = height;
              }
            }
          }
          TableLayoutPanelCellStyle layoutPanelCellStyle = new TableLayoutPanelCellStyle();
          objRowsCells.Add(layoutPanelCellStyle);
          num3 += (float) num6;
          if (index1 > 0)
          {
            TableLayoutPanelCellStyle objRowsCell = objRowsCells[index1 - 1];
            if (objRowsCell != null)
            {
              layoutPanelCellStyle.TopPercent = 100f - objRowsCell.BottomPercent;
              layoutPanelCellStyle.TopMarginPixel = objRowsCell.BottomMarginPixel * -1f;
            }
            layoutPanelCellStyle.BottomPercent = 100f - layoutPanelCellStyle.TopPercent;
            layoutPanelCellStyle.BottomMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.BottomPercent) / 100.0) * num2 - num3;
          }
          else
          {
            if ((double) num2 < (double) this.Height)
              num2 = (float) this.Height;
            layoutPanelCellStyle.BottomPercent = 100f - layoutPanelCellStyle.TopPercent;
            layoutPanelCellStyle.BottomMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.BottomPercent) / 100.0) * num2 - num3;
          }
          if (index1 == intNewRowNum - 1)
          {
            layoutPanelCellStyle.BottomPercent = 0.0f;
            layoutPanelCellStyle.BottomMarginPixel = 0.0f;
          }
        }
      }
      float num7 = 0.0f;
      for (int index3 = 0; index3 < intNewColNum; ++index3)
      {
        if (index3 == 0 && index3 < this.ColumnStyles.Count)
        {
          TableLayoutPanelCellStyle layoutPanelCellStyle = new TableLayoutPanelCellStyle();
          objColumnsCells.Add(layoutPanelCellStyle);
          if (this.ColumnStyles[index3].SizeType == SizeType.Percent)
          {
            float num8 = this.NormalizePercentage(fltTotalSum2, this.ColumnStyles[index3].Width);
            layoutPanelCellStyle.RightPercent = 100f - num8;
            layoutPanelCellStyle.RightMarginPixel = num8 / 100f * num1;
          }
          else if (this.ColumnStyles[index3].SizeType == SizeType.Absolute)
          {
            num7 += this.ColumnStyles[index3].Width;
            layoutPanelCellStyle.RightPercent = 100f;
            layoutPanelCellStyle.RightMarginPixel = num7 * -1f;
          }
        }
        else if (index3 < this.ColumnStyles.Count)
        {
          TableLayoutPanelCellStyle objColumnsCell = objColumnsCells[index3 - 1];
          TableLayoutPanelCellStyle layoutPanelCellStyle = new TableLayoutPanelCellStyle();
          objColumnsCells.Add(layoutPanelCellStyle);
          if (objColumnsCell != null)
          {
            layoutPanelCellStyle.LeftPercent = 100f - objColumnsCell.RightPercent;
            layoutPanelCellStyle.LeftMarginPixel = objColumnsCell.RightMarginPixel * -1f;
          }
          if (index3 == this.ColumnStyles.Count - 1 && index3 == intNewColNum - 1)
          {
            layoutPanelCellStyle.RightPercent = 0.0f;
            layoutPanelCellStyle.RightMarginPixel = 0.0f;
          }
          else if (this.ColumnStyles[index3].SizeType == SizeType.Percent)
          {
            float num9 = this.NormalizePercentage(fltTotalSum2, this.ColumnStyles[index3].Width);
            layoutPanelCellStyle.RightPercent = (float) (100.0 - ((double) layoutPanelCellStyle.LeftPercent + (double) num9));
            layoutPanelCellStyle.RightMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.RightPercent) / 100.0) * num1 - num7;
          }
          else if (this.ColumnStyles[index3].SizeType == SizeType.Absolute)
          {
            num7 += this.ColumnStyles[index3].Width;
            layoutPanelCellStyle.RightPercent = 100f - layoutPanelCellStyle.LeftPercent;
            layoutPanelCellStyle.RightMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.RightPercent) / 100.0) * num1 - num7;
          }
        }
        else
        {
          int num10 = 1;
          for (int intRow = 0; intRow < intNewRowNum; ++intRow)
          {
            Control controlFromPosition = this.GetControlFromPosition(index3, intRow);
            TableLayoutPanelCellPosition positionFromControl = this.GetPositionFromControl(controlFromPosition);
            if (controlFromPosition != null)
            {
              int columnSpan = this.GetColumnSpan(controlFromPosition);
              if (columnSpan == 1)
              {
                if (num10 < controlFromPosition.Width)
                  num10 = controlFromPosition.Width;
              }
              else if (columnSpan > 1 && positionFromControl.Column + columnSpan - 1 == columnSpan)
              {
                int height = controlFromPosition.Height;
                for (int index4 = index3 - 1; index4 >= positionFromControl.Column; --index4)
                {
                  TableLayoutPanelCellStyle objColumnsCell = objColumnsCells[index4];
                  height -= (int) ((double) Math.Abs(objColumnsCell.RightMarginPixel) - (double) objColumnsCell.LeftMarginPixel);
                }
                if (num10 < height)
                  num10 = height;
              }
            }
          }
          TableLayoutPanelCellStyle layoutPanelCellStyle = new TableLayoutPanelCellStyle();
          objColumnsCells.Add(layoutPanelCellStyle);
          num7 += (float) num10;
          if (index3 > 0)
          {
            TableLayoutPanelCellStyle objColumnsCell = objColumnsCells[index3 - 1];
            if (objColumnsCell != null)
            {
              layoutPanelCellStyle.LeftPercent = 100f - objColumnsCell.RightPercent;
              layoutPanelCellStyle.LeftMarginPixel = objColumnsCell.RightMarginPixel * -1f;
            }
            layoutPanelCellStyle.RightPercent = 100f - layoutPanelCellStyle.LeftPercent;
            layoutPanelCellStyle.RightMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.RightPercent) / 100.0) * num1 - num7;
          }
          else
          {
            if ((double) num1 < (double) this.Width)
              num1 = (float) this.Width;
            layoutPanelCellStyle.RightPercent = 100f;
            layoutPanelCellStyle.RightMarginPixel = (float) ((100.0 - (double) layoutPanelCellStyle.RightPercent) / 100.0) * num1 - num7;
          }
          if (index3 == intNewColNum - 1)
          {
            layoutPanelCellStyle.RightPercent = 0.0f;
            layoutPanelCellStyle.RightMarginPixel = 0.0f;
          }
        }
      }
    }

    /// <summary>
    /// Normalizes the percentage mainly when the sum of sizes of cells is not 100.
    /// </summary>
    /// <param name="fltTotalSum">The FLT total sum.</param>
    /// <param name="fltCurrentValue">The FLT current value.</param>
    /// <returns></returns>
    private float NormalizePercentage(float fltTotalSum, float fltCurrentValue) => (float) ((double) fltCurrentValue / (double) fltTotalSum * 100.0);

    /// <summary>
    /// Raises the <see cref="E:ControlRemoved" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
    protected override void OnControlRemoved(ControlEventArgs e)
    {
      base.OnControlRemoved(e);
      if (e.Control == null)
        return;
      ((IAttributeExtender) e.Control).SetAttribute("RS", (string) null);
      ((IAttributeExtender) e.Control).SetAttribute("CS", (string) null);
      ((IAttributeExtender) e.Control).SetAttribute("RSP", (string) null);
      ((IAttributeExtender) e.Control).SetAttribute("CSP", (string) null);
    }

    /// <summary>
    /// Gets the new row and column number according to the newly added controls.
    /// </summary>
    /// <param name="intNewRowNum">The row count return value.</param>
    /// <param name="intNewColNum">The column count return value.</param>
    /// <returns></returns>
    internal void GetNewColAndRowCount(out int intNewRowNum, out int intNewColNum)
    {
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo((IArrangedElement) this);
      if (containerInfo != null)
      {
        intNewColNum = Math.Max(containerInfo.MaxColumns, containerInfo.MinColumns);
        intNewRowNum = Math.Max(containerInfo.MaxRows, containerInfo.MinRows);
      }
      else
      {
        intNewColNum = 0;
        intNewRowNum = 0;
      }
    }

    /// <summary>Gets the size of the control.</summary>
    /// <param name="objProposedSize">The proposed size in a 'Size' struct format.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objProposedSize)
    {
      int width = objProposedSize.Width;
      int height = objProposedSize.Height;
      if (this.AutoSize)
      {
        if (this.Controls.Count > 0)
        {
          foreach (Control control in (ArrangedElementCollection) this.Controls)
          {
            TableLayoutControlPosition controlPosition = this.GetControlPosition(control);
            if (controlPosition != null)
            {
              Size objProposedSize1 = new Size(control.LayoutWidth, control.LayoutHeight);
              Size objPreferredSize;
              if (control.UsePreferredSize)
              {
                objPreferredSize = control.GetPreferredSize(objProposedSize1);
                objPreferredSize = Control.GetPreferredSizeByAutoSizeMode(control, objProposedSize1, objPreferredSize);
              }
              else
                objPreferredSize = objProposedSize1;
              if (controlPosition.Column >= 0 && controlPosition.Column < this.ColumnStyles.Count && this.ColumnStyles[controlPosition.Column].SizeType == SizeType.AutoSize && (double) objPreferredSize.Width > (double) this.ColumnStyles[controlPosition.Column].Width)
                this.ColumnStyles[controlPosition.Column].Width = (float) objPreferredSize.Width;
              if (controlPosition.Row >= 0 && controlPosition.Row < this.RowStyles.Count && this.RowStyles[controlPosition.Row].SizeType == SizeType.AutoSize && (double) objPreferredSize.Height > (double) this.RowStyles[controlPosition.Row].Height)
                this.RowStyles[controlPosition.Row].Height = (float) objPreferredSize.Height;
            }
          }
        }
        width = 0;
        height = 0;
        foreach (ColumnStyle columnStyle in (IEnumerable) this.ColumnStyles)
          width += Convert.ToInt32(columnStyle.Width);
        foreach (RowStyle rowStyle in (IEnumerable) this.RowStyles)
          height += Convert.ToInt32(rowStyle.Height);
      }
      return new Size(width, height);
    }

    /// <summary>
    /// Layout the internal controls to reflect parent changes
    /// </summary>
    /// <param name="objEventArgs">The layout arguments.</param>
    /// <param name="objNewSize">The new parent size.</param>
    /// <param name="objOldSize">The old parent size.</param>
    protected override void OnLayoutControls(
      LayoutEventArgs objEventArgs,
      ref Size objNewSize,
      ref Size objOldSize)
    {
      Control.ControlCollection controls = (Control.ControlCollection) this.Controls;
      if (controls == null || controls.Count <= 0)
        return;
      int num1 = objNewSize.Width - objOldSize.Width;
      int num2 = objNewSize.Height - objOldSize.Height;
      if (num2 == 0 && num1 == 0)
        return;
      foreach (Control objControl in (ArrangedElementCollection) controls)
      {
        DockStyle dock = objControl.Dock;
        ColumnStyle columnStyle = (ColumnStyle) null;
        RowStyle rowStyle = (RowStyle) null;
        int column = this.GetColumn(objControl);
        if (column >= 0 && column < this.ColumnStyles.Count)
          columnStyle = this.ColumnStyles[column];
        int row = this.GetRow(objControl);
        if (row >= 0 && row < this.RowStyles.Count)
          rowStyle = this.RowStyles[row];
        if (columnStyle != null && rowStyle != null && (columnStyle.SizeType == SizeType.Percent || rowStyle.SizeType == SizeType.Percent))
        {
          switch (dock)
          {
            case DockStyle.Fill:
              if (num1 != 0 && columnStyle.SizeType == SizeType.Percent || num2 != 0 && rowStyle.SizeType == SizeType.Percent)
              {
                objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                continue;
              }
              continue;
            case DockStyle.Top:
            case DockStyle.Bottom:
              if (dock == DockStyle.Bottom && num2 != 0 && rowStyle.SizeType == SizeType.Percent)
                objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
              if (num1 != 0 && columnStyle.SizeType == SizeType.Percent)
              {
                objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                continue;
              }
              continue;
            case DockStyle.Right:
            case DockStyle.Left:
              if (num1 != 0 && columnStyle.SizeType == SizeType.Percent && dock == DockStyle.Right)
                objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
              if (num2 != 0 && rowStyle.SizeType == SizeType.Percent)
              {
                objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                continue;
              }
              continue;
            default:
              int left = objControl.Left;
              int top = objControl.Top;
              int height = objControl.Height;
              int width = objControl.Width;
              AnchorStyles anchor = objControl.Anchor;
              bool flag1 = objControl.IsRightAnchored(anchor);
              bool flag2 = objControl.IsLeftAnchored(anchor);
              bool flag3 = objControl.IsTopAnchored(anchor);
              bool flag4 = objControl.IsBottomAnchored(anchor);
              bool flag5 = false;
              bool flag6 = false;
              if (num1 != 0 && columnStyle.SizeType == SizeType.Percent)
              {
                if (flag1 && !flag2)
                {
                  left += Convert.ToInt32((float) ((double) columnStyle.Size * (double) num1 / 100.0));
                  flag6 = true;
                }
                else if (flag1 & flag2)
                {
                  width += Convert.ToInt32((float) ((double) columnStyle.Size * (double) num1 / 100.0));
                  flag5 = true;
                }
                else if (!flag1 && !flag2)
                {
                  left += Convert.ToInt32((float) ((double) columnStyle.Size * (double) num1 / 200.0));
                  flag6 = true;
                }
              }
              if (num2 != 0 && rowStyle.SizeType == SizeType.Percent)
              {
                if (flag4 && !flag3)
                {
                  top += Convert.ToInt32((float) ((double) rowStyle.Size * (double) num2 / 100.0));
                  flag6 = true;
                }
                else if (flag4 & flag3)
                {
                  height += Convert.ToInt32((float) ((double) rowStyle.Size * (double) num2 / 100.0));
                  flag5 = true;
                }
                else if (!flag4 && !flag3)
                {
                  top += Convert.ToInt32((float) ((double) rowStyle.Size * (double) num2 / 200.0));
                  flag6 = true;
                }
              }
              if (flag6 | flag5)
              {
                objControl.UpdateBounds(left, top, width, height, width, height, objEventArgs.IsClientSource);
                if (flag6)
                  objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
                if (flag5)
                {
                  objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                  continue;
                }
                continue;
              }
              continue;
          }
        }
      }
    }

    /// <summary>Gets the size of the layout.</summary>
    /// <param name="fltSize">Size of the lay out.</param>
    /// <param name="enmSizeType">Type of size.</param>
    /// <returns></returns>
    private string GetLayoutSize(float fltSize, SizeType enmSizeType)
    {
      string layoutSize = string.Empty;
      switch (enmSizeType)
      {
        case SizeType.AutoSize:
          layoutSize = string.Empty;
          break;
        case SizeType.Absolute:
          layoutSize = string.Format("{0}px", (object) fltSize.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case SizeType.Percent:
          layoutSize = string.Format("{0}%", (object) fltSize.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          break;
      }
      return layoutSize;
    }

    /// <summary>Renders the child controls.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    /// <param name="lngRequestID">Request ID.</param>
    /// <remarks>
    /// Overrides default controls rendering cause the fill docking mechanism is not
    /// fit to handle table layout children.
    /// </remarks>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      for (int index = this.Controls.Count - 1; index >= 0; --index)
        ((IRenderableComponent) this.Controls[index]).RenderComponent(objContext, objWriter, lngRequestID);
    }

    /// <summary>Gets the cell position.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [SRDescription("GridPanelCellPositionDescr")]
    [DefaultValue(-1)]
    [SRCategory("CatLayout")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DisplayName("Cell")]
    public TableLayoutPanelCellPosition GetCellPosition(Control objControl) => this.LayoutSettings.GetCellPosition((object) objControl);

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new TableLayoutPanelRenderer(this);

    /// <summary>Gets the column.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [SRDescription("GridPanelColumnDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatLayout")]
    [DefaultValue(-1)]
    [DisplayName("Column")]
    public int GetColumn(Control objControl) => this.LayoutSettings.GetColumn((object) objControl);

    /// <summary>Gets the column span.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [SRCategory("CatLayout")]
    [SRDescription("GridPanelGetColumnSpanDescr")]
    [DefaultValue(1)]
    [DisplayName("ColumnSpan")]
    public int GetColumnSpan(Control objControl) => this.LayoutSettings.GetColumnSpan((object) objControl);

    /// <summary>Gets the column widths.</summary>
    /// <returns></returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetColumnWidths()
    {
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo((IArrangedElement) this);
      if (containerInfo.Columns == null)
        return new int[0];
      int[] columnWidths = new int[containerInfo.Columns.Length];
      for (int index = 0; index < containerInfo.Columns.Length; ++index)
        columnWidths[index] = containerInfo.Columns[index].MinSize;
      return columnWidths;
    }

    /// <summary>
    /// Returns the child control occupying the specified position.
    /// </summary>
    /// <param name="intColumn">The column position of the control to retrieve.</param>
    /// <param name="intRow">The row position of the control to retrieve.</param>
    /// <returns>
    /// The child control occupying the specified cell; otherwise, null if no control
    /// exists at the specified column and row.
    /// </returns>
    public Control GetControlFromPosition(int intColumn, int intRow) => (Control) this.LayoutSettings.GetControlFromPosition(intColumn, intRow);

    /// <summary>Gets the position from control.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    public TableLayoutPanelCellPosition GetPositionFromControl(Control objControl) => this.LayoutSettings.GetPositionFromControl((IArrangedElement) objControl);

    /// <summary>Gets the row.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(-1)]
    [SRDescription("GridPanelRowDescr")]
    [SRCategory("CatLayout")]
    [DisplayName("Row")]
    public int GetRow(Control objControl) => this.LayoutSettings.GetRow((object) objControl);

    /// <summary>Gets the row heights.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public int[] GetRowHeights()
    {
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo((IArrangedElement) this);
      if (containerInfo.Rows == null)
        return new int[0];
      int[] rowHeights = new int[containerInfo.Rows.Length];
      for (int index = 0; index < containerInfo.Rows.Length; ++index)
        rowHeights[index] = containerInfo.Rows[index].MinSize;
      return rowHeights;
    }

    /// <summary>Gets the row span.</summary>
    /// <param name="objControl">The control.</param>
    /// <returns></returns>
    [SRDescription("GridPanelGetRowSpanDescr")]
    [DefaultValue(1)]
    [SRCategory("CatLayout")]
    [DisplayName("RowSpan")]
    public int GetRowSpan(Control objControl) => this.LayoutSettings.GetRowSpan((object) objControl);

    /// <summary>Sets the cell position.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="objPosition">The position.</param>
    public void SetCellPosition(Control objControl, TableLayoutPanelCellPosition objPosition)
    {
      this.LayoutSettings.SetCellPosition((object) objControl, objPosition);
      this.FireObservableItemPropertyChanged("CellPosition", (object) objControl);
      this.Update();
    }

    /// <summary>Sets the column.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intColumn">The column.</param>
    public void SetColumn(Control objControl, int intColumn)
    {
      this.LayoutSettings.SetColumn((object) objControl, intColumn);
      this.FireObservableItemPropertyChanged("Column", (object) objControl);
      this.Update();
    }

    /// <summary>Sets the column span.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intValue">The value.</param>
    public void SetColumnSpan(Control objControl, int intValue)
    {
      this.LayoutSettings.SetColumnSpan((object) objControl, intValue);
      this.FireObservableItemPropertyChanged("ColumnSpan", (object) objControl);
      this.Update();
    }

    /// <summary>Sets the row.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intRow">The row.</param>
    public void SetRow(Control objControl, int intRow)
    {
      this.LayoutSettings.SetRow((object) objControl, intRow);
      this.FireObservableItemPropertyChanged("Row", (object) objControl);
      this.Update();
    }

    /// <summary>Sets the row span.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="intValue">The value.</param>
    public void SetRowSpan(Control objControl, int intValue)
    {
      this.LayoutSettings.SetRowSpan((object) objControl, intValue);
      this.FireObservableItemPropertyChanged("RowSpan", (object) objControl);
      this.Update();
    }

    /// <summary>Creates the controls instance.</summary>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected override Control.ControlCollection CreateControlsInstance() => (Control.ControlCollection) new TableLayoutControlCollection(this);

    /// <summary>
    /// Raises the <see cref="E:CellPaint" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TableLayoutCellPaintEventArgs" /> instance containing the event data.</param>
    protected virtual void OnCellPaint(TableLayoutCellPaintEventArgs e)
    {
      TableLayoutCellPaintEventHandler handler = (TableLayoutCellPaintEventHandler) this.GetHandler(TableLayoutPanel.EventCellPaint);
      if (handler == null)
        return;
      handler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:Layout" /> event.
    /// </summary>
    /// <param name="objLevent">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected new void OnLayout(LayoutEventArgs objLevent) => this.Invalidate();

    /// <summary>
    /// Raises the <see cref="E:PaintBackground" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs" /> instance containing the event data.</param>
    protected void OnPaintBackground(PaintEventArgs e)
    {
      int cellBorderWidth = this.CellBorderWidth;
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo((IArrangedElement) this);
      TableLayout.Strip[] columns = containerInfo.Columns;
      TableLayout.Strip[] rows = containerInfo.Rows;
      TableLayoutPanelCellBorderStyle cellBorderStyle = this.CellBorderStyle;
      if (columns == null || rows == null)
        return;
      int length1 = columns.Length;
      int length2 = rows.Length;
      int num1 = 0;
      int num2 = 0;
      Graphics graphics = e.Graphics;
      Rectangle rectangle1 = new Rectangle(this.Location, this.Size);
      Rectangle clipRectangle = e.ClipRectangle;
      bool flag = this.RightToLeft == RightToLeft.Yes;
      int x = !flag ? rectangle1.X + cellBorderWidth / 2 : rectangle1.Right - cellBorderWidth / 2;
      for (int intColumn = 0; intColumn < length1; ++intColumn)
      {
        int y = rectangle1.Y + cellBorderWidth / 2;
        if (flag)
          x -= columns[intColumn].MinSize;
        for (int intRow = 0; intRow < length2; ++intRow)
        {
          Rectangle rectangle2 = new Rectangle(x, y, columns[intColumn].MinSize, rows[intRow].MinSize);
          Rectangle rectangle3 = new Rectangle(rectangle2.X + (cellBorderWidth + 1) / 2, rectangle2.Y + (cellBorderWidth + 1) / 2, rectangle2.Width - (cellBorderWidth + 1) / 2, rectangle2.Height - (cellBorderWidth + 1) / 2);
          if (clipRectangle.IntersectsWith(rectangle3))
            this.OnCellPaint(new TableLayoutCellPaintEventArgs(graphics, clipRectangle, rectangle3, intColumn, intRow));
          y += rows[intRow].MinSize;
          if (intColumn == 0)
            num2 += rows[intRow].MinSize;
        }
        if (!flag)
          x += columns[intColumn].MinSize;
        num1 += columns[intColumn].MinSize;
      }
      Rectangle rectangle4 = new Rectangle(cellBorderWidth / 2 + rectangle1.X, cellBorderWidth / 2 + rectangle1.Y, rectangle1.Width - cellBorderWidth, rectangle1.Height - cellBorderWidth);
      switch (cellBorderStyle)
      {
        case TableLayoutPanelCellBorderStyle.Inset:
          graphics.DrawLine(SystemPens.ControlDark, rectangle4.Right, rectangle4.Y, rectangle4.Right, rectangle4.Bottom);
          graphics.DrawLine(SystemPens.ControlDark, rectangle4.X, rectangle4.Y + rectangle4.Height - 1, rectangle4.X + rectangle4.Width - 1, rectangle4.Y + rectangle4.Height - 1);
          break;
        case TableLayoutPanelCellBorderStyle.Outset:
          using (Pen pen = new Pen(SystemColors.Window))
          {
            graphics.DrawLine(pen, rectangle4.X + rectangle4.Width - 1, rectangle4.Y, rectangle4.X + rectangle4.Width - 1, rectangle4.Y + rectangle4.Height - 1);
            graphics.DrawLine(pen, rectangle4.X, rectangle4.Y + rectangle4.Height - 1, rectangle4.X + rectangle4.Width - 1, rectangle4.Y + rectangle4.Height - 1);
            break;
          }
      }
    }

    /// <summary>Gets the calculated height of the control.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
    /// <returns></returns>
    internal float GetControlCalculatedHeight(Control objControl, bool blnUseLayoutValues)
    {
      float calculatedHeight1 = 0.0f;
      if (objControl != null)
      {
        int row = this.GetRow(objControl);
        if (row >= 0)
        {
          int rowSpan = this.GetRowSpan(objControl);
          float calculatedHeight2 = (float) this.GetCalculatedHeight(blnUseLayoutValues);
          float num1 = 0.0f;
          float num2 = 0.0f;
          int rowCount = this.RowCount;
          foreach (RowStyle rowStyle in (IEnumerable) this.RowStyles)
          {
            if (this.RowStyles.IndexOf(rowStyle) < rowCount)
            {
              if (rowStyle.SizeType == SizeType.Absolute)
                num1 += rowStyle.Height;
              else if (rowStyle.SizeType == SizeType.Percent)
                num2 += rowStyle.Height;
            }
          }
          for (int index = 0; index < rowSpan; ++index)
          {
            if (row + index < this.RowStyles.Count)
            {
              RowStyle rowStyle = this.RowStyles[row + index];
              if (rowStyle != null && this.RowStyles.IndexOf(rowStyle) < rowCount)
              {
                switch (rowStyle.SizeType)
                {
                  case SizeType.Absolute:
                    calculatedHeight1 += rowStyle.Height;
                    continue;
                  case SizeType.Percent:
                    if ((double) calculatedHeight2 > (double) num1)
                    {
                      float height = rowStyle.Height;
                      if ((double) num2 < 100.0)
                        height += (float) ((100.0 - (double) num2) * (double) height / 100.0);
                      calculatedHeight1 += (float) (((double) calculatedHeight2 - (double) num1) * (double) height / 100.0);
                      continue;
                    }
                    continue;
                  default:
                    continue;
                }
              }
            }
            else if (index == 0)
              calculatedHeight1 += (float) objControl.LayoutHeight;
          }
        }
      }
      return calculatedHeight1;
    }

    /// <summary>Gets the calculated width of the control.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
    /// <returns></returns>
    internal float GetControlCalculatedWidth(Control objControl, bool blnUseLayoutValues)
    {
      float controlCalculatedWidth = 0.0f;
      if (objControl != null)
      {
        int column = this.GetColumn(objControl);
        if (column >= 0)
        {
          int columnSpan = this.GetColumnSpan(objControl);
          float calculatedWidth = (float) this.GetCalculatedWidth(blnUseLayoutValues);
          float num1 = 0.0f;
          float num2 = 0.0f;
          int columnCount = this.ColumnCount;
          foreach (ColumnStyle columnStyle in (IEnumerable) this.ColumnStyles)
          {
            if (this.ColumnStyles.IndexOf(columnStyle) < columnCount)
            {
              if (columnStyle.SizeType == SizeType.Absolute)
                num2 += columnStyle.Width;
              else if (columnStyle.SizeType == SizeType.Percent)
                num1 += columnStyle.Width;
            }
          }
          for (int index = 0; index < columnSpan; ++index)
          {
            if (column + index < this.ColumnStyles.Count)
            {
              ColumnStyle columnStyle = this.ColumnStyles[column + index];
              if (columnStyle != null && this.ColumnStyles.IndexOf(columnStyle) < columnCount)
              {
                switch (columnStyle.SizeType)
                {
                  case SizeType.Absolute:
                    controlCalculatedWidth += columnStyle.Width;
                    continue;
                  case SizeType.Percent:
                    if ((double) calculatedWidth > (double) num2)
                    {
                      float width = columnStyle.Width;
                      if ((double) num1 < 100.0)
                        width += (float) ((100.0 - (double) num1) * (double) width / 100.0);
                      controlCalculatedWidth += (float) (((double) calculatedWidth - (double) num2) * (double) width / 100.0);
                      continue;
                    }
                    continue;
                  default:
                    continue;
                }
              }
            }
            else if (index == 0)
              controlCalculatedWidth += (float) objControl.LayoutWidth;
          }
        }
      }
      return controlCalculatedWidth;
    }

    /// <summary>Gets the control calculated left.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
    /// <returns></returns>
    internal float GetControlCalculatedLeft(Control objControl, bool blnUseLayoutValues)
    {
      float calculatedLeft = (float) this.GetCalculatedLeft(blnUseLayoutValues);
      if (objControl != null)
      {
        int column = this.GetColumn(objControl);
        if (column >= 0)
        {
          this.GetColumnSpan(objControl);
          int calculatedWidth = this.GetCalculatedWidth(blnUseLayoutValues);
          float num1 = 0.0f;
          float num2 = 0.0f;
          int columnCount = this.ColumnCount;
          foreach (ColumnStyle columnStyle in (IEnumerable) this.ColumnStyles)
          {
            if (this.ColumnStyles.IndexOf(columnStyle) < columnCount)
            {
              if (columnStyle.SizeType == SizeType.Absolute)
                num2 += columnStyle.Width;
              else if (columnStyle.SizeType == SizeType.Percent)
                num1 += columnStyle.Width;
            }
          }
          for (int index = 0; index < column; ++index)
          {
            if (index < this.ColumnStyles.Count)
            {
              ColumnStyle columnStyle = this.ColumnStyles[index];
              if (columnStyle != null && this.ColumnStyles.IndexOf(columnStyle) < columnCount)
              {
                switch (columnStyle.SizeType)
                {
                  case SizeType.Absolute:
                    calculatedLeft += columnStyle.Width;
                    continue;
                  case SizeType.Percent:
                    float width = columnStyle.Width;
                    if ((double) num1 < 100.0)
                      width += (float) ((100.0 - (double) num1) * (double) width / 100.0);
                    calculatedLeft += (float) ((double) calculatedWidth * (double) width / 100.0);
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
        }
      }
      return calculatedLeft;
    }

    /// <summary>Gets the control calculated top.</summary>
    /// <param name="objControl">The control.</param>
    /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
    /// <returns></returns>
    internal float GetControlCalculatedTop(Control objControl, bool blnUseLayoutValues)
    {
      float calculatedTop = (float) this.GetCalculatedTop(blnUseLayoutValues);
      if (objControl != null)
      {
        int row = this.GetRow(objControl);
        if (row >= 0)
        {
          this.GetRowSpan(objControl);
          int calculatedHeight = this.GetCalculatedHeight(blnUseLayoutValues);
          float num1 = 0.0f;
          float num2 = 0.0f;
          int rowCount = this.RowCount;
          foreach (RowStyle rowStyle in (IEnumerable) this.RowStyles)
          {
            if (this.RowStyles.IndexOf(rowStyle) < rowCount)
            {
              if (rowStyle.SizeType == SizeType.Absolute)
                num2 += rowStyle.Height;
              else if (rowStyle.SizeType == SizeType.Percent)
                num1 += rowStyle.Height;
            }
          }
          for (int index = 0; index < row; ++index)
          {
            if (index < this.RowStyles.Count)
            {
              RowStyle rowStyle = this.RowStyles[index];
              if (rowStyle != null && this.RowStyles.IndexOf(rowStyle) < rowCount)
              {
                switch (rowStyle.SizeType)
                {
                  case SizeType.Absolute:
                    calculatedTop += rowStyle.Height;
                    continue;
                  case SizeType.Percent:
                    float height = rowStyle.Height;
                    if ((double) num1 < 100.0)
                      height += (float) ((100.0 - (double) num1) * (double) height / 100.0);
                    calculatedTop += (float) ((double) calculatedHeight * (double) height / 100.0);
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
        }
      }
      return calculatedTop;
    }

    /// <summary>Scales the control.</summary>
    /// <param name="objFactor">The factor.</param>
    /// <param name="enmSpecified">The specified.</param>
    protected void ScaleControl(SizeF objFactor, BoundsSpecified enmSpecified) => this.ScaleAbsoluteStyles(objFactor);

    /// <summary>Gets a numbers string.</summary>
    /// <param name="intFrom">Int from.</param>
    /// <param name="intTo">Int to.</param>
    /// <returns></returns>
    private string GetNumbers(int intFrom, int intTo)
    {
      string[] strArray = new string[intTo - intFrom + 1];
      for (int index = intFrom; index <= intTo; ++index)
        strArray[index - intFrom] = index.ToString();
      return string.Join(",", strArray);
    }

    /// <summary>Gets a control position.</summary>
    /// <param name="objControl">Obj control.</param>
    /// <returns></returns>
    private TableLayoutControlPosition GetControlPosition(Control objControl) => new TableLayoutControlPosition()
    {
      Control = objControl,
      Column = this.GetColumn(objControl),
      Row = this.GetRow(objControl),
      Colspan = this.GetColumnSpan(objControl),
      Rowspan = this.GetRowSpan(objControl)
    };

    bool IExtenderProvider.CanExtend(object obj) => obj is Control control && control.Parent == this;

    private void ScaleAbsoluteStyles(SizeF objFactor)
    {
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo((IArrangedElement) this);
      int num1 = 0;
      int num2 = -1;
      int index = containerInfo.Rows.Length - 1;
      if (containerInfo.Rows.Length != 0)
        num2 = containerInfo.Rows[index].MinSize;
      int num3 = -1;
      int num4 = containerInfo.Columns.Length - 1;
      if (containerInfo.Columns.Length != 0)
        num3 = containerInfo.Columns[containerInfo.Columns.Length - 1].MinSize;
      foreach (ColumnStyle columnStyle in (IEnumerable) this.ColumnStyles)
      {
        if (columnStyle.SizeType == SizeType.Absolute)
          columnStyle.Width = num1 != num4 || num3 <= 0 ? (float) Math.Round((double) columnStyle.Width * (double) objFactor.Width) : (float) Math.Round((double) num3 * (double) objFactor.Width);
        ++num1;
      }
      int num5 = 0;
      foreach (RowStyle rowStyle in (IEnumerable) this.RowStyles)
      {
        if (rowStyle.SizeType == SizeType.Absolute)
          rowStyle.Height = num5 != index || num2 <= 0 ? (float) Math.Round((double) rowStyle.Height * (double) objFactor.Height) : (float) Math.Round((double) num2 * (double) objFactor.Height);
      }
    }

    private bool ShouldSerializeControls()
    {
      TableLayoutControlCollection controls = this.Controls;
      return controls != null && controls.Count > 0;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.DataGridViewSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>DataGridView Skin</summary>
  [ToolboxBitmap(typeof (DataGridView), "DataGridView.bmp")]
  [SkinDependency(typeof (DataGridViewFilterButtonSkin))]
  [SkinDependency(typeof (DataGridViewButtonCellSkin))]
  [SkinDependency(typeof (DataGridViewCheckBoxCellSkin))]
  [SkinDependency(typeof (DataGridViewComboBoxCellSkin))]
  [SkinDependency(typeof (DataGridViewImageCellSkin))]
  [SkinDependency(typeof (DataGridViewLinkCellSkin))]
  [SkinDependency(typeof (DataGridViewTextBoxCellSkin))]
  [SkinDependency(typeof (ColumnChooserButtonSkin))]
  [SkinDependency(typeof (DataGridViewActiveTextBoxCellSkin))]
  [SkinDependency(typeof (DataGridViewGroupingTreeViewSkin))]
  [SkinDependency(typeof (DataGridViewCellPanelSkin))]
  [SkinDependency(typeof (DataGridViewFilterComboBoxSkin))]
  [SkinDependency(typeof (DataGridViewHeaderFilterComboBoxSkin))]
  [SkinDependency(typeof (DataGridViewFilterComboBoxSkin))]
  [Serializable]
  public class DataGridViewSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the extended columns non frozen style.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ExtendedColumnsNonFrozenStyle => new StyleValue((CommonSkin) this, nameof (ExtendedColumnsNonFrozenStyle));

    /// <summary>Gets the extended columns frozen style.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ExtendedColumnsFrozenStyle => new StyleValue((CommonSkin) this, "ExtendedColumnsFrozen");

    /// <summary>Gets the extended columns corner style.</summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ExtendedColumnsCornerStyle => new StyleValue((CommonSkin) this, "ExtendedColumnsCorner");

    /// <summary>
    /// Gets the "clear all filters" tooltip localized string.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string ClearAllFiltersToolTip => Gizmox.WebGUI.Forms.SR.GetString("ClearAllFilters");

    /// <summary>Gets or sets the drop indicator style.</summary>
    /// <value>The drop indicator style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("Grouping TreeNode drop indicator style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue DropIndicatorStyle => new StyleValue((CommonSkin) this, nameof (DropIndicatorStyle));

    /// <summary>Gets the grouping drop area empty style.</summary>
    [Category("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("The empty grouping drop area style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue GroupingDropAreaStyle => new StyleValue((CommonSkin) this, nameof (GroupingDropAreaStyle));

    /// <summary>Gets the grouping drop area empty message style.</summary>
    [Category("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("The empty grouping drop area empty message style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue GroupingDropAreaEmptyMessageStyle => new StyleValue((CommonSkin) this, nameof (GroupingDropAreaEmptyMessageStyle));

    /// <summary>Gets the grouping drop area empty message.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual string GroupingDropAreaEmptyMessage => Gizmox.WebGUI.Forms.SR.GetString("DataGridViewGroupingTreeViewDragColumnHeaderHere");

    /// <summary>
    /// Gets or sets the grouping drop area empty message align.
    /// </summary>
    /// <value>The grouping drop area empty message align.</value>
    [Category("Appearance")]
    [Gizmox.WebGUI.Forms.SRDescription("The empty grouping drop area message alignment.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public HorizontalAlignment GroupingDropAreaEmptyMessageAlign
    {
      get => this.GetValue<HorizontalAlignment>(nameof (GroupingDropAreaEmptyMessageAlign), HorizontalAlignment.Left);
      set => this.SetValue(nameof (GroupingDropAreaEmptyMessageAlign), (object) value);
    }

    /// <summary>Resets the grouping drop area empty message align.</summary>
    private void ResetGroupingDropAreaEmptyMessageAlign() => this.Reset("GroupingDropAreaEmptyMessageAlign");

    /// <summary>Gets the "clear all filters" button style.</summary>
    [Category("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("The \"Clear All Filters\" button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue FilterRowClearButtonStyle => new StyleValue((CommonSkin) this, nameof (FilterRowClearButtonStyle));

    /// <summary>Gets the caption style.</summary>
    [Category("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("The caption style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CaptionStyle => new StyleValue((CommonSkin) this, nameof (CaptionStyle));

    /// <summary>Gets the row header normal style.</summary>
    /// <value>The row header normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal row header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue RowHeaderNormalStyle => (StyleValue) new DataGridViewSkin.GridStyleValue(this, nameof (RowHeaderNormalStyle));

    /// <summary>Gets the row header selected style.</summary>
    /// <value>The row header selected style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The selected row header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual OpacityValue SelectedRowHeaderOpacity
    {
      get => this.GetValue<OpacityValue>(nameof (SelectedRowHeaderOpacity), new OpacityValue(this.DefaultSelectedRowHeaderOpacity));
      set
      {
        if (value.Opacity < 0 || value.Opacity > 100)
          throw new Exception("You must supply values between 1 and 100.");
        this.SetValue(nameof (SelectedRowHeaderOpacity), (object) value);
      }
    }

    /// <summary>Gets the default selected row header opacity.</summary>
    /// <value>The default selected row header opacity.</value>
    protected virtual int DefaultSelectedRowHeaderOpacity => 60;

    /// <summary>Gets the column header normal style.</summary>
    /// <value>The row column normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal row column style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ColumnHeaderNormalStyle => (StyleValue) new DataGridViewSkin.GridStyleValue(this, nameof (ColumnHeaderNormalStyle));

    /// <summary>Gets the left top header normal style.</summary>
    /// <value>The left top header normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The left top header normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinValue<StyleValue> LeftTopHeaderNormalStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.LeftTopHeaderNormalStyleLTR, this.LeftTopHeaderNormalStyleRTL);

    /// <summary>Gets the left top header normal style LTR.</summary>
    /// <value>The left top header normal style LTR.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Gizmox.WebGUI.Forms.SRDescription("The LeftToRight left top header normal style.")]
    protected virtual StyleValue LeftTopHeaderNormalStyleLTR => (StyleValue) new DataGridViewSkin.GridStyleValue(this, nameof (LeftTopHeaderNormalStyleLTR));

    /// <summary>Gets the left top header normal style RTL.</summary>
    /// <value>The left top header normal style RTL.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Gizmox.WebGUI.Forms.SRDescription("The RightToLeft left top header normal style.")]
    protected virtual StyleValue LeftTopHeaderNormalStyleRTL => (StyleValue) new DataGridViewSkin.GridStyleValue(this, nameof (LeftTopHeaderNormalStyleRTL));

    /// <summary>Gets the cell normal style.</summary>
    /// <value>The cell normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal cell style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CellNormalStyle => new StyleValue((CommonSkin) this, nameof (CellNormalStyle));

    /// <summary>Gets the color of the cell normal style fore color .</summary>
    /// <value>The color of the cell normal style fore.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Color CellNormalStyleForeColor => this.CellNormalStyle.ForeColor;

    /// <summary>Gets the cell alternative style.</summary>
    /// <value>The cell alternative style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The alternative cell style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual StyleValue CellAlternativeStyle => new StyleValue((CommonSkin) this, nameof (CellAlternativeStyle), this.CellNormalStyle);

    /// <summary>Gets the cell selected style.</summary>
    /// <value>The cell selected style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The selected cell style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CellSelectedStyle => new StyleValue((CommonSkin) this, nameof (CellSelectedStyle), this.CellNormalStyle);

    /// <summary>Gets or sets the grid lines style.</summary>
    /// <value></value>
    [Category("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("The color of the grid lines style.")]
    public virtual BorderStyle GridLinesStyle
    {
      get => this.GetValue<BorderStyle>(nameof (GridLinesStyle), BorderStyle.FixedSingle);
      set => this.SetValue(nameof (GridLinesStyle), (object) value);
    }

    /// <summary>
    /// Gets the width of the drop indicator down arrow image.
    /// </summary>
    /// <value>The width of the drop indicator down arrow image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DropIndicatorDownArrowImageWidth => this.GetImageWidth(this.DropIndicatorStyle.BackgroundImage);

    /// <summary>
    /// Gets the height of the drop indicator down arrow image.
    /// </summary>
    /// <value>The height of the drop indicator down arrow image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int DropIndicatorDownArrowImageHeight => this.GetImageHeight(this.DropIndicatorStyle.BackgroundImage);

    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The grouping drop area height.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual int DropAreaHeight
    {
      get => this.GetValue<int>(nameof (DropAreaHeight), 100);
      set => this.SetValue(nameof (DropAreaHeight), (object) value);
    }

    /// <summary>Gets the width of the filter clear button image.</summary>
    /// <value>The width of the filter clear button image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int FilterClearButtonImageWidth => this.GetImageWidth(this.FilterRowClearButtonStyle.BackgroundImage);

    /// <summary>Gets the height of the filter clear button image.</summary>
    /// <value>The height of the filter clear button image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int FilterClearButtonImageHeight => this.GetImageHeight(this.FilterRowClearButtonStyle.BackgroundImage);

    /// <summary>Gets or sets the clear all filters button margin.</summary>
    /// <value>The clear all filters button margin.</value>
    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The \"Clear All Filters\" button margin.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int ClearAllFiltersButtonMargin
    {
      get => this.GetValue<int>(nameof (ClearAllFiltersButtonMargin), 5);
      set => this.SetValue(nameof (ClearAllFiltersButtonMargin), (object) value);
    }

    /// <summary>Gets or sets the width of the grid lines.</summary>
    /// <value></value>
    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The width of the grid lines.")]
    public virtual BorderWidth GridLinesWidth
    {
      get => this.GetValue<BorderWidth>(nameof (GridLinesWidth), this.DefaultGridLinesWidth);
      set => this.SetValue(nameof (GridLinesWidth), (object) value);
    }

    /// <summary>Resets the width of the grid lines.</summary>
    private void ResetGridLinesWidth() => this.Reset("GridLinesWidth");

    /// <summary>Gets the default width of the grid lines.</summary>
    /// <value>The default width of the grid lines.</value>
    protected virtual BorderWidth DefaultGridLinesWidth => new BorderWidth(1);

    /// <summary>Gets or sets the grid lines color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("The color of the grid lines.")]
    public Color GridLinesColor
    {
      get => this.GetValue<Color>(nameof (GridLinesColor), this.DefaultGridLinesColor);
      set => this.SetValue(nameof (GridLinesColor), (object) value);
    }

    /// <summary>Resets the color of the grid lines.</summary>
    private void ResetGridLinesColor() => this.Reset("GridLinesColor");

    /// <summary>Gets the default color of the grid lines.</summary>
    /// <value>The default color of the grid lines.</value>
    protected virtual Color DefaultGridLinesColor => Color.FromArgb(208, 215, 229);

    /// <summary>Gets the grid lines style which can be translated.</summary>
    /// <value>The grid lines style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderValue GridLines => new BorderValue()
    {
      Color = (BorderColor) this.GridLinesColor,
      Style = this.GridLinesStyle,
      Width = this.GridLinesWidth
    };

    /// <summary>Gets or sets the height of the paging control.</summary>
    /// <value>The height of the paging control.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging control height.")]
    public virtual int PagingPanelHeight
    {
      get => this.GetValue<int>(nameof (PagingPanelHeight), this.GetImageHeight(this.PagingPanelStyle.BackgroundImage, this.DefaultPagingPanelHeight));
      set => this.SetValue(nameof (PagingPanelHeight), (object) value);
    }

    /// <summary>Resets the height of the paging panel.</summary>
    internal void ResetPagingPanelHeight() => this.Reset("PagingPanelHeight");

    /// <summary>Gets the default height of the paging panel.</summary>
    /// <value>The default height of the paging panel.</value>
    protected virtual int DefaultPagingPanelHeight => 21;

    /// <summary>Gets or sets the width of the paging first button.</summary>
    /// <value>The width of the paging first button.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging first button width.")]
    public virtual int PagingFirstButtonWidth
    {
      get => this.GetValue<int>(nameof (PagingFirstButtonWidth), this.DefaultPagingFirstButtonWidth);
      set => this.SetValue(nameof (PagingFirstButtonWidth), (object) value);
    }

    /// <summary>Resets the width of the paging first button.</summary>
    internal void ResetPagingFirstButtonWidth() => this.Reset("PagingFirstButtonWidth");

    /// <summary>Gets the default width of the paging first button.</summary>
    /// <value>The default width of the paging first button.</value>
    protected virtual int DefaultPagingFirstButtonWidth => 20;

    /// <summary>Gets or sets the width of the paging last button.</summary>
    /// <value>The width of the paging last button.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging last button width.")]
    public virtual int PagingLastButtonWidth
    {
      get => this.GetValue<int>(nameof (PagingLastButtonWidth), this.DefaultPagingLastButtonWidth);
      set => this.SetValue(nameof (PagingLastButtonWidth), (object) value);
    }

    /// <summary>Resets the width of the paging last button.</summary>
    internal void ResetPagingLastButtonWidth() => this.Reset("PagingLastButtonWidth");

    /// <summary>Gets the default width of the paging last button.</summary>
    /// <value>The default width of the paging last button.</value>
    protected virtual int DefaultPagingLastButtonWidth => 20;

    /// <summary>Gets or sets the width of the paging previous button.</summary>
    /// <value>The width of the paging previous button.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging previous button width.")]
    public virtual int PagingPreviousButtonWidth
    {
      get => this.GetValue<int>(nameof (PagingPreviousButtonWidth), this.DefaultPagingPreviousButtonWidth);
      set => this.SetValue(nameof (PagingPreviousButtonWidth), (object) value);
    }

    /// <summary>Resets the width of the paging previous button.</summary>
    internal void ResetPagingPreviousButtonWidth() => this.Reset("PagingPreviousButtonWidth");

    /// <summary>Gets the default width of the paging previous button.</summary>
    /// <value>The default width of the paging previous button.</value>
    protected virtual int DefaultPagingPreviousButtonWidth => 20;

    /// <summary>Gets or sets the width of the paging next button.</summary>
    /// <value>The width of the paging next button.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging next button width.")]
    public virtual int PagingNextButtonWidth
    {
      get => this.GetValue<int>(nameof (PagingNextButtonWidth), this.DefaultPagingNextButtonWidth);
      set => this.SetValue(nameof (PagingNextButtonWidth), (object) value);
    }

    /// <summary>Resets the width of the paging next button.</summary>
    internal void ResetPagingNextButtonWidth() => this.Reset("PagingNextButtonWidth");

    /// <summary>Gets the default width of the paging next button.</summary>
    /// <value>The default width of the paging next button.</value>
    protected virtual int DefaultPagingNextButtonWidth => 20;

    /// <summary>Gets or sets the width of the paging box.</summary>
    /// <value>The width of the paging box.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging box width.")]
    public virtual int PagingBoxWidth
    {
      get => this.GetValue<int>(nameof (PagingBoxWidth), this.DefaultPagingBoxWidth);
      set => this.SetValue(nameof (PagingBoxWidth), (object) value);
    }

    /// <summary>Resets the width of the paging box.</summary>
    internal void ResetPagingBoxWidth() => this.Reset("PagingBoxWidth");

    /// <summary>Gets the default width of the paging box.</summary>
    /// <value>The default width of the paging box.</value>
    protected virtual int DefaultPagingBoxWidth => 50;

    /// <summary>Gets the 'GoTo' box style.</summary>
    /// <value>The 'GoTo' box style.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The current page / 'Go To' box style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PagingGotoBoxStyle => new StyleValue((CommonSkin) this, nameof (PagingGotoBoxStyle));

    /// <summary>Gets the paging panel style.</summary>
    /// <value>The paging panel style.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The pagging panel style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PagingPanelStyle => new StyleValue((CommonSkin) this, nameof (PagingPanelStyle));

    /// <summary>Gets the paging prev button style.</summary>
    /// <value>The paging prev button style.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging prev button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PagingPrevButtonStyle => new StyleValue((CommonSkin) this, nameof (PagingPrevButtonStyle));

    /// <summary>Gets the paging next button style.</summary>
    /// <value>The paging next button style.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging next button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PagingNextButtonStyle => new StyleValue((CommonSkin) this, nameof (PagingNextButtonStyle));

    /// <summary>Gets the paging last button style.</summary>
    /// <value>The paging last button style.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging last button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PagingLastButtonStyle => new StyleValue((CommonSkin) this, nameof (PagingLastButtonStyle));

    /// <summary>Gets the paging first button style.</summary>
    /// <value>The paging first button style.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging first button style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue PagingFirstButtonStyle => new StyleValue((CommonSkin) this, nameof (PagingFirstButtonStyle));

    /// <summary>Gets the bidirectional paging last button style.</summary>
    /// <value>The bidirectional paging last button style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue BidirectionalPagingLastButtonStyle => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.PagingLastButtonStyle, this.PagingFirstButtonStyle);

    /// <summary>Gets the bidirectional paging first button style.</summary>
    /// <value>The bidirectional paging first button style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue BidirectionalPagingFirstButtonStyle => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.PagingFirstButtonStyle, this.PagingLastButtonStyle);

    /// <summary>Gets the bidirectional paging prev button style.</summary>
    /// <value>The bidirectional paging prev button style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue BidirectionalPagingPrevButtonStyle => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.PagingPrevButtonStyle, this.PagingNextButtonStyle);

    /// <summary>Gets the bidirectional paging next button style.</summary>
    /// <value>The bidirectional paging next button style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkinValue BidirectionalPagingNextButtonStyle => (SkinValue) new BidirectionalSkinValue<StyleValue>((Skin) this, this.PagingNextButtonStyle, this.PagingPrevButtonStyle);

    /// <summary>Gets or sets the paging number seperator format.</summary>
    /// <value>The paging number seperator format.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The paging number seperator format.")]
    public string PagingNumberSeperatorFormat
    {
      get => this.GetValue<string>(nameof (PagingNumberSeperatorFormat), this.DefaultPagingNumberSeperatorFormat);
      set => this.SetValue(nameof (PagingNumberSeperatorFormat), (object) value);
    }

    /// <summary>Gets the default paging number seperator format.</summary>
    public string DefaultPagingNumberSeperatorFormat => "/";

    /// <summary>Gets or sets the equals comparision operator.</summary>
    /// <value>The equals comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The equals comparison operator.")]
    public virtual ImageResourceReference EqualsComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (EqualsComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (EqualsComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the not equals comparision operator.</summary>
    /// <value>The not equals comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The NotEquals comparison operator.")]
    public virtual ImageResourceReference NotEqualsComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (NotEqualsComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (NotEqualsComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the initial operator image.</summary>
    /// <value>The initial operator image.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The initial operator image.")]
    public virtual ImageResourceReference InitialOperatorImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (InitialOperatorImage), (ImageResourceReference) "");
      set => this.SetValue(nameof (InitialOperatorImage), (object) value);
    }

    /// <summary>Gets or sets the less than comparision operator.</summary>
    /// <value>The less than comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The LessThan comparison operator.")]
    public virtual ImageResourceReference LessThanComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (LessThanComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (LessThanComparisionOperator), (object) value);
    }

    /// <summary>
    /// Gets or sets the less than or equal to comparision operator.
    /// </summary>
    /// <value>The less than or equal to comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The LessThanOrEqualTo comparison operator.")]
    public virtual ImageResourceReference LessThanOrEqualToComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (LessThanOrEqualToComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (LessThanOrEqualToComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the greater than comparision operator.</summary>
    /// <value>The greater than comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The GreaterThan comparison operator.")]
    public virtual ImageResourceReference GreaterThanComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (GreaterThanComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (GreaterThanComparisionOperator), (object) value);
    }

    /// <summary>
    /// Gets or sets the greater than or equal to comparision operator.
    /// </summary>
    /// <value>The greater than or equal to comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The GreaterThanOrEqualTo comparison operator.")]
    public virtual ImageResourceReference GreaterThanOrEqualToComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (GreaterThanOrEqualToComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (GreaterThanOrEqualToComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the like comparision operator.</summary>
    /// <value>The like comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The Like comparison operator.")]
    public virtual ImageResourceReference LikeComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (LikeComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (LikeComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the match comparision operator.</summary>
    /// <value>The match comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The Match comparison operator.")]
    public virtual ImageResourceReference MatchComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (MatchComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (MatchComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the not like comparision operator.</summary>
    /// <value>The not like comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The NotLike comparison operator.")]
    public virtual ImageResourceReference NotLikeComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (NotLikeComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (NotLikeComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the does not match comparision operator.</summary>
    /// <value>The does not match comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The DoesNotMatch comparison operator.")]
    public virtual ImageResourceReference DoesNotMatchComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (DoesNotMatchComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (DoesNotMatchComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the starts with comparision operator.</summary>
    /// <value>The starts with comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The StartsWith comparison operator.")]
    public virtual ImageResourceReference StartsWithComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (StartsWithComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (StartsWithComparisionOperator), (object) value);
    }

    /// <summary>
    /// Gets or sets the does not start with comparision operator.
    /// </summary>
    /// <value>The does not start with comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The DoesNotStartWith comparison operator.")]
    public virtual ImageResourceReference DoesNotStartWithComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (DoesNotStartWithComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (DoesNotStartWithComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the ends with comparision operator.</summary>
    /// <value>The ends with comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The EndsWith comparison operator.")]
    public virtual ImageResourceReference EndsWithComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (EndsWithComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (EndsWithComparisionOperator), (object) value);
    }

    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The DoesNotEndWith comparison operator.")]
    public virtual ImageResourceReference DoesNotEndWithComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (DoesNotEndWithComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (DoesNotEndWithComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the contains comparision operator.</summary>
    /// <value>The contains comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The Contains comparison operator.")]
    public virtual ImageResourceReference ContainsComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (ContainsComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (ContainsComparisionOperator), (object) value);
    }

    /// <summary>
    /// Gets or sets the does not contain comparision operator.
    /// </summary>
    /// <value>The does not contain comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The DoesNotContain comparison operator.")]
    public virtual ImageResourceReference DoesNotContainComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (DoesNotContainComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (DoesNotContainComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the custom comparision operator.</summary>
    /// <value>The custom comparision operator.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The Custom comparison operator.")]
    public virtual ImageResourceReference CustomComparisionOperator
    {
      get => this.GetValue<ImageResourceReference>(nameof (CustomComparisionOperator), (ImageResourceReference) "");
      set => this.SetValue(nameof (CustomComparisionOperator), (object) value);
    }

    /// <summary>Gets or sets the filter clear button image.</summary>
    /// <value>The filter clear button image.</value>
    [Gizmox.WebGUI.Forms.SRCategory("Images")]
    [Gizmox.WebGUI.Forms.SRDescription("The filter clear button image.")]
    public virtual ImageResourceReference FilterCellClearButtonImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (FilterCellClearButtonImage), (ImageResourceReference) "");
      set => this.SetValue(nameof (FilterCellClearButtonImage), (object) value);
    }

    /// <summary>Gets the width of the header filter combo box image.</summary>
    /// <value>The width of the header filter combo box image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual SkinValue HeaderFilterComboBoxImageWidth => SkinFactory.GetSkin(this.Owner, typeof (DataGridViewHeaderFilterComboBoxSkin)) is DataGridViewHeaderFilterComboBoxSkin skin ? skin.FilterNormalImageWidth : (SkinValue) null;

    /// <summary>Gets the sort ascending indicator image.</summary>
    [Category("Images")]
    [Description("The column sorted ascending indicator image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual ImageResourceReference SortAscendingIndicatorImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (SortAscendingIndicatorImage), new ImageResourceReference(typeof (DataGridViewSkin), "ArrowUp.gif"));
      set => this.SetValue(nameof (SortAscendingIndicatorImage), (object) value);
    }

    /// <summary>Gets the sort descending indicator image.</summary>
    [Category("Images")]
    [Description("The column sorted descending indicator image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual ImageResourceReference SortDescendingIndicatorImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (SortDescendingIndicatorImage), new ImageResourceReference(typeof (DataGridViewSkin), "ArrowDown.gif"));
      set => this.SetValue(nameof (SortDescendingIndicatorImage), (object) value);
    }

    [Category("Images")]
    [Description("The row header edit mode Image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> RowHeaderEditModeImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "RowHeaderEditModeImageLTR", "RowHeaderEditModeImageRTL");

    /// <summary>Gets or sets the drop down over image LTR.</summary>
    /// <value>The drop down over image LTR.</value>
    [Description("The row header edit mode left to right over image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference RowHeaderEditModeImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (RowHeaderEditModeImageLTR), new ImageResourceReference(typeof (DataGridViewSkin), "DGVEditedModeLTR.gif"));
      set => this.SetValue(nameof (RowHeaderEditModeImageLTR), (object) value);
    }

    /// <summary>Gets or sets the drop down over image RTL.</summary>
    /// <value>The drop down over image RTL.</value>
    [Description("The row header edit mode right to left over image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference RowHeaderEditModeImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (RowHeaderEditModeImageRTL), new ImageResourceReference(typeof (DataGridViewSkin), "DGVEditedModeRTL.gif"));
      set => this.SetValue(nameof (RowHeaderEditModeImageRTL), (object) value);
    }

    [Category("Images")]
    [Description("The row header Selected mode Image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public BidirectionalSkinProperty<ImageResourceReference> RowHeaderSelectedModeImage => new BidirectionalSkinProperty<ImageResourceReference>((Skin) this, "RowHeaderSelectedModeImageLTR", "RowHeaderSelectedModeImageRTL");

    /// <summary>Gets or sets the drop down over image LTR.</summary>
    /// <value>The drop down over image LTR.</value>
    [Description("The row header Selected mode left to right over image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference RowHeaderSelectedModeImageLTR
    {
      get => this.GetValue<ImageResourceReference>(nameof (RowHeaderSelectedModeImageLTR), new ImageResourceReference(typeof (DataGridViewSkin), "DGVSelectedModeLTR.gif"));
      set => this.SetValue(nameof (RowHeaderSelectedModeImageLTR), (object) value);
    }

    /// <summary>Gets or sets the drop down over image RTL.</summary>
    /// <value>The drop down over image RTL.</value>
    [Description("The row header Selected mode right to left over image")]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ImageResourceReference RowHeaderSelectedModeImageRTL
    {
      get => this.GetValue<ImageResourceReference>(nameof (RowHeaderSelectedModeImageRTL), new ImageResourceReference(typeof (DataGridViewSkin), "DGVSelectedModeRTL.gif"));
      set => this.SetValue(nameof (RowHeaderSelectedModeImageRTL), (object) value);
    }

    /// <summary>Gets or sets the row header new row mode image.</summary>
    /// <value>The row header new row mode image.</value>
    [Category("Images")]
    [Description("The row header new row mode Image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual ImageResourceReference RowHeaderNewRowModeImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (RowHeaderNewRowModeImage), new ImageResourceReference(typeof (DataGridViewSkin), "DGVNewRowMode.gif"));
      set => this.SetValue(nameof (RowHeaderNewRowModeImage), (object) value);
    }

    /// <summary>Gets or sets the row header error provider image.</summary>
    /// <value>The row header error provider image.</value>
    [Category("Images")]
    [Description("The row header error Image.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual ImageResourceReference RowHeaderErrorProviderImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (RowHeaderErrorProviderImage), new ImageResourceReference(typeof (DataGridViewSkin), "ErrorProvider.gif"));
      set => this.SetValue(nameof (RowHeaderErrorProviderImage), (object) value);
    }

    /// <summary>Gets the size of the sort ascending indicator image.</summary>
    /// <value>The size of the sort ascending indicator image.</value>
    internal Size SortAscendingIndicatorImageSize => this.GetImageSize(this.SortAscendingIndicatorImage, Size.Empty);

    /// <summary>Gets the size of the sort descending indicator image.</summary>
    /// <value>The size of the sort descending indicator image.</value>
    internal Size SortDescendingIndicatorImageSize => this.GetImageSize(this.SortDescendingIndicatorImage, Size.Empty);

    /// <summary>Gets the size of the image.</summary>
    /// <param name="strImageFileName">Name of the STR image file.</param>
    /// <returns></returns>
    internal Size GetImageSize(string strImageFileName) => !string.IsNullOrEmpty(strImageFileName) ? this.GetImageSize(new ImageResourceReference(typeof (DataGridViewSkin), strImageFileName), Size.Empty) : Size.Empty;

    /// <summary>Gets or sets the width of the expand collapse column.</summary>
    /// <value>The width of the expand collapse column.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int ExpandCollapseColumnWidth => Math.Max(Math.Max(this.ExpandButtonImageWidth + this.ExpandButtonImageStyle.Padding.Horizontal, this.CollapseButtonImageWidth + this.CollapseButtonImageStyle.Padding.Horizontal), this.EmptyExpandCollapseImageWidth + this.EmptyExpandCollapseImageStyle.Padding.Horizontal);

    /// <summary>Gets the expand button image style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The expand button image style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue EmptyExpandCollapseImageStyle => new StyleValue((CommonSkin) this, nameof (EmptyExpandCollapseImageStyle));

    /// <summary>Gets the width of the expand button image.</summary>
    /// <value>The width of the expand button image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal int EmptyExpandCollapseImageWidth => this.GetImageSize(this.EmptyExpandCollapseImageStyle.BackgroundImage, Size.Empty).Width;

    /// <summary>Gets the expand button image style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The column chooser style")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ColumnChooserStyle => new StyleValue((CommonSkin) this, nameof (ColumnChooserStyle));

    /// <summary>Gets the expand button image style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The expand button image style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ExpandButtonImageStyle => new StyleValue((CommonSkin) this, nameof (ExpandButtonImageStyle));

    /// <summary>Gets the width of the expand button image.</summary>
    /// <value>The width of the expand button image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal int ExpandButtonImageWidth => this.GetImageSize(this.ExpandButtonImageStyle.BackgroundImage, Size.Empty).Width;

    /// <summary>Gets the collapse button image style.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The collapse button image style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue CollapseButtonImageStyle => new StyleValue((CommonSkin) this, nameof (CollapseButtonImageStyle));

    /// <summary>Gets the width of the collapse button image.</summary>
    /// <value>The width of the collapse button image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal int CollapseButtonImageWidth => this.GetImageSize(this.CollapseButtonImageStyle.BackgroundImage, Size.Empty).Width;

    /// <summary>Gets the row header style for the expanded grid.</summary>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The row header for the expanded Data Grid View.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public StyleValue ExpandedRowHeaderStyle => new StyleValue((CommonSkin) this, nameof (ExpandedRowHeaderStyle));

    [Serializable]
    public class GridStyleValue : StyleValue
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.DataGridViewSkin.GridStyleValue" /> class.
      /// </summary>
      /// <param name="objPropertyOwner">The property owner.</param>
      /// <param name="strPropertyPrefix">The property prefix.</param>
      public GridStyleValue(DataGridViewSkin objPropertyOwner, string strPropertyPrefix)
        : base((CommonSkin) objPropertyOwner, strPropertyPrefix)
      {
      }

      /// <summary>Gets or sets the default border width.</summary>
      /// <value></value>
      protected override BorderColor DefaultBorderColor => this.DataGridViewSkin != null ? (BorderColor) this.DataGridViewSkin.GridLinesColor : base.DefaultBorderColor;

      /// <summary>Gets or sets the default border style.</summary>
      /// <value></value>
      protected override BorderStyle DefaultBorderStyle => this.DataGridViewSkin != null ? this.DataGridViewSkin.GridLinesStyle : base.DefaultBorderStyle;

      /// <summary>Gets or sets the default border width.</summary>
      /// <value></value>
      protected override BorderWidth DefaultBorderWidth => this.DataGridViewSkin != null ? this.DataGridViewSkin.GridLinesWidth : base.DefaultBorderWidth;

      /// <summary>Gets the property grid skin.</summary>
      /// <value>The property grid skin.</value>
      private DataGridViewSkin DataGridViewSkin => this.Skin as DataGridViewSkin;
    }
  }
}

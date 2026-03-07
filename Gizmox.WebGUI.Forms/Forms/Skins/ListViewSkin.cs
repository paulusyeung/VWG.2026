// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.ListViewSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>ListView Skin</summary>
  [ToolboxBitmap(typeof (ListView), "ListView.bmp")]
  [Serializable]
  public class ListViewSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets or sets the height of the large item label.</summary>
    /// <value>The height of the large item label.</value>
    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The height of a large item label.")]
    public int LargeItemLabelHeight
    {
      get => this.GetValue<int>(nameof (LargeItemLabelHeight), 27);
      set => this.SetValue(nameof (LargeItemLabelHeight), (object) value);
    }

    /// <summary>Gets or sets the color of the row back.</summary>
    /// <value>The color of the row back.</value>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("The row backcolor.")]
    public virtual Color RowBackColor
    {
      get => this.GetValue<Color>(nameof (RowBackColor), this.DefaultRowBackColor);
      set => this.SetValue(nameof (RowBackColor), (object) value);
    }

    /// <summary>Resets the color of the row back.</summary>
    internal void ResetRowBackColor() => this.Reset("RowBackColor");

    /// <summary>Gets the default color of the row back.</summary>
    /// <value>The default color of the row back.</value>
    protected virtual Color DefaultRowBackColor => SystemColors.Window;

    /// <summary>Gets or sets the color of the row fore.</summary>
    /// <value>The color of the row fore.</value>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("The row fore color.")]
    public virtual Color RowForeColor
    {
      get => this.GetValue<Color>(nameof (RowForeColor), this.DefaultRowForeColor);
      set => this.SetValue(nameof (RowForeColor), (object) value);
    }

    /// <summary>Resets the color of the row fore.</summary>
    internal void ResetRowForeColor() => this.Reset("RowForeColor");

    /// <summary>Gets the default color of the row fore.</summary>
    /// <value>The default color of the row fore.</value>
    protected virtual Color DefaultRowForeColor => SystemColors.WindowText;

    /// <summary>Gets or sets the row font.</summary>
    /// <value>The row font.</value>
    [Category("Fonts")]
    [Gizmox.WebGUI.Forms.SRDescription("The row font.")]
    public virtual Font RowFont
    {
      get => this.GetValue<Font>(nameof (RowFont), this.DefaultRowFont);
      set => this.SetValue(nameof (RowFont), (object) value);
    }

    /// <summary>Resets the row font.</summary>
    internal void ResetRowFont() => this.Reset("RowFont");

    /// <summary>Gets the default row font.</summary>
    /// <value>The default row font.</value>
    protected virtual Font DefaultRowFont => this.Font;

    /// <summary>Gets the width of the header seperator.</summary>
    /// <value>The width of the header seperator.</value>
    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The width of the header seperator.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual int HeaderSeperatorWidth
    {
      get => this.GetValue<int>(nameof (HeaderSeperatorWidth), this.DefaultHeaderSeperatorWidth);
      set => this.SetValue(nameof (HeaderSeperatorWidth), (object) value);
    }

    /// <summary>Resets the width of the header seperator.</summary>
    internal void ResetHeaderSeperatorWidth() => this.Reset("HeaderSeperatorWidth");

    /// <summary>Gets the default width of the header seperator.</summary>
    /// <value>The default width of the header seperator.</value>
    protected virtual int DefaultHeaderSeperatorWidth => 3;

    /// <summary>Gets the height of the check box button.</summary>
    /// <value>The height of the check box button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CheckBoxButtonHeight => this.GetMaxImageHeight(this.DefaultCheckBoxButtonHeight, "CheckBox0.gif", "CheckBox1.gif");

    /// <summary>Resets the height of the check box button.</summary>
    private void ResetCheckBoxButtonHeight() => this.Reset("CheckBoxButtonHeight");

    /// <summary>Gets the default height of the check box button.</summary>
    /// <value>The default height of the check box button.</value>
    protected virtual int DefaultCheckBoxButtonHeight => 13;

    /// <summary>Gets the width of the check box button.</summary>
    /// <value>The width of the check box button.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual int CheckBoxButtonWidth => this.GetMaxImageWidth(this.DefaultCheckBoxButtonWidth, "CheckBox0.gif", "CheckBox1.gif");

    /// <summary>Resets the width of the check box button.</summary>
    private void ResetCheckBoxButtonWidth() => this.Reset("CheckBoxButtonWidth");

    /// <summary>Gets the default width of the check box button.</summary>
    /// <value>The default width of the check box button.</value>
    protected virtual int DefaultCheckBoxButtonWidth => 13;

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
    internal void ResetGridLinesWidth() => this.Reset("GridLinesWidth");

    /// <summary>Gets the default width of the grid lines.</summary>
    /// <value>The default width of the grid lines.</value>
    protected virtual BorderWidth DefaultGridLinesWidth => new BorderWidth(1);

    /// <summary>Gets the cell normal style.</summary>
    /// <value>The cell normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal cell style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CellNormalStyle => new StyleValue((CommonSkin) this, nameof (CellNormalStyle));

    /// <summary>Gets the cell alternative style.</summary>
    /// <value>The cell alternative style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The alternative cell style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CellAlternativeStyle => new StyleValue((CommonSkin) this, nameof (CellAlternativeStyle));

    /// <summary>Gets the cell selected style.</summary>
    /// <value>The cell selected style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The selected cell style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CellSelectedStyle => new StyleValue((CommonSkin) this, nameof (CellSelectedStyle));

    /// <summary>Gets the header normal style.</summary>
    /// <value>The header normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderNormalStyle => new StyleValue((CommonSkin) this, nameof (HeaderNormalStyle));

    /// <summary>Gets the header hover style.</summary>
    /// <value>The header hover style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The hover header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderHoverStyle => new StyleValue((CommonSkin) this, nameof (HeaderHoverStyle), this.HeaderNormalStyle);

    /// <summary>Gets the header pressed style.</summary>
    /// <value>The header pressed style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The pressed header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderPressedStyle => new StyleValue((CommonSkin) this, nameof (HeaderPressedStyle), this.HeaderNormalStyle);

    /// <summary>Gets the header disabled style.</summary>
    /// <value>The header disabled style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderDisabledStyle => new StyleValue((CommonSkin) this, nameof (HeaderDisabledStyle), this.HeaderNormalStyle);

    /// <summary>Gets the header seperator normal style.</summary>
    /// <value>The header seperator normal style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal header seperator style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderSeperatorNormalStyle => new StyleValue((CommonSkin) this, nameof (HeaderSeperatorNormalStyle));

    /// <summary>Gets the header seperator hover style.</summary>
    /// <value>The header seperator hover style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The hover header seperator style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderSeperatorHoverStyle => new StyleValue((CommonSkin) this, nameof (HeaderSeperatorHoverStyle), this.HeaderNormalStyle);

    /// <summary>Gets the header seperator pressed style.</summary>
    /// <value>The header seperator pressed style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The pressed header seperator style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderSeperatorPressedStyle => new StyleValue((CommonSkin) this, nameof (HeaderSeperatorPressedStyle), this.HeaderNormalStyle);

    /// <summary>Gets the header seperator disabled style.</summary>
    /// <value>The header seperator disabled style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The normal header seperator style.")]
    public virtual StyleValue HeaderSeperatorDisabledStyle => new StyleValue((CommonSkin) this, nameof (HeaderSeperatorDisabledStyle), this.HeaderNormalStyle);

    /// <summary>Gets or sets the grid lines style.</summary>
    /// <value></value>
    [Category("Styles")]
    [Gizmox.WebGUI.Forms.SRDescription("The color of the grid lines style.")]
    public virtual BorderStyle GridLinesStyle
    {
      get => this.GetValue<BorderStyle>(nameof (GridLinesStyle), BorderStyle.FixedSingle);
      set => this.SetValue(nameof (GridLinesStyle), (object) value);
    }

    /// <summary>Resets the grid lines style.</summary>
    internal void ResetGridLinesStyle() => this.Reset("GridLinesStyle");

    /// <summary>Gets or sets the group header seperator color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Description("The color which is used to display group header seperator.")]
    public virtual Color GroupHeaderSeperatorColor
    {
      get => this.GetValue<Color>(nameof (GroupHeaderSeperatorColor), this.DefaultGroupHeaderSeperatorColor);
      set => this.SetValue(nameof (GroupHeaderSeperatorColor), (object) value);
    }

    /// <summary>Resets the color of the group header seperator.</summary>
    internal void ResetGroupHeaderSeperatorColor() => this.Reset("GroupHeaderSeperatorColor");

    /// <summary>Gets the default color of the group header seperator.</summary>
    /// <value>The default color of the group header seperator.</value>
    protected virtual Color DefaultGroupHeaderSeperatorColor => Color.FromArgb(187, 190, 209);

    /// <summary>Gets the group header style.</summary>
    [Category("GroupHeader")]
    [Gizmox.WebGUI.Forms.SRDescription("The group header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue GroupHeaderStyle => new StyleValue((CommonSkin) this, nameof (GroupHeaderStyle));

    /// <summary>Resets the group header style.</summary>
    internal void ResetGroupHeaderStyle() => this.GroupHeaderStyle.Reset();

    /// <summary>Gets or sets the group header fore color.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Category("Colors")]
    [Description("The foreground color of this component, which is used to display group header text.")]
    [Obsolete("This property is obselete, Please use GroupHeaderStyle propert.y")]
    public virtual Color GroupHeaderForeColor
    {
      get => this.GetValue<Color>(nameof (GroupHeaderForeColor), this.DefaultGroupHeaderForeColor);
      set => this.SetValue(nameof (GroupHeaderForeColor), (object) value);
    }

    /// <summary>Resets the color of the group header fore.</summary>
    [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
    internal void ResetGroupHeaderForeColor() => this.Reset("GroupHeaderForeColor");

    /// <summary>Gets the default color of the group header fore.</summary>
    /// <value>The default color of the group header fore.</value>
    [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
    protected virtual Color DefaultGroupHeaderForeColor => Color.FromArgb(36, 62, 137);

    /// <summary>Gets or sets the grid lines color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("The color of the grid lines.")]
    public virtual Color GridLinesColor
    {
      get => this.GetValue<Color>(nameof (GridLinesColor), this.DefaultGridLinesColor);
      set => this.SetValue(nameof (GridLinesColor), (object) value);
    }

    /// <summary>Resets the color of the grid lines.</summary>
    internal void ResetGridLinesColor() => this.Reset("GridLinesColor");

    /// <summary>Gets the default color of the grid lines.</summary>
    /// <value>The default color of the grid lines.</value>
    protected virtual Color DefaultGridLinesColor => Color.FromArgb(213, 213, 213);

    /// <summary>Gets or sets the sorted column background color.</summary>
    /// <value></value>
    [Category("Colors")]
    [Gizmox.WebGUI.Forms.SRDescription("The sorted column background color.")]
    public virtual Color SortedColumnBackColor
    {
      get => this.GetAmbientValue<Color>(nameof (SortedColumnBackColor), this.DefaultSortedColumnBackColor);
      set => this.SetValue(nameof (SortedColumnBackColor), (object) value);
    }

    /// <summary>Resets the color of the sorted column back.</summary>
    internal void ResetSortedColumnBackColor() => this.Reset("SortedColumnBackColor");

    /// <summary>Gets the default color of the sorted column back.</summary>
    /// <value>The default color of the sorted column back.</value>
    protected virtual Color DefaultSortedColumnBackColor => Color.FromArgb(247, 247, 247);

    /// <summary>Gets the group header seperator background.</summary>
    /// <value>The group header seperator background.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundValue GroupHeaderSeperatorBackground => new BackgroundValue()
    {
      BackColor = this.GroupHeaderSeperatorColor
    };

    /// <summary>
    /// Gets or sets the font of the group header text displayed by the control.
    /// </summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Category("Fonts")]
    [Description("The font used to display group header text in the control.")]
    [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
    public virtual Font GroupHeaderFont
    {
      get => this.GetValue<Font>(nameof (GroupHeaderFont), this.DefaultGroupHeaderFont);
      set => this.SetValue(nameof (GroupHeaderFont), (object) value);
    }

    /// <summary>Resets the group header font.</summary>
    [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
    internal void ResetGroupHeaderFont() => this.Reset("GroupHeaderFont");

    /// <summary>Gets the default group header font.</summary>
    /// <value>The default group header font.</value>
    [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
    protected virtual Font DefaultGroupHeaderFont => new Font("Tahoma", 8.25f);

    /// <summary>Gets the group header foreground.</summary>
    /// <value>The group header foreground.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
    public virtual ForegroundValue GroupHeaderForeground => new ForegroundValue()
    {
      ForeColor = this.GroupHeaderForeColor
    };

    /// <summary>Gets the grid lines style which can be translated.</summary>
    /// <value>The grid lines style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BorderValue GridLines => new BorderValue()
    {
      Color = (BorderColor) this.GridLinesColor,
      Style = this.GridLinesStyle,
      Width = this.GridLinesWidth
    };

    /// <summary>
    /// Gets or sets a value indicating whether to show grid lines.
    /// </summary>
    /// <value><c>true</c> to show grid lines; otherwise, <c>false</c>.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The show grid lines.")]
    public virtual bool ShowGridLines
    {
      get => this.GetValue<bool>(nameof (ShowGridLines), this.DefaultShowGridLines);
      set => this.SetValue(nameof (ShowGridLines), (object) value);
    }

    /// <summary>Resets the show grid lines.</summary>
    private void ResetShowGridLines() => this.Reset("ShowGridLines");

    /// <summary>Gets the default show grid lines.</summary>
    /// <value>The default show grid lines.</value>
    protected virtual bool DefaultShowGridLines => false;

    /// <summary>Gets or sets the sorted column background image.</summary>
    /// <value>The sorted column background image.</value>
    [Gizmox.WebGUI.Forms.SRDescription("The sorted column background image")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public ImageResourceReference SortedColumnBackgroundImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (SortedColumnBackgroundImage), (ImageResourceReference) "");
      set => this.SetValue(nameof (SortedColumnBackgroundImage), (object) value);
    }

    /// <summary>Resets the sorted column background image.</summary>
    internal void ResetSortedColumnBackgroundImage() => this.Reset("SortedColumnBackgroundImage");

    /// <summary>
    /// Gets or sets the sorted column background image repeat.
    /// </summary>
    /// <value>The sorted column background image repeat.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets if or how a sorted column background image will be repeated.")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual BackgroundImageRepeat SortedColumnBackgroundImageRepeat
    {
      get => this.GetValue<BackgroundImageRepeat>(nameof (SortedColumnBackgroundImageRepeat), this.DefaultSortedColumnBackgroundImageRepeat);
      set => this.SetValue(nameof (SortedColumnBackgroundImageRepeat), (object) value);
    }

    /// <summary>Resets the sorted column background image repeat.</summary>
    internal void ResetSortedColumnBackgroundImageRepeat() => this.Reset("SortedColumnBackgroundImageRepeat");

    /// <summary>
    /// Gets the default sorted column background image repeat.
    /// </summary>
    /// <value>The default sorted column background image repeat.</value>
    protected virtual BackgroundImageRepeat DefaultSortedColumnBackgroundImageRepeat => BackgroundImageRepeat.Repeat;

    /// <summary>
    /// Gets or sets the sorted column background image position.
    /// </summary>
    /// <value>The sorted column background image position.</value>
    [Gizmox.WebGUI.Forms.SRDescription("Sets the starting position of a sorted column background image.")]
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    public virtual BackgroundImagePosition SortedColumnBackgroundImagePosition
    {
      get => this.GetValue<BackgroundImagePosition>(nameof (SortedColumnBackgroundImagePosition), this.DefaultSortedColumnBackgroundImagePosition);
      set => this.SetValue(nameof (SortedColumnBackgroundImagePosition), (object) value);
    }

    /// <summary>Resets the sorted column background image position.</summary>
    internal void ResetSortedColumnBackgroundImagePosition() => this.Reset("SortedColumnBackgroundImagePosition");

    /// <summary>
    /// Gets the default sorted column background image position.
    /// </summary>
    /// <value>The default sorted column background image position.</value>
    protected virtual BackgroundImagePosition DefaultSortedColumnBackgroundImagePosition => BackgroundImagePosition.TopLeft;

    /// <summary>Gets the sorted column background.</summary>
    /// <value>The sorted column background.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BackgroundValue SortedColumnBackground => new BackgroundValue()
    {
      BackColor = this.SortedColumnBackColor,
      BackgroundImage = this.SortedColumnBackgroundImage,
      BackgroundImagePosition = this.SortedColumnBackgroundImagePosition,
      BackgroundImageRepeat = this.SortedColumnBackgroundImageRepeat
    };

    /// <summary>Gets the item size for view.</summary>
    /// <param name="enmView">The list view view.</param>
    /// <returns></returns>
    internal Size GetItemSizeForView(View enmView)
    {
      switch (enmView)
      {
        case View.LargeIcon:
          return new Size(200, 200);
        case View.List:
          return new Size(100, 21);
        case View.SmallIcon:
          return new Size(130, 21);
        default:
          return Size.Empty;
      }
    }

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
    protected virtual int DefaultPagingPanelHeight => 22;

    /// <summary>Gets or sets the height of the header.</summary>
    /// <value>The height of the header.</value>
    [Category("Paging")]
    [Gizmox.WebGUI.Forms.SRDescription("The header height.")]
    public virtual int HeaderHeight
    {
      get => this.GetValue<int>(nameof (HeaderHeight), this.DefaultHeaderHeight);
      set => this.SetValue(nameof (HeaderHeight), (object) value);
    }

    /// <summary>Resets the height of the header.</summary>
    internal void ResetHeaderHeight() => this.Reset("HeaderHeight");

    /// <summary>Gets the default height of the header.</summary>
    /// <value>The default height of the header.</value>
    protected virtual int DefaultHeaderHeight => -1;

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
  }
}

// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.MonthCalendarSkin
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>MonthCalendar Skin</summary>
  [ToolboxBitmap(typeof (MonthCalendar), "MonthCalendar.bmp")]
  [Serializable]
  public class MonthCalendarSkin : ControlSkin
  {
    private void InitializeComponent()
    {
    }

    /// <summary>Gets the selected day style.</summary>
    /// <value>The selected day style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The style of the current day when selected.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue TodaySelectedStyle => new StyleValue((CommonSkin) this, nameof (TodaySelectedStyle), this.SelectedDayStyle);

    /// <summary>Gets the hover selected day style.</summary>
    /// <value>The hover selected day style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The hover style of the current day when selected.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverTodaySelectedStyle => new StyleValue((CommonSkin) this, nameof (HoverTodaySelectedStyle), this.HoverSelectedDayStyle);

    /// <summary>Gets the today style.</summary>
    /// <value>The today style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The style of the current day.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue TodayStyle => new StyleValue((CommonSkin) this, nameof (TodayStyle), this.NormalDayStyle);

    /// <summary>Gets the hover today style.</summary>
    /// <value>The hover today style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The hover style of the current day.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverTodayStyle => new StyleValue((CommonSkin) this, nameof (HoverTodayStyle), this.HoverDayStyle);

    /// <summary>Gets the external day style.</summary>
    /// <value>The external day style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The style of days that are outside the range of the current month.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue ExternalDayStyle => new StyleValue((CommonSkin) this, nameof (ExternalDayStyle), this.NormalDayStyle);

    /// <summary>Gets the hover external day style.</summary>
    /// <value>The hover external day style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The hover style of days that are outside the range of the current month.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverExternalDayStyle => new StyleValue((CommonSkin) this, nameof (HoverExternalDayStyle), this.HoverDayStyle);

    /// <summary>Gets the month calendar caption style.</summary>
    /// <value>The month calendar caption style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The month calendar caption style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue CaptionStyle => new StyleValue((CommonSkin) this, nameof (CaptionStyle));

    /// <summary>Gets the month calendar header style.</summary>
    /// <value>The month calendar header style.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
    [Description("The month calendar header style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HeaderStyle => new StyleValue((CommonSkin) this, nameof (HeaderStyle));

    /// <summary>Gets the month normal day style.</summary>
    /// <value>The month normal day style.</value>
    [Category("States")]
    [Description("The month calendar normal day style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NormalDayStyle => new StyleValue((CommonSkin) this, nameof (NormalDayStyle));

    /// <summary>Gets the month selected day style.</summary>
    /// <value>The month selected day style.</value>
    [Category("States")]
    [Description("The month calendar selected day style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SelectedDayStyle => new StyleValue((CommonSkin) this, nameof (SelectedDayStyle), this.NormalDayStyle);

    /// <summary>Gets the month Hover Selected day style.</summary>
    /// <value>The month Hover Selected day style.</value>
    [Category("States")]
    [Description("The month calendar Hover Selected day style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverSelectedDayStyle => new StyleValue((CommonSkin) this, nameof (HoverSelectedDayStyle), this.SelectedDayStyle);

    /// <summary>Gets the hover day style.</summary>
    [Category("States")]
    [Description("The month calendar hover day style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverDayStyle => new StyleValue((CommonSkin) this, nameof (HoverDayStyle), this.NormalDayStyle);

    /// <summary>Gets the navigate next style.</summary>
    /// <value>The navigate next style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The navigate next style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NavigateNextStyle => new StyleValue((CommonSkin) this, nameof (NavigateNextStyle));

    /// <summary>Gets the navigate previous style.</summary>
    /// <value>The navigate previous style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The navigate previous style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NavigatePreviousStyle => new StyleValue((CommonSkin) this, nameof (NavigatePreviousStyle));

    /// <summary>Gets the bidirectional navigate previous style.</summary>
    /// <value>The bidirectional navigate previous style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigatePreviousStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.NavigatePreviousStyle, this.NavigateNextStyle);

    /// <summary>Gets the width of the navigate next.</summary>
    /// <value>The width of the navigate next.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NavigateNextWidth => this.GetImageWidth(this.NavigateNextStyle.BackgroundImage, this.DefaultNavigateNextWidth);

    /// <summary>Gets the width of the navigate previous.</summary>
    /// <value>The width of the navigate previous.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NavigatePreviousWidth => this.GetImageWidth(this.NavigatePreviousStyle.BackgroundImage, this.DefaultNavigatePreviousWidth);

    /// <summary>Gets the width of the default navigate previous.</summary>
    /// <value>The width of the default navigate previous.</value>
    protected virtual int DefaultNavigatePreviousWidth => 5;

    /// <summary>Gets the width of the default navigate next.</summary>
    /// <value>The width of the default navigate next.</value>
    protected virtual int DefaultNavigateNextWidth => 5;

    /// <summary>Gets the bidirectional navigate next style.</summary>
    /// <value>The bidirectional navigate next style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigateNextStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.NavigateNextStyle, this.NavigatePreviousStyle);

    /// <summary>Gets the normal month cell style.</summary>
    /// <value>The normal month cell style.</value>
    [Category("States")]
    [Description("The month cell normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NormalMonthCellStyle => new StyleValue((CommonSkin) this, nameof (NormalMonthCellStyle));

    /// <summary>Gets the hover month cell style.</summary>
    [Category("States")]
    [Description("The month cell Hover style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverMonthCellStyle => new StyleValue((CommonSkin) this, nameof (HoverMonthCellStyle), this.NormalMonthCellStyle);

    /// <summary>Gets the selected month cell style.</summary>
    /// <value>The selected month cell style.</value>
    [Category("States")]
    [Description("The month cell selected  style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SelectedMonthCellStyle => new StyleValue((CommonSkin) this, nameof (SelectedMonthCellStyle), this.NormalMonthCellStyle);

    /// <summary>Gets the Hover Selected month cell style.</summary>
    /// <value>The Hover Selected month cell style.</value>
    [Category("States")]
    [Description("The month cell Hover Selected  style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverSelectedMonthCellStyle => new StyleValue((CommonSkin) this, nameof (HoverSelectedMonthCellStyle), this.SelectedMonthCellStyle);

    /// <summary>Gets or sets the month view padding.</summary>
    /// <value>The month view padding.</value>
    public PaddingValue MonthViewPadding
    {
      get => this.GetValue<PaddingValue>(nameof (MonthViewPadding), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(4, 10, 4, 10)));
      set => this.SetValue(nameof (MonthViewPadding), (object) value);
    }

    /// <summary>Gets the normal year cell style.</summary>
    /// <value>The normal year cell style.</value>
    [Category("States")]
    [Description("The Year cell normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NormalYearCellStyle => new StyleValue((CommonSkin) this, nameof (NormalYearCellStyle), this.NormalMonthCellStyle);

    /// <summary>Gets the hover year cell style.</summary>
    [Category("States")]
    [Description("The Year cell Hover style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverYearCellStyle => new StyleValue((CommonSkin) this, nameof (HoverYearCellStyle), this.NormalYearCellStyle);

    /// <summary>Gets the selected year cell style.</summary>
    /// <value>The selected year cell style.</value>
    [Category("States")]
    [Description("The year cell selected  style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SelectedYearCellStyle => new StyleValue((CommonSkin) this, nameof (SelectedYearCellStyle), this.NormalYearCellStyle);

    /// <summary>Gets the Hover Selected year cell style.</summary>
    /// <value>The Hover Selected year cell style.</value>
    [Category("States")]
    [Description("The year cell Hover Selected  style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverSelectedYearCellStyle => new StyleValue((CommonSkin) this, nameof (HoverSelectedYearCellStyle), this.SelectedYearCellStyle);

    /// <summary>Gets or sets the year view padding.</summary>
    /// <value>The year view padding.</value>
    public PaddingValue YearViewPadding
    {
      get => this.GetValue<PaddingValue>(nameof (YearViewPadding), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(4, 14, 4, 10)));
      set => this.SetValue(nameof (YearViewPadding), (object) value);
    }

    /// <summary>Gets the normal YearRange cell style.</summary>
    /// <value>The normal YearRange cell style.</value>
    [Category("States")]
    [Description("The YearRange cell normal style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NormalYearRangeCellStyle => new StyleValue((CommonSkin) this, nameof (NormalYearRangeCellStyle));

    /// <summary>Gets the hover year range cell style.</summary>
    [Category("States")]
    [Description("The YearRange cell Hover style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverYearRangeCellStyle => new StyleValue((CommonSkin) this, nameof (HoverYearRangeCellStyle), this.NormalYearRangeCellStyle);

    /// <summary>Gets the selected YearRange cell style.</summary>
    /// <value>The selected YearRange cell style.</value>
    [Category("States")]
    [Description("The YearRange cell selected  style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue SelectedYearRangeCellStyle => new StyleValue((CommonSkin) this, nameof (SelectedYearRangeCellStyle), this.NormalYearRangeCellStyle);

    /// <summary>Gets the Hover Selected YearRange cell style.</summary>
    /// <value>The Hover Selected YearRange cell style.</value>
    [Category("States")]
    [Description("The YearRange cell Hover Selected style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue HoverSelectedYearRangeCellStyle => new StyleValue((CommonSkin) this, nameof (HoverSelectedYearRangeCellStyle), this.SelectedYearRangeCellStyle);

    /// <summary>Gets or sets the year range view padding.</summary>
    /// <value>The year range view padding.</value>
    public PaddingValue YearRangeViewPadding
    {
      get => this.GetValue<PaddingValue>(nameof (YearRangeViewPadding), new PaddingValue(new Gizmox.WebGUI.Forms.Padding(0, 8, 0, 8)));
      set => this.SetValue(nameof (YearRangeViewPadding), (object) value);
    }

    /// <summary>Gets the navigate next disabled style.</summary>
    /// <value>The navigate next disabled style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The navigate next disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NavigateNextDisabledStyle => new StyleValue((CommonSkin) this, nameof (NavigateNextDisabledStyle), this.NavigateNextStyle);

    /// <summary>Gets the navigate previous disabled style.</summary>
    /// <value>The navigate previous disabled style.</value>
    [Category("States")]
    [Gizmox.WebGUI.Forms.SRDescription("The navigate previous disabled style.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual StyleValue NavigatePreviousDisabledStyle => new StyleValue((CommonSkin) this, nameof (NavigatePreviousDisabledStyle), this.NavigatePreviousStyle);

    /// <summary>
    /// Gets the bidirectional navigate previous disabled style.
    /// </summary>
    /// <value>The bidirectional navigate previous disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigatePreviousDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.NavigatePreviousDisabledStyle, this.NavigateNextDisabledStyle);

    /// <summary>Gets the bidirectional navigate next disabled style.</summary>
    /// <value>The bidirectional navigate next disabled style.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigateNextDisabledStyle => new BidirectionalSkinValue<StyleValue>((Skin) this, this.NavigateNextDisabledStyle, this.NavigatePreviousDisabledStyle);

    /// <summary>Gets the width of the navigate next.</summary>
    /// <value>The width of the navigate next.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NavigateNextDisabledWidth => this.GetImageWidth(this.NavigateNextDisabledStyle.BackgroundImage, this.DefaultNavigateNextWidth);

    /// <summary>Gets the width of the navigate previous.</summary>
    /// <value>The width of the navigate previous.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NavigatePreviousDisabledWidth => this.GetImageWidth(this.NavigatePreviousDisabledStyle.BackgroundImage, this.DefaultNavigatePreviousWidth);

    /// <summary>Gets or sets the next image.</summary>
    /// <value>The next image.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Category("Images")]
    [Description("The image for the 'Next' button.")]
    public virtual ImageResourceReference NextImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (NextImage), new ImageResourceReference(typeof (MonthCalendarSkin), "ArrowWhiteLTR.png"));
      set => this.SetValue(nameof (NextImage), (object) value);
    }

    /// <summary>Gets or sets the previous image.</summary>
    /// <value>The previous image.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Category("Images")]
    [Description("The image for the 'Previous' button.")]
    public virtual ImageResourceReference PreviousImage
    {
      get => this.GetValue<ImageResourceReference>(nameof (PreviousImage), new ImageResourceReference(typeof (MonthCalendarSkin), "ArrowWhiteRTL.png"));
      set => this.SetValue(nameof (PreviousImage), (object) value);
    }

    /// <summary>Gets or sets the size of the next image.</summary>
    /// <value>The size of the next image.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Category("Sizes")]
    [Description("The image size for the 'Next' button.")]
    public Size NextImageSize
    {
      get => this.GetValue<Size>(nameof (NextImageSize), this.GetImageSize(this.NextImage, Size.Empty));
      set => this.SetValue(nameof (NextImageSize), (object) value);
    }

    /// <summary>Gets or sets the size of the previous image.</summary>
    /// <value>The size of the previous image.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Category("Sizes")]
    [Description("The image size for the 'Previous' button.")]
    public Size PreviousImageSize
    {
      get => this.GetValue<Size>(nameof (PreviousImageSize), this.GetImageSize(this.PreviousImage, Size.Empty));
      set => this.SetValue(nameof (PreviousImageSize), (object) value);
    }

    /// <summary>Gets the height of the next image.</summary>
    /// <value>The height of the next image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int NextImageHeight => this.NextImageSize.Height;

    /// <summary>Gets the width of the next image.</summary>
    /// <value>The width of the next image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int NextImageWidth => this.NextImageSize.Width;

    /// <summary>Gets the height of the previous image.</summary>
    /// <value>The height of the previous image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int PreviousImageHeight => this.PreviousImageSize.Height;

    /// <summary>Gets the width of the previous image.</summary>
    /// <value>The width of the previous image.</value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int PreviousImageWidth => this.PreviousImageSize.Width;

    /// <summary>Gets or sets the height of the caption.</summary>
    /// <value>The height of the caption.</value>
    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The caption height.")]
    public int CaptionHeight
    {
      get => this.GetValue<int>(nameof (CaptionHeight), this.DefaultCaptionHeight);
      set => this.SetValue(nameof (CaptionHeight), (object) value);
    }

    /// <summary>Resets the height of the caption.</summary>
    internal void ResetCaptionHeight() => this.Reset("CaptionHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultCaptionHeight => this.GetImageHeight(this.CaptionStyle.BackgroundImage, 30);

    /// <summary>Gets or sets the height of the header.</summary>
    /// <value>The height of the header.</value>
    [Category("Sizes")]
    [Gizmox.WebGUI.Forms.SRDescription("The header height.")]
    public int HeaderHeight
    {
      get => this.GetValue<int>(nameof (HeaderHeight), this.DefaultHeaderHeight);
      set => this.SetValue(nameof (HeaderHeight), (object) value);
    }

    /// <summary>Resets the height of the header.</summary>
    internal void ResetHeaderHeight() => this.Reset("HeaderHeight");

    /// <summary>Gets default value</summary>
    protected virtual int DefaultHeaderHeight => this.GetImageHeight(this.HeaderStyle.BackgroundImage, 19);

    /// <summary>Gets or sets the height of the month cell.</summary>
    /// <value>The height of the month cell.</value>
    public int MonthCellHeight
    {
      get => this.GetValue<int>(nameof (MonthCellHeight), this.GetImageHeight(this.SelectedMonthCellStyle.BackgroundImage, 31));
      set => this.SetValue(nameof (MonthCellHeight), (object) value);
    }

    /// <summary>Resets the height of the month cell.</summary>
    public void ResetMonthCellHeight() => this.Reset("MonthCellHeight");

    /// <summary>Gets or sets the height of the year cell.</summary>
    /// <value>The height of the year cell.</value>
    public int YearCellHeight
    {
      get => this.GetValue<int>(nameof (YearCellHeight), this.GetImageHeight(this.SelectedYearCellStyle.BackgroundImage, 31));
      set => this.SetValue(nameof (YearCellHeight), (object) value);
    }

    /// <summary>Resets the height of the year cell.</summary>
    public void ResetYearCellHeight() => this.Reset("YearCellHeight");

    /// <summary>Gets or sets the height of the year range cell.</summary>
    /// <value>The height of the year range cell.</value>
    public int YearRangeCellHeight
    {
      get => this.GetValue<int>(nameof (YearRangeCellHeight), this.GetImageHeight(this.SelectedYearRangeCellStyle.BackgroundImage, 31));
      set => this.SetValue(nameof (YearRangeCellHeight), (object) value);
    }

    /// <summary>Resets the height of the year range cell.</summary>
    public void ResetYearRangeCellHeight() => this.Reset("YearRangeCellHeight");
  }
}

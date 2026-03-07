using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// MonthCalendar Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(MonthCalendar), "MonthCalendar.bmp"), Serializable()]
    public class MonthCalendarSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        private void InitializeComponent()
        {

        }


        #region Styles

        /// <summary>
        /// Gets the selected day style.
        /// </summary>
        /// <value>
        /// The selected day style.
        /// </value>
        [SRCategory("CatAppearance"), Description("The style of the current day when selected.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue TodaySelectedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TodaySelectedStyle", SelectedDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the hover selected day style.
        /// </summary>
        /// <value>
        /// The hover selected day style.
        /// </value>
        [SRCategory("CatAppearance"), Description("The hover style of the current day when selected.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverTodaySelectedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverTodaySelectedStyle", HoverSelectedDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the today style.
        /// </summary>
        /// <value>
        /// The today style.
        /// </value>
        [SRCategory("CatAppearance"), Description("The style of the current day.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue TodayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TodayStyle", NormalDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the hover today style.
        /// </summary>
        /// <value>
        /// The hover today style.
        /// </value>
        [SRCategory("CatAppearance"), Description("The hover style of the current day.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverTodayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverTodayStyle", HoverDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the external day style.
        /// </summary>
        /// <value>
        /// The external day style.
        /// </value>
        [SRCategory("CatAppearance"), Description("The style of days that are outside the range of the current month.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ExternalDayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ExternalDayStyle", NormalDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the hover external day style.
        /// </summary>
        /// <value>
        /// The hover external day style.
        /// </value>
        [SRCategory("CatAppearance"), Description("The hover style of days that are outside the range of the current month.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverExternalDayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverExternalDayStyle", HoverDayStyle);
                return objStyle;
            }
        }



        /// <summary>
        /// Gets the month calendar caption style.
        /// </summary>
        /// <value>The month calendar caption style.</value>
        [SRCategory("CatAppearance"), Description("The month calendar caption style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue CaptionStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CaptionStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the month calendar header style.
        /// </summary>
        /// <value>The month calendar header style.</value>
        [SRCategory("CatAppearance"), Description("The month calendar header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the month normal day style.
        /// </summary>
        /// <value>The month normal day style.</value>
        [Category("States"), Description("The month calendar normal day style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NormalDayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NormalDayStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the month selected day style.
        /// </summary>
        /// <value>The month selected day style.</value>
        [Category("States"), Description("The month calendar selected day style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SelectedDayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SelectedDayStyle", this.NormalDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the month Hover Selected day style.
        /// </summary>
        /// <value>The month Hover Selected day style.</value>
        [Category("States"), Description("The month calendar Hover Selected day style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverSelectedDayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverSelectedDayStyle", this.SelectedDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the hover day style.
        /// </summary>
        [Category("States"), Description("The month calendar hover day style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverDayStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverDayStyle", this.NormalDayStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the navigate next style.
        /// </summary>
        /// <value>The navigate next style.</value>
        [Category("States"), SRDescription("The navigate next style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NavigateNextStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NavigateNextStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the navigate previous style.
        /// </summary>
        /// <value>The navigate previous style.</value>
        [Category("States"), SRDescription("The navigate previous style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NavigatePreviousStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NavigatePreviousStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bidirectional navigate previous style.
        /// </summary>
        /// <value>The bidirectional navigate previous style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigatePreviousStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.NavigatePreviousStyle, this.NavigateNextStyle);
            }
        }

        /// <summary>
        /// Gets the width of the navigate next.
        /// </summary>
        /// <value>The width of the navigate next.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NavigateNextWidth
        {
            get
            {
                return this.GetImageWidth(this.NavigateNextStyle.BackgroundImage, this.DefaultNavigateNextWidth);
            }
        }

        /// <summary>
        /// Gets the width of the navigate previous.
        /// </summary>
        /// <value>The width of the navigate previous.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NavigatePreviousWidth
        {
            get
            {
                return this.GetImageWidth(this.NavigatePreviousStyle.BackgroundImage, this.DefaultNavigatePreviousWidth);
            }
        }

        /// <summary>
        /// Gets the width of the default navigate previous.
        /// </summary>
        /// <value>The width of the default navigate previous.</value>
        protected virtual int DefaultNavigatePreviousWidth
        {
            get
            {
                return 5;
            }
        }

        /// <summary>
        /// Gets the width of the default navigate next.
        /// </summary>
        /// <value>The width of the default navigate next.</value>
        protected virtual int DefaultNavigateNextWidth
        {
            get
            {
                return 5;
            }
        }

        /// <summary>
        /// Gets the bidirectional navigate next style.
        /// </summary>
        /// <value>The bidirectional navigate next style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigateNextStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.NavigateNextStyle, this.NavigatePreviousStyle);
            }
        }



        /// <summary>
        /// Gets the normal month cell style.
        /// </summary>
        /// <value>The normal month cell style.</value>
        [Category("States"), Description("The month cell normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NormalMonthCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NormalMonthCellStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the hover month cell style.
        /// </summary>
        [Category("States"), Description("The month cell Hover style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverMonthCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverMonthCellStyle", this.NormalMonthCellStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the selected month cell style.
        /// </summary>
        /// <value>The selected month cell style.</value>
        [Category("States"), Description("The month cell selected  style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SelectedMonthCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SelectedMonthCellStyle", this.NormalMonthCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the Hover Selected month cell style.
        /// </summary>
        /// <value>The Hover Selected month cell style.</value>
        [Category("States"), Description("The month cell Hover Selected  style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverSelectedMonthCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverSelectedMonthCellStyle", this.SelectedMonthCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the month view padding.
        /// </summary>
        /// <value>The month view padding.</value>
        public PaddingValue MonthViewPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("MonthViewPadding", new PaddingValue(new Padding(4, 10, 4, 10)));
            }
            set
            {
                this.SetValue("MonthViewPadding", value);
            }
        }



        /// <summary>
        /// Gets the normal year cell style.
        /// </summary>
        /// <value>The normal year cell style.</value>
        [Category("States"), Description("The Year cell normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NormalYearCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NormalYearCellStyle", this.NormalMonthCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the hover year cell style.
        /// </summary>
        [Category("States"), Description("The Year cell Hover style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverYearCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverYearCellStyle", this.NormalYearCellStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the selected year cell style.
        /// </summary>
        /// <value>The selected year cell style.</value>
        [Category("States"), Description("The year cell selected  style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SelectedYearCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SelectedYearCellStyle", this.NormalYearCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the Hover Selected year cell style.
        /// </summary>
        /// <value>The Hover Selected year cell style.</value>
        [Category("States"), Description("The year cell Hover Selected  style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverSelectedYearCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverSelectedYearCellStyle", this.SelectedYearCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the year view padding.
        /// </summary>
        /// <value>The year view padding.</value>
        public PaddingValue YearViewPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("YearViewPadding", new PaddingValue(new Padding(4, 14, 4, 10)));
            }
            set
            {
                this.SetValue("YearViewPadding", value);
            }
        }


        /// <summary>
        /// Gets the normal YearRange cell style.
        /// </summary>
        /// <value>The normal YearRange cell style.</value>
        [Category("States"), Description("The YearRange cell normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NormalYearRangeCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NormalYearRangeCellStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the hover year range cell style.
        /// </summary>
        [Category("States"), Description("The YearRange cell Hover style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverYearRangeCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverYearRangeCellStyle", this.NormalYearRangeCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the selected YearRange cell style.
        /// </summary>
        /// <value>The selected YearRange cell style.</value>
        [Category("States"), Description("The YearRange cell selected  style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SelectedYearRangeCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "SelectedYearRangeCellStyle", this.NormalYearRangeCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the Hover Selected YearRange cell style.
        /// </summary>
        /// <value>The Hover Selected YearRange cell style.</value>
        [Category("States"), Description("The YearRange cell Hover Selected style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HoverSelectedYearRangeCellStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HoverSelectedYearRangeCellStyle", this.SelectedYearRangeCellStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the year range view padding.
        /// </summary>
        /// <value>The year range view padding.</value>
        public PaddingValue YearRangeViewPadding
        {
            get
            {
                return this.GetValue<PaddingValue>("YearRangeViewPadding", new PaddingValue(new Padding(0, 8, 0, 8)));
            }
            set
            {
                this.SetValue("YearRangeViewPadding", value);
            }
        }

        #region Navigate Disabled Style

        /// <summary>
        /// Gets the navigate next disabled style.
        /// </summary>
        /// <value>
        /// The navigate next disabled style.
        /// </value>
        [Category("States"), SRDescription("The navigate next disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NavigateNextDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NavigateNextDisabledStyle", this.NavigateNextStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the navigate previous disabled style.
        /// </summary>
        /// <value>
        /// The navigate previous disabled style.
        /// </value>
        [Category("States"), SRDescription("The navigate previous disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue NavigatePreviousDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "NavigatePreviousDisabledStyle",this.NavigatePreviousStyle);
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the bidirectional navigate previous disabled style.
        /// </summary>
        /// <value>
        /// The bidirectional navigate previous disabled style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigatePreviousDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.NavigatePreviousDisabledStyle, this.NavigateNextDisabledStyle);
            }
        }


        /// <summary>
        /// Gets the bidirectional navigate next disabled style.
        /// </summary>
        /// <value>
        /// The bidirectional navigate next disabled style.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BidirectionalSkinValue<StyleValue> BidirectionalNavigateNextDisabledStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.NavigateNextDisabledStyle, this.NavigatePreviousDisabledStyle);
            }
        }

        /// <summary>
        /// Gets the width of the navigate next.
        /// </summary>
        /// <value>The width of the navigate next.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NavigateNextDisabledWidth
        {
            get
            {
                return this.GetImageWidth(this.NavigateNextDisabledStyle.BackgroundImage, this.DefaultNavigateNextWidth);
            }
        }

        /// <summary>
        /// Gets the width of the navigate previous.
        /// </summary>
        /// <value>The width of the navigate previous.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NavigatePreviousDisabledWidth
        {
            get
            {
                return this.GetImageWidth(this.NavigatePreviousDisabledStyle.BackgroundImage, this.DefaultNavigatePreviousWidth);
            }
        }

        #endregion Navigate Disabled Style

        #endregion

        #region Images

        #endregion

        /// <summary>
        /// Gets or sets the next image.
        /// </summary>
        /// <value>
        /// The next image.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Images"), Description("The image for the 'Next' button.")]
        public virtual ImageResourceReference NextImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("NextImage", new ImageResourceReference(typeof(MonthCalendarSkin), "ArrowWhiteLTR.png"));
            }
            set
            {
                this.SetValue("NextImage", value);
            }
        }

        /// <summary>
        /// Gets or sets the previous image.
        /// </summary>
        /// <value>
        /// The previous image.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Images"), Description("The image for the 'Previous' button.")]
        public virtual ImageResourceReference PreviousImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("PreviousImage", new ImageResourceReference(typeof(MonthCalendarSkin), "ArrowWhiteRTL.png"));
            }
            set
            {
                this.SetValue("PreviousImage", value);
            }
        }

        #region Sizes

        /// <summary>
        /// Gets or sets the size of the next image.
        /// </summary>
        /// <value>
        /// The size of the next image.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Sizes"), Description("The image size for the 'Next' button.")]
        public Size NextImageSize
        {
            get
            {
                return this.GetValue<Size>("NextImageSize", GetImageSize(NextImage, Size.Empty));
            }
            set
            {
                this.SetValue("NextImageSize", value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the previous image.
        /// </summary>
        /// <value>
        /// The size of the previous image.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Category("Sizes"), Description("The image size for the 'Previous' button.")]
        public Size PreviousImageSize
        {
            get
            {
                return this.GetValue<Size>("PreviousImageSize", GetImageSize(PreviousImage, Size.Empty));
            }
            set
            {
                this.SetValue("PreviousImageSize", value);
            }
        }

        /// <summary>
        /// Gets the height of the next image.
        /// </summary>
        /// <value>
        /// The height of the next image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int NextImageHeight
        {
            get
            {
                return NextImageSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the next image.
        /// </summary>
        /// <value>
        /// The width of the next image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int NextImageWidth
        {
            get
            {
                return NextImageSize.Width;
            }
        }

        /// <summary>
        /// Gets the height of the previous image.
        /// </summary>
        /// <value>
        /// The height of the previous image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PreviousImageHeight
        {
            get
            {
                return PreviousImageSize.Height;
            }
        }

        /// <summary>
        /// Gets the width of the previous image.
        /// </summary>
        /// <value>
        /// The width of the previous image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PreviousImageWidth
        {
            get
            {
                return PreviousImageSize.Width;
            }
        }

        /// <summary>
        /// Gets or sets the height of the caption.
        /// </summary>
        /// <value>The height of the caption.</value>
        [Category("Sizes"), SRDescription("The caption height.")]
        public int CaptionHeight
        {
            get
            {
                return this.GetValue<int>("CaptionHeight", this.DefaultCaptionHeight);
            }
            set
            {
                this.SetValue("CaptionHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the caption.
        /// </summary>
        internal void ResetCaptionHeight()
        {
            this.Reset("CaptionHeight");
        }


        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultCaptionHeight
        {
            get
            {
                return this.GetImageHeight(this.CaptionStyle.BackgroundImage, 30);
            }
        }

        /// <summary>
        /// Gets or sets the height of the header.
        /// </summary>
        /// <value>The height of the header.</value>
        [Category("Sizes"), SRDescription("The header height.")]
        public int HeaderHeight
        {
            get
            {
                return this.GetValue<int>("HeaderHeight", this.DefaultHeaderHeight);
            }
            set
            {
                this.SetValue("HeaderHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the header.
        /// </summary>
        internal void ResetHeaderHeight()
        {
            this.Reset("HeaderHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultHeaderHeight
        {
            get
            {
                return this.GetImageHeight(this.HeaderStyle.BackgroundImage, 19);
            }
        }


        /// <summary>
        /// Gets or sets the height of the month cell.
        /// </summary>
        /// <value>The height of the month cell.</value>
        public int MonthCellHeight
        {
            get
            {
                return this.GetValue<int>("MonthCellHeight", this.GetImageHeight(this.SelectedMonthCellStyle.BackgroundImage, 31));
            }
            set
            {
                this.SetValue("MonthCellHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the month cell.
        /// </summary>
        public void ResetMonthCellHeight()
        {
            this.Reset("MonthCellHeight");
        }


        /// <summary>
        /// Gets or sets the height of the year cell.
        /// </summary>
        /// <value>The height of the year cell.</value>
        public int YearCellHeight
        {
            get
            {
                return this.GetValue<int>("YearCellHeight", this.GetImageHeight(this.SelectedYearCellStyle.BackgroundImage, 31));
            }
            set
            {
                this.SetValue("YearCellHeight", value);
            }
        }


        /// <summary>
        /// Resets the height of the year cell.
        /// </summary>
        public void ResetYearCellHeight()
        {
            this.Reset("YearCellHeight");
        }


        /// <summary>
        /// Gets or sets the height of the year range cell.
        /// </summary>
        /// <value>The height of the year range cell.</value>
        public int YearRangeCellHeight
        {
            get
            {
                return this.GetValue<int>("YearRangeCellHeight", this.GetImageHeight(this.SelectedYearRangeCellStyle.BackgroundImage, 31));
            }
            set
            {
                this.SetValue("YearRangeCellHeight", value);
            }
        }


        /// <summary>
        /// Resets the height of the year range cell.
        /// </summary>
        public void ResetYearRangeCellHeight()
        {
            this.Reset("YearRangeCellHeight");
        }
        #endregion

    }
}

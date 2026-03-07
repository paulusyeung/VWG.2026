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
    /// DataGridView Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(DataGridView), "DataGridView.bmp")]
    [SkinDependency(typeof(DataGridViewFilterButtonSkin))]
    [SkinDependency(typeof(DataGridViewButtonCellSkin))]
    [SkinDependency(typeof(DataGridViewCheckBoxCellSkin))]
    [SkinDependency(typeof(DataGridViewComboBoxCellSkin))]
    [SkinDependency(typeof(DataGridViewImageCellSkin))]
    [SkinDependency(typeof(DataGridViewLinkCellSkin))]
    [SkinDependency(typeof(DataGridViewTextBoxCellSkin))]
    [SkinDependency(typeof(ColumnChooserButtonSkin))]
    [SkinDependency(typeof(DataGridViewActiveTextBoxCellSkin)), Serializable()]
    [SkinDependency(typeof(DataGridViewGroupingTreeViewSkin))]
    [SkinDependency(typeof(DataGridViewCellPanelSkin))]
    [SkinDependency(typeof(DataGridViewFilterComboBoxSkin))]
    [SkinDependency(typeof(DataGridViewHeaderFilterComboBoxSkin))]
    [SkinDependency(typeof(DataGridViewFilterComboBoxSkin))]
    public class DataGridViewSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        #region GridStyleValue class

        [Serializable()]
        public class GridStyleValue : StyleValue
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GridStyleValue"/> class.
            /// </summary>
            /// <param name="objPropertyOwner">The property owner.</param>
            /// <param name="strPropertyPrefix">The property prefix.</param>
            public GridStyleValue(DataGridViewSkin objPropertyOwner, string strPropertyPrefix)
                : base(objPropertyOwner, strPropertyPrefix)
            {
            }

            /// <summary>
            /// Gets or sets the default border width.
            /// </summary>
            /// <value></value>
            protected override BorderColor DefaultBorderColor
            {
                get
                {
                    if (this.DataGridViewSkin != null)
                    {
                        return this.DataGridViewSkin.GridLinesColor;
                    }
                    else
                    {
                        return base.DefaultBorderColor;
                    }

                }
            }

            /// <summary>
            /// Gets or sets the default border style.
            /// </summary>
            /// <value></value>
            protected override BorderStyle DefaultBorderStyle
            {
                get
                {
                    if (this.DataGridViewSkin != null)
                    {
                        return this.DataGridViewSkin.GridLinesStyle;
                    }
                    else
                    {
                        return base.DefaultBorderStyle;
                    }
                }
            }

            /// <summary>
            /// Gets or sets the default border width.
            /// </summary>
            /// <value></value>
            protected override BorderWidth DefaultBorderWidth
            {
                get
                {
                    if (this.DataGridViewSkin != null)
                    {
                        return this.DataGridViewSkin.GridLinesWidth;
                    }
                    else
                    {
                        return base.DefaultBorderWidth;
                    }
                }
            }

            /// <summary>
            /// Gets the property grid skin.
            /// </summary>
            /// <value>The property grid skin.</value>
            private DataGridViewSkin DataGridViewSkin
            {
                get
                {
                    return this.Skin as DataGridViewSkin;
                }
            }
        }

        #endregion GridStyleValue class

        private void InitializeComponent()
        {

        }

        #region Styles

        /// <summary>
        /// Gets the extended columns non frozen style.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ExtendedColumnsNonFrozenStyle
        {
            get
            {
                return new StyleValue(this, "ExtendedColumnsNonFrozenStyle");
            }
        }
        /// <summary>
        /// Gets the extended columns frozen style.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ExtendedColumnsFrozenStyle
        {
            get
            {
                return new StyleValue(this, "ExtendedColumnsFrozen");
            }
        }
        /// <summary>
        /// Gets the extended columns corner style.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ExtendedColumnsCornerStyle
        {
            get
            {
                return new StyleValue(this, "ExtendedColumnsCorner");
            }
        }

        /// <summary>
        /// Gets the "clear all filters" tooltip localized string.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ClearAllFiltersToolTip
        {
            get
            {
                return SR.GetString("ClearAllFilters");
            }
        }

        /// <summary>
        /// Gets or sets the drop indicator style.
        /// </summary>
        /// <value>
        /// The drop indicator style.
        /// </value>
        [SRCategory("Styles"), SRDescription("Grouping TreeNode drop indicator style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue DropIndicatorStyle
        {
            get
            {
                return new StyleValue(this, "DropIndicatorStyle");
            }
        }

        /// <summary>
        /// Gets the grouping drop area empty style.
        /// </summary>
        [Category("Styles"), SRDescription("The empty grouping drop area style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue GroupingDropAreaStyle
        {
            get
            {
                return new StyleValue(this, "GroupingDropAreaStyle");
            }
        }

        /// <summary>
        /// Gets the grouping drop area empty message style.
        /// </summary>
        [Category("Styles"), SRDescription("The empty grouping drop area empty message style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue GroupingDropAreaEmptyMessageStyle
        {
            get
            {
                return new StyleValue(this, "GroupingDropAreaEmptyMessageStyle");
            }
        }

        /// <summary>
        /// Gets the grouping drop area empty message.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string GroupingDropAreaEmptyMessage
        {
            get
            {
                return SR.GetString("DataGridViewGroupingTreeViewDragColumnHeaderHere");
            }
        }

        /// <summary>
        /// Gets or sets the grouping drop area empty message align.
        /// </summary>
        /// <value>
        /// The grouping drop area empty message align.
        /// </value>
        [Category("Appearance"), SRDescription("The empty grouping drop area message alignment.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public HorizontalAlignment GroupingDropAreaEmptyMessageAlign
        {
            get
            {
                return this.GetValue<HorizontalAlignment>("GroupingDropAreaEmptyMessageAlign", HorizontalAlignment.Left);
            }
            set
            {
                this.SetValue("GroupingDropAreaEmptyMessageAlign", value);
            }
        }

        /// <summary>
        /// Resets the grouping drop area empty message align.
        /// </summary>
        private void ResetGroupingDropAreaEmptyMessageAlign()
        {
            this.Reset("GroupingDropAreaEmptyMessageAlign");
        }

        /// <summary>
        /// Gets the "clear all filters" button style.
        /// </summary>
        [Category("Styles"), SRDescription("The \"Clear All Filters\" button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue FilterRowClearButtonStyle
        {
            get
            {
                return new StyleValue(this, "FilterRowClearButtonStyle");
            }
        }

        /// <summary>
        /// Gets the caption style.
        /// </summary>
        [Category("Styles"), SRDescription("The caption style.")]
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
        /// Gets the row header normal style.
        /// </summary>
        /// <value>The row header normal style.</value>
        [Category("States"), SRDescription("The normal row header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue RowHeaderNormalStyle
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "RowHeaderNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the row header selected style.
        /// </summary>
        /// <value>The row header selected style.</value>
        [Category("States"), SRDescription("The selected row header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual OpacityValue SelectedRowHeaderOpacity
        {
            get
            {
                return this.GetValue<OpacityValue>("SelectedRowHeaderOpacity", new OpacityValue(this.DefaultSelectedRowHeaderOpacity));
            }
            set
            {
                if (value.Opacity >= 0 && value.Opacity <= 100)
                {
                    this.SetValue("SelectedRowHeaderOpacity", value);
                }
                else
                {
                    throw new Exception("You must supply values between 1 and 100.");
                }
            }
        }

        /// <summary>
        /// Gets the default selected row header opacity.
        /// </summary>
        /// <value>The default selected row header opacity.</value>
        protected virtual int DefaultSelectedRowHeaderOpacity
        {
            get
            {
                return 60;
            }
        }

        /// <summary>
        /// Gets the column header normal style.
        /// </summary>
        /// <value>The row column normal style.</value>
        [Category("States"), SRDescription("The normal row column style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ColumnHeaderNormalStyle
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "ColumnHeaderNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top header normal style.
        /// </summary>
        /// <value>The left top header normal style.</value>
        [Category("States"), SRDescription("The left top header normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinValue<StyleValue> LeftTopHeaderNormalStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.LeftTopHeaderNormalStyleLTR, this.LeftTopHeaderNormalStyleRTL);
            }
        }


        /// <summary>
        /// Gets the left top header normal style LTR.
        /// </summary>
        /// <value>The left top header normal style LTR.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRDescription("The LeftToRight left top header normal style.")]
        protected virtual StyleValue LeftTopHeaderNormalStyleLTR
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "LeftTopHeaderNormalStyleLTR");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top header normal style RTL.
        /// </summary>
        /// <value>The left top header normal style RTL.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [SRDescription("The RightToLeft left top header normal style.")]
        protected virtual StyleValue LeftTopHeaderNormalStyleRTL
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "LeftTopHeaderNormalStyleRTL");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the cell normal style.
        /// </summary>
        /// <value>The cell normal style.</value>
        [Category("States"), SRDescription("The normal cell style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue CellNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CellNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the color of the cell normal style fore color .
        /// </summary>
        /// <value>The color of the cell normal style fore.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Color CellNormalStyleForeColor
        {
            get
            {
                return CellNormalStyle.ForeColor;
            }
        }



        /// <summary>
        /// Gets the cell alternative style.
        /// </summary>
        /// <value>The cell alternative style.</value>
        [Category("States"), SRDescription("The alternative cell style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual StyleValue CellAlternativeStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CellAlternativeStyle", this.CellNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the cell selected style.
        /// </summary>
        /// <value>The cell selected style.</value>
        [Category("States"), SRDescription("The selected cell style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue CellSelectedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CellSelectedStyle", this.CellNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the grid lines style.
        /// </summary>
        /// <value></value>
        [Category("Styles"), SRDescription("The color of the grid lines style.")]
        public virtual BorderStyle GridLinesStyle
        {
            get
            {
                return this.GetValue<BorderStyle>("GridLinesStyle", BorderStyle.FixedSingle);
            }
            set
            {
                this.SetValue("GridLinesStyle", value);
            }
        }

        #endregion

        #region Sizes

        /// <summary>
        /// Gets the width of the drop indicator down arrow image.
        /// </summary>
        /// <value>
        /// The width of the drop indicator down arrow image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DropIndicatorDownArrowImageWidth
        {
            get
            {
                return GetImageWidth(this.DropIndicatorStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the height of the drop indicator down arrow image.
        /// </summary>
        /// <value>
        /// The height of the drop indicator down arrow image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int DropIndicatorDownArrowImageHeight
        {
            get
            {
                return GetImageHeight(this.DropIndicatorStyle.BackgroundImage);
            }
        }

        [Category("Sizes"), SRDescription("The grouping drop area height.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual int DropAreaHeight
        {
            get
            {
                return GetValue<int>("DropAreaHeight", 100);
            }
            set
            {
                SetValue("DropAreaHeight", value);
            }
        }

        /// <summary>
        /// Gets the width of the filter clear button image.
        /// </summary>
        /// <value>
        /// The width of the filter clear button image.
        /// </value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int FilterClearButtonImageWidth
        {
            get
            {
                return this.GetImageWidth(this.FilterRowClearButtonStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the height of the filter clear button image.
        /// </summary>
        /// <value>
        /// The height of the filter clear button image.
        /// </value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int FilterClearButtonImageHeight
        {
            get
            {
                return this.GetImageHeight(this.FilterRowClearButtonStyle.BackgroundImage);
            }
        }


        /// <summary>
        /// Gets or sets the clear all filters button margin.
        /// </summary>
        /// <value>
        /// The clear all filters button margin.
        /// </value>
        [Category("Sizes"), SRDescription("The \"Clear All Filters\" button margin.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ClearAllFiltersButtonMargin
        {
            get
            {
                return this.GetValue<int>("ClearAllFiltersButtonMargin", 5);

            }
            set
            {
                this.SetValue("ClearAllFiltersButtonMargin", value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the grid lines.
        /// </summary>
        /// <value></value>
        [Category("Sizes"), SRDescription("The width of the grid lines.")]
        public virtual BorderWidth GridLinesWidth
        {
            get
            {
                return this.GetValue<BorderWidth>("GridLinesWidth", this.DefaultGridLinesWidth);
            }
            set
            {
                this.SetValue("GridLinesWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the grid lines.
        /// </summary>
        private void ResetGridLinesWidth()
        {
            this.Reset("GridLinesWidth");
        }

        /// <summary>
        /// Gets the default width of the grid lines.
        /// </summary>
        /// <value>The default width of the grid lines.</value>
        protected virtual BorderWidth DefaultGridLinesWidth
        {
            get
            {
                return new BorderWidth(1);
            }
        }



        #endregion

        #region Colors

        /// <summary>
        /// Gets or sets the grid lines color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), SRDescription("The color of the grid lines.")]
        public Color GridLinesColor
        {
            get
            {
                return this.GetValue<Color>("GridLinesColor", this.DefaultGridLinesColor);
            }
            set
            {
                this.SetValue("GridLinesColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the grid lines.
        /// </summary>
        private void ResetGridLinesColor()
        {
            this.Reset("GridLinesColor");
        }

        /// <summary>
        /// Gets the default color of the grid lines.
        /// </summary>
        /// <value>The default color of the grid lines.</value>
        protected virtual Color DefaultGridLinesColor
        {
            get
            {
                return Color.FromArgb(208, 215, 229);
            }
        }



        #endregion

        #region Borders

        /// <summary>
        /// Gets the grid lines style which can be translated.
        /// </summary>
        /// <value>The grid lines style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BorderValue GridLines
        {
            get
            {
                BorderValue objBorderValue = new BorderValue();
                objBorderValue.Color = this.GridLinesColor;
                objBorderValue.Style = this.GridLinesStyle;
                objBorderValue.Width = this.GridLinesWidth;
                return objBorderValue;
            }
        }

        #endregion

        #region Paging

        #region Sizes

        /// <summary>
        /// Gets or sets the height of the paging control.
        /// </summary>
        /// <value>The height of the paging control.</value>
        [Category("Paging"), SRDescription("The paging control height.")]
        public virtual int PagingPanelHeight
        {
            get
            {
                return this.GetValue<int>("PagingPanelHeight", this.GetImageHeight(this.PagingPanelStyle.BackgroundImage, this.DefaultPagingPanelHeight));
            }
            set
            {
                this.SetValue("PagingPanelHeight", value);
            }
        }

        /// <summary>
        /// Resets the height of the paging panel.
        /// </summary>
        internal void ResetPagingPanelHeight()
        {
            this.Reset("PagingPanelHeight");
        }

        /// <summary>
        /// Gets the default height of the paging panel.
        /// </summary>
        /// <value>The default height of the paging panel.</value>
        protected virtual int DefaultPagingPanelHeight
        {
            get
            {
                return 21;
            }
        }

        /// <summary>
        /// Gets or sets the width of the paging first button.
        /// </summary>
        /// <value>The width of the paging first button.</value>
        [Category("Paging"), SRDescription("The paging first button width.")]
        public virtual int PagingFirstButtonWidth
        {
            get
            {
                return this.GetValue<int>("PagingFirstButtonWidth", this.DefaultPagingFirstButtonWidth);

            }
            set
            {
                this.SetValue("PagingFirstButtonWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the paging first button.
        /// </summary>
        internal void ResetPagingFirstButtonWidth()
        {
            this.Reset("PagingFirstButtonWidth");
        }

        /// <summary>
        /// Gets the default width of the paging first button.
        /// </summary>
        /// <value>The default width of the paging first button.</value>
        protected virtual int DefaultPagingFirstButtonWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets or sets the width of the paging last button.
        /// </summary>
        /// <value>The width of the paging last button.</value>
        [Category("Paging"), SRDescription("The paging last button width.")]
        public virtual int PagingLastButtonWidth
        {
            get
            {
                return this.GetValue<int>("PagingLastButtonWidth", this.DefaultPagingLastButtonWidth);
                //return this.GetValue<int>("PagingLastButtonWidth", this.GetImageWidth(this.PagingLastButtonStyle.BackgroundImage, 20));
            }
            set
            {
                this.SetValue("PagingLastButtonWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the paging last button.
        /// </summary>
        internal void ResetPagingLastButtonWidth()
        {
            this.Reset("PagingLastButtonWidth");
        }

        /// <summary>
        /// Gets the default width of the paging last button.
        /// </summary>
        /// <value>The default width of the paging last button.</value>
        protected virtual int DefaultPagingLastButtonWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets or sets the width of the paging previous button.
        /// </summary>
        /// <value>The width of the paging previous button.</value>
        [Category("Paging"), SRDescription("The paging previous button width.")]
        public virtual int PagingPreviousButtonWidth
        {
            get
            {
                return this.GetValue<int>("PagingPreviousButtonWidth", this.DefaultPagingPreviousButtonWidth);
            }
            set
            {
                this.SetValue("PagingPreviousButtonWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the paging previous button.
        /// </summary>
        internal void ResetPagingPreviousButtonWidth()
        {
            this.Reset("PagingPreviousButtonWidth");
        }

        /// <summary>
        /// Gets the default width of the paging previous button.
        /// </summary>
        /// <value>The default width of the paging previous button.</value>
        protected virtual int DefaultPagingPreviousButtonWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets or sets the width of the paging next button.
        /// </summary>
        /// <value>The width of the paging next button.</value>
        [Category("Paging"), SRDescription("The paging next button width.")]
        public virtual int PagingNextButtonWidth
        {
            get
            {
                return this.GetValue<int>("PagingNextButtonWidth", this.DefaultPagingNextButtonWidth);
            }
            set
            {
                this.SetValue("PagingNextButtonWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the paging next button.
        /// </summary>
        internal void ResetPagingNextButtonWidth()
        {
            this.Reset("PagingNextButtonWidth");
        }

        /// <summary>
        /// Gets the default width of the paging next button.
        /// </summary>
        /// <value>The default width of the paging next button.</value>
        protected virtual int DefaultPagingNextButtonWidth
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets or sets the width of the paging box.
        /// </summary>
        /// <value>The width of the paging box.</value>
        [Category("Paging"), SRDescription("The paging box width.")]
        public virtual int PagingBoxWidth
        {
            get
            {
                return this.GetValue<int>("PagingBoxWidth", this.DefaultPagingBoxWidth);
            }
            set
            {
                this.SetValue("PagingBoxWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the paging box.
        /// </summary>
        internal void ResetPagingBoxWidth()
        {
            this.Reset("PagingBoxWidth");
        }

        /// <summary>
        /// Gets the default width of the paging box.
        /// </summary>
        /// <value>The default width of the paging box.</value>
        protected virtual int DefaultPagingBoxWidth
        {
            get
            {
                return 50;
            }
        }


        #endregion

        #region Styles

        /// <summary>
        /// Gets the 'GoTo' box style.
        /// </summary>
        /// <value>The 'GoTo' box style.</value>
        [Category("Paging"), SRDescription("The current page / 'Go To' box style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PagingGotoBoxStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PagingGotoBoxStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the paging panel style.
        /// </summary>
        /// <value>The paging panel style.</value>
        [Category("Paging"), SRDescription("The pagging panel style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PagingPanelStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PagingPanelStyle");

                return objStyle;
            }
        }



        /// <summary>
        /// Gets the paging prev button style.
        /// </summary>
        /// <value>The paging prev button style.</value>
        [Category("Paging"), SRDescription("The paging prev button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PagingPrevButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PagingPrevButtonStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the paging next button style.
        /// </summary>
        /// <value>The paging next button style.</value>
        [Category("Paging"), SRDescription("The paging next button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PagingNextButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PagingNextButtonStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the paging last button style.
        /// </summary>
        /// <value>The paging last button style.</value>
        [Category("Paging"), SRDescription("The paging last button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PagingLastButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PagingLastButtonStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the paging first button style.
        /// </summary>
        /// <value>The paging first button style.</value>
        [Category("Paging"), SRDescription("The paging first button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue PagingFirstButtonStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "PagingFirstButtonStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bidirectional paging last button style.
        /// </summary>
        /// <value>The bidirectional paging last button style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue BidirectionalPagingLastButtonStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.PagingLastButtonStyle, this.PagingFirstButtonStyle);
            }
        }

        /// <summary>
        /// Gets the bidirectional paging first button style.
        /// </summary>
        /// <value>The bidirectional paging first button style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue BidirectionalPagingFirstButtonStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.PagingFirstButtonStyle, this.PagingLastButtonStyle);
            }
        }

        /// <summary>
        /// Gets the bidirectional paging prev button style.
        /// </summary>
        /// <value>The bidirectional paging prev button style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue BidirectionalPagingPrevButtonStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.PagingPrevButtonStyle, this.PagingNextButtonStyle);
            }
        }

        /// <summary>
        /// Gets the bidirectional paging next button style.
        /// </summary>
        /// <value>The bidirectional paging next button style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SkinValue BidirectionalPagingNextButtonStyle
        {
            get
            {
                return new BidirectionalSkinValue<StyleValue>(this, this.PagingNextButtonStyle, this.PagingPrevButtonStyle);
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the paging number seperator format.
        /// </summary>
        /// <value>
        /// The paging number seperator format.
        /// </value>
        [Category("Paging"), SRDescription("The paging number seperator format.")]
        public string PagingNumberSeperatorFormat
        {
            get
            {
                return this.GetValue<string>("PagingNumberSeperatorFormat", this.DefaultPagingNumberSeperatorFormat);
            }
            set
            {
                this.SetValue("PagingNumberSeperatorFormat", value);
            }
        }


        /// <summary>
        /// Gets the default paging number seperator format.
        /// </summary>
        public string DefaultPagingNumberSeperatorFormat
        {
            get
            {
                return "/";
            }
        }

        #endregion

        #region Filtering related.

        /// <summary>
        /// Gets or sets the equals comparision operator.
        /// </summary>
        /// <value>
        /// The equals comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The equals comparison operator.")]
        public virtual ImageResourceReference EqualsComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("EqualsComparisionOperator", "");
            }
            set
            {
                this.SetValue("EqualsComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the not equals comparision operator.
        /// </summary>
        /// <value>
        /// The not equals comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The NotEquals comparison operator.")]
        public virtual ImageResourceReference NotEqualsComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("NotEqualsComparisionOperator", "");
            }
            set
            {
                this.SetValue("NotEqualsComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the initial operator image.
        /// </summary>
        /// <value>
        /// The initial operator image.
        /// </value>
        [SRCategory("Images"), SRDescription("The initial operator image.")]
        public virtual ImageResourceReference InitialOperatorImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("InitialOperatorImage", "");
            }
            set
            {
                this.SetValue("InitialOperatorImage", value);
            }
        }

        /// <summary>
        /// Gets or sets the less than comparision operator.
        /// </summary>
        /// <value>
        /// The less than comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The LessThan comparison operator.")]
        public virtual ImageResourceReference LessThanComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("LessThanComparisionOperator", "");
            }
            set
            {
                this.SetValue("LessThanComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the less than or equal to comparision operator.
        /// </summary>
        /// <value>
        /// The less than or equal to comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The LessThanOrEqualTo comparison operator.")]
        public virtual ImageResourceReference LessThanOrEqualToComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("LessThanOrEqualToComparisionOperator", "");
            }
            set
            {
                this.SetValue("LessThanOrEqualToComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the greater than comparision operator.
        /// </summary>
        /// <value>
        /// The greater than comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The GreaterThan comparison operator.")]
        public virtual ImageResourceReference GreaterThanComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("GreaterThanComparisionOperator", "");
            }
            set
            {
                this.SetValue("GreaterThanComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the greater than or equal to comparision operator.
        /// </summary>
        /// <value>
        /// The greater than or equal to comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The GreaterThanOrEqualTo comparison operator.")]
        public virtual ImageResourceReference GreaterThanOrEqualToComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("GreaterThanOrEqualToComparisionOperator", "");
            }
            set
            {
                this.SetValue("GreaterThanOrEqualToComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the like comparision operator.
        /// </summary>
        /// <value>
        /// The like comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The Like comparison operator.")]
        public virtual ImageResourceReference LikeComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("LikeComparisionOperator", "");
            }
            set
            {
                this.SetValue("LikeComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the match comparision operator.
        /// </summary>
        /// <value>
        /// The match comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The Match comparison operator.")]
        public virtual ImageResourceReference MatchComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("MatchComparisionOperator", "");
            }
            set
            {
                this.SetValue("MatchComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the not like comparision operator.
        /// </summary>
        /// <value>
        /// The not like comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The NotLike comparison operator.")]
        public virtual ImageResourceReference NotLikeComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("NotLikeComparisionOperator", "");
            }
            set
            {
                this.SetValue("NotLikeComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the does not match comparision operator.
        /// </summary>
        /// <value>
        /// The does not match comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The DoesNotMatch comparison operator.")]
        public virtual ImageResourceReference DoesNotMatchComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DoesNotMatchComparisionOperator", "");
            }
            set
            {
                this.SetValue("DoesNotMatchComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the starts with comparision operator.
        /// </summary>
        /// <value>
        /// The starts with comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The StartsWith comparison operator.")]
        public virtual ImageResourceReference StartsWithComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("StartsWithComparisionOperator", "");
            }
            set
            {
                this.SetValue("StartsWithComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the does not start with comparision operator.
        /// </summary>
        /// <value>
        /// The does not start with comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The DoesNotStartWith comparison operator.")]
        public virtual ImageResourceReference DoesNotStartWithComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DoesNotStartWithComparisionOperator", "");
            }
            set
            {
                this.SetValue("DoesNotStartWithComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the ends with comparision operator.
        /// </summary>
        /// <value>
        /// The ends with comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The EndsWith comparison operator.")]
        public virtual ImageResourceReference EndsWithComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("EndsWithComparisionOperator", "");
            }
            set
            {
                this.SetValue("EndsWithComparisionOperator", value);
            }
        }

        [SRCategory("Images"), SRDescription("The DoesNotEndWith comparison operator.")]
        public virtual ImageResourceReference DoesNotEndWithComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DoesNotEndWithComparisionOperator", "");
            }
            set
            {
                this.SetValue("DoesNotEndWithComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the contains comparision operator.
        /// </summary>
        /// <value>
        /// The contains comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The Contains comparison operator.")]
        public virtual ImageResourceReference ContainsComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("ContainsComparisionOperator", "");
            }
            set
            {
                this.SetValue("ContainsComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the does not contain comparision operator.
        /// </summary>
        /// <value>
        /// The does not contain comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The DoesNotContain comparison operator.")]
        public virtual ImageResourceReference DoesNotContainComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("DoesNotContainComparisionOperator", "");
            }
            set
            {
                this.SetValue("DoesNotContainComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the custom comparision operator.
        /// </summary>
        /// <value>
        /// The custom comparision operator.
        /// </value>
        [SRCategory("Images"), SRDescription("The Custom comparison operator.")]
        public virtual ImageResourceReference CustomComparisionOperator
        {
            get
            {
                return this.GetValue<ImageResourceReference>("CustomComparisionOperator", "");
            }
            set
            {
                this.SetValue("CustomComparisionOperator", value);
            }
        }

        /// <summary>
        /// Gets or sets the filter clear button image.
        /// </summary>
        /// <value>
        /// The filter clear button image.
        /// </value>
        [SRCategory("Images"), SRDescription("The filter clear button image.")]
        public virtual ImageResourceReference FilterCellClearButtonImage
        {
            get
            {
                return GetValue<ImageResourceReference>("FilterCellClearButtonImage", "");
            }

            set
            {
                SetValue("FilterCellClearButtonImage", value);
            }
        }

        /// <summary>
        /// Gets the width of the header filter combo box image.
        /// </summary>
        /// <value>
        /// The width of the header filter combo box image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SkinValue HeaderFilterComboBoxImageWidth
        {
            get
            {
                DataGridViewHeaderFilterComboBoxSkin objDataGridViewHeaderFilterComboBoxSkin = SkinFactory.GetSkin(this.Owner, typeof(DataGridViewHeaderFilterComboBoxSkin)) as DataGridViewHeaderFilterComboBoxSkin;

                if (objDataGridViewHeaderFilterComboBoxSkin != null)
                {
                    return objDataGridViewHeaderFilterComboBoxSkin.FilterNormalImageWidth;
                }

                return null;
            }
        }

        #endregion

        #region Images

        #region Sorting related

        /// <summary>
        /// Gets the sort ascending indicator image.
        /// </summary>
        [Category("Images"), Description("The column sorted ascending indicator image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageResourceReference SortAscendingIndicatorImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SortAscendingIndicatorImage", new ImageResourceReference(typeof(DataGridViewSkin), "ArrowUp.gif"));
            }
            set
            {
                this.SetValue("SortAscendingIndicatorImage", value);
            }
        }

        /// <summary>
        /// Gets the sort descending indicator image.
        /// </summary>
        [Category("Images"), Description("The column sorted descending indicator image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageResourceReference SortDescendingIndicatorImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SortDescendingIndicatorImage", new ImageResourceReference(typeof(DataGridViewSkin), "ArrowDown.gif"));
            }
            set
            {
                this.SetValue("SortDescendingIndicatorImage", value);
            }
        }

        #endregion

        #region Edit mode related

        [Category("Images"), Description("The row header edit mode Image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> RowHeaderEditModeImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "RowHeaderEditModeImageLTR", "RowHeaderEditModeImageRTL");
            }
        }


        /// <summary>
        /// Gets or sets the drop down over image LTR.
        /// </summary>
        /// <value>The drop down over image LTR.</value>
        [Description("The row header edit mode left to right over image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference RowHeaderEditModeImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RowHeaderEditModeImageLTR", new ImageResourceReference(typeof(DataGridViewSkin), "DGVEditedModeLTR.gif"));
            }
            set
            {
                this.SetValue("RowHeaderEditModeImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the drop down over image RTL.
        /// </summary>
        /// <value>The drop down over image RTL.</value>
        [Description("The row header edit mode right to left over image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference RowHeaderEditModeImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RowHeaderEditModeImageRTL", new ImageResourceReference(typeof(DataGridViewSkin), "DGVEditedModeRTL.gif"));
            }
            set
            {
                this.SetValue("RowHeaderEditModeImageRTL", value);
            }
        }

        #endregion

        #region Selected mode related

        [Category("Images"), Description("The row header Selected mode Image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BidirectionalSkinProperty<ImageResourceReference> RowHeaderSelectedModeImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "RowHeaderSelectedModeImageLTR", "RowHeaderSelectedModeImageRTL");
            }
        }


        /// <summary>
        /// Gets or sets the drop down over image LTR.
        /// </summary>
        /// <value>The drop down over image LTR.</value>
        [Description("The row header Selected mode left to right over image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference RowHeaderSelectedModeImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RowHeaderSelectedModeImageLTR", new ImageResourceReference(typeof(DataGridViewSkin), "DGVSelectedModeLTR.gif"));
            }
            set
            {
                this.SetValue("RowHeaderSelectedModeImageLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the drop down over image RTL.
        /// </summary>
        /// <value>The drop down over image RTL.</value>
        [Description("The row header Selected mode right to left over image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference RowHeaderSelectedModeImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RowHeaderSelectedModeImageRTL", new ImageResourceReference(typeof(DataGridViewSkin), "DGVSelectedModeRTL.gif"));
            }
            set
            {
                this.SetValue("RowHeaderSelectedModeImageRTL", value);
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the row header new row mode image.
        /// </summary>
        /// <value>
        /// The row header new row mode image.
        /// </value>
        [Category("Images"), Description("The row header new row mode Image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageResourceReference RowHeaderNewRowModeImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RowHeaderNewRowModeImage", new ImageResourceReference(typeof(DataGridViewSkin), "DGVNewRowMode.gif"));
            }
            set
            {
                this.SetValue("RowHeaderNewRowModeImage", value);
            }
        }

        /// <summary>
        /// Gets or sets the row header error provider image.
        /// </summary>
        /// <value>
        /// The row header error provider image.
        /// </value>
        [Category("Images"), Description("The row header error Image.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageResourceReference RowHeaderErrorProviderImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("RowHeaderErrorProviderImage", new ImageResourceReference(typeof(DataGridViewSkin), "ErrorProvider.gif"));
            }
            set
            {
                this.SetValue("RowHeaderErrorProviderImage", value);
            }
        }

        /// <summary>
        /// Gets the size of the sort ascending indicator image.
        /// </summary>
        /// <value>
        /// The size of the sort ascending indicator image.
        /// </value>
        internal Size SortAscendingIndicatorImageSize
        {
            get
            {
                return this.GetImageSize(this.SortAscendingIndicatorImage, Size.Empty);
            }
        }

        /// <summary>
        /// Gets the size of the sort descending indicator image.
        /// </summary>
        /// <value>
        /// The size of the sort descending indicator image.
        /// </value>
        internal Size SortDescendingIndicatorImageSize
        {
            get
            {
                return this.GetImageSize(this.SortDescendingIndicatorImage, Size.Empty);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        /// <param name="strImageFileName">Name of the STR image file.</param>
        /// <returns></returns>
        internal Size GetImageSize(string strImageFileName)
        {
            if (!string.IsNullOrEmpty(strImageFileName))
            {
                return this.GetImageSize(new ImageResourceReference(typeof(DataGridViewSkin), strImageFileName), Size.Empty);
            }

            return Size.Empty;
        }

        #endregion

        #region Hierarchy

        /// <summary>
        /// Gets or sets the width of the expand collapse column.
        /// </summary>
        /// <value>
        /// The width of the expand collapse column.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ExpandCollapseColumnWidth
        {
            get
            {
                return Math.Max(Math.Max(this.ExpandButtonImageWidth + this.ExpandButtonImageStyle.Padding.Horizontal, this.CollapseButtonImageWidth + this.CollapseButtonImageStyle.Padding.Horizontal), this.EmptyExpandCollapseImageWidth + this.EmptyExpandCollapseImageStyle.Padding.Horizontal);
            }
        }

        /// <summary>
        /// Gets the expand button image style.
        /// </summary>
        [Category("States"), SRDescription("The expand button image style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue EmptyExpandCollapseImageStyle
        {
            get
            {
                return new StyleValue(this, "EmptyExpandCollapseImageStyle");
            }
        }

        /// <summary>
        /// Gets the width of the expand button image.
        /// </summary>
        /// <value>
        /// The width of the expand button image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal int EmptyExpandCollapseImageWidth
        {
            get
            {
                return GetImageSize(this.EmptyExpandCollapseImageStyle.BackgroundImage, Size.Empty).Width;
            }
        }

        /// <summary>
        /// Gets the expand button image style.
        /// </summary>
        [Category("States"), SRDescription("The column chooser style")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ColumnChooserStyle
        {
            get
            {
                return new StyleValue(this, "ColumnChooserStyle");
            }
        }

        /// <summary>
        /// Gets the expand button image style.
        /// </summary>
        [Category("States"), SRDescription("The expand button image style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ExpandButtonImageStyle
        {
            get
            {
                return new StyleValue(this, "ExpandButtonImageStyle");
            }
        }

        /// <summary>
        /// Gets the width of the expand button image.
        /// </summary>
        /// <value>
        /// The width of the expand button image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal int ExpandButtonImageWidth
        {
            get
            {
                return GetImageSize(this.ExpandButtonImageStyle.BackgroundImage, Size.Empty).Width;
            }
        }

        /// <summary>
        /// Gets the collapse button image style.
        /// </summary>
        [Category("States"), SRDescription("The collapse button image style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue CollapseButtonImageStyle
        {
            get
            {
                return new StyleValue(this, "CollapseButtonImageStyle");
            }
        }

        /// <summary>
        /// Gets the width of the collapse button image.
        /// </summary>
        /// <value>
        /// The width of the collapse button image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal int CollapseButtonImageWidth
        {
            get
            {
                return GetImageSize(this.CollapseButtonImageStyle.BackgroundImage, Size.Empty).Width;
            }
        }

        /// <summary>
        /// Gets the row header style for the expanded grid.
        /// </summary>
        [Category("States"), SRDescription("The row header for the expanded Data Grid View.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ExpandedRowHeaderStyle
        {
            get
            {
                return new StyleValue(this, "ExpandedRowHeaderStyle");
            }
        }

        #endregion
    }
}

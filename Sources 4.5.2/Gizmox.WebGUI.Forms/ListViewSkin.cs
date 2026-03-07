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
    /// ListView Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ListView), "ListView.bmp"), Serializable()]
    public class ListViewSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        private void InitializeComponent()
        {

        }

        
        #region Sizes

        /// <summary>
        /// Gets or sets the height of the large item label.
        /// </summary>
        /// <value>
        /// The height of the large item label.
        /// </value>
        [Category("Sizes"), SRDescription("The height of a large item label.")]
        public int LargeItemLabelHeight 
        {
            get 
            {
                return this.GetValue<int>("LargeItemLabelHeight", 27);

            }
            set
            {
                this.SetValue("LargeItemLabelHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the row back.
        /// </summary>
        /// <value>The color of the row back.</value>
        [Category("Colors"), SRDescription("The row backcolor.")]
        public virtual Color RowBackColor
        {
            get
            {
                return this.GetValue<Color>("RowBackColor", this.DefaultRowBackColor);
            }
            set
            {
                this.SetValue("RowBackColor", value);
            }
        }


        /// <summary>
        /// Resets the color of the row back.
        /// </summary>
        internal void ResetRowBackColor()
        {
            this.Reset("RowBackColor");
        }

        /// <summary>
        /// Gets the default color of the row back.
        /// </summary>
        /// <value>The default color of the row back.</value>
        protected virtual Color DefaultRowBackColor
        {
            get
            {
                return SystemColors.Window;
            }
        }


        /// <summary>
        /// Gets or sets the color of the row fore.
        /// </summary>
        /// <value>The color of the row fore.</value>
        [Category("Colors"), SRDescription("The row fore color.")]
        public virtual Color RowForeColor
        {
            get
            {
                return this.GetValue<Color>("RowForeColor", this.DefaultRowForeColor);
            }
            set
            {
                this.SetValue("RowForeColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the row fore.
        /// </summary>
        internal void ResetRowForeColor()
        {
            this.Reset("RowForeColor");
        }

        /// <summary>
        /// Gets the default color of the row fore.
        /// </summary>
        /// <value>The default color of the row fore.</value>
        protected virtual Color DefaultRowForeColor
        {
            get
            {
                return SystemColors.WindowText;
            }
        }

        /// <summary>
        /// Gets or sets the row font.
        /// </summary>
        /// <value>The row font.</value>
        [Category("Fonts"), SRDescription("The row font.")]
        public virtual Font RowFont
        {
            get
            {
                return this.GetValue<Font>("RowFont", this.DefaultRowFont);
            }
            set
            {
                this.SetValue("RowFont", value);
            }
        }

        /// <summary>
        /// Resets the row font.
        /// </summary>
        internal void ResetRowFont()
        {
            this.Reset("RowFont");
        }

        /// <summary>
        /// Gets the default row font.
        /// </summary>
        /// <value>The default row font.</value>
        protected virtual Font DefaultRowFont
        {
            get
            {
                return this.Font;
            }
        }

        /// <summary>
        /// Gets the width of the header seperator.
        /// </summary>
        /// <value>The width of the header seperator.</value>
        [Category("Sizes"), SRDescription("The width of the header seperator.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual int HeaderSeperatorWidth
        {
            get
            {
                return this.GetValue<int>("HeaderSeperatorWidth", this.DefaultHeaderSeperatorWidth);
            }
            set
            {
                this.SetValue("HeaderSeperatorWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the header seperator.
        /// </summary>
        internal void ResetHeaderSeperatorWidth()
        {
            this.Reset("HeaderSeperatorWidth");
        }

        /// <summary>
        /// Gets the default width of the header seperator.
        /// </summary>
        /// <value>The default width of the header seperator.</value>
        protected virtual int DefaultHeaderSeperatorWidth
        {
            get
            {
                return 3;
            }
        }

        /// <summary>
        /// Gets the height of the check box button.
        /// </summary>
        /// <value>The height of the check box button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CheckBoxButtonHeight
        {
            get
            {
                return this.GetMaxImageHeight(this.DefaultCheckBoxButtonHeight, "CheckBox0.gif", "CheckBox1.gif");
            }
        }

        /// <summary>
        /// Resets the height of the check box button.
        /// </summary>
        private void ResetCheckBoxButtonHeight()
        {
            this.Reset("CheckBoxButtonHeight");
        }

        /// <summary>
        /// Gets the default height of the check box button.
        /// </summary>
        /// <value>The default height of the check box button.</value>
        protected virtual int DefaultCheckBoxButtonHeight
        {
            get
            {
                return 13;
            }
        }

        /// <summary>
        /// Gets the width of the check box button.
        /// </summary>
        /// <value>The width of the check box button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CheckBoxButtonWidth
        {
            get
            {
                return this.GetMaxImageWidth(this.DefaultCheckBoxButtonWidth, "CheckBox0.gif", "CheckBox1.gif");
            }
        }

        /// <summary>
        /// Resets the width of the check box button.
        /// </summary>
        private void ResetCheckBoxButtonWidth()
        {
            this.Reset("CheckBoxButtonWidth");
        }

        /// <summary>
        /// Gets the default width of the check box button.
        /// </summary>
        /// <value>The default width of the check box button.</value>
        protected virtual int DefaultCheckBoxButtonWidth
        {
            get
            {
                return 13;
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
        internal void ResetGridLinesWidth()
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

        #region Styles

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
        /// Gets the cell alternative style.
        /// </summary>
        /// <value>The cell alternative style.</value>
        [Category("States"), SRDescription("The alternative cell style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue CellAlternativeStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CellAlternativeStyle");
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
                StyleValue objStyle = new StyleValue(this, "CellSelectedStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header normal style.
        /// </summary>
        /// <value>The header normal style.</value>
        [Category("States"), SRDescription("The normal header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header hover style.
        /// </summary>
        /// <value>The header hover style.</value>
        [Category("States"), SRDescription("The hover header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderHoverStyle", this.HeaderNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header pressed style.
        /// </summary>
        /// <value>The header pressed style.</value>
        [Category("States"), SRDescription("The pressed header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderPressedStyle", this.HeaderNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header disabled style.
        /// </summary>
        /// <value>The header disabled style.</value>
        [Category("States"), SRDescription("The normal header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderDisabledStyle", this.HeaderNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header seperator normal style.
        /// </summary>
        /// <value>The header seperator normal style.</value>
        [Category("States"), SRDescription("The normal header seperator style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderSeperatorNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderSeperatorNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header seperator hover style.
        /// </summary>
        /// <value>The header seperator hover style.</value>
        [Category("States"), SRDescription("The hover header seperator style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderSeperatorHoverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderSeperatorHoverStyle", this.HeaderNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header seperator pressed style.
        /// </summary>
        /// <value>The header seperator pressed style.</value>
        [Category("States"), SRDescription("The pressed header seperator style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue HeaderSeperatorPressedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderSeperatorPressedStyle", this.HeaderNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the header seperator disabled style.
        /// </summary>
        /// <value>The header seperator disabled style.</value>
        [Category("States"), SRDescription("The normal header seperator style.")]
        public virtual StyleValue HeaderSeperatorDisabledStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderSeperatorDisabledStyle", this.HeaderNormalStyle);
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

        /// <summary>
        /// Resets the grid lines style.
        /// </summary>
        internal void ResetGridLinesStyle()
        {
            this.Reset("GridLinesStyle");
        }

        #endregion
          
        #region Colors

        /// <summary>
        /// Gets or sets the group header seperator color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), Description("The color which is used to display group header seperator.")]
        public virtual Color GroupHeaderSeperatorColor
        {
            get
            {
                return this.GetValue<Color>("GroupHeaderSeperatorColor", this.DefaultGroupHeaderSeperatorColor);
            }
            set
            {
                this.SetValue("GroupHeaderSeperatorColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the group header seperator.
        /// </summary>
        internal void ResetGroupHeaderSeperatorColor()
        {
            this.Reset("GroupHeaderSeperatorColor");
        }

        /// <summary>
        /// Gets the default color of the group header seperator.
        /// </summary>
        /// <value>The default color of the group header seperator.</value>
        protected virtual Color DefaultGroupHeaderSeperatorColor
        {
            get
            {
                return Color.FromArgb(187, 190, 209);
            }
        }

        /// <summary>
        /// Gets the group header style.
        /// </summary>
        [Category("GroupHeader"), SRDescription("The group header style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue GroupHeaderStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "GroupHeaderStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Resets the group header style.
        /// </summary>
        internal void ResetGroupHeaderStyle()
        {
            this.GroupHeaderStyle.Reset();
        }

        /// <summary>
        /// Gets or sets the group header fore color.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Colors"), Description("The foreground color of this component, which is used to display group header text.")]
        [Obsolete("This property is obselete, Please use GroupHeaderStyle propert.y")]
        public virtual Color GroupHeaderForeColor
        {
            get
            {
                return this.GetValue<Color>("GroupHeaderForeColor", this.DefaultGroupHeaderForeColor );
            }
            set
            {
                this.SetValue("GroupHeaderForeColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the group header fore.
        /// </summary>
        [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
        internal void ResetGroupHeaderForeColor()
        {
            this.Reset("GroupHeaderForeColor");
        }

        /// <summary>
        /// Gets the default color of the group header fore.
        /// </summary>
        /// <value>The default color of the group header fore.</value>
        [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
        protected virtual Color DefaultGroupHeaderForeColor
        {
            get
            {
                return Color.FromArgb(36, 62, 137);
            }
        }

        /// <summary>
        /// Gets or sets the grid lines color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), SRDescription("The color of the grid lines.")]
        public virtual Color GridLinesColor
        {
            get
            {
                return this.GetValue<Color>("GridLinesColor", this.DefaultGridLinesColor );
            }
            set
            {
                this.SetValue("GridLinesColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the grid lines.
        /// </summary>
        internal void ResetGridLinesColor()
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
                return Color.FromArgb(213, 213, 213);
            }
        }

        /// <summary>
        /// Gets or sets the sorted column background color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), SRDescription("The sorted column background color.")]
        public virtual Color SortedColumnBackColor
        {
            get
            {
                return this.GetAmbientValue<Color>("SortedColumnBackColor", this.DefaultSortedColumnBackColor);
            }
            set
            {
                this.SetValue("SortedColumnBackColor", value);
            }
        }

        /// <summary>
        /// Resets the color of the sorted column back.
        /// </summary>
        internal void ResetSortedColumnBackColor()
        {
            this.Reset("SortedColumnBackColor");
        }

        /// <summary>
        /// Gets the default color of the sorted column back.
        /// </summary>
        /// <value>The default color of the sorted column back.</value>
        protected virtual Color DefaultSortedColumnBackColor
        {
            get
            {
                return Color.FromArgb(247, 247, 247);
            }
        }

        #endregion


        /// <summary>
        /// Gets the group header seperator background.
        /// </summary>
        /// <value>The group header seperator background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundValue GroupHeaderSeperatorBackground
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                objBackgroundValue.BackColor = this.GroupHeaderSeperatorColor;
                return objBackgroundValue;
            }
        }

        /// <summary>
        /// Gets or sets the font of the group header text displayed by the control.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Fonts"), Description("The font used to display group header text in the control.")]
        [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
        public virtual Font GroupHeaderFont
        {
            get
            {
                return this.GetValue<Font>("GroupHeaderFont", this.DefaultGroupHeaderFont);
            }
            set
            {
                this.SetValue("GroupHeaderFont", value);
            }
        }

        /// <summary>
        /// Resets the group header font.
        /// </summary>
        [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
        internal void ResetGroupHeaderFont()
        {
            this.Reset("GroupHeaderFont");
        }

        /// <summary>
        /// Gets the default group header font.
        /// </summary>
        /// <value>The default group header font.</value>
        [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
        protected virtual Font DefaultGroupHeaderFont
        {
            get
            {
                return new Font("Tahoma", 8.25f);
            }
        }

        /// <summary>
        /// Gets the group header foreground.
        /// </summary>
        /// <value>The group header foreground.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
        public virtual ForegroundValue GroupHeaderForeground
        {
            get
            {
                ForegroundValue objForegroundValue = new ForegroundValue();
                objForegroundValue.ForeColor = this.GroupHeaderForeColor;
                return objForegroundValue;
            }
        }

        /// <summary>
        /// Gets the grid lines style which can be translated.
        /// </summary>
        /// <value>The grid lines style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BorderValue GridLines
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

        /// <summary>
        /// Gets or sets a value indicating whether to show grid lines.
        /// </summary>
        /// <value><c>true</c> to show grid lines; otherwise, <c>false</c>.</value>
        [Category("States"), SRDescription("The show grid lines.")]
        public virtual bool ShowGridLines
        {
            get
            {
                return this.GetValue<bool>("ShowGridLines", this.DefaultShowGridLines);
            }
            set
            {
                this.SetValue("ShowGridLines", value);
            }
        }

        /// <summary>
        /// Resets the show grid lines.
        /// </summary>
        private void ResetShowGridLines()
        {
            this.Reset("ShowGridLines");
        }

        /// <summary>
        /// Gets the default show grid lines.
        /// </summary>
        /// <value>The default show grid lines.</value>
        protected virtual bool DefaultShowGridLines
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the sorted column background image.
        /// </summary>
        /// <value>The sorted column background image.</value>
        [SRDescription("The sorted column background image")]
        [SRCategory("CatAppearance")]
        public ImageResourceReference SortedColumnBackgroundImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("SortedColumnBackgroundImage", "");
            }
            set
            {
                this.SetValue("SortedColumnBackgroundImage", value);
            }
        }

        /// <summary>
        /// Resets the sorted column background image.
        /// </summary>
        internal void ResetSortedColumnBackgroundImage()
        {
            this.Reset("SortedColumnBackgroundImage");
        }

        /// <summary>
        /// Gets or sets the sorted column background image repeat.
        /// </summary>
        /// <value>The sorted column background image repeat.</value>
        [SRDescription("Sets if or how a sorted column background image will be repeated.")]
        [SRCategory("CatAppearance")]
        public virtual BackgroundImageRepeat SortedColumnBackgroundImageRepeat
        {
            get
            {
                return this.GetValue<BackgroundImageRepeat>("SortedColumnBackgroundImageRepeat", this.DefaultSortedColumnBackgroundImageRepeat);
            }
            set
            {
                this.SetValue("SortedColumnBackgroundImageRepeat", value);
            }
        }

        /// <summary>
        /// Resets the sorted column background image repeat.
        /// </summary>
        internal void ResetSortedColumnBackgroundImageRepeat()
        {
            this.Reset("SortedColumnBackgroundImageRepeat");
        }

        /// <summary>
        /// Gets the default sorted column background image repeat.
        /// </summary>
        /// <value>The default sorted column background image repeat.</value>
        protected virtual BackgroundImageRepeat DefaultSortedColumnBackgroundImageRepeat
        {
            get
            {
                return BackgroundImageRepeat.Repeat;
            }
        }

        /// <summary>
        /// Gets or sets the sorted column background image position.
        /// </summary>
        /// <value>The sorted column background image position.</value>
        [SRDescription("Sets the starting position of a sorted column background image.")]
        [SRCategory("CatAppearance")]
        public virtual BackgroundImagePosition SortedColumnBackgroundImagePosition
        {
            get
            {
                return this.GetValue<BackgroundImagePosition>("SortedColumnBackgroundImagePosition", this.DefaultSortedColumnBackgroundImagePosition);
            }
            set
            {
                this.SetValue("SortedColumnBackgroundImagePosition", value);
            }
        }

        /// <summary>
        /// Resets the sorted column background image position.
        /// </summary>
        internal void ResetSortedColumnBackgroundImagePosition()
        {
            this.Reset("SortedColumnBackgroundImagePosition");
        }

        /// <summary>
        /// Gets the default sorted column background image position.
        /// </summary>
        /// <value>The default sorted column background image position.</value>
        protected virtual BackgroundImagePosition DefaultSortedColumnBackgroundImagePosition
        {
            get
            {
                return BackgroundImagePosition.TopLeft;
            }
        }

        /// <summary>
        /// Gets the sorted column background.
        /// </summary>
        /// <value>The sorted column background.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BackgroundValue SortedColumnBackground
        {
            get
            {
                BackgroundValue objBackgroundValue = new BackgroundValue();
                objBackgroundValue.BackColor = this.SortedColumnBackColor;
                objBackgroundValue.BackgroundImage = this.SortedColumnBackgroundImage;
                objBackgroundValue.BackgroundImagePosition = this.SortedColumnBackgroundImagePosition;
                objBackgroundValue.BackgroundImageRepeat = this.SortedColumnBackgroundImageRepeat;
                return objBackgroundValue;
            }
        }


        #region Temporary properties

        /// <summary>
        /// Gets the item size for view.
        /// </summary>
        /// <param name="enmView">The list view view.</param>
        /// <returns></returns>
        internal Size GetItemSizeForView(View enmView)
        {
            switch (enmView)
            {
                case View.LargeIcon:
                    return new Size(200, 200);
                case View.SmallIcon:
                    return new Size(130, 21);
                case View.List:
                    return new Size(100, 21);
            }

            return Size.Empty;
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
                return 22;
            }
        }

        /// <summary>
        /// Gets or sets the height of the header.
        /// </summary>
        /// <value>The height of the header.</value>
        [Category("Paging"), SRDescription("The header height.")]
        public virtual int HeaderHeight
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
        /// Gets the default height of the header.
        /// </summary>
        /// <value>The default height of the header.</value>
        protected virtual int DefaultHeaderHeight
        {
            get
            {
                return -1;
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
                //return this.GetValue<int>("PagingFirstButtonWidth", this.GetImageWidth(this.PagingFirstButtonStyle.BackgroundImage, 20));

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
                //return this.GetValue<int>("PagingPreviousButtonWidth", this.GetImageWidth(this.PagingPrevButtonStyle.BackgroundImage, 20));
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
                //return this.GetValue<int>("PagingNextButtonWidth", this.GetImageWidth(this.PagingNextButtonStyle.BackgroundImage, 20));

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
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// Provides loading customization capabilities
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ProgressBar))]
    public class TaskBarSkin : CommonSkin
    {
        #region Methods

        private void InitializeComponent()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the task bar item frame.
        /// </summary>
        /// <value>The task bar item frame.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public TextResourceReference ItemTemplate
        {
            get
            {
                return new TextResourceReference(typeof(TaskBarSkin), "TaskBarItemTemplate.htm");
            }
        }

        /// <summary>
        /// Gets the task bar item style.
        /// </summary>
        /// <value>The task bar item style.</value>
        [Category("States"), SRDescription("The taskbar item style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ItemStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the task bar item content style.
        /// </summary>
        /// <value>The task bar item content style.</value>
        [Category("States"), SRDescription("The taskbar item content style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ItemContentStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemContentStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the task bar item label style.
        /// </summary>
        /// <value>The task bar item label style.</value>
        [Category("States"), SRDescription("The taskbar item label style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ItemLabelStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemLabelStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the task bar item image style.
        /// </summary>
        /// <value>The task bar item image style.</value>
        [Category("States"), SRDescription("The taskbar item image style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StyleValue ItemImageStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemImageStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the width of the item content.
        /// </summary>
        /// <value>The width of the item content.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int ItemContentWidth
        {
            get
            {
                return this.ItemWidth - (this.ItemContentStyle.Margin.Right + this.ItemContentStyle.Margin.Left);
            }
        }

        /// <summary>
        /// Gets or sets the width of the task bar item image.
        /// </summary>
        /// <value>The width of the task bar item image.</value>
        [Category("Sizes"), Description("Task bar item height.")]
        public int ItemImageWidth
        {
            get
            {
                return this.GetValue<int>("ItemImageWidth", 16);
            }
            set
            {
                this.SetValue("ItemImageWidth", value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the task bar item image.
        /// </summary>
        /// <value>The height of the task bar item image.</value>
        [Category("Sizes"), Description("Task bar item height.")]
        public int ItemImageHeight
        {
            get
            {
                return this.GetValue<int>("ItemImageHeight", 16);
            }
            set
            {
                this.SetValue("ItemImageHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the task bar item.
        /// </summary>
        /// <value>The height of the task bar item.</value>
        [Category("Sizes"), Description("Task bar item height.")]
        public int ItemHeight
        {
            get
            {
                return this.GetValue<int>("ItemHeight", 28);
            }
            set
            {
                this.SetValue("ItemHeight", value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the task bar item.
        /// </summary>
        /// <value>The width of the task bar item.</value>
        [Category("Sizes"), Description("Task bar item width.")]
        public int ItemWidth
        {
            get
            {
                return this.GetValue<int>("ItemWidth", 158);
            }
            set
            {
                this.SetValue("ItemWidth", value);
            }
        }

        /// <summary>
        /// Gets the frame style.
        /// </summary>
        /// <value>The frame style.</value>
        [Category("States"), Description("The taskbar frame style.")]
        public FrameStyleValue FrameStyle
        {
            get
            {
                return new FrameStyleValue(
                    this.LeftBottomFrameStyle,
                    this.LeftFrameStyle,
                    this.LeftTopFrameStyle,
                    this.TopFrameStyle,
                    this.RightTopFrameStyle,
                    this.RightFrameStyle,
                    this.RightBottomFrameStyle,
                    this.BottomFrameStyle,
                    this.CenterFrameStyle);
            }
        }

        /// <summary>
        /// Gets the task bar item frame style.
        /// </summary>
        /// <value>The task bar item frame style.</value>
        [Category("States"), Description("The taskbar item frame style.")]
        public TripleCellFrameStyleValue ItemFrameNormalStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.ItemLeftFrameNormalStyle,
                    this.ItemRightFrameNormalStyle,
                    this.ItemCenterFrameNormalStyle);
            }
        }

        /// <summary>
        /// Gets the task bar item frame style.
        /// </summary>
        /// <value>The task bar item frame style.</value>
        [Category("States"), Description("The taskbar item frame style.")]
        public TripleCellFrameStyleValue ItemFrameOverStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.ItemLeftFrameOverStyle,
                    this.ItemRightFrameOverStyle,
                    this.ItemCenterFrameOverStyle);
            }
        }

        /// <summary>
        /// Gets the task bar item frame style.
        /// </summary>
        /// <value>The task bar item frame style.</value>
        [Category("States"), Description("The taskbar item frame style.")]
        public TripleCellFrameStyleValue ItemFrameDownStyle
        {
            get
            {
                return new TripleCellFrameStyleValue(
                    this.ItemLeftFrameDownStyle,
                    this.ItemRightFrameDownStyle,
                    this.ItemCenterFrameDownStyle);
            }
        }

        #region Taskbar frame style

        /// <summary>
        /// Gets the default width of the left frame.
        /// </summary>
        /// <value>The default width of the left frame.</value>
        protected virtual int DefaultLeftFrameWidth
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the default height of the bottom frame.
        /// </summary>
        /// <value>The default height of the bottom frame.</value>
        protected virtual int DefaultBottomFrameHeight
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the default width of the right frame.
        /// </summary>
        /// <value>The default width of the right frame.</value>
        protected virtual int DefaultRightFrameWidth
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the default height of the top frame.
        /// </summary>
        /// <value>The default height of the top frame.</value>
        protected virtual int DefaultTopFrameHeight
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int RightFrameWidth
        {
            get
            {
                return this.GetImageWidth(this.FrameStyle.RightStyle.BackgroundImage, this.DefaultRightFrameWidth);
            }
        }

        /// <summary>
        /// Gets or sets the height of the top frame.
        /// </summary>
        /// <value>The height of the top frame.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int TopFrameHeight
        {
            get
            {
                return this.GetImageHeight(this.FrameStyle.TopStyle.BackgroundImage, this.DefaultTopFrameHeight);
            }
        }

        /// <summary>
        /// Gets or sets the height of the bottom frame.
        /// </summary>
        /// <value>The height of the bottom frame.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int BottomFrameHeight
        {
            get
            {
                return this.GetImageHeight(this.FrameStyle.BottomStyle.BackgroundImage, this.DefaultBottomFrameHeight);
            }
        }

        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int LeftFrameWidth
        {
            get
            {
                return this.GetImageWidth(this.FrameStyle.LeftStyle.BackgroundImage, this.DefaultLeftFrameWidth);
            }
        }

        /// <summary>
        /// Gets the center frame style.
        /// </summary>
        /// <value>The center frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterFrameStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left frame style.
        /// </summary>
        /// <value>The left frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top frame style.
        /// </summary>
        /// <value>The top frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom frame style.
        /// </summary>
        /// <value>The bottom frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right frame style.
        /// </summary>
        /// <value>The right frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top frame style.
        /// </summary>
        /// <value>The right top frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top frame style.
        /// </summary>
        /// <value>The left top frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom frame style.
        /// </summary>
        /// <value>The left bottom frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomFrameStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom frame style.
        /// </summary>
        /// <value>The right bottom frame style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomFrameStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomFrameStyle");
                return objStyle;
            }
        }

        #endregion

        #region Taskbar item frame Style

        /// <summary>
        /// Gets the default width of the item left frame.
        /// </summary>
        /// <value>The default width of the item left frame.</value>
        protected virtual int DefaultItemLeftFrameWidth
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the default width of the item right frame.
        /// </summary>
        /// <value>The default width of the item right frame.</value>
        protected virtual int DefaultItemRightFrameWidth
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the width of the item right frame.
        /// </summary>
        /// <value>The width of the item right frame.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ItemRightFrameWidth
        {
            get
            {
                return this.GetImageWidth(this.ItemFrameNormalStyle.RightStyle.BackgroundImage, this.DefaultItemRightFrameWidth);
            }
        }

        /// <summary>
        /// Gets or sets the width of the item left frame.
        /// </summary>
        /// <value>The width of the item left frame.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int ItemLeftFrameWidth
        {
            get
            {
                return this.GetImageWidth(this.ItemFrameNormalStyle.LeftStyle.BackgroundImage, this.DefaultItemLeftFrameWidth);
            }
        }

        /// <summary>
        /// Gets the item center frame normal style.
        /// </summary>
        /// <value>The item center frame normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemCenterFrameNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemCenterFrameNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item center frame over style.
        /// </summary>
        /// <value>The item center frame over style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemCenterFrameOverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemCenterFrameOverStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item center frame down style.
        /// </summary>
        /// <value>The item center frame down style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemCenterFrameDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemCenterFrameDownStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item left frame normal style.
        /// </summary>
        /// <value>The item left frame normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemLeftFrameNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemLeftFrameNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item left frame over style.
        /// </summary>
        /// <value>The item left frame over style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemLeftFrameOverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemLeftFrameOverStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item left frame down style.
        /// </summary>
        /// <value>The item left frame down style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemLeftFrameDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemLeftFrameDownStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item right frame normal style.
        /// </summary>
        /// <value>The item right frame normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemRightFrameNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemRightFrameNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item right frame over style.
        /// </summary>
        /// <value>The item right frame over style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemRightFrameOverStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemRightFrameOverStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the item right frame down style.
        /// </summary>
        /// <value>The item right frame down style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue ItemRightFrameDownStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "ItemRightFrameDownStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom frame display style.
        /// </summary>
        /// <value>The bottom frame display style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BottomFrameDisplayStyle
        {
            get
            {
                return this.BottomFrameHeight == 0 ? "display:none;" : "";
            }
        }

        #endregion

        #endregion
    }
}
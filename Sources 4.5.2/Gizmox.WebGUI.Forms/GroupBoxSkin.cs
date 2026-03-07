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
    /// GroupBox Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(GroupBox), "GroupBox.bmp"), Serializable()]
    public class GroupBoxSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {

        #region Normal Style

        /// <summary>
        /// Gets the normal groupbox style.
        /// </summary>
        /// <value>The normal groupbox style.</value>
        [Category("States"), Description("The normal groupbox style.")]
        public HeaderedFrameStyleValue NormalStyle
        {
            get
            {
                return new HeaderedFrameStyleValue(
                    this.LeftBottomNormalStyle,
                    this.LeftNormalStyle,
                    this.LeftTopNormalStyle,
                    this.TopNormalStyle,
                    this.RightTopNormalStyle,
                    this.RightNormalStyle,
                    this.RightBottomNormalStyle,
                    this.BottomNormalStyle,
                    this.CenterNormalStyle,
                    this.HeaderLeftNormalStyle,
                    this.HeaderCenterNormalStyle,
                    this.HeaderRightNormalStyle);
            }
        }


        /// <summary>
        /// Gets the header center normal style.
        /// </summary>
        /// <value>The header center normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue HeaderCenterNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderCenterNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the width of the header left cell.
        /// </summary>
        /// <value>The width of the header left cell.</value>
        [Category("Sizes"), Description("The width of the header left cell.")]
        public virtual int HeaderLeftWidth
        {
            get
            {
                return this.GetValue<int>("HeaderLeftWidth", this.GetImageWidth(this.NormalStyle.HeaderLeftStyle.BackgroundImage, this.DefaultHeaderLeftWidth));
            }
            set
            {
                this.SetValue("HeaderLeftWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the header left cell.
        /// </summary>
        internal void ResetHeaderLeftWidth()
        {
            this.Reset("HeaderLeftWidth");
        }

        /// <summary>
        /// Gets the default width of the header left.
        /// </summary>
        /// <value>The default width of the header left.</value>
        protected virtual int DefaultHeaderLeftWidth
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets the header left normal style.
        /// </summary>
        /// <value>The header left normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue HeaderLeftNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderLeftNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the width of the header right cell.
        /// </summary>
        /// <value>The width of the header right cell.</value>
        [Category("Sizes"), Description("The width of the header right cell.")]
        public virtual int HeaderRightWidth
        {
            get
            {
                return this.GetValue<int>("HeaderRightWidth", this.GetImageWidth(this.NormalStyle.HeaderRightStyle.BackgroundImage, this.DefaultHeaderRightWidth));
            }
            set
            {
                this.SetValue("HeaderRightWidth", value);
            }
        }

        /// <summary>
        /// Resets the width of the header right cell.
        /// </summary>
        internal void ResetHeaderRightWidth()
        {
            this.Reset("HeaderRightWidth");
        }

        /// <summary>
        /// Gets the default width of the header right.
        /// </summary>
        /// <value>The default width of the header right.</value>
        protected virtual int DefaultHeaderRightWidth
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets the header right normal style.
        /// </summary>
        /// <value>The header right normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue HeaderRightNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HeaderRightNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center normal style.
        /// </summary>
        /// <value>The center normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual StyleValue CenterNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left normal style.
        /// </summary>
        /// <value>The left normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the top normal style.
        /// </summary>
        /// <value>The top normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue TopNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the bottom normal style.
        /// </summary>
        /// <value>The bottom normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue BottomNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right normal style.
        /// </summary>
        /// <value>The right normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right top normal style.
        /// </summary>
        /// <value>The right top normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightTopNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left top normal style.
        /// </summary>
        /// <value>The left top normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftTopNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the left bottom normal style.
        /// </summary>
        /// <value>The left bottom normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue LeftBottomNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the right bottom normal style.
        /// </summary>
        /// <value>The right bottom normal style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual FramePartStyleValue RightBottomNormalStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomNormalStyle");
                return objStyle;
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Category("Sizes"), Description("The width of the left frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int LeftFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Left);
            }
        }

        /// <summary>
        /// Resets the width of the left frame.
        /// </summary>
        internal void ResetLeftFrameWidth()
        {
            this.Reset("LeftFrameWidth");
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Category("Sizes"), Description("The width of the right frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int RightFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Right);
            }
        }

        /// <summary>
        /// Resets the width of the right frame.
        /// </summary>
        internal void ResetRightFrameWidth()
        {
            this.Reset("RightFrameWidth");
        }

        /// <summary>
        /// Gets or sets the height of the top frame.
        /// </summary>
        /// <value>The height of the top frame.</value>
        [Category("Sizes"), Description("The height of the top frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int TopFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Top);
            }
        }

        /// <summary>
        /// Resets the height of the top frame.
        /// </summary>
        internal void ResetTopFrameHeight()
        {
            this.Reset("TopFrameHeight");
        }

        /// <summary>
        /// Gets or sets the height of the bottom frame.
        /// </summary>
        /// <value>The height of the bottom frame.</value>
        [Category("Sizes"), Description("The height of the bottom frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int BottomFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.NormalStyle, FrameEdge.Bottom);
            }
        }

        /// <summary>
        /// Resets the height of the bottom frame.
        /// </summary>
        internal void ResetBottomFrameHeight()
        {
            this.Reset("BottomFrameHeight");
        }

        private void InitializeComponent()
        {

        }
    }
}

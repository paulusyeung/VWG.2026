using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// ToolBar Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(ToolBar),"ToolBar.bmp")]
    [SkinDependency(typeof(ToolBarButtonSkin))]
    [SkinDependency(typeof(FlatToolBarSkin))]
    [SkinDependency(typeof(FlatToolBarButtonSkin))]
    public class ToolBarSkin : ControlSkin
    {

        /// <summary>
        /// Gets the height of the defalut.
        /// </summary>
        /// <value>The height of the defalut.</value>
        internal static int DefalutHeight
        {
            get
            {
                return 25;
            }
        }

        /// <summary>
        /// Gets or sets the height of the toolbar.
        /// </summary>
        /// <value>The height of the toolbar.</value>
        [Category("Sizes"), Description("The height of the main menu.")]
        public int Height
        {
            get
            {
                return this.GetValue<int>("Height", ToolBarSkin.DefalutHeight);
            }
            set
            {
                this.SetValue("Height", value);
            }
        }

        /// <summary>
        /// Resets the height of the menu.
        /// </summary>
        private void ResetHeight()
        {
            this.Reset("Height");
        }


        /// <summary>
        /// Gets the frame frame style.
        /// </summary>
        /// <value>The frame frame style.</value>
        public FrameStyleValue FrameStyle
        {
            get
            {
                return new FrameStyleValue(this.LeftBottomStyle, this.LeftStyle,
                                            this.LeftTopStyle, this.TopStyle,
                                            this.RightTopStyle, this.RightStyle,
                                            this.RightBottomStyle, this.BottomStyle,
                                            this.CenterStyle);
            }
        }

        /// <summary>
        /// Gets or sets the height of the top frame.
        /// </summary>
        /// <value>The height of the top frame.</value>
        [Category("Sizes"), Description("The height of the top frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int TopFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Top);
            }
        }

        /// <summary>
        /// Gets or sets the width of the right frame.
        /// </summary>
        /// <value>The width of the right frame.</value>
        [Category("Sizes"), Description("The width of the right frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int RightFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Right);
            }
        }
        
        /// <summary>
        /// Gets or sets the height of the bottom frame.
        /// </summary>
        /// <value>The height of the bottom frame.</value>
        [Category("Sizes"), Description("The height of the bottom frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int BottomFrameHeight
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Bottom);
            }
        }
        
        /// <summary>
        /// Gets or sets the width of the left frame.
        /// </summary>
        /// <value>The width of the left frame.</value>
        [Category("Sizes"), Description("The width of the left frame.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int LeftFrameWidth
        {
            get
            {
                return GetFrameEdgeSize(this.FrameStyle, FrameEdge.Left);
            }
        }

        /// <summary>
        /// Gets the frame left top style.
        /// </summary>
        /// <value>The frame left top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue LeftTopStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftTopStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame top style.
        /// </summary>
        /// <value>The frame top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue TopStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "TopStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame right top style.
        /// </summary>
        /// <value>The frame right top style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue RightTopStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightTopStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame left style.
        /// </summary>
        /// <value>The frame left style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue LeftStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame right style.
        /// </summary>
        /// <value>The frame right style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue RightStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame left bottom style.
        /// </summary>
        /// <value>The frame left bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue LeftBottomStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "LeftBottomStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the center style.
        /// </summary>
        /// <value>The center style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleValue CenterStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "CenterStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame bottom style.
        /// </summary>
        /// <value>The frame bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue BottomStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "BottomStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the frame right bottom style.
        /// </summary>
        /// <value>The frame right bottom style.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FramePartStyleValue RightBottomStyle
        {
            get
            {
                FramePartStyleValue objStyle = new FramePartStyleValue(this, "RightBottomStyle");
                return objStyle;
            }
        }

        private void InitializeComponent()
        {
            
        }
    }
}


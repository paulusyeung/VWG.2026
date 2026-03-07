using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Design;
namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// PropertyGrid Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(PropertyGrid),"PropertyGrid.bmp")]
    [Serializable()]
    [SkinDependency(typeof(AnchorPanelSkin))]
    [SkinDependency(typeof(DockButtonSkin))]
    public class PropertyGridSkin : ControlSkin
    {
        /// <summary>
        /// 
        /// </summary>
        #region GridStyleValue class

        public class GridStyleValue : StyleValue
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GridStyleValue"/> class.
            /// </summary>
            /// <param name="objPropertyOwner">The property owner.</param>
            /// <param name="strPropertyPrefix">The property prefix.</param>
            public GridStyleValue(PropertyGridSkin objPropertyOwner, string strPropertyPrefix)
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
                    if (this.PropertyGridSkin != null)
                    {
                        return this.PropertyGridSkin.GridLinesColor;
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
                    if (this.PropertyGridSkin != null)
                    {
                        return this.PropertyGridSkin.GridLinesStyle;
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
                    if (this.PropertyGridSkin != null)
                    {
                        return this.PropertyGridSkin.GridLinesWidth;
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
            private PropertyGridSkin PropertyGridSkin
            {
                get
                {
                    return this.Skin as PropertyGridSkin;
                }
            }
        }

        #endregion GridStyleValue class


        #region Sizes

        /// <summary>
        /// Gets the row height
        /// </summary>
        /// <value>The row height.</value>
        [Category("Sizes"), Description("The row height.")]
        public virtual int RowHeight
        {
            get
            {
                return this.GetValue<int>("RowHeight", this.DefaultRowHeight);
            }
            set
            {
                this.SetValue("RowHeight", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetRowHeight()
        {
            this.Reset("RowHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultRowHeight
        {
            get
            {
                return 18;
            }
        }

        /// <summary>
        /// Gets or sets the width of the grid lines.
        /// </summary>
        /// <value></value>
        [Category("Sizes"), Description("The width of the grid lines.")]
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
        /// Resets the height value
        /// </summary>
        internal void ResetGridLinesWidth()
        {
            this.Reset("GridLinesWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual BorderWidth DefaultGridLinesWidth
        {
            get
            {
                return new BorderWidth(1);
            }
        }

        /// <summary>
        /// Gets the width of the plus button.
        /// </summary>
        /// <value>The width of the plus button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int PlusButtonWidth
        {
            get
            {
                return this.GetMaxImageWidth(this.DefaultPlusButtonWidth, "PGLightPlus0.gif", "PGLightPlus1.gif");
            }

        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetPlusButtonWidth()
        {
            this.Reset("PlusButtonWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultPlusButtonWidth
        {
            get
            {
                return 9;
            }
        }

        /// <summary>
        /// Gets the height of the plus button.
        /// </summary>
        /// <value>The height of the plus button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int PlusButtonHeight
        {
            get
            {
                return this.GetMaxImageHeight(this.DefaultPlusButtonHeight, "PGLightPlus0.gif", "PGLightPlus1.gif");
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetPlusButtonHeight()
        {
            this.Reset("PlusButtonHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultPlusButtonHeight
        {
            get
            {
                return 9;
            }
        }

        /// <summary>
        /// Gets the height of the category plus button.
        /// </summary>
        /// <value>The height of the category plus button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CategoryPlusButtonHeight
        {
            get
            {
                return this.GetMaxImageHeight(this.DefaultCategoryPlusButtonHeight, "PGLightPlus0.gif");
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetCategoryPlusButtonHeight()
        {
            this.Reset("CategoryPlusButtonHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultCategoryPlusButtonHeight
        {
            get
            {
                return 9;
            }
        }

        /// <summary>
        /// Gets the width of the category plus button.
        /// </summary>
        /// <value>The width of the category plus button.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CategoryPlusButtonWidth
        {
            get
            {
                return this.GetMaxImageWidth(this.DefaultCategoryPlusButtonWidth, "PGLightPlus0.gif");
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetCategoryPlusButtonWidth()
        {
            this.Reset("CategoryPlusButtonWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultCategoryPlusButtonWidth
        {
            get
            {
                return 9;
            }
        }

        #endregion
        
        /// <summary>
        /// Gets the category style.
        /// </summary>
        /// <value>The category style.</value>
        [Category("Style"), Description("The category style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue CategoryStyle
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "CategoryStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the splitter style.
        /// </summary>
        /// <value>The splitter style.</value>
        [Category("Style"), Description("The splitter style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue SplitterStyle
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "SplitterStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the property value normal style.
        /// </summary>
        /// <value>The property value normal style.</value>
        [Category("States"), Description("The property value normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ValueNormalStyle
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "ValueNormalStyle");
                return objStyle;
            }
        }


        /// <summary>
        /// Gets the property value active style.
        /// </summary>
        /// <value>The property value active style.</value>
        [Category("States"), Description("The property value active style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ValueActiveStyle
        {
            get
            {
                StyleValue objStyle = new GridStyleValue(this, "ValueActiveStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the property label normal style.
        /// </summary>
        /// <value>The property label normal style.</value>
        [Category("States"), Description("The property label normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue LabelNormalStyle
        {
            get
            {
                GridStyleValue objStyle = new GridStyleValue(this, "LabelNormalStyle");
                return objStyle;
            }
        }




        /// <summary>
        /// Gets the property label active style.
        /// </summary>
        /// <value>The property label active style.</value>
        [Category("States"), Description("The property label active style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue LabelActiveStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "LabelActiveStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the outline style.
        /// </summary>
        /// <value>The outline style.</value>
        [Category("Style"), Description("The outline style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue OutlineStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "OutlineStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets or sets the grid lines color.
        /// </summary>
        /// <value></value>
        [Category("Colors"), Description("The color of the grid lines.")]
        public virtual Color GridLinesColor
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
        /// Resets the height value
        /// </summary>
        internal void ResetGridLinesColor()
        {
            this.Reset("GridLinesColor");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual Color DefaultGridLinesColor
        {
            get
            {
                return Color.FromArgb(211, 219, 233);
            }
        }

        /// <summary>
        /// Gets or sets the grid lines style.
        /// </summary>
        /// <value></value>
        [Category("Styles"), Description("The color of the grid lines style.")]
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
        /// Gets the help panel style.
        /// </summary>
        /// <value>The help panel style.</value>
        [Category("Styles"), Description("The help panel style, you can define the BorderStyle, BorderColor and Padding of the help panel.")]
        public virtual StyleValue HelpPanelStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "HelpPanelStyle");
                return objStyle;
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

        private void InitializeComponent()
        {

        }
    }
}

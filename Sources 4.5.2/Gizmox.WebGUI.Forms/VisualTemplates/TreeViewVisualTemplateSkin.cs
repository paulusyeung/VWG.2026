using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class TreeViewVisualTemplateSkin : TreeViewSkin
    {
        private void InitializeComponent()
        {

        }


        /// <summary>
        /// Gets the TreeView row style.
        /// </summary>
        /// <value>
        /// The TreeView row style.
        /// </value>
        public virtual StyleValue TreeViewRowStyle
        {
            get
            {
                return new StyleValue(this, "TreeViewRowStyle", null);
            }
        }

        /// <summary>
        /// Gets the TreeView visual template back container style.
        /// </summary>
        /// <value>
        /// The TreeView visual template back container style.
        /// </value>
        public virtual StyleValue TreeViewVisualTemplateBackContainerStyle
        {
            get
            {
                return new StyleValue(this, "TreeViewVisualTemplateBackContainerStyle", null);
            }
        }


        /// <summary>
        /// Gets the TreeView visual template back button style.
        /// </summary>
        /// <value>
        /// The TreeView visual template back button style.
        /// </value>
        public virtual StyleValue TreeViewVisualTemplateBackButtonStyle
        {
            get
            {
                return new StyleValue(this, "TreeViewVisualTemplateBackButtonStyle", null);
            }
        }

        /// <summary>
        /// Gets the TreeView visual template back button style.
        /// </summary>
        /// <value>
        /// The TreeView visual template back button style.
        /// </value>
        public virtual StyleValue TreeViewVisualTemplateBackButtonDisabledStyle
        {
            get
            {
                return new StyleValue(this, "TreeViewVisualTemplateBackButtonStyle", null);
            }
        }

        /// <summary>
        /// Gets the TreeView visual template back button style.
        /// </summary>
        /// <value>
        /// The TreeView visual template back button style.
        /// </value>
        public virtual Size TreeViewVisualTemplateBackButtonSize
        {
            get
            {
                return this.GetValue<Size>("TreeViewVisualTemplateBackButtonSize", new Size(90, DefaultTreeViewNodeHeight));
            }
            set
            {
                this.SetValue("TreeViewVisualTemplateBackButtonSize", value);
            }
        }


        /// <summary>
        /// Gets the width of the TreeView visual template back button.
        /// </summary>
        /// <value>
        /// The width of the TreeView visual template back button.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TreeViewVisualTemplateBackButtonWidth
        {
            get
            {
                return this.TreeViewVisualTemplateBackButtonSize.Width;
            }
        }


        /// <summary>
        /// Gets the TreeView visual tempalte button text.
        /// </summary>
        /// <value>
        /// The TreeView visual tempalte button text.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageResourceReference TreeViewVisualTempalteButtonImageRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TreeViewVisualTempalteButtonImageRTL", null);
            }
            set
            {
                this.SetValue("TreeViewVisualTempalteButtonImageRTL", value);
            }
        }
               

        /// <summary>
        /// Gets or sets the TreeView visual tempalte button image LTR.
        /// </summary>
        /// <value>
        /// The TreeView visual tempalte button image LTR.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageResourceReference TreeViewVisualTempalteButtonImageLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TreeViewVisualTempalteButtonImageLTR", null);
            }
            set
            {
                this.SetValue("TreeViewVisualTempalteButtonImageLTR", value);
            }
        }

        /// <summary>
        /// Gets the TreeView visual tempalte button image.
        /// </summary>
        /// <value>
        /// The TreeView visual tempalte button image.
        /// </value>
        public BidirectionalSkinProperty<ImageResourceReference> TreeViewVisualTempalteButtonImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "TreeViewVisualTempalteButtonImageLTR", "TreeViewVisualTempalteButtonImageRTL");
            }
        }

        /// <summary>
        /// Gets the height of the TreeView visual template back button.
        /// </summary>
        /// <value>
        /// The height of the TreeView visual template back button.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TreeViewVisualTemplateBackButtonHeight
        {
            get
            {
                return this.TreeViewVisualTemplateBackButtonSize.Height;
            }
        }

        /// <summary>
        /// Gets or sets the TreeView visual template next LTR.
        /// </summary>
        /// <value>
        /// The TreeView visual template next LTR.
        /// </value>
        public virtual ImageResourceReference TreeViewVisualTemplateNextLTR
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TreeViewVisualTemplateNextLTR", null);
            }
            set
            {
                this.SetValue("TreeViewVisualTemplateNextLTR", value);
            }
        }

        /// <summary>
        /// Gets or sets the TreeView visual template next RTL.
        /// </summary>
        /// <value>
        /// The TreeView visual template next RTL.
        /// </value>
        public virtual ImageResourceReference TreeViewVisualTemplateNextRTL
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TreeViewVisualTemplateNextRTL", null);
            }
            set
            {
                this.SetValue("TreeViewVisualTemplateNextRTL", value);
            }
        }

        /// <summary>
        /// Gets the TreeView visual template next.
        /// </summary>
        /// <value>
        /// The TreeView visual template next.
        /// </value>
        public BidirectionalSkinProperty<ImageResourceReference> TreeViewVisualTemplateNext
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "TreeViewVisualTemplateNextLTR", "TreeViewVisualTemplateNextRTL");
            }
        }


        /// <summary>
        /// Gets or sets the TreeView visual template next witdh.
        /// </summary>
        /// <value>
        /// The TreeView visual template next witdh.
        /// </value>
        public virtual int TreeViewVisualTemplateNextWidth
        {
            get
            {
                return this.GetValue<int>("TreeViewVisualTemplateNextWidth", this.GetImageWidth(this.TreeViewVisualTemplateNextLTR, this.DefaultTreeViewNodeNextWidth));
            }
            set
            {
                this.SetValue("TreeViewVisualTemplateNextWidth", value);
            }
        }


        /// <summary>
        /// Resets the width of the TreeView visual template next.
        /// </summary>
        private void ResetTreeViewVisualTemplateNextWidth()
        {
            this.Reset("TreeViewVisualTemplateNextWidth");
        }

        /// <summary>
        /// Gets the default width of the TreeView node next.
        /// </summary>
        /// <value>
        /// The default width of the TreeView node next.
        /// </value>
        public int DefaultTreeViewNodeNextWidth
        {
            get
            {
                return 19;
            }
        }

        /// <summary>
        /// Gets or sets the height of the TreeView node.
        /// </summary>
        /// <value>
        /// The height of the TreeView node.
        /// </value>
        public virtual int TreeViewNodeHeight
        {
            get
            {
                return this.GetValue<int>("TreeViewNodeHeight", DefaultTreeViewNodeHeight);
            }
            set
            {
                this.SetValue("TreeViewNodeHeight", value);
            }
        }

        

        /// <summary>
        /// Gets the default height of the TreeView node.
        /// </summary>
        /// <value>
        /// The default height of the TreeView node.
        /// </value>
        protected internal virtual int DefaultTreeViewNodeHeight
        {
            get
            {
                return 32;
            }
        }


        /// <summary>
        /// Resets the height of the TreeView node.
        /// </summary>
        private void ResetTreeViewNodeHeight()
        {
            this.Reset("TreeViewNodeHeight");
        }

    }
}
#region Using

using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.ComponentModel;


#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Summary description for GroupingTreeViewSkin
    /// </summary>   
    [SkinContainer(typeof(DataGridViewSkin)), Serializable()]
    public class DataGridViewGroupingTreeViewSkin : TreeViewSkin
    {
        private void InitializeComponent()
        {

        }

        #region Styles

        /// <summary>
        /// Gets the node close button style.
        /// </summary>
        [SRCategory("Styles"), SRDescription("Grouping TreeNode Close button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue TreeNodeCloseButtonStyle
        {
            get
            {
                return new StyleValue(this, "TreeNodeCloseButtonStyle");
            }
        }

        /// <summary>
        /// Gets the node joint style.
        /// </summary>
        [SRCategory("Styles"), SRDescription("Grouping TreeNode joint style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue TreeNodeJointStyle
        {
            get
            {
                return new StyleValue(this, "TreeNodeJointStyle");
            }
        }

        #endregion

        #region Sizes

        /// <summary>
        /// Gets or sets the height of the tree node.
        /// </summary>
        /// <value>
        /// The height of the tree node.
        /// </value>
        [SRCategory("Sizes"), SRDescription("Grouping TreeNode height in pixels.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual int TreeNodeHeight
        {
            get
            {
                return GetValue<int>("TreeNodeHeight", 18);
            }

            set
            {
                this.SetValue("TreeNodeHeight", value);
            }
        }

        /// <summary>
        /// Gets the width of the node close button.
        /// </summary>
        /// <value>
        /// The width of the node close button.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int TreeNodeCloseButtonWidth
        {
            get
            {
                return this.GetImageWidth(this.TreeNodeCloseButtonStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets the width of the tree node joint image.
        /// </summary>
        /// <value>
        /// The width of the tree node joint image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int TreeNodeJointImageWidth
        {
            get
            {
                return Math.Max(this.GetImageWidth(this.TreeNodeJointLTRImage), this.GetImageWidth(this.TreeNodeJointRTLImage));
            }
        }

        /// <summary>
        /// Gets the height of the tree node joint image.
        /// </summary>
        /// <value>
        /// The height of the tree node joint image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int TreeNodeJointImageHeight
        {
            get
            {
                return Math.Max(this.GetImageHeight(this.TreeNodeJointLTRImage), this.GetImageHeight(this.TreeNodeJointRTLImage));
            }
        }

        /// <summary>
        /// Gets or sets the height of top indicator placeholder.
        /// </summary>
        /// <value>
        /// The height of top indicator placeholder.
        /// </value>
        [SRCategory("Sizes"), SRDescription("Grouping Area top indicator placeholder height in pixels.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual int TopNodePlaceHolderHeight
        {
            get
            {
                return GetValue<int>("TopNodePlaceHolderHeight", 5);
            }

            set
            {
                SetValue("TopNodePlaceHolderHeight", value);
            }
        }

        /// <summary>
        /// Gets the height of the node close button.
        /// </summary>
        /// <value>
        /// The height of the node close button.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int TreeNodeCloseButtonHeight
        {
            get
            {
                return this.GetImageHeight(this.TreeNodeCloseButtonStyle.BackgroundImage);
            }
        }

        /// <summary>
        /// Gets or sets the tree node padding top.
        /// </summary>
        /// <value>
        /// The tree node padding top.
        /// </value>
        [SRDescription("The tree node top padding.")]
        [SRCategory("Images")]
        public virtual int TreeNodePaddingTop
        {
            get
            {
                return GetValue<int>("TreeNodePaddingTop", (this.TreeNodeJointImageHeight - this.TreeNodeHeight) / 2);
            }

            set
            {
                SetValue("TreeNodePaddingTop", value);
            }
        }

        #endregion

        #region Images

        /// <summary>
        /// Gets or sets the node joint LTR image.
        /// </summary>
        /// <value>
        /// The node joint LTR image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference TreeNodeJointLTRImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TreeNodeJointLTRImage", new ImageResourceReference(typeof(DataGridViewGroupingTreeViewSkin), "GroupingTreeNodeJointLTR.gif"));
            }
            set
            {
                this.SetValue("TreeNodeJointLTRImage", value);
            }
        }

        /// <summary>
        /// Resets the node joint LTR image.
        /// </summary>
        private void ResetNodeJointLTRImage()
        {
            this.Reset("TreeNodeJointLTRImage");
        }

        /// <summary>
        /// Gets or sets the node joint RTL image.
        /// </summary>
        /// <value>
        /// The node joint RTL image.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageResourceReference TreeNodeJointRTLImage
        {
            get
            {
                return this.GetValue<ImageResourceReference>("TreeNodeJointRTLImage", new ImageResourceReference(typeof(DataGridViewGroupingTreeViewSkin), "GroupingTreeNodeJointRTL.gif"));
            }
            set
            {
                this.SetValue("TreeNodeJointRTLImage", value);
            }
        }

        /// <summary>
        /// Resets the node joint RTL image.
        /// </summary>
        private void ResetNodeJointRTLImage()
        {
            this.Reset("TreeNodeJointRTLImage");
        }

        /// <summary>
        /// Gets the tree node joint image.
        /// </summary>
        [SRDescription("The node joint image.")]
        [SRCategory("Images")]
        public virtual BidirectionalSkinProperty<ImageResourceReference> TreeNodeJointImage
        {
            get
            {
                return new BidirectionalSkinProperty<ImageResourceReference>(this, "TreeNodeJointLTRImage", "TreeNodeJointRTLImage");
            }
        }
    }

        #endregion


}


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
    /// TreeView Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(TreeView),"TreeView.bmp")]
    [Serializable()]
    public class TreeViewSkin : Gizmox.WebGUI.Forms.Skins.ControlSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>Gets or sets a value indicating whether the selection highlight spans the width of the tree view control.</summary>
        /// <returns>true if the selection highlight spans the width of the tree view control; otherwise, false. The default is false.</returns>
        [SRCategory("CatBehavior"), SRDescription("TreeViewFullRowSelectDescr")]
        [Browsable(false)]
        public virtual bool FullRowSelect
        {
            get
            {
                return this.GetValue<bool>("FullRowSelect", this.DefaultFullRowSelect);
            }
            set
            {
                this.SetValue("FullRowSelect", value);
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetFullRowSelect()
        {
            this.Reset("FullRowSelect");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual bool DefaultFullRowSelect
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the tree node normal style.
        /// </summary>
        /// <value>The tree node normal style.</value>
        [Category("States"), Description("The tree node normal style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue TreeNodeNormalStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TreeNodeNormalStyle");
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the tree node selected style.
        /// </summary>
        /// <value>The tree node selected style.</value>
        [Category("States"), Description("The tree node selected style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue TreeNodeSelectedStyle
        {
            get
            {
                StyleValue objStyle = new StyleValue(this, "TreeNodeSelectedStyle", this.TreeNodeNormalStyle);
                return objStyle;
            }
        }

        /// <summary>
        /// Gets the height of the check box image.
        /// </summary>
        /// <value>The height of the check box image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CheckBoxImageHeight
        {
            get
            {
                return this.GetMaxImageHeight(this.DefaultCheckBoxImageHeight, "CheckBox0.gif", "CheckBox1.gif");
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetCheckBoxImageHeight()
        {
            this.Reset("CheckBoxImageHeight");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultCheckBoxImageHeight
        {
            get
            {
                return 13;
            }
        }

        /// <summary>
        /// Gets the width of the check box image.
        /// </summary>
        /// <value>The width of the check box image.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual int CheckBoxImageWidth
        {
            get
            {
                return this.GetMaxImageWidth(this.DefaultCheckBoxImageWidth, "CheckBox0.gif", "CheckBox1.gif");
            }
        }

        /// <summary>
        /// Resets the height value
        /// </summary>
        internal void ResetCheckBoxImageWidth()
        {
            this.Reset("CheckBoxImageWidth");
        }

        /// <summary>
        /// Gets default value
        /// </summary>
        protected virtual int DefaultCheckBoxImageWidth
        {
            get
            {
                return 13;
            }
        }
    }
}

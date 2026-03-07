using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Panel Skin
    /// </summary>
    [SkinContainer(typeof(ToolStripDropDownSkin)), Serializable()]
    public class ToolStripDropDownContentPanelSkin : PanelSkin
    {
        private void InitializeComponent()
        {

        }
        
        /// <summary>
        /// Gets the scroll up button style.
        /// </summary>
        /// <value>
        /// The scroll up button style.
        /// </value>
        [Category("Styles"), SRDescription("The scroll up button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ScrollUpButtonStyle
        {
            get
            {
                return new StyleValue(this, "ScrollUpButtonStyle");
            }
        }

        /// <summary>
        /// Gets the scroll up button disabled style.
        /// </summary>
        /// <value>
        /// The scroll up button disabled style.
        /// </value>
        [Category("Styles"), SRDescription("The scroll up button disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ScrollUpButtonDisabledStyle
        {
            get
            {
                return new StyleValue(this, "ScrollUpButtonDisabledStyle");
            }
        }

        /// <summary>
        /// Gets the scroll down button style.
        /// </summary>
        /// <value>
        /// The scroll down button style.
        /// </value>
        [Category("Styles"), SRDescription("The scroll down button style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ScrollDownButtonStyle
        {
            get
            {
                return new StyleValue(this, "ScrollDownButtonStyle");
            }
        }

        /// <summary>
        /// Gets the scroll down button disabled style.
        /// </summary>
        /// <value>
        /// The scroll down button disabled style.
        /// </value>
        [Category("Styles"), SRDescription("The scroll down button disabled style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual StyleValue ScrollDownButtonDisabledStyle
        {
            get
            {
                return new StyleValue(this, "ScrollDownButtonDisabledStyle");
            }
        }

        /// <summary>
        /// Gets the height of the scroll up button.
        /// </summary>
        /// <value>
        /// The height of the scroll up button.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int ScrollUpButtonHeight
        {
            get
            {
                return this.GetMaxImageHeight(9, ScrollUpButtonStyle.BackgroundImage.ResourceName, ScrollUpButtonDisabledStyle.BackgroundImage.ResourceName);
            }
        }

        /// <summary>
        /// Gets the height of the scroll down button.
        /// </summary>
        /// <value>
        /// The height of the scroll down button.
        /// </value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int ScrollDownButtonHeight
        {
            get
            {
                return this.GetMaxImageHeight(9, ScrollDownButtonStyle.BackgroundImage.ResourceName, ScrollDownButtonDisabledStyle.BackgroundImage.ResourceName);
            }
        }
    }
}

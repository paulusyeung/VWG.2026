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
    /// TabPage Skin
    /// </summary>
    [SkinContainerAttribute(typeof(TabControlSkin))]
    [ToolboxBitmap(typeof(TabPage), "TabPage.bmp"), Serializable()]
    public class TabPageSkin : ControlSkin
    {
        /// <summary>
        /// Gets or sets the font of the header text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <remarks>Font is defined as an ambient property which means that in inherits from is container.</remarks>
        [Category("Fonts"), Description("The font used to display header text in the control.")]
        public Font HeaderFont
        {
            get
            {
                return this.GetAmbientValue<Font>("HeaderFont", new Font("Tahoma", 8.25f));
            }
            set
            {
                this.SetValue("HeaderFont", value);
            }
        }

        /// <summary>
        /// Gets or sets the header fore color.
        /// </summary>
        /// <value></value>
        /// <remarks>HeaderForeColor is defined as an ambient property which means that in inherits from is container.</remarks>
        [Category("Colors"), Description("The foreground color of this component, which is used to display header text.")]
        public Color HeaderForeColor
        {
            get
            {
                return this.GetAmbientValue<Color>("HeaderForeColor", Color.Black);
            }
            set
            {
                this.SetValue("HeaderForeColor", value);
            }
        }

        private void InitializeComponent()
        {

        }
        
    }
}

#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A TextBox control
    /// </summary>
    [Serializable]
    [Skin(typeof(BorderlessTextBoxVisualTemplateSkin))]
    [VisualTemplate(typeof(TextBox), "Visually adjusts the TextBox control to an appearance more suitable for the customized device.")]
    public class BorderlessTextBoxVisualTemplate : VisualTemplate
    {
        public BorderlessTextBoxVisualTemplate()
        {
        }

        /// <summary>
        /// Gets the name of the visual template.
        /// </summary>
        /// <value>
        /// The name of the visual template.
        /// </value>
        public override string VisualTemplateName
        {
            get
            {
                return "BorderlessTextBoxVisualTemplate";
            }
        }

        /// <summary>
        /// Gets the visualizer image.
        /// </summary>
        /// <value>
        /// The visualizer image.
        /// </value>
        public override Common.Resources.ResourceHandle VisualizerImage
        {
            get
            {
                return new SkinResourceHandle(typeof(BorderlessTextBoxVisualTemplateSkin), "TextBoxBorderLess.png"); ;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Borderless Display";
        }


        /// <summary>
        /// Gets the default visual template for a given control.
        /// </summary>
        /// <param name="objControl">The object control.</param>
        /// <returns></returns>
        public override VisualTemplate GetDefault(Control objControl)
        {
            return new BorderlessTextBoxVisualTemplate();
        }
    }

}

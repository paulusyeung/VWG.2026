using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A borderless button visualtemplate
    /// </summary>
    [Skin(typeof(BorderlessButtonVisualTemplateSkin))]
    [Serializable()]
    [VisualTemplate(typeof(Button), "Visually adjusts the Button control to an appearance more suitable for the customized device.")]
    public class BorderlessButtonVisualTemplate : VisualTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonHideOnDisplayVisualTemplate"/> class.
        /// </summary>
        public BorderlessButtonVisualTemplate()
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
                return "ButtonBorderLessVisualTemplate";
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
                return new SkinResourceHandle(typeof(BorderlessButtonVisualTemplateSkin), "BTNBorderLess.png"); ;
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
            return "Borderless button";
        }
    }
}

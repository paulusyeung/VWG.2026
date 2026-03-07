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
    /// A spread tab control visual template.
    /// </summary>
    [VisualTemplate(typeof(TabControl), "Visually adjusts the Tab control to an appearance more suitable for the customized device.\r\nThe Spread Visual Template creates a view for each tabbed page and displays the tab navigation in a device friendly manner.")]
    [Skin(typeof(TabControlSpreadVisualTemplateSkin))]
    [Serializable()]
    public class TabControlSpreadVisualTemplate : VisualTemplate
    {
        public TabControlSpreadVisualTemplate()
        {
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
                return new SkinResourceHandle(typeof(TabControlSpreadVisualTemplateSkin), "TabControlSpread.png"); ;
            }
        }
        public override VisualTemplate GetDefault(Control objControl)
        {
            return new TabControlSpreadVisualTemplate();
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
                return "TabControlSpreadVisualTemplate";
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
            return "Spread tab control";
        }
    }

}

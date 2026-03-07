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
    /// A TabControl control
    /// </summary>
    [VisualTemplate(typeof(TabControl), "Visually adjusts the Tab control to an appearance more suitable for the customized device.\r\nThe Logical Visual Template creates a view for each tabbed page while hiding the tab navigation (tab navigation can still be controlled with Actions).")]
    [Skin(typeof(TabControlLogicalVisualTemplateSkin))]
    [Serializable()]
    public class TabControlLogicalVisualTemplate : VisualTemplate
    {
        public TabControlLogicalVisualTemplate()
        {
        }

        public override void Render(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.Render(objContext, objWriter);
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
                return new SkinResourceHandle(typeof(TabControlLogicalVisualTemplateSkin), "TabControlLogical.png"); ;
            }
        }

        public override VisualTemplate GetDefault(Control objControl)
        {
            return new TabControlLogicalVisualTemplate();
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
                return "TabControlLogicalVisualTemplate";
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
            return "Logical tab control";
        }
    }

}

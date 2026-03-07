using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.Web;

namespace Gizmox.WebGUI.Forms
{
    [VisualTemplate(typeof(TrackBar), "Visually adjusts the TrackBar control to appear identical to a native TrackBar on the customized device.")]
    [Skin(typeof(NativeTrackBarVisualTemplateSkin))]
    [Serializable()]
    public class NativeTrackBarVisualTemplate : VisualTemplate
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeTrackBarVisualTemplate"/> class.
        /// </summary>
        public NativeTrackBarVisualTemplate()
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
                return "NativeTrackBarVisualTemplate";
            }
        }

        /// <summary>
        /// Gets the visualizer image.
        /// </summary>
        /// <value>
        /// The visualizer image.
        /// </value>
        public override ResourceHandle VisualizerImage
        {
            get
            {
                return new SkinResourceHandle(typeof(NativeTrackBarVisualTemplateSkin), "NativeTrackBar.png"); ;
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
            return "Native TrackBar";
        }
    }
}

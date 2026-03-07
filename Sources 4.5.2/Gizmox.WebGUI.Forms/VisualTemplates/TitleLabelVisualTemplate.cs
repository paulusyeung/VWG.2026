/*
' Visual WebGui - http://www.visualwebgui.com
' Copyright (c) 2005
' by Gizmox Inc. ( http://www.gizmox.com )
'
' This program is free software; you can redistribute it and/or modify it 
' under the terms of the GNU General Public License as published by the Free 
' Software Foundation; either version 2 of the License, or (at your option) 
' any later version.
'
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU GENERAL PUBLIC LICENSE FOR MORE DETAILS.
' YOU SHOULD HAVE RECEIVED A COPY OF THE GNU GENERAL PUBLIC LICENSE ALONG WITH THIS PROGRAM; if not, 
' write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
'
' contact: opensource@visualwebgui.com
*/

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
    /// A Label control
    /// </summary>
    [Skin(typeof(TitleLabelVisualTemplateSkin))]
    [Serializable()]
    [VisualTemplate(typeof(Label), "Visually adjusts the Label control to an appearance more suitable for the customized device.")]
    public class TitleLabelVisualTemplate : VisualTemplate
    {
        public TitleLabelVisualTemplate()
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
                return "TitleLabelVisualTemplate";
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
                return new SkinResourceHandle(typeof(TitleLabelVisualTemplateSkin), "LabelTitleTemplate.png"); ;
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
            return "Title label";
        }
    }

}

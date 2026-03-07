using System;
using System.Collections;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;


namespace Gizmox.WebGUI.Forms.Design
{
    public class MenuStripItemCollectionEditor : ToolStripItemCollectionEditor
    {
        /// <summary>
        /// Gets the designer availability.
        /// </summary>
        /// <value>The designer availability.</value>
        protected override ToolStripItemDesignerAvailability DesignerAvailability
        {
            get
            {
                return ToolStripItemDesignerAvailability.MenuStrip;
            }
        }
    }
}

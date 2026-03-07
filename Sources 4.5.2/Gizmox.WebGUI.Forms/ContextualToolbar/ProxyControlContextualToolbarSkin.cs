#region Using

using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Drawing;
using Gizmox.WebGUI.Common.Resources;


#endregion

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
    /// <summary>
    /// Summary description for ContextualToolbarSkin
    /// </summary>   
    public class ProxyControlContextualToolbarSkin : ContextualToolbarSkin
    {
        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {

        }


        /// <summary>
        /// Gets or sets the size of the contextual toolbar.
        /// </summary>
        /// <value>
        /// The size of the contextual toolbar.
        /// </value>
        public override Size ContextualToolbarSize
        {
            get
            {
                return this.GetValue<Size>("ContextualToolbarSize", new Size(220, 38));
            }
            set
            {
                this.SetValue("ContextualToolbarSize", value);
            }
        }

    }
}


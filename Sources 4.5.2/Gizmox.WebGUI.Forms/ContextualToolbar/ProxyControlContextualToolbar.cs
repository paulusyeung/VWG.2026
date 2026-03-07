#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using System.Reflection;


#endregion

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
    /// <summary>
    /// Summary description for ContextualToolbar
    /// </summary>
    [ToolboxItem(false)]
    [Serializable()]
    [Skin(typeof(ProxyControlContextualToolbarSkin))]
    internal class ProxyControlContextualToolbar : ContextualToolbar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualToolbar"/> class.
        /// </summary>
        public ProxyControlContextualToolbar()
        {
        }

        /// <summary>
        /// Initializes the base buttons buttons.
        /// </summary>
        protected override void InitContextualToolbarButtons()
        {
            base.InitContextualToolbarButtons();
            ProxyControlContextualToolbarSkin objSkin = this.Skin as ProxyControlContextualToolbarSkin;
            if (objSkin != null)
            {
                this.AddChild(new ContextualToolbarButton("Actions", objSkin.ContextualToolbarActions, "Add/Remove actions."));
                this.AddChild(new ContextualToolbarButton("VisualTemplate", objSkin.ContextualToolbarVisualTemplates, "Add/Remove visual templates."));
            }
        }
    }
}
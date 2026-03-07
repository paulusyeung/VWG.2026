using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
    /// <summary>
    /// WorkspaceTabs Skin
    /// </summary>
    [ToolboxBitmapAttribute(typeof(TabControl))]
    [Serializable()]
    [SkinDependency(typeof(WorkspaceTabSkin))]
    public class WorkspaceTabsSkin : Gizmox.WebGUI.Forms.Skins.TabControlSkin
    {
        private void InitializeComponent()
        {

        }

        #region Override Images		

        /// <summary>
        /// Gets the tabs container style.
        /// </summary>
        /// <value>The tabs container style.</value>
        [Category("States"), Description("The tabs top container style.")]
        public override StyleValue TabsTopContainerStyle
        {
            get
            {
                return base.TabsTopContainerStyle;

            }
        }
 
	    #endregion    
    }

    
}

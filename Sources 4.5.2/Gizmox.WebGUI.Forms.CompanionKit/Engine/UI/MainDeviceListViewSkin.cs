using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// ListView Skin
    /// </summary>
    public class MainDeviceListViewSkin : Gizmox.WebGUI.Forms.Skins.ListViewSkin
    {
        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Gets or sets a value indicating whether to show grid lines.
        /// </summary>
        /// <value>
        ///   <c>true</c> to show grid lines; otherwise, <c>false</c>.
        /// </value>
        public override bool ShowGridLines
        {
            get
            {
                return false;
            }
            set
            {
                base.ShowGridLines = value;
            }
        }
    }
}

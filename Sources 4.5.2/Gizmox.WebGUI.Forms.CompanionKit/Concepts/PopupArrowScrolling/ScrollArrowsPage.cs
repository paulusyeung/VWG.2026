using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.PopupArrowScrolling
{
    public partial class ScrollArrowsPage : UserControl
    {
        public ScrollArrowsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjArrowsRB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjArrowsRB_CheckedChanged(object sender, EventArgs e)
        {
            //If Arrows ScrollerType is chosen
            if (mobjArrowsRB.Checked)
                mobjPanel.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.Arrows;
            //If Default ScrollerType is chosen
            else
                mobjPanel.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.Default;
        }
    }
}
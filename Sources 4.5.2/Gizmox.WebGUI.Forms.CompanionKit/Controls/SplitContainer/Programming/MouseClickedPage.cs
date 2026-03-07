#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.SplitContainer.Programming
{
    public partial class MouseClickedPage : UserControl
    {
        public MouseClickedPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the SplitContainer.
        /// Shows message that mouse click on the SplitContainer
        /// </summary>
        private void mobjSplitContainer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked on SplitContainer!");
        }

        /// <summary>
        /// Handles Click event of the SplitContainer Panel1 (left panel)
        /// Shows message that mouse click on the left panel of the SplitContainer
        /// </summary>
        private void mobjSplitContainer_Panel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked on the left panel!");
        }

        /// <summary>
        /// Handles Click event of the SplitContainer Panel2 (right panel)
        /// Shows message that mouse click on the left panel of the SplitContainer
        /// </summary>
        private void mobjSplitContainer_Panel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked on the right panel!");
        }
    }
}
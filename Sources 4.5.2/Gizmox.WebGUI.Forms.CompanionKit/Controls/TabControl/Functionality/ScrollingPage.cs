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

namespace CompanionKit.Controls.TabControl.Functionality
{
    public partial class ScrollingPage : UserControl
    {
        public ScrollingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjMultilineCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMultilineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjDemoTabControl.Multiline = mobjMultilineCheckBox.Checked ? true : false;
        }
    }
}
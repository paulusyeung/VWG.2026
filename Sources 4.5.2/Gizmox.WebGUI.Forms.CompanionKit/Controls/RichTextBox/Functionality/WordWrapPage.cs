using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.RichTextBox.Functionality
{
    public partial class WordWrapPage : UserControl
    {
        public WordWrapPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjIsWordWrap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIsWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            //Change WordWrap property of RichTextBox
            mobjRichTextBox.WordWrap = mobjIsWordWrap.Checked;

        }

    }
}
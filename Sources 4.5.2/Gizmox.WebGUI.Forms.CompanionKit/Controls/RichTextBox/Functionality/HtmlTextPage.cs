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
    public partial class HtmlTextPage : UserControl
    {
        public HtmlTextPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjHtmlButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjHtmlButton_Click(object sender, EventArgs e)
        {
            //Set RichTextBox Html property
            mobjRichTextBox.Html = mobjTextBox.Text;
        }

        /// <summary>
        /// Handles the Click event of the mobjTextButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextButton_Click(object sender, EventArgs e)
        {
            //Set RichTextBox Text property
            mobjRichTextBox.Text = mobjTextBox.Text;
        }

    }
}
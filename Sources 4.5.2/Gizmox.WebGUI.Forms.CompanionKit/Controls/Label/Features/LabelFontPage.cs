using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.LabelFolder.Features
{
    public partial class LabelFontPage : UserControl
    {
        public LabelFontPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjButton1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton1_Click(object sender, EventArgs e)
        {
            // Save label object in FontDialog.Tag property
            fontDialog1.Tag = mobjLabel1;
            // Set font for FontDialog using Label.Font property
            fontDialog1.Font = mobjLabel1.Font;
            // Open FontDialog window
            fontDialog1.ShowDialog(new EventHandler(FontDialog_Closed));
        }

        /// <summary>
        /// Handles the Click event of the mobjButton2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton2_Click(object sender, EventArgs e)
        {
            // Save label object in FontDialog.Tag property
            fontDialog1.Tag = mobjLabel2;
            // Set font for FontDialog using Label.Font property
            fontDialog1.Font = mobjLabel2.Font;
            // Open FontDialog window
            fontDialog1.ShowDialog(new EventHandler(FontDialog_Closed));
        }

        /// <summary>
        /// Handles the Click event of the mobjButton3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton3_Click(object sender, EventArgs e)
        {
            // Save label object in FontDialog.Tag property
            fontDialog1.Tag = mobjLabel3;
            // Set font for FontDialog using Label.Font property
            fontDialog1.Font = mobjLabel3.Font;
            // Open FontDialog window
            fontDialog1.ShowDialog(new EventHandler(FontDialog_Closed));
        }

        /// <summary>
        /// Handles the Closed event of the FontDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FontDialog_Closed(object sender, EventArgs e)
        {
            // Get Label object saved
            Label label = ((FontDialog)sender).Tag as Label;
            // Set font for Label object
            label.Font = fontDialog1.Font;
        }
    }
}
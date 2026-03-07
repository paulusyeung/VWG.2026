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
    public partial class ControlPropertiesPage : UserControl
    {
        public ControlPropertiesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjMultiLineCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMultiLineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.mobjMultiLineRichTextBox.Multiline = this.mobjMultiLineCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Click event of the mobjSelectionFontButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSelectionFontButton_Click(object sender, EventArgs e)
        {
            FontDialog selectionFondDialog = new FontDialog();
            selectionFondDialog.Closed +=new EventHandler(selectionFondDialog_Closed);
            selectionFondDialog.ShowDialog();
        }

        /// <summary>
        /// Handles the Closed event of the selectionFondDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void selectionFondDialog_Closed(object sender, EventArgs e)
        {
            FontDialog fontDialog = sender as FontDialog;
            
            if (fontDialog.DialogResult == DialogResult.OK)
            {
                this.mobjSelectionFontRichTextBox.SelectionFont = fontDialog.Font;
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjFontButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjFontButton_Click(object sender, EventArgs e)
        {
            FontDialog fondDialog = new FontDialog();
            fondDialog.Closed += new EventHandler(fontDialog_Closed);
            fondDialog.ShowDialog();
        }

        /// <summary>
        /// Handles the Closed event of the fontDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void fontDialog_Closed(object sender, EventArgs e)
        {
            FontDialog fontDialog = sender as FontDialog;

            if (fontDialog.DialogResult == DialogResult.OK)
            {
                this.mobjFontRichTextBox.Font = fontDialog.Font;
            }
        }
    }
}
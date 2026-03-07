using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.StackPanel.Functionality
{
    public partial class StackPanelDemonstrationPage : UserControl
    {
        public StackPanelDemonstrationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjHorizontalRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjHorizontalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Changes StackPanel's orientation
            this.mobjStackPanel.Orientation = mobjHorizontalRadioButton.Checked ? Orientation.Horizontal : Orientation.Vertical;
        }

        /// <summary>
        /// Handles the Click event of the mobjAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            //Adds new label to StackPanel's controls collection
            Label mobjLabel = new Label();
            mobjLabel.Text = "Label#" + (this.mobjStackPanel.Controls.Count + 1);
            mobjLabel.BorderStyle=Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            mobjLabel.BackColor = System.Drawing.Color.LightBlue;
            this.mobjStackPanel.Controls.Add(mobjLabel);
        }

        /// <summary>
        /// Handles the Click event of the mobjRemoveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRemoveButton_Click(object sender, EventArgs e)
        {
            //If control collection is not empty - remove last item
            if (this.mobjStackPanel.Controls.Count > 0)
            {
                this.mobjStackPanel.Controls.RemoveAt(this.mobjStackPanel.Controls.Count - 1);
            }
        }
    }
}
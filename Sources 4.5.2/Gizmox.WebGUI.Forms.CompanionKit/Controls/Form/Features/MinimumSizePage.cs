using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.Form.Features
{
    public partial class MinimumSizePage : UserControl
    {
        public MinimumSizePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objOpenDialogButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjOpenDialogButton_Click(object sender, EventArgs e)
        {
            //Creates and displays MinimumSizeForm instance
            MinimumSizeForm mobjDialog = new MinimumSizeForm();
            mobjDialog.MinimumSize = mobjDialog.mobjBorderPanel.Size = this.MinimumSize;
            mobjDialog.ShowDialog();
        }

        /// <summary>
        /// Handles the ValueChanged event of the objWidthNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjWidthNUD_ValueChanged(object sender, EventArgs e)
        {
            //Applies Minimum Height of form
            this.MinimumSize = new Size((int)mobjWidthNUD.Value, this.MinimumSize.Height);
            //Updates panel's size according to form's MinimumSize 
            mobjBorderPanel.Size = this.MinimumSize;
        }

        /// <summary>
        /// Handles the ValueChanged event of the objHeightNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjHeightNUD_ValueChanged(object sender, EventArgs e)
        {
            //Applies Minimum Width of form
            this.MinimumSize = new Size(this.MinimumSize.Width, (int)mobjHeightNUD.Value);
            //Updates panel's size according to form's MinimumSize 
            mobjBorderPanel.Size = this.MinimumSize;
        }

        /// <summary>
        /// Handles the Click event of the objBorderButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjBorderButton_Click(object sender, EventArgs e)
        {
            //Gets visibility state of panel
            bool IsBorderVisible = mobjBorderPanel.Visible;
            //If Border is invisible - show it 
            if (!IsBorderVisible)
            {
                mobjBorderPanel.Visible = true;
                mobjBorderButton.Text = "Hide minimum size border";
            }
            //If visible - hide it
            else
            {
                mobjBorderPanel.Visible = false;
                mobjBorderButton.Text = "Show minimum size border";
            }
        }


    }
}
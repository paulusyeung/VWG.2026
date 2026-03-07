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

namespace CompanionKit.Controls.Form.Programming
{
    public partial class OrientationForm : global::Gizmox.WebGUI.Forms.Form
    {
        public OrientationForm()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Handles the OrientationChanged event of the Form2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="OrientationChangedEventArgs"/> instance containing the event data.</param>
        private void FormOrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            //Change Label text
            if (e.Orientation.Value==0 || e.Orientation.Value==180)
                 mobjOrientationLabel.Text = ("Orientation: Portrait");
            if (e.Orientation.Value==90 || e.Orientation.Value==-90)
                mobjOrientationLabel.Text = ("Orientation: Landscape");
        }

        /// <summary>
        /// Handles the Click event of the mobjCloseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCloseButton_Click(object sender, EventArgs e)
        {
            //Close form
            this.Close();
        }

    }
}
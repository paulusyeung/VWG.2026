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

namespace CompanionKit.Controls.ListView.Features
{
    public partial class CheckBoxPage : UserControl
    {
        public CheckBoxPage()
        {
            InitializeComponent();            
        }


        /// <summary>
        /// Handles the CheckedChanged event of the mobjGridCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjGridCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Change ListView.GridLines property
            mobjListView.GridLines = mobjGridCheck.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjBoxesCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjBoxesCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Change ListView.CheckBoxes property
            mobjListView.CheckBoxes = mobjBoxesCheck.Checked;
        }
    }
}
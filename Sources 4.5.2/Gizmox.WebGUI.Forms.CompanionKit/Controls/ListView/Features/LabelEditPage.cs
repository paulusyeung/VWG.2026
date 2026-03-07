using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ListView.Features
{
    public partial class LabelEditPage : UserControl
    {
        public LabelEditPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjEditCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjEditCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Change ListView.LabelEdit property
            mobjListView.LabelEdit = mobjEditCheck.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the RB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            //Set ListView.View property to selected view
            if (mobjDetailsRB.Checked)
                mobjListView.View = View.Details;
            else if (mobjListRB.Checked)
                mobjListView.View = View.List;
            else if (mobjSmallIconRB.Checked)
                mobjListView.View = View.SmallIcon;
            else
                mobjListView.View = View.LargeIcon;
        }

    }
}
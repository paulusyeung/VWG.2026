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

namespace CompanionKit.Controls.CheckBox.Functionality
{
    public partial class AutoCheckPage : UserControl
    {
        public AutoCheckPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjChkApprove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void mobjChkApprove_Click(object sender, EventArgs e)
		{
			// if AutoCheck is set to false the code have to set
			// correct appearance, else we don't need to change it
			// because will be set automatically
			if (mobjChkApprove.AutoCheck == false)
			{
				if (int.Parse(mobjTxtScore.Text) >= mobjMinScore.Value)
				{
					mobjChkApprove.Checked = !mobjChkApprove.Checked;
				}
			}
		}

        /// <summary>
        /// Handles the Click event of the mobjSetAutoCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void mobjSetAutoCheck_Click(object sender, EventArgs e)
		{
            //Change AutoCheck value of Approval CheckBox
			mobjChkApprove.AutoCheck = mobjSetAutoCheck.Checked;
			mobjChkApprove.Text = string.Format("Approve loan [auto check - {0}]", mobjChkApprove.AutoCheck);
		}
    }
}
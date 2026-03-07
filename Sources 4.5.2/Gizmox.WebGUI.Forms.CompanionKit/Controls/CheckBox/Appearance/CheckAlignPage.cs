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

namespace CompanionKit.Controls.CheckBox.Appearance
{
    public partial class CheckAlignPage : UserControl
    {
        public CheckAlignPage()
        {
            InitializeComponent();

            //Populate Text Align and Check Align ComboBoxes with appropriate values and set default selected items
            mobjTextCB.DataSource = Enum.GetValues(typeof(ContentAlignment));
            mobjCheckCB.DataSource = Enum.GetValues(typeof(ContentAlignment));
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjTextCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change TextAlign property of CheckBox
            mobjCheckBox.TextAlign = (ContentAlignment)mobjTextCB.SelectedItem;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjCheckCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change CheckAlign property of CheckBox
            mobjCheckBox.CheckAlign = (ContentAlignment)mobjCheckCB.SelectedItem;
        }
    }
}
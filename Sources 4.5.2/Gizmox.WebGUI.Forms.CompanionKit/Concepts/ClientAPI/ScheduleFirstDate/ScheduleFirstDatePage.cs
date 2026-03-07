using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ScheduleFirstDate
{
    public partial class ScheduleFirstDatePage : UserControl
    {
        public ScheduleFirstDatePage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Click event of the mobjButtonBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButtonBack_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("navigateDate", -1);
        }


        /// <summary>
        /// Handles the Click event of the mobjButtonForward control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButtonForward_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("navigateDate", 1);
        }

        /// <summary>
        /// Handles the Load event of the ScheduleFirstDatePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ScheduleFirstDatePage_Load(object sender, EventArgs e)
        {
            //Set ScheduleBox.FirstDate to Today's date by default
            mobjScheduleBox.FirstDate = DateTime.Today;
        }
    }
}
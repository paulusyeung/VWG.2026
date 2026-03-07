using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.MonthCalendar.Features
{
    public partial class SelectionPropertiesPage : UserControl
    {
        public SelectionPropertiesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Sets MaxSelectionCount value, which picked from NUD control
            mobjMonthCalendar.MaxSelectionCount = (int)mobjNumericUpDown.Value;
        }

        /// <summary>
        /// Handles the Load event of the SelectionPropertiesPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectionPropertiesPage_Load(object sender, EventArgs e)
        {
            //OnLoad dateTimePickers initialization
            mobjStartDateTimePicker.Value = DateTime.Now;
            mobjEndDateTimePicker.Value = DateTime.Now.AddDays(3);
        }

        /// <summary>
        /// Handles the Click event of the mobjButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            //Assigns selection range to MonthCalendar, based on dateTimePickers values  
            mobjMonthCalendar.SelectionRange = new SelectionRange(mobjStartDateTimePicker.Value, mobjEndDateTimePicker.Value);
        }
    }
}
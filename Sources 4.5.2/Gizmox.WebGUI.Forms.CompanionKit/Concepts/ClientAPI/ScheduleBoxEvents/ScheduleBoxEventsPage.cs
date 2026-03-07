using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Text.RegularExpressions;

namespace CompanionKit.Concepts.ClientAPI.ScheduleBoxEvents
{
    public partial class ScheduleBoxEventsPage : UserControl
    {
        public ScheduleBoxEventsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objButton_Click(object sender, EventArgs e)
        {
            //If start date more than end, then swap their values
            if (objStartDateTimePicker.Value > objEndDateTimePicker.Value)
            {
                DateTime objTempDate = objStartDateTimePicker.Value;
                objStartDateTimePicker.Value = objEndDateTimePicker.Value;
                objEndDateTimePicker.Value = objTempDate;
            }

            //Putting ticks from dateTimePickers into variables
            long lngStartDate = objStartDateTimePicker.Value.Ticks;
            long lngEndDate = objEndDateTimePicker.Value.Ticks;


           //If fields are not empty, then invoke js-function
           if (!string.IsNullOrEmpty(objSubjectTextBox.Text) && !string.IsNullOrEmpty(objTagTextBox.Text))
           {
               //Invoking js-function with arguments
               VWGClientContext.Current.Invoke("addEvent", lngStartDate, lngEndDate);
           }
           else { MessageBox.Show("Please fill all required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        /// <summary>
        /// Handles the Load event of the ScheduleBoxEventsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ScheduleBoxEventsPage_Load(object sender, EventArgs e)
        {
            //Setting  initial values of dateTimePickers
            objStartDateTimePicker.Value = DateTime.Now;
            objEndDateTimePicker.Value = DateTime.Now.AddHours(2);
            objScheduleBox.FirstDate = DateTime.Now;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the viewModeCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objViewModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Updating schedule's source, after view's mode is changed
            VWGClientContext.Current.Invoke("updateSchedule", objViewModeCombo.SelectedItem);
        }
    }
}
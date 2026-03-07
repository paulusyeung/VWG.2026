using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.MonthCalendar.Programming
{
    public partial class SettingValuePage : UserControl
    {
        public SettingValuePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the Button that set date for the select MonthCalendar
        /// </summary>
        private void mobjSetDateButton_Click(object sender, EventArgs e)
        {
            if (this.mobjEnableMonthCalendarRadioButton.Checked)
            {
                // Set date of the DateTimePicker for the enable MonthCalendar
                this.mobjEnableMonthCalendar.Value = this.mobjSelectDateDateTimePicker.Value;
            }
            else
            {
                // Set date of the DateTimePicker for the disable MonthCalendar
                this.mobjDisableMonthCalendar.Value = this.mobjSelectDateDateTimePicker.Value;
            }
        }
    }
}
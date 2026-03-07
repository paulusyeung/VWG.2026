using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DateTimePicker.Functionality
{
    public partial class CheckedPropertyPage : UserControl
    {
        public CheckedPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles CheckedChanged event of the DateTimePicker.
        /// Updates text of the label that represents checked state of the DateTimePicker.
        /// </summary>
        private void mobjDemoDateTimePicker_CheckedChanged(object sender, EventArgs e)
        {
            // Update text of the label that represents checked state of the DateTimePicker.
            this.mobjDateTimePickerCheckBoxStateLabel.Text = string.Format("The DateTimePicker is {0} now !", (this.mobjDemoDateTimePicker.Checked) ? "checked" : "unchecked");
        }

        /// <summary>
        /// Handles Load event of the example UserControl.
        /// </summary>
        private void CheckedPropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial value for text of the label that represents checked state of the DateTimePicker.
            this.mobjDateTimePickerCheckBoxStateLabel.Text = string.Format("The DateTimePicker is {0} now!", (this.mobjDemoDateTimePicker.Checked) ? "checked" : "unchecked");
        }
    }
}
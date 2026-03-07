using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DateTimePicker.Features
{
    public partial class MaxDatePropertyPage : UserControl
    {
        public MaxDatePropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles ValueChanged event of the DateTimePicker that 
        /// represents allowed maximum date for the demonstrated DateTimePicker.
        /// </summary>
        private void mobjMaxDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.DateTimePicker mobjDateTimePicker = sender as Gizmox.WebGUI.Forms.DateTimePicker;

            // Change maximum limit of the DateTimePicker.
            this.mobjDemoDateTimePicker.MaxDate = mobjDateTimePicker.Value;
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void MaxDatePropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial value for the DateTimePicker as maximum date of the demonstrated DateTimePicker
            this.mobjMaxDateTimePicker.Value = this.mobjDemoDateTimePicker.MaxDate;
        }
    }
}
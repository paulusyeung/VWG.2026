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
    public partial class MinDatePropertyPage : UserControl
    {
        public MinDatePropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles ValueChanged event of the DateTimePicker that 
        /// represents allowed minimum date for the demonstrated DateTimePicker.
        /// </summary>
        private void mobjMinDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.DateTimePicker mobjDateTimePicker = sender as Gizmox.WebGUI.Forms.DateTimePicker;

            // Change minimum limit of the DateTimePicker.
            this.mobjDemoDateTimePicker.MinDate = mobjDateTimePicker.Value;
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void MinDatePropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial value for the DateTimePicker as minimum date of the demonstrated DateTimePicker
            this.mobjMinDateTimePicker.Value = this.mobjDemoDateTimePicker.MinDate;
        }
    }
}
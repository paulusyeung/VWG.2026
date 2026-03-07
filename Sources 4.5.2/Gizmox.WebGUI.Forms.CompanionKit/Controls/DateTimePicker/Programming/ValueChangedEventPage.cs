using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DateTimePicker.Programming
{
    public partial class ValueChangedEventPage : UserControl
    {
        public ValueChangedEventPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void ValueChangedEventPage_Load(object sender, EventArgs e)
        {
            // Set initial value for text of the label that represents current value of the DateTimePicker.
            this.mobjSelectedValueLabel.Text = string.Format("You selected:\r\n{0}", this.mobjDemoDateTimePicker.Value.ToLongDateString());
        }


        /// <summary>
        /// Handles ValueChanged event of the demonstrated DateTimePicker.
        /// </summary>
        private void mobjDemoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Update text of the label that represents current value of the DateTimePicker.
            this.mobjSelectedValueLabel.Text = string.Format("You selected:\r\n{0}", this.mobjDemoDateTimePicker.Value.ToLongDateString());
        }
    }
}
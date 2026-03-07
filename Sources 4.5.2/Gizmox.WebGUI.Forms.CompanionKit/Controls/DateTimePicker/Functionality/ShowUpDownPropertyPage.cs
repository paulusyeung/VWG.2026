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
    public partial class ShowUpDownPropertyPage : UserControl
    {
        public ShowUpDownPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles CheckedChanged event of the CheckBox that represents 
        /// a state of the DateTimePicker ShowUpDown property
        /// </summary>
        private void mobjUpDownButtonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Set value for the DateTimePicker ShowUpDown property according to checked state of the CheckBox
            this.mobjDemoDateTimePicker.ShowUpDown = this.mobjUpDownButtonCheckBox.Checked;
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void ShowUpDownPropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial checked state for the CheckBox that represents 
            // a state of the DateTimePicker ShowUpDown property
            this.mobjUpDownButtonCheckBox.Checked = this.mobjDemoDateTimePicker.ShowUpDown;
        }
    }
}
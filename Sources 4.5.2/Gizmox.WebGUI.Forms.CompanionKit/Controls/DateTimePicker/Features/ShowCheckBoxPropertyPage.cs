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
    public partial class ShowCheckBoxPropertyPage : UserControl
    {
        public ShowCheckBoxPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void ShowCheckBoxPropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial checked state for the CheckBox that represents 
            // a state of the DateTimePicker ShowCheckBox property
            this.mobjAllowCheckBoxForDateTimePickerCheckBox.Checked = this.mobjDemoDateTimePicker.ShowCheckBox;
        }

        /// <summary>
        /// Handles CheckedChanged event of the CheckBox that represents 
        /// a state of the DateTimePicker ShowCheckBox property
        /// </summary>
        private void mobjAllowCheckBoxForDateTimePickerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Set value for the DateTimePicker ShowCheckBox property according to checked state of the CheckBox
            this.mobjDemoDateTimePicker.ShowCheckBox = this.mobjAllowCheckBoxForDateTimePickerCheckBox.Checked;
        }

    }
}
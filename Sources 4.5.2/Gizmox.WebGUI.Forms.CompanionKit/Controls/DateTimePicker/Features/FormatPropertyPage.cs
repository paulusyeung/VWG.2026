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
    public partial class FormatPropertyPage : UserControl
    {
        public FormatPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void FormatPropertyPage_Load(object sender, EventArgs e)
        {
            // Fill up the ComboBow with enable date formats of the DataTimePicker.
            DateTimePickerFormat mobjDefaultDateFormat = this.mobjDemoDateTimePicker.Format;
            this.mobjDateFormatComboBox.DataSource = Enum.GetValues(typeof(DateTimePickerFormat));
            this.mobjDateFormatComboBox.SelectedItem = mobjDefaultDateFormat;
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox that contains 
        /// enable date formats of the DataTimePicker. Sets selected format 
        /// for the DateTimePicker.
        /// </summary>
        private void mobjDateFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set selected date format for the DateTimePicker
            this.mobjDemoDateTimePicker.Format = (DateTimePickerFormat)this.mobjDateFormatComboBox.SelectedItem;
        }
    }
}
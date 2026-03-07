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
    public partial class CustomFormatPropertyPage : UserControl
    {
        public CustomFormatPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Handles Load event of the example' UserControl
        /// </summary>
        private void CustomFormatPropertyPage_Load(object sender, EventArgs e)
        {
            // Fill up with custom date formats.
            this.mobjDateFormatsListBox.Items.AddRange(new string[]{"M/d/yyyy", "dddd, MMMM dd, yyyy", 
                                                              "dddd, MMMM dd, yyyy h:mm:ss tt", 
                                                              "MMMM dd", "ddd, dd MMM yyyy HH:mm:ss", 
                                                              "h:mm tt", "h:mm:ss tt", "yyyy-MM-dd HH:mm:ssZ", 
                                                              "MMMM, yyyy"});
            this.mobjDateFormatsListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles a SelectedIndexChanged event of the ListBox 
        /// that contains custom date formats of the DateTimePicker
        /// </summary>
        private void mobjDateFormatsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update custom format of the demonstrated DateTimePicker.
            this.mobjDemoDateTimePicker.CustomFormat = (string)this.mobjDateFormatsListBox.SelectedItem;
        }
    }
}
using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Collections;

namespace CompanionKit.Controls.BindingNavigator.Features
{
    public partial class CountItemFormatPropertyPage : UserControl
    {
        public CountItemFormatPropertyPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Handles Load event for Page
        /// </summary>
        private void CountItemFormatPropertyPage_Load(object sender, EventArgs e)
        {
            // Set data source for BindingSource
            mobjBindingSource.DataSource = new string[] { "Item1", "Item2", "Item3", "Item4", "Item5" };
            // Set display format for BindingNavigator control
            SetFormat();
        }

        /// <summary>
        /// Handles Click event for Button control
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            // Set display format for BindingNavigator control
            SetFormat();
        }

        /// <summary>
        /// Sets display format for BindingNavigator control
        /// </summary>
        private void SetFormat()
        {
            mobjBindingNavigator.CountItemFormat = mobjPrefixTextBox.Text + " {0} " + mobjCenterTextTextBox.Text + " {1} " + mobjSuffixTextBox.Text;
        }
    }
}
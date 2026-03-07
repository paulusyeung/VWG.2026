using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.SearchTextBox.Features
{
    public partial class SearchTextBoxWatermarkTextProperty : UserControl
    {
        public SearchTextBoxWatermarkTextProperty()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event for Page
        /// </summary>
        private void SearchTextBoxWatermarkTextProperty_Load(object sender, EventArgs e)
        {
            // Set watermark
            SetWatermarkText();
        }

        /// <summary>
        /// Handles Click event for Button control
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Set watermark
            SetWatermarkText();
        }

        /// <summary>
        /// Sets watermark text for SearchTextBox control
        /// </summary>
        public void SetWatermarkText()
        {
            searchTextBox1.WatermarkText = textBox1.Text;
        }        
    }
}
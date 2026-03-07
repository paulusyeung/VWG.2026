using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.WatermarkTextBox.Features
{
    public partial class MessagePropertyPage : UserControl
    {
        public MessagePropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            //if textBox contains not empty text - assign it to WatermarkTextBox's message property
            if(!string.IsNullOrEmpty(mobjInputTextBox.Text))
            {
                mobjWatermarkTextBox.Message = mobjInputTextBox.Text;
            }
        }
    }
}
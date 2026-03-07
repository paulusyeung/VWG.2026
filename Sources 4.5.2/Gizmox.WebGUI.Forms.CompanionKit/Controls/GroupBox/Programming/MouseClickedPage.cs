#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.GroupBox.Programming
{
    public partial class MouseClickedPage : UserControl
    {
        public MouseClickedPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the GroupBox control.
        /// Shows message that indicates whether the event is fired.
        /// </summary>
        private void mobjGroupBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = e as MouseEventArgs;
            if (mea != null)
            {
                if (mea.Button == MouseButtons.Right)
                { //Check for right button click
                    this.mobjButtonClickedLabel.Text = "Right clicked";
                }
                else if (mea.Button == MouseButtons.Left)
                { //Check for Left button click
                    this.mobjButtonClickedLabel.Text = "Left clicked";
                }
            }
            else
            {
                this.mobjButtonClickedLabel.Text = "Mouse clicked!";
            }
        }
    }
}

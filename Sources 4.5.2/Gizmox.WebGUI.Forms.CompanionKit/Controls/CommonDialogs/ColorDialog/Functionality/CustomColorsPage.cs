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

namespace CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality
{
    public partial class CustomColorsPage : UserControl
    {
        public CustomColorsPage()
        {
            InitializeComponent();
        }

        private void CustomColorsPage_Load(object sender, EventArgs e)
        {
            //Set array colors to CustomColors property of ColorDialog
            this.mobjDemoColorDialog.CustomColors = new int[] { 0x80FFFF, 0x8080FF };
        }

        private void mobjChangeBackColorButton_Click(object sender, EventArgs e)
        {
            //Set represented Label backgroud color a initial color for ColorDialog
            this.mobjDemoColorDialog.Color = this.mobjColorlLabel.BackColor;
            //Show ColorDialog
            this.mobjDemoColorDialog.ShowDialog();
        }

        private void mobjDemoColorDialog_Closed(object sender, EventArgs e)
        {
            //Check dialog result for closed ColorDialog
            if (this.mobjDemoColorDialog.DialogResult == DialogResult.OK)
            {
                //Set selct Color as background color of represented Label
                this.mobjColorlLabel.BackColor = this.mobjDemoColorDialog.Color;
            }
        }
    }
}
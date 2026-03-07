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
    public partial class AllowFullOpenPage : UserControl
    {
        /// <summary>
        /// Indicates whether button was click for backgroud color change 
        /// </summary>
        private bool _isBackColorLabelChanged = false;

        public AllowFullOpenPage()
        {
            InitializeComponent();
        }

        private void mobjChangeBackColorButton_Click(object sender, EventArgs e)
        {
            //Set represented Label backgroud color a initial color for ColorDialog
            this.mobjDemoColorDialog.Color = this.mobjColorLabel.BackColor;
            //Changed value of flag, that indicates whether button was click for 
            //backgroud color change, to true
            _isBackColorLabelChanged = true;
            //Show ColorDialog
            this.mobjDemoColorDialog.ShowDialog();
        }

        private void mobjChangeForeColorButton_Click(object sender, EventArgs e)
        {
            //Set represented Label foreground color a initial color for ColorDialog
            this.mobjDemoColorDialog.Color = this.mobjColorLabel.ForeColor;
            //Changed value of flag, that indicates whether button was click for 
            //foreground color change, to false
            _isBackColorLabelChanged = false;
            //Show ColorDialog
            this.mobjDemoColorDialog.ShowDialog();
        }

        private void mobjDemoColorDialog_Closed(object sender, EventArgs e)
        {
            //Check dialog result for closed ColorDialog
            if (this.mobjDemoColorDialog.DialogResult == DialogResult.OK)
            {
                //Check whether backgroud color of represented Label should be changed
                if (_isBackColorLabelChanged)
                {
                    //Set backgroud color of represented Label to selected color
                    this.mobjColorLabel.BackColor = this.mobjDemoColorDialog.Color;
                }
                else
                {
                    //Set foregroud color of represented Label to selected color
                    this.mobjColorLabel.ForeColor = this.mobjDemoColorDialog.Color;
                }
            }
           
        }

    }
}
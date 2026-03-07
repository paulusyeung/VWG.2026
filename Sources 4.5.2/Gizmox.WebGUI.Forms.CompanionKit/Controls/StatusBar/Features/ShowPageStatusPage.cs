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

namespace CompanionKit.Controls.StatusBar.Features
{
    public partial class ShowPageStatusPage : UserControl
    {
        /// <summary>
        /// Represents percents of page loading process.
        /// </summary>
        private int _mintNumber = 0;

        public ShowPageStatusPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update text of the status bar an the progrest according to loading process.
        /// </summary>
        private void updateStatusBarTimer_Tick(object sender, EventArgs e)
        {
            // Increase loading percents.
            _mintNumber += 6;
            
            //Resets percent of loadin process.
            if (_mintNumber > 100)
            {
                this.mobjDemoStatusBar.Text = "Starting";
                _mintNumber = 0;
            }

            // Update the StatusBar text with loading phase name.
            else if (_mintNumber > 0 && _mintNumber < 40)
            {
                this.mobjDemoStatusBar.Text = "Phase 1";
            } 
            else if (_mintNumber > 40 && _mintNumber < 80)
            {
                this.mobjDemoStatusBar.Text = "Phase 2";
            } 
            else if (_mintNumber > 80 && _mintNumber < 100)
            {
                this.mobjDemoStatusBar.Text = "Phase 3";
            }
            this.mobjProgressBar.Value = _mintNumber;
        }
    }
}
using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.TabControl.Appearance
{
    public partial class TabsAlignmentPage : UserControl
    {
        public TabsAlignmentPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjTopRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTopRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Changes tabs alignment
            mobjTabControl.Alignment = mobjTopRadioButton.Checked ? TabAlignment.Top : TabAlignment.Bottom;
            //Changes tabPage image
            ChangeTabImages();
        }

        /// <summary>
        /// Changes the tab images.
        /// </summary>
        private void ChangeTabImages()
        {
            //Gets image name string 
            string mstrImageName = mobjTabControl.Alignment == TabAlignment.Top ? "Images.TabTop.png" : "Images.TabBottom.png"; 
            //Changes each item's image
            foreach (TabPage mobjTabPage in mobjTabControl.TabPages)
            {
                mobjTabPage.BackgroundImage = mstrImageName;
            }
        }
    }
}
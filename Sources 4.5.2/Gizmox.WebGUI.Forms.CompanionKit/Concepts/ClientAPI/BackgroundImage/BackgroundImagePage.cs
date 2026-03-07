using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.BackgroundImage;

namespace CompanionKit.Concepts.ClientAPI.BackgroundImage
{
    public partial class BackgroundImagePage : UserControl
    {
        public BackgroundImagePage()
        {
            InitializeComponent();

            //Add custom panel to user control
            BackImagePanel mobjCustomPanel = new BackImagePanel();
                mobjCustomPanel.CustomStyle = "BackImagePanelSkin";
                mobjCustomPanel.Location = new Point(10, 60);
                mobjCustomPanel.Size = new System.Drawing.Size(300, 280);
                mobjCustomPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(mobjCustomPanel);

        }
    }
}
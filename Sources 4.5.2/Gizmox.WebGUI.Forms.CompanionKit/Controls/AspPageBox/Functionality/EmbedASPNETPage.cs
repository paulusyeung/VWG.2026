using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.AspPageBox.Functionality
{
    public partial class EmbedASPNETPage : UserControl
    {
        public EmbedASPNETPage()
        {
            InitializeComponent();
        }

        private void EmbedASPNETPage_Load(object sender, EventArgs e)
        {
            this.demoAspPageBox.Path = @"Controls\AspPageBox\Functionality\AspViewPage.aspx";
        }
    }
}
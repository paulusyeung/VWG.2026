using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ImageListFolder.Programming
{
    public partial class ToolBarImageListPage : UserControl
    {
        public ToolBarImageListPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles ButtonClick event for the ToolBar
        /// </summary>
        private void mobjToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            // Show ImageKey property value of the button being clicked
            MessageBox.Show(string.Format("Button ImageKey: {0}", e.Button.ImageKey));
        }
    }
}
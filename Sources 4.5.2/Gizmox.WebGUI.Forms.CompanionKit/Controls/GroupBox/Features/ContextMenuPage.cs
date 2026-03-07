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

namespace CompanionKit.Controls.GroupBox.Features
{
    public partial class ContextMenuPage : UserControl
    {
        public ContextMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handels Click event for Context menu item.
        /// Shows message box.
        /// </summary>
        private void menuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                this.mobjLabel.Text = string.Format("You've selected '{0}' menu item.", menuItem.Text);
            }
        }
    }
}
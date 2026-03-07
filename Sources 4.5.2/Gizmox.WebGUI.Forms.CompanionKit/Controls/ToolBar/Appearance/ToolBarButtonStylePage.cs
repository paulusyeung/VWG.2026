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

namespace CompanionKit.Controls.ToolBar.Appearance
{
    public partial class ToolBarButtonStylePage : UserControl
    {
        public ToolBarButtonStylePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of DropDown menu items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            MessageBox.Show(string.Format("Menu Item {0} has been clicked!", menuItem.Text));
        }

        /// <summary>
        /// Handles click event for ToolBars' Buttons.
        /// </summary>
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button != null)
            {
                switch (e.Button.Style)
                {
                    case ToolBarButtonStyle.PushButton:
                        MessageBox.Show("Pushed button has been clicked!");
                        break;
                    case ToolBarButtonStyle.ToggleButton:
                        MessageBox.Show(string.Format("Toggle button is turn {0}!", (e.Button.Pushed ? "on" : "off")));
                        break;
                    default:
                        MessageBox.Show(string.Format("ToolBar button '{0}' is clicked with {1} style!", e.Button.Name, e.Button.Style));
                        break;
                }
            }
        }

    }
}
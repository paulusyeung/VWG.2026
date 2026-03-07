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

namespace CompanionKit.Controls.ContextMenu.Programming
{
    public partial class PopupPage : UserControl
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Popup event for ContextMenu.
        /// Changes text of the label that indicates whether Contextmenu is popped up.
        /// </summary>
        private void mobjContextMenu_Popup(object sender, EventArgs e)
        {
            UpdateLabel(true);
        }

        /// <summary>
        /// Handles Click event for Menu item.
        /// Changes text of label that represents information abour clicked item.
        /// </summary>
        private void mobjMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem mobjMenuItem = sender as MenuItem;
            if (mobjMenuItem != null)
            {
                this.mobjLabel2.Text = string.Format("You've selected '{0}' menu item.", mobjMenuItem.Text);
                CenterLabel(mobjLabel2);
            }
        }

        /// <summary>
        /// Handles Collapse event for ContextMenu.
        /// Changes text of the label that indicates whether ContextMenu is collapsed.
        /// </summary>
        private void mobjContextMenu_Collapse(object sender, EventArgs e)
        {
            UpdateLabel(false);
        }

        /// <summary>
        /// Update text and location of the label.
        /// </summary>
        /// <param name="isPopuped">Indicates whether context menu is popped up</param>
        private void UpdateLabel(bool isPopuped)
        {
            this.mobjLabel1.Text = string.Format("ContexMenu is{0} shown!", isPopuped ? "" : "n't");
            CenterLabel(mobjLabel1);
        }

        /// <summary>
        /// Centers label on the user control.
        /// </summary>
        /// <param name="ctrLabel">the label that should be centered</param>
        private void CenterLabel(Label ctrLabel)
        {
            ctrLabel.Location = new System.Drawing.Point((637 - ctrLabel.Width) / 2, ctrLabel.Location.Y);
        }

    }
}

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.WorkspaceTabs.PopulatingData
{
    public partial class TabPagesCollectionPage : UserControl
    {
        public TabPagesCollectionPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            //Adds to TabPages collection new WorkspaceTab item
            WorkspaceTab objTab = new WorkspaceTab();
            objTab.Text= Text = string.Format("workspaceTab{0}", mobjWorkspaceTabs.TabPages.Count+1);
            objTab.BackColor= Color.FromArgb(255, 255, 192);
            mobjWorkspaceTabs.TabPages.Add(objTab);
        }

        /// <summary>
        /// Handles the CloseClick event of the objWorkspaceTabs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjWorkspaceTabs_CloseClick(object sender, EventArgs e)
        {
            //Gets index of last item
            int mintIndex = mobjWorkspaceTabs.TabPages.Count - 1;
            //If index more or equal zero, then remove item with such an index
            if (mintIndex >= 0)
            {
                mobjWorkspaceTabs.TabPages.RemoveAt(mintIndex);
            }
        }
    }
}
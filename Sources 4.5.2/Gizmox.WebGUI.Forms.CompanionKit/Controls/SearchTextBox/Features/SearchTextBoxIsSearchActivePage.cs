using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.SearchTextBox.Features
{
    public partial class SearchTextBoxIsSearchActivePage : UserControl
    {
        public SearchTextBoxIsSearchActivePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event for Button control
        /// Sets tooltip text and icon according to search state
        /// </summary>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            
            if (searchTextBox1.IsSearchActive)
            {
                this.errorProvider1.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.InProgress.png");
                errorProvider1.SetError(searchTextBox1, "Search in progress");
            }
            else
            {
                this.errorProvider1.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.Success.png");
                errorProvider1.SetError(searchTextBox1, "Search complete");
            }
        }

        /// <summary>
        /// Handles Search event for SearchTextBox control
        /// Hides tooltip for SearchTextBox control
        /// </summary>
        private void searchTextBox1_Search(object sender, EventArgs e)
        {
            this.errorProvider1.Icon = null;
            errorProvider1.SetError(searchTextBox1, "");
        }
    }
}
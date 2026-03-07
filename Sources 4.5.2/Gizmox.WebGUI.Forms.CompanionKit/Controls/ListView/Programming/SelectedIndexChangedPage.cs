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

namespace CompanionKit.Controls.ListView.Programming
{
    public partial class SelectedIndexChangedPage : UserControl
    {
        public SelectedIndexChangedPage()
        {
            InitializeComponent();

            // Fill up the ListView
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User1", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User2", "8-800-9513546" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User3", "8-800-8524563" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User4", "8-800-9874613" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User5", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User6", "8-800-9513546" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User7", "8-800-8524563" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User8", "8-800-9874613" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User9", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User10", "8-800-9513546" }));
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.mobjListView.SelectedItem == null)
            {
                this.mobjSelectedLabel.Text = "Unselected items of ListView";
            }
            else 
            {
                this.mobjSelectedLabel.Text = string.Format("Item #{0} is selected with user {1} with phone {2}", this.mobjListView.SelectedIndex, this.mobjListView.SelectedItem.SubItems[0].Text, this.mobjListView.SelectedItem.SubItems[1].Text);
            }
        }
    }
}
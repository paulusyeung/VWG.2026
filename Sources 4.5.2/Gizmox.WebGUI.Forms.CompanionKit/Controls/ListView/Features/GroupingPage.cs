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

namespace CompanionKit.Controls.ListView.Features
{
    public partial class GroupingPage : UserControl
    {
        public GroupingPage()
        {
            InitializeComponent();

            // Fill up listView
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "1", "User1", "8-800-1234556", "user1@gmail.com" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "2", "User2", "8-800-9513546", "user2@gmail.com" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "3", "User3", "8-800-8524563", "user3@gmail.com" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "4", "User4", "8-800-9874613", "user4@gmail.com" }));

            // Define  group for each item
            this.mobjListView.Items[0].Group = this.mobjListView.Groups[0];
            this.mobjListView.Items[1].Group = this.mobjListView.Groups[1];
            this.mobjListView.Items[2].Group = this.mobjListView.Groups[1];
            this.mobjListView.Items[3].Group = this.mobjListView.Groups[1];
        }
    }
}
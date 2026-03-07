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
    public partial class ColumnReorderingPage : UserControl
    {
        public ColumnReorderingPage()
        {
            InitializeComponent();
            // Fill up ListView with allowed reordering of columns
            this.allowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "1", "User1", "Name1" }));
            this.allowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "2", "User2", "Name2" }));
            this.allowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "3", "User3", "Name3" }));
            this.allowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "4", "User4", "Name4" }));

            // Fill up ListView with unallowed reordering of columns
            this.unallowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "1", "User1", "Name1" }));
            this.unallowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "2", "User2", "Name2" }));
            this.unallowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "3", "User3", "Name3" }));
            this.unallowedReorderingColumnListView.Items.Add(new ListViewItem(new string[] { "4", "User4", "Name4" }));

        }
    }
}
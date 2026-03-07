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
    public partial class ResizingPage : UserControl
    {
        public ResizingPage()
        {
            InitializeComponent();

            // Fill up ListView
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "1", "User1", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "2", "User2", "8-800-9513546" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "3", "User3", "8-800-8524563" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "4", "User4", "8-800-9874613" }));
        }
    }
}
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

namespace CompanionKit.Controls.ListBox.PopulatingData
{
    public partial class CollectionDataSourcePage : UserControl
    {
        public CollectionDataSourcePage()
        {
            InitializeComponent();
            //Set collection of customer as DataSource.
            this.mobjListBox.DataSource = global::Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.CustomerData.GetCustomers();
            //Fill Display and Value Members
            mobjDisplayText.Text = mobjListBox.DisplayMember;
            mobjValueText.Text = mobjListBox.ValueMember;
        }
    }
}
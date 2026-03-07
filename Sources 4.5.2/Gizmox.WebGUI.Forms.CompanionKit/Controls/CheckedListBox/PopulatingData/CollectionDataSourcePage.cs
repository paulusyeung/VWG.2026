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

namespace CompanionKit.Controls.CheckedListBox.PopulatingData
{
    public partial class CollectionDataSourcePage : UserControl
    {
        public CollectionDataSourcePage()
        {
            InitializeComponent();

            //Set collection of customer as DataSource.
            this.mobjCheckedListBox.DataSource = global::Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.CustomerData.GetCustomers();

            //Fill ValueMember and DisplayMember TextBoxes
            mobjValueTB.Text = mobjCheckedListBox.ValueMember;
            mobjDisplayTB.Text = mobjCheckedListBox.DisplayMember;
        }

    }
}
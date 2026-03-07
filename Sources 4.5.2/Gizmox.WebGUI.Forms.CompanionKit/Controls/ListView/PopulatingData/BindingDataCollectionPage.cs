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

namespace CompanionKit.Controls.ListView.PopulatingData
{
    public partial class BindingDataCollectionPage : UserControl
    {
        public BindingDataCollectionPage()
        {
            InitializeComponent();
            
            // Set DataSources for the ListView as Customer objects collection.
            this.mobjListView.DataSource = Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.CustomerData.GetCustomers();
        }
    }
}
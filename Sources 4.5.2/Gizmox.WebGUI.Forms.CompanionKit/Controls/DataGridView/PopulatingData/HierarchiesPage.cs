using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    public partial class HierarchiesPage : UserControl
    {
        public HierarchiesPage()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Handles the Load event of the HierarchiesPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HierarchiesPage_Load(object sender, EventArgs e)
        {
            //Fill DataGridView

            this.ordersAdapter.Fill(mobjDS.Orders);
            this.orderDetailsAdapter.Fill(this.mobjDS.Order_Details);
            this.productsAdapter.Fill(this.mobjDS.Products);
        }
    }
}
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

namespace CompanionKit.Controls.ListView.Performance
{
    public partial class PagingPage : UserControl
    {
        public PagingPage()
        {
            InitializeComponent();
            
            // Fill up ListView
            for (int i = 1; i < 31; ++i)
            {
                this.listViewWithPaging.Items.Add(new ListViewItem(new string[] { string.Format("User{0}", i), string.Format("user{0}@gmail.com", i) }));
                this.listViewWithoutPaging.Items.Add(new ListViewItem(new string[] { string.Format("User{0}", i), string.Format("user{0}@gmail.com", i) }));
            }

            this.itemsPerPagesNumUpDown.Value = this.listViewWithPaging.ItemsPerPage;
            }

        /// <summary>
        /// Handles the ValueChanged event of the itemsPerPagesNumUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void itemsPerPagesNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.listViewWithPaging.ItemsPerPage = decimal.ToInt32(this.itemsPerPagesNumUpDown.Value);
        }

       
    }
}
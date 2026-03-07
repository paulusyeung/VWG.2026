#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CompanionKit.Controls.ListView.Features
{
    public partial class ViewsPage : UserControl
    {
        public ViewsPage()
        {
            InitializeComponent();
            // Fill up ListView
            this.mobjListView.Items.Add(GetListViewItem("User1", "8-800-1234556" ));
            this.mobjListView.Items.Add(GetListViewItem("User2", "8-800-9513546" ));
            this.mobjListView.Items.Add(GetListViewItem("User3", "8-800-8524563" ));
            this.mobjListView.Items.Add(GetListViewItem("User4", "8-800-9874613" ));
        }

        /// <summary>
        /// Gets item for ListView with defined data.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="phone">User phone.</param>
        /// <returns></returns>
        private ListViewItem GetListViewItem( string userName, string phone)
        {
            // Create ListView item
            ListViewItem listViewItem = new ListViewItem(new string[] {userName, phone});
            
            // Set icons for the ListView items that displayed when ListView is LargeIcon view mode. 
            listViewItem.LargeImage = new ImageResourceHandle("32x32.Photo.png");
            // Set icons for the ListView items that displayed when ListView is SmallIcon view mode.
            listViewItem.SmallImage = new ImageResourceHandle("16x16.Photo.png");
           
            return listViewItem;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjDetailsRB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RB_CheckedChanged(object sender, EventArgs e)
        { 
            //Set ListView.View property to selected view
            if (mobjDetailsRB.Checked)
                mobjListView.View = View.Details;
            else if (mobjListRB.Checked)
                mobjListView.View = View.List;
            else if (mobjSmallIconRB.Checked)
                mobjListView.View = View.SmallIcon;
            else
                mobjListView.View = View.LargeIcon;
        }
    }
}

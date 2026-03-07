using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.SearchTextBox.Functionality
{
    public partial class SearchingPage : UserControl
    {
        //Creates list of listView's items
        List<ListViewItem> mobjListOfItems = new List<ListViewItem>();

        public SearchingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the SearchingPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SearchingPage_Load(object sender, EventArgs e)
        {
            //Fills list with items and assigns to listView control
            mobjListOfItems.Add(new ListViewItem("Orange" ));
            mobjListOfItems.Add(new ListViewItem("Grape" ));
            mobjListOfItems.Add(new ListViewItem("Cherry" ));
            mobjListOfItems.Add(new ListViewItem("Banana" ));
            mobjListOfItems.Add(new ListViewItem("Apple" ));
            mobjListOfItems.Add(new ListViewItem("Lime" ));
            mobjListOfItems.Add(new ListViewItem("Pineapple" ));
            mobjListOfItems.Add(new ListViewItem("Strawberry" ));
            mobjListView.Items.AddRange(mobjListOfItems.ToArray());
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjSearchTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            //If text of searchTextBox is empty or null - reassign default list
            if (string.IsNullOrEmpty(mobjSearchTextBox.Text))
            {
                mobjListView.Items.Clear();
                mobjListView.Items.AddRange(mobjListOfItems.ToArray());
            }
        }

        /// <summary>
        /// Handles the Search event of the mobjSearchTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objSearchTextBox_Search(object sender, EventArgs e)
        {
            //Creates list where all items, which contain keyword, will be added
            List<ListViewItem> mobjListOfFilteredItems = new List<ListViewItem>();
            //Checks all items on keyword content
            //If item contains - add to list
            foreach (ListViewItem mobjItem in mobjListOfItems)
            {
                if (mobjItem.Text.ToLower().Contains(mobjSearchTextBox.Text.ToLower()))
                {
                    mobjListOfFilteredItems.Add(mobjItem);
                }
            }
            //Clears items list 
            mobjListView.Items.Clear();
            //If filtered list is not empty - assign to listView
            if (mobjListOfFilteredItems.Count != 0)
            {
                mobjListView.Items.AddRange(mobjListOfFilteredItems.ToArray());
            }
            //If list empty - show message and clear searchTextBox text
            else { MessageBox.Show(string.Format("Sorry, but '{0}' has no result ", mobjSearchTextBox.Text)); mobjSearchTextBox.Text = string.Empty; }
        }
    }
}
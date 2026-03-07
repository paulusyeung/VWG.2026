using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.SearchTextBox.Features
{
    public partial class SearchTextBoxDropDownMenuPropertyPage : UserControl
    {
        public SearchTextBoxDropDownMenuPropertyPage()
        {
            InitializeComponent();
            // Create menu items
            MenuItem item1 = new MenuItem("Top 5 searches");
            MenuItem item11 = new MenuItem("free movies");
            MenuItem item12 = new MenuItem("music");
            MenuItem item13 = new MenuItem("funny cats");
            MenuItem item14 = new MenuItem("online tv");
            MenuItem item15 = new MenuItem("video chat");
            // Add Click event handlers to menu items
            item11.Click += new EventHandler(menuItem_Click);
            item12.Click += new EventHandler(menuItem_Click);
            item13.Click += new EventHandler(menuItem_Click);
            item14.Click += new EventHandler(menuItem_Click);
            item15.Click += new EventHandler(menuItem_Click);
            // Add menu items to context menu
            item1.MenuItems.Add(item11);
            item1.MenuItems.Add(item12);            
            item1.MenuItems.Add(item13);
            item1.MenuItems.Add(item14);
            item1.MenuItems.Add(item15);
            contextMenu1.MenuItems.Add(item1);

            // Create menu items
            MenuItem item2 = new MenuItem("Search engines");
            MenuItem item21 = new MenuItem("Google");
            MenuItem item22 = new MenuItem("Bing");
            MenuItem item23 = new MenuItem("Yahoo");
            // Add Click event handlers to menu items
            item21.Click += new EventHandler(SearchEngineChanged);
            item22.Click += new EventHandler(SearchEngineChanged);
            item23.Click += new EventHandler(SearchEngineChanged);
            // Add menu items to context menu
            item2.MenuItems.Add(item21);
            item2.MenuItems.Add(item22);
            item2.MenuItems.Add(item23);            
            contextMenu1.MenuItems.Add(item2);
        }

        /// <summary>
        /// Handles Click event for MenuItem
        /// </summary>
        private void menuItem_Click(object sender, EventArgs e)
        {
            // Set text for SearchTextBox control
            searchTextBox1.Text = ((MenuItem)sender).Text;
        }

        /// <summary>
        /// Handles Click event for MenuItem
        /// </summary>
        private void SearchEngineChanged(object sender, EventArgs e)
        {
            // Uncheck all menu items
            foreach (MenuItem menuItem in contextMenu1.MenuItems[1].MenuItems)
            {
                menuItem.Checked = false;
            }
            // Check selected menu item
            ((MenuItem)sender).Checked = true;
        }
    }
}
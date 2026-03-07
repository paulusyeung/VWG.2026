using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.Collections;

namespace CompanionKit.Controls.BindingNavigator.Features
{
    public partial class CustomizingImagesPage : UserControl
    {
        public CustomizingImagesPage()
        {
            InitializeComponent();
            
            // All custom images are containing inside the ImageList

            // Set image for 'Move first' button
            mobjBindingNavigator.Buttons[0].ImageIndex = 0;
            // Set image for 'Move previous' button
            mobjBindingNavigator.Buttons[1].ImageIndex = 1;
            // Set image for 'Move next' button
            mobjBindingNavigator.Buttons[5].ImageIndex = 2;
            // Set image for 'Move last' button
            mobjBindingNavigator.Buttons[6].ImageIndex = 3;
            // Set image for 'Add new' button
            mobjBindingNavigator.Buttons[8].ImageIndex = 4;
            // Set image for 'Remove' button
            mobjBindingNavigator.Buttons[9].ImageIndex = 5;

            // Create and fill list
            ArrayList itemList = new ArrayList();
            itemList.Add(new Item("Item 1"));
            itemList.Add(new Item("Item 2"));
            itemList.Add(new Item("Item 3"));
            itemList.Add(new Item("Item 4"));
            itemList.Add(new Item("Item 5"));
            // Set list as data source for BindingSource
            mobjBindingSource.DataSource = itemList;
        }

        /// <summary>
        /// Represents 'Item' BL object
        /// </summary>
        public class Item
        {
            // Property and field to store
            // item name
            private string _name;
            public string Name
            {
                get { return this._name; }
                set { this._name = value; }
            }

            public Item(string name)
            {
                this.Name = name;
            }

            public Item()
            {
                this._name = "New item";
            }

            // Returns item name
            public override string ToString()
            {
                return this._name;
            }
        }
    }
}
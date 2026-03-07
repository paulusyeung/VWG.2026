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
    public partial class BindingToDataPage : UserControl
    {
        public BindingToDataPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event for Page
        /// </summary>
        private void BindingToDataPage_Load(object sender, EventArgs e)
        {
            // Create and fill list
            List<Friend> mobjFriendList = new List<Friend>();
            mobjFriendList.Add(new Friend("Michael"));
            mobjFriendList.Add(new Friend("Jack"));
            mobjFriendList.Add(new Friend("Kate"));
            mobjFriendList.Add(new Friend("John"));
            mobjFriendList.Add(new Friend("Hugo"));
            // Set list as data source for BindingSource
            mobjBindingSource.DataSource = mobjFriendList;
        }

        /// <summary>
        /// Represents 'Friend' BL object
        /// </summary>
        public class Friend
        {
            // Property and field to store
            // friend's name
            private string _name;
            public string Name 
            {
                get { return this._name; }
                set { this._name = value; }
            }

            public Friend(string name)
            {
                this.Name = name;
            }

            public Friend()
            {
                this._name = "New friend";
            }

            // Returns friend's name
            public override string ToString()
            {
                return this._name;
            }
        }
    }
}
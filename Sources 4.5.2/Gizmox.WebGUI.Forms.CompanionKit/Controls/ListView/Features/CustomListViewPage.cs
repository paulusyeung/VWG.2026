using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;


namespace CompanionKit.Controls.ListView.Features
{
    public partial class CustomListViewPage : UserControl
    {
        public CustomListViewPage()
        {
            InitializeComponent();

            // Fill up ListView
            this.mobjListView.Items.Add(GetListViewItem("1", "User1", "Photo.png", DateTime.Now, "Call #8-800-1234557", true));
            this.mobjListView.Items.Add(GetListViewItem("2", "User2", "Photo.png", DateTime.Now, "Call #8-800-9513546", false));
            this.mobjListView.Items.Add(GetListViewItem("3", "User3", "Photo.png", DateTime.Now, "Call #8-800-8524565", true));
            this.mobjListView.Items.Add(GetListViewItem("4", "User4", "Photo.png", DateTime.Now, "Call #8-800-9874614", false));
            this.mobjListView.Items.Add(GetListViewItem("5", "User5", "Photo.png", DateTime.Now, "Call #8-800-9874613", true));
            this.mobjListView.Items.Add(GetListViewItem("6", "User6", "Photo.png", DateTime.Now, "Call #8-800-9874612", false));
        }

        /// <summary>
        /// Gets item for the ListView with defined data.
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="userName">User Name</param>
        /// <param name="filePhotoName">File name of user foto, the file should be in Resources.Icons folder</param>
        /// <param name="visitDate">The date of user visit</param>
        /// <param name="buttonText">User phone</param>
        /// <param name="blnVIP">Indicates whether user is VIP person</param>
        /// <returns></returns>
        private ListViewItem GetListViewItem(string userID, string userName, string filePhotoName, DateTime visitDate, string buttonText, bool blnVIP)
        {
            ListViewItem listViewItem = new ListViewItem();
            
            // prepare button for 3rd column
            Gizmox.WebGUI.Forms.Button button1 = new Gizmox.WebGUI.Forms.Button();
            button1.AutoSize = true;
            button1.Text = buttonText;
            button1.Click += new System.EventHandler(this.button1_Click);
            // relate sub-item with control, for further data-extracting from Item
            button1.Tag = listViewItem;
            
            // prepare checkbox for 4th column
            Gizmox.WebGUI.Forms.CheckBox chkVIP = new Gizmox.WebGUI.Forms.CheckBox();
            chkVIP.Checked = blnVIP;
            chkVIP.CheckedChanged += new EventHandler(chkVIP_CheckedChanged);
            // relate sub-item with control, for further data-extracting from Item
            chkVIP.Tag = listViewItem;

            listViewItem.SubItems.Add(userID);
            listViewItem.SubItems.Add(userName);
            listViewItem.SubItems.Add(GetIconForPhoto(filePhotoName));
            listViewItem.SubItems.Add(visitDate.ToShortDateString());
            listViewItem.SubItems.Add(button1);
            listViewItem.SubItems.Add(chkVIP);
            
            return listViewItem;
        }

        /// <summary>
        /// Approve by message on checkbox click
        /// </summary>
        void chkVIP_CheckedChanged(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.CheckBox chkVIP = sender as Gizmox.WebGUI.Forms.CheckBox;
            if (null != chkVIP)
            {
                ListViewItem objUserItem = (ListViewItem)chkVIP.Tag;
                if (null != objUserItem)
                {

                    string strMessage = string.Format("The user '{0}' tagged as {1}VIP user.",
                        objUserItem.SubItems[1], chkVIP.Checked ? "" : "non-");

                    MessageBox.Show(strMessage, "Example of checkbox");
                }
            }
        }

        /// <summary>
        /// Approve by message on button click
        /// </summary>        
        private void button1_Click(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Button button = sender as Gizmox.WebGUI.Forms.Button;
            if(button != null)
            {
                ListViewItem objUserItem = (ListViewItem)button.Tag;
                if (null != objUserItem)
                {
                    MessageBox.Show(string.Format("The phone number of '{1}' is '{0}'", 
                        button.Text.Substring(5), objUserItem.SubItems[1]));
                }
            }
        }
        /// <summary>
        /// Gets VWG defined name of icon for user photo.
        /// </summary>
        private string GetIconForPhoto(string strName)
        {
            return (new Gizmox.WebGUI.Common.Resources.IconResourceHandle(strName)).ToString();
        }

    }
}

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

namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    public partial class UserForm : global::Gizmox.WebGUI.Forms.Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        public int UserID
        {
            get
            {
                return int.Parse(this.userIDTextBox.Text);
            }

            set
            {
                this.userIDTextBox.Text = value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets name of user.
        /// </summary>
        public string UserName
        {
            get
            {
                return this.userNameTextBox.Text;
            }

            set
            {
                this.userNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets email of user.
        /// </summary>
        public string Email
        {
            get
            {
                return this.emailTextBox.Text;
            }

            set
            {
                this.emailTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets phone of user.
        /// </summary>
        public string Phone
        {
            get
            {
                return this.phoneTextBox.Text;
            }

            set
            {
                this.phoneTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets address of user.
        /// </summary>
        public string Address
        {
            get
            {
                return this.addressTextBox.Text;
            }

            set
            {
                this.addressTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets city of user.
        /// </summary>
        public string City
        {
            get
            {
                return this.cityTextBox.Text;
            }

            set
            {
                this.cityTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets country of user.
        /// </summary>
        public string Country
        {
            get
            {
                return this.countryTextBox.Text;
            }

            set
            {
                this.countryTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets state of user.
        /// </summary>
        public string State
        {
            get
            {
                return this.stateTextBox.Text;
            }

            set
            {
                this.stateTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets ZipCode of user.
        /// </summary>
        public string ZipCode
        {
            get
            {
                return this.zipCodeTextBox.Text;
            }

            set
            {
                this.zipCodeTextBox.Text = value;
            }
        }        

        /// <summary>
        /// Handles Click event for 'Ok' button of the user form.
        /// Sets OK dialog result for the form and closes the form.
        /// </summary>
        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles Click event for 'Cancel' button of the user form.
        /// Sets Cancel dialog result for the form and closes the form.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
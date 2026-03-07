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

namespace CompanionKit.Controls.Form.Features
{
    public partial class DialogReturnValueForm : global::Gizmox.WebGUI.Forms.Form
    {
        public DialogReturnValueForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the 'Save' button.
        /// Closes the Form and set OK dialog result for the Form.
        /// </summary>
        private void mobjSaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles Click event of the 'Cancel' button.
        /// Closes the Form and set Cancel dialog result for the Form.
        /// </summary>
        private void mobjCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Gets or sets text value of the TextBox that represents user first name.
        /// </summary>
        public String UserFirstName
        {
            get
            {
                return this.mobjUserFirstNameTextBox.Text;
            }

            set
            {
                this.mobjUserFirstNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets text value of the TextBox that represents user last name.
        /// </summary>
        public String UserLastName
        {
            get
            {
                return this.mobjUserLastNameTextBox.Text;
            }

            set
            {
                this.mobjUserLastNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets user full name.
        /// </summary>
        public String UserFullName
        {
            get
            {
                return string.Format("{0} {1}", this.mobjUserFirstNameTextBox.Text, this.mobjUserLastNameTextBox.Text);
            }
        }

        /// <summary>
        /// Gets or sets text value of the TextBox that represents user phone.
        /// </summary>
        public String Phone
        {
            get
            {
                return this.mobjPhoneTextBox.Text;
            }

            set
            {
                this.mobjPhoneTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets text value of the TextBox that represents user email.
        /// </summary>
        public String Email
        {
            get
            {
                return this.mobjEmailTextBox.Text;
            }

            set
            {
                this.mobjEmailTextBox.Text = value;
            }
        }

    }
}
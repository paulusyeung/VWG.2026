#region Using

using System;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Common.Interfaces;

#endregion

namespace CompanionKit.DeviceIntegration.Contacts.Functionality
{
    public partial class ExampleCreate : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleCreate"/> class.
        /// </summary>
        public ExampleCreate()
        {
            InitializeComponent();
            btnCreate.Click += new EventHandler(btnCreate_Click);
        }

        void ExampleCreate_Load(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the btnCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnCreate_Click(object sender, EventArgs e)
        {
            // Validate user input.
            if (string.IsNullOrEmpty(tbAddress.Text) ||
                string.IsNullOrEmpty(tbMail.Text) ||
                string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrEmpty(tbPhone.Text))
            {
                mobjStatusImage.Image = new ImageResourceHandle("16x16.Failed.png");
                mobjStatusLabel.Text = "All fields must be filled";
            }
            else
            {
                // Create contact
                IContact contact = Context.DeviceIntegrator.Contacts.CreateContact();

                // Create address
                ContactAddress address = new ContactAddress();
                address.Formatted = tbAddress.Text;

                // Create email
                ContactField email = new ContactField();
                email.Value = tbMail.Text;
                email.Type = "Home";

                // Create phone
                ContactField phone = new ContactField();
                phone.Value = tbPhone.Text;
                phone.Type = "Mobile";

                // Add data to contact.
                contact.Addresses.Add(address);
                contact.Emails.Add(email);
                contact.PhoneNumbers.Add(phone);
                contact.DisplayName = tbName.Text;

                contact.Save(OnContactSaved);
            }
        }

        private void OnContactSaved(object sender, SaveContactEventArgs e)
        {
            string strLastName = tbName.Text;
            tbName.Text = "";
            tbPhone.Text = "";
            tbMail.Text = "";
            tbAddress.Text = "";

            mobjStatusImage.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.Success.png");
            mobjStatusLabel.Text = "Success: '" + strLastName + "'";
        }
    }
} 
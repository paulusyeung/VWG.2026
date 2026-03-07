#region Using

using System;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Device.Contacts;

#endregion

namespace CompanionKit.DeviceIntegration.Contacts.Functionality
{
    public partial class ExampleSearch : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleSearch"/> class.
        /// </summary>
        public ExampleSearch()
        {
            InitializeComponent();

            // Get all contacts
            SearchContacts("");
        }

        /// <summary>
        /// Handles the Search event of the searchTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void searchTextBox_Search(object sender, EventArgs e)
        {
            contactsListView.Items.Clear();

            SearchContacts(searchTextBox.Text);
        }

        /// <summary>
        /// Handles the Clear event of the searchTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void searchTextBox_Clear(object sender, System.EventArgs e)
        {
            contactsListView.Items.Clear();

            // Get all contacts
            SearchContacts("");
        }

        /// <summary>
        /// Searches the contacts.
        /// </summary>
        /// <param name="strSearchFilter">The STR search filter.</param>
        private void SearchContacts(string strSearchFilter)
        {
            // Create find options.
            ContactFindOptions options = new ContactFindOptions(strSearchFilter, true, ContactFields.DisplayName | ContactFields.Emails | ContactFields.Addresses | ContactFields.PhoneNumbers);
            Context.DeviceIntegrator.Contacts.FindContacts(DisplayContacts, options);
        }

        /// <summary>
        /// Callback for FindContacts.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.Contacts.FindContactsEventArgs"/> instance containing the event data.</param>
        private void DisplayContacts(object sender, FindContactsEventArgs e)
        {
            foreach (IContact objContact in e.Contacts)
            {
                // Create new listview item
                ListViewItem listItem = new ListViewItem();

                // Fill data
                listItem.Text = objContact.DisplayName ?? "No name";
                listItem.SubItems.Add(objContact.PhoneNumbers != null && objContact.PhoneNumbers.Count > 0 && objContact.PhoneNumbers[0].Value != null ? objContact.PhoneNumbers[0].Value : "No phone number");
                listItem.SubItems.Add(objContact.Addresses != null && objContact.Addresses.Count > 0 && objContact.Addresses[0].Formatted != null ? objContact.Addresses[0].Formatted : "No address");
                listItem.SubItems.Add(objContact.Emails != null && objContact.Emails.Count > 0 && objContact.Emails[0].Value != null ? objContact.Emails[0].Value : "No email");
                // Add to listview.
                contactsListView.Items.Add(listItem);
            }
        }
    }
}
#region Using

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.Storage;
using System;

#endregion

namespace CompanionKit.DeviceIntegration.Storage.Functionality
{
    public partial class LocalStorageExample : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalStorageExample"/> class.
        /// </summary>
        public LocalStorageExample()
        {
            InitializeComponent();
            mbtnStore.ClientClick += new ClientEventHandler(btnStore_ClientClick);
        }

        /// <summary>
        /// Handles the Click event of the mbtnLoad control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void mbtnLoad_Click(object sender, EventArgs e)
        {
            // Get all data by keys, 1-by-1. Server callback provided.
            Context.DeviceIntegrator.Storage.LocalStorage.GetItem(LoadContactData, "name");
            Context.DeviceIntegrator.Storage.LocalStorage.GetItem(LoadContactData, "phone");
            Context.DeviceIntegrator.Storage.LocalStorage.GetItem(LoadContactData, "email");
            Context.DeviceIntegrator.Storage.LocalStorage.GetItem(LoadContactData, "address");
        }

        /// <summary>
        /// Loads the contact data. Get item server callback.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Common.Device.LocalStorage.LocalStorageEventArgs"/> instance containing the event data.</param>
        private void LoadContactData(object sender, LocalStorageEventArgs e)
        {
            // Clear JSON-formatted data.In real app, could be deserialized to objects.
            if (!string.IsNullOrEmpty(e.Value) && !string.IsNullOrEmpty(e.Key) && e.Value != "null")
            {
                switch (e.Key)
                {
                    case "name":
                        tbName.Text = e.Value.Replace("\"", "").Replace("\\", "");
                        break;
                    case "email":
                        tbMail.Text = e.Value.Replace("\"", "").Replace("\\", "");
                        break;
                    case "address":
                        tbAddress.Text = e.Value.Replace("\"", "").Replace("\\", "");
                        break;
                    case "phone":
                        tbPhone.Text = e.Value.Replace("\"", "").Replace("\\", "");
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the ClientClick event of the btnStore control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        void btnStore_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            ClientContext context = objArgs.Context;
            context.Invoke("storeLocalStorage", tbName.ID.ToString(), tbMail.ID.ToString(), tbAddress.ID.ToString(), tbPhone.ID.ToString());
        }
    }
}
#region Using

using System;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace CompanionKit.DeviceIntegration.Contacts.Functionality
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Skin(typeof(ContactsListViewSkin))]
    [Serializable()]
    public class ContactsListView : ListView
    {
        public ContactsListView()
        {
            this.CustomStyle = "ContactsListViewSkin";
        }
    }

}

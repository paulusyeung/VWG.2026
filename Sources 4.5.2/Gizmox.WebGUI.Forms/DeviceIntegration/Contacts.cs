#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Contacts;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Device.Common;
using Newtonsoft.Json.Linq;
using Gizmox.WebGUI.Common.Device;

#endregion

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// Represents entity that provides access to the device contacts database.
    /// </summary>
    [Serializable]
    public class Contacts : DeviceComponent, IContacts
    {
        private SingleCallMethodStore<FindContactsEventArgs> mobjFindContactsCallbackStore;
        private SingleCallMethodStore<EmptyDeviceEventArgs> mobjRemoveContactCallbackStore;
        private SingleCallMethodStore<SaveContactEventArgs> mobjSaveContactCallbackStore;

        /// <summary>
        /// Gets the method store for FindContacts() server callbacks.
        /// </summary>
        internal SingleCallMethodStore<FindContactsEventArgs> FindContactsCallbackStore
        {
            get
            {
                if (mobjFindContactsCallbackStore == null)
                {
                    mobjFindContactsCallbackStore = new SingleCallMethodStore<FindContactsEventArgs>();
                }
                return mobjFindContactsCallbackStore;
            }
        }

        /// <summary>
        /// Gets the RemoveContact callback store.
        /// </summary>
        internal SingleCallMethodStore<EmptyDeviceEventArgs> RemoveContactCallbackStore
        {
            get
            {
                mobjRemoveContactCallbackStore = mobjRemoveContactCallbackStore ?? new SingleCallMethodStore<EmptyDeviceEventArgs>();
                return mobjRemoveContactCallbackStore;
            }
        }

        /// <summary>
        /// Gets the SaveContact callback store.
        /// </summary>
        internal SingleCallMethodStore<SaveContactEventArgs> SaveContactCallbackStore
        {
            get
            {
                mobjSaveContactCallbackStore = mobjSaveContactCallbackStore ?? new SingleCallMethodStore<SaveContactEventArgs>();
                return mobjSaveContactCallbackStore;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Contacts"/> class.
        /// </summary>
        /// <param name="objMobileIntegrator">The obj mobile integrator.</param>
        public Contacts(DeviceIntegrator objMobileIntegrator)
            : base(objMobileIntegrator)
        { }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.Contacts;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);
            string strMethodKey = objEvent.Type;
            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(strMethodKey);

            switch (objSplittedValues.Key)
            {
                case "remove":
                    EmptyDeviceEventArgs objRemoveArgs = EmptyDeviceEventArgs.ParseFromVWGEvent(objEvent);
                    if (objRemoveArgs != null)
                    {
                        this.RemoveContactCallbackStore.InvokeContextualMethod(objSplittedValues.Value, objRemoveArgs);
                    }
                    break;
                case "save":
                    SaveContactEventArgs objSaveArgs = SaveContactEventArgs.ParseFromVWGEvent(objEvent);
                    if (objSaveArgs != null)
                    {
                        this.SaveContactCallbackStore.InvokeContextualMethod(objSplittedValues.Value, objSaveArgs);
                    }
                    break;
                case "find":
                    FindContactsEventArgs objFindArgs = GetFindEventArgs(objEvent);
                    if (objFindArgs != null)
                    {
                        this.FindContactsCallbackStore.InvokeContextualMethod(objSplittedValues.Value, objFindArgs);
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets the find eventArgs.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private FindContactsEventArgs GetFindEventArgs(IEvent objEvent)
        {
            // Prepare an arguments object
            FindContactsEventArgs objArguments = null;

            if (!DeviceEventArgs.TryGetError(objEvent, out objArguments))
            {
                // Get contacts number.
                string strContacts = objEvent["contacts"];
                List<IContact> lstContacts = null;

                if (!string.IsNullOrEmpty(strContacts))
                {
                    int intContactsLength;

                    if (int.TryParse(strContacts, out intContactsLength))
                    {
                        string strContact;
                        lstContacts = new List<IContact>();

                        // Parse contacts from JSON
                        for (int i = 0; i < intContactsLength; i++)
                        {
                            Contact objContact = new Contact(this);

                            strContact = objEvent["contact" + i];

                            if (!string.IsNullOrEmpty(strContact))
                            {
                                objContact.ParseFromJson(strContact);
                                lstContacts.Add(objContact);
                            }
                        }
                    }

                    // Create args with contacts list.
                    objArguments = new FindContactsEventArgs(lstContacts);
                }
            }

            return objArguments;
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Contacts_Initialize", ID);
        }

        /// <summary>
        /// Creates the contact on server.
        /// </summary>
        /// <param name="objProperties">The contact properties.</param>
        /// <returns></returns>
        public IContact CreateContact()
        {
            return new Contact(this);
        }

        /// <summary>
        /// Queries the device contacts database and returns an array of Contact objects (server callback).
        /// </summary>
        /// <param name="objMethod">The callback method.</param>
        /// <param name="objOptions">The contact options.</param>
        public void FindContacts(EventHandler<FindContactsEventArgs> objMethod, ContactFindOptions objOptions)
        {
            string strMethodKey = FindContactsCallbackStore.StoreContextualSingleCallMethod(this, "find", objMethod);
            Invoke("DeviceIntegrator.Contacts.findContacts", strMethodKey, CommonUtils.GetClientJsonObject(objOptions));
        }

    }
}

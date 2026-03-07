using System;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Forms.Client;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData
{
    /// <summary>
    /// Represents Device Contact
    /// </summary>
    [Serializable]
    public class Contact : DevicePropertyDictionary, IContact
    {
        #region Members

        private Contacts mobjContacts;

        #endregion Members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="objProperties">The properties.</param>
        internal Contact(Contacts objContacts)
        {
            mobjContacts = objContacts;
        }

        public Contact()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="objBirthday">The birthday.</param>
        /// <param name="strDisplayName">Display name</param>
        /// <param name="objName">Name.</param>
        /// <param name="strNickname">The nickname.</param>
        /// <param name="strNote">The note.</param>
        public Contact(DateTime? objBirthday,
                       string strDisplayName,
                       ContactName objName,
                       string strNickname,
                       string strNote)
        {
            this.Birthday = objBirthday;
            this.DisplayName = strDisplayName;
            this.Name = objName;
            this.Nickname = strNickname;
            this.Note = strNote;
        }

        #endregion C'tors

        #region Methods

        /// <summary>
        /// Gets the contact collection property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strPropertyName">Name of the property.</param>
        /// <returns></returns>
        private IList<T> GetContactsCollectionProperty<T>(string strPropertyName) where T : class
        {
            IList<T> arrPropertyCollection = GetNullableProperty<List<T>>(strPropertyName);
            if (arrPropertyCollection == null)
            {
                arrPropertyCollection = new List<T>();
                SetNullableProperty(strPropertyName, arrPropertyCollection);
            }

            return arrPropertyCollection;
        }

        /// <summary>
        /// Parses the contact from JSON.
        /// </summary>
        /// <param name="strContact">The contact.</param>
        /// <returns></returns>
        public void ParseFromJson(string strContact)
        {
            JObject objJson = JsonUtils.Deserialize(strContact);


            if (objJson != null)
            {
                // ID
                if (objJson.Value<string>("id") != null)
                {
                    this.ID = objJson.Value<uint>("id");
                }

                // DisplayName
                this.DisplayName = objJson.Value<string>("displayName");

                // Note
                this.Note = objJson.Value<string>("note");

                // Nickname
                this.Nickname = objJson.Value<string>("nickname");


                // Birthday
                if (objJson.Value<string>("birthday") != null)
                {
                    if (objJson.Value<DateTime>("birthday") != null)
                    {
                        this.Birthday = objJson.Value<DateTime>("birthday");
                    }

                    else
                    {
                        this.Birthday = JsonUtils.Deserialize<DateTime>(objJson.Value<string>("birthday"));
                    }
                }

                // Name
                this.Name = JsonUtils.Deserialize<ContactName>(objJson["name"].ToString());

                // PhoneNumbers
                ContactField[] arrPhoneNumbers = JsonUtils.Deserialize<ContactField[]>(objJson["phoneNumbers"].ToString());
                if (arrPhoneNumbers != null)
                {
                    this.PhoneNumbers = new List<ContactField>(arrPhoneNumbers);
                }

                // URLs
                ContactField[] arrUrls = JsonUtils.Deserialize<ContactField[]>(objJson["urls"].ToString());
                if (arrUrls != null)
                {
                    this.URLs = new List<ContactField>(arrUrls);
                }

                // Emails
                ContactField[] arrEmails = JsonUtils.Deserialize<ContactField[]>(objJson["emails"].ToString());
                if (arrEmails != null)
                {
                    this.Emails = new List<ContactField>(arrEmails);

                }

                // Addresses
                ContactAddress[] arrAddresses = JsonUtils.Deserialize<ContactAddress[]>(objJson["addresses"].ToString());
                if (arrAddresses != null)
                {
                    this.Addresses = new List<ContactAddress>(arrAddresses);

                }

                // Organizations
                ContactOrganization[] arrOrganizations = JsonUtils.Deserialize<ContactOrganization[]>(objJson["organizations"].ToString());
                if (arrOrganizations != null)
                {
                    this.Organizations = new List<ContactOrganization>(arrOrganizations);
                }

                // IMs
                ContactField[] arrIMs = JsonUtils.Deserialize<ContactField[]>(objJson["ims"].ToString());
                if (arrIMs != null)
                {
                    this.IMs = new List<ContactField>(arrIMs);
                }

                // Categories
                ContactField[] arrCategories = JsonUtils.Deserialize<ContactField[]>(objJson["categories"].ToString());
                if (arrCategories != null)
                {
                    this.Categories = new List<ContactField>(arrCategories);
                }

                // Photos
                ContactField[] arrPhotos = JsonUtils.Deserialize<ContactField[]>(objJson["photos"].ToString());
                if (arrPhotos != null)
                {
                    this.Photos = new List<ContactField>(arrPhotos);
                }
            }
        }

        /// <summary>
        /// Removes the contact from the device contacts database (server callback).
        /// </summary>
        /// <param name="objMethod">The callback method.</param>
        public void Remove(EventHandler<EmptyDeviceEventArgs> objMethod)
        {
            string strMethodKey = mobjContacts.RemoveContactCallbackStore.StoreContextualSingleCallMethod(this, "remove", objMethod);
            mobjContacts.Invoke("DeviceIntegrator.Contacts.removeContact", strMethodKey, CommonUtils.GetClientJsonObject(this));
        }

        /// <summary>
        /// Saves a new contact to the device contacts database with server callback.
        /// </summary>
        /// <param name="objMethod">The callback method.</param>
        public void Save(EventHandler<SaveContactEventArgs> objMethod)
        {
            string strMethodKey = mobjContacts.SaveContactCallbackStore.StoreContextualSingleCallMethod(this, "save", objMethod);
            mobjContacts.Invoke("DeviceIntegrator.Contacts.saveContact", strMethodKey, CommonUtils.GetClientJsonObject(this));
        }

        /// <summary>
        /// Clones this instance on server.
        /// </summary>
        /// <returns>Cloned contact.</returns>
        public IContact Clone()
        {
            return DeepCopy();
        }

        /// <summary>
        /// Creates deep copy of contact.
        /// </summary>
        /// <returns>Deep copy of contact.</returns>
        private IContact DeepCopy()
        {
            Contact objClonedContact = new Contact(this.mobjContacts);
            objClonedContact.Addresses = new List<ContactAddress>(this.Addresses);
            objClonedContact.Emails = new List<ContactField>(this.Emails);
            objClonedContact.Categories = new List<ContactField>(this.Categories);
            objClonedContact.IMs = new List<ContactField>(this.IMs);
            objClonedContact.Organizations = new List<ContactOrganization>(this.Organizations);
            objClonedContact.PhoneNumbers = new List<ContactField>(this.PhoneNumbers);
            objClonedContact.Photos = new List<ContactField>(this.Photos);
            objClonedContact.URLs = new List<ContactField>(this.URLs);
            objClonedContact.Name = new ContactName();
            objClonedContact.Name.Formatted = Name.Formatted;
            objClonedContact.Name.Family = Name.Family;
            objClonedContact.Name.Given = Name.Given;
            objClonedContact.Name.Middle = Name.Middle;
            objClonedContact.Birthday = Birthday;
            objClonedContact.DisplayName = DisplayName;
            objClonedContact.Nickname = Nickname;
            objClonedContact.Note = Note;

            return objClonedContact;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the globally unique identifier.
        /// </summary>
        public uint? ID
        {
            get
            {
                return GetNullableValueTypeProperty<uint>("id");
            }
            set
            {
                AddNullableValueTypeProperty("id", value);
            }
        }

        /// <summary>
        /// Gets or sets the name of this Contact, suitable for display to end-users.
        /// </summary>
        /// <value>
        /// The name of this Contact, suitable for display to end-users.
        /// </value>
        public string DisplayName
        {
            get
            {
                return GetNullableProperty<string>("displayName");
            }
            set
            {
                SetNullableProperty("displayName", value);
            }
        }

        /// <summary>
        /// Gets or sets the object containing all components of a persons name.
        /// </summary>
        /// <value>
        /// The object containing all components of a persons name.
        /// </value>
        public ContactName Name
        {
            get
            {
                return GetNullableProperty<ContactName>("name");
            }
            set
            {
                SetNullableProperty("name", value);
            }
        }

        /// <summary>
        /// Gets or sets the casual name to address the contact by.
        /// </summary>
        /// <value>
        /// The casual name to address the contact by.
        /// </value>
        public string Nickname
        {
            get
            {
                return GetNullableProperty<string>("nickname");
            }
            set
            {
                SetNullableProperty("nickname", value);
            }
        }

        /// <summary>
        /// Gets or sets the array of all the contact's phone numbers.
        /// </summary>        
        public IList<ContactField> PhoneNumbers
        {
            get
            {
                return GetContactsCollectionProperty<ContactField>("phoneNumbers");
            }

            internal set
            {
                SetNullableProperty("phoneNumbers", value);
            }
        }

        /// <summary>
        /// Gets the array of all the contact's email addresses.
        /// </summary>
        public IList<ContactField> Emails
        {
            get
            {
                return GetContactsCollectionProperty<ContactField>("emails");
            }
            internal set
            {
                SetNullableProperty("emails", value);
            }
        }

        /// <summary>
        /// Gets or sets the array of all the contact's addresses
        /// </summary>
        public IList<ContactAddress> Addresses
        {
            get
            {
                return GetContactsCollectionProperty<ContactAddress>("addresses");
            }
            internal set
            {
                SetNullableProperty("addresses", value);
            }
        }

        /// <summary>
        /// Gets or sets the array of all the contact's IM addresses.
        /// </summary>        
        public IEnumerable<ContactField> IMs
        {
            get
            {
                // return GetContactsCollectionProperty<ContactField>("ims");
                IList<ContactField> arrPropertyCollection = GetNullableProperty<List<ContactField>>("ims");
                if (arrPropertyCollection == null)
                {
                    arrPropertyCollection = new List<ContactField>();
                    SetNullableProperty("ims", arrPropertyCollection);
                }

                return arrPropertyCollection as IEnumerable<ContactField>;
            }

            internal set
            {
                SetNullableProperty("ims", value);
            }
        }

        /// <summary>
        /// Gets the array of all the contact's organizations.
        /// </summary>
        public IList<ContactOrganization> Organizations
        {
            get
            {
                return GetContactsCollectionProperty<ContactOrganization>("organizations");
            }

            internal set
            {
                SetNullableProperty("organizations", value);
            }
        }

        /// <summary>
        /// Gets or sets the birthday of the contact.
        /// </summary>
        /// <value>
        /// The birthday of the contact.
        /// </value>
        public DateTime? Birthday
        {
            get
            {
                return GetNullableValueTypeProperty<DateTime>("birthday");
            }
            set
            {
                AddNullableValueTypeProperty<DateTime>("birthday", value);
            }
        }

        /// <summary>
        /// Gets or sets the note about the contact.
        /// </summary>
        /// <value>
        /// The note about the contact.
        /// </value>
        public string Note
        {
            get
            {
                return GetNullableProperty<string>("note");
            }
            set
            {
                SetNullableProperty("note", value);
            }
        }

        /// <summary>
        /// Gets array of the contact's photos.
        /// </summary>
        public IList<ContactField> Photos
        {
            get
            {
                return GetContactsCollectionProperty<ContactField>("photos");
            }

            internal set
            {
                SetNullableProperty("photos", value);
            }
        }

        /// <summary>
        /// Gets the array of all the contacts user defined categories.
        /// </summary>
        public IList<ContactField> Categories
        {
            get
            {
                return GetContactsCollectionProperty<ContactField>("categories");
            }

            internal set
            {
                SetNullableProperty("categories", value);
            }
        }

        /// <summary>
        /// Gets array of web pages associated to the contact.
        /// </summary>
        public IList<ContactField> URLs
        {
            get
            {
                return GetContactsCollectionProperty<ContactField>("urls");
            }

            internal set
            {
                SetNullableProperty("urls", value);
            }
        }

        #endregion Properties
    }
}

// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData.Contact
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData
{
  /// <summary>Represents Device Contact</summary>
  [Serializable]
  public class Contact : DevicePropertyDictionary, IContact
  {
    private Gizmox.WebGUI.Forms.DeviceIntegration.Contacts mobjContacts;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData.Contact" /> class.
    /// </summary>
    /// <param name="objProperties">The properties.</param>
    internal Contact(Gizmox.WebGUI.Forms.DeviceIntegration.Contacts objContacts) => this.mobjContacts = objContacts;

    public Contact()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData.Contact" /> class.
    /// </summary>
    /// <param name="objBirthday">The birthday.</param>
    /// <param name="strDisplayName">Display name</param>
    /// <param name="objName">Name.</param>
    /// <param name="strNickname">The nickname.</param>
    /// <param name="strNote">The note.</param>
    public Contact(
      DateTime? objBirthday,
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

    /// <summary>Gets the contact collection property.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="strPropertyName">Name of the property.</param>
    /// <returns></returns>
    private IList<T> GetContactsCollectionProperty<T>(string strPropertyName) where T : class
    {
      IList<T> objProperty = (IList<T>) this.GetNullableProperty<List<T>>(strPropertyName);
      if (objProperty == null)
      {
        objProperty = (IList<T>) new List<T>();
        this.SetNullableProperty<IList<T>>(strPropertyName, objProperty);
      }
      return objProperty;
    }

    /// <summary>Parses the contact from JSON.</summary>
    /// <param name="strContact">The contact.</param>
    /// <returns></returns>
    public void ParseFromJson(string strContact)
    {
      JObject jobject = JsonUtils.Deserialize(strContact);
      if (jobject == null)
        return;
      if (jobject.Value<string>((object) "id") != null)
        this.ID = new uint?(jobject.Value<uint>((object) "id"));
      this.DisplayName = jobject.Value<string>((object) "displayName");
      this.Note = jobject.Value<string>((object) "note");
      this.Nickname = jobject.Value<string>((object) "nickname");
      if (jobject.Value<string>((object) "birthday") != null)
      {
        jobject.Value<DateTime>((object) "birthday");
        this.Birthday = new DateTime?(jobject.Value<DateTime>((object) "birthday"));
      }
      this.Name = JsonUtils.Deserialize<ContactName>(jobject["name"].ToString());
      ContactField[] collection1 = JsonUtils.Deserialize<ContactField[]>(jobject["phoneNumbers"].ToString());
      if (collection1 != null)
        this.PhoneNumbers = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) collection1);
      ContactField[] collection2 = JsonUtils.Deserialize<ContactField[]>(jobject["urls"].ToString());
      if (collection2 != null)
        this.URLs = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) collection2);
      ContactField[] collection3 = JsonUtils.Deserialize<ContactField[]>(jobject["emails"].ToString());
      if (collection3 != null)
        this.Emails = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) collection3);
      ContactAddress[] collection4 = JsonUtils.Deserialize<ContactAddress[]>(jobject["addresses"].ToString());
      if (collection4 != null)
        this.Addresses = (IList<ContactAddress>) new List<ContactAddress>((IEnumerable<ContactAddress>) collection4);
      ContactOrganization[] collection5 = JsonUtils.Deserialize<ContactOrganization[]>(jobject["organizations"].ToString());
      if (collection5 != null)
        this.Organizations = (IList<ContactOrganization>) new List<ContactOrganization>((IEnumerable<ContactOrganization>) collection5);
      ContactField[] collection6 = JsonUtils.Deserialize<ContactField[]>(jobject["ims"].ToString());
      if (collection6 != null)
        this.IMs = (IEnumerable<ContactField>) new List<ContactField>((IEnumerable<ContactField>) collection6);
      ContactField[] collection7 = JsonUtils.Deserialize<ContactField[]>(jobject["categories"].ToString());
      if (collection7 != null)
        this.Categories = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) collection7);
      ContactField[] collection8 = JsonUtils.Deserialize<ContactField[]>(jobject["photos"].ToString());
      if (collection8 == null)
        return;
      this.Photos = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) collection8);
    }

    /// <summary>
    /// Removes the contact from the device contacts database (server callback).
    /// </summary>
    /// <param name="objMethod">The callback method.</param>
    public void Remove(EventHandler<EmptyDeviceEventArgs> objMethod) => this.mobjContacts.Invoke("DeviceIntegrator.Contacts.removeContact", (object) this.mobjContacts.RemoveContactCallbackStore.StoreContextualSingleCallMethod((object) this, "remove", objMethod), (object) CommonUtils.GetClientJsonObject((object) this));

    /// <summary>
    /// Saves a new contact to the device contacts database with server callback.
    /// </summary>
    /// <param name="objMethod">The callback method.</param>
    public void Save(EventHandler<SaveContactEventArgs> objMethod) => this.mobjContacts.Invoke("DeviceIntegrator.Contacts.saveContact", (object) this.mobjContacts.SaveContactCallbackStore.StoreContextualSingleCallMethod((object) this, "save", objMethod), (object) CommonUtils.GetClientJsonObject((object) this));

    /// <summary>Clones this instance on server.</summary>
    /// <returns>Cloned contact.</returns>
    public IContact Clone() => this.DeepCopy();

    /// <summary>Creates deep copy of contact.</summary>
    /// <returns>Deep copy of contact.</returns>
    private IContact DeepCopy()
    {
      Contact contact = new Contact(this.mobjContacts)
      {
        Addresses = (IList<ContactAddress>) new List<ContactAddress>((IEnumerable<ContactAddress>) this.Addresses),
        Emails = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) this.Emails),
        Categories = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) this.Categories),
        IMs = (IEnumerable<ContactField>) new List<ContactField>(this.IMs),
        Organizations = (IList<ContactOrganization>) new List<ContactOrganization>((IEnumerable<ContactOrganization>) this.Organizations),
        PhoneNumbers = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) this.PhoneNumbers),
        Photos = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) this.Photos),
        URLs = (IList<ContactField>) new List<ContactField>((IEnumerable<ContactField>) this.URLs),
        Name = new ContactName()
      };
      contact.Name.Formatted = this.Name.Formatted;
      contact.Name.Family = this.Name.Family;
      contact.Name.Given = this.Name.Given;
      contact.Name.Middle = this.Name.Middle;
      contact.Birthday = this.Birthday;
      contact.DisplayName = this.DisplayName;
      contact.Nickname = this.Nickname;
      contact.Note = this.Note;
      return (IContact) contact;
    }

    /// <summary>Gets the globally unique identifier.</summary>
    public uint? ID
    {
      get => this.GetNullableValueTypeProperty<uint>("id");
      set => this.AddNullableValueTypeProperty<uint>("id", value);
    }

    /// <summary>
    /// Gets or sets the name of this Contact, suitable for display to end-users.
    /// </summary>
    /// <value>
    /// The name of this Contact, suitable for display to end-users.
    /// </value>
    public string DisplayName
    {
      get => this.GetNullableProperty<string>("displayName");
      set => this.SetNullableProperty<string>("displayName", value);
    }

    /// <summary>
    /// Gets or sets the object containing all components of a persons name.
    /// </summary>
    /// <value>The object containing all components of a persons name.</value>
    public ContactName Name
    {
      get => this.GetNullableProperty<ContactName>("name");
      set => this.SetNullableProperty<ContactName>("name", value);
    }

    /// <summary>
    /// Gets or sets the casual name to address the contact by.
    /// </summary>
    /// <value>The casual name to address the contact by.</value>
    public string Nickname
    {
      get => this.GetNullableProperty<string>("nickname");
      set => this.SetNullableProperty<string>("nickname", value);
    }

    /// <summary>
    /// Gets or sets the array of all the contact's phone numbers.
    /// </summary>
    public IList<ContactField> PhoneNumbers
    {
      get => this.GetContactsCollectionProperty<ContactField>("phoneNumbers");
      internal set => this.SetNullableProperty<IList<ContactField>>("phoneNumbers", value);
    }

    /// <summary>Gets the array of all the contact's email addresses.</summary>
    public IList<ContactField> Emails
    {
      get => this.GetContactsCollectionProperty<ContactField>("emails");
      internal set => this.SetNullableProperty<IList<ContactField>>("emails", value);
    }

    /// <summary>Gets or sets the array of all the contact's addresses</summary>
    public IList<ContactAddress> Addresses
    {
      get => this.GetContactsCollectionProperty<ContactAddress>("addresses");
      internal set => this.SetNullableProperty<IList<ContactAddress>>("addresses", value);
    }

    /// <summary>
    /// Gets or sets the array of all the contact's IM addresses.
    /// </summary>
    public IEnumerable<ContactField> IMs
    {
      get
      {
        IList<ContactField> objProperty = (IList<ContactField>) this.GetNullableProperty<List<ContactField>>("ims");
        if (objProperty == null)
        {
          objProperty = (IList<ContactField>) new List<ContactField>();
          this.SetNullableProperty<IList<ContactField>>("ims", objProperty);
        }
        return (IEnumerable<ContactField>) objProperty;
      }
      internal set => this.SetNullableProperty<IEnumerable<ContactField>>("ims", value);
    }

    /// <summary>Gets the array of all the contact's organizations.</summary>
    public IList<ContactOrganization> Organizations
    {
      get => this.GetContactsCollectionProperty<ContactOrganization>("organizations");
      internal set => this.SetNullableProperty<IList<ContactOrganization>>("organizations", value);
    }

    /// <summary>Gets or sets the birthday of the contact.</summary>
    /// <value>The birthday of the contact.</value>
    public DateTime? Birthday
    {
      get => this.GetNullableValueTypeProperty<DateTime>("birthday");
      set => this.AddNullableValueTypeProperty<DateTime>("birthday", value);
    }

    /// <summary>Gets or sets the note about the contact.</summary>
    /// <value>The note about the contact.</value>
    public string Note
    {
      get => this.GetNullableProperty<string>("note");
      set => this.SetNullableProperty<string>("note", value);
    }

    /// <summary>Gets array of the contact's photos.</summary>
    public IList<ContactField> Photos
    {
      get => this.GetContactsCollectionProperty<ContactField>("photos");
      internal set => this.SetNullableProperty<IList<ContactField>>("photos", value);
    }

    /// <summary>
    /// Gets the array of all the contacts user defined categories.
    /// </summary>
    public IList<ContactField> Categories
    {
      get => this.GetContactsCollectionProperty<ContactField>("categories");
      internal set => this.SetNullableProperty<IList<ContactField>>("categories", value);
    }

    /// <summary>Gets array of web pages associated to the contact.</summary>
    public IList<ContactField> URLs
    {
      get => this.GetContactsCollectionProperty<ContactField>("urls");
      internal set => this.SetNullableProperty<IList<ContactField>>("urls", value);
    }
  }
}

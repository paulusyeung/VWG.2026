#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData
{
	/// 
	/// Represents Device Contact
	/// </summary>
	[Serializable]
	public class Contact : DevicePropertyDictionary, IContact
	{
		private Contacts mobjContacts;

		/// 
		/// Gets the globally unique identifier.
		/// </summary>
		public uint? ID
		{
			get
			{
				return GetNullableValueTypeProperty("id");
			}
			set
			{
				AddNullableValueTypeProperty("id", value);
			}
		}

		/// 
		/// Gets or sets the name of this Contact, suitable for display to end-users.
		/// </summary>
		/// 
		/// The name of this Contact, suitable for display to end-users.
		/// </value>
		public string DisplayName
		{
			get
			{
				return GetNullableProperty("displayName");
			}
			set
			{
				SetNullableProperty("displayName", value);
			}
		}

		/// 
		/// Gets or sets the object containing all components of a persons name.
		/// </summary>
		/// 
		/// The object containing all components of a persons name.
		/// </value>
		public ContactName Name
		{
			get
			{
				return GetNullableProperty("name");
			}
			set
			{
				SetNullableProperty("name", value);
			}
		}

		/// 
		/// Gets or sets the casual name to address the contact by.
		/// </summary>
		/// 
		/// The casual name to address the contact by.
		/// </value>
		public string Nickname
		{
			get
			{
				return GetNullableProperty("nickname");
			}
			set
			{
				SetNullableProperty("nickname", value);
			}
		}

		/// 
		/// Gets or sets the array of all the contact's phone numbers.
		/// </summary>        
		public IList PhoneNumbers
		{
			get
			{
				return GetContactsCollectionProperty("phoneNumbers");
			}
			internal set
			{
				SetNullableProperty("phoneNumbers", value);
			}
		}

		/// 
		/// Gets the array of all the contact's email addresses.
		/// </summary>
		public IList Emails
		{
			get
			{
				return GetContactsCollectionProperty("emails");
			}
			internal set
			{
				SetNullableProperty("emails", value);
			}
		}

		/// 
		/// Gets or sets the array of all the contact's addresses
		/// </summary>
		public IList Addresses
		{
			get
			{
				return GetContactsCollectionProperty("addresses");
			}
			internal set
			{
				SetNullableProperty("addresses", value);
			}
		}

		/// 
		/// Gets or sets the array of all the contact's IM addresses.
		/// </summary>        
		public IEnumerable IMs
		{
			get
			{
				IList list = GetNullableProperty<List>("ims");
				if (list == null)
				{
					list = new List<object>();
					SetNullableProperty("ims", list);
				}
				return list;
			}
			internal set
			{
				SetNullableProperty("ims", value);
			}
		}

		/// 
		/// Gets the array of all the contact's organizations.
		/// </summary>
		public IList Organizations
		{
			get
			{
				return GetContactsCollectionProperty("organizations");
			}
			internal set
			{
				SetNullableProperty("organizations", value);
			}
		}

		/// 
		/// Gets or sets the birthday of the contact.
		/// </summary>
		/// 
		/// The birthday of the contact.
		/// </value>
		public DateTime? Birthday
		{
			get
			{
				return GetNullableValueTypeProperty("birthday");
			}
			set
			{
				AddNullableValueTypeProperty("birthday", value);
			}
		}

		/// 
		/// Gets or sets the note about the contact.
		/// </summary>
		/// 
		/// The note about the contact.
		/// </value>
		public string Note
		{
			get
			{
				return GetNullableProperty("note");
			}
			set
			{
				SetNullableProperty("note", value);
			}
		}

		/// 
		/// Gets array of the contact's photos.
		/// </summary>
		public IList Photos
		{
			get
			{
				return GetContactsCollectionProperty("photos");
			}
			internal set
			{
				SetNullableProperty("photos", value);
			}
		}

		/// 
		/// Gets the array of all the contacts user defined categories.
		/// </summary>
		public IList Categories
		{
			get
			{
				return GetContactsCollectionProperty("categories");
			}
			internal set
			{
				SetNullableProperty("categories", value);
			}
		}

		/// 
		/// Gets array of web pages associated to the contact.
		/// </summary>
		public IList URLs
		{
			get
			{
				return GetContactsCollectionProperty("urls");
			}
			internal set
			{
				SetNullableProperty("urls", value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData.Contact" /> class.
		/// </summary>
		/// <param name="objProperties">The properties.</param>
		internal Contact(Contacts objContacts)
		{
			mobjContacts = objContacts;
		}

		public Contact()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData.Contact" /> class.
		/// </summary>
		/// <param name="objBirthday">The birthday.</param>
		/// <param name="strDisplayName">Display name</param>
		/// <param name="objName">Name.</param>
		/// <param name="strNickname">The nickname.</param>
		/// <param name="strNote">The note.</param>
		public Contact(DateTime? objBirthday, string strDisplayName, ContactName objName, string strNickname, string strNote)
		{
			Birthday = objBirthday;
			DisplayName = strDisplayName;
			Name = objName;
			Nickname = strNickname;
			Note = strNote;
		}

		/// 
		/// Gets the contact collection property.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="strPropertyName">Name of the property.</param>
		/// </returns>
		private IList GetContactsCollectionProperty(string strPropertyName) where T : class
		{
			IList list = GetNullableProperty<List>(strPropertyName);
			if (list == null)
			{
				list = new List<object>();
				SetNullableProperty(strPropertyName, list);
			}
			return list;
		}

		/// 
		/// Parses the contact from JSON.
		/// </summary>
		/// <param name="strContact">The contact.</param>
		/// </returns>
		public void ParseFromJson(string strContact)
		{
			JObject jObject = JsonUtils.Deserialize(strContact);
			if (jObject == null)
			{
				return;
			}
			if (jObject.Value("id") != null)
			{
				ID = jObject.Value("id");
			}
			DisplayName = jObject.Value("displayName");
			Note = jObject.Value("note");
			Nickname = jObject.Value("nickname");
			if (jObject.Value("birthday") != null)
			{
				jObject.Value("birthday");
				if (true)
				{
					Birthday = jObject.Value("birthday");
				}
				else
				{
					Birthday = JsonUtils.Deserialize(jObject.Value("birthday"));
				}
			}
			Name = JsonUtils.Deserialize(jObject["name"].ToString());
			ContactField[] array = JsonUtils.Deserialize<ContactField[]>(jObject["phoneNumbers"].ToString());
			if (array != null)
			{
				PhoneNumbers = new List(array);
			}
			ContactField[] array2 = JsonUtils.Deserialize<ContactField[]>(jObject["urls"].ToString());
			if (array2 != null)
			{
				URLs = new List(array2);
			}
			ContactField[] array3 = JsonUtils.Deserialize<ContactField[]>(jObject["emails"].ToString());
			if (array3 != null)
			{
				Emails = new List(array3);
			}
			ContactAddress[] array4 = JsonUtils.Deserialize<ContactAddress[]>(jObject["addresses"].ToString());
			if (array4 != null)
			{
				Addresses = new List(array4);
			}
			ContactOrganization[] array5 = JsonUtils.Deserialize<ContactOrganization[]>(jObject["organizations"].ToString());
			if (array5 != null)
			{
				Organizations = new List(array5);
			}
			ContactField[] array6 = JsonUtils.Deserialize<ContactField[]>(jObject["ims"].ToString());
			if (array6 != null)
			{
				IMs = new List(array6);
			}
			ContactField[] array7 = JsonUtils.Deserialize<ContactField[]>(jObject["categories"].ToString());
			if (array7 != null)
			{
				Categories = new List(array7);
			}
			ContactField[] array8 = JsonUtils.Deserialize<ContactField[]>(jObject["photos"].ToString());
			if (array8 != null)
			{
				Photos = new List(array8);
			}
		}

		/// 
		/// Removes the contact from the device contacts database (server callback).
		/// </summary>
		/// <param name="objMethod">The callback method.</param>
		public void Remove(EventHandler objMethod)
		{
			string text = mobjContacts.RemoveContactCallbackStore.StoreContextualSingleCallMethod(this, "remove", objMethod);
			mobjContacts.Invoke("DeviceIntegrator.Contacts.removeContact", text, CommonUtils.GetClientJsonObject(this));
		}

		/// 
		/// Saves a new contact to the device contacts database with server callback.
		/// </summary>
		/// <param name="objMethod">The callback method.</param>
		public void Save(EventHandler objMethod)
		{
			string text = mobjContacts.SaveContactCallbackStore.StoreContextualSingleCallMethod(this, "save", objMethod);
			mobjContacts.Invoke("DeviceIntegrator.Contacts.saveContact", text, CommonUtils.GetClientJsonObject(this));
		}

		/// 
		/// Clones this instance on server.
		/// </summary>
		/// Cloned contact.</returns>
		public IContact Clone()
		{
			return DeepCopy();
		}

		/// 
		/// Creates deep copy of contact.
		/// </summary>
		/// Deep copy of contact.</returns>
		private IContact DeepCopy()
		{
			Contact contact = new Contact(mobjContacts);
			contact.Addresses = new List(Addresses);
			contact.Emails = new List(Emails);
			contact.Categories = new List(Categories);
			contact.IMs = new List(IMs);
			contact.Organizations = new List(Organizations);
			contact.PhoneNumbers = new List(PhoneNumbers);
			contact.Photos = new List(Photos);
			contact.URLs = new List(URLs);
			contact.Name = new ContactName();
			contact.Name.Formatted = Name.Formatted;
			contact.Name.Family = Name.Family;
			contact.Name.Given = Name.Given;
			contact.Name.Middle = Name.Middle;
			contact.Birthday = Birthday;
			contact.DisplayName = DisplayName;
			contact.Nickname = Nickname;
			contact.Note = Note;
			return contact;
		}
	}
}

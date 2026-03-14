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

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
/// 
	/// Represents entity that provides access to the device contacts database.
	/// </summary>
	[Serializable]
	public class Contacts : DeviceComponent, IContacts
	{
		private SingleCallMethodStore<FindContactsEventArgs> mobjFindContactsCallbackStore;

		private SingleCallMethodStore<EmptyDeviceEventArgs> mobjRemoveContactCallbackStore;

		private SingleCallMethodStore<SaveContactEventArgs> mobjSaveContactCallbackStore;

		/// 
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

		/// 
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

		/// 
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

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Contacts" /> class.
		/// </summary>
		/// <param name="objMobileIntegrator">The obj mobile integrator.</param>
		public Contacts(DeviceIntegrator objMobileIntegrator)
			: base(objMobileIntegrator)
		{
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "CON";
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(type);
			switch (keyValuePair.Key)
			{
			case "remove":
			{
				EmptyDeviceEventArgs e = EmptyDeviceEventArgs.ParseFromVWGEvent(objEvent);
				if (e != null)
				{
					RemoveContactCallbackStore.InvokeContextualMethod(keyValuePair.Value, e);
				}
				break;
			}
			case "save":
			{
				SaveContactEventArgs e2 = SaveContactEventArgs.ParseFromVWGEvent(objEvent);
				if (e2 != null)
				{
					SaveContactCallbackStore.InvokeContextualMethod(keyValuePair.Value, e2);
				}
				break;
			}
			case "find":
			{
				FindContactsEventArgs findEventArgs = GetFindEventArgs(objEvent);
				if (findEventArgs != null)
				{
					FindContactsCallbackStore.InvokeContextualMethod(keyValuePair.Value, findEventArgs);
				}
				break;
			}
			}
		}

		/// 
		/// Gets the find eventArgs.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private FindContactsEventArgs GetFindEventArgs(IEvent objEvent)
		{
			FindContactsEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs))
			{
				string text = objEvent["contacts"];
				List list = null;
				if (!string.IsNullOrEmpty(text))
				{
					if (int.TryParse(text, out var result))
					{
						list = new List<object>();
						for (int i = 0; i < result; i++)
						{
							Contact contact = new Contact(this);
							string text2 = objEvent["contact" + i];
							if (!string.IsNullOrEmpty(text2))
							{
								contact.ParseFromJson(text2);
								list.Add(contact);
							}
						}
					}
					objEventArgs = new FindContactsEventArgs(list);
				}
			}
			return objEventArgs;
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Contacts_Initialize", ID);
		}

		/// 
		/// Creates the contact on server.
		/// </summary>
		/// <param name="objProperties">The contact properties.</param>
		/// </returns>
		public IContact CreateContact()
		{
			return new Contact(this);
		}

		/// 
		/// Queries the device contacts database and returns an array of Contact objects (server callback).
		/// </summary>
		/// <param name="objMethod">The callback method.</param>
		/// <param name="objOptions">The contact options.</param>
		public void FindContacts(EventHandler<FindContactsEventArgs> objMethod, ContactFindOptions objOptions)
		{
			string text = FindContactsCallbackStore.StoreContextualSingleCallMethod(this, "find", objMethod);
			Invoke("DeviceIntegrator.Contacts.findContacts", text, CommonUtils.GetClientJsonObject(objOptions));
		}
	}
}

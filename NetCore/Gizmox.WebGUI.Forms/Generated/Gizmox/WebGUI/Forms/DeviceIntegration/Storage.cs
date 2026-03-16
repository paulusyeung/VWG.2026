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
[Serializable]
	public class Storage : DeviceComponent, IStorage
	{
		private LocalStorage mobjLocalStorage;

		private SingleCallMethodStore<LocalStorageEventArgs> mobjClearLocalStorageMethods;

		private SingleCallMethodStore<LocalStorageEventArgs> mobjGetLocalStorageItemMethods;

		private SingleCallMethodStore<LocalStorageEventArgs> mobjSetLocalStorageItemMethods;

		private SingleCallMethodStore<LocalStorageEventArgs> mobjRemoveLocalStorageItemMethods;

		private SingleCallMethodStore<LocalStorageEventArgs> mobjGetLocalStorageKeyMethods;

		private SingleCallMethodStore<SQLResultEventArgs> mobjExecuteSQLMethods;

		private SingleCallMethodStore<TransactionEventArgs> mobjTransactionCallbackMethods;

		/// 
		/// Gets the transaction callback methods.
		/// </summary>
		internal SingleCallMethodStore<TransactionEventArgs> TransactionCallbackMethods
		{
			get
			{
				if (mobjTransactionCallbackMethods == null)
				{
					mobjTransactionCallbackMethods = new SingleCallMethodStore<TransactionEventArgs>();
				}
				return mobjTransactionCallbackMethods;
			}
		}

		/// 
		/// Gets the execute SQL methods store.
		/// </summary>
		internal SingleCallMethodStore<SQLResultEventArgs> ExecuteSQLMethods
		{
			get
			{
				if (mobjExecuteSQLMethods == null)
				{
					mobjExecuteSQLMethods = new SingleCallMethodStore<SQLResultEventArgs>();
				}
				return mobjExecuteSQLMethods;
			}
		}

		/// 
		/// Gets the clear local storage methods.
		/// </summary>
		internal SingleCallMethodStore<LocalStorageEventArgs> ClearLocalStorageMethods
		{
			get
			{
				if (mobjClearLocalStorageMethods == null)
				{
					mobjClearLocalStorageMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
				}
				return mobjClearLocalStorageMethods;
			}
		}

		/// 
		/// Gets the set local storage item methods store.
		/// </summary>
		internal SingleCallMethodStore<LocalStorageEventArgs> SetLocalStorageItemMethods
		{
			get
			{
				if (mobjSetLocalStorageItemMethods == null)
				{
					mobjSetLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
				}
				return mobjSetLocalStorageItemMethods;
			}
		}

		/// 
		/// Gets the get local storage item methods store.
		/// </summary>
		internal SingleCallMethodStore<LocalStorageEventArgs> GetLocalStorageItemMethods
		{
			get
			{
				if (mobjGetLocalStorageItemMethods == null)
				{
					mobjGetLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
				}
				return mobjGetLocalStorageItemMethods;
			}
		}

		/// 
		/// Gets the get local storage key methods store.
		/// </summary>
		internal SingleCallMethodStore<LocalStorageEventArgs> GetLocalStorageKeyMethods
		{
			get
			{
				if (mobjGetLocalStorageKeyMethods == null)
				{
					mobjGetLocalStorageKeyMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
				}
				return mobjGetLocalStorageKeyMethods;
			}
		}

		/// 
		/// Gets the remove local storage item methods store.
		/// </summary>
		internal SingleCallMethodStore<LocalStorageEventArgs> RemoveLocalStorageItemMethods
		{
			get
			{
				if (mobjRemoveLocalStorageItemMethods == null)
				{
					mobjRemoveLocalStorageItemMethods = new SingleCallMethodStore<LocalStorageEventArgs>();
				}
				return mobjRemoveLocalStorageItemMethods;
			}
		}

		/// 
		/// Gets the local storage.
		/// </summary>
		public ILocalStorage LocalStorage
		{
			get
			{
				if (mobjLocalStorage == null)
				{
					mobjLocalStorage = new LocalStorage(this);
				}
				return mobjLocalStorage;
			}
		}

		public Storage(DeviceIntegrator objPhonegapIntegrator)
			: base(objPhonegapIntegrator)
		{
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Storage_Initialize", ID);
		}

		/// 
		/// Opens the database (server).
		/// </summary>
		/// <param name="objOptions">The database options.</param>
		/// 
		/// The database instance.
		/// </returns>
		public IDatabase OpenDatabase(DatabaseOptions objOptions)
		{
			return new Database(objOptions, this);
		}

		protected internal override string GetTag()
		{
			return "SQL";
		}

		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(type);
			switch (keyValuePair.Key)
			{
			case "clearLocalStorage":
				ClearLocalStorageMethods.InvokeContextualMethod(keyValuePair.Value, new LocalStorageEventArgs());
				break;
			case "getItem":
			{
				LocalStorageEventArgs localStorageArgsFromEvent = GetLocalStorageArgsFromEvent(objEvent);
				if (localStorageArgsFromEvent != null)
				{
					GetLocalStorageItemMethods.InvokeContextualMethod(keyValuePair.Value, localStorageArgsFromEvent);
				}
				break;
			}
			case "setItem":
			{
				LocalStorageEventArgs localStorageArgsFromEvent2 = GetLocalStorageArgsFromEvent(objEvent);
				if (localStorageArgsFromEvent2 != null)
				{
					SetLocalStorageItemMethods.InvokeContextualMethod(keyValuePair.Value, localStorageArgsFromEvent2);
				}
				break;
			}
			case "removeItem":
			{
				LocalStorageEventArgs localStorageArgsFromEvent4 = GetLocalStorageArgsFromEvent(objEvent);
				if (localStorageArgsFromEvent4 != null)
				{
					RemoveLocalStorageItemMethods.InvokeContextualMethod(keyValuePair.Value, localStorageArgsFromEvent4);
				}
				break;
			}
			case "key":
			{
				LocalStorageEventArgs localStorageArgsFromEvent3 = GetLocalStorageArgsFromEvent(objEvent);
				if (localStorageArgsFromEvent3 != null)
				{
					GetLocalStorageKeyMethods.InvokeContextualMethod(keyValuePair.Value, localStorageArgsFromEvent3);
				}
				break;
			}
			case "executeSQL":
			{
				SQLResultEventArgs sQLResultEventArgsFromEvent = GetSQLResultEventArgsFromEvent(objEvent);
				if (sQLResultEventArgsFromEvent != null)
				{
					ExecuteSQLMethods.InvokeContextualMethod(keyValuePair.Value, sQLResultEventArgsFromEvent);
				}
				break;
			}
			case "transaction":
			{
				TransactionEventArgs transactionEventArgsFromEvent = GetTransactionEventArgsFromEvent(objEvent);
				if (transactionEventArgsFromEvent != null)
				{
					TransactionCallbackMethods.InvokeContextualMethod(keyValuePair.Value, transactionEventArgsFromEvent);
				}
				break;
			}
			}
		}

		/// 
		/// Gets the transaction event args from event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private TransactionEventArgs GetTransactionEventArgsFromEvent(IEvent objEvent)
		{
			TransactionEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError<TransactionEventArgs>(objEvent, out objEventArgs))
			{
				objEventArgs = new TransactionEventArgs();
			}
			return objEventArgs;
		}

		/// 
		/// Gets the transaction event args from event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private SQLResultEventArgs GetSQLResultEventArgsFromEvent(IEvent objEvent)
		{
			SQLResultEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError<SQLResultEventArgs>(objEvent, out objEventArgs))
			{
				SQLResultSet sQLResultSet = new SQLResultSet();
				if (!string.IsNullOrEmpty(objEvent["rows"]))
				{
					int num = JsonUtils.Deserialize<int>(objEvent["rows"]);
					List<Dictionary<string, string>> list = null;
					if (num > 0)
					{
						list = new List<Dictionary<string, string>>();
						for (int i = 0; i < num; i++)
						{
							if (!string.IsNullOrEmpty(objEvent["row" + i]))
							{
								Dictionary<string, string> dictionary = ParseRowFromJSON(objEvent["row" + i]);
								if (dictionary != null)
								{
									list.Add(dictionary);
								}
							}
						}
						sQLResultSet.Rows = list;
					}
				}
				if (!string.IsNullOrEmpty(objEvent["insertId"]) && uint.TryParse(objEvent["insertId"], out var result))
				{
					sQLResultSet.InsertID = result;
				}
				if (!string.IsNullOrEmpty(objEvent["rowsAffected"]) && uint.TryParse(objEvent["rowsAffected"], out var result2))
				{
					sQLResultSet.RowsAffected = result2;
				}
				objEventArgs = new SQLResultEventArgs(sQLResultSet);
				if (!string.IsNullOrEmpty(objEvent["command"]))
				{
					objEventArgs.Command = objEvent["command"];
				}
			}
			return objEventArgs;
		}

		/// 
		/// Parses the rows from JSON.
		/// </summary>
		/// <param name="strRowData">The STR rows.</param>
		/// </returns>
		private Dictionary<string, string> ParseRowFromJSON(string strRowData)
		{
			return JsonUtils.Deserialize<Dictionary<string, string>>(strRowData);
		}

		/// 
		/// Gets the local storage args from event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private LocalStorageEventArgs GetLocalStorageArgsFromEvent(IEvent objEvent)
		{
			LocalStorageEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError<LocalStorageEventArgs>(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["localStorageArgs"]))
			{
				JObject jObject = JsonUtils.Deserialize<JObject>(objEvent["localStorageArgs"]);
				string strKey = jObject.Value<string>("key");
				string strValue = jObject.Value<string>("item");
				objEventArgs = new LocalStorageEventArgs(strKey, strValue);
			}
			return objEventArgs;
		}
	}
}

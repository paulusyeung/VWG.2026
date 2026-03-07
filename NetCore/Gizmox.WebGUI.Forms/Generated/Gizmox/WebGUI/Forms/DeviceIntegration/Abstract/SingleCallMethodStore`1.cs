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

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
	/// 
	/// Represents store for device component single-call methods.
	/// </summary>
	/// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
	[Serializable]
	internal class SingleCallMethodStore<TEventArgsType> where TEventArgsType : EventArgs
	{
		/// 
		///
		/// </summary>
		/// <typeparam name="TEventArgsType">The type of the event args type.</typeparam>
		private class ContextualData<TEventArgsType> where TEventArgsType : EventArgs
		{
			private object mobjContext;

			private EventHandler mobjHandler;

			/// 
			/// Gets the context.
			/// </summary>
			internal object Context => mobjContext;

			/// 
			/// Gets the handler.
			/// </summary>
			internal EventHandler Handler => mobjHandler;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore`1.ContextualData`1" /> class.
			/// </summary>
			/// <param name="objContext">The obj context.</param>
			/// <param name="objHandler">The obj handler.</param>
			public ContextualData(object objContext, EventHandler objHandler)
			{
				mobjContext = objContext;
				mobjHandler = objHandler;
			}
		}

		/// 
		/// Stores typed EventHandlers by key. 
		/// </summary>
		private Dictionary<string, Action> mobjMethodsIndexByMethodKey;

		private Dictionary<string, ContextualData> mobjContextualMethodsIndexByMethodKey;

		/// 
		/// Gets the contextual methods.
		/// </summary>
		private Dictionary<string, ContextualData> ContextualMethods
		{
			get
			{
				if (mobjContextualMethodsIndexByMethodKey == null)
				{
					mobjContextualMethodsIndexByMethodKey = new Dictionary<string, ContextualData>();
				}
				return mobjContextualMethodsIndexByMethodKey;
			}
		}

		/// 
		/// Gets the methods store.
		/// </summary>
		private Dictionary<string, Action> Methods
		{
			get
			{
				if (mobjMethodsIndexByMethodKey == null)
				{
					mobjMethodsIndexByMethodKey = new Dictionary<string, Action>();
				}
				return mobjMethodsIndexByMethodKey;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore`1" /> class.
		/// </summary>
		internal SingleCallMethodStore()
		{
		}

		/// 
		/// Stores a single-call method.
		/// </summary>
		/// <param name="objMethod">The method.</param>
		/// </returns>
		internal string StoreSingleCallMethod(Action objMethod)
		{
			return StoreSingleCallMethod(null, objMethod);
		}

		internal string StoreContextualSingleCallMethod(object objThis, string strPrefix, EventHandler objMethod)
		{
			if (objMethod != null)
			{
				string text = Guid.NewGuid().ToString("N");
				ContextualMethods.Add(text, new ContextualData(objThis, objMethod));
				if (!string.IsNullOrEmpty(strPrefix))
				{
					text = strPrefix + "-" + text;
				}
				return text;
			}
			return null;
		}

		/// 
		/// Stores a single-call method.
		/// </summary>
		/// <param name="objMethod">The method.</param>
		/// </returns>
		internal string StoreSingleCallMethod(string strPrefix, Action objMethod)
		{
			if (objMethod != null)
			{
				string text = Guid.NewGuid().ToString("N");
				Methods.Add(text, objMethod);
				if (!string.IsNullOrEmpty(strPrefix))
				{
					text = strPrefix + "-" + text;
				}
				return text;
			}
			return null;
		}

		/// 
		/// Determines whether [has registered method] [the specified STR method key].
		/// </summary>
		/// <param name="strMethodKey">The STR method key.</param>
		/// 
		///   true</c> if [has registered method] [the specified STR method key]; otherwise, false</c>.
		/// </returns>
		internal bool HasRegisteredMethod(string strMethodKey)
		{
			return Methods.ContainsKey(strMethodKey);
		}

		/// 
		/// Invokes the contextual method.
		/// </summary>
		/// <param name="strMethodKey">The STR method key.</param>
		/// <param name="args">The args.</param>
		protected internal void InvokeContextualMethod(string strMethodKey, TEventArgsType args)
		{
			if (ContextualMethods.ContainsKey(strMethodKey))
			{
				ContextualData contextualData = ContextualMethods[strMethodKey];
				contextualData.Handler(contextualData.Context, args);
				ContextualMethods.Remove(strMethodKey);
			}
		}

		/// 
		/// Invokes the single call method.
		/// </summary>
		/// <param name="strMethodKey">The STR method key.</param>
		/// <param name="args">The args.</param>
		protected internal void InvokeSingleCallMethod(string strMethodKey, TEventArgsType args)
		{
			if (Methods.ContainsKey(strMethodKey))
			{
				Methods[strMethodKey](args);
				Methods.Remove(strMethodKey);
			}
		}

		internal TContextType GetContaxt<TContextType>(string strMethodKey) where TContextType : class
		{
			if (ContextualMethods.ContainsKey(strMethodKey))
			{
				return ContextualMethods[strMethodKey].Context as TContextType;
			}
			return null;
		}

		/// 
		/// Determines whether [has event listeners].
		/// </summary>
		/// 
		///   true</c> if [has event listeners]; otherwise, false</c>.
		/// </returns>
		internal bool HasEventListeners()
		{
			return Methods.Count > 0;
		}
	}
}

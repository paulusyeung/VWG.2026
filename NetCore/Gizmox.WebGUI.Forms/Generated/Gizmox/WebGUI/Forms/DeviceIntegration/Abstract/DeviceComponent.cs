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
	///
	/// </summary>
	[Serializable]
	public abstract class DeviceComponent : RegisteredComponent
	{
		private DeviceIntegrator mobjDeviceIntegrator;

		private List<KeyValuePair<string, object[]>> mobjClientMethodsInvocationBuffer;

		private bool mblnBufferInvoke = true;

		private bool mblnShouldThrowUnsupportedError = true;

		/// 
		/// Gets the mobile integrator.
		/// </summary>
		protected internal DeviceIntegrator DeviceIntegrator => mobjDeviceIntegrator;

		/// 
		/// Gets the current application context.
		/// </summary>
		public override IContext Context => VWGContext.Current;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.DeviceComponent" /> class.
		/// </summary>
		/// <param name="objDeviceIntegrator">The obj device integrator.</param>
		public DeviceComponent(DeviceIntegrator objDeviceIntegrator)
		{
			mobjDeviceIntegrator = objDeviceIntegrator;
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal abstract string GetTag();

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "DNIE")
			{
				throw new NotSupportedException(string.Format("This Device Provider do not support the {0} method of {1}", objEvent["methodName"], objEvent["featureName"]));
			}
		}

		/// 
		/// Renders the component ID.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected void RenderComponentID(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("Id", ID.ToString());
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			DeviceIntegrator.Update();
		}

		/// 
		/// Renders the attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		internal virtual void RenderAttributes(IContext objContext, IResponseWriter objWriter)
		{
		}

		/// 
		/// Called just before the RenderComponent is called.
		/// NOTE: This method is called also if the component is not dirty.
		/// </summary>
		public void OnRendering(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			mblnBufferInvoke = false;
		}

		/// 
		/// Called after the render component is called.
		/// NOTE: This method is called also if the component is not dirty.
		/// </summary>
		public void OnRendered(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			InvokeBufferedMethods();
			mblnBufferInvoke = true;
		}

		/// 
		/// Renders the component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		internal void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (!base.IsRegistered)
			{
				RegisterSelf();
			}
			if (IsDirty(lngRequestID))
			{
				objWriter.WriteStartElement(GetTag());
				RenderComponentID(objWriter as IAttributeWriter);
				RenderAttributes(objContext, objWriter);
				RenderSubComponents(lngRequestID, objContext, objWriter);
				RenderComponentClientEvents(objContext, objWriter, lngRequestID);
				ClearComponentOfflineEvents();
				objWriter.WriteEndElement();
			}
		}

		protected internal virtual void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
		}

		/// 
		/// Invoke all methods that are stored in the buffer
		/// </summary>
		private void InvokeBufferedMethods()
		{
			if (mobjClientMethodsInvocationBuffer == null)
			{
				return;
			}
			foreach (KeyValuePair<string, object[]> item in mobjClientMethodsInvocationBuffer)
			{
				VWGClientContext.Current.Invoke(item.Key, item.Value);
			}
			mobjClientMethodsInvocationBuffer.Clear();
			mobjClientMethodsInvocationBuffer = null;
		}

		/// 
		/// Centralized method to invoke client methods
		/// </summary>
		/// <param name="strMethodName"></param>
		/// <param name="arrArguments"></param>
		protected internal virtual void Invoke(string strMethodName, params object[] arrArguments)
		{
			if (mblnBufferInvoke)
			{
				mobjClientMethodsInvocationBuffer = mobjClientMethodsInvocationBuffer ?? new List<KeyValuePair<string, object[]>>();
				mobjClientMethodsInvocationBuffer.Add(new KeyValuePair<string, object[]>(strMethodName, arrArguments));
			}
			else
			{
				VWGClientContext.Current.Invoke(DeviceIntegrator, strMethodName, arrArguments);
			}
		}

		/// 
		/// Splits the prefix from method key.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// </returns>
		protected internal KeyValuePair<string, string> SplitPrefixFromMethodKey(string strValue)
		{
			string[] array = strValue.Split('-');
			if (array.Length == 2)
			{
				return new KeyValuePair<string, string>(array[0], array[1]);
			}
			return new KeyValuePair<string, string>(null, null);
		}
	}
}

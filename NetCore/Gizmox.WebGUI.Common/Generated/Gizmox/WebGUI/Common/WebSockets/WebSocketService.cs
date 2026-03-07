#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
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
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI.Common.WebSockets
{
	[Serializable]
	[MetadataTag("WEBS")]
	public class WebSocketService : RegisteredComponent
	{
		private IWebSocketHandler mobjWebSocketHandler;

		private IWebSocketProvider mobjWebSocketProvider;

		public string ConnectionId => ((IContextParams)Context).WebSocketConnectionId;

		private IWebSocketProvider Provider
		{
			get
			{
				if (mobjWebSocketProvider == null)
				{
					mobjWebSocketProvider = CommonUtils.GetProvider<IWebSocketProvider>("Gizmox.WebGUI.Forms.SignalR.SignalRWebSocketProvider, Gizmox.WebGUI.Forms.SignalR", blnIsCache: true);
				}
				return mobjWebSocketProvider;
			}
		}

		public override IContext Context => VWGContext.Current;

		public IWebSocketHandler WebSocketHandler => mobjWebSocketHandler;

		public void SetHandler<T>() where T : IWebSocketHandler
		{
			IWebSocketHandler webSocketHandler = Activator.CreateInstance(typeof(T)) as IWebSocketHandler;
			if (mobjWebSocketHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				RemoveClientHandler("Notification", mobjWebSocketHandler.ClientHandle);
			}
			mobjWebSocketHandler = webSocketHandler;
			if (mobjWebSocketHandler.IsClientHandler)
			{
				AddClientHandler("Notification", mobjWebSocketHandler.ClientHandle);
			}
			Update();
		}

		internal void WebSocketInitialized()
		{
			if (mobjWebSocketHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjWebSocketHandler.WebSocketInitialized();
			}
		}

		public void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (!IsDirty(lngRequestID))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (base.IsRegistered)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				RegisterSelf();
			}
			objWriter.WriteStartElement(WGConst.ControlsPrefix, "WEBS", WGConst.ControlsNamespace);
			(objWriter as IAttributeWriter).WriteAttributeString("Id", ID);
			RenderComponentEventAttributes(objContext, (IAttributeWriter)objWriter, blnForceRender: true);
			RenderComponentClientEvents(objContext, objWriter, lngRequestID);
			objWriter.WriteEndElement();
		}

		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (!(type == "Notification"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (mobjWebSocketHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!mobjWebSocketHandler.IsServerHandler)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjWebSocketHandler.Handle(objEvent["WSC"], objEvent["WSD"]);
			}
			base.FireEvent(objEvent);
		}

		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (mobjWebSocketHandler != null && mobjWebSocketHandler.IsClientHandler)
			{
				criticalClientEventsData.Set("NF");
			}
			return criticalClientEventsData;
		}

		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (mobjWebSocketHandler != null)
			{
				if (!mobjWebSocketHandler.IsServerHandler)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					criticalEventsData.Set("NF");
				}
			}
			return criticalEventsData;
		}

		public void Send(string strConnectionId, string strData, SendType objSendType)
		{
			Provider?.Send(strConnectionId, strData, objSendType);
		}

		public void Send(string strData, SendType objSendType)
		{
			Send(ConnectionId, strData, objSendType);
		}

		public void Send(string strFromConnectionId, string strToConnectionId, string strData)
		{
			IWebSocketProvider provider = Provider;
			if (provider == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				provider.Send(strFromConnectionId, strToConnectionId, strData);
			}
		}

		public void Send(string strToConnectionId, string strData)
		{
			Send(ConnectionId, strToConnectionId, strData);
		}
	}
}

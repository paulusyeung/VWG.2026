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

namespace Gizmox.WebGUI.Common.Gateways
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Gateway : HostHttpHandler, IRequiresSessionState
	{
		private IContext mobjContext;

		public new bool IsReusable => false;

		internal IContext Context => mobjContext;

		private bool IsCompressionRequired
		{
			get
			{
				if (mobjContext != null && mobjContext.Request is IRequestParams requestParams)
				{
					return requestParams.IsCompressionRequired;
				}
				return false;
			}
		}

		public Gateway(IContext objContext)
		{
			mobjContext = objContext;
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			Global.Context = Context;
			try
			{
				GatewayParameters gatewayParameters = new GatewayParameters(((IRequestParams)Context.Request).Resource);
				if (!gatewayParameters.IsValid)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new Exception("Gateway reference url is invalid.");
				}
				string component = gatewayParameters.Component;
				string action = gatewayParameters.Action;
				long ticks = DateTime.Now.Ticks;
				IRegisteredComponent registeredComponent = ((ISessionRegistry)mobjContext).GetRegisteredComponent(component);
				IGatewayComponent gatewayComponent = registeredComponent as IGatewayComponent;
				IGatewayControl gatewayControl = registeredComponent as IGatewayControl;
				if (gatewayControl != null)
				{
					IGatewayHandler gatewayHandler = gatewayControl.GetGatewayHandler(Context, action);
					if (gatewayHandler == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						VerboseRecord.Write(this, "Server/Gateway/Processing", "Warrning", "Gateway component does not support IGatewayHandler interface.");
					}
					else
					{
						if (CommonSwitches.TraceVerbose)
						{
							if (gatewayControl == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								VerboseRecord.Write(this, "Server/Gateway", "Processing", "Processing gateway (component=" + component + ",type=" + gatewayControl.GetType().Name + ",action=" + action + ").");
							}
						}
						gatewayHandler.ProcessGatewayRequest(Context, (IRegisteredComponent)gatewayControl);
					}
					TraceRecord.Write(new GatewayTraceRecord(action, (IRegisteredComponent)gatewayControl, ticks));
				}
				else if (gatewayComponent == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					VerboseRecord.Write(this, "Server/Gateway/Processing", "Error", "Could not find gateway component.");
					objHostContext.Response.StatusCode = 404;
				}
				else
				{
					if (CommonSwitches.TraceVerbose)
					{
						if (gatewayControl == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							VerboseRecord.Write(this, "Server/Gateway", "Processing", "Processing gateway (component=" + component + ",type=" + gatewayControl.GetType().Name + ",action=" + action + ").");
						}
					}
					if (!IsCompressionRequired)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						CommonUtils.PrepareResponseForGZip(objHostContext);
					}
					gatewayComponent.ProcessRequest(Context, action);
					TraceRecord.Write(new GatewayTraceRecord(action, (IRegisteredComponent)gatewayControl, ticks));
				}
			}
			catch (Exception ex)
			{
				Global.ClearRequestParams();
				throw new HttpException(ex.Message, ex);
			}
			Global.ClearRequestParams();
		}
	}
}

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

namespace Gizmox.WebGUI.Forms.Client
{
	[Serializable]
	public class ClientContext
	{
		private class FC
		{
			private IClientArgument A;

			private ClientContext B;

			private ISkinable C;

			private string D;

			private object[] E;

			public string MethodName => D;

			public FC(ClientContext objClientContext, ISkinable objObscuringScope, IClientArgument objClientArgument, string strMethodName, object[] arrArguments)
			{
				B = objClientContext;
				C = objObscuringScope;
				D = strMethodName;
				E = arrArguments;
				A = objClientArgument;
				if (objClientArgument != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					A = new ClientArgument();
				}
			}

			public virtual void Render(IContext objContext, IResponseWriter objWriter)
			{
				objWriter.WriteStartElement("MI");
				string scopeMethodName = B.GetScopeMethodName(objContext, C, D);
				objWriter.WriteAttributeString("ME", scopeMethodName);
				for (int i = 0; i < E.Length; i++)
				{
					object objValue = E[i];
					ClientValue clientValue = A.ToClientValue(objValue);
					objWriter.WriteAttributeString("ARG" + i, clientValue.Value);
					if (clientValue.Type == ClientValueType.String)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string strValue = clientValue.Type.ToString()[0].ToString();
					objWriter.WriteAttributeString("ARGT" + i, strValue);
				}
				objWriter.WriteEndElement();
			}
		}

		private List<FC> mobjMethodInvokes = new List<FC>();

		private Dictionary<string, FC> mobjKeyMethodInvokeMap = new Dictionary<string, FC>();

		private readonly object mobjComponent;

		public ClientContext(object objComponent)
			: this()
		{
			mobjComponent = objComponent;
		}

		public ClientContext()
		{
		}

		public void Invoke(string strMethodName, params object[] arrArguments)
		{
			Invoke(null, InvokationUniqueness.None, strMethodName, arrArguments);
		}

		public void Invoke(ISkinable objObscuringScope, string strMethodName, params object[] arrArguments)
		{
			Invoke(objObscuringScope, InvokationUniqueness.None, strMethodName, arrArguments);
		}

		public void Invoke(ISkinable objObscuringScope, InvokationUniqueness enmUniqueness, string strMethodName, params object[] arrArguments)
		{
			Invoke(objObscuringScope, enmUniqueness, null, strMethodName, arrArguments);
		}

		public void Invoke(ISkinable objObscuringScope, InvokationUniqueness enmUniqueness, IClientArgument objClientArgument, string strMethodName, params object[] arrArguments)
		{
			RegisterMethodInvoke(objObscuringScope, enmUniqueness, objClientArgument, strMethodName, arrArguments);
		}

		public void PreloadResources(int intBlockSize, int intRequestTimeout, PreloadResourcesCompleteEventHandler onPreloadResourcesComplete)
		{
			if (onPreloadResourcesComplete != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				PreloadResourcesComponent preloadResourcesComponent = new PreloadResourcesComponent(onPreloadResourcesComplete);
				string url = ClientStaticGateway.GetUrl<EC>("PreloadResourcesStaticGateway", new string[2]
				{
					"BlockSize",
					intBlockSize.ToString()
				});
				Invoke("vwgContext.preloadResources", intBlockSize, intRequestTimeout, url, preloadResourcesComponent.ID);
			}
			else
			{
				Invoke("vwgContext.preloadResources", intBlockSize, intRequestTimeout);
			}
		}

		public void PreloadResources(PreloadResourcesCompleteEventHandler onPreloadResourcesComplete)
		{
			PreloadResources(500, -1, onPreloadResourcesComplete);
		}

		public string GetScopeMethodName(IContext objContext, ISkinable objObscuringScope, string strMember)
		{
			return SkinFactory.GetSkinMethod(objContext, objObscuringScope, strMember);
		}

		internal bool IsMethodInvokesExist()
		{
			return mobjMethodInvokes.Count > 0;
		}

		public void RenderMethodInvokes(IContext context, IResponseWriter objWriter)
		{
			if (mobjMethodInvokes.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			objWriter.WriteStartElement("MIs");
			using (List<FC>.Enumerator enumerator = mobjMethodInvokes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					enumerator.Current.Render(context, objWriter);
				}
			}
			objWriter.WriteEndElement();
			mobjMethodInvokes.Clear();
			mobjKeyMethodInvokeMap.Clear();
		}

		private void RegisterMethodInvoke(ISkinable objObscuringScope, InvokationUniqueness enmUniqueness, IClientArgument objClientArgument, string strMethodName, params object[] arrArguments)
		{
			FC fC = new FC(this, objObscuringScope, objClientArgument, strMethodName, arrArguments);
			string text = null;
			switch (enmUniqueness)
			{
			case InvokationUniqueness.Component:
				if (objObscuringScope == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_00bd;
				}
				if (objObscuringScope is IRegisteredComponent)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(objObscuringScope is IIdentifiedComponent))
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_00bd;
				}
				if (!(objObscuringScope is IRegisteredComponent))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(objObscuringScope is IIdentifiedComponent))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text = $"{((IIdentifiedComponent)objObscuringScope).ID}_{fC.MethodName}";
					}
				}
				else
				{
					text = $"{((IRegisteredComponent)objObscuringScope).ID}_{fC.MethodName}";
				}
				break;
			default:
				/*OpCode not supported: LdMemberToken*/;
				break;
			case InvokationUniqueness.Global:
				{
					text = string.Format("{0}_{1}", "$$", fC.MethodName);
					break;
				}
				IL_00bd:
				text = string.Format("{0}_{1}", "$$", fC.MethodName);
				break;
			}
			if (text == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjKeyMethodInvokeMap.TryGetValue(text, out var value))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjMethodInvokes.Remove(value);
				}
				mobjKeyMethodInvokeMap[text] = fC;
			}
			mobjMethodInvokes.Add(fC);
		}
	}
}

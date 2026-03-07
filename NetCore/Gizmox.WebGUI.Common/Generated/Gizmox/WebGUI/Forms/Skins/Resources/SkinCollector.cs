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

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	internal class SkinCollector : Dictionary<string, SkinCollectorResource>
	{
		internal string mstrCollectorName = string.Empty;

		internal GlobalScope mobjGlobalScope;

		private bool mblnIsCompiled;

		private object mobjLockCompileOperation = new object();

		private object mobjLockResourceCacheCreation = new object();

		public string Name => mstrCollectorName;

		public bool IsCompiled => mblnIsCompiled;

		protected virtual bool IsCompressionEnabled => ConfigHelper.IsCompressionEnabled;

		protected virtual bool IsBrowserDependent => true;

		protected virtual bool IsObscuringDependent => false;

		internal virtual bool SupportsMultilineSkinValues => false;

		protected virtual bool IsLocalizable => true;

		protected virtual bool IsThemable => true;

		protected virtual string ContentType => CommonUtils.GetMimeType(Path.GetExtension(Name));

		internal virtual bool IsCompileEnabled => false;

		protected virtual bool IsServerCacheEnabled => ConfigHelper.IsCacheEnabled;

		protected virtual bool IsClientCacheEnabled => ConfigHelper.IsCacheEnabled;

		public SkinCollector(GlobalScope objGlobalScope, string strCollectorName)
		{
			mobjGlobalScope = objGlobalScope;
			mstrCollectorName = strCollectorName;
		}

		private void Compile()
		{
			if (mblnIsCompiled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			object obj = mobjLockCompileOperation;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (mblnIsCompiled)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				try
				{
					foreach (SkinCollectorResource value in base.Values)
					{
						if (!value.IsCompiled)
						{
							value.Compile();
						}
					}
				}
				finally
				{
					mblnIsCompiled = true;
				}
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(obj);
				}
			}
		}

		protected virtual void WriteContent(Stream objOutputStream, BB objController)
		{
			StreamWriter streamWriter = new StreamWriter(objOutputStream, objController.TextEncoding);
			WriteStart(streamWriter, objController);
			WriteContent(streamWriter, objController);
			WriteEnd(streamWriter, objController);
			streamWriter.Flush();
		}

		internal void Write(Stream objOutputStream, BB objController)
		{
			EnsureCompiled();
			WriteContent(objOutputStream, objController);
		}

		internal void Write(HostContext objHostContext, BB objController)
		{
			EnsureCompiled();
			CommonUtils.GZipSupport gZipSupport = GetGZipSupport(objHostContext);
			WriteHeaders(objHostContext, objController, gZipSupport);
			WriteContent(objHostContext, objController, gZipSupport);
		}

		private void EnsureCompiled()
		{
			if (!IsCompileEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (IsCompiled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Compile();
			}
		}

		private void WriteContent(HostContext objHostContext, BB objController, CommonUtils.GZipSupport enmGZipSupport)
		{
			HostResponse response = objHostContext.Response;
			if (!IsServerCacheEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsGZipRequired(enmGZipSupport))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CommonUtils.ApplyGZipFilter(response, enmGZipSupport);
				}
				WriteContent(response.OutputStream, objController);
				return;
			}
			string strCacheKey = GenerateCacheKey(objController, enmGZipSupport);
			if (WriteContentFromCache(objHostContext, response.OutputStream, strCacheKey))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			object obj = mobjLockResourceCacheCreation;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (WriteContentFromCache(objHostContext, response.OutputStream, strCacheKey))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				MemoryStream memoryStream = new MemoryStream();
				Stream gZipStreamWriter = CommonUtils.GetGZipStreamWriter(memoryStream, enmGZipSupport);
				try
				{
					WriteContent(gZipStreamWriter, objController);
					gZipStreamWriter.Close();
				}
				finally
				{
					if (gZipStreamWriter == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						((IDisposable)gZipStreamWriter).Dispose();
					}
				}
				WriteCacheAndOutput(objHostContext, response.OutputStream, strCacheKey, memoryStream.ToArray());
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(obj);
				}
			}
		}

		private void WriteCacheAndOutput(HostContext objHostContext, Stream objOutputStream, string strCacheKey, byte[] arrContent)
		{
			SkinFactory.Cache[strCacheKey] = arrContent;
			objOutputStream.Write(arrContent, 0, arrContent.Length);
		}

		private string GenerateCacheKey(BB objController, CommonUtils.GZipSupport enmGZipSupport)
		{
			return $"{GetResourcePresentationDrawingEngineCacheKey()}|{GetResourceThemeCacheKey(objController.ResourceThemeCacheKey)}|{GetResourceCultureCacheKey(objController.ResourceCultureCacheKey)}|{GetResourceBrowserCacheKey(objController.ResourceBrowserCacheKey)}|{GetResourceCacheVersionCacheKey(objController.ResourceCacheVersionCacheKey)}|{GetResourceBrowserCapabilitiesCacheKey(objController.CSS3BrowserCapabilities, objController.HTML5BrowserCapabilities, objController.MISCBrowserCapabilities)}|{GetResourceGZipSupportCacheKey((int)enmGZipSupport)}|{GetResourceObscuringCacheKey(ConfigHelper.IsObscuringEnabled)}|{mstrCollectorName}";
		}

		private string GetResourceBrowserCapabilitiesCacheKey(CSS3BrowserCapabilities enmCSS3BrowserCapabilities, HTML5BrowserCapabilities enmHTML5BrowserCapabilities, MISCBrowserCapabilities enmMISCBrowserCapabilities)
		{
			return $"{Convert.ToInt32(enmCSS3BrowserCapabilities).ToString()}.{Convert.ToInt32(enmHTML5BrowserCapabilities).ToString()}.{Convert.ToInt32(enmMISCBrowserCapabilities).ToString()}";
		}

		private string GetResourcePresentationDrawingEngineCacheKey()
		{
			return ConfigHelper.CurrentPresentationDrawingEngine.ToString();
		}

		private string GetResourceObscuringCacheKey(bool blnIsObscuringEnabled)
		{
			if (!IsObscuringDependent)
			{
				/*OpCode not supported: LdMemberToken*/;
				return "X";
			}
			if (blnIsObscuringEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return "1";
			}
			return "0";
		}

		private string GetResourceGZipSupportCacheKey(int intGZipSupportCacheKey)
		{
			if (!IsCompressionEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return "X";
			}
			return intGZipSupportCacheKey.ToString();
		}

		private string GetResourceCacheVersionCacheKey(string strCacheVersionCacheKey)
		{
			return strCacheVersionCacheKey;
		}

		private string GetResourceBrowserCacheKey(string strBrowserCacheKey)
		{
			if (!IsBrowserDependent)
			{
				/*OpCode not supported: LdMemberToken*/;
				return "X";
			}
			return strBrowserCacheKey;
		}

		private string GetResourceCultureCacheKey(string strCultureCacheKey)
		{
			if (!IsLocalizable)
			{
				/*OpCode not supported: LdMemberToken*/;
				return "xx-XX";
			}
			return strCultureCacheKey;
		}

		private string GetResourceThemeCacheKey(string strThemeCacheKey)
		{
			if (!IsThemable)
			{
				/*OpCode not supported: LdMemberToken*/;
				return "X";
			}
			return strThemeCacheKey;
		}

		private bool IsGZipRequired(CommonUtils.GZipSupport enmGZipSupport)
		{
			return enmGZipSupport != CommonUtils.GZipSupport.None;
		}

		private bool WriteContentFromCache(HostContext objHostContext, Stream objOutputStream, string strCacheKey)
		{
			byte[] array = SkinFactory.Cache[strCacheKey];
			if (array != null)
			{
				objOutputStream.Write(array, 0, array.Length);
				return true;
			}
			return false;
		}

		private void WriteHeaders(HostContext objHostContext, BB objController, CommonUtils.GZipSupport enmGZipSupport)
		{
			HostResponse response = objHostContext.Response;
			CommonUtils.WriteGZipHeaders(response, enmGZipSupport);
			if (!IsClientCacheEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				response.Cache.SetCacheability(HttpCacheability.Public);
				response.Cache.SetExpires(DateTime.Now.AddYears(1));
			}
			if (!string.IsNullOrEmpty(ContentType))
			{
				response.ContentType = ContentType;
			}
			WriteHeaders(objHostContext.Response, objController);
		}

		protected virtual void WriteHeaders(HostResponse objResponse, BB objController)
		{
		}

		public override string ToString()
		{
			return $"{mstrCollectorName}, Type:{GetType().Name}";
		}

		internal virtual void WriteContent(StreamWriter objStreamWriter, BB objController)
		{
		}

		internal virtual void WriteStart(StreamWriter objStreamWriter, BB objController)
		{
		}

		internal virtual void WriteEnd(StreamWriter objStreamWriter, BB objController)
		{
		}

		private CommonUtils.GZipSupport GetGZipSupport(HostContext objContext)
		{
			if (!IsCompressionEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return CommonUtils.GZipSupport.None;
			}
			return CommonUtils.GetGZipSupport(objContext);
		}
	}
}

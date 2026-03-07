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
	internal abstract class SkinIncludeCollector
	{
		private object mobjLockResourceCacheCreation = new object();

		protected virtual string ContentType => null;

		protected virtual bool IsCompressionEnabled => ConfigHelper.IsCompressionEnabled;

		protected virtual bool IsServerCacheEnabled => ConfigHelper.IsCacheEnabled;

		protected virtual bool IsClientCacheEnabled => ConfigHelper.IsCacheEnabled;

		public SkinIncludeCollector()
		{
		}

		protected virtual void WriteContent(Stream objOutputStream, IContext objContext)
		{
			if (objOutputStream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (objContext.Config == null)
				{
					return;
				}
				List<Include> includedResources = GetIncludedResources(objContext);
				if (includedResources == null)
				{
					return;
				}
				using List<Include>.Enumerator enumerator = includedResources.GetEnumerator();
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					Stream content = enumerator.Current.Content;
					if (content == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (content.Length <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					byte[] array = new byte[content.Length];
					content.Read(array, 0, array.Length);
					content.Close();
					objOutputStream.Write(array, 0, array.Length);
				}
			}
		}

		internal void Write(Stream objOutputStream, IContext objContext)
		{
			WriteContent(objOutputStream, objContext);
		}

		internal void Write(HostContext objHostContext, IContext objContext)
		{
			CommonUtils.GZipSupport gZipSupport = GetGZipSupport(objHostContext);
			WriteHeaders(objHostContext, gZipSupport);
			WriteContent(objHostContext, gZipSupport, objContext);
		}

		private void WriteContent(HostContext objHostContext, CommonUtils.GZipSupport enmGZipSupport, IContext objContext)
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
				WriteContent(response.OutputStream, objContext);
				return;
			}
			string strCacheKey = GenerateCacheKey(objContext, enmGZipSupport);
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
				using (Stream stream = CommonUtils.GetGZipStreamWriter(memoryStream, enmGZipSupport))
				{
					WriteContent(stream, objContext);
					stream.Close();
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
			if (arrContent != null && arrContent.Length != 0)
			{
				objOutputStream.Write(arrContent, 0, arrContent.Length);
			}
		}

		private string GenerateCacheKey(IContext objContext, CommonUtils.GZipSupport enmGZipSupport)
		{
			return $"{GetResourceGZipSupportCacheKey((int)enmGZipSupport)}|{GetResourcePresentationDrawingEngineCacheKey()}|{GetResourceName()}";
		}

		protected abstract string GetResourceName();

		private string GetResourceGZipSupportCacheKey(int intGZipSupportCacheKey)
		{
			if (!IsCompressionEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return "X";
			}
			return intGZipSupportCacheKey.ToString();
		}

		private string GetResourcePresentationDrawingEngineCacheKey()
		{
			return Convert.ToInt32(ConfigHelper.CurrentPresentationDrawingEngine).ToString();
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
				if (array.Length != 0)
				{
					objOutputStream.Write(array, 0, array.Length);
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private void WriteHeaders(HostContext objHostContext, CommonUtils.GZipSupport enmGZipSupport)
		{
			HostResponse response = objHostContext.Response;
			CommonUtils.WriteGZipHeaders(response, enmGZipSupport);
			if (string.IsNullOrEmpty(ContentType))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				response.ContentType = ContentType;
			}
			if (!IsClientCacheEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				response.Cache.SetCacheability(HttpCacheability.Public);
				response.Cache.SetExpires(DateTime.Now.AddYears(1));
			}
			WriteHeaders(objHostContext.Response);
		}

		protected virtual void WriteHeaders(HostResponse objResponse)
		{
			if (CommonSwitches.DisableCaching.Enabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				objResponse.Expires = -1;
			}
			else
			{
				objResponse.Expires = 10000;
				objResponse.Cache.SetCacheability(HttpCacheability.Private);
			}
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

		protected virtual List<Include> GetIncludedResources(IContext objContext)
		{
			return null;
		}
	}
}

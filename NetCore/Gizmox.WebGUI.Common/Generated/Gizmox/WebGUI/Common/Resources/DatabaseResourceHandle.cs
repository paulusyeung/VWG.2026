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

namespace Gizmox.WebGUI.Common.Resources
{
	[Serializable]
	public abstract class DatabaseResourceHandle : StaticGatewayResourceHandle, IStaticGateway
	{
		private string mstrQualifier = string.Empty;

		private string mstrToken = string.Empty;

		private IContext mobjContext;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed override string File
		{
			get
			{
				return base.File;
			}
			set
			{
				base.File = value;
			}
		}

		public override bool IsServerResource => true;

		protected virtual string ContentTypeColumn => "ContentType";

		protected virtual string ContentColumn => "Content";

		protected string Qualifier => mstrQualifier;

		protected string Token => mstrToken;

		protected virtual bool UseAuthentication => true;

		protected virtual HttpCacheability Cacheability => HttpCacheability.Public;

		protected virtual int Expires => -1;

		protected IContext Context
		{
			get
			{
				if (mobjContext != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjContext = VWGContext.Current;
				}
				return mobjContext;
			}
		}

		static DatabaseResourceHandle()
		{
		}

		public DatabaseResourceHandle(string strQualifier)
			: this(strQualifier, string.Empty)
		{
		}

		public DatabaseResourceHandle(string strQualifier, string strToken)
		{
			mstrQualifier = HttpUtility.UrlEncode(strQualifier);
			mstrToken = HttpUtility.UrlEncode(ValidateToken(strToken));
			RegisterType(GetUniqueName(), GetType());
		}

		public DatabaseResourceHandle()
		{
		}

		IStaticGatewayHandler IStaticGateway.GetGatewayHandler(IContext objContext)
		{
			HostRequest request = objContext.HostContext.Request;
			HostResponse response = objContext.HostContext.Response;
			mobjContext = objContext;
			IDbConnection connection = GetConnection();
			try
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}
				if (!UseAuthentication)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Authenticate(connection, request.QueryString["Token"]);
				}
				IDataReader dataReader = GetDataReader(connection, request.QueryString["Qualifier"]);
				if (dataReader == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new HttpException(404, "The resource could not be found.");
				}
				if (!dataReader.Read())
				{
					throw new HttpException(404, "The resource could not be found.");
				}
				Write(response, dataReader);
				dataReader.Close();
			}
			finally
			{
				if (connection == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					connection.Dispose();
				}
			}
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected sealed override string GetSpecificResourceHandle()
		{
			return $"{base.GetSpecificResourceHandle()}?Qualifier={Qualifier}&Token={Token}";
		}

		protected internal override string GetUniqueIdentifier()
		{
			return base.GetSpecificResourceHandle();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Icon ToIcon()
		{
			return base.ToIcon();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Image ToImage()
		{
			return base.ToImage();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Stream ToStream()
		{
			return base.ToStream();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		protected virtual void Authenticate(IDbConnection objConnection, string strToken)
		{
			if (strToken != HostContext.Current.Session.SessionID)
			{
				throw new HttpException(401, "Session authentication failed.");
			}
		}

		protected abstract IDbConnection GetConnection();

		protected abstract IDataReader GetDataReader(IDbConnection objConnection, string strQualifier);

		protected virtual void Write(HostResponse objResponse, IDataReader objDataReader)
		{
			WriteCacheHeaders(objResponse);
			WriteContentType(objResponse, objDataReader);
			WriteContent(objResponse, objDataReader);
		}

		protected virtual void WriteCacheHeaders(HostResponse objResponse)
		{
			objResponse.Expires = Expires;
			objResponse.Cache.SetCacheability(Cacheability);
		}

		protected virtual void WriteContentType(HostResponse objResponse, IDataReader objDataReader)
		{
			objResponse.ContentType = objDataReader.GetString(objDataReader.GetOrdinal(ContentTypeColumn));
		}

		protected virtual void WriteContent(HostResponse objResponse, IDataReader objDataReader)
		{
			objResponse.BinaryWrite((byte[])objDataReader[objDataReader.GetOrdinal(ContentColumn)]);
		}

		protected virtual string GetUniqueName()
		{
			return GetType().FullName;
		}

		private string ValidateToken(string strToken)
		{
			if (!string.IsNullOrEmpty(strToken))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (UseAuthentication)
			{
				return HostContext.Current.Session.SessionID;
			}
			return strToken;
		}
	}
}

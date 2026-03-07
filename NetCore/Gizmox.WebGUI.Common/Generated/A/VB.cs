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

namespace A
{
	internal abstract class VB : IEnumerable<VB>, IEnumerable
	{
		private readonly VB P;

		private readonly UB Q;

		private readonly List<VB> R;

		private readonly int S;

		private readonly int T;

		private readonly string U;

		private readonly string V;

		private bool W;

		private readonly int X;

		private WB Y;

		public VB Parent => P;

		public int Depth => X;

		public VB[] Nodes => R.ToArray();

		public UB Namespaces => Q;

		public TB Namespace => Q[U];

		public virtual QB Document
		{
			get
			{
				if (P != null)
				{
					return P.Document;
				}
				return null;
			}
		}

		public virtual CC TypeResolver
		{
			get
			{
				if (P != null)
				{
					return P.TypeResolver;
				}
				return null;
			}
		}

		public string NodeName => V;

		public WB State
		{
			get
			{
				if (Y != WB.A)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Y = GetState(null, blnThrowOnValidation: true);
				}
				return Y;
			}
		}

		public string NodePrefix => U;

		public int LineNumber => S;

		public int LinePosition => T;

		internal VB(VB objParentNode, XmlTextReader objReader)
		{
			R = new List<VB>();
			Q = new UB(this);
			P = objParentNode;
			objParentNode?.R.Add(this);
			S = objReader.LineNumber;
			T = objReader.LinePosition;
			V = objReader.LocalName;
			U = objReader.Prefix;
			X = objReader.Depth;
		}

		protected VB()
		{
			R = new List<VB>();
			Q = new UB(this);
			P = null;
			S = 0;
			T = 0;
			V = null;
			U = null;
			X = -1;
		}

		internal void Initialize(XamlParseExceptionCollection objExceptions, bool blnThrowOnValidation)
		{
			Initialize(Document, objExceptions, blnThrowOnValidation);
		}

		private void Initialize(QB objDocumentNode, XamlParseExceptionCollection objExceptions, bool blnThrowOnValidation)
		{
			if (W)
			{
				return;
			}
			W = true;
			if (Y != WB.A)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Y = GetState(objExceptions, blnThrowOnValidation);
			}
			OnIntializing(objDocumentNode);
			using List<VB>.Enumerator enumerator = R.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				enumerator.Current.Initialize(objDocumentNode, objExceptions, blnThrowOnValidation);
			}
		}

		protected virtual void OnIntializing(QB objDocument)
		{
		}

		protected virtual WB GetState(XamlParseExceptionCollection objExceptions, bool blnThrowOnValidation)
		{
			return WB.B;
		}

		public IEnumerator<VB> GetEnumerator()
		{
			return R.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return R.GetEnumerator();
		}
	}
}

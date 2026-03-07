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

namespace Gizmox.WebGUI.Virtualization
{
	[Serializable]
	internal class VirtualNode
	{
		private Guid mobjId;

		private string mstrName;

		private Guid mobjForestId;

		private DateTime mobjCreatedOn;

		private string mstrCreatedBy;

		private DateTime mobjUpdatedOn;

		private string mstrUpdatedBy;

		private Guid mobjDataId;

		private string mstrDataValue;

		private Guid mobjParentId;

		private Guid mobjType;

		private int mintContentLegth;

		private bool mblnIsNew;

		private long mdblAttributes;

		public Guid Id => mobjId;

		public Guid ForestId
		{
			get
			{
				if (!(mobjForestId != Guid.Empty))
				{
					/*OpCode not supported: LdMemberToken*/;
					return VirtualForest.Default.Id;
				}
				return mobjForestId;
			}
		}

		public string Name => mstrName;

		public Guid ParentId => mobjParentId;

		public Guid Type => mobjType;

		public DateTime CreatedOn => mobjCreatedOn;

		public string CreatedBy => mstrCreatedBy;

		public DateTime UpdatedOn => mobjUpdatedOn;

		public string UpdatedBy => mstrUpdatedBy;

		public Guid DataId => mobjDataId;

		public string DataValue => mstrDataValue;

		public int ContentLegth => mintContentLegth;

		public VirtualReference Reference => new VirtualReference(this);

		internal VirtualNode(Guid objId, string strName, Guid objParentId, Guid objType, Guid objForest, DateTime objCreatedOn, string strCreatedBy, DateTime objUpdatedOn, string strUpdatedBy, Guid objDataId, string strDataValue, int intContentLegth, bool blnIsNew, long lngAttributes)
		{
			mobjId = objId;
			mstrName = strName;
			mobjParentId = objParentId;
			mobjType = objType;
			mobjForestId = objForest;
			mobjCreatedOn = objCreatedOn;
			mstrCreatedBy = strCreatedBy;
			mobjUpdatedOn = objUpdatedOn;
			mstrUpdatedBy = strUpdatedBy;
			mobjDataId = objDataId;
			mstrDataValue = strDataValue;
			mintContentLegth = intContentLegth;
			mblnIsNew = blnIsNew;
			mdblAttributes = lngAttributes;
		}
	}
}

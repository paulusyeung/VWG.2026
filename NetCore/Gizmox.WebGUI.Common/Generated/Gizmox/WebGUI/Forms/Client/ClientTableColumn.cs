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
	[TypeConverter(typeof(ClientTableColumnTypeConverter))]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	public class ClientTableColumn : ComponentBase
	{
		private string mstrName = string.Empty;

		private ClientStorageDataType menmType = ClientStorageDataType.Text;

		private bool mblnIsUnique;

		private bool mblnIsAutoIncreased;

		private bool mblnIsPrimaryKey;

		private string mstrDefaultValue = string.Empty;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
			}
		}

		[Description("Specifies column type. Note: SQLite has dynamically-typed columns.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ClientStorageDataType Type
		{
			get
			{
				return menmType;
			}
			set
			{
				menmType = value;
			}
		}

		[Description("Specifies that this column values have uniqueness constraint.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[DefaultValue(false)]
		public bool IsUnique
		{
			get
			{
				return mblnIsUnique;
			}
			set
			{
				if (mblnIsUnique == value)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mblnIsUnique = value;
				}
			}
		}

		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Specifies that an ID chosen for the new row is at least one larger than the largest ID that has ever before existed in that same table.")]
		public bool IsAutoIncreased
		{
			get
			{
				return mblnIsAutoIncreased;
			}
			set
			{
				if (mblnIsAutoIncreased == value)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mblnIsAutoIncreased = value;
				}
			}
		}

		[DefaultValue(false)]
		[Description("Specifies that this column is the PRIMARY KEY of the owning table.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public bool IsPrimaryKey
		{
			get
			{
				return mblnIsPrimaryKey;
			}
			set
			{
				if (mblnIsPrimaryKey == value)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mblnIsPrimaryKey = value;
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Specifies a default value to use for the column if no value is explicitly provided by the user when doing an INSERT.")]
		[DefaultValue("")]
		public string DefaultValue
		{
			get
			{
				return mstrDefaultValue;
			}
			set
			{
				if (!(value != mstrDefaultValue))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrDefaultValue = value;
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
			}
		}

		public ClientTableColumn(string strName, ClientStorageDataType enmType, string strDefaultValue, bool blnIsUniuqe, bool blnIsPrimaryKey, bool blnIsAutoIncreased)
		{
			mstrName = strName;
			menmType = enmType;
			mblnIsUnique = blnIsUniuqe;
			mblnIsPrimaryKey = blnIsPrimaryKey;
			mblnIsAutoIncreased = blnIsAutoIncreased;
			mstrDefaultValue = strDefaultValue;
		}

		public ClientTableColumn()
		{
		}

		internal void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			objWriter.WriteStartElement("C");
			RenderClientTableColumnAttribute(objContext, objWriter, lngRequestID);
			objWriter.WriteEndElement();
		}

		private void RenderClientTableColumnAttribute(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			string name = Name;
			if (!string.IsNullOrEmpty(name))
			{
				objWriter.WriteAttributeString("N", name);
			}
			if (!IsAutoIncreased)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.WriteAttributeString("AI", "1");
			}
			string text = menmType.ToString();
			text = text.ToUpperInvariant();
			objWriter.WriteAttributeString("TP", text);
			if (!IsPrimaryKey)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.WriteAttributeString("PK", "1");
			}
			if (IsUnique)
			{
				objWriter.WriteAttributeString("UNQ", "1");
			}
			if (string.IsNullOrEmpty(DefaultValue))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objWriter.WriteAttributeString("DEF", DefaultValue.ToString());
			}
		}
	}
}

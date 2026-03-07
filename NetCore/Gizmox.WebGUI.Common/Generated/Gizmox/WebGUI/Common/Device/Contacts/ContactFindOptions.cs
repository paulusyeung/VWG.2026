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

namespace Gizmox.WebGUI.Common.Device.Contacts
{
	[Serializable]
	public class ContactFindOptions : DevicePropertyDictionary
	{
		private ContactFields menmFields;

		public ContactFields Fields
		{
			get
			{
				return menmFields;
			}
			set
			{
				menmFields = value;
				IList<string> filteredFieldsArray = GetFilteredFieldsArray(menmFields);
				SetNullableProperty("fields", filteredFieldsArray);
			}
		}

		public IList<string> FilteredFields
		{
			get
			{
				List<string> list = GetNullableProperty<List<string>>("fields");
				if (list != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					list = GetFilteredFieldsArray(menmFields);
					SetNullableProperty("fields", list.ToArray());
				}
				return list;
			}
		}

		public bool? IsMultiple
		{
			get
			{
				return GetNullableValueTypeProperty<bool>("multiple");
			}
			set
			{
				AddNullableValueTypeProperty("multiple", value);
			}
		}

		public string Filter
		{
			get
			{
				return GetNullableProperty<string>("filter");
			}
			set
			{
				SetNullableProperty("filter", value);
			}
		}

		public ContactFindOptions(string strFilter, bool blnIsMultiple, ContactFields enmFields)
		{
			Filter = strFilter;
			IsMultiple = blnIsMultiple;
			Fields = enmFields;
		}

		public ContactFindOptions()
		{
		}

		private List<string> GetFilteredFieldsArray(ContactFields enmFields)
		{
			List<string> list = new List<string>();
			if ((enmFields & ContactFields.All) == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (enmFields == ContactFields.None)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (enmFields != ContactFields.ID)
				{
					/*OpCode not supported: LdMemberToken*/;
					if ((enmFields & ContactFields.Addresses) != ContactFields.None)
					{
						list.Add("addresses");
					}
					if ((enmFields & ContactFields.Birthday) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("birthday");
					}
					if ((enmFields & ContactFields.Categories) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("categories");
					}
					if ((enmFields & ContactFields.DisplayName) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("displayName");
					}
					if ((enmFields & ContactFields.Emails) != ContactFields.None)
					{
						list.Add("emails");
					}
					if ((enmFields & ContactFields.ID) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("id");
					}
					if ((enmFields & ContactFields.IMs) != ContactFields.None)
					{
						list.Add("ims");
					}
					if ((enmFields & ContactFields.Name) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("name");
					}
					if ((enmFields & ContactFields.Nickname) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("nickname");
					}
					if ((enmFields & ContactFields.Note) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("note");
					}
					if ((enmFields & ContactFields.Organizations) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("organizations");
					}
					if ((enmFields & ContactFields.PhoneNumbers) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("phoneNumbers");
					}
					if ((enmFields & ContactFields.Photos) != ContactFields.None)
					{
						list.Add("photos");
					}
					if ((enmFields & ContactFields.URLs) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add("urls");
					}
					goto IL_01bb;
				}
				list.Add("id");
			}
			else
			{
				list.Add("*");
			}
			goto IL_01bb;
			IL_01bb:
			return list;
		}
	}
}

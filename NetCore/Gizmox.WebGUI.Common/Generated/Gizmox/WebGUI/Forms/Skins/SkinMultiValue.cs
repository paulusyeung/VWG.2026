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

namespace Gizmox.WebGUI.Forms.Skins
{
	[Serializable]
	[TypeConverter(typeof(SkinMultiValueConverter))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class SkinMultiValue : SkinValue, ISkinContainer
	{
		private readonly Skin mobjSkin;

		private readonly string mstrPrefix;

		private readonly SkinMultiValue mobjBaseStyle;

		private Dictionary<string, object> mobjDefaults;

		private bool mblnIsInitializing;

		private bool mblnIsAmbientValues;

		[Browsable(false)]
		public Skin Skin => mobjSkin;

		protected string Prefix => mstrPrefix;

		protected SkinMultiValue Defaults => mobjBaseStyle;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected bool DesignMode => mobjSkin.DesignModeInternal;

		Skin ISkinContainer.Skin => mobjSkin;

		public SkinMultiValue(Skin objPropertyOwner, string strPropertyPrefix)
			: this(objPropertyOwner, strPropertyPrefix, null)
		{
		}

		public SkinMultiValue(Skin objPropertyOwner, string strPropertyPrefix, SkinMultiValue objBaseStyle)
			: this(objPropertyOwner, strPropertyPrefix, objBaseStyle, blnIsAmbientValues: false)
		{
		}

		public SkinMultiValue(Skin objPropertyOwner, string strPropertyPrefix, SkinMultiValue objBaseStyle, bool blnIsAmbientValues)
		{
			if (objPropertyOwner != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (string.IsNullOrEmpty(strPropertyPrefix))
				{
					throw new ArgumentNullException("strPropertyPrefix");
				}
				mblnIsAmbientValues = blnIsAmbientValues;
				mobjSkin = objPropertyOwner;
				mstrPrefix = strPropertyPrefix;
				mobjBaseStyle = objBaseStyle;
				return;
			}
			throw new ArgumentNullException("objPropertyOwner");
		}

		private string GetMultiKey(string strKey)
		{
			return $"{mstrPrefix}.{strKey}";
		}

		private string[] GetMultiKeys(string[] strKeys)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < strKeys.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string strKey = strKeys[i];
				list.Add(GetMultiKey(strKey));
			}
			return list.ToArray();
		}

		protected T GetValue<T>(string strKey, T objDefaultValue)
		{
			string multiKey = GetMultiKey(strKey);
			if (mobjDefaults == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjDefaults.ContainsKey(multiKey))
				{
					if (mblnIsAmbientValues)
					{
						return mobjSkin.GetAmbientValue(multiKey, (T)mobjDefaults[multiKey]);
					}
					return mobjSkin.GetValue(multiKey, (T)mobjDefaults[multiKey]);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!mobjSkin.HasValue(multiKey))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (mobjBaseStyle == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return objDefaultValue;
				}
				return mobjBaseStyle.GetValue(strKey, objDefaultValue);
			}
			if (!mblnIsAmbientValues)
			{
				/*OpCode not supported: LdMemberToken*/;
				return mobjSkin.GetValue(multiKey, objDefaultValue);
			}
			return mobjSkin.GetAmbientValue(multiKey, objDefaultValue);
		}

		protected int GetImageHeight(ImageResourceReference objImageResourceReference, int intDefault)
		{
			return mobjSkin.GetImageHeight(objImageResourceReference, intDefault);
		}

		protected internal int GetImageWidth(ImageResourceReference objImageResourceReference, int intDefault)
		{
			return mobjSkin.GetImageWidth(objImageResourceReference, intDefault);
		}

		protected int GetImageHeight(string strKey, int intDefault)
		{
			return mobjSkin.GetImageHeight(strKey, intDefault);
		}

		protected int GetMaxImageHeight(int intDefault, params string[] strKeys)
		{
			return mobjSkin.GetMaxImageHeight(intDefault, strKeys);
		}

		protected int GetImageWidth(string strKey, int intDefault)
		{
			return mobjSkin.GetImageWidth(strKey, intDefault);
		}

		protected Size GetImageSize(ImageResourceReference objImageResourceReference, Size objDefault)
		{
			return mobjSkin.GetImageSize(objImageResourceReference, objDefault);
		}

		protected int GetMaxImageWidth(int intDefault, params string[] strKeys)
		{
			return mobjSkin.GetMaxImageWidth(intDefault, strKeys);
		}

		protected bool ShouldSerialize(string strKey)
		{
			return mobjSkin.ShouldSerialize(GetMultiKey(strKey));
		}

		protected void Reset(string strKey)
		{
			mobjSkin.Reset(GetMultiKey(strKey));
		}

		protected void SetValue(string strKey, object objValue)
		{
			if (!mblnIsInitializing)
			{
				mobjSkin.SetValue(GetMultiKey(strKey), objValue);
			}
			else
			{
				SetDefaultValue(GetMultiKey(strKey), objValue);
			}
		}

		protected bool HasValue(string strKey)
		{
			string multiKey = GetMultiKey(strKey);
			if (mobjDefaults == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjDefaults.ContainsKey(multiKey))
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!mblnIsAmbientValues)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (mobjSkin.HasValue(multiKey))
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjSkin.HasAmbientValue(multiKey))
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (mobjBaseStyle != null)
			{
				if (mobjBaseStyle.HasValue(strKey))
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private void SetDefaultValue(string strKey, object objValue)
		{
			if (mobjDefaults == null)
			{
				mobjDefaults = new Dictionary<string, object>();
			}
			mobjDefaults[strKey] = objValue;
		}
	}
}

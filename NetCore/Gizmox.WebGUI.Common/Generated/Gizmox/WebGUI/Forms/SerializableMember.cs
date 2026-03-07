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

namespace Gizmox.WebGUI.Forms
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public abstract class SerializableMember
	{
		private readonly int mintIndex;

		private readonly string mstrName;

		private readonly Type mobjOwnerType;

		private readonly Type mobjMemberType;

		private static Dictionary<Type, int> mobjCurrentIdByType = new Dictionary<Type, int>();

		private const int mintFieldsPerTypeLimit = 500;

		private static Type NullableType = typeof(Nullable<>);

		private readonly SerializableMemberMetadata mobjMemberMetadata;

		private static List<SerializableMember> mobjMembers = new List<SerializableMember>();

		private int mintCallGetCount;

		private double mdblCallGetTime;

		private int mintCallSetCount;

		private double mdblCallSetTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool TraceMode => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool TraceContentMode => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static double TotalCallGetTime
		{
			get
			{
				double num = 0.0;
				IEnumerator<SerializableMember> enumerator = RegisteredMembers.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						SerializableMember current = enumerator.Current;
						num += current.CallGetTime;
					}
					return num;
				}
				finally
				{
					if (enumerator == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						enumerator.Dispose();
					}
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int TotalCallGetCount
		{
			get
			{
				int num = 0;
				using IEnumerator<SerializableMember> enumerator = RegisteredMembers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					SerializableMember current = enumerator.Current;
					num += current.CallGetCount;
				}
				return num;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static double TotalCallSetTime
		{
			get
			{
				double num = 0.0;
				IEnumerator<SerializableMember> enumerator = RegisteredMembers.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						SerializableMember current = enumerator.Current;
						num += current.CallSetTime;
					}
					return num;
				}
				finally
				{
					if (enumerator == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						enumerator.Dispose();
					}
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int TotalCallSetCount
		{
			get
			{
				int num = 0;
				IEnumerator<SerializableMember> enumerator = RegisteredMembers.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						SerializableMember current = enumerator.Current;
						num += current.CallSetCount;
					}
					return num;
				}
				finally
				{
					if (enumerator == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						enumerator.Dispose();
					}
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CallGetCount => mintCallGetCount;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double CallGetTime => mdblCallGetTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AvarageGetCallTime
		{
			get
			{
				if (mintCallGetCount == 0)
				{
					return 0.0;
				}
				return mdblCallGetTime / (double)mintCallGetCount;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string CallStats => $"{OwnerType.Name}.{Name}: GetTime:{CallGetTime} GetCalls:{CallGetCount} SetTime:{CallSetTime} SetCalls:{CallSetCount}";

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CallSetCount => mintCallSetCount;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double CallSetTime => mdblCallSetTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AvarageSetCallTime
		{
			get
			{
				if (mintCallSetCount != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mdblCallSetTime / (double)mintCallSetCount;
				}
				return 0.0;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IEnumerable<SerializableMember> RegisteredMembers => mobjMembers;

		internal SerializableMemberMetadata Metadata => mobjMemberMetadata;

		internal bool IsDynamicDefaultValue => mobjMemberMetadata.IsDynamicDefaultValue;

		internal object DefaultValue => Metadata.DefaultValue;

		internal int Index => mintIndex;

		internal string Name => mstrName;

		internal Type OwnerType => mobjOwnerType;

		internal Type MemberType => mobjMemberType;

		internal SerializableMember(int intKey, string strName, Type objMemberType, Type objOwnerType, SerializableMemberMetadata objMemberMetadata)
		{
			mintIndex = intKey;
			mstrName = strName;
			mobjMemberType = objMemberType;
			mobjOwnerType = objOwnerType;
			if (objMemberMetadata != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objMemberMetadata = AutoGenerateMetadata(objMemberType);
			}
			mobjMemberMetadata = objMemberMetadata;
		}

		protected abstract SerializableMemberMetadata AutoGenerateMetadata(Type objMemberType);

		internal static void RegisterMember(SerializableMember objMember)
		{
			mobjMembers.Add(objMember);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetTracing()
		{
			mintCallGetCount = 0;
			mdblCallGetTime = 0.0;
			mintCallSetCount = 0;
			mdblCallSetTime = 0.0;
		}

		public override string ToString()
		{
			return $"{OwnerType.Name}.{Name}";
		}

		internal void RegisterGetCall(long lngTime1, long lngTime2)
		{
			mintCallGetCount++;
			mdblCallGetTime += TimeSpan.FromTicks(lngTime2 - lngTime1).TotalMilliseconds;
		}

		internal void RegisterSetCall(long lngTime1, long lngTime2)
		{
			mintCallSetCount++;
			mdblCallSetTime += TimeSpan.FromTicks(lngTime2 - lngTime1).TotalMilliseconds;
		}

		public bool IsValidValue(object objValue)
		{
			if (objValue == null)
			{
				if (mobjMemberType.IsValueType)
				{
					if (!mobjMemberType.IsGenericType || mobjMemberType.GetGenericTypeDefinition() != NullableType)
					{
						return false;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			else
			{
				if (!mobjMemberType.IsInstanceOfType(objValue))
				{
					return false;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return true;
		}

		protected static int GeneratePropertyId(Type objOwnerType)
		{
			int num = 0;
			lock (mobjCurrentIdByType)
			{
				if (mobjCurrentIdByType.ContainsKey(objOwnerType))
				{
					num = mobjCurrentIdByType[objOwnerType];
					mobjCurrentIdByType[objOwnerType] = num + 1;
				}
				else
				{
					num = GetFirstTypeGeneratedId(objOwnerType);
					mobjCurrentIdByType[objOwnerType] = num + 1;
				}
			}
			return num;
		}

		private static int GetFirstTypeGeneratedId(Type objType)
		{
			if (!(objType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (typeof(SerializableObject).IsAssignableFrom(objType))
				{
					if (!(objType == typeof(SerializableObject)))
					{
						/*OpCode not supported: LdMemberToken*/;
						return 500 + GetFirstTypeGeneratedId(objType.BaseType);
					}
					return 0;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return 0;
		}
	}
}

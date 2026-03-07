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
	public class SerializationWriter
	{
		private object[] A;

		private int B;

		private int C;

		internal SerializationWriter(int intInitialSize)
		{
			C = intInitialSize;
			A = new object[intInitialSize];
		}

		public void WriteInt32(int intValue)
		{
			EnsureCapacity(1);
			A[B] = intValue;
			B++;
		}

		public void WriteInt64(long lngValue)
		{
			EnsureCapacity(1);
			A[B] = lngValue;
			B++;
		}

		public void WriteLong(long lngValue)
		{
			EnsureCapacity(1);
			A[B] = lngValue;
			B++;
		}

		public void WriteBoolean(bool blnValue)
		{
			EnsureCapacity(1);
			A[B] = blnValue;
			B++;
		}

		public void WriteCultureInfo(CultureInfo objCultureInfo)
		{
			if (objCultureInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				WriteInt32(0);
			}
			else
			{
				WriteInt32(objCultureInfo.LCID);
			}
		}

		public void WriteArray(ICollection objCollection)
		{
			if (objCollection == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				WriteInt32(0);
				return;
			}
			int count = objCollection.Count;
			EnsureCapacity(count + 1);
			A[B] = count;
			B++;
			IEnumerator enumerator = objCollection.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					object current = enumerator.Current;
					WriteSerializableObject(current);
					B++;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void WriteDictionary<TKey, TValue>(Dictionary<TKey, TValue> objDictionary)
		{
			if (objDictionary == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				WriteInt32(0);
				return;
			}
			int count = objDictionary.Count;
			EnsureCapacity(count * 2 + 1);
			A[B] = count;
			B++;
			using Dictionary<TKey, TValue>.Enumerator enumerator = objDictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				WriteSerializableObject(current.Key);
				B++;
				WriteSerializableObject(current.Value);
				B++;
			}
		}

		public void WriteHashtable(Hashtable objDictionary)
		{
			if (objDictionary != null)
			{
				int count = objDictionary.Count;
				EnsureCapacity(count * 2 + 1);
				A[B] = count;
				B++;
				IDictionaryEnumerator enumerator = objDictionary.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
						WriteSerializableObject(dictionaryEntry.Key);
						B++;
						WriteSerializableObject(dictionaryEntry.Value);
						B++;
					}
					return;
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
			WriteInt32(0);
		}

		public void WriteNameValueCollection(NameValueCollection objNameValueCollection)
		{
			if (objNameValueCollection == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				WriteInt32(0);
				return;
			}
			int count = objNameValueCollection.Count;
			EnsureCapacity(count * 2 + 1);
			A[B] = count;
			B++;
			for (int i = 0; i < count; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				A[B] = objNameValueCollection.GetKey(i);
				B++;
				A[B] = objNameValueCollection[i];
				B++;
			}
		}

		public void WriteDateTime(DateTime objValue)
		{
			EnsureCapacity(1);
			A[B] = objValue;
			B++;
		}

		public void WriteString(string strValue)
		{
			EnsureCapacity(1);
			A[B] = strValue;
			B++;
		}

		public void WriteObject(object objValue)
		{
			EnsureCapacity(1);
			WriteSerializableObject(objValue);
			B++;
		}

		private string GetDefaultSerializableTypeRseolverString()
		{
			_ = string.Empty;
			return "Gizmox.WebGUI.Forms.SerializableTypeRseolver, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
		}

		private void WriteSerializableObject(object objValue)
		{
			if (SerializableObject.IsSerializedState && objValue != null)
			{
				Type type = objValue.GetType();
				if (type.IsInterface)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (type.IsSerializable && !typeof(MarshalByRefObject).IsAssignableFrom(type))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ISerializableTypeRseolver provider = CommonUtils.GetProvider<ISerializableTypeRseolver>(GetDefaultSerializableTypeRseolverString(), blnIsCache: true);
					if (provider == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						Type serializableType = provider.GetSerializableType(type);
						if (!(serializableType != null))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							objValue = Activator.CreateInstance(serializableType, objValue);
						}
					}
				}
			}
			A[B] = objValue;
		}

		internal object[] SaveData()
		{
			return A;
		}

		private void EnsureCapacity(int intRequiredSpace)
		{
			int num = B + intRequiredSpace;
			if (A.Length >= num)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			int num2;
			if (A.Length == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				num2 = 4;
			}
			else
			{
				num2 = A.Length * 2;
			}
			int num3 = num2;
			if (num3 >= num)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				num3 = num;
			}
			object[] array = new object[num3];
			A.CopyTo(array, 0);
			C = num3;
			A = array;
		}

		public static int GetRequiredCapacity(ICollection objCollection)
		{
			if (objCollection != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 1 + objCollection.Count;
			}
			return 1;
		}

		public static int GetRequiredCapacity(IDictionary objDictionary)
		{
			if (objDictionary == null)
			{
				return 1;
			}
			return 1 + objDictionary.Count * 2;
		}

		public static int GetRequiredCapacity(NameValueCollection objNameValueCollection)
		{
			if (objNameValueCollection != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 1 + objNameValueCollection.Count * 2;
			}
			return 1;
		}
	}
}

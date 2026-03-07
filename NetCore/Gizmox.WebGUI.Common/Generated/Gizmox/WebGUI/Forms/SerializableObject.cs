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
	public class SerializableObject
	{
		private static bool mblnIsSerializedState;

		internal static bool IsSerializationEnabled;

		[NonSerialized]
		private L[] H;

		[NonSerialized]
		private uint I;

		private object[] mobjData;

		protected virtual int SerializableDataInitialSize
		{
			get
			{
				if (I != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					return (int)(2 + I * 2);
				}
				return 1;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual bool IsSerializableObjectInitializing => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual int SerializableFieldStorageInitialSize => 2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool CanRaiseEvents => true;

		internal static bool IsSerializedState => mblnIsSerializedState;

		static SerializableObject()
		{
			mblnIsSerializedState = false;
			IsSerializationEnabled = true;
			try
			{
				HostContext current = HostContext.Current;
				if (current == null)
				{
					return;
				}
				if (current.Session == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				int num;
				if (current.Session.Mode == HostSessionStateMode.InProc)
				{
					/*OpCode not supported: LdMemberToken*/;
					num = 0;
				}
				else
				{
					num = ((current.Session.Mode != HostSessionStateMode.Off) ? 1 : 0);
				}
				mblnIsSerializedState = (byte)num != 0;
			}
			catch
			{
			}
		}

		protected internal void RemoveValue<T>(SerializableProperty objSerializableProperty)
		{
			if (objSerializableProperty != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				ClearField(objSerializableProperty.Index);
				return;
			}
			throw new ArgumentNullException("objSerializableProperty");
		}

		public bool SetValue<T>(SerializableProperty objSerializableProperty, T objValue)
		{
			if (objSerializableProperty != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				long lngTime = 0L;
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					lngTime = DateTime.Now.Ticks;
				}
				bool result = SetField(objSerializableProperty.Index, objValue, objSerializableProperty.DefaultValue);
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					long ticks = DateTime.Now.Ticks;
					objSerializableProperty.RegisterSetCall(lngTime, ticks);
				}
				return result;
			}
			throw new ArgumentNullException("objSerializableProperty");
		}

		public bool SetValue<T>(SerializableProperty objSerializableProperty, T objValue, T objDefaultValue)
		{
			if (objSerializableProperty != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!objSerializableProperty.IsValidValue(objValue))
				{
					throw new ArgumentException($"Value argument is invalid [{objSerializableProperty.OwnerType.FullName}.{objSerializableProperty.Name}].");
				}
				long lngTime = 0L;
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					lngTime = DateTime.Now.Ticks;
				}
				bool result = SetField(objSerializableProperty.Index, objValue, objDefaultValue);
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					long ticks = DateTime.Now.Ticks;
					objSerializableProperty.RegisterSetCall(lngTime, ticks);
				}
				return result;
			}
			throw new ArgumentNullException("objSerializableProperty");
		}

		public T GetValue<T>(SerializableProperty objSerializableProperty, out bool blnFound)
		{
			if (objSerializableProperty != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				long lngTime = 0L;
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					lngTime = DateTime.Now.Ticks;
				}
				K k = FindField(objSerializableProperty.Index);
				T result;
				if (k.Found)
				{
					L field = GetField(k.Index);
					blnFound = true;
					result = (T)field.Value;
				}
				else
				{
					blnFound = false;
					result = (T)objSerializableProperty.DefaultValue;
				}
				if (SerializableMember.TraceMode)
				{
					long ticks = DateTime.Now.Ticks;
					objSerializableProperty.RegisterGetCall(lngTime, ticks);
				}
				return result;
			}
			throw new ArgumentNullException("objSerializableProperty");
		}

		public T GetValue<T>(SerializableProperty objSerializableProperty)
		{
			if (objSerializableProperty != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				long lngTime = 0L;
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					lngTime = DateTime.Now.Ticks;
				}
				K k = FindField(objSerializableProperty.Index);
				T result;
				if (!k.Found)
				{
					/*OpCode not supported: LdMemberToken*/;
					result = (T)objSerializableProperty.DefaultValue;
				}
				else
				{
					result = (T)GetField(k.Index).Value;
				}
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					long ticks = DateTime.Now.Ticks;
					objSerializableProperty.RegisterGetCall(lngTime, ticks);
				}
				return result;
			}
			throw new ArgumentNullException("objSerializableProperty");
		}

		public T GetValue<T>(SerializableProperty objSerializableProperty, out bool blnFound, T objDefault)
		{
			if (objSerializableProperty != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				long lngTime = 0L;
				if (SerializableMember.TraceMode)
				{
					lngTime = DateTime.Now.Ticks;
				}
				K k = FindField(objSerializableProperty.Index);
				T result;
				if (k.Found)
				{
					L field = GetField(k.Index);
					blnFound = true;
					result = (T)field.Value;
				}
				else
				{
					blnFound = false;
					result = objDefault;
				}
				if (!SerializableMember.TraceMode)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					long ticks = DateTime.Now.Ticks;
					objSerializableProperty.RegisterGetCall(lngTime, ticks);
				}
				return result;
			}
			throw new ArgumentNullException("objSerializableProperty");
		}

		public T GetValue<T>(SerializableProperty objSerializableProperty, T objDefault)
		{
			if (objSerializableProperty == null)
			{
				throw new ArgumentNullException("objSerializableProperty");
			}
			long lngTime = 0L;
			if (!SerializableMember.TraceMode)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				lngTime = DateTime.Now.Ticks;
			}
			K k = FindField(objSerializableProperty.Index);
			T result = ((!k.Found) ? objDefault : ((T)GetField(k.Index).Value));
			if (!SerializableMember.TraceMode)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				long ticks = DateTime.Now.Ticks;
				objSerializableProperty.RegisterGetCall(lngTime, ticks);
			}
			return result;
		}

		protected internal bool ContainsValue<T>(SerializableProperty objSerializableProperty)
		{
			return HasField(objSerializableProperty.Index);
		}

		protected internal bool AddHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			return AddHandler(objSerializableEvent.Index, objValue);
		}

		protected internal bool RemoveHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			if (objSerializableEvent == null)
			{
				throw new ArgumentNullException("objSerializableEvent");
			}
			if ((object)objValue != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return RemoveHandler(objSerializableEvent.Index, objValue);
			}
			throw new ArgumentNullException("objValue");
		}

		protected internal Delegate GetHandler(SerializableEvent objSerializableEvent)
		{
			if (objSerializableEvent != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return GetHandler(objSerializableEvent.Index);
			}
			throw new ArgumentNullException("objSerializableEvent");
		}

		protected internal bool HasHandler(SerializableEvent objSerializableEvent)
		{
			return (object)GetHandler(objSerializableEvent) != null;
		}

		private Delegate GetHandler(int intMemberIndex)
		{
			K k = FindField(intMemberIndex);
			if (k.Found)
			{
				L l = H[k.Index];
				return (Delegate)l.Value;
			}
			return null;
		}

		private bool RemoveHandler(int intMemberIndex, Delegate objValue)
		{
			bool result = false;
			K k = FindField(intMemberIndex);
			if (k.Found)
			{
				Delegate obj = (Delegate)H[k.Index].Value;
				if ((object)obj != null)
				{
					obj = Delegate.Remove(obj, objValue);
					if ((object)obj != null)
					{
						/*OpCode not supported: LdMemberToken*/;
						H[k.Index].Value = obj;
					}
					else
					{
						RemoveField(k.Index);
						result = true;
					}
				}
			}
			return result;
		}

		private bool AddHandler(int intMemberIndex, Delegate objValue)
		{
			bool result = false;
			K k = FindField(intMemberIndex);
			if (!k.Found)
			{
				/*OpCode not supported: LdMemberToken*/;
				result = true;
				L objField = new L(intMemberIndex);
				objField.Value = objValue;
				InsertField(objField, k.Index);
			}
			else
			{
				object value = H[k.Index].Value;
				if (value != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					H[k.Index].Value = Delegate.Combine((Delegate)value, objValue);
				}
				else
				{
					H[k.Index].Value = objValue;
				}
			}
			return result;
		}

		private void ClearField(int intMemberIndex)
		{
			K k = FindField(intMemberIndex);
			if (!k.Found)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				RemoveField(k.Index);
			}
		}

		private L GetField(uint intFieldIndex)
		{
			return H[intFieldIndex];
		}

		private bool HasField(int intIndex)
		{
			return FindField(intIndex).Found;
		}

		private bool SetField(int intMemberIndex, object objValue, object objDefaultValue)
		{
			K k = FindField(intMemberIndex);
			if (!object.Equals(objDefaultValue, objValue))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!k.Found)
				{
					/*OpCode not supported: LdMemberToken*/;
					L objField = new L(intMemberIndex);
					objField.Value = objValue;
					InsertField(objField, k.Index);
					return true;
				}
				if (!object.Equals(H[k.Index].Value, objValue))
				{
					H[k.Index].Value = objValue;
					return true;
				}
				return false;
			}
			if (!k.Found)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			RemoveField(k.Index);
			return true;
		}

		private K FindField(int intMemberIndex)
		{
			uint num = 0u;
			uint num2 = I;
			if (num2 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return new K(0u, blnFieldFound: false);
			}
			while (num2 - num > 3)
			{
				uint num3 = (num2 + num) / 2;
				int memberIndex = H[num3].MemberIndex;
				if (intMemberIndex != memberIndex)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (intMemberIndex > memberIndex)
					{
						/*OpCode not supported: LdMemberToken*/;
						num = num3 + 1;
					}
					else
					{
						num2 = num3;
					}
					continue;
				}
				return new K(num3);
			}
			while (true)
			{
				int memberIndex = H[num].MemberIndex;
				if (memberIndex != intMemberIndex)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (memberIndex > intMemberIndex)
					{
						break;
					}
					num++;
					if (num >= num2)
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				return new K(num);
			}
			return new K(num, blnFieldFound: false);
		}

		private void RemoveField(uint intFieldIndex)
		{
			uint i = I;
			Array.Copy(H, intFieldIndex + 1, H, intFieldIndex, i - intFieldIndex - 1);
			i = (I = i - 1);
			H[i] = new L(-1);
		}

		private void InsertField(L objField, uint intFieldIndex)
		{
			uint i = I;
			if (i == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (H == null)
				{
					H = new L[SerializableFieldStorageInitialSize];
				}
				H[0] = objField;
			}
			else if (H.Length != i)
			{
				/*OpCode not supported: LdMemberToken*/;
				Array.Copy(H, intFieldIndex, H, intFieldIndex + 1, i - intFieldIndex);
				H[intFieldIndex] = objField;
			}
			else
			{
				double num = i;
				double num2;
				if (IsSerializableObjectInitializing)
				{
					/*OpCode not supported: LdMemberToken*/;
					num2 = 2.0;
				}
				else
				{
					num2 = 1.2;
				}
				int num3 = (int)(num * num2);
				if (num3 != i)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					num3++;
				}
				_ = SerializableMember.TraceContentMode;
				L[] array = new L[num3];
				Array.Copy(H, 0L, array, 0L, intFieldIndex);
				array[intFieldIndex] = objField;
				Array.Copy(H, intFieldIndex, array, intFieldIndex + 1, i - intFieldIndex);
				H = array;
			}
			I = i + 1;
		}

		[OnDeserialized]
		private void OnSerializableObjectDeserializing(StreamingContext objContext)
		{
			if (!IsSerializationEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			OnSerializableObjectDeserializing(new SerializationReader(mobjData));
			mobjData = null;
			OnSerializableObjectDeserialized();
		}

		[OnSerializing]
		private void OnSerializableObjectSerializing(StreamingContext objContext)
		{
			if (IsSerializationEnabled)
			{
				SerializationWriter serializationWriter = new SerializationWriter(SerializableDataInitialSize);
				OnSerializableObjectSerializing(serializationWriter);
				mobjData = serializationWriter.SaveData();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			if (I == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				objWriter.WriteInt32(0);
				return;
			}
			objWriter.WriteInt32((int)I);
			objWriter.WriteInt32(H.Length);
			for (int i = 0; i < I; i++)
			{
				objWriter.WriteInt32(H[i].MemberIndex);
				objWriter.WriteObject(H[i].Value);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			I = (uint)objReader.ReadInt32();
			if (I != 0)
			{
				int num = objReader.ReadInt32();
				H = new L[num];
				for (int i = 0; i < I; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					H[i] = new L(objReader.ReadInt32(), objReader.ReadObject());
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual void OnSerializableObjectDeserialized()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public long GetCurrentTicks(bool blnIsForceRender)
		{
			if (!blnIsForceRender)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.Now.Ticks;
			}
			return DateTime.Now.Ticks - 10000;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public long GetCurrentTicks()
		{
			return GetCurrentTicks(blnIsForceRender: false);
		}
			protected internal void RemoveValue(SerializableProperty objSerializableProperty) { RemoveValue<object>(objSerializableProperty); }
		public bool SetValue(SerializableProperty objSerializableProperty, object objValue) { return SetValue<object>(objSerializableProperty, objValue); }
		public bool SetValue(SerializableProperty objSerializableProperty, object objValue, object objDefaultValue) { return SetValue<object>(objSerializableProperty, objValue, objDefaultValue); }
		public dynamic GetValue(SerializableProperty objSerializableProperty, out bool blnFound) { return GetValue<object>(objSerializableProperty, out blnFound); }
		public dynamic GetValue(SerializableProperty objSerializableProperty) { return GetValue<object>(objSerializableProperty); }
		public dynamic GetValue(SerializableProperty objSerializableProperty, out bool blnFound, object objDefault) { return GetValue<object>(objSerializableProperty, out blnFound, objDefault); }
		public dynamic GetValue(SerializableProperty objSerializableProperty, object objDefault) { return GetValue<object>(objSerializableProperty, objDefault); }
		protected internal bool ContainsValue(SerializableProperty objSerializableProperty) { return ContainsValue<object>(objSerializableProperty); }
	}
}
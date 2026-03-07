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
	public class KeysConverter : TypeConverter, IComparer
	{
		private ArrayList A;

		private IDictionary B;

		private const Keys C = Keys.A;

		private const Keys D = Keys.D0;

		private const Keys E = Keys.NumPad0;

		private const Keys F = Keys.Z;

		private const Keys G = Keys.D9;

		private const Keys H = Keys.NumPad9;

		private StandardValuesCollection I;

		private ArrayList DisplayOrder
		{
			get
			{
				if (A != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Initialize();
				}
				return A;
			}
		}

		private IDictionary KeyNames
		{
			get
			{
				if (B != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Initialize();
				}
				return B;
			}
		}

		private void AddKey(string key, Keys value)
		{
			B[key] = value;
			A.Add(key);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
		{
			if (!(objSourceType != typeof(string)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (objSourceType != typeof(Enum[]))
				{
					return base.CanConvertFrom(objContext, objSourceType);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return true;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(Enum[]))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public int Compare(object objFirstValue, object objSecondValue)
		{
			return string.Compare(ConvertToString(objFirstValue), ConvertToString(objSecondValue), ignoreCase: false, CultureInfo.InvariantCulture);
		}

		public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
		{
			if (!(objValue is string))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objValue is Enum[])
				{
					/*OpCode not supported: LdMemberToken*/;
					long num = 0L;
					Enum[] array = (Enum[])objValue;
					foreach (Enum value in array)
					{
						num |= Convert.ToInt64(value, CultureInfo.InvariantCulture);
					}
					return Enum.ToObject(typeof(Keys), num);
				}
				return base.ConvertFrom(objContext, objCulture, objValue);
			}
			string text = ((string)objValue).Trim();
			if (text.Length == 0)
			{
				return null;
			}
			string[] array2 = text.Split('+');
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = array2[j].Trim();
			}
			Keys keys = Keys.None;
			bool flag = false;
			for (int k = 0; k < array2.Length; k++)
			{
				/*OpCode not supported: LdMemberToken*/;
				object obj = KeyNames[array2[k]];
				if (obj != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					obj = Enum.Parse(typeof(Keys), array2[k]);
				}
				if (obj != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					Keys keys2 = (Keys)obj;
					if ((keys2 & Keys.KeyCode) == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (flag)
						{
							throw new FormatException(SR.GetString("KeysConverterInvalidKeyCombination"));
						}
						/*OpCode not supported: LdMemberToken*/;
						flag = true;
					}
					keys |= keys2;
					continue;
				}
				throw new FormatException(SR.GetString("KeysConverterInvalidKeyName", array2[k]));
			}
			return keys;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo objCulture, object objValue, Type objDestinationType)
		{
			if (!(objDestinationType == null))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objValue is Keys)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(objValue is int))
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_0319;
				}
				bool flag = objDestinationType == typeof(string);
				bool flag2 = false;
				if (flag)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					flag2 = objDestinationType == typeof(Enum[]);
				}
				if (flag || flag2)
				{
					Keys keys = (Keys)objValue;
					bool flag3 = false;
					ArrayList arrayList = new ArrayList();
					Keys keys2 = keys & Keys.Modifiers;
					for (int i = 0; i < DisplayOrder.Count; i++)
					{
						/*OpCode not supported: LdMemberToken*/;
						string text = DisplayOrder[i].ToString();
						Keys keys3 = (Keys)B[text];
						if ((keys3 & keys2) == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (flag)
						{
							if (flag3)
							{
								arrayList.Add("+");
							}
							arrayList.Add(text);
						}
						else
						{
							arrayList.Add(keys3);
						}
						flag3 = true;
					}
					Keys keys4 = keys & Keys.KeyCode;
					bool flag4 = false;
					if (!(flag3 && flag))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						arrayList.Add("+");
					}
					for (int j = 0; j < DisplayOrder.Count; j++)
					{
						/*OpCode not supported: LdMemberToken*/;
						string text2 = DisplayOrder[j].ToString();
						Keys keys5 = (Keys)B[text2];
						if (!keys5.Equals(keys4))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (!flag)
						{
							/*OpCode not supported: LdMemberToken*/;
							arrayList.Add(keys5);
						}
						else
						{
							arrayList.Add(text2);
						}
						flag3 = true;
						flag4 = true;
						break;
					}
					if (flag4)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!Enum.IsDefined(typeof(Keys), (int)keys4))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!flag)
					{
						/*OpCode not supported: LdMemberToken*/;
						arrayList.Add(keys4);
					}
					else
					{
						arrayList.Add(keys4.ToString());
					}
					if (flag)
					{
						/*OpCode not supported: LdMemberToken*/;
						StringBuilder stringBuilder = new StringBuilder(32);
						{
							IEnumerator enumerator = arrayList.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									/*OpCode not supported: LdMemberToken*/;
									string value = (string)enumerator.Current;
									stringBuilder.Append(value);
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
						return stringBuilder.ToString();
					}
					return (Enum[])arrayList.ToArray(typeof(Enum));
				}
				goto IL_0319;
			}
			throw new ArgumentNullException("destinationType");
			IL_0319:
			return base.ConvertTo(context, objCulture, objValue, objDestinationType);
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if (I != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ArrayList arrayList = new ArrayList();
				IEnumerator enumerator = KeyNames.Values.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						object current = enumerator.Current;
						arrayList.Add(current);
					}
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
				arrayList.Sort(this);
				I = new StandardValuesCollection(arrayList.ToArray());
			}
			return I;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext objContext)
		{
			return false;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext)
		{
			return true;
		}

		private void Initialize()
		{
			B = new Hashtable(34);
			A = new ArrayList(34);
			AddKey(SR.GetString("toStringEnter"), Keys.Enter);
			AddKey("F12", Keys.F12);
			AddKey("F11", Keys.F11);
			AddKey("F10", Keys.F10);
			AddKey(SR.GetString("toStringEnd"), Keys.End);
			AddKey(SR.GetString("toStringControl"), Keys.Control);
			AddKey("F8", Keys.F8);
			AddKey("F9", Keys.F9);
			AddKey(SR.GetString("toStringAlt"), Keys.Alt);
			AddKey("F4", Keys.F4);
			AddKey("F5", Keys.F5);
			AddKey("F6", Keys.F6);
			AddKey("F7", Keys.F7);
			AddKey("F1", Keys.F1);
			AddKey("F2", Keys.F2);
			AddKey("F3", Keys.F3);
			AddKey(SR.GetString("toStringPageDown"), Keys.Next);
			AddKey(SR.GetString("toStringInsert"), Keys.Insert);
			AddKey(SR.GetString("toStringHome"), Keys.Home);
			AddKey(SR.GetString("toStringDelete"), Keys.Delete);
			AddKey(SR.GetString("toStringShift"), Keys.Shift);
			AddKey(SR.GetString("toStringPageUp"), Keys.PageUp);
			AddKey(SR.GetString("toStringBack"), Keys.Back);
			AddKey("0", Keys.D0);
			AddKey("1", Keys.D1);
			AddKey("2", Keys.D2);
			AddKey("3", Keys.D3);
			AddKey("4", Keys.D4);
			AddKey("5", Keys.D5);
			AddKey("6", Keys.D6);
			AddKey("7", Keys.D7);
			AddKey("8", Keys.D8);
			AddKey("9", Keys.D9);
		}
	}
}

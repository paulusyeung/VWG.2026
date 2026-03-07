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

namespace Gizmox.WebGUI.Forms.Serialization
{
	[Serializable]
	public struct SerializableBitVector32
	{
		[Serializable]
		public struct Section
		{
			private readonly short mask;

			private readonly short offset;

			public short Mask => mask;

			public short Offset => offset;

			internal Section(short mask, short offset)
			{
				this.mask = mask;
				this.offset = offset;
			}

			public override bool Equals(object o)
			{
				if (o is Section)
				{
					return Equals((Section)o);
				}
				return false;
			}

			public bool Equals(Section obj)
			{
				if (obj.mask != mask)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return obj.offset == offset;
			}

			public static bool operator ==(Section a, Section b)
			{
				return a.Equals(b);
			}

			public static bool operator !=(Section a, Section b)
			{
				return !(a == b);
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public static string ToString(Section value)
			{
				return "Section{0x" + Convert.ToString(value.Mask, 16) + ", 0x" + Convert.ToString(value.Offset, 16) + "}";
			}

			public override string ToString()
			{
				return ToString(this);
			}
		}

		private uint data;

		public bool this[int bit]
		{
			get
			{
				return (data & bit) == bit;
			}
			set
			{
				if (!value)
				{
					/*OpCode not supported: LdMemberToken*/;
					data &= (uint)(~bit);
				}
				else
				{
					data |= (uint)bit;
				}
			}
		}

		public int this[Section section]
		{
			get
			{
				return (int)((data & (section.Mask << (section.Offset & 0x1F))) >> (section.Offset & 0x1F));
			}
			set
			{
				value <<= (int)section.Offset;
				int num = (0xFFFF & section.Mask) << (int)section.Offset;
				data = (uint)((data & ~num) | (value & num));
			}
		}

		public int Data => (int)data;

		public SerializableBitVector32(int data)
		{
			this.data = (uint)data;
		}

		public SerializableBitVector32(SerializableBitVector32 value)
		{
			data = value.data;
		}

		private static short CountBitsSet(short mask)
		{
			short num = 0;
			while ((mask & 1) != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				num++;
				mask >>= 1;
			}
			return num;
		}

		public static int CreateMask()
		{
			return CreateMask(0);
		}

		public static int CreateMask(int previous)
		{
			if (previous != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (previous == int.MinValue)
				{
					throw new InvalidOperationException(SR.GetString("BitVectorFull"));
				}
				return previous << 1;
			}
			return 1;
		}

		private static short CreateMaskFromHighValue(short highValue)
		{
			short num = 16;
			while ((highValue & 0x8000) == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				num--;
				highValue <<= 1;
			}
			ushort num2 = 0;
			while (num > 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				num--;
				num2 <<= 1;
				num2 |= 1;
			}
			return (short)num2;
		}

		public static Section CreateSection(short maxValue)
		{
			return CreateSectionHelper(maxValue, 0, 0);
		}

		public static Section CreateSection(short maxValue, Section previous)
		{
			return CreateSectionHelper(maxValue, previous.Mask, previous.Offset);
		}

		private static Section CreateSectionHelper(short maxValue, short priorMask, short priorOffset)
		{
			if (maxValue >= 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				short num = (short)(priorOffset + CountBitsSet(priorMask));
				if (num < 32)
				{
					/*OpCode not supported: LdMemberToken*/;
					return new Section(CreateMaskFromHighValue(maxValue), num);
				}
				throw new InvalidOperationException(SR.GetString("BitVectorFull"));
			}
			throw new ArgumentException(SR.GetString("Argument_InvalidValue", "maxValue", 0), "maxValue");
		}

		public override bool Equals(object o)
		{
			if (o is SerializableBitVector32)
			{
				return data == ((SerializableBitVector32)o).data;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static string ToString(SerializableBitVector32 value)
		{
			StringBuilder stringBuilder = new StringBuilder(45);
			stringBuilder.Append("SerializableBitVector32{");
			int num = (int)value.data;
			for (int i = 0; i < 32; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				if ((num & 0x80000000u) == 0L)
				{
					/*OpCode not supported: LdMemberToken*/;
					stringBuilder.Append("0");
				}
				else
				{
					stringBuilder.Append("1");
				}
				num <<= 1;
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public override string ToString()
		{
			return ToString(this);
		}
	}
}

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

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	[TypeConverter(typeof(FileContentConverter))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class FileContent : Stream
	{
		public class FileContentConverter : TypeConverter
		{
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				if (!(destinationType == typeof(MemoryStream)))
				{
					/*OpCode not supported: LdMemberToken*/;
					return base.CanConvertTo(context, destinationType);
				}
				return true;
			}

			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (!(destinationType == typeof(MemoryStream)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (value is FileContent fileContent)
				{
					return fileContent.IndexStream;
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}

		internal class NB : Stream
		{
			private Stream A;

			public override bool CanRead => A.CanRead;

			public override bool CanSeek => A.CanSeek;

			public override bool CanWrite => false;

			public override long Length => A.Length;

			public override long Position
			{
				get
				{
					return A.Position;
				}
				set
				{
					A.Position = value;
				}
			}

			public NB(Stream objStream)
			{
				A = objStream;
			}

			public override void Flush()
			{
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				return A.Read(buffer, offset, count);
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				return A.Seek(offset, origin);
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}
		}

		internal MemoryStream mobjIndexStream;

		[NonSerialized]
		private bool C;

		[NonSerialized]
		private bool D;

		[NonSerialized]
		private bool E;

		[NonSerialized]
		private BinaryWriter F;

		[NonSerialized]
		private readonly string G = "";

		private BinaryWriter Writer
		{
			get
			{
				if (F != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CheckWrite();
					F = new BinaryWriter(this);
				}
				return F;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		private Stream IndexStream
		{
			get
			{
				if (mobjIndexStream != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjIndexStream = new MemoryStream();
				}
				return mobjIndexStream;
			}
		}

		public override bool CanRead => IndexStream.CanRead;

		public override bool CanSeek => IndexStream.CanSeek;

		public override bool CanWrite
		{
			get
			{
				if (!C)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return IndexStream.CanWrite;
			}
		}

		public override long Length => IndexStream.Length;

		public override long Position
		{
			get
			{
				return IndexStream.Position;
			}
			set
			{
				IndexStream.Position = value;
			}
		}

		public string FileName => G;

		public FileContent(Stream objStream)
		{
			try
			{
				if (objStream != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(objStream is FileStream fileStream))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						G = fileStream.Name;
					}
					NB objStream2 = new NB(objStream);
					IntializeForLoading();
					ResetStreamPositionIfNeeded(objStream2);
					LoadProperties(objStream2);
					ResetStreamPositionIfNeeded(objStream2);
					LoadIndexes(objStream2);
					ResetStreamPositionIfNeeded(objStream2);
					LoadContent(objStream2);
					TerminateLoading();
					if (F == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						F.Flush();
					}
					return;
				}
				throw new ArgumentNullException("objStream", "Stream cannot be null.");
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		protected virtual void LoadProperties(Stream objStream)
		{
			WriteProperty(FileProperty.ContentLength, objStream.Length);
		}

		protected virtual void LoadIndexes(Stream objStream)
		{
		}

		protected virtual void LoadContent(Stream objStream)
		{
			byte[] array = new byte[objStream.Length];
			objStream.Read(array, 0, array.Length);
			WriteContent(array);
		}

		internal virtual void DumpTokens(Stream strOutput, Stream objContent)
		{
			throw new NotSupportedException("Tokens can only be dumped in TextContent based streams.");
		}

		protected void WriteProperty(FileProperty enmProperty, short intPropertyValue)
		{
			CheckWriteProperty();
			Writer.Write((int)enmProperty);
			Writer.Write(1);
			Writer.Write(intPropertyValue);
		}

		protected void WriteProperty(FileProperty enmProperty, int intPropertyValue)
		{
			CheckWriteProperty();
			Writer.Write((int)enmProperty);
			Writer.Write(2);
			Writer.Write(intPropertyValue);
		}

		protected void WriteProperty(FileProperty enmProperty, long intPropertyValue)
		{
			CheckWriteProperty();
			Writer.Write((int)enmProperty);
			Writer.Write(3);
			Writer.Write(intPropertyValue);
		}

		protected void WriteProperty(FileProperty enmProperty, string strPropertyValue)
		{
			CheckWriteProperty();
			Writer.Write((int)enmProperty);
			Writer.Write(4);
			Writer.Write(strPropertyValue);
		}

		protected void WriteProperty(FileProperty enmProperty, bool blnPropertyValue)
		{
			CheckWriteProperty();
			Writer.Write((int)enmProperty);
			Writer.Write(6);
			Writer.Write(blnPropertyValue);
		}

		protected void WriteProperty(FileProperty enmProperty, byte bytPropertyValue)
		{
			CheckWriteProperty();
			Writer.Write((int)enmProperty);
			Writer.Write(5);
			Writer.Write(bytPropertyValue);
		}

		private void WriteContent(byte[] arrBuffer)
		{
			CheckWriteContent();
			ClosePropertyWriteIfNeeded();
			CloseIndexesWriteIfNeeded();
			Writer.Write(arrBuffer);
			CloseWrite();
		}

		protected void WriteIndex(FileIndexType enmIndexType, int intStart, int intLength)
		{
			CheckWriteIndex();
			ClosePropertyWriteIfNeeded();
			Writer.Write((int)enmIndexType);
			Writer.Write(intStart);
			Writer.Write(intLength);
		}

		private void IntializeForLoading()
		{
			C = true;
			D = true;
			E = true;
		}

		private void TerminateLoading()
		{
			ClosePropertyWriteIfNeeded();
			CloseIndexesWriteIfNeeded();
			CloseWriteIfNeeded();
		}

		private void CloseIndexesWriteIfNeeded()
		{
			if (D)
			{
				CloseIndexesWrite();
			}
		}

		private void CloseIndexesWrite()
		{
			if (D)
			{
				D = false;
				Writer.Write(0);
			}
		}

		private void CloseWriteIfNeeded()
		{
			if (C)
			{
				CloseWrite();
			}
		}

		private void CloseWrite()
		{
			if (C)
			{
				C = false;
			}
		}

		private void ClosePropertyWrite()
		{
			if (E)
			{
				E = false;
				Writer.Write(0);
			}
		}

		private void ClosePropertyWriteIfNeeded()
		{
			if (E)
			{
				ClosePropertyWrite();
			}
		}

		private void CheckWriteIndex()
		{
			if (!D)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (C)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			throw new Exception("Cannot write indexes in this context.");
		}

		private void CheckWriteContent()
		{
			if (C)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			throw new Exception("Cannot write properties in this context.");
		}

		private void CheckWriteProperty()
		{
			if (!E)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (C)
			{
				return;
			}
			throw new Exception("Cannot write properties in this context.");
		}

		private void CheckWrite()
		{
			if (!C)
			{
				throw new Exception("Cannot write in this context.");
			}
		}

		protected void ResetStreamPositionIfNeeded(Stream objStream)
		{
			if (objStream.Position != 0L)
			{
				objStream.Position = 0L;
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return IndexStream.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return IndexStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			IndexStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			IndexStream.Write(buffer, offset, count);
		}

		public override void Flush()
		{
			IndexStream.Flush();
		}
	}
}

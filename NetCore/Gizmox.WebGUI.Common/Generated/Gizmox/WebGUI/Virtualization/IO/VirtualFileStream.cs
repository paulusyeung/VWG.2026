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

namespace Gizmox.WebGUI.Virtualization.IO
{
	public class VirtualFileStream : Stream
	{
		private VirtualReference A;

		private Stream B;

		private string C = string.Empty;

		private FileMode D = FileMode.CreateNew;

		private FileAccess E = FileAccess.ReadWrite;

		private FileShare F;

		private bool G;

		private bool H;

		private int I = 1024;

		private FileOptions J;

		private FileSecurity K;

		private FileSystemRights L = FileSystemRights.FullControl;

		private bool M;

		public override bool CanRead => NodeStream.CanRead;

		public override bool CanSeek => NodeStream.CanSeek;

		public override bool CanWrite => NodeStream.CanWrite;

		public virtual bool IsAsync => G;

		public override long Length => NodeStream.Length;

		public string Name
		{
			get
			{
				if (!string.IsNullOrEmpty(C))
				{
					return Path.GetFileName(C);
				}
				return string.Empty;
			}
		}

		public override long Position
		{
			get
			{
				return NodeStream.Position;
			}
			set
			{
				NodeStream.Position = value;
			}
		}

		internal Stream NodeStream
		{
			get
			{
				if (B != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					B = global::A.H.ReadContentStream(this, D);
					if (B == null)
					{
						throw new FileNotFoundException();
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return B;
			}
		}

		internal VirtualReference Reference
		{
			get
			{
				if (A != null)
				{
					return A;
				}
				return global::A.H.GetFileReference(C);
			}
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode enmAccessMode)
		{
			A = objVirtualReference;
			D = enmAccessMode;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode)
		{
			C = path;
			D = mode;
			OpenFile();
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode mode, FileAccess access)
		{
			A = objVirtualReference;
			E = access;
			D = mode;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode, FileAccess access)
		{
			C = path;
			E = access;
			D = mode;
			OpenFile();
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode mode, FileAccess access, FileShare share)
		{
			A = objVirtualReference;
			E = access;
			D = mode;
			F = share;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode, FileAccess access, FileShare share)
		{
			C = path;
			D = mode;
			F = share;
			E = access;
			OpenFile();
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode mode, FileAccess access, FileShare share, int bufferSize)
		{
			A = objVirtualReference;
			E = access;
			D = mode;
			F = share;
			I = bufferSize;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
		{
			C = path;
			D = mode;
			F = share;
			E = access;
			I = bufferSize;
			OpenFile();
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
		{
			A = objVirtualReference;
			E = access;
			D = mode;
			F = share;
			I = bufferSize;
			G = useAsync;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
		{
			C = path;
			D = mode;
			F = share;
			E = access;
			I = bufferSize;
			G = useAsync;
			OpenFile();
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options)
		{
			A = objVirtualReference;
			E = access;
			D = mode;
			F = share;
			I = bufferSize;
			J = options;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options)
		{
			C = path;
			D = mode;
			F = share;
			E = access;
			I = bufferSize;
			J = options;
			I = bufferSize;
			OpenFile();
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options)
		{
			A = objVirtualReference;
			D = mode;
			F = share;
			I = bufferSize;
			J = options;
			L = rights;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options)
		{
			C = path;
			D = mode;
			F = share;
			I = bufferSize;
			J = options;
			L = rights;
			OpenFile();
		}

		internal VirtualFileStream(VirtualReference objVirtualReference, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options, FileSecurity fileSecurity)
		{
			A = objVirtualReference;
			D = mode;
			F = share;
			I = bufferSize;
			J = options;
			L = rights;
			K = fileSecurity;
			OpenFile();
		}

		public VirtualFileStream(string path, FileMode mode, FileSystemRights rights, FileShare share, int bufferSize, FileOptions options, FileSecurity fileSecurity)
		{
			C = path;
			D = mode;
			F = share;
			I = bufferSize;
			J = options;
			L = rights;
			K = fileSecurity;
			OpenFile();
		}

		private void OpenFile()
		{
			global::A.H.OpenFile(Reference, new G(J, E, F, D, L, K, blnThrowExceptions: true));
		}

		public override IAsyncResult BeginRead(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject)
		{
			return NodeStream.BeginRead(array, offset, numBytes, userCallback, stateObject);
		}

		public override IAsyncResult BeginWrite(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject)
		{
			SetDirty();
			return NodeStream.BeginWrite(array, offset, numBytes, userCallback, stateObject);
		}

		private void SetDirty()
		{
			if (H)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				H = true;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (B == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					B.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			return NodeStream.EndRead(asyncResult);
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			NodeStream.EndWrite(asyncResult);
		}

		public override void Flush()
		{
			NodeStream.Flush();
		}

		public FileSecurity GetAccessControl()
		{
			throw new NotImplementedException();
		}

		public virtual void Lock(long position, long length)
		{
		}

		public override int Read(byte[] array, int offset, int count)
		{
			return NodeStream.Read(array, offset, count);
		}

		public override int ReadByte()
		{
			return NodeStream.ReadByte();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return Seek(offset, origin);
		}

		public void SetAccessControl(FileSecurity fileSecurity)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			SetDirty();
			NodeStream.SetLength(value);
		}

		public virtual void Unlock(long position, long length)
		{
		}

		public override void Write(byte[] array, int offset, int count)
		{
			SetDirty();
			NodeStream.Write(array, offset, count);
		}

		public override void WriteByte(byte value)
		{
			SetDirty();
			NodeStream.WriteByte(value);
		}

		public override void Close()
		{
			try
			{
				if (!M)
				{
					M = true;
					if (!H)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						global::A.H.SetFileStream(this);
					}
				}
			}
			finally
			{
				if (B == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					B.Close();
				}
				base.Close();
			}
		}
	}
}

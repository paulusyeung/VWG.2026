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
	public class FileIndex
	{
		internal class GB
		{
			private readonly FileIndexType A;

			private readonly int B;

			private readonly int C;

			public FileIndexType Type => A;

			public int Index => C;

			public int Length => B;

			public GB(FileIndexType enmType, int intIndex, int intLength)
			{
				A = enmType;
				C = intIndex;
				B = intLength;
			}
		}

		internal class HB : GB
		{
			private readonly string D;

			public string Content => D;

			public HB(GB objFileIndex, string strContent)
				: base(objFileIndex.Type, objFileIndex.Index, objFileIndex.Length)
			{
				D = strContent;
			}
		}

		private Dictionary<FileProperty, object> A;

		private GB[] B;

		private int C = -1;

		private byte[] D;

		private Stream E;

		private bool F;

		internal virtual bool IsCompileEnabled => false;

		internal GB[] Indexes => B;

		public Stream ContentStream => new MemoryStream(Content, writable: false);

		public byte[] Content
		{
			get
			{
				if (!F)
				{
					if (!UseContentCache)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (D != null)
						{
							return D;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					byte[] array = new byte[ContentLength];
					E.Position = C;
					E.Read(array, 0, array.Length);
					if (!UseContentCache)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						D = array;
					}
					return array;
				}
				return new byte[0];
			}
		}

		protected virtual bool UseContentCache => false;

		public int ContentLength => (int)ReadProperty(FileProperty.ContentLength, 0L);

		public FileIndex(Stream objContentStream)
		{
			if (objContentStream != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				E = objContentStream;
				F = E.Length == 0;
				BinaryReader objReader = new BinaryReader(objContentStream);
				ResetPositionIfNeeded(objContentStream);
				ReadProperties(objReader);
				ReadIndexes(objReader);
				ReadContentPosition(objContentStream);
				ReadCompilerIndexes(objContentStream);
				return;
			}
			throw new ArgumentNullException("objContentStream");
		}

		internal virtual void WriteContent(SkinScope objSkinScope, Stream objStream, BB objCollector)
		{
			byte[] content = Content;
			objStream.Write(content, 0, content.Length);
		}

		internal virtual void WriteContent(SkinScope objSkinScope, StreamWriter objStreamWriter, BB objCollector)
		{
			throw new NotSupportedException("Writing to a stream writer is only supported in TextIndex inherited indexes.");
		}

		public void DumpTokens(string strPath)
		{
			if (!File.Exists(strPath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				File.Delete(strPath);
			}
			DumpTokens(File.OpenWrite(strPath));
		}

		public void DumpTokens(Stream objOutput)
		{
			if (E is FileContent fileContent)
			{
				fileContent.DumpTokens(objOutput, ContentStream);
				return;
			}
			throw new NotSupportedException("Dumping tokens requires a FileContent as the content stream.");
		}

		public void DumpIndexes(string strPath)
		{
			if (!File.Exists(strPath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				File.Delete(strPath);
			}
			DumpIndexes(File.OpenWrite(strPath));
		}

		public virtual void DumpIndexes(Stream objStream)
		{
			byte[] content = Content;
			objStream.Write(content, 0, content.Length);
			objStream.Flush();
		}

		public void DumpContent(Stream objStream)
		{
			if (Content.Length == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			byte[] content = Content;
			objStream.Write(content, 0, content.Length);
		}

		private void ReadContentPosition(Stream objContentStream)
		{
			if (F)
			{
				/*OpCode not supported: LdMemberToken*/;
				C = -1;
			}
			else
			{
				C = (int)objContentStream.Position;
			}
		}

		private void ReadProperties(BinaryReader objReader)
		{
			A = new Dictionary<FileProperty, object>();
			if (!F)
			{
				while (ReadProperty(objReader))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
			}
		}

		private bool ReadProperty(BinaryReader objReader)
		{
			FileProperty fileProperty = (FileProperty)objReader.ReadInt32();
			if (fileProperty != FileProperty.Null)
			{
				switch ((FilePropertyType)objReader.ReadInt32())
				{
				case FilePropertyType.Boolean:
					A[fileProperty] = objReader.ReadBoolean();
					break;
				case FilePropertyType.Byte:
					A[fileProperty] = objReader.ReadByte();
					break;
				case FilePropertyType.Int16:
					A[fileProperty] = objReader.ReadInt16();
					break;
				case FilePropertyType.Int32:
					A[fileProperty] = objReader.ReadInt32();
					break;
				case FilePropertyType.Int64:
					A[fileProperty] = objReader.ReadInt64();
					break;
				case FilePropertyType.String:
					A[fileProperty] = objReader.ReadString();
					break;
				default:
					throw new Exception("Unhandled file property type encountered.");
				}
				return true;
			}
			return false;
		}

		private void ReadIndexes(BinaryReader objReader)
		{
			List<GB> list = new List<GB>();
			if (F)
			{
				/*OpCode not supported: LdMemberToken*/;
				B = new GB[0];
				return;
			}
			try
			{
				while (ReadIndex(objReader, list))
				{
				}
			}
			finally
			{
				B = list.ToArray();
			}
		}

		private void ReadCompilerIndexes(Stream objContentStream)
		{
			if (!SkinFactory.IsCompilerEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!IsCompileEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ReadCompilerIndexes(new StreamReader(objContentStream));
			}
		}

		protected virtual void ReadCompilerIndexes(StreamReader objStreamReader)
		{
		}

		protected void ReadCompilerIndex(int intIndexIndex, string strContent)
		{
			if (B.Length <= intIndexIndex)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (intIndexIndex < 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				B[intIndexIndex] = new HB(B[intIndexIndex], strContent);
			}
		}

		private bool ReadIndex(BinaryReader objReader, List<GB> objEntries)
		{
			FileIndexType fileIndexType = (FileIndexType)objReader.ReadInt32();
			if (fileIndexType != FileIndexType.Null)
			{
				int intIndex = objReader.ReadInt32();
				int intLength = objReader.ReadInt32();
				objEntries.Add(new GB(fileIndexType, intIndex, intLength));
				return true;
			}
			return false;
		}

		private void ResetPositionIfNeeded(Stream objContentStream)
		{
			if (F)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objContentStream.Position == 0L)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objContentStream.Position = 0L;
			}
		}

		protected long ReadProperty(FileProperty enmFileProperty, long lngDefaultValue)
		{
			object obj = ReadProperty(enmFileProperty);
			if (!(obj is long))
			{
				/*OpCode not supported: LdMemberToken*/;
				return lngDefaultValue;
			}
			return (long)obj;
		}

		protected int ReadProperty(FileProperty enmFileProperty, int intDefaultValue)
		{
			object obj = ReadProperty(enmFileProperty);
			if (!(obj is int))
			{
				/*OpCode not supported: LdMemberToken*/;
				return intDefaultValue;
			}
			return (int)obj;
		}

		protected object ReadProperty(FileProperty enmFileProperty)
		{
			if (A == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (A.ContainsKey(enmFileProperty))
			{
				return A[enmFileProperty];
			}
			return null;
		}

		internal virtual void Compile(MB objSkinScope)
		{
		}
	}
}

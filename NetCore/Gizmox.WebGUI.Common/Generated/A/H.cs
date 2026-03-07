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

namespace A
{
	internal static class H
	{
		internal static readonly Guid A = new Guid("49567684-7741-434d-9C83-5B4F076957B2");

		internal static readonly Guid B = new Guid("E7422628-10A0-4817-99DB-DF333F0A5E19");

		internal static readonly Guid C = new Guid("1F2BACF8-D142-4203-91D4-234505858C6F");

		private static string FileNotFoundErrorMessage => "Could not find file in virtual file system.";

		internal static VirtualDirectoryInfo CreateDirectory(string directoryPath)
		{
			return CreateDirectory(directoryPath, null);
		}

		internal static VirtualDirectoryInfo CreateDirectory(string directoryPath, DirectorySecurity directorySecurity)
		{
			string[] array = directoryPath.Split('\\');
			string strName = array[array.Length - 1];
			string directoryPath2 = string.Join("\\", array, 0, array.Length - 1);
			VirtualNode virtualNode = F.Current.Create(GetDirectoryReference(directoryPath2), strName, C);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualDirectoryInfo(virtualNode);
		}

		internal static VirtualDirectoryInfo CreateSubdirectory(VirtualDirectoryInfo virtualDirectoryInfo, string path)
		{
			return CreateSubdirectory(virtualDirectoryInfo, path, null);
		}

		internal static VirtualDirectoryInfo CreateSubdirectory(VirtualDirectoryInfo virtualDirectoryInfo, string path, DirectorySecurity directorySecurity)
		{
			VirtualNode virtualNode = F.Current.Create(GetDirectoryReference(virtualDirectoryInfo), GetSafeDirectoryPath(path), C);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualDirectoryInfo(virtualNode);
		}

		internal static void DeleteDirectory(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			F.Current.Delete(virtualDirectoryInfo.Reference);
		}

		internal static void DeleteDirectory(VirtualDirectoryInfo virtualDirectoryInfo, bool recursive)
		{
			F.Current.Delete(virtualDirectoryInfo.Reference);
		}

		internal static void DeleteDirectory(string directoryPath)
		{
			F.Current.Delete(new VirtualReference(VirtualForest.Default.Id, GetSafeDirectoryPath(directoryPath), C));
		}

		internal static void DeleteDirectory(string directoryPath, bool recursive)
		{
			F.Current.Delete(new VirtualReference(VirtualForest.Default.Id, GetSafeDirectoryPath(directoryPath), C));
		}

		internal static bool GetDirectoryExists(string directoryPath)
		{
			if (OpenDirectory(directoryPath) != null)
			{
				return true;
			}
			return false;
		}

		internal static VirtualNode OpenDirectory(string strDirectoryPath)
		{
			return OpenDirectory(GetDirectoryReference(strDirectoryPath));
		}

		internal static VirtualNode OpenDirectory(VirtualReference objDirectoryReference)
		{
			return F.Current.Read(objDirectoryReference);
		}

		internal static VirtualNode OpenDirectory(VirtualDirectoryInfo objVirtualDirectoryInfo)
		{
			return OpenDirectory(objVirtualDirectoryInfo.Reference);
		}

		internal static bool GetDirectoryExists(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			if (OpenDirectory(virtualDirectoryInfo) == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return true;
		}

		internal static DateTime GetDirectoryCreationTime(string directoryPath)
		{
			return OpenDirectory(directoryPath)?.CreatedOn ?? DateTime.MinValue;
		}

		internal static DateTime GetDirectoryCreationTimeUtc(string directoryPath)
		{
			VirtualNode virtualNode = OpenDirectory(directoryPath);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.CreatedOn;
		}

		internal static string[] GetDirectories(string directoryPath)
		{
			return GetDirectories(directoryPath, string.Empty, SearchOption.AllDirectories);
		}

		internal static string[] GetDirectories(string directoryPath, string searchPattern)
		{
			return GetDirectories(directoryPath, searchPattern, SearchOption.AllDirectories);
		}

		internal static string[] GetDirectories(string directoryPath, string searchPattern, SearchOption searchOption)
		{
			List<string> list = new List<string>();
			VirtualNode[] array = F.Current.ReadList(GetDirectoryReference(directoryPath), C, Guid.Empty);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode virtualNode = array2[i];
					list.Add(virtualNode.Name);
				}
			}
			return list.ToArray();
		}

		internal static VirtualDirectoryInfo[] GetDirectories(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			return GetDirectories(virtualDirectoryInfo, string.Empty, SearchOption.AllDirectories);
		}

		internal static VirtualDirectoryInfo[] GetDirectories(VirtualDirectoryInfo virtualDirectoryInfo, string searchPattern)
		{
			return GetDirectories(virtualDirectoryInfo, searchPattern, SearchOption.AllDirectories);
		}

		internal static VirtualDirectoryInfo[] GetDirectories(VirtualDirectoryInfo virtualDirectoryInfo, string searchPattern, SearchOption searchOption)
		{
			List<VirtualDirectoryInfo> list = new List<VirtualDirectoryInfo>();
			VirtualNode[] array = F.Current.ReadList(GetDirectoryReference(virtualDirectoryInfo), C, Guid.Empty);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode objVirtualNode = array2[i];
					list.Add(new VirtualDirectoryInfo(objVirtualNode));
				}
			}
			return list.ToArray();
		}

		internal static VirtualFileInfo[] GetDirectoryFiles(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			return GetDirectoryFiles(virtualDirectoryInfo, string.Empty, SearchOption.AllDirectories);
		}

		internal static VirtualFileInfo[] GetDirectoryFiles(VirtualDirectoryInfo virtualDirectoryInfo, string searchPattern)
		{
			return GetDirectoryFiles(virtualDirectoryInfo, searchPattern, SearchOption.AllDirectories);
		}

		internal static VirtualFileInfo[] GetDirectoryFiles(VirtualDirectoryInfo virtualDirectoryInfo, string searchPattern, SearchOption searchOption)
		{
			List<VirtualFileInfo> list = new List<VirtualFileInfo>();
			VirtualNode[] array = F.Current.ReadList(GetDirectoryReference(virtualDirectoryInfo), A, Guid.Empty, searchPattern);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode objVirtualNode = array2[i];
					list.Add(new VirtualFileInfo(objVirtualNode));
				}
			}
			return list.ToArray();
		}

		internal static string GetDirectoryRoot(string directoryPath)
		{
			return Path.GetPathRoot(directoryPath);
		}

		internal static VirtualDirectoryInfo GetDirectoryRoot(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			VirtualNode virtualNode = F.Current.ReadRoot(GetDirectoryReference(virtualDirectoryInfo));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualDirectoryInfo(virtualNode);
		}

		internal static string[] GetDirectoryFiles(string directoryPath)
		{
			return GetDirectoryFiles(directoryPath, string.Empty, SearchOption.AllDirectories);
		}

		internal static string[] GetDirectoryFiles(string directoryPath, string searchPattern)
		{
			return GetDirectoryFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
		}

		internal static string[] GetDirectoryFiles(string directoryPath, string searchPattern, SearchOption searchOption)
		{
			List<string> list = new List<string>();
			VirtualNode[] array = F.Current.ReadList(GetDirectoryReference(directoryPath), A, Guid.Empty, searchPattern);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode virtualNode = array2[i];
					list.Add(virtualNode.Name);
				}
			}
			return list.ToArray();
		}

		internal static DateTime GetDirectoryLastAccessTime(string directoryPath)
		{
			VirtualNode virtualNode = OpenDirectory(directoryPath);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.UpdatedOn;
		}

		internal static DateTime GetDirectoryLastAccessTimeUtc(string directoryPath)
		{
			VirtualNode virtualNode = OpenDirectory(directoryPath);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.UpdatedOn;
		}

		internal static DateTime GetDirectoryLastWriteTime(string directoryPath)
		{
			return OpenDirectory(directoryPath)?.UpdatedOn ?? DateTime.MinValue;
		}

		internal static DateTime GetDirectoryLastWriteTimeUtc(string directoryPath)
		{
			VirtualNode virtualNode = OpenDirectory(directoryPath);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.UpdatedOn;
		}

		internal static VirtualDirectoryInfo GetDirectoryParent(string directoryPath)
		{
			VirtualNode virtualNode = F.Current.ReadParent(GetDirectoryReference(directoryPath));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualDirectoryInfo(virtualNode);
		}

		internal static VirtualDirectoryInfo GetDirectoryParent(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			VirtualNode virtualNode = F.Current.ReadParent(GetDirectoryReference(virtualDirectoryInfo));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualDirectoryInfo(virtualNode);
		}

		internal static void MoveDirectory(string sourceDirectoryName, string destDirectoryName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetDirectoryCreationTime(string directoryPath, DateTime creationTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetDirectoryCreationTimeUtc(string directoryPath, DateTime creationTimeUtc)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetDirectoryLastAccessTime(string path, DateTime lastAccessTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetDirectoryLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetDirectoryLastWriteTime(string path, DateTime lastWriteTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetDirectoryLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static VirtualDirectoryInfo GetDirectory(VirtualFileInfo virtualFileInfo)
		{
			VirtualNode virtualNode = F.Current.ReadParent(GetFileReference(virtualFileInfo));
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualDirectoryInfo(virtualNode);
		}

		internal static string GetDirectoryName(VirtualFileInfo virtualFileInfo)
		{
			return F.Current.ReadPath(GetFileReference(virtualFileInfo));
		}

		internal static void SetDirectoryAccessControl(string path, DirectorySecurity directorySecurity)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetDirectoryAccessControl(VirtualDirectoryInfo virtualDirectoryInfo, DirectorySecurity directorySecurity)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void MoveDirectoryTo(VirtualDirectoryInfo virtualDirectoryInfo, string destDirName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static VirtualDirectoryInfo GetRootDirectory(VirtualDriveInfo virtualDriveInfo)
		{
			VirtualNode virtualNode = virtualDriveInfo.Node;
			if (virtualNode != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				virtualNode = (virtualDriveInfo.Node = OpenDirectory(virtualDriveInfo.Reference));
			}
			if (virtualNode != null)
			{
				return new VirtualDirectoryInfo(virtualNode);
			}
			return null;
		}

		internal static VirtualFileStream CreateFile(string path)
		{
			return CreateFile(GetFileReference(path, includeFileName: false), Path.GetFileName(path), FileMode.OpenOrCreate);
		}

		internal static VirtualFileStream CreateFile(VirtualReference objVirtualReference, string strFileName, FileMode enmFileMode)
		{
			VirtualNode virtualNode = F.Current.Create(objVirtualReference, strFileName, A);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualFileStream(virtualNode.Reference, enmFileMode);
		}

		internal static StreamWriter CreateTextFile(string path)
		{
			Stream fileStream = GetFileStream(path, FileMode.OpenOrCreate);
			if (fileStream != null)
			{
				return new StreamWriter(fileStream);
			}
			throw new FileNotFoundException(FileNotFoundErrorMessage, path);
		}

		internal static VirtualFileStream CreateFile(VirtualFileInfo objVirtualFileInfo)
		{
			VirtualFileStream virtualFileStream = new VirtualFileStream(objVirtualFileInfo.Reference, FileMode.Open);
			if (virtualFileStream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new FileNotFoundException(FileNotFoundErrorMessage, objVirtualFileInfo.FullPath);
			}
			return virtualFileStream;
		}

		internal static VirtualFileStream CreateFile(string path, int bufferSize)
		{
			return CreateFile(path, bufferSize, FileOptions.None, null);
		}

		internal static VirtualFileStream CreateFile(string path, int bufferSize, FileOptions options)
		{
			return CreateFile(path, bufferSize, options, null);
		}

		internal static VirtualFileStream CreateFile(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity)
		{
			return CreateFile(path);
		}

		internal static Stream ReadContentStream(VirtualFileStream virtualFileStream, FileMode enmFileMode)
		{
			return ReadContentStream(virtualFileStream.Reference, enmFileMode);
		}

		internal static Stream ReadContentStream(VirtualReference virtualReference, FileMode enmFileMode)
		{
			Stream stream = null;
			if (enmFileMode != FileMode.Create)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stream = F.Current.CreateEmptyContent();
			}
			if (stream != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stream = F.Current.ReadContent(virtualReference);
			}
			if (stream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (enmFileMode != FileMode.Append)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (stream.Position == stream.Length)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Stream stream2 = stream;
				stream2.Position = stream2.Length;
			}
			return stream;
		}

		internal static void SetFileStream(VirtualFileStream virtualFileStream)
		{
			SetFileStream(virtualFileStream.Reference, virtualFileStream.NodeStream);
		}

		internal static void SetFileStream(VirtualReference virtualReference, Stream contentStream)
		{
			F.Current.Update(virtualReference, B, string.Empty, contentStream);
		}

		internal static void AppendAllText(string path, string contents)
		{
			Stream stream = new VirtualFileStream(path, FileMode.Open);
			try
			{
				if (stream != null)
				{
					stream.Position = stream.Length;
					StreamWriter streamWriter = new StreamWriter(stream);
					streamWriter.Write(contents);
					streamWriter.Flush();
					streamWriter.Close();
					return;
				}
				throw new FileNotFoundException(FileNotFoundErrorMessage, path);
			}
			finally
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)stream).Dispose();
				}
			}
		}

		internal static void AppendAllText(string path, string contents, Encoding encoding)
		{
			Stream stream = new VirtualFileStream(path, FileMode.Open);
			try
			{
				if (stream != null)
				{
					stream.Position = stream.Length;
					StreamWriter streamWriter = new StreamWriter(stream, encoding);
					streamWriter.Write(contents);
					streamWriter.Flush();
					streamWriter.Close();
					return;
				}
				throw new FileNotFoundException(FileNotFoundErrorMessage, path);
			}
			finally
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)stream).Dispose();
				}
			}
		}

		internal static StreamWriter GetStreamWriterForAppendText(VirtualFileInfo virtualFileInfo)
		{
			Stream fileStreamForWrite = GetFileStreamForWrite(virtualFileInfo);
			if (fileStreamForWrite == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new FileNotFoundException(FileNotFoundErrorMessage, virtualFileInfo.FullName);
			}
			fileStreamForWrite.Position = fileStreamForWrite.Length;
			return new StreamWriter(fileStreamForWrite);
		}

		internal static VirtualFileStream GetFileStreamForWrite(VirtualFileInfo virtualFileInfo)
		{
			return new VirtualFileStream(virtualFileInfo.Reference, FileMode.Append);
		}

		internal static StreamWriter GetStreamWriterForAppendText(string path)
		{
			Stream fileStream = GetFileStream(path, FileMode.Append);
			if (fileStream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new FileNotFoundException(FileNotFoundErrorMessage, path);
			}
			fileStream.Position = fileStream.Length;
			return new StreamWriter(fileStream);
		}

		internal static VirtualFileStream GetFileStream(string path, FileMode mode)
		{
			return new VirtualFileStream(GetFileReference(path), mode);
		}

		internal static VirtualFileStream GetFileStream(string path, FileMode mode, FileAccess access)
		{
			return new VirtualFileStream(GetFileReference(path), mode, access);
		}

		internal static VirtualFileStream GetFileStream(string path, FileMode mode, FileAccess access, FileShare share)
		{
			return new VirtualFileStream(GetFileReference(path), mode, access, share);
		}

		internal static VirtualFileStream GetFileStream(string path)
		{
			return new VirtualFileStream(GetFileReference(path), FileMode.Open, FileAccess.Read);
		}

		internal static StreamReader OpenFileText(string path)
		{
			return new StreamReader(new VirtualFileStream(GetFileReference(path), FileMode.Open, FileAccess.Read));
		}

		internal static VirtualFileStream OpenFileWrite(string path)
		{
			return new VirtualFileStream(GetFileReference(path), FileMode.Open, FileAccess.ReadWrite);
		}

		internal static string ReadAllFileText(string path)
		{
			string text = null;
			Stream stream = ReadContentStream(GetFileReference(path), FileMode.Open);
			try
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new FileNotFoundException("Could not find file in virtual file system.", path);
				}
				StreamReader streamReader = new StreamReader(stream);
				text = streamReader.ReadToEnd();
				streamReader.Close();
				return text;
			}
			finally
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)stream).Dispose();
				}
			}
		}

		internal static string ReadAllFileText(string path, Encoding encoding)
		{
			string text = null;
			using Stream stream = ReadContentStream(GetFileReference(path), FileMode.Open);
			if (stream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new FileNotFoundException("Could not find file in virtual file system.", path);
			}
			StreamReader streamReader = new StreamReader(stream, encoding);
			text = streamReader.ReadToEnd();
			streamReader.Close();
			return text;
		}

		internal static byte[] ReadAllFileBytes(string path)
		{
			byte[] array = null;
			Stream stream = ReadContentStream(GetFileReference(path), FileMode.Open);
			try
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new FileNotFoundException("Could not find file in virtual file system.", path);
				}
				if (stream.Position == 0L)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stream.Position = 0L;
				}
				array = new byte[stream.Length];
				stream.Read(array, 0, array.Length);
				return array;
			}
			finally
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)stream).Dispose();
				}
			}
		}

		internal static string[] ReadAllFileLines(string path)
		{
			List<string> list = new List<string>();
			Stream stream = ReadContentStream(GetFileReference(path), FileMode.Open);
			try
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new FileNotFoundException("Could not find file in virtual file system.", path);
				}
				StreamReader streamReader = new StreamReader(stream);
				string text = null;
				while ((text = streamReader.ReadLine()) != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					list.Add(text);
				}
				streamReader.Close();
			}
			finally
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)stream).Dispose();
				}
			}
			return list.ToArray();
		}

		internal static string[] ReadAllFileLines(string path, Encoding encoding)
		{
			List<string> list = new List<string>();
			Stream stream = ReadContentStream(GetFileReference(path), FileMode.Open);
			try
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new FileNotFoundException("Could not find file in virtual file system.", path);
				}
				StreamReader streamReader = new StreamReader(stream, encoding);
				string text = null;
				while ((text = streamReader.ReadLine()) != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					list.Add(text);
				}
				streamReader.Close();
			}
			finally
			{
				if (stream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)stream).Dispose();
				}
			}
			return list.ToArray();
		}

		internal static void WriteAllFileBytes(string path, byte[] bytes)
		{
			Stream fileStream = GetFileStream(path, FileMode.Create);
			try
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					fileStream.Write(bytes, 0, bytes.Length);
				}
			}
			finally
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)fileStream).Dispose();
				}
			}
		}

		internal static void WriteAllFileLines(string path, string[] contents)
		{
			Stream fileStream = GetFileStream(path, FileMode.Create);
			try
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				StreamWriter streamWriter = new StreamWriter(fileStream);
				for (int i = 0; i < contents.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string value = contents[i];
					streamWriter.WriteLine(value);
				}
				streamWriter.Flush();
			}
			finally
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)fileStream).Dispose();
				}
			}
		}

		internal static void WriteAllFileLines(string path, string[] contents, Encoding encoding)
		{
			Stream fileStream = GetFileStream(path, FileMode.Create);
			try
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				StreamWriter streamWriter = new StreamWriter(fileStream, encoding);
				for (int i = 0; i < contents.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string value = contents[i];
					streamWriter.WriteLine(value);
				}
				streamWriter.Flush();
			}
			finally
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)fileStream).Dispose();
				}
			}
		}

		internal static void WriteAllFileText(string path, string contents)
		{
			Stream fileStream = GetFileStream(path, FileMode.Create);
			try
			{
				if (fileStream != null)
				{
					StreamWriter streamWriter = new StreamWriter(fileStream);
					streamWriter.Write(contents);
					streamWriter.Flush();
				}
			}
			finally
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)fileStream).Dispose();
				}
			}
		}

		internal static void WriteAllFileText(string path, string contents, Encoding encoding)
		{
			Stream fileStream = GetFileStream(path, FileMode.Create);
			try
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				StreamWriter streamWriter = new StreamWriter(fileStream, encoding);
				streamWriter.Write(contents);
				streamWriter.Flush();
			}
			finally
			{
				if (fileStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)fileStream).Dispose();
				}
			}
		}

		internal static StreamWriter CreateFileStreamWriter(VirtualFileInfo virtualFileInfo)
		{
			Stream stream = OpenFileStream(virtualFileInfo, FileMode.Create);
			if (stream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new StreamWriter(stream);
		}

		internal static VirtualFileStream OpenFileStream(VirtualFileInfo virtualFileInfo, FileMode mode)
		{
			return new VirtualFileStream(virtualFileInfo.Reference, mode);
		}

		internal static VirtualFileStream OpenFileStream(VirtualFileInfo virtualFileInfo, FileMode mode, FileAccess access)
		{
			return new VirtualFileStream(virtualFileInfo.Reference, mode, access);
		}

		internal static VirtualFileStream OpenFileStream(VirtualFileInfo virtualFileInfo, FileMode mode, FileAccess access, FileShare share)
		{
			return new VirtualFileStream(virtualFileInfo.Reference, mode, access, share);
		}

		internal static VirtualFileStream OpenFileStreamForRead(VirtualFileInfo virtualFileInfo)
		{
			return new VirtualFileStream(virtualFileInfo.Reference, FileMode.Open, FileAccess.Read);
		}

		internal static StreamReader OpenFileStreamReader(VirtualFileInfo virtualFileInfo)
		{
			return new StreamReader(new VirtualFileStream(virtualFileInfo.Reference, FileMode.Open, FileAccess.Read));
		}

		internal static VirtualNode OpenFileForRead(VirtualReference objFileReference)
		{
			return OpenFile(objFileReference, G.ReadWithExceptions);
		}

		internal static VirtualNode OpenFile(VirtualReference objFileReference, G objOptions)
		{
			VirtualNode virtualNode = null;
			bool flag = false;
			bool flag2 = false;
			switch (objOptions.Mode)
			{
			case FileMode.Open:
			case FileMode.Truncate:
				flag = true;
				break;
			case FileMode.CreateNew:
				flag2 = true;
				break;
			}
			if (!flag)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (flag2)
				{
					virtualNode = F.Current.Read(objFileReference);
					if (virtualNode != null)
					{
						throw new IOException("File already exists.");
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				if (virtualNode != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					virtualNode = F.Current.Create(GetDirectoryReference(objFileReference), objFileReference.NodeName, objFileReference.NodeType);
				}
			}
			else
			{
				virtualNode = F.Current.Read(objFileReference);
				if (virtualNode == null && objOptions.ThrowExceptions)
				{
					throw new FileNotFoundException(FileNotFoundErrorMessage, GetFileName(objFileReference));
				}
			}
			return virtualNode;
		}

		internal static VirtualNode OpenFileForRead(string strFilePath)
		{
			return OpenFile(strFilePath, G.ReadWithExceptions);
		}

		internal static VirtualNode OpenFile(string strFilePath, G objOptions)
		{
			return OpenFile(GetFileReference(strFilePath), objOptions);
		}

		internal static VirtualNode OpenFileForRead(VirtualFileInfo objFileInfo)
		{
			return OpenFile(objFileInfo, G.ReadWithExceptions);
		}

		internal static VirtualNode OpenFile(VirtualFileInfo objFileInfo, G objOptions)
		{
			return OpenFile(objFileInfo, objOptions);
		}

		internal static VirtualFileInfo CopyFile(VirtualFileInfo virtualFileInfo, string destFileName)
		{
			VirtualReference reference = virtualFileInfo.Reference;
			VirtualReference fileReference = GetFileReference(destFileName);
			VirtualNode virtualNode = F.Current.Copy(reference, fileReference);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualFileInfo(virtualNode);
		}

		internal static VirtualFileInfo CopyFile(VirtualFileInfo virtualFileInfo, string destFileName, bool overwrite)
		{
			VirtualReference reference = virtualFileInfo.Reference;
			VirtualReference fileReference = GetFileReference(destFileName);
			VirtualNode virtualNode = F.Current.Copy(reference, fileReference);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new VirtualFileInfo(virtualNode);
		}

		internal static void CopyFile(string sourceFileName, string destFileName)
		{
			VirtualReference fileReference = GetFileReference(sourceFileName);
			VirtualReference fileReference2 = GetFileReference(destFileName);
			F.Current.Copy(fileReference, fileReference2);
		}

		internal static void CopyFile(string sourceFileName, string destFileName, bool overwrite)
		{
			VirtualReference fileReference = GetFileReference(sourceFileName);
			VirtualReference fileReference2 = GetFileReference(destFileName);
			F.Current.Copy(fileReference, fileReference2);
		}

		internal static void SetFileAccessControl(VirtualFileInfo virtualFileInfo, FileSecurity fileSecurity)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileAccessControl(string path, FileSecurity fileSecurity)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileAccessControl(string path, FileAttributes fileAttributes)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static FileSecurity GetFileAccessControl(string path)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static FileSecurity GetFileAccessControl(string path, AccessControlSections includeSections)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static FileSecurity GetFileAccessControl(VirtualFileInfo virtualFileInfo)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static FileSecurity GetFileAccessControl(VirtualFileInfo virtualFileInfo, AccessControlSections includeSections)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void MoveFile(VirtualFileInfo virtualFileInfo, string destFileName)
		{
			VirtualReference reference = virtualFileInfo.Reference;
			VirtualReference fileReference = GetFileReference(destFileName);
			F.Current.Move(reference, fileReference);
		}

		internal static void MoveFile(string sourceFileName, string destFileName)
		{
			VirtualReference fileReference = GetFileReference(sourceFileName);
			VirtualReference fileReference2 = GetFileReference(destFileName);
			F.Current.Move(fileReference, fileReference2);
		}

		internal static void DecryptFile(VirtualFileInfo virtualFileInfo)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void EncryptFile(VirtualFileInfo virtualFileInfo)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void DecryptFile(string path)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void EncryptFile(string path)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void DeleteFile(string path)
		{
			F.Current.Delete(GetFileReference(path));
		}

		internal static void Delete(VirtualFileInfo virtualFileInfo)
		{
			F.Current.Delete(GetFileReference(virtualFileInfo));
		}

		internal static bool GetFileReadOnly(VirtualFileInfo virtualFileInfo)
		{
			return (virtualFileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
		}

		internal static DateTime GetFileCreationTime(string path)
		{
			return OpenFileForRead(path)?.CreatedOn ?? DateTime.MinValue;
		}

		internal static DateTime GetFileCreationTimeUtc(string path)
		{
			VirtualNode virtualNode = OpenFileForRead(path);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.CreatedOn;
		}

		internal static DateTime GetFileLastAccessTime(string path)
		{
			return OpenFileForRead(path)?.UpdatedOn ?? DateTime.MinValue;
		}

		internal static DateTime GetFileLastAccessTimeUtc(string path)
		{
			VirtualNode virtualNode = OpenFileForRead(path);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.UpdatedOn;
		}

		internal static DateTime GetFileLastWriteTime(string path)
		{
			VirtualNode virtualNode = OpenFileForRead(path);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.UpdatedOn;
		}

		internal static DateTime GetFileLastWriteTimeUtc(string path)
		{
			VirtualNode virtualNode = OpenFileForRead(path);
			if (virtualNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNode.UpdatedOn;
		}

		internal static bool GetFileExists(VirtualFileInfo virtualFileInfo)
		{
			if (OpenFileForRead(virtualFileInfo) == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return true;
		}

		internal static long GetFileLength(VirtualFileInfo virtualFileInfo)
		{
			VirtualNode virtualNodeFromFileSystemInfo = GetVirtualNodeFromFileSystemInfo(virtualFileInfo);
			if (virtualNodeFromFileSystemInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new FileNotFoundException("Could not find file in virtual file system.", virtualFileInfo.FullPath);
			}
			return virtualNodeFromFileSystemInfo.ContentLegth;
		}

		private static VirtualNode GetVirtualNodeFromFileSystemInfo(VirtualFileSystemInfo virtualFileInfo)
		{
			if (virtualFileInfo.Node != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				virtualFileInfo.Node = OpenFileForRead(virtualFileInfo.Reference);
			}
			if (virtualFileInfo.Node == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return virtualFileInfo.Node;
		}

		internal static string GetFileName(VirtualReference objFileReference)
		{
			if (objFileReference.Node == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return objFileReference.NodeName;
			}
			return objFileReference.Node.Name;
		}

		internal static string GetFileName(VirtualFileInfo virtualFileInfo)
		{
			if (virtualFileInfo.Node == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				string fullPath = virtualFileInfo.FullPath;
				if (!string.IsNullOrEmpty(fullPath))
				{
					return Path.GetFileName(fullPath);
				}
				return string.Empty;
			}
			return virtualFileInfo.Node.Name;
		}

		internal static bool GetFileExists(string path)
		{
			return OpenFileForRead(path) != null;
		}

		internal static FileAttributes GetFileAttributes(string path)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileCreationTime(string path, DateTime creationTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileCreationTimeUtc(string path, object creationTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileLastAccessTime(string path, DateTime lastAccessTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileLastAccessTimeUtc(string path, object lastAccessTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileLastWriteTimeUtc(string path, DateTime lastWriteTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileLastWriteTime(string path, DateTime lastWriteTime)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileReadOnly(VirtualFileInfo virtualFileInfo, bool value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void ReplaceFile(string sourceFileName, string destinationFileName, string destinationBackupFileName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void ReplaceFile(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static VirtualFileInfo ReplaceFile(VirtualFileInfo virtualFileInfo, string destinationFileName, string destinationBackupFileName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static VirtualFileInfo ReplaceFile(VirtualFileInfo virtualFileInfo, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static string[] GetFileSystemEntries(string path)
		{
			List<string> list = new List<string>();
			string[] array = F.Current.ReadNameList(GetDirectoryReference(path), A, C);
			if (array != null)
			{
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string item = array2[i];
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		internal static string[] GetFileSystemEntries(string path, string searchPattern)
		{
			List<string> list = new List<string>();
			string[] array = F.Current.ReadNameList(GetDirectoryReference(path), A, C, searchPattern);
			if (array != null)
			{
				string[] array2 = array;
				foreach (string item in array2)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		internal static VirtualFileSystemInfo[] GetFileSystemInfos(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			List<VirtualFileSystemInfo> list = new List<VirtualFileSystemInfo>();
			VirtualNode[] array = F.Current.ReadList(GetDirectoryReference(virtualDirectoryInfo), A, C);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				foreach (VirtualNode virtualNode in array2)
				{
					if (!(virtualNode.Type == C))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!(virtualNode.Type == A))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							list.Add(new VirtualFileInfo(virtualNode));
						}
					}
					else
					{
						list.Add(new VirtualDirectoryInfo(virtualNode));
					}
				}
			}
			return list.ToArray();
		}

		internal static VirtualFileSystemInfo[] GetFileSystemInfos(VirtualDirectoryInfo virtualDirectoryInfo, string searchPattern)
		{
			List<VirtualFileSystemInfo> list = new List<VirtualFileSystemInfo>();
			VirtualNode[] array = F.Current.ReadList(GetDirectoryReference(virtualDirectoryInfo), A, C, searchPattern);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				foreach (VirtualNode virtualNode in array2)
				{
					if (!(virtualNode.Type == C))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!(virtualNode.Type == A))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							list.Add(new VirtualFileInfo(virtualNode));
						}
					}
					else
					{
						list.Add(new VirtualDirectoryInfo(virtualNode));
					}
				}
			}
			return list.ToArray();
		}

		internal static void RefreshFile(VirtualFileSystemInfo objVirtualFileSystemInfo)
		{
			objVirtualFileSystemInfo.Node = F.Current.Read(objVirtualFileSystemInfo.Reference);
		}

		internal static DateTime GetFileCreationTimeUtc(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			VirtualNode virtualNodeFromFileSystemInfo = GetVirtualNodeFromFileSystemInfo(virtualFileSystemInfo);
			if (virtualNodeFromFileSystemInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNodeFromFileSystemInfo.UpdatedOn;
		}

		internal static string GetFileExtension(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			if (!(virtualFileSystemInfo is VirtualFileInfo virtualFileInfo))
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			return Path.GetExtension(virtualFileInfo.Name);
		}

		internal static string GetFullName(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			if (string.IsNullOrEmpty(virtualFileSystemInfo.FullPath))
			{
				/*OpCode not supported: LdMemberToken*/;
				return virtualFileSystemInfo.FullPath = Path.Combine(F.Current.ReadPath(virtualFileSystemInfo.Reference), virtualFileSystemInfo.Name);
			}
			return virtualFileSystemInfo.FullPath;
		}

		internal static DateTime GetLastAccessTime(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			VirtualNode virtualNodeFromFileSystemInfo = GetVirtualNodeFromFileSystemInfo(virtualFileSystemInfo);
			if (virtualNodeFromFileSystemInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNodeFromFileSystemInfo.UpdatedOn;
		}

		internal static DateTime GetLastAccessTimeUtc(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			VirtualNode virtualNodeFromFileSystemInfo = GetVirtualNodeFromFileSystemInfo(virtualFileSystemInfo);
			if (virtualNodeFromFileSystemInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNodeFromFileSystemInfo.UpdatedOn;
		}

		internal static DateTime GetLastWriteTime(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			VirtualNode virtualNodeFromFileSystemInfo = GetVirtualNodeFromFileSystemInfo(virtualFileSystemInfo);
			if (virtualNodeFromFileSystemInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNodeFromFileSystemInfo.UpdatedOn;
		}

		internal static DateTime GetLastWriteTimeUtc(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			return GetVirtualNodeFromFileSystemInfo(virtualFileSystemInfo)?.UpdatedOn ?? DateTime.MinValue;
		}

		internal static DateTime GetCreationTime(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			VirtualNode virtualNodeFromFileSystemInfo = GetVirtualNodeFromFileSystemInfo(virtualFileSystemInfo);
			if (virtualNodeFromFileSystemInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DateTime.MinValue;
			}
			return virtualNodeFromFileSystemInfo.CreatedOn;
		}

		internal static FileAttributes GetAttributes(VirtualFileSystemInfo virtualFileSystemInfo)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetFileCreationTimeUtc(VirtualFileSystemInfo virtualFileSystemInfo, DateTime value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetLastAccessTime(VirtualFileSystemInfo virtualFileSystemInfo, DateTime value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetLastWriteTimeUtc(VirtualFileSystemInfo virtualFileSystemInfo, DateTime value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetAttributes(VirtualFileSystemInfo virtualFileSystemInfo, FileAttributes value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetCreationTime(VirtualFileSystemInfo virtualFileSystemInfo, DateTime value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetLastAccessTimeUtc(VirtualFileSystemInfo virtualFileSystemInfo, DateTime value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static void SetLastWriteTime(VirtualFileSystemInfo virtualFileSystemInfo, DateTime value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static string[] GetLogicalDrives()
		{
			List<string> list = new List<string>();
			VirtualNode[] array = F.Current.ReadList(VirtualReference.DefaultRoot, C, Guid.Empty);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode virtualNode = array2[i];
					list.Add(virtualNode.Name);
				}
			}
			return list.ToArray();
		}

		internal static VirtualDriveInfo CreateDrive(string driveName)
		{
			VirtualNode virtualNode = F.Current.Create(VirtualReference.DefaultRoot, GetSafeDriveName(driveName), C);
			if (virtualNode != null)
			{
				return new VirtualDriveInfo(virtualNode);
			}
			return null;
		}

		internal static VirtualDriveInfo[] GetDrives()
		{
			List<VirtualDriveInfo> list = new List<VirtualDriveInfo>();
			VirtualNode[] array = F.Current.ReadList(VirtualReference.DefaultRoot, C, Guid.Empty);
			if (array == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VirtualNode[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					VirtualNode objVirtualNode = array2[i];
					list.Add(new VirtualDriveInfo(objVirtualNode));
				}
			}
			return list.ToArray();
		}

		internal static void SetDriveName(VirtualDriveInfo virtualDriveInfo, string value)
		{
			F.Current.Update(virtualDriveInfo.Reference, value);
		}

		internal static DirectorySecurity GetDirectoryAccessControl(string directoryPath)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static DirectorySecurity GetDirectoryAccessControl(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static DirectorySecurity GetDirectoryAccessControl(VirtualDirectoryInfo virtualDirectoryInfo, AccessControlSections includeSections)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static DirectorySecurity GetDirectoryAccessControl(string directoryPath, AccessControlSections includeSections)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		internal static VirtualReference GetDirectoryReference(VirtualDirectoryInfo virtualDirectoryInfo)
		{
			return virtualDirectoryInfo.Reference;
		}

		internal static VirtualReference GetDirectoryReference(string directoryPath)
		{
			return new VirtualReference(VirtualForest.Default.Id, GetSafeDirectoryPath(directoryPath), C);
		}

		internal static VirtualReference GetFileReference(string path)
		{
			return GetFileReference(path, includeFileName: true);
		}

		private static VirtualReference GetDirectoryReference(VirtualReference virtualFileReference)
		{
			return new VirtualReference(virtualFileReference.ForestId, virtualFileReference.Path, virtualFileReference.PathType, string.Empty, Guid.Empty);
		}

		private static VirtualReference GetFileReference(string path, bool includeFileName)
		{
			if (includeFileName)
			{
				return new VirtualReference(VirtualForest.Default.Id, Path.GetDirectoryName(path).Trim('\\'), C, Path.GetFileName(path), A);
			}
			return new VirtualReference(VirtualForest.Default.Id, Path.GetDirectoryName(path).Trim('\\'), C);
		}

		internal static VirtualReference GetFileReference(VirtualFileInfo virtualFileInfo)
		{
			return virtualFileInfo.Reference;
		}

		internal static string GetSafeDirectoryPath(string directoryPath)
		{
			if (string.IsNullOrEmpty(directoryPath))
			{
				/*OpCode not supported: LdMemberToken*/;
				return "";
			}
			return directoryPath.Trim('\\');
		}

		internal static string GetSafeDriveName(string driveName)
		{
			if (string.IsNullOrEmpty(driveName))
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			return driveName.Trim('\\');
		}

		internal static string GetSafePathName(string strPathName)
		{
			return strPathName;
		}

		internal static string GetFullPathIfRelative(string path)
		{
			if (!Path.IsPathRooted(path))
			{
				/*OpCode not supported: LdMemberToken*/;
				return Path.Combine(GetCurrentDirectory(), path);
			}
			return path;
		}

		internal static string GetCurrentDirectory()
		{
			return "C:\\";
		}

		internal static void SetCurrentDirectory(string directoryPath)
		{
		}
	}
}

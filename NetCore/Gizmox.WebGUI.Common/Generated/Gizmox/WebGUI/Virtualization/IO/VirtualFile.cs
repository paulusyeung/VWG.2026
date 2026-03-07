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
	public static class VirtualFile
	{
		public static void AppendAllText(string path, string contents)
		{
			H.AppendAllText(path, contents);
		}

		public static void AppendAllText(string path, string contents, Encoding encoding)
		{
			H.AppendAllText(path, contents, encoding);
		}

		public static StreamWriter AppendText(string path)
		{
			return H.GetStreamWriterForAppendText(path);
		}

		public static void Copy(string sourceFileName, string destFileName)
		{
			H.CopyFile(sourceFileName, destFileName);
		}

		public static void Copy(string sourceFileName, string destFileName, bool overwrite)
		{
			H.CopyFile(sourceFileName, destFileName, overwrite);
		}

		public static VirtualFileStream Create(string path)
		{
			return H.CreateFile(path);
		}

		public static VirtualFileStream Create(string path, int bufferSize)
		{
			return H.CreateFile(path, bufferSize);
		}

		public static VirtualFileStream Create(string path, int bufferSize, FileOptions options)
		{
			return H.CreateFile(path, bufferSize, options);
		}

		public static VirtualFileStream Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity)
		{
			return H.CreateFile(path, bufferSize, options, fileSecurity);
		}

		public static StreamWriter CreateText(string path)
		{
			return H.CreateTextFile(path);
		}

		public static void Decrypt(string path)
		{
			H.DecryptFile(path);
		}

		public static void Delete(string path)
		{
			H.DeleteFile(path);
		}

		public static void Encrypt(string path)
		{
			H.EncryptFile(path);
		}

		public static bool Exists(string path)
		{
			return H.GetFileExists(path);
		}

		public static FileSecurity GetAccessControl(string path)
		{
			return H.GetFileAccessControl(path);
		}

		public static FileSecurity GetAccessControl(string path, AccessControlSections includeSections)
		{
			return H.GetFileAccessControl(path, includeSections);
		}

		public static FileAttributes GetAttributes(string path)
		{
			return H.GetFileAttributes(path);
		}

		public static DateTime GetCreationTime(string path)
		{
			return H.GetFileCreationTime(path);
		}

		public static DateTime GetCreationTimeUtc(string path)
		{
			return H.GetFileCreationTimeUtc(path);
		}

		public static DateTime GetLastAccessTime(string path)
		{
			return H.GetFileLastAccessTime(path);
		}

		public static DateTime GetLastAccessTimeUtc(string path)
		{
			return H.GetFileLastAccessTimeUtc(path);
		}

		public static DateTime GetLastWriteTime(string path)
		{
			return H.GetFileLastWriteTime(path);
		}

		public static DateTime GetLastWriteTimeUtc(string path)
		{
			return H.GetFileLastWriteTimeUtc(path);
		}

		public static void Move(string sourceFileName, string destFileName)
		{
			H.MoveFile(sourceFileName, destFileName);
		}

		public static VirtualFileStream Open(string path, FileMode mode)
		{
			return H.GetFileStream(path, mode);
		}

		public static VirtualFileStream Open(string path, FileMode mode, FileAccess access)
		{
			return H.GetFileStream(path, mode, access);
		}

		public static VirtualFileStream Open(string path, FileMode mode, FileAccess access, FileShare share)
		{
			return H.GetFileStream(path, mode, access, share);
		}

		public static VirtualFileStream OpenRead(string path)
		{
			return H.GetFileStream(path);
		}

		public static StreamReader OpenText(string path)
		{
			return H.OpenFileText(path);
		}

		public static VirtualFileStream OpenWrite(string path)
		{
			return H.OpenFileWrite(path);
		}

		public static byte[] ReadAllBytes(string path)
		{
			return H.ReadAllFileBytes(path);
		}

		public static string[] ReadAllLines(string path)
		{
			return H.ReadAllFileLines(path);
		}

		public static string[] ReadAllLines(string path, Encoding encoding)
		{
			return H.ReadAllFileLines(path, encoding);
		}

		public static string ReadAllText(string path)
		{
			return H.ReadAllFileText(path);
		}

		public static string ReadAllText(string path, Encoding encoding)
		{
			return H.ReadAllFileText(path, encoding);
		}

		public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)
		{
			H.ReplaceFile(sourceFileName, destinationFileName, destinationBackupFileName);
		}

		public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
		{
			H.ReplaceFile(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
		}

		public static void SetAccessControl(string path, FileSecurity fileSecurity)
		{
			H.SetFileAccessControl(path, fileSecurity);
		}

		public static void SetAttributes(string path, FileAttributes fileAttributes)
		{
			H.SetFileAccessControl(path, fileAttributes);
		}

		public static void SetCreationTime(string path, DateTime creationTime)
		{
			H.SetFileCreationTime(path, creationTime);
		}

		public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
		{
			H.SetFileCreationTimeUtc(path, creationTimeUtc);
		}

		public static void SetLastAccessTime(string path, DateTime lastAccessTime)
		{
			H.SetFileLastAccessTime(path, lastAccessTime);
		}

		public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
		{
			H.SetFileLastAccessTimeUtc(path, lastAccessTimeUtc);
		}

		public static void SetLastWriteTime(string path, DateTime lastWriteTime)
		{
			H.SetFileLastWriteTime(path, lastWriteTime);
		}

		public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
		{
			H.SetFileLastWriteTimeUtc(path, lastWriteTimeUtc);
		}

		public static void WriteAllBytes(string path, byte[] bytes)
		{
			H.WriteAllFileBytes(path, bytes);
		}

		public static void WriteAllLines(string path, string[] contents)
		{
			H.WriteAllFileLines(path, contents);
		}

		public static void WriteAllLines(string path, string[] contents, Encoding encoding)
		{
			H.WriteAllFileLines(path, contents, encoding);
		}

		public static void WriteAllText(string path, string contents)
		{
			H.WriteAllFileText(path, contents);
		}

		public static void WriteAllText(string path, string contents, Encoding encoding)
		{
			H.WriteAllFileText(path, contents, encoding);
		}
	}
}

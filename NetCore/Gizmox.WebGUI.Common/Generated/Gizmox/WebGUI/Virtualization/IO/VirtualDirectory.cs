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
	public static class VirtualDirectory
	{
		public static VirtualDirectoryInfo CreateDirectory(string path)
		{
			return H.CreateDirectory(path);
		}

		public static VirtualDirectoryInfo CreateDirectory(string path, DirectorySecurity directorySecurity)
		{
			return H.CreateDirectory(path, directorySecurity);
		}

		public static void Delete(string path)
		{
			H.DeleteDirectory(path);
		}

		public static void Delete(string path, bool recursive)
		{
			H.DeleteDirectory(path, recursive);
		}

		public static bool Exists(string path)
		{
			return H.GetDirectoryExists(path);
		}

		public static DirectorySecurity GetAccessControl(string path)
		{
			return H.GetDirectoryAccessControl(path);
		}

		public static DirectorySecurity GetAccessControl(string path, AccessControlSections includeSections)
		{
			return H.GetDirectoryAccessControl(path, includeSections);
		}

		public static DateTime GetCreationTime(string path)
		{
			return H.GetDirectoryCreationTime(path);
		}

		public static DateTime GetCreationTimeUtc(string path)
		{
			return H.GetDirectoryCreationTimeUtc(path);
		}

		public static string GetCurrentDirectory()
		{
			return H.GetCurrentDirectory();
		}

		public static string[] GetDirectories(string path)
		{
			return H.GetDirectories(path);
		}

		public static string[] GetDirectories(string path, string searchPattern)
		{
			return H.GetDirectories(path, searchPattern);
		}

		public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
		{
			return H.GetDirectories(path, searchPattern, searchOption);
		}

		public static string GetDirectoryRoot(string path)
		{
			return H.GetDirectoryRoot(path);
		}

		public static string[] GetFiles(string path)
		{
			return H.GetDirectoryFiles(path);
		}

		public static string[] GetFiles(string path, string searchPattern)
		{
			return H.GetDirectoryFiles(path, searchPattern);
		}

		public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
		{
			return H.GetDirectoryFiles(path, searchPattern, searchOption);
		}

		public static string[] GetFileSystemEntries(string path)
		{
			return H.GetFileSystemEntries(path);
		}

		public static string[] GetFileSystemEntries(string path, string searchPattern)
		{
			return H.GetFileSystemEntries(path, searchPattern);
		}

		public static DateTime GetLastAccessTime(string path)
		{
			return H.GetDirectoryLastAccessTime(path);
		}

		public static DateTime GetLastAccessTimeUtc(string path)
		{
			return H.GetDirectoryLastAccessTimeUtc(path);
		}

		public static DateTime GetLastWriteTime(string path)
		{
			return H.GetDirectoryLastWriteTime(path);
		}

		public static DateTime GetLastWriteTimeUtc(string path)
		{
			return H.GetDirectoryLastWriteTimeUtc(path);
		}

		public static string[] GetLogicalDrives()
		{
			return H.GetLogicalDrives();
		}

		public static VirtualDirectoryInfo GetParent(string path)
		{
			return H.GetDirectoryParent(path);
		}

		public static void Move(string sourceDirName, string destDirName)
		{
			H.MoveDirectory(sourceDirName, destDirName);
		}

		public static void SetAccessControl(string path, DirectorySecurity directorySecurity)
		{
			H.SetDirectoryAccessControl(path, directorySecurity);
		}

		public static void SetCreationTime(string path, DateTime creationTime)
		{
			H.SetDirectoryCreationTime(path, creationTime);
		}

		public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
		{
			H.SetDirectoryCreationTimeUtc(path, creationTimeUtc);
		}

		public static void SetCurrentDirectory(string path)
		{
			H.SetCurrentDirectory(path);
		}

		public static void SetLastAccessTime(string path, DateTime lastAccessTime)
		{
			H.SetDirectoryLastAccessTime(path, lastAccessTime);
		}

		public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
		{
			H.SetDirectoryLastAccessTimeUtc(path, lastAccessTimeUtc);
		}

		public static void SetLastWriteTime(string path, DateTime lastWriteTime)
		{
			H.SetDirectoryLastWriteTime(path, lastWriteTime);
		}

		public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
		{
			H.SetDirectoryLastWriteTimeUtc(path, lastWriteTimeUtc);
		}
	}
}

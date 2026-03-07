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

namespace Gizmox.WebGUI.Common.Forms.Security
{
	public class UserFilePermissions
	{
		private string A;

		private WindowsIdentity B;

		private bool C;

		private bool D;

		private bool E;

		private bool F;

		public bool CanReadData
		{
			get
			{
				if (C)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return E;
			}
		}

		public bool CanWriteData
		{
			get
			{
				if (!D)
				{
					return F;
				}
				return false;
			}
		}

		public WindowsIdentity WindowsIdentity => B;

		public string Path => A;

		public UserFilePermissions(string path)
			: this(path, WindowsIdentity.GetCurrent())
		{
		}

		public UserFilePermissions(string path, WindowsIdentity principal)
		{
			A = path;
			B = principal;
			try
			{
				AuthorizationRuleCollection accessRules = new FileInfo(A).GetAccessControl().GetAccessRules(includeExplicit: true, includeInherited: true, typeof(SecurityIdentifier));
				for (int i = 0; i < accessRules.Count; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					FileSystemAccessRule fileSystemAccessRule = (FileSystemAccessRule)accessRules[i];
					if (!B.User.Equals(fileSystemAccessRule.IdentityReference))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!AccessControlType.Deny.Equals(fileSystemAccessRule.AccessControlType))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!AccessControlType.Allow.Equals(fileSystemAccessRule.AccessControlType))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (!Contains(FileSystemRights.ReadData, fileSystemAccessRule))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							E = true;
						}
						if (!Contains(FileSystemRights.WriteData, fileSystemAccessRule))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							F = true;
						}
					}
					else
					{
						if (Contains(FileSystemRights.ReadData, fileSystemAccessRule))
						{
							C = true;
						}
						if (!Contains(FileSystemRights.WriteData, fileSystemAccessRule))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							D = true;
						}
					}
				}
				IdentityReferenceCollection groups = B.Groups;
				for (int j = 0; j < groups.Count; j++)
				{
					/*OpCode not supported: LdMemberToken*/;
					for (int k = 0; k < accessRules.Count; k++)
					{
						/*OpCode not supported: LdMemberToken*/;
						FileSystemAccessRule fileSystemAccessRule2 = (FileSystemAccessRule)accessRules[k];
						if (!groups[j].Equals(fileSystemAccessRule2.IdentityReference))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!AccessControlType.Deny.Equals(fileSystemAccessRule2.AccessControlType))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (AccessControlType.Allow.Equals(fileSystemAccessRule2.AccessControlType))
							{
								if (!Contains(FileSystemRights.ReadData, fileSystemAccessRule2))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									E = true;
								}
								if (!Contains(FileSystemRights.WriteData, fileSystemAccessRule2))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									F = true;
								}
							}
						}
						else
						{
							if (!Contains(FileSystemRights.ReadData, fileSystemAccessRule2))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								C = true;
							}
							if (Contains(FileSystemRights.WriteData, fileSystemAccessRule2))
							{
								D = true;
							}
						}
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
				throw new FormsSecurityException(A + " file has an invalid permission configuration: it is impossible to read its permissions. To fix this problem, either elevate IIS permissions on the VWGFormSecurity directory and its contents, or disable the Forms Security feature.");
			}
		}

		public override string ToString()
		{
			string text = "";
			if (!CanReadData)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text += ",";
				}
				text += "ReadData";
			}
			if (!CanWriteData)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text += ",";
				}
				text += "WriteData";
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "None";
			}
			return text;
		}

		public bool Contains(FileSystemRights right, FileSystemAccessRule rule)
		{
			return (right & rule.FileSystemRights) == right;
		}
	}
}

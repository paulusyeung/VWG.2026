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

namespace Gizmox.WebGUI.Common.Resources
{
	[Serializable]
	public class HttpPostedFileHandle : FileHandle
	{
		[Serializable]
		internal static class WinAPI
		{
			[DllImport("kernel32.dll", SetLastError = true)]
			internal static extern bool CloseHandle(IntPtr handle);

			[DllImport("advapi32.dll", SetLastError = true)]
			internal static extern int OpenThreadToken(IntPtr thread, int access, bool openAsSelf, ref IntPtr hToken);

			[DllImport("kernel32.dll")]
			internal static extern IntPtr GetCurrentThread();

			[DllImport("advapi32.dll")]
			internal static extern int RevertToSelf();

			[DllImport("advapi32.dll")]
			internal static extern int SetThreadToken(IntPtr threadref, IntPtr token);
		}

		[Serializable]
		internal class ImpersonationContext : IDisposable
		{
			private bool _impersonating;

			private bool _reverted;

			private HandleRef _savedToken;

			internal static bool CurrentThreadTokenExists
			{
				get
				{
					bool result = false;
					try
					{
					}
					finally
					{
						IntPtr currentToken = GetCurrentToken();
						if (!(currentToken != IntPtr.Zero))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							result = true;
							WinAPI.CloseHandle(currentToken);
						}
					}
					return result;
				}
			}

			internal ImpersonationContext()
			{
			}

			internal ImpersonationContext(IntPtr token)
			{
				ImpersonateToken(new HandleRef(this, token));
			}

			private void Dispose(bool disposing)
			{
				if (!(_savedToken.Handle != IntPtr.Zero))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				try
				{
				}
				finally
				{
					WinAPI.CloseHandle(_savedToken.Handle);
					_savedToken = new HandleRef(this, IntPtr.Zero);
				}
			}

			~ImpersonationContext()
			{
				Dispose(disposing: false);
			}

			private static IntPtr GetCurrentToken()
			{
				IntPtr hToken = IntPtr.Zero;
				if (WinAPI.OpenThreadToken(WinAPI.GetCurrentThread(), 131084, openAsSelf: true, ref hToken) != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (Marshal.GetLastWin32Error() != 1008)
					{
						throw new HttpException();
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return hToken;
			}

			protected void ImpersonateToken(HandleRef token)
			{
				try
				{
					_savedToken = new HandleRef(this, GetCurrentToken());
					if (!(_savedToken.Handle != IntPtr.Zero))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (WinAPI.RevertToSelf() == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						_reverted = true;
					}
					if (!(token.Handle != IntPtr.Zero))
					{
						/*OpCode not supported: LdMemberToken*/;
						return;
					}
					if (WinAPI.SetThreadToken(IntPtr.Zero, token.Handle) != 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						_impersonating = true;
						return;
					}
					throw new HttpException();
				}
				catch
				{
					RestoreImpersonation();
					throw;
				}
			}

			private void RestoreImpersonation()
			{
				if (!_impersonating)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					WinAPI.RevertToSelf();
					_impersonating = false;
				}
				if (!(_savedToken.Handle != IntPtr.Zero))
				{
					return;
				}
				if (!_reverted)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (WinAPI.SetThreadToken(IntPtr.Zero, _savedToken.Handle) == 0)
					{
						throw new HttpException();
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				_reverted = false;
			}

			void IDisposable.Dispose()
			{
				Undo();
			}

			internal void Undo()
			{
				RestoreImpersonation();
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}

		[Serializable]
		internal sealed class ApplicationImpersonationContext : ImpersonationContext
		{
			internal ApplicationImpersonationContext()
			{
				PropertyInfo property = typeof(HostingEnvironment).GetProperty("ApplicationIdentityToken", BindingFlags.Static | BindingFlags.NonPublic);
				if (!(property == null))
				{
					/*OpCode not supported: LdMemberToken*/;
					ImpersonateToken(new HandleRef(this, (IntPtr)property.GetValue(null, null)));
					return;
				}
				throw new Exception("Could not find 'System.Web.Hosting.HostingEnvironment.ApplicationIdentityToken' property");
			}
		}

		private long mintContentLength;

		private string mstrFileName;

		private string mstrContentType;

		private ITempFileCollection mobjTempFiles;

		private string mstrPostedFileName;

		public override long ContentLength => mintContentLength;

		public override string ContentType => mstrContentType;

		public override string FileName => mstrFileName;

		public string PostedFileName => mstrPostedFileName;

		public override string OriginalFileName => mstrPostedFileName;

		public override Stream InputStream
		{
			get
			{
				if (InternalStream != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					InternalStream = File.Open(mstrFileName, FileMode.Open);
				}
				return InternalStream;
			}
		}

		private static string GetDefaultTempFileCollectionString()
		{
			_ = string.Empty;
			return "Gizmox.WebGUI.Common.FileIO.WebTempFileCollection, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
		}

		public static HttpPostedFileHandle Create(HostPostedFile postedFile)
		{
			_ = VWGContext.Current;
			HttpPostedFileHandle httpPostedFileHandle = new HttpPostedFileHandle();
			httpPostedFileHandle.mstrPostedFileName = postedFile.FileName;
			httpPostedFileHandle.mstrContentType = postedFile.ContentType;
			httpPostedFileHandle.mobjTempFiles = CommonUtils.GetProvider<ITempFileCollection>(GetDefaultTempFileCollectionString(), blnIsCache: true);
			httpPostedFileHandle.mstrFileName = httpPostedFileHandle.mobjTempFiles.AddTempFile("post");
			postedFile.SaveAs(httpPostedFileHandle.mstrFileName);
			httpPostedFileHandle.mintContentLength = postedFile.ContentLength;
			httpPostedFileHandle.mstrContentType = postedFile.ContentType;
			return httpPostedFileHandle;
		}

		public override void Close()
		{
			base.Close();
			if (!(mobjTempFiles is IDisposable disposable))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				disposable.Dispose();
			}
		}
	}
}

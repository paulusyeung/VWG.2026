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
	[Serializable]
	public sealed class Application
	{
		public static bool AllowQuit => true;

		public static WebSocketService WebSockets
		{
			get
			{
				if (!(VWGContext.Current is IContextParams contextParams))
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return contextParams.WebSocketService;
			}
		}

		public static string CompanyName
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public static CultureInfo CurrentCulture
		{
			get
			{
				if (VWGContext.Current == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return Thread.CurrentThread.CurrentCulture;
				}
				return VWGContext.Current.CurrentUICulture;
			}
			set
			{
			}
		}

		public static CultureInfo CurrentUICulture
		{
			get
			{
				if (VWGContext.Current == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return Thread.CurrentThread.CurrentUICulture;
				}
				return VWGContext.Current.CurrentUICulture;
			}
			set
			{
			}
		}

		public static string ExecutablePath
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public static string LocalUserAppDataPath
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public static bool MessageLoop => false;

		public static OpenFormCollection OpenForms
		{
			get
			{
				return OpenFormsInternal;
			}
		}

		internal static OpenFormCollection OpenFormsInternal
		{
			get
			{
				OpenFormCollection objFormCollection = null;
				if (VWGContext.Current != null)
				{
					if (VWGContext.Current.MainForm == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						GetApplicationOpenForms(VWGContext.Current.MainForm, ref objFormCollection);
					}
				}
				return objFormCollection;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		public static string ProductName => string.Empty;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static string ProductVersion => string.Empty;

		public static string StartupPath => HostContext.Current.Request.PhysicalApplicationPath;

		public static event EventHandler ApplicationExit
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ApplicationExit += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ApplicationExit -= value;
				}
			}
		}

		public static event EventHandler ThreadSuspend
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadSuspend += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadSuspend -= value;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static event EventHandler EnterThreadModal
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.EnterThreadModal += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.EnterThreadModal -= value;
				}
			}
		}

		public static event EventHandler Idle
		{
			add
			{
				if (VWGContext.Current is IApplicationContext applicationContext)
				{
					applicationContext.Idle += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.Idle -= value;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static event EventHandler LeaveThreadModal
		{
			add
			{
				if (VWGContext.Current is IApplicationContext applicationContext)
				{
					applicationContext.LeaveThreadModal += value;
				}
			}
			remove
			{
				if (VWGContext.Current is IApplicationContext applicationContext)
				{
					applicationContext.LeaveThreadModal -= value;
				}
			}
		}

		public static event EventHandler ThreadExit
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadExit += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadExit -= value;
				}
			}
		}

		public static event EventHandler ThreadRefresh
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadRefresh += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadRefresh -= value;
				}
			}
		}

		public static event ThreadBookmarkEventHandler ThreadBookmarkNavigate
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadBookmarkNavigate += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadBookmarkNavigate -= value;
				}
			}
		}

		public static event CancelEventHandler BeforeApplicationTimeout
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.BeforeApplicationTimeout += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.BeforeApplicationTimeout -= value;
				}
			}
		}

		public static event ThreadMessageEventHandler ThreadMessage
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadMessage += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadMessage -= value;
				}
			}
		}

		public static event ThreadExceptionEventHandler ThreadException
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadException += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadException -= value;
				}
			}
		}

		public static event EventHandler ThreadTick
		{
			add
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadTick += value;
				}
			}
			remove
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.ThreadTick -= value;
				}
			}
		}

		public static void SetThreadBookmark(object objData)
		{
			SetThreadBookmark(objData, string.Empty);
		}

		public static void SetThreadBookmark(object objData, string strBookmarkTitle)
		{
			if (!(VWGContext.Current is IApplicationContext applicationContext))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				applicationContext.SetThreadBookmark(objData, strBookmarkTitle);
			}
		}

		public static void DoEvents()
		{
		}

		public static void EnableVisualStyles()
		{
			throw new NotImplementedException();
		}

		public static void Exit()
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static void Exit(CancelEventArgs e)
		{
			throw new NotImplementedException();
		}

		public static void ExitThread()
		{
			throw new NotImplementedException();
		}

		public static void OnThreadException(Exception t)
		{
			if (!(VWGContext.Current is IApplicationContext applicationContext))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				applicationContext.OnThreadException(t);
			}
		}

		public static void Restart()
		{
			throw new NotImplementedException();
		}

		public static void SetCompatibleTextRenderingDefault(bool defaultValue)
		{
			throw new NotImplementedException();
		}

		public static void SetUnhandledExceptionMode(UnhandledExceptionMode mode)
		{
			throw new NotImplementedException();
		}

		public static void SetUnhandledExceptionMode(UnhandledExceptionMode mode, bool threadScope)
		{
			throw new NotImplementedException();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static void UnregisterMessageLoop()
		{
			throw new NotImplementedException();
		}

		private static void GetApplicationOpenForms(IForm objForm, ref OpenFormCollection objFormCollection)
		{
			if (objForm == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (objFormCollection != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objFormCollection = new OpenFormCollection();
			}
			objFormCollection.Add(objForm);
			if (objForm.Forms == null)
			{
				return;
			}
			if (objForm.Forms.Length == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			for (int i = 0; i < objForm.Forms.Length; i++)
			{
				GetApplicationOpenForms(objForm.Forms[i], ref objFormCollection);
			}
		}
	}
}

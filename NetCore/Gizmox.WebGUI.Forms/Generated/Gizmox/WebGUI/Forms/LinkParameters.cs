#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
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
using Gizmox.WebGUI.Common.Extensibility;
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
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// 
	/// Holds window parameters for opening links
	/// </summary>
	[Serializable]
	public class LinkParameters : ILinkParameters
	{
		/// 
		/// Holds arguments to open links with
		/// </summary>
		[Serializable]
		public class LinkArguments : ILinkArguments
		{
			/// 
			/// Arguments storage
			/// </summary>
			private Hashtable mobjArguments = null;

			/// 
			/// Set or get arguments
			/// </summary>
			/// <param name="strName"></param>
			/// </returns>
			public string this[string strName]
			{
				get
				{
					if (mobjArguments != null)
					{
						return mobjArguments[strName] as string;
					}
					return null;
				}
				set
				{
					if (mobjArguments == null)
					{
						mobjArguments = new Hashtable();
					}
					mobjArguments[strName] = value;
				}
			}

			/// 
			/// Gets an array of argument names
			/// </summary>
			public string[] Names
			{
				get
				{
					if (mobjArguments == null)
					{
						return new string[0];
					}
					return (string[])new ArrayList(mobjArguments.Keys).ToArray(typeof(string));
				}
			}

			/// 
			/// Gets the arguments count
			/// </summary>
			public int Count => Names.Length;

			/// 
			/// Clears the argument collection
			/// </summary>
			public void Clear()
			{
				if (mobjArguments != null)
				{
					mobjArguments.Clear();
				}
			}
		}

		/// 
		/// The link window stule
		/// </summary>
		private LinkWindowStyle menmWindowStyle = LinkWindowStyle.Normal;

		/// 
		/// The link window size 
		/// </summary>
		private Size mobjWindowSize = Size.Empty;

		/// 
		/// A flag indicating if window should be opened in full screen
		/// </summary>
		private bool mblnFullScreen = false;

		/// 
		/// The link window location
		/// </summary>
		private Point mobjLocation = Point.Empty;

		/// 
		/// A flag indicating of location bar should be displayed in the link window
		/// </summary>
		private bool mblnShowLocationBar = false;

		/// 
		/// A flag indicating of menu bar should be displayed in the link window
		/// </summary>
		private bool mblnShowMenuBar = false;

		/// 
		/// A flag indicating of title bar should be displayed in the link window
		/// </summary>
		private bool mblnShowTitleBar = true;

		/// 
		/// A flag indicating of toolbar should be displayed in the link window
		/// </summary>
		private bool mblnShowToolBar = false;

		/// 
		/// A flag indicating of status bar should be displayed in the link window
		/// </summary>
		private bool mblnShowStatusBar = false;

		/// 
		/// A flag indicating if the link window should be resizable
		/// </summary>
		private bool mblnResizable = true;

		/// 
		/// A flag indicating if the link window should have scrollbars
		/// </summary>
		private bool mblnScrollBars = true;

		/// 
		/// The target window name
		/// </summary>
		private string mstrTarget = "_blank";

		/// 
		/// Holds form related arguments
		/// </summary>
		private ILinkArguments mobjFormArguments = null;

		/// 
		/// Holds form related arguments
		/// </summary>
		private ILinkArguments mobjQueryArguments = null;

		/// 
		/// Gets or sets query string arguments
		/// </summary>
		public ILinkArguments QueryString
		{
			get
			{
				if (mobjQueryArguments == null)
				{
					mobjQueryArguments = new LinkArguments();
				}
				return mobjQueryArguments;
			}
		}

		/// 
		/// Gets or sets form arguments
		/// </summary>
		public ILinkArguments Form
		{
			get
			{
				if (mobjFormArguments == null)
				{
					mobjFormArguments = new LinkArguments();
				}
				return mobjFormArguments;
			}
		}

		/// 
		/// Get or sets the window style
		/// </summary>
		public LinkWindowStyle WindowStyle
		{
			get
			{
				return menmWindowStyle;
			}
			set
			{
				menmWindowStyle = value;
			}
		}

		/// 
		/// Gets or sets the window size
		/// </summary>
		public Size Size
		{
			get
			{
				return mobjWindowSize;
			}
			set
			{
				mobjWindowSize = value;
			}
		}

		/// 
		/// Gets or sets the link window full screen mode
		/// </summary>
		public bool FullScreen
		{
			get
			{
				return mblnFullScreen;
			}
			set
			{
				mblnFullScreen = value;
			}
		}

		/// 
		/// Gets or sets the link window location
		/// </summary>
		public Point Location
		{
			get
			{
				return mobjLocation;
			}
			set
			{
				mobjLocation = value;
			}
		}

		/// 
		/// Gets or sets the link windows location bar visibility
		/// </summary>
		public bool ShowLocationBar
		{
			get
			{
				return mblnShowLocationBar;
			}
			set
			{
				mblnShowLocationBar = value;
			}
		}

		/// 
		/// Gets or sets the link windows menu bar visibility
		/// </summary>
		public bool ShowMenuBar
		{
			get
			{
				return mblnShowMenuBar;
			}
			set
			{
				mblnShowMenuBar = value;
			}
		}

		/// 
		/// Gets or sets the link windows title bar visibility
		/// </summary>
		public bool ShowTitleBar
		{
			get
			{
				return mblnShowTitleBar;
			}
			set
			{
				mblnShowTitleBar = value;
			}
		}

		/// 
		/// Gets or sets the link windows toolbar visibility
		/// </summary>
		public bool ShowToolBar
		{
			get
			{
				return mblnShowToolBar;
			}
			set
			{
				mblnShowToolBar = value;
			}
		}

		/// 
		/// Gets or sets the link windows status bar visibility
		/// </summary>
		public bool ShowStatusBar
		{
			get
			{
				return mblnShowStatusBar;
			}
			set
			{
				mblnShowStatusBar = value;
			}
		}

		/// 
		/// Gets or sets the resizable mode of the link window
		/// </summary>
		public bool Resizable
		{
			get
			{
				return mblnResizable;
			}
			set
			{
				mblnResizable = value;
			}
		}

		/// 
		/// Gets or sets the scrollbars visibility in the link window
		/// </summary>
		public bool ScrollBars
		{
			get
			{
				return mblnScrollBars;
			}
			set
			{
				mblnScrollBars = value;
			}
		}

		/// 
		/// Gets or sets the link targer
		/// </summary>
		public string Target
		{
			get
			{
				return mstrTarget;
			}
			set
			{
				mstrTarget = value;
			}
		}

		/// 
		/// Create a new link parameters instance
		/// </summary>
		public LinkParameters()
		{
		}

		/// 
		/// Create a new link parameters instance
		/// </summary>
		/// <param name="enmWindowStyle">The link window style</param>
		public LinkParameters(LinkWindowStyle enmWindowStyle)
		{
		}

		/// 
		/// Create a new link parameters instance
		/// </summary>
		/// <param name="enmWindowStyle">The link window style</param>
		/// <param name="objWindowSize">The link window size</param>
		public LinkParameters(LinkWindowStyle enmWindowStyle, Size objWindowSize)
		{
			menmWindowStyle = enmWindowStyle;
			mobjWindowSize = objWindowSize;
		}
	}
}

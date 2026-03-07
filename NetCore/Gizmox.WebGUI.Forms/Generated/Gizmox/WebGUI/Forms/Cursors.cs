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
	/// Provides a collection of <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> objects for use by a Windows Forms application.</summary>
	/// 2</filterpriority>
	[Serializable]
	public sealed class Cursors
	{
		private static Cursor appStarting;

		private static Cursor arrow;

		private static Cursor cross;

		private static Cursor defaultCursor;

		private static Cursor hand;

		private static Cursor help;

		private static Cursor hSplit;

		private static Cursor iBeam;

		private static Cursor no;

		private static Cursor noMove2D;

		private static Cursor noMoveHoriz;

		private static Cursor noMoveVert;

		private static Cursor panEast;

		private static Cursor panNE;

		private static Cursor panNorth;

		private static Cursor panNW;

		private static Cursor panSE;

		private static Cursor panSouth;

		private static Cursor panSW;

		private static Cursor panWest;

		private static Cursor sizeAll;

		private static Cursor sizeNESW;

		private static Cursor sizeNS;

		private static Cursor sizeNWSE;

		private static Cursor sizeWE;

		private static Cursor upArrow;

		private static Cursor vSplit;

		private static Cursor wait;

		/// Gets the cursor that appears when an application starts.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears when an application starts.</returns>
		/// 1</filterpriority>
		public static Cursor AppStarting
		{
			get
			{
				if (appStarting == null)
				{
					appStarting = new Cursor("AppStarting", "progress");
				}
				return appStarting;
			}
		}

		/// Gets the arrow cursor.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the arrow cursor.</returns>
		/// 1</filterpriority>
		public static Cursor Arrow
		{
			get
			{
				if (arrow == null)
				{
					arrow = new Cursor("Arrow");
				}
				return arrow;
			}
		}

		/// Gets the crosshair cursor.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the crosshair cursor.</returns>
		/// 1</filterpriority>
		public static Cursor Cross
		{
			get
			{
				if (cross == null)
				{
					cross = new Cursor("Cross");
				}
				return cross;
			}
		}

		/// Gets the default cursor, which is usually an arrow cursor.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the default cursor.</returns>
		/// 1</filterpriority>
		public static Cursor Default
		{
			get
			{
				if (defaultCursor == null)
				{
					defaultCursor = new Cursor("Default");
				}
				return defaultCursor;
			}
		}

		/// Gets the hand cursor, typically used when hovering over a Web link.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the hand cursor.</returns>
		/// 1</filterpriority>
		public static Cursor Hand
		{
			get
			{
				if (hand == null)
				{
					hand = new Cursor("Hand", "pointer");
				}
				return hand;
			}
		}

		/// Gets the Help cursor, which is a combination of an arrow and a question mark.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the Help cursor.</returns>
		/// 1</filterpriority>
		public static Cursor Help
		{
			get
			{
				if (help == null)
				{
					help = new Cursor("Help", "help");
				}
				return help;
			}
		}

		/// Gets the cursor that appears when the mouse is positioned over a horizontal splitter bar.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears when the mouse is positioned over a horizontal splitter bar.</returns>
		/// 1</filterpriority>
		public static Cursor HSplit
		{
			get
			{
				if (hSplit == null)
				{
					hSplit = new Cursor("HSplit");
				}
				return hSplit;
			}
		}

		/// Gets the I-beam cursor, which is used to show where the text cursor appears when the mouse is clicked.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the I-beam cursor.</returns>
		/// 1</filterpriority>
		public static Cursor IBeam
		{
			get
			{
				if (iBeam == null)
				{
					iBeam = new Cursor("IBeam", "text");
				}
				return iBeam;
			}
		}

		/// Gets the cursor that indicates that a particular region is invalid for the current operation.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that indicates that a particular region is invalid for the current operation.</returns>
		/// 1</filterpriority>
		public static Cursor No
		{
			get
			{
				if (no == null)
				{
					no = new Cursor("No", "not-allowed");
				}
				return no;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is not moving, but the window can be scrolled in both a horizontal and vertical direction.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is not moving.</returns>
		/// 1</filterpriority>
		public static Cursor NoMove2D
		{
			get
			{
				if (noMove2D == null)
				{
					noMove2D = new Cursor("NoMove2D");
				}
				return noMove2D;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is not moving, but the window can be scrolled in a horizontal direction.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is not moving.</returns>
		/// 1</filterpriority>
		public static Cursor NoMoveHoriz
		{
			get
			{
				if (noMoveHoriz == null)
				{
					noMoveHoriz = new Cursor("NoMoveHoriz");
				}
				return noMoveHoriz;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is not moving, but the window can be scrolled in a vertical direction.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is not moving.</returns>
		/// 1</filterpriority>
		public static Cursor NoMoveVert
		{
			get
			{
				if (noMoveVert == null)
				{
					noMoveVert = new Cursor("NoMoveVert");
				}
				return noMoveVert;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the right.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the right.</returns>
		/// 1</filterpriority>
		public static Cursor PanEast
		{
			get
			{
				if (panEast == null)
				{
					panEast = new Cursor("PanEast");
				}
				return panEast;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the right.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the right.</returns>
		/// 1</filterpriority>
		public static Cursor PanNE
		{
			get
			{
				if (panNE == null)
				{
					panNE = new Cursor("PanNE");
				}
				return panNE;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in an upward direction.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in an upward direction.</returns>
		/// 1</filterpriority>
		public static Cursor PanNorth
		{
			get
			{
				if (panNorth == null)
				{
					panNorth = new Cursor("PanNorth");
				}
				return panNorth;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the left.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the left.</returns>
		/// 1</filterpriority>
		public static Cursor PanNW
		{
			get
			{
				if (panNW == null)
				{
					panNW = new Cursor("PanNW");
				}
				return panNW;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the right.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the right.</returns>
		/// 1</filterpriority>
		public static Cursor PanSE
		{
			get
			{
				if (panSE == null)
				{
					panSE = new Cursor("PanSE");
				}
				return panSE;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in a downward direction.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in a downward direction.</returns>
		/// 1</filterpriority>
		public static Cursor PanSouth
		{
			get
			{
				if (panSouth == null)
				{
					panSouth = new Cursor("PanSouth");
				}
				return panSouth;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the left.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the left.</returns>
		/// 1</filterpriority>
		public static Cursor PanSW
		{
			get
			{
				if (panSW == null)
				{
					panSW = new Cursor("PanSW");
				}
				return panSW;
			}
		}

		/// Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the left.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the left.</returns>
		/// 1</filterpriority>
		public static Cursor PanWest
		{
			get
			{
				if (panWest == null)
				{
					panWest = new Cursor("PanWest");
				}
				return panWest;
			}
		}

		/// Gets the four-headed sizing cursor, which consists of four joined arrows that point north, south, east, and west.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the four-headed sizing cursor.</returns>
		/// 1</filterpriority>
		public static Cursor SizeAll
		{
			get
			{
				if (sizeAll == null)
				{
					sizeAll = new Cursor("SizeAll");
				}
				return sizeAll;
			}
		}

		/// Gets the two-headed diagonal (northeast/southwest) sizing cursor.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents two-headed diagonal (northeast/southwest) sizing cursor.</returns>
		/// 1</filterpriority>
		public static Cursor SizeNESW
		{
			get
			{
				if (sizeNESW == null)
				{
					sizeNESW = new Cursor("SizeNESW");
				}
				return sizeNESW;
			}
		}

		/// Gets the two-headed vertical (north/south) sizing cursor.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the two-headed vertical (north/south) sizing cursor.</returns>
		/// 1</filterpriority>
		public static Cursor SizeNS
		{
			get
			{
				if (sizeNS == null)
				{
					sizeNS = new Cursor("SizeNS");
				}
				return sizeNS;
			}
		}

		/// Gets the two-headed diagonal (northwest/southeast) sizing cursor.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the two-headed diagonal (northwest/southeast) sizing cursor.</returns>
		/// 1</filterpriority>
		public static Cursor SizeNWSE
		{
			get
			{
				if (sizeNWSE == null)
				{
					sizeNWSE = new Cursor("SizeNWSE");
				}
				return sizeNWSE;
			}
		}

		/// Gets the two-headed horizontal (west/east) sizing cursor.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the two-headed horizontal (west/east) sizing cursor.</returns>
		/// 1</filterpriority>
		public static Cursor SizeWE
		{
			get
			{
				if (sizeWE == null)
				{
					sizeWE = new Cursor("SizeWE");
				}
				return sizeWE;
			}
		}

		/// Gets the up arrow cursor, typically used to identify an insertion point.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the up arrow cursor.</returns>
		/// 1</filterpriority>
		public static Cursor UpArrow
		{
			get
			{
				if (upArrow == null)
				{
					upArrow = new Cursor("UpArrow");
				}
				return upArrow;
			}
		}

		/// Gets the cursor that appears when the mouse is positioned over a vertical splitter bar.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears when the mouse is positioned over a vertical splitter bar.</returns>
		/// 1</filterpriority>
		public static Cursor VSplit
		{
			get
			{
				if (vSplit == null)
				{
					vSplit = new Cursor("VSplit");
				}
				return vSplit;
			}
		}

		/// Gets the wait cursor, typically an hourglass shape.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the wait cursor.</returns>
		/// 1</filterpriority>
		public static Cursor WaitCursor
		{
			get
			{
				if (wait == null)
				{
					wait = new Cursor("WaitCursor", "wait");
				}
				return wait;
			}
		}

		private Cursors()
		{
		}

		internal static Cursor KnownCursorFromHCursor(IntPtr handle)
		{
			if (handle == IntPtr.Zero)
			{
				return null;
			}
			return Default;
		}
	}
}

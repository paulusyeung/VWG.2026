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
/// Represents a display device or multiple display devices on a single system.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class Screen
	{
		/// 
		/// Related screen context
		/// </summary>
		private IContextParams mobjContextParams = null;

		/// Gets an array of all displays on the system.</summary>
		/// An array of type <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>, containing all displays on the system.</returns>
		public static Screen[] AllScreens => new Screen[1] { PrimaryScreen };

		/// Gets the number of bits of memory, associated with one pixel of data.</summary>
		/// The number of bits of memory, associated with one pixel of data </returns>
		public int BitsPerPixel
		{
			get
			{
				if (mobjContextParams == null)
				{
					return 16;
				}
				return mobjContextParams.ScreenColorDepth;
			}
		}

		/// Gets the bounds of the display.</summary>
		/// A <see cref="T:System.Drawing.Rectangle"></see>, representing the bounds of the display.</returns>
		public Rectangle Bounds
		{
			get
			{
				if (mobjContextParams == null)
				{
					return new Rectangle(0, 0, 800, 600);
				}
				return new Rectangle(0, 0, mobjContextParams.ScreenWidth, mobjContextParams.ScreenHeight);
			}
		}

		/// Gets the device name associated with a display.</summary>
		/// The device name associated with a display.</returns>
		public string DeviceName => "Device0";

		/// Gets a value indicating whether a particular display is the primary device.</summary>
		/// true if this display is primary; otherwise, false.</returns>
		public bool Primary => true;

		/// Gets the primary display.</summary>
		/// The primary display.</returns>
		public static Screen PrimaryScreen => new Screen((IContextParams)VWGContext.Current);

		/// Gets the working area of the display. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
		/// A <see cref="T:System.Drawing.Rectangle"></see>, representing the working area of the display.</returns>
		public Rectangle WorkingArea
		{
			get
			{
				if (mobjContextParams == null)
				{
					return new Rectangle(0, 0, 800, 600);
				}
				return new Rectangle(0, 0, mobjContextParams.ScreenAvailableWidth, mobjContextParams.ScreenAvailableHeight);
			}
		}

		static Screen()
		{
		}

		internal Screen(IContextParams objContextParams)
		{
			mobjContextParams = objContextParams;
		}

		/// Gets or sets a value indicating whether the specified object is equal to this Screen.</summary>
		/// true if the specified object is equal to this <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>; otherwise, false.</returns>
		/// <param name="obj">The object to compare to this <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest portion of the specified control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest region of the specified control. In multiple display environments where no display contains the control, the display closest to the specified control is returned.</returns>
		/// <param name="objControl">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
		public static Screen FromControl(Control objControl)
		{
			return PrimaryScreen;
		}

		/// Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest portion of the object referred to by the specified handle.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest region of the object. In multiple display environments where no display contains any portion of the specified window, the display closest to the object is returned.</returns>
		/// <param name="objWindowHandle">The window handle for which to retrieve the <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
		public static Screen FromHandle(IntPtr objWindowHandle)
		{
			return PrimaryScreen;
		}

		/// Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the specified point.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the point. In multiple display environments where no display contains the point, the display closest to the specified point is returned.</returns>
		/// <param name="objPoint">A <see cref="T:System.Drawing.Point"></see> that specifies the location for which to retrieve a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see>. </param>
		public static Screen FromPoint(Point objPoint)
		{
			return PrimaryScreen;
		}

		/// Retrieves a <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest portion of the rectangle.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Screen"></see> for the display that contains the largest region of the specified rectangle. In multiple display environments where no display contains the rectangle, the display closest to the rectangle is returned.</returns>
		/// <param name="objRectangle">A <see cref="T:System.Drawing.Rectangle"></see> that specifies the area for which to retrieve the display. </param>
		public static Screen FromRectangle(Rectangle objRectangle)
		{
			return PrimaryScreen;
		}

		/// 
		/// Retrieves the bounds of the display that contains the specified point.
		/// </summary>
		/// <param name="objPoint">A <see cref="T:System.Drawing.Point"></see> that specifies the coordinates for which to retrieve the display bounds.</param>
		/// 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the bounds of the display that contains the specified point. In multiple display environments where no display contains the specified point, the display closest to the point is returned.
		/// </returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public static Rectangle GetBounds(Point objPoint)
		{
			return PrimaryScreen.Bounds;
		}

		/// 
		/// Retrieves the bounds of the display that contains the largest portion of the specified rectangle.
		/// </summary>
		/// <param name="objRectangle">A <see cref="T:System.Drawing.Rectangle"></see> that specifies the area for which to retrieve the display bounds.</param>
		/// 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the bounds of the display that contains the specified rectangle. In multiple display environments where no monitor contains the specified rectangle, the monitor closest to the rectangle is returned.
		/// </returns>
		public static Rectangle GetBounds(Rectangle objRectangle)
		{
			return PrimaryScreen.Bounds;
		}

		/// 
		/// Retrieves the bounds of the display that contains the largest portion of the specified control.
		/// </summary>
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve the display bounds.</param>
		/// 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the bounds of the display that contains the specified control. In multiple display environments where no display contains the specified control, the display closest to the control is returned.
		/// </returns>
		public static Rectangle GetBounds(Control objControl)
		{
			return PrimaryScreen.Bounds;
		}

		/// Computes and retrieves a hash code for an object.</summary>
		/// A hash code for an object.</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// Retrieves the working area closest to the specified point. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
		/// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the working area. In multiple display environments where no display contains the specified point, the display closest to the point is returned.</returns>
		/// <param name="objPoint">A <see cref="T:System.Drawing.Point"></see> that specifies the coordinates for which to retrieve the working area. </param>
		public static Rectangle GetWorkingArea(Point objPoint)
		{
			return PrimaryScreen.WorkingArea;
		}

		/// Retrieves the working area for the display that contains the largest portion of the specified rectangle. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
		/// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the working area. In multiple display environments where no display contains the specified rectangle, the display closest to the rectangle is returned.</returns>
		/// <param name="objRectangle">The <see cref="T:System.Drawing.Rectangle"></see> that specifies the area for which to retrieve the working area. </param>
		public static Rectangle GetWorkingArea(Rectangle objRectangle)
		{
			return PrimaryScreen.WorkingArea;
		}

		/// Retrieves the working area for the display that contains the largest region of the specified control. The working area is the desktop area of the display, excluding taskbars, docked windows, and docked tool bars.</summary>
		/// A <see cref="T:System.Drawing.Rectangle"></see> that specifies the working area. In multiple display environments where no display contains the specified control, the display closest to the control is returned.</returns>
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve the working area. </param>
		public static Rectangle GetWorkingArea(Control objControl)
		{
			return PrimaryScreen.WorkingArea;
		}

		/// Retrieves a string representing this object.</summary>
		/// A string representation of the object.</returns>
		public override string ToString()
		{
			return GetType().Name + "[Bounds=" + Bounds.ToString() + " WorkingArea=" + WorkingArea.ToString() + " Primary=" + Primary + " DeviceName=" + DeviceName;
		}
	}
}

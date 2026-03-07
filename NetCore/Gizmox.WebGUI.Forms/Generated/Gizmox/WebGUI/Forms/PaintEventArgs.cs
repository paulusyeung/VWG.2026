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
	/// Provides data for the Paint event.
	/// </summary>
	[Serializable]
	public class PaintEventArgs : EventArgs, IDisposable
	{
		private readonly Rectangle mobjClipRectangle;

		private readonly IntPtr mobjDC;

		private Graphics mobjGraphics;

		private IntPtr mobjOldPal;

		private GraphicsState mobjSavedGraphicsState;

		/// 
		/// Gets the clip rectangle.
		/// </summary>
		/// The clip rectangle.</value>
		public Rectangle ClipRectangle => mobjClipRectangle;

		/// 
		/// Gets the graphics.
		/// </summary>
		/// The graphics.</value>
		public Graphics Graphics
		{
			get
			{
				if (mobjGraphics == null && mobjDC != IntPtr.Zero)
				{
					mobjGraphics = Graphics.FromHdcInternal(mobjDC);
					mobjGraphics.PageUnit = GraphicsUnit.Pixel;
					mobjSavedGraphicsState = mobjGraphics.Save();
				}
				return mobjGraphics;
			}
		}

		internal IntPtr HDC
		{
			get
			{
				if (mobjGraphics == null)
				{
					return mobjDC;
				}
				return IntPtr.Zero;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs" /> class.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objClipRect">The clip rect.</param>
		public PaintEventArgs(Graphics objGraphics, Rectangle objClipRect)
		{
			mobjDC = IntPtr.Zero;
			mobjOldPal = IntPtr.Zero;
			if (objGraphics == null)
			{
				throw new ArgumentNullException("graphics");
			}
			mobjGraphics = objGraphics;
			mobjClipRectangle = objClipRect;
		}

		internal PaintEventArgs(IntPtr objDC, Rectangle objClipRect)
		{
			mobjDC = IntPtr.Zero;
			mobjOldPal = IntPtr.Zero;
			mobjDC = objDC;
			mobjClipRectangle = objClipRect;
		}

		/// 
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs" /> is reclaimed by garbage collection.
		/// </summary>
		~PaintEventArgs()
		{
			Dispose(blnDisposing: false);
		}

		/// 
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(blnDisposing: true);
			GC.SuppressFinalize(this);
		}

		/// 
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="blnDisposing">true</c> to release both managed and unmanaged resources; false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool blnDisposing)
		{
			if (blnDisposing && mobjGraphics != null && mobjDC != IntPtr.Zero)
			{
				mobjGraphics.Dispose();
			}
			if (mobjOldPal != IntPtr.Zero && mobjDC != IntPtr.Zero)
			{
				mobjOldPal = IntPtr.Zero;
			}
		}

		internal void ResetGraphics()
		{
			if (mobjGraphics != null && mobjSavedGraphicsState != null)
			{
				mobjGraphics.Restore(mobjSavedGraphicsState);
				mobjSavedGraphicsState = null;
			}
		}
	}
}

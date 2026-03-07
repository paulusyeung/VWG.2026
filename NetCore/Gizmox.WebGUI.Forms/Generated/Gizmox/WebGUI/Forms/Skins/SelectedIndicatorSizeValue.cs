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

namespace Gizmox.WebGUI.Forms.Skins
{
	/// 
	///
	/// </summary>
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[TypeConverter(typeof(SelectedIndicatorSizeValueConverter))]
	public class SelectedIndicatorSizeValue
	{
		private CommonSkin mobjCommonSkin;

		/// 
		/// Gets the top Size.
		/// </summary>
		/// The top Size.</value>
		public Size TopSize
		{
			get
			{
				return mobjCommonSkin.TopSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.TopSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Gets the bottom Size.
		/// </summary>
		/// The bottom Size.</value>
		public Size BottomSize
		{
			get
			{
				return mobjCommonSkin.BottomSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.BottomSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Gets the left Size.
		/// </summary>
		/// The left Size.</value>
		public Size LeftSize
		{
			get
			{
				return mobjCommonSkin.LeftSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.LeftSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Gets the left top Size.
		/// </summary>
		/// The left top Size.</value>
		public Size LeftTopSize
		{
			get
			{
				return mobjCommonSkin.LeftTopSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.LeftTopSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Gets the left bottom Size.
		/// </summary>
		/// The left bottom Size.</value>
		public Size LeftBottomSize
		{
			get
			{
				return mobjCommonSkin.LeftBottomSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.LeftBottomSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Gets the right Size.
		/// </summary>
		/// The right Size.</value>
		public Size RightSize
		{
			get
			{
				return mobjCommonSkin.RightSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.RightSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Gets the right top Size.
		/// </summary>
		/// The right top Size.</value>
		public Size RightTopSize
		{
			get
			{
				return mobjCommonSkin.RightTopSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.RightTopSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Gets the right bottom Size.
		/// </summary>
		/// The right bottom Size.</value>
		public Size RightBottomSize
		{
			get
			{
				return mobjCommonSkin.RightBottomSelectedIndicatorSize;
			}
			set
			{
				mobjCommonSkin.RightBottomSelectedIndicatorSize = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.SelectedIndicatorSizeValue" /> class.
		/// </summary>
		/// <param name="objCommonSkin">The obj common skin.</param>
		/// <exception cref="T:System.ArgumentNullException">objCommonSkin</exception>
		public SelectedIndicatorSizeValue(CommonSkin objCommonSkin)
		{
			if (objCommonSkin == null)
			{
				throw new ArgumentNullException("objCommonSkin");
			}
			mobjCommonSkin = objCommonSkin;
		}

		/// 
		/// Resets the size of the top.
		/// </summary>
		private void ResetTopSize()
		{
			mobjCommonSkin.ResetTopSelectedIndicatorSize();
		}

		/// 
		/// Resets the size of the bottom.
		/// </summary>
		private void ResetBottomSize()
		{
			mobjCommonSkin.ResetBottomSelectedIndicatorSize();
		}

		/// 
		/// Resets the size of the left.
		/// </summary>
		private void ResetLeftSize()
		{
			mobjCommonSkin.ResetLeftSelectedIndicatorSize();
		}

		/// 
		/// Resets the size of the left top.
		/// </summary>
		private void ResetLeftTopSize()
		{
			mobjCommonSkin.ResetLeftTopSelectedIndicatorSize();
		}

		/// 
		/// Resets the size of the left bottom.
		/// </summary>
		private void ResetLeftBottomSize()
		{
			mobjCommonSkin.ResetLeftBottomSelectedIndicatorSize();
		}

		/// 
		/// Resets the size of the right.
		/// </summary>
		private void ResetRightSize()
		{
			mobjCommonSkin.ResetRightSelectedIndicatorSize();
		}

		/// 
		/// Resets the size of the right top.
		/// </summary>
		private void ResetRightTopSize()
		{
			mobjCommonSkin.ResetRightTopSelectedIndicatorSize();
		}

		/// 
		/// Resets the size of the right bottom.
		/// </summary>
		private void ResetRightBottomSize()
		{
			mobjCommonSkin.ResetRightBottomSelectedIndicatorSize();
		}
	}
}

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
	/// Encapsulates the information needed when creating a control.</summary>
	[Serializable]
	public class CreateParams : SerializableObject
	{
		private static readonly SerializableProperty mstrCaptionProperty = SerializableProperty.Register("mstrCaption", typeof(string), typeof(CreateParams));

		private static readonly SerializableProperty mstrClassNameProperty = SerializableProperty.Register("mstrClassName", typeof(string), typeof(CreateParams));

		private static readonly SerializableProperty mstrClassStyleProperty = SerializableProperty.Register("mstrClassStyle", typeof(int), typeof(CreateParams));

		private static readonly SerializableProperty mintHeightProperty = SerializableProperty.Register("mintHeight", typeof(int), typeof(CreateParams));

		private static readonly SerializableProperty mobjParamProperty = SerializableProperty.Register("mobjParam", typeof(object), typeof(CreateParams));

		private static readonly SerializableProperty mintWidthProperty = SerializableProperty.Register("mintWidth", typeof(int), typeof(CreateParams));

		private static readonly SerializableProperty mintXProperty = SerializableProperty.Register("mintX", typeof(int), typeof(CreateParams));

		private static readonly SerializableProperty mintYProperty = SerializableProperty.Register("mintY", typeof(int), typeof(CreateParams));

		private string mstrCaption
		{
			get
			{
				return GetValue(mstrCaptionProperty);
			}
			set
			{
				SetValue(mstrCaptionProperty, value);
			}
		}

		private string mstrClassName
		{
			get
			{
				return GetValue(mstrClassNameProperty);
			}
			set
			{
				SetValue(mstrClassNameProperty, value);
			}
		}

		private int mstrClassStyle
		{
			get
			{
				return GetValue(mstrClassStyleProperty);
			}
			set
			{
				SetValue(mstrClassStyleProperty, value);
			}
		}

		private int mintHeight
		{
			get
			{
				return GetValue(mintHeightProperty);
			}
			set
			{
				SetValue(mintHeightProperty, value);
			}
		}

		private object mobjParam
		{
			get
			{
				return GetValue(mobjParamProperty);
			}
			set
			{
				SetValue(mobjParamProperty, value);
			}
		}

		private int mintWidth
		{
			get
			{
				return GetValue(mintWidthProperty);
			}
			set
			{
				SetValue(mintWidthProperty, value);
			}
		}

		private int mintX
		{
			get
			{
				return GetValue(mintXProperty);
			}
			set
			{
				SetValue(mintXProperty, value);
			}
		}

		private int mintY
		{
			get
			{
				return GetValue(mintYProperty);
			}
			set
			{
				SetValue(mintYProperty, value);
			}
		}

		/// Gets or sets the control's initial text.</summary>
		/// The control's initial text.</returns>
		/// 1</filterpriority>
		public string Caption
		{
			get
			{
				return mstrCaption;
			}
			set
			{
				mstrCaption = value;
			}
		}

		/// Gets or sets the name of the Windows class to derive the control from.</summary>
		/// The name of the Windows class to derive the control from.</returns>
		/// 1</filterpriority>
		public string ClassName
		{
			get
			{
				return mstrClassName;
			}
			set
			{
				mstrClassName = value;
			}
		}

		/// Gets or sets a bitwise combination of class style values.</summary>
		/// A bitwise combination of the class style values.</returns>
		/// 1</filterpriority>
		public int ClassStyle
		{
			get
			{
				return mstrClassStyle;
			}
			set
			{
				mstrClassStyle = value;
			}
		}

		/// Gets or sets a bitwise combination of extended window style values.</summary>
		/// A bitwise combination of the extended window style values.</returns>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ExStyle
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// Gets or sets the initial height of the control.</summary>
		/// The numeric value that represents the initial height of the control.</returns>
		/// 1</filterpriority>
		public int Height
		{
			get
			{
				return mintHeight;
			}
			set
			{
				mintHeight = value;
			}
		}

		/// Gets or sets additional parameter information needed to create the control.</summary>
		/// The <see cref="T:System.Object"></see> that holds additional parameter information needed to create the control.</returns>
		/// 1</filterpriority>
		public object Param
		{
			get
			{
				return mobjParam;
			}
			set
			{
				mobjParam = value;
			}
		}

		/// Gets or sets the control's parent.</summary> 
		/// An <see cref="T:System.IntPtr"></see> that contains the window handle of the control's parent.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IntPtr Parent
		{
			get
			{
				return IntPtr.Zero;
			}
			set
			{
			}
		}

		/// Gets or sets a bitwise combination of window style values.</summary> 
		/// A bitwise combination of the window style values.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Style
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// Gets or sets the initial width of the control.</summary>
		/// The numeric value that represents the initial width of the control.</returns>
		/// 1</filterpriority>
		public int Width
		{
			get
			{
				return mintWidth;
			}
			set
			{
				mintWidth = value;
			}
		}

		/// Gets or sets the initial left position of the control.</summary>
		/// The numeric value that represents the initial left position of the control.</returns>
		/// 1</filterpriority>
		public int X
		{
			get
			{
				return mintX;
			}
			set
			{
				mintX = value;
			}
		}

		/// Gets or sets the top position of the initial location of the control.</summary>
		/// The numeric value that represents the top position of the initial location of the control.</returns>
		/// 1</filterpriority>
		public int Y
		{
			get
			{
				return mintY;
			}
			set
			{
				mintY = value;
			}
		}
	}
}

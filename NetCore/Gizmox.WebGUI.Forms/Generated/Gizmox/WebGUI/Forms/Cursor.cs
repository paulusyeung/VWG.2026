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
/// Represents the image used to paint the mouse pointer.</summary>
	/// 1</filterpriority>
	/// <completionlist cref="T:Gizmox.WebGUI.Forms.Cursors" />
	[Serializable]
	[Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[TypeConverter(typeof(CursorConverter))]
	public sealed class Cursor : IDisposable
	{
		private string mstrType;

		private string mstrStyle;

		/// 
		///
		/// </summary>
		public string Type => mstrType;

		/// 
		/// Gets or sets the bounds that represent the clipping rectangle for the cursor.
		/// </summary>
		/// 
		/// The clip.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static Rectangle Clip
		{
			get
			{
				return Rectangle.Empty;
			}
			set
			{
			}
		}

		/// 
		/// Gets the handle of the cursor.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IntPtr Handle => IntPtr.Zero;

		/// 
		/// Gets the hotspot of cursor.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point HotSpot => Point.Empty;

		/// 
		/// Gets or sets the cursor's position.
		/// </summary>
		/// 
		/// The position.
		/// </value>
		public static Point Position
		{
			get
			{
				if (!(VWGContext.Current is IContextParams { CursorPosition: var cursorPosition }))
				{
					return Point.Empty;
				}
				return cursorPosition;
			}
			private set
			{
			}
		}

		/// 
		/// Gets the size of the cursor object.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size Size => Size.Empty;

		/// 
		/// Gets or sets the tag.
		/// </summary>
		/// 
		/// The tag.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[TypeConverter(typeof(StringConverter))]
		[DefaultValue(null)]
		[SRCategory("CatData")]
		[Localizable(false)]
		[Bindable(true)]
		[SRDescription("ControlTagDescr")]
		public object Tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the Style.
		/// </summary>
		/// 
		/// The Style.
		/// </value>
		private string Style => mstrStyle;

		/// 
		/// Gets or sets the current.
		/// </summary>
		/// 
		/// The current.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Cursor Current
		{
			get
			{
				return Cursors.Default;
			}
			set
			{
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class.
		/// </summary>
		/// <param name="strType">Type of the STR.</param>
		public Cursor(string strType)
			: this(strType, "default")
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class.
		/// </summary>
		/// <param name="strType">Type of the STR.</param>
		/// <param name="strStyle">The STR style.</param>
		public Cursor(string strType, string strStyle)
		{
			mstrType = strType;
			mstrStyle = strStyle;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class from the specified Windows handle.       
		/// </summary>
		/// <param name="ptrHandle">The handle.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public Cursor(IntPtr ptrHandle)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class from the specified data stream.
		/// </summary>
		/// <param name="objStream">The stream.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public Cursor(Stream objStream)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class  from the specified resource with the specified resource type.
		/// </summary>
		/// <param name="objType">The type.</param>
		/// <param name="objResource">The resource.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		public Cursor(Type objType, string objResource)
			: this(objType.Module.Assembly.GetManifestResourceStream(objType, objResource))
		{
		}

		/// 
		/// Renders the cursor.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		internal void RenderCursor(IContext objContext, IAttributeWriter objWriter)
		{
			if (this != Cursors.Default)
			{
				objWriter.WriteAttributeString("CUR", mstrStyle);
			}
		}

		/// Retrieves a human readable string representing this <see cref="T:System.Windows.Forms.Cursor"></see>.</summary>
		/// A <see cref="T:System.String"></see> that represents this <see cref="T:System.Windows.Forms.Cursor"></see>.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			string text = null;
			text = TypeDescriptor.GetConverter(typeof(Cursor)).ConvertToString(this);
			return "[Cursor: " + text + "]";
		}

		/// 
		/// Implements the operator ==.
		/// </summary>
		/// <param name="objCursor1">The left.</param>
		/// <param name="objCursor2">The right.</param>
		/// 
		/// The result of the operator.
		/// </returns>
		public static bool operator ==(Cursor objCursor1, Cursor objCursor2)
		{
			if ((object)objCursor1 == null != ((object)objCursor2 == null))
			{
				return false;
			}
			if (object.Equals(objCursor1, objCursor2))
			{
				return true;
			}
			return string.Equals(objCursor1.Style, objCursor2.Style);
		}

		/// 
		/// Implements the operator !=.
		/// </summary>
		/// <param name="objCursor1">The left.</param>
		/// <param name="objCursor2">The right.</param>
		/// 
		/// The result of the operator.
		/// </returns>
		public static bool operator !=(Cursor objCursor1, Cursor objCursor2)
		{
			return !(objCursor1 == objCursor2);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj is not Cursor cursor)
			{
				return false;
			}
			return string.Equals(Style, cursor.Style, StringComparison.Ordinal);
		}

		/// 
		/// Copies the handle  of this Cursor.
		/// </summary>
		/// </returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IntPtr CopyHandle()
		{
			return IntPtr.Zero;
		}

		/// 
		/// Draws the cursor on the specified surface, within the specified bounds.
		/// </summary>
		/// <param name="objGraphics">The g.</param>
		/// <param name="objTargetRect">The target rect.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void Draw(Graphics objGraphics, Rectangle objTargetRect)
		{
		}

		/// 
		/// Draws the cursor in a stretched format on the specified surface, within the specified bounds.
		/// </summary>
		/// <param name="objGraphics">The g.</param>
		/// <param name="objTargetRect">The target rect.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void DrawStretched(Graphics objGraphics, Rectangle objTargetRect)
		{
		}

		/// 
		/// Returns a hash code for this Cursor.
		/// </summary>
		/// 
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override int GetHashCode()
		{
			return Style?.GetHashCode(StringComparison.Ordinal) ?? 0;
		}

		/// 
		/// Hides the cursor.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static void Hide()
		{
		}

		/// 
		/// Shows this cursor.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static void Show()
		{
		}

		/// 
		///             Releases all resources used by the Cursor.
		/// </summary>
		public void Dispose()
		{
		}
	}
}

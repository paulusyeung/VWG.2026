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
	/// Represents border thickness information associated with a user interface (UI) element.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(BorderWidthConverter))]
	public struct BorderWidth
	{
		private bool mblnAll;

		private int mintTop;

		private int mintLeft;

		private int mintRight;

		private int mintBottom;

		/// 
		/// Provides a <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> object with no thickness.
		/// </summary>
		public static readonly BorderWidth Empty;

		/// 
		/// Gets or sets the thickness value for all the edges.
		/// </summary>
		/// The thickness, in pixels, for all edges if the same; otherwise, -1.</returns>
		[Browsable(false)]
		public int All
		{
			get
			{
				if (!mblnAll)
				{
					return -1;
				}
				return mintTop;
			}
			set
			{
				if (!mblnAll || mintTop != value)
				{
					mblnAll = true;
					mintTop = (mintLeft = (mintRight = (mintBottom = value)));
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance is all.
		/// </summary>
		/// true</c> if this instance is all; otherwise, false</c>.</value>
		internal bool IsAll => mblnAll;

		/// 
		/// Gets or sets the thickness value for the bottom edge.
		/// </summary>
		/// The thickness, in pixels, for the bottom edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Bottom
		{
			get
			{
				if (mblnAll)
				{
					return mintTop;
				}
				return mintBottom;
			}
			set
			{
				if (mblnAll || mintBottom != value)
				{
					mblnAll = false;
					mintBottom = value;
				}
			}
		}

		/// 
		/// Gets or sets the thickness value for the left edge.
		/// </summary>
		/// The thickness, in pixels, for the left edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Left
		{
			get
			{
				if (mblnAll)
				{
					return mintTop;
				}
				return mintLeft;
			}
			set
			{
				if (mblnAll || mintLeft != value)
				{
					mblnAll = false;
					mintLeft = value;
				}
			}
		}

		/// 
		/// Gets or sets the thickness value for the right edge.
		/// </summary>
		/// The thickness, in pixels, for the right edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Right
		{
			get
			{
				if (mblnAll)
				{
					return mintTop;
				}
				return mintRight;
			}
			set
			{
				if (mblnAll || mintRight != value)
				{
					mblnAll = false;
					mintRight = value;
				}
			}
		}

		/// 
		/// Gets or sets the thickness value for the top edge.
		/// </summary>
		/// The thickness, in pixels, for the top edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Top
		{
			get
			{
				return mintTop;
			}
			set
			{
				if (mblnAll || mintTop != value)
				{
					mblnAll = false;
					mintTop = value;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using the supplied thickness size for all edges.
		/// </summary>
		/// <param name="intAll">The number of pixels to be used for thickness for all edges.</param>
		public BorderWidth(int intAll)
		{
			mblnAll = true;
			mintTop = (mintLeft = (mintRight = (mintBottom = intAll)));
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using a separate thickness size for each edge.
		/// </summary>
		/// <param name="intRight">The thickness size, in pixels, for the right edge.</param>
		/// <param name="intBottom">The thickness size, in pixels, for the bottom edge.</param>
		/// <param name="intLeft">The thickness size, in pixels, for the left edge.</param>
		/// <param name="intTop">The thickness size, in pixels, for the top edge.</param>
		public BorderWidth(int intLeft, int intTop, int intRight, int intBottom)
		{
			mintTop = intTop;
			mintLeft = intLeft;
			mintRight = intRight;
			mintBottom = intBottom;
			mblnAll = mintTop == mintLeft && mintTop == mintRight && mintTop == mintBottom;
		}

		/// 
		/// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
		/// </summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equivalent; otherwise, false.</returns>
		/// <param name="other">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.</param>
		public override bool Equals(object other)
		{
			if (other is BorderWidth borderWidth && borderWidth.mblnAll == mblnAll && borderWidth.mintTop == mintTop && borderWidth.mintLeft == mintLeft && borderWidth.mintBottom == mintBottom)
			{
				return borderWidth.mintRight == mintRight;
			}
			return false;
		}

		/// 
		/// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equivalent.
		/// </summary>
		/// true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are equal; otherwise, false.</returns>
		/// <param name="objWidth2">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
		/// <param name="objWidth1">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
		public static bool operator ==(BorderWidth objWidth1, BorderWidth objWidth2)
		{
			if (objWidth1.Left == objWidth2.Left && objWidth1.Top == objWidth2.Top && objWidth1.Right == objWidth2.Right)
			{
				return objWidth1.Bottom == objWidth2.Bottom;
			}
			return false;
		}

		/// 
		/// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are not equivalent.
		/// </summary>
		/// true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> objects are different; otherwise, false.</returns>
		/// <param name="objWidth2">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
		/// <param name="objWidth1">A <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> to test.</param>
		public static bool operator !=(BorderWidth objWidth1, BorderWidth objWidth2)
		{
			return !(objWidth1 == objWidth2);
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.BorderWidth" /> to <see cref="T:System.Int32" />.
		/// </summary>
		/// <param name="objBorderWidth">The thickness.</param>
		/// The result of the conversion.</returns>
		public static implicit operator int(BorderWidth objBorderWidth)
		{
			return objBorderWidth.All;
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:System.Int32" /> to <see cref="T:Gizmox.WebGUI.Forms.BorderWidth" />.
		/// </summary>
		/// <param name="intBorderWidth">The thickness.</param>
		/// The result of the conversion.</returns>
		public static implicit operator BorderWidth(int intBorderWidth)
		{
			return new BorderWidth(intBorderWidth);
		}

		/// 
		/// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
		/// </summary>
		/// 
		/// A 32-bit signed integer.
		/// </returns>
		public override int GetHashCode()
		{
			return Left ^ ClientUtils.RotateLeft(Top, 8) ^ ClientUtils.RotateLeft(Right, 16) ^ ClientUtils.RotateLeft(Bottom, 24);
		}

		/// 
		/// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
		/// </summary>
		/// 
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see>.
		/// </returns>
		public override string ToString()
		{
			string[] array = new string[9]
			{
				"{Left=",
				Left.ToString(),
				",Top=",
				Top.ToString(),
				",Right=",
				Right.ToString(),
				",Bottom=",
				Bottom.ToString(),
				"}"
			};
			return string.Concat(array);
		}

		private void ResetAll()
		{
			All = 0;
		}

		private void ResetBottom()
		{
			Bottom = 0;
		}

		private void ResetLeft()
		{
			Left = 0;
		}

		private void ResetRight()
		{
			Right = 0;
		}

		private void ResetTop()
		{
			Top = 0;
		}

		internal void Scale(float fltX, float fltY)
		{
			mintTop = (int)((float)mintTop * fltY);
			mintLeft = (int)((float)mintLeft * fltX);
			mintRight = (int)((float)mintRight * fltX);
			mintBottom = (int)((float)mintBottom * fltY);
		}

		internal bool ShouldSerializeAll()
		{
			return mblnAll;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderWidth"></see> class using the supplied thickness size for all edges.
		/// </summary>
		static BorderWidth()
		{
			Empty = new BorderWidth(0);
		}
	}
}

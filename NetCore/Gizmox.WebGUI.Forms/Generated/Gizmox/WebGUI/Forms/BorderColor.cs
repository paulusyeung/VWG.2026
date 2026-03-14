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
	/// Represents color information associated with a user interface (UI) element.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(BorderColorConverter))]
	[WebEditor(typeof(BorderColorEditor), typeof(WebUITypeEditor))]
	[Editor("Gizmox.WebGUI.Forms.Design.BorderColorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public struct BorderColor
	{
		private bool mblnAll;

		private Color mobjTop;

		private Color mobjLeft;

		private Color mobjRight;

		private Color mobjBottom;

		/// 
		/// Provides a <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> object with no color.
		/// </summary>
		public static readonly BorderColor Empty;

		/// 
		/// Gets or sets all.
		/// </summary>
		/// All.</value>
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public Color All
		{
			get
			{
				if (!mblnAll)
				{
					return Color.Empty;
				}
				return mobjTop;
			}
			set
			{
				if (!mblnAll || mobjTop != value)
				{
					mblnAll = true;
					mobjTop = (mobjLeft = (mobjRight = (mobjBottom = value)));
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance is all.
		/// </summary>
		/// true</c> if this instance is all; otherwise, false</c>.</value>
		internal bool IsAll => mblnAll;

		/// 
		/// Gets or sets the bottom.
		/// </summary>
		/// The bottom.</value>
		[RefreshProperties(RefreshProperties.All)]
		public Color Bottom
		{
			get
			{
				if (mblnAll)
				{
					return mobjTop;
				}
				return mobjBottom;
			}
			set
			{
				if (mblnAll || mobjBottom != value)
				{
					mblnAll = false;
					mobjBottom = value;
				}
			}
		}

		/// 
		/// Gets or sets the left.
		/// </summary>
		/// The left.</value>
		[RefreshProperties(RefreshProperties.All)]
		public Color Left
		{
			get
			{
				if (mblnAll)
				{
					return mobjTop;
				}
				return mobjLeft;
			}
			set
			{
				if (mblnAll || mobjLeft != value)
				{
					mblnAll = false;
					mobjLeft = value;
				}
			}
		}

		/// 
		/// Gets or sets the right.
		/// </summary>
		/// The right.</value>
		[RefreshProperties(RefreshProperties.All)]
		public Color Right
		{
			get
			{
				if (mblnAll)
				{
					return mobjTop;
				}
				return mobjRight;
			}
			set
			{
				if (mblnAll || mobjRight != value)
				{
					mblnAll = false;
					mobjRight = value;
				}
			}
		}

		/// 
		/// Gets or sets the top.
		/// </summary>
		/// The top.</value>
		[RefreshProperties(RefreshProperties.All)]
		public Color Top
		{
			get
			{
				return mobjTop;
			}
			set
			{
				if (mblnAll || mobjTop != value)
				{
					mblnAll = false;
					mobjTop = value;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColor" /> struct.
		/// </summary>
		/// <param name="objAll">All.</param>
		public BorderColor(Color objAll)
		{
			mblnAll = true;
			mobjTop = (mobjLeft = (mobjRight = (mobjBottom = objAll)));
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColor" /> struct.
		/// </summary>
		/// <param name="objLeft">The left.</param>
		/// <param name="objTop">The top.</param>
		/// <param name="objRight">The right.</param>
		/// <param name="objBottom">The bottom.</param>
		public BorderColor(Color objLeft, Color objTop, Color objRight, Color objBottom)
		{
			mobjTop = objTop;
			mobjLeft = objLeft;
			mobjRight = objRight;
			mobjBottom = objBottom;
			mblnAll = !(mobjTop != mobjLeft) && !(mobjTop != mobjRight) && mobjTop == mobjBottom;
		}

		/// 
		/// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
		/// </summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equivalent; otherwise, false.</returns>
		/// <param name="objOther">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.</param>
		public override bool Equals(object objOther)
		{
			if (objOther is BorderColor borderColor && borderColor.mblnAll == mblnAll && borderColor.mobjTop == mobjTop && borderColor.mobjLeft == mobjLeft && borderColor.mobjBottom == mobjBottom)
			{
				return borderColor.mobjRight == mobjRight;
			}
			return false;
		}

		/// 
		/// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equivalent.
		/// </summary>
		/// true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are equal; otherwise, false.</returns>
		/// <param name="objColor2">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
		/// <param name="objColor1">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
		public static bool operator ==(BorderColor objColor1, BorderColor objColor2)
		{
			if (objColor1.Left == objColor2.Left && objColor1.Top == objColor2.Top && objColor1.Right == objColor2.Right)
			{
				return objColor1.Bottom == objColor2.Bottom;
			}
			return false;
		}

		/// 
		/// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are not equivalent.
		/// </summary>
		/// true if the two <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> objects are different; otherwise, false.</returns>
		/// <param name="objColor2">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
		/// <param name="objColor1">A <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> to test.</param>
		public static bool operator !=(BorderColor objColor1, BorderColor objColor2)
		{
			return !(objColor1 == objColor2);
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.BorderColor" /> to <see cref="T:System.Int32" />.
		/// </summary>
		/// <param name="objBorderColor">The color.</param>
		/// The result of the conversion.</returns>
		public static implicit operator Color(BorderColor objBorderColor)
		{
			return objBorderColor.All;
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:System.Int32" /> to <see cref="T:Gizmox.WebGUI.Forms.BorderColor" />.
		/// </summary>
		/// <param name="objBorderColor">The color.</param>
		/// The result of the conversion.</returns>
		public static implicit operator BorderColor(Color objBorderColor)
		{
			return new BorderColor(objBorderColor);
		}

		/// 
		/// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
		/// </summary>
		/// 
		/// A 32-bit signed integer.
		/// </returns>
		public override int GetHashCode()
		{
			return Top.GetHashCode() + Right.GetHashCode() + Bottom.GetHashCode() + Left.GetHashCode();
		}

		/// 
		/// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
		/// </summary>
		/// 
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see>.
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
			All = Color.Empty;
		}

		private void ResetBottom()
		{
			Bottom = Color.Empty;
		}

		private void ResetLeft()
		{
			Left = Color.Empty;
		}

		private void ResetRight()
		{
			Right = Color.Empty;
		}

		private void ResetTop()
		{
			Top = Color.Empty;
		}

		internal bool ShouldSerializeAll()
		{
			return mblnAll;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BorderColor"></see> class using the supplied color size for all edges.
		/// </summary>
		static BorderColor()
		{
			Empty = new BorderColor(Color.Empty);
		}
	}
}

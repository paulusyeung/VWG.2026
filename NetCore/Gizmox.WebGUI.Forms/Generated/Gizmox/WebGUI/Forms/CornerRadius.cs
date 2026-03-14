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
	/// Represents corner information associated with a user interface (UI) element.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(CornerRadiusConverter))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct CornerRadius
	{
		private bool mblnAll;

		private int mintTopLeft;

		private int mintBottomLeft;

		private int mintTopRight;

		private int mintBottomRight;

		/// 
		/// Provides a <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> object with no corner.
		/// </summary>
		public static readonly CornerRadius Empty;

		/// 
		/// Gets or sets the corner value for all the edges.
		/// </summary>
		/// The corner, in pixels, for all edges if the same; otherwise, -1.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int All
		{
			get
			{
				if (!mblnAll)
				{
					return -1;
				}
				return mintTopLeft;
			}
			set
			{
				if (!mblnAll || mintTopLeft != value)
				{
					mblnAll = true;
					mintTopLeft = (mintBottomLeft = (mintTopRight = (mintBottomRight = value)));
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance is all.
		/// </summary>
		/// true</c> if this instance is all; otherwise, false</c>.</value>
		internal bool IsAll => mblnAll;

		/// 
		/// Gets or sets the corner value for the bottom right corner.
		/// </summary>
		/// The corner, in pixels, for the bottom right corner.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int BottomRight
		{
			get
			{
				if (mblnAll)
				{
					return mintTopLeft;
				}
				return mintBottomRight;
			}
			set
			{
				if (mblnAll || mintBottomRight != value)
				{
					mblnAll = false;
					mintBottomRight = value;
				}
			}
		}

		/// 
		/// Gets or sets the corner value for the bottom left corner.
		/// </summary>
		/// The corner, in pixels, for the bottom left corner.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int BottomLeft
		{
			get
			{
				if (mblnAll)
				{
					return mintTopLeft;
				}
				return mintBottomLeft;
			}
			set
			{
				if (mblnAll || mintBottomLeft != value)
				{
					mblnAll = false;
					mintBottomLeft = value;
				}
			}
		}

		/// 
		/// Gets or sets the corner value for the top right corner.
		/// </summary>
		/// The corner, in pixels, for the top right corner.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int TopRight
		{
			get
			{
				if (mblnAll)
				{
					return mintTopLeft;
				}
				return mintTopRight;
			}
			set
			{
				if (mblnAll || mintTopRight != value)
				{
					mblnAll = false;
					mintTopRight = value;
				}
			}
		}

		/// 
		/// Gets or sets the corner value for the top left corner.
		/// </summary>
		/// The corner, in pixels, for the top left corner.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int TopLeft
		{
			get
			{
				return mintTopLeft;
			}
			set
			{
				if (mblnAll || mintTopLeft != value)
				{
					mblnAll = false;
					mintTopLeft = value;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using the supplied corner size for all edges.
		/// </summary>
		/// <param name="intAll">The number of pixels to be used for corner for all edges.</param>
		public CornerRadius(int intAll)
		{
			mblnAll = true;
			mintBottomRight = intAll;
			mintTopRight = intAll;
			mintBottomLeft = intAll;
			mintTopLeft = intAll;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using a separate corner size for each edge.
		/// </summary>
		/// <param name="topLeft">The corner size, in pixels, for the top left edge.</param>
		/// <param name="topRight">The corner size, in pixels, for the top right edge.</param>
		/// <param name="intBottomRight">The corner size, in pixels, for the bottom right edge.</param>
		/// <param name="intBottomLeft">The corner size, in pixels, for the bottom left edge.</param>
		public CornerRadius(int topLeft, int topRight, int intBottomRight, int intBottomLeft)
		{
			mintTopLeft = topLeft;
			mintBottomLeft = intBottomLeft;
			mintTopRight = topRight;
			mintBottomRight = intBottomRight;
			mblnAll = mintTopLeft == mintBottomLeft && mintTopLeft == mintTopRight && mintTopLeft == mintBottomRight;
		}

		/// 
		/// Determines whether the value of the specified object is equivalent to the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
		/// </summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equivalent; otherwise, false.</returns>
		/// <param name="other">The object to compare to the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.</param>
		public override bool Equals(object other)
		{
			if (other is CornerRadius cornerRadius && cornerRadius.mblnAll == mblnAll && cornerRadius.mintTopLeft == mintTopLeft && cornerRadius.mintBottomLeft == mintBottomLeft && cornerRadius.mintBottomRight == mintBottomRight)
			{
				return cornerRadius.mintTopRight == mintTopRight;
			}
			return false;
		}

		/// 
		/// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equivalent.
		/// </summary>
		/// true if the two <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are equal; otherwise, false.</returns>
		/// <param name="objRadius2">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
		/// <param name="objRadius1">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
		public static bool operator ==(CornerRadius objRadius1, CornerRadius objRadius2)
		{
			if (objRadius1.BottomLeft == objRadius2.BottomLeft && objRadius1.TopLeft == objRadius2.TopLeft && objRadius1.TopRight == objRadius2.TopRight)
			{
				return objRadius1.BottomRight == objRadius2.BottomRight;
			}
			return false;
		}

		/// 
		/// Tests whether two specified <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are not equivalent.
		/// </summary>
		/// true if the two <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> objects are different; otherwise, false.</returns>
		/// <param name="objRadius2">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
		/// <param name="objRadius1">A <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> to test.</param>
		public static bool operator !=(CornerRadius objRadius1, CornerRadius objRadius2)
		{
			return !(objRadius1 == objRadius2);
		}

		/// 
		/// Generates a hash code for the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
		/// </summary>
		/// 
		/// A 32-bit signed integer.
		/// </returns>
		public override int GetHashCode()
		{
			return BottomLeft ^ ClientUtils.RotateLeft(TopLeft, 8) ^ ClientUtils.RotateLeft(TopRight, 16) ^ ClientUtils.RotateLeft(BottomRight, 24);
		}

		/// 
		/// Returns a string that represents the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
		/// </summary>
		/// 
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.Corner"></see>.
		/// </returns>
		public override string ToString()
		{
			string[] array = new string[9]
			{
				"{TopLeft=",
				TopLeft.ToString(),
				",TopRight=",
				TopRight.ToString(),
				",BottomRight=",
				BottomRight.ToString(),
				",BottomLeft=",
				BottomLeft.ToString(),
				"}"
			};
			return string.Concat(array);
		}

		private void ResetAll()
		{
			All = 0;
		}

		private void ResetBottomRight()
		{
			BottomRight = 0;
		}

		private void ResetBottomLeft()
		{
			BottomLeft = 0;
		}

		private void ResetTopRight()
		{
			TopRight = 0;
		}

		private void ResetTopLeft()
		{
			TopLeft = 0;
		}

		internal void Scale(float fltX, float fltY)
		{
			mintTopLeft = (int)((float)mintTopLeft * fltY);
			mintBottomLeft = (int)((float)mintBottomLeft * fltX);
			mintTopRight = (int)((float)mintTopRight * fltX);
			mintBottomRight = (int)((float)mintBottomRight * fltY);
		}

		internal bool ShouldSerializeAll()
		{
			return mblnAll;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Corner"></see> class using the supplied corner size for all edges.
		/// </summary>
		static CornerRadius()
		{
			Empty = new CornerRadius(0);
		}
	}
}

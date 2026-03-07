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
	/// This class represents the abilities of the jquery Resizable.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(ResizableOptionsTypeConverter))]
	public class ResizableOptions : JQueryUIOptions
	{
		private bool mblnIsResizable = true;

		private Component[] mobjAlsoResize = new Component[0];

		private bool mblnAnimate = false;

		private int mintAnimateDuration = 500;

		private bool mblnAspectRatio = false;

		private bool mblnAutoHide = false;

		private ContainmentMode menmContainmentMode = ContainmentMode.None;

		private bool mblnGhost = false;

		/// 
		/// Gets or sets a value indicating whether this instance is Resizable.
		/// </summary>
		/// 
		/// true</c> if this instance is Resizable; otherwise, false</c>.
		/// </value>
		[SRDescription("One or more elements to resize synchronously with the resizable element.")]
		public bool IsResizable
		{
			get
			{
				return mblnIsResizable;
			}
			set
			{
				mblnIsResizable = value;
			}
		}

		/// 
		/// One or more elements to resize synchronously with the resizable element.
		/// </summary>
		/// 
		/// The also resize.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[TypeConverter(typeof(JQueryUIOptionsComponentTypeConverter))]
		[SRDescription("Gets or sets a value indicating whether this instance is Resizable.")]
		public Component[] AlsoResize
		{
			get
			{
				return mobjAlsoResize;
			}
			set
			{
				mobjAlsoResize = value;
			}
		}

		/// 
		/// Animates to the final size after resizing.
		/// Due to a known bug in jQeury (http://bugs.jqueryui.com/ticket/7453), this property is hidden at the moment.
		/// </summary>
		/// 
		///   true</c> if animate; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		[SRDescription("Animates to the final size after resizing.")]
		public bool Animate
		{
			get
			{
				return mblnAnimate;
			}
			set
			{
				mblnAnimate = value;
			}
		}

		/// 
		/// How long to animate when using the animate option.
		/// </summary>
		/// 
		/// The duration of the animate.
		/// </value>
		[Browsable(false)]
		[SRDescription("How long to animate when using the animate option.")]
		public int AnimateDuration
		{
			get
			{
				return mintAnimateDuration;
			}
			set
			{
				mintAnimateDuration = value;
			}
		}

		/// 
		/// Whether the element should be constrained to a specific aspect ratio.
		/// </summary>
		/// 
		///   true</c> if [aspect ratio]; otherwise, false</c>.
		/// </value>
		[SRDescription("Whether the element should be constrained to a specific aspect ratio.")]
		public bool AspectRatio
		{
			get
			{
				return mblnAspectRatio;
			}
			set
			{
				mblnAspectRatio = value;
			}
		}

		/// 
		/// Whether the handles should hide when the user is not hovering over the element.
		/// </summary>
		/// 
		///   true</c> if [auto hide]; otherwise, false</c>.
		/// </value>
		[SRDescription("Whether the handles should hide when the user is not hovering over the element.")]
		public bool AutoHide
		{
			get
			{
				return mblnAutoHide;
			}
			set
			{
				mblnAutoHide = value;
			}
		}

		/// 
		/// Constrains resizing to within the bounds of the specified element or region.
		/// </summary>
		/// 
		/// The containment mode.
		/// </value>
		[SRDescription("Constrains resizing to within the bounds of the specified element or region.")]
		public ContainmentMode ContainmentMode
		{
			get
			{
				return menmContainmentMode;
			}
			set
			{
				menmContainmentMode = value;
			}
		}

		/// 
		/// If set to true, a semi-transparent helper element is shown for resizing.
		/// </summary>
		/// 
		///   true</c> if ghost; otherwise, false</c>.
		/// </value>
		[SRDescription("If set to true, a semi-transparent helper element is shown for resizing.")]
		public bool Ghost
		{
			get
			{
				return mblnGhost;
			}
			set
			{
				mblnGhost = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ResizableOptions" /> class.
		/// </summary>
		internal ResizableOptions()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ResizableOptions" /> class.
		/// </summary>
		/// <param name="blnIsResizable">if set to true</c> [BLN is Resizable].</param>
		public ResizableOptions(bool blnIsResizable)
		{
			mblnIsResizable = blnIsResizable;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ResizableOptions" /> class.
		/// </summary>
		/// <param name="blnIsResizable">if set to true</c> [BLN is Resizable].</param>
		/// <param name="objAlsoResize">The obj also resize.</param>
		/// <param name="blnAnimate">if set to true</c> [BLN animate].</param>
		/// <param name="intAnimateDuration">Duration of the int animate.</param>
		/// <param name="blnAspectRatio">if set to true</c> [BLN aspect ratio].</param>
		/// <param name="blnAutoHide">if set to true</c> [BLN auto hide].</param>
		/// <param name="enmContainmentMode">The enm containment mode.</param>
		/// <param name="blnGhost">if set to true</c> [BLN ghost].</param>
		/// <param name="intXgrid">The int xgrid.</param>
		/// <param name="intYgrid">The int ygrid.</param>
		public ResizableOptions(bool blnIsResizable, Component[] objAlsoResize, bool blnAnimate, int intAnimateDuration, bool blnAspectRatio, bool blnAutoHide, ContainmentMode enmContainmentMode, bool blnGhost, int intXgrid, int intYgrid)
			: base(intXgrid, intYgrid)
		{
			mblnIsResizable = blnIsResizable;
			mobjAlsoResize = objAlsoResize;
			mblnAnimate = blnAnimate;
			mintAnimateDuration = intAnimateDuration;
			mblnAspectRatio = blnAspectRatio;
			mblnAutoHide = blnAutoHide;
			menmContainmentMode = enmContainmentMode;
			mblnGhost = blnGhost;
		}

		/// 
		/// Determines whether this instance is default.
		/// </summary>
		/// 
		///   true</c> if this instance is default; otherwise, false</c>.
		/// </returns>
		internal new bool IsDefault()
		{
			return base.IsDefault() && (mobjAlsoResize == null || mobjAlsoResize.Length == 0) && !mblnAnimate && mintAnimateDuration == 500 && !mblnAspectRatio && !mblnAutoHide && menmContainmentMode == ContainmentMode.None && !mblnGhost;
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", mblnIsResizable ? "1" : "0", mblnAnimate ? "1" : "0", mintAnimateDuration, mblnAspectRatio ? "1" : "0", mblnAutoHide ? "1" : "0", (int)menmContainmentMode, mblnGhost ? "1" : "0", base.ToString());
		}

		/// 
		/// To the render string.
		/// </summary>
		/// </returns>
		internal new string ToRenderString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.ToRenderString());
			if (mblnAnimate)
			{
				stringBuilder.AppendFormat("{0}|", "animate:true");
				if (mintAnimateDuration != 500)
				{
					stringBuilder.AppendFormat("{0}|", "animateDuration:" + mintAnimateDuration);
				}
			}
			if (mblnAspectRatio)
			{
				stringBuilder.AppendFormat("{0}|", "aspectRatio:true");
			}
			if (mblnAutoHide)
			{
				stringBuilder.AppendFormat("{0}|", "autoHide:true");
			}
			if (mblnGhost)
			{
				stringBuilder.AppendFormat("{0}|", "ghost:true");
			}
			if (menmContainmentMode != ContainmentMode.None)
			{
				if (menmContainmentMode == ContainmentMode.Form)
				{
					stringBuilder.AppendFormat("{0}|", "containment:\\'document\\'");
				}
				else if (menmContainmentMode == ContainmentMode.Parent)
				{
					stringBuilder.AppendFormat("{0}|", "containment:\\'parent\\'");
				}
			}
			if (mobjAlsoResize != null && mobjAlsoResize.Length != 0)
			{
				stringBuilder.Append("alsoResize:\\'");
				bool flag = true;
				Component[] array = mobjAlsoResize;
				foreach (Component component in array)
				{
					if (!flag)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.AppendFormat("#VWG_{0}", component.ID);
					flag = false;
				}
				stringBuilder.Append("\\'|");
			}
			return stringBuilder.ToString().TrimEnd('|');
		}

		/// 
		/// Converts from string.
		/// </summary>
		/// <param name="strValues">The STR values.</param>
		/// </returns>
		internal void ConvertFromString(string strValue)
		{
			string[] array = strValue.Split('|');
			if (array.Length == 9)
			{
				IsResizable = array[0] == "1";
				Animate = array[1] == "1";
				AnimateDuration = int.Parse(array[2]);
				AspectRatio = array[3] == "1";
				AutoHide = array[4] == "1";
				ContainmentMode = (ContainmentMode)int.Parse(array[5]);
				Ghost = array[6] == "1";
				base.ConvertFromString(array[7], array[8]);
			}
			else if (array.Length == 1)
			{
				IsResizable = array[0] == "1";
			}
			else
			{
				IsResizable = false;
			}
		}
	}
}

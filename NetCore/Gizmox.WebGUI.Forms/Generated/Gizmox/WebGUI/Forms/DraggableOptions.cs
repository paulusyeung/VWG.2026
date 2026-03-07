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
	/// This class represents the abilities of the jquery draggble.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(DraggableOptionsTypeConverter))]
	public class DraggableOptions : JQueryUIOptions
	{
		private bool mblnIsDraggable = true;

		private SnapTo menmSnapTo = SnapTo.None;

		private SnapMode menmSnapMode = SnapMode.Both;

		private int mintSnapTolerance = 20;

		private RevertMode menmRevertMode = RevertMode.None;

		private int mintRevertDuration = 500;

		private bool mblnAllowNegativeAxes = true;

		/// 
		/// Gets or sets a value indicating whether this instance is draggable.
		/// </summary>
		/// 
		/// true</c> if this instance is draggable; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[SRDescription("Gets or sets a value indicating whether this instance is draggable.")]
		public bool IsDraggable
		{
			get
			{
				return mblnIsDraggable;
			}
			set
			{
				mblnIsDraggable = value;
			}
		}

		/// 
		/// Whether the element should snap to other elements.
		/// </summary>
		/// 
		/// The snap to.
		/// </value>
		[DefaultValue(SnapTo.None)]
		[SRDescription("Whether the element should snap to other elements.")]
		public SnapTo SnapTo
		{
			get
			{
				return menmSnapTo;
			}
			set
			{
				menmSnapTo = value;
			}
		}

		/// 
		/// Determines which edges of snap elements the draggable will snap to. Ignored if the SnapTo option is off.. Possible values: "inner", "outer", "both", "Grid".
		/// </summary>
		/// 
		/// The snap mode.
		/// </value>
		[DefaultValue(SnapMode.Both)]
		[SRDescription("Determines which edges of snap elements the draggable will snap to. Ignored if the SnapTo option is off.. Possible values: \"inner\", \"outer\", \"both\",\"Grid\".")]
		public SnapMode SnapMode
		{
			get
			{
				return menmSnapMode;
			}
			set
			{
				menmSnapMode = value;
			}
		}

		/// 
		/// The distance in pixels from the snap element edges at which snapping should occur. Ignored if the SnapTo option is off.
		/// </summary>
		/// 
		/// The snap tolerance.
		/// </value>
		[DefaultValue(20)]
		[SRDescription("The distance in pixels from the snap element edges at which snapping should occur. Ignored if the SnapTo option is off.")]
		public int SnapTolerance
		{
			get
			{
				return mintSnapTolerance;
			}
			set
			{
				mintSnapTolerance = value;
			}
		}

		/// 
		/// Whether the element should revert to its start position when dragging stops.
		/// </summary>
		/// 
		/// The revert mode.
		/// </value>
		[DefaultValue(RevertMode.None)]
		[SRDescription("Whether the element should revert to its start position when dragging stops.")]
		public RevertMode RevertMode
		{
			get
			{
				return menmRevertMode;
			}
			set
			{
				menmRevertMode = value;
			}
		}

		/// 
		/// The duration of the revert animation, in milliseconds. Ignored if the RevertMode option is none.
		/// </summary>
		/// 
		/// The duration of the revert.
		/// </value>
		[DefaultValue(500)]
		[SRDescription("The duration of the revert animation, in milliseconds. Ignored if the RevertMode option is none.")]
		public int RevertDuration
		{
			get
			{
				return mintRevertDuration;
			}
			set
			{
				mintRevertDuration = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether negative axes values are permitted.
		/// </summary>
		/// 
		///   true</c> if [allow negative axes values]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool AllowNegativeAxes
		{
			get
			{
				return mblnAllowNegativeAxes;
			}
			set
			{
				mblnAllowNegativeAxes = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DraggableOptions" /> class.
		/// </summary>
		/// <param name="blnIsDraggable">if set to true</c> [BLN is draggable].</param>
		public DraggableOptions(bool blnIsDraggable)
		{
			mblnIsDraggable = blnIsDraggable;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DraggableOptions" /> class.
		/// </summary>
		/// <param name="blnIsDraggable">if set to true</c> [BLN is draggable].</param>
		/// <param name="enmSnapTo">The enm snap to.</param>
		/// <param name="enmSnapMode">The enm snap mode.</param>
		/// <param name="intSnapTolerance">The int snap tolerance.</param>
		/// <param name="enmRevertMode">The enm revert mode.</param>
		/// <param name="intRevertDuration">Duration of the int revert.</param>
		/// <param name="intXgrid">The int xgrid.</param>
		/// <param name="intYgrid">The int ygrid.</param>
		/// <param name="blnAllowNegativeAxes">if set to true</c> [BLN allow negative values].</param>
		public DraggableOptions(bool blnIsDraggable, SnapTo enmSnapTo, SnapMode enmSnapMode, int intSnapTolerance, RevertMode enmRevertMode, int intRevertDuration, int intXgrid, int intYgrid, bool blnAllowNegativeAxes)
		{
			mblnIsDraggable = blnIsDraggable;
			menmSnapTo = enmSnapTo;
			menmSnapMode = enmSnapMode;
			menmRevertMode = enmRevertMode;
			mintSnapTolerance = intSnapTolerance;
			mintRevertDuration = intRevertDuration;
			base.Xgrid = intXgrid;
			base.Ygrid = intYgrid;
			mblnAllowNegativeAxes = blnAllowNegativeAxes;
		}

		/// 
		/// Determines whether this instance is default.
		/// </summary>
		/// 
		///   true</c> if this instance is default; otherwise, false</c>.
		/// </returns>
		internal override bool IsDefault()
		{
			return base.IsDefault() && menmSnapTo == SnapTo.None && SnapMode == SnapMode.Both && SnapTolerance == 20 && RevertMode == RevertMode.None && RevertDuration == 500 && AllowNegativeAxes;
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", mblnIsDraggable ? "1" : "0", (int)menmSnapTo, (int)menmSnapMode, base.Xgrid, base.Ygrid, mintSnapTolerance, (int)menmRevertMode, mintRevertDuration, mblnAllowNegativeAxes);
		}

		/// 
		/// To the render string.
		/// </summary>
		/// </returns>
		internal new string ToRenderString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.ToRenderString());
			if (menmSnapTo != SnapTo.None)
			{
				if (menmSnapTo == SnapTo.Siblings)
				{
					stringBuilder.AppendFormat("{0}|", "snap:siblings");
				}
				else
				{
					stringBuilder.AppendFormat("{0}|", "snap:true");
				}
			}
			if (menmSnapMode != SnapMode.Both)
			{
				stringBuilder.AppendFormat("{0}|", "snapMode:\\'" + menmSnapMode.ToString().ToLower() + "\\'");
			}
			if (mintSnapTolerance != 20)
			{
				stringBuilder.AppendFormat("{0}|", "snapTolerance:" + mintSnapTolerance);
			}
			if (menmRevertMode != RevertMode.None)
			{
				if (menmRevertMode != RevertMode.Always)
				{
					stringBuilder.AppendFormat("{0}|", "revert:\\'" + menmRevertMode.ToString().ToLower() + "\\'");
				}
				else
				{
					stringBuilder.AppendFormat("{0}|", "revert:true");
				}
			}
			if (mintRevertDuration != 500)
			{
				stringBuilder.AppendFormat("{0}|", "revertDuration:" + mintRevertDuration);
			}
			if (!mblnAllowNegativeAxes)
			{
				stringBuilder.AppendFormat("{0}|", "allowNegativeAxes:false");
			}
			return stringBuilder.ToString().TrimEnd('|');
		}
	}
}

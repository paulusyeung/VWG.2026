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
	///
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class GroupingAreaStyleProperties
	{
		private DataGridView mobjDataGridView = null;

		private DataGridViewSkin mobjSkin = null;

		/// 
		/// Gets or sets the height of the grouping area.
		/// </summary>
		/// 
		/// The height.
		/// </value>
		[Category("Appearance")]
		[Description("Background height of data grid view grouping area.")]
		public int Height
		{
			get
			{
				return mobjDataGridView.GroupingAreaHeight;
			}
			set
			{
				mobjDataGridView.GroupingAreaHeight = value;
			}
		}

		/// 
		/// Gets or sets the backcolor of the grouping area.
		/// </summary>
		/// 
		/// The backcolor of the grouping area.
		/// </value>        
		[Category("Appearance")]
		[Description("Background color of data grid view grouping area.")]
		public Color BackColor
		{
			get
			{
				return mobjDataGridView.GroupingAreaBackColor;
			}
			set
			{
				mobjDataGridView.GroupingAreaBackColor = value;
			}
		}

		/// 
		/// Gets or sets the background image.
		/// </summary>
		/// 
		/// The background image.
		/// </value>
		[Category("Appearance")]
		[Description("Background image of data grid view grouping area.")]
		[DefaultValue(null)]
		public ResourceHandle BackgroundImage
		{
			get
			{
				return mobjDataGridView.GroupingAreaBackgroundImage;
			}
			set
			{
				mobjDataGridView.GroupingAreaBackgroundImage = value;
			}
		}

		/// 
		/// Gets or sets the background image position.
		/// </summary>
		/// 
		/// The background image position.
		/// </value>
		[DefaultValue(BackgroundImagePosition.MiddleCenter)]
		[Category("Appearance")]
		[Description("Position of data grid view grouping area background image.")]
		public BackgroundImagePosition BackgroundImagePosition
		{
			get
			{
				return mobjDataGridView.GroupingAreaBackgroundImagePosition;
			}
			set
			{
				mobjDataGridView.GroupingAreaBackgroundImagePosition = value;
			}
		}

		/// 
		/// Gets or sets the background image repeat.
		/// </summary>
		/// 
		/// The background image repeat.
		/// </value>
		[DefaultValue(BackgroundImageRepeat.Repeat)]
		[Category("Appearance")]
		[Description("Repeat style of data grid view grouping area background image.")]
		public BackgroundImageRepeat BackgroundImageRepeat
		{
			get
			{
				return mobjDataGridView.GroupingAreaBackgroundImageRepeat;
			}
			set
			{
				mobjDataGridView.GroupingAreaBackgroundImageRepeat = value;
			}
		}

		/// 
		/// Gets or sets the color of the border.
		/// </summary>
		/// 
		/// The color of the border.
		/// </value>        
		[Category("Appearance")]
		[Description("Border color of data grid view grouping area.")]
		public BorderColor BorderColor
		{
			get
			{
				return mobjDataGridView.GroupingAreaBorderColor;
			}
			set
			{
				mobjDataGridView.GroupingAreaBorderColor = value;
			}
		}

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// 
		/// The border style.
		/// </value>        
		[Category("Appearance")]
		[Description("Border style of data grid view grouping area.")]
		public BorderStyle BorderStyle
		{
			get
			{
				return mobjDataGridView.GroupingAreaBorderStyle;
			}
			set
			{
				mobjDataGridView.GroupingAreaBorderStyle = value;
			}
		}

		/// 
		/// Gets or sets the width of the border.
		/// </summary>
		/// 
		/// The width of the border.
		/// </value>       
		[Category("Appearance")]
		[Description("Border width of data grid view grouping area.")]
		public BorderWidth BorderWidth
		{
			get
			{
				return mobjDataGridView.GroupingAreaBorderWidth;
			}
			set
			{
				mobjDataGridView.GroupingAreaBorderWidth = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GroupingAreaStyleProperties" /> class.
		/// </summary>
		/// <param name="objDataGridView">The obj data grid view.</param>
		public GroupingAreaStyleProperties(DataGridView objDataGridView)
		{
			mobjDataGridView = objDataGridView;
			mobjSkin = SkinFactory.GetSkin(mobjDataGridView) as DataGridViewSkin;
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Empty;
		}

		/// 
		/// Determines whether to serialize the backcolor of grouping area.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBackColor()
		{
			if (SkinFactory.GetSkin(mobjDataGridView) is DataGridViewSkin dataGridViewSkin)
			{
				return BackColor != dataGridViewSkin.GroupingDropAreaStyle.BackColor;
			}
			return false;
		}

		/// 
		/// Determines whether to serialize the border color of grouping area.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBorderColor()
		{
			if (mobjSkin != null)
			{
				return BorderColor != mobjSkin.GroupingDropAreaStyle.BorderColor;
			}
			return false;
		}

		/// 
		///  Determines whether to serialize the border style of grouping area.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBorderStyle()
		{
			if (mobjSkin != null)
			{
				return BorderStyle != mobjSkin.GroupingDropAreaStyle.BorderStyle;
			}
			return false;
		}

		/// 
		///  Determines whether to serialize the border width of grouping area.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBorderWidth()
		{
			if (mobjSkin != null)
			{
				return BorderWidth != mobjSkin.GroupingDropAreaStyle.BorderWidth;
			}
			return false;
		}

		/// 
		/// Determines whether to serialize the height of grouping area.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeHeight()
		{
			if (mobjSkin != null)
			{
				return Height != mobjSkin.DropAreaHeight;
			}
			return false;
		}
	}
}

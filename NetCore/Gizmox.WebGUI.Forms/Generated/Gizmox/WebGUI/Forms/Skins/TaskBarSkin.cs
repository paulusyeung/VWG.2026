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
	/// Provides loading customization capabilities
	/// </summary>
	[ToolboxBitmap(typeof(ProgressBar))]
	public class TaskBarSkin : CommonSkin
	{
		/// 
		/// Gets the task bar item frame.
		/// </summary>
		/// The task bar item frame.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public TextResourceReference ItemTemplate => new TextResourceReference(typeof(TaskBarSkin), "TaskBarItemTemplate.htm");

		/// 
		/// Gets the task bar item style.
		/// </summary>
		/// The task bar item style.</value>
		[Category("States")]
		[SRDescription("The taskbar item style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ItemStyle => new StyleValue(this, "ItemStyle");

		/// 
		/// Gets the task bar item content style.
		/// </summary>
		/// The task bar item content style.</value>
		[Category("States")]
		[SRDescription("The taskbar item content style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ItemContentStyle => new StyleValue(this, "ItemContentStyle");

		/// 
		/// Gets the task bar item label style.
		/// </summary>
		/// The task bar item label style.</value>
		[Category("States")]
		[SRDescription("The taskbar item label style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ItemLabelStyle => new StyleValue(this, "ItemLabelStyle");

		/// 
		/// Gets the task bar item image style.
		/// </summary>
		/// The task bar item image style.</value>
		[Category("States")]
		[SRDescription("The taskbar item image style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ItemImageStyle => new StyleValue(this, "ItemImageStyle");

		/// 
		/// Gets the width of the item content.
		/// </summary>
		/// The width of the item content.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ItemContentWidth => ItemWidth - (ItemContentStyle.Margin.Right + ItemContentStyle.Margin.Left);

		/// 
		/// Gets or sets the width of the task bar item image.
		/// </summary>
		/// The width of the task bar item image.</value>
		[Category("Sizes")]
		[Description("Task bar item height.")]
		public int ItemImageWidth
		{
			get
			{
				return GetValue("ItemImageWidth", 16);
			}
			set
			{
				SetValue("ItemImageWidth", value);
			}
		}

		/// 
		/// Gets or sets the height of the task bar item image.
		/// </summary>
		/// The height of the task bar item image.</value>
		[Category("Sizes")]
		[Description("Task bar item height.")]
		public int ItemImageHeight
		{
			get
			{
				return GetValue("ItemImageHeight", 16);
			}
			set
			{
				SetValue("ItemImageHeight", value);
			}
		}

		/// 
		/// Gets or sets the height of the task bar item.
		/// </summary>
		/// The height of the task bar item.</value>
		[Category("Sizes")]
		[Description("Task bar item height.")]
		public int ItemHeight
		{
			get
			{
				return GetValue("ItemHeight", 28);
			}
			set
			{
				SetValue("ItemHeight", value);
			}
		}

		/// 
		/// Gets or sets the width of the task bar item.
		/// </summary>
		/// The width of the task bar item.</value>
		[Category("Sizes")]
		[Description("Task bar item width.")]
		public int ItemWidth
		{
			get
			{
				return GetValue("ItemWidth", 158);
			}
			set
			{
				SetValue("ItemWidth", value);
			}
		}

		/// 
		/// Gets the frame style.
		/// </summary>
		/// The frame style.</value>
		[Category("States")]
		[Description("The taskbar frame style.")]
		public FrameStyleValue FrameStyle => new FrameStyleValue(LeftBottomFrameStyle, LeftFrameStyle, LeftTopFrameStyle, TopFrameStyle, RightTopFrameStyle, RightFrameStyle, RightBottomFrameStyle, BottomFrameStyle, CenterFrameStyle);

		/// 
		/// Gets the task bar item frame style.
		/// </summary>
		/// The task bar item frame style.</value>
		[Category("States")]
		[Description("The taskbar item frame style.")]
		public TripleCellFrameStyleValue ItemFrameNormalStyle => new TripleCellFrameStyleValue(ItemLeftFrameNormalStyle, ItemRightFrameNormalStyle, ItemCenterFrameNormalStyle);

		/// 
		/// Gets the task bar item frame style.
		/// </summary>
		/// The task bar item frame style.</value>
		[Category("States")]
		[Description("The taskbar item frame style.")]
		public TripleCellFrameStyleValue ItemFrameOverStyle => new TripleCellFrameStyleValue(ItemLeftFrameOverStyle, ItemRightFrameOverStyle, ItemCenterFrameOverStyle);

		/// 
		/// Gets the task bar item frame style.
		/// </summary>
		/// The task bar item frame style.</value>
		[Category("States")]
		[Description("The taskbar item frame style.")]
		public TripleCellFrameStyleValue ItemFrameDownStyle => new TripleCellFrameStyleValue(ItemLeftFrameDownStyle, ItemRightFrameDownStyle, ItemCenterFrameDownStyle);

		/// 
		/// Gets the default width of the left frame.
		/// </summary>
		/// The default width of the left frame.</value>
		protected virtual int DefaultLeftFrameWidth => 0;

		/// 
		/// Gets the default height of the bottom frame.
		/// </summary>
		/// The default height of the bottom frame.</value>
		protected virtual int DefaultBottomFrameHeight => 0;

		/// 
		/// Gets the default width of the right frame.
		/// </summary>
		/// The default width of the right frame.</value>
		protected virtual int DefaultRightFrameWidth => 0;

		/// 
		/// Gets the default height of the top frame.
		/// </summary>
		/// The default height of the top frame.</value>
		protected virtual int DefaultTopFrameHeight => 0;

		/// 
		/// Gets or sets the width of the right frame.
		/// </summary>
		/// The width of the right frame.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int RightFrameWidth => GetImageWidth(FrameStyle.RightStyle.BackgroundImage, DefaultRightFrameWidth);

		/// 
		/// Gets or sets the height of the top frame.
		/// </summary>
		/// The height of the top frame.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int TopFrameHeight => GetImageHeight(FrameStyle.TopStyle.BackgroundImage, DefaultTopFrameHeight);

		/// 
		/// Gets or sets the height of the bottom frame.
		/// </summary>
		/// The height of the bottom frame.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int BottomFrameHeight => GetImageHeight(FrameStyle.BottomStyle.BackgroundImage, DefaultBottomFrameHeight);

		/// 
		/// Gets or sets the width of the left frame.
		/// </summary>
		/// The width of the left frame.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int LeftFrameWidth => GetImageWidth(FrameStyle.LeftStyle.BackgroundImage, DefaultLeftFrameWidth);

		/// 
		/// Gets the center frame style.
		/// </summary>
		/// The center frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue CenterFrameStyle => new StyleValue(this, "CenterFrameStyle");

		/// 
		/// Gets the left frame style.
		/// </summary>
		/// The left frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftFrameStyle => new FramePartStyleValue(this, "LeftFrameStyle");

		/// 
		/// Gets the top frame style.
		/// </summary>
		/// The top frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue TopFrameStyle => new FramePartStyleValue(this, "TopFrameStyle");

		/// 
		/// Gets the bottom frame style.
		/// </summary>
		/// The bottom frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue BottomFrameStyle => new FramePartStyleValue(this, "BottomFrameStyle");

		/// 
		/// Gets the right frame style.
		/// </summary>
		/// The right frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightFrameStyle => new FramePartStyleValue(this, "RightFrameStyle");

		/// 
		/// Gets the right top frame style.
		/// </summary>
		/// The right top frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightTopFrameStyle => new FramePartStyleValue(this, "RightTopFrameStyle");

		/// 
		/// Gets the left top frame style.
		/// </summary>
		/// The left top frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftTopFrameStyle => new FramePartStyleValue(this, "LeftTopFrameStyle");

		/// 
		/// Gets the left bottom frame style.
		/// </summary>
		/// The left bottom frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue LeftBottomFrameStyle => new FramePartStyleValue(this, "LeftBottomFrameStyle");

		/// 
		/// Gets the right bottom frame style.
		/// </summary>
		/// The right bottom frame style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FramePartStyleValue RightBottomFrameStyle => new FramePartStyleValue(this, "RightBottomFrameStyle");

		/// 
		/// Gets the default width of the item left frame.
		/// </summary>
		/// The default width of the item left frame.</value>
		protected virtual int DefaultItemLeftFrameWidth => 0;

		/// 
		/// Gets the default width of the item right frame.
		/// </summary>
		/// The default width of the item right frame.</value>
		protected virtual int DefaultItemRightFrameWidth => 0;

		/// 
		/// Gets or sets the width of the item right frame.
		/// </summary>
		/// The width of the item right frame.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ItemRightFrameWidth => GetImageWidth(ItemFrameNormalStyle.RightStyle.BackgroundImage, DefaultItemRightFrameWidth);

		/// 
		/// Gets or sets the width of the item left frame.
		/// </summary>
		/// The width of the item left frame.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int ItemLeftFrameWidth => GetImageWidth(ItemFrameNormalStyle.LeftStyle.BackgroundImage, DefaultItemLeftFrameWidth);

		/// 
		/// Gets the item center frame normal style.
		/// </summary>
		/// The item center frame normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemCenterFrameNormalStyle => new StyleValue(this, "ItemCenterFrameNormalStyle");

		/// 
		/// Gets the item center frame over style.
		/// </summary>
		/// The item center frame over style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemCenterFrameOverStyle => new StyleValue(this, "ItemCenterFrameOverStyle");

		/// 
		/// Gets the item center frame down style.
		/// </summary>
		/// The item center frame down style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemCenterFrameDownStyle => new StyleValue(this, "ItemCenterFrameDownStyle");

		/// 
		/// Gets the item left frame normal style.
		/// </summary>
		/// The item left frame normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemLeftFrameNormalStyle => new StyleValue(this, "ItemLeftFrameNormalStyle");

		/// 
		/// Gets the item left frame over style.
		/// </summary>
		/// The item left frame over style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemLeftFrameOverStyle => new StyleValue(this, "ItemLeftFrameOverStyle");

		/// 
		/// Gets the item left frame down style.
		/// </summary>
		/// The item left frame down style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemLeftFrameDownStyle => new StyleValue(this, "ItemLeftFrameDownStyle");

		/// 
		/// Gets the item right frame normal style.
		/// </summary>
		/// The item right frame normal style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemRightFrameNormalStyle => new StyleValue(this, "ItemRightFrameNormalStyle");

		/// 
		/// Gets the item right frame over style.
		/// </summary>
		/// The item right frame over style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemRightFrameOverStyle => new StyleValue(this, "ItemRightFrameOverStyle");

		/// 
		/// Gets the item right frame down style.
		/// </summary>
		/// The item right frame down style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual StyleValue ItemRightFrameDownStyle => new StyleValue(this, "ItemRightFrameDownStyle");

		/// 
		/// Gets the bottom frame display style.
		/// </summary>
		/// The bottom frame display style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string BottomFrameDisplayStyle => (BottomFrameHeight == 0) ? "display:none;" : "";

		private void InitializeComponent()
		{
		}
	}
}

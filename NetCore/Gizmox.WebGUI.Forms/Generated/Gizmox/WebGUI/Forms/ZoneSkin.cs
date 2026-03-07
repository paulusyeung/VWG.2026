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
	[Serializable]
	[SkinContainer(typeof(DockingManagerSkin))]
	public class ZoneSkin : ContainerControlSkin
	{
		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue TopDockIndicator => new StyleValue(this, "TopDockIndicator");

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue TopDockIndicatorHover => new StyleValue(this, "TopDockIndicatorHover");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TopDockIndicatorWidth => GetImageSize(TopDockIndicator.BackgroundImage, Size.Empty).Width;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TopDockIndicatorHeight => GetImageSize(TopDockIndicator.BackgroundImage, Size.Empty).Height;

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue RightDockIndicator => new StyleValue(this, "RightDockIndicator");

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue RightDockIndicatorHover => new StyleValue(this, "RightDockIndicatorHover");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightDockIndicatorWidth => GetImageSize(RightDockIndicator.BackgroundImage, Size.Empty).Width;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightDockIndicatorHeight => GetImageSize(RightDockIndicator.BackgroundImage, Size.Empty).Height;

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue BottomDockIndicator => new StyleValue(this, "BottomDockIndicator");

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue BottomDockIndicatorHover => new StyleValue(this, "BottomDockIndicatorHover");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int BottomDockIndicatorWidth => GetImageSize(BottomDockIndicator.BackgroundImage, Size.Empty).Width;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int BottomDockIndicatorHeight => GetImageSize(BottomDockIndicator.BackgroundImage, Size.Empty).Height;

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue LeftDockIndicator => new StyleValue(this, "LeftDockIndicator");

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue LeftDockIndicatorHover => new StyleValue(this, "LeftDockIndicatorHover");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftDockIndicatorWidth => GetImageSize(LeftDockIndicator.BackgroundImage, Size.Empty).Width;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftDockIndicatorHeight => GetImageSize(LeftDockIndicator.BackgroundImage, Size.Empty).Height;

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue CenterDockIndicator => new StyleValue(this, "CenterDockIndicator");

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue CenterDockIndicatorHover => new StyleValue(this, "CenterDockIndicatorHover");

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CenterDockIndicatorWidth => GetImageSize(CenterDockIndicator.BackgroundImage, Size.Empty).Width;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CenterDockIndicatorHeight => GetImageSize(CenterDockIndicator.BackgroundImage, Size.Empty).Height;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LeftColumnWidth => LeftDockIndicatorWidth;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MiddleColumnWidth => Math.Max(TopDockIndicatorWidth, Math.Max(CenterDockIndicatorWidth, BottomDockIndicatorWidth));

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RightColumnWidth => RightDockIndicatorWidth;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TopRowHeight => TopDockIndicatorHeight;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MiddleRowHeight => Math.Max(LeftDockIndicatorHeight, Math.Max(CenterDockIndicatorHeight, RightDockIndicatorHeight));

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int BottomRowHeight => BottomDockIndicatorHeight;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TotalWidth => LeftColumnWidth + CenterDockIndicatorWidth + RightColumnWidth;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TotalHeight => TopDockIndicatorHeight + CenterDockIndicatorHeight + BottomRowHeight;

		private void InitializeComponent()
		{
		}
	}
}

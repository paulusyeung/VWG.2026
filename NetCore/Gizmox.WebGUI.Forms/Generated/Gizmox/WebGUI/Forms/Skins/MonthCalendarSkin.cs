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
	/// MonthCalendar Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(MonthCalendar), "MonthCalendar.bmp")]
	public class MonthCalendarSkin : ControlSkin
	{
		/// 
		/// Gets the selected day style.
		/// </summary>
		/// 
		/// The selected day style.
		/// </value>
		[SRCategory("CatAppearance")]
		[Description("The style of the current day when selected.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue TodaySelectedStyle => new StyleValue(this, "TodaySelectedStyle", SelectedDayStyle);

		/// 
		/// Gets the hover selected day style.
		/// </summary>
		/// 
		/// The hover selected day style.
		/// </value>
		[SRCategory("CatAppearance")]
		[Description("The hover style of the current day when selected.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverTodaySelectedStyle => new StyleValue(this, "HoverTodaySelectedStyle", HoverSelectedDayStyle);

		/// 
		/// Gets the today style.
		/// </summary>
		/// 
		/// The today style.
		/// </value>
		[SRCategory("CatAppearance")]
		[Description("The style of the current day.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue TodayStyle => new StyleValue(this, "TodayStyle", NormalDayStyle);

		/// 
		/// Gets the hover today style.
		/// </summary>
		/// 
		/// The hover today style.
		/// </value>
		[SRCategory("CatAppearance")]
		[Description("The hover style of the current day.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverTodayStyle => new StyleValue(this, "HoverTodayStyle", HoverDayStyle);

		/// 
		/// Gets the external day style.
		/// </summary>
		/// 
		/// The external day style.
		/// </value>
		[SRCategory("CatAppearance")]
		[Description("The style of days that are outside the range of the current month.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ExternalDayStyle => new StyleValue(this, "ExternalDayStyle", NormalDayStyle);

		/// 
		/// Gets the hover external day style.
		/// </summary>
		/// 
		/// The hover external day style.
		/// </value>
		[SRCategory("CatAppearance")]
		[Description("The hover style of days that are outside the range of the current month.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverExternalDayStyle => new StyleValue(this, "HoverExternalDayStyle", HoverDayStyle);

		/// 
		/// Gets the month calendar caption style.
		/// </summary>
		/// The month calendar caption style.</value>
		[SRCategory("CatAppearance")]
		[Description("The month calendar caption style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CaptionStyle => new StyleValue(this, "CaptionStyle");

		/// 
		/// Gets the month calendar header style.
		/// </summary>
		/// The month calendar header style.</value>
		[SRCategory("CatAppearance")]
		[Description("The month calendar header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderStyle => new StyleValue(this, "HeaderStyle");

		/// 
		/// Gets the month normal day style.
		/// </summary>
		/// The month normal day style.</value>
		[Category("States")]
		[Description("The month calendar normal day style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NormalDayStyle => new StyleValue(this, "NormalDayStyle");

		/// 
		/// Gets the month selected day style.
		/// </summary>
		/// The month selected day style.</value>
		[Category("States")]
		[Description("The month calendar selected day style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SelectedDayStyle => new StyleValue(this, "SelectedDayStyle", NormalDayStyle);

		/// 
		/// Gets the month Hover Selected day style.
		/// </summary>
		/// The month Hover Selected day style.</value>
		[Category("States")]
		[Description("The month calendar Hover Selected day style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverSelectedDayStyle => new StyleValue(this, "HoverSelectedDayStyle", SelectedDayStyle);

		/// 
		/// Gets the hover day style.
		/// </summary>
		[Category("States")]
		[Description("The month calendar hover day style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverDayStyle => new StyleValue(this, "HoverDayStyle", NormalDayStyle);

		/// 
		/// Gets the navigate next style.
		/// </summary>
		/// The navigate next style.</value>
		[Category("States")]
		[SRDescription("The navigate next style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NavigateNextStyle => new StyleValue(this, "NavigateNextStyle");

		/// 
		/// Gets the navigate previous style.
		/// </summary>
		/// The navigate previous style.</value>
		[Category("States")]
		[SRDescription("The navigate previous style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NavigatePreviousStyle => new StyleValue(this, "NavigatePreviousStyle");

		/// 
		/// Gets the bidirectional navigate previous style.
		/// </summary>
		/// The bidirectional navigate previous style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BidirectionalSkinValue<object> BidirectionalNavigatePreviousStyle => new BidirectionalSkinValue<object>(this, NavigatePreviousStyle, NavigateNextStyle);

		/// 
		/// Gets the width of the navigate next.
		/// </summary>
		/// The width of the navigate next.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int NavigateNextWidth => GetImageWidth(NavigateNextStyle.BackgroundImage, DefaultNavigateNextWidth);

		/// 
		/// Gets the width of the navigate previous.
		/// </summary>
		/// The width of the navigate previous.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int NavigatePreviousWidth => GetImageWidth(NavigatePreviousStyle.BackgroundImage, DefaultNavigatePreviousWidth);

		/// 
		/// Gets the width of the default navigate previous.
		/// </summary>
		/// The width of the default navigate previous.</value>
		protected virtual int DefaultNavigatePreviousWidth => 5;

		/// 
		/// Gets the width of the default navigate next.
		/// </summary>
		/// The width of the default navigate next.</value>
		protected virtual int DefaultNavigateNextWidth => 5;

		/// 
		/// Gets the bidirectional navigate next style.
		/// </summary>
		/// The bidirectional navigate next style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BidirectionalSkinValue<object> BidirectionalNavigateNextStyle => new BidirectionalSkinValue<object>(this, NavigateNextStyle, NavigatePreviousStyle);

		/// 
		/// Gets the normal month cell style.
		/// </summary>
		/// The normal month cell style.</value>
		[Category("States")]
		[Description("The month cell normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NormalMonthCellStyle => new StyleValue(this, "NormalMonthCellStyle");

		/// 
		/// Gets the hover month cell style.
		/// </summary>
		[Category("States")]
		[Description("The month cell Hover style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverMonthCellStyle => new StyleValue(this, "HoverMonthCellStyle", NormalMonthCellStyle);

		/// 
		/// Gets the selected month cell style.
		/// </summary>
		/// The selected month cell style.</value>
		[Category("States")]
		[Description("The month cell selected  style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SelectedMonthCellStyle => new StyleValue(this, "SelectedMonthCellStyle", NormalMonthCellStyle);

		/// 
		/// Gets the Hover Selected month cell style.
		/// </summary>
		/// The Hover Selected month cell style.</value>
		[Category("States")]
		[Description("The month cell Hover Selected  style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverSelectedMonthCellStyle => new StyleValue(this, "HoverSelectedMonthCellStyle", SelectedMonthCellStyle);

		/// 
		/// Gets or sets the month view padding.
		/// </summary>
		/// The month view padding.</value>
		public PaddingValue MonthViewPadding
		{
			get
			{
				return GetValue("MonthViewPadding", new PaddingValue(new Padding(4, 10, 4, 10)));
			}
			set
			{
				SetValue("MonthViewPadding", value);
			}
		}

		/// 
		/// Gets the normal year cell style.
		/// </summary>
		/// The normal year cell style.</value>
		[Category("States")]
		[Description("The Year cell normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NormalYearCellStyle => new StyleValue(this, "NormalYearCellStyle", NormalMonthCellStyle);

		/// 
		/// Gets the hover year cell style.
		/// </summary>
		[Category("States")]
		[Description("The Year cell Hover style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverYearCellStyle => new StyleValue(this, "HoverYearCellStyle", NormalYearCellStyle);

		/// 
		/// Gets the selected year cell style.
		/// </summary>
		/// The selected year cell style.</value>
		[Category("States")]
		[Description("The year cell selected  style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SelectedYearCellStyle => new StyleValue(this, "SelectedYearCellStyle", NormalYearCellStyle);

		/// 
		/// Gets the Hover Selected year cell style.
		/// </summary>
		/// The Hover Selected year cell style.</value>
		[Category("States")]
		[Description("The year cell Hover Selected  style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverSelectedYearCellStyle => new StyleValue(this, "HoverSelectedYearCellStyle", SelectedYearCellStyle);

		/// 
		/// Gets or sets the year view padding.
		/// </summary>
		/// The year view padding.</value>
		public PaddingValue YearViewPadding
		{
			get
			{
				return GetValue("YearViewPadding", new PaddingValue(new Padding(4, 14, 4, 10)));
			}
			set
			{
				SetValue("YearViewPadding", value);
			}
		}

		/// 
		/// Gets the normal YearRange cell style.
		/// </summary>
		/// The normal YearRange cell style.</value>
		[Category("States")]
		[Description("The YearRange cell normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NormalYearRangeCellStyle => new StyleValue(this, "NormalYearRangeCellStyle");

		/// 
		/// Gets the hover year range cell style.
		/// </summary>
		[Category("States")]
		[Description("The YearRange cell Hover style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverYearRangeCellStyle => new StyleValue(this, "HoverYearRangeCellStyle", NormalYearRangeCellStyle);

		/// 
		/// Gets the selected YearRange cell style.
		/// </summary>
		/// The selected YearRange cell style.</value>
		[Category("States")]
		[Description("The YearRange cell selected  style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SelectedYearRangeCellStyle => new StyleValue(this, "SelectedYearRangeCellStyle", NormalYearRangeCellStyle);

		/// 
		/// Gets the Hover Selected YearRange cell style.
		/// </summary>
		/// The Hover Selected YearRange cell style.</value>
		[Category("States")]
		[Description("The YearRange cell Hover Selected style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HoverSelectedYearRangeCellStyle => new StyleValue(this, "HoverSelectedYearRangeCellStyle", SelectedYearRangeCellStyle);

		/// 
		/// Gets or sets the year range view padding.
		/// </summary>
		/// The year range view padding.</value>
		public PaddingValue YearRangeViewPadding
		{
			get
			{
				return GetValue("YearRangeViewPadding", new PaddingValue(new Padding(0, 8, 0, 8)));
			}
			set
			{
				SetValue("YearRangeViewPadding", value);
			}
		}

		/// 
		/// Gets the navigate next disabled style.
		/// </summary>
		/// 
		/// The navigate next disabled style.
		/// </value>
		[Category("States")]
		[SRDescription("The navigate next disabled style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NavigateNextDisabledStyle => new StyleValue(this, "NavigateNextDisabledStyle", NavigateNextStyle);

		/// 
		/// Gets the navigate previous disabled style.
		/// </summary>
		/// 
		/// The navigate previous disabled style.
		/// </value>
		[Category("States")]
		[SRDescription("The navigate previous disabled style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue NavigatePreviousDisabledStyle => new StyleValue(this, "NavigatePreviousDisabledStyle", NavigatePreviousStyle);

		/// 
		/// Gets the bidirectional navigate previous disabled style.
		/// </summary>
		/// 
		/// The bidirectional navigate previous disabled style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BidirectionalSkinValue<object> BidirectionalNavigatePreviousDisabledStyle => new BidirectionalSkinValue<object>(this, NavigatePreviousDisabledStyle, NavigateNextDisabledStyle);

		/// 
		/// Gets the bidirectional navigate next disabled style.
		/// </summary>
		/// 
		/// The bidirectional navigate next disabled style.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BidirectionalSkinValue<object> BidirectionalNavigateNextDisabledStyle => new BidirectionalSkinValue<object>(this, NavigateNextDisabledStyle, NavigatePreviousDisabledStyle);

		/// 
		/// Gets the width of the navigate next.
		/// </summary>
		/// The width of the navigate next.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int NavigateNextDisabledWidth => GetImageWidth(NavigateNextDisabledStyle.BackgroundImage, DefaultNavigateNextWidth);

		/// 
		/// Gets the width of the navigate previous.
		/// </summary>
		/// The width of the navigate previous.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int NavigatePreviousDisabledWidth => GetImageWidth(NavigatePreviousDisabledStyle.BackgroundImage, DefaultNavigatePreviousWidth);

		/// 
		/// Gets or sets the next image.
		/// </summary>
		/// 
		/// The next image.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Category("Images")]
		[Description("The image for the 'Next' button.")]
		public virtual ImageResourceReference NextImage
		{
			get
			{
				return GetValue("NextImage", new ImageResourceReference(typeof(MonthCalendarSkin), "ArrowWhiteLTR.png"));
			}
			set
			{
				SetValue("NextImage", value);
			}
		}

		/// 
		/// Gets or sets the previous image.
		/// </summary>
		/// 
		/// The previous image.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Category("Images")]
		[Description("The image for the 'Previous' button.")]
		public virtual ImageResourceReference PreviousImage
		{
			get
			{
				return GetValue("PreviousImage", new ImageResourceReference(typeof(MonthCalendarSkin), "ArrowWhiteRTL.png"));
			}
			set
			{
				SetValue("PreviousImage", value);
			}
		}

		/// 
		/// Gets or sets the size of the next image.
		/// </summary>
		/// 
		/// The size of the next image.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Category("Sizes")]
		[Description("The image size for the 'Next' button.")]
		public Size NextImageSize
		{
			get
			{
				return GetValue("NextImageSize", GetImageSize(NextImage, Size.Empty));
			}
			set
			{
				SetValue("NextImageSize", value);
			}
		}

		/// 
		/// Gets or sets the size of the previous image.
		/// </summary>
		/// 
		/// The size of the previous image.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Category("Sizes")]
		[Description("The image size for the 'Previous' button.")]
		public Size PreviousImageSize
		{
			get
			{
				return GetValue("PreviousImageSize", GetImageSize(PreviousImage, Size.Empty));
			}
			set
			{
				SetValue("PreviousImageSize", value);
			}
		}

		/// 
		/// Gets the height of the next image.
		/// </summary>
		/// 
		/// The height of the next image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NextImageHeight => NextImageSize.Height;

		/// 
		/// Gets the width of the next image.
		/// </summary>
		/// 
		/// The width of the next image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NextImageWidth => NextImageSize.Width;

		/// 
		/// Gets the height of the previous image.
		/// </summary>
		/// 
		/// The height of the previous image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PreviousImageHeight => PreviousImageSize.Height;

		/// 
		/// Gets the width of the previous image.
		/// </summary>
		/// 
		/// The width of the previous image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PreviousImageWidth => PreviousImageSize.Width;

		/// 
		/// Gets or sets the height of the caption.
		/// </summary>
		/// The height of the caption.</value>
		[Category("Sizes")]
		[SRDescription("The caption height.")]
		public int CaptionHeight
		{
			get
			{
				return GetValue("CaptionHeight", DefaultCaptionHeight);
			}
			set
			{
				SetValue("CaptionHeight", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultCaptionHeight => GetImageHeight(CaptionStyle.BackgroundImage, 30);

		/// 
		/// Gets or sets the height of the header.
		/// </summary>
		/// The height of the header.</value>
		[Category("Sizes")]
		[SRDescription("The header height.")]
		public int HeaderHeight
		{
			get
			{
				return GetValue("HeaderHeight", DefaultHeaderHeight);
			}
			set
			{
				SetValue("HeaderHeight", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultHeaderHeight => GetImageHeight(HeaderStyle.BackgroundImage, 19);

		/// 
		/// Gets or sets the height of the month cell.
		/// </summary>
		/// The height of the month cell.</value>
		public int MonthCellHeight
		{
			get
			{
				return GetValue("MonthCellHeight", GetImageHeight(SelectedMonthCellStyle.BackgroundImage, 31));
			}
			set
			{
				SetValue("MonthCellHeight", value);
			}
		}

		/// 
		/// Gets or sets the height of the year cell.
		/// </summary>
		/// The height of the year cell.</value>
		public int YearCellHeight
		{
			get
			{
				return GetValue("YearCellHeight", GetImageHeight(SelectedYearCellStyle.BackgroundImage, 31));
			}
			set
			{
				SetValue("YearCellHeight", value);
			}
		}

		/// 
		/// Gets or sets the height of the year range cell.
		/// </summary>
		/// The height of the year range cell.</value>
		public int YearRangeCellHeight
		{
			get
			{
				return GetValue("YearRangeCellHeight", GetImageHeight(SelectedYearRangeCellStyle.BackgroundImage, 31));
			}
			set
			{
				SetValue("YearRangeCellHeight", value);
			}
		}

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the height of the caption.
		/// </summary>
		internal void ResetCaptionHeight()
		{
			Reset("CaptionHeight");
		}

		/// 
		/// Resets the height of the header.
		/// </summary>
		internal void ResetHeaderHeight()
		{
			Reset("HeaderHeight");
		}

		/// 
		/// Resets the height of the month cell.
		/// </summary>
		public void ResetMonthCellHeight()
		{
			Reset("MonthCellHeight");
		}

		/// 
		/// Resets the height of the year cell.
		/// </summary>
		public void ResetYearCellHeight()
		{
			Reset("YearCellHeight");
		}

		/// 
		/// Resets the height of the year range cell.
		/// </summary>
		public void ResetYearRangeCellHeight()
		{
			Reset("YearRangeCellHeight");
		}
	}
}

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
	/// ListView Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(ListView), "ListView.bmp")]
	public class ListViewSkin : ControlSkin
	{
		/// 
		/// Gets or sets the height of the large item label.
		/// </summary>
		/// 
		/// The height of the large item label.
		/// </value>
		[Category("Sizes")]
		[SRDescription("The height of a large item label.")]
		public int LargeItemLabelHeight
		{
			get
			{
				return GetValue("LargeItemLabelHeight", 27);
			}
			set
			{
				SetValue("LargeItemLabelHeight", value);
			}
		}

		/// 
		/// Gets or sets the color of the row back.
		/// </summary>
		/// The color of the row back.</value>
		[Category("Colors")]
		[SRDescription("The row backcolor.")]
		public virtual Color RowBackColor
		{
			get
			{
				return GetValue("RowBackColor", DefaultRowBackColor);
			}
			set
			{
				SetValue("RowBackColor", value);
			}
		}

		/// 
		/// Gets the default color of the row back.
		/// </summary>
		/// The default color of the row back.</value>
		protected virtual Color DefaultRowBackColor => SystemColors.Window;

		/// 
		/// Gets or sets the color of the row fore.
		/// </summary>
		/// The color of the row fore.</value>
		[Category("Colors")]
		[SRDescription("The row fore color.")]
		public virtual Color RowForeColor
		{
			get
			{
				return GetValue("RowForeColor", DefaultRowForeColor);
			}
			set
			{
				SetValue("RowForeColor", value);
			}
		}

		/// 
		/// Gets the default color of the row fore.
		/// </summary>
		/// The default color of the row fore.</value>
		protected virtual Color DefaultRowForeColor => SystemColors.WindowText;

		/// 
		/// Gets or sets the row font.
		/// </summary>
		/// The row font.</value>
		[Category("Fonts")]
		[SRDescription("The row font.")]
		public virtual Font RowFont
		{
			get
			{
				return GetValue("RowFont", DefaultRowFont);
			}
			set
			{
				SetValue("RowFont", value);
			}
		}

		/// 
		/// Gets the default row font.
		/// </summary>
		/// The default row font.</value>
		protected virtual Font DefaultRowFont => Font;

		/// 
		/// Gets the width of the header seperator.
		/// </summary>
		/// The width of the header seperator.</value>
		[Category("Sizes")]
		[SRDescription("The width of the header seperator.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual int HeaderSeperatorWidth
		{
			get
			{
				return GetValue("HeaderSeperatorWidth", DefaultHeaderSeperatorWidth);
			}
			set
			{
				SetValue("HeaderSeperatorWidth", value);
			}
		}

		/// 
		/// Gets the default width of the header seperator.
		/// </summary>
		/// The default width of the header seperator.</value>
		protected virtual int DefaultHeaderSeperatorWidth => 3;

		/// 
		/// Gets the height of the check box button.
		/// </summary>
		/// The height of the check box button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CheckBoxButtonHeight => GetMaxImageHeight(DefaultCheckBoxButtonHeight, "CheckBox0.gif", "CheckBox1.gif");

		/// 
		/// Gets the default height of the check box button.
		/// </summary>
		/// The default height of the check box button.</value>
		protected virtual int DefaultCheckBoxButtonHeight => 13;

		/// 
		/// Gets the width of the check box button.
		/// </summary>
		/// The width of the check box button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int CheckBoxButtonWidth => GetMaxImageWidth(DefaultCheckBoxButtonWidth, "CheckBox0.gif", "CheckBox1.gif");

		/// 
		/// Gets the default width of the check box button.
		/// </summary>
		/// The default width of the check box button.</value>
		protected virtual int DefaultCheckBoxButtonWidth => 13;

		/// 
		/// Gets or sets the width of the grid lines.
		/// </summary>
		/// </value>
		[Category("Sizes")]
		[SRDescription("The width of the grid lines.")]
		public virtual BorderWidth GridLinesWidth
		{
			get
			{
				return GetValue("GridLinesWidth", DefaultGridLinesWidth);
			}
			set
			{
				SetValue("GridLinesWidth", value);
			}
		}

		/// 
		/// Gets the default width of the grid lines.
		/// </summary>
		/// The default width of the grid lines.</value>
		protected virtual BorderWidth DefaultGridLinesWidth => new BorderWidth(1);

		/// 
		/// Gets the cell normal style.
		/// </summary>
		/// The cell normal style.</value>
		[Category("States")]
		[SRDescription("The normal cell style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CellNormalStyle => new StyleValue(this, "CellNormalStyle");

		/// 
		/// Gets the cell alternative style.
		/// </summary>
		/// The cell alternative style.</value>
		[Category("States")]
		[SRDescription("The alternative cell style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CellAlternativeStyle => new StyleValue(this, "CellAlternativeStyle");

		/// 
		/// Gets the cell selected style.
		/// </summary>
		/// The cell selected style.</value>
		[Category("States")]
		[SRDescription("The selected cell style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CellSelectedStyle => new StyleValue(this, "CellSelectedStyle");

		/// 
		/// Gets the header normal style.
		/// </summary>
		/// The header normal style.</value>
		[Category("States")]
		[SRDescription("The normal header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderNormalStyle => new StyleValue(this, "HeaderNormalStyle");

		/// 
		/// Gets the header hover style.
		/// </summary>
		/// The header hover style.</value>
		[Category("States")]
		[SRDescription("The hover header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderHoverStyle => new StyleValue(this, "HeaderHoverStyle", HeaderNormalStyle);

		/// 
		/// Gets the header pressed style.
		/// </summary>
		/// The header pressed style.</value>
		[Category("States")]
		[SRDescription("The pressed header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderPressedStyle => new StyleValue(this, "HeaderPressedStyle", HeaderNormalStyle);

		/// 
		/// Gets the header disabled style.
		/// </summary>
		/// The header disabled style.</value>
		[Category("States")]
		[SRDescription("The normal header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderDisabledStyle => new StyleValue(this, "HeaderDisabledStyle", HeaderNormalStyle);

		/// 
		/// Gets the header seperator normal style.
		/// </summary>
		/// The header seperator normal style.</value>
		[Category("States")]
		[SRDescription("The normal header seperator style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderSeperatorNormalStyle => new StyleValue(this, "HeaderSeperatorNormalStyle");

		/// 
		/// Gets the header seperator hover style.
		/// </summary>
		/// The header seperator hover style.</value>
		[Category("States")]
		[SRDescription("The hover header seperator style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderSeperatorHoverStyle => new StyleValue(this, "HeaderSeperatorHoverStyle", HeaderNormalStyle);

		/// 
		/// Gets the header seperator pressed style.
		/// </summary>
		/// The header seperator pressed style.</value>
		[Category("States")]
		[SRDescription("The pressed header seperator style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue HeaderSeperatorPressedStyle => new StyleValue(this, "HeaderSeperatorPressedStyle", HeaderNormalStyle);

		/// 
		/// Gets the header seperator disabled style.
		/// </summary>
		/// The header seperator disabled style.</value>
		[Category("States")]
		[SRDescription("The normal header seperator style.")]
		public virtual StyleValue HeaderSeperatorDisabledStyle => new StyleValue(this, "HeaderSeperatorDisabledStyle", HeaderNormalStyle);

		/// 
		/// Gets or sets the grid lines style.
		/// </summary>
		/// </value>
		[Category("Styles")]
		[SRDescription("The color of the grid lines style.")]
		public virtual BorderStyle GridLinesStyle
		{
			get
			{
				return GetValue("GridLinesStyle", BorderStyle.FixedSingle);
			}
			set
			{
				SetValue("GridLinesStyle", value);
			}
		}

		/// 
		/// Gets or sets the group header seperator color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[Description("The color which is used to display group header seperator.")]
		public virtual Color GroupHeaderSeperatorColor
		{
			get
			{
				return GetValue("GroupHeaderSeperatorColor", DefaultGroupHeaderSeperatorColor);
			}
			set
			{
				SetValue("GroupHeaderSeperatorColor", value);
			}
		}

		/// 
		/// Gets the default color of the group header seperator.
		/// </summary>
		/// The default color of the group header seperator.</value>
		protected virtual Color DefaultGroupHeaderSeperatorColor => Color.FromArgb(187, 190, 209);

		/// 
		/// Gets the group header style.
		/// </summary>
		[Category("GroupHeader")]
		[SRDescription("The group header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue GroupHeaderStyle => new StyleValue(this, "GroupHeaderStyle");

		/// 
		/// Gets or sets the group header fore color.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Colors")]
		[Description("The foreground color of this component, which is used to display group header text.")]
		[Obsolete("This property is obselete, Please use GroupHeaderStyle propert.y")]
		public virtual Color GroupHeaderForeColor
		{
			get
			{
				return GetValue("GroupHeaderForeColor", DefaultGroupHeaderForeColor);
			}
			set
			{
				SetValue("GroupHeaderForeColor", value);
			}
		}

		/// 
		/// Gets the default color of the group header fore.
		/// </summary>
		/// The default color of the group header fore.</value>
		[Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
		protected virtual Color DefaultGroupHeaderForeColor => Color.FromArgb(36, 62, 137);

		/// 
		/// Gets or sets the grid lines color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[SRDescription("The color of the grid lines.")]
		public virtual Color GridLinesColor
		{
			get
			{
				return GetValue("GridLinesColor", DefaultGridLinesColor);
			}
			set
			{
				SetValue("GridLinesColor", value);
			}
		}

		/// 
		/// Gets the default color of the grid lines.
		/// </summary>
		/// The default color of the grid lines.</value>
		protected virtual Color DefaultGridLinesColor => Color.FromArgb(213, 213, 213);

		/// 
		/// Gets or sets the sorted column background color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[SRDescription("The sorted column background color.")]
		public virtual Color SortedColumnBackColor
		{
			get
			{
				return GetAmbientValue("SortedColumnBackColor", DefaultSortedColumnBackColor);
			}
			set
			{
				SetValue("SortedColumnBackColor", value);
			}
		}

		/// 
		/// Gets the default color of the sorted column back.
		/// </summary>
		/// The default color of the sorted column back.</value>
		protected virtual Color DefaultSortedColumnBackColor => Color.FromArgb(247, 247, 247);

		/// 
		/// Gets the group header seperator background.
		/// </summary>
		/// The group header seperator background.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundValue GroupHeaderSeperatorBackground
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = GroupHeaderSeperatorColor;
				return backgroundValue;
			}
		}

		/// 
		/// Gets or sets the font of the group header text displayed by the control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Fonts")]
		[Description("The font used to display group header text in the control.")]
		[Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
		public virtual Font GroupHeaderFont
		{
			get
			{
				return GetValue("GroupHeaderFont", DefaultGroupHeaderFont);
			}
			set
			{
				SetValue("GroupHeaderFont", value);
			}
		}

		/// 
		/// Gets the default group header font.
		/// </summary>
		/// The default group header font.</value>
		[Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
		protected virtual Font DefaultGroupHeaderFont => new Font("Tahoma", 8.25f);

		/// 
		/// Gets the group header foreground.
		/// </summary>
		/// The group header foreground.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
		public virtual ForegroundValue GroupHeaderForeground
		{
			get
			{
				ForegroundValue foregroundValue = new ForegroundValue();
				foregroundValue.ForeColor = GroupHeaderForeColor;
				return foregroundValue;
			}
		}

		/// 
		/// Gets the grid lines style which can be translated.
		/// </summary>
		/// The grid lines style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BorderValue GridLines
		{
			get
			{
				BorderValue borderValue = new BorderValue();
				borderValue.Color = GridLinesColor;
				borderValue.Style = GridLinesStyle;
				borderValue.Width = GridLinesWidth;
				return borderValue;
			}
		}

		/// 
		/// Gets or sets a value indicating whether to show grid lines.
		/// </summary>
		/// true</c> to show grid lines; otherwise, false</c>.</value>
		[Category("States")]
		[SRDescription("The show grid lines.")]
		public virtual bool ShowGridLines
		{
			get
			{
				return GetValue("ShowGridLines", DefaultShowGridLines);
			}
			set
			{
				SetValue("ShowGridLines", value);
			}
		}

		/// 
		/// Gets the default show grid lines.
		/// </summary>
		/// The default show grid lines.</value>
		protected virtual bool DefaultShowGridLines => false;

		/// 
		/// Gets or sets the sorted column background image.
		/// </summary>
		/// The sorted column background image.</value>
		[SRDescription("The sorted column background image")]
		[SRCategory("CatAppearance")]
		public ImageResourceReference SortedColumnBackgroundImage
		{
			get
			{
				return GetValue("SortedColumnBackgroundImage", (ImageResourceReference)"");
			}
			set
			{
				SetValue("SortedColumnBackgroundImage", value);
			}
		}

		/// 
		/// Gets or sets the sorted column background image repeat.
		/// </summary>
		/// The sorted column background image repeat.</value>
		[SRDescription("Sets if or how a sorted column background image will be repeated.")]
		[SRCategory("CatAppearance")]
		public virtual BackgroundImageRepeat SortedColumnBackgroundImageRepeat
		{
			get
			{
				return GetValue("SortedColumnBackgroundImageRepeat", DefaultSortedColumnBackgroundImageRepeat);
			}
			set
			{
				SetValue("SortedColumnBackgroundImageRepeat", value);
			}
		}

		/// 
		/// Gets the default sorted column background image repeat.
		/// </summary>
		/// The default sorted column background image repeat.</value>
		protected virtual BackgroundImageRepeat DefaultSortedColumnBackgroundImageRepeat => BackgroundImageRepeat.Repeat;

		/// 
		/// Gets or sets the sorted column background image position.
		/// </summary>
		/// The sorted column background image position.</value>
		[SRDescription("Sets the starting position of a sorted column background image.")]
		[SRCategory("CatAppearance")]
		public virtual BackgroundImagePosition SortedColumnBackgroundImagePosition
		{
			get
			{
				return GetValue("SortedColumnBackgroundImagePosition", DefaultSortedColumnBackgroundImagePosition);
			}
			set
			{
				SetValue("SortedColumnBackgroundImagePosition", value);
			}
		}

		/// 
		/// Gets the default sorted column background image position.
		/// </summary>
		/// The default sorted column background image position.</value>
		protected virtual BackgroundImagePosition DefaultSortedColumnBackgroundImagePosition => BackgroundImagePosition.TopLeft;

		/// 
		/// Gets the sorted column background.
		/// </summary>
		/// The sorted column background.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual BackgroundValue SortedColumnBackground
		{
			get
			{
				BackgroundValue backgroundValue = new BackgroundValue();
				backgroundValue.BackColor = SortedColumnBackColor;
				backgroundValue.BackgroundImage = SortedColumnBackgroundImage;
				backgroundValue.BackgroundImagePosition = SortedColumnBackgroundImagePosition;
				backgroundValue.BackgroundImageRepeat = SortedColumnBackgroundImageRepeat;
				return backgroundValue;
			}
		}

		/// 
		/// Gets or sets the height of the paging control.
		/// </summary>
		/// The height of the paging control.</value>
		[Category("Paging")]
		[SRDescription("The paging control height.")]
		public virtual int PagingPanelHeight
		{
			get
			{
				return GetValue("PagingPanelHeight", GetImageHeight(PagingPanelStyle.BackgroundImage, DefaultPagingPanelHeight));
			}
			set
			{
				SetValue("PagingPanelHeight", value);
			}
		}

		/// 
		/// Gets the default height of the paging panel.
		/// </summary>
		/// The default height of the paging panel.</value>
		protected virtual int DefaultPagingPanelHeight => 22;

		/// 
		/// Gets or sets the height of the header.
		/// </summary>
		/// The height of the header.</value>
		[Category("Paging")]
		[SRDescription("The header height.")]
		public virtual int HeaderHeight
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
		/// Gets the default height of the header.
		/// </summary>
		/// The default height of the header.</value>
		protected virtual int DefaultHeaderHeight => -1;

		/// 
		/// Gets or sets the width of the paging first button.
		/// </summary>
		/// The width of the paging first button.</value>
		[Category("Paging")]
		[SRDescription("The paging first button width.")]
		public virtual int PagingFirstButtonWidth
		{
			get
			{
				return GetValue("PagingFirstButtonWidth", DefaultPagingFirstButtonWidth);
			}
			set
			{
				SetValue("PagingFirstButtonWidth", value);
			}
		}

		/// 
		/// Gets the default width of the paging first button.
		/// </summary>
		/// The default width of the paging first button.</value>
		protected virtual int DefaultPagingFirstButtonWidth => 20;

		/// 
		/// Gets or sets the width of the paging last button.
		/// </summary>
		/// The width of the paging last button.</value>
		[Category("Paging")]
		[SRDescription("The paging last button width.")]
		public virtual int PagingLastButtonWidth
		{
			get
			{
				return GetValue("PagingLastButtonWidth", DefaultPagingLastButtonWidth);
			}
			set
			{
				SetValue("PagingLastButtonWidth", value);
			}
		}

		/// 
		/// Gets the default width of the paging last button.
		/// </summary>
		/// The default width of the paging last button.</value>
		protected virtual int DefaultPagingLastButtonWidth => 20;

		/// 
		/// Gets or sets the width of the paging previous button.
		/// </summary>
		/// The width of the paging previous button.</value>
		[Category("Paging")]
		[SRDescription("The paging previous button width.")]
		public virtual int PagingPreviousButtonWidth
		{
			get
			{
				return GetValue("PagingPreviousButtonWidth", DefaultPagingPreviousButtonWidth);
			}
			set
			{
				SetValue("PagingPreviousButtonWidth", value);
			}
		}

		/// 
		/// Gets the default width of the paging previous button.
		/// </summary>
		/// The default width of the paging previous button.</value>
		protected virtual int DefaultPagingPreviousButtonWidth => 20;

		/// 
		/// Gets or sets the width of the paging next button.
		/// </summary>
		/// The width of the paging next button.</value>
		[Category("Paging")]
		[SRDescription("The paging next button width.")]
		public virtual int PagingNextButtonWidth
		{
			get
			{
				return GetValue("PagingNextButtonWidth", DefaultPagingNextButtonWidth);
			}
			set
			{
				SetValue("PagingNextButtonWidth", value);
			}
		}

		/// 
		/// Gets the default width of the paging next button.
		/// </summary>
		/// The default width of the paging next button.</value>
		protected virtual int DefaultPagingNextButtonWidth => 20;

		/// 
		/// Gets or sets the width of the paging box.
		/// </summary>
		/// The width of the paging box.</value>
		[Category("Paging")]
		[SRDescription("The paging box width.")]
		public virtual int PagingBoxWidth
		{
			get
			{
				return GetValue("PagingBoxWidth", DefaultPagingBoxWidth);
			}
			set
			{
				SetValue("PagingBoxWidth", value);
			}
		}

		/// 
		/// Gets the default width of the paging box.
		/// </summary>
		/// The default width of the paging box.</value>
		protected virtual int DefaultPagingBoxWidth => 50;

		/// 
		/// Gets the 'GoTo' box style.
		/// </summary>
		/// The 'GoTo' box style.</value>
		[Category("Paging")]
		[SRDescription("The current page / 'Go To' box style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PagingGotoBoxStyle => new StyleValue(this, "PagingGotoBoxStyle");

		/// 
		/// Gets the paging panel style.
		/// </summary>
		/// The paging panel style.</value>
		[Category("Paging")]
		[SRDescription("The pagging panel style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PagingPanelStyle => new StyleValue(this, "PagingPanelStyle");

		/// 
		/// Gets the paging prev button style.
		/// </summary>
		/// The paging prev button style.</value>
		[Category("Paging")]
		[SRDescription("The paging prev button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PagingPrevButtonStyle => new StyleValue(this, "PagingPrevButtonStyle");

		/// 
		/// Gets the paging next button style.
		/// </summary>
		/// The paging next button style.</value>
		[Category("Paging")]
		[SRDescription("The paging next button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PagingNextButtonStyle => new StyleValue(this, "PagingNextButtonStyle");

		/// 
		/// Gets the paging last button style.
		/// </summary>
		/// The paging last button style.</value>
		[Category("Paging")]
		[SRDescription("The paging last button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PagingLastButtonStyle => new StyleValue(this, "PagingLastButtonStyle");

		/// 
		/// Gets the paging first button style.
		/// </summary>
		/// The paging first button style.</value>
		[Category("Paging")]
		[SRDescription("The paging first button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue PagingFirstButtonStyle => new StyleValue(this, "PagingFirstButtonStyle");

		/// 
		/// Gets the bidirectional paging last button style.
		/// </summary>
		/// The bidirectional paging last button style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue BidirectionalPagingLastButtonStyle => new BidirectionalSkinValue<object>(this, PagingLastButtonStyle, PagingFirstButtonStyle);

		/// 
		/// Gets the bidirectional paging first button style.
		/// </summary>
		/// The bidirectional paging first button style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue BidirectionalPagingFirstButtonStyle => new BidirectionalSkinValue<object>(this, PagingFirstButtonStyle, PagingLastButtonStyle);

		/// 
		/// Gets the bidirectional paging prev button style.
		/// </summary>
		/// The bidirectional paging prev button style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue BidirectionalPagingPrevButtonStyle => new BidirectionalSkinValue<object>(this, PagingPrevButtonStyle, PagingNextButtonStyle);

		/// 
		/// Gets the bidirectional paging next button style.
		/// </summary>
		/// The bidirectional paging next button style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SkinValue BidirectionalPagingNextButtonStyle => new BidirectionalSkinValue<object>(this, PagingNextButtonStyle, PagingPrevButtonStyle);

		/// 
		/// Gets or sets the paging number seperator format.
		/// </summary>
		/// 
		/// The paging number seperator format.
		/// </value>
		[Category("Paging")]
		[SRDescription("The paging number seperator format.")]
		public string PagingNumberSeperatorFormat
		{
			get
			{
				return GetValue("PagingNumberSeperatorFormat", DefaultPagingNumberSeperatorFormat);
			}
			set
			{
				SetValue("PagingNumberSeperatorFormat", value);
			}
		}

		/// 
		/// Gets the default paging number seperator format.
		/// </summary>
		public string DefaultPagingNumberSeperatorFormat => "/";

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the color of the row back.
		/// </summary>
		internal void ResetRowBackColor()
		{
			Reset("RowBackColor");
		}

		/// 
		/// Resets the color of the row fore.
		/// </summary>
		internal void ResetRowForeColor()
		{
			Reset("RowForeColor");
		}

		/// 
		/// Resets the row font.
		/// </summary>
		internal void ResetRowFont()
		{
			Reset("RowFont");
		}

		/// 
		/// Resets the width of the header seperator.
		/// </summary>
		internal void ResetHeaderSeperatorWidth()
		{
			Reset("HeaderSeperatorWidth");
		}

		/// 
		/// Resets the height of the check box button.
		/// </summary>
		private void ResetCheckBoxButtonHeight()
		{
			Reset("CheckBoxButtonHeight");
		}

		/// 
		/// Resets the width of the check box button.
		/// </summary>
		private void ResetCheckBoxButtonWidth()
		{
			Reset("CheckBoxButtonWidth");
		}

		/// 
		/// Resets the width of the grid lines.
		/// </summary>
		internal void ResetGridLinesWidth()
		{
			Reset("GridLinesWidth");
		}

		/// 
		/// Resets the grid lines style.
		/// </summary>
		internal void ResetGridLinesStyle()
		{
			Reset("GridLinesStyle");
		}

		/// 
		/// Resets the color of the group header seperator.
		/// </summary>
		internal void ResetGroupHeaderSeperatorColor()
		{
			Reset("GroupHeaderSeperatorColor");
		}

		/// 
		/// Resets the group header style.
		/// </summary>
		internal void ResetGroupHeaderStyle()
		{
			GroupHeaderStyle.Reset();
		}

		/// 
		/// Resets the color of the group header fore.
		/// </summary>
		[Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
		internal void ResetGroupHeaderForeColor()
		{
			Reset("GroupHeaderForeColor");
		}

		/// 
		/// Resets the color of the grid lines.
		/// </summary>
		internal void ResetGridLinesColor()
		{
			Reset("GridLinesColor");
		}

		/// 
		/// Resets the color of the sorted column back.
		/// </summary>
		internal void ResetSortedColumnBackColor()
		{
			Reset("SortedColumnBackColor");
		}

		/// 
		/// Resets the group header font.
		/// </summary>
		[Obsolete("This property is obselete, Please use GroupHeaderStyle property.")]
		internal void ResetGroupHeaderFont()
		{
			Reset("GroupHeaderFont");
		}

		/// 
		/// Resets the show grid lines.
		/// </summary>
		private void ResetShowGridLines()
		{
			Reset("ShowGridLines");
		}

		/// 
		/// Resets the sorted column background image.
		/// </summary>
		internal void ResetSortedColumnBackgroundImage()
		{
			Reset("SortedColumnBackgroundImage");
		}

		/// 
		/// Resets the sorted column background image repeat.
		/// </summary>
		internal void ResetSortedColumnBackgroundImageRepeat()
		{
			Reset("SortedColumnBackgroundImageRepeat");
		}

		/// 
		/// Resets the sorted column background image position.
		/// </summary>
		internal void ResetSortedColumnBackgroundImagePosition()
		{
			Reset("SortedColumnBackgroundImagePosition");
		}

		/// 
		/// Gets the item size for view.
		/// </summary>
		/// <param name="enmView">The list view view.</param>
		/// </returns>
		internal Size GetItemSizeForView(View enmView)
		{
			return enmView switch
			{
				View.LargeIcon => new Size(200, 200), 
				View.SmallIcon => new Size(130, 21), 
				View.List => new Size(100, 21), 
				_ => Size.Empty, 
			};
		}

		/// 
		/// Resets the height of the paging panel.
		/// </summary>
		internal void ResetPagingPanelHeight()
		{
			Reset("PagingPanelHeight");
		}

		/// 
		/// Resets the height of the header.
		/// </summary>
		internal void ResetHeaderHeight()
		{
			Reset("HeaderHeight");
		}

		/// 
		/// Resets the width of the paging first button.
		/// </summary>
		internal void ResetPagingFirstButtonWidth()
		{
			Reset("PagingFirstButtonWidth");
		}

		/// 
		/// Resets the width of the paging last button.
		/// </summary>
		internal void ResetPagingLastButtonWidth()
		{
			Reset("PagingLastButtonWidth");
		}

		/// 
		/// Resets the width of the paging previous button.
		/// </summary>
		internal void ResetPagingPreviousButtonWidth()
		{
			Reset("PagingPreviousButtonWidth");
		}

		/// 
		/// Resets the width of the paging next button.
		/// </summary>
		internal void ResetPagingNextButtonWidth()
		{
			Reset("PagingNextButtonWidth");
		}

		/// 
		/// Resets the width of the paging box.
		/// </summary>
		internal void ResetPagingBoxWidth()
		{
			Reset("PagingBoxWidth");
		}
	}
}

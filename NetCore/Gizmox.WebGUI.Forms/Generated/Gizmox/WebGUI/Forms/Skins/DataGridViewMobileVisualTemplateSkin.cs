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
	///
	/// </summary>
	[Serializable]
	public class DataGridViewMobileVisualTemplateSkin : DataGridViewSkin
	{
		/// 
		/// Gets or sets the data grid view visual template add new row image.
		/// </summary>
		/// 
		/// The data grid view visual template add new row image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateAddNewRowImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateAddNewRowImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateAddNewRowImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template properties image.
		/// </summary>
		/// 
		/// The data grid view visual template properties image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplatePropertiesImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplatePropertiesImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplatePropertiesImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template sort image.
		/// </summary>
		/// 
		/// The data grid view visual template sort image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateSortImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateSortImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateSortImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template filter image.
		/// </summary>
		/// 
		/// The data grid view visual template filter image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateFilterImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateFilterImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateFilterImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template view configuration image.
		/// </summary>
		/// 
		/// The data grid view visual template view configuration image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateViewConfigurationImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateViewConfigurationImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateViewConfigurationImage", value);
			}
		}

		/// 
		/// Gets the size of the caption.
		/// </summary>
		/// 
		/// The size of the caption.
		/// </value>
		public Size CaptionSize => GetValue("CaptionSize", new Size(0, DefaultCaptionHeight));

		/// 
		/// Gets the default height of the caption.
		/// </summary>
		/// 
		/// The default height of the caption.
		/// </value>
		public int DefaultCaptionHeight => 32;

		/// 
		/// Gets the height of the TreeView visual template back button.
		/// </summary>
		/// 
		/// The height of the TreeView visual template back button.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CaptionHeight => CaptionSize.Height;

		/// 
		/// Gets the size of the bottom menu.
		/// </summary>
		/// 
		/// The size of the bottom menu.
		/// </value>
		public Size BottomMenuSize => GetValue("BottomMenuSize", new Size(0, DefaultBottomMenuHeight));

		/// 
		/// Gets the default height of the bottom menu.
		/// </summary>
		/// 
		/// The default height of the bottom menu.
		/// </value>
		public int DefaultBottomMenuHeight => 32;

		/// 
		/// Gets the height of the bottom menu.
		/// </summary>
		/// 
		/// The height of the bottom menu.
		/// </value>
		public int BottomMenuHeight => BottomMenuSize.Height;

		/// 
		/// Gets the bottom menu style.
		/// </summary>
		/// 
		/// The bottom menu style.
		/// </value>
		[Category("Styles")]
		[Description("The bottom menu style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue BottomMenuStyle => new StyleValue(this, "BottomMenuStyle");

		/// 
		/// Gets the bottom menu button style.
		/// </summary>
		/// 
		/// The bottom menu button style.
		/// </value>
		[Category("Styles")]
		[Description("The bottom menu button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue BottomMenuButtonStyle => new StyleValue(this, "BottomMenuButtonStyle");

		/// 
		/// Gets the size of the bottom menut button.
		/// </summary>
		/// 
		/// The size of the bottom menut button.
		/// </value>
		public virtual Size BottomMenutButtonSize => GetValue("BottomMenutButtonSize", new Size(DefaultBottomMenuButtonWidthHeight, DefaultBottomMenuButtonWidthHeight));

		/// 
		/// Gets the width of the bottom menu button.
		/// </summary>
		/// 
		/// The width of the bottom menu button.
		/// </value>
		public int BottomMenuButtonWidth => BottomMenutButtonSize.Width;

		/// 
		/// Gets the height of the bottom menu button.
		/// </summary>
		/// 
		/// The height of the bottom menu button.
		/// </value>
		public int BottomMenuButtonHeight => BottomMenutButtonSize.Width;

		/// 
		/// Gets the default height of the buttom menu bottom width.
		/// </summary>
		/// 
		/// The default height of the buttom menu bottom width.
		/// </value>
		private int DefaultBottomMenuButtonWidthHeight => 26;

		/// 
		/// Gets the caption menu button style.
		/// </summary>
		/// 
		/// The caption menu button style.
		/// </value>
		[Category("Styles")]
		[Description("The caption menu button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CaptionMenuButtonStyle => new StyleValue(this, "CaptionMenuButtonStyle");

		/// 
		/// Gets the size of the caption menut button.
		/// </summary>
		/// 
		/// The size of the caption menut button.
		/// </value>
		public virtual Size CaptionMenutButtonSize => GetValue("CaptionMenutButtonSize", new Size(DefaultCaptionMenuButtonWidthHeight, DefaultCaptionMenuButtonWidthHeight));

		/// 
		/// Gets the width of the caption menu button.
		/// </summary>
		/// 
		/// The width of the caption menu button.
		/// </value>
		public int CaptionMenuButtonWidth => CaptionMenutButtonSize.Width;

		/// 
		/// Gets the height of the caption menu button.
		/// </summary>
		/// 
		/// The height of the caption menu button.
		/// </value>
		public int CaptionMenuButtonHeight => BottomMenutButtonSize.Width;

		/// 
		/// Gets the default height of the buttom menu bottom width.
		/// </summary>
		/// 
		/// The default height of the buttom menu bottom width.
		/// </value>
		private int DefaultCaptionMenuButtonWidthHeight => 28;

		/// 
		/// Gets the sort column row style.
		/// </summary>
		/// 
		/// The sort column row style.
		/// </value>
		[Category("Styles")]
		[Description("The bottom menu button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SortColumnRowStyle => new StyleValue(this, "SortColumnRowStyle");

		/// 
		/// Gets the sort column text style.
		/// </summary>
		/// 
		/// The sort column text style.
		/// </value>
		[Category("Styles")]
		[Description("The sorting text style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SortColumnTextStyle => new StyleValue(this, "SortColumnTextStyle");

		/// 
		/// Gets or sets the data grid view visual template sort column check image.
		/// </summary>
		/// 
		/// The data grid view visual template sort column check image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateSortColumnCheckImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateSortColumnCheckImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateSortColumnCheckImage", value);
			}
		}

		/// 
		/// Gets the width of the data grid view visual template sort column check width.
		/// </summary>
		/// 
		/// The width of the data grid view visual template sort column check width.
		/// </value>
		public int DataGridViewVisualTemplateSortColumnCheckWidth => GetImageWidth(DataGridViewVisualTemplateSortColumnCheckImage, CaptionMenutButtonSize.Width);

		/// 
		/// Gets or sets the data grid view visual template filter column next image RTL.
		/// </summary>
		/// 
		/// The data grid view visual template filter column next image RTL.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ImageResourceReference DataGridViewVisualTemplateFilterColumnNextImageRTL
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateFilterColumnNextImageRTL", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateFilterColumnNextImageRTL", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template filter column next image LTR.
		/// </summary>
		/// 
		/// The data grid view visual template filter column next image LTR.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ImageResourceReference DataGridViewVisualTemplateFilterColumnNextImageLTR
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateFilterColumnNextImageLTR", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateFilterColumnNextImageLTR", value);
			}
		}

		/// 
		/// Gets the data grid view visual template filter column next image.
		/// </summary>
		/// 
		/// The data grid view visual template filter column next image.
		/// </value>
		public BidirectionalSkinProperty<object> DataGridViewVisualTemplateFilterColumnNextImage => new BidirectionalSkinProperty<object>(this, "DataGridViewVisualTemplateFilterColumnNextImageLTR", "DataGridViewVisualTemplateFilterColumnNextImageRTL");

		/// 
		/// Gets the width of the data grid view visual template filter column next.
		/// </summary>
		/// 
		/// The width of the data grid view visual template filter column next.
		/// </value>
		public int DataGridViewVisualTemplateFilterColumnNextWidth => GetImageWidth(DataGridViewVisualTemplateFilterColumnNextImageLTR, CaptionMenutButtonSize.Width);

		/// 
		/// Gets the filter column row style.
		/// </summary>
		/// 
		/// The filter column row style.
		/// </value>
		[Category("Styles")]
		[Description("The filter page row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue FilterColumnRowStyle => new StyleValue(this, "FilterColumnRowStyle");

		/// 
		/// Gets the filter column text style.
		/// </summary>
		/// 
		/// The filter column text style.
		/// </value>
		[Category("Styles")]
		[Description("The filtering text style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue FilterColumnTextStyle => new StyleValue(this, "FilterColumnTextStyle");

		/// 
		/// Gets the filter column data style.
		/// </summary>
		/// 
		/// The filter column data style.
		/// </value>
		[Category("Styles")]
		[Description("The filtering data style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue FilterColumnDataStyle => new StyleValue(this, "FilterColumnDataStyle");

		/// 
		/// Gets the view column row style.
		/// </summary>
		/// 
		/// The view column row style.
		/// </value>
		[Category("Styles")]
		[Description("The view page row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue DisplayOrderColumnRowStyle => new StyleValue(this, "DisplayOrderColumnRowStyle");

		/// 
		/// Gets the view sub title style.
		/// </summary>
		/// 
		/// The view sub title style.
		/// </value>
		[Category("Styles")]
		[Description("The view sub title style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ViewSubTitleStyle => new StyleValue(this, "ViewSubTitleStyle");

		/// 
		/// Gets the view column row style.
		/// </summary>
		/// 
		/// The view column row style.
		/// </value>
		[Category("Styles")]
		[Description("The view page column row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ViewColumnRowStyle => new StyleValue(this, "ViewColumnRowStyle");

		/// 
		/// Gets the view categoty title column row style.
		/// </summary>
		/// 
		/// The view categoty title column row style.
		/// </value>
		[Category("Styles")]
		[Description("The view categoty title column row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ViewCategoryTitleColumnRowStyle => new StyleValue(this, "ViewCategoryTitleColumnRowStyle");

		/// 
		/// Gets the add group column row style.
		/// </summary>
		/// 
		/// The add group column row style.
		/// </value>
		[Category("Styles")]
		[Description("The add group column row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue AddGroupColumnRowStyle => new StyleValue(this, "AddGroupColumnRowStyle");

		/// 
		/// Gets the group column row style.
		/// </summary>
		/// 
		/// The group column row style.
		/// </value>
		[Category("Styles")]
		[Description("The group column row style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue GroupColumnRowStyle => new StyleValue(this, "GroupColumnRowStyle");

		/// 
		/// Gets the view column text style.
		/// </summary>
		/// 
		/// The view column text style.
		/// </value>
		[Category("Styles")]
		[Description("The view text style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ViewColumnTextStyle => new StyleValue(this, "ViewColumnTextStyle");

		/// 
		/// Gets the view column data style.
		/// </summary>
		/// 
		/// The view column data style.
		/// </value>
		[Category("Styles")]
		[Description("The view data style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ViewColumnDataStyle => new StyleValue(this, "ViewColumnDataStyle");

		/// 
		/// Gets or sets the data grid view visual template list disabled image.
		/// </summary>
		/// 
		/// The data grid view visual template list disabled image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateListDisabledImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateListDisabledImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateListDisabledImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template list enabled image.
		/// </summary>
		/// 
		/// The data grid view visual template list enabled image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateListEnabledImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateListEnabledImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateListEnabledImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template table disabled image.
		/// </summary>
		/// 
		/// The data grid view visual template table disabled image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateTableDisabledImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateTableDisabledImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateTableDisabledImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template table enabled image.
		/// </summary>
		/// 
		/// The data grid view visual template table enabled image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateTableEnabledImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateTableEnabledImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateTableEnabledImage", value);
			}
		}

		/// 
		/// Gets the width of the data grid view visual template list enabled.
		/// </summary>
		/// 
		/// The width of the data grid view visual template list enabled.
		/// </value>
		public int DataGridViewVisualTemplateListEnabledWidth => GetImageWidth(DataGridViewVisualTemplateListEnabledImage, 45);

		/// 
		/// Gets the width of the data grid view visual template list disabled.
		/// </summary>
		/// 
		/// The width of the data grid view visual template list disabled.
		/// </value>
		public int DataGridViewVisualTemplateListDisabledWidth => GetImageWidth(DataGridViewVisualTemplateListDisabledImage, 45);

		/// 
		/// Gets the width of the data grid view visual template table enabled.
		/// </summary>
		/// 
		/// The width of the data grid view visual template table enabled.
		/// </value>
		public int DataGridViewVisualTemplateTableEnabledWidth => GetImageWidth(DataGridViewVisualTemplateTableEnabledImage, 45);

		/// 
		/// Gets the width of the data grid view visual template table disabled.
		/// </summary>
		/// 
		/// The width of the data grid view visual template table disabled.
		/// </value>
		public int DataGridViewVisualTemplateTableDisabledWidth => GetImageWidth(DataGridViewVisualTemplateTableDisabledImage, 45);

		/// 
		/// Gets or sets the data grid view visual template view by groups disabled image.
		/// </summary>
		/// 
		/// The data grid view visual template view by groups disabled image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateViewByGroupsDisabledImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateViewByGroupsDisabledImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateViewByGroupsDisabledImage", value);
			}
		}

		/// 
		/// Gets or sets the data grid view visual template view by groups enabled image.
		/// </summary>
		/// 
		/// The data grid view visual template view by groups enabled image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateViewByGroupsEnabledImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateViewByGroupsEnabledImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateViewByGroupsEnabledImage", value);
			}
		}

		/// 
		/// Gets the width of the data grid view visual template view by groups disabled.
		/// </summary>
		/// 
		/// The width of the data grid view visual template view by groups disabled.
		/// </value>
		public int DataGridViewVisualTemplateViewByGroupsDisabledWidth => GetImageWidth(DataGridViewVisualTemplateViewByGroupsDisabledImage, 45);

		/// 
		/// Gets the width of the data grid view visual template view by groups enabled.
		/// </summary>
		/// 
		/// The width of the data grid view visual template view by groups enabled.
		/// </value>
		public int DataGridViewVisualTemplateViewByGroupsEnabledWidth => GetImageWidth(DataGridViewVisualTemplateViewByGroupsEnabledImage, 45);

		/// 
		/// Gets or sets the data grid view visual template add group image.
		/// </summary>
		/// 
		/// The data grid view visual template add group image.
		/// </value>
		public ImageResourceReference DataGridViewVisualTemplateAddGroupImage
		{
			get
			{
				return GetValue<ImageResourceReference>("DataGridViewVisualTemplateAddGroupImage", null);
			}
			set
			{
				SetValue("DataGridViewVisualTemplateAddGroupImage", value);
			}
		}

		/// 
		/// Gets the width of the data grid view visual template add group.
		/// </summary>
		/// 
		/// The width of the data grid view visual template add group.
		/// </value>
		public int DataGridViewVisualTemplateAddGroupWidth => GetImageWidth(DataGridViewVisualTemplateAddGroupImage, 45);

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the size of the caption.
		/// </summary>
		public void ResetCaptionSize()
		{
			Reset("CaptionSize");
		}

		/// 
		/// Resets the size of the bottom menu.
		/// </summary>
		public void ResetBottomMenuSize()
		{
			Reset("BottomMenuSize");
		}
	}
}

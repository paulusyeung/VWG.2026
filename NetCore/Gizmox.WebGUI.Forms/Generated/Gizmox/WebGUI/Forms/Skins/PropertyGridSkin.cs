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
	/// PropertyGrid Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(PropertyGrid), "PropertyGrid.bmp")]
	[SkinDependency(typeof(AnchorPanelSkin))]
	[SkinDependency(typeof(DockButtonSkin))]
	public class PropertyGridSkin : ControlSkin
	{
		/// 
		///
		/// </summary>
		public class GridStyleValue : StyleValue
		{
			/// 
			/// Gets or sets the default border width.
			/// </summary>
			/// </value>
			protected override BorderColor DefaultBorderColor
			{
				get
				{
					if (PropertyGridSkin != null)
					{
						return PropertyGridSkin.GridLinesColor;
					}
					return base.DefaultBorderColor;
				}
			}

			/// 
			/// Gets or sets the default border style.
			/// </summary>
			/// </value>
			protected override BorderStyle DefaultBorderStyle
			{
				get
				{
					if (PropertyGridSkin != null)
					{
						return PropertyGridSkin.GridLinesStyle;
					}
					return base.DefaultBorderStyle;
				}
			}

			/// 
			/// Gets or sets the default border width.
			/// </summary>
			/// </value>
			protected override BorderWidth DefaultBorderWidth
			{
				get
				{
					if (PropertyGridSkin != null)
					{
						return PropertyGridSkin.GridLinesWidth;
					}
					return base.DefaultBorderWidth;
				}
			}

			/// 
			/// Gets the property grid skin.
			/// </summary>
			/// The property grid skin.</value>
			private PropertyGridSkin PropertyGridSkin => base.Skin as PropertyGridSkin;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.PropertyGridSkin.GridStyleValue" /> class.
			/// </summary>
			/// <param name="objPropertyOwner">The property owner.</param>
			/// <param name="strPropertyPrefix">The property prefix.</param>
			public GridStyleValue(PropertyGridSkin objPropertyOwner, string strPropertyPrefix)
				: base(objPropertyOwner, strPropertyPrefix)
			{
			}
		}

		/// 
		/// Gets the row height
		/// </summary>
		/// The row height.</value>
		[Category("Sizes")]
		[Description("The row height.")]
		public virtual int RowHeight
		{
			get
			{
				return GetValue("RowHeight", DefaultRowHeight);
			}
			set
			{
				SetValue("RowHeight", value);
			}
		}

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultRowHeight => 18;

		/// 
		/// Gets or sets the width of the grid lines.
		/// </summary>
		/// </value>
		[Category("Sizes")]
		[Description("The width of the grid lines.")]
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
		/// Gets default value
		/// </summary>
		protected virtual BorderWidth DefaultGridLinesWidth => new BorderWidth(1);

		/// 
		/// Gets the width of the plus button.
		/// </summary>
		/// The width of the plus button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int PlusButtonWidth => GetMaxImageWidth(DefaultPlusButtonWidth, "PGLightPlus0.gif", "PGLightPlus1.gif");

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultPlusButtonWidth => 9;

		/// 
		/// Gets the height of the plus button.
		/// </summary>
		/// The height of the plus button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int PlusButtonHeight => GetMaxImageHeight(DefaultPlusButtonHeight, "PGLightPlus0.gif", "PGLightPlus1.gif");

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultPlusButtonHeight => 9;

		/// 
		/// Gets the height of the category plus button.
		/// </summary>
		/// The height of the category plus button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CategoryPlusButtonHeight => GetMaxImageHeight(DefaultCategoryPlusButtonHeight, "PGLightPlus0.gif");

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultCategoryPlusButtonHeight => 9;

		/// 
		/// Gets the width of the category plus button.
		/// </summary>
		/// The width of the category plus button.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CategoryPlusButtonWidth => GetMaxImageWidth(DefaultCategoryPlusButtonWidth, "PGLightPlus0.gif");

		/// 
		/// Gets default value
		/// </summary>
		protected virtual int DefaultCategoryPlusButtonWidth => 9;

		/// 
		/// Gets the category style.
		/// </summary>
		/// The category style.</value>
		[Category("Style")]
		[Description("The category style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CategoryStyle => new GridStyleValue(this, "CategoryStyle");

		/// 
		/// Gets the splitter style.
		/// </summary>
		/// The splitter style.</value>
		[Category("Style")]
		[Description("The splitter style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue SplitterStyle => new GridStyleValue(this, "SplitterStyle");

		/// 
		/// Gets the property value normal style.
		/// </summary>
		/// The property value normal style.</value>
		[Category("States")]
		[Description("The property value normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ValueNormalStyle => new GridStyleValue(this, "ValueNormalStyle");

		/// 
		/// Gets the property value active style.
		/// </summary>
		/// The property value active style.</value>
		[Category("States")]
		[Description("The property value active style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ValueActiveStyle => new GridStyleValue(this, "ValueActiveStyle");

		/// 
		/// Gets the property label normal style.
		/// </summary>
		/// The property label normal style.</value>
		[Category("States")]
		[Description("The property label normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue LabelNormalStyle => new GridStyleValue(this, "LabelNormalStyle");

		/// 
		/// Gets the property label active style.
		/// </summary>
		/// The property label active style.</value>
		[Category("States")]
		[Description("The property label active style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue LabelActiveStyle => new StyleValue(this, "LabelActiveStyle");

		/// 
		/// Gets the outline style.
		/// </summary>
		/// The outline style.</value>
		[Category("Style")]
		[Description("The outline style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue OutlineStyle => new StyleValue(this, "OutlineStyle");

		/// 
		/// Gets or sets the grid lines color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[Description("The color of the grid lines.")]
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
		/// Gets default value
		/// </summary>
		protected virtual Color DefaultGridLinesColor => Color.FromArgb(211, 219, 233);

		/// 
		/// Gets or sets the grid lines style.
		/// </summary>
		/// </value>
		[Category("Styles")]
		[Description("The color of the grid lines style.")]
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
		/// Gets the help panel style.
		/// </summary>
		/// The help panel style.</value>
		[Category("Styles")]
		[Description("The help panel style, you can define the BorderStyle, BorderColor and Padding of the help panel.")]
		public virtual StyleValue HelpPanelStyle => new StyleValue(this, "HelpPanelStyle");

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
		/// Resets the height value
		/// </summary>
		internal void ResetRowHeight()
		{
			Reset("RowHeight");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetGridLinesWidth()
		{
			Reset("GridLinesWidth");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetPlusButtonWidth()
		{
			Reset("PlusButtonWidth");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetPlusButtonHeight()
		{
			Reset("PlusButtonHeight");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetCategoryPlusButtonHeight()
		{
			Reset("CategoryPlusButtonHeight");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetCategoryPlusButtonWidth()
		{
			Reset("CategoryPlusButtonWidth");
		}

		/// 
		/// Resets the height value
		/// </summary>
		internal void ResetGridLinesColor()
		{
			Reset("GridLinesColor");
		}

		private void InitializeComponent()
		{
		}
	}
}

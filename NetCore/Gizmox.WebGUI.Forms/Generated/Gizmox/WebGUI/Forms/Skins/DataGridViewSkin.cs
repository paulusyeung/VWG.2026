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
	/// DataGridView Skin
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(DataGridView), "DataGridView.bmp")]
	[SkinDependency(typeof(DataGridViewFilterButtonSkin))]
	[SkinDependency(typeof(DataGridViewButtonCellSkin))]
	[SkinDependency(typeof(DataGridViewCheckBoxCellSkin))]
	[SkinDependency(typeof(DataGridViewComboBoxCellSkin))]
	[SkinDependency(typeof(DataGridViewImageCellSkin))]
	[SkinDependency(typeof(DataGridViewLinkCellSkin))]
	[SkinDependency(typeof(DataGridViewTextBoxCellSkin))]
	[SkinDependency(typeof(ColumnChooserButtonSkin))]
	[SkinDependency(typeof(DataGridViewActiveTextBoxCellSkin))]
	[SkinDependency(typeof(DataGridViewGroupingTreeViewSkin))]
	[SkinDependency(typeof(DataGridViewCellPanelSkin))]
	[SkinDependency(typeof(DataGridViewFilterComboBoxSkin))]
	[SkinDependency(typeof(DataGridViewHeaderFilterComboBoxSkin))]
	[SkinDependency(typeof(DataGridViewFilterComboBoxSkin))]
	public class DataGridViewSkin : ControlSkin
	{
		[Serializable]
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
					if (DataGridViewSkin != null)
					{
						return DataGridViewSkin.GridLinesColor;
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
					if (DataGridViewSkin != null)
					{
						return DataGridViewSkin.GridLinesStyle;
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
					if (DataGridViewSkin != null)
					{
						return DataGridViewSkin.GridLinesWidth;
					}
					return base.DefaultBorderWidth;
				}
			}

			/// 
			/// Gets the property grid skin.
			/// </summary>
			/// The property grid skin.</value>
			private DataGridViewSkin DataGridViewSkin => base.Skin as DataGridViewSkin;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.DataGridViewSkin.GridStyleValue" /> class.
			/// </summary>
			/// <param name="objPropertyOwner">The property owner.</param>
			/// <param name="strPropertyPrefix">The property prefix.</param>
			public GridStyleValue(DataGridViewSkin objPropertyOwner, string strPropertyPrefix)
				: base(objPropertyOwner, strPropertyPrefix)
			{
			}
		}

		/// 
		/// Gets the extended columns non frozen style.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ExtendedColumnsNonFrozenStyle => new StyleValue(this, "ExtendedColumnsNonFrozenStyle");

		/// 
		/// Gets the extended columns frozen style.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ExtendedColumnsFrozenStyle => new StyleValue(this, "ExtendedColumnsFrozen");

		/// 
		/// Gets the extended columns corner style.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ExtendedColumnsCornerStyle => new StyleValue(this, "ExtendedColumnsCorner");

		/// 
		/// Gets the "clear all filters" tooltip localized string.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual string ClearAllFiltersToolTip => SR.GetString("ClearAllFilters");

		/// 
		/// Gets or sets the drop indicator style.
		/// </summary>
		/// 
		/// The drop indicator style.
		/// </value>
		[SRCategory("Styles")]
		[SRDescription("Grouping TreeNode drop indicator style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue DropIndicatorStyle => new StyleValue(this, "DropIndicatorStyle");

		/// 
		/// Gets the grouping drop area empty style.
		/// </summary>
		[Category("Styles")]
		[SRDescription("The empty grouping drop area style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue GroupingDropAreaStyle => new StyleValue(this, "GroupingDropAreaStyle");

		/// 
		/// Gets the grouping drop area empty message style.
		/// </summary>
		[Category("Styles")]
		[SRDescription("The empty grouping drop area empty message style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue GroupingDropAreaEmptyMessageStyle => new StyleValue(this, "GroupingDropAreaEmptyMessageStyle");

		/// 
		/// Gets the grouping drop area empty message.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual string GroupingDropAreaEmptyMessage => SR.GetString("DataGridViewGroupingTreeViewDragColumnHeaderHere");

		/// 
		/// Gets or sets the grouping drop area empty message align.
		/// </summary>
		/// 
		/// The grouping drop area empty message align.
		/// </value>
		[Category("Appearance")]
		[SRDescription("The empty grouping drop area message alignment.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public HorizontalAlignment GroupingDropAreaEmptyMessageAlign
		{
			get
			{
				return GetValue("GroupingDropAreaEmptyMessageAlign", HorizontalAlignment.Left);
			}
			set
			{
				SetValue("GroupingDropAreaEmptyMessageAlign", value);
			}
		}

		/// 
		/// Gets the "clear all filters" button style.
		/// </summary>
		[Category("Styles")]
		[SRDescription("The \"Clear All Filters\" button style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue FilterRowClearButtonStyle => new StyleValue(this, "FilterRowClearButtonStyle");

		/// 
		/// Gets the caption style.
		/// </summary>
		[Category("Styles")]
		[SRDescription("The caption style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CaptionStyle => new StyleValue(this, "CaptionStyle");

		/// 
		/// Gets the row header normal style.
		/// </summary>
		/// The row header normal style.</value>
		[Category("States")]
		[SRDescription("The normal row header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue RowHeaderNormalStyle => new GridStyleValue(this, "RowHeaderNormalStyle");

		/// 
		/// Gets the row header selected style.
		/// </summary>
		/// The row header selected style.</value>
		[Category("States")]
		[SRDescription("The selected row header style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual OpacityValue SelectedRowHeaderOpacity
		{
			get
			{
				return GetValue("SelectedRowHeaderOpacity", new OpacityValue(DefaultSelectedRowHeaderOpacity));
			}
			set
			{
				if (value.Opacity >= 0 && value.Opacity <= 100)
				{
					SetValue("SelectedRowHeaderOpacity", value);
					return;
				}
				throw new Exception("You must supply values between 1 and 100.");
			}
		}

		/// 
		/// Gets the default selected row header opacity.
		/// </summary>
		/// The default selected row header opacity.</value>
		protected virtual int DefaultSelectedRowHeaderOpacity => 60;

		/// 
		/// Gets the column header normal style.
		/// </summary>
		/// The row column normal style.</value>
		[Category("States")]
		[SRDescription("The normal row column style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue ColumnHeaderNormalStyle => new GridStyleValue(this, "ColumnHeaderNormalStyle");

		/// 
		/// Gets the left top header normal style.
		/// </summary>
		/// The left top header normal style.</value>
		[Category("States")]
		[SRDescription("The left top header normal style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinValue<object> LeftTopHeaderNormalStyle => new BidirectionalSkinValue<object>(this, LeftTopHeaderNormalStyleLTR, LeftTopHeaderNormalStyleRTL);

		/// 
		/// Gets the left top header normal style LTR.
		/// </summary>
		/// The left top header normal style LTR.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("The LeftToRight left top header normal style.")]
		protected virtual StyleValue LeftTopHeaderNormalStyleLTR => new GridStyleValue(this, "LeftTopHeaderNormalStyleLTR");

		/// 
		/// Gets the left top header normal style RTL.
		/// </summary>
		/// The left top header normal style RTL.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("The RightToLeft left top header normal style.")]
		protected virtual StyleValue LeftTopHeaderNormalStyleRTL => new GridStyleValue(this, "LeftTopHeaderNormalStyleRTL");

		/// 
		/// Gets the cell normal style.
		/// </summary>
		/// The cell normal style.</value>
		[Category("States")]
		[SRDescription("The normal cell style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CellNormalStyle => new StyleValue(this, "CellNormalStyle");

		/// 
		/// Gets the color of the cell normal style fore color .
		/// </summary>
		/// The color of the cell normal style fore.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Color CellNormalStyleForeColor => CellNormalStyle.ForeColor;

		/// 
		/// Gets the cell alternative style.
		/// </summary>
		/// The cell alternative style.</value>
		[Category("States")]
		[SRDescription("The alternative cell style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual StyleValue CellAlternativeStyle => new StyleValue(this, "CellAlternativeStyle", CellNormalStyle);

		/// 
		/// Gets the cell selected style.
		/// </summary>
		/// The cell selected style.</value>
		[Category("States")]
		[SRDescription("The selected cell style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual StyleValue CellSelectedStyle => new StyleValue(this, "CellSelectedStyle", CellNormalStyle);

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
		/// Gets the width of the drop indicator down arrow image.
		/// </summary>
		/// 
		/// The width of the drop indicator down arrow image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DropIndicatorDownArrowImageWidth => GetImageWidth(DropIndicatorStyle.BackgroundImage);

		/// 
		/// Gets the height of the drop indicator down arrow image.
		/// </summary>
		/// 
		/// The height of the drop indicator down arrow image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int DropIndicatorDownArrowImageHeight => GetImageHeight(DropIndicatorStyle.BackgroundImage);

		[Category("Sizes")]
		[SRDescription("The grouping drop area height.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual int DropAreaHeight
		{
			get
			{
				return GetValue("DropAreaHeight", 100);
			}
			set
			{
				SetValue("DropAreaHeight", value);
			}
		}

		/// 
		/// Gets the width of the filter clear button image.
		/// </summary>
		/// 
		/// The width of the filter clear button image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int FilterClearButtonImageWidth => GetImageWidth(FilterRowClearButtonStyle.BackgroundImage);

		/// 
		/// Gets the height of the filter clear button image.
		/// </summary>
		/// 
		/// The height of the filter clear button image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual int FilterClearButtonImageHeight => GetImageHeight(FilterRowClearButtonStyle.BackgroundImage);

		/// 
		/// Gets or sets the clear all filters button margin.
		/// </summary>
		/// 
		/// The clear all filters button margin.
		/// </value>
		[Category("Sizes")]
		[SRDescription("The \"Clear All Filters\" button margin.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int ClearAllFiltersButtonMargin
		{
			get
			{
				return GetValue("ClearAllFiltersButtonMargin", 5);
			}
			set
			{
				SetValue("ClearAllFiltersButtonMargin", value);
			}
		}

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
		/// Gets or sets the grid lines color.
		/// </summary>
		/// </value>
		[Category("Colors")]
		[SRDescription("The color of the grid lines.")]
		public Color GridLinesColor
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
		protected virtual Color DefaultGridLinesColor => Color.FromArgb(208, 215, 229);

		/// 
		/// Gets the grid lines style which can be translated.
		/// </summary>
		/// The grid lines style.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BorderValue GridLines
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
		protected virtual int DefaultPagingPanelHeight => 21;

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

		/// 
		/// Gets or sets the equals comparision operator.
		/// </summary>
		/// 
		/// The equals comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The equals comparison operator.")]
		public virtual ImageResourceReference EqualsComparisionOperator
		{
			get
			{
				return GetValue("EqualsComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("EqualsComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the not equals comparision operator.
		/// </summary>
		/// 
		/// The not equals comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The NotEquals comparison operator.")]
		public virtual ImageResourceReference NotEqualsComparisionOperator
		{
			get
			{
				return GetValue("NotEqualsComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("NotEqualsComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the initial operator image.
		/// </summary>
		/// 
		/// The initial operator image.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The initial operator image.")]
		public virtual ImageResourceReference InitialOperatorImage
		{
			get
			{
				return GetValue("InitialOperatorImage", (ImageResourceReference)"");
			}
			set
			{
				SetValue("InitialOperatorImage", value);
			}
		}

		/// 
		/// Gets or sets the less than comparision operator.
		/// </summary>
		/// 
		/// The less than comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The LessThan comparison operator.")]
		public virtual ImageResourceReference LessThanComparisionOperator
		{
			get
			{
				return GetValue("LessThanComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("LessThanComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the less than or equal to comparision operator.
		/// </summary>
		/// 
		/// The less than or equal to comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The LessThanOrEqualTo comparison operator.")]
		public virtual ImageResourceReference LessThanOrEqualToComparisionOperator
		{
			get
			{
				return GetValue("LessThanOrEqualToComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("LessThanOrEqualToComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the greater than comparision operator.
		/// </summary>
		/// 
		/// The greater than comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The GreaterThan comparison operator.")]
		public virtual ImageResourceReference GreaterThanComparisionOperator
		{
			get
			{
				return GetValue("GreaterThanComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("GreaterThanComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the greater than or equal to comparision operator.
		/// </summary>
		/// 
		/// The greater than or equal to comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The GreaterThanOrEqualTo comparison operator.")]
		public virtual ImageResourceReference GreaterThanOrEqualToComparisionOperator
		{
			get
			{
				return GetValue("GreaterThanOrEqualToComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("GreaterThanOrEqualToComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the like comparision operator.
		/// </summary>
		/// 
		/// The like comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The Like comparison operator.")]
		public virtual ImageResourceReference LikeComparisionOperator
		{
			get
			{
				return GetValue("LikeComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("LikeComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the match comparision operator.
		/// </summary>
		/// 
		/// The match comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The Match comparison operator.")]
		public virtual ImageResourceReference MatchComparisionOperator
		{
			get
			{
				return GetValue("MatchComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("MatchComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the not like comparision operator.
		/// </summary>
		/// 
		/// The not like comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The NotLike comparison operator.")]
		public virtual ImageResourceReference NotLikeComparisionOperator
		{
			get
			{
				return GetValue("NotLikeComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("NotLikeComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the does not match comparision operator.
		/// </summary>
		/// 
		/// The does not match comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The DoesNotMatch comparison operator.")]
		public virtual ImageResourceReference DoesNotMatchComparisionOperator
		{
			get
			{
				return GetValue("DoesNotMatchComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("DoesNotMatchComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the starts with comparision operator.
		/// </summary>
		/// 
		/// The starts with comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The StartsWith comparison operator.")]
		public virtual ImageResourceReference StartsWithComparisionOperator
		{
			get
			{
				return GetValue("StartsWithComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("StartsWithComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the does not start with comparision operator.
		/// </summary>
		/// 
		/// The does not start with comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The DoesNotStartWith comparison operator.")]
		public virtual ImageResourceReference DoesNotStartWithComparisionOperator
		{
			get
			{
				return GetValue("DoesNotStartWithComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("DoesNotStartWithComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the ends with comparision operator.
		/// </summary>
		/// 
		/// The ends with comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The EndsWith comparison operator.")]
		public virtual ImageResourceReference EndsWithComparisionOperator
		{
			get
			{
				return GetValue("EndsWithComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("EndsWithComparisionOperator", value);
			}
		}

		[SRCategory("Images")]
		[SRDescription("The DoesNotEndWith comparison operator.")]
		public virtual ImageResourceReference DoesNotEndWithComparisionOperator
		{
			get
			{
				return GetValue("DoesNotEndWithComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("DoesNotEndWithComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the contains comparision operator.
		/// </summary>
		/// 
		/// The contains comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The Contains comparison operator.")]
		public virtual ImageResourceReference ContainsComparisionOperator
		{
			get
			{
				return GetValue("ContainsComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("ContainsComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the does not contain comparision operator.
		/// </summary>
		/// 
		/// The does not contain comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The DoesNotContain comparison operator.")]
		public virtual ImageResourceReference DoesNotContainComparisionOperator
		{
			get
			{
				return GetValue("DoesNotContainComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("DoesNotContainComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the custom comparision operator.
		/// </summary>
		/// 
		/// The custom comparision operator.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The Custom comparison operator.")]
		public virtual ImageResourceReference CustomComparisionOperator
		{
			get
			{
				return GetValue("CustomComparisionOperator", (ImageResourceReference)"");
			}
			set
			{
				SetValue("CustomComparisionOperator", value);
			}
		}

		/// 
		/// Gets or sets the filter clear button image.
		/// </summary>
		/// 
		/// The filter clear button image.
		/// </value>
		[SRCategory("Images")]
		[SRDescription("The filter clear button image.")]
		public virtual ImageResourceReference FilterCellClearButtonImage
		{
			get
			{
				return GetValue("FilterCellClearButtonImage", (ImageResourceReference)"");
			}
			set
			{
				SetValue("FilterCellClearButtonImage", value);
			}
		}

		/// 
		/// Gets the width of the header filter combo box image.
		/// </summary>
		/// 
		/// The width of the header filter combo box image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual SkinValue HeaderFilterComboBoxImageWidth
		{
			get
			{
				if (!(SkinFactory.GetSkin(base.Owner, typeof(DataGridViewHeaderFilterComboBoxSkin)) is DataGridViewHeaderFilterComboBoxSkin { FilterNormalImageWidth: var filterNormalImageWidth }))
				{
					return null;
				}
				return filterNormalImageWidth;
			}
		}

		/// 
		/// Gets the sort ascending indicator image.
		/// </summary>
		[Category("Images")]
		[Description("The column sorted ascending indicator image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual ImageResourceReference SortAscendingIndicatorImage
		{
			get
			{
				return GetValue("SortAscendingIndicatorImage", new ImageResourceReference(typeof(DataGridViewSkin), "ArrowUp.gif"));
			}
			set
			{
				SetValue("SortAscendingIndicatorImage", value);
			}
		}

		/// 
		/// Gets the sort descending indicator image.
		/// </summary>
		[Category("Images")]
		[Description("The column sorted descending indicator image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual ImageResourceReference SortDescendingIndicatorImage
		{
			get
			{
				return GetValue("SortDescendingIndicatorImage", new ImageResourceReference(typeof(DataGridViewSkin), "ArrowDown.gif"));
			}
			set
			{
				SetValue("SortDescendingIndicatorImage", value);
			}
		}

		[Category("Images")]
		[Description("The row header edit mode Image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> RowHeaderEditModeImage => new BidirectionalSkinProperty<object>(this, "RowHeaderEditModeImageLTR", "RowHeaderEditModeImageRTL");

		/// 
		/// Gets or sets the drop down over image LTR.
		/// </summary>
		/// The drop down over image LTR.</value>
		[Description("The row header edit mode left to right over image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference RowHeaderEditModeImageLTR
		{
			get
			{
				return GetValue("RowHeaderEditModeImageLTR", new ImageResourceReference(typeof(DataGridViewSkin), "DGVEditedModeLTR.gif"));
			}
			set
			{
				SetValue("RowHeaderEditModeImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the drop down over image RTL.
		/// </summary>
		/// The drop down over image RTL.</value>
		[Description("The row header edit mode right to left over image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference RowHeaderEditModeImageRTL
		{
			get
			{
				return GetValue("RowHeaderEditModeImageRTL", new ImageResourceReference(typeof(DataGridViewSkin), "DGVEditedModeRTL.gif"));
			}
			set
			{
				SetValue("RowHeaderEditModeImageRTL", value);
			}
		}

		[Category("Images")]
		[Description("The row header Selected mode Image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public BidirectionalSkinProperty<object> RowHeaderSelectedModeImage => new BidirectionalSkinProperty<object>(this, "RowHeaderSelectedModeImageLTR", "RowHeaderSelectedModeImageRTL");

		/// 
		/// Gets or sets the drop down over image LTR.
		/// </summary>
		/// The drop down over image LTR.</value>
		[Description("The row header Selected mode left to right over image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference RowHeaderSelectedModeImageLTR
		{
			get
			{
				return GetValue("RowHeaderSelectedModeImageLTR", new ImageResourceReference(typeof(DataGridViewSkin), "DGVSelectedModeLTR.gif"));
			}
			set
			{
				SetValue("RowHeaderSelectedModeImageLTR", value);
			}
		}

		/// 
		/// Gets or sets the drop down over image RTL.
		/// </summary>
		/// The drop down over image RTL.</value>
		[Description("The row header Selected mode right to left over image")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ImageResourceReference RowHeaderSelectedModeImageRTL
		{
			get
			{
				return GetValue("RowHeaderSelectedModeImageRTL", new ImageResourceReference(typeof(DataGridViewSkin), "DGVSelectedModeRTL.gif"));
			}
			set
			{
				SetValue("RowHeaderSelectedModeImageRTL", value);
			}
		}

		/// 
		/// Gets or sets the row header new row mode image.
		/// </summary>
		/// 
		/// The row header new row mode image.
		/// </value>
		[Category("Images")]
		[Description("The row header new row mode Image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual ImageResourceReference RowHeaderNewRowModeImage
		{
			get
			{
				return GetValue("RowHeaderNewRowModeImage", new ImageResourceReference(typeof(DataGridViewSkin), "DGVNewRowMode.gif"));
			}
			set
			{
				SetValue("RowHeaderNewRowModeImage", value);
			}
		}

		/// 
		/// Gets or sets the row header error provider image.
		/// </summary>
		/// 
		/// The row header error provider image.
		/// </value>
		[Category("Images")]
		[Description("The row header error Image.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual ImageResourceReference RowHeaderErrorProviderImage
		{
			get
			{
				return GetValue("RowHeaderErrorProviderImage", new ImageResourceReference(typeof(DataGridViewSkin), "ErrorProvider.gif"));
			}
			set
			{
				SetValue("RowHeaderErrorProviderImage", value);
			}
		}

		/// 
		/// Gets the size of the sort ascending indicator image.
		/// </summary>
		/// 
		/// The size of the sort ascending indicator image.
		/// </value>
		internal Size SortAscendingIndicatorImageSize => GetImageSize(SortAscendingIndicatorImage, Size.Empty);

		/// 
		/// Gets the size of the sort descending indicator image.
		/// </summary>
		/// 
		/// The size of the sort descending indicator image.
		/// </value>
		internal Size SortDescendingIndicatorImageSize => GetImageSize(SortDescendingIndicatorImage, Size.Empty);

		/// 
		/// Gets or sets the width of the expand collapse column.
		/// </summary>
		/// 
		/// The width of the expand collapse column.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ExpandCollapseColumnWidth => Math.Max(Math.Max(ExpandButtonImageWidth + ExpandButtonImageStyle.Padding.Horizontal, CollapseButtonImageWidth + CollapseButtonImageStyle.Padding.Horizontal), EmptyExpandCollapseImageWidth + EmptyExpandCollapseImageStyle.Padding.Horizontal);

		/// 
		/// Gets the expand button image style.
		/// </summary>
		[Category("States")]
		[SRDescription("The expand button image style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue EmptyExpandCollapseImageStyle => new StyleValue(this, "EmptyExpandCollapseImageStyle");

		/// 
		/// Gets the width of the expand button image.
		/// </summary>
		/// 
		/// The width of the expand button image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal int EmptyExpandCollapseImageWidth => GetImageSize(EmptyExpandCollapseImageStyle.BackgroundImage, Size.Empty).Width;

		/// 
		/// Gets the expand button image style.
		/// </summary>
		[Category("States")]
		[SRDescription("The column chooser style")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ColumnChooserStyle => new StyleValue(this, "ColumnChooserStyle");

		/// 
		/// Gets the expand button image style.
		/// </summary>
		[Category("States")]
		[SRDescription("The expand button image style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ExpandButtonImageStyle => new StyleValue(this, "ExpandButtonImageStyle");

		/// 
		/// Gets the width of the expand button image.
		/// </summary>
		/// 
		/// The width of the expand button image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal int ExpandButtonImageWidth => GetImageSize(ExpandButtonImageStyle.BackgroundImage, Size.Empty).Width;

		/// 
		/// Gets the collapse button image style.
		/// </summary>
		[Category("States")]
		[SRDescription("The collapse button image style.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue CollapseButtonImageStyle => new StyleValue(this, "CollapseButtonImageStyle");

		/// 
		/// Gets the width of the collapse button image.
		/// </summary>
		/// 
		/// The width of the collapse button image.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal int CollapseButtonImageWidth => GetImageSize(CollapseButtonImageStyle.BackgroundImage, Size.Empty).Width;

		/// 
		/// Gets the row header style for the expanded grid.
		/// </summary>
		[Category("States")]
		[SRDescription("The row header for the expanded Data Grid View.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public StyleValue ExpandedRowHeaderStyle => new StyleValue(this, "ExpandedRowHeaderStyle");

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the grouping drop area empty message align.
		/// </summary>
		private void ResetGroupingDropAreaEmptyMessageAlign()
		{
			Reset("GroupingDropAreaEmptyMessageAlign");
		}

		/// 
		/// Resets the width of the grid lines.
		/// </summary>
		private void ResetGridLinesWidth()
		{
			Reset("GridLinesWidth");
		}

		/// 
		/// Resets the color of the grid lines.
		/// </summary>
		private void ResetGridLinesColor()
		{
			Reset("GridLinesColor");
		}

		/// 
		/// Resets the height of the paging panel.
		/// </summary>
		internal void ResetPagingPanelHeight()
		{
			Reset("PagingPanelHeight");
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

		/// 
		/// Gets the size of the image.
		/// </summary>
		/// <param name="strImageFileName">Name of the STR image file.</param>
		/// </returns>
		internal Size GetImageSize(string strImageFileName)
		{
			if (!string.IsNullOrEmpty(strImageFileName))
			{
				return GetImageSize(new ImageResourceReference(typeof(DataGridViewSkin), strImageFileName), Size.Empty);
			}
			return Size.Empty;
		}
	}
}

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
	/// Represents a row in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[TypeConverter("Gizmox.WebGUI.Forms.DataGridViewRowConverter, Gizmox.WebGUI.Forms")]
	public class DataGridViewRow : DataGridViewBand
	{
		private string mstrErrorText = null;

		private static Type objRowType;

		private DataGridViewCellCollection mobjCells = null;

		private HierarchicDataGridView mobjChildGrid = null;

		private HierarchicInfo mobjRelatedHierarchyInfo;

		private DataGridViewRowStyle mobjStyle = null;

		private RowExpansionType menmRowExpansionType;

		private bool mblnIsExpanded;

		/// 
		/// Gets or sets the type of the row expansion.
		/// </summary>
		/// 
		/// The type of the row expansion.
		/// </value>
		[DefaultValue(RowExpansionType.Inherit)]
		public RowExpansionType RowExpansionIndicatorVisibility
		{
			get
			{
				return menmRowExpansionType;
			}
			set
			{
				if (menmRowExpansionType != value)
				{
					menmRowExpansionType = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow" /> is expanded.
		/// </summary>
		/// 
		///   true</c> if expanded; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool Expanded
		{
			get
			{
				return mblnIsExpanded;
			}
			set
			{
				if (value)
				{
					Expand();
				}
				else
				{
					Collapse();
				}
			}
		}

		/// 
		/// Gets the child grid.
		/// </summary>
		/// 
		/// The child grid.
		/// </value>
		public HierarchicDataGridView ChildGrid
		{
			get
			{
				if (mobjChildGrid == null && ContainedInBindedHierarchicGrid && !IsNewRow)
				{
					mobjChildGrid = CreateAndBindChildDataGrid();
				}
				return mobjChildGrid;
			}
		}

		/// 
		/// Gets the related hierarchy info.
		/// </summary>
		internal HierarchicInfo RelatedHierarchyInfo => mobjRelatedHierarchyInfo;

		/// 
		/// Gets the member ID.
		/// </summary>
		/// The member ID.</value>
		protected override string MemberID => "R" + ((!IsFilterRow) ? (base.Index + (base.DataGridView.ShowFilterRow ? 1 : 0)) : 0);

		/// 
		/// Gets or sets the style.
		/// </summary>
		/// 
		/// The style.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DataGridViewRowStyle Style => mobjStyle;

		/// 
		/// This is a recursive function that loop through a control and all of its parents
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>
		/// 
		/// 	true</c> if this instance is events enabled; otherwise, false</c>.
		/// </value>        
		/// false if one of the controls is hidden or disabled.</returns>
		public override bool IsEventsEnabled
		{
			get
			{
				if (!Visible)
				{
					return false;
				}
				return base.IsEventsEnabled;
			}
		}

		/// Gets the collection of cells that populate the row.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> that contains all of the cells in the row.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public DataGridViewCellCollection Cells
		{
			get
			{
				if (mobjCells == null)
				{
					mobjCells = CreateCellsInstance();
				}
				return mobjCells;
			}
		}

		/// Gets the data-bound object that populated the row.</summary>
		/// The data-bound <see cref="T:System.Object"></see>.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public object DataBoundItem
		{
			get
			{
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView != null && dataGridView.DataConnection != null && base.Index > -1 && base.Index != dataGridView.NewRowIndex)
				{
					return dataGridView.DataConnection.CurrencyManager[base.Index];
				}
				return null;
			}
		}

		/// Gets or sets the default styles for the row, which are used to render cells in the row unless the styles are overridden. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		/// 1</filterpriority>
		[Browsable(true)]
		[SRDescription("DataGridView_RowDefaultCellStyleDescr")]
		[NotifyParentProperty(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatAppearance")]
		public override DataGridViewCellStyle DefaultCellStyle
		{
			get
			{
				return base.DefaultCellStyle;
			}
			set
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", "DefaultCellStyle"));
				}
				base.DefaultCellStyle = value;
			}
		}

		/// Gets a value indicating whether this row is displayed on the screen.</summary>
		/// true if the row is currently displayed on the screen; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		[Browsable(false)]
		public override bool Displayed
		{
			get
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "Displayed"));
				}
				return GetDisplayed(base.Index);
			}
		}

		/// Gets or sets the height, in pixels, of the row divider.</summary>
		/// The height, in pixels, of the divider (the row's bottom margin). </returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		[NotifyParentProperty(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_RowDividerHeightDescr")]
		[DefaultValue(0)]
		public int DividerHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// Gets or sets the error message text for row-level errors.</summary>
		/// A <see cref="T:System.String"></see> containing the error message.</returns>
		/// <exception cref="T:System.InvalidOperationException">When getting the value of this property, the row is a shared row in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		/// 1</filterpriority>
		[NotifyParentProperty(true)]
		[SRCategory("CatAppearance")]
		[DefaultValue("")]
		[SRDescription("DataGridView_RowErrorTextDescr")]
		public string ErrorText
		{
			get
			{
				return GetErrorText(base.Index);
			}
			set
			{
				ErrorTextInternal = value;
			}
		}

		/// 
		/// Gets or sets the error text internal.
		/// </summary>
		/// The error text internal.</value>
		private string ErrorTextInternal
		{
			get
			{
				if (mstrErrorText != null)
				{
					return mstrErrorText;
				}
				return string.Empty;
			}
			set
			{
				string errorTextInternal = ErrorTextInternal;
				string text = mstrErrorText;
				DataGridView dataGridView = base.DataGridView;
				if ((!CommonUtils.IsNullOrEmpty(value) || text != null) && text != value)
				{
					mstrErrorText = value;
					if (dataGridView != null)
					{
						dataGridView.FocusInternal();
						dataGridView.Update();
					}
				}
				if (dataGridView != null && !errorTextInternal.Equals(ErrorTextInternal))
				{
					dataGridView.OnRowErrorTextChanged(this);
				}
			}
		}

		/// Gets or sets a value indicating whether the row is frozen. </summary>
		/// true if the row is frozen; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		public override bool Frozen
		{
			get
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "Frozen"));
				}
				return GetFrozen(base.Index);
			}
			set
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", "Frozen"));
				}
				base.Frozen = value;
			}
		}

		/// 
		/// Gets the location.
		/// </summary>
		/// The location.</value>
		protected internal override Point Location
		{
			get
			{
				Point empty = Point.Empty;
				if (base.DataGridView != null)
				{
					empty.X += base.DataGridView.Padding.Left + base.DataGridView.Margin.Left;
					empty.Y += base.DataGridView.Padding.Top + base.DataGridView.Margin.Top;
					if (base.DataGridView.ColumnHeadersVisible)
					{
						empty.Y += base.DataGridView.ColumnHeadersHeight;
					}
					if (base.DataGridView.RowHeadersVisible)
					{
						empty.X += base.DataGridView.RowHeadersWidth;
					}
					IList pageRows = base.DataGridView.PageRows;
					if (pageRows.Count > 0)
					{
						foreach (DataGridViewRow item in pageRows)
						{
							if (item == this)
							{
								break;
							}
							if (item.Visible)
							{
								empty.Y += item.Height;
							}
						}
					}
					empty.Y -= base.DataGridView.ScrollPoisition.Y;
				}
				return empty;
			}
		}

		/// 
		/// Gets a value indicating whether this instance has error text.
		/// </summary>
		/// 
		/// 	true</c> if this instance has error text; otherwise, false</c>.
		/// </value>
		internal bool HasErrorText
		{
			get
			{
				string text = mstrErrorText;
				if (text != null && text != string.Empty)
				{
					return true;
				}
				return false;
			}
		}

		/// Gets or sets the row's header cell.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> that represents the header cell of row.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataGridViewRowHeaderCell HeaderCell
		{
			get
			{
				return (DataGridViewRowHeaderCell)base.HeaderCellCore;
			}
			set
			{
				base.HeaderCellCore = value;
			}
		}

		/// Gets or sets the current height of the row.</summary>
		/// The height, in pixels, of the row. The default is the height of the default font plus 9 pixels.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[NotifyParentProperty(true)]
		[SRDescription("DataGridView_RowHeightDescr")]
		[DefaultValue(22)]
		public int Height
		{
			get
			{
				return base.Thickness;
			}
			set
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", "Height"));
				}
				base.Thickness = value;
			}
		}

		/// Gets the cell style in effect for the row.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that specifies the formatting and style information for the cells in the row.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		public override DataGridViewCellStyle InheritedStyle
		{
			get
			{
				if (base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "InheritedStyle"));
				}
				DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
				BuildInheritedRowStyle(base.Index, dataGridViewCellStyle);
				return dataGridViewCellStyle;
			}
		}

		/// Gets a value indicating whether the row is the row for new records.</summary>
		/// true if the row is the last row in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, 
		/// which is used for the entry of a new row of data; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsNewRow
		{
			get
			{
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView != null)
				{
					return dataGridView.NewRowIndex == base.Index;
				}
				return false;
			}
		}

		/// 
		/// Gets a value indicating whether this instance is filter row.
		/// </summary>
		/// 
		/// 	true</c> if this instance is filter row; otherwise, false</c>.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool IsFilterRow => false;

		/// Gets or sets the minimum height of the row.</summary>
		/// The minimum row height in pixels, ranging from 2 to <see cref="F:System.Int32.MaxValue"></see>. The default is 3.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 2.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int MinimumHeight
		{
			get
			{
				return base.MinimumThickness;
			}
			set
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", "MinimumHeight"));
				}
				base.MinimumThickness = value;
			}
		}

		/// Gets or sets a value indicating whether the row is read-only.</summary>
		/// true if the row is read-only; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		/// 1</filterpriority>
		[NotifyParentProperty(true)]
		[SRDescription("DataGridView_RowReadOnlyDescr")]
		[DefaultValue(false)]
		[Browsable(true)]
		[SRCategory("CatBehavior")]
		public override bool ReadOnly
		{
			get
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "ReadOnly"));
				}
				return GetReadOnly(base.Index);
			}
			set
			{
				if (value != ReadOnly && base.DataGridView != null)
				{
					base.DataGridView.Update();
				}
				base.ReadOnly = value;
			}
		}

		/// Gets or sets a value indicating whether users can resize the row or indicating that the behavior is inherited from the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value that indicates whether the row can be resized or whether it can be resized only when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property is set to true.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		[SRDescription("DataGridView_RowResizableDescr")]
		[SRCategory("CatBehavior")]
		[NotifyParentProperty(true)]
		[DefaultValue(DataGridViewTriState.NotSet)]
		public override DataGridViewTriState Resizable
		{
			get
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "Resizable"));
				}
				return GetResizable(base.Index);
			}
			set
			{
				base.Resizable = value;
			}
		}

		/// Gets or sets a value indicating whether the row is selected. </summary>
		/// true if the row is selected; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		public override bool Selected
		{
			get
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "Selected"));
				}
				return GetSelected(base.Index);
			}
			set
			{
				base.Selected = value;
			}
		}

		/// Gets the current state of the row.</summary>
		/// A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the row state.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		public override DataGridViewElementStates State
		{
			get
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "State"));
				}
				return GetState(base.Index);
			}
		}

		/// Gets or sets a value indicating whether the row is visible. </summary>
		/// true if the row is visible; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		public override bool Visible
		{
			get
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", "Visible"));
				}
				return GetVisible(base.Index);
			}
			set
			{
				if (base.DataGridView != null && base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", "Visible"));
				}
				base.Visible = value;
			}
		}

		/// Gets or sets the shortcut menu for the row.</summary>
		/// The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the current <see cref="T:System.Windows.Forms.DataGridViewRow"></see>. The default is null.</returns>
		/// <exception cref="T:System.InvalidOperationException">When getting the value of this property, the row is in a <see cref="T:System.Windows.Forms.DataGridView"></see> control and is a shared row.</exception>
		[SRDescription("DataGridView_RowContextMenuStripDescr")]
		[DefaultValue(null)]
		[SRCategory("CatBehavior")]
		public override ContextMenu ContextMenu
		{
			get
			{
				return base.ContextMenu;
			}
			set
			{
				base.ContextMenu = value;
			}
		}

		/// 
		/// Gets a value indicating whether [contained in hierarchic grid].
		/// </summary>
		/// 
		/// 	true</c> if [contained in hierarchic grid]; otherwise, false</c>.
		/// </value>
		public bool ContainedInBindedHierarchicGrid => base.DataGridView != null && base.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded);

		/// 
		/// Gets a value indicating whether this instance is hierarchic.
		/// </summary>
		/// 
		/// 	true</c> if this instance is hierarchic; otherwise, false</c>.
		/// </value>
		public bool IsHierarchic => base.DataGridView != null && base.DataGridView.IsHierarchic(HierarchicInfoSelector.Any);

		static DataGridViewRow()
		{
			objRowType = typeof(DataGridViewRow);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> class without using a template.</summary>
		public DataGridViewRow()
		{
			base.BandIsRow = true;
			base.MinimumThickness = 3;
			base.Thickness = GetDefaultRowHeight();
			mobjStyle = new DataGridViewRowStyle(this);
			base.TagName = "DR";
		}

		/// 
		/// Called when [shared state changed].
		/// </summary>
		/// <param name="intSharedRowIndex">Index of the shared row.</param>
		/// <param name="enmElementState">State of the element.</param>
		internal void OnSharedStateChanged(int intSharedRowIndex, DataGridViewElementStates enmElementState)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				DataGridViewRowCollection rows = dataGridView.Rows;
				dataGridView.Rows.InvalidateCachedRowCount(enmElementState);
				dataGridView.Rows.InvalidateCachedRowsHeight(enmElementState);
				dataGridView.OnDataGridViewElementStateChanged(this, intSharedRowIndex, enmElementState);
			}
		}

		/// 
		/// Called when [shared state changing].
		/// </summary>
		/// <param name="intSharedRowIndex">Index of the shared row.</param>
		/// <param name="enmElementState">State of the element.</param>
		internal void OnSharedStateChanging(int intSharedRowIndex, DataGridViewElementStates enmElementState)
		{
			base.DataGridView.OnDataGridViewElementStateChanging(this, intSharedRowIndex, enmElementState);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "Resize":
			{
				int num = int.Parse(objEvent["VLB"]);
				if (num > 5)
				{
					base.ThicknessInternal = num;
				}
				break;
			}
			case "Click":
				if (base.DataGridView != null)
				{
					int eventValue3 = GetEventValue(objEvent, "X", 0);
					int eventValue4 = GetEventValue(objEvent, "Y", 0);
					MouseEventArgs e2 = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue3, eventValue4, 0);
					DataGridViewCellMouseEventArgs e3 = new DataGridViewCellMouseEventArgs(-1, base.Index, eventValue3, eventValue4, e2);
					base.DataGridView.OnRowHeaderMouseClickInternal(e3);
				}
				break;
			case "DoubleClick":
				if (base.DataGridView != null)
				{
					int eventValue = GetEventValue(objEvent, "X", 0);
					int eventValue2 = GetEventValue(objEvent, "Y", 0);
					DataGridViewCellMouseEventArgs e = new DataGridViewCellMouseEventArgs(-1, base.Index, eventValue, eventValue2, new MouseEventArgs(MouseButtons.Left, 1, eventValue, eventValue2, 0));
					base.DataGridView.OnRowHeaderMouseDoubleClickInternal(e);
				}
				break;
			case "Expand":
				ExpandInternal(blnIsClientSource: true);
				break;
			case "Collapse":
				Collapse();
				break;
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (base.DataGridView != null && base.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEIGHTCHANGED))
			{
				criticalEventsData.Set("SC");
			}
			return criticalEventsData;
		}

		/// 
		/// Checks if the current control needs rendering and
		/// continues to process sub tree/
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected override void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
		}

		/// 
		/// Renders the updated attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderSelectedAttribute(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderNumberOfChildRows(objWriter, blnForceRender: true);
				RenderRowExpansionType(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout) && Visible)
			{
				objWriter.WriteAttributeString("H", Height.ToString());
			}
		}

		/// 
		/// Renders the band attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			if (base.DataGridView == null || !Visible)
			{
				return;
			}
			if (IsNewRow)
			{
				objWriter.WriteAttributeString("IN", "1");
			}
			if (DataGridViewElement.ShouldRender(RenderMask, Renderable.SelectedAttribute))
			{
				RenderSelectedAttribute(objWriter, blnForceRender: false);
			}
			objWriter.WriteAttributeString("H", Height.ToString());
			if (Resizable == DataGridViewTriState.False)
			{
				objWriter.WriteAttributeString("RE", "0");
			}
			if (DataGridViewElement.ShouldRender(RenderMask, Renderable.ErrorTextAttribute))
			{
				string errorText = ErrorText;
				if (!string.IsNullOrEmpty(errorText))
				{
					objWriter.WriteAttributeText("EM", errorText);
				}
			}
			if (base.DataGridView != null && base.DataGridView.IsHierarchic(HierarchicInfoSelector.Any) && !IsNewRow)
			{
				if (Expanded)
				{
					objWriter.WriteAttributeString("IEX", "1");
				}
				if (base.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded) && mobjChildGrid != null)
				{
					objWriter.WriteAttributeString("CGH", ChildGrid.Height.ToString());
				}
				if (base.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded))
				{
					RenderNumberOfChildRows(objWriter, blnForceRender: false);
				}
				RenderRowExpansionType(objWriter, blnForceRender: false);
			}
			DataGridViewRowStyle style = Style;
			if (style != null && style.BorderWidth != 0 && style.BorderColor != Color.Empty && style.BorderStyle != BorderStyle.None)
			{
				objWriter.WriteAttributeString("BS", BorderValue.GetBorderName(style.BorderStyle));
				objWriter.WriteAttributeString("BC", BorderValue.GetBorderColor(style.BorderColor).ToString());
				objWriter.WriteAttributeString("BRW", style.BorderWidth.ToString());
			}
		}

		/// 
		/// Renders the type of the row expansion.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderRowExpansionType(IAttributeWriter objWriter, bool blnForceRender)
		{
			RowExpansionType rowExpansionIndicatorVisibility = RowExpansionIndicatorVisibility;
			if (rowExpansionIndicatorVisibility != RowExpansionType.Inherit || blnForceRender)
			{
				int num = (int)rowExpansionIndicatorVisibility;
				objWriter.WriteAttributeString("EIN", num.ToString());
			}
		}

		/// 
		/// Renders the number of child rows.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderNumberOfChildRows(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (ContainedInBindedHierarchicGrid && mobjChildGrid != null)
			{
				int intValue = (mobjChildGrid.AllowUserToAddRows ? (mobjChildGrid.Rows.Count - 1) : mobjChildGrid.Rows.Count);
				objWriter.WriteAttributeString("NOC", intValue);
			}
		}

		/// 
		/// Renders the selected attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSelectedAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (Selected && (base.DataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect || base.DataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect))
			{
				objWriter.WriteAttributeString("SE", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SE", "0");
			}
		}

		/// 
		/// Pres the render component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		private void PreRenderHeaderCell(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
			HeaderCell?.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
		}

		/// 
		/// Posts the render header cell.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePostRender">if set to true</c> [BLN force post render].</param>
		private void PostRenderHeaderCell(IContext objContext, long lngRequestID, bool blnForcePostRender)
		{
			HeaderCell?.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
		}

		/// 
		/// Pres the render component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		internal override void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
			base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
			PreRenderHeaderCell(objContext, lngRequestID, blnForcePreRender);
			if (base.DataGridView != null)
			{
				DataGridViewColumn dataGridViewColumn = base.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
				while (dataGridViewColumn != null && dataGridViewColumn.Index >= 0 && dataGridViewColumn.Index < Cells.Count)
				{
					Cells[dataGridViewColumn.Index].PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
					dataGridViewColumn = base.DataGridView.Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
				}
			}
			if (Expanded && ContainedInBindedHierarchicGrid)
			{
				ChildGrid.PreRenderControlInternal(objContext, lngRequestID);
			}
		}

		/// 
		/// Posts the render component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePostRender">if set to true</c> [BLN force post render].</param>
		internal override void PostRenderComponent(IContext objContext, long lngRequestID, bool blnForcePostRender)
		{
			base.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
			PostRenderHeaderCell(objContext, lngRequestID, blnForcePostRender);
			if (base.DataGridView != null)
			{
				DataGridViewColumn dataGridViewColumn = base.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
				while (dataGridViewColumn != null && dataGridViewColumn.Index >= 0 && dataGridViewColumn.Index < Cells.Count)
				{
					Cells[dataGridViewColumn.Index].PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
					dataGridViewColumn = base.DataGridView.Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
				}
			}
			if (Expanded && ContainedInBindedHierarchicGrid)
			{
				ChildGrid.PostRenderControlInternal(objContext, lngRequestID);
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
			if (HeaderCell != null)
			{
				((IRenderableComponentMember)HeaderCell).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
			if (base.DataGridView != null)
			{
				DataGridViewColumn dataGridViewColumn = base.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
				while (dataGridViewColumn != null && dataGridViewColumn.Index >= 0 && dataGridViewColumn.Index < Cells.Count)
				{
					((IRenderableComponentMember)Cells[dataGridViewColumn.Index]).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
					dataGridViewColumn = base.DataGridView.Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
				}
				if (Expanded && ContainedInBindedHierarchicGrid)
				{
					ChildGrid.RenderControl(objContext, objWriter, lngRequestID);
				}
			}
		}

		/// 
		/// Gets the default height of the row.
		/// </summary>
		/// </returns>
		public static int GetDefaultRowHeight()
		{
			int num = 0;
			num = CommonUtils.GetFontHeight(Control.DefaultFont);
			return num + 9;
		}

		/// 
		/// Resets the child grid.
		/// </summary>
		internal void ResetChildGrid()
		{
			if (mobjChildGrid != null)
			{
				Collapse();
				mobjChildGrid = null;
			}
		}

		/// 
		/// Expands this instance.
		/// </summary>
		public void Expand()
		{
			ExpandInternal(blnIsClientSource: false);
		}

		/// 
		/// Expands this instance.
		/// </summary>
		/// <param name="blnIsClientSource">True - if the user expanded the row from the row's expantion button, False - if row was expanded from an external invokation (like a Button.Click event)</param>
		private void ExpandInternal(bool blnIsClientSource)
		{
			if (IsFilterRow || IsNewRow)
			{
				return;
			}
			if (ContainedInBindedHierarchicGrid)
			{
				if (mobjChildGrid == null)
				{
					mobjChildGrid = CreateAndBindChildDataGrid();
				}
				mblnIsExpanded = true;
				if (blnIsClientSource)
				{
					switch (base.DataGridView.RootGrid.ExpansionIndicator)
					{
					case ShowExpansionIndicator.Never:
						Collapse();
						break;
					case ShowExpansionIndicator.CheckOnDisplay:
					case ShowExpansionIndicator.CheckOnExpand:
					case ShowExpansionIndicator.Empty:
						if (!mobjChildGrid.HasRows())
						{
							Collapse();
							UpdateParams(AttributeType.Control);
						}
						break;
					default:
						throw new NotImplementedException("The expanstion indicator of type: " + base.DataGridView.RootGrid.ExpansionIndicator.ToString() + " is not supported");
					case ShowExpansionIndicator.Always:
						break;
					}
				}
			}
			else if (IsHierarchic)
			{
				mblnIsExpanded = true;
			}
			if (mblnIsExpanded)
			{
				RowExpandingEventArgs e = new RowExpandingEventArgs(this);
				base.DataGridView.OnRowExpanding(e);
				if (!e.Cancel)
				{
					base.DataGridView.OnRowExpanded(new RowExpandedEventArgs(this));
					Update();
				}
				else
				{
					mblnIsExpanded = false;
				}
			}
		}

		/// 
		/// Ensures the columns visibility.
		/// </summary>
		internal void EnsureColumnsVisibility(DataGridView objDataGridView, HierarchicInfo objInfo)
		{
			if (objDataGridView == null || objInfo == null)
			{
				return;
			}
			DataGridView rootGrid = objDataGridView.RootGrid;
			List<object> list = new List<object>();
			foreach (DataGridViewColumn column in objDataGridView.Columns)
			{
				string dataPropertyName = column.DataPropertyName;
				bool flag = objInfo.HiddenColumns.IndexOf(dataPropertyName) == -1;
				if (flag && rootGrid.HideGroupedColumns)
				{
					flag = rootGrid.GroupingColumns.IndexOf(dataPropertyName) == -1;
				}
				if (column.Visible != flag)
				{
					column.Visible = flag;
					list.Add(column);
				}
			}
			objDataGridView.OnColumnChooserColumnsVisibilityChanged(list);
		}

		/// 
		/// Collapses this instance.
		/// </summary>
		public void Collapse()
		{
			if (mblnIsExpanded)
			{
				RowCollapsingEventArgs e = new RowCollapsingEventArgs(this);
				base.DataGridView.OnRowCollapsing(e);
				if (!e.Cancel)
				{
					mblnIsExpanded = false;
					base.DataGridView.OnRowCollapsed(this);
				}
				Update();
			}
		}

		/// 
		/// Gets the grouping columns without root.
		/// </summary>
		/// <param name="objDataGridViewColumns">The obj data grid view columns.</param>
		/// </returns>
		private UniqueObservableCollection<object> GetGroupingColumnsWithoutRoot(UniqueObservableCollection<object> objDataGridViewColumns)
		{
			UniqueObservableCollection<object> uniqueObservableCollection = new UniqueObservableCollection<object>();
			for (int i = 1; i < objDataGridViewColumns.Count; i++)
			{
				uniqueObservableCollection.Add(objDataGridViewColumns[i]);
			}
			return uniqueObservableCollection;
		}

		/// 
		/// Binds the child data grid.
		/// </summary>
		private HierarchicDataGridView CreateAndBindChildDataGrid()
		{
			HierarchicDataGridView hierarchicDataGridView = CreateGridView();
			DataGridView dataGridView = base.DataGridView;
			hierarchicDataGridView.VisualTemplate = dataGridView.VisualTemplate;
			hierarchicDataGridView.HierarchyLevel = dataGridView.HierarchyLevel + 1;
			hierarchicDataGridView.ContainingRow = this;
			dataGridView.RootGrid.NotifyHierarchicGridCreated(hierarchicDataGridView);
			hierarchicDataGridView.RootGrid = dataGridView.RootGrid;
			hierarchicDataGridView.GroupingColumns = GetGroupingColumnsWithoutRoot(dataGridView.GroupingColumns);
			hierarchicDataGridView.SystemHierarchicInfos = HierarchicInfo.GetClonedInfos(dataGridView.SystemHierarchicInfos, blnIncludeRoot: false);
			dataGridView.SuspendLayout();
			ObservableCollection<object> hierarchicInfos = dataGridView.HierarchicInfos;
			dataGridView.ResumeLayout();
			if (dataGridView.RootGrid.SystemHierarchicInfos.Count > dataGridView.HierarchyLevel)
			{
				hierarchicDataGridView.HierarchicInfos = HierarchicInfo.GetClonedInfos(hierarchicInfos, blnIncludeRoot: true);
			}
			else
			{
				hierarchicDataGridView.HierarchicInfos = HierarchicInfo.GetClonedInfos(hierarchicInfos, blnIncludeRoot: false);
			}
			ObservableCollection<object> relevantHierarchicInfos = base.DataGridView.GetRelevantHierarchicInfos();
			hierarchicDataGridView.BindingContext = dataGridView.BindingContext;
			hierarchicDataGridView.DataSource = dataGridView.GetClonedBindingSourceWithFilterForNextLevel(this);
			if (relevantHierarchicInfos.Count > 0)
			{
				mobjRelatedHierarchyInfo = relevantHierarchicInfos[0];
				EnsureColumnsVisibility(hierarchicDataGridView, mobjRelatedHierarchyInfo);
				if (hierarchicDataGridView.SystemHierarchicInfos.Count == 0)
				{
					mobjRelatedHierarchyInfo.HiddenColumns.CollectionChanged += HiddenColumns_CollectionChanged;
				}
			}
			return hierarchicDataGridView;
		}

		/// 
		/// Handles the CollectionChanged event of the HiddenColumns control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
		private void HiddenColumns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			EnsureColumnsVisibility(mobjChildGrid, mobjRelatedHierarchyInfo);
		}

		/// 
		/// Creates the grid view.
		/// </summary>
		/// </returns>
		private HierarchicDataGridView CreateGridView()
		{
			HierarchicDataGridView hierarchicDataGridView = null;
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				Type childGridType = dataGridView.GetChildGridType(this);
				if (childGridType != null)
				{
					hierarchicDataGridView = Activator.CreateInstance(childGridType) as HierarchicDataGridView;
				}
				if (hierarchicDataGridView != null)
				{
					hierarchicDataGridView.BorderStyle = BorderStyle.FixedSingle;
					hierarchicDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
					hierarchicDataGridView.Dock = DockStyle.Fill;
					hierarchicDataGridView.CustomStyle = dataGridView.CustomStyle;
					hierarchicDataGridView.UseInternalPaging = dataGridView.UseInternalPaging;
					hierarchicDataGridView.SupportGroupCount = dataGridView.SupportGroupCount;
					hierarchicDataGridView.ExpansionIndicator = dataGridView.ExpansionIndicator;
				}
			}
			return hierarchicDataGridView;
		}

		/// 
		/// Sets the read only cell core.
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="blnReadOnly">if set to true</c> [read only].</param>
		internal void SetReadOnlyCellCore(DataGridViewCell objDataGridViewCell, bool blnReadOnly)
		{
			if (ReadOnly && !blnReadOnly)
			{
				foreach (DataGridViewCell cell in Cells)
				{
					cell.ReadOnlyInternal = true;
				}
				objDataGridViewCell.ReadOnlyInternal = false;
				ReadOnly = false;
			}
			else if (!ReadOnly && blnReadOnly)
			{
				objDataGridViewCell.ReadOnlyInternal = true;
			}
		}

		/// Sets the values of the row's cells.</summary>
		/// true if all values have been set; otherwise, false.</returns>
		/// <param name="arrValues">One or more objects that represent the cell values in the row.-or-An <see cref="T:System.Array"></see> of <see cref="T:System.Object"></see> values. </param>
		/// <exception cref="T:System.ArgumentNullException">values is null. </exception>
		/// <exception cref="T:System.InvalidOperationException">This method is called when the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is operating in virtual mode. -or-This row is a shared row.</exception>
		/// 1</filterpriority>
		public bool SetValues(params object[] arrValues)
		{
			if (arrValues == null)
			{
				throw new ArgumentNullException("values");
			}
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				if (dataGridView.VirtualMode)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
				}
				if (base.Index == -1)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
				}
			}
			return SetValuesInternal(arrValues);
		}

		/// 
		/// Sets the values internal.
		/// </summary>
		/// <param name="arrValues">The values.</param>
		/// </returns>
		internal bool SetValuesInternal(params object[] arrValues)
		{
			bool flag = true;
			DataGridViewCellCollection cells = Cells;
			int count = cells.Count;
			for (int i = 0; i < cells.Count && i != arrValues.Length; i++)
			{
				if (!cells[i].SetValueInternal(base.Index, arrValues[i]))
				{
					flag = false;
				}
			}
			if (flag)
			{
				return arrValues.Length <= count;
			}
			return false;
		}

		/// Gets a human-readable string that describes the row.</summary>
		/// A <see cref="T:System.String"></see> that describes this row.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(36);
			stringBuilder.Append("DataGridViewRow { Index=");
			stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			if (base.DataGridView != null)
			{
				base.DataGridView.Update(blnRedrawOnly: true);
			}
		}

		/// 
		/// Updates only the parameters of this instance.
		/// </summary>
		protected override void UpdateParams()
		{
			base.UpdateParams();
			if (base.DataGridView != null)
			{
				base.DataGridView.Update(blnRedrawOnly: true);
			}
		}

		/// 
		/// Updates the params.
		/// </summary>
		/// <param name="enmParams">The enm params.</param>
		protected internal override void UpdateParams(AttributeType enmParams)
		{
			base.UpdateParams(enmParams);
			if (base.DataGridView != null)
			{
				base.DataGridView.Update(blnRedrawOnly: true);
			}
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="blnRedrawOnly">if set to true</c> [BLN redraw only].</param>
		public override void Update(bool blnRedrawOnly)
		{
			base.Update(blnRedrawOnly);
			if (base.DataGridView != null)
			{
				base.DataGridView.Update(blnRedrawOnly: true);
			}
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="enmParams">The enm params.</param>
		internal override void Update(AttributeType enmParams)
		{
			base.Update(enmParams);
			if (base.DataGridView != null)
			{
				base.DataGridView.Update(blnRedrawOnly: true);
			}
		}

		/// Modifies an input row header border style according to the specified criteria.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the new border style used.</returns>
		/// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the row header border style.</param>
		/// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the row header border style to modify. </param>
		/// <param name="blnSingleVerticalBorderAdded">true to add a single vertical border to the result; otherwise, false. </param>
		/// <param name="blnIsLastVisibleRow">true if the row is the last row in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that has its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Visible"></see> property set to true; otherwise, false. </param>
		/// <param name="blnSingleHorizontalBorderAdded">true to add a single horizontal border to the result; otherwise, false. </param>
		/// <param name="blnIsFirstDisplayedRow">true if the row is the first row displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>; otherwise, false. </param>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual DataGridViewAdvancedBorderStyle AdjustRowHeaderBorderStyle(DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedRow, bool blnIsLastVisibleRow)
		{
			return null;
		}

		/// 
		/// Builds the inherited row header cell style.
		/// </summary>
		/// <param name="objInheritedCellStyle">The inherited cell style.</param>
		private void BuildInheritedRowHeaderCellStyle(DataGridViewCellStyle objInheritedCellStyle)
		{
		}

		/// 
		/// Builds the inherited row style.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objInheritedRowStyle">The inherited row style.</param>
		private void BuildInheritedRowStyle(int intRowIndex, DataGridViewCellStyle ObjInheritedRowStyle)
		{
		}

		/// Creates an exact copy of this row.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</returns>
		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewRow dataGridViewRow = ((!(type == objRowType)) ? ((DataGridViewRow)Activator.CreateInstance(type)) : new DataGridViewRow());
			if (dataGridViewRow != null)
			{
				CloneInternal(dataGridViewRow);
				if (HasErrorText)
				{
					dataGridViewRow.ErrorText = ErrorTextInternal;
				}
				if (base.HasHeaderCell)
				{
					dataGridViewRow.HeaderCell = (DataGridViewRowHeaderCell)HeaderCell.Clone();
				}
				dataGridViewRow.CloneCells(this);
			}
			return dataGridViewRow;
		}

		/// 
		/// Clones the cells.
		/// </summary>
		/// <param name="objRowTemplate">The row template.</param>
		private void CloneCells(DataGridViewRow objRowTemplate)
		{
			int count = objRowTemplate.Cells.Count;
			if (count > 0)
			{
				DataGridViewCell[] array = new DataGridViewCell[count];
				for (int i = 0; i < count; i++)
				{
					DataGridViewCell dataGridViewCell = objRowTemplate.Cells[i];
					DataGridViewCell dataGridViewCell2 = (DataGridViewCell)dataGridViewCell.Clone();
					array[i] = dataGridViewCell2;
				}
				Cells.AddRange(array);
			}
		}

		/// Clears the existing cells and sets their template according to the supplied <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> template.</summary>
		/// <param name="objDataGridView">A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that acts as a template for cell styles. </param>
		/// <exception cref="T:System.InvalidOperationException">A row that already belongs to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was added. -or-A column that has no cell template was added.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridView is null. </exception>
		/// 1</filterpriority>
		public void CreateCells(DataGridView objDataGridView)
		{
		}

		/// Clears the existing cells and sets their template and values.</summary>
		/// <param name="objDataGridView">A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that acts as a template for cell styles. </param>
		/// <param name="arrValues">An array of objects that initialize the reset cells. </param>
		/// <exception cref="T:System.ArgumentNullException">Either of the parameters is null. </exception>
		/// <exception cref="T:System.InvalidOperationException">A row that already belongs to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was added. -or-A column that has no cell template was added.</exception>
		/// 1</filterpriority>
		public void CreateCells(DataGridView objDataGridView, params object[] arrValues)
		{
		}

		/// Constructs a new collection of cells based on this row.</summary>
		/// The newly created <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual DataGridViewCellCollection CreateCellsInstance()
		{
			return new DataGridViewCellCollection(this);
		}

		/// 
		/// Detaches from data grid view.
		/// </summary>
		internal void DetachFromDataGridView()
		{
			if (base.DataGridView == null)
			{
				return;
			}
			base.DataGridViewInternal = null;
			base.IndexInternal = -1;
			if (base.HasHeaderCell)
			{
				HeaderCell.DataGridViewInternal = null;
			}
			foreach (DataGridViewCell cell in Cells)
			{
				cell.DataGridViewInternal = null;
				if (cell.Selected)
				{
					cell.SelectedInternal = false;
				}
			}
			if (Selected)
			{
				base.SelectedInternal = false;
			}
		}

		/// Draws a focus rectangle around the specified bounds.</summary>
		/// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> used to paint the focus rectangle.</param>
		/// <param name="enmRowState">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that specifies the state of the row.</param>
		/// <param name="objBounds">A <see cref="T:System.Drawing.Rectangle"></see> that contains the bounds of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that is being painted.</param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to paint the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
		/// <param name="intRowIndex">The row index of the cell that is being painted.</param>
		/// <param name="objClipBounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the area of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that needs to be painted.</param>
		/// <param name="blnCellsPaintSelectionBackground">true to use the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.SelectionBackColor"></see> property of cellStyle as the color of the focus rectangle; false to use the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.BackColor"></see> property of cellStyle as the color of the focus rectangle.</param>
		/// <exception cref="T:System.InvalidOperationException">The row has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		/// <exception cref="T:System.ArgumentNullException">graphics is null.-or-cellStyle is null.</exception>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected internal virtual void DrawFocus(Graphics objGraphics, Rectangle objClipBounds, Rectangle objBounds, int intRowIndex, DataGridViewElementStates enmRowState, DataGridViewCellStyle objCellStyle, bool blnCellsPaintSelectionBackground)
		{
		}

		/// 
		/// Gets the displayed.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool GetDisplayed(int intRowIndex)
		{
			return (GetState(intRowIndex) & DataGridViewElementStates.Displayed) != 0;
		}

		/// Gets the error text for the row at the specified index.</summary>
		/// A string that describes the error of the row at the specified index.</returns>
		/// <param name="intRowIndex">The index of the row that contains the error.</param>
		/// <exception cref="T:System.InvalidOperationException">The row belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The row belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is less than zero or greater than the number of rows in the control minus one. </exception>
		public string GetErrorText(int intRowIndex)
		{
			string text = ErrorTextInternal;
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null)
			{
				return text;
			}
			if (intRowIndex == -1)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
			}
			if (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (CommonUtils.IsNullOrEmpty(text) && dataGridView.DataSource != null && intRowIndex != dataGridView.NewRowIndex)
			{
				text = dataGridView.DataConnection.GetError(intRowIndex);
			}
			if (dataGridView.DataSource == null && !dataGridView.VirtualMode)
			{
				return text;
			}
			return dataGridView.OnRowErrorTextNeeded(intRowIndex, text);
		}

		/// 
		/// Gets the frozen.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool GetFrozen(int intRowIndex)
		{
			return (GetState(intRowIndex) & DataGridViewElementStates.Frozen) != 0;
		}

		/// 
		/// Gets the event integer attribute value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="strAttribute">The attribute name.</param>
		/// <param name="intDefault">The default integer value.</param>
		/// </returns>
		protected new int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
		{
			string text = objEvent[strAttribute];
			if (CommonUtils.IsNullOrEmpty(text))
			{
				return intDefault;
			}
			return int.Parse(text);
		}

		/// 
		/// Gets the height.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal int GetHeight(int intRowIndex)
		{
			GetHeightInfo(intRowIndex, out var intHeight, out var _);
			return intHeight;
		}

		/// 
		/// Gets the minimum height.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal int GetMinimumHeight(int intRowIndex)
		{
			GetHeightInfo(intRowIndex, out var _, out var intMinimumHeight);
			return intMinimumHeight;
		}

		/// Calculates the ideal height of the specified row based on the specified criteria.</summary>
		/// The ideal height of the row, in pixels.</returns>
		/// <param name="enmAutoSizeRowMode">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> that specifies an automatic sizing mode.</param>
		/// <param name="intRowIndex">The index of the row whose preferred height is calculated.</param>
		/// <param name="blnFixedWidth">true to calculate the preferred height for a fixed cell width; otherwise, false.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The rowIndex is not in the valid range of 0 to the number of rows in the control minus 1. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> value. </exception>
		public virtual int GetPreferredHeight(int intRowIndex, DataGridViewAutoSizeRowMode enmAutoSizeRowMode, bool blnFixedWidth)
		{
			DataGridView dataGridView = base.DataGridView;
			if ((enmAutoSizeRowMode & (DataGridViewAutoSizeRowMode)(-4)) != 0)
			{
				throw new InvalidEnumArgumentException("autoSizeRowMode", (int)enmAutoSizeRowMode, typeof(DataGridViewAutoSizeRowMode));
			}
			if (dataGridView != null && (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count))
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (dataGridView == null)
			{
				return -1;
			}
			int num = 0;
			if (dataGridView.RowHeadersVisible && (enmAutoSizeRowMode & DataGridViewAutoSizeRowMode.RowHeader) != 0)
			{
				num = ((!blnFixedWidth && dataGridView.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && dataGridView.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing) ? Math.Max(num, HeaderCell.GetPreferredSize(intRowIndex).Height) : Math.Max(num, HeaderCell.GetPreferredHeight(intRowIndex, dataGridView.RowHeadersWidth)));
			}
			if ((enmAutoSizeRowMode & DataGridViewAutoSizeRowMode.AllCellsExceptHeader) != 0)
			{
				foreach (DataGridViewCell cell in Cells)
				{
					DataGridViewColumn dataGridViewColumn = dataGridView.Columns[cell.ColumnIndex];
					if (dataGridViewColumn.Visible)
					{
						int num2 = ((!blnFixedWidth && (dataGridViewColumn.InheritedAutoSizeMode & (DataGridViewAutoSizeColumnMode)12) != DataGridViewAutoSizeColumnMode.NotSet) ? cell.GetPreferredSize(intRowIndex).Height : cell.GetPreferredHeight(intRowIndex, dataGridViewColumn.Width));
						if (num < num2)
						{
							num = num2;
						}
					}
				}
			}
			return num;
		}

		/// 
		/// Gets the read only.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool GetReadOnly(int intRowIndex)
		{
			if ((GetState(intRowIndex) & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
			{
				return true;
			}
			return base.DataGridView?.ReadOnly ?? false;
		}

		/// 
		/// Gets the resizable.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal DataGridViewTriState GetResizable(int intRowIndex)
		{
			if ((GetState(intRowIndex) & DataGridViewElementStates.ResizableSet) != DataGridViewElementStates.None)
			{
				if ((GetState(intRowIndex) & DataGridViewElementStates.Resizable) == 0)
				{
					return DataGridViewTriState.False;
				}
				return DataGridViewTriState.True;
			}
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null)
			{
				return DataGridViewTriState.NotSet;
			}
			if (!dataGridView.AllowUserToResizeRows)
			{
				return DataGridViewTriState.False;
			}
			return DataGridViewTriState.True;
		}

		/// 
		/// Gets the selected.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool GetSelected(int intRowIndex)
		{
			return (GetState(intRowIndex) & DataGridViewElementStates.Selected) != 0;
		}

		/// Returns a value indicating the current state of the row.</summary>
		/// A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the row state.</returns>
		/// <param name="intRowIndex">The index of the row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The row has been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, but the rowIndex value is not in the valid range of 0 to the number of rows in the control minus 1.</exception>
		/// <exception cref="T:System.ArgumentException">The row is not a shared row, but the rowIndex value does not match the row's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Index"></see> property value.-or-The row has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, but the rowIndex value does not match the row's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Index"></see> property value.</exception>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual DataGridViewElementStates GetState(int intRowIndex)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView != null)
			{
				DataGridViewRowCollection dataGridViewRowCollection = null;
				dataGridViewRowCollection = dataGridView.Rows;
				if (intRowIndex < 0 || intRowIndex >= dataGridViewRowCollection.Count)
				{
					throw new ArgumentOutOfRangeException("rowIndex");
				}
				if (dataGridViewRowCollection.SharedRow(intRowIndex).Index == -1)
				{
					return dataGridViewRowCollection.GetRowState(intRowIndex);
				}
			}
			if (intRowIndex != base.Index)
			{
				throw new ArgumentException(SR.GetString("InvalidArgument", "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture)));
			}
			return base.State;
		}

		/// 
		/// Gets the visible.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		internal bool GetVisible(int intRowIndex)
		{
			return (GetState(intRowIndex) & DataGridViewElementStates.Visible) != 0;
		}

		/// Gets the shortcut menu for the row.</summary>
		/// A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> that belongs to the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index.</returns>
		/// <param name="intRowIndex">The index of the current row.</param>
		/// <exception cref="T:System.InvalidOperationException">rowIndex is -1.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than or equal to the number of rows in the control minus one.</exception>
		public ContextMenu GetContextMenu(int intRowIndex)
		{
			ContextMenu contextMenuInternal = base.ContextMenuInternal;
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null)
			{
				return contextMenuInternal;
			}
			if (intRowIndex == -1)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
			}
			if (intRowIndex < 0 || intRowIndex >= dataGridView.Rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (!dataGridView.VirtualMode && dataGridView.DataSource == null)
			{
				return contextMenuInternal;
			}
			return dataGridView.OnRowContextMenuNeeded(intRowIndex, contextMenuInternal);
		}

		/// 
		/// Gets the context menu strip.
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// </returns>
		public ContextMenuStrip GetContextMenuStrip(int rowIndex)
		{
			ContextMenuStrip contextMenuStripInternal = base.ContextMenuStripInternal;
			if (base.DataGridView == null)
			{
				return contextMenuStripInternal;
			}
			if (rowIndex == -1)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
			}
			if (rowIndex < 0 || rowIndex >= base.DataGridView.Rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (!base.DataGridView.VirtualMode && base.DataGridView.DataSource == null)
			{
				return contextMenuStripInternal;
			}
			return base.DataGridView.OnRowContextMenuStripNeeded(rowIndex, contextMenuStripInternal);
		}
	}
}

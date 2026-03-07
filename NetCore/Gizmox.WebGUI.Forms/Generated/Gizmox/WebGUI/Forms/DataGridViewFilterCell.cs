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
	[ToolboxItem(false)]
	public class DataGridViewFilterCell : DataGridViewCell
	{
		/// 
		///
		/// </summary>
		[Serializable]
		[ToolboxItem(false)]
		internal class DataGridViewFilterControl : UserControl
		{
			private DataGridViewColumn mobjOwningColumn = null;

			private DataGridView mobjOwningDataGridView = null;

			private Panel mobjLeftPanel;

			private DataGridViewFilterButton mobjOperatorsButton;

			private Panel mobjRightPanel;

			private DataGridViewFilterButton mobjClearButton;

			internal DataGridViewFilterComboBox mobjValuesComboBox;

			private ContextMenu mobjOperatorsContextMenu;

			private DataGridViewFilterCell mobjOwningCell;

			/// 
			/// Gets the comparision operator.
			/// </summary>
			public FilterComparisonOperator ComparisionOperator
			{
				get
				{
					if (mobjOperatorsButton != null && mobjOperatorsButton.Tag != null)
					{
						return (FilterComparisonOperator)mobjOperatorsButton.Tag;
					}
					return FilterComparisonOperator.None;
				}
			}

			/// 
			/// Gets the comparision value.
			/// </summary>
			public string ComparisionValue
			{
				get
				{
					if (mobjValuesComboBox != null)
					{
						return mobjValuesComboBox.Text;
					}
					return string.Empty;
				}
			}

			/// 
			/// Gets the comparision Item.
			/// </summary>
			public object ComparisionItem
			{
				get
				{
					if (mobjValuesComboBox != null)
					{
						return mobjValuesComboBox.SelectedItem;
					}
					return null;
				}
			}

			/// 
			/// Occurs when [filter changed].
			/// </summary>
			public event EventHandler FilterChanged;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewFilterCell.DataGridViewFilterControl" /> class.
			/// </summary>
			/// <param name="objOwningDataGridView">The obj owning data grid view.</param>
			/// <param name="objOwningColumn">The obj owning column.</param>
			/// <param name="objOwningCell">The obj owning cell.</param>
			/// <param name="blnFilteringEnabled">if set to true</c> [BLN filtering enabled].</param>
			public DataGridViewFilterControl(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, DataGridViewFilterCell objOwningCell, bool blnFilteringEnabled)
			{
				objOwningDataGridView.mblnSuspendFilterInitialization = true;
				mobjOwningCell = objOwningCell;
				InitializeComponent();
				if (blnFilteringEnabled)
				{
					mobjOwningDataGridView = objOwningDataGridView;
					mobjOwningColumn = objOwningColumn;
					InitializeValuesComboBox();
					InitializeOperatorsContextMenu();
					InitializeOperatorsButton();
					InitializeClearButton();
				}
				objOwningDataGridView.mblnSuspendFilterInitialization = false;
			}

			/// 
			/// Initializes the operators button.
			/// </summary>
			private void InitializeOperatorsButton()
			{
				if (mobjOwningDataGridView != null && mobjOwningDataGridView.Skin is DataGridViewSkin dataGridViewSkin)
				{
					mobjOperatorsButton.Image = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.InitialOperatorImage);
				}
			}

			/// 
			/// Handles context menu click.
			/// </summary>
			/// <param name="objSource">The obj source.</param>
			/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Forms.MenuItemEventArgs" /> instance containing the event data.</param>
			private void OperatorsContextMenuClick(object objSource, MenuItemEventArgs objArgs)
			{
				MenuItem menuItem = objArgs.MenuItem;
				if (menuItem != null)
				{
					SetOperator(menuItem.Tag, menuItem.Icon);
					FireFilterChanged(blnForceFilterChanged: false);
				}
			}

			/// 
			/// Occurs when the values combobox's text changed.
			/// </summary>
			/// <param name="sender">The sender.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void ValuesComboBoxTextChanged(object sender, EventArgs e)
			{
				if (mobjValuesComboBox.SelectedItem is DataGridViewSystemFilterOption { Option: SystemFilterOptions.Custom })
				{
					if (mobjOwningColumn.ShowHeaderFilter && mobjOwningColumn.HeaderCell != null)
					{
						mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
						mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
					}
					mobjOwningDataGridView.OpenCustomFilterDialog(mobjOwningCell);
					return;
				}
				if (!mobjValuesComboBox.IsValidValue())
				{
					mobjValuesComboBox.TextChanged -= ValuesComboBoxTextChanged;
					mobjValuesComboBox.Text = string.Empty;
					mobjValuesComboBox.TextChanged += ValuesComboBoxTextChanged;
					MessageBox.Show(SR.GetString("InvalidFilterMessage"), string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				FireFilterChanged(blnForceFilterChanged: false);
			}

			/// 
			/// Fire filter changed event.
			/// </summary>
			internal void FireFilterChanged(bool blnForceFilterChanged)
			{
				EventHandler eventHandler = this.FilterChanged;
				if (eventHandler != null && !mobjOwningDataGridView.mblnSuspendFilterInitialization && (!InValidFilterCriteria() || IsSystemFilter() || blnForceFilterChanged))
				{
					mobjOwningDataGridView.mblnSuspendFilterInitialization = true;
					if (mobjOwningColumn.ShowHeaderFilter && mobjOwningColumn.HasHeaderCell)
					{
						mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
						mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
					}
					mobjOwningColumn.mstrCustomFilterExpression = string.Empty;
					eventHandler(this, EventArgs.Empty);
					mobjOwningDataGridView.mblnSuspendFilterInitialization = false;
				}
			}

			/// 
			/// Determines whether [is system filter].
			/// </summary>
			/// 
			///   true</c> if [is system filter]; otherwise, false</c>.
			/// </returns>
			private bool IsSystemFilter()
			{
				return mobjValuesComboBox.SelectedItem is DataGridViewSystemFilterOption;
			}

			/// 
			/// Determines whether the filter is being created: either only an operator, or only value presents.
			/// </summary>
			/// </returns>
			private bool InValidFilterCriteria()
			{
				return ((mobjValuesComboBox.SelectedItem != null || !string.IsNullOrEmpty(mobjValuesComboBox.Text)) && ComparisionOperator == FilterComparisonOperator.None) || (mobjValuesComboBox.SelectedItem == null && string.IsNullOrEmpty(mobjValuesComboBox.Text) && ComparisionOperator != FilterComparisonOperator.None);
			}

			/// 
			/// Clears the filter.
			/// </summary>
			/// <param name="blnClearHeaderFilter">if set to true</c> [BLN clear header filter].</param>
			internal void ClearFilter(bool blnClearHeaderFilter)
			{
				ClearCriteria(blnClearHeaderFilter);
			}

			/// 
			/// Clears the criteria.
			/// </summary>
			/// <param name="sender">The sender.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void ClearCriteria(object sender, EventArgs e)
			{
				ClearCriteria(blnClearHeaderFilter: true);
			}

			/// 
			/// Clears criteria.
			/// </summary>
			/// <param name="blnClearHeaderFilter">if set to true</c> [BLN clear header filter].</param>
			private void ClearCriteria(bool blnClearHeaderFilter)
			{
				bool mblnSuspendFilterInitialization = mobjOwningDataGridView.mblnSuspendFilterInitialization;
				string text = mobjValuesComboBox.Text;
				object tag = mobjOperatorsButton.Tag;
				string mstrCustomFilterExpression = mobjOwningColumn.mstrCustomFilterExpression;
				bool flag = false;
				mobjOwningDataGridView.mblnSuspendFilterInitialization = true;
				SetOperator(null, null);
				mobjOwningColumn.mstrCustomFilterExpression = string.Empty;
				if (blnClearHeaderFilter && mobjOwningColumn.ShowHeaderFilter && mobjOwningColumn.HeaderCell != null && mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex != -1)
				{
					flag = true;
					mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
					mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
				}
				mobjValuesComboBox.SelectedIndex = -1;
				mobjValuesComboBox.Text = string.Empty;
				InitializeOperatorsButton();
				mobjOwningDataGridView.mblnSuspendFilterInitialization = mblnSuspendFilterInitialization;
				if ((text != mobjValuesComboBox.Text && tag != mobjOperatorsButton.Tag) || flag || mstrCustomFilterExpression != mobjOwningColumn.mstrCustomFilterExpression)
				{
					FireFilterChanged(blnForceFilterChanged: true);
				}
			}

			/// 
			/// Sets the operator.
			/// </summary>
			/// <param name="objOperator">The operator.</param>
			/// <param name="objResourceHandle">The resource handle.</param>
			internal void SetOperator(object objOperator, ResourceHandle objResourceHandle)
			{
				mobjOperatorsButton.Tag = objOperator;
				mobjOperatorsButton.Image = objResourceHandle;
			}

			/// 
			/// Initializes the clear button.
			/// </summary>
			private void InitializeClearButton()
			{
				if (mobjOwningDataGridView != null && mobjOwningDataGridView.Skin is DataGridViewSkin dataGridViewSkin)
				{
					mobjClearButton.Image = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.FilterCellClearButtonImage);
				}
			}

			/// 
			/// Initializes the operators context menu.
			/// </summary>
			private void InitializeOperatorsContextMenu()
			{
				BindingSource bindingSource = mobjOwningDataGridView.DataSource as BindingSource;
				if (mobjOwningColumn == null || bindingSource == null)
				{
					return;
				}
				List<object> filterComparisonOperator = GetFilterComparisonOperator(mobjOwningColumn.ValueType);
				foreach (FilterComparisonOperator item in filterComparisonOperator)
				{
					MenuItem menuItem = new MenuItem(SR.GetString($"FilterComparisionOperator_{item.ToString()}"));
					menuItem.Tag = item;
					menuItem.Icon = GetFilterComparisionOperatorImage(item);
					mobjOperatorsContextMenu.MenuItems.Add(menuItem);
				}
			}

			/// 
			/// Refreshes this instance.
			/// </summary>
			internal void RefreshFilterComboBox()
			{
				object tag = mobjOperatorsButton.Tag;
				ResourceHandle image = mobjOperatorsButton.Image;
				string text = mobjValuesComboBox.Text;
				InitializeValuesComboBox();
				SetOperator(tag, image);
				mobjValuesComboBox.Text = text;
			}

			/// 
			/// Gets the filter comparision operator image.
			/// </summary>
			/// <param name="enmFilterComparisionOperator">The enm filter comparision operator.</param>
			/// </returns>
			private ResourceHandle GetFilterComparisionOperatorImage(FilterComparisonOperator enmFilterComparisionOperator)
			{
				return GetFilterComparisionOperatorImage(mobjOwningDataGridView, enmFilterComparisionOperator);
			}

			/// 
			/// Gets the filter comparision operator image.
			/// </summary>
			/// <param name="mobjOwningDataGridView">The mobj owning data grid view.</param>
			/// <param name="enmFilterComparisionOperator">The enm filter comparision operator.</param>
			/// </returns>
			internal static ResourceHandle GetFilterComparisionOperatorImage(DataGridView objOwningDataGridView, FilterComparisonOperator enmFilterComparisionOperator)
			{
				ResourceHandle result = null;
				if (objOwningDataGridView != null && objOwningDataGridView.Skin is DataGridViewSkin dataGridViewSkin)
				{
					switch (enmFilterComparisionOperator)
					{
					case FilterComparisonOperator.Contains:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.ContainsComparisionOperator);
						break;
					case FilterComparisonOperator.Custom:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.CustomComparisionOperator);
						break;
					case FilterComparisonOperator.DoesNotContain:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.DoesNotContainComparisionOperator);
						break;
					case FilterComparisonOperator.DoesNotEndWith:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.DoesNotEndWithComparisionOperator);
						break;
					case FilterComparisonOperator.DoesNotMatch:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.DoesNotMatchComparisionOperator);
						break;
					case FilterComparisonOperator.DoesNotStartWith:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.DoesNotStartWithComparisionOperator);
						break;
					case FilterComparisonOperator.Equals:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.EqualsComparisionOperator);
						break;
					case FilterComparisonOperator.EndsWith:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.EndsWithComparisionOperator);
						break;
					case FilterComparisonOperator.GreaterThan:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.GreaterThanComparisionOperator);
						break;
					case FilterComparisonOperator.GreaterThanOrEqualTo:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.GreaterThanOrEqualToComparisionOperator);
						break;
					case FilterComparisonOperator.LessThan:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.LessThanComparisionOperator);
						break;
					case FilterComparisonOperator.LessThanOrEqualTo:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.LessThanOrEqualToComparisionOperator);
						break;
					case FilterComparisonOperator.Like:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.LikeComparisionOperator);
						break;
					case FilterComparisonOperator.Match:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.MatchComparisionOperator);
						break;
					case FilterComparisonOperator.NotEquals:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.NotEqualsComparisionOperator);
						break;
					case FilterComparisonOperator.NotLike:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.NotLikeComparisionOperator);
						break;
					case FilterComparisonOperator.StartsWith:
						result = dataGridViewSkin.GetResourceHandleFromReference(dataGridViewSkin.StartsWithComparisionOperator);
						break;
					}
				}
				return result;
			}

			/// 
			/// Gets the filter comparison operator.
			/// </summary>
			/// <param name="objColumnType">Type of the column.</param>
			/// </returns>
			internal static List<object> GetFilterComparisonOperator(Type objColumnType)
			{
				List<object> list = new List<object>();
				list.Add(FilterComparisonOperator.Equals);
				list.Add(FilterComparisonOperator.NotEquals);
				if (objColumnType != typeof(bool))
				{
					list.Add(FilterComparisonOperator.LessThan);
					list.Add(FilterComparisonOperator.LessThanOrEqualTo);
					list.Add(FilterComparisonOperator.GreaterThan);
					list.Add(FilterComparisonOperator.GreaterThanOrEqualTo);
				}
				if (objColumnType != typeof(sbyte) && objColumnType != typeof(short) && objColumnType != typeof(int) && objColumnType != typeof(long) && objColumnType != typeof(byte) && objColumnType != typeof(ushort) && objColumnType != typeof(uint) && objColumnType != typeof(long) && objColumnType != typeof(float) && objColumnType != typeof(double) && objColumnType != typeof(bool) && objColumnType != typeof(char) && objColumnType != typeof(decimal))
				{
					list.Add(FilterComparisonOperator.Like);
					list.Add(FilterComparisonOperator.StartsWith);
					list.Add(FilterComparisonOperator.Contains);
					list.Add(FilterComparisonOperator.EndsWith);
					list.Add(FilterComparisonOperator.DoesNotStartWith);
					list.Add(FilterComparisonOperator.DoesNotEndWith);
					list.Add(FilterComparisonOperator.DoesNotContain);
					list.Add(FilterComparisonOperator.NotLike);
				}
				return list;
			}

			/// 
			/// Initializes the values combo box.
			/// </summary>
			private void InitializeValuesComboBox()
			{
				if (string.IsNullOrEmpty(mobjValuesComboBox.Text) && mobjOperatorsButton.Tag == null)
				{
					mobjValuesComboBox.OwningColumn = mobjOwningColumn;
					mobjValuesComboBox.OwningDataGridView = mobjOwningDataGridView;
					mobjValuesComboBox.InitializeFilterValues(blnAddSystemFilterOptions: true, blnCalculateDropDownWidth: false, blnClearBindingSourceFilter: false);
				}
			}

			/// 
			/// Initializes the component.
			/// </summary>
			private void InitializeComponent()
			{
				mobjLeftPanel = new Panel();
				mobjOperatorsButton = new DataGridViewFilterButton();
				mobjRightPanel = new Panel();
				mobjClearButton = new DataGridViewFilterButton();
				mobjValuesComboBox = new DataGridViewFilterComboBox(mobjOwningDataGridView, mobjOwningColumn, mobjOwningCell);
				mobjOperatorsContextMenu = new ContextMenu();
				mobjLeftPanel.SuspendLayout();
				mobjRightPanel.SuspendLayout();
				SuspendLayout();
				mobjLeftPanel.Controls.Add(mobjOperatorsButton);
				mobjLeftPanel.Dock = DockStyle.Left;
				mobjLeftPanel.Location = new Point(0, 0);
				mobjLeftPanel.Name = "mobjLeftPanel";
				mobjLeftPanel.Size = new Size(26, 24);
				mobjLeftPanel.TabIndex = 0;
				mobjLeftPanel.BackColor = Color.Transparent;
				mobjOperatorsButton.Anchor = AnchorStyles.None;
				mobjOperatorsButton.DropDownMenu = mobjOperatorsContextMenu;
				mobjOperatorsButton.Location = new Point(1, 0);
				mobjOperatorsButton.Name = "mobjOperatorsButton";
				mobjOperatorsButton.Size = new Size(24, 24);
				mobjOperatorsButton.TabIndex = 1;
				mobjOperatorsButton.MenuClick += OperatorsContextMenuClick;
				mobjOperatorsButton.ToolTip = SR.GetString("SelectFilterOperation");
				mobjRightPanel.Controls.Add(mobjClearButton);
				mobjRightPanel.Dock = DockStyle.Right;
				mobjRightPanel.Location = new Point(269, 0);
				mobjRightPanel.Name = "mobjRightPanel";
				mobjRightPanel.Size = new Size(26, 24);
				mobjRightPanel.TabIndex = 0;
				mobjRightPanel.BackColor = Color.Transparent;
				mobjClearButton.Anchor = AnchorStyles.None;
				mobjClearButton.Location = new Point(1, 0);
				mobjClearButton.Name = "mobjClearButton";
				mobjClearButton.Size = new Size(24, 24);
				mobjClearButton.TabIndex = 0;
				mobjClearButton.Click += ClearCriteria;
				mobjClearButton.ToolTip = SR.GetString("ClearFilterExpression");
				mobjValuesComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				mobjValuesComboBox.BorderStyle = BorderStyle.Fixed3D;
				mobjValuesComboBox.FormattingEnabled = true;
				mobjValuesComboBox.Location = new Point(25, 2);
				mobjValuesComboBox.Name = "mobjValuesComboBox";
				mobjValuesComboBox.Size = new Size(237, 21);
				mobjValuesComboBox.TabIndex = 1;
				mobjValuesComboBox.TextChanged += ValuesComboBoxTextChanged;
				BackColor = Color.Transparent;
				Dock = DockStyle.Fill;
				base.Controls.Add(mobjValuesComboBox);
				base.Controls.Add(mobjRightPanel);
				base.Controls.Add(mobjLeftPanel);
				base.Size = new Size(287, 24);
				mobjLeftPanel.ResumeLayout(blnPerformLayout: false);
				mobjRightPanel.ResumeLayout(blnPerformLayout: false);
				ResumeLayout(blnPerformLayout: false);
			}
		}

		private DataGridViewColumn mobjOwningColumn = null;

		private DataGridViewFilterControl mobjDataGridViewFilterControl = null;

		private DataGridView mobjOwningDataGridView = null;

		/// 
		/// Filter cell type identificator.
		/// </summary>
		protected const string FilterTypeName = "8";

		/// 
		/// Gets TypeName of FilterCell
		/// </summary>
		internal override string TypeName => "8";

		/// 
		/// Gets the render mask.
		/// </summary>
		internal override int RenderMask => base.RenderMask | 1 | 4 | 2;

		/// 
		/// Gets the prerender mask.
		/// </summary>
		internal override int PreRenderMask => base.PreRenderMask | 1;

		/// 
		/// Gets the comparision operator.
		/// </summary>
		internal FilterComparisonOperator ComparisonOperator
		{
			get
			{
				if (mobjDataGridViewFilterControl != null)
				{
					return mobjDataGridViewFilterControl.ComparisionOperator;
				}
				return FilterComparisonOperator.None;
			}
		}

		/// 
		/// Gets the comparision value.
		/// </summary>
		internal string ComparisionValue
		{
			get
			{
				if (mobjDataGridViewFilterControl != null)
				{
					return mobjDataGridViewFilterControl.ComparisionValue;
				}
				return string.Empty;
			}
		}

		/// 
		/// Gets the comparision item.
		/// </summary>
		internal object ComparisionItem
		{
			get
			{
				if (mobjDataGridViewFilterControl != null)
				{
					return mobjDataGridViewFilterControl.ComparisionItem;
				}
				return null;
			}
		}

		/// 
		/// Gets the name of the data property.
		/// </summary>
		/// 
		/// The name of the data property.
		/// </value>
		internal string DataPropertyName
		{
			get
			{
				if (mobjOwningColumn != null)
				{
					return mobjOwningColumn.DataPropertyName;
				}
				return string.Empty;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow row filtering].
		/// </summary>
		/// 
		///   true</c> if [allow row filtering]; otherwise, false</c>.
		/// </value>
		internal bool AllowRowFiltering
		{
			get
			{
				if (mobjOwningColumn != null)
				{
					return mobjOwningColumn.AllowRowFiltering;
				}
				return true;
			}
			set
			{
				if (mobjOwningColumn != null)
				{
					mobjOwningColumn.AllowRowFiltering = value;
				}
			}
		}

		/// 
		/// Gets or sets the data type of the values in the cell.
		/// </summary>
		/// A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
		internal new Type ValueType
		{
			get
			{
				if (mobjOwningColumn != null)
				{
					return mobjOwningColumn.ValueType;
				}
				return null;
			}
		}

		/// 
		/// Gets the data grid view filter control.
		/// </summary>
		/// 
		/// The data grid view filter control.
		/// </value>
		internal DataGridViewFilterControl DataGridViewFilterControlObject => mobjDataGridViewFilterControl;

		/// 
		/// Occurs when [filter changed].
		/// </summary>
		public event EventHandler FilterChanged;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewFilterCell" /> class.
		/// </summary>
		public DataGridViewFilterCell(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, bool blnFilteringEnabled)
		{
			InitializeDataGridViewFilterCell(objOwningDataGridView, objOwningColumn, blnFilteringEnabled);
			base.Panel.Controls.Add(mobjDataGridViewFilterControl);
			Colspan = 1;
			Rowspan = 1;
		}

		/// 
		/// Clears the filter.
		/// </summary>
		/// <param name="blnClearHeaderFilter">if set to true</c> [BLN clear header filter].</param>
		public void ClearFilter(bool blnClearHeaderFilter)
		{
			mobjDataGridViewFilterControl.ClearFilter(blnClearHeaderFilter);
		}

		/// 
		/// Initializes the data grid view filter cell.
		/// </summary>
		/// <param name="objOwningDataGridView">The obj owning data grid view.</param>
		/// <param name="objOwningColumn">The obj owning column.</param>
		/// <param name="blnFilteringEnabled">if set to true</c> [BLN filtering enabled].</param>
		private void InitializeDataGridViewFilterCell(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, bool blnFilteringEnabled)
		{
			mobjOwningColumn = objOwningColumn;
			mobjOwningDataGridView = objOwningDataGridView;
			if (mobjDataGridViewFilterControl == null)
			{
				mobjDataGridViewFilterControl = new DataGridViewFilterControl(objOwningDataGridView, objOwningColumn, this, blnFilteringEnabled);
			}
			else
			{
				objOwningDataGridView.mblnSuspendFilterInitialization = true;
				mobjDataGridViewFilterControl.RefreshFilterComboBox();
				objOwningDataGridView.mblnSuspendFilterInitialization = false;
			}
			if (blnFilteringEnabled)
			{
				mobjDataGridViewFilterControl.FilterChanged += OnDataGridViewFilterControlFilterChanged;
				mobjOwningColumn.AllowRowFilteringChanged += OnAllowRowFilteringChanged;
			}
			AllowRowFiltering = mobjOwningColumn.AllowRowFiltering && blnFilteringEnabled;
			InitializeCellPanelAvailablity();
			base.DataGridViewInternal = objOwningDataGridView;
			base.OwningColumnInternal = objOwningColumn;
		}

		/// 
		/// Refreshes the filter cell.
		/// </summary>
		internal void RefreshFilterCell()
		{
			RefreshFilterCell(mobjOwningDataGridView, mobjOwningColumn, AllowRowFiltering);
		}

		/// 
		/// Refreshes the filter cell.
		/// </summary>
		/// <param name="objOwningDataGridView">The owning data grid view.</param>
		/// <param name="objOwningColumn">The obj owning column.</param>
		/// <param name="blnFilteringEnabled">if set to true</c> [BLN filtering enabled].</param>
		private void RefreshFilterCell(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, bool blnFilteringEnabled)
		{
			InitializeDataGridViewFilterCell(objOwningDataGridView, objOwningColumn, blnFilteringEnabled);
		}

		/// 
		/// Called when [allow row filtering changed].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnAllowRowFilteringChanged(object sender, EventArgs e)
		{
			InitializeCellPanelAvailablity();
		}

		/// 
		/// Initializes the cell panel availablity.
		/// </summary>
		private void InitializeCellPanelAvailablity()
		{
			base.Panel.Enabled = AllowRowFiltering;
		}

		/// 
		/// Updates the filter combo box.
		/// </summary>
		internal void UpdateFilterComboBox()
		{
			if (mobjDataGridViewFilterControl.mobjValuesComboBox != null)
			{
				mobjDataGridViewFilterControl.mobjValuesComboBox.Update();
			}
		}

		/// 
		/// Called when [data grid view filter control filter changed].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnDataGridViewFilterControlFilterChanged(object sender, EventArgs e)
		{
			if (this.FilterChanged != null)
			{
				this.FilterChanged(this, e);
			}
		}
	}
}

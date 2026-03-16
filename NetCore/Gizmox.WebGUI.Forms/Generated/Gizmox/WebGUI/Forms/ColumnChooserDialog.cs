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
	internal class ColumnChooserDialog : CommonDialog
	{
		/// 
		///
		/// </summary>
		protected class ColumnChooserForm : CommonDialogForm
		{
			/// 
			///
			/// </summary>
			private class AllHierarchys
			{
				/// 
				/// Returns a <see cref="T:System.String" /> that represents this instance.
				/// </summary>
				/// 
				/// A <see cref="T:System.String" /> that represents this instance.
				/// </returns>
				public override string ToString()
				{
					return SR.GetString("WGLablesAll");
				}
			}

			/// 
			/// A helper class for the root node
			/// </summary>
			private class RootDataGridViewWithName
			{
				private DataGridView mobjDataGridView;

				/// 
				/// Returns a <see cref="T:System.String" /> that represents this instance.
				/// </summary>
				/// 
				/// A <see cref="T:System.String" /> that represents this instance.
				/// </returns>
				public override string ToString()
				{
					if (mobjDataGridView is HierarchicDataGridView)
					{
						return (mobjDataGridView as HierarchicDataGridView).ContainingRow.RelatedHierarchyInfo.ToString();
					}
					return mobjDataGridView.Name;
				}

				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm.RootDataGridViewWithName" /> class.
				/// </summary>
				/// <param name="mobjDataGridView">The mobj data grid view.</param>
				public RootDataGridViewWithName(DataGridView mobjDataGridView)
				{
					this.mobjDataGridView = mobjDataGridView;
				}
			}

			/// 
			///
			/// </summary>
			[Serializable]
			private class DataGridViewColumnTreeNode : TreeNode
			{
				private string mstrColumnName;

				private DataGridViewColumn mobjColumn;

				private bool mblnInitialCheckedState;

				/// 
				/// Gets or sets the name of the column.
				/// </summary>
				/// 
				/// The name of the column.
				/// </value>
				internal string ColumnName
				{
					get
					{
						return mstrColumnName;
					}
					set
					{
						mstrColumnName = value;
					}
				}

				/// 
				/// Gets or sets the column.
				/// </summary>
				/// 
				/// The column.
				/// </value>
				internal DataGridViewColumn Column
				{
					get
					{
						return mobjColumn;
					}
					set
					{
						mobjColumn = value;
					}
				}

				/// 
				/// Gets or sets a value indicating whether [initial checked state].
				/// </summary>
				/// 
				///   true</c> if [initial checked state]; otherwise, false</c>.
				/// </value>
				internal bool InitialCheckedState
				{
					get
					{
						return mblnInitialCheckedState;
					}
					set
					{
						mblnInitialCheckedState = value;
					}
				}

				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode" /> class.
				/// </summary>
				/// <param name="strColumnName">Name of the STR column.</param>
				/// <param name="blnInitialCheckedState">if set to true</c> [BLN initial checked state].</param>
				public DataGridViewColumnTreeNode(string strColumnName, bool blnInitialCheckedState)
					: this(strColumnName, blnInitialCheckedState, null)
				{
				}

				/// 
				/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode" /> class.
				/// </summary>
				/// <param name="strColumnName">Name of the STR column.</param>
				/// <param name="blnInitialCheckedState">if set to true</c> [BLN initial checked state].</param>
				/// <param name="objColumn">The obj column.</param>
				public DataGridViewColumnTreeNode(string strColumnName, bool blnInitialCheckedState, DataGridViewColumn objColumn)
					: base(strColumnName)
				{
					mstrColumnName = strColumnName;
					mobjColumn = objColumn;
					base.Checked = (mblnInitialCheckedState = blnInitialCheckedState);
				}
			}

			private DataGridView mobjDataGridView;

			private Dictionary<HierarchicInfo, IEnumerable<TreeNode>> mobjNodesIndexedByTheirHierarchyLevel;

			private List<TreeNode> mobjRootNodeColumns;

			private TreeView mobjTreeColumnsViewer;

			private ColumnChooserButton mobjCancel;

			private ColumnChooserButton mobjOk;

			private Panel mobjButtons;

			private ComboBox mobjHierarchyFilter;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm" /> class.
			/// </summary>
			/// <param name="objDialog">The obj dialog.</param>
			/// <param name="objDataGridView">The obj data grid view.</param>
			public ColumnChooserForm(CommonDialog objDialog, DataGridView objDataGridView)
				: base(objDialog)
			{
				mobjDataGridView = objDataGridView;
				mobjNodesIndexedByTheirHierarchyLevel = new Dictionary<HierarchicInfo, IEnumerable<TreeNode>>();
				mobjRootNodeColumns = new List<TreeNode>();
				InitializeComponent();
				FillComboBoxFilter();
				InitializeAndFillColumnsTree();
			}

			/// 
			/// Fills the combo box filter.
			/// </summary>
			private void FillComboBoxFilter()
			{
				if (!mobjDataGridView.IsHierarchic(HierarchicInfoSelector.Public))
				{
					return;
				}
				mobjHierarchyFilter.Items.Add(new RootDataGridViewWithName(mobjDataGridView));
				foreach (HierarchicInfo hierarchicInfo in mobjDataGridView.HierarchicInfos)
				{
					mobjHierarchyFilter.Items.Add(hierarchicInfo);
				}
			}

			/// 
			/// Fills the columns tree.
			/// </summary>
			private void InitializeAndFillColumnsTree()
			{
				InitializeFillRootGridColumns();
				if (mobjDataGridView.IsHierarchic(HierarchicInfoSelector.Public))
				{
					InitializeAndFillHierarchicColumns(mobjDataGridView.HierarchicInfos, mobjTreeColumnsViewer.Nodes[mobjTreeColumnsViewer.Nodes.Count - 1]);
				}
				mobjTreeColumnsViewer.ExpandAll();
			}

			/// 
			/// Initializes the fill root grid columns.
			/// </summary>
			private void InitializeFillRootGridColumns()
			{
				foreach (DataGridViewColumn column in mobjDataGridView.Columns)
				{
					if (!column.IsExcludedFromColumnChooser)
					{
						DataGridViewColumnTreeNode dataGridViewColumnTreeNode = new DataGridViewColumnTreeNode(column.HeaderText, column.Visible, column);
						mobjTreeColumnsViewer.Nodes.Add(dataGridViewColumnTreeNode);
						mobjRootNodeColumns.Add(dataGridViewColumnTreeNode);
					}
				}
			}

			/// 
			/// Fills the hierarchic columns.
			/// </summary>
			/// <param name="objInfos">The obj infos.</param>
			/// <param name="objHierarchicNode">The obj hierarchic node.</param>
			private void InitializeAndFillHierarchicColumns(ObservableCollection<HierarchicInfo> objInfos, TreeNode objHierarchicNode)
			{
				HierarchicInfo hierarchicInfo = objInfos[0];
				List<TreeNode> value = InitializeAndFillSingleHierarchicColumns(objHierarchicNode.Nodes, hierarchicInfo);
				mobjNodesIndexedByTheirHierarchyLevel.Add(hierarchicInfo, value);
				if (objInfos.Count > 1)
				{
					InitializeAndFillHierarchicColumns(HierarchicInfo.GetClonedInfos(objInfos, blnIncludeRoot: false), objHierarchicNode.Nodes[objHierarchicNode.Nodes.Count - 1]);
				}
			}

			/// 
			/// Fills the single hierarchic columns.
			/// </summary>
			/// <param name="objHierarchicNodeCollection">The obj hierarchic node collection.</param>
			/// <param name="objCurrentInfoLevel">The obj current info level.</param>
			/// </returns>
			private static List<TreeNode> InitializeAndFillSingleHierarchicColumns(TreeNodeCollection objHierarchicNodeCollection, HierarchicInfo objCurrentInfoLevel)
			{
				IEnumerable<string> columnNamesFromBindedSource = GetColumnNamesFromBindedSource(objCurrentInfoLevel.BindedSource);
				List<TreeNode> list = new List<TreeNode>();
				foreach (string item in columnNamesFromBindedSource)
				{
					bool blnInitialCheckedState = objCurrentInfoLevel.HiddenColumns.IndexOf(item) == -1;
					DataGridViewColumnTreeNode dataGridViewColumnTreeNode = new DataGridViewColumnTreeNode(item, blnInitialCheckedState);
					objHierarchicNodeCollection.Add(dataGridViewColumnTreeNode);
					list.Add(dataGridViewColumnTreeNode);
				}
				return list;
			}

			/// 
			/// Gets the column names from binded source.
			/// </summary>
			/// <param name="objBindingSource">The obj binding source.</param>
			/// </returns>
			private static IEnumerable<string> GetColumnNamesFromBindedSource(BindingSource objBindingSource)
			{
				foreach (PropertyDescriptor objColumnProperty in objBindingSource.CurrencyManager.GetItemProperties())
				{
					if (!typeof(IList).IsAssignableFrom(objColumnProperty.PropertyType))
					{
						yield return objColumnProperty.Name;
					}
				}
			}

			/// 
			/// Initializes the component.
			/// </summary>
			private void InitializeComponent()
			{
				mobjHierarchyFilter = new ComboBox();
				mobjCancel = new ColumnChooserButton();
				mobjOk = new ColumnChooserButton();
				mobjButtons = new Panel();
				mobjTreeColumnsViewer = new TreeView();
				mobjTreeColumnsViewer.Dock = DockStyle.Fill;
				mobjTreeColumnsViewer.ShowLines = false;
				mobjTreeColumnsViewer.ShowPlusMinus = false;
				mobjTreeColumnsViewer.CheckBoxes = true;
				mobjTreeColumnsViewer.TreeViewNodeSorter = mobjDataGridView.ColumnChooserSorter;
				mobjCancel.Text = SR.GetString("WGLablesCancel");
				mobjCancel.Anchor = AnchorStyles.None;
				mobjCancel.Location = new Point(111, 3);
				mobjCancel.Click += btnCancel_Click;
				mobjOk.Text = SR.GetString("WGLabelsOk");
				mobjOk.Anchor = AnchorStyles.None;
				mobjOk.Location = new Point(15, 3);
				mobjOk.Click += btnOk_Click;
				mobjButtons.Dock = DockStyle.Bottom;
				mobjButtons.Size = new Size(200, 29);
				mobjButtons.Controls.Add(mobjCancel);
				mobjButtons.Controls.Add(mobjOk);
				mobjHierarchyFilter.Dock = DockStyle.Top;
				mobjHierarchyFilter.Height = 21;
				mobjHierarchyFilter.Items.Add(new AllHierarchys());
				mobjHierarchyFilter.SelectedIndex = 0;
				mobjHierarchyFilter.SelectedIndexChanged += cboViewTypeChooser_SelectedIndexChanged;
				mobjHierarchyFilter.DropDownStyle = ComboBoxStyle.DropDownList;
				base.Controls.Add(mobjTreeColumnsViewer);
				base.Controls.Add(mobjButtons);
				base.Controls.Add(mobjHierarchyFilter);
				base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
				Text = SR.GetString("DataGridView_ChooseShowHideColumns");
				base.DialogType = DialogTypes.MainWindow;
				base.Size = new Size(225, 550);
			}

			/// 
			/// Handles the SelectedIndexChanged event of the cboViewTypeChooser control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void cboViewTypeChooser_SelectedIndexChanged(object sender, EventArgs e)
			{
				object obj = mobjHierarchyFilter.Items[mobjHierarchyFilter.SelectedIndex];
				bool flag = false;
				IEnumerable<TreeNode> enumerable = null;
				mobjTreeColumnsViewer.Nodes.Clear();
				if (obj is AllHierarchys)
				{
					enumerable = mobjRootNodeColumns;
					flag = true;
				}
				else if (obj is RootDataGridViewWithName)
				{
					enumerable = mobjRootNodeColumns;
				}
				else if (obj is HierarchicInfo)
				{
					enumerable = mobjNodesIndexedByTheirHierarchyLevel[obj as HierarchicInfo];
				}
				foreach (TreeNode item in enumerable)
				{
					mobjTreeColumnsViewer.Nodes.Add(item);
				}
				if (flag)
				{
					mobjTreeColumnsViewer.ExpandAll();
				}
				else
				{
					mobjTreeColumnsViewer.CollapseAll();
				}
			}

			/// 
			/// Updates the owning dialog.
			/// </summary>
			private void UpdateOwningDialog()
			{
				if (!(base.CommonDialogOwner is ColumnChooserDialog columnChooserDialog))
				{
					return;
				}
				List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> list = new List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>>();
				foreach (DataGridViewColumnTreeNode mobjRootNodeColumn in mobjRootNodeColumns)
				{
					DataGridViewColumn column = mobjRootNodeColumn.Column;
					if (column != null)
					{
						ColumnCheckedStatus columnCheckedStatus = new ColumnCheckedStatus();
						columnCheckedStatus.IsChecked = mobjRootNodeColumn.Checked;
						columnCheckedStatus.IsChanged = mobjRootNodeColumn.Checked != mobjRootNodeColumn.InitialCheckedState;
						list.Add(new KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>(column, columnCheckedStatus));
					}
				}
				columnChooserDialog.ChosenRootColumns = list;
				foreach (HierarchicInfo key in mobjNodesIndexedByTheirHierarchyLevel.Keys)
				{
					List<KeyValuePair<string, ColumnCheckedStatus>> list2 = new List<KeyValuePair<string, ColumnCheckedStatus>>();
					columnChooserDialog.ChosenColumnsIndexByTheirHierarchy.Add(key, list2);
					foreach (DataGridViewColumnTreeNode item in mobjNodesIndexedByTheirHierarchyLevel[key])
					{
						ColumnCheckedStatus columnCheckedStatus2 = new ColumnCheckedStatus();
						columnCheckedStatus2.IsChecked = item.Checked;
						columnCheckedStatus2.IsChanged = item.Checked != item.InitialCheckedState;
						list2.Add(new KeyValuePair<string, ColumnCheckedStatus>(item.ColumnName, columnCheckedStatus2));
					}
				}
			}

			/// 
			/// Handles the Click event of the btnCancel control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void btnCancel_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.Cancel;
				Close();
			}

			/// 
			/// Handles the Click event of the btnOk control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void btnOk_Click(object sender, EventArgs e)
			{
				UpdateOwningDialog();
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private DataGridView objDataGridView;

		private List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> marrChosenRootColumns;

		private Dictionary<HierarchicInfo, List<KeyValuePair<string, ColumnCheckedStatus>>> mobjChosenColumnsIndexByTheirHierarchy;

		/// 
		/// Gets the chosen columns index by their hierarchy.
		/// </summary>
		internal Dictionary<HierarchicInfo, List<KeyValuePair<string, ColumnCheckedStatus>>> ChosenColumnsIndexByTheirHierarchy
		{
			get
			{
				if (mobjChosenColumnsIndexByTheirHierarchy == null)
				{
					mobjChosenColumnsIndexByTheirHierarchy = new Dictionary<HierarchicInfo, List<KeyValuePair<string, ColumnCheckedStatus>>>();
				}
				return mobjChosenColumnsIndexByTheirHierarchy;
			}
		}

		/// 
		/// Gets the chosen root columns.
		/// </summary>
		internal List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> ChosenRootColumns
		{
			get
			{
				return marrChosenRootColumns;
			}
			private set
			{
				marrChosenRootColumns = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog" /> class.
		/// </summary>
		/// <param name="objDataGridView">The obj data grid view.</param>
		public ColumnChooserDialog(DataGridView objDataGridView)
		{
			this.objDataGridView = objDataGridView;
		}

		/// 
		/// When overridden in a derived class, resets the properties of a common dialog box to their default values.
		/// </summary>
		public override void Reset()
		{
		}

		/// 
		/// Creates a dialog for instance for the current common dialog
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			return new ColumnChooserForm(this, objDataGridView);
		}
	}
}

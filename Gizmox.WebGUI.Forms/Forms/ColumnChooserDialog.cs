// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColumnChooserDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class ColumnChooserDialog : CommonDialog
  {
    private DataGridView objDataGridView;
    private List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> marrChosenRootColumns;
    private Dictionary<HierarchicInfo, List<KeyValuePair<string, ColumnCheckedStatus>>> mobjChosenColumnsIndexByTheirHierarchy;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog" /> class.
    /// </summary>
    /// <param name="objDataGridView">The obj data grid view.</param>
    public ColumnChooserDialog(DataGridView objDataGridView) => this.objDataGridView = objDataGridView;

    /// <summary>
    /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
    /// </summary>
    public override void Reset()
    {
    }

    /// <summary>
    /// Creates a dialog for instance for the current common dialog
    /// </summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new ColumnChooserDialog.ColumnChooserForm((CommonDialog) this, this.objDataGridView);

    /// <summary>Gets the chosen columns index by their hierarchy.</summary>
    internal Dictionary<HierarchicInfo, List<KeyValuePair<string, ColumnCheckedStatus>>> ChosenColumnsIndexByTheirHierarchy
    {
      get
      {
        if (this.mobjChosenColumnsIndexByTheirHierarchy == null)
          this.mobjChosenColumnsIndexByTheirHierarchy = new Dictionary<HierarchicInfo, List<KeyValuePair<string, ColumnCheckedStatus>>>();
        return this.mobjChosenColumnsIndexByTheirHierarchy;
      }
    }

    /// <summary>Gets the chosen root columns.</summary>
    internal List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> ChosenRootColumns
    {
      get => this.marrChosenRootColumns;
      private set => this.marrChosenRootColumns = value;
    }

    /// <summary>
    /// 
    /// </summary>
    protected class ColumnChooserForm : CommonDialog.CommonDialogForm
    {
      private DataGridView mobjDataGridView;
      private Dictionary<HierarchicInfo, IEnumerable<TreeNode>> mobjNodesIndexedByTheirHierarchyLevel;
      private List<TreeNode> mobjRootNodeColumns;
      private TreeView mobjTreeColumnsViewer;
      private ColumnChooserButton mobjCancel;
      private ColumnChooserButton mobjOk;
      private Panel mobjButtons;
      private ComboBox mobjHierarchyFilter;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm" /> class.
      /// </summary>
      /// <param name="objDialog">The obj dialog.</param>
      /// <param name="objDataGridView">The obj data grid view.</param>
      public ColumnChooserForm(CommonDialog objDialog, DataGridView objDataGridView)
        : base(objDialog)
      {
        this.mobjDataGridView = objDataGridView;
        this.mobjNodesIndexedByTheirHierarchyLevel = new Dictionary<HierarchicInfo, IEnumerable<TreeNode>>();
        this.mobjRootNodeColumns = new List<TreeNode>();
        this.InitializeComponent();
        this.FillComboBoxFilter();
        this.InitializeAndFillColumnsTree();
      }

      /// <summary>Fills the combo box filter.</summary>
      private void FillComboBoxFilter()
      {
        if (!this.mobjDataGridView.IsHierarchic(HierarchicInfoSelector.Public))
          return;
        this.mobjHierarchyFilter.Items.Add((object) new ColumnChooserDialog.ColumnChooserForm.RootDataGridViewWithName(this.mobjDataGridView));
        foreach (object hierarchicInfo in (Collection<HierarchicInfo>) this.mobjDataGridView.HierarchicInfos)
          this.mobjHierarchyFilter.Items.Add(hierarchicInfo);
      }

      /// <summary>Fills the columns tree.</summary>
      private void InitializeAndFillColumnsTree()
      {
        this.InitializeFillRootGridColumns();
        if (this.mobjDataGridView.IsHierarchic(HierarchicInfoSelector.Public))
          this.InitializeAndFillHierarchicColumns(this.mobjDataGridView.HierarchicInfos, this.mobjTreeColumnsViewer.Nodes[this.mobjTreeColumnsViewer.Nodes.Count - 1]);
        this.mobjTreeColumnsViewer.ExpandAll();
      }

      /// <summary>Initializes the fill root grid columns.</summary>
      private void InitializeFillRootGridColumns()
      {
        foreach (DataGridViewColumn column in (BaseCollection) this.mobjDataGridView.Columns)
        {
          if (!column.IsExcludedFromColumnChooser)
          {
            ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode objTreeViewNode = new ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode(column.HeaderText, column.Visible, column);
            this.mobjTreeColumnsViewer.Nodes.Add((TreeNode) objTreeViewNode);
            this.mobjRootNodeColumns.Add((TreeNode) objTreeViewNode);
          }
        }
      }

      /// <summary>Fills the hierarchic columns.</summary>
      /// <param name="objInfos">The obj infos.</param>
      /// <param name="objHierarchicNode">The obj hierarchic node.</param>
      private void InitializeAndFillHierarchicColumns(
        ObservableCollection<HierarchicInfo> objInfos,
        TreeNode objHierarchicNode)
      {
        HierarchicInfo objInfo = objInfos[0];
        List<TreeNode> treeNodeList = ColumnChooserDialog.ColumnChooserForm.InitializeAndFillSingleHierarchicColumns(objHierarchicNode.Nodes, objInfo);
        this.mobjNodesIndexedByTheirHierarchyLevel.Add(objInfo, (IEnumerable<TreeNode>) treeNodeList);
        if (objInfos.Count <= 1)
          return;
        this.InitializeAndFillHierarchicColumns(HierarchicInfo.GetClonedInfos(objInfos, false), objHierarchicNode.Nodes[objHierarchicNode.Nodes.Count - 1]);
      }

      /// <summary>Fills the single hierarchic columns.</summary>
      /// <param name="objHierarchicNodeCollection">The obj hierarchic node collection.</param>
      /// <param name="objCurrentInfoLevel">The obj current info level.</param>
      /// <returns></returns>
      private static List<TreeNode> InitializeAndFillSingleHierarchicColumns(
        TreeNodeCollection objHierarchicNodeCollection,
        HierarchicInfo objCurrentInfoLevel)
      {
        IEnumerable<string> fromBindedSource = ColumnChooserDialog.ColumnChooserForm.GetColumnNamesFromBindedSource(objCurrentInfoLevel.BindedSource);
        List<TreeNode> treeNodeList = new List<TreeNode>();
        foreach (string strColumnName in fromBindedSource)
        {
          bool blnInitialCheckedState = objCurrentInfoLevel.HiddenColumns.IndexOf(strColumnName) == -1;
          ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode objTreeViewNode = new ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode(strColumnName, blnInitialCheckedState);
          objHierarchicNodeCollection.Add((TreeNode) objTreeViewNode);
          treeNodeList.Add((TreeNode) objTreeViewNode);
        }
        return treeNodeList;
      }

      /// <summary>Gets the column names from binded source.</summary>
      /// <param name="objBindingSource">The obj binding source.</param>
      /// <returns></returns>
      private static IEnumerable<string> GetColumnNamesFromBindedSource(
        BindingSource objBindingSource)
      {
        foreach (PropertyDescriptor itemProperty in objBindingSource.CurrencyManager.GetItemProperties())
        {
          if (!typeof (IList).IsAssignableFrom(itemProperty.PropertyType))
            yield return itemProperty.Name;
        }
      }

      /// <summary>Initializes the component.</summary>
      private void InitializeComponent()
      {
        this.mobjHierarchyFilter = new ComboBox();
        this.mobjCancel = new ColumnChooserButton();
        this.mobjOk = new ColumnChooserButton();
        this.mobjButtons = new Panel();
        this.mobjTreeColumnsViewer = new TreeView();
        this.mobjTreeColumnsViewer.Dock = DockStyle.Fill;
        this.mobjTreeColumnsViewer.ShowLines = false;
        this.mobjTreeColumnsViewer.ShowPlusMinus = false;
        this.mobjTreeColumnsViewer.CheckBoxes = true;
        this.mobjTreeColumnsViewer.TreeViewNodeSorter = this.mobjDataGridView.ColumnChooserSorter;
        this.mobjCancel.Text = SR.GetString("WGLablesCancel");
        this.mobjCancel.Anchor = AnchorStyles.None;
        this.mobjCancel.Location = new Point(111, 3);
        this.mobjCancel.Click += new EventHandler(this.btnCancel_Click);
        this.mobjOk.Text = SR.GetString("WGLabelsOk");
        this.mobjOk.Anchor = AnchorStyles.None;
        this.mobjOk.Location = new Point(15, 3);
        this.mobjOk.Click += new EventHandler(this.btnOk_Click);
        this.mobjButtons.Dock = DockStyle.Bottom;
        this.mobjButtons.Size = new Size(200, 29);
        this.mobjButtons.Controls.Add((Control) this.mobjCancel);
        this.mobjButtons.Controls.Add((Control) this.mobjOk);
        this.mobjHierarchyFilter.Dock = DockStyle.Top;
        this.mobjHierarchyFilter.Height = 21;
        this.mobjHierarchyFilter.Items.Add((object) new ColumnChooserDialog.ColumnChooserForm.AllHierarchys());
        this.mobjHierarchyFilter.SelectedIndex = 0;
        this.mobjHierarchyFilter.SelectedIndexChanged += new EventHandler(this.cboViewTypeChooser_SelectedIndexChanged);
        this.mobjHierarchyFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Controls.Add((Control) this.mobjTreeColumnsViewer);
        this.Controls.Add((Control) this.mobjButtons);
        this.Controls.Add((Control) this.mobjHierarchyFilter);
        this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        this.Text = SR.GetString("DataGridView_ChooseShowHideColumns");
        this.DialogType = DialogTypes.MainWindow;
        this.Size = new Size(225, 550);
      }

      /// <summary>
      /// Handles the SelectedIndexChanged event of the cboViewTypeChooser control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void cboViewTypeChooser_SelectedIndexChanged(object sender, EventArgs e)
      {
        object key = this.mobjHierarchyFilter.Items[this.mobjHierarchyFilter.SelectedIndex];
        bool flag = false;
        IEnumerable<TreeNode> treeNodes = (IEnumerable<TreeNode>) null;
        this.mobjTreeColumnsViewer.Nodes.Clear();
        switch (key)
        {
          case ColumnChooserDialog.ColumnChooserForm.AllHierarchys _:
            treeNodes = (IEnumerable<TreeNode>) this.mobjRootNodeColumns;
            flag = true;
            break;
          case ColumnChooserDialog.ColumnChooserForm.RootDataGridViewWithName _:
            treeNodes = (IEnumerable<TreeNode>) this.mobjRootNodeColumns;
            break;
          case HierarchicInfo _:
            treeNodes = this.mobjNodesIndexedByTheirHierarchyLevel[key as HierarchicInfo];
            break;
        }
        foreach (TreeNode objTreeViewNode in treeNodes)
          this.mobjTreeColumnsViewer.Nodes.Add(objTreeViewNode);
        if (flag)
          this.mobjTreeColumnsViewer.ExpandAll();
        else
          this.mobjTreeColumnsViewer.CollapseAll();
      }

      /// <summary>Updates the owning dialog.</summary>
      private void UpdateOwningDialog()
      {
        if (!(this.CommonDialogOwner is ColumnChooserDialog commonDialogOwner))
          return;
        List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> keyValuePairList1 = new List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>>();
        foreach (ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode mobjRootNodeColumn in this.mobjRootNodeColumns)
        {
          DataGridViewColumn column = mobjRootNodeColumn.Column;
          if (column != null)
            keyValuePairList1.Add(new KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>(column, new ColumnCheckedStatus()
            {
              IsChecked = mobjRootNodeColumn.Checked,
              IsChanged = mobjRootNodeColumn.Checked != mobjRootNodeColumn.InitialCheckedState
            }));
        }
        commonDialogOwner.ChosenRootColumns = keyValuePairList1;
        foreach (HierarchicInfo key in this.mobjNodesIndexedByTheirHierarchyLevel.Keys)
        {
          List<KeyValuePair<string, ColumnCheckedStatus>> keyValuePairList2 = new List<KeyValuePair<string, ColumnCheckedStatus>>();
          commonDialogOwner.ChosenColumnsIndexByTheirHierarchy.Add(key, keyValuePairList2);
          foreach (ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode viewColumnTreeNode in this.mobjNodesIndexedByTheirHierarchyLevel[key])
            keyValuePairList2.Add(new KeyValuePair<string, ColumnCheckedStatus>(viewColumnTreeNode.ColumnName, new ColumnCheckedStatus()
            {
              IsChecked = viewColumnTreeNode.Checked,
              IsChanged = viewColumnTreeNode.Checked != viewColumnTreeNode.InitialCheckedState
            }));
        }
      }

      /// <summary>Handles the Click event of the btnCancel control.</summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void btnCancel_Click(object sender, EventArgs e)
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }

      /// <summary>Handles the Click event of the btnOk control.</summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void btnOk_Click(object sender, EventArgs e)
      {
        this.UpdateOwningDialog();
        this.DialogResult = DialogResult.OK;
        this.Close();
      }

      /// <summary>
      /// 
      /// </summary>
      private class AllHierarchys
      {
        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => SR.GetString("WGLablesAll");
      }

      /// <summary>A helper class for the root node</summary>
      private class RootDataGridViewWithName
      {
        private DataGridView mobjDataGridView;

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.mobjDataGridView is HierarchicDataGridView ? (this.mobjDataGridView as HierarchicDataGridView).ContainingRow.RelatedHierarchyInfo.ToString() : this.mobjDataGridView.Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm.RootDataGridViewWithName" /> class.
        /// </summary>
        /// <param name="mobjDataGridView">The mobj data grid view.</param>
        public RootDataGridViewWithName(DataGridView mobjDataGridView) => this.mobjDataGridView = mobjDataGridView;
      }

      /// <summary>
      /// 
      /// </summary>
      [Serializable]
      private class DataGridViewColumnTreeNode : TreeNode
      {
        private string mstrColumnName;
        private DataGridViewColumn mobjColumn;
        private bool mblnInitialCheckedState;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode" /> class.
        /// </summary>
        /// <param name="strColumnName">Name of the STR column.</param>
        /// <param name="blnInitialCheckedState">if set to <c>true</c> [BLN initial checked state].</param>
        public DataGridViewColumnTreeNode(string strColumnName, bool blnInitialCheckedState)
          : this(strColumnName, blnInitialCheckedState, (DataGridViewColumn) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnChooserDialog.ColumnChooserForm.DataGridViewColumnTreeNode" /> class.
        /// </summary>
        /// <param name="strColumnName">Name of the STR column.</param>
        /// <param name="blnInitialCheckedState">if set to <c>true</c> [BLN initial checked state].</param>
        /// <param name="objColumn">The obj column.</param>
        public DataGridViewColumnTreeNode(
          string strColumnName,
          bool blnInitialCheckedState,
          DataGridViewColumn objColumn)
          : base(strColumnName)
        {
          this.mstrColumnName = strColumnName;
          this.mobjColumn = objColumn;
          this.Checked = this.mblnInitialCheckedState = blnInitialCheckedState;
        }

        /// <summary>Gets or sets the name of the column.</summary>
        /// <value>The name of the column.</value>
        internal string ColumnName
        {
          get => this.mstrColumnName;
          set => this.mstrColumnName = value;
        }

        /// <summary>Gets or sets the column.</summary>
        /// <value>The column.</value>
        internal DataGridViewColumn Column
        {
          get => this.mobjColumn;
          set => this.mobjColumn = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [initial checked state].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [initial checked state]; otherwise, <c>false</c>.
        /// </value>
        internal bool InitialCheckedState
        {
          get => this.mblnInitialCheckedState;
          set => this.mblnInitialCheckedState = value;
        }
      }
    }
  }
}

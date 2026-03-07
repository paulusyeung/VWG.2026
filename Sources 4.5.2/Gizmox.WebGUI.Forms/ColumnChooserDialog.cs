using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Data;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class ColumnChooserDialog : CommonDialog
    {
        #region Private members

        private DataGridView objDataGridView;
        private List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> marrChosenRootColumns;
        private Dictionary<HierarchicInfo, List<KeyValuePair<string, ColumnCheckedStatus>>> mobjChosenColumnsIndexByTheirHierarchy;

        #endregion Private members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChooserDialog"/> class.
        /// </summary>
        /// <param name="objDataGridView">The obj data grid view.</param>
        public ColumnChooserDialog(DataGridView objDataGridView)
        {
            this.objDataGridView = objDataGridView;
        }

        #endregion C'tors

        #region Methods

        /// <summary>
        /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
        /// </summary>
        public override void Reset()
        { }

        /// <summary>
        /// Creates a dialog for instance for the current common dialog
        /// </summary>
        /// <returns></returns>
        protected override CommonDialog.CommonDialogForm CreateForm()
        {
            return new ColumnChooserForm(this, objDataGridView);
        }

        #endregion Methods

        #region Porperties

        /// <summary>
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

        /// <summary>
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

        #endregion Porperties
       
        /// <summary>
        /// 
        /// </summary>
        protected class ColumnChooserForm : CommonDialog.CommonDialogForm
        {
            #region Private members

            private DataGridView mobjDataGridView;
            private Dictionary<HierarchicInfo, IEnumerable<TreeNode>> mobjNodesIndexedByTheirHierarchyLevel;
            private List<TreeNode> mobjRootNodeColumns;

            #endregion Private members

            #region C'tors

            /// <summary>
            /// Initializes a new instance of the <see cref="ColumnChooserForm"/> class.
            /// </summary>
            /// <param name="objDialog">The obj dialog.</param>
            /// <param name="objDataGridView">The obj data grid view.</param>
            public ColumnChooserForm(CommonDialog objDialog, DataGridView objDataGridView)
                : base(objDialog)
            {
                this.mobjDataGridView = objDataGridView;
                this.mobjNodesIndexedByTheirHierarchyLevel = new Dictionary<HierarchicInfo, IEnumerable<TreeNode>>();
                this.mobjRootNodeColumns = new List<TreeNode>();

                InitializeComponent();
                FillComboBoxFilter();
                InitializeAndFillColumnsTree();
            }

            #endregion C'tors

            /// <summary>
            /// Fills the combo box filter.
            /// </summary>
            private void FillComboBoxFilter()
            {
                // If the grid is not hierarchic, there's no need to put anything in the filter
                if (this.mobjDataGridView.IsHierarchic(HierarchicInfoSelector.Public))
                {
                    // Add the root node
                    this.mobjHierarchyFilter.Items.Add(new RootDataGridViewWithName(this.mobjDataGridView));

                    // Add child hierarchys
                    foreach (HierarchicInfo objCurrentInfoLevel in this.mobjDataGridView.HierarchicInfos)
                    {
                        this.mobjHierarchyFilter.Items.Add(objCurrentInfoLevel);
                    }
                }
            }

            /// <summary>
            /// Fills the columns tree.
            /// </summary>
            private void InitializeAndFillColumnsTree()
            {
                // Init the root node and add it to the treeView 
                InitializeFillRootGridColumns();

                // If DGV is hierarchic, add all child columns
                if (mobjDataGridView.IsHierarchic(HierarchicInfoSelector.Public))
                {
                    InitializeAndFillHierarchicColumns(this.mobjDataGridView.HierarchicInfos, this.mobjTreeColumnsViewer.Nodes[this.mobjTreeColumnsViewer.Nodes.Count - 1]);
                }

                // Show all noded
                this.mobjTreeColumnsViewer.ExpandAll();
            }

            /// <summary>
            /// Initializes the fill root grid columns.
            /// </summary>
            private void InitializeFillRootGridColumns()
            {
                foreach (DataGridViewColumn objColumn in this.mobjDataGridView.Columns)
                {
                    if (!objColumn.IsExcludedFromColumnChooser)
                    {
                        // Create the node
                        DataGridViewColumnTreeNode objNode = new DataGridViewColumnTreeNode(objColumn.HeaderText, objColumn.Visible, objColumn);
                        // Add the node to the treeView
                        this.mobjTreeColumnsViewer.Nodes.Add(objNode);
                        // Save all created nodes in a list to maintain their references
                        this.mobjRootNodeColumns.Add(objNode);
                    }
                }
            }
            
            /// <summary>
            /// Fills the hierarchic columns.
            /// </summary>
            /// <param name="objInfos">The obj infos.</param>
            /// <param name="objHierarchicNode">The obj hierarchic node.</param>
            private void InitializeAndFillHierarchicColumns(ObservableCollection<HierarchicInfo> objInfos, TreeNode objHierarchicNode)
            {
                // Take current level's info
                HierarchicInfo objCurrentInfoLevel = objInfos[0];

                // Create the column nodes for the relevant hierarchy and return a list of the created nodes
                List<TreeNode> objNodesHierarchyList = InitializeAndFillSingleHierarchicColumns(objHierarchicNode.Nodes, objCurrentInfoLevel);

                // Map the nodes to the respective hierarchy
                this.mobjNodesIndexedByTheirHierarchyLevel.Add(objCurrentInfoLevel, objNodesHierarchyList);

                // Check if we have more levels
                if (objInfos.Count > 1)
                {
                    // Recursively Create the nodes
                    InitializeAndFillHierarchicColumns(HierarchicInfo.GetClonedInfos(objInfos, false), objHierarchicNode.Nodes[objHierarchicNode.Nodes.Count - 1]);
                }
            }

            /// <summary>
            /// Fills the single hierarchic columns.
            /// </summary>
            /// <param name="objHierarchicNodeCollection">The obj hierarchic node collection.</param>
            /// <param name="objCurrentInfoLevel">The obj current info level.</param>
            /// <returns></returns>
            private static List<TreeNode> InitializeAndFillSingleHierarchicColumns(TreeNodeCollection objHierarchicNodeCollection, HierarchicInfo objCurrentInfoLevel)
            {
                IEnumerable<string> objColumnNames = GetColumnNamesFromBindedSource(objCurrentInfoLevel.BindedSource);

                // Prepare a list for the nodes in this hierarchy level
                List<TreeNode> objNodesHierarchyList = new List<TreeNode>();

                foreach (string strColumnName in objColumnNames)
                {
                    bool blnIsChecked = objCurrentInfoLevel.HiddenColumns.IndexOf(strColumnName) == -1;

                    // Create the node
                    DataGridViewColumnTreeNode objNode = new DataGridViewColumnTreeNode(strColumnName, blnIsChecked);

                    // Add to the TreeView
                    objHierarchicNodeCollection.Add(objNode);

                    // Add the the 'return' list
                    objNodesHierarchyList.Add(objNode);
                }

                return objNodesHierarchyList;
            }

            /// <summary>
            /// Gets the column names from binded source.
            /// </summary>
            /// <param name="objBindingSource">The obj binding source.</param>
            /// <returns></returns>
            private static IEnumerable<string> GetColumnNamesFromBindedSource(BindingSource objBindingSource)
            {
                // Go through all properties in the currency
                foreach (System.ComponentModel.PropertyDescriptor objColumnProperty in objBindingSource.CurrencyManager.GetItemProperties())
                {
                    // Check if assignable from IList (see DataGridViewDataConnection.GetCollectionOfBoundDataGridViewColumns)
                    if (!typeof(System.Collections.IList).IsAssignableFrom(objColumnProperty.PropertyType))
                    {
                        yield return objColumnProperty.Name;
                    }
                }
            }

            /// <summary>
            /// Initializes the component.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjHierarchyFilter = new ComboBox();
                this.mobjCancel = new ColumnChooserButton();
                this.mobjOk = new ColumnChooserButton();
                this.mobjButtons = new Panel();
                this.mobjTreeColumnsViewer = new TreeView();
                //
                // objColumnsViewer
                //
                this.mobjTreeColumnsViewer.Dock = DockStyle.Fill;
                this.mobjTreeColumnsViewer.ShowLines = false;
                this.mobjTreeColumnsViewer.ShowPlusMinus = false;
                this.mobjTreeColumnsViewer.CheckBoxes = true;
                this.mobjTreeColumnsViewer.TreeViewNodeSorter = mobjDataGridView.ColumnChooserSorter;
                //
                //btnCancel
                //
                this.mobjCancel.Text = SR.GetString("WGLablesCancel");
                this.mobjCancel.Anchor = AnchorStyles.None;
                this.mobjCancel.Location = new Point(111, 3);
                this.mobjCancel.Click += new EventHandler(btnCancel_Click);
                //
                //btnOk
                //
                this.mobjOk.Text = SR.GetString("WGLabelsOk");
                this.mobjOk.Anchor = AnchorStyles.None;
                this.mobjOk.Location = new Point(15, 3);
                this.mobjOk.Click += new EventHandler(btnOk_Click);
                //
                //pnlButtons
                //
                this.mobjButtons.Dock = DockStyle.Bottom;
                this.mobjButtons.Size = new Size(200, 29);
                this.mobjButtons.Controls.Add(this.mobjCancel);
                this.mobjButtons.Controls.Add(this.mobjOk);
                //
                // cboViewTypeChooser
                //
                this.mobjHierarchyFilter.Dock = DockStyle.Top;
                this.mobjHierarchyFilter.Height = 21;
                this.mobjHierarchyFilter.Items.Add(new AllHierarchys());
                this.mobjHierarchyFilter.SelectedIndex = 0;
                this.mobjHierarchyFilter.SelectedIndexChanged += new EventHandler(cboViewTypeChooser_SelectedIndexChanged);
                this.mobjHierarchyFilter.DropDownStyle = ComboBoxStyle.DropDownList;

                this.Controls.Add(this.mobjTreeColumnsViewer);
                this.Controls.Add(this.mobjButtons);
                this.Controls.Add(this.mobjHierarchyFilter);

                this.FormBorderStyle = Forms.FormBorderStyle.SizableToolWindow;
                this.Text = SR.GetString("DataGridView_ChooseShowHideColumns");
                this.DialogType = DialogTypes.MainWindow;
                this.Size = new Size(225, 550);
            }

            private TreeView mobjTreeColumnsViewer;
            private ColumnChooserButton mobjCancel;
            private ColumnChooserButton mobjOk;
            private Panel mobjButtons;
            private ComboBox mobjHierarchyFilter;

            #region Event listeners

            /// <summary>
            /// Handles the SelectedIndexChanged event of the cboViewTypeChooser control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            void cboViewTypeChooser_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Get the selected value
                object objSelectedValue = mobjHierarchyFilter.Items[mobjHierarchyFilter.SelectedIndex];

                // Indication id we need to expand all nodes
                bool blnIsExpandAll = false;

                // Holder for the node list that needs to be shown
                IEnumerable<TreeNode> objNewRootNodes = null;

                // Clear the TreeView
                this.mobjTreeColumnsViewer.Nodes.Clear();

                // 'All' option
                if (objSelectedValue is AllHierarchys)
                {
                    // Add the root nodes
                    objNewRootNodes = this.mobjRootNodeColumns;

                    // Expand all
                    blnIsExpandAll = true;
                }
                else if (objSelectedValue is RootDataGridViewWithName)
                {
                    // Only root
                    objNewRootNodes = this.mobjRootNodeColumns;
                }
                else if (objSelectedValue is HierarchicInfo)
                {
                    // A non root grid
                    objNewRootNodes = this.mobjNodesIndexedByTheirHierarchyLevel[objSelectedValue as HierarchicInfo];
                }

                foreach (TreeNode objTreeNode in objNewRootNodes)
                {
                    // Add the nodes to the TreeView
                    this.mobjTreeColumnsViewer.Nodes.Add(objTreeNode);
                }

                // Expand/Collapse all
                if (blnIsExpandAll)
                {
                    this.mobjTreeColumnsViewer.ExpandAll();
                }
                else
                {
                    this.mobjTreeColumnsViewer.CollapseAll();
                }
            }

            /// <summary>
            /// Updates the owning dialog.
            /// </summary>
            private void UpdateOwningDialog()
            {
                ColumnChooserDialog objDialog = this.CommonDialogOwner as ColumnChooserDialog;
                
                if (objDialog != null)
                {
                    List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> objChosenColumns = new List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>>();

                    foreach (DataGridViewColumnTreeNode objNode in this.mobjRootNodeColumns)
                    {
                        DataGridViewColumn objColumn = objNode.Column;

                        if (objColumn!=null)
                        {
                            ColumnCheckedStatus objStatus = new ColumnCheckedStatus();
                            objStatus.IsChecked = objNode.Checked;
                            objStatus.IsChanged = objNode.Checked != objNode.InitialCheckedState;
                            objChosenColumns.Add(new KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>(objColumn, objStatus));
                        }
                    }

                    objDialog.ChosenRootColumns = objChosenColumns;

                    // Iterate through the hierarchic levels
                    foreach (HierarchicInfo objInfo in this.mobjNodesIndexedByTheirHierarchyLevel.Keys)
                    {
                        List<KeyValuePair<string, ColumnCheckedStatus>> objColumnsChooseIndicator = new List<KeyValuePair<string, ColumnCheckedStatus>>();

                        objDialog.ChosenColumnsIndexByTheirHierarchy.Add(objInfo, objColumnsChooseIndicator);

                        // Iterate through every node in this level
                        foreach (DataGridViewColumnTreeNode objNode in this.mobjNodesIndexedByTheirHierarchyLevel[objInfo])
                        {
                            ColumnCheckedStatus objStatus = new ColumnCheckedStatus();

                            objStatus.IsChecked = objNode.Checked;
                            objStatus.IsChanged = objNode.Checked != objNode.InitialCheckedState;

                            objColumnsChooseIndicator.Add(new KeyValuePair<string, ColumnCheckedStatus>(objNode.ColumnName, objStatus));
                        }
                    }
                }
            }
            /// <summary>
            /// Handles the Click event of the btnCancel control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            void btnCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = Forms.DialogResult.Cancel;
                this.Close();
            }
            /// <summary>
            /// Handles the Click event of the btnOk control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            void btnOk_Click(object sender, EventArgs e)
            {
                UpdateOwningDialog();

                this.DialogResult = Forms.DialogResult.OK;
                this.Close();
            }

            #endregion Event listeners

            #region Helper Classes

            /// <summary>
            /// 
            /// </summary>
            private class AllHierarchys
            {
                /// <summary>
                /// Returns a <see cref="System.String"/> that represents this instance.
                /// </summary>
                /// <returns>
                /// A <see cref="System.String"/> that represents this instance.
                /// </returns>
                public override string ToString()
                {
                    return SR.GetString("WGLablesAll"); ;
                }
            }

            /// <summary>
            /// A helper class for the root node
            /// </summary>
            private class RootDataGridViewWithName
            {
                private DataGridView mobjDataGridView;

                /// <summary>
                /// Returns a <see cref="System.String"/> that represents this instance.
                /// </summary>
                /// <returns>
                /// A <see cref="System.String"/> that represents this instance.
                /// </returns>
                public override string ToString()
                {
                    if (this.mobjDataGridView is HierarchicDataGridView)
                    {
                        return (this.mobjDataGridView as HierarchicDataGridView).ContainingRow.RelatedHierarchyInfo.ToString();
                    }
                    return this.mobjDataGridView.Name;
                }

                #region C'tors

                /// <summary>
                /// Initializes a new instance of the <see cref="RootDataGridViewWithName"/> class.
                /// </summary>
                /// <param name="mobjDataGridView">The mobj data grid view.</param>
                public RootDataGridViewWithName(DataGridView mobjDataGridView)
                {
                    this.mobjDataGridView = mobjDataGridView;
                }

                #endregion C'tors
            }

            /// <summary>
            /// 
            /// </summary>
			[Serializable()]
            private class DataGridViewColumnTreeNode : TreeNode
            {
                #region Class members

                private string mstrColumnName;
                private DataGridViewColumn mobjColumn;
                private bool mblnInitialCheckedState;

                #endregion Class members

                #region C'tors

                /// <summary>
                /// Initializes a new instance of the <see cref="DataGridViewColumnTreeNode"/> class.
                /// </summary>
                /// <param name="strColumnName">Name of the STR column.</param>
                /// <param name="blnInitialCheckedState">if set to <c>true</c> [BLN initial checked state].</param>
                public DataGridViewColumnTreeNode(string strColumnName, bool blnInitialCheckedState)
                    : this(strColumnName, blnInitialCheckedState, null)
                { }

                /// <summary>
                /// Initializes a new instance of the <see cref="DataGridViewColumnTreeNode"/> class.
                /// </summary>
                /// <param name="strColumnName">Name of the STR column.</param>
                /// <param name="blnInitialCheckedState">if set to <c>true</c> [BLN initial checked state].</param>
                /// <param name="objColumn">The obj column.</param>
                public DataGridViewColumnTreeNode(string strColumnName, bool blnInitialCheckedState, DataGridViewColumn objColumn)
                    :base(strColumnName)
                {
                    this.mstrColumnName = strColumnName;
                    this.mobjColumn = objColumn;
                    this.Checked = this.mblnInitialCheckedState = blnInitialCheckedState;
                }

                #endregion C'tors

                #region Properties

                /// <summary>
                /// Gets or sets the name of the column.
                /// </summary>
                /// <value>
                /// The name of the column.
                /// </value>
                internal string ColumnName
                {
                    get { return mstrColumnName; }
                    set { mstrColumnName = value; }
                }

                /// <summary>
                /// Gets or sets the column.
                /// </summary>
                /// <value>
                /// The column.
                /// </value>
                internal DataGridViewColumn Column
                {
                    get { return mobjColumn; }
                    set { mobjColumn = value; }
                }

                /// <summary>
                /// Gets or sets a value indicating whether [initial checked state].
                /// </summary>
                /// <value>
                ///   <c>true</c> if [initial checked state]; otherwise, <c>false</c>.
                /// </value>
                internal bool InitialCheckedState
                {
                    get { return mblnInitialCheckedState; }
                    set { mblnInitialCheckedState = value; }
                }

                #endregion Properties
            }

            #endregion Helper Classes

        }

    }

    /// <summary>
    /// 
    /// </summary>
    internal class ColumnCheckedStatus
    {
        private bool mblnIsChecked;
        private bool mblnIsChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsChecked
        {
            get { return mblnIsChecked; }
            set { mblnIsChecked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is changed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is changed; otherwise, <c>false</c>.
        /// </value>
        public bool IsChanged
        {
            get { return mblnIsChanged; }
            set { mblnIsChanged = value; }
        }
    }
}

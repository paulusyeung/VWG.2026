using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using WinForms = System.Windows.Forms;
using WebGUIForms = Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design.Editors.Resources.Objects
{
    #region DataGridViewGroupingColumnsControl class

    /// <summary>
    /// Represents GroupingColumns Design time collection editor.
    /// </summary>
    public partial class DataGridViewGroupingColumnsControl : WinForms.UserControl
    {
        #region Members

        private DataGridView mobjDataGridView = null;

        #endregion

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewGroupingColumnsControl"/> class.
        /// </summary>
        public DataGridViewGroupingColumnsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewGroupingColumnsControl"/> class.
        /// </summary>
        /// <param name="objDataGridView">The obj data grid view.</param>
        public DataGridViewGroupingColumnsControl(WebGUIForms.DataGridView objDataGridView)
            : this()
        {
            // Init members.
            mobjDataGridView = objDataGridView;

            if (mobjDataGridView != null)
            {
                // Fill targets list.
                foreach (string strGroupingColumnDataPropertyName in mobjDataGridView.GroupingColumns)
                {

                    string strColumnName = this.mobjDataGridView.Columns.GetRealDataMemberForProposedMember(strGroupingColumnDataPropertyName);

                    DataGridViewColumn objDataGridViewColumn = mobjDataGridView.Columns[strColumnName];

                    if (objDataGridViewColumn != null)
                    {
                        mobjTargetListBox.Items.Add(new DataGridViewColumnItem(objDataGridViewColumn));
                    }
                }

                // Fill sources list.
                foreach (WebGUIForms.DataGridViewColumn objDataGridViewColumn in mobjDataGridView.Columns)
                {
                    if (!mobjDataGridView.GroupingColumns.Contains(objDataGridViewColumn.DataPropertyName))
                    {
                        mobjSourceListBox.Items.Add(new DataGridViewColumnItem(objDataGridViewColumn));
                    }
                }
            }

            // Initialize buttons availability.
            this.InitializeSourceButtons();
            this.InitializeTargetButtons();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected columns -- return object of EditValue.
        /// </summary>
        public UniqueObservableCollection<string> SelectedColumns
        {
            get
            {
                UniqueObservableCollection<string> arrSelectedColumns = new UniqueObservableCollection<string>();

                // Return targets.
                foreach (DataGridViewColumnItem objDataGridViewColumnItem in mobjTargetListBox.Items)
                {
                    arrSelectedColumns.Add(objDataGridViewColumnItem.DataGridViewColumn.DataPropertyName);
                }

                return arrSelectedColumns;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [up button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnUpButtonClick(object sender, EventArgs e)
        {
            // Move selected item up.
            MoveListItemUpDown(true);
        }

        /// <summary>
        /// Moves the list item up-down.
        /// </summary>
        /// <param name="blnMoveUp">if set to <c>true</c> [BLN move up].</param>
        private void MoveListItemUpDown(bool blnMoveUp)
        {
            // Get selected index.
            int intSelectedIndex = mobjTargetListBox.SelectedIndex;

            // Get selected item.
            object objSelectedItem = mobjTargetListBox.SelectedItem;

            // Remove and insert the selected item.
            mobjTargetListBox.Items.RemoveAt(intSelectedIndex);
            mobjTargetListBox.Items.Insert(intSelectedIndex + (blnMoveUp ? -1 : 1), objSelectedItem);

            mobjTargetListBox.SelectedItems.Add(objSelectedItem);
        }

        /// <summary>
        /// Called when [down button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnDownButtonClick(object sender, EventArgs e)
        {
            // Move selected item down.
            MoveListItemUpDown(false);
        }

        /// <summary>
        /// Called when [target list box selected index changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnTargetListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // Initialize left/up/down buttons.
            InitializeTargetButtons();
        }

        /// <summary>
        /// Initializes the target buttons.
        /// </summary>
        private void InitializeTargetButtons()
        {
            mobjUpButton.Enabled = mobjTargetListBox.SelectedIndex > 0;
            mobjDownButton.Enabled = mobjTargetListBox.SelectedIndex < mobjTargetListBox.Items.Count - 1;
            mobjLeftButton.Enabled = mobjTargetListBox.SelectedIndex != -1;
        }

        /// <summary>
        /// Called when [source list box selected index changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSourceListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // Initialize right button.
            InitializeSourceButtons();
        }

        /// <summary>
        /// Initializes the source buttons.
        /// </summary>
        private void InitializeSourceButtons()
        {
            mobjRightBtton.Enabled = mobjSourceListBox.SelectedIndex != -1;
        }

        /// <summary>
        /// Called when [left button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnLeftButtonClick(object sender, EventArgs e)
        {
            // Get selected item.
            object objSelectedItem = mobjTargetListBox.SelectedItem;

            // Return it to source list.
            mobjTargetListBox.Items.Remove(objSelectedItem);
            mobjSourceListBox.Items.Add(objSelectedItem);
        }

        /// <summary>
        /// Called when [right btton click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnRightButtonClick(object sender, EventArgs e)
        {
            // Get selected item.
            object objSelectedItem = mobjSourceListBox.SelectedItem;

            // Put it to target list.
            mobjSourceListBox.Items.Remove(objSelectedItem);
            mobjTargetListBox.Items.Add(objSelectedItem);
        }

        #endregion
    }

    #endregion DataGridViewGroupingColumnsControl class


    #region DataGridViewColumnItem Class

    /// <summary>
    /// Represents DataGridViewColumn as list item.
    /// </summary>
    class DataGridViewColumnItem
    {
        #region Members

        private WebGUIForms.DataGridViewColumn mobjDataGridViewColumn = null;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the data grid view column.
        /// </summary>
        internal WebGUIForms.DataGridViewColumn DataGridViewColumn
        {
            get
            {
                return mobjDataGridViewColumn;
            }
        }

        #endregion Properties

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewColumnItem"/> class.
        /// </summary>
        /// <param name="objDataGridViewColumn">The obj data grid view column.</param>
        public DataGridViewColumnItem(WebGUIForms.DataGridViewColumn objDataGridViewColumn)
        {
            mobjDataGridViewColumn = objDataGridViewColumn;
        }

        #endregion C'tors

        #region Methods

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (mobjDataGridViewColumn != null)
            {
                return string.Format("{0}{1}", mobjDataGridViewColumn.Name, !string.IsNullOrEmpty(mobjDataGridViewColumn.DataPropertyName) ? string.Format(" ({0})", mobjDataGridViewColumn.DataPropertyName) : string.Empty);
            }

            return base.ToString();
        }

        #endregion Methods
    }

    #endregion DataGridViewColumnItem Class
}

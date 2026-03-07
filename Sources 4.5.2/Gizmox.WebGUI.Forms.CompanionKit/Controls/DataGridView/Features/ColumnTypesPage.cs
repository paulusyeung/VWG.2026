#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI;

#endregion

namespace CompanionKit.Controls.DataGridView.Features
{
    public partial class ColumnTypesPage : UserControl
    {
        public ColumnTypesPage()
        {
            InitializeComponent();
            // Add custom ComboBox column to DataGridView
            DataGridViewCustomComboBoxColumn mobjDataGridViewCustomComboBoxColumn = new DataGridViewCustomComboBoxColumn();
            mobjDataGridViewCustomComboBoxColumn.Width = 80;
            this.mobjDataGridView.Columns.Add(mobjDataGridViewCustomComboBoxColumn);

            // Add custom Ellipsis column to DataGridView
            DataGridViewEllipsisColumn mobjEllipsisColumn = new DataGridViewEllipsisColumn();
            mobjEllipsisColumn.Width = 85;
            this.mobjDataGridView.Columns.Add(mobjEllipsisColumn);
            
            // Fill up DataGridView
            Gizmox.WebGUI.Common.Resources.ResourceHandle mobjPhotoResource = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("32x32.Photo.png");
            this.mobjDataGridView.Rows.Add(new object[] { "1", "User1", "john@gmail.com", "+18-800-1234565", true, "2000", mobjPhotoResource });
            this.mobjDataGridView.Rows.Add(new object[] { "2", "User2", "john@gmail.com", "+18-800-1234565", true, "2001", mobjPhotoResource });
            this.mobjDataGridView.Rows.Add(new object[] { "3", "User2", "john@gmail.com", "+18-800-1234565", false, "1995", mobjPhotoResource });
            this.mobjDataGridView.Rows.Add(new object[] { "4", "User3", "john@gmail.com", "+18-800-1234565", true, "1999", mobjPhotoResource });
            this.mobjDataGridView.Rows.Add(new object[] { "5", "User4", "john@gmail.com", "+18-800-1234565", false, "2009", mobjPhotoResource });

            this.RegisterEllipsisEventhandler();
        }

        #region Register Ellipsis Handler
        private void RegisterEllipsisEventhandler()
        {
            foreach (DataGridViewRow objRow in this.mobjDataGridView.Rows )
            {
                foreach (DataGridViewCell objCell in objRow.Cells)
                {
                    if (objCell.GetType() == typeof(DataGridViewEllipsisCell))
                        ((DataGridViewEllipsisCell)objCell).Ellipsis += this.EllipsisEventHandler;
                }
            }
        }

        private void EllipsisEventHandler(object  obj, EventArgs e)
        {
            DataGridViewEllipsisCell objCell = obj as DataGridViewEllipsisCell;
            if (objCell == null || objCell.Value == null || string.IsNullOrEmpty(objCell.Value.ToString().Trim()))
                MessageBox.Show ("Ellipsis cell has no value");
            else
                MessageBox.Show ("Ellipsis cell's value = " + objCell.Value.ToString());
        }
        #endregion

        #region EllipsisColumn
        /// <summary>
        /// Ellipsis cell consist of a docked to right button and a docked fill TextBox
        /// The cell's panel is used to display the controls
        /// </summary>
        public class DataGridViewEllipsisCell : DataGridViewTextBoxCell
        {
            Gizmox.WebGUI.Forms.Button objButton = null;
            Gizmox.WebGUI.Forms.TextBox objTextbox = null;

            public event EventHandler Ellipsis;

            public DataGridViewEllipsisCell() : base()
            {
                // Get reference to cell's panel
                DataGridViewCellPanel objPanel = this.Panel;

                // Create the button
                objButton = new Gizmox.WebGUI.Forms.Button();
                objButton.Width = 30;
                objButton.Text = "...";
                objButton.Dock = DockStyle.Right;
                objButton.Click += this.buttonClick;

                // Create the textbox
                objTextbox = new Gizmox.WebGUI.Forms.TextBox();
                objTextbox.Dock = DockStyle.Fill;

                // Wire the TextChanged event to update the underlying cell's value
                objTextbox.TextChanged += this.textChanged;

                // Add the controls
                objPanel.Controls.Add(objTextbox);
                objPanel.Controls.Add(objButton);

                // Activate the panel
                objPanel.Visible = true;
                this.Colspan = 1;
                this.Rowspan = 1;
            }

            /// <summary>
            /// When TextBox's text is update, update to underlying cell's value
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void textChanged(object sender, EventArgs e)
            {
                this.SetValue(this.RowIndex, objTextbox.Text);
            }

            /// <summary>
            /// When value is set, also set TextBox.Text
            /// </summary>
            /// <param name="intRowIndex"></param>
            /// <param name="objValue"></param>
            /// <returns></returns>
            protected override bool SetValue(int intRowIndex, object objValue)
            {
                if (objTextbox.Text != (string) objValue)
                    objTextbox.Text = (string)objValue;
                return base.SetValue(intRowIndex, objValue);
            }

            /// <summary>
            /// Underlying cell's value always determines the value. Update TextBox.Text if required.
            /// </summary>
            /// <param name="intRowIndex"></param>
            /// <returns></returns>
            protected override object GetValue(int intRowIndex)
            {
                string strValue = (string) base.GetValue(intRowIndex);
                if (objTextbox.Text != strValue)
                    objTextbox.Text = strValue;
                return strValue;
            }

            /// <summary>
            /// On Button.Click, raise the Ellipsis event for the cell
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void buttonClick(object sender, EventArgs e)
            {
                // sender will be the Cell
                if (this.Ellipsis != null)
                    this.Ellipsis(this, EventArgs.Empty);
            }

            /// <summary>
            /// Make sure Panel's controls follow cell's ReadOnly setting when cell is rendered
            /// </summary>
            /// <param name="objWriter"></param>
            protected override void RenderReadOnlyAttribute(IAttributeWriter objWriter)
            {
                if (objTextbox.ReadOnly != base.ReadOnly)
                    objTextbox.ReadOnly = base.ReadOnly;
                if (objButton.Enabled != !base.ReadOnly)
                    objButton.Enabled = !base.ReadOnly;
                base.RenderReadOnlyAttribute(objWriter);
            }

        }


        public class DataGridViewEllipsisColumn : DataGridViewTextBoxColumn 
        {
            public DataGridViewEllipsisColumn() : base()
            {
                // Set a custom template for a cell of DataGridView.
                this.CellTemplate = new DataGridViewEllipsisCell();

                this.HeaderText = "Ellipsis Column";
                this.Name = "ellipsisColumn";
            }

        }
        #endregion

        #region CustomComboboxColumn
        private class DataGridViewCustomComboBoxCell : DataGridViewComboBoxCell
        {
            /// <summary>
            /// The form is used as custom DropDown control.
            /// </summary>
            private global::CompanionKit.Controls.ComboBox.Features.TreeViewComboBoxForm _treeViewForm = null;

            /// <summary>
            /// Occurs when selected item changed.
            /// </summary>
            public event EventHandler ValueChanged;

            /// <summary>
            /// Initializes a new instance of the <see cref="TreeViewComboBox"/> class.
            /// </summary>
            public DataGridViewCustomComboBoxCell()
            {
                _treeViewForm = new CompanionKit.Controls.ComboBox.Features.TreeViewComboBoxForm();
                _treeViewForm.Closed += new EventHandler(OnFormClosed);
            }

            /// <summary>
            /// Called when form is closed.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void OnFormClosed(object sender, EventArgs e)
            {
                if (((global::Gizmox.WebGUI.Forms.Form)sender).DialogResult == DialogResult.OK)
                {
                    if (this._treeViewForm.Tree.SelectedNode != null)
                    {
                            
                        this.ValueType = typeof(string);
                        this.Value = this._treeViewForm.Tree.SelectedNode.Text;
                    }
                    if (ValueChanged != null)
                    {
                        ValueChanged(this, EventArgs.Empty);
                    }
                }
            }

            /// <summary>
            /// Gets a value indicating whether this instance has a custom drop down.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
            /// </value>
            protected override bool IsCustomDropDown
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            /// Gets the custom form to display as drop down
            /// </summary>
            /// <returns></returns>
            protected override Gizmox.WebGUI.Forms.Form GetCustomDropDown()
            {
                _treeViewForm.DialogResult = DialogResult.None;
                return _treeViewForm;
                
            }

            /// <summary>
            /// Make sure the selected value exists in the ComboBox's Items collection, else it will not render
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            /// <param name="objFormatedValue"></param>
            protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
            {
                if (this.Value != null)
                {
                    if (!this.Items.Contains(this.Value))
                        this.Items.Add(this.Value);
                }
                base.RenderCellValue(objContext, objWriter, objFormatedValue);
            }

        }

        /// <summary>
        /// This class represents custom column type that is inherited from the DataGridViewComboBoxColumn column type.
        /// </summary>
        private class DataGridViewCustomComboBoxColumn : DataGridViewComboBoxColumn
        {
            public DataGridViewCustomComboBoxColumn()
            {
                // Set a custom template for a cell of DataGridView.
                this.CellTemplate = new DataGridViewCustomComboBoxCell();
                
                // Set dafault column property values
                this.AutoComplete = false;
                this.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
                this.DataPropertyName = "";
                this.DefaultCellStyle = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
                this.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
                this.DisplayStyle = Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
                this.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
                this.HeaderText = "Custom ComboBox";
                this.Name = "customComboBox";
                this.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
                this.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
                this.Width = 100;
            }
            
        }
        #endregion

    }
}

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DataGridView.Features
{
    public partial class ExtendedHeadersPage : UserControl
    {
        //Define ExtendedHeader UserControl
        public ExtendedHeaderUserControl mobjUserControl = new ExtendedHeaderUserControl();
        public ExtendedHeadersPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ExtendedHeadersPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ExtendedHeadersPage_Load(object sender, EventArgs e)
        {
            //Fill DGV with 3 rows of data
            mobjDGV.Rows.Add("row 1", "item 1", "value 1");
            mobjDGV.Rows.Add("row 2", "item 2", "value 2");
            mobjDGV.Rows.Add("row 3", "item 3", "value 3");

            //Add a row to ExtendedColumnHeader
            mobjDGV.ExtendedColumnHeaders.Rows.Add(new ExtendedHeaderRowData(HeightMode.Custom, 100));
            mobjDGV.ExtendedColumnHeaders.Rows[0].Height = 50;

            //Define AddButton
            Gizmox.WebGUI.Forms.Button mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            mobjAddButton.Location = new System.Drawing.Point(0, 0);
            mobjAddButton.Size = new System.Drawing.Size(104, 23);
            mobjAddButton.Text = "Add row";
            mobjAddButton.Click += new EventHandler(mobjAddButton_Click);
            
            //Define Remove Button
            Gizmox.WebGUI.Forms.Button mobjRemoveButton = new Gizmox.WebGUI.Forms.Button();
            mobjRemoveButton.Location = new System.Drawing.Point(0, 25);
            mobjRemoveButton.Size = new System.Drawing.Size(104, 23);
            mobjRemoveButton.Text = "Remove row";
            mobjRemoveButton.Click += new EventHandler(mobjRemoveButton_Click);
            
            //Add buttons to ExtendedHeader UserControl
            mobjUserControl.Controls.Add(mobjRemoveButton);
            mobjUserControl.Controls.Add(mobjAddButton);
            mobjUserControl.ColIndex = 0;
            //Add UserControl to ExtendedHeader
            mobjDGV.ExtendedColumnHeaders.HeaderControls.Add(mobjUserControl);
        }

        /// <summary>
        /// Handles the Click event of the mobjAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            //Add row in DGV
            mobjDGV.Rows.Add("new item");
        }

        /// <summary>
        /// Handles the Click event of the mobjRemoveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRemoveButton_Click(object sender, EventArgs e)
        {
            //If one row is selected in DGV
            if (mobjDGV.SelectedRows.Count == 1)
            {
                //If new row is selected in DGV
                if (mobjDGV.SelectedRows[0].IsNewRow)
                    MessageBox.Show("You cannot remove a new row.");
                //If not a new row is selected in DGV
                else
                    mobjDGV.Rows.RemoveAt(mobjDGV.SelectedRows[0].Index);
            }
            //If more then one row is selected in DGV
            else
                MessageBox.Show("Please select one row to remove.");
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjNUD_ValueChanged(object sender, EventArgs e)
        {
            //Change the number of column ExtendedHeader belongs to
            mobjUserControl.ColIndex = Convert.ToInt32(mobjNUD.Value) - 1;
            mobjDGV.Update();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjIsExtHeaderVisible control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIsExtHeaderVisible_CheckedChanged(object sender, EventArgs e)
        {
            //Show or hide Extended ColumnHeader
            mobjDGV.ExtendedColumnHeaders.ShowExtendedColumnHeader = mobjIsExtHeaderVisible.Checked;
        }


    }
}
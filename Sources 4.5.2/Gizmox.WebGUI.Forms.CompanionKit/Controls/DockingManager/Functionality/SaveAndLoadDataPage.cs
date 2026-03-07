using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DockingManager.Functionality
{
    public partial class SaveAndLoadDataPage : UserControl
    {
        //Byte array for windows serialization
        byte[] marrByteArray;
        //User index global variable
        int mintUserIndex = 0; 

        public SaveAndLoadDataPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            //Adds new window
            DockingWindow mobjDockingWindow = new DockingWindow();
            FillDockingWindow(mobjDockingWindow);
            mobjDockingManager.AddTabbedWindows(mobjDockingWindow);
        }

        /// <summary>
        /// Handles the Click event of the mobjSaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSaveButton_Click(object sender, EventArgs e)
        {
            //Serializates all windows
            marrByteArray = mobjDockingManager.SaveData();
        }

        /// <summary>
        /// Handles the Click event of the mobjLoadButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjLoadButton_Click(object sender, EventArgs e)
        {
            //If byte array is not null - deserialize windows
            if (marrByteArray != null)
            {
                mobjDockingManager.LoadData(marrByteArray);
            }
        }

        /// <summary>
        /// Fills the docking window.
        /// </summary>
        /// <param name="objDockingWindow">The obj docking window.</param>
        void FillDockingWindow(DockingWindow objDockingWindow)
        {
            //Settings up DockingWindow control
            objDockingWindow.Text = mobjNorthwindDataSet.Customers[mintUserIndex].ContactName;
            objDockingWindow.HeaderText = mobjNorthwindDataSet.Customers[mintUserIndex].ContactTitle;
            //Increase counter or reset it if value more than customer count
            mintUserIndex = mintUserIndex == (mobjNorthwindDataSet.Customers.Count - 1) ? 0 : mintUserIndex + 1;
        }

        /// <summary>
        /// Handles the Load event of the SaveAndLoadDataPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SaveAndLoadDataPage_Load(object sender, EventArgs e)
        {
            //Fill up table adapter with data from table
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers); 
        }
    }
}
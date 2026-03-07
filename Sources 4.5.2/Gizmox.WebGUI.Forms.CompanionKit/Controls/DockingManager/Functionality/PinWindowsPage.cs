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
    public partial class PinWindowsPage : UserControl
    {
        //User index global variable
        int mintUserIndex = 0; 

        public PinWindowsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objPinButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPinButton_Click(object sender, EventArgs e)
        {
            //Pins all windows
            mobjDockingManager.PinAll();
        }

        /// <summary>
        /// Handles the Click event of the objUnpinButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjUnpinButton_Click(object sender, EventArgs e)
        {
            //Unpins all windows
            mobjDockingManager.UnpinAll();
        }

        /// <summary>
        /// Handles the Load event of the PinWindowsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PinWindowsPage_Load(object sender, EventArgs e)
        {
            //Fill up table adapter with data from table
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers); 

            //Creates 5 DockingWindows
            for (int i = 0; i < 5; i++)
            {
                DockingWindow mobjDockingWindow = new DockingWindow();
                FillDockingWindow(mobjDockingWindow);
                mobjDockingManager.AddAutoHiddenWindows(DockStyle.Top, mobjDockingWindow);
            }
        }

        /// <summary>
        /// Fills the docking window.
        /// </summary>
        /// <param name="objDockingWindow">The obj docking window.</param>
        void FillDockingWindow(DockingWindow objDockingWindow)
        {
            //Fills string with User info
            string strUserInfo = string.Format("User Name:{0}\r\nCompany Name:{1}\r\nCountry:{2}\r\nCity:{3}\r\nAddress:{4}\r\nPhone:{5}",
                mobjNorthwindDataSet.Customers[mintUserIndex].ContactName,
                mobjNorthwindDataSet.Customers[mintUserIndex].CompanyName,
                mobjNorthwindDataSet.Customers[mintUserIndex].Country,
                mobjNorthwindDataSet.Customers[mintUserIndex].City,
                mobjNorthwindDataSet.Customers[mintUserIndex].Address,
                mobjNorthwindDataSet.Customers[mintUserIndex].Phone);
            //Creates and fills label control
            Label mobjUserLabel = new Label();
            mobjUserLabel.AutoSize = false;
            mobjUserLabel.Text = strUserInfo;
            mobjUserLabel.Dock = DockStyle.Fill;
            //Settings up DockingWindow control
            objDockingWindow.Text = mobjNorthwindDataSet.Customers[mintUserIndex].ContactName;
            objDockingWindow.HeaderText = mobjNorthwindDataSet.Customers[mintUserIndex].ContactTitle;
            objDockingWindow.Controls.Add(mobjUserLabel);
            //Increase counter or reset it if value more than customer count
            mintUserIndex = mintUserIndex == (mobjNorthwindDataSet.Customers.Count - 1) ? 0 : mintUserIndex + 1;
        }
    }
}
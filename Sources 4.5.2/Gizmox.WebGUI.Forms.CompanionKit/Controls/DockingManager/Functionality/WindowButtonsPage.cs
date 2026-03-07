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
    public partial class WindowButtonsPage : UserControl
    {
        //User index global variable
        int mintUserIndex = 0; 

        public WindowButtonsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCloseCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjDockingManager.ShowCloseButton = mobjCloseCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjDropDownCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjDropDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjDockingManager.ShowDropDownButton = mobjDropDownCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjMaximizeCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMaximizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjDockingManager.ShowMaximizeButton = mobjMaximizeCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjMinimizeCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMinimizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjDockingManager.ShowMinimizeButton = mobjMinimizeCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjPinCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjDockingManager.ShowPinButton = mobjPinCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Load event of the WindowButtonsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WindowButtonsPage_Load(object sender, EventArgs e)
        {
            //Fill up table adapter with data from table
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers); 

            //Creates 5 DockingWindows
            for (int i = 0; i < 5; i++)
            {
                DockingWindow mobjDockingWindow = new DockingWindow();
                FillDockingWindow(mobjDockingWindow);
                mobjDockingManager.AddTabbedWindows(mobjDockingWindow);
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
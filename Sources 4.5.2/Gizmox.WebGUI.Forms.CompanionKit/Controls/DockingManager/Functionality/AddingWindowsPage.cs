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
    public partial class AddingWindowsPage : UserControl
    {
        //User index global variable
        int mintUserIndex = 0; 

        public AddingWindowsPage()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Handles the Click event of the objAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            //Creates new instance of DockingWindow
            DockingWindow mobjDockingWindow = new DockingWindow();
            //Fills DockingWindow  with content
            FillDockingWindow(mobjDockingWindow);
            //Adds new window to DockingManager according to selected type in comboBox
            switch (mobjComboBox.SelectedIndex)
            {
                //AutoHidden
                case 0:
                    //Applies DockStyle to AutoHiddenWindow according to selected value
                    switch (mobjPositionComboBox.SelectedIndex)
                    {
                        //Top
                        case 0:
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Top, mobjDockingWindow);
                            break;
                        //Bottom
                        case 1:
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Bottom, mobjDockingWindow);
                            break;
                        //Left
                        case 2:
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Left, mobjDockingWindow);
                            break;
                        //Right
                        case 3:
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Right, mobjDockingWindow);
                            break;
                    }
                    break;
                //Docked
                case 1:
                    mobjDockingManager.AddDockedWindows(mobjDockingWindow);
                    break;
                //Float
                case 2:
                    mobjDockingManager.AddFloatWindows(mobjDockingWindow);
                    break;
                //Tabbed
                case 3:
                    mobjDockingManager.AddTabbedWindows(mobjDockingWindow);
                    break;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the objComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If AutoHidden type is selected - shows additional comboBox
            if (mobjComboBox.SelectedIndex == 0)
            {
                mobjPositionComboBox.Visible = true;
                mobjPositionLabel.Visible = true;
            }
            //If other type - hides it
            else
            {
                mobjPositionComboBox.Visible = false;
                mobjPositionLabel.Visible = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the objCloseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCloseButton_Click(object sender, EventArgs e)
        {
            //Closes all windows
            mobjDockingManager.CloseAll();
            mobjDockingManager.CloseAllFloatingWindows();
        }

        /// <summary>
        /// Handles the Click event of the objShowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShowButton_Click(object sender, EventArgs e)
        {
            //Shows all windows
            mobjDockingManager.ShowAll();
        }

        /// <summary>
        /// Handles the Load event of the AddingWindowsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddingWindowsPage_Load(object sender, EventArgs e)
        {
            //Fill up table adapter with data from table
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers); 

            //Selects first item in comboBox on load
            mobjComboBox.SelectedIndex = 0;
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
            mintUserIndex = mintUserIndex == (mobjNorthwindDataSet.Customers.Count - 1) ? 0 : mintUserIndex+1;
        }
    }
}
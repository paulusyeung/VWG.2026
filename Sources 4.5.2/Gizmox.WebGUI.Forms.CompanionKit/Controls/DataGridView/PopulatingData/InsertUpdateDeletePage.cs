#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using CompanionKit.Controls.DataGridView.PopulatingData;
using CompanionKit.Controls.DataGridView;


#endregion

namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    public partial class InsertUpdateDeletePage : UserControl
    {
        /// <summary>
        /// Represents list of the selected user ids on which should execute 
        /// selection action. The List is cleared after execution the action.
        /// </summary>
        private List<int> _selectedUserId = new List<int>();

        private bool mblnIsLoadCompleted = false;

        public InsertUpdateDeletePage()
        {
            InitializeComponent();
        }

        private void InsertUpdateDeletePage_Load(object sender, EventArgs e)
        {
            // Fill up the DataGridView
            for (int i = 1; i < 20; ++i)
            {
                this.mobjUserDS.Users.AddUsersRow(string.Format("User{0}", i), 
                                         string.Format("user{0}@gmail.com", i),
                                         string.Format("8-800-236589{0}", i), "Franklin",
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", 
                                         "Tennessee", "37064");
            }

            mblnIsLoadCompleted = true;
        }

        /// <summary>
        /// Handles Popup event for the ContextMenu.
        /// Disables/enables some menu items if some rows is selected.
        /// </summary>
        private void mobjContextMenu_Popup(object sender, EventArgs e)
        {

            if (this.mobjDataGridView.SelectedRows.Count > 1
                || (this.mobjDataGridView.SelectedRows.Count == 1 
                    && !this.mobjDataGridView.SelectedRows[0].IsNewRow))
            {
                this.mobjModifyRowMenuItem.Enabled = true;
                this.mobjRemoveRowMenuItem.Enabled = true;
            }
            else
            {
                this.mobjModifyRowMenuItem.Enabled = false;
                this.mobjRemoveRowMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Handles click event for add menu action.
        /// Opens form for add user. Colosed event is registered 
        /// for the Form and hanler add entered new USer to DataSet.
        /// </summary>
        private void mobjAddRowMenuItem_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Text = "Add User Form";
            userForm.Closed += new EventHandler(mobjUserFormAddUser_Closed);
            userForm.Show();
        }

        /// <summary>
        /// Hadnles Closed event for Added User Form.
        /// Add entered user to DataSet on closing the Form.
        /// </summary>
        private void mobjUserFormAddUser_Closed(object sender, EventArgs e)
        {
            UserForm userForm = sender as UserForm;
            if (userForm.DialogResult == DialogResult.OK)
            {
                this.mobjUserDS.Users.AddUsersRow(userForm.UserName, userForm.Email,
                                              userForm.Phone, userForm.City,
                                              userForm.Address, userForm.Country,
                                              userForm.State, userForm.ZipCode);
            }
        }

        /// <summary>
        /// Handles click event for modify menu action.
        /// Opens form for modify user data. Colosed event is registered 
        /// for the Form and hanler modifies selected User in DataSet.
        /// The Mofify User Form is opened for all selection rows.
        /// </summary>
        private void mobjModifyRowMenuItem_Click(object sender, EventArgs e)
        {   
            _selectedUserId.Clear();
            // Collects all selection user ids in specified List
            for (int i = 0; i < this.mobjDataGridView.SelectedRows.Count; ++i)
            {
                DataGridViewRow mobjDGVRow = this.mobjDataGridView.SelectedRows[i];
                if (!mobjDGVRow.IsNewRow)
                {
                    _selectedUserId.Add(int.Parse(mobjDGVRow.Cells["userIDColumn"].Value.ToString()));
                }
            }
            
            // Show Modify User Form for each selected user.
            ShowUserFormForRow();
        }

        /// <summary>
        /// Hadnles Closed event for Modify User Form.
        /// Modify specified user in DataSet on closing the Form.
        /// </summary>
        private void mobjUserFormModifyUser_Closed(object sender, EventArgs e)
        {

            UserForm userForm = sender as UserForm;
            if (userForm.DialogResult == DialogResult.OK)
            {
                // Get row user for selected user from DataSet.
                UserDS.UsersRow modifyRow = this.mobjUserDS.Users.FindByUserId(userForm.UserID);
                if (modifyRow != null) 
                {
                    modifyRow.UserName = userForm.UserName;
                    modifyRow.UserEmail = userForm.Email;
                    modifyRow.UserPhone = userForm.Phone;
                    modifyRow.UserCity = userForm.City;
                    modifyRow.UserAddress = userForm.Address;
                    modifyRow.UserCountry = userForm.Country;
                    modifyRow.UserState = userForm.State;
                    modifyRow.UserZipCode = userForm.ZipCode;
                    this.mobjUserDS.Users.AcceptChanges();
                }
            }
            // Show Modify User Form for each selected user.
            ShowUserFormForRow();
        }
        /// <summary>
        /// Shows Modify User Form for each selected user.
        /// </summary>
        private void ShowUserFormForRow()
        {
            if (_selectedUserId.Count > 0)
            {
                UserForm mobjUserForm = new UserForm();
                mobjUserForm.Text = "Modify User Form";
                mobjUserForm.Closed += new EventHandler(mobjUserFormModifyUser_Closed);
                
                int userId = _selectedUserId[0];
                _selectedUserId.Remove(userId);

                UserDS.UsersRow mobjModifyRow = this.mobjUserDS.Users.FindByUserId(userId);
                mobjUserForm.UserID = mobjModifyRow.UserId;
                mobjUserForm.UserName = mobjModifyRow.UserName;
                mobjUserForm.Email = mobjModifyRow.UserEmail;
                mobjUserForm.Phone = mobjModifyRow.UserPhone;
                mobjUserForm.City = mobjModifyRow.UserCity;
                mobjUserForm.Address = mobjModifyRow.UserAddress;
                mobjUserForm.Country = mobjModifyRow.UserCountry;
                mobjUserForm.State = mobjModifyRow.UserState;
                mobjUserForm.ZipCode = mobjModifyRow.UserZipCode;
                mobjUserForm.Show();
            }
        }

        /// <summary>
        /// Handles click event for remove menu action.
        /// Removes selected row from the DataSet. If selected row isn't NewLine.
        /// </summary>
        private void mobjRemoveRowMenuItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow mobjRow in this.mobjDataGridView.SelectedRows)
            {
                if (!mobjRow.IsNewRow)
                {
                    int mintUserId = int.Parse(mobjRow.Cells["userIDColumn"].Value.ToString());
                    UserDS.UsersRow mobjModifyRow = this.mobjUserDS.Users.FindByUserId(mintUserId);
                    if (mobjModifyRow != null)
                    {
                        mobjModifyRow.Delete();
                    }
                }
            }
        }

        private void mobjDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (mblnIsLoadCompleted)
            {
                this.mobjDataGridView.Rows[e.RowIndex].Selected = true;
                this.mobjDataGridView.FirstDisplayedScrollingRowIndex = e.RowIndex;
            }

        }
    }
}

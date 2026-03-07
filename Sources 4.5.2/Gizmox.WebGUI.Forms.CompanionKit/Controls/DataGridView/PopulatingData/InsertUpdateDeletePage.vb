Namespace CompanionKit.Controls.DataGridView.PopulatingData

	Public Class InsertUpdateDeletePage

        ''' <summary>
        ''' Represents list of the selected user ids on which should execute 
        ''' selection action. The List is cleared after execution the action.
        ''' </summary>
        ''' <remarks></remarks>
        Private _selectedUserId As List(Of Integer) = New List(Of Integer)

        Private mblnIsLoadCompleted As Boolean = False


        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        Private Sub InsertUpdateDeletePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up the DataGridView
            For i As Integer = 1 To 19
                Me.mobjUserDS.Users.AddUsersRow(String.Format("User{0}", i), String.Format("user{0}@gmail.com", i), String.Format("8-800-236589{0}", i), "Franklin", String.Format("10{0} Murfreeboro Rd.", i), "USA", _
                 "Tennessee", "37064")
            Next

            mblnIsLoadCompleted = True
        End Sub

        ''' <summary>
        ''' Handles Popup event for the ContextMenu.
        ''' Disables/enables some menu items if some rows is selected.
        ''' </summary>
        Private Sub mobjContextMenu_Popup(sender As Object, e As EventArgs) Handles mobjContextMenu.Popup

            If Me.mobjDataGridView.SelectedRows.Count > 1 OrElse (Me.mobjDataGridView.SelectedRows.Count = 1 AndAlso Not Me.mobjDataGridView.SelectedRows(0).IsNewRow) Then
                Me.mobjModifyRowMenuItem.Enabled = True
                Me.mobjRemoveRowMenuItem.Enabled = True
            Else
                Me.mobjModifyRowMenuItem.Enabled = False
                Me.mobjRemoveRowMenuItem.Enabled = False
            End If
        End Sub

        ''' <summary>
        ''' Handles click event for add menu action.
        ''' Opens form for add user. Colosed event is registered 
        ''' for the Form and hanler add entered new USer to DataSet.
        ''' </summary>
        Private Sub mobjAddRowMenuItem_Click(sender As Object, e As EventArgs) Handles mobjAddRowMenuItem.Click
            Dim mobjUserForm As New UserForm()
            mobjUserForm.Text = "Add User Form"
            AddHandler mobjUserForm.Closed, AddressOf mobjUserFormAddUser_Closed
            mobjUserForm.Show()
        End Sub

        ''' <summary>
        ''' Hadnles Closed event for Added User Form.
        ''' Add entered user to DataSet on closing the Form.
        ''' </summary>
        Private Sub mobjUserFormAddUser_Closed(sender As Object, e As EventArgs)
            Dim userForm As UserForm = TryCast(sender, UserForm)
            If userForm.DialogResult = DialogResult.OK Then
                Me.mobjUserDS.Users.AddUsersRow(userForm.UserName, userForm.Email, userForm.Phone, userForm.City, userForm.Address, userForm.Country, _
                 userForm.State, userForm.ZipCode)
            End If
        End Sub

        ''' <summary>
        ''' Handles click event for modify menu action.
        ''' Opens form for modify user data. Colosed event is registered 
        ''' for the Form and hanler modifies selected User in DataSet.
        ''' The Mofify User Form is opened for all selection rows.
        ''' </summary>
        Private Sub mobjModifyRowMenuItem_Click(sender As Object, e As EventArgs) Handles mobjModifyRowMenuItem.Click
            _selectedUserId.Clear()
            ' Collects all selection user ids in specified List
            For i As Integer = 0 To Me.mobjDataGridView.SelectedRows.Count - 1
                Dim mobjDGVRow As DataGridViewRow = Me.mobjDataGridView.SelectedRows(i)
                If Not mobjDGVRow.IsNewRow Then
                    _selectedUserId.Add(Integer.Parse(mobjDGVRow.Cells("userIDColumn").Value.ToString()))
                End If
            Next

            ' Show Modify User Form for each selected user.
            ShowUserFormForRow()
        End Sub

        ''' <summary>
        ''' Hadnles Closed event for Modify User Form.
        ''' Modify specified user in DataSet on closing the Form.
        ''' </summary>
        Private Sub mobjUserFormModifyUser_Closed(sender As Object, e As EventArgs)

            Dim userForm As UserForm = TryCast(sender, UserForm)
            If userForm.DialogResult = DialogResult.OK Then
                ' Get row user for selected user from DataSet.
                Dim modifyRow As UserDS.UsersRow = Me.mobjUserDS.Users.FindByUserId(userForm.UserID)
                If modifyRow IsNot Nothing Then
                    modifyRow.UserName = userForm.UserName
                    modifyRow.UserEmail = userForm.Email
                    modifyRow.UserPhone = userForm.Phone
                    modifyRow.UserCity = userForm.City
                    modifyRow.UserAddress = userForm.Address
                    modifyRow.UserCountry = userForm.Country
                    modifyRow.UserState = userForm.State
                    modifyRow.UserZipCode = userForm.ZipCode
                    Me.mobjUserDS.Users.AcceptChanges()
                End If
            End If
            ' Show Modify User Form for each selected user.
            ShowUserFormForRow()
        End Sub
        ''' <summary>
        ''' Shows Modify User Form for each selected user.
        ''' </summary>
        Private Sub ShowUserFormForRow()
            If _selectedUserId.Count > 0 Then
                Dim mobjUserForm As New UserForm()
                mobjUserForm.Text = "Modify User Form"
                AddHandler mobjUserForm.Closed, AddressOf mobjUserFormModifyUser_Closed

                Dim userId As Integer = _selectedUserId(0)
                _selectedUserId.Remove(userId)

                Dim mobjModifyRow As UserDS.UsersRow = Me.mobjUserDS.Users.FindByUserId(userId)
                mobjUserForm.UserID = mobjModifyRow.UserId
                mobjUserForm.UserName = mobjModifyRow.UserName
                mobjUserForm.Email = mobjModifyRow.UserEmail
                mobjUserForm.Phone = mobjModifyRow.UserPhone
                mobjUserForm.City = mobjModifyRow.UserCity
                mobjUserForm.Address = mobjModifyRow.UserAddress
                mobjUserForm.Country = mobjModifyRow.UserCountry
                mobjUserForm.State = mobjModifyRow.UserState
                mobjUserForm.ZipCode = mobjModifyRow.UserZipCode
                mobjUserForm.Show()
            End If
        End Sub

        ''' <summary>
        ''' Handles click event for remove menu action.
        ''' Removes selected row from the DataSet. If selected row isn't NewLine.
        ''' </summary>
        Private Sub mobjRemoveRowMenuItem_Click(sender As Object, e As EventArgs) Handles mobjRemoveRowMenuItem.Click
            For Each mobjRow As DataGridViewRow In Me.mobjDataGridView.SelectedRows
                If Not mobjRow.IsNewRow Then
                    Dim mintUserId As Integer = Integer.Parse(mobjRow.Cells("userIDColumn").Value.ToString())
                    Dim mobjModifyRow As UserDS.UsersRow = Me.mobjUserDS.Users.FindByUserId(mintUserId)
                    If mobjModifyRow IsNot Nothing Then
                        mobjModifyRow.Delete()
                    End If
                End If
            Next
        End Sub

        Private Sub mobjDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles mobjDataGridView.RowsAdded
            If mblnIsLoadCompleted Then
                Me.mobjDataGridView.Rows(e.RowIndex).Selected = True
                Me.mobjDataGridView.FirstDisplayedScrollingRowIndex = e.RowIndex
            End If

        End Sub
    End Class

End Namespace

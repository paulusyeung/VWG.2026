Namespace CompanionKit.Controls.ClientStorage.Functionality

	Public Class ExecutingQueriesPage

        'Global variables
        Private mblnIsSelectQueryType As Boolean
        Private mstrQueryTypePattern As String = String.Empty
        Private mstrFields As String = String.Empty

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the ExecutingQueriesPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ExecutingQueriesPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Applies ClientStorage control to mainform
            'Note: If Form is using instead of UserControl, this line of code should be replaced to: this.ClientStorage = this.objClientStorage;
            Me.Form.ClientStorage = Me.mobjClientStorage
            'Changes state of CheckBoxList's items
            For i As Integer = 0 To mobjCheckBoxList.Items.Count - 1
                mobjCheckBoxList.SetItemChecked(i, True)
            Next
            'Selects the query type
            mobjRadioButtonSelect.Checked = True
            'Fills ListView on load
            VWGClientContext.Current.Invoke("InititializeDatabase")
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the mobjInitButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjInitButton_ClientClick(objSender As Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjInitButton.ClientClick
            'Calls InititializeDatabase js-function
            objArgs.Context.Invoke("InititializeDatabase")
        End Sub


        ''' <summary>
        ''' Handles the CheckedChanged event of the RadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles mobjRadioButtonDelete.CheckedChanged, mobjRadioButtonInsert.CheckedChanged, mobjRadioButtonSelect.CheckedChanged
            'Defines query pattern according to choosen radioButton
            Select Case DirectCast(sender, Gizmox.WebGUI.Forms.RadioButton).Text
                Case "SELECT"
                    mstrQueryTypePattern = "SELECT {0} FROM 'objClientTable'"
                    mblnIsSelectQueryType = True
                    Exit Select
                Case "INSERT"
                    mstrQueryTypePattern = "INSERT INTO 'objClientTable' ({0}) VALUES ()"
                    mblnIsSelectQueryType = False
                    Exit Select
                Case "DELETE"
                    mstrQueryTypePattern = "DELETE FROM 'objClientTable'"
                    mblnIsSelectQueryType = False
                    Exit Select
            End Select

            ' Cannot run SELECT or INSERT query without fields
            If Not mobjRadioButtonDelete.Checked AndAlso String.IsNullOrEmpty(mstrFields) Then
                mobjQueryTextBox.Text = String.Empty
            Else
                mobjQueryTextBox.Text = String.Format(mstrQueryTypePattern, mstrFields)
            End If
        End Sub

        ''' <summary>
        ''' Handles the ItemCheck event of the mobjCheckBoxList control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBoxList_ItemCheck(objSender As Object, objArgs As ItemCheckEventArgs) Handles mobjCheckBoxList.ItemCheck
            Dim mstrComma As String = String.Empty
            mstrFields = String.Empty

            'Changes visibility of listView's columns
            mobjListView.Columns(objArgs.Index).Visible = IIf(objArgs.NewValue = CheckState.Checked, True, False)

            'Iterate through checklistbox items
            For intItemIndex As Integer = 0 To mobjListView.Columns.Count - 1
                ' If column is visible, add to query fields
                If mobjListView.Columns(intItemIndex).Visible Then
                    mstrFields += mstrComma + mobjCheckBoxList.Items(intItemIndex)
                    mstrComma = ", "
                End If
            Next

            ' Cannot run SELECT or INSERT query without fields
            If String.IsNullOrEmpty(mstrFields) AndAlso Not mobjRadioButtonDelete.Checked Then
                mobjQueryTextBox.Text = String.Empty
            Else
                mobjQueryTextBox.Text = String.Format(mstrQueryTypePattern, mstrFields)
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjRunButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRunButton_Click(sender As Object, e As EventArgs) Handles mobjRunButton.Click
            'Calls js function, if TextBox is not empty
            If Not String.IsNullOrEmpty(mobjQueryTextBox.Text) Then
                VWGClientContext.Current.Invoke("ExecuteQuery", mobjQueryTextBox.Text, mblnIsSelectQueryType)
            End If
        End Sub

	End Class

End Namespace
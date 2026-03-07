Namespace CompanionKit.Controls.DataGridView.Features

	Public Class VirtualModePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjFillDGVButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjFillDGVButton_Click(sender As Object, e As EventArgs) Handles mobjFillDGVButton.Click
            'Clears all records if such exist
            If mobjDGVUserDS.Users.Count > 0 Then
                mobjDGVUserDS.Users.Clear()
            End If
            ' Fills up the DataGridView.
            For i As Integer = 1 To 2999
                mobjDGVUserDS.Users.AddUsersRow(String.Format("User{0}", i), String.Format("user{0}@gmail.com", i), String.Format("8-800-236589{0}", i), "Franklin", String.Format("10{0} Murfreeboro Rd.", i), "USA", _
                 "Tennessee", "37064")
            Next
            'Creates temp Column array and fills with current values 
            Dim mobjTempCollection As DataGridViewColumn() = New DataGridViewColumn(mobjDataGridView.Columns.Count - 1) {}
            mobjDataGridView.Columns.CopyTo(mobjTempCollection, 0)
            'Temporary unbinding datasource
            mobjDataGridView.DataSource = Nothing
            'If DVG doesn't contain any column - fills with temp array  
            If mobjDataGridView.Columns.Count = 0 Then
                mobjDataGridView.Columns.AddRange(mobjTempCollection)
            End If
            'Shows warning message with possibility to stop binding operation or continue it
            MessageBox.Show("Press 'Yes' to cancel this operation or press 'No' to continue (probably, page will fall)", "Page is not responding", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, AddressOf OnTimeout)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjFillVDGVButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjFillVDGVButton_Click(sender As Object, e As EventArgs) Handles mobjFillVDGVButton.Click
            'Clears all records if such exist
            If mobjVDGVUserDS.Users.Count > 0 Then
                mobjVDGVUserDS.Users.Clear()
            End If
            ' Fills up the VirtualDataGridView.
            For i As Integer = 1 To 2999
                mobjVDGVUserDS.Users.AddUsersRow(String.Format("User{0}", i), String.Format("user{0}@gmail.com", i), String.Format("8-800-236589{0}", i), "Franklin", String.Format("10{0} Murfreeboro Rd.", i), "USA", _
                 "Tennessee", "37064")
            Next
        End Sub

        ''' <summary>
        ''' Called when [timeout].
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub OnTimeout(sender As Object, e As EventArgs)
            'If 'Yes' button pressed - clear all added data  
            If DirectCast(sender, MessageBoxWindow).DialogResult = DialogResult.Yes Then
                mobjDGVUserDS = New UserDS()
                mobjDGVBindingSource.DataSource = mobjDGVUserDS
                mobjDataGridView.DataSource = mobjDGVBindingSource
            Else
                'If 'No' button pressed - bind back datasource
                mobjDataGridView.DataSource = mobjDGVBindingSource
            End If
        End Sub
    End Class

End Namespace
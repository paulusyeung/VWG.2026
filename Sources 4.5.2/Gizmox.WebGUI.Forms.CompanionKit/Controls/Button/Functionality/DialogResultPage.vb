Namespace CompanionKit.Controls.Button.Functionality

	Public Class DialogResultPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        '' <summary>
        ''' Handles the Click event of the mobjOpenButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjOpenButton_Click(sender As Object, e As EventArgs) Handles mobjOpenButton.Click
            'Show form as dialog
            Dim mobjDialogForm As New CustomDialogForm()
            mobjDialogForm.ShowDialog(AddressOf OnCloseForm)
        End Sub

        ''' <summary>
        ''' Called when [close form].
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub OnCloseForm(sender As Object, args As EventArgs)
            'Show appropriate message
            Dim objForm As CustomDialogForm = DirectCast(sender, CustomDialogForm)
            If objForm.DialogResult = DialogResult.Yes Then
                MessageBox.Show("'Yes' button has been clicked")
            ElseIf objForm.DialogResult = DialogResult.No Then
                MessageBox.Show("'No' button has been clicked")
            End If
        End Sub

	End Class

End Namespace
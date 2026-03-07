Namespace CompanionKit.Controls.CheckedListBox.Functionality

	Public Class CheckOnClickPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Set initial checked state for the CheckBox according to CheckOnClick property value of demonstrates CheckedListBox 
            Me.mobjCheckOnClick.Checked = Me.mobjCheckedListBox.CheckOnClick


		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckOnClick control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckOnClick_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjCheckOnClick.CheckedChanged
            'Change CheckOnClick property value of demonstrates CheckedListBox according to checked state of the CheckBox.
            Me.mobjCheckedListBox.CheckOnClick = Me.mobjCheckOnClick.Checked
            ' TODO: check after Beta 2 released, VWG-6446, remove call to Update()
            Me.mobjCheckedListBox.Update()
        End Sub
	End Class

End Namespace
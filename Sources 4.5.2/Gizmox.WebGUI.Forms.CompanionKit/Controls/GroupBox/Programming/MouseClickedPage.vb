Namespace CompanionKit.Controls.GroupBox.Programming

	Public Class MouseClickedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the GroupBox control.
        ''' Shows message that indicates whether the event is fired.
        ''' </summary>
        Private Sub mobjGroupBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjGroupBox.Click
            Dim args As MouseEventArgs = TryCast(e, MouseEventArgs)
            If (Not args Is Nothing) Then
                If (args.Button = MouseButtons.Right) Then
                    Me.mobjButtonClickedLabel.Text = "Right clicked"
                ElseIf (args.Button = MouseButtons.Left) Then
                    Me.mobjButtonClickedLabel.Text = "Left clicked"
                End If
            Else
                Me.mobjButtonClickedLabel.Text = "Mouse clicked!"
            End If

        End Sub
	End Class

End Namespace

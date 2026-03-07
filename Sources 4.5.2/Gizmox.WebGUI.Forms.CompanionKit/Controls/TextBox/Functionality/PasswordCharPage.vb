Imports System

Namespace CompanionKit.Controls.TextBox.Functionality

	Public Class PasswordCharPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjCharTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCharTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjCharTextBox.TextChanged
            'If Text property is not empty or null, then -- continue
            If Not String.IsNullOrEmpty(mobjCharTextBox.Text) Then
                'If string contains more than one char, take first one
                If mobjCharTextBox.Text.ToCharArray().Length > 1 Then
                    mobjCharTextBox.Text = mobjCharTextBox.Text.ToCharArray()(0).ToString()
                End If
                'Applies parsed string to PasswordChar property
                mobjTextBox.PasswordChar = Char.Parse(mobjCharTextBox.Text)
            End If
        End Sub

	End Class

End Namespace
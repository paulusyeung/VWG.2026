Namespace CompanionKit.Controls.RichTextBox.Functionality

	Public Class ControlPropertiesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjMultiLineCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjMultiLineCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjMultiLineCheckBox.CheckedChanged
            Me.mobjMultiLineRichTextBox.Multiline = Me.mobjMultiLineCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjSelectionFontButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSelectionFontButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjSelectionFontButton.Click

            Dim selectionFondDialog As New FontDialog()
            AddHandler selectionFondDialog.Closed, AddressOf selectionFondDialog_Closed
            selectionFondDialog.ShowDialog()

        End Sub

        ''' <summary>
        ''' Handles the Closed event of the selectionFondDialog control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub selectionFondDialog_Closed(sender As Object, e As EventArgs)
            Dim fontDialog As FontDialog = TryCast(sender, FontDialog)

            If fontDialog.DialogResult = DialogResult.OK Then
                Me.mobjSelectionFontRichTextBox.SelectionFont = fontDialog.Font
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjFontButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjFontButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjFontButton.Click
            Dim fondDialog As New FontDialog()
            AddHandler fondDialog.Closed, AddressOf fontDialog_Closed
            fondDialog.ShowDialog()
        End Sub
        ''' <summary>
        ''' Handles the Closed event of the fontDialog control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub fontDialog_Closed(sender As Object, e As EventArgs)
            Dim fontDialog As FontDialog = TryCast(sender, FontDialog)

            If fontDialog.DialogResult = DialogResult.OK Then
                Me.mobjFontRichTextBox.Font = fontDialog.Font
            End If
        End Sub

    End Class

End Namespace
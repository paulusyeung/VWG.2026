Imports System.Drawing

Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Functionality

	Public Class FontPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
		End Sub

        Private Sub FontPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(Me.mobjChangeFontLabel.Font)
        End Sub

        Private Sub mobjChangeFontButton_Click(sender As Object, e As EventArgs) Handles mobjChangeFontButton.Click
            'Set initial Font for FontDialog
            Me.mobjDemoFontDialog.Font = Me.mobjChangeFontLabel.Font
            'Show FontDialog
            Me.mobjDemoFontDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Updates text of represented label with name and size of selected Font.
        ''' </summary>
        ''' <param name="newFont">selected font in FontDialog</param>
        Private Sub UpdateTestOfLabel(newFont As Font)
            Me.mobjChangeFontLabel.Text = String.Format("Font selected in the dialog: {0}, {1} pt.", newFont.Name, newFont.Size)
        End Sub

        Private Sub mobjDemoFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Closed
            'Check dialog result of FontDialog
            If Me.mobjDemoFontDialog.DialogResult = DialogResult.OK Then
                'Change Font of represented Label to selected Font
                Me.mobjChangeFontLabel.Font = Me.mobjDemoFontDialog.Font
                UpdateTestOfLabel(Me.mobjChangeFontLabel.Font)
            End If
        End Sub

	End Class

End Namespace

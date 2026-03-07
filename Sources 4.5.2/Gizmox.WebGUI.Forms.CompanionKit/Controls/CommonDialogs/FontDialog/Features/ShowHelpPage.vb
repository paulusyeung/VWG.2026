Imports System.Drawing

Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	Public Class ShowHelpPage

        Private _selectedFont As Font


		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub mobjDemoFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Closed
            'Check dialog result of FontDialog
            If Me.mobjDemoFontDialog.DialogResult = DialogResult.OK Then
                'Change text of represented Label to selected Font
                Me.mobjShowHelpLabel.Font = Me.mobjDemoFontDialog.Font
                UpdateTestOfLabel(Me.mobjShowHelpLabel.Font)
            End If
        End Sub

        Private Sub mobjShowHelpButton_Click(sender As Object, e As EventArgs) Handles mobjShowHelpButton.Click
            'Set initial Font for FontDialog
            Me.mobjDemoFontDialog.Font = Me.mobjShowHelpLabel.Font
            'Set FontDialog ShowHelp property value according to checked state of CheckBox
            Me.mobjDemoFontDialog.ShowHelp = Me.mobjAllowShowHelpCheckBox.Checked
            'Show FontDialog
            Me.mobjDemoFontDialog.ShowDialog()
        End Sub

        Private Sub ShowHelpPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(Me.mobjShowHelpLabel.Font)
        End Sub

        ''' <summary>
        ''' Updates text of represented label with name and size of selected Font.
        ''' </summary>
        ''' <param name="newFont">selected font in FontDialog</param>
        Private Sub UpdateTestOfLabel(newFont As Font)
            Me.mobjShowHelpLabel.Text = String.Format("Font selected in the dialog:: {0}, {1} pt.", newFont.Name, newFont.Size)
        End Sub

	End Class

End Namespace

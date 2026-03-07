Imports System.Drawing

Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	Public Class MaxSizePage


		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub MaxSizePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.mobjSetMaxSizeFontNumericUpDown.Minimum = Me.mobjDemoFontDialog.MinSize
            Me.mobjSetMaxSizeFontNumericUpDown.Maximum = Me.mobjDemoFontDialog.MaxSize
            'Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(Me.mobjMaxSizeFontLabel.Font)
        End Sub

        Private Sub mobjChangeFontButton_Click(sender As Object, e As EventArgs) Handles mobjChangeFontButton.Click
            'Set initial Font for FontDialog
            Me.mobjDemoFontDialog.Font = Me.mobjMaxSizeFontLabel.Font
            'Set maximum size font taht user can select in FontDialog
            Me.mobjDemoFontDialog.MaxSize = Decimal.ToInt16(Me.mobjSetMaxSizeFontNumericUpDown.CurrentValue)
            'Show FontDialog
            Me.mobjDemoFontDialog.ShowDialog()
        End Sub

        Private Sub mobjDemoFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Closed
            'Check dialog result of FontDialog
            If Me.mobjDemoFontDialog.DialogResult = DialogResult.OK Then
                Me.mobjMaxSizeFontLabel.Font = Me.mobjDemoFontDialog.Font
                'Change text of represented Label to selected Font
                UpdateTestOfLabel(Me.mobjMaxSizeFontLabel.Font)
            End If
        End Sub

        ''' <summary>
        ''' Updates text of represented label with name and size of selected Font.
        ''' </summary>
        ''' <param name="newFont">selected font in FontDialog</param>
        Private Sub UpdateTestOfLabel(newFont As Font)
            Me.mobjMaxSizeFontLabel.Text = String.Format("Font selected in the dialog: {0}, {1} pt.", newFont.Name, newFont.Size)
        End Sub

	End Class

End Namespace

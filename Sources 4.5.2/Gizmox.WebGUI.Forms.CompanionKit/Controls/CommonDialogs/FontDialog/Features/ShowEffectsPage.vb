Imports System.Drawing

Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

	Public Class ShowEffectsPage


		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub mobjDemoFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Closed
            'Check dialog result of FontDialog
            If Me.mobjDemoFontDialog.DialogResult = DialogResult.OK Then
                'Change text of represented Label to selected Font
                Me.mobjShowEffectsLabel.Font = Me.mobjDemoFontDialog.Font
                UpdateTestOfLabel(Me.mobjShowEffectsLabel.Font)
            End If
        End Sub

        Private Sub mobjShowEffectsButton_Click(sender As Object, e As EventArgs) Handles mobjShowEffectsButton.Click
            'Set initial Font for FontDialog
            Me.mobjDemoFontDialog.Font = Me.mobjShowEffectsLabel.Font
            'Set FontDialog ShowEffects property value according to checked state of CheckBox
            Me.mobjDemoFontDialog.ShowEffects = Me.mobjAllowShowEffectsCheckBox.Checked
            'Show FontDialog
            Me.mobjDemoFontDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Updates text of represented label with name and size of selected Font.
        ''' </summary>
        ''' <param name="newFont">selected font in FontDialog</param>
        Private Sub UpdateTestOfLabel(newFont As Font)
            Me.mobjShowEffectsLabel.Text = String.Format("Font selected in the dialog: {0}, {1} pt.", newFont.Name, newFont.Size)
        End Sub

        Private Sub ShowEffectsPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(Me.mobjShowEffectsLabel.Font)
        End Sub

    End Class

End Namespace

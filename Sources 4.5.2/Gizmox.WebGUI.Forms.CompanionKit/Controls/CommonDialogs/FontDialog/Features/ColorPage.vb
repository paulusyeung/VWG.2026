Imports System.Drawing

Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features

    Public Class ColorPage


        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            UpdateFontLabel(Me.mobjColorFontLabel.Font)
        End Sub

        Private Sub mobjChangeForeColorButton_Click(sender As Object, e As EventArgs) Handles mobjChangeForeColorButton.Click
            'Set initial Color for FontDialog
            Me.mobjDemoFontDialog.Color = Me.mobjColorFontLabel.ForeColor
            'Set initial Font for FontDialog
            Me.mobjDemoFontDialog.Font = Me.mobjColorFontLabel.Font
            'Show FontDialog
            Me.mobjDemoFontDialog.ShowDialog()
        End Sub

        Private Sub mobjDemoFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Closed
            'Check dialog result of FontDialog
            If mobjDemoFontDialog.DialogResult = DialogResult.OK Then
                'Change Font of represented Label to selected Font
                Me.mobjColorFontLabel.ForeColor = Me.mobjDemoFontDialog.Color
                Me.mobjColorFontLabel.Font = Me.mobjDemoFontDialog.Font
                UpdateFontLabel(Me.mobjDemoFontDialog.Font)
            End If
        End Sub

        Private Sub UpdateFontLabel(newFont As Font)
            If newFont IsNot Nothing Then
                Me.mobjColorFontLabel.Text = String.Format("Font selected in the dialog: {0}, {1}pt", newFont.Name, newFont.Size)
            End If
        End Sub

    End Class

End Namespace

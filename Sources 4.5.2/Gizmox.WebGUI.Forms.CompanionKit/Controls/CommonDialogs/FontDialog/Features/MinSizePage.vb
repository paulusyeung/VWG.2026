Imports System.Drawing

Namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features


    Public Class MinSizePage


        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        Private Sub mobjChangeFontButton_Click(sender As Object, e As EventArgs) Handles mobjChangeFontButton.Click
            'Set initial Font for FontDialog
            Me.mobjDemoFontDialog.Font = Me.mobjMinSizeFontLabel.Font
            'Set minimum size font taht user can select in FontDialog
            Me.mobjDemoFontDialog.MinSize = Decimal.ToInt16(Me.mobjSetMinSizeFontNumericUpDown.CurrentValue)
            'int.Parse(this.setMinSizeFontTextBox.Text);
            'Show FontDialog
            Me.mobjDemoFontDialog.ShowDialog()
        End Sub

        Private Sub MinSizePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Update initial Text of represents label with Name and Size label Font
            UpdateTestOfLabel(Me.mobjMinSizeFontLabel.Font)

            Me.mobjSetMinSizeFontNumericUpDown.Minimum = Me.mobjDemoFontDialog.MinSize
            Me.mobjSetMinSizeFontNumericUpDown.Maximum = Me.mobjDemoFontDialog.MaxSize
        End Sub

        Private Sub mobjDemoFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Closed
            'Check dialog result of FontDialog
            If Me.mobjDemoFontDialog.DialogResult = DialogResult.OK Then
                'Change Font of represented Label to selected Font
                Me.mobjMinSizeFontLabel.Font = Me.mobjDemoFontDialog.Font
                UpdateTestOfLabel(Me.mobjMinSizeFontLabel.Font)
            End If
        End Sub

        ''' <summary>
        ''' Updates text of represented label with name and size of selected Font.
        ''' </summary>
        ''' <param name="newFont">selected font in FontDialog</param>
        Private Sub UpdateTestOfLabel(newFont As Font)
            Me.mobjMinSizeFontLabel.Text = String.Format("Font selected in the dialog: {0}, {1} pt.", newFont.Name, newFont.Size)
        End Sub

    End Class

End Namespace

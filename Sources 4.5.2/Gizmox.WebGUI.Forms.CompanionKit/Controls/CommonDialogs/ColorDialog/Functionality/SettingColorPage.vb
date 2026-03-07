Namespace CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality

	Public Class SettingColorPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub mobjChangeBackColorButton_Click(sender As Object, e As EventArgs) Handles mobjChangeBackColorButton.Click
            'Set represented Label backgroud color a initial color for ColorDialog
            Me.mobjDemoColorDialog.Color = Me.mobjColorlLabel.BackColor
            'Show ColorDialog
            Me.mobjDemoColorDialog.ShowDialog()
        End Sub

        Private Sub mobjDemoColorDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoColorDialog.Closed
            'Check dialog result for closed ColorDialog
            If Me.mobjDemoColorDialog.DialogResult = DialogResult.OK Then
                'Set selct Color as background color of represented Label
                Me.mobjColorlLabel.BackColor = Me.mobjDemoColorDialog.Color
            End If
        End Sub
	End Class
End Namespace
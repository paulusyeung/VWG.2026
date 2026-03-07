Namespace CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality

	Public Class AllowFullOpenPage

        Private _isBackColorLabelChanged As Boolean = False


		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub mobjChangeBackColorButton_Click(sender As Object, e As EventArgs) Handles mobjChangeBackColorButton.Click
            'Set represented Label backgroud color a initial color for ColorDialog
            Me.mobjDemoColorDialog.Color = Me.mobjColorLabel.BackColor
            'Changed value of flag, that indicates whether button was click for 
            'backgroud color change, to true
            _isBackColorLabelChanged = True
            'Show ColorDialog
            Me.mobjDemoColorDialog.ShowDialog()
        End Sub

        Private Sub mobjChangeForeColorButton_Click(sender As Object, e As EventArgs) Handles mobjChangeForeColorButton.Click
            'Set represented Label foreground color a initial color for ColorDialog
            Me.mobjDemoColorDialog.Color = Me.mobjColorLabel.ForeColor
            'Changed value of flag, that indicates whether button was click for 
            'foreground color change, to false
            _isBackColorLabelChanged = False
            'Show ColorDialog
            Me.mobjDemoColorDialog.ShowDialog()
        End Sub

        Private Sub mobjDemoColorDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoColorDialog.Closed
            'Check dialog result for closed ColorDialog
            If Me.mobjDemoColorDialog.DialogResult = DialogResult.OK Then
                'Check whether backgroud color of represented Label should be changed
                If _isBackColorLabelChanged Then
                    'Set backgroud color of represented Label to selected color
                    Me.mobjColorLabel.BackColor = Me.mobjDemoColorDialog.Color
                Else
                    'Set foregroud color of represented Label to selected color
                    Me.mobjColorLabel.ForeColor = Me.mobjDemoColorDialog.Color
                End If
            End If

        End Sub
	End Class

End Namespace
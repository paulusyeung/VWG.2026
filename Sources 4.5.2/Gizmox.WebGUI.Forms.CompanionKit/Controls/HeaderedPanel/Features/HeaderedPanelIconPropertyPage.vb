Namespace CompanionKit.Controls.HeaderedPanel.Features

	Public Class HeaderedPanelIconPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub
        ''' <summary>
        ''' Handles CheckedChanged event for RadioButton controls
        ''' </summary>
        Private Sub RadioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjRadioButton3.CheckedChanged, mobjRadioButton2.CheckedChanged, mobjRadioButton1.CheckedChanged
            ' If RadioButton is checked
            If DirectCast(sender, Gizmox.WebGUI.Forms.RadioButton).Checked Then
                ' Set icon for HeaderedPanel using RadioButton.Image property
                Me.mobjHeaderedPanel.Icon = DirectCast(sender, Gizmox.WebGUI.Forms.RadioButton).Image
            End If
        End Sub

	End Class

End Namespace
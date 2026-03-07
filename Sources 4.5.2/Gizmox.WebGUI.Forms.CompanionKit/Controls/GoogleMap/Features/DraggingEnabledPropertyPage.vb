Namespace CompanionKit.Controls.GoogleMap.Features

	Public Class DraggingEnabledPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles CheckedChanged event for CheckBox control
        ''' </summary>
        Private Sub mobjAllowDraggingCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjAllowDraggingCheckBox.CheckedChanged
            ' Set enable dragging for GoogleMap control
            mobjGoogleMap.MapDraggingEnabled = mobjAllowDraggingCheckBox.Checked
        End Sub
    End Class

End Namespace
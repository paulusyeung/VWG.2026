Namespace CompanionKit.Controls.GoogleMap.Features

	Public Class MapZoomLevelPropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the CheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjCheckBox.CheckedChanged
            'Toggles state of MapDoubleClickZooms control
            mobjGoogleMap.MapDoubleClickZooms = mobjCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the NumericUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNumericUpDown_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjNumericUpDown.ValueChanged
            'Sets MaoZoomLevel property and updates GoogleMap control
            mobjGoogleMap.MapZoomLevel = CInt(mobjNumericUpDown.Value)
            mobjGoogleMap.Update()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the MapZoomLevelPropertyPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub MapZoomLevelPropertyPage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            'On load initialization
            mobjGoogleMap.MapDoubleClickZooms = False
            mobjNumericUpDown.Value = mobjGoogleMap.MapZoomLevel
        End Sub

        ''' <summary>
        ''' Handles the MapZoomLevelChanged event of the GoogleMap control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjGoogleMap_MapZoomLevelChanged(sender As System.Object, e As System.EventArgs) Handles mobjGoogleMap.MapZoomLevelChanged
            mobjNumericUpDown.Value = mobjGoogleMap.MapZoomLevel
        End Sub
    End Class

End Namespace
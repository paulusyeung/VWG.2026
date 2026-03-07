Imports Gizmox.WebGUI.Forms.Google

Namespace CompanionKit.Controls.GoogleMap.Features

    Public Class MapLocationPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Click event for Button
        ''' </summary>
        Private Sub mobjSetCoordinatesButton_Click(sender As Object, e As EventArgs) Handles mobjSetCoordinatesButton.Click
            ' Set local variable for validation
            Dim isValid As Boolean = True
            ' Set local variables for coordinates
            Dim longitude As Double = CDbl(Me.mobjLongitudeNUD.Value)
            Dim latitude As Double = CDbl(Me.mobjLatitudeNUD.Value)

            ' If all values entered are valid
            If isValid Then
                ' Set map location for GoogleMap control
                Me.mobjGoogleMap.MapLocation = New Gizmox.WebGUI.Forms.Google.GoogleMapLocation(latitude, longitude)
            End If
        End Sub
    End Class

End Namespace
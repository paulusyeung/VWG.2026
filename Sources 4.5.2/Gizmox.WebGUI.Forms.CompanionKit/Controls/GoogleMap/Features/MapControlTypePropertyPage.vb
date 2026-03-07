Imports Gizmox.WebGUI.Forms.Google

Namespace CompanionKit.Controls.GoogleMap.Features

    Public Class MapControlTypePropertyPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event for ComboBox
        ''' </summary>
        Private Sub mobjMapControlTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjMapControlTypeComboBox.SelectedIndexChanged
            ' Set map control type for GoogleMap control
            If (mobjMapControlTypeComboBox.SelectedIndex = 0) Then
                mobjGoogleMap.MapControlType = GoogleMapControlType.[Default]
            Else
                If (mobjMapControlTypeComboBox.SelectedIndex = 1) Then
                    mobjGoogleMap.MapControlType = GoogleMapControlType.DropdownMenu
                Else
                    mobjGoogleMap.MapControlType = GoogleMapControlType.HorizontalBar
                End If
            End If
        End Sub

        Private Sub mobjMapZoomControlTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjMapZoomControlTypeComboBox.SelectedIndexChanged
            ' Set map control type for GoogleMap control
            If (mobjMapZoomControlTypeComboBox.SelectedIndex = 0) Then
                mobjGoogleMap.MapZoomControlType = GoogleMapZoomControlType.[Default]
            Else
                If (mobjMapZoomControlTypeComboBox.SelectedIndex = 1) Then
                    mobjGoogleMap.MapZoomControlType = GoogleMapZoomControlType.Large
                Else
                    mobjGoogleMap.MapZoomControlType = GoogleMapZoomControlType.Small
                End If
            End If
        End Sub

    End Class

End Namespace
Imports Gizmox.WebGUI.Forms.Google

Namespace CompanionKit.Controls.GoogleMap.Features

    Public Class MapTypePropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event for Page
        ''' </summary>
        Private Sub MapTypePropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill ComboBox items collection with GoogleMapType enum items
            mobjMapTypeComboBox.DataSource = [Enum].GetValues(GetType(GoogleMapType))
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged for ComboBox
        ''' </summary>
        Private Sub mobjMapTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjMapTypeComboBox.SelectedIndexChanged
            ' Set map type for GoogleMap
            mobjGoogleMap.MapType = DirectCast(mobjMapTypeComboBox.SelectedItem, GoogleMapType)
        End Sub
    End Class

End Namespace
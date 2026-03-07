Namespace CompanionKit.Controls.GoogleMap.Features

	Public Class MapLayersCollectionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the ItemCheck event of the mobjCheckedListBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckedListBox_ItemCheck(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.ItemCheckEventArgs) Handles mobjCheckedListBox.ItemCheck
            'Gets type of selected item
            Dim objMapLayerType As Gizmox.WebGUI.Forms.Google.GoogleMapLayerType = DirectCast(DirectCast(objSender, Gizmox.WebGUI.Forms.CheckedListBox).Items(objArgs.Index), Gizmox.WebGUI.Forms.Google.GoogleMapLayerType)
            'Gets string with name of type
            Dim strType As String = objMapLayerType.ToString()
            'If item checked - add new layer to collection
            If objArgs.NewValue = CheckState.Checked Then
                mobjGoogleMap.MapLayers.Add(GetInstance(strType))
            Else
                ' if unchecked - remove layer from collection
                mobjGoogleMap.MapLayers.RemoveItemByLayerType(DirectCast(objMapLayerType, Gizmox.WebGUI.Forms.Google.GoogleMapLayerType))
            End If
            'Updates googleMap control
            mobjGoogleMap.Update()
        End Sub


        ''' <summary>
        ''' Gets the instance.
        ''' </summary>
        ''' <param name="strTypeName">string value of type name.</param>
        ''' <returns></returns>
        Private Function GetInstance(strTypeName As String) As Gizmox.WebGUI.Forms.Google.GoogleMapLayer
            'Returns MapLayer type according to its name
            Select Case strTypeName
                Case "BicyclingLayer"
                    Return New Gizmox.WebGUI.Forms.Google.GoogleMapBicyclingLayer()
                Case "KmlLayer"
                    Return New Gizmox.WebGUI.Forms.Google.GoogleMapKmlLayer()
                Case "TrafficLayer"
                    Return New Gizmox.WebGUI.Forms.Google.GoogleMapTrafficLayer()
                Case "TransitLayer"
                    Return New Gizmox.WebGUI.Forms.Google.GoogleMapTransitLayer()
                Case "CloudLayer"
                    Return New Gizmox.WebGUI.Forms.Google.GoogleMapCloudLayer()
                Case "WeatherLayer"
                    Return New Gizmox.WebGUI.Forms.Google.GoogleMapWeatherLayer()
                Case "HeatmapLayer"
                    Return New Gizmox.WebGUI.Forms.Google.GoogleMapHeatMapLayer()
                Case Else
                    Return Nothing
            End Select
        End Function

        ''' <summary>
        ''' Handles the Load event of the MapLayersCollectionPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub MapLayersCollectionPage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            'Fills checkListBox with all GoogleMapLayer types
            mobjCheckedListBox.Items.AddRange([Enum].GetValues(GetType(Gizmox.WebGUI.Forms.Google.GoogleMapLayerType)))
        End Sub
    End Class

End Namespace
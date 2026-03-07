Imports Gizmox.WebGUI.Forms.Google

Namespace CompanionKit.Controls.GoogleMap.Features

    Public Class OverLaysPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event for Page
        ''' </summary>
        Private Sub OverLaysPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Add overlays to GoogleMap
            mobjGoogleMap.MapOverlays.Add(New GoogleMapMarkerOverlay(37.819722, -122.478611, "Golden Gate Bridge"))
            mobjGoogleMap.MapOverlays.Add(New GoogleMapMarkerOverlay(37.814111, -122.478615, "Happy fisher"))
            ' Load ListBox items
            LoadListBoxItems()
        End Sub

        ''' <summary>
        ''' Loads all GoogleMap overlays to ListBox items collection
        ''' </summary>
        Private Sub LoadListBoxItems()
            ' Clear ListBox items collection
            mobjOverlaysLabel.Items.Clear()
            ' Update map
            mobjGoogleMap.UpdateOverlays()

            For Each overlay As GoogleMapMarkerOverlay In mobjGoogleMap.MapOverlays
                ' Add overlay as ListBox item
                mobjOverlaysLabel.Items.Add(overlay)
            Next
        End Sub

        ''' <summary>
        ''' Handles Click event for 'Set Location' button
        ''' </summary>
        Private Sub mobjSetMapLocationButton_Click(sender As Object, e As EventArgs) Handles mobjSetMapLocationButton.Click
            ' Set local variable for validation result
            Dim mblnIsValid As Boolean = True
            ' Set local variables for coordinates
            Dim mdblLongitude As Double = 0
            Dim mdblLatitude As Double = 0
            ' If set location by coordinates
            If mobjCoordinatesRadioButton.Checked Then
                mdblLongitude = CDbl(Me.mobjLongitudeNUD.Value)
                mdblLatitude = CDbl(Me.mobjLatitudeNUD.Value)
            Else
                ' If set location by name
                ' Validate location name entered
                If mobjLocationNameAddressTextBox.Text = "" Then
                    mobjErrorProvider.SetError(mobjLocationNameAddressTextBox, "Please enter location name")
                    mblnIsValid = False
                Else
                    mobjErrorProvider.SetError(mobjLocationNameAddressTextBox, "")
                End If
            End If
            ' If all values entered are valid
            If mblnIsValid Then
                ' If locate by coordinates
                If mobjCoordinatesRadioButton.Checked Then
                    ' Set location for GoogleMap control
                    mobjGoogleMap.MapLocation = New GoogleMapLocation(mdblLatitude, mdblLongitude)
                Else
                    ' If locate by location name / address
                    ' Set location for GoogleMap control
                    mobjGoogleMap.MapAddress = mobjLocationNameAddressTextBox.Text
                End If
                ' Update input controls values for location coordinates
                mobjLongitudeNUD.Value = Convert.ToDecimal(mobjGoogleMap.MapLocation.Longitude)
                mobjLatitudeNUD.Value = Convert.ToDecimal(mobjGoogleMap.MapLocation.Latitude)
            End If
        End Sub

        ''' <summary>
        ''' Handles Click event for 'Add' button
        ''' </summary>
        Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
            ' Create and open form for adding new overlay item
            Dim mobjNewOverlayForm As New NewOverlayForm(Me.mobjGoogleMap.MapOverlays, AddressOf LoadListBoxItems)
            mobjNewOverlayForm.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles Click event for 'Edit' button
        ''' </summary>
        Private Sub mobjEditButton_Click(sender As Object, e As EventArgs) Handles mobjEditButton.Click
            ' If ListBox has selected item
            If mobjOverlaysLabel.SelectedItem IsNot Nothing Then
                ' Create and open form for editing overlay item
                Dim mobjEditOverlayForm As New EditOverlayForm(DirectCast(mobjOverlaysLabel.SelectedItem, GoogleMapMarkerOverlay), AddressOf LoadListBoxItems)
                mobjEditOverlayForm.ShowDialog()
            End If
        End Sub

        ''' <summary>
        ''' Handles Click event for 'Remove' button
        ''' </summary>
        Private Sub mobjRemoveButton_Click(sender As Object, e As EventArgs) Handles mobjRemoveButton.Click
            '  If ListBox has selected item
            If mobjOverlaysLabel.SelectedItem IsNot Nothing Then
                ' Remove selected overlay item
                mobjGoogleMap.MapOverlays.Remove(DirectCast(mobjOverlaysLabel.SelectedItem, GoogleMapMarkerOverlay))
                ' Refresh ListBox control
                LoadListBoxItems()
            End If
        End Sub

        ''' <summary>
        ''' Handles CheckedChanged event for RadioButton controls
        ''' Enables/disables input control accordind to
        ''' RadioButton option selected
        ''' </summary>
        Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCoordinatesRadioButton.CheckedChanged, mobjLocationNameAddressRadioButton.CheckedChanged
            If mobjCoordinatesRadioButton.Checked Then
                mobjLocationNameAddressTextBox.Enabled = False
                mobjLatitudeNUD.Enabled = True
                mobjLongitudeNUD.Enabled = True
            Else
                mobjLocationNameAddressTextBox.Enabled = True
                mobjLatitudeNUD.Enabled = False
                mobjLongitudeNUD.Enabled = False
            End If
        End Sub
    End Class

End Namespace
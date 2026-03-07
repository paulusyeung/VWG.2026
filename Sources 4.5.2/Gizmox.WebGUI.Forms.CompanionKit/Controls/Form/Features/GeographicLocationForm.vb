Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Public Class GeographicLocationForm

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Handles the CheckedChanged event of the objRepeatCheckBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjRepeatCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjRepeatCheckBox.CheckedChanged
        Me.GeographicLocation.RepeatCheck = mobjRepeatCheckBox.Checked
    End Sub

    ''' <summary>
    ''' Handles the CheckedChanged event of the objHighAccuracyCheckBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjHighAccuracyCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjHighAccuracyCheckBox.CheckedChanged
        Me.GeographicLocation.EnableHighAccuracy = mobjHighAccuracyCheckBox.Checked
    End Sub

    ''' <summary>
    ''' Handles the ValueChanged event of the objMaxAgeNUD control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjMaxAgeNUD_ValueChanged(sender As Object, e As EventArgs) Handles mobjMaxAgeNUD.ValueChanged
        Me.GeographicLocation.MaximumAge = mobjMaxAgeNUD.Value
    End Sub

    ''' <summary>
    ''' Handles the ValueChanged event of the objTimeoutNUD control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjTimeoutNUD_ValueChanged(sender As Object, e As EventArgs) Handles mobjTimeoutNUD.ValueChanged
        Me.GeographicLocation.Timeout = mobjTimeoutNUD.Value
    End Sub

    ''' <summary>
    ''' Handles the CheckedChanged event of the objMaxAgeNullCheckBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjMaxAgeNullCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjMaxAgeNullCheckBox.CheckedChanged
        'If MaxAgeNullCheckBox is checked -- disable MaxAgeNUD, otherwise enable it.
        mobjMaxAgeNUD.Enabled = Not mobjMaxAgeNullCheckBox.Checked
        'Sets MaximumAge property
        If (mobjMaxAgeNullCheckBox.Checked) Then
            Me.GeographicLocation.MaximumAge = mobjMaxAgeNUD.Value
        Else
            Me.GeographicLocation.MaximumAge = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Handles the CheckedChanged event of the objTimeoutNullCheckBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub mobjTimeoutNullCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjTimeoutNullCheckBox.CheckedChanged
        'If TimeoutNullCheckBox is checked -- disable TimeoutNUD, otherwise enable it.
        mobjTimeoutNUD.Enabled = Not mobjTimeoutNullCheckBox.Checked
        'Sets Timeout property
        If (mobjTimeoutNullCheckBox.Checked) Then
            Me.GeographicLocation.Timeout = mobjTimeoutNUD.Value
        Else
            Me.GeographicLocation.Timeout = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Handles the GeographicLocationChanged event of the GeographicLocationForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="GeographicLocationChangedEventArgs"/> instance containing the event data.</param>
    Private Sub GeographicLocationForm_GeographicLocationChanged(sender As Object, e As GeographicLocationChangedEventArgs) Handles Me.GeographicLocationChanged
        'Sets location variables
        Dim dblLatitude As Double = e.Location.Latitude
        Dim dblLongitude As Double = e.Location.Longitude
        'Sets start map location and adds marker location
        mobjGoogleMap.MapOverlays.Clear()
        mobjGoogleMap.MapOverlays.Add(New Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay(dblLatitude, dblLongitude))
        mobjGoogleMap.MapLocation = New Gizmox.WebGUI.Forms.Google.GoogleMapLocation(dblLatitude, dblLongitude)
    End Sub

End Class

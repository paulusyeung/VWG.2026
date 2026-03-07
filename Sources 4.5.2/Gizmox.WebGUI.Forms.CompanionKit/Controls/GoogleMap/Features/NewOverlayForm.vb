Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Google

Public Class NewOverlayForm
    ' Field to store overlay collection passed
    Private _overlays As GoogleMapOverlayCollection
    ' Create delegate
    Public Delegate Sub OverlayAdded()
    ' Cteate handler to store method passed to the construcor
    Public OverlayAddedHandler As OverlayAdded

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Overloaded form constructor
    ''' </summary>
    ''' <param name="overlays">Collection of GoogleMapOverlay objects</param>
    Public Sub New(overlays As GoogleMapOverlayCollection, handler As OverlayAdded)
        InitializeComponent()
        ' Save overlays collection passed to local variable
        Me._overlays = overlays
        ' Save method passed to local variable
        Me.OverlayAddedHandler = handler
    End Sub

    ''' <summary>
    ''' Handles Click event for 'Add' button
    ''' </summary>
    Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
        ' Set local variable for validation result
        Dim mblnIsValid As Boolean = True
        ' Set local variables for coordinates
        Dim mdblLongitude As Double = 0
        Dim mdblLatitude As Double = 0
        ' If set location by coordinates
        If mobjCoordinatesRadioButton.Checked Then
            mdblLongitude = CDbl(mobjLongitudeNUD.Value)
            mdblLatitude = CDbl(mobjLatitudeNUD.Value)
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
        ' Validate description value entered
        If mobjDescriptionTextBox.Text = "" Then
            mobjErrorProvider.SetError(mobjDescriptionTextBox, "Please enter description")
            mblnIsValid = False
        Else
            mobjErrorProvider.SetError(mobjDescriptionTextBox, "")
        End If
        ' If all values entered are valid
        If mblnIsValid Then
            If mobjCoordinatesRadioButton.Checked Then
                ' Add new overlay item by coordinates
                Me._overlays.Add(New GoogleMapMarkerOverlay(mdblLatitude, mdblLongitude, mobjDescriptionTextBox.Text))
            Else
                ' Add new overlay item by location name
                Dim newOverlay As New GoogleMapMarkerOverlay()
                newOverlay.Address = mobjLocationNameAddressTextBox.Text
                newOverlay.WindowInfoContent = mobjDescriptionTextBox.Text
                Me._overlays.Add(newOverlay)
            End If
            ' Perform delegated method
            Me.OverlayAddedHandler()
            ' Close window
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Handles Click event for 'Cancel' button
    ''' </summary>
    Private Sub mobjCancelButton_Click(sender As Object, e As EventArgs) Handles mobjCancelButton.Click
        ' Close window
        Me.Close()
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

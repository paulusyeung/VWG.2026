Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Google

Public Class EditOverlayForm

    ' Field to store overlay item passed
    Private _overlay As GoogleMapMarkerOverlay
    ' Create delegate
    Public Delegate Sub OverlayEdited()
    ' Cteate handler to store method passed to the construcor
    Public OverlayEditedHandler As OverlayEdited

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Overloaded form constructor
    ''' </summary>
    ''' <param name="overlays">Collection of GoogleMapOverlay objects</param>
    ''' <param name="handler">Methos that will be invoked after overlay item is edited</param>
    Public Sub New(overlay As GoogleMapMarkerOverlay, handler As OverlayEdited)
        InitializeComponent()
        ' Save overlay passed to local variable
        Me._overlay = overlay
        ' Save method passed to local variable
        Me.OverlayEditedHandler = handler
    End Sub

    ''' <summary>
    ''' Handles Click event for 'Save' button
    ''' </summary>
    Private Sub mobjSaveButton_Click(sender As Object, e As EventArgs) Handles mobjSaveButton.Click
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
        ' Validate description value entered
        If mobjDescriptionTextBox.Text = "" Then
            mobjErrorProvider.SetError(mobjDescriptionTextBox, "Please enter description")
            mblnIsValid = False
        Else
            mobjErrorProvider.SetError(mobjDescriptionTextBox, "")
        End If
        ' If all values entered are valid
        If mblnIsValid Then
            ' If overlay located by coordinates
            If mobjCoordinatesRadioButton.Checked Then
                Me._overlay.Address = ""
                Me._overlay.Location = New GoogleMapLocation(mdblLatitude, mdblLongitude)
            Else
                ' If overlay located by location name / address
                Me._overlay.Location = New GoogleMapLocation()
                Me._overlay.Address = mobjLocationNameAddressTextBox.Text
            End If
            ' Set overlay description text
            Me._overlay.WindowInfoContent = mobjDescriptionTextBox.Text
            ' Perform delegated method
            Me.OverlayEditedHandler()
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
    ''' Handles Load event for Form
    ''' Loads Overlay item data for editing
    ''' </summary>
    Private Sub EditOverlayForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _overlay.Address = "" Then
            mobjCoordinatesRadioButton.Checked = True
            mobjLongitudeNUD.Value = CDec(_overlay.MapLocation.Longitude)
            mobjLatitudeNUD.Value = CDec(_overlay.MapLocation.Latitude)
        Else
            mobjLocationNameAddressRadioButton.Checked = True
            mobjLocationNameAddressTextBox.Text = _overlay.Address
        End If

        mobjDescriptionTextBox.Text = _overlay.WindowInfoContent
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

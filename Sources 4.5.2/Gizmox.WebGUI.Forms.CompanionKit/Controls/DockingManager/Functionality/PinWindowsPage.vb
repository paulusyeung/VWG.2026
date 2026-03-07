Namespace CompanionKit.Controls.DockingManager.Functionality

	Public Class PinWindowsPage

        'User index global variable
        Private mintUserIndex As Integer = 0

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjPinButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjPinButton_Click(sender As Object, e As EventArgs) Handles mobjPinButton.Click
            'Pins all windows
            mobjDockingManager.PinAll()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the objUnpinButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjUnpinButton_Click(sender As Object, e As EventArgs) Handles mobjUnpinButton.Click
            'Unpins all windows
            mobjDockingManager.UnpinAll()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the PinWindowsPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PinWindowsPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Fill up table adapter with data from table
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)

            'Creates 5 DockingWindows
            For i As Integer = 0 To 4
                Dim mobjDockingWindow As New DockingWindow()
                FillDockingWindow(mobjDockingWindow)
                mobjDockingManager.AddAutoHiddenWindows(DockStyle.Top, mobjDockingWindow)
            Next
        End Sub

        ''' <summary>
        ''' Fills the docking window.
        ''' </summary>
        ''' <param name="objDockingWindow">The obj docking window.</param>
        Private Sub FillDockingWindow(objDockingWindow As DockingWindow)
            'Fills string with User info
            Dim strUserInfo As String = String.Format("User Name:{0}" & vbCr & vbLf & "Company Name:{1}" & vbCr & vbLf & "Country:{2}" & vbCr & vbLf & "City:{3}" & vbCr & vbLf & "Address:{4}" & vbCr & vbLf & "Phone:{5}", mobjNorthwindDataSet.Customers(mintUserIndex).ContactName, mobjNorthwindDataSet.Customers(mintUserIndex).CompanyName, mobjNorthwindDataSet.Customers(mintUserIndex).Country, mobjNorthwindDataSet.Customers(mintUserIndex).City, mobjNorthwindDataSet.Customers(mintUserIndex).Address, _
             mobjNorthwindDataSet.Customers(mintUserIndex).Phone)
            'Creates and fills label control
            Dim mobjUserLabel As New Label()
            mobjUserLabel.AutoSize = False
            mobjUserLabel.Text = strUserInfo
            mobjUserLabel.Dock = DockStyle.Fill
            'Settings up DockingWindow control
            objDockingWindow.Text = mobjNorthwindDataSet.Customers(mintUserIndex).ContactName
            objDockingWindow.HeaderText = mobjNorthwindDataSet.Customers(mintUserIndex).ContactTitle
            objDockingWindow.Controls.Add(mobjUserLabel)
            'Increase counter or reset it if value more than customer count
            If (mintUserIndex = (mobjNorthwindDataSet.Customers.Count - 1)) Then
                mintUserIndex = 0
            Else
                mintUserIndex = mintUserIndex + 1
            End If
        End Sub
	End Class

End Namespace
Namespace CompanionKit.Controls.DockingManager.Functionality

    Public Class AddingWindowsPage

        'User index global variable
        Private mintUserIndex As Integer = 0

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub


        ''' <summary>
        ''' Handles the Click event of the objAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
            'Creates new instance of DockingWindow
            Dim mobjDockingWindow As New DockingWindow()
            'Fills DockingWindow  with content
            FillDockingWindow(mobjDockingWindow)
            'Adds new window to DockingManager according to selected type in comboBox
            Select Case mobjComboBox.SelectedIndex
                'AutoHidden
                Case 0
                    'Applies DockStyle to AutoHiddenWindow according to selected value
                    Select Case mobjPositionComboBox.SelectedIndex
                        'Top
                        Case 0
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Top, mobjDockingWindow)
                            Exit Select
                            'Bottom
                        Case 1
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Bottom, mobjDockingWindow)
                            Exit Select
                            'Left
                        Case 2
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Left, mobjDockingWindow)
                            Exit Select
                            'Right
                        Case 3
                            mobjDockingManager.AddAutoHiddenWindows(DockStyle.Right, mobjDockingWindow)
                            Exit Select
                    End Select
                    Exit Select
                    'Docked
                Case 1
                    mobjDockingManager.AddDockedWindows(mobjDockingWindow)
                    Exit Select
                    'Float
                Case 2
                    mobjDockingManager.AddFloatWindows(mobjDockingWindow)
                    Exit Select
                    'Tabbed
                Case 3
                    mobjDockingManager.AddTabbedWindows(mobjDockingWindow)
                    Exit Select
            End Select
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the objComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            'If AutoHidden type is selected - shows additional comboBox
            If mobjComboBox.SelectedIndex = 0 Then
                mobjPositionComboBox.Visible = True
                mobjPositionLabel.Visible = True
            Else
                'If other type - hides it
                mobjPositionComboBox.Visible = False
                mobjPositionLabel.Visible = False
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the objCloseButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCloseButton_Click(sender As Object, e As EventArgs) Handles mobjCloseButton.Click
            'Closes all windows
            mobjDockingManager.CloseAll()
            mobjDockingManager.CloseAllFloatingWindows()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the objShowButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowButton_Click(sender As Object, e As EventArgs) Handles mobjShowButton.Click
            'Shows all windows
            mobjDockingManager.ShowAll()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the AddingWindowsPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub AddingWindowsPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Fill up table adapter with data from table
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)

            'Selects first item in comboBox on load
            mobjComboBox.SelectedIndex = 0
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
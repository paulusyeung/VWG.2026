Namespace CompanionKit.Controls.DockingManager.Functionality

	Public Class SaveAndLoadDataPage
        Inherits UserControl

        'Byte array for windows serialization
        Private marrByteArray As Byte()
        'User index global variable
        Private mintUserIndex As Integer = 0

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
            'Adds new window
            Dim mobjDockingWindow As New DockingWindow()
            FillDockingWindow(mobjDockingWindow)
            mobjDockingManager.AddTabbedWindows(mobjDockingWindow)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjSaveButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSaveButton_Click(sender As Object, e As EventArgs) Handles mobjSaveButton.Click
            'Serializates all windows
            marrByteArray = mobjDockingManager.SaveData()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjLoadButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjLoadButton_Click(sender As Object, e As EventArgs) Handles mobjLoadButton.Click
            'If byte array is not null - deserialize windows
            If marrByteArray IsNot Nothing Then
                mobjDockingManager.LoadData(marrByteArray)
            End If
        End Sub

        ''' <summary>
        ''' Fills the docking window.
        ''' </summary>
        ''' <param name="objDockingWindow">The obj docking window.</param>
        Private Sub FillDockingWindow(objDockingWindow As DockingWindow)
            'Settings up DockingWindow control
            objDockingWindow.Text = mobjNorthwindDataSet.Customers(mintUserIndex).ContactName
            objDockingWindow.HeaderText = mobjNorthwindDataSet.Customers(mintUserIndex).ContactTitle
            'Increase counter or reset it if value more than customer count
            mintUserIndex = IIf(mintUserIndex = (mobjNorthwindDataSet.Customers.Count - 1), 0, mintUserIndex + 1)
        End Sub

        ''' <summary>
        ''' Handles the Load event of the SaveAndLoadDataPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub SaveAndLoadDataPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Fill up table adapter with data from table
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
        End Sub

	End Class

End Namespace
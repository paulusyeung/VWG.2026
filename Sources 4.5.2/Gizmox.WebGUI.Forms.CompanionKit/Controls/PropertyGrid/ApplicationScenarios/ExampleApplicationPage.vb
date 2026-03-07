Namespace CompanionKit.Controls.PropertyGrid.ApplicationScenarios

	Public Class ExampleApplicationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles click event of the Buttons that creates event.
        ''' </summary>
        Private Sub createEventsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles createEventsButton.Click

            Dim eventSummary As String = Me.eventSummaryTextBox.Text
            If String.IsNullOrEmpty(eventSummary) Then
                MessageBox.Show("Please enter summary event!")
            Else
                ' Add event to ListView
                Dim newItem As New ListViewItem(New String() {Me.demoDateTimePicker.Value.ToString("dddd, MMMM dd, yyyy HH:mm:ss"), eventSummary})
                Me.eventsListView.Items.Add(newItem)
                Me.eventsListView.SelectedItem = newItem
            End If

        End Sub

        ''' <summary>
        ''' Handles click event of the menu item, that opens Options dialog for source control.
        ''' </summary>
        Private Sub optionsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optionsMenuItem.Click
            Dim optionsmenu As MenuItem = TryCast(sender, MenuItem)

            ' Shows Options dialog for source control.
            Dim optionDialog As OptionsDialog = New OptionsDialog(MyBase.ActiveControl)
            optionDialog.ShowDialog()

        End Sub

        ''' <summary>
        ''' Handles Load event for example's UserControl
        ''' </summary>
        Private Sub ExampleApplicationPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Fill up ListView with events
            Dim i As Integer
            For i = 0 To 3 - 1
                Me.eventsListView.Items.Add(New ListViewItem(New String() {DateTime.Now.ToString("dddd, MMMM dd, yyyy HH:mm:ss"), String.Format("Event {0}", i)}))
            Next i

        End Sub
    End Class

End Namespace

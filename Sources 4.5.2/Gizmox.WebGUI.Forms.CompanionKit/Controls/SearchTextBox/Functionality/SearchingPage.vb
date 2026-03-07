Namespace CompanionKit.Controls.SearchTextBox.Functionality

    Public Class SearchingPage

        'Creates list of listView's items
        Private mobjListOfItems As New List(Of ListViewItem)()

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Search event of the mobjSearchTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSearchTextBox_Search(sender As System.Object, e As System.EventArgs) Handles mobjSearchTextBox.Search
            'Creates list where all items, which contain keyword, will be added
            Dim mobjListOfFilteredItems As New List(Of ListViewItem)()
            'Checks all items on keyword content
            'If item contains - add to list
            For Each mobjItem As ListViewItem In mobjListOfItems
                If mobjItem.Text.ToLower().Contains(mobjSearchTextBox.Text.ToLower()) Then
                    mobjListOfFilteredItems.Add(mobjItem)
                End If
            Next
            'Clears items list 
            mobjListView.Items.Clear()
            'If filtered list is not empty - assign to listView
            If mobjListOfFilteredItems.Count <> 0 Then
                mobjListView.Items.AddRange(mobjListOfFilteredItems.ToArray())
            Else
                'If list empty - show message and clear searchTextBox text
                MessageBox.Show(String.Format("Sorry, but '{0}' has no result ", mobjSearchTextBox.Text))
                mobjSearchTextBox.Text = String.Empty
            End If
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjSearchTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub objSearchTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles mobjSearchTextBox.TextChanged
            'If text of searchTextBox is empty or null - reassign default list
            If String.IsNullOrEmpty(mobjSearchTextBox.Text) Then
                mobjListView.Items.Clear()
                mobjListView.Items.AddRange(mobjListOfItems.ToArray())
            End If
        End Sub

        ''' <summary>
        ''' Handles the Load event of the SearchingPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub SearchingPage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            'Fills list with items and assigns to listView control
            mobjListOfItems.Add(New ListViewItem("Orange"))
            mobjListOfItems.Add(New ListViewItem("Grape"))
            mobjListOfItems.Add(New ListViewItem("Cherry"))
            mobjListOfItems.Add(New ListViewItem("Banana"))
            mobjListOfItems.Add(New ListViewItem("Apple"))
            mobjListOfItems.Add(New ListViewItem("Lime"))
            mobjListOfItems.Add(New ListViewItem("Pineapple"))
            mobjListOfItems.Add(New ListViewItem("Strawberry"))
            mobjListView.Items.AddRange(mobjListOfItems.ToArray())
        End Sub
    End Class

End Namespace
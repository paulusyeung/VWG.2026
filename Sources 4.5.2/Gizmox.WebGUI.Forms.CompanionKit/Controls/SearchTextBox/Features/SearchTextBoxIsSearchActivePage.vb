Namespace CompanionKit.Controls.SearchTextBox.Features

	Public Class SearchTextBoxIsSearchActivePage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Click event for Button control
        ''' Sets tooltip text and icon according to search state
        ''' </summary>
        Private Sub btnCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCheck.Click
            If Me.searchTextBox1.IsSearchActive Then
                Me.errorProvider1.Icon = New ImageResourceHandle("16x16.InProgress.png")
                Me.errorProvider1.SetError(Me.searchTextBox1, "Search in progress")
            Else
                Me.errorProvider1.Icon = New ImageResourceHandle("16x16.Success.png")
                Me.errorProvider1.SetError(Me.searchTextBox1, "Search complete")
            End If
        End Sub

        ''' <summary>
        ''' Handles Search event for SearchTextBox control
        ''' Hides tooltip for SearchTextBox control
        ''' </summary>
        Private Sub searchTextBox1_Search(ByVal sender As Object, ByVal e As EventArgs) Handles searchTextBox1.Search
            Me.errorProvider1.Icon = Nothing
            Me.errorProvider1.SetError(Me.searchTextBox1, "")
        End Sub

	End Class

End Namespace
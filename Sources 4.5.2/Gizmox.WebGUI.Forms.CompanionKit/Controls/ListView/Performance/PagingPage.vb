Namespace CompanionKit.Controls.ListView.Performance

	Public Class PagingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Fill up ListView
			Dim i As Integer
			For i = 1 To 30
                Me.listViewWithPaging.Items.Add(New ListViewItem(New String() {String.Format("User{0}", i), String.Format("user{0}@gmail.com", i)}))
                Me.listViewWithoutPaging.Items.Add(New ListViewItem(New String() {String.Format("User{0}", i), String.Format("user{0}@gmail.com", i)}))
			Next i

            Me.itemsPerPagesNumUpDown.Value = Me.listViewWithPaging.ItemsPerPage

		End Sub
        ''' <summary>
        ''' Handles the ValueChanged event of the itemsPerPagesNumUpDown control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub itemsPerPagesNumUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemsPerPagesNumUpDown.ValueChanged
            Me.listViewWithPaging.ItemsPerPage = Decimal.ToInt32(Me.itemsPerPagesNumUpDown.Value)
        End Sub
	End Class

End Namespace
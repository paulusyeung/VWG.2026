Namespace CompanionKit.Controls.ListView.Features

	Public Class ColumnReorderingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Fill up ListView with allowed reordering of columns
            Me.allowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"1", "User1", "Name1"}))
            Me.allowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"2", "User2", "Name2"}))
            Me.allowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"3", "User3", "Name3"}))
            Me.allowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"4", "User4", "Name4"}))

            ' Fill up ListView with unallowed reordering of columns
            Me.unallowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"1", "User1", "Name1"}))
            Me.unallowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"2", "User2", "Name2"}))
            Me.unallowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"3", "User3", "Name3"}))
            Me.unallowedReorderingColumnListView.Items.Add(New ListViewItem(New String() {"4", "User4", "Name4"}))


		End Sub
	End Class

End Namespace
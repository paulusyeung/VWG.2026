Namespace CompanionKit.Controls.ListView.Features

	Public Class GroupingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Fill up listView
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"1", "User1", "8-800-1234556", "user1@gmail.com"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"2", "User2", "8-800-9513546", "user2@gmail.com"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"3", "User3", "8-800-8524563", "user3@gmail.com"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"4", "User4", "8-800-9874613", "user4@gmail.com"}))

            ' Define  group for each item
            Me.mobjListView.Items.Item(0).Group = Me.mobjListView.Groups.Item(0)
            Me.mobjListView.Items.Item(1).Group = Me.mobjListView.Groups.Item(1)
            Me.mobjListView.Items.Item(2).Group = Me.mobjListView.Groups.Item(1)
            Me.mobjListView.Items.Item(3).Group = Me.mobjListView.Groups.Item(1)


		End Sub
	End Class

End Namespace
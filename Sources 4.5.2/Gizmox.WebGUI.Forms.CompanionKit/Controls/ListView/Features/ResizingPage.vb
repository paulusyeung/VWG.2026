Namespace CompanionKit.Controls.ListView.Features

	Public Class ResizingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Fill up ListView
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"1", "User1", "8-800-1234556"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"2", "User2", "8-800-9513546"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"3", "User3", "8-800-8524563"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"4", "User4", "8-800-9874613"}))


		End Sub
	End Class

End Namespace
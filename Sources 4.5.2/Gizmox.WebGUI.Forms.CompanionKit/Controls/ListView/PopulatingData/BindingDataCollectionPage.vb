Namespace CompanionKit.Controls.ListView.PopulatingData

	Public Class BindingDataCollectionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            '  Set DataSources for the ListView as Customer objects collection.
            Me.mobjListView.DataSource = Global.CompanionKit.Controls.Utils.CustomerData.GetCustomers

		End Sub
	End Class

End Namespace
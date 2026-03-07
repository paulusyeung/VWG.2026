Namespace CompanionKit.Controls.ListView.PopulatingData

	Public Class BindingDataSourcePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()



		End Sub

        Private Sub BindingDataSourcePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up adapter, that is DataSources for the ListView, with data of Database Customer table.
            Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
        End Sub
	End Class

End Namespace
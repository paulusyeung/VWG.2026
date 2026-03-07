Namespace CompanionKit.Controls.DataGridView.Features

	Public Class BasicSortingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub BasicSortingPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up adapter, that is DataSources for the DataGridView, with data of Database Customer table.
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
        End Sub
	End Class

End Namespace
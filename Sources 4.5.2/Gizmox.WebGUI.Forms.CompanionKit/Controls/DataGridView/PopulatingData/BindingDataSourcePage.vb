Namespace CompanionKit.Controls.DataGridView.PopulatingData

	Public Class BindingDataSourcePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            'Allow grouping
            Me.mobjDataGridView.ShowGroupingDropArea = True

		End Sub

        Private Sub BindingDataSourcePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up table adapter with data from table
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
        End Sub
	End Class

End Namespace
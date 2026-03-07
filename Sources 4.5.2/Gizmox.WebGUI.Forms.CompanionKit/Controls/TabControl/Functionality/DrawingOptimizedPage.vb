Namespace CompanionKit.Controls.TabControl.Functionality

	Public Class DrawingOptimizedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example's UserControl
        ''' </summary>
        Private Sub DrawingOptimizedPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up adapter, that is DataSources for the DataGridView, with data of Database Customer table.
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
        End Sub
    End Class

End Namespace
Namespace CompanionKit.Controls.TabControl.Functionality

	Public Class MemoryOptimizedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example's UserControl
        ''' </summary>
        Private Sub MemoryOptimizedPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Fill up adapter, that is DataSources for the DataGridView, with data of Database Customer table.
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
        End Sub
    End Class

End Namespace
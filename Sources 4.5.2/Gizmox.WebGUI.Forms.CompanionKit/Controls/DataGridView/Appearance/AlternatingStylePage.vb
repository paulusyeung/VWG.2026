Namespace CompanionKit.Controls.DataGridView.Appearance

	Public Class AlternatingStylePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub AlternatingStylePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.mobjDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Drawing.Color.Lavender
            Me.mobjDataGridView.AlternatingRowsDefaultCellStyle.Font = New Drawing.Font(Me.mobjDataGridView.Font, Drawing.FontStyle.Regular)

            ' Relates PropertyGrid with DataGridView AlternatingRowsDefaultCellStyle propety object
            Me.mobjPropertyGrid.SelectedObject = Me.mobjDataGridView.AlternatingRowsDefaultCellStyle

            ' Fill up adapter, that is DataSources for the DataGridView, with data of Database Customer table.
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)

        End Sub
	End Class

End Namespace

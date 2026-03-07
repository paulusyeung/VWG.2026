Namespace CompanionKit.Controls.ListBox.PopulatingData

	Public Class DataBaseDataSourcePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Fill Display and Value Members
            mobjDisplayText.Text = mobjListBox.DisplayMember
            mobjValueText.Text = mobjListBox.ValueMember

		End Sub

        ''' <summary>
        ''' Handles the Load event of the DataBaseDataSourcePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		Private Sub DataBaseDataSourcePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'Fill up adapter with data from Customers table of DataBase
			Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
		End Sub
	End Class

End Namespace
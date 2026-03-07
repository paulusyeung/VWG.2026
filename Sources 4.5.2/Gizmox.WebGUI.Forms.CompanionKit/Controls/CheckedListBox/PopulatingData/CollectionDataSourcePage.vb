Namespace CompanionKit.Controls.CheckedListBox.PopulatingData

	Public Class CollectionDataSourcePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Set collection of customer as DataSource.
            Me.mobjCheckedListBox.DataSource = Global.CompanionKit.Controls.Utils.CustomerData.GetCustomers

            'Fill ValueMember and DisplayMember TextBoxes
            mobjValueTB.Text = mobjCheckedListBox.ValueMember
            mobjDisplayTB.Text = mobjCheckedListBox.DisplayMember

		End Sub
	End Class

End Namespace
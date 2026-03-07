Namespace CompanionKit.Controls.ListBox.PopulatingData

	Public Class CollectionDataSourcePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
			'Set collection of customer as DataSource.
            Me.mobjListBox.DataSource = Global.CompanionKit.Controls.Utils.CustomerData.GetCustomers
            'Fill Display and Value Members
            mobjDisplayText.Text = mobjListBox.DisplayMember
            mobjValueText.Text = mobjListBox.ValueMember
		End Sub

	End Class

End Namespace
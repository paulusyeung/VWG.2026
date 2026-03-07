Namespace CompanionKit.Controls.ListBox.Appearance

	Public Class TextWithColorPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Set collection of customer as DataSource.
            Me.mobjListBox.DataSource = Global.CompanionKit.Controls.Utils.CustomerData.GetCustomers

            'Fill TextBoxes with the values of appropriate properties
            Me.mobjDisplayTextBox.Text = Me.mobjListBox.DisplayMember
            Me.mobjValueTextBox.Text = Me.mobjListBox.ValueMember
            Me.mobjColorTextBox.Text = Me.mobjListBox.ColorMember
		End Sub

    End Class

End Namespace
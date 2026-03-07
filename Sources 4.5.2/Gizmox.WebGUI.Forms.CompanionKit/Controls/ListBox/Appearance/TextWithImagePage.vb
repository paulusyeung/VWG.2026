Namespace CompanionKit.Controls.ListBox.Appearance

	Public Class TextWithImagePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Get ResourceHandle for photo of customer.
            Dim photoResource As Gizmox.WebGUI.Common.Resources.ResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle("32x32.Photo.png")
			'Set objects collection as DataSource for ComboBox.
            Me.mobjListBox.DataSource = CompanionKit.Controls.Utils.CustomerData.GetCustomersWithImage(photoResource)

            'Fill TextBoxes with the values of appropriate properties
            Me.mobjDisplayTextBox.Text = Me.mobjListBox.DisplayMember
            Me.mobjValueTextBox.Text = Me.mobjListBox.ValueMember
            Me.mobjImageTextBox.Text = Me.mobjListBox.ImageMember
		End Sub

    End Class

End Namespace

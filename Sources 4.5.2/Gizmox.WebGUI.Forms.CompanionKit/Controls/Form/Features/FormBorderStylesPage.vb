Namespace CompanionKit.Controls.Form.Features

	Public Class FormBorderStylesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            ' Fill up with the form border styles.
            Me.mobjComboBox.DataSource = Global.System.Enum.GetValues(GetType(BorderStyle))


		End Sub

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Opens Form with the specified border style.
        ''' </summary>
        Private Sub mobjButton_Click(sender As Object, e As EventArgs) Handles mobjButton.Click
            Dim form As New BorderStyleForm()
            form.BorderStyle = DirectCast(Me.mobjComboBox.SelectedItem, Gizmox.WebGUI.Forms.BorderStyle)
            form.ShowDialog()
        End Sub
	End Class

End Namespace
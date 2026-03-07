Namespace CompanionKit.Controls.Form.Programming

	Public Class CloseHandlingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Opens the demonstrated form.
        ''' </summary>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            Dim form As New ClosedForm
            AddHandler form.Closed, New EventHandler(AddressOf Me.form_Closed)
            form.ShowDialog()

        End Sub

        ''' <summary>
        ''' Handles Closed event for the demonstrated form.
        ''' </summary>
		Private Sub form_Closed(ByVal sender As Object, ByVal e As EventArgs)
            Dim form As Gizmox.WebGUI.Forms.Form = TryCast(sender, Gizmox.WebGUI.Forms.Form)
			MessageBox.Show(String.Format("Form {0} is closed!", form.Text))
		End Sub

	End Class

End Namespace
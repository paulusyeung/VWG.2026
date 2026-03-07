Namespace CompanionKit.Controls.Form.Features

	Public Class WindowTypeForm

        ''' <summary>
        ''' Creates the From type.
        ''' </summary>
        ''' <param name="windowType">Name of the Form type</param>
        Public Sub New(ByVal _windowType As String)

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            ' Set name of the form and text for form label.
            Me.Text = String.Format("This is {0} Form.", _windowType)
            Me.mobjLabel.Text = String.Format("This is {0} Form. Click on button for closing it.", _windowType)
        End Sub

        ''' <summary>
        ''' Handles Click event of the 'Close' button.
        ''' Closes the demonstrated form.
        ''' </summary>
        Private Sub mobjCloseButton_Click(sender As Object, e As EventArgs) Handles mobjCloseButton.Click
            Me.Close()
        End Sub
	End Class

End Namespace

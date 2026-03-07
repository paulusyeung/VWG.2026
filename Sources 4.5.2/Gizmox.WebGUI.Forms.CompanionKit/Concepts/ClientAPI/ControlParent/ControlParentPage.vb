Namespace CompanionKit.Concepts.ClientAPI.ControlParent

	Public Class ControlParentPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowParentButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjShowParentButton.Click
            VWGClientContext.Current.Invoke("showParent")
        End Sub
    End Class

End Namespace
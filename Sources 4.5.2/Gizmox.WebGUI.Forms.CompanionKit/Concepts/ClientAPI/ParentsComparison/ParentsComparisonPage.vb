Namespace CompanionKit.Concepts.ClientAPI.ParentsComparison

	Public Class ParentsComparisonPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the Click event of the objButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub objButton_Click(sender As System.Object, e As System.EventArgs) Handles objButton.Click
            VWGClientContext.Current.Invoke("compareParents")
        End Sub
    End Class

End Namespace
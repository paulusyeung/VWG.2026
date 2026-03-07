Namespace CompanionKit.Controls.Form.Programming

	Public Class ActivateHandlingPage

        ''' <summary>
        '''  Represents list of the opened Modeless Forms.
        ''' </summary>
        Private _openedForms As List(Of Gizmox.WebGUI.Forms.Form) = New List(Of Gizmox.WebGUI.Forms.Form)

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
		End Sub

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Opens modeless form.
        ''' </summary>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            Dim form As New ActivatingForm
            Me._openedForms.Add(form)
            AddHandler form.Closed, New EventHandler(AddressOf Me.form_Closed)
            form.Show()

        End Sub

        ''' <summary>
        ''' Handles Closed event of the modeless form.
        ''' Removes the Modeless form from list.
        ''' </summary>
		Private Sub form_Closed(ByVal sender As Object, ByVal e As EventArgs)
			Me._openedForms.Remove(TryCast(sender, Global.Gizmox.WebGUI.Forms.Form))
		End Sub


        ''' <summary>
        ''' Handles VisibleChanged event of the example user control.
        ''' Closes all modeless Form after switch to an another example.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
		Private Sub ActivateHandlingpage_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
            Dim form As Gizmox.WebGUI.Forms.Form
            For Each form In DirectCast(Me._openedForms.ToArray.Clone, Gizmox.WebGUI.Forms.Form())
                form.Close()
            Next

		End Sub
	End Class

End Namespace
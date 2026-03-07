Namespace CompanionKit.Controls.Form.Features

	Public Class MDIFormPage

		Private _mdiForm As MDIParentForm

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the button.
        ''' Opens MDI Parent Form.
        ''' </summary>
        Private Sub mobjOpenMDIFormBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjOpenMDIFormBtn.Click
            Me._mdiForm = New MDIParentForm
            AddHandler Me._mdiForm.Closed, New EventHandler(AddressOf Me._mdiForm_Closed)
            Me._mdiForm.Show()

        End Sub

        ''' <summary>
        ''' Handles Closed event of the MDI Parent form. 
        ''' Updates values property that represents shortcut on the MDI Parent Form.
        ''' </summary>
        Private Sub _mdiForm_Closed(ByVal sender As Object, ByVal e As EventArgs)
            Me._mdiForm = Nothing
        End Sub

        ''' <summary>
        ''' Handles VisibleChanged event of the example user control.
        ''' Closes MDI Parent Form after switch to an another example.
        ''' </summary>
		Private Sub MDIFormPage_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
			If (Not Me._mdiForm Is Nothing) Then
				Me._mdiForm.Close()
			End If

		End Sub
	End Class

End Namespace
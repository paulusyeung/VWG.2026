Namespace CompanionKit.Controls.PropertyGrid.Functionality
	Public Class ObjectInspection

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()



		End Sub

		''' <summary>
		''' Select the initial and another label to inspection
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		''' <remarks></remarks>
		Private Sub objMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objMultiple.Click
			Me.objPropGrid.SelectedObjects = New Object() {Me.objInitial, Me.objAnotherLabel}
		End Sub

		''' <summary>
		''' Select the link label and change the URL property
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		''' <remarks></remarks>
		Private Sub objButton03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objButton03.Click
			Me.objPropGrid.SelectedObject = Me.objVWGLinkLabel
		End Sub

		''' <summary>
		''' Select the other label to change
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		''' <remarks></remarks>
		Private Sub objButton02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objButton02.Click
			Me.objPropGrid.SelectedObject = Me.objAnotherLabel
		End Sub

		''' <summary>
		''' Select the label to inspection
		''' Change the Text property, Border style, Border Width
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		''' <remarks></remarks>
		Private Sub objButton01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objButton01.Click
			Me.objPropGrid.SelectedObject = Me.objInitial
		End Sub
	End Class

End Namespace
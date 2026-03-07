Namespace CompanionKit.Controls.CheckedListBox.Functionality

	Public Class AddItemPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Set maximum boundary as count of Items in CheckedListBox for 
			'NumericUpDown that used to define position of added item.
            Me.mobjAddedItemPlace.Maximum = Me.mobjCheckedListBox.Items.Count



		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjAddButton.Click
            'Get text for added item
            Dim addedItemText As String = Me.mobjAddedItemText.Text
            'Check whether text for added item isn't empty.
            If String.IsNullOrEmpty(addedItemText) Then
                MessageBox.Show("Please input text for added item!")
            End If
            'Get position of added item
            Dim addedItemPlace As Integer = Decimal.ToInt32(Me.mobjAddedItemPlace.Value)
            If (addedItemPlace > Me.mobjCheckedListBox.Items.Count) Then
                addedItemPlace = Me.mobjCheckedListBox.Items.Count
            ElseIf (addedItemPlace < 0) Then
                addedItemPlace = 0
            End If
            'Insert new item to ListBox
            Me.mobjCheckedListBox.Items.Insert(addedItemPlace, Me.GetNewItemName(addedItemText))
            'Select added item
            Me.mobjCheckedListBox.SelectedIndex = addedItemPlace
            'Update maximum boundary for NumericUpDown
            Me.mobjAddedItemPlace.Maximum = Me.mobjCheckedListBox.Items.Count
        End Sub

		''' <summary>
		''' Gets name for added item. If user entered name is contained in CheckedListBox, then it will change with adds index.
		''' </summary>
		''' <param name="newItemName">User entered item name</param>
		''' <returns></returns>
		''' <remarks></remarks>
		Private Function GetNewItemName(ByVal newItemName As String) As String
			Dim addedItemName As String = newItemName
			Dim i As Integer = 1
            Do While Me.mobjCheckedListBox.Items.Contains(addedItemName)
                addedItemName = (newItemName & i)
                i += 1
            Loop
			Return addedItemName
		End Function

	End Class

End Namespace
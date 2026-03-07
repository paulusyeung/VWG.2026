Namespace CompanionKit.Controls.DomainUpDown.Programming

	Public Class AddItemsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjAddButton.Click
            ' Get text for added item
            Dim addedItemText As String = Me.mobjNameAddedItemTextBox.Text
            ' Check whether text for added item isn't empty.
            If String.IsNullOrEmpty(addedItemText) Then
                MessageBox.Show("Please input text for added item!")
            Else
                ' Insert new item to DomainUpDown
                addedItemText = Me.GetNewItemName(addedItemText)
                Me.mobjDomainUpDown.Items.Add(addedItemText)
                Me.mobjDomainUpDown.SelectedItem = addedItemText
            End If

        End Sub

        ''' <summary>
        ''' Handles the Load event of the AddItemsPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub AddItemsPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.mobjDomainUpDown.SelectedIndex = 0
        End Sub

        ''' <summary>
        ''' Gets name for added item. If user entered name is contained in the DomainUpDown, 
        ''' then it will change with adds index.
        ''' </summary>
        ''' <param name="newItemName">User entered item name</param>
        Private Function GetNewItemName(ByVal newItemName As String) As String
            Dim addedItemName As String = newItemName
            Dim i As Integer = 1
            Do While Me.mobjDomainUpDown.Items.Contains(addedItemName)
                addedItemName = (newItemName & i)
                i += 1
            Loop
            Return addedItemName
        End Function

    End Class

End Namespace
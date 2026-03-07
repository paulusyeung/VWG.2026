Namespace CompanionKit.Concepts.ClientAPI.ComboBoxItems

	Public Class ComboBoxItemsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            'Fill ComboBox with 3 default items
            mobjComboBox.Items.Add("item1")
            mobjComboBox.Items.Add("item2")
            mobjComboBox.Items.Add("item3")
            mobjComboBox.SelectedIndex = 0

        End Sub
        ''' <summary>
        ''' Fires an event.
        ''' </summary>
        ''' <param name="objEvent">event.</param>
        Protected Overrides Sub FireEvent(objEvent As Gizmox.WebGUI.Common.Interfaces.IEvent)
            'Catch custom events
            If objEvent.Type = "addItemOnServer" Then
                'Get events attributes - text of new item
                Dim strNewItemText As String = objEvent("text")

                'Add new item in ComboBox on server
                mobjComboBox.Items.Add(strNewItemText)
                If mobjComboBox.Items.Count = 1 Then
                    mobjComboBox.SelectedIndex = 0
                End If

            ElseIf objEvent.Type = "removeItemOnServer" Then
                'Get events attributes - index of item to be removed
                Dim intIndexToRemove As Integer = -1

                If Integer.TryParse(objEvent("index"), intIndexToRemove) AndAlso intIndexToRemove >= 0 AndAlso intIndexToRemove < mobjComboBox.Items.Count Then
                    'Remove item in ComboBox on server by position
                    mobjComboBox.Items.RemoveAt(intIndexToRemove)

                    ' Update selected index in mobjComboBox

                    ' If 1st item deleted and there are more items, select the 1st one
                    If intIndexToRemove = 0 AndAlso mobjComboBox.Items.Count >= 1 Then
                        mobjComboBox.SelectedIndex = 0
                    Else

                        ' If not the 1st item deleted, or there are no more items, select previous index
                        mobjComboBox.SelectedIndex = intIndexToRemove - 1
                    End If


                End If
            Else
                MyBase.FireEvent(objEvent)
            End If
        End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjAddButton.Click
            VWGClientContext.Current.Invoke("addItem")
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjRemoveButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjRemoveButton.Click
            VWGClientContext.Current.Invoke("removeItem")
        End Sub

        ''' <summary>
        ''' Handles the ClientSelectedIndexChanged event of the mobjComboBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_ClientSelectedIndexChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjComboBox.ClientSelectedIndexChanged
            objArgs.Context.Invoke("selectedChanged")
        End Sub
    End Class

End Namespace
Namespace CompanionKit.Concepts.ClientAPI.ListView

	Public Class ListViewPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

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

                'Add new item in ListView on server
                mobjListView.Items.Add(strNewItemText)

            ElseIf objEvent.Type = "fillOnServer" Then
                'Clear ListView
                mobjListView.Items.Clear()
                'Fill ListView with 5 items 
                For i As Integer = 0 To 4
                    mobjListView.Items.Add("item" + (i + 1).ToString())

                    mobjListView.Items(i).SubItems.Add("subitem" + (i + 1).ToString())
                Next

            ElseIf objEvent.Type = "removeItemOnServer" Then
                'If there are items in ListView
                If mobjListView.Items.Count > 0 Then
                    'Remove lest item in ListView on server
                    mobjListView.Items.RemoveAt(mobjListView.Items.Count - 1)
                End If

            ElseIf objEvent.Type = "removeAllOnServer" Then
                'Clear ListView
                mobjListView.Items.Clear()
            Else

                MyBase.FireEvent(objEvent)
            End If
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the mobjFillListViewButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjFillListViewButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjFillListViewButton.ClientClick
            objArgs.Context.Invoke("fillListView")
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the mobjAddItemButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddItemButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjAddItemButton.ClientClick
            objArgs.Context.Invoke("addItem")
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the mobjRemoveAllButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveAllButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjRemoveAllButton.ClientClick
            objArgs.Context.Invoke("removeAllFromListView")
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the mobjRemoveItemButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveItemButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjRemoveItemButton.ClientClick
            objArgs.Context.Invoke("removeItem")
        End Sub

        ''' <summary>
        ''' Handles the ClientSelectedIndexChanged event of the mobjListView control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub mobjListView_ClientSelectedIndexChanged(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles mobjListView.ClientSelectedIndexChanged
            objArgs.Context.Invoke("showSelectedItems")
        End Sub
    End Class

End Namespace
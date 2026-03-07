Imports Gizmox.WebGUI.Common.Resources
Namespace CompanionKit.Controls.ListView.Features

	Public Class ViewsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Fill up ListView
            Me.mobjListView.Items.Add(GetListViewItem("User1", "8-800-1234556"))
            Me.mobjListView.Items.Add(GetListViewItem("User2", "8-800-9513546"))
            Me.mobjListView.Items.Add(GetListViewItem("User3", "8-800-8524563"))
            Me.mobjListView.Items.Add(GetListViewItem("User4", "8-800-9874613"))


		End Sub

        ''' <summary>
        ''' Gets item for ListView with defined data.
        ''' </summary>
        ''' <param name="userName">User name.</param>
        ''' <param name="phone">User phone.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetListViewItem(ByVal userName As String, ByVal phone As String) As ListViewItem
            ' Create ListView item
            Dim listViewItem As New ListViewItem(New String() {userName, phone})

            ' Set icons for the ListView items that displayed when ListView is LargeIcon view mode. 
            listViewItem.LargeImage = New ImageResourceHandle("32x32.Photo.png")
            ' Set icons for the ListView items that displayed when ListView is SmallIcon view mode.
            listViewItem.SmallImage = New ImageResourceHandle("16x16.Photo.png")
            Return listViewItem
        End Function

        ''' <summary>
        ''' Handles the CheckedChanged event of the RB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub RB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjDetailsRB.CheckedChanged, mobjListRB.CheckedChanged, mobjLargeIconRB.CheckedChanged, mobjSmallIconRB.CheckedChanged
            'Set ListView.View property to selected view
            If mobjDetailsRB.Checked Then
                mobjListView.View = View.Details
            ElseIf mobjListRB.Checked Then
                mobjListView.View = View.List
            ElseIf mobjSmallIconRB.Checked Then
                mobjListView.View = View.SmallIcon
            Else
                mobjListView.View = View.LargeIcon
            End If
        End Sub

    End Class

End Namespace

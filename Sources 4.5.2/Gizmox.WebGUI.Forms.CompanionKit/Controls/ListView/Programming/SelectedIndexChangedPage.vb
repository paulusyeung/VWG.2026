Namespace CompanionKit.Controls.ListView.Programming

	Public Class SelectedIndexChangedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Fill up the ListView
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User1", "8-800-1234556"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User2", "8-800-9513546"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User3", "8-800-8524563"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User4", "8-800-9874613"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User5", "8-800-1234556"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User6", "8-800-9513546"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User7", "8-800-8524563"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User8", "8-800-9874613"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User9", "8-800-1234556"}))
            Me.mobjListView.Items.Add(New ListViewItem(New String() {"User10", "8-800-9513546"}))


		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjListView control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjListView.SelectedIndexChanged
            If (Me.mobjListView.SelectedItem Is Nothing) Then
                Me.mobjSelectedLabel.Text = "Unselected items of ListView"
            Else
                Me.mobjSelectedLabel.Text = String.Format("Item #{0} is selected with user {1} with phone {2}", Me.mobjListView.SelectedIndex, Me.mobjListView.SelectedItem.SubItems.Item(0).Text, Me.mobjListView.SelectedItem.SubItems.Item(1).Text)
            End If

        End Sub
	End Class

End Namespace
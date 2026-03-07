Imports System.Drawing
Namespace CompanionKit.Controls.ListView.Programming

	Public Class ItemFormatingValidatingPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Set DataSource as array of Colors.
			Dim knownColors As KnownColor() = DirectCast(Global.System.Enum.GetValues(GetType(KnownColor)), KnownColor())
			Dim colors As Color() = New Drawing.Color(knownColors.Length - 1) {}
			Dim i As Integer
			For i = 0 To knownColors.Length - 1
				colors(i) = Color.FromKnownColor(knownColors(i))
			Next i
            Me.mobjForeCB.DataSource = colors
            Me.mobjForeCB.ColorMember = "Name"
            Me.mobjForeCB.DisplayMember = "Name"

            Me.mobjBackCB.DataSource = colors.Clone
            Me.mobjBackCB.ColorMember = "Name"
            Me.mobjBackCB.DisplayMember = "Name"

            'Show Grid Lines
            Me.mobjListView.GridLines = True

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

            'Set default background and foreground colors
            For Each objItem As ListViewItem In Me.mobjListView.Items
                objItem.ForeColor = Color.Black
                objItem.BackColor = Color.White
            Next

		End Sub

        ''' <summary>
        ''' Handles the ItemFormatting event of the mobjListView control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="global.Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs"/> instance containing the event data.</param>
        Private Sub mobjListView_ItemFormatting(ByVal sender As System.Object, ByVal e As Global.Gizmox.WebGUI.Forms.ListViewItemFormattingEventArgs) Handles mobjListView.ItemFormatting

            'Define currently formatted item in ListView
            Dim formattedItem As ListViewItem = Me.mobjListView.SelectedItem
            If formattedItem IsNot Nothing Then
                'Change Result Text
                Me.mobjResultLabel.Text = String.Format("Item #{0} has foreground {1} and background {2} colors.", formattedItem.Index, formattedItem.ForeColor.Name, formattedItem.BackColor.Name)
            End If

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjForeCB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjForeCB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjForeCB.SelectedIndexChanged

          'Change fore color of selected item
            If Me.mobjListView.SelectedItem IsNot Nothing Then
                Me.mobjListView.SelectedItem.ForeColor = DirectCast(Me.mobjForeCB.SelectedItem, Color)
            End If

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the ComboBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjBackCB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjBackCB.SelectedIndexChanged

            'Change back color of selected item
            If Me.mobjListView.SelectedItem IsNot Nothing Then
                Me.mobjListView.SelectedItem.BackColor = DirectCast(Me.mobjBackCB.SelectedItem, Color)
            End If

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the ListView1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjListView.SelectedIndexChanged
            'Change selected items in ComboBoxes
            If Me.mobjListView.SelectedItem IsNot Nothing AndAlso Me.mobjForeCB.Items.Contains(Me.mobjListView.SelectedItem.ForeColor) Then
                Me.mobjForeCB.SelectedItem = Me.mobjListView.SelectedItem.ForeColor
            End If
            If Me.mobjListView.SelectedItem IsNot Nothing AndAlso Me.mobjForeCB.Items.Contains(Me.mobjListView.SelectedItem.BackColor) Then
                Me.mobjBackCB.SelectedItem = Me.mobjListView.SelectedItem.BackColor
            End If
        End Sub
	End Class

End Namespace
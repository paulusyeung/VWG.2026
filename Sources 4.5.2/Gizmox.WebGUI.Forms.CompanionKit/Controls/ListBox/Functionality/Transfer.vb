Namespace CompanionKit.Controls.ListBox.Functionality

	Public Class Transfer

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()



		End Sub

        ''' <summary>
        ''' Handles the Click event of the BtnAllToLeft control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub btnAllToLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllToLeft.Click
            'Add all items of the right ListBox into the left ListBox
            Me.mobjListBox1.Items.AddRange(Me.mobjListBox2.Items)
            'Remove all items from the left ListBox 
            Me.mobjListBox2.Items.Clear()
            Me.UpdatedEnableStatusForTransferedButtons()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the BtnToLeft control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub btnToLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToLeft.Click
            'Add selected items of the right ListBox into the left ListBox
            Me.mobjListBox1.Items.AddRange(Me.mobjListBox2.SelectedItems)
            'Remove selected items from the right ListBox 
            Dim selectedItems As String() = New String(Me.mobjListBox2.SelectedItems.Count - 1) {}
            Me.mobjListBox2.SelectedItems.CopyTo(selectedItems, 0)
            Dim selectedItem As String
            For Each selectedItem In selectedItems
                Me.mobjListBox2.Items.Remove(selectedItem)
            Next
            Me.UpdatedEnableStatusForTransferedButtons()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the BtnAllToRight control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub btnAllToRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllToRight.Click
            'Add selected items of the left ListBox into the right ListBoxAdd all items of the left ListBox into the right ListBox
            Me.mobjListBox2.Items.AddRange(Me.mobjListBox1.Items)
            'Remove all items from the left ListBox 
            Me.mobjListBox1.Items.Clear()
            Me.UpdatedEnableStatusForTransferedButtons()

        End Sub

        ''' <summary>
        ''' Handles the Click event of the BtnToRight control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub btnToRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToRight.Click
            'Add selected items of the left ListBox into the right ListBox
            Me.mobjListBox2.Items.AddRange(Me.mobjListBox1.SelectedItems)
            'Remove selected items from the left ListBox 
            Dim selectedItems As String() = New String(Me.mobjListBox1.SelectedItems.Count - 1) {}
            Me.mobjListBox1.SelectedItems.CopyTo(selectedItems, 0)
            Dim selectedItem As String
            For Each selectedItem In selectedItems
                Me.mobjListBox1.Items.Remove(selectedItem)
            Next
            Me.UpdatedEnableStatusForTransferedButtons()

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjListBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjListBox1.SelectedIndexChanged
            'Set initial enable state for buttons that transfer 
            'item between left and right ListBoxes
            Me.UpdatedEnableStatusForTransferedButtons()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjListBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjListBox2.SelectedIndexChanged
            'Set initial enable state for buttons that transfer 
            'item between left and right ListBoxes
            Me.UpdatedEnableStatusForTransferedButtons()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the Transfer control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		Private Sub Transfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'Set initial enable state for buttons that transfer 
			'item between left and right ListBoxes
			Me.UpdatedEnableStatusForTransferedButtons()
		End Sub

		''' <summary>
		''' Updates enable state for buttons that transfer item between left and right ListBoxes
		''' </summary>
		''' <remarks></remarks>
		Private Sub UpdatedEnableStatusForTransferedButtons()
            If Not ((Me.mobjListBox1.Items.Count <= 0) OrElse Me.btnAllToRight.Enabled) Then
                Me.btnAllToRight.Enabled = True
            End If
            If ((Me.mobjListBox1.Items.Count < 1) AndAlso Me.btnAllToRight.Enabled) Then
                Me.btnAllToRight.Enabled = False
            End If
            If Not ((Me.mobjListBox1.SelectedItems.Count <= 0) OrElse Me.btnToRight.Enabled) Then
                Me.btnToRight.Enabled = True
            End If
            If ((Me.mobjListBox1.SelectedItems.Count < 1) AndAlso Me.btnToRight.Enabled) Then
                Me.btnToRight.Enabled = False
            End If
            If Not ((Me.mobjListBox2.Items.Count <= 0) OrElse Me.btnAllToLeft.Enabled) Then
                Me.btnAllToLeft.Enabled = True
            End If
            If ((Me.mobjListBox2.Items.Count < 1) AndAlso Me.btnAllToLeft.Enabled) Then
                Me.btnAllToLeft.Enabled = False
            End If
            If Not ((Me.mobjListBox2.SelectedItems.Count <= 0) OrElse Me.btnToLeft.Enabled) Then
                Me.btnToLeft.Enabled = True
            End If
            If ((Me.mobjListBox2.SelectedItems.Count < 1) AndAlso Me.btnToLeft.Enabled) Then
                Me.btnToLeft.Enabled = False
            End If
		End Sub

	End Class

End Namespace
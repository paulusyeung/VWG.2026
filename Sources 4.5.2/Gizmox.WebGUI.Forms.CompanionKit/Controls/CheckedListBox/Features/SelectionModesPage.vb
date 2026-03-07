Namespace CompanionKit.Controls.CheckedListBox.Features

	Public Class SelectionModesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
		End Sub

        ''' <summary>
        ''' Handles the Load event of the SelectionModesPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub SelectionModesPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Fill up ComboBox with avalaible selection mode of the CheckedListBox.
            Dim defaultSelectionMode As SelectionMode = Me.mobjCheckedListBox.SelectionMode
            Me.mobjSelectionModesComboBox.DataSource = System.Enum.GetValues(GetType(SelectionMode))
            Me.mobjSelectionModesComboBox.SelectedItem = defaultSelectionMode

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjSelectionModesComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSelectionModesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSelectionModesComboBox.SelectedIndexChanged

            Dim newSelectionMode As SelectionMode = DirectCast(Me.mobjSelectionModesComboBox.SelectedItem, SelectionMode)
            Me.mobjCheckedListBox.SelectionMode = newSelectionMode
            Select Case newSelectionMode
                Case SelectionMode.None
                    ' Unchecked all items'CheckBoxes
                    Dim checkedItemIndex As Integer
                    For Each checkedItemIndex In Me.mobjCheckedListBox.CheckedIndices
                        Me.mobjCheckedListBox.SetItemChecked(checkedItemIndex, False)
                    Next
                    Exit Select
            End Select

        End Sub

        ''' <summary>
        ''' Handles the ItemCheck event of the mobjCheckedListBox control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckedListBox_ItemCheck(ByVal objSender As System.Object, ByVal objArgs As Gizmox.WebGUI.Forms.ItemCheckEventArgs) Handles mobjCheckedListBox.ItemCheck

            ' unallow to check item if selection mode is none.
            If ((Me.mobjCheckedListBox.SelectionMode = SelectionMode.None) AndAlso (objArgs.NewValue = CheckState.Checked)) Then
                Me.mobjCheckedListBox.SetItemChecked(objArgs.Index, False)
            End If

        End Sub
    End Class

End Namespace

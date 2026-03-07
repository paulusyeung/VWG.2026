Namespace CompanionKit.Controls.DomainUpDown.Programming

	Public Class RemoveItemsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjRemoveItemByNameRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveItemByNameRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjRemoveItemByNameRadioButton.CheckedChanged
            ' Enable/Disable ComboBox that contain items of the DomainUpDown.
            Me.mobjRemoveItemComboBox.Enabled = Me.mobjRemoveItemByNameRadioButton.Checked

        End Sub

        ''' <summary>
        ''' Handles the Click event of the removeItemButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveItemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjRemoveItemButton.Click

            Dim selectedItem As String = ""
            If Me.mobjRemoveItemByNameRadioButton.Checked Then
                ' Check if ComboBox has selected item
                If Not Me.mobjRemoveItemComboBox.SelectedItem Is Nothing Then
                    '  Remove item by name
                    selectedItem = CStr(Me.mobjRemoveItemComboBox.SelectedItem)
                    Me.mobjDomainUpDown.Items.Remove(selectedItem)
                End If
            Else
                '  Remove item by position
                Dim index As Integer = Decimal.ToInt16(Me.mobjRemoveItemByPositionNumericUpDown.Value)
                selectedItem = CStr(Me.mobjDomainUpDown.Items.Item(index))
                Me.mobjDomainUpDown.Items.RemoveAt(index)
            End If
            Me.mobjRemoveItemComboBox.Items.Remove(selectedItem)

            If (Me.mobjDomainUpDown.Items.Count > 0) Then
                Me.mobjRemoveItemByPositionNumericUpDown.Maximum = (Me.mobjDomainUpDown.Items.Count - 1)
                Me.mobjRemoveItemComboBox.SelectedIndex = 0
                Me.mobjRemoveItemComboBox.Text = CStr(Me.mobjRemoveItemComboBox.SelectedItem)
                Me.mobjDomainUpDown.SelectedIndex = 0
            Else
                Me.mobjRemoveItemComboBox.Enabled = False
                Me.mobjRemoveItemComboBox.Text = String.Empty
                Me.mobjRemoveItemByPositionNumericUpDown.Enabled = False
                Me.mobjRemoveItemButton.Enabled = False
                Me.mobjDomainUpDown.Text = "DomainUpDown is empty"
                Me.mobjDomainUpDown.Enabled = False
            End If


        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the removeItemByPositionRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveItemByPositionRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjRemoveItemByPositionRadioButton.CheckedChanged
            '  Enable/Disable NumericUpDown that item indices of the DomainUpDown.
            Me.mobjRemoveItemByPositionNumericUpDown.Enabled = Me.mobjRemoveItemByPositionRadioButton.Checked
        End Sub

        ''' <summary>
        ''' Handles the Load event of the RemoveItemsPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub RemoveItemsPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up DomainUpDown and ComboBox with string values
            Dim i As Integer
            For i = 0 To 30 - 1
                Dim objItem As String = String.Format("Item{0}", i)
                Me.mobjRemoveItemComboBox.Items.Add(objItem)
                Me.mobjDomainUpDown.Items.Add(objItem)
            Next i
            '  Limit upper bound of the NumericUpDown with number of items in DomainUpDown cintrol.
            Me.mobjRemoveItemByPositionNumericUpDown.Maximum = (Me.mobjDomainUpDown.Items.Count - 1)
            Me.mobjRemoveItemComboBox.SelectedIndex = 0
            Me.mobjDomainUpDown.SelectedIndex = 0
            Me.mobjRemoveItemByNameRadioButton.Checked = True

        End Sub
    End Class

End Namespace

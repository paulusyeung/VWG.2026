Namespace CompanionKit.Controls.ListBox.Features

	Public Class SortedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
			'Set CheckBox Checked property value to false.
            Me.mobjIsSorted.Checked = False
			'Set initially state for controls which related from checked the ComboBox. 
			Me.UpdateControlProperty()

		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjIsSorted control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjIsSorted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjIsSorted.CheckedChanged
            'Updates state for controls which related from checked the ComboBox.
            Me.UpdateControlProperty()
        End Sub

		''' <summary>
		''' Sets unsorted data to ListBox.
		''' </summary>
		''' <remarks></remarks>
		Private Sub SetUnsortedArrayString()
            Me.mobjListBox.Items.Clear()
            Me.mobjListBox.Items.AddRange(New Object() {"A item", "X item", "Y item", "I item", "J item", "K item", "L item", "M item", "N item", "O item", "B item", "C item", "T item", "U item", "V item", "D item", "E item", "F item", "G item", "P item", "Q item", "R item", "S item", "W item", "Z item"})
		End Sub

		''' <summary>
		''' Updates initially state for controls which related from checked the ComboBox. 
		''' </summary>
		''' <remarks></remarks>
		Private Sub UpdateControlProperty()
            Me.mobjListBox.Sorted = Me.mobjIsSorted.Checked
            Me.mobjLabel.Text = String.Format("The items are {0}", IIf(Me.mobjIsSorted.Checked, "sorted alphabetically", "not sorted"))
            If Not Me.mobjListBox.Sorted Then
                Me.SetUnsortedArrayString()
            End If
		End Sub

	End Class

End Namespace

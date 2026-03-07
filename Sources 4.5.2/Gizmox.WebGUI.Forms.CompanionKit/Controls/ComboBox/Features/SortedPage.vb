Namespace CompanionKit.Controls.ComboBox.Features

	Public Class SortedPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            'Set CheckBox Checked property value to false.
            Me.mobjCheckBox.Checked = False

            'Set initially state for controls which related from checked the ComboBox. 

            UpdateControlProperty()
        End Sub
        ''' <summary>
        ''' Updates initially state for controls which related from checked the ComboBox. 
        ''' </summary>
        Private Sub UpdateControlProperty()
            Me.mobjComboBox.Sorted = Me.mobjCheckBox.Checked
            If Me.mobjCheckBox.Checked Then
                Me.mobjLabel.Text = "Items are sorted"
            Else
                Me.mobjLabel.Text = "Items are not sorted"
                SetUnsortedArrayString()
            End If
        End Sub

        Private Sub mobjCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBox.CheckedChanged
            'Updates state for controls which related from checked the ComboBox.
            UpdateControlProperty()
        End Sub

        ''' <summary>
        ''' Sets unsorted data to ComboBox.
        ''' </summary>
        Private Sub SetUnsortedArrayString()
            Me.mobjComboBox.Items.Clear()
            Me.mobjComboBox.Items.AddRange(New Object() {"A item", "X item", "Y item", "I item", "J item", "K item", _
             "L item", "M item", "N item", "O item", "B item", "C item", _
             "T item", "U item", "V item", "D item", "E item", "F item", _
             "G item", "P item", "Q item", "R item", "S item", "W item", _
             "Z item"})
            Me.mobjComboBox.SelectedIndex = 0
        End Sub

	End Class

End Namespace

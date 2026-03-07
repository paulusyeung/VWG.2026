Namespace CompanionKit.Controls.ListBox.Appearance

    Public Class CheckBoxAndRadioButtonsPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            'Set initial Normal view for LitBox. ListBox' item will be displayed without RadioButton and CheckBox
            UpdateListBoxCaption()
        End Sub
        ''' <summary>
        ''' Update text of the ListBox caption label according to the selected  item view type
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdateListBoxCaption()
            Dim listBoxItemsViewType As String = ""
            If Me.checkBoxViewRadioButton.Checked Then
                listBoxItemsViewType = "checkbox "
            ElseIf Me.radioButtonViewRadioButton.Checked Then
                listBoxItemsViewType = "radiobutton "
            End If
            Me.mobjDescritionLabel.Text = String.Format("Listbox with {0}items:", listBoxItemsViewType)
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the normalViewRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub normalViewRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles normalViewRadioButton.CheckedChanged
            UpdateListBoxCaption()
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the checkBoxViewRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub checkBoxViewRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkBoxViewRadioButton.CheckedChanged
            'Change CheckBoxes property value to checked state of 'CheckBox' RadioButton.
            ' If value is true, ListBox item will be displayed with CheckBox, 
            ' otherwise it will be displayed without CheckBox
            Me.mobjListBox.CheckBoxes = Me.checkBoxViewRadioButton.Checked
            UpdateListBoxCaption()
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the radioButtonViewRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub radioButtonViewRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radioButtonViewRadioButton.CheckedChanged
            'Change RadioBoxes property value to checked state of 'RadioButton' RadioButton.
            ' If value is true, ListBox item will be displayed with RadioButton, 
            ' otherwise it will be displayed without RadioButton
            Me.mobjListBox.RadioBoxes = Me.radioButtonViewRadioButton.Checked
            UpdateListBoxCaption()
        End Sub
    End Class

End Namespace

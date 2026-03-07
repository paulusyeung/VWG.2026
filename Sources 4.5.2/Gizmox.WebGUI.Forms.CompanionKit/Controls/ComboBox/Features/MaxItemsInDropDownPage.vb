Namespace CompanionKit.Controls.ComboBox.Features

	Public Class MaxItemsInDropDownPage

		Public Sub New()
            InitializeComponent()
            Me.mobjComboBox.SelectedIndex = 0
            'Set text for TextBox as initially value of tested ComboBox MaxDropDownItems property.
            Me.mobjTextBox.Text = Me.mobjComboBox.MaxDropDownItems.ToString()
            'Set validator on input text for TextBox. The TextBox have to input only digits.
            Me.mobjTextBox.Validator = New TextBoxValidation("", "", String.Concat("0-9"))
        End Sub

        Private Sub mobjTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjTextBox.TextChanged

            'If value of the TextBox is changed then new value is set for tested ComboBox 
            'MaxDropDownItems property after losing focus from the TextBox
            If Not String.IsNullOrEmpty(Me.mobjTextBox.Text) Then
                Me.mobjComboBox.MaxDropDownItems = Integer.Parse(Me.mobjTextBox.Text)
            End If
        End Sub
	End Class

End Namespace
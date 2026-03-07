Namespace CompanionKit.Controls.Form.Features
	Public Class DialogReturnValueForm


        ''' <summary>
        ''' Handles Click event of the 'Cancel' button.
        ''' Closes the Form and set Cancel dialog result for the Form.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub mobjCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjCancelButton.Click
            MyBase.DialogResult = DialogResult.Cancel
            MyBase.Close()
        End Sub

        ''' <summary>
        ''' Handles Click event of the 'Save' button.
        ''' Closes the Form and set OK dialog result for the Form.
        ''' </summary>
        Private Sub mobjSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSaveButton.Click
            MyBase.DialogResult = WebGUI.Forms.DialogResult.OK
            MyBase.Close()
        End Sub

        ''' <summary>
        ''' Gets or sets text value of the TextBox that represents user email.
        ''' </summary>
		Public Property Email() As String
			Get
                Return Me.mobjEmailTextBox.Text
			End Get
			Set(ByVal value As String)
                Me.mobjEmailTextBox.Text = value
			End Set
		End Property

        ''' <summary>
        ''' Gets or sets text value of the TextBox that represents user phone.
        ''' </summary>
		Public Property Phone() As String
			Get
                Return Me.mobjPhoneTextBox.Text
			End Get
			Set(ByVal value As String)
                Me.mobjPhoneTextBox.Text = value
			End Set
		End Property

        ''' <summary>
        ''' Gets or sets text value of the TextBox that represents user first name.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
		Public Property UserFirstName() As String
			Get
                Return Me.mobjUserFirstNameTextBox.Text
			End Get
			Set(ByVal value As String)
                Me.mobjUserFirstNameTextBox.Text = value
			End Set
		End Property

        ''' <summary>
        ''' Gets or sets user full name.
        ''' </summary>
		Public ReadOnly Property UserFullName() As String
			Get
                Return String.Format("{0} {1}", Me.mobjUserFirstNameTextBox.Text, Me.mobjUserLastNameTextBox.Text)
			End Get
		End Property

        ''' <summary>
        ''' Gets or sets text value of the TextBox that represents user last name.
        ''' </summary>
		Public Property UserLastName() As String
			Get
                Return Me.mobjUserLastNameTextBox.Text
			End Get
			Set(ByVal value As String)
                Me.mobjUserLastNameTextBox.Text = value
			End Set
		End Property


	End Class

End Namespace

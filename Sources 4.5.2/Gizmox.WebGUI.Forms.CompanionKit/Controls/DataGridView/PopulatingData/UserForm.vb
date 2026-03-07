Namespace CompanionKit.Controls.DataGridView.PopulatingData
    Public Class UserForm


        ''' <summary>
        ''' Handles Click event for 'Ok' button of the user form.
        ''' Sets OK dialog result for the form and closes the form.
        ''' </summary>
        Private Sub okBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okBtn.Click
            MyBase.DialogResult = DialogResult.OK
            MyBase.Close()

        End Sub

        ''' <summary>
        ''' Handles Click event for 'Cancel' button of the user form.
        ''' Sets Cancel dialog result for the form and closes the form.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
            MyBase.DialogResult = DialogResult.Cancel
            MyBase.Close()

        End Sub

        ' Properties
        ''' <summary>
        '''  Gets or sets address of user.
        ''' </summary>
        Public Property Address() As String
            Get
                Return Me.AddressTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.AddressTextBox.Text = value
            End Set
        End Property

        ''' <summary>
        '''  Gets or sets city of user.
        ''' </summary>
        Public Property City() As String
            Get
                Return Me.cityTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.cityTextBox.Text = value
            End Set
        End Property

        ''' <summary>
        '''  Gets or sets country of user.
        ''' </summary>
        Public Property Country() As String
            Get
                Return Me.CountryTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.CountryTextBox.Text = value
            End Set
        End Property

        ''' <summary>
        '''  Gets or sets email of user.
        ''' </summary>
        Public Property Email() As String
            Get
                Return Me.EmailTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.EmailTextBox.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets phone of user.
        ''' </summary>
        Public Property Phone() As String
            Get
                Return Me.PhoneTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.PhoneTextBox.Text = value
            End Set
        End Property


        ''' <summary>
        ''' Gets or sets state of user.
        ''' </summary>
        Public Property State() As String
            Get
                Return Me.StateTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.StateTextBox.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets user id.
        ''' </summary>
        Public Property UserID() As Integer
            Get
                Return Integer.Parse(Me.UserIDTextBox.Text)
            End Get
            Set(ByVal value As Integer)
                Me.UserIDTextBox.Text = value.ToString
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets name of user.
        ''' </summary>
        Public Property UserName() As String
            Get
                Return Me.userNameTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.userNameTextBox.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets ZipCode of user.
        ''' </summary>
        Public Property ZipCode() As String
            Get
                Return Me.ZipCodeTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.ZipCodeTextBox.Text = value
            End Set
        End Property

    End Class
End Namespace
Imports System.Text.RegularExpressions


Namespace CompanionKit.Controls.ErrorProvider.ApplicationScenarios

    Public Class ErrorProviderValidatingAFormPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Load event of the ErrorProviderValidatingAFormPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub ErrorProviderValidatingAFormPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Add items to 'Gender' ComboBox
            Me.mobjGenderCB.Items.Add("Male")
            Me.mobjGenderCB.Items.Add("Female")
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjRegisterButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRegisterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjRegisterButton.Click
            ' Check if all data entered is valid
            If Me.IsValid Then
                ' Show success message
                MessageBox.Show("You have successfully registered!")
            End If
        End Sub
        ''' <summary>
        ''' Performs entered data validation
        ''' </summary>
        Private Function IsValid() As Boolean
            ' Declare variable to return
            Dim _isValid As Boolean = True
            ' Validate First Name entered
            If (Me.mobjFirstNameTextBox.Text = String.Empty) Then
                ' Set error with message on the control
                Me.mobjErrorProviderFailed.SetError(Me.mobjFirstNameTextBox, "Please enter First Name")
                _isValid = False
            Else
                ' Set success and message on the control
                Me.mobjErrorProviderSuccess.SetError(Me.mobjFirstNameTextBox, "OK")
            End If
            ' Validate Last Name entered
            If (Me.mobjLastNameTextBox.Text = String.Empty) Then
                ' Set error with message on the control
                Me.mobjErrorProviderFailed.SetError(Me.mobjLastNameTextBox, "Please enter Last Name")
                _isValid = False
            Else
                ' Set success and message on the control
                Me.mobjErrorProviderSuccess.SetError(Me.mobjLastNameTextBox, "OK")
            End If
            ' Validate Username entered
            If (Me.mobjUsernameTextBox.Text = String.Empty) Then
                ' Set error with message on the control
                Me.mobjErrorProviderFailed.SetError(Me.mobjUsernameTextBox, "Please enter Username")
                _isValid = False
            Else
                ' Set success and message on the control
                Me.mobjErrorProviderSuccess.SetError(Me.mobjUsernameTextBox, "OK")
            End If
            ' Validate Password entered
            If (Me.mobjPasswordTextBox.Text = String.Empty) Then
                ' Set error with message on the control
                Me.mobjErrorProviderFailed.SetError(Me.mobjPasswordTextBox, "Please enter Password")
                _isValid = False
            Else
                ' Set success and message on the control
                Me.mobjErrorProviderSuccess.SetError(Me.mobjPasswordTextBox, "OK")
            End If
            ' Validate Gender selected
            If (Me.mobjGenderCB.SelectedItem Is Nothing) Then
                ' Set error with message on the control
                Me.mobjErrorProviderFailed.SetError(Me.mobjGenderCB, "Please select Gender")
                _isValid = False
            Else
                ' Set success and message on the control
                Me.mobjErrorProviderSuccess.SetError(Me.mobjGenderCB, "OK")
            End If
            ' Validate Email entered
            If (Me.mobjEmailTextBox.Text = String.Empty) Then
                ' Set error with message on the control
                Me.mobjErrorProviderFailed.SetError(Me.mobjEmailTextBox, "Please enter Email")
                _isValid = False
            Else
                ' Set pattern for Email
                Dim regex As New Regex("^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                ' Check if Email is valid
                If Not regex.Match(Me.mobjEmailTextBox.Text).Success Then
                    ' Set error with message on the control
                    Me.mobjErrorProviderFailed.SetError(Me.mobjEmailTextBox, "Please enter correct Email")
                    _isValid = False
                Else
                    ' Set success and message on the control
                    Me.mobjErrorProviderSuccess.SetError(Me.mobjEmailTextBox, "OK")
                End If
            End If
            ' Check if terms are agreed
            If Not Me.mobjAgreeTermsCheck.Checked Then
                ' Set error with message on the control
                Me.mobjErrorProviderFailed.SetError(Me.mobjAgreeTermsCheck, "You have to agree to the terms")
                Return False
            End If
            ' Remove error and message from the control
            Me.mobjErrorProviderFailed.SetError(Me.mobjAgreeTermsCheck, "")
            Return _isValid
        End Function

    End Class

End Namespace
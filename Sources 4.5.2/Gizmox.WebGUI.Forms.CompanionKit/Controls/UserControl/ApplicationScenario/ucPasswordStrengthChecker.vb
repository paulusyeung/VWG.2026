Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports System.Text.RegularExpressions
Imports System.Drawing


Public Class ucPasswordStrengthChecker

    ' Public property that is used for retrieving password entered
    Public ReadOnly Property Password() As String
        Get
            ' Get password TextBox text value
            Return Me.tbPassword.Text
        End Get
    End Property

    ''' <summary>
    ''' Handles Click event of the the 'Check' button
    ''' </summary>
    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        ' Check if password is entered
        If (String.IsNullOrEmpty(tbPassword.Text)) Then
            ' Show warning message
            MessageBox.Show("Please enter the password!")
            Return
        End If

        ' Save the password entered into local variable
        Dim password As String = tbPassword.Text
        ' Create regular expression for strong password
        Dim strongPattern As Regex = New Regex("^(?=.*[a-z].*[a-z])(?=.*[A-Z].*[A-Z])(?=.*\d.*\d)(?=.*\W.*\W)[a-zA-Z0-9\S]{9,}$")
        ' Create regular expression for good password
        Dim goodPattern As Regex = New Regex("^(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{7,30}$")

        ' Check if password matches the strong password pattern
        If (strongPattern.Match(password).Success) Then
            ' Change backgtound color for label
            lblResult.BackColor = Color.LightGreen
            ' Change text for label
            lblResult.Text = "Strong password"

            ' Check if password matches the good password pattern
        ElseIf (goodPattern.Match(password).Success) Then
            ' Change backgtound color for label
            lblResult.BackColor = Color.Yellow
            ' Change text for label
            lblResult.Text = "Good password"
        Else
            ' Change backgtound color for label
            lblResult.BackColor = Color.LightCoral
            ' Change text for label
            lblResult.Text = "Weak password"
        End If

        ' Show label
        lblResult.Visible = True
        ' Show 'Help' button
        btnHelp.Visible = True

    End Sub
    ''' <summary>
    ''' Handles Click event of the 'Help' button
    ''' </summary>
    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        ' Set message text for help window
        Dim helpMessage As String = "Strong password: requires at least two lowercase letters," & vbCrLf & _
"two uppercase letters, two digits, and two special characters. " & vbCrLf & _
"There must be a minimum of 9 characters total, and no white space" & vbCrLf & _
"characters are allowed." & vbCrLf & _
vbCrLf & _
"Good password: requires at least 1 lower case, 1 upper case, " & vbCrLf & _
"1 numeric, 1 non-word. There must be a minimum of 7 characters " & vbCrLf & _
"total, and no white space characters are allowed."

        ' Show help window
        MessageBox.Show(helpMessage, "Help topic", MessageBoxButtons.OK, MessageBoxIcon.Information, True)
    End Sub
End Class

Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPasswordStrengthChecker
    Inherits Gizmox.WebGui.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Visual WebGui Designer
    Private Shadows components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Visual WebGui Designer
    'It can be modified using the Visual WebGui Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblDescription = New Gizmox.WebGUI.Forms.Label()
        Me.tbPassword = New Gizmox.WebGUI.Forms.TextBox()
        Me.lblResult = New Gizmox.WebGUI.Forms.Label()
        Me.btnCheck = New Gizmox.WebGUI.Forms.Button()
        Me.btnHelp = New Gizmox.WebGUI.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' lblDescription
        ' 
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(12, 12)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(35, 13)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Enter your password"
        ' 
        ' tbPassword
        ' 
        Me.tbPassword.AllowDrag = False
        Me.tbPassword.Location = New System.Drawing.Point(14, 35)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = "*"c
        Me.tbPassword.Size = New System.Drawing.Size(175, 30)
        Me.tbPassword.TabIndex = 1
        ' 
        ' lblResult
        ' 
        Me.lblResult.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
        Me.lblResult.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
        Me.lblResult.Location = New System.Drawing.Point(14, 73)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(175, 30)
        Me.lblResult.TabIndex = 2
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblResult.Visible = False
        ' 
        ' btnCheck
        ' 
        Me.btnCheck.Location = New System.Drawing.Point(202, 35)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(106, 30)
        Me.btnCheck.TabIndex = 3
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        ' 
        ' btnHelp
        ' 
        Me.btnHelp.Location = New System.Drawing.Point(202, 73)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(106, 30)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "Help"
        Me.btnHelp.Visible = False
        ' 
        ' ucPasswordStrengthChecker
        ' 
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.lblDescription)
        Me.Size = New System.Drawing.Size(318, 126)
        Me.Text = "ucPasswordStrengthChecker"
        Me.ResumeLayout(False)

    End Sub

    Private lblDescription As Label
    Private tbPassword As TextBox
    Private lblResult As Label
    Private WithEvents btnCheck As Button
    Private WithEvents btnHelp As Button

End Class

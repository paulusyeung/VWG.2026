Namespace CompanionKit.Concepts.ClientAPI.ValidationForm

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ValidationFormPage
		Inherits UserControl

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If disposing AndAlso components IsNot Nothing Then
					components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		'Required by the Visual WebGui UserControl Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the WebGui UserControl Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
            Me.objPasswordLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objMailLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objLoginButton = New Gizmox.WebGUI.Forms.Button()
            Me.objPasswordTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.objMailTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.SuspendLayout()
            '
            'objPasswordLabel
            '
            Me.objPasswordLabel.AutoSize = True
            Me.objPasswordLabel.Location = New System.Drawing.Point(26, 91)
            Me.objPasswordLabel.Name = "objPasswordLabel"
            Me.objPasswordLabel.Size = New System.Drawing.Size(35, 13)
            Me.objPasswordLabel.TabIndex = 4
            Me.objPasswordLabel.Text = "Password"
            '
            'objMailLabel
            '
            Me.objMailLabel.AutoSize = True
            Me.objMailLabel.Location = New System.Drawing.Point(44, 35)
            Me.objMailLabel.Name = "objMailLabel"
            Me.objMailLabel.Size = New System.Drawing.Size(35, 13)
            Me.objMailLabel.TabIndex = 3
            Me.objMailLabel.Text = "E-mail"
            '
            'objLoginButton
            '
            Me.objLoginButton.Location = New System.Drawing.Point(114, 154)
            Me.objLoginButton.Name = "objLoginButton"
            Me.objLoginButton.Size = New System.Drawing.Size(187, 23)
            Me.objLoginButton.TabIndex = 2
            Me.objLoginButton.Text = "Login"
            '
            'objPasswordTextBox
            '
            Me.objPasswordTextBox.AllowDrag = False
            Me.objPasswordTextBox.ClientId = "password"
            Me.objPasswordTextBox.Location = New System.Drawing.Point(114, 88)
            Me.objPasswordTextBox.Name = "objPasswordTextBox"
            Me.objPasswordTextBox.Size = New System.Drawing.Size(187, 20)
            Me.objPasswordTextBox.TabIndex = 1
            Me.objPasswordTextBox.UseSystemPasswordChar = True
            '
            'objMailTextBox
            '
            Me.objMailTextBox.AllowDrag = False
            Me.objMailTextBox.ClientId = "email"
            Me.objMailTextBox.Location = New System.Drawing.Point(114, 32)
            Me.objMailTextBox.Name = "objMailTextBox"
            Me.objMailTextBox.Size = New System.Drawing.Size(187, 20)
            Me.objMailTextBox.TabIndex = 0
            '
            'ValidationFormPage
            '
            Me.ClientId = "form"
            Me.Controls.Add(Me.objMailTextBox)
            Me.Controls.Add(Me.objPasswordTextBox)
            Me.Controls.Add(Me.objLoginButton)
            Me.Controls.Add(Me.objMailLabel)
            Me.Controls.Add(Me.objPasswordLabel)
            Me.Size = New System.Drawing.Size(331, 239)
            Me.Text = "ValidationFormPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objPasswordLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objMailLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objLoginButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objPasswordTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents objMailTextBox As Gizmox.WebGUI.Forms.TextBox

	End Class

End Namespace
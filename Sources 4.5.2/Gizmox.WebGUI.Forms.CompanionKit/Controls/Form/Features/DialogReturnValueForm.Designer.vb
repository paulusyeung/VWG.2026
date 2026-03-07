Namespace CompanionKit.Controls.Form.Features
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DialogReturnValueForm
		Inherits Global.Gizmox.WebGUI.Forms.Form

		'Form overrides dispose to clean up the component list.
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
            Me.mobjUserFirstNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjUserFirstNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjUserLastNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjUserLastNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPhoneLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPhoneTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjEmailLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjEmailTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjSaveButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjCancelButton = New Gizmox.WebGUI.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' mobjUserFirstNameLabel
            ' 
            Me.mobjUserFirstNameLabel.AutoSize = True
            Me.mobjUserFirstNameLabel.Location = New System.Drawing.Point(12, 19)
            Me.mobjUserFirstNameLabel.Name = "userFirstNameLabel"
            Me.mobjUserFirstNameLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjUserFirstNameLabel.TabIndex = 0
            Me.mobjUserFirstNameLabel.Text = "User First Name"
            ' 
            ' mobjUserFirstNameTextBox
            ' 
            Me.mobjUserFirstNameTextBox.AllowDrag = False
            Me.mobjUserFirstNameTextBox.Location = New System.Drawing.Point(15, 39)
            Me.mobjUserFirstNameTextBox.Name = "textBox1"
            Me.mobjUserFirstNameTextBox.Size = New System.Drawing.Size(130, 30)
            Me.mobjUserFirstNameTextBox.TabIndex = 1
            ' 
            ' mobjUserLastNameLabel
            ' 
            Me.mobjUserLastNameLabel.AutoSize = True
            Me.mobjUserLastNameLabel.Location = New System.Drawing.Point(169, 19)
            Me.mobjUserLastNameLabel.Name = "label2"
            Me.mobjUserLastNameLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjUserLastNameLabel.TabIndex = 2
            Me.mobjUserLastNameLabel.Text = "User Last Name"
            ' 
            ' mobjUserLastNameTextBox
            ' 
            Me.mobjUserLastNameTextBox.AllowDrag = False
            Me.mobjUserLastNameTextBox.Location = New System.Drawing.Point(172, 39)
            Me.mobjUserLastNameTextBox.Name = "textBox2"
            Me.mobjUserLastNameTextBox.Size = New System.Drawing.Size(130, 30)
            Me.mobjUserLastNameTextBox.TabIndex = 3
            ' 
            ' mobjPhoneLabel
            ' 
            Me.mobjPhoneLabel.AutoSize = True
            Me.mobjPhoneLabel.Location = New System.Drawing.Point(12, 82)
            Me.mobjPhoneLabel.Name = "label3"
            Me.mobjPhoneLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjPhoneLabel.TabIndex = 4
            Me.mobjPhoneLabel.Text = "Phone"
            ' 
            ' mobjPhoneTextBox
            ' 
            Me.mobjPhoneTextBox.AllowDrag = False
            Me.mobjPhoneTextBox.Location = New System.Drawing.Point(12, 102)
            Me.mobjPhoneTextBox.Name = "phoneTextBox"
            Me.mobjPhoneTextBox.Size = New System.Drawing.Size(130, 30)
            Me.mobjPhoneTextBox.TabIndex = 5
            ' 
            ' mobjEmailLabel
            ' 
            Me.mobjEmailLabel.AutoSize = True
            Me.mobjEmailLabel.Location = New System.Drawing.Point(169, 82)
            Me.mobjEmailLabel.Name = "emailLabel"
            Me.mobjEmailLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjEmailLabel.TabIndex = 6
            Me.mobjEmailLabel.Text = "E-mail"
            ' 
            ' mobjEmailTextBox
            ' 
            Me.mobjEmailTextBox.AllowDrag = False
            Me.mobjEmailTextBox.Location = New System.Drawing.Point(172, 102)
            Me.mobjEmailTextBox.Name = "emailTextBox"
            Me.mobjEmailTextBox.Size = New System.Drawing.Size(130, 30)
            Me.mobjEmailTextBox.TabIndex = 7
            ' 
            ' mobjSaveButton
            ' 
            Me.mobjSaveButton.Location = New System.Drawing.Point(12, 153)
            Me.mobjSaveButton.Name = "saveButton"
            Me.mobjSaveButton.Size = New System.Drawing.Size(130, 43)
            Me.mobjSaveButton.TabIndex = 8
            Me.mobjSaveButton.Text = "Save..."
            Me.mobjSaveButton.UseVisualStyleBackColor = True
            ' 
            ' mobjCancelButton
            ' 
            Me.mobjCancelButton.Location = New System.Drawing.Point(172, 153)
            Me.mobjCancelButton.Name = "cancelButton"
            Me.mobjCancelButton.Size = New System.Drawing.Size(130, 43)
            Me.mobjCancelButton.TabIndex = 9
            Me.mobjCancelButton.Text = "Cancel..."
            Me.mobjCancelButton.UseVisualStyleBackColor = True
            ' 
            ' DialogReturnValueForm
            ' 
            Me.Controls.Add(Me.mobjCancelButton)
            Me.Controls.Add(Me.mobjSaveButton)
            Me.Controls.Add(Me.mobjEmailTextBox)
            Me.Controls.Add(Me.mobjEmailLabel)
            Me.Controls.Add(Me.mobjPhoneTextBox)
            Me.Controls.Add(Me.mobjPhoneLabel)
            Me.Controls.Add(Me.mobjUserLastNameTextBox)
            Me.Controls.Add(Me.mobjUserLastNameLabel)
            Me.Controls.Add(Me.mobjUserFirstNameTextBox)
            Me.Controls.Add(Me.mobjUserFirstNameLabel)
            Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
            Me.Size = New System.Drawing.Size(316, 205)
            Me.Text = "Dialog Return Value"
            Me.ResumeLayout(False)

        End Sub

        Private mobjUserFirstNameLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjUserFirstNameTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Private mobjUserLastNameLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjUserLastNameTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Private mobjPhoneLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjPhoneTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Private mobjEmailLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjEmailTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Protected WithEvents mobjSaveButton As Global.Gizmox.WebGUI.Forms.Button
        Protected WithEvents mobjCancelButton As Global.Gizmox.WebGUI.Forms.Button

	End Class

End Namespace
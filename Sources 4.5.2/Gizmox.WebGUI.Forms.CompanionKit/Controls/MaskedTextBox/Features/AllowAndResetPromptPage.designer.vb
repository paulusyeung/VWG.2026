Namespace CompanionKit.Controls.MaskedTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AllowAndResetPromptPage
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
            Me.mobjResetCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaskedTextBox = New Gizmox.WebGUI.Forms.MaskedTextBox()
            Me.mobjAllowCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.SuspendLayout()
            '
            ' mobjResetCheckBox
            '
            Me.mobjResetCheckBox.AccessibleDescription = ""
            Me.mobjResetCheckBox.AccessibleName = ""
            Me.mobjResetCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjResetCheckBox.AutoSize = True
            Me.mobjResetCheckBox.Checked = True
            Me.mobjResetCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjResetCheckBox.Location = New System.Drawing.Point(31, 104)
            Me.mobjResetCheckBox.Name = "mobjResetCheckBox"
            Me.mobjResetCheckBox.Size = New System.Drawing.Size(102, 17)
            Me.mobjResetCheckBox.TabIndex = 2
            Me.mobjResetCheckBox.Text = "ResetOnPrompt"
            '
            ' mobjLabel
            '
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Location = New System.Drawing.Point(28, 23)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "MaskedTextBox:"
            '
            ' mobjMaskedTextBox
            '
            Me.mobjMaskedTextBox.AccessibleDescription = ""
            Me.mobjMaskedTextBox.AccessibleName = ""
            Me.mobjMaskedTextBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjMaskedTextBox.CustomStyle = "Masked"
            Me.mobjMaskedTextBox.Location = New System.Drawing.Point(31, 50)
            Me.mobjMaskedTextBox.Mask = "000-LLL-CCC"
            Me.mobjMaskedTextBox.Name = "mobjMaskedTextBox"
            Me.mobjMaskedTextBox.Size = New System.Drawing.Size(152, 30)
            Me.mobjMaskedTextBox.TabIndex = 0
            '
            ' mobjAllowCheckBox
            '
            Me.mobjAllowCheckBox.AccessibleDescription = ""
            Me.mobjAllowCheckBox.AccessibleName = ""
            Me.mobjAllowCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjAllowCheckBox.AutoSize = True
            Me.mobjAllowCheckBox.Checked = True
            Me.mobjAllowCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjAllowCheckBox.Location = New System.Drawing.Point(31, 133)
            Me.mobjAllowCheckBox.Name = "mobjAllowCheckBox"
            Me.mobjAllowCheckBox.Size = New System.Drawing.Size(123, 17)
            Me.mobjAllowCheckBox.TabIndex = 3
            Me.mobjAllowCheckBox.Text = "AllowPromptAsInput"
            '
            ' AllowAndResetPromptPage
            '
            Me.Controls.Add(Me.mobjAllowCheckBox)
            Me.Controls.Add(Me.mobjMaskedTextBox)
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjResetCheckBox)
            Me.Size = New System.Drawing.Size(222, 191)
            Me.Text = "AllowAndResetPromptPage"
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjResetCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjMaskedTextBox As Gizmox.WebGUI.Forms.MaskedTextBox
        Private WithEvents mobjAllowCheckBox As Gizmox.WebGUI.Forms.CheckBox

	End Class

End Namespace
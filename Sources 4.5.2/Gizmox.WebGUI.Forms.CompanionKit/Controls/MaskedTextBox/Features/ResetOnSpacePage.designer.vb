Namespace CompanionKit.Controls.MaskedTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ResetOnSpacePage
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
            Me.mobjMaskedTextBox = New Gizmox.WebGUI.Forms.MaskedTextBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.SuspendLayout()
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
            Me.mobjMaskedTextBox.Size = New System.Drawing.Size(128, 30)
            Me.mobjMaskedTextBox.TabIndex = 0
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
            ' mobjCheckBox
            '
            Me.mobjCheckBox.AccessibleDescription = ""
            Me.mobjCheckBox.AccessibleName = ""
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox.AutoSize = True
            Me.mobjCheckBox.Checked = True
            Me.mobjCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjCheckBox.Location = New System.Drawing.Point(31, 104)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(100, 17)
            Me.mobjCheckBox.TabIndex = 2
            Me.mobjCheckBox.Text = "ResetOnSpace "
            '
            ' ResetOnSpacePage
            '
            Me.Controls.Add(Me.mobjCheckBox)
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjMaskedTextBox)
            Me.Size = New System.Drawing.Size(191, 150)
            Me.Text = "ResetOnSpacePage"
            Me.ResumeLayout(False)

        End Sub

        Private mobjMaskedTextBox As Gizmox.WebGUI.Forms.MaskedTextBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox


	End Class

End Namespace
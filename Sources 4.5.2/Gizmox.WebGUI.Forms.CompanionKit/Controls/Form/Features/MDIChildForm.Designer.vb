Namespace CompanionKit.Controls.Form.Features
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MDIChildForm
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
            Me.mobjLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.mobjButton = New Global.Gizmox.WebGUI.Forms.Button
            Me.SuspendLayout()
            '
            ' mobjLabel
            '
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.Location = New System.Drawing.Point(0, 28)
            Me.mobjLabel.Name = "label1"
            Me.mobjLabel.Size = New System.Drawing.Size(268, 43)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "This is Enable MDI Child Form #"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            ' mobjButton
            '
            Me.mobjButton.AccessibleDescription = ""
            Me.mobjButton.AccessibleName = ""
            Me.mobjButton.Location = New System.Drawing.Point(72, 108)
            Me.mobjButton.Name = "button1"
            Me.mobjButton.Size = New System.Drawing.Size(115, 43)
            Me.mobjButton.TabIndex = 1
            Me.mobjButton.Text = "Click Me!"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'MDIChildForm
            '
            Me.Controls.Add(Me.mobjButton)
            Me.Controls.Add(Me.mobjLabel)
            Me.Size = New System.Drawing.Size(268, 160)
            Me.Text = "New Child Form #"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjButton As Global.Gizmox.WebGUI.Forms.Button

	End Class
End Namespace
Namespace CompanionKit.Controls.Form.Features
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class WindowTypeForm
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
            Me.mobjCloseButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjCloseButton
            ' 
            Me.mobjCloseButton.AccessibleDescription = ""
            Me.mobjCloseButton.AccessibleName = ""
            Me.mobjCloseButton.Location = New System.Drawing.Point(126, 93)
            Me.mobjCloseButton.Name = "closeButton"
            Me.mobjCloseButton.Size = New System.Drawing.Size(132, 42)
            Me.mobjCloseButton.TabIndex = 0
            Me.mobjCloseButton.Text = "Close"
            Me.mobjCloseButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.Location = New System.Drawing.Point(2, 9)
            Me.mobjLabel.Name = "label1"
            Me.mobjLabel.Size = New System.Drawing.Size(376, 62)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "This is Modaless form. Click on button for closing it."
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' WindowTypeForm
            ' 
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjCloseButton)
            Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
            Me.Size = New System.Drawing.Size(378, 153)
            Me.Text = "Window Type Form"
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjCloseButton As Global.Gizmox.WebGUI.Forms.Button
        Private mobjLabel As Global.Gizmox.WebGUI.Forms.Label

	End Class
End Namespace
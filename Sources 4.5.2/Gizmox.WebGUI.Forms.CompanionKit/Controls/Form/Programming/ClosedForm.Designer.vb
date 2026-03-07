Namespace CompanionKit.Controls.Form.Programming
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ClosedForm
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
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjButton
            ' 
            Me.mobjButton.AccessibleDescription = ""
            Me.mobjButton.AccessibleName = ""
            Me.mobjButton.Location = New System.Drawing.Point(85, 97)
            Me.mobjButton.Name = "button1"
            Me.mobjButton.Size = New System.Drawing.Size(130, 49)
            Me.mobjButton.TabIndex = 0
            Me.mobjButton.Text = "Close"
            Me.mobjButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "label1"
            Me.mobjLabel.Size = New System.Drawing.Size(296, 97)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Click on button to close the form and you will see message that will inform you a" + "bout closing Form."
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' ClosedForm
            ' 
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjButton)
            Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
            Me.Size = New System.Drawing.Size(296, 166)
            Me.Text = "Closed Form"
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjButton As Global.Gizmox.WebGUI.Forms.Button
        Private mobjLabel As Global.Gizmox.WebGUI.Forms.Label

	End Class
End Namespace
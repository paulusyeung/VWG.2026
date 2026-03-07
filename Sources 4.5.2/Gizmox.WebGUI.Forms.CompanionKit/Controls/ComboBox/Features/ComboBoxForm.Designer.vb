Namespace CompanionKit.Controls.ComboBox.Features
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ComboBoxForm
		Inherits Gizmox.WebGUI.Forms.Form

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
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button
            Me.SuspendLayout()
            '
            'Button1
            '
            Me.mobjButton.Location = New System.Drawing.Point(91, 51)
            Me.mobjButton.Name = "Button1"
            Me.mobjButton.Size = New System.Drawing.Size(75, 23)
            Me.mobjButton.TabIndex = 0
            Me.mobjButton.Text = "Click Me!"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'ComboBoxForm
            '
            Me.Controls.Add(Me.mobjButton)
            Me.Size = New System.Drawing.Size(257, 124)
            Me.Text = "ComboBoxForm"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button

	End Class
End Namespace

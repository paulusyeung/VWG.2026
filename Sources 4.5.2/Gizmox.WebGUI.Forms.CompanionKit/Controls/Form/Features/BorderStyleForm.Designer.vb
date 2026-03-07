Namespace CompanionKit.Controls.Form.Features
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BorderStyleForm
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
           Me.mobjOkButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjOkButton
            ' 
            Me.mobjOkButton.Location = New System.Drawing.Point(100, 106)
            Me.mobjOkButton.Name = "mobjOkButton"
            Me.mobjOkButton.Size = New System.Drawing.Size(116, 44)
            Me.mobjOkButton.TabIndex = 8
            Me.mobjOkButton.Text = "Ok"
            Me.mobjOkButton.UseVisualStyleBackColor = True
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Location = New System.Drawing.Point(95, 62)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(121, 30)
            Me.mobjComboBox.TabIndex = 11
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Location = New System.Drawing.Point(54, 25)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(210, 22)
            Me.mobjLabel.TabIndex = 12
            Me.mobjLabel.Text = "Select a form border style:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' BorderStyleForm
            ' 
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjComboBox)
            Me.Controls.Add(Me.mobjOkButton)
            Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
            Me.Size = New System.Drawing.Size(334, 165)
            Me.Text = "BorderStyle Form"
            Me.ResumeLayout(False)

        End Sub

        Protected WithEvents mobjOkButton As Global.Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private mobjLabel As Global.Gizmox.WebGUI.Forms.Label

	End Class
End Namespace
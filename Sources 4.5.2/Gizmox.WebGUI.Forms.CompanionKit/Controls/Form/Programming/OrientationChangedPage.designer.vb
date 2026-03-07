Namespace CompanionKit.Controls.Form.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class OrientationChangedPage
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
            Me.mobjOpenButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            '
            'mobjOpenButton
            '
            Me.mobjOpenButton.AccessibleDescription = ""
            Me.mobjOpenButton.AccessibleName = ""
            Me.mobjOpenButton.Location = New System.Drawing.Point(77, 89)
            Me.mobjOpenButton.Name = "mobjOpenButton"
            Me.mobjOpenButton.Size = New System.Drawing.Size(169, 57)
            Me.mobjOpenButton.TabIndex = 0
            Me.mobjOpenButton.Text = "Open Form"
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.AccessibleDescription = ""
            Me.mobjInfoLabel.AccessibleName = ""
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(419, 65)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "Click button to open form and then rotate the device to see event fire:"
            '
            'OrientationChangedPage
            '
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Controls.Add(Me.mobjOpenButton)
            Me.Size = New System.Drawing.Size(391, 306)
            Me.Text = "OrientationChangedPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjOpenButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
	End Class

End Namespace
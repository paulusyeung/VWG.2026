Namespace CompanionKit.Concepts.VisualEffects.BorderRadius

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BorderRadiusPage
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
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLabelInfo = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMinusButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjPlusButton = New Gizmox.WebGUI.Forms.Button()
            Me.SuspendLayout()
            '
            'mobjTextBox
            '
            Me.mobjTextBox.AccessibleDescription = ""
            Me.mobjTextBox.AccessibleName = ""
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Location = New System.Drawing.Point(21, 39)
            Me.mobjTextBox.Multiline = True
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(250, 143)
            Me.mobjTextBox.TabIndex = 0
            '
            'mobjLabelInfo
            '
            Me.mobjLabelInfo.AccessibleDescription = ""
            Me.mobjLabelInfo.AccessibleName = ""
            Me.mobjLabelInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabelInfo.Location = New System.Drawing.Point(330, 85)
            Me.mobjLabelInfo.Name = "mobjLabelInfo"
            Me.mobjLabelInfo.Size = New System.Drawing.Size(479, 36)
            Me.mobjLabelInfo.TabIndex = 1
            Me.mobjLabelInfo.Text = "Use buttons to change radius:"
            '
            'mobjMinusButton
            '
            Me.mobjMinusButton.AccessibleDescription = ""
            Me.mobjMinusButton.AccessibleName = ""
            Me.mobjMinusButton.Location = New System.Drawing.Point(21, 204)
            Me.mobjMinusButton.Name = "mobjMinusButton"
            Me.mobjMinusButton.Size = New System.Drawing.Size(120, 40)
            Me.mobjMinusButton.TabIndex = 2
            Me.mobjMinusButton.Text = "Radius -5px"
            '
            'mobjPlusButton
            '
            Me.mobjPlusButton.AccessibleDescription = ""
            Me.mobjPlusButton.AccessibleName = ""
            Me.mobjPlusButton.Location = New System.Drawing.Point(151, 204)
            Me.mobjPlusButton.Name = "mobjPlusButton"
            Me.mobjPlusButton.Size = New System.Drawing.Size(120, 40)
            Me.mobjPlusButton.TabIndex = 3
            Me.mobjPlusButton.Text = "Radius +5px"
            '
            'BorderRadiusPage
            '
            Me.Controls.Add(Me.mobjPlusButton)
            Me.Controls.Add(Me.mobjMinusButton)
            Me.Controls.Add(Me.mobjLabelInfo)
            Me.Controls.Add(Me.mobjTextBox)
            Me.Size = New System.Drawing.Size(479, 353)
            Me.Text = "BorderRadiusPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjLabelInfo As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMinusButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjPlusButton As Gizmox.WebGUI.Forms.Button
	End Class

End Namespace
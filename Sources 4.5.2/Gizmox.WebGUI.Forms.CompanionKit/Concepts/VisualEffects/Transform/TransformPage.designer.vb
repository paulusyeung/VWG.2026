Namespace CompanionKit.Concepts.VisualEffects.Transform

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TransformPage
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
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjRotateRB = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjScaleRB = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTranslateRB = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjScewRB = New Gizmox.WebGUI.Forms.CheckBox()
            Me.SuspendLayout()
            '
            'mobjPanel
            '
            Me.mobjPanel.AccessibleDescription = ""
            Me.mobjPanel.AccessibleName = ""
            Me.mobjPanel.BackColor = System.Drawing.Color.MistyRose
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(2)
            Me.mobjPanel.Location = New System.Drawing.Point(75, 131)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(164, 167)
            Me.mobjPanel.TabIndex = 1
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.AccessibleDescription = ""
            Me.mobjInfoLabel.AccessibleName = ""
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(377, 50)
            Me.mobjInfoLabel.TabIndex = 2
            Me.mobjInfoLabel.Text = "Use buttons to set appropriate type of Transform visual effect:"
            '
            'mobjRotateRB
            '
            Me.mobjRotateRB.AccessibleDescription = ""
            Me.mobjRotateRB.AccessibleName = ""
            Me.mobjRotateRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            Me.mobjRotateRB.Location = New System.Drawing.Point(35, 50)
            Me.mobjRotateRB.Name = "mobjRotateRB"
            Me.mobjRotateRB.Size = New System.Drawing.Size(122, 30)
            Me.mobjRotateRB.TabIndex = 3
            Me.mobjRotateRB.Text = "Rotate"
            Me.mobjRotateRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjScaleRB
            '
            Me.mobjScaleRB.AccessibleDescription = ""
            Me.mobjScaleRB.AccessibleName = ""
            Me.mobjScaleRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            Me.mobjScaleRB.Location = New System.Drawing.Point(35, 91)
            Me.mobjScaleRB.Name = "mobjScaleRB"
            Me.mobjScaleRB.Size = New System.Drawing.Size(122, 30)
            Me.mobjScaleRB.TabIndex = 4
            Me.mobjScaleRB.Text = "Scale"
            Me.mobjScaleRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTranslateRB
            '
            Me.mobjTranslateRB.AccessibleDescription = ""
            Me.mobjTranslateRB.AccessibleName = ""
            Me.mobjTranslateRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            Me.mobjTranslateRB.Location = New System.Drawing.Point(170, 50)
            Me.mobjTranslateRB.Name = "mobjTranslateRB"
            Me.mobjTranslateRB.Size = New System.Drawing.Size(122, 30)
            Me.mobjTranslateRB.TabIndex = 5
            Me.mobjTranslateRB.Text = "Translate"
            Me.mobjTranslateRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjScewRB
            '
            Me.mobjScewRB.AccessibleDescription = ""
            Me.mobjScewRB.AccessibleName = ""
            Me.mobjScewRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            Me.mobjScewRB.Location = New System.Drawing.Point(170, 91)
            Me.mobjScewRB.Name = "mobjScewRB"
            Me.mobjScewRB.Size = New System.Drawing.Size(122, 30)
            Me.mobjScewRB.TabIndex = 6
            Me.mobjScewRB.Text = "Scew"
            Me.mobjScewRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TransformPage
            '
            Me.Controls.Add(Me.mobjScewRB)
            Me.Controls.Add(Me.mobjTranslateRB)
            Me.Controls.Add(Me.mobjScaleRB)
            Me.Controls.Add(Me.mobjRotateRB)
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(377, 439)
            Me.Text = "TransformPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjPanel As Panel
        Friend WithEvents mobjInfoLabel As Label
        Friend WithEvents mobjRotateRB As CheckBox
        Friend WithEvents mobjScaleRB As CheckBox
        Friend WithEvents mobjTranslateRB As CheckBox
        Friend WithEvents mobjScewRB As CheckBox
	End Class

End Namespace
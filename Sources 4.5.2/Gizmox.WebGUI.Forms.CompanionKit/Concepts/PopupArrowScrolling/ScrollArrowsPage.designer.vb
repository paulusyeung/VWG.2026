Namespace CompanionKit.Concepts.PopupArrowScrolling

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ScrollArrowsPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDefaultRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjArrowsRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.AccessibleDescription = ""
            Me.mobjInfoLabel.AccessibleName = ""
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(419, 50)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Chose ScrollerType value for panel:"
            '
            'mobjPanel
            '
            Me.mobjPanel.AccessibleDescription = ""
            Me.mobjPanel.AccessibleName = ""
            Me.mobjPanel.AutoScroll = True
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel.Controls.Add(Me.mobjTextBox)
            Me.mobjPanel.Controls.Add(Me.mobjLabel)
            Me.mobjPanel.Controls.Add(Me.mobjButton)
            Me.mobjPanel.Location = New System.Drawing.Point(15, 50)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(213, 160)
            Me.mobjPanel.TabIndex = 1
            '
            'mobjTextBox
            '
            Me.mobjTextBox.AccessibleDescription = ""
            Me.mobjTextBox.AccessibleName = ""
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Location = New System.Drawing.Point(18, 132)
            Me.mobjTextBox.Multiline = True
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(153, 141)
            Me.mobjTextBox.TabIndex = 2
            Me.mobjTextBox.Text = "Text Box..."
            '
            'mobjLabel
            '
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.BackColor = System.Drawing.Color.PapayaWhip
            Me.mobjLabel.Location = New System.Drawing.Point(15, 68)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(156, 49)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Test Label"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjButton
            '
            Me.mobjButton.AccessibleDescription = ""
            Me.mobjButton.AccessibleName = ""
            Me.mobjButton.Location = New System.Drawing.Point(15, 24)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(156, 29)
            Me.mobjButton.TabIndex = 0
            Me.mobjButton.Text = "Button"
            '
            'mobjDefaultRB
            '
            Me.mobjDefaultRB.AccessibleDescription = ""
            Me.mobjDefaultRB.AccessibleName = ""
            Me.mobjDefaultRB.Checked = True
            Me.mobjDefaultRB.Location = New System.Drawing.Point(15, 234)
            Me.mobjDefaultRB.Name = "mobjDefaultRB"
            Me.mobjDefaultRB.Size = New System.Drawing.Size(190, 40)
            Me.mobjDefaultRB.TabIndex = 2
            Me.mobjDefaultRB.Text = "Default"
            '
            'mobjArrowsRB
            '
            Me.mobjArrowsRB.AccessibleDescription = ""
            Me.mobjArrowsRB.AccessibleName = ""
            Me.mobjArrowsRB.Location = New System.Drawing.Point(15, 284)
            Me.mobjArrowsRB.Name = "mobjArrowsRB"
            Me.mobjArrowsRB.Size = New System.Drawing.Size(190, 40)
            Me.mobjArrowsRB.TabIndex = 3
            Me.mobjArrowsRB.Text = "Arrows"
            '
            'ScrollArrowsPage
            '
            Me.Controls.Add(Me.mobjArrowsRB)
            Me.Controls.Add(Me.mobjDefaultRB)
            Me.Controls.Add(Me.mobjPanel)
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Size = New System.Drawing.Size(391, 380)
            Me.Text = "ScrollArrowsPage"
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjDefaultRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjArrowsRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
	End Class

End Namespace
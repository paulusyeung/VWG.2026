Namespace CompanionKit.Concepts.ClientAPI.ListBox

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ListBoxPage
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
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFillButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjCheckBox1 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjClearButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjCheckBox2 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjCheckBox3 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.SuspendLayout()
            '
            'mobjListBox
            '
            Me.mobjListBox.ClientId = "lbox"
            Me.mobjListBox.Location = New System.Drawing.Point(18, 82)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(175, 186)
            Me.mobjListBox.TabIndex = 0
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Padding = New Gizmox.WebGUI.Forms.Padding(10, 10, 0, 0)
            Me.mobjInfoLabel.Size = New System.Drawing.Size(391, 81)
            Me.mobjInfoLabel.TabIndex = 2
            Me.mobjInfoLabel.Text = "Click button to fill ListBox with tagNames of checked CheckBoxes:"
            '
            'mobjFillButton
            '
            Me.mobjFillButton.Location = New System.Drawing.Point(18, 281)
            Me.mobjFillButton.Name = "mobjFillButton"
            Me.mobjFillButton.Size = New System.Drawing.Size(80, 23)
            Me.mobjFillButton.TabIndex = 3
            Me.mobjFillButton.Text = "Fill"
            '
            'mobjCheckBox1
            '
            Me.mobjCheckBox1.AutoSize = True
            Me.mobjCheckBox1.ClientId = "chb1"
            Me.mobjCheckBox1.Location = New System.Drawing.Point(208, 122)
            Me.mobjCheckBox1.Name = "mobjCheckBox1"
            Me.mobjCheckBox1.Size = New System.Drawing.Size(59, 17)
            Me.mobjCheckBox1.TabIndex = 5
            Me.mobjCheckBox1.Text = "check1"
            '
            'mobjClearButton
            '
            Me.mobjClearButton.Location = New System.Drawing.Point(113, 281)
            Me.mobjClearButton.Name = "mobjClearButton"
            Me.mobjClearButton.Size = New System.Drawing.Size(80, 23)
            Me.mobjClearButton.TabIndex = 7
            Me.mobjClearButton.Text = "Clear"
            '
            'mobjCheckBox2
            '
            Me.mobjCheckBox2.AutoSize = True
            Me.mobjCheckBox2.ClientId = "chb2"
            Me.mobjCheckBox2.Location = New System.Drawing.Point(208, 155)
            Me.mobjCheckBox2.Name = "mobjCheckBox2"
            Me.mobjCheckBox2.Size = New System.Drawing.Size(59, 17)
            Me.mobjCheckBox2.TabIndex = 8
            Me.mobjCheckBox2.Text = "check2"
            '
            'mobjCheckBox3
            '
            Me.mobjCheckBox3.AutoSize = True
            Me.mobjCheckBox3.ClientId = "chb3"
            Me.mobjCheckBox3.Location = New System.Drawing.Point(208, 188)
            Me.mobjCheckBox3.Name = "mobjCheckBox3"
            Me.mobjCheckBox3.Size = New System.Drawing.Size(59, 17)
            Me.mobjCheckBox3.TabIndex = 9
            Me.mobjCheckBox3.Text = "check3"
            '
            'ListBoxPage
            '
            Me.ClientId = "uc"
            Me.Controls.Add(Me.mobjCheckBox3)
            Me.Controls.Add(Me.mobjCheckBox2)
            Me.Controls.Add(Me.mobjClearButton)
            Me.Controls.Add(Me.mobjCheckBox1)
            Me.Controls.Add(Me.mobjFillButton)
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Controls.Add(Me.mobjListBox)
            Me.Size = New System.Drawing.Size(391, 306)
            Me.Text = "ListBoxPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjFillButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjCheckBox1 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjClearButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjCheckBox2 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjCheckBox3 As Gizmox.WebGUI.Forms.CheckBox


	End Class

End Namespace
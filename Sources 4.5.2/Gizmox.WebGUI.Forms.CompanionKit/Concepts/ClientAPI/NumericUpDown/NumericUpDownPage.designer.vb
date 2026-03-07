Namespace CompanionKit.Concepts.ClientAPI.NumericUpDown

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class NumericUpDownPage
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
            Me.mobjNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjSelectedInfo = New Gizmox.WebGUI.Forms.Label()
            CType(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'mobjNumericUpDown
            '
            Me.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNumericUpDown.ClientId = "nud"
            Me.mobjNumericUpDown.CurrentValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjNumericUpDown.Location = New System.Drawing.Point(16, 235)
            Me.mobjNumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
            Me.mobjNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjNumericUpDown.Name = "mobjNumericUpDown"
            Me.mobjNumericUpDown.Size = New System.Drawing.Size(120, 20)
            Me.mobjNumericUpDown.TabIndex = 0
            Me.mobjNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Padding = New Gizmox.WebGUI.Forms.Padding(10, 10, 0, 0)
            Me.mobjLabel.Size = New System.Drawing.Size(404, 56)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Select item in ListBox to change NumericUpDown value:"
            '
            'mobjListBox
            '
            Me.mobjListBox.ClientId = "lb"
            Me.mobjListBox.Items.AddRange(New Object() {"item1", "item2", "item3", "item4", "item5", "item6"})
            Me.mobjListBox.Location = New System.Drawing.Point(16, 64)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(171, 160)
            Me.mobjListBox.TabIndex = 2
            '
            'mobjSelectedInfo
            '
            Me.mobjSelectedInfo.ClientId = "info"
            Me.mobjSelectedInfo.Location = New System.Drawing.Point(146, 235)
            Me.mobjSelectedInfo.Name = "mobjSelectedInfo"
            Me.mobjSelectedInfo.Size = New System.Drawing.Size(76, 21)
            Me.mobjSelectedInfo.TabIndex = 3
            Me.mobjSelectedInfo.Text = "value: 1"
            Me.mobjSelectedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'NumericUpDownPage
            '
            Me.Controls.Add(Me.mobjSelectedInfo)
            Me.Controls.Add(Me.mobjListBox)
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjNumericUpDown)
            Me.Size = New System.Drawing.Size(404, 400)
            Me.Text = "NumericUpDownPage"
            CType(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private WithEvents mobjSelectedInfo As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace
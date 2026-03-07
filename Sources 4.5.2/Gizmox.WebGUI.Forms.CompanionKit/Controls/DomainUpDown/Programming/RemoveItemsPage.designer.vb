Namespace CompanionKit.Controls.DomainUpDown.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class RemoveItemsPage
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
            Me.mobjDomainUpDownLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDomainUpDown = New Gizmox.WebGUI.Forms.DomainUpDown()
            Me.mobjRemoveItemByPositionNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjRemoveItemComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjRemoveItemByNameRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRemoveItemByPositionRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRemoveItemButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.mobjRemoveItemByPositionNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjDomainUpDownLabel
            '
            Me.mobjDomainUpDownLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right
            Me.mobjDomainUpDownLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDomainUpDownLabel.Name = "mobjDomainUpDownLabel"
            Me.mobjDomainUpDownLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjDomainUpDownLabel.Size = New System.Drawing.Size(106, 75)
            Me.mobjDomainUpDownLabel.TabIndex = 0
            Me.mobjDomainUpDownLabel.Text = "Domain Up Down"
            Me.mobjDomainUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjDomainUpDown
            '
            Me.mobjDomainUpDown.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDomainUpDown.Location = New System.Drawing.Point(121, 27)
            Me.mobjDomainUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0)
            Me.mobjDomainUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjDomainUpDown.Name = "mobjDomainUpDown"
            Me.mobjDomainUpDown.Size = New System.Drawing.Size(184, 21)
            Me.mobjDomainUpDown.TabIndex = 3
            '
            'mobjRemoveItemByPositionNumericUpDown
            '
            Me.mobjRemoveItemByPositionNumericUpDown.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjRemoveItemByPositionNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjRemoveItemByPositionNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjRemoveItemByPositionNumericUpDown.Enabled = False
            Me.mobjRemoveItemByPositionNumericUpDown.Location = New System.Drawing.Point(121, 177)
            Me.mobjRemoveItemByPositionNumericUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0)
            Me.mobjRemoveItemByPositionNumericUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjRemoveItemByPositionNumericUpDown.Name = "mobjRemoveItemByPositionNumericUpDown"
            Me.mobjRemoveItemByPositionNumericUpDown.Size = New System.Drawing.Size(184, 21)
            Me.mobjRemoveItemByPositionNumericUpDown.TabIndex = 6
            '
            'mobjRemoveItemComboBox
            '
            Me.mobjRemoveItemComboBox.AllowDrag = False
            Me.mobjRemoveItemComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjRemoveItemComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjRemoveItemComboBox.Location = New System.Drawing.Point(121, 102)
            Me.mobjRemoveItemComboBox.Margin = New Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0)
            Me.mobjRemoveItemComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjRemoveItemComboBox.Name = "mobjRemoveItemComboBox"
            Me.mobjRemoveItemComboBox.Size = New System.Drawing.Size(184, 25)
            Me.mobjRemoveItemComboBox.TabIndex = 7
            '
            'mobjRemoveItemByNameRadioButton
            '
            Me.mobjRemoveItemByNameRadioButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right
            Me.mobjRemoveItemByNameRadioButton.Checked = True
            Me.mobjRemoveItemByNameRadioButton.Location = New System.Drawing.Point(0, 75)
            Me.mobjRemoveItemByNameRadioButton.Name = "mobjRemoveItemByNameRadioButton"
            Me.mobjRemoveItemByNameRadioButton.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjRemoveItemByNameRadioButton.Size = New System.Drawing.Size(106, 75)
            Me.mobjRemoveItemByNameRadioButton.TabIndex = 8
            Me.mobjRemoveItemByNameRadioButton.Text = "Remove item by name"
            Me.mobjRemoveItemByNameRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjRemoveItemByNameRadioButton.UseVisualStyleBackColor = True
            '
            'mobjRemoveItemByPositionRadioButton
            '
            Me.mobjRemoveItemByPositionRadioButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right
            Me.mobjRemoveItemByPositionRadioButton.Location = New System.Drawing.Point(0, 150)
            Me.mobjRemoveItemByPositionRadioButton.Name = "mobjRemoveItemByPositionRadioButton"
            Me.mobjRemoveItemByPositionRadioButton.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjRemoveItemByPositionRadioButton.Size = New System.Drawing.Size(106, 75)
            Me.mobjRemoveItemByPositionRadioButton.TabIndex = 9
            Me.mobjRemoveItemByPositionRadioButton.Text = "Remove item by position"
            Me.mobjRemoveItemByPositionRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjRemoveItemByPositionRadioButton.UseVisualStyleBackColor = True
            '
            'mobjRemoveItemButton
            '
            Me.mobjRemoveItemButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRemoveItemButton.Location = New System.Drawing.Point(121, 240)
            Me.mobjRemoveItemButton.Margin = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjRemoveItemButton.MaximumSize = New System.Drawing.Size(200, 60)
            Me.mobjRemoveItemButton.Name = "mobjRemoveItemButton"
            Me.mobjRemoveItemButton.Size = New System.Drawing.Size(184, 45)
            Me.mobjRemoveItemButton.TabIndex = 10
            Me.mobjRemoveItemButton.Text = "Remove item"
            Me.mobjRemoveItemButton.UseVisualStyleBackColor = True
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 66.66666!))
            Me.mobjTLP.Controls.Add(Me.mobjDomainUpDownLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjRemoveItemButton, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjDomainUpDown, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjRemoveItemByPositionNumericUpDown, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjRemoveItemByPositionRadioButton, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjRemoveItemByNameRadioButton, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjRemoveItemComboBox, 1, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 300)
            Me.mobjTLP.TabIndex = 11
            '
            'RemoveItemsPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 300)
            Me.Text = "RemoveItemsPage"
            CType(Me.mobjRemoveItemByPositionNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjDomainUpDownLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjDomainUpDown As Gizmox.WebGUI.Forms.DomainUpDown
        Friend WithEvents mobjRemoveItemByPositionNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjRemoveItemComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjRemoveItemByNameRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjRemoveItemByPositionRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjRemoveItemButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
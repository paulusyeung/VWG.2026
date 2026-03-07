Namespace CompanionKit.Controls.DomainUpDown.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddItemsPage
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
            Me.mobjDomainUpDown = New Gizmox.WebGUI.Forms.DomainUpDown()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDomainUpDownLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNameAddedItemLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNameAddedItemTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjDomainUpDown
            '
            Me.mobjDomainUpDown.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjDomainUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDomainUpDown.Items.Add("Item1")
            Me.mobjDomainUpDown.Items.Add("Item2")
            Me.mobjDomainUpDown.Items.Add("Item3")
            Me.mobjDomainUpDown.Items.Add("Item4")
            Me.mobjDomainUpDown.Items.Add("Item5")
            Me.mobjDomainUpDown.Items.Add("Item6")
            Me.mobjDomainUpDown.Location = New System.Drawing.Point(111, 62)
            Me.mobjDomainUpDown.Margin = New Gizmox.WebGUI.Forms.Padding(15, 0, 15, 0)
            Me.mobjDomainUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjDomainUpDown.Name = "mobjDomainUpDown"
            Me.mobjDomainUpDown.Size = New System.Drawing.Size(194, 21)
            Me.mobjDomainUpDown.Sorted = True
            Me.mobjDomainUpDown.TabIndex = 0
            Me.mobjDomainUpDown.Text = "demoDomainUpDown"
            '
            'mobjAddButton
            '
            Me.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddButton.Location = New System.Drawing.Point(111, 305)
            Me.mobjAddButton.Margin = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjAddButton.MaximumSize = New System.Drawing.Size(200, 60)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(194, 60)
            Me.mobjAddButton.TabIndex = 1
            Me.mobjAddButton.Text = "Add item to DomainUpDown"
            Me.mobjAddButton.UseVisualStyleBackColor = True
            '
            'mobjDomainUpDownLabel
            '
            Me.mobjDomainUpDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDomainUpDownLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDomainUpDownLabel.Name = "mobjDomainUpDownLabel"
            Me.mobjDomainUpDownLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjDomainUpDownLabel.Size = New System.Drawing.Size(96, 145)
            Me.mobjDomainUpDownLabel.TabIndex = 2
            Me.mobjDomainUpDownLabel.Text = "Domain Up Down"
            Me.mobjDomainUpDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjNameAddedItemLabel
            '
            Me.mobjNameAddedItemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNameAddedItemLabel.Location = New System.Drawing.Point(0, 145)
            Me.mobjNameAddedItemLabel.Name = "mobjNameAddedItemLabel"
            Me.mobjNameAddedItemLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjNameAddedItemLabel.Size = New System.Drawing.Size(96, 145)
            Me.mobjNameAddedItemLabel.TabIndex = 3
            Me.mobjNameAddedItemLabel.Text = "New item text"
            Me.mobjNameAddedItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjNameAddedItemTextBox
            '
            Me.mobjNameAddedItemTextBox.AllowDrag = False
            Me.mobjNameAddedItemTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjNameAddedItemTextBox.Location = New System.Drawing.Point(111, 205)
            Me.mobjNameAddedItemTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(15, 3, 15, 3)
            Me.mobjNameAddedItemTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjNameAddedItemTextBox.Name = "mobjNameAddedItemTextBox"
            Me.mobjNameAddedItemTextBox.Size = New System.Drawing.Size(194, 25)
            Me.mobjNameAddedItemTextBox.TabIndex = 4
            Me.mobjNameAddedItemTextBox.Text = "Added item"
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0!))
            Me.mobjTLP.Controls.Add(Me.mobjDomainUpDownLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjAddButton, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjNameAddedItemTextBox, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjDomainUpDown, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjNameAddedItemLabel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 36.36364!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 36.36364!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.27273!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 5
            '
            'AddItemsPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "AddItemsPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjDomainUpDown As Gizmox.WebGUI.Forms.DomainUpDown
        Friend WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjDomainUpDownLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjNameAddedItemLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjNameAddedItemTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
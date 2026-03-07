Namespace CompanionKit.Controls.PropertyGrid.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ResetPropertyPage
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
            Me.mobjPropertyGrid = New Gizmox.WebGUI.Forms.PropertyGrid()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjButtonTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanelTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTableLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.mobjTableLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            ' mobjPropertyGrid
            '
            Me.mobjPropertyGrid.AccessibleDescription = ""
            Me.mobjPropertyGrid.AccessibleName = ""
            Me.mobjPropertyGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjPropertyGrid.CategoryForeColor = System.Drawing.Color.Empty
            Me.mobjPropertyGrid.CommandsVisibleIfAvailable = False
            Me.mobjPropertyGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPropertyGrid.HelpForeColor = System.Drawing.Color.Black
            Me.mobjPropertyGrid.LineColor = System.Drawing.Color.Empty
            Me.mobjPropertyGrid.Location = New System.Drawing.Point(0, 0)
            Me.mobjPropertyGrid.MaximumSize = New System.Drawing.Size(600, 400)
            Me.mobjPropertyGrid.Name = "objPropertyGrid"
            Me.mobjPropertyGrid.Size = New System.Drawing.Size(321, 227)
            Me.mobjPropertyGrid.TabIndex = 0
            Me.mobjPropertyGrid.ViewBackColor = System.Drawing.Color.White
            Me.mobjPropertyGrid.ViewForeColor = System.Drawing.Color.Black
            '
            ' mobjComboBox
            '
            Me.mobjComboBox.AccessibleDescription = ""
            Me.mobjComboBox.AccessibleName = ""
            Me.mobjComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"Button", "Panel"})
            Me.mobjComboBox.Location = New System.Drawing.Point(36, 38)
            Me.mobjComboBox.Name = "objComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(143, 21)
            Me.mobjComboBox.TabIndex = 1
            '
            ' mobjLabel
            '
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Location = New System.Drawing.Point(33, 16)
            Me.mobjLabel.Name = "objLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(83, 13)
            Me.mobjLabel.TabIndex = 2
            Me.mobjLabel.Text = "Choose control:"
            '
            ' mobjButton
            '
            Me.mobjButton.AccessibleDescription = ""
            Me.mobjButton.AccessibleName = ""
            Me.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButton.Location = New System.Drawing.Point(39, 93)
            Me.mobjButton.Name = "objButton"
            Me.mobjButton.Size = New System.Drawing.Size(100, 100)
            Me.mobjButton.TabIndex = 3
            Me.mobjButton.Text = "Button"
            '
            ' mobjPanel
            '
            Me.mobjPanel.AccessibleDescription = ""
            Me.mobjPanel.AccessibleName = ""
            Me.mobjPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(64)), CInt(CByte(64)), CInt(CByte(64))))
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Dashed
            Me.mobjPanel.Location = New System.Drawing.Point(179, 93)
            Me.mobjPanel.Name = "objPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(100, 100)
            Me.mobjPanel.TabIndex = 4
            '
            ' mobjButtonTextLabel
            '
            Me.mobjButtonTextLabel.AccessibleDescription = ""
            Me.mobjButtonTextLabel.AccessibleName = ""
            Me.mobjButtonTextLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonTextLabel.AutoSize = True
            Me.mobjButtonTextLabel.Location = New System.Drawing.Point(51, 71)
            Me.mobjButtonTextLabel.Name = "objButtonTextLabel"
            Me.mobjButtonTextLabel.Size = New System.Drawing.Size(43, 13)
            Me.mobjButtonTextLabel.TabIndex = 6
            Me.mobjButtonTextLabel.Text = "Button:"
            '
            ' mobjPanelTextLabel
            '
            Me.mobjPanelTextLabel.AccessibleDescription = ""
            Me.mobjPanelTextLabel.AccessibleName = ""
            Me.mobjPanelTextLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjPanelTextLabel.AutoSize = True
            Me.mobjPanelTextLabel.Location = New System.Drawing.Point(191, 71)
            Me.mobjPanelTextLabel.Name = "objPanelTextLabel"
            Me.mobjPanelTextLabel.Size = New System.Drawing.Size(37, 13)
            Me.mobjPanelTextLabel.TabIndex = 7
            Me.mobjPanelTextLabel.Text = "Panel:"
            '
            ' mobjTopPanel
            '
            Me.mobjTopPanel.AccessibleDescription = ""
            Me.mobjTopPanel.AccessibleName = ""
            Me.mobjTopPanel.Controls.Add(Me.mobjLabel)
            Me.mobjTopPanel.Controls.Add(Me.mobjComboBox)
            Me.mobjTopPanel.Controls.Add(Me.mobjPanelTextLabel)
            Me.mobjTopPanel.Controls.Add(Me.mobjButtonTextLabel)
            Me.mobjTopPanel.Controls.Add(Me.mobjPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjButton)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(107, 0)
            Me.mobjTopPanel.Name = "objTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(321, 227)
            Me.mobjTopPanel.TabIndex = 9
            '
            ' mobjBottomPanel
            '
            Me.mobjBottomPanel.AccessibleDescription = ""
            Me.mobjBottomPanel.AccessibleName = ""
            Me.mobjBottomPanel.Controls.Add(Me.mobjPropertyGrid)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.Location = New System.Drawing.Point(107, 227)
            Me.mobjBottomPanel.Name = "objBottomPanel"
            Me.mobjBottomPanel.Size = New System.Drawing.Size(321, 227)
            Me.mobjBottomPanel.TabIndex = 10
            '
            ' mobjTableLayoutPanel
            '
            Me.mobjTableLayoutPanel.AccessibleDescription = ""
            Me.mobjTableLayoutPanel.AccessibleName = ""
            Me.mobjTableLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTableLayoutPanel.ColumnCount = 3
            Me.mobjTableLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjTableLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjTableLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjTableLayoutPanel.Controls.Add(Me.mobjBottomPanel, 1, 1)
            Me.mobjTableLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 0)
            Me.mobjTableLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTableLayoutPanel.Location = New System.Drawing.Point(15, 15)
            Me.mobjTableLayoutPanel.Name = "mobjTableLayoutPanel"
            Me.mobjTableLayoutPanel.RowCount = 3
            Me.mobjTableLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTableLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTableLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjTableLayoutPanel.Size = New System.Drawing.Size(535, 475)
            Me.mobjTableLayoutPanel.TabIndex = 11
            '
            ' ResetPropertyPage
            '
            Me.Controls.Add(Me.mobjTableLayoutPanel)
            Me.DockPadding.All = 15
            Me.Location = New System.Drawing.Point(0, -150)
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(565, 505)
            Me.Text = "ResetPropertyPage"
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.mobjTableLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjPropertyGrid As Gizmox.WebGUI.Forms.PropertyGrid
        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjButton As Gizmox.WebGUI.Forms.Button
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjButtonTextLabel As Gizmox.WebGUI.Forms.Label
        Private mobjPanelTextLabel As Gizmox.WebGUI.Forms.Label
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjTableLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
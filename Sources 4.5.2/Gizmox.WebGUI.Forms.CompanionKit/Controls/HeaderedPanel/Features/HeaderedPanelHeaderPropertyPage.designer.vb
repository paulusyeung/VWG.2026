Namespace CompanionKit.Controls.HeaderedPanel.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HeaderedPanelHeaderPropertyPage
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
            Me.mobjHeaderedPanel = New Gizmox.WebGUI.Forms.HeaderedPanel()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjAdditionalLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjHeaderedPanel.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjAdditionalLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjHeaderedPanel
            ' 
            Me.mobjHeaderedPanel.Controls.Add(Me.mobjLabel)
            Me.mobjHeaderedPanel.CustomStyle = "HeaderedPanel"
            Me.mobjHeaderedPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHeaderedPanel.Location = New System.Drawing.Point(65, 20)
            Me.mobjHeaderedPanel.Name = "mobjHeaderedPanel"
            Me.mobjHeaderedPanel.Size = New System.Drawing.Size(522, 86)
            Me.mobjHeaderedPanel.TabIndex = 0
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Location = New System.Drawing.Point(213, 32)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Panel content"
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjTextBox.Location = New System.Drawing.Point(45, 53)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(207, 30)
            Me.mobjTextBox.TabIndex = 1
            Me.mobjTextBox.Text = "Custom Text"
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"Work", "Friends", "Family"})
            Me.mobjComboBox.Location = New System.Drawing.Point(42, 22)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(213, 30)
            Me.mobjComboBox.TabIndex = 2
            ' 
            ' mobjDateTimePicker
            ' 
            Me.mobjDateTimePicker.CustomFormat = ""
            Me.mobjDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.[Short]
            Me.mobjDateTimePicker.Location = New System.Drawing.Point(265, 22)
            Me.mobjDateTimePicker.Name = "mobjDateTimePicker"
            Me.mobjDateTimePicker.Size = New System.Drawing.Size(213, 30)
            Me.mobjDateTimePicker.TabIndex = 3
            ' 
            ' mobjButton
            ' 
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjButton.Location = New System.Drawing.Point(65, 228)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(522, 50)
            Me.mobjButton.TabIndex = 4
            Me.mobjButton.Text = "Reset Controls"
            Me.mobjButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjHeaderedPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAdditionalLayoutPanel, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(653, 300)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' mobjAdditionalLayoutPanel
            ' 
            Me.mobjAdditionalLayoutPanel.ColumnCount = 5
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 8.333333F))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 41.66667F))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 41.66667F))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 8.333333F))
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 0)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjTextBox, 1, 1)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjDateTimePicker, 3, 0)
            Me.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAdditionalLayoutPanel.Location = New System.Drawing.Point(65, 106)
            Me.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel"
            Me.mobjAdditionalLayoutPanel.RowCount = 2
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAdditionalLayoutPanel.Size = New System.Drawing.Size(522, 86)
            Me.mobjAdditionalLayoutPanel.TabIndex = 0
            ' 
            ' HeaderedPanelHeaderPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(653, 300)
            Me.Text = "HeaderedPanelHeaderPropertyPage"
            Me.mobjHeaderedPanel.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjAdditionalLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjHeaderedPanel As Gizmox.WebGUI.Forms.HeaderedPanel
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjAdditionalLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
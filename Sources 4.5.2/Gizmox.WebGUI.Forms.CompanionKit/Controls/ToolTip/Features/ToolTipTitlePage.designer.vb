Namespace CompanionKit.Controls.ToolTip.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ToolTipTitlePage
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
            Me.mobjToolTip = New Gizmox.WebGUI.Forms.ToolTip()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjLinkLabel = New Gizmox.WebGUI.Forms.LinkLabel()
            Me.mobjTrackBar = New Gizmox.WebGUI.Forms.TrackBar()
            Me.mobjDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjTextBoxCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjListBoxCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLinkLabelCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTrackBarCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjDateTimePickerCheckbox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjInputTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjToolTipTextPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjListBoxPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjToolTipTextPanel.SuspendLayout()
            Me.mobjListBoxPanel.SuspendLayout()
            Me.mobjLabelPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTextBox.Location = New System.Drawing.Point(334, 33)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(295, 30)
            Me.mobjTextBox.TabIndex = 5
            ' 
            ' mobjListBox
            ' 
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"Item 1", "Item 2", "Item 3", "Item 4", "Item 5"})
            Me.mobjListBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(301, 43)
            Me.mobjListBox.TabIndex = 6
            ' 
            ' mobjLinkLabel
            ' 
            Me.mobjLinkLabel.AutoSize = True
            Me.mobjLinkLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLinkLabel.LinkColor = System.Drawing.Color.Blue
            Me.mobjLinkLabel.Location = New System.Drawing.Point(331, 142)
            Me.mobjLinkLabel.Name = "mobjLinkLabel"
            Me.mobjLinkLabel.Size = New System.Drawing.Size(301, 13)
            Me.mobjLinkLabel.TabIndex = 7
            Me.mobjLinkLabel.TabStop = True
            Me.mobjLinkLabel.Text = "www.visualwebgui.com"
            ' 
            ' mobjTrackBar
            ' 
            Me.mobjTrackBar.AllowDrag = False
            Me.mobjTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTrackBar.Location = New System.Drawing.Point(331, 179)
            Me.mobjTrackBar.Name = "mobjTrackBar"
            Me.mobjTrackBar.Size = New System.Drawing.Size(301, 30)
            Me.mobjTrackBar.TabIndex = 8
            ' 
            ' mobjDateTimePicker
            ' 
            Me.mobjDateTimePicker.CustomFormat = ""
            Me.mobjDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.[Short]
            Me.mobjDateTimePicker.Location = New System.Drawing.Point(331, 216)
            Me.mobjDateTimePicker.Name = "mobjDateTimePicker"
            Me.mobjDateTimePicker.Size = New System.Drawing.Size(301, 21)
            Me.mobjDateTimePicker.TabIndex = 9
            ' 
            ' mobjTextBoxCheckBox
            ' 
            Me.mobjTextBoxCheckBox.AutoSize = True
            Me.mobjTextBoxCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTextBoxCheckBox.Location = New System.Drawing.Point(30, 30)
            Me.mobjTextBoxCheckBox.Name = "mobjTextBoxCheckBox"
            Me.mobjTextBoxCheckBox.Size = New System.Drawing.Size(301, 17)
            Me.mobjTextBoxCheckBox.TabIndex = 10
            Me.mobjTextBoxCheckBox.Text = "TextBox"
            Me.mobjTextBoxCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjListBoxCheckBox
            ' 
            Me.mobjListBoxCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBoxCheckBox.Location = New System.Drawing.Point(30, 67)
            Me.mobjListBoxCheckBox.Name = "mobjListBoxCheckBox"
            Me.mobjListBoxCheckBox.Size = New System.Drawing.Size(301, 75)
            Me.mobjListBoxCheckBox.TabIndex = 10
            Me.mobjListBoxCheckBox.Text = "ListBox"
            ' 
            ' mobjLinkLabelCheckBox
            ' 
            Me.mobjLinkLabelCheckBox.AutoSize = True
            Me.mobjLinkLabelCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLinkLabelCheckBox.Location = New System.Drawing.Point(30, 142)
            Me.mobjLinkLabelCheckBox.Name = "mobjLinkLabelCheckBox"
            Me.mobjLinkLabelCheckBox.Size = New System.Drawing.Size(301, 17)
            Me.mobjLinkLabelCheckBox.TabIndex = 10
            Me.mobjLinkLabelCheckBox.Text = "LinkLabel"
            ' 
            ' mobjTrackBarCheckBox
            ' 
            Me.mobjTrackBarCheckBox.AutoSize = True
            Me.mobjTrackBarCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTrackBarCheckBox.Location = New System.Drawing.Point(30, 179)
            Me.mobjTrackBarCheckBox.Name = "mobjTrackBarCheckBox"
            Me.mobjTrackBarCheckBox.Size = New System.Drawing.Size(301, 17)
            Me.mobjTrackBarCheckBox.TabIndex = 11
            Me.mobjTrackBarCheckBox.Text = "TrackBar"
            Me.mobjTrackBarCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjDateTimePickerCheckbox
            ' 
            Me.mobjDateTimePickerCheckbox.AutoSize = True
            Me.mobjDateTimePickerCheckbox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDateTimePickerCheckbox.Location = New System.Drawing.Point(30, 216)
            Me.mobjDateTimePickerCheckbox.Name = "mobjDateTimePickerCheckbox"
            Me.mobjDateTimePickerCheckbox.Size = New System.Drawing.Size(301, 17)
            Me.mobjDateTimePickerCheckbox.TabIndex = 12
            Me.mobjDateTimePickerCheckbox.Text = "DateTimePicker"
            Me.mobjDateTimePickerCheckbox.UseVisualStyleBackColor = True
            ' 
            ' mobjInputTextBox
            ' 
            Me.mobjInputTextBox.AllowDrag = False
            Me.mobjInputTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInputTextBox.Location = New System.Drawing.Point(0, 20)
            Me.mobjInputTextBox.Multiline = True
            Me.mobjInputTextBox.Name = "mobjInputTextBox"
            Me.mobjInputTextBox.Size = New System.Drawing.Size(602, 93)
            Me.mobjInputTextBox.TabIndex = 13
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(64, 13)
            Me.mobjLabel.TabIndex = 14
            Me.mobjLabel.Text = "ToolTip text"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjToolTipTextPanel, 1, 6)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBoxCheckBox, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjListBoxCheckBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLinkLabelCheckBox, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTrackBarCheckBox, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLinkLabel, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTrackBar, 2, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDateTimePicker, 2, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDateTimePickerCheckbox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjListBoxPanel, 2, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 8
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(663, 400)
            Me.mobjLayoutPanel.TabIndex = 15
            ' 
            ' mobjToolTipTextPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjToolTipTextPanel, 2)
            Me.mobjToolTipTextPanel.Controls.Add(Me.mobjInputTextBox)
            Me.mobjToolTipTextPanel.Controls.Add(Me.mobjLabelPanel)
            Me.mobjToolTipTextPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjToolTipTextPanel.Location = New System.Drawing.Point(30, 253)
            Me.mobjToolTipTextPanel.Name = "mobjToolTipTextPanel"
            Me.mobjToolTipTextPanel.Size = New System.Drawing.Size(602, 113)
            Me.mobjToolTipTextPanel.TabIndex = 0
            ' 
            ' mobjListBoxPanel
            ' 
            Me.mobjListBoxPanel.Controls.Add(Me.mobjListBox)
            Me.mobjListBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBoxPanel.DockPadding.Bottom = 10
            Me.mobjListBoxPanel.DockPadding.Top = 10
            Me.mobjListBoxPanel.Location = New System.Drawing.Point(331, 67)
            Me.mobjListBoxPanel.Name = "mobjListBoxPanel"
            Me.mobjListBoxPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjListBoxPanel.Size = New System.Drawing.Size(301, 75)
            Me.mobjListBoxPanel.TabIndex = 0
            ' 
            ' mobjLabelPanel
            ' 
            Me.mobjLabelPanel.Controls.Add(Me.mobjLabel)
            Me.mobjLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabelPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabelPanel.Name = "mobjLabelPanel"
            Me.mobjLabelPanel.Size = New System.Drawing.Size(602, 20)
            Me.mobjLabelPanel.TabIndex = 15
            ' 
            ' ToolTipTitlePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(663, 400)
            Me.Text = "ToolTipTitlePage"
            DirectCast(Me.mobjTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjToolTipTextPanel.ResumeLayout(False)
            Me.mobjListBoxPanel.ResumeLayout(False)
            Me.mobjLabelPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjToolTip As Gizmox.WebGUI.Forms.ToolTip
        Private mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private mobjLinkLabel As Gizmox.WebGUI.Forms.LinkLabel
        Private mobjTrackBar As Gizmox.WebGUI.Forms.TrackBar
        Private mobjDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents mobjTextBoxCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjListBoxCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjLinkLabelCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjTrackBarCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjDateTimePickerCheckbox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjInputTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjToolTipTextPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjListBoxPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLabelPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace
Namespace CompanionKit.Controls.MonthCalendar.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SelectionPropertiesPage
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
          Me.mobjMaxSelectionTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjEndTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjStartTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjStartDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjEndDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjMonthCalendar = New Gizmox.WebGUI.Forms.MonthCalendar()
            Me.mobjCommonLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjCalendarPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjCommonLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjMaxSelectionTextLabel
            ' 
            Me.mobjMaxSelectionTextLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjMaxSelectionTextLabel, 2)
            Me.mobjMaxSelectionTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaxSelectionTextLabel.Location = New System.Drawing.Point(271, 13)
            Me.mobjMaxSelectionTextLabel.Name = "objMaxSelectionTextLabel"
            Me.mobjMaxSelectionTextLabel.Size = New System.Drawing.Size(252, 30)
            Me.mobjMaxSelectionTextLabel.TabIndex = 6
            Me.mobjMaxSelectionTextLabel.Text = "MaxCount:"
            ' 
            ' mobjEndTextLabel
            ' 
            Me.mobjEndTextLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjEndTextLabel, 2)
            Me.mobjEndTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjEndTextLabel.Location = New System.Drawing.Point(20, 93)
            Me.mobjEndTextLabel.Name = "objEndTextLabel"
            Me.mobjEndTextLabel.Size = New System.Drawing.Size(251, 30)
            Me.mobjEndTextLabel.TabIndex = 5
            Me.mobjEndTextLabel.Text = "EndRange:"
            ' 
            ' mobjStartTextLabel
            ' 
            Me.mobjStartTextLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjStartTextLabel, 2)
            Me.mobjStartTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStartTextLabel.Location = New System.Drawing.Point(20, 13)
            Me.mobjStartTextLabel.Name = "objStartTextLabel"
            Me.mobjStartTextLabel.Size = New System.Drawing.Size(251, 30)
            Me.mobjStartTextLabel.TabIndex = 4
            Me.mobjStartTextLabel.Text = "StartRange:"
            ' 
            ' mobjStartDateTimePicker
            ' 
            Me.mobjStartDateTimePicker.CustomFormat = ""
            Me.mobjStartDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStartDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.[Short]
            Me.mobjStartDateTimePicker.Location = New System.Drawing.Point(20, 43)
            Me.mobjStartDateTimePicker.Name = "objStartDateTimePicker"
            Me.mobjStartDateTimePicker.Size = New System.Drawing.Size(231, 21)
            Me.mobjStartDateTimePicker.TabIndex = 1
            ' 
            ' mobjNumericUpDown
            ' 
            Me.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNumericUpDown.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.mobjNumericUpDown.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNumericUpDown.Location = New System.Drawing.Point(271, 43)
            Me.mobjNumericUpDown.Name = "objNumericUpDown"
            Me.mobjNumericUpDown.Size = New System.Drawing.Size(231, 17)
            Me.mobjNumericUpDown.TabIndex = 3
            ' 
            ' mobjEndDateTimePicker
            ' 
            Me.mobjEndDateTimePicker.CustomFormat = ""
            Me.mobjEndDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjEndDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.[Short]
            Me.mobjEndDateTimePicker.Location = New System.Drawing.Point(20, 123)
            Me.mobjEndDateTimePicker.Name = "objEndDateTimePicker"
            Me.mobjEndDateTimePicker.Size = New System.Drawing.Size(231, 21)
            Me.mobjEndDateTimePicker.TabIndex = 2
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjLayoutPanel)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjGroupBox.Size = New System.Drawing.Size(533, 191)
            Me.mobjGroupBox.TabIndex = 4
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "SelectionGroup"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjEndTextLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjStartTextLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxSelectionTextLabel, 3, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNumericUpDown, 3, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjStartDateTimePicker, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjEndDateTimePicker, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjButton, 3, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(5, 19)
            Me.mobjLayoutPanel.Name = "tableLayoutPanel1"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(523, 167)
            Me.mobjLayoutPanel.TabIndex = 8
            ' 
            ' mobjButton
            ' 
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton.Location = New System.Drawing.Point(271, 93)
            Me.mobjButton.Name = "objButton"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjButton, 2)
            Me.mobjButton.Size = New System.Drawing.Size(231, 60)
            Me.mobjButton.TabIndex = 7
            Me.mobjButton.Text = "Set Range"
            ' 
            ' mobjMonthCalendar
            ' 
            Me.mobjMonthCalendar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjMonthCalendar.Location = New System.Drawing.Point(153, 74)
            Me.mobjMonthCalendar.Name = "objMonthCalendar"
            Me.mobjMonthCalendar.SelectionEnd = New System.DateTime(2013, 9, 19, 11, 29, 50, _
             244)
            Me.mobjMonthCalendar.SelectionRange = New Gizmox.WebGUI.Forms.SelectionRange(New System.DateTime(2013, 9, 19, 0, 0, 0, _
             0), New System.DateTime(2013, 9, 19, 0, 0, 0, _
             0))
            Me.mobjMonthCalendar.SelectionStart = New System.DateTime(2013, 9, 19, 11, 29, 50, _
             244)
            Me.mobjMonthCalendar.Size = New System.Drawing.Size(227, 162)
            Me.mobjMonthCalendar.TabIndex = 0
            Me.mobjMonthCalendar.Value = New System.DateTime(2013, 9, 19, 11, 29, 50, _
             244)
            ' 
            ' mobjCommonLayoutPanel
            ' 
            Me.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjCommonLayoutPanel.ColumnCount = 3
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjMonthCalendar, 1, 1)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjPanel, 0, 3)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjCalendarPanel, 0, 1)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCommonLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel"
            Me.mobjCommonLayoutPanel.RowCount = 5
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjCommonLayoutPanel.Size = New System.Drawing.Size(533, 452)
            Me.mobjCommonLayoutPanel.TabIndex = 5
            ' 
            ' mobjCalendarPanel
            ' 
            Me.mobjCalendarPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCalendarPanel.Location = New System.Drawing.Point(0, 70)
            Me.mobjCalendarPanel.Name = "mobjCalendarPanel"
            Me.mobjCalendarPanel.Size = New System.Drawing.Size(50, 171)
            Me.mobjCalendarPanel.TabIndex = 0
            ' 
            ' mobjPanel
            ' 
            Me.mobjCommonLayoutPanel.SetColumnSpan(Me.mobjPanel, 3)
            Me.mobjPanel.Controls.Add(Me.mobjGroupBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(0, 261)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjCommonLayoutPanel.SetRowSpan(Me.mobjPanel, 2)
            Me.mobjPanel.Size = New System.Drawing.Size(533, 191)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AutoSize = True
            Me.mobjCommonLayoutPanel.SetColumnSpan(Me.mobjInfoLabel, 3)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(533, 70)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Tip: User can select range by holding Shift and pressing on date "
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' SelectionPropertiesPage
            ' 
            Me.Controls.Add(Me.mobjCommonLayoutPanel)
            Me.Location = New System.Drawing.Point(0, -68)
            Me.Size = New System.Drawing.Size(533, 452)
            Me.Text = "SelectionPropertiesPage"
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjCommonLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjMaxSelectionTextLabel As Gizmox.WebGUI.Forms.Label
        Private mobjEndTextLabel As Gizmox.WebGUI.Forms.Label
        Private mobjStartTextLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjStartDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents mobjNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjEndDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjMonthCalendar As Gizmox.WebGUI.Forms.MonthCalendar
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private mobjCommonLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjCalendarPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label


	End Class

End Namespace
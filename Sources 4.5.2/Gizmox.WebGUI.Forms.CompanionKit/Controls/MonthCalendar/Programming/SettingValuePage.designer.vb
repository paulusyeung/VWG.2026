Namespace CompanionKit.Controls.MonthCalendar.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SettingValuePage
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
            Me.mobjEnableMonthCalendar = New Gizmox.WebGUI.Forms.MonthCalendar()
            Me.mobjSelectDateDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjSetDateButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDisableMonthCalendar = New Gizmox.WebGUI.Forms.MonthCalendar()
            Me.mobjDisableMonthCalendarRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjEnableMonthCalendarRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' enableMonthCalendar
            ' 
            Me.mobjEnableMonthCalendar.Location = New System.Drawing.Point(20, 182)
            Me.mobjEnableMonthCalendar.Name = "enableMonthCalendar"
            Me.mobjEnableMonthCalendar.SelectionEnd = New System.DateTime(2010, 5, 7, 17, 4, 35, _
             786)
            Me.mobjEnableMonthCalendar.SelectionRange = New Gizmox.WebGUI.Forms.SelectionRange(New System.DateTime(2010, 5, 7, 0, 0, 0, _
             0), New System.DateTime(2010, 5, 7, 0, 0, 0, _
             0))
            Me.mobjEnableMonthCalendar.SelectionStart = New System.DateTime(2010, 5, 7, 17, 4, 35, _
             786)
            Me.mobjEnableMonthCalendar.Size = New System.Drawing.Size(227, 162)
            Me.mobjEnableMonthCalendar.TabIndex = 1
            Me.mobjEnableMonthCalendar.Value = New System.DateTime(2010, 5, 7, 17, 4, 35, _
             786)
            ' 
            ' selectDateDateTimePicker
            ' 
            Me.mobjSelectDateDateTimePicker.CustomFormat = ""
            Me.mobjSelectDateDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSelectDateDateTimePicker.Location = New System.Drawing.Point(20, 22)
            Me.mobjSelectDateDateTimePicker.Name = "selectDateDateTimePicker"
            Me.mobjSelectDateDateTimePicker.Size = New System.Drawing.Size(379, 21)
            Me.mobjSelectDateDateTimePicker.TabIndex = 4
            ' 
            ' setDateButton
            ' 
            Me.mobjSetDateButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSetDateButton.Location = New System.Drawing.Point(419, 22)
            Me.mobjSetDateButton.Name = "setDateButton"
            Me.mobjSetDateButton.Size = New System.Drawing.Size(379, 50)
            Me.mobjSetDateButton.TabIndex = 5
            Me.mobjSetDateButton.Text = "Set date to MonthCalendar"
            Me.mobjSetDateButton.UseVisualStyleBackColor = True
            ' 
            ' disableMonthCalendar
            ' 
            Me.mobjDisableMonthCalendar.Enabled = False
            Me.mobjDisableMonthCalendar.Location = New System.Drawing.Point(419, 182)
            Me.mobjDisableMonthCalendar.Name = "disableMonthCalendar"
            Me.mobjDisableMonthCalendar.SelectionEnd = New System.DateTime(2010, 5, 7, 17, 4, 35, _
             801)
            Me.mobjDisableMonthCalendar.SelectionRange = New Gizmox.WebGUI.Forms.SelectionRange(New System.DateTime(2010, 5, 7, 0, 0, 0, _
             0), New System.DateTime(2010, 5, 7, 0, 0, 0, _
             0))
            Me.mobjDisableMonthCalendar.SelectionStart = New System.DateTime(2010, 5, 7, 17, 4, 35, _
             801)
            Me.mobjDisableMonthCalendar.Size = New System.Drawing.Size(227, 162)
            Me.mobjDisableMonthCalendar.TabIndex = 6
            Me.mobjDisableMonthCalendar.Value = New System.DateTime(2010, 5, 7, 17, 4, 35, _
             801)
            ' 
            ' disableMonthCalendarRadioButton
            ' 
            Me.mobjDisableMonthCalendarRadioButton.AutoSize = True
            Me.mobjDisableMonthCalendarRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDisableMonthCalendarRadioButton.Location = New System.Drawing.Point(419, 92)
            Me.mobjDisableMonthCalendarRadioButton.Name = "disableMonthCalendarRadioButton"
            Me.mobjDisableMonthCalendarRadioButton.Size = New System.Drawing.Size(379, 70)
            Me.mobjDisableMonthCalendarRadioButton.TabIndex = 7
            Me.mobjDisableMonthCalendarRadioButton.Text = "Set date to disabled MonthCalendar"
            Me.mobjDisableMonthCalendarRadioButton.UseVisualStyleBackColor = True
            ' 
            ' enableMonthCalendarRadioButton
            ' 
            Me.mobjEnableMonthCalendarRadioButton.AutoSize = True
            Me.mobjEnableMonthCalendarRadioButton.Checked = True
            Me.mobjEnableMonthCalendarRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjEnableMonthCalendarRadioButton.Location = New System.Drawing.Point(20, 92)
            Me.mobjEnableMonthCalendarRadioButton.Name = "enableMonthCalendarRadioButton"
            Me.mobjEnableMonthCalendarRadioButton.Size = New System.Drawing.Size(379, 70)
            Me.mobjEnableMonthCalendarRadioButton.TabIndex = 8
            Me.mobjEnableMonthCalendarRadioButton.Text = "Set date to enabled MonthCalendar"
            Me.mobjEnableMonthCalendarRadioButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDisableMonthCalendar, 3, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSelectDateDateTimePicker, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSetDateButton, 3, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjEnableMonthCalendarRadioButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjEnableMonthCalendar, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDisableMonthCalendarRadioButton, 3, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(819, 387)
            Me.mobjLayoutPanel.TabIndex = 9
            ' 
            ' SettingValuePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(819, 387)
            Me.Text = "SettingValuePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjEnableMonthCalendar As Gizmox.WebGUI.Forms.MonthCalendar
        Private mobjSelectDateDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents mobjSetDateButton As Gizmox.WebGUI.Forms.Button
        Private mobjDisableMonthCalendar As Gizmox.WebGUI.Forms.MonthCalendar
        Private WithEvents mobjDisableMonthCalendarRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjEnableMonthCalendarRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
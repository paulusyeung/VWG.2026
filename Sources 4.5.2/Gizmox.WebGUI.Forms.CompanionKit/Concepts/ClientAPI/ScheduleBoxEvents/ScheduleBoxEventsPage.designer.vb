Namespace CompanionKit.Concepts.ClientAPI.ScheduleBoxEvents

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ScheduleBoxEventsPage
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
            Me.objEndDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.objSubjectLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objStartDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.objSubjectTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.objEndDateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objTagTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.objStartDateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objColorLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objTagLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objViewModeCombo = New Gizmox.WebGUI.Forms.ComboBox()
            Me.objViewModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objViewModeGroup = New Gizmox.WebGUI.Forms.GroupBox()
            Me.colorCombo = New Gizmox.WebGUI.Forms.ComboBox()
            Me.objButton = New Gizmox.WebGUI.Forms.Button()
            Me.objScheduleBox = New Gizmox.WebGUI.Forms.ScheduleBox()
            Me.objChildBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objInputDataGroup = New Gizmox.WebGUI.Forms.GroupBox()
            Me.objBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objViewModeGroup.SuspendLayout()
            Me.objChildBottomPanel.SuspendLayout()
            Me.objInputDataGroup.SuspendLayout()
            Me.objBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objEndDateTimePicker
            '
            Me.objEndDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss"
            Me.objEndDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom
            Me.objEndDateTimePicker.Location = New System.Drawing.Point(62, 132)
            Me.objEndDateTimePicker.Name = "objEndDateTimePicker"
            Me.objEndDateTimePicker.Size = New System.Drawing.Size(127, 21)
            Me.objEndDateTimePicker.TabIndex = 17
            '
            'objSubjectLabel
            '
            Me.objSubjectLabel.AutoSize = True
            Me.objSubjectLabel.Location = New System.Drawing.Point(7, 23)
            Me.objSubjectLabel.Name = "objSubjectLabel"
            Me.objSubjectLabel.Size = New System.Drawing.Size(43, 13)
            Me.objSubjectLabel.TabIndex = 8
            Me.objSubjectLabel.Text = "Sub"
            '
            'objStartDateTimePicker
            '
            Me.objStartDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss"
            Me.objStartDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom
            Me.objStartDateTimePicker.Location = New System.Drawing.Point(62, 101)
            Me.objStartDateTimePicker.Name = "objStartDateTimePicker"
            Me.objStartDateTimePicker.Size = New System.Drawing.Size(127, 21)
            Me.objStartDateTimePicker.TabIndex = 16
            '
            'objSubjectTextBox
            '
            Me.objSubjectTextBox.AllowDrag = False
            Me.objSubjectTextBox.ClientId = "subject"
            Me.objSubjectTextBox.Location = New System.Drawing.Point(62, 20)
            Me.objSubjectTextBox.Name = "objSubjectTextBox"
            Me.objSubjectTextBox.Size = New System.Drawing.Size(93, 20)
            Me.objSubjectTextBox.TabIndex = 2
            '
            'objEndDateLabel
            '
            Me.objEndDateLabel.AutoSize = True
            Me.objEndDateLabel.Location = New System.Drawing.Point(7, 138)
            Me.objEndDateLabel.Name = "objEndDateLabel"
            Me.objEndDateLabel.Size = New System.Drawing.Size(48, 13)
            Me.objEndDateLabel.TabIndex = 12
            Me.objEndDateLabel.Text = "End"
            '
            'objTagTextBox
            '
            Me.objTagTextBox.AllowDrag = False
            Me.objTagTextBox.ClientId = "tag"
            Me.objTagTextBox.Location = New System.Drawing.Point(62, 46)
            Me.objTagTextBox.Name = "objTagTextBox"
            Me.objTagTextBox.Size = New System.Drawing.Size(93, 20)
            Me.objTagTextBox.TabIndex = 3
            '
            'objStartDateLabel
            '
            Me.objStartDateLabel.AutoSize = True
            Me.objStartDateLabel.Location = New System.Drawing.Point(7, 107)
            Me.objStartDateLabel.Name = "objStartDateLabel"
            Me.objStartDateLabel.Size = New System.Drawing.Size(54, 13)
            Me.objStartDateLabel.TabIndex = 11
            Me.objStartDateLabel.Text = "Start"
            '
            'objColorLabel
            '
            Me.objColorLabel.AutoSize = True
            Me.objColorLabel.Location = New System.Drawing.Point(7, 72)
            Me.objColorLabel.Name = "objColorLabel"
            Me.objColorLabel.Size = New System.Drawing.Size(32, 13)
            Me.objColorLabel.TabIndex = 10
            Me.objColorLabel.Text = "Color"
            '
            'objTagLabel
            '
            Me.objTagLabel.AutoSize = True
            Me.objTagLabel.Location = New System.Drawing.Point(7, 49)
            Me.objTagLabel.Name = "objTagLabel"
            Me.objTagLabel.Size = New System.Drawing.Size(52, 13)
            Me.objTagLabel.TabIndex = 9
            Me.objTagLabel.Text = "Tag"
            '
            'objViewModeCombo
            '
            Me.objViewModeCombo.AllowDrag = False
            Me.objViewModeCombo.ClientId = "view"
            Me.objViewModeCombo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.objViewModeCombo.FormattingEnabled = True
            Me.objViewModeCombo.Items.AddRange(New Object() {"Day", "Week", "Month", "FullWeek", "FullMonth"})
            Me.objViewModeCombo.Location = New System.Drawing.Point(58, 24)
            Me.objViewModeCombo.Name = "objViewModeCombo"
            Me.objViewModeCombo.Size = New System.Drawing.Size(71, 21)
            Me.objViewModeCombo.TabIndex = 7
            Me.objViewModeCombo.Text = "Week"
            '
            'objViewModeLabel
            '
            Me.objViewModeLabel.AutoSize = True
            Me.objViewModeLabel.Location = New System.Drawing.Point(13, 27)
            Me.objViewModeLabel.Name = "objViewModeLabel"
            Me.objViewModeLabel.Size = New System.Drawing.Size(55, 13)
            Me.objViewModeLabel.TabIndex = 13
            Me.objViewModeLabel.Text = "View"
            '
            'objViewModeGroup
            '
            Me.objViewModeGroup.Controls.Add(Me.objViewModeCombo)
            Me.objViewModeGroup.Controls.Add(Me.objViewModeLabel)
            Me.objViewModeGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objViewModeGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objViewModeGroup.Location = New System.Drawing.Point(196, 0)
            Me.objViewModeGroup.Name = "objViewModeGroup"
            Me.objViewModeGroup.Size = New System.Drawing.Size(135, 68)
            Me.objViewModeGroup.TabIndex = 15
            Me.objViewModeGroup.TabStop = False
            Me.objViewModeGroup.Text = "View Mode"
            '
            'colorCombo
            '
            Me.colorCombo.AllowDrag = False
            Me.colorCombo.ClientId = "color"
            Me.colorCombo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.colorCombo.FormattingEnabled = True
            Me.colorCombo.Items.AddRange(New Object() {"Red", "Blue", "Green", "Yellow", "Purple"})
            Me.colorCombo.Location = New System.Drawing.Point(62, 69)
            Me.colorCombo.Name = "colorCombo"
            Me.colorCombo.Size = New System.Drawing.Size(93, 21)
            Me.colorCombo.TabIndex = 6
            Me.colorCombo.Text = "Red"
            '
            'objButton
            '
            Me.objButton.Location = New System.Drawing.Point(0, 1)
            Me.objButton.Name = "objButton"
            Me.objButton.Size = New System.Drawing.Size(123, 59)
            Me.objButton.TabIndex = 0
            Me.objButton.Text = "AddEvent"
            '
            'objScheduleBox
            '
            Me.objScheduleBox.ClientId = "schedule"
            Me.objScheduleBox.DisplayMonthHeader = False
            Me.objScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objScheduleBox.FirstDate = New Date(2013, 8, 8, 13, 50, 24, 484)
            Me.objScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday
            Me.objScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock12H
            Me.objScheduleBox.Location = New System.Drawing.Point(15, 15)
            Me.objScheduleBox.Name = "objScheduleBox"
            Me.objScheduleBox.Size = New System.Drawing.Size(364, 260)
            Me.objScheduleBox.TabIndex = 1
            Me.objScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Week
            Me.objScheduleBox.WorkEndHour = 17
            Me.objScheduleBox.WorkStartHour = 9
            '
            'objChildBottomPanel
            '
            Me.objChildBottomPanel.Controls.Add(Me.objButton)
            Me.objChildBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objChildBottomPanel.Location = New System.Drawing.Point(196, 68)
            Me.objChildBottomPanel.Name = "objChildBottomPanel"
            Me.objChildBottomPanel.Size = New System.Drawing.Size(168, 100)
            Me.objChildBottomPanel.TabIndex = 16
            '
            'objInputDataGroup
            '
            Me.objInputDataGroup.Controls.Add(Me.objEndDateTimePicker)
            Me.objInputDataGroup.Controls.Add(Me.objSubjectLabel)
            Me.objInputDataGroup.Controls.Add(Me.objStartDateTimePicker)
            Me.objInputDataGroup.Controls.Add(Me.objSubjectTextBox)
            Me.objInputDataGroup.Controls.Add(Me.objEndDateLabel)
            Me.objInputDataGroup.Controls.Add(Me.objTagTextBox)
            Me.objInputDataGroup.Controls.Add(Me.objStartDateLabel)
            Me.objInputDataGroup.Controls.Add(Me.objColorLabel)
            Me.objInputDataGroup.Controls.Add(Me.objTagLabel)
            Me.objInputDataGroup.Controls.Add(Me.colorCombo)
            Me.objInputDataGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objInputDataGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objInputDataGroup.Location = New System.Drawing.Point(0, 0)
            Me.objInputDataGroup.Name = "objInputDataGroup"
            Me.objInputDataGroup.Size = New System.Drawing.Size(196, 168)
            Me.objInputDataGroup.TabIndex = 14
            Me.objInputDataGroup.TabStop = False
            Me.objInputDataGroup.Text = "Input Data"
            '
            'objBottomPanel
            '
            Me.objBottomPanel.Controls.Add(Me.objViewModeGroup)
            Me.objBottomPanel.Controls.Add(Me.objChildBottomPanel)
            Me.objBottomPanel.Controls.Add(Me.objInputDataGroup)
            Me.objBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objBottomPanel.Location = New System.Drawing.Point(15, 275)
            Me.objBottomPanel.Name = "objBottomPanel"
            Me.objBottomPanel.Size = New System.Drawing.Size(364, 168)
            Me.objBottomPanel.TabIndex = 16
            '
            'ScheduleBoxEventsPage
            '
            Me.Controls.Add(Me.objScheduleBox)
            Me.Controls.Add(Me.objBottomPanel)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(394, 458)
            Me.Text = "ScheduleBoxEventsPage"
            Me.objViewModeGroup.ResumeLayout(False)
            Me.objChildBottomPanel.ResumeLayout(False)
            Me.objInputDataGroup.ResumeLayout(False)
            Me.objBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.blnLoadFlag = True
        End Sub
        Private blnLoadFlag As Boolean = False
        Private WithEvents objEndDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents objSubjectLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objStartDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents objSubjectTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents objEndDateLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objTagTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents objStartDateLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objColorLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objTagLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objViewModeCombo As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents objViewModeLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objViewModeGroup As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents colorCombo As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents objButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox
        Private WithEvents objChildBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objInputDataGroup As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents objBottomPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
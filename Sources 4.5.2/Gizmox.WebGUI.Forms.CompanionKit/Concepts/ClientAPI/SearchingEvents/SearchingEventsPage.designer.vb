Namespace CompanionKit.Concepts.ClientAPI.SearchingEvents

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SearchingEventsPage
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
            Me.objOutputTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.objOutputDataGroup = New Gizmox.WebGUI.Forms.GroupBox()
            Me.objStartDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.objViewModeCombo = New Gizmox.WebGUI.Forms.ComboBox()
            Me.objViewModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objViewModeGroup = New Gizmox.WebGUI.Forms.GroupBox()
            Me.objEndDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.objEndLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objStartLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objInputDataGroup = New Gizmox.WebGUI.Forms.GroupBox()
            Me.objButton = New Gizmox.WebGUI.Forms.Button()
            Me.objRangeRadio = New Gizmox.WebGUI.Forms.RadioButton()
            Me.objExactRadio = New Gizmox.WebGUI.Forms.RadioButton()
            Me.objSearchTypeGroup = New Gizmox.WebGUI.Forms.GroupBox()
            Me.objScheduleBox = New Gizmox.WebGUI.Forms.ScheduleBox()
            Me.objPanel3 = New Gizmox.WebGUI.Forms.Panel()
            Me.objPanel1 = New Gizmox.WebGUI.Forms.Panel()
            Me.objPanel2 = New Gizmox.WebGUI.Forms.Panel()
            Me.objOutputDataGroup.SuspendLayout()
            Me.objViewModeGroup.SuspendLayout()
            Me.objInputDataGroup.SuspendLayout()
            Me.objSearchTypeGroup.SuspendLayout()
            Me.objPanel3.SuspendLayout()
            Me.objPanel1.SuspendLayout()
            Me.objPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'objOutputTextBox
            '
            Me.objOutputTextBox.AllowDrag = False
            Me.objOutputTextBox.ClientId = "textBox"
            Me.objOutputTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objOutputTextBox.Location = New System.Drawing.Point(10, 24)
            Me.objOutputTextBox.Multiline = True
            Me.objOutputTextBox.Name = "objOutputTextBox"
            Me.objOutputTextBox.ReadOnly = True
            Me.objOutputTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical
            Me.objOutputTextBox.Size = New System.Drawing.Size(300, 46)
            Me.objOutputTextBox.TabIndex = 0
            '
            'objOutputDataGroup
            '
            Me.objOutputDataGroup.Controls.Add(Me.objOutputTextBox)
            Me.objOutputDataGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objOutputDataGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objOutputDataGroup.Location = New System.Drawing.Point(10, 10)
            Me.objOutputDataGroup.MinimumSize = New System.Drawing.Size(320, 80)
            Me.objOutputDataGroup.Name = "objOutputDataGroup"
            Me.objOutputDataGroup.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objOutputDataGroup.Size = New System.Drawing.Size(320, 80)
            Me.objOutputDataGroup.TabIndex = 6
            Me.objOutputDataGroup.TabStop = False
            Me.objOutputDataGroup.Text = "Output data"
            '
            'objStartDateTimePicker
            '
            Me.objStartDateTimePicker.CustomFormat = "MM/dd/yyyy"
            Me.objStartDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom
            Me.objStartDateTimePicker.Location = New System.Drawing.Point(86, 17)
            Me.objStartDateTimePicker.Name = "objStartDateTimePicker"
            Me.objStartDateTimePicker.Size = New System.Drawing.Size(100, 21)
            Me.objStartDateTimePicker.TabIndex = 16
            '
            'objViewModeCombo
            '
            Me.objViewModeCombo.AllowDrag = False
            Me.objViewModeCombo.ClientId = "view"
            Me.objViewModeCombo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.objViewModeCombo.FormattingEnabled = True
            Me.objViewModeCombo.Items.AddRange(New Object() {"Day", "Week", "Month", "FullWeek", "FullMonth"})
            Me.objViewModeCombo.Location = New System.Drawing.Point(74, 17)
            Me.objViewModeCombo.Name = "objViewModeCombo"
            Me.objViewModeCombo.Size = New System.Drawing.Size(97, 21)
            Me.objViewModeCombo.TabIndex = 7
            Me.objViewModeCombo.Text = "Week"
            '
            'objViewModeLabel
            '
            Me.objViewModeLabel.AutoSize = True
            Me.objViewModeLabel.Location = New System.Drawing.Point(12, 20)
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
            Me.objViewModeGroup.Location = New System.Drawing.Point(10, 10)
            Me.objViewModeGroup.Name = "objViewModeGroup"
            Me.objViewModeGroup.Size = New System.Drawing.Size(196, 48)
            Me.objViewModeGroup.TabIndex = 15
            Me.objViewModeGroup.TabStop = False
            Me.objViewModeGroup.Text = "View Mode"
            '
            'objEndDateTimePicker
            '
            Me.objEndDateTimePicker.CustomFormat = "MM/dd/yyyy"
            Me.objEndDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom
            Me.objEndDateTimePicker.Location = New System.Drawing.Point(86, 47)
            Me.objEndDateTimePicker.Name = "objEndDateTimePicker"
            Me.objEndDateTimePicker.Size = New System.Drawing.Size(100, 21)
            Me.objEndDateTimePicker.TabIndex = 16
            Me.objEndDateTimePicker.Visible = False
            '
            'objEndLabel
            '
            Me.objEndLabel.AutoSize = True
            Me.objEndLabel.ClientId = "eLabel"
            Me.objEndLabel.Location = New System.Drawing.Point(19, 49)
            Me.objEndLabel.Name = "objEndLabel"
            Me.objEndLabel.Size = New System.Drawing.Size(35, 13)
            Me.objEndLabel.TabIndex = 7
            Me.objEndLabel.Text = "End"
            Me.objEndLabel.Visible = False
            '
            'objStartLabel
            '
            Me.objStartLabel.AutoSize = True
            Me.objStartLabel.Location = New System.Drawing.Point(19, 23)
            Me.objStartLabel.Name = "objStartLabel"
            Me.objStartLabel.Size = New System.Drawing.Size(35, 13)
            Me.objStartLabel.TabIndex = 6
            Me.objStartLabel.Text = "Start"
            '
            'objInputDataGroup
            '
            Me.objInputDataGroup.Controls.Add(Me.objEndDateTimePicker)
            Me.objInputDataGroup.Controls.Add(Me.objStartDateTimePicker)
            Me.objInputDataGroup.Controls.Add(Me.objEndLabel)
            Me.objInputDataGroup.Controls.Add(Me.objStartLabel)
            Me.objInputDataGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objInputDataGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objInputDataGroup.Location = New System.Drawing.Point(132, 10)
            Me.objInputDataGroup.Name = "objInputDataGroup"
            Me.objInputDataGroup.Size = New System.Drawing.Size(198, 71)
            Me.objInputDataGroup.TabIndex = 5
            Me.objInputDataGroup.TabStop = False
            Me.objInputDataGroup.Text = "Input data"
            '
            'objButton
            '
            Me.objButton.Location = New System.Drawing.Point(218, 15)
            Me.objButton.Name = "objButton"
            Me.objButton.Size = New System.Drawing.Size(112, 42)
            Me.objButton.TabIndex = 7
            Me.objButton.Text = "Find Events"
            '
            'objRangeRadio
            '
            Me.objRangeRadio.AutoSize = True
            Me.objRangeRadio.Location = New System.Drawing.Point(10, 43)
            Me.objRangeRadio.Name = "objRangeRadio"
            Me.objRangeRadio.Size = New System.Drawing.Size(56, 17)
            Me.objRangeRadio.TabIndex = 17
            Me.objRangeRadio.Text = "Range"
            '
            'objExactRadio
            '
            Me.objExactRadio.AutoSize = True
            Me.objExactRadio.Checked = True
            Me.objExactRadio.ClientId = "exact"
            Me.objExactRadio.Location = New System.Drawing.Point(10, 17)
            Me.objExactRadio.Name = "objExactRadio"
            Me.objExactRadio.Size = New System.Drawing.Size(77, 17)
            Me.objExactRadio.TabIndex = 16
            Me.objExactRadio.Text = "Exact date"
            '
            'objSearchTypeGroup
            '
            Me.objSearchTypeGroup.Controls.Add(Me.objRangeRadio)
            Me.objSearchTypeGroup.Controls.Add(Me.objExactRadio)
            Me.objSearchTypeGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objSearchTypeGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objSearchTypeGroup.Location = New System.Drawing.Point(10, 10)
            Me.objSearchTypeGroup.Name = "objSearchTypeGroup"
            Me.objSearchTypeGroup.Size = New System.Drawing.Size(122, 71)
            Me.objSearchTypeGroup.TabIndex = 4
            Me.objSearchTypeGroup.TabStop = False
            Me.objSearchTypeGroup.Text = "Search by"
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
            Me.objScheduleBox.Size = New System.Drawing.Size(340, 136)
            Me.objScheduleBox.TabIndex = 1
            Me.objScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Week
            Me.objScheduleBox.WorkEndHour = 17
            Me.objScheduleBox.WorkStartHour = 9
            '
            'objPanel3
            '
            Me.objPanel3.Controls.Add(Me.objOutputDataGroup)
            Me.objPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objPanel3.DockPadding.All = 10
            Me.objPanel3.Location = New System.Drawing.Point(15, 310)
            Me.objPanel3.MaximumSize = New System.Drawing.Size(340, 100)
            Me.objPanel3.Name = "objPanel3"
            Me.objPanel3.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objPanel3.Size = New System.Drawing.Size(340, 100)
            Me.objPanel3.TabIndex = 18
            '
            'objPanel1
            '
            Me.objPanel1.Controls.Add(Me.objInputDataGroup)
            Me.objPanel1.Controls.Add(Me.objSearchTypeGroup)
            Me.objPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objPanel1.DockPadding.All = 10
            Me.objPanel1.Location = New System.Drawing.Point(15, 151)
            Me.objPanel1.Name = "objPanel1"
            Me.objPanel1.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objPanel1.Size = New System.Drawing.Size(340, 91)
            Me.objPanel1.TabIndex = 16
            '
            'objPanel2
            '
            Me.objPanel2.Controls.Add(Me.objViewModeGroup)
            Me.objPanel2.Controls.Add(Me.objButton)
            Me.objPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objPanel2.DockPadding.All = 10
            Me.objPanel2.Location = New System.Drawing.Point(15, 242)
            Me.objPanel2.Name = "objPanel2"
            Me.objPanel2.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objPanel2.Size = New System.Drawing.Size(340, 68)
            Me.objPanel2.TabIndex = 17
            '
            'SearchingEventsPage
            '
            Me.Controls.Add(Me.objScheduleBox)
            Me.Controls.Add(Me.objPanel1)
            Me.Controls.Add(Me.objPanel2)
            Me.Controls.Add(Me.objPanel3)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(370, 425)
            Me.Text = "SearchingEventsPage"
            Me.objOutputDataGroup.ResumeLayout(False)
            Me.objViewModeGroup.ResumeLayout(False)
            Me.objInputDataGroup.ResumeLayout(False)
            Me.objSearchTypeGroup.ResumeLayout(False)
            Me.objPanel3.ResumeLayout(False)
            Me.objPanel1.ResumeLayout(False)
            Me.objPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub
        Private WithEvents objOutputTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents objOutputDataGroup As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents objStartDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents objViewModeCombo As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents objViewModeLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objViewModeGroup As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents objEndDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents objEndLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objStartLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objInputDataGroup As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents objButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objRangeRadio As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents objExactRadio As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents objSearchTypeGroup As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents objScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox
        Private WithEvents objPanel3 As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objPanel1 As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objPanel2 As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
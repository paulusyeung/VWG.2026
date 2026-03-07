Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace CompanionKit.Controls.ScheduleBox
    Public Class Appearence
		Inherits Gizmox.WebGUI.Forms.UserControl
        ' Methods
        Public Sub New()
            Me.InitializeComponent
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub firstDateDate_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not Me.ScheduleBox Is Nothing) Then
                Me.ScheduleBox.FirstDate = Me.calendarDate.Value
            End If
        End Sub

        Private Sub firstDateOfWeek_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not Me.ScheduleBox Is Nothing) Then
				Me.ScheduleBox.FirstDayOfWeek = DirectCast([Enum].Parse(GetType(Day), TryCast(TryCast(sender, Control).Tag, String)), Day)
            End If
        End Sub

        Private Sub hourFormat_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not Me.ScheduleBox Is Nothing) Then
				Me.ScheduleBox.HourFormat = DirectCast([Enum].Parse(GetType(ScheduleBoxHourFormat), TryCast(TryCast(sender, Control).Tag, String)), ScheduleBoxHourFormat)
            End If
        End Sub

        Private Sub InitializeComponent()
			Me.calendarDate = New Gizmox.WebGUI.Forms.MonthCalendar
			Me.groupBox5 = New Gizmox.WebGUI.Forms.GroupBox
			Me.daySunday = New Gizmox.WebGUI.Forms.RadioButton
			Me.dayMonday = New Gizmox.WebGUI.Forms.RadioButton
			Me.groupBox4 = New Gizmox.WebGUI.Forms.GroupBox
			Me.hour12 = New Gizmox.WebGUI.Forms.RadioButton
			Me.hour24 = New Gizmox.WebGUI.Forms.RadioButton
			Me.groupBox3 = New Gizmox.WebGUI.Forms.GroupBox
			Me.viewDay = New Gizmox.WebGUI.Forms.RadioButton
			Me.viewMonth = New Gizmox.WebGUI.Forms.RadioButton
			Me.viewFullMonth = New Gizmox.WebGUI.Forms.RadioButton
			Me.viewFullWeek = New Gizmox.WebGUI.Forms.RadioButton
			Me.viewWeek = New Gizmox.WebGUI.Forms.RadioButton
			Me.groupBox2 = New Gizmox.WebGUI.Forms.GroupBox
			Me.lblEndWork = New Gizmox.WebGUI.Forms.Label
			Me.lblStartWork = New Gizmox.WebGUI.Forms.Label
			Me.workEnd = New Gizmox.WebGUI.Forms.TrackBar
			Me.workStart = New Gizmox.WebGUI.Forms.TrackBar
			Me.groupBox1 = New Gizmox.WebGUI.Forms.GroupBox
            Me.groupBox5.SuspendLayout
            Me.groupBox4.SuspendLayout
            Me.groupBox3.SuspendLayout
            Me.groupBox2.SuspendLayout
            Me.workEnd.BeginInit
            Me.workStart.BeginInit
            Me.groupBox1.SuspendLayout
            MyBase.SuspendLayout
            Me.calendarDate.Location = New Point(14, &H18)
            Me.calendarDate.Name = "calendarDate"
            Me.calendarDate.Size = New Size(150, &H9B)
            Me.calendarDate.TabIndex = 14
            Me.calendarDate.Value = New DateTime(&H7DA, 12, 2, 15, 15, &H2E, &H26E)
            AddHandler Me.calendarDate.DateChanged, New EventHandler(AddressOf Me.firstDateDate_ValueChanged)
            Me.groupBox5.Controls.Add(Me.calendarDate)
            Me.groupBox5.FlatStyle = FlatStyle.Flat
            Me.groupBox5.Location = New Point(4, &H193)
            Me.groupBox5.Name = "groupBox5"
            Me.groupBox5.Size = New Size(170, &HBB)
            Me.groupBox5.TabIndex = 15
            Me.groupBox5.TabStop = False
            Me.groupBox5.Text = "Date"
            Me.daySunday.AutoSize = True
            Me.daySunday.Location = New Point(&H11, &H13)
            Me.daySunday.Name = "daySunday"
            Me.daySunday.Size = New Size(&H3D, &H11)
            Me.daySunday.TabIndex = 0
            Me.daySunday.Tag = "Sunday"
            Me.daySunday.Text = "Sunday"
            AddHandler Me.daySunday.CheckedChanged, New EventHandler(AddressOf Me.firstDateOfWeek_CheckedChanged)
            Me.dayMonday.AutoSize = True
            Me.dayMonday.Checked = True
            Me.dayMonday.Location = New Point(&H11, &H2A)
            Me.dayMonday.Name = "dayMonday"
            Me.dayMonday.Size = New Size(&H3F, &H11)
            Me.dayMonday.TabIndex = 0
            Me.dayMonday.Tag = "Monday"
            Me.dayMonday.Text = "Monday"
            AddHandler Me.dayMonday.CheckedChanged, New EventHandler(AddressOf Me.firstDateOfWeek_CheckedChanged)
            Me.groupBox4.Controls.Add(Me.daySunday)
            Me.groupBox4.Controls.Add(Me.dayMonday)
            Me.groupBox4.FlatStyle = FlatStyle.Flat
            Me.groupBox4.Location = New Point(4, &HD9)
            Me.groupBox4.Name = "groupBox4"
            Me.groupBox4.Size = New Size(170, &H45)
            Me.groupBox4.TabIndex = 13
            Me.groupBox4.TabStop = False
            Me.groupBox4.Text = "First day of week"
            Me.hour12.AutoSize = True
            Me.hour12.Location = New Point(&H11, &H13)
            Me.hour12.Name = "hour12"
            Me.hour12.Size = New Size(&H44, &H11)
            Me.hour12.TabIndex = 0
            Me.hour12.Tag = "Clock12H"
            Me.hour12.Text = "12 Hours"
            AddHandler Me.hour12.CheckedChanged, New EventHandler(AddressOf Me.hourFormat_CheckedChanged)
            Me.hour24.AutoSize = True
            Me.hour24.Checked = True
            Me.hour24.Location = New Point(&H11, &H2A)
            Me.hour24.Name = "hour24"
            Me.hour24.Size = New Size(&H44, &H11)
            Me.hour24.TabIndex = 0
            Me.hour24.Tag = "Clock24H"
            Me.hour24.Text = "24 Hours"
            AddHandler Me.hour24.CheckedChanged, New EventHandler(AddressOf Me.hourFormat_CheckedChanged)
            Me.groupBox3.Controls.Add(Me.hour12)
            Me.groupBox3.Controls.Add(Me.hour24)
            Me.groupBox3.FlatStyle = FlatStyle.Flat
            Me.groupBox3.Location = New Point(4, &H90)
            Me.groupBox3.Name = "groupBox3"
            Me.groupBox3.Size = New Size(170, 70)
            Me.groupBox3.TabIndex = 13
            Me.groupBox3.TabStop = False
            Me.groupBox3.Text = "Hour format"
            Me.viewDay.AutoSize = True
            Me.viewDay.Checked = True
            Me.viewDay.Location = New Point(&H11, &H6F)
            Me.viewDay.Name = "viewDay"
            Me.viewDay.Size = New Size(&H2C, &H11)
            Me.viewDay.TabIndex = 0
            Me.viewDay.Tag = "Day"
            Me.viewDay.Text = "Day"
            AddHandler Me.viewDay.CheckedChanged, New EventHandler(AddressOf Me.Views_Changed)
            Me.viewMonth.AutoSize = True
            Me.viewMonth.Location = New Point(&H11, &H58)
            Me.viewMonth.Name = "viewMonth"
            Me.viewMonth.Size = New Size(&H37, &H11)
            Me.viewMonth.TabIndex = 0
            Me.viewMonth.Tag = "Month"
            Me.viewMonth.Text = "Month"
            AddHandler Me.viewMonth.CheckedChanged, New EventHandler(AddressOf Me.Views_Changed)
            Me.viewFullMonth.AutoSize = True
            Me.viewFullMonth.Location = New Point(&H11, &H41)
            Me.viewFullMonth.Name = "viewFullMonth"
            Me.viewFullMonth.Size = New Size(&H47, &H11)
            Me.viewFullMonth.TabIndex = 0
            Me.viewFullMonth.Tag = "FullMonth"
            Me.viewFullMonth.Text = "FullMonth"
            AddHandler Me.viewFullMonth.CheckedChanged, New EventHandler(AddressOf Me.Views_Changed)
            Me.viewFullWeek.AutoSize = True
            Me.viewFullWeek.Location = New Point(&H11, &H2A)
            Me.viewFullWeek.Name = "viewFullWeek"
            Me.viewFullWeek.Size = New Size(&H44, &H11)
            Me.viewFullWeek.TabIndex = 0
            Me.viewFullWeek.Tag = "FullWeek"
            Me.viewFullWeek.Text = "FullWeek"
            AddHandler Me.viewFullWeek.CheckedChanged, New EventHandler(AddressOf Me.Views_Changed)
            Me.viewWeek.AutoSize = True
            Me.viewWeek.Location = New Point(&H11, &H13)
            Me.viewWeek.Name = "viewWeek"
            Me.viewWeek.Size = New Size(&H34, &H11)
            Me.viewWeek.TabIndex = 0
            Me.viewWeek.Tag = "Week"
            Me.viewWeek.Text = "Week"
            Me.viewWeek.UseVisualStyleBackColor = True
            AddHandler Me.viewWeek.CheckedChanged, New EventHandler(AddressOf Me.Views_Changed)
            Me.groupBox2.Controls.Add(Me.viewDay)
            Me.groupBox2.Controls.Add(Me.viewMonth)
            Me.groupBox2.Controls.Add(Me.viewFullMonth)
            Me.groupBox2.Controls.Add(Me.viewFullWeek)
            Me.groupBox2.Controls.Add(Me.viewWeek)
            Me.groupBox2.FlatStyle = FlatStyle.Flat
            Me.groupBox2.Location = New Point(4, 5)
            Me.groupBox2.Name = "groupBox2"
            Me.groupBox2.Size = New Size(170, &H88)
            Me.groupBox2.TabIndex = 12
            Me.groupBox2.TabStop = False
            Me.groupBox2.Text = "ScheduleBox view mode"
            Me.lblEndWork.AutoSize = True
            Me.lblEndWork.Location = New Point(150, &H4C)
            Me.lblEndWork.Name = "lblEndWork"
            Me.lblEndWork.Size = New Size(13, 13)
            Me.lblEndWork.TabIndex = 11
            Me.lblEndWork.Text = "17"
            Me.lblEndWork.TextAlign = ContentAlignment.MiddleLeft
            Me.lblStartWork.AutoSize = True
            Me.lblStartWork.Location = New Point(&H97, &H19)
            Me.lblStartWork.Name = "lblStartWork"
            Me.lblStartWork.Size = New Size(13, 13)
            Me.lblStartWork.TabIndex = 11
            Me.lblStartWork.Text = "9"
            Me.lblStartWork.TextAlign = ContentAlignment.MiddleLeft
            Me.workEnd.Location = New Point(8, &H47)
            Me.workEnd.Maximum = &H17
            Me.workEnd.Minimum = &H10
            Me.workEnd.Name = "workEnd"
            Me.workEnd.Size = New Size(130, &H23)
            Me.workEnd.TabIndex = 10
            Me.workEnd.Value = &H11
            AddHandler Me.workEnd.ValueChanged, New EventHandler(AddressOf Me.workHours_ValueChanged)
            Me.workStart.Location = New Point(8, 20)
            Me.workStart.Maximum = 12
            Me.workStart.Minimum = 7
            Me.workStart.Name = "workStart"
            Me.workStart.Size = New Size(130, &H30)
            Me.workStart.TabIndex = 10
            Me.workStart.Value = 9
            AddHandler Me.workStart.ValueChanged, New EventHandler(AddressOf Me.workHours_ValueChanged)
            Me.groupBox1.Controls.Add(Me.lblEndWork)
            Me.groupBox1.Controls.Add(Me.lblStartWork)
            Me.groupBox1.Controls.Add(Me.workEnd)
            Me.groupBox1.Controls.Add(Me.workStart)
            Me.groupBox1.FlatStyle = FlatStyle.Flat
            Me.groupBox1.Location = New Point(4, &H121)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New Size(170, &H6F)
            Me.groupBox1.TabIndex = 11
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Work hours [start/end]"
            MyBase.Controls.Add(Me.groupBox1)
            MyBase.Controls.Add(Me.groupBox2)
            MyBase.Controls.Add(Me.groupBox3)
            MyBase.Controls.Add(Me.groupBox4)
            MyBase.Controls.Add(Me.groupBox5)
            MyBase.Size = New Size(&HBB, &H263)
            Me.Text = "Appearence"
            Me.groupBox5.ResumeLayout(False)
            Me.groupBox4.ResumeLayout(False)
            Me.groupBox3.ResumeLayout(False)
            Me.groupBox2.ResumeLayout(False)
            Me.workEnd.EndInit
            Me.workStart.EndInit
            Me.groupBox1.ResumeLayout(False)
            MyBase.ResumeLayout(False)
        End Sub

        Public Sub SetInitial_1()
            Me.SetInitial_Common
            Me.viewWeek.Checked = True
            Me.workStart.Value = 8
        End Sub

        Public Sub SetInitial_2()
            Me.viewMonth.Checked = True
            Me.workStart.Value = 7
            Me.SetInitial_Common
        End Sub

        Public Sub SetInitial_3()
            Me.ScheduleBox.View = ScheduleBoxView.FullWeek
            Me.SetInitial_Common
        End Sub

        Public Sub SetInitial_4()
            Me.viewDay.Checked = True
            Me.workStart.Value = 9
            Me.SetInitial_Common
        End Sub

        Public Sub SetInitial_Common()
            Me.ScheduleBox.HourFormat = ScheduleBoxHourFormat.Clock24H
            Me.ScheduleBox.WorkEndHour = &H11
            Me.ScheduleBox.WorkStartHour = 9
            Me.ScheduleBox.FirstDayOfWeek = Day.Monday
			Me.ScheduleBox.FirstDate = Me.ScheduleBox.Events.Item(0).Start
			Me.calendarDate.Value = Me.ScheduleBox.FirstDate
        End Sub

		Private Sub Views_Changed(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me.ScheduleBox Is Nothing) Then
				Me.ScheduleBox.View = DirectCast([Enum].Parse(GetType(ScheduleBoxView), TryCast(TryCast(sender, Control).Tag, String)), ScheduleBoxView)
			End If
		End Sub

        Private Sub workHours_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not Me.ScheduleBox Is Nothing) Then
                If (sender Is Me.workEnd) Then
                    Me.ScheduleBox.WorkEndHour = Me.workEnd.Value
                    Me.lblEndWork.Text = Me.workEnd.Value.ToString
                ElseIf (sender Is Me.workStart) Then
                    Me.ScheduleBox.WorkStartHour = Me.workStart.Value
                    Me.lblStartWork.Text = Me.workStart.Value.ToString
                End If
                Me.ScheduleBox.Update
            End If
        End Sub


        ' Properties
		Public Property ScheduleBox() As Gizmox.WebGUI.Forms.ScheduleBox
			Get
				Return Me.mobjScheduleBox
			End Get
			Set(ByVal value As Gizmox.WebGUI.Forms.ScheduleBox)
				Me.mobjScheduleBox = value
			End Set
		End Property


        ' Fields
		Private calendarDate As Gizmox.WebGUI.Forms.MonthCalendar
        Private components As IContainer = Nothing
		Private dayMonday As Gizmox.WebGUI.Forms.RadioButton
		Private daySunday As Gizmox.WebGUI.Forms.RadioButton
		Private groupBox1 As Gizmox.WebGUI.Forms.GroupBox
		Private groupBox2 As Gizmox.WebGUI.Forms.GroupBox
		Private groupBox3 As Gizmox.WebGUI.Forms.GroupBox
		Private groupBox4 As Gizmox.WebGUI.Forms.GroupBox
		Private groupBox5 As Gizmox.WebGUI.Forms.GroupBox
		Private hour12 As Gizmox.WebGUI.Forms.RadioButton
		Private hour24 As Gizmox.WebGUI.Forms.RadioButton
		Private lblEndWork As Gizmox.WebGUI.Forms.Label
		Private lblStartWork As Gizmox.WebGUI.Forms.Label
		Private mobjScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox
		Private viewDay As Gizmox.WebGUI.Forms.RadioButton
		Private viewFullMonth As Gizmox.WebGUI.Forms.RadioButton
		Private viewFullWeek As Gizmox.WebGUI.Forms.RadioButton
		Private viewMonth As Gizmox.WebGUI.Forms.RadioButton
		Private viewWeek As Gizmox.WebGUI.Forms.RadioButton
		Private workEnd As Gizmox.WebGUI.Forms.TrackBar
		Private workStart As Gizmox.WebGUI.Forms.TrackBar
    End Class
End Namespace


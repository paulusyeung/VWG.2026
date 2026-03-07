Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace CompanionKit.Controls.ScheduleBox.Appearance
    Public Class ScheduleBoxViewPropertiesPage
        Inherits UserControl
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

		Private Sub EventDoubleClick(ByVal sender As Object, ByVal e As Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventArgs)
			Events.ProcessOpenEvent(Me.demoScheduleBox, e.Event)
		End Sub

		Private Sub InitializeComponent()
			Me.demoScheduleBox = New Gizmox.WebGUI.Forms.ScheduleBox
			Me.panel1 = New Gizmox.WebGUI.Forms.Panel
			Me.panel2 = New Gizmox.WebGUI.Forms.Panel
			Me.objAppearance = New Appearence
			Me.panel1.SuspendLayout()
			Me.panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.demoScheduleBox.DisplayMonthHeader = True
			Me.demoScheduleBox.Dock = DockStyle.Fill
			Me.demoScheduleBox.FirstDate = New DateTime(&H7DA, 5, &H1F, 11, &H1D, &H33, &HE3)
			Me.demoScheduleBox.FirstDayOfWeek = Day.Monday
			Me.demoScheduleBox.HourFormat = ScheduleBoxHourFormat.Clock24H
			Me.demoScheduleBox.Location = New Point(0, 0)
			Me.demoScheduleBox.Name = "demoScheduleBox"
			Me.demoScheduleBox.Size = New Size(470, &H2A0)
			Me.demoScheduleBox.TabIndex = 0
			Me.demoScheduleBox.View = ScheduleBoxView.Day
			Me.demoScheduleBox.WorkEndHour = &H11
			Me.demoScheduleBox.WorkStartHour = 9
			AddHandler Me.demoScheduleBox.EventDoubleClick, New Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventHandler(AddressOf Me.EventDoubleClick)
			Me.panel1.Controls.Add(Me.objAppearance)
			Me.panel1.Dock = DockStyle.Left
			Me.panel1.Location = New Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New Size(180, &H2A0)
			Me.panel1.TabIndex = 2
			Me.panel2.Controls.Add(Me.demoScheduleBox)
			Me.panel2.Dock = DockStyle.Fill
			Me.panel2.Location = New Point(180, 0)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New Size(470, &H2A0)
			Me.panel2.TabIndex = 3
			Me.objAppearance.AutoValidate = AutoValidate.EnablePreventFocusChange
			Me.objAppearance.Location = New Point(0, 0)
			Me.objAppearance.Name = "objAppearance"
			Me.objAppearance.ScheduleBox = Nothing
			Me.objAppearance.Size = New Size(&HB5, &H268)
			Me.objAppearance.TabIndex = 1
			Me.objAppearance.Text = "Appearence"
			MyBase.Controls.Add(Me.panel2)
			MyBase.Controls.Add(Me.panel1)
			MyBase.Size = New Size(650, &H2A0)
			Me.Text = "ScheduleBoxViewPropertiesPage"
			AddHandler MyBase.Load, New EventHandler(AddressOf Me.ScheduleBoxViewPropertiesPage_Load)
			Me.panel1.ResumeLayout(False)
			Me.panel2.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

        Private Sub ScheduleBoxViewPropertiesPage_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.objAppearance.ScheduleBox = Me.demoScheduleBox
            Dim currEvent As ScheduleBoxEvent
            For Each currEvent In Events.GetEvents
                Me.demoScheduleBox.Events.Add(currEvent)
            Next
            Me.objAppearance.SetInitial_1
        End Sub


        ' Fields
        Private components As IContainer = Nothing
		Private demoScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox
        Private objAppearance As Appearence
		Private panel1 As Gizmox.WebGUI.Forms.Panel
		Private panel2 As Gizmox.WebGUI.Forms.Panel
    End Class
End Namespace


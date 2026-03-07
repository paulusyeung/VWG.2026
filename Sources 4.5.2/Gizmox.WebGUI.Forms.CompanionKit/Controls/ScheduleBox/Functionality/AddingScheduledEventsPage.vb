Imports CompanionKit.Controls.ScheduleBox
Imports Gizmox.WebGUI.Forms
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace CompanionKit.Controls.ScheduleBox.Functionality
    Public Class AddingScheduledEventsPage
        Inherits UserControl
        ' Methods
        Public Sub New()
            Me.InitializeComponent
        End Sub

		Private Sub AddingScheduledEventsPage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.objAppearance.ScheduleBox = Me.demoScheduleBox
			Dim currEvent As ScheduleBoxEvent
			For Each currEvent In Events.GetEvents
				Me.demoScheduleBox.Events.Add(currEvent)
			Next
			Me.objAppearance.SetInitial_4()
		End Sub

		Private Sub AddNewEvent(ByVal sender As Object, ByVal e As EventArgs) Handles objAddNew.Click
			Events.ProcessAddEvent(Me.demoScheduleBox, Nothing, False, Nothing)
		End Sub

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If (disposing AndAlso (Not Me.components Is Nothing)) Then
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub EventDoubleClick(ByVal sender As Object, ByVal e As Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventArgs) Handles demoScheduleBox.EventDoubleClick
			Events.ProcessOpenEvent(Me.demoScheduleBox, e.Event)
		End Sub

        Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddingScheduledEventsPage))
			Me.objAppearance = New CompanionKit.Controls.ScheduleBox.Appearence
			Me.panel1 = New Gizmox.WebGUI.Forms.Panel
			Me.objAddNew = New Gizmox.WebGUI.Forms.Button
			Me.demoScheduleBox = New Gizmox.WebGUI.Forms.ScheduleBox
			Me.panel2 = New Gizmox.WebGUI.Forms.Panel
			Me.panel1.SuspendLayout()
			Me.panel2.SuspendLayout()
			Me.SuspendLayout()
			'
			'objAppearance
			'
			Me.objAppearance.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
			Me.objAppearance.Location = New System.Drawing.Point(0, 0)
			Me.objAppearance.Name = "objAppearance"
			Me.objAppearance.ScheduleBox = Nothing
			Me.objAppearance.Size = New System.Drawing.Size(181, 616)
			Me.objAppearance.TabIndex = 1
			Me.objAppearance.Text = "Appearence"
			'
			'panel1
			'
			Me.panel1.Controls.Add(Me.objAddNew)
			Me.panel1.Controls.Add(Me.objAppearance)
			Me.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(180, 670)
			Me.panel1.TabIndex = 2
			'
			'objAddNew
			'
			Me.objAddNew.AutoSize = True
			Me.objAddNew.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("objAddNew.Image"))
			Me.objAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.objAddNew.Location = New System.Drawing.Point(0, 600)
			Me.objAddNew.Name = "objAddNew"
			Me.objAddNew.Padding = New Gizmox.WebGUI.Forms.Padding(15, 5, 5, 5)
			Me.objAddNew.Size = New System.Drawing.Size(172, 43)
			Me.objAddNew.TabIndex = 2
			Me.objAddNew.Text = "Add new event ..."
			Me.objAddNew.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText
			Me.objAddNew.UseVisualStyleBackColor = True
			'
			'demoScheduleBox
			'
			Me.demoScheduleBox.DisplayMonthHeader = True
			Me.demoScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
			Me.demoScheduleBox.FirstDate = New Date(2010, 5, 31, 11, 29, 51, 227)
			Me.demoScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday
			Me.demoScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock24H
			Me.demoScheduleBox.Location = New System.Drawing.Point(0, 0)
			Me.demoScheduleBox.Name = "demoScheduleBox"
			Me.demoScheduleBox.Size = New System.Drawing.Size(470, 670)
			Me.demoScheduleBox.TabIndex = 0
			Me.demoScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Day
			Me.demoScheduleBox.WorkEndHour = 17
			Me.demoScheduleBox.WorkStartHour = 9
			'
			'panel2
			'
			Me.panel2.Controls.Add(Me.demoScheduleBox)
			Me.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
			Me.panel2.Location = New System.Drawing.Point(180, 0)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(470, 670)
			Me.panel2.TabIndex = 3
			'
			'AddingScheduledEventsPage
			'
			Me.Controls.Add(Me.panel2)
			Me.Controls.Add(Me.panel1)
			Me.Size = New System.Drawing.Size(650, 670)
			Me.Text = "AddingScheduledEventsPage"
			Me.panel1.ResumeLayout(False)
			Me.panel2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub


        ' Fields
        Private components As IContainer = Nothing
		Private WithEvents demoScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox
		Private WithEvents objAddNew As Gizmox.WebGUI.Forms.Button
        Private objAppearance As Appearence
		Private panel1 As Gizmox.WebGUI.Forms.Panel
		Private panel2 As Gizmox.WebGUI.Forms.Panel
    End Class
End Namespace


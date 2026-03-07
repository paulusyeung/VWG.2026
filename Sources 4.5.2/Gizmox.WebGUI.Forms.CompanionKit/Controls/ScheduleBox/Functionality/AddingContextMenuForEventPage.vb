Imports CompanionKit.Controls.ScheduleBox
Imports Gizmox.WebGUI.Forms
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace CompanionKit.Controls.ScheduleBox.Functionality
    Public Class AddingContextMenuForEventPage
        Inherits UserControl

        Public Sub New()
            Me.InitializeComponent
        End Sub

		Private Sub AddingContextMenuForEventPage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			'Prepare menu item for control with an image
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddingContextMenuForEventPage))
			Dim parentMenu As New Gizmox.WebGUI.Forms.ContextMenu
			Dim newItem As New MenuItem("Add new ...")
			newItem.Tag = "new"
			newItem.Icon = resources.GetString("menuNew.Icon")
			parentMenu.MenuItems.Add(newItem)
			Me.objAppearance.ScheduleBox = Me.demoScheduleBox
			Me.objAppearance.ScheduleBox.ContextMenu = parentMenu
			AddHandler Me.demoScheduleBox.MenuClick, New MenuEventHandler(AddressOf Me.EventMenuClick)

			Dim currEvent As ScheduleBoxEvent
			For Each currEvent In Events.GetEvents
				currEvent.ContextMenu = Me.objEventMenu
				Me.demoScheduleBox.Events.Add(currEvent)
			Next
			Me.objAppearance.SetInitial_2()
		End Sub

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If (disposing AndAlso (Not Me.components Is Nothing)) Then
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub EventDoubleClick(ByVal sender As Object, ByVal e As Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventArgs) Handles demoScheduleBox.EventDoubleClick
			ProcessOpenEvent(e.Event)
		End Sub

        Private Sub EventMenuClick(ByVal sender As Object, ByVal objArgs As MenuItemEventArgs)
            Dim menuitem As MenuItem = objArgs.MenuItem
            Dim objEvent As ScheduleBoxEvent = DirectCast(objArgs.Member, ScheduleBoxEvent)
			Dim action As String = menuitem.Tag.ToString
			If (Not action Is Nothing) Then
				If (action = "new") Then
					Events.ProcessAddEvent(Me.demoScheduleBox, Me.objEventMenu, False, Nothing)
				ElseIf (action = "open") Then
					ProcessOpenEvent(objEvent)
				ElseIf (action = "recreate") Then
					Events.ProcessAddEvent(Me.demoScheduleBox, Me.objEventMenu, True, objEvent)
				ElseIf (action = "delete") Then
					Me.demoScheduleBox.Events.Remove(objEvent)
				End If
			End If
		End Sub

		Private Sub ProcessOpenEvent(ByVal objEvent As ScheduleBoxEvent)
			Dim eventForm As New EventForm
			eventForm.TargetEvent = objEvent
			AddHandler eventForm.FormClosed, New Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(AddressOf EditFormClosed)
			eventForm.ShowDialog()
		End Sub

		Private Sub EditFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
			Dim eventForm As EventForm = DirectCast(sender, Gizmox.WebGUI.Forms.Form)
			If eventForm.DialogResult = DialogResult.OK Then
				Me.demoScheduleBox.FirstDate = eventForm.TargetEvent.Start
			End If
		End Sub

		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddingContextMenuForEventPage))
			Me.panel1 = New Gizmox.WebGUI.Forms.Panel
			Me.objAppearance = New CompanionKit.Controls.ScheduleBox.Appearence
			Me.demoScheduleBox = New Gizmox.WebGUI.Forms.ScheduleBox
			Me.panel2 = New Gizmox.WebGUI.Forms.Panel
			Me.objEventMenu = New Gizmox.WebGUI.Forms.ContextMenu
			Me.menuOpen = New Gizmox.WebGUI.Forms.MenuItem
			Me.menuNew = New Gizmox.WebGUI.Forms.MenuItem
			Me.menuDelete = New Gizmox.WebGUI.Forms.MenuItem
			Me.menuRecreate = New Gizmox.WebGUI.Forms.MenuItem
			Me.panel1.SuspendLayout()
			Me.panel2.SuspendLayout()
			Me.SuspendLayout()
			'
			'panel1
			'
			Me.panel1.Controls.Add(Me.objAppearance)
			Me.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(180, 674)
			Me.panel1.TabIndex = 2
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
			'demoScheduleBox
			'
			Me.demoScheduleBox.DisplayMonthHeader = True
			Me.demoScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
			Me.demoScheduleBox.FirstDate = New Date(2010, 5, 31, 11, 29, 51, 227)
			Me.demoScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday
			Me.demoScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock24H
			Me.demoScheduleBox.Location = New System.Drawing.Point(0, 0)
			Me.demoScheduleBox.Name = "demoScheduleBox"
			Me.demoScheduleBox.Size = New System.Drawing.Size(479, 674)
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
			Me.panel2.Size = New System.Drawing.Size(479, 674)
			Me.panel2.TabIndex = 3
			'
			'objEventMenu
			'
			Me.objEventMenu.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.menuOpen, Me.menuNew, Me.menuDelete, Me.menuRecreate})
			'
			'menuOpen
			'
			Me.menuOpen.Icon = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuOpen.Icon"))
			Me.menuOpen.Index = 0
			Me.menuOpen.Tag = "open"
			Me.menuOpen.Text = "Open"
			'
			'menuNew
			'
			Me.menuNew.Icon = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuNew.Icon"))
			Me.menuNew.Index = 1
			Me.menuNew.Tag = "new"
			Me.menuNew.Text = "Add new ..."
			'
			'menuDelete
			'
			Me.menuDelete.Icon = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuDelete.Icon"))
			Me.menuDelete.Index = 2
			Me.menuDelete.Tag = "delete"
			Me.menuDelete.Text = "Delete"
			'
			'menuRecreate
			'
			Me.menuRecreate.Icon = New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("menuRecreate.Icon"))
			Me.menuRecreate.Index = 3
			Me.menuRecreate.Tag = "recreate"
			Me.menuRecreate.Text = "Re-create"
			'
			'AddingContextMenuForEventPage
			'
			Me.Controls.Add(Me.panel2)
			Me.Controls.Add(Me.panel1)
			Me.Size = New System.Drawing.Size(659, 674)
			Me.Text = "AddingContextMenuForEventPage"
			Me.panel1.ResumeLayout(False)
			Me.panel2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		' Fields
		Private components As IContainer = Nothing
		Private WithEvents demoScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox
		Private menuDelete As Gizmox.WebGUI.Forms.MenuItem
		Private menuNew As Gizmox.WebGUI.Forms.MenuItem
		Private menuOpen As Gizmox.WebGUI.Forms.MenuItem
		Private menuRecreate As Gizmox.WebGUI.Forms.MenuItem
		Private objAppearance As Appearence
		Private objEventMenu As Gizmox.WebGUI.Forms.ContextMenu
		Private panel1 As Gizmox.WebGUI.Forms.Panel
		Private panel2 As Gizmox.WebGUI.Forms.Panel
	End Class
End Namespace


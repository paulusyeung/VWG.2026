Imports Gizmox.WebGUI.Forms
Imports System
Imports System.Collections.Generic

Namespace CompanionKit.Controls.ScheduleBox
    Public Class Events
        ' Methods
        Public Shared Function Create(ByVal start As DateTime, ByVal [end] As DateTime, ByVal subject As String, ByVal tag As String) As ScheduleBoxEvent
            Dim objEvent As New ScheduleBoxEvent
            objEvent.Start = start
            objEvent.End = [end]
            objEvent.Subject = subject
            objEvent.Tag = tag
            Return objEvent
        End Function

		Public Shared Function GetEvents() As IEnumerable(Of ScheduleBoxEvent)
			Dim events As New List(Of ScheduleBoxEvent)
			events.Add(Create(New DateTime(2010, 11, &H1C, 8, 15, 0), New DateTime(2010, 11, &H1C, 9, 30, 0), "BI Upgrade " & ChrW(8211) & " A chance to do it right", "In this session we will share the best practices and tips upgrading Microsoft BI platform. Upgrading projects are the best chance to do it right, don't miss it. End to end explanation, planning to implementation and QA. Best practices in SSIS and SSAS. With an experience of many large upgrades projects we will give you the keys for success upgrades."))
			events.Add(Create(New DateTime(2010, 11, &H1C, 10, 30, 0), New DateTime(2010, 11, &H1C, 11, 0, 0), "Developers Tools and Technologies Keynote", "Introduction to the new dev technologies."))
			events.Add(Create(New DateTime(2010, 11, &H1C, &H10, 15, 0), New DateTime(2010, 11, &H1C, &H11, &H19, 0), "Business Intelligence platform", "Presenting Visio services, PerformancePoint Services, Excel Services, PowerPivot and many other great components "))
			events.Add(Create(New DateTime(2010, 11, &H1D, 9, 15, 0), New DateTime(2010, 11, &H1D, 11, &H19, 0), "Parallel Programming in .NET Framework", ".NET 4 include new technologies for enabling parallelism in managed applications."))
			events.Add(Create(New DateTime(2010, 11, &H1D, 12, 15, 0), New DateTime(2010, 11, &H1D, 14, &H19, 0), "Building Your First Application in the Cloud", "This session will introduce tools and technologies for cloud development, scalability and cloud design patterns."))
			events.Add(Create(New DateTime(2010, 11, &H1D, &H10, 15, 0), New DateTime(2010, 11, &H1D, &H11, &H19, 0), "Virtualization scenarios for business critical Applications", "This session covers virtualization scenarios, the customer pain points and how a combination of systems to solves them. "))
			events.Add(Create(New DateTime(2010, 11, 30, 8, 0, 0), New DateTime(2010, 11, 30, 9, 0, 0), "Breakfast", "All included. 3 persons per table."))
			events.Add(Create(New DateTime(2010, 11, 30, 11, 30, 0), New DateTime(2010, 11, 30, 14, 0, 0), "Social Computing at its best", "Social Computing is 2010's new buzz word but how can we effectivly bring the new Web 2.0 world into the enterprise?"))
			events.Add(Create(New DateTime(2010, 11, 30, 14, 30, 0), New DateTime(2010, 11, 30, &H11, 0, 0), "Extending the private cloud partners solutions panel", "This special panel will host our major partners talking about the integration with Private Cloud solutions in the world of hardware and storage."))
			events.Add(Create(New DateTime(2010, 11, 30, &H10, 30, 0), New DateTime(2010, 11, 30, &H11, 30, 0), "Gizmox - Press conference", "Gizmox - the only .NET based vendor to offer instant Client/Server CloudMove - announces a new free downloadable assessment tool."))
			events.Add(Create(New DateTime(2010, 11, &H17, 10, 0, 0), New DateTime(2010, 11, &H19, &H15, 30, 0), "Unplanned free time - [long event crossing the few days]", "Consider to use this free time to schedule other events."))
			events.Add(Create(New DateTime(2010, 11, &H18, 13, 0, 0), New DateTime(2010, 11, &H1A, &H12, 30, 0), "Planned free time - [long event crossing the few days]", "Use this free time to travel with guests"))
			Return events
		End Function

		''' <summary>
		''' Open the form for event adding
		''' </summary>
		Public Shared Sub ProcessAddEvent(ByVal demoScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox, ByVal menu As Gizmox.WebGUI.Forms.ContextMenu, ByVal blnCopy As Boolean, ByVal objEvent As ScheduleBoxEvent)
			Dim newEvent As ScheduleBoxEvent = Nothing
			If (blnCopy AndAlso (Not objEvent Is Nothing)) Then
				newEvent = Events.Create(objEvent.Start, objEvent.End, objEvent.Subject, _
				IIf((Not objEvent.Tag Is Nothing), objEvent.Tag.ToString, ""))
			Else
				newEvent = New ScheduleBoxEvent
				newEvent.Start = DateTime.Now
				newEvent.End = newEvent.Start.AddHours(1)
			End If
			If (Not newEvent Is Nothing) Then
				Dim eventForm As New EventForm
				eventForm.TargetEvent = newEvent
				newEvent.ContextMenu = menu
				eventForm.ControlledScheduleBox = demoScheduleBox
				AddHandler eventForm.FormClosed, New Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(AddressOf AddFormClosed)
				eventForm.ShowDialog()
			End If
		End Sub

		Private Shared Sub AddFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
			Dim eventForm As EventForm = DirectCast(sender, Gizmox.WebGUI.Forms.Form)
			If eventForm.DialogResult = DialogResult.OK Then
				eventForm.ControlledScheduleBox.Events.Add(eventForm.TargetEvent)
				eventForm.ControlledScheduleBox.FirstDate = eventForm.TargetEvent.Start
			End If
		End Sub

		''' <summary>
		''' Open the form for event editing
		''' </summary>
		Public Shared Sub ProcessOpenEvent(ByVal demoScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox, ByVal objEvent As ScheduleBoxEvent)
			Dim eventForm As New EventForm
			eventForm.TargetEvent = objEvent
			eventForm.ControlledScheduleBox = demoScheduleBox
			AddHandler eventForm.FormClosed, New Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(AddressOf EditFormClosed)
			eventForm.ShowDialog()
		End Sub
		Private Shared Sub EditFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
			Dim eventForm As EventForm = DirectCast(sender, Gizmox.WebGUI.Forms.Form)
			If eventForm.DialogResult = DialogResult.OK Then
				eventForm.ControlledScheduleBox.FirstDate = eventForm.TargetEvent.Start
			End If
		End Sub

	End Class
End Namespace


Imports Gizmox.WebGUI.Forms
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace CompanionKit.Controls.ScheduleBox
    Public Class EventForm
		Inherits Gizmox.WebGUI.Forms.Form
        ' Methods
        Public Sub New()
            Me.InitializeComponent
        End Sub

        Private Sub cancelEventButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            MyBase.DialogResult = DialogResult.Cancel
            MyBase.Close
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.components = New Container
			Me.subjectLabel = New Gizmox.WebGUI.Forms.Label
			Me.subjectTextBox = New Gizmox.WebGUI.Forms.TextBox
			Me.startDateLabel = New Gizmox.WebGUI.Forms.Label
			Me.startDateDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker
			Me.endDateDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker
			Me.endDateLabel = New Gizmox.WebGUI.Forms.Label
			Me.okButton = New Gizmox.WebGUI.Forms.Button
			Me.cancelEventButton = New Gizmox.WebGUI.Forms.Button
            Me.tagLabel = New Label
			Me.tagTextBox = New Gizmox.WebGUI.Forms.TextBox
			Me.testButton = New Gizmox.WebGUI.Forms.Button
            Me.errorProvider1 = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            MyBase.SuspendLayout
            Me.subjectLabel.AutoSize = True
            Me.subjectLabel.Location = New Point(20, 30)
            Me.subjectLabel.Name = "subjectLabel"
            Me.subjectLabel.Size = New Size(&H23, 13)
            Me.subjectLabel.TabIndex = 0
            Me.subjectLabel.Text = "Event subject:"
            Me.subjectTextBox.Location = New Point(&H63, &H1A)
            Me.subjectTextBox.Name = "subjectTextBox"
            Me.subjectTextBox.Size = New Size(&H131, 20)
            Me.subjectTextBox.TabIndex = 1
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New Point(20, &H4B)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New Size(&H23, 13)
            Me.startDateLabel.TabIndex = 2
            Me.startDateLabel.Text = "Start  time:"
            Me.startDateDateTimePicker.CalendarFirstDayOfWeek = Day.Default
            Me.startDateDateTimePicker.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt"
            Me.startDateDateTimePicker.Format = DateTimePickerFormat.Custom
            Me.startDateDateTimePicker.Location = New Point(&H63, &H47)
            Me.startDateDateTimePicker.Name = "startDateDateTimePicker"
            Me.startDateDateTimePicker.Size = New Size(&H131, &H15)
            Me.startDateDateTimePicker.TabIndex = 3
            AddHandler Me.startDateDateTimePicker.ValueChanged, New EventHandler(AddressOf Me.startDateDateTimePicker_ValueChanged)
            Me.endDateDateTimePicker.CalendarFirstDayOfWeek = Day.Default
            Me.endDateDateTimePicker.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt"
            Me.endDateDateTimePicker.Format = DateTimePickerFormat.Custom
            Me.endDateDateTimePicker.Location = New Point(&H63, 100)
            Me.endDateDateTimePicker.Name = "endDateDateTimePicker"
            Me.endDateDateTimePicker.Size = New Size(&H131, &H15)
            Me.endDateDateTimePicker.TabIndex = 4
            Me.endDateLabel.AutoSize = True
            Me.endDateLabel.Location = New Point(20, &H68)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New Size(&H23, 13)
            Me.endDateLabel.TabIndex = 5
            Me.endDateLabel.Text = "End time:"
            Me.okButton.Location = New Point(&HFE, &HE4)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New Size(&H4B, &H17)
            Me.okButton.TabIndex = 6
            Me.okButton.Text = "Ok"
            Me.okButton.UseVisualStyleBackColor = True
            AddHandler Me.okButton.Click, New EventHandler(AddressOf Me.okButton_Click)
            Me.cancelEventButton.Location = New Point(&H149, &HE4)
            Me.cancelEventButton.Name = "cancelEventButton"
            Me.cancelEventButton.Size = New Size(&H4B, &H17)
            Me.cancelEventButton.TabIndex = 7
            Me.cancelEventButton.Text = "Cancel"
            Me.cancelEventButton.UseVisualStyleBackColor = True
            AddHandler Me.cancelEventButton.Click, New EventHandler(AddressOf Me.cancelEventButton_Click)
            Me.tagLabel.AutoSize = True
            Me.tagLabel.Location = New Point(20, &H94)
            Me.tagLabel.Name = "tagLabel"
            Me.tagLabel.Size = New Size(&H23, 13)
            Me.tagLabel.TabIndex = 8
            Me.tagLabel.Text = "Details:"
            Me.tagTextBox.Location = New Point(&H63, &H90)
            Me.tagTextBox.Multiline = True
            Me.tagTextBox.Name = "tagTextBox"
            Me.tagTextBox.ScrollBars = ScrollBars.Vertical
            Me.tagTextBox.Size = New Size(&H131, &H44)
            Me.tagTextBox.TabIndex = 9
            Me.testButton.AutoSize = True
            Me.testButton.Location = New Point(&H17, &HE4)
            Me.testButton.Name = "testButton"
            Me.testButton.Size = New Size(&H71, &H17)
            Me.testButton.TabIndex = 6
            Me.testButton.Text = "Fill with a test data"
            Me.testButton.UseVisualStyleBackColor = True
            AddHandler Me.testButton.Click, New EventHandler(AddressOf Me.testButton_Click)
            Me.errorProvider1.BlinkRate = 3
            Me.errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError
            MyBase.AcceptButton = Me.okButton
            Me.BorderStyle = BorderStyle.FixedSingle
            Me.BorderWidth = New BorderWidth(2)
            MyBase.CancelButton = Me.cancelEventButton
            MyBase.Controls.Add(Me.testButton)
            MyBase.Controls.Add(Me.tagTextBox)
            MyBase.Controls.Add(Me.tagLabel)
            MyBase.Controls.Add(Me.cancelEventButton)
            MyBase.Controls.Add(Me.okButton)
            MyBase.Controls.Add(Me.endDateLabel)
            MyBase.Controls.Add(Me.endDateDateTimePicker)
            MyBase.Controls.Add(Me.startDateDateTimePicker)
            MyBase.Controls.Add(Me.startDateLabel)
            MyBase.Controls.Add(Me.subjectTextBox)
            MyBase.Controls.Add(Me.subjectLabel)
            MyBase.FormBorderStyle = FormBorderStyle.None
            MyBase.Size = New Size(&H1BA, &H110)
            MyBase.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Event details"
            MyBase.ResumeLayout(False)
        End Sub

        Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.subjectTextBox.Text.Trim.Length = 0) Then
                Me.errorProvider1.SetError(Me.subjectTextBox, "The subject can't be empty")
            Else
                Me.errorProvider1.SetError(Me.subjectTextBox, "")
                MyBase.DialogResult = DialogResult.OK
                Me.mobjEvent.Subject = Me.SubjectEvent
                Me.mobjEvent.Start = Me.StartTimeEvent
                Me.mobjEvent.End = Me.EndTimeEvent
                Me.mobjEvent.Tag = Me.EventTag

            End If
        End Sub

        Private Sub startDateDateTimePicker_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.endDateDateTimePicker.MinDate = Me.startDateDateTimePicker.Value
        End Sub

        Private Sub testButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.subjectTextBox.Text = "Experimental event subject"
            Me.startDateDateTimePicker.Value = New DateTime(&H7DA, 12, 1, 11, 0, 0)
            Me.endDateDateTimePicker.Value = New DateTime(&H7DA, 12, 1, 12, 0, 0)
            Me.tagTextBox.Text = "An additional event details and description"
        End Sub


        ' Properties
        Public Property EndTimeEvent As DateTime
            Get
                Return Me.endDateDateTimePicker.Value
            End Get
            Set(ByVal value As DateTime)
                Me.endDateDateTimePicker.Value = value
            End Set
        End Property

        Public Property EventTag As String
            Get
                Return Me.tagTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.tagTextBox.Text = value
            End Set
        End Property

        Public Property StartTimeEvent As DateTime
            Get
                Return Me.startDateDateTimePicker.Value
            End Get
            Set(ByVal value As DateTime)
                Me.startDateDateTimePicker.Value = value
            End Set
        End Property

        Public Property SubjectEvent As String
            Get
                Return Me.subjectTextBox.Text
            End Get
            Set(ByVal value As String)
                Me.subjectTextBox.Text = value
            End Set
        End Property

        Public Property TargetEvent As ScheduleBoxEvent
            Get
                Return Me.mobjEvent
            End Get
            Set(ByVal value As ScheduleBoxEvent)
                Me.mobjEvent = value
                Me.SubjectEvent = Me.mobjEvent.Subject
                Me.StartTimeEvent = Me.mobjEvent.Start
                Me.EndTimeEvent = Me.mobjEvent.End
				Me.EventTag = String.Empty
				If Not Me.mobjEvent.Tag Is Nothing Then
					Me.EventTag = Me.mobjEvent.Tag.ToString
				End If
			End Set
        End Property


		Public Property ControlledScheduleBox() As Gizmox.WebGUI.Forms.ScheduleBox
			Get
				Return Me.scheduleboxcontrol
			End Get
			Set(ByVal value As Gizmox.WebGUI.Forms.ScheduleBox)
				Me.scheduleboxcontrol = value
			End Set
		End Property

		' Fields
		Private cancelEventButton As Gizmox.WebGUI.Forms.Button
        Private components As IContainer = Nothing
		Private endDateDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
		Private endDateLabel As Gizmox.WebGUI.Forms.Label
		Private errorProvider1 As Gizmox.WebGUI.Forms.ErrorProvider
		Private mobjEvent As Gizmox.WebGUI.Forms.ScheduleBoxEvent = Nothing
		Private okButton As Gizmox.WebGUI.Forms.Button
		Public startDateDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
		Private startDateLabel As Gizmox.WebGUI.Forms.Label
		Private subjectLabel As Gizmox.WebGUI.Forms.Label
		Private subjectTextBox As Gizmox.WebGUI.Forms.TextBox
		Private tagLabel As Gizmox.WebGUI.Forms.Label
		Private tagTextBox As Gizmox.WebGUI.Forms.TextBox
		Private testButton As Gizmox.WebGUI.Forms.Button
		Private scheduleboxcontrol As Gizmox.WebGUI.Forms.ScheduleBox
    End Class
End Namespace


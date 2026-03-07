Namespace CompanionKit.Concepts.ClientAPI.ScheduleFirstDate

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ScheduleFirstDatePage
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
        ''' <summary>
        ''' Initializes the component.
        ''' </summary>
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
            Me.mobjScheduleBox = New Gizmox.WebGUI.Forms.ScheduleBox()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjButtonBack = New Gizmox.WebGUI.Forms.Button()
            Me.mobjButtonForward = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjScheduleBox
            '
            Me.mobjScheduleBox.ClientId = "schedule"
            Me.mobjScheduleBox.DisplayMonthHeader = False
            Me.mobjScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjScheduleBox.FirstDate = New Date(2013, 8, 7, 17, 44, 43, 983)
            Me.mobjScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday
            Me.mobjScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock12H
            Me.mobjScheduleBox.Location = New System.Drawing.Point(15, 15)
            Me.mobjScheduleBox.Name = "mobjScheduleBox"
            Me.mobjScheduleBox.Size = New System.Drawing.Size(404, 256)
            Me.mobjScheduleBox.TabIndex = 0
            Me.mobjScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Day
            Me.mobjScheduleBox.WorkEndHour = 17
            Me.mobjScheduleBox.WorkStartHour = 9
            '
            'mobjPanel
            '
            Me.mobjPanel.Controls.Add(Me.mobjScheduleBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjPanel.DockPadding.All = 15
            Me.mobjPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjPanel.Size = New System.Drawing.Size(434, 286)
            Me.mobjPanel.TabIndex = 1
            '
            'mobjButtonBack
            '
            Me.mobjButtonBack.ClientId = "btnBack"
            Me.mobjButtonBack.Location = New System.Drawing.Point(15, 307)
            Me.mobjButtonBack.Name = "mobjButtonBack"
            Me.mobjButtonBack.Size = New System.Drawing.Size(60, 23)
            Me.mobjButtonBack.TabIndex = 2
            Me.mobjButtonBack.Text = "<<"
            '
            'mobjButtonForward
            '
            Me.mobjButtonForward.ClientId = "btnForward"
            Me.mobjButtonForward.Location = New System.Drawing.Point(179, 307)
            Me.mobjButtonForward.Name = "mobjButtonForward"
            Me.mobjButtonForward.Size = New System.Drawing.Size(60, 23)
            Me.mobjButtonForward.TabIndex = 3
            Me.mobjButtonForward.Text = ">>"
            '
            'mobjLabel
            '
            Me.mobjLabel.Location = New System.Drawing.Point(75, 302)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(104, 32)
            Me.mobjLabel.TabIndex = 4
            Me.mobjLabel.Text = "First date"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ScheduleFirstDatePage
            '
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjButtonForward)
            Me.Controls.Add(Me.mobjButtonBack)
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(434, 415)
            Me.Text = "ScheduleFirstDatePage"
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjScheduleBox As Gizmox.WebGUI.Forms.ScheduleBox
        Friend WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjButtonBack As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjButtonForward As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label


	End Class

End Namespace
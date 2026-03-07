Namespace CompanionKit.Controls.PropertyGrid.ApplicationScenarios

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ExampleApplicationPage
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
            Me.demoDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker
            Me.optionsContextMenu = New Gizmox.WebGUI.Forms.ContextMenu
            Me.optionsMenuItem = New Gizmox.WebGUI.Forms.MenuItem
            Me.eventSummaryTextBox = New Gizmox.WebGUI.Forms.TextBox
            Me.createEventsButton = New Gizmox.WebGUI.Forms.Button
            Me.eventsListView = New Gizmox.WebGUI.Forms.ListView
            Me.dateEventColumn = New Gizmox.WebGUI.Forms.ColumnHeader
            Me.eventSummaryColumn = New Gizmox.WebGUI.Forms.ColumnHeader
            Me.descriptionlabel = New Gizmox.WebGUI.Forms.Label
            Me.eventSummaryLabel = New Gizmox.WebGUI.Forms.Label
            Me.SuspendLayout()
            '
            'demoDateTimePicker
            '
            Me.demoDateTimePicker.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.[Default]
            Me.demoDateTimePicker.ContextMenu = Me.optionsContextMenu
            Me.demoDateTimePicker.CustomFormat = ""
            Me.demoDateTimePicker.Location = New System.Drawing.Point(39, 29)
            Me.demoDateTimePicker.Name = "demoDateTimePicker"
            Me.demoDateTimePicker.Size = New System.Drawing.Size(200, 21)
            Me.demoDateTimePicker.TabIndex = 0
            '
            'optionsContextMenu
            '
            Me.optionsContextMenu.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.optionsMenuItem})
            '
            'optionsMenuItem
            '
            Me.optionsMenuItem.Index = 0
            Me.optionsMenuItem.Text = "Options..."
            '
            'eventSummaryTextBox
            '
            Me.eventSummaryTextBox.ContextMenu = Me.optionsContextMenu
            Me.eventSummaryTextBox.Location = New System.Drawing.Point(346, 29)
            Me.eventSummaryTextBox.Name = "eventSummaryTextBox"
            Me.eventSummaryTextBox.Size = New System.Drawing.Size(223, 20)
            Me.eventSummaryTextBox.TabIndex = 1
            '
            'createEventsButton
            '
            Me.createEventsButton.ContextMenu = Me.optionsContextMenu
            Me.createEventsButton.Location = New System.Drawing.Point(451, 61)
            Me.createEventsButton.Name = "createEventsButton"
            Me.createEventsButton.Size = New System.Drawing.Size(118, 23)
            Me.createEventsButton.TabIndex = 2
            Me.createEventsButton.Text = "Create event"
            Me.createEventsButton.UseVisualStyleBackColor = True
            '
            'eventsListView
            '
            Me.eventsListView.AutoGenerateColumns = True
            Me.eventsListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.dateEventColumn, Me.eventSummaryColumn})
            Me.eventsListView.ContextMenu = Me.optionsContextMenu
            Me.eventsListView.DataMember = Nothing
            Me.eventsListView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.eventsListView.ForeColor = System.Drawing.Color.Blue
            Me.eventsListView.ItemsPerPage = 20
            Me.eventsListView.Location = New System.Drawing.Point(39, 110)
            Me.eventsListView.Name = "eventsListView"
            Me.eventsListView.ShowItemToolTips = False
            Me.eventsListView.Size = New System.Drawing.Size(530, 185)
            Me.eventsListView.TabIndex = 3
            Me.eventsListView.TotalItems = 1
            '
            'dateEventColumn
            '
            Me.dateEventColumn.ContextMenu = Me.optionsContextMenu
            Me.dateEventColumn.Image = Nothing
            Me.dateEventColumn.Text = "Time of event"
            Me.dateEventColumn.Width = 350
            '
            'eventSummaryColumn
            '
            Me.eventSummaryColumn.ContextMenu = Me.optionsContextMenu
            Me.eventSummaryColumn.Image = Nothing
            Me.eventSummaryColumn.Text = "Event summary"
            Me.eventSummaryColumn.Width = 350
            '
            'descriptionlabel
            '
            Me.descriptionlabel.AutoSize = True
            Me.descriptionlabel.Location = New System.Drawing.Point(39, 91)
            Me.descriptionlabel.Name = "descriptionlabel"
            Me.descriptionlabel.Size = New System.Drawing.Size(38, 13)
            Me.descriptionlabel.TabIndex = 4
            Me.descriptionlabel.Text = "Right click the event to change properties"
            '
            'eventSummaryLabel
            '
            Me.eventSummaryLabel.AutoSize = True
            Me.eventSummaryLabel.Location = New System.Drawing.Point(259, 33)
            Me.eventSummaryLabel.Name = "eventSummaryLabel"
            Me.eventSummaryLabel.Size = New System.Drawing.Size(38, 13)
            Me.eventSummaryLabel.TabIndex = 5
            Me.eventSummaryLabel.Text = "Event summary"
            '
            'ExampleApplicationPage
            '
            Me.ContextMenu = Me.optionsContextMenu
            Me.Controls.Add(Me.eventSummaryLabel)
            Me.Controls.Add(Me.descriptionlabel)
            Me.Controls.Add(Me.eventsListView)
            Me.Controls.Add(Me.createEventsButton)
            Me.Controls.Add(Me.eventSummaryTextBox)
            Me.Controls.Add(Me.demoDateTimePicker)
            Me.Size = New System.Drawing.Size(632, 306)
            Me.Text = "ExampleApplicationPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Friend WithEvents optionsContextMenu As Gizmox.WebGUI.Forms.ContextMenu
        Friend WithEvents eventSummaryTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents createEventsButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents eventsListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents dateEventColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents eventSummaryColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents optionsMenuItem As Gizmox.WebGUI.Forms.MenuItem
        Friend WithEvents descriptionlabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents eventSummaryLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace

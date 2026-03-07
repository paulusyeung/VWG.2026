Namespace CompanionKit.Controls.DateTimePicker.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckedPropertyPage
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
            Me.mobjDemoDateTimePickerLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjDateTimePickerCheckBoxStateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoDateTimePickerLabel
            ' 
            Me.mobjDemoDateTimePickerLabel.AutoSize = True
            Me.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePickerLabel.Location = New System.Drawing.Point(75, 49)
            Me.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel"
            Me.mobjDemoDateTimePickerLabel.Size = New System.Drawing.Size(350, 50)
            Me.mobjDemoDateTimePickerLabel.TabIndex = 0
            Me.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker"
            Me.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDemoDateTimePicker
            ' 
            Me.mobjDemoDateTimePicker.CustomFormat = ""
            Me.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePicker.Location = New System.Drawing.Point(75, 99)
            Me.mobjDemoDateTimePicker.Name = "demoDateTimePicker"
            Me.mobjDemoDateTimePicker.ShowCheckBox = True
            Me.mobjDemoDateTimePicker.Size = New System.Drawing.Size(350, 21)
            Me.mobjDemoDateTimePicker.TabIndex = 1
            ' 
            ' mobjDateTimePickerCheckBoxStateLabel
            ' 
            Me.mobjDateTimePickerCheckBoxStateLabel.AutoSize = True
            Me.mobjDateTimePickerCheckBoxStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDateTimePickerCheckBoxStateLabel.Location = New System.Drawing.Point(75, 149)
            Me.mobjDateTimePickerCheckBoxStateLabel.Name = "dateTimePickerCheckBoxStateLabel"
            Me.mobjDateTimePickerCheckBoxStateLabel.Size = New System.Drawing.Size(350, 50)
            Me.mobjDateTimePickerCheckBoxStateLabel.TabIndex = 2
            Me.mobjDateTimePickerCheckBoxStateLabel.Text = "The DateTimePicker is checked/unchecked now"
            Me.mobjDateTimePickerCheckBoxStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePickerLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDateTimePickerCheckBoxStateLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePicker, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(500, 249)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' CheckedPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.MinimumSize = New System.Drawing.Size(305, 180)
            Me.Size = New System.Drawing.Size(500, 249)
            Me.Text = "CheckedPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoDateTimePickerLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjDemoDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjDateTimePickerCheckBoxStateLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
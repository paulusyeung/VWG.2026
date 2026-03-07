Namespace CompanionKit.Controls.DateTimePicker.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CalendarForeColorPropertyPage
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
            Me.mobjForeColorLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjForeColorComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjDemoDateTimePickerLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjForeColorLabel
            ' 
            Me.mobjForeColorLabel.AutoSize = True
            Me.mobjForeColorLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjForeColorLabel.Location = New System.Drawing.Point(66, 43)
            Me.mobjForeColorLabel.Name = "foreColorLabel"
            Me.mobjForeColorLabel.Size = New System.Drawing.Size(310, 30)
            Me.mobjForeColorLabel.TabIndex = 0
            Me.mobjForeColorLabel.Text = "Calendar foreground color"
            ' 
            ' mobjForeColorComboBox
            ' 
            Me.mobjForeColorComboBox.AllowDrag = False
            Me.mobjForeColorComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjForeColorComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjForeColorComboBox.Location = New System.Drawing.Point(66, 73)
            Me.mobjForeColorComboBox.Name = "foreColorComboBox"
            Me.mobjForeColorComboBox.Size = New System.Drawing.Size(310, 21)
            Me.mobjForeColorComboBox.TabIndex = 1
            ' 
            ' mobjDemoDateTimePickerLabel
            ' 
            Me.mobjDemoDateTimePickerLabel.AutoSize = True
            Me.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePickerLabel.Location = New System.Drawing.Point(66, 123)
            Me.mobjDemoDateTimePickerLabel.Name = "demoDataTimePickerLabel"
            Me.mobjDemoDateTimePickerLabel.Size = New System.Drawing.Size(310, 30)
            Me.mobjDemoDateTimePickerLabel.TabIndex = 2
            Me.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker"
            ' 
            ' mobjDemoDateTimePicker
            ' 
            Me.mobjDemoDateTimePicker.CustomFormat = ""
            Me.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePicker.Location = New System.Drawing.Point(66, 153)
            Me.mobjDemoDateTimePicker.Name = "demoDateTimePicker"
            Me.mobjDemoDateTimePicker.Size = New System.Drawing.Size(310, 21)
            Me.mobjDemoDateTimePicker.TabIndex = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjForeColorLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePicker, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjForeColorComboBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePickerLabel, 1, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(444, 226)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' CalendarForeColorPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.MinimumSize = New System.Drawing.Size(323, 226)
            Me.Size = New System.Drawing.Size(444, 226)
            Me.Text = "CalendarForeColorPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjForeColorLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjForeColorComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjDemoDateTimePickerLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDemoDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
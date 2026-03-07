Namespace CompanionKit.Controls.DateTimePicker.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FormatPropertyPage
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
            Me.mobjDateFormatLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDateFormatComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjDemoDateTimePickerLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDateFormatLabel
            ' 
            Me.mobjDateFormatLabel.AutoSize = True
            Me.mobjDateFormatLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDateFormatLabel.Location = New System.Drawing.Point(78, 28)
            Me.mobjDateFormatLabel.Name = "dateFormatLabel"
            Me.mobjDateFormatLabel.Size = New System.Drawing.Size(368, 50)
            Me.mobjDateFormatLabel.TabIndex = 0
            Me.mobjDateFormatLabel.Text = "Select the date format to apply:"
            Me.mobjDateFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDateFormatComboBox
            ' 
            Me.mobjDateFormatComboBox.AllowDrag = False
            Me.mobjDateFormatComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjDateFormatComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDateFormatComboBox.Location = New System.Drawing.Point(78, 78)
            Me.mobjDateFormatComboBox.Name = "dateFormatComboBox"
            Me.mobjDateFormatComboBox.Size = New System.Drawing.Size(368, 21)
            Me.mobjDateFormatComboBox.TabIndex = 1
            ' 
            ' mobjDemoDateTimePickerLabel
            ' 
            Me.mobjDemoDateTimePickerLabel.AutoSize = True
            Me.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePickerLabel.Location = New System.Drawing.Point(78, 128)
            Me.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel"
            Me.mobjDemoDateTimePickerLabel.Size = New System.Drawing.Size(368, 50)
            Me.mobjDemoDateTimePickerLabel.TabIndex = 2
            Me.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker"
            Me.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDemoDateTimePicker
            ' 
            Me.mobjDemoDateTimePicker.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt"
            Me.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePicker.Location = New System.Drawing.Point(78, 178)
            Me.mobjDemoDateTimePicker.Name = "demoDateTimePicker"
            Me.mobjDemoDateTimePicker.Size = New System.Drawing.Size(368, 21)
            Me.mobjDemoDateTimePicker.TabIndex = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDateFormatLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePicker, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDateFormatComboBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePickerLabel, 1, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(526, 236)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' FormatPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.MinimumSize = New System.Drawing.Size(339, 236)
            Me.Size = New System.Drawing.Size(526, 236)
            Me.Text = "FormatPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDateFormatLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjDateFormatComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjDemoDateTimePickerLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDemoDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
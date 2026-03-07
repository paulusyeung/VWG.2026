Namespace CompanionKit.Controls.DateTimePicker.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MaxDatePropertyPage
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
            Me.mobjMaxDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjDemoDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjMaxDateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoDateTimePickerLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjMaxDateTimePicker
            ' 
            Me.mobjMaxDateTimePicker.CustomFormat = ""
            Me.mobjMaxDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaxDateTimePicker.Location = New System.Drawing.Point(68, 75)
            Me.mobjMaxDateTimePicker.Name = "maxDateTimePicker"
            Me.mobjMaxDateTimePicker.Size = New System.Drawing.Size(321, 21)
            Me.mobjMaxDateTimePicker.TabIndex = 0
            ' 
            ' mobjDemoDateTimePicker
            ' 
            Me.mobjDemoDateTimePicker.CustomFormat = ""
            Me.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePicker.Location = New System.Drawing.Point(68, 175)
            Me.mobjDemoDateTimePicker.Name = "demoDateTimePicker"
            Me.mobjDemoDateTimePicker.Size = New System.Drawing.Size(321, 21)
            Me.mobjDemoDateTimePicker.TabIndex = 2
            ' 
            ' mobjMaxDateLabel
            ' 
            Me.mobjMaxDateLabel.AutoSize = True
            Me.mobjMaxDateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaxDateLabel.Location = New System.Drawing.Point(68, 25)
            Me.mobjMaxDateLabel.Name = "maxDatelabel"
            Me.mobjMaxDateLabel.Size = New System.Drawing.Size(321, 50)
            Me.mobjMaxDateLabel.TabIndex = 3
            Me.mobjMaxDateLabel.Text = "Maximum date"
            Me.mobjMaxDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDemoDateTimePickerLabel
            ' 
            Me.mobjDemoDateTimePickerLabel.AutoSize = True
            Me.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePickerLabel.Location = New System.Drawing.Point(68, 125)
            Me.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel"
            Me.mobjDemoDateTimePickerLabel.Size = New System.Drawing.Size(321, 50)
            Me.mobjDemoDateTimePickerLabel.TabIndex = 5
            Me.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker"
            Me.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxDateLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePicker, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePickerLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxDateTimePicker, 1, 2)
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(459, 230)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' MaxDatePropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.MinimumSize = New System.Drawing.Size(330, 230)
            Me.Size = New System.Drawing.Size(459, 230)
            Me.Text = "MaxDatePropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjMaxDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjDemoDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjMaxDateLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDemoDateTimePickerLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace
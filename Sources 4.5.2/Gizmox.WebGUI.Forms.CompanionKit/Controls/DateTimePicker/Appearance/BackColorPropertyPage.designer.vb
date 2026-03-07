Namespace CompanionKit.Controls.DateTimePicker.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BackColorPropertyPage
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
            Me.mobjDemoDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjBackColorLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjBackColorComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjDemoDateTimePickerLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjDemoDateTimePicker
            '
            Me.mobjDemoDateTimePicker.CustomFormat = ""
            Me.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePicker.Location = New System.Drawing.Point(63, 183)
            Me.mobjDemoDateTimePicker.Name = "mobjDemoDateTimePicker"
            Me.mobjDemoDateTimePicker.Size = New System.Drawing.Size(294, 21)
            Me.mobjDemoDateTimePicker.TabIndex = 0
            '
            'mobjBackColorLabel
            '
            Me.mobjBackColorLabel.AutoSize = True
            Me.mobjBackColorLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBackColorLabel.Location = New System.Drawing.Point(63, 33)
            Me.mobjBackColorLabel.Name = "mobjBackColorLabel"
            Me.mobjBackColorLabel.Size = New System.Drawing.Size(294, 50)
            Me.mobjBackColorLabel.TabIndex = 1
            Me.mobjBackColorLabel.Text = "Background color"
            Me.mobjBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'mobjBackColorComboBox
            '
            Me.mobjBackColorComboBox.AllowDrag = False
            Me.mobjBackColorComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjBackColorComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBackColorComboBox.Location = New System.Drawing.Point(63, 83)
            Me.mobjBackColorComboBox.Name = "mobjBackColorComboBox"
            Me.mobjBackColorComboBox.Size = New System.Drawing.Size(294, 21)
            Me.mobjBackColorComboBox.TabIndex = 2
            '
            'mobjDemoDateTimePickerLabel
            '
            Me.mobjDemoDateTimePickerLabel.AutoSize = True
            Me.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePickerLabel.Location = New System.Drawing.Point(63, 133)
            Me.mobjDemoDateTimePickerLabel.Name = "mobjDemoDateTimePickerLabel"
            Me.mobjDemoDateTimePickerLabel.Size = New System.Drawing.Size(294, 50)
            Me.mobjDemoDateTimePickerLabel.TabIndex = 3
            Me.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker"
            Me.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'mobjLayoutPanel
            '
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBackColorLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePicker, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePickerLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBackColorComboBox, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(420, 246)
            Me.mobjLayoutPanel.TabIndex = 4
            '
            'BackColorPropertyPage
            '
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.MinimumSize = New System.Drawing.Size(353, 246)
            Me.Size = New System.Drawing.Size(420, 246)
            Me.Text = "BackColorPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjBackColorLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjBackColorComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjDemoDateTimePickerLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
Namespace CompanionKit.Controls.DateTimePicker.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ShowCheckBoxPropertyPage
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
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjDemoDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjDemoDateTimePickerLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjAllowCheckBoxForDateTimePickerCheckBox
            ' 
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.AutoSize = True
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.Location = New System.Drawing.Point(76, 30)
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.Name = "allowCheckBoxForDateTimePickerCheckBox"
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.Size = New System.Drawing.Size(359, 40)
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.TabIndex = 0
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.Text = "Enable CheckBox"
            Me.mobjAllowCheckBoxForDateTimePickerCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjDemoDateTimePicker
            ' 
            Me.mobjDemoDateTimePicker.CustomFormat = ""
            Me.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePicker.Location = New System.Drawing.Point(76, 140)
            Me.mobjDemoDateTimePicker.Name = "demoDateTimePicker"
            Me.mobjDemoDateTimePicker.Size = New System.Drawing.Size(359, 21)
            Me.mobjDemoDateTimePicker.TabIndex = 1
            ' 
            ' mobjDemoDateTimePickerLabel
            ' 
            Me.mobjDemoDateTimePickerLabel.AutoSize = True
            Me.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoDateTimePickerLabel.Location = New System.Drawing.Point(76, 90)
            Me.mobjDemoDateTimePickerLabel.Name = "demoDateTimePickerLabel"
            Me.mobjDemoDateTimePickerLabel.Size = New System.Drawing.Size(359, 50)
            Me.mobjDemoDateTimePickerLabel.TabIndex = 2
            Me.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker"
            Me.mobjDemoDateTimePickerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAllowCheckBoxForDateTimePickerCheckBox, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePicker, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoDateTimePickerLabel, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(513, 200)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' ShowCheckBoxPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.MinimumSize = New System.Drawing.Size(340, 200)
            Me.Size = New System.Drawing.Size(513, 200)
            Me.Text = "ShowCheckBoxPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjAllowCheckBoxForDateTimePickerCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjDemoDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private mobjDemoDateTimePickerLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
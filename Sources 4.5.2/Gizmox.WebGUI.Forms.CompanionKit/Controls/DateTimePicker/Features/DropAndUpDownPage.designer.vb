Namespace CompanionKit.Controls.DateTimePicker.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DropAndUpDownPage
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
            Me.mobjDTPLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDateTimePicker = New Gizmox.WebGUI.Forms.DateTimePicker()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDTPLabel
            ' 
            Me.mobjDTPLabel.AutoSize = True
            Me.mobjDTPLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDTPLabel.Location = New System.Drawing.Point(65, 134)
            Me.mobjDTPLabel.Name = "objDTPLabel"
            Me.mobjDTPLabel.Size = New System.Drawing.Size(307, 50)
            Me.mobjDTPLabel.TabIndex = 0
            Me.mobjDTPLabel.Text = "DateTimePicker:"
            Me.mobjDTPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjComboLabel
            ' 
            Me.mobjComboLabel.AutoSize = True
            Me.mobjComboLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboLabel.Location = New System.Drawing.Point(65, 34)
            Me.mobjComboLabel.Name = "objComboLabel"
            Me.mobjComboLabel.Size = New System.Drawing.Size(307, 50)
            Me.mobjComboLabel.TabIndex = 1
            Me.mobjComboLabel.Text = "DateTimePicker's buttons structure:"
            Me.mobjComboLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDateTimePicker
            ' 
            Me.mobjDateTimePicker.CustomFormat = ""
            Me.mobjDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDateTimePicker.Location = New System.Drawing.Point(65, 184)
            Me.mobjDateTimePicker.Name = "objDateTimePicker"
            Me.mobjDateTimePicker.Size = New System.Drawing.Size(307, 21)
            Me.mobjDateTimePicker.TabIndex = 2
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"DropDown", "UpDown", "Both"})
            Me.mobjComboBox.Location = New System.Drawing.Point(65, 84)
            Me.mobjComboBox.Name = "objComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(307, 21)
            Me.mobjComboBox.TabIndex = 3
            Me.mobjComboBox.Text = "DropDown"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDateTimePicker, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDTPLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 2)
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(439, 249)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' DropAndUpDownPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(439, 249)
            Me.Text = "DropAndUpDownPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDTPLabel As Gizmox.WebGUI.Forms.Label
        Private mobjComboLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDateTimePicker As Gizmox.WebGUI.Forms.DateTimePicker
        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace
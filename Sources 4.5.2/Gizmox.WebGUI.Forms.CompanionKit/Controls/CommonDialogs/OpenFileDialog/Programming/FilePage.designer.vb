Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FilePage
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
            Me.mobjFileNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjFileNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjFileSizeTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjFileSizeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjOrigFileNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjOrigFileNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjFileNameLabel
            ' 
            Me.mobjFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFileNameLabel.Location = New System.Drawing.Point(93, 83)
            Me.mobjFileNameLabel.Name = "mobjFileNameLabel"
            Me.mobjFileNameLabel.Size = New System.Drawing.Size(248, 50)
            Me.mobjFileNameLabel.TabIndex = 0
            Me.mobjFileNameLabel.Text = "Selected file name"
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjOpenFileDialogButton, 2)
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(93, 213)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(434, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 1
            Me.mobjOpenFileDialogButton.Text = "Open selection file dialog"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjFileNameTextBox
            ' 
            Me.mobjFileNameTextBox.AllowDrag = False
            Me.mobjFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFileNameTextBox.Location = New System.Drawing.Point(344, 86)
            Me.mobjFileNameTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjFileNameTextBox.Name = "mobjFileNameTextBox"
            Me.mobjFileNameTextBox.[ReadOnly] = True
            Me.mobjFileNameTextBox.Size = New System.Drawing.Size(180, 30)
            Me.mobjFileNameTextBox.TabIndex = 2
            ' 
            ' mobjFileSizeTextBox
            ' 
            Me.mobjFileSizeTextBox.AllowDrag = False
            Me.mobjFileSizeTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFileSizeTextBox.Location = New System.Drawing.Point(344, 146)
            Me.mobjFileSizeTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjFileSizeTextBox.Name = "mobjFileSizeTextBox"
            Me.mobjFileSizeTextBox.[ReadOnly] = True
            Me.mobjFileSizeTextBox.Size = New System.Drawing.Size(180, 30)
            Me.mobjFileSizeTextBox.TabIndex = 4
            ' 
            ' mobjFileSizeLabel
            ' 
            Me.mobjFileSizeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFileSizeLabel.Location = New System.Drawing.Point(93, 143)
            Me.mobjFileSizeLabel.Name = "mobjFileSizeLabel"
            Me.mobjFileSizeLabel.Size = New System.Drawing.Size(248, 50)
            Me.mobjFileSizeLabel.TabIndex = 6
            Me.mobjFileSizeLabel.Text = "Selected file size"
            ' 
            ' mobjOrigFileNameLabel
            ' 
            Me.mobjOrigFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOrigFileNameLabel.Location = New System.Drawing.Point(93, 23)
            Me.mobjOrigFileNameLabel.Name = "mobjOrigFileNameLabel"
            Me.mobjOrigFileNameLabel.Size = New System.Drawing.Size(248, 50)
            Me.mobjOrigFileNameLabel.TabIndex = 7
            Me.mobjOrigFileNameLabel.Text = "Original file name"
            ' 
            ' mobjOrigFileNameTextBox
            ' 
            Me.mobjOrigFileNameTextBox.AllowDrag = False
            Me.mobjOrigFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOrigFileNameTextBox.Location = New System.Drawing.Point(344, 26)
            Me.mobjOrigFileNameTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjOrigFileNameTextBox.Name = "mobjOrigFileNameTextBox"
            Me.mobjOrigFileNameTextBox.Size = New System.Drawing.Size(180, 30)
            Me.mobjOrigFileNameTextBox.TabIndex = 8
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOrigFileNameTextBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileSizeLabel, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOrigFileNameLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileSizeTextBox, 2, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileNameLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileNameTextBox, 2, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 9
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(622, 287)
            Me.mobjLayoutPanel.TabIndex = 9
            ' 
            ' FilePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Location = New System.Drawing.Point(0, -63)
            Me.Size = New System.Drawing.Size(622, 287)
            Me.Text = "FilePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjFileNameLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjFileNameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjFileSizeTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjFileSizeLabel As Gizmox.WebGUI.Forms.Label
        Private mobjOrigFileNameLabel As Gizmox.WebGUI.Forms.Label
        Private mobjOrigFileNameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace

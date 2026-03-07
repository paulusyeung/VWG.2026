Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FileOkPage
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
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjFileNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFileNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjFileSizeTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjFileSizeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjOpenFileDialogButton, 2)
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(106, 161)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(494, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 0
            Me.mobjOpenFileDialogButton.Text = "Open selection file dialog with Visual WebGui Upload Dialog"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjFileNameLabel
            ' 
            Me.mobjFileNameLabel.AllowDrop = True
            Me.mobjFileNameLabel.AutoSize = True
            Me.mobjFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFileNameLabel.Location = New System.Drawing.Point(106, 21)
            Me.mobjFileNameLabel.Name = "mobjFileNameLabel"
            Me.mobjFileNameLabel.Size = New System.Drawing.Size(282, 50)
            Me.mobjFileNameLabel.TabIndex = 1
            Me.mobjFileNameLabel.Text = "Selected file name"
            ' 
            ' mobjFileNameTextBox
            ' 
            Me.mobjFileNameTextBox.AllowDrag = False
            Me.mobjFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFileNameTextBox.Location = New System.Drawing.Point(391, 24)
            Me.mobjFileNameTextBox.Name = "mobjFileNameTextBox"
            Me.mobjFileNameTextBox.[ReadOnly] = True
            Me.mobjFileNameTextBox.Size = New System.Drawing.Size(206, 30)
            Me.mobjFileNameTextBox.TabIndex = 2
            ' 
            ' mobjFileSizeTextBox
            ' 
            Me.mobjFileSizeTextBox.AllowDrag = False
            Me.mobjFileSizeTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFileSizeTextBox.Location = New System.Drawing.Point(391, 94)
            Me.mobjFileSizeTextBox.Name = "mobjFileSizeTextBox"
            Me.mobjFileSizeTextBox.[ReadOnly] = True
            Me.mobjFileSizeTextBox.Size = New System.Drawing.Size(206, 30)
            Me.mobjFileSizeTextBox.TabIndex = 4
            ' 
            ' mobjFileSizeLabel
            ' 
            Me.mobjFileSizeLabel.AutoSize = True
            Me.mobjFileSizeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFileSizeLabel.Location = New System.Drawing.Point(106, 91)
            Me.mobjFileSizeLabel.Name = "mobjFileSizeLabel"
            Me.mobjFileSizeLabel.Size = New System.Drawing.Size(282, 50)
            Me.mobjFileSizeLabel.TabIndex = 6
            Me.mobjFileSizeLabel.Text = "Selected file size"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileNameTextBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileSizeLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileNameLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFileSizeTextBox, 2, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(707, 232)
            Me.mobjLayoutPanel.TabIndex = 7
            ' 
            ' FileOkPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(707, 232)
            Me.Text = "FileOkPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private mobjFileNameLabel As Gizmox.WebGUI.Forms.Label
        Private mobjFileNameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjFileSizeTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjFileSizeLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

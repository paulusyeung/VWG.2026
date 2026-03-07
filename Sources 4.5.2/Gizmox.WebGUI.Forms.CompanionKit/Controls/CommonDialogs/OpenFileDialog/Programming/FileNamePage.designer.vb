Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FileNamePage
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
            Me.mobjDemoOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjSelectedFileNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSelectedFileTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjOrigFileNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjOrigFileNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjSelectedFileNameLabel
            ' 
            Me.mobjSelectedFileNameLabel.AutoSize = True
            Me.mobjSelectedFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSelectedFileNameLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSelectedFileNameLabel.Name = "mobjSelectedFileNameLabel"
            Me.mobjSelectedFileNameLabel.Size = New System.Drawing.Size(443, 34)
            Me.mobjSelectedFileNameLabel.TabIndex = 0
            Me.mobjSelectedFileNameLabel.Text = "Temporary file name:"
            ' 
            ' mobjSelectedFileTextBox
            ' 
            Me.mobjSelectedFileTextBox.AllowDrag = False
            Me.mobjSelectedFileTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjSelectedFileTextBox.Location = New System.Drawing.Point(0, 40)
            Me.mobjSelectedFileTextBox.Name = "mobjSelectedFileTextBox"
            Me.mobjSelectedFileTextBox.[ReadOnly] = True
            Me.mobjSelectedFileTextBox.Size = New System.Drawing.Size(443, 30)
            Me.mobjSelectedFileTextBox.TabIndex = 1
            Me.mobjSelectedFileTextBox.Text = "You haven't selected file."
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(95, 181)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(443, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 2
            Me.mobjOpenFileDialogButton.Text = "Open selection file dialog"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjOrigFileNameLabel
            ' 
            Me.mobjOrigFileNameLabel.AutoSize = True
            Me.mobjOrigFileNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjOrigFileNameLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjOrigFileNameLabel.Name = "mobjOrigFileNameLabel"
            Me.mobjOrigFileNameLabel.Size = New System.Drawing.Size(443, 14)
            Me.mobjOrigFileNameLabel.TabIndex = 3
            Me.mobjOrigFileNameLabel.Text = "Original selected file name:"
            ' 
            ' mobjOrigFileNameTextBox
            ' 
            Me.mobjOrigFileNameTextBox.AllowDrag = False
            Me.mobjOrigFileNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjOrigFileNameTextBox.Location = New System.Drawing.Point(0, 40)
            Me.mobjOrigFileNameTextBox.Name = "mobjOrigFileNameTextBox"
            Me.mobjOrigFileNameTextBox.Size = New System.Drawing.Size(443, 30)
            Me.mobjOrigFileNameTextBox.TabIndex = 4
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBottomPanel, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(634, 253)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjSelectedFileNameLabel)
            Me.mobjTopPanel.Controls.Add(Me.mobjSelectedFileTextBox)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(95, 21)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(443, 60)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.Controls.Add(Me.mobjOrigFileNameLabel)
            Me.mobjBottomPanel.Controls.Add(Me.mobjOrigFileNameTextBox)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.Location = New System.Drawing.Point(95, 101)
            Me.mobjBottomPanel.Name = "mobjBottomPanel"
            Me.mobjBottomPanel.Size = New System.Drawing.Size(443, 60)
            Me.mobjBottomPanel.TabIndex = 0
            ' 
            ' FileNamePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(634, 253)
            Me.Text = "FileNamePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjSelectedFileNameLabel As Gizmox.WebGUI.Forms.Label
        Private mobjSelectedFileTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private mobjOrigFileNameLabel As Gizmox.WebGUI.Forms.Label
        Private mobjOrigFileNameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

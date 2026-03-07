Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class InitialDirectoryPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(InitialDirectoryPage))
            Me.mobjInitialDirectoryLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInitialDirectoryTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjInitialDirectoryFolderBrowserDialog = New Gizmox.WebGUI.Forms.FolderBrowserDialog()
            Me.mobjDemoOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjInitialDirectoryButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjInitialDirectoryLabel
            ' 
            Me.mobjInitialDirectoryLabel.AutoSize = True
            Me.mobjInitialDirectoryLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInitialDirectoryLabel.Location = New System.Drawing.Point(75, 39)
            Me.mobjInitialDirectoryLabel.Name = "mobjInitialDirectoryLabel"
            Me.mobjInitialDirectoryLabel.Size = New System.Drawing.Size(201, 50)
            Me.mobjInitialDirectoryLabel.TabIndex = 0
            Me.mobjInitialDirectoryLabel.Text = "Initial directory"
            ' 
            ' mobjInitialDirectoryTextBox
            ' 
            Me.mobjInitialDirectoryTextBox.AllowDrag = False
            Me.mobjInitialDirectoryTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInitialDirectoryTextBox.Location = New System.Drawing.Point(279, 42)
            Me.mobjInitialDirectoryTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjInitialDirectoryTextBox.Name = "mobjInitialDirectoryTextBox"
            Me.mobjInitialDirectoryTextBox.Size = New System.Drawing.Size(145, 30)
            Me.mobjInitialDirectoryTextBox.TabIndex = 1
            ' 
            ' mobjInitialDirectoryFolderBrowserDialog
            ' 
            Me.mobjInitialDirectoryFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyDocuments
            ' 
            ' mobjInitialDirectoryButton
            ' 
            Me.mobjInitialDirectoryButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInitialDirectoryButton.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjInitialDirectoryButton.Image"))
            Me.mobjInitialDirectoryButton.Location = New System.Drawing.Point(437, 39)
            Me.mobjInitialDirectoryButton.MaximumSize = New System.Drawing.Size(30, 30)
            Me.mobjInitialDirectoryButton.Name = "mobjInitialDirectoryButton"
            Me.mobjInitialDirectoryButton.Size = New System.Drawing.Size(30, 30)
            Me.mobjInitialDirectoryButton.TabIndex = 2
            Me.mobjInitialDirectoryButton.UseVisualStyleBackColor = True
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjOpenFileDialogButton, 4)
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(75, 109)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(392, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 3
            Me.mobjOpenFileDialogButton.Text = "Open OpenFileDialog with specified initial directory"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 6
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInitialDirectoryButton, 4, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInitialDirectoryTextBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInitialDirectoryLabel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(544, 199)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' InitialDirectoryPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(544, 199)
            Me.Text = "InitialDirectoryPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjInitialDirectoryLabel As Gizmox.WebGUI.Forms.Label
        Private mobjInitialDirectoryTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjInitialDirectoryFolderBrowserDialog As Gizmox.WebGUI.Forms.FolderBrowserDialog
        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private WithEvents mobjInitialDirectoryButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

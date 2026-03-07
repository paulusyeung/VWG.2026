Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FileNamesPage
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
            Me.mobjSelectedFilesLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjSelectedFileNamesListView = New Gizmox.WebGUI.Forms.ListView()
            Me.mobjTempFileNameColumn = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjOrigFileNameColumn = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjSelectedFilesLabel
            ' 
            Me.mobjSelectedFilesLabel.AutoSize = True
            Me.mobjSelectedFilesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectedFilesLabel.Location = New System.Drawing.Point(94, 13)
            Me.mobjSelectedFilesLabel.Name = "mobjSelectedFilesLabel"
            Me.mobjSelectedFilesLabel.Size = New System.Drawing.Size(442, 50)
            Me.mobjSelectedFilesLabel.TabIndex = 0
            Me.mobjSelectedFilesLabel.Text = "Selected file names"
            Me.mobjSelectedFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(94, 197)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(442, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 2
            Me.mobjOpenFileDialogButton.Text = "Open selection file dialog"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjDemoOpenFileDialog
            ' 
            Me.mobjDemoOpenFileDialog.Multiselect = True
            ' 
            ' mobjSelectedFileNamesListView
            ' 
            Me.mobjSelectedFileNamesListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.mobjTempFileNameColumn, Me.mobjOrigFileNameColumn})
            Me.mobjSelectedFileNamesListView.DataMember = Nothing
            Me.mobjSelectedFileNamesListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectedFileNamesListView.Location = New System.Drawing.Point(94, 73)
            Me.mobjSelectedFileNamesListView.Name = "mobjSelectedFileNamesListView"
            Me.mobjSelectedFileNamesListView.Size = New System.Drawing.Size(442, 104)
            Me.mobjSelectedFileNamesListView.TabIndex = 3
            Me.mobjSelectedFileNamesListView.TotalItems = 1
            ' 
            ' mobjTempFileNameColumn
            ' 
            Me.mobjTempFileNameColumn.Text = "Temporary file name"
            Me.mobjTempFileNameColumn.Width = 212
            ' 
            ' mobjOrigFileNameColumn
            ' 
            Me.mobjOrigFileNameColumn.Text = "Original file name"
            Me.mobjOrigFileNameColumn.Width = 224
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSelectedFilesLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSelectedFileNamesListView, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(632, 261)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' FileNamesPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(632, 261)
            Me.Text = "FileNamesPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjSelectedFilesLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjSelectedFileNamesListView As Gizmox.WebGUI.Forms.ListView
        Private mobjTempFileNameColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Private mobjOrigFileNameColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

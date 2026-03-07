Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FilesPage
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
            Me.mobjSelectedFilesListView = New Gizmox.WebGUI.Forms.ListView()
            Me.mobjFileNameColumn = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjFileSizeColumn = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjSelectedFilesLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjSelectedFilesListView
            ' 
            Me.mobjSelectedFilesListView.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.ColumnContent
            Me.mobjSelectedFilesListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.mobjFileNameColumn, Me.mobjFileSizeColumn})
            Me.mobjSelectedFilesListView.DataMember = Nothing
            Me.mobjSelectedFilesListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectedFilesListView.Location = New System.Drawing.Point(81, 78)
            Me.mobjSelectedFilesListView.Name = "mobjSelectedFilesListView"
            Me.mobjSelectedFilesListView.Size = New System.Drawing.Size(380, 84)
            Me.mobjSelectedFilesListView.TabIndex = 0
            Me.mobjSelectedFilesListView.TotalItems = 1
            ' 
            ' mobjFileNameColumn
            ' 
            Me.mobjFileNameColumn.Text = "File Name"
            Me.mobjFileNameColumn.Width = 179
            ' 
            ' mobjFileSizeColumn
            ' 
            Me.mobjFileSizeColumn.Text = "File Size"
            Me.mobjFileSizeColumn.Width = 190
            ' 
            ' mobjSelectedFilesLabel
            ' 
            Me.mobjSelectedFilesLabel.AutoSize = True
            Me.mobjSelectedFilesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectedFilesLabel.Location = New System.Drawing.Point(81, 18)
            Me.mobjSelectedFilesLabel.Name = "mobjSelectedFilesLabel"
            Me.mobjSelectedFilesLabel.Size = New System.Drawing.Size(380, 50)
            Me.mobjSelectedFilesLabel.TabIndex = 1
            Me.mobjSelectedFilesLabel.Text = "Selection files' name and size"
            Me.mobjSelectedFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(81, 182)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(380, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 2
            Me.mobjOpenFileDialogButton.Text = "Open selection file dialog"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjDemoOpenFileDialog
            ' 
            Me.mobjDemoOpenFileDialog.Multiselect = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSelectedFilesLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSelectedFilesListView, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(544, 250)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' FilesPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(544, 250)
            Me.Text = "FilesPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjSelectedFilesListView As Gizmox.WebGUI.Forms.ListView
        Private mobjFileNameColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Private mobjFileSizeColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Private mobjSelectedFilesLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

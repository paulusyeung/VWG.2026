Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TitlePage
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
            Me.mobjTitleFileDialogLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTitleFileDialogTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoOpenFileDialog
            ' 
            Me.mobjDemoOpenFileDialog.Title = "Open File Dialog"
            ' 
            ' mobjTitleFileDialogLabel
            ' 
            Me.mobjTitleFileDialogLabel.AutoSize = True
            Me.mobjTitleFileDialogLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTitleFileDialogLabel.Location = New System.Drawing.Point(88, 32)
            Me.mobjTitleFileDialogLabel.Name = "mobjTitleFileDialogLabel"
            Me.mobjTitleFileDialogLabel.Size = New System.Drawing.Size(237, 50)
            Me.mobjTitleFileDialogLabel.TabIndex = 0
            Me.mobjTitleFileDialogLabel.Text = "Title of the open file dialog"
            ' 
            ' mobjTitleFileDialogTextBox
            ' 
            Me.mobjTitleFileDialogTextBox.AllowDrag = False
            Me.mobjTitleFileDialogTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTitleFileDialogTextBox.Location = New System.Drawing.Point(328, 35)
            Me.mobjTitleFileDialogTextBox.Name = "mobjTitleFileDialogTextBox"
            Me.mobjTitleFileDialogTextBox.Size = New System.Drawing.Size(171, 30)
            Me.mobjTitleFileDialogTextBox.TabIndex = 1
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjOpenFileDialogButton, 2)
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(88, 102)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(414, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 2
            Me.mobjOpenFileDialogButton.Text = "Open file dialog with custom title"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTitleFileDialogLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTitleFileDialogTextBox, 2, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(593, 185)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' TitlePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(593, 185)
            Me.Text = "TitlePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjTitleFileDialogLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTitleFileDialogTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MaxFileSizePage
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
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaximumFileSizeTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(82, 27)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(221, 50)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Maximum file size (KB)"
            ' 
            ' mobjMaximumFileSizeTextBox
            ' 
            Me.mobjMaximumFileSizeTextBox.AllowDrag = False
            Me.mobjMaximumFileSizeTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaximumFileSizeTextBox.Location = New System.Drawing.Point(306, 30)
            Me.mobjMaximumFileSizeTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjMaximumFileSizeTextBox.Name = "mobjMaximumFileSizeTextBox"
            Me.mobjMaximumFileSizeTextBox.Size = New System.Drawing.Size(159, 30)
            Me.mobjMaximumFileSizeTextBox.TabIndex = 1
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjOpenFileDialogButton, 2)
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(82, 97)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(386, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 2
            Me.mobjOpenFileDialogButton.Text = "Open File Dialog with limited by maximum file size"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaximumFileSizeTextBox, 2, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(553, 174)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' MaxFileSizePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(553, 174)
            Me.Text = "MaxFileSizePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMaximumFileSizeTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

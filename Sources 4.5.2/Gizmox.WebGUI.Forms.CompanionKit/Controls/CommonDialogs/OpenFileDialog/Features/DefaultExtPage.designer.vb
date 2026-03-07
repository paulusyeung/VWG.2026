Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DefaultExtPage
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
            Me.mobjDefaultExtLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDefaultExtTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjOpenFileDialogButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDefaultExtLabel
            ' 
            Me.mobjDefaultExtLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDefaultExtLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDefaultExtLabel.Name = "mobjDefaultExtLabel"
            Me.mobjDefaultExtLabel.Size = New System.Drawing.Size(261, 50)
            Me.mobjDefaultExtLabel.TabIndex = 0
            Me.mobjDefaultExtLabel.Text = "Default extension"
            ' 
            ' mobjDefaultExtTextBox
            ' 
            Me.mobjDefaultExtTextBox.AllowDrag = False
            Me.mobjDefaultExtTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.mobjDefaultExtTextBox.Location = New System.Drawing.Point(261, 0)
            Me.mobjDefaultExtTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjDefaultExtTextBox.Name = "mobjDefaultExtTextBox"
            Me.mobjDefaultExtTextBox.Size = New System.Drawing.Size(119, 30)
            Me.mobjDefaultExtTextBox.TabIndex = 1
            ' 
            ' mobjOpenFileDialogButton
            ' 
            Me.mobjOpenFileDialogButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileDialogButton.Location = New System.Drawing.Point(81, 95)
            Me.mobjOpenFileDialogButton.Name = "mobjOpenFileDialogButton"
            Me.mobjOpenFileDialogButton.Size = New System.Drawing.Size(380, 50)
            Me.mobjOpenFileDialogButton.TabIndex = 2
            Me.mobjOpenFileDialogButton.Text = "Open OpenFileDialog with specified DefaultExt"
            Me.mobjOpenFileDialogButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileDialogButton, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(543, 171)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjDefaultExtLabel)
            Me.mobjPanel.Controls.Add(Me.mobjDefaultExtTextBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(81, 25)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(380, 50)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' DefaultExtPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(543, 171)
            Me.Text = "DefaultExtPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDefaultExtLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjOpenFileDialogButton As Gizmox.WebGUI.Forms.Button
        Public mobjDefaultExtTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

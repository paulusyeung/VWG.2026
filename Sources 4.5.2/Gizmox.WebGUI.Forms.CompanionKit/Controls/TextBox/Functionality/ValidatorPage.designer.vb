Namespace CompanionKit.Controls.TextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ValidatorPage
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
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjLabelPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(384, 50)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Enter only digits, '.' and '-' characters"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjTextBox.Location = New System.Drawing.Point(95, 84)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(194, 30)
            Me.mobjTextBox.TabIndex = 0
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabelPanel, 0, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(384, 145)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(0, 77)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(200, 40)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjLabelPanel
            ' 
            Me.mobjLabelPanel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjLabelPanel, 3)
            Me.mobjLabelPanel.Controls.Add(Me.mobjLabel)
            Me.mobjLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabelPanel.Location = New System.Drawing.Point(0, 27)
            Me.mobjLabelPanel.Name = "mobjLabelPanel"
            Me.mobjLabelPanel.Size = New System.Drawing.Size(384, 50)
            Me.mobjLabelPanel.TabIndex = 0
            ' 
            ' ValidatorPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(384, 145)
            Me.Text = "ValidatorPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjLabelPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend mobjLabel As Label
        Friend mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLabelPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

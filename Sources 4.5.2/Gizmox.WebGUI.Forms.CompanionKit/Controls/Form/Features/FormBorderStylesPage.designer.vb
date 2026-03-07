Namespace CompanionKit.Controls.Form.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FormBorderStylesPage
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
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjAdditionalLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjAdditionalLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(231, 35)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Border style"
            '
            'mobjComboBox
            '
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjComboBox.Location = New System.Drawing.Point(0, 35)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(231, 30)
            Me.mobjComboBox.TabIndex = 2
            '
            'mobjButton
            '
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton.Location = New System.Drawing.Point(115, 107)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(231, 50)
            Me.mobjButton.TabIndex = 3
            Me.mobjButton.Text = "Open form with selected border style"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'mobjLayoutPanel
            '
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjButton, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0!))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(462, 214)
            Me.mobjLayoutPanel.TabIndex = 4
            '
            'mobjPanel
            '
            Me.mobjPanel.Controls.Add(Me.mobjAdditionalLayoutPanel)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(115, 37)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(231, 70)
            Me.mobjPanel.TabIndex = 0
            '
            'mobjAdditionalLayoutPanel
            '
            Me.mobjAdditionalLayoutPanel.ColumnCount = 1
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0!))
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjComboBox, 0, 1)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAdditionalLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel"
            Me.mobjAdditionalLayoutPanel.RowCount = 2
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjAdditionalLayoutPanel.Size = New System.Drawing.Size(231, 70)
            Me.mobjAdditionalLayoutPanel.TabIndex = 3
            '
            'FormBorderStylesPage
            '
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(462, 214)
            Me.Text = "FormBorderStylesPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjAdditionalLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjButton As Global.Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjAdditionalLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

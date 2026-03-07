Namespace CompanionKit.Concepts.ClientAPI.EnabledAndVisible

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class EnabledVisiblePage
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
        ''' <summary>
        ''' Initializes the component.
        ''' </summary>
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
            Me.mobjEnabledCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjVisibleCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabelEnabled = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabelVisible = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel1 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel2 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel4 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel3 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel1.SuspendLayout()
            Me.mobjPanel2.SuspendLayout()
            Me.mobjPanel4.SuspendLayout()
            Me.mobjPanel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjEnabledCheckBox
            '
            Me.mobjEnabledCheckBox.AutoSize = True
            Me.mobjEnabledCheckBox.Checked = True
            Me.mobjEnabledCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjEnabledCheckBox.Location = New System.Drawing.Point(50, 50)
            Me.mobjEnabledCheckBox.Name = "mobjEnabledCheckBox"
            Me.mobjEnabledCheckBox.Size = New System.Drawing.Size(64, 17)
            Me.mobjEnabledCheckBox.TabIndex = 1
            Me.mobjEnabledCheckBox.Text = "Enabled"
            '
            'mobjVisibleCheckBox
            '
            Me.mobjVisibleCheckBox.AutoSize = True
            Me.mobjVisibleCheckBox.Checked = True
            Me.mobjVisibleCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjVisibleCheckBox.Location = New System.Drawing.Point(50, 17)
            Me.mobjVisibleCheckBox.Name = "mobjVisibleCheckBox"
            Me.mobjVisibleCheckBox.Size = New System.Drawing.Size(53, 17)
            Me.mobjVisibleCheckBox.TabIndex = 2
            Me.mobjVisibleCheckBox.Text = "Visibe"
            '
            'mobjButton
            '
            Me.mobjButton.ClientId = "btn"
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton.Location = New System.Drawing.Point(10, 0)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(119, 75)
            Me.mobjButton.TabIndex = 3
            Me.mobjButton.Text = "Button"
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 15, 0, 15)
            Me.mobjLabel.Size = New System.Drawing.Size(818, 70)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Check/uncheck to change appropriate property of Button:"
            '
            'mobjLabelEnabled
            '
            Me.mobjLabelEnabled.ClientId = "lblEnabled"
            Me.mobjLabelEnabled.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabelEnabled.Location = New System.Drawing.Point(10, 0)
            Me.mobjLabelEnabled.Name = "mobjLabelEnabled"
            Me.mobjLabelEnabled.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 5)
            Me.mobjLabelEnabled.Size = New System.Drawing.Size(679, 34)
            Me.mobjLabelEnabled.TabIndex = 4
            Me.mobjLabelEnabled.Text = "Button is enabled"
            '
            'mobjLabelVisible
            '
            Me.mobjLabelVisible.ClientId = "lblVisible"
            Me.mobjLabelVisible.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabelVisible.Location = New System.Drawing.Point(10, 34)
            Me.mobjLabelVisible.Name = "mobjLabelVisible"
            Me.mobjLabelVisible.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 5)
            Me.mobjLabelVisible.Size = New System.Drawing.Size(679, 41)
            Me.mobjLabelVisible.TabIndex = 5
            Me.mobjLabelVisible.Text = "Button is visible"
            '
            'mobjPanel1
            '
            Me.mobjPanel1.Controls.Add(Me.mobjEnabledCheckBox)
            Me.mobjPanel1.Controls.Add(Me.mobjVisibleCheckBox)
            Me.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjPanel1.Location = New System.Drawing.Point(0, 60)
            Me.mobjPanel1.Name = "mobjPanel1"
            Me.mobjPanel1.Size = New System.Drawing.Size(818, 85)
            Me.mobjPanel1.TabIndex = 6
            '
            'mobjPanel2
            '
            Me.mobjPanel2.Controls.Add(Me.mobjPanel4)
            Me.mobjPanel2.Controls.Add(Me.mobjPanel3)
            Me.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjPanel2.Location = New System.Drawing.Point(0, 145)
            Me.mobjPanel2.Name = "mobjPanel2"
            Me.mobjPanel2.Size = New System.Drawing.Size(818, 75)
            Me.mobjPanel2.TabIndex = 7
            '
            'mobjPanel4
            '
            Me.mobjPanel4.Controls.Add(Me.mobjLabelVisible)
            Me.mobjPanel4.Controls.Add(Me.mobjLabelEnabled)
            Me.mobjPanel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel4.DockPadding.Left = 10
            Me.mobjPanel4.Location = New System.Drawing.Point(129, 0)
            Me.mobjPanel4.Name = "mobjPanel4"
            Me.mobjPanel4.Padding = New Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0)
            Me.mobjPanel4.Size = New System.Drawing.Size(689, 75)
            Me.mobjPanel4.TabIndex = 1
            '
            'mobjPanel3
            '
            Me.mobjPanel3.Controls.Add(Me.mobjButton)
            Me.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjPanel3.DockPadding.Left = 10
            Me.mobjPanel3.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel3.Name = "mobjPanel3"
            Me.mobjPanel3.Padding = New Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0)
            Me.mobjPanel3.Size = New System.Drawing.Size(129, 75)
            Me.mobjPanel3.TabIndex = 0
            '
            'EnabledVisiblePage
            '
            Me.Controls.Add(Me.mobjPanel2)
            Me.Controls.Add(Me.mobjPanel1)
            Me.Controls.Add(Me.mobjLabel)
            Me.Size = New System.Drawing.Size(818, 361)
            Me.Text = "EnabledVisiblePage"
            Me.mobjPanel1.ResumeLayout(False)
            Me.mobjPanel2.ResumeLayout(False)
            Me.mobjPanel4.ResumeLayout(False)
            Me.mobjPanel3.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjEnabledCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjVisibleCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjLabelEnabled As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjLabelVisible As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjPanel1 As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjPanel2 As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjPanel4 As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjPanel3 As Gizmox.WebGUI.Forms.Panel
	End Class

End Namespace
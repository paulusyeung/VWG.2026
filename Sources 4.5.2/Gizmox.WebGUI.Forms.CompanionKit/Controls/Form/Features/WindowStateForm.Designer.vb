Namespace CompanionKit.Controls.Form.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class WindowStateForm
		Inherits Global.Gizmox.WebGUI.Forms.Form

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		'Required by the Visual WebGui Designer
		Private Shadows components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Visual WebGui Designer
		'It can be modified using the Visual WebGui Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
            Me.mobjCommonLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaximizeCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjMinimizeCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjStateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCloseButton = New Gizmox.WebGUI.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' mobjCommonLabel
            ' 
            Me.mobjCommonLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjCommonLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjCommonLabel.Name = "label1"
            Me.mobjCommonLabel.Size = New System.Drawing.Size(372, 89)
            Me.mobjCommonLabel.TabIndex = 0
            Me.mobjCommonLabel.Text = "Check button that will be have this form and select window state for this form an" + "d click on button."
            Me.mobjCommonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjMaximizeCheckBox
            ' 
            Me.mobjMaximizeCheckBox.AutoSize = True
            Me.mobjMaximizeCheckBox.Location = New System.Drawing.Point(133, 78)
            Me.mobjMaximizeCheckBox.Name = "maximizeBtnCheckBox"
            Me.mobjMaximizeCheckBox.Size = New System.Drawing.Size(104, 17)
            Me.mobjMaximizeCheckBox.TabIndex = 1
            Me.mobjMaximizeCheckBox.Text = "Maximize button"
            Me.mobjMaximizeCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjMinimizeCheckBox
            ' 
            Me.mobjMinimizeCheckBox.AutoSize = True
            Me.mobjMinimizeCheckBox.Location = New System.Drawing.Point(133, 108)
            Me.mobjMinimizeCheckBox.Name = "checkBox2"
            Me.mobjMinimizeCheckBox.Size = New System.Drawing.Size(100, 17)
            Me.mobjMinimizeCheckBox.TabIndex = 2
            Me.mobjMinimizeCheckBox.Text = "Minimize button"
            Me.mobjMinimizeCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjStateLabel
            ' 
            Me.mobjStateLabel.Location = New System.Drawing.Point(0, 127)
            Me.mobjStateLabel.Name = "label2"
            Me.mobjStateLabel.Size = New System.Drawing.Size(380, 31)
            Me.mobjStateLabel.TabIndex = 3
            Me.mobjStateLabel.Text = "Select window state for opened form"
            Me.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Location = New System.Drawing.Point(103, 158)
            Me.mobjComboBox.Name = "comboBox1"
            Me.mobjComboBox.Size = New System.Drawing.Size(175, 30)
            Me.mobjComboBox.TabIndex = 4
            ' 
            ' mobjCloseButton
            ' 
            Me.mobjCloseButton.Location = New System.Drawing.Point(48, 195)
            Me.mobjCloseButton.Name = "closeButton"
            Me.mobjCloseButton.Size = New System.Drawing.Size(288, 38)
            Me.mobjCloseButton.TabIndex = 5
            Me.mobjCloseButton.Text = "Close"
            Me.mobjCloseButton.UseVisualStyleBackColor = True
            ' 
            ' WindowStateForm
            ' 
            Me.Controls.Add(Me.mobjCloseButton)
            Me.Controls.Add(Me.mobjComboBox)
            Me.Controls.Add(Me.mobjStateLabel)
            Me.Controls.Add(Me.mobjMinimizeCheckBox)
            Me.Controls.Add(Me.mobjMaximizeCheckBox)
            Me.Controls.Add(Me.mobjCommonLabel)
            Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
            Me.Size = New System.Drawing.Size(372, 242)
            Me.Text = "Window State Form"
            Me.ResumeLayout(False)

        End Sub

        Private mobjCommonLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMaximizeCheckBox As Global.Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjMinimizeCheckBox As Global.Gizmox.WebGUI.Forms.CheckBox
        Private mobjStateLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjCloseButton As Global.Gizmox.WebGUI.Forms.Button

	End Class

End Namespace
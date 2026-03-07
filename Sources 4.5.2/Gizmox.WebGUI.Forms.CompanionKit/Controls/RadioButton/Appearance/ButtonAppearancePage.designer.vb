Namespace CompanionKit.Controls.RadioButton.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ButtonAppearancePage
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
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjRadioButton3 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButton1 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButton2 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjGroupBox.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjGroupBox.Controls.Add(Me.mobjRadioButton3)
            Me.mobjGroupBox.Controls.Add(Me.mobjRadioButton1)
            Me.mobjGroupBox.Controls.Add(Me.mobjRadioButton2)
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(28, 93)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(163, 123)
            Me.mobjGroupBox.TabIndex = 0
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "RadioButtons"
            ' 
            ' mobjRadioButton3
            ' 
            Me.mobjRadioButton3.AutoSize = True
            Me.mobjRadioButton3.Location = New System.Drawing.Point(25, 85)
            Me.mobjRadioButton3.Name = "mobjRadioButton3"
            Me.mobjRadioButton3.Size = New System.Drawing.Size(87, 17)
            Me.mobjRadioButton3.TabIndex = 5
            Me.mobjRadioButton3.Text = "radioButton3"
            ' 
            ' mobjRadioButton1
            ' 
            Me.mobjRadioButton1.AutoSize = True
            Me.mobjRadioButton1.Checked = True
            Me.mobjRadioButton1.Location = New System.Drawing.Point(25, 29)
            Me.mobjRadioButton1.Name = "mobjRadioButton1"
            Me.mobjRadioButton1.Size = New System.Drawing.Size(87, 17)
            Me.mobjRadioButton1.TabIndex = 3
            Me.mobjRadioButton1.Text = "radioButton1"
            ' 
            ' mobjRadioButton2
            ' 
            Me.mobjRadioButton2.AutoSize = True
            Me.mobjRadioButton2.Location = New System.Drawing.Point(25, 57)
            Me.mobjRadioButton2.Name = "mobjRadioButton2"
            Me.mobjRadioButton2.Size = New System.Drawing.Size(87, 17)
            Me.mobjRadioButton2.TabIndex = 4
            Me.mobjRadioButton2.Text = "radioButton2"
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"Normal", "Button"})
            Me.mobjComboBox.Location = New System.Drawing.Point(28, 48)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(111, 30)
            Me.mobjComboBox.TabIndex = 1
            Me.mobjComboBox.Text = "Normal"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Location = New System.Drawing.Point(25, 26)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel.TabIndex = 2
            Me.mobjLabel.Text = "ButtonAppearance:"
            ' 
            ' ButtonAppearancePage
            ' 
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjComboBox)
            Me.Controls.Add(Me.mobjGroupBox)
            Me.Size = New System.Drawing.Size(217, 238)
            Me.Text = "ButtonAppearancePage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub


        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private mobjRadioButton3 As Gizmox.WebGUI.Forms.RadioButton
        Private mobjRadioButton1 As Gizmox.WebGUI.Forms.RadioButton
        Private mobjRadioButton2 As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label


	End Class

End Namespace
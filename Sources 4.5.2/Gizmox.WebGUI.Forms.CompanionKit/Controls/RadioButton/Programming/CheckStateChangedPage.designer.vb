Namespace CompanionKit.Controls.RadioButton.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckStateChangedPage
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
            Me.mobjRadioButton1 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButton2 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckBox1 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjCheckBox2 = New Gizmox.WebGUI.Forms.CheckBox()
            Me.SuspendLayout()
            ' 
            ' mobjRadioButton1
            ' 
            Me.mobjRadioButton1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioButton1.AutoSize = True
            Me.mobjRadioButton1.Location = New System.Drawing.Point(24, 25)
            Me.mobjRadioButton1.Name = "mobjRadioButton1"
            Me.mobjRadioButton1.Size = New System.Drawing.Size(90, 17)
            Me.mobjRadioButton1.TabIndex = 0
            Me.mobjRadioButton1.Text = "RadioButton1"
            ' 
            ' mobjRadioButton2
            ' 
            Me.mobjRadioButton2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioButton2.AutoSize = True
            Me.mobjRadioButton2.Location = New System.Drawing.Point(24, 127)
            Me.mobjRadioButton2.Name = "mobjRadioButton2"
            Me.mobjRadioButton2.Size = New System.Drawing.Size(90, 17)
            Me.mobjRadioButton2.TabIndex = 1
            Me.mobjRadioButton2.Text = "RadioButton2"
            ' 
            ' mobjLabel1
            ' 
            Me.mobjLabel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLabel1.AutoSize = True
            Me.mobjLabel1.Font = New System.Drawing.Font("Tahoma", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(204))
            Me.mobjLabel1.Location = New System.Drawing.Point(19, 69)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel1.TabIndex = 2
            Me.mobjLabel1.Text = "label1"
            ' 
            ' mobjLabel2
            ' 
            Me.mobjLabel2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLabel2.AutoSize = True
            Me.mobjLabel2.Font = New System.Drawing.Font("Tahoma", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(204))
            Me.mobjLabel2.Location = New System.Drawing.Point(19, 171)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel2.TabIndex = 3
            Me.mobjLabel2.Text = "label2"
            ' 
            ' mobjCheckBox1
            ' 
            Me.mobjCheckBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox1.AutoSize = True
            Me.mobjCheckBox1.Location = New System.Drawing.Point(177, 25)
            Me.mobjCheckBox1.Name = "mobjCheckBox1"
            Me.mobjCheckBox1.Size = New System.Drawing.Size(89, 17)
            Me.mobjCheckBox1.TabIndex = 4
            Me.mobjCheckBox1.Text = "RB1 Checked"
            ' 
            ' mobjCheckBox2
            ' 
            Me.mobjCheckBox2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox2.AutoSize = True
            Me.mobjCheckBox2.Location = New System.Drawing.Point(177, 127)
            Me.mobjCheckBox2.Name = "mobjCheckBox2"
            Me.mobjCheckBox2.Size = New System.Drawing.Size(89, 17)
            Me.mobjCheckBox2.TabIndex = 5
            Me.mobjCheckBox2.Text = "RB2 Checked"
            ' 
            ' CheckStateChangedPage
            ' 
            Me.Controls.Add(Me.mobjCheckBox2)
            Me.Controls.Add(Me.mobjCheckBox1)
            Me.Controls.Add(Me.mobjLabel2)
            Me.Controls.Add(Me.mobjLabel1)
            Me.Controls.Add(Me.mobjRadioButton2)
            Me.Controls.Add(Me.mobjRadioButton1)
            Me.Size = New System.Drawing.Size(323, 215)
            Me.Text = "CheckStateChangedPage"
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjRadioButton1 As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRadioButton2 As Gizmox.WebGUI.Forms.RadioButton
        Private mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Private mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCheckBox1 As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjCheckBox2 As Gizmox.WebGUI.Forms.CheckBox

	End Class

End Namespace

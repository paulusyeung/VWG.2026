Namespace CompanionKit.Concepts.ClientAPI.LoadingIcon

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class LoadingIconPage
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
            Me.objButton = New Gizmox.WebGUI.Forms.Button()
            Me.objNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.objLabel = New Gizmox.WebGUI.Forms.Label()
            DirectCast(Me.objNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' objButton
            ' 
            Me.objButton.AccessibleDescription = ""
            Me.objButton.AccessibleName = ""
            Me.objButton.Location = New System.Drawing.Point(29, 126)
            Me.objButton.Name = "objButton"
            Me.objButton.Size = New System.Drawing.Size(116, 23)
            Me.objButton.TabIndex = 0
            Me.objButton.Text = "Show Loading Icon"
            ' 
            ' objNumericUpDown
            ' 
            Me.objNumericUpDown.AccessibleDescription = ""
            Me.objNumericUpDown.AccessibleName = ""
            Me.objNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.objNumericUpDown.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.objNumericUpDown.ClientId = "nud"
            Me.objNumericUpDown.CurrentValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.objNumericUpDown.Location = New System.Drawing.Point(29, 73)
            Me.objNumericUpDown.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
            Me.objNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.objNumericUpDown.Name = "objNumericUpDown"
            Me.objNumericUpDown.Size = New System.Drawing.Size(120, 17)
            Me.objNumericUpDown.TabIndex = 1
            Me.objNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            ' 
            ' objLabel
            ' 
            Me.objLabel.AccessibleDescription = ""
            Me.objLabel.AccessibleName = ""
            Me.objLabel.AutoSize = True
            Me.objLabel.Location = New System.Drawing.Point(26, 50)
            Me.objLabel.Name = "objLabel"
            Me.objLabel.Size = New System.Drawing.Size(35, 13)
            Me.objLabel.TabIndex = 2
            Me.objLabel.Text = "Duration, sec"
            ' 
            ' LoadingIconPage
            ' 
            Me.Controls.Add(Me.objLabel)
            Me.Controls.Add(Me.objNumericUpDown)
            Me.Controls.Add(Me.objButton)
            Me.MaximumSize = New System.Drawing.Size(315, 225)
            Me.Size = New System.Drawing.Size(315, 225)
            Me.Text = "LoadingIconPage"
            DirectCast(Me.objNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents objButton As Gizmox.WebGUI.Forms.Button
        Private objNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private objLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace
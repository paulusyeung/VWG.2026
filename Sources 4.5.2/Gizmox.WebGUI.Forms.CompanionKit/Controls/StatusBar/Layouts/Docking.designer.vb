Namespace CompanionKit.Controls.StatusBar.Layouts

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class Docking
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
            Me.mobjDockComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTestStatusBar = New Gizmox.WebGUI.Forms.StatusBar()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjDockComboBox
            ' 
            Me.mobjDockComboBox.AllowDrag = False
            Me.mobjDockComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjDockComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjDockComboBox.Location = New System.Drawing.Point(182, 86)
            Me.mobjDockComboBox.Name = "mobjDockComboBox"
            Me.mobjDockComboBox.Size = New System.Drawing.Size(155, 30)
            Me.mobjDockComboBox.TabIndex = 1
            ' 
            ' mobjTestStatusBar
            ' 
            Me.mobjTestStatusBar.Location = New System.Drawing.Point(0, 284)
            Me.mobjTestStatusBar.Name = "mobjTestStatusBar"
            Me.mobjTestStatusBar.Size = New System.Drawing.Size(511, 22)
            Me.mobjTestStatusBar.TabIndex = 3
            Me.mobjTestStatusBar.Text = "This is test StatusBar"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Location = New System.Drawing.Point(179, 55)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel.TabIndex = 4
            Me.mobjLabel.Text = "Dock Style"
            ' 
            ' Docking
            ' 
            Me.Controls.Add(Me.mobjLabel)
            Me.Controls.Add(Me.mobjTestStatusBar)
            Me.Controls.Add(Me.mobjDockComboBox)
            Me.Size = New System.Drawing.Size(511, 200)
            Me.Text = "Docking"
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDockComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjTestStatusBar As Gizmox.WebGUI.Forms.StatusBar
        Private mobjLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace

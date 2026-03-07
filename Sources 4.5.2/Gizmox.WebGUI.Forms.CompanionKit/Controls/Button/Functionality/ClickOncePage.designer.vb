Namespace CompanionKit.Controls.Button.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ClickOncePage
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
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjAllowCheckOnceCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjButton
            '
            Me.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButton.ClickOnce = True
            Me.mobjButton.Location = New System.Drawing.Point(85, 129)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(149, 73)
            Me.mobjButton.TabIndex = 0
            Me.mobjButton.Text = "Click Once"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'mobjAllowCheckOnceCheckBox
            '
            Me.mobjAllowCheckOnceCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjAllowCheckOnceCheckBox.Location = New System.Drawing.Point(50, 289)
            Me.mobjAllowCheckOnceCheckBox.Name = "mobjAllowCheckOnceCheckBox"
            Me.mobjAllowCheckOnceCheckBox.Size = New System.Drawing.Size(220, 50)
            Me.mobjAllowCheckOnceCheckBox.TabIndex = 1
            Me.mobjAllowCheckOnceCheckBox.Text = "Allow ClickOnce for the Button"
            Me.mobjAllowCheckOnceCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjAllowCheckOnceCheckBox.UseVisualStyleBackColor = True
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(320, 52)
            Me.mobjLabel.TabIndex = 2
            Me.mobjLabel.Text = "Turn on/off 'click once' for the button:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjAllowCheckOnceCheckBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjButton, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 3
            '
            'ClickOncePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "ClickOncePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjAllowCheckOnceCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

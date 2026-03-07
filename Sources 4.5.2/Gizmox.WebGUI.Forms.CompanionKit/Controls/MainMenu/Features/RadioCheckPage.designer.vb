Namespace CompanionKit.Controls.MainMenu.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class RadioCheckPage
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
            Me.openFormWithMainMenuButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'openFormWithMainMenuButton
            '
            Me.openFormWithMainMenuButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.openFormWithMainMenuButton.Location = New System.Drawing.Point(35, 155)
            Me.openFormWithMainMenuButton.Name = "openFormWithMainMenuButton"
            Me.openFormWithMainMenuButton.Size = New System.Drawing.Size(250, 90)
            Me.openFormWithMainMenuButton.TabIndex = 0
            Me.openFormWithMainMenuButton.Text = "Open Form with MainMenu that supports Menu item radio checks"
            Me.openFormWithMainMenuButton.UseVisualStyleBackColor = True
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.openFormWithMainMenuButton, 0, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 1
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 1
            '
            'RadioCheckPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "RadioCheckPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents openFormWithMainMenuButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
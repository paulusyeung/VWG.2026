Namespace CompanionKit.Controls.Button.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DialogResultPage
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
            Me.mobjOpenButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjOpenButton
            '
            Me.mobjOpenButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjOpenButton.Location = New System.Drawing.Point(49, 182)
            Me.mobjOpenButton.Name = "mobjOpenButton"
            Me.mobjOpenButton.Size = New System.Drawing.Size(221, 72)
            Me.mobjOpenButton.TabIndex = 0
            Me.mobjOpenButton.Text = "Open CustomDialog"
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjOpenButton, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 1
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 87)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Click button to open custom dialog:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'DialogResultPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "DialogResultPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjOpenButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace
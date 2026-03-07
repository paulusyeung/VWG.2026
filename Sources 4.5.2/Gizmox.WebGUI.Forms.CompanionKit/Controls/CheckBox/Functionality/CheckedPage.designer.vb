Namespace CompanionKit.Controls.CheckBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckedPage
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
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjStateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjCheckBox
            '
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox.Location = New System.Drawing.Point(95, 85)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(130, 50)
            Me.mobjCheckBox.TabIndex = 0
            Me.mobjCheckBox.Text = "Demo CheckBox"
            Me.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjStateLabel
            '
            Me.mobjStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStateLabel.Font = New System.Drawing.Font("Tahoma", 15.25!)
            Me.mobjStateLabel.Location = New System.Drawing.Point(0, 154)
            Me.mobjStateLabel.Name = "mobjStateLabel"
            Me.mobjStateLabel.Size = New System.Drawing.Size(320, 66)
            Me.mobjStateLabel.TabIndex = 1
            Me.mobjStateLabel.Text = "label1"
            Me.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 66)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "CheckBox with changing Checked property:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjStateLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjCheckBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 220)
            Me.mobjTLP.TabIndex = 2
            '
            'CheckedPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 220)
            Me.Text = "CheckedPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjStateLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

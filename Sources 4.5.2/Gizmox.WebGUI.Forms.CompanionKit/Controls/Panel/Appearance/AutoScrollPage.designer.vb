Namespace CompanionKit.Controls.Panel.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AutoScrollPage
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
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjAutoScrollEnabled = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjPanel
            '
            Me.mobjPanel.AutoScroll = True
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(0, 80)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(320, 240)
            Me.mobjPanel.TabIndex = 0
            '
            'mobjButton
            '
            Me.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButton.Location = New System.Drawing.Point(75, 335)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(170, 50)
            Me.mobjButton.TabIndex = 1
            Me.mobjButton.Text = "Add Button to Panel"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'mobjAutoScrollEnabled
            '
            Me.mobjAutoScrollEnabled.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjAutoScrollEnabled.Checked = True
            Me.mobjAutoScrollEnabled.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjAutoScrollEnabled.Location = New System.Drawing.Point(85, 15)
            Me.mobjAutoScrollEnabled.Name = "mobjAutoScrollEnabled"
            Me.mobjAutoScrollEnabled.Size = New System.Drawing.Size(150, 50)
            Me.mobjAutoScrollEnabled.TabIndex = 2
            Me.mobjAutoScrollEnabled.Text = "Enable AutoScroll"
            Me.mobjAutoScrollEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjAutoScrollEnabled, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjButton, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjPanel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 3
            '
            'AutoScrollPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "AutoScrollPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjAutoScrollEnabled As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

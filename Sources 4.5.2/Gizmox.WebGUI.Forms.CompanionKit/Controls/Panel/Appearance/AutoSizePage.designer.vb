Namespace CompanionKit.Controls.Panel.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AutoSizePage
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
            Me.mobjAutoSizeCB = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjButton
            '
            Me.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButton.Location = New System.Drawing.Point(60, 345)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(200, 50)
            Me.mobjButton.TabIndex = 1
            Me.mobjButton.Text = "Add Button to Panel"
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'mobjAutoSizeCB
            '
            Me.mobjAutoSizeCB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjAutoSizeCB.Location = New System.Drawing.Point(100, 75)
            Me.mobjAutoSizeCB.Name = "mobjAutoSizeCB"
            Me.mobjAutoSizeCB.Size = New System.Drawing.Size(120, 50)
            Me.mobjAutoSizeCB.TabIndex = 2
            Me.mobjAutoSizeCB.Text = "AutoSize"
            Me.mobjAutoSizeCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjAutoSizeCB.UseVisualStyleBackColor = True
            '
            'mobjPanel
            '
            Me.mobjPanel.Anchor = CType(((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Left), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjPanel.BackColor = System.Drawing.Color.Transparent
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel.Location = New System.Drawing.Point(10, 140)
            Me.mobjPanel.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(250, 200)
            Me.mobjPanel.TabIndex = 3
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 4
            Me.mobjInfoLabel.Text = "Change AutoSize property for Panel with MaxWidth=1000:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjButton, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjAutoSizeCB, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjPanel, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 5
            '
            'AutoSizePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "AutoSizePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjAutoSizeCB As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

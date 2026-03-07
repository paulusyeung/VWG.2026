Namespace CompanionKit.Controls.CheckBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckStatePage
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
            Me.mobjCheckStateButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjCheckBox
            '
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right
            Me.mobjCheckBox.Location = New System.Drawing.Point(30, 99)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjCheckBox.Size = New System.Drawing.Size(130, 50)
            Me.mobjCheckBox.TabIndex = 0
            Me.mobjCheckBox.Text = "Demo CheckBox"
            Me.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjCheckBox.ThreeState = True
            '
            'mobjStateLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjStateLabel, 2)
            Me.mobjStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStateLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.mobjStateLabel.Location = New System.Drawing.Point(0, 166)
            Me.mobjStateLabel.Name = "mobjStateLabel"
            Me.mobjStateLabel.Size = New System.Drawing.Size(320, 84)
            Me.mobjStateLabel.TabIndex = 1
            Me.mobjStateLabel.Text = "label1"
            Me.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCheckStateButton
            '
            Me.mobjCheckStateButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Left
            Me.mobjCheckStateButton.Location = New System.Drawing.Point(170, 104)
            Me.mobjCheckStateButton.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0)
            Me.mobjCheckStateButton.Name = "mobjCheckStateButton"
            Me.mobjCheckStateButton.Size = New System.Drawing.Size(120, 40)
            Me.mobjCheckStateButton.TabIndex = 2
            Me.mobjCheckStateButton.Text = "Checks State"
            Me.mobjCheckStateButton.UseVisualStyleBackColor = True
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 83)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "CheckBox with changing CheckState property:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjStateLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjCheckStateButton, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjCheckBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 250)
            Me.mobjTLP.TabIndex = 3
            '
            'CheckStatePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 250)
            Me.Text = "CheckStatePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjStateLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjCheckStateButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

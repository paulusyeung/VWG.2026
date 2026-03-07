Namespace CompanionKit.Controls.CheckBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ThreeStatePage
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
            Me.mobjStateCombo = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjStateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjCheckBox
            '
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right
            Me.mobjCheckBox.Location = New System.Drawing.Point(40, 87)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjCheckBox.Size = New System.Drawing.Size(120, 50)
            Me.mobjCheckBox.TabIndex = 0
            Me.mobjCheckBox.Text = "CheckBox"
            Me.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjCheckBox.ThreeState = True
            '
            'mobjStateCombo
            '
            Me.mobjStateCombo.AllowDrag = False
            Me.mobjStateCombo.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjStateCombo.FormattingEnabled = True
            Me.mobjStateCombo.Location = New System.Drawing.Point(170, 102)
            Me.mobjStateCombo.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjStateCombo.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjStateCombo.Name = "mobjStateCombo"
            Me.mobjStateCombo.Size = New System.Drawing.Size(140, 25)
            Me.mobjStateCombo.TabIndex = 1
            Me.mobjStateCombo.Text = "Unchecked"
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 75)
            Me.mobjInfoLabel.TabIndex = 2
            Me.mobjInfoLabel.Text = "CheckBox demonstrates ThreeState functionality:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjStateLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjStateLabel, 2)
            Me.mobjStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStateLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.mobjStateLabel.Location = New System.Drawing.Point(0, 150)
            Me.mobjStateLabel.Name = "mobjStateLabel"
            Me.mobjStateLabel.Size = New System.Drawing.Size(320, 100)
            Me.mobjStateLabel.TabIndex = 3
            Me.mobjStateLabel.Text = "CheckBox State: "
            Me.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjStateCombo, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjStateLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjCheckBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 250)
            Me.mobjTLP.TabIndex = 4
            '
            'ThreeStatePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 250)
            Me.Text = "ThreeStatePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjStateCombo As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjStateLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace

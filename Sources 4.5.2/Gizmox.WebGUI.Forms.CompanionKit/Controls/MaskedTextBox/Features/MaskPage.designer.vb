Namespace CompanionKit.Controls.MaskedTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MaskPage
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
            Me.mobjMaskLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaskComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjMaskedTextBox = New Gizmox.WebGUI.Forms.MaskedTextBox()
            Me.mobjMaskedTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjMaskLabel
            '
            Me.mobjMaskLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaskLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjMaskLabel.Name = "mobjMaskLabel"
            Me.mobjMaskLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjMaskLabel.Size = New System.Drawing.Size(160, 200)
            Me.mobjMaskLabel.TabIndex = 0
            Me.mobjMaskLabel.Text = "Select mask"
            Me.mobjMaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjMaskComboBox
            '
            Me.mobjMaskComboBox.AllowDrag = False
            Me.mobjMaskComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjMaskComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjMaskComboBox.Location = New System.Drawing.Point(160, 89)
            Me.mobjMaskComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMaskComboBox.Name = "mobjMaskComboBox"
            Me.mobjMaskComboBox.Size = New System.Drawing.Size(160, 25)
            Me.mobjMaskComboBox.TabIndex = 1
            '
            'mobjMaskedTextBox
            '
            Me.mobjMaskedTextBox.AllowDrag = False
            Me.mobjMaskedTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjMaskedTextBox.CustomStyle = "Masked"
            Me.mobjMaskedTextBox.Location = New System.Drawing.Point(163, 287)
            Me.mobjMaskedTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMaskedTextBox.Name = "mobjMaskedTextBox"
            Me.mobjMaskedTextBox.Size = New System.Drawing.Size(154, 25)
            Me.mobjMaskedTextBox.TabIndex = 2
            '
            'mobjMaskedTextLabel
            '
            Me.mobjMaskedTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaskedTextLabel.Location = New System.Drawing.Point(0, 200)
            Me.mobjMaskedTextLabel.Name = "mobjMaskedTextLabel"
            Me.mobjMaskedTextLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjMaskedTextLabel.Size = New System.Drawing.Size(160, 200)
            Me.mobjMaskedTextLabel.TabIndex = 3
            Me.mobjMaskedTextLabel.Text = "Enter masked text"
            Me.mobjMaskedTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjMaskLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjMaskedTextBox, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjMaskedTextLabel, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjMaskComboBox, 1, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 4
            '
            'MaskPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "MaskPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjMaskLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjMaskComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjMaskedTextBox As Gizmox.WebGUI.Forms.MaskedTextBox
        Friend WithEvents mobjMaskedTextLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
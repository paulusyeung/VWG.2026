Namespace CompanionKit.Controls.MaskedTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextMaskFormatPage
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
            Me.mobjMaskValuesLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaskedTextBox = New Gizmox.WebGUI.Forms.MaskedTextBox()
            Me.mobjMaskValuesComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTextMaskFormatLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextMaskFormatComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueOfTextPropertyLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjMaskValuesLabel
            '
            Me.mobjMaskValuesLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaskValuesLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjMaskValuesLabel.Name = "mobjMaskValuesLabel"
            Me.mobjMaskValuesLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjMaskValuesLabel.Size = New System.Drawing.Size(160, 100)
            Me.mobjMaskValuesLabel.TabIndex = 0
            Me.mobjMaskValuesLabel.Text = "Select mask:"
            Me.mobjMaskValuesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjMaskedTextBox
            '
            Me.mobjMaskedTextBox.AllowDrag = False
            Me.mobjMaskedTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjMaskedTextBox.CustomStyle = "Masked"
            Me.mobjMaskedTextBox.Location = New System.Drawing.Point(163, 237)
            Me.mobjMaskedTextBox.Mask = "00000"
            Me.mobjMaskedTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMaskedTextBox.Name = "mobjMaskedTextBox"
            Me.mobjMaskedTextBox.Size = New System.Drawing.Size(154, 25)
            Me.mobjMaskedTextBox.TabIndex = 1
            '
            'mobjMaskValuesComboBox
            '
            Me.mobjMaskValuesComboBox.AllowDrag = False
            Me.mobjMaskValuesComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjMaskValuesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjMaskValuesComboBox.Location = New System.Drawing.Point(160, 39)
            Me.mobjMaskValuesComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMaskValuesComboBox.Name = "mobjMaskValuesComboBox"
            Me.mobjMaskValuesComboBox.Size = New System.Drawing.Size(160, 25)
            Me.mobjMaskValuesComboBox.TabIndex = 2
            '
            'mobjTextMaskFormatLabel
            '
            Me.mobjTextMaskFormatLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextMaskFormatLabel.Location = New System.Drawing.Point(0, 100)
            Me.mobjTextMaskFormatLabel.Name = "mobjTextMaskFormatLabel"
            Me.mobjTextMaskFormatLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTextMaskFormatLabel.Size = New System.Drawing.Size(160, 100)
            Me.mobjTextMaskFormatLabel.TabIndex = 3
            Me.mobjTextMaskFormatLabel.Text = "Select Text Mask Format:"
            Me.mobjTextMaskFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTextMaskFormatComboBox
            '
            Me.mobjTextMaskFormatComboBox.AllowDrag = False
            Me.mobjTextMaskFormatComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextMaskFormatComboBox.Location = New System.Drawing.Point(160, 139)
            Me.mobjTextMaskFormatComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextMaskFormatComboBox.Name = "mobjTextMaskFormatComboBox"
            Me.mobjTextMaskFormatComboBox.Size = New System.Drawing.Size(160, 25)
            Me.mobjTextMaskFormatComboBox.TabIndex = 4
            '
            'mobjTextLabel
            '
            Me.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLabel.Location = New System.Drawing.Point(0, 200)
            Me.mobjTextLabel.Name = "mobjTextLabel"
            Me.mobjTextLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTextLabel.Size = New System.Drawing.Size(160, 100)
            Me.mobjTextLabel.TabIndex = 5
            Me.mobjTextLabel.Text = "Enter masked text:"
            Me.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjValueOfTextPropertyLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjValueOfTextPropertyLabel, 2)
            Me.mobjValueOfTextPropertyLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueOfTextPropertyLabel.Location = New System.Drawing.Point(0, 300)
            Me.mobjValueOfTextPropertyLabel.Name = "mobjValueOfTextPropertyLabel"
            Me.mobjValueOfTextPropertyLabel.Size = New System.Drawing.Size(320, 100)
            Me.mobjValueOfTextPropertyLabel.TabIndex = 6
            Me.mobjValueOfTextPropertyLabel.Text = "Value of MaskedTextBox Text property:"
            Me.mobjValueOfTextPropertyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjMaskValuesLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjMaskedTextBox, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjTextMaskFormatComboBox, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjValueOfTextPropertyLabel, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjMaskValuesComboBox, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjTextMaskFormatLabel, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjTextLabel, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 7
            '
            'TextMaskFormatPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "TextMaskFormatPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjMaskValuesLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjMaskedTextBox As Gizmox.WebGUI.Forms.MaskedTextBox
        Friend WithEvents mobjMaskValuesComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTextMaskFormatLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTextMaskFormatComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTextLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjValueOfTextPropertyLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
	End Class

End Namespace
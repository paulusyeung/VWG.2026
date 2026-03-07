Namespace CompanionKit.Controls.RichTextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ControlPropertiesPage
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
            Me.mobjFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFontButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjFontRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjSelectionFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSelectionFontButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjSelectionFontRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjMultiLineCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjMultiLineRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjFontRichTExtBoxGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjTLP1 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjSelectionFontRichTExtBoxGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjTLP2 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjMultiLineRichTExtBoxGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjTLP3 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLPMain = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjFontRichTExtBoxGroupBox.SuspendLayout()
            Me.mobjTLP1.SuspendLayout()
            Me.mobjSelectionFontRichTExtBoxGroupBox.SuspendLayout()
            Me.mobjTLP2.SuspendLayout()
            Me.mobjMultiLineRichTExtBoxGroupBox.SuspendLayout()
            Me.mobjTLP3.SuspendLayout()
            Me.mobjTLPMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjFontLabel
            '
            Me.mobjFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFontLabel.Location = New System.Drawing.Point(31, 74)
            Me.mobjFontLabel.Name = "fontLabel"
            Me.mobjFontLabel.Size = New System.Drawing.Size(172, 36)
            Me.mobjFontLabel.TabIndex = 0
            Me.mobjFontLabel.Text = "Font"
            Me.mobjFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjFontButton
            '
            Me.mobjFontButton.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjFontButton.Location = New System.Drawing.Point(172, 6)
            Me.mobjFontButton.Name = "fontButton"
            Me.mobjFontButton.Size = New System.Drawing.Size(322, 23)
            Me.mobjFontButton.TabIndex = 1
            Me.mobjFontButton.Text = "Change Font..."
            Me.mobjFontButton.UseVisualStyleBackColor = True
            '
            'mobjFontRichTextBox
            '
            Me.mobjTLP1.SetColumnSpan(Me.mobjFontRichTextBox, 2)
            Me.mobjFontRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFontRichTextBox.Location = New System.Drawing.Point(10, 46)
            Me.mobjFontRichTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjFontRichTextBox.Name = "demoFontRichTextBox"
            Me.mobjFontRichTextBox.Size = New System.Drawing.Size(474, 90)
            Me.mobjFontRichTextBox.TabIndex = 2
            '
            'mobjSelectionFontLabel
            '
            Me.mobjSelectionFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectionFontLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSelectionFontLabel.Name = "selectionFontLabel"
            Me.mobjSelectionFontLabel.Size = New System.Drawing.Size(172, 36)
            Me.mobjSelectionFontLabel.TabIndex = 3
            Me.mobjSelectionFontLabel.Text = "Selection font:"
            Me.mobjSelectionFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjSelectionFontButton
            '
            Me.mobjSelectionFontButton.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjSelectionFontButton.Location = New System.Drawing.Point(172, 6)
            Me.mobjSelectionFontButton.Name = "selectionFontButton"
            Me.mobjSelectionFontButton.Size = New System.Drawing.Size(322, 23)
            Me.mobjSelectionFontButton.TabIndex = 4
            Me.mobjSelectionFontButton.Text = "Change selection font..."
            Me.mobjSelectionFontButton.UseVisualStyleBackColor = True
            '
            'mobjSelectionFontRichTextBox
            '
            Me.mobjTLP2.SetColumnSpan(Me.mobjSelectionFontRichTextBox, 2)
            Me.mobjSelectionFontRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectionFontRichTextBox.Location = New System.Drawing.Point(10, 46)
            Me.mobjSelectionFontRichTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjSelectionFontRichTextBox.Name = "demoSelectionFontRichTextBox"
            Me.mobjSelectionFontRichTextBox.Size = New System.Drawing.Size(474, 90)
            Me.mobjSelectionFontRichTextBox.TabIndex = 5
            '
            'mobjMultiLineCheckBox
            '
            Me.mobjMultiLineCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjMultiLineCheckBox.Location = New System.Drawing.Point(197, 0)
            Me.mobjMultiLineCheckBox.Name = "multiLineCheckBox"
            Me.mobjMultiLineCheckBox.Size = New System.Drawing.Size(200, 37)
            Me.mobjMultiLineCheckBox.TabIndex = 6
            Me.mobjMultiLineCheckBox.Text = "Allow multiline for RichTextBox"
            Me.mobjMultiLineCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjMultiLineCheckBox.UseVisualStyleBackColor = True
            '
            'mobjMultiLineRichTextBox
            '
            Me.mobjMultiLineRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMultiLineRichTextBox.Location = New System.Drawing.Point(10, 47)
            Me.mobjMultiLineRichTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjMultiLineRichTextBox.Name = "demoMultiLineRichTextBox"
            Me.mobjMultiLineRichTextBox.Size = New System.Drawing.Size(474, 91)
            Me.mobjMultiLineRichTextBox.TabIndex = 7
            '
            'mobjFontRichTExtBoxGroupBox
            '
            Me.mobjFontRichTExtBoxGroupBox.Controls.Add(Me.mobjTLP1)
            Me.mobjFontRichTExtBoxGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFontRichTExtBoxGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjFontRichTExtBoxGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjFontRichTExtBoxGroupBox.Name = "demoFontRichTExtBoxGroupBox"
            Me.mobjFontRichTExtBoxGroupBox.Size = New System.Drawing.Size(500, 166)
            Me.mobjFontRichTExtBoxGroupBox.TabIndex = 8
            Me.mobjFontRichTExtBoxGroupBox.TabStop = False
            Me.mobjFontRichTExtBoxGroupBox.Text = "Changing Font property for RichTextBox"
            '
            'mobjTLP1
            '
            Me.mobjTLP1.ColumnCount = 2
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0!))
            Me.mobjTLP1.Controls.Add(Me.mobjFontLabel, 0, 0)
            Me.mobjTLP1.Controls.Add(Me.mobjFontButton, 1, 0)
            Me.mobjTLP1.Controls.Add(Me.mobjFontRichTextBox, 0, 1)
            Me.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP1.Location = New System.Drawing.Point(3, 17)
            Me.mobjTLP1.Name = "mobjTLP1"
            Me.mobjTLP1.RowCount = 2
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75.0!))
            Me.mobjTLP1.Size = New System.Drawing.Size(494, 146)
            Me.mobjTLP1.TabIndex = 12
            '
            'mobjSelectionFontRichTExtBoxGroupBox
            '
            Me.mobjSelectionFontRichTExtBoxGroupBox.Controls.Add(Me.mobjTLP2)
            Me.mobjSelectionFontRichTExtBoxGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectionFontRichTExtBoxGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjSelectionFontRichTExtBoxGroupBox.Location = New System.Drawing.Point(0, 166)
            Me.mobjSelectionFontRichTExtBoxGroupBox.Name = "demoSelectionFontRichTExtBoxGroupBox"
            Me.mobjSelectionFontRichTExtBoxGroupBox.Size = New System.Drawing.Size(500, 166)
            Me.mobjSelectionFontRichTExtBoxGroupBox.TabIndex = 9
            Me.mobjSelectionFontRichTExtBoxGroupBox.TabStop = False
            Me.mobjSelectionFontRichTExtBoxGroupBox.Text = "Changing selection Font property for RichTextBox"
            '
            'mobjTLP2
            '
            Me.mobjTLP2.ColumnCount = 2
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0!))
            Me.mobjTLP2.Controls.Add(Me.mobjSelectionFontButton, 1, 0)
            Me.mobjTLP2.Controls.Add(Me.mobjSelectionFontLabel, 0, 0)
            Me.mobjTLP2.Controls.Add(Me.mobjSelectionFontRichTextBox, 0, 1)
            Me.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP2.Location = New System.Drawing.Point(3, 17)
            Me.mobjTLP2.Name = "mobjTLP2"
            Me.mobjTLP2.RowCount = 2
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75.0!))
            Me.mobjTLP2.Size = New System.Drawing.Size(494, 146)
            Me.mobjTLP2.TabIndex = 12
            '
            'mobjMultiLineRichTExtBoxGroupBox
            '
            Me.mobjMultiLineRichTExtBoxGroupBox.Controls.Add(Me.mobjTLP3)
            Me.mobjMultiLineRichTExtBoxGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMultiLineRichTExtBoxGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjMultiLineRichTExtBoxGroupBox.Location = New System.Drawing.Point(0, 332)
            Me.mobjMultiLineRichTExtBoxGroupBox.Name = "demoMultiLineRichTExtBoxGroupBox"
            Me.mobjMultiLineRichTExtBoxGroupBox.Size = New System.Drawing.Size(500, 168)
            Me.mobjMultiLineRichTExtBoxGroupBox.TabIndex = 10
            Me.mobjMultiLineRichTExtBoxGroupBox.TabStop = False
            Me.mobjMultiLineRichTExtBoxGroupBox.Text = "Changing selection property for RichTextBox"
            '
            'mobjTLP3
            '
            Me.mobjTLP3.ColumnCount = 1
            Me.mobjTLP3.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP3.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0!))
            Me.mobjTLP3.Controls.Add(Me.mobjMultiLineRichTextBox, 0, 1)
            Me.mobjTLP3.Controls.Add(Me.mobjMultiLineCheckBox, 0, 0)
            Me.mobjTLP3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP3.Location = New System.Drawing.Point(3, 17)
            Me.mobjTLP3.Name = "mobjTLP3"
            Me.mobjTLP3.RowCount = 2
            Me.mobjTLP3.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP3.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75.0!))
            Me.mobjTLP3.Size = New System.Drawing.Size(494, 148)
            Me.mobjTLP3.TabIndex = 12
            '
            'mobjTLPMain
            '
            Me.mobjTLPMain.ColumnCount = 1
            Me.mobjTLPMain.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLPMain.Controls.Add(Me.mobjFontRichTExtBoxGroupBox, 0, 0)
            Me.mobjTLPMain.Controls.Add(Me.mobjMultiLineRichTExtBoxGroupBox, 0, 2)
            Me.mobjTLPMain.Controls.Add(Me.mobjSelectionFontRichTExtBoxGroupBox, 0, 1)
            Me.mobjTLPMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLPMain.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLPMain.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLPMain.Name = "mobjTLPMain"
            Me.mobjTLPMain.RowCount = 3
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLPMain.Size = New System.Drawing.Size(500, 500)
            Me.mobjTLPMain.TabIndex = 11
            '
            'ControlPropertiesPage
            '
            Me.Controls.Add(Me.mobjTLPMain)
            Me.Size = New System.Drawing.Size(500, 500)
            Me.Text = "ControlPropertiesPage"
            Me.mobjFontRichTExtBoxGroupBox.ResumeLayout(False)
            Me.mobjTLP1.ResumeLayout(False)
            Me.mobjSelectionFontRichTExtBoxGroupBox.ResumeLayout(False)
            Me.mobjTLP2.ResumeLayout(False)
            Me.mobjMultiLineRichTExtBoxGroupBox.ResumeLayout(False)
            Me.mobjTLP3.ResumeLayout(False)
            Me.mobjTLPMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjFontLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjFontButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjFontRichTextBox As Gizmox.WebGUI.Forms.RichTextBox
        Friend WithEvents mobjSelectionFontLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjSelectionFontButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjSelectionFontRichTextBox As Gizmox.WebGUI.Forms.RichTextBox
        Friend WithEvents mobjMultiLineCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjMultiLineRichTextBox As Gizmox.WebGUI.Forms.RichTextBox
        Friend WithEvents mobjFontRichTExtBoxGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjSelectionFontRichTExtBoxGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjMultiLineRichTExtBoxGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjTLPMain As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLP1 As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLP2 As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLP3 As Gizmox.WebGUI.Forms.TableLayoutPanel
	End Class

End Namespace
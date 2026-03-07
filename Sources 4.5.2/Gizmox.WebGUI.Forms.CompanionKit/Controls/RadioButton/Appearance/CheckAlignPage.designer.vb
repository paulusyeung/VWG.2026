Namespace CompanionKit.Controls.RadioButton.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckAlignPage
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
            Me.mobjRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTextComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjRadioLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjRadioButton
            ' 
            Me.mobjRadioButton.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Blue)
            Me.mobjRadioButton.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjRadioButton.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(2)
            Me.mobjRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRadioButton.Location = New System.Drawing.Point(114, 27)
            Me.mobjRadioButton.Name = "mobjRadioButton"
            Me.mobjRadioButton.Size = New System.Drawing.Size(342, 81)
            Me.mobjRadioButton.TabIndex = 0
            Me.mobjRadioButton.Text = "Test Check Alignment"
            ' 
            ' mobjRadioComboBox
            ' 
            Me.mobjRadioComboBox.AllowDrag = False
            Me.mobjRadioComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioComboBox.FormattingEnabled = True
            Me.mobjRadioComboBox.Items.AddRange(New Object() {"TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", _
             "BottomLeft", "BottomCenter", "BottomRight"})
            Me.mobjRadioComboBox.Location = New System.Drawing.Point(116, 38)
            Me.mobjRadioComboBox.Name = "mobjRadioComboBox"
            Me.mobjRadioComboBox.Size = New System.Drawing.Size(141, 30)
            Me.mobjRadioComboBox.TabIndex = 1
            ' 
            ' mobjTextComboBox
            ' 
            Me.mobjTextComboBox.AllowDrag = False
            Me.mobjTextComboBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTextComboBox.FormattingEnabled = True
            Me.mobjTextComboBox.Items.AddRange(New Object() {"TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", _
             "BottomLeft", "BottomCenter", "BottomRight"})
            Me.mobjTextComboBox.Location = New System.Drawing.Point(116, 95)
            Me.mobjTextComboBox.Name = "mobjTextComboBox"
            Me.mobjTextComboBox.Size = New System.Drawing.Size(141, 30)
            Me.mobjTextComboBox.TabIndex = 2
            ' 
            ' mobjTextLabel
            ' 
            Me.mobjTextLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTextLabel.AutoSize = True
            Me.mobjTextLabel.Location = New System.Drawing.Point(113, 17)
            Me.mobjTextLabel.Name = "mobjTextLabel"
            Me.mobjTextLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjTextLabel.TabIndex = 3
            Me.mobjTextLabel.Text = "Text"
            ' 
            ' mobjRadioLabel
            ' 
            Me.mobjRadioLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioLabel.AutoSize = True
            Me.mobjRadioLabel.Location = New System.Drawing.Point(113, 72)
            Me.mobjRadioLabel.Name = "mobjRadioLabel"
            Me.mobjRadioLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjRadioLabel.TabIndex = 4
            Me.mobjRadioLabel.Text = "Radio Box"
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjRadioComboBox)
            Me.mobjGroupBox.Controls.Add(Me.mobjTextLabel)
            Me.mobjGroupBox.Controls.Add(Me.mobjRadioLabel)
            Me.mobjGroupBox.Controls.Add(Me.mobjTextComboBox)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(114, 128)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(190, 103)
            Me.mobjGroupBox.TabIndex = 5
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "Alignment"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGroupBox, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjRadioButton, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(571, 293)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' CheckAlignPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(571, 293)
            Me.Text = "CheckAlignPage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjRadioButton As Global.Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRadioComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjTextComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjTextLabel As Gizmox.WebGUI.Forms.Label
        Private mobjRadioLabel As Gizmox.WebGUI.Forms.Label
        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

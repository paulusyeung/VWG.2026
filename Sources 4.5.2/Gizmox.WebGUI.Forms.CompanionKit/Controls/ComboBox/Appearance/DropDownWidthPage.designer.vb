Namespace CompanionKit.Controls.ComboBox.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DropDownWidthPage
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
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjDropDownWidthLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"Item1", "Item2", "Item3", "Item4", "Item5"})
            Me.mobjComboBox.Location = New System.Drawing.Point(45, 165)
            Me.mobjComboBox.Name = "objComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjComboBox.TabIndex = 0
            Me.mobjComboBox.Text = "Item1"
            ' 
            ' mobjNumericUpDown
            ' 
            Me.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNumericUpDown.CurrentValue = New Decimal(New Integer() {40, 0, 0, 0})
            Me.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNumericUpDown.Location = New System.Drawing.Point(45, 65)
            Me.mobjNumericUpDown.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
            Me.mobjNumericUpDown.Minimum = New Decimal(New Integer() {40, 0, 0, 0})
            Me.mobjNumericUpDown.Name = "objNumericUpDown"
            Me.mobjNumericUpDown.Size = New System.Drawing.Size(200, 21)
            Me.mobjNumericUpDown.TabIndex = 1
            Me.mobjNumericUpDown.Value = New Decimal(New Integer() {40, 0, 0, 0})
            ' 
            ' mobjDropDownWidthLabel
            ' 
            Me.mobjDropDownWidthLabel.AutoSize = True
            Me.mobjDropDownWidthLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDropDownWidthLabel.Location = New System.Drawing.Point(45, 15)
            Me.mobjDropDownWidthLabel.Name = "objDropDownWidthLabel"
            Me.mobjDropDownWidthLabel.Size = New System.Drawing.Size(200, 50)
            Me.mobjDropDownWidthLabel.TabIndex = 2
            Me.mobjDropDownWidthLabel.Text = "DropDownWidth:"
            Me.mobjDropDownWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjComboBoxLabel
            ' 
            Me.mobjComboBoxLabel.AutoSize = True
            Me.mobjComboBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBoxLabel.Location = New System.Drawing.Point(45, 115)
            Me.mobjComboBoxLabel.Name = "objComboBoxLabel"
            Me.mobjComboBoxLabel.Size = New System.Drawing.Size(200, 50)
            Me.mobjComboBoxLabel.TabIndex = 3
            Me.mobjComboBoxLabel.Text = "ComboBox:"
            Me.mobjComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDropDownWidthLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBoxLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNumericUpDown, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(291, 210)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' DropDownWidthPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(291, 210)
            Me.Text = "DropDownWidthPage"
            DirectCast(Me.mobjNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private mobjDropDownWidthLabel As Gizmox.WebGUI.Forms.Label
        Private mobjComboBoxLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace
Namespace CompanionKit.Controls.ComboBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MaxItemsInDropDownPage
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
            Me.mobjCurrentMaxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjMaxComboBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjCurrentMaxLabel
            ' 
            Me.mobjCurrentMaxLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjCurrentMaxLabel, 3)
            Me.mobjCurrentMaxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCurrentMaxLabel.Location = New System.Drawing.Point(0, 22)
            Me.mobjCurrentMaxLabel.Name = "label1"
            Me.mobjCurrentMaxLabel.Size = New System.Drawing.Size(379, 50)
            Me.mobjCurrentMaxLabel.TabIndex = 0
            Me.mobjCurrentMaxLabel.Text = "Current MaxDropDownItems"
            Me.mobjCurrentMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextBox.Location = New System.Drawing.Point(92, 75)
            Me.mobjTextBox.Name = "textBox1"
            Me.mobjTextBox.Size = New System.Drawing.Size(194, 34)
            Me.mobjTextBox.TabIndex = 1
            ' 
            ' mobjMaxComboBoxLabel
            ' 
            Me.mobjMaxComboBoxLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjMaxComboBoxLabel, 3)
            Me.mobjMaxComboBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaxComboBoxLabel.Location = New System.Drawing.Point(0, 132)
            Me.mobjMaxComboBoxLabel.Name = "label2"
            Me.mobjMaxComboBoxLabel.Size = New System.Drawing.Size(379, 50)
            Me.mobjMaxComboBoxLabel.TabIndex = 2
            Me.mobjMaxComboBoxLabel.Text = "ComboBox"
            Me.mobjMaxComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", _
             "G item", "I item", "J item", "K item", "L item", "M item", _
             "N item", "O item", "P item", "Q item", "R item", "S item", _
             "T item", "U item", "V item", "W item", "X item", "Y item", _
             "Z item"})
            Me.mobjComboBox.Location = New System.Drawing.Point(89, 182)
            Me.mobjComboBox.Name = "comboBox1"
            Me.mobjComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjComboBox.TabIndex = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCurrentMaxLabel, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaxComboBoxLabel, 0, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(379, 234)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' MaxItemsInDropDownPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(379, 234)
            Me.Text = "MaxItemsInDropDownPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjCurrentMaxLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjMaxComboBoxLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

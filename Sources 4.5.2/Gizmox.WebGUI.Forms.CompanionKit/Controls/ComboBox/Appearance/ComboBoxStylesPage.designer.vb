Namespace CompanionKit.Controls.ComboBox.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ComboBoxStylesPage
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
            Me.mobjSimpleComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjSimpleLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDesciptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDropDownLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDropDownComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjDropDownListComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjDropDownListLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjSimpleComboBox
            ' 
            Me.mobjSimpleComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjSimpleComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSimpleComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.Simple
            Me.mobjSimpleComboBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", _
             "G item", "I item", "J item", "K item", "L item", "M item", _
             "N item", "O item", "P item", "Q item", "R item", "S item", _
             "T item", "U item", "V item", "W item", "X item", "Y item", _
             "Z item"})
            Me.mobjSimpleComboBox.Location = New System.Drawing.Point(127, 76)
            Me.mobjSimpleComboBox.Name = "comboBox2"
            Me.mobjSimpleComboBox.Size = New System.Drawing.Size(200, 100)
            Me.mobjSimpleComboBox.TabIndex = 1
            ' 
            ' mobjSimpleLabel
            ' 
            Me.mobjSimpleLabel.AutoSize = True
            Me.mobjSimpleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSimpleLabel.Location = New System.Drawing.Point(127, 46)
            Me.mobjSimpleLabel.Name = "label2"
            Me.mobjSimpleLabel.Size = New System.Drawing.Size(200, 30)
            Me.mobjSimpleLabel.TabIndex = 3
            Me.mobjSimpleLabel.Text = "Simple"
            Me.mobjSimpleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDesciptionLabel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDesciptionLabel, 3)
            Me.mobjDesciptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDesciptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDesciptionLabel.Name = "desciptionLabel"
            Me.mobjDesciptionLabel.Size = New System.Drawing.Size(455, 46)
            Me.mobjDesciptionLabel.TabIndex = 4
            Me.mobjDesciptionLabel.Text = "See below how the DropDownStyle property affects appearence and functionality of " + "ComboBox control:"
            Me.mobjDesciptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjDropDownLabel
            ' 
            Me.mobjDropDownLabel.AutoSize = True
            Me.mobjDropDownLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDropDownLabel.Location = New System.Drawing.Point(127, 196)
            Me.mobjDropDownLabel.Name = "label1"
            Me.mobjDropDownLabel.Size = New System.Drawing.Size(200, 30)
            Me.mobjDropDownLabel.TabIndex = 3
            Me.mobjDropDownLabel.Text = "DropDown"
            Me.mobjDropDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDropDownComboBox
            ' 
            Me.mobjDropDownComboBox.AllowDrag = False
            Me.mobjDropDownComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjDropDownComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDropDownComboBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", _
             "G item", "I item", "J item", "K item", "L item", "M item", _
             "N item", "O item", "P item", "Q item", "R item", "S item", _
             "T item", "U item", "V item", "W item", "X item", "Y item", _
             "Z item"})
            Me.mobjDropDownComboBox.Location = New System.Drawing.Point(127, 226)
            Me.mobjDropDownComboBox.Name = "comboBox1"
            Me.mobjDropDownComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjDropDownComboBox.TabIndex = 1
            ' 
            ' mobjDropDownListComboBox
            ' 
            Me.mobjDropDownListComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjDropDownListComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDropDownListComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjDropDownListComboBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", _
             "G item", "I item", "J item", "K item", "L item", "M item", _
             "N item", "O item", "P item", "Q item", "R item", "S item", _
             "T item", "U item", "V item", "W item", "X item", "Y item", _
             "Z item"})
            Me.mobjDropDownListComboBox.Location = New System.Drawing.Point(127, 306)
            Me.mobjDropDownListComboBox.Name = "comboBox3"
            Me.mobjDropDownListComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjDropDownListComboBox.TabIndex = 1
            ' 
            ' mobjDropDownListLabel
            ' 
            Me.mobjDropDownListLabel.AutoSize = True
            Me.mobjDropDownListLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDropDownListLabel.Location = New System.Drawing.Point(127, 276)
            Me.mobjDropDownListLabel.Name = "label3"
            Me.mobjDropDownListLabel.Size = New System.Drawing.Size(200, 30)
            Me.mobjDropDownListLabel.TabIndex = 3
            Me.mobjDropDownListLabel.Text = "DropDownList"
            Me.mobjDropDownListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSimpleComboBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDropDownListComboBox, 1, 8)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDropDownListLabel, 1, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSimpleLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDropDownLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDropDownComboBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDesciptionLabel, 0, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(5, 5)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 10
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(455, 383)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' ComboBoxStylesPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.DockPadding.All = 5
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.Size = New System.Drawing.Size(465, 393)
            Me.Text = "ComboBoxStylesPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjSimpleComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjSimpleLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDesciptionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDropDownLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDropDownComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjDropDownListComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjDropDownListLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

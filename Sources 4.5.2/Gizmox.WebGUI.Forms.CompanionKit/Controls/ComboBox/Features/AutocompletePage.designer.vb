Namespace CompanionKit.Controls.ComboBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AutocompletePage
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
            Me.mobjComboBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjAutoCompleteComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjOptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjComboBoxLabel
            ' 
            Me.mobjComboBoxLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjComboBoxLabel, 3)
            Me.mobjComboBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBoxLabel.Location = New System.Drawing.Point(0, 21)
            Me.mobjComboBoxLabel.Name = "label1"
            Me.mobjComboBoxLabel.Size = New System.Drawing.Size(339, 50)
            Me.mobjComboBoxLabel.TabIndex = 0
            Me.mobjComboBoxLabel.Text = "AutoCompleted ComboBox"
            Me.mobjComboBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.AutoCompleteSource = Gizmox.WebGUI.Forms.AutoCompleteSource.ListItems
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.Items.AddRange(New Object() {"A item", "B item", "C item", "D item", "E item", "F item", _
             "G item", "I item", "J item", "K item", "L item", "M item", _
             "N item", "O item", "P item", "Q item", "R item", "S item", _
             "T item", "U item", "V item", "W item", "X item", "Y item", _
             "Z item"})
            Me.mobjComboBox.Location = New System.Drawing.Point(69, 71)
            Me.mobjComboBox.Name = "comboBox1"
            Me.mobjComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjComboBox.TabIndex = 1
            ' 
            ' mobjAutoCompleteComboBox
            ' 
            Me.mobjAutoCompleteComboBox.AutoCompleteSource = Gizmox.WebGUI.Forms.AutoCompleteSource.ListItems
            Me.mobjAutoCompleteComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjAutoCompleteComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAutoCompleteComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjAutoCompleteComboBox.Items.AddRange(New Object() {"None", "Suggest", "Append", "SuggestAppend"})
            Me.mobjAutoCompleteComboBox.Location = New System.Drawing.Point(69, 171)
            Me.mobjAutoCompleteComboBox.Name = "mobjAutoCompleteComboBox"
            Me.mobjAutoCompleteComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjAutoCompleteComboBox.TabIndex = 1
            Me.mobjAutoCompleteComboBox.Text = "None"
            ' 
            ' mobjOptionLabel
            ' 
            Me.mobjOptionLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjOptionLabel, 3)
            Me.mobjOptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOptionLabel.Location = New System.Drawing.Point(0, 121)
            Me.mobjOptionLabel.Name = "label2"
            Me.mobjOptionLabel.Size = New System.Drawing.Size(339, 50)
            Me.mobjOptionLabel.TabIndex = 0
            Me.mobjOptionLabel.Text = "AutoComplete Options"
            Me.mobjOptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAutoCompleteComboBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBoxLabel, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOptionLabel, 0, 4)
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(339, 223)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' AutocompletePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(339, 223)
            Me.Text = "AutocompletePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjComboBoxLabel As Gizmox.WebGUI.Forms.Label
        Private mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjAutoCompleteComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjOptionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

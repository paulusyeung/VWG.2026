Namespace CompanionKit.Controls.ComboBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ValueTextChangePage
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
            Me.components = New System.ComponentModel.Container()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjSelectLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjComboBoxTextTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjValueLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBoxTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.DataSource = Me.mobjBindingSource
            Me.mobjComboBox.DisplayMember = "Name"
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjComboBox.Name = "comboBox1"
            Me.mobjComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjComboBox.TabIndex = 0
            Me.mobjComboBox.ValueMember = "Name"
            ' 
            ' mobjBindingSource
            ' 
            Me.mobjBindingSource.DataSource = GetType(System.Drawing.Color)
            ' 
            ' mobjSelectLabel
            ' 
            Me.mobjSelectLabel.AutoSize = True
            Me.mobjSelectLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectLabel.Location = New System.Drawing.Point(10, 11)
            Me.mobjSelectLabel.Name = "label1"
            Me.mobjSelectLabel.Size = New System.Drawing.Size(254, 50)
            Me.mobjSelectLabel.TabIndex = 1
            Me.mobjSelectLabel.Text = "Select ComboBox"
            Me.mobjSelectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjValueTextBox
            ' 
            Me.mobjValueTextBox.AllowDrag = False
            Me.mobjValueTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueTextBox.Location = New System.Drawing.Point(267, 84)
            Me.mobjValueTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueTextBox.Name = "textBox1"
            Me.mobjValueTextBox.[ReadOnly] = True
            Me.mobjValueTextBox.Size = New System.Drawing.Size(200, 24)
            Me.mobjValueTextBox.TabIndex = 2
            ' 
            ' mobjComboBoxTextTextBox
            ' 
            Me.mobjComboBoxTextTextBox.AllowDrag = False
            Me.mobjComboBoxTextTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBoxTextTextBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjComboBoxTextTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjComboBoxTextTextBox.Name = "textBox2"
            Me.mobjComboBoxTextTextBox.[ReadOnly] = True
            Me.mobjComboBoxTextTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjComboBoxTextTextBox.TabIndex = 3
            ' 
            ' mobjValueLabel
            ' 
            Me.mobjValueLabel.AutoSize = True
            Me.mobjValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueLabel.Location = New System.Drawing.Point(10, 81)
            Me.mobjValueLabel.Name = "label2"
            Me.mobjValueLabel.Size = New System.Drawing.Size(254, 30)
            Me.mobjValueLabel.TabIndex = 4
            Me.mobjValueLabel.Text = "Selected Value"
            Me.mobjValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjComboBoxTextLabel
            ' 
            Me.mobjComboBoxTextLabel.AutoSize = True
            Me.mobjComboBoxTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBoxTextLabel.Location = New System.Drawing.Point(10, 131)
            Me.mobjComboBoxTextLabel.Name = "label3"
            Me.mobjComboBoxTextLabel.Size = New System.Drawing.Size(254, 50)
            Me.mobjComboBoxTextLabel.TabIndex = 5
            Me.mobjComboBoxTextLabel.Text = "Text of ComboBox"
            Me.mobjComboBoxTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjTextLabel
            ' 
            Me.mobjTextLabel.AutoSize = True
            Me.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLabel.Location = New System.Drawing.Point(10, 201)
            Me.mobjTextLabel.Name = "mobjTextLabel"
            Me.mobjTextLabel.Size = New System.Drawing.Size(254, 30)
            Me.mobjTextLabel.TabIndex = 6
            Me.mobjTextLabel.Text = "Text"
            Me.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjTextTextBox
            ' 
            Me.mobjTextTextBox.AllowDrag = False
            Me.mobjTextTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextTextBox.Location = New System.Drawing.Point(267, 204)
            Me.mobjTextTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextTextBox.Name = "mobjTextTextBox"
            Me.mobjTextTextBox.Size = New System.Drawing.Size(200, 24)
            Me.mobjTextTextBox.TabIndex = 3
            Me.mobjTextTextBox.Text = "ActiveBorder"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSelectLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextLabel, 1, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextTextBox, 2, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBoxTextLabel, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueTextBox, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 2, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 2, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 9
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(529, 242)
            Me.mobjLayoutPanel.TabIndex = 7
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjComboBoxTextTextBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.DockPadding.Bottom = 10
            Me.mobjPanel.DockPadding.Top = 10
            Me.mobjPanel.Location = New System.Drawing.Point(264, 131)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjPanel.Size = New System.Drawing.Size(254, 50)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjComboBox)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.DockPadding.Bottom = 10
            Me.mobjTopPanel.DockPadding.Top = 10
            Me.mobjTopPanel.Location = New System.Drawing.Point(264, 11)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjTopPanel.Size = New System.Drawing.Size(254, 50)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' ValueTextChangePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(529, 242)
            Me.Text = "ValueTextChangePage"
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjSelectLabel As Gizmox.WebGUI.Forms.Label
        Private mobjValueTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjComboBoxTextTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjValueLabel As Gizmox.WebGUI.Forms.Label
        Private mobjComboBoxTextLabel As Gizmox.WebGUI.Forms.Label
        Private mobjTextLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

Namespace CompanionKit.Controls.ComboBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ForceSelectedIndexChangedOnClickPage
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
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextBox.Location = New System.Drawing.Point(82, 159)
            Me.mobjTextBox.Multiline = True
            Me.mobjTextBox.Name = "objTextBox"
            Me.mobjTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical
            Me.mobjTextBox.Size = New System.Drawing.Size(362, 117)
            Me.mobjTextBox.TabIndex = 2
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"Item1", "Item2", "Item3", "Item4", "Item5", "Item6"})
            Me.mobjComboBox.Location = New System.Drawing.Point(79, 106)
            Me.mobjComboBox.Name = "objComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(368, 21)
            Me.mobjComboBox.TabIndex = 0
            Me.mobjComboBox.Text = "Item1"
            ' 
            ' mobjCheckBox
            ' 
            Me.mobjCheckBox.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjCheckBox, 2)
            Me.mobjCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckBox.Location = New System.Drawing.Point(79, 26)
            Me.mobjCheckBox.Name = "objCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(448, 80)
            Me.mobjCheckBox.TabIndex = 1
            Me.mobjCheckBox.Text = "Force to fire SelectedIndexChanged on click"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCheckBox, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBox, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(527, 306)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' ForceSelectedIndexChangedOnClickPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(527, 306)
            Me.Text = "ForceSelectedIndexChangedOnClickPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace
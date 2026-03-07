Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ExtendedHeadersPage
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
            Dim DataGridViewCellStyle7 As Gizmox.WebGUI.Forms.DataGridViewCellStyle = New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As Gizmox.WebGUI.Forms.DataGridViewCellStyle = New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As Gizmox.WebGUI.Forms.DataGridViewCellStyle = New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDGV = New Gizmox.WebGUI.Forms.DataGridView()
            Me.Column1 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.Column2 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.Column3 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjColIndexLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIsExtHeaderVisible = New Gizmox.WebGUI.Forms.CheckBox()
            CType(Me.mobjDGV, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.mobjNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.AccessibleDescription = ""
            Me.mobjInfoLabel.AccessibleName = ""
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(419, 61)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "Extended Header contains two buttons for adding and removing rows in DataGridView" & _
        ". Use NumericUpDown to change the number of column extended header belongs to:"
            '
            'mobjDGV
            '
            Me.mobjDGV.AccessibleDescription = ""
            Me.mobjDGV.AccessibleName = ""
            Me.mobjDGV.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
            Me.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDGV.ExtendedColumnHeaders.ShowExtendedColumnHeader = True
            Me.mobjDGV.Location = New System.Drawing.Point(0, 61)
            Me.mobjDGV.Name = "mobjDGV"
            Me.mobjDGV.Size = New System.Drawing.Size(419, 273)
            Me.mobjDGV.TabIndex = 2
            '
            'Column1
            '
            Me.Column1.DefaultCellStyle = DataGridViewCellStyle7
            Me.Column1.Name = "Column1"
            '
            'Column2
            '
            Me.Column2.DefaultCellStyle = DataGridViewCellStyle8
            Me.Column2.Name = "Column2"
            '
            'Column3
            '
            Me.Column3.DefaultCellStyle = DataGridViewCellStyle9
            Me.Column3.Name = "Column3"
            '
            'mobjNUD
            '
            Me.mobjNUD.AccessibleDescription = ""
            Me.mobjNUD.AccessibleName = ""
            Me.mobjNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNUD.CurrentValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjNUD.Location = New System.Drawing.Point(165, 354)
            Me.mobjNUD.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
            Me.mobjNUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjNUD.Name = "mobjNUD"
            Me.mobjNUD.Size = New System.Drawing.Size(120, 21)
            Me.mobjNUD.TabIndex = 3
            Me.mobjNUD.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'mobjColIndexLabel
            '
            Me.mobjColIndexLabel.AccessibleDescription = ""
            Me.mobjColIndexLabel.AccessibleName = ""
            Me.mobjColIndexLabel.Location = New System.Drawing.Point(29, 356)
            Me.mobjColIndexLabel.Name = "mobjColIndexLabel"
            Me.mobjColIndexLabel.Size = New System.Drawing.Size(136, 23)
            Me.mobjColIndexLabel.TabIndex = 4
            Me.mobjColIndexLabel.Text = "Column Number:"
            '
            'mobjIsExtHeaderVisible
            '
            Me.mobjIsExtHeaderVisible.AccessibleDescription = ""
            Me.mobjIsExtHeaderVisible.AccessibleName = ""
            Me.mobjIsExtHeaderVisible.Checked = True
            Me.mobjIsExtHeaderVisible.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjIsExtHeaderVisible.Location = New System.Drawing.Point(32, 406)
            Me.mobjIsExtHeaderVisible.Name = "mobjIsExtHeaderVisible"
            Me.mobjIsExtHeaderVisible.Size = New System.Drawing.Size(253, 41)
            Me.mobjIsExtHeaderVisible.TabIndex = 5
            Me.mobjIsExtHeaderVisible.Text = "Show Extended Column Header"
            '
            'ExtendedHeadersPage
            '
            Me.Controls.Add(Me.mobjIsExtHeaderVisible)
            Me.Controls.Add(Me.mobjColIndexLabel)
            Me.Controls.Add(Me.mobjNUD)
            Me.Controls.Add(Me.mobjDGV)
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Size = New System.Drawing.Size(391, 460)
            Me.Text = "ExtendedHeadersPage"
            CType(Me.mobjDGV, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.mobjNUD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjDGV As Gizmox.WebGUI.Forms.DataGridView
        Private WithEvents Column1 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private WithEvents Column2 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private WithEvents Column3 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private WithEvents mobjNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjColIndexLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjIsExtHeaderVisible As Gizmox.WebGUI.Forms.CheckBox

	End Class

End Namespace
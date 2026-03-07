Namespace CompanionKit.Concepts.ClientAPI.FillingDataGridView

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FillingDataGridViewPage
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
            Dim DataGridViewCellStyle1 As Gizmox.WebGUI.Forms.DataGridViewCellStyle = New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As Gizmox.WebGUI.Forms.DataGridViewCellStyle = New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Me.objDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.Id = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.Value = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.objNumericUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.objButton = New Gizmox.WebGUI.Forms.Button()
            Me.objRightPanel = New Gizmox.WebGUI.Forms.Panel()
            CType(Me.objDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.objNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.objRightPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objDataGridView
            '
            Me.objDataGridView.AllowDrag = False
            Me.objDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.objDataGridView.ClientId = "dvg"
            Me.objDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.Id, Me.Value})
            Me.objDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objDataGridView.Location = New System.Drawing.Point(15, 15)
            Me.objDataGridView.Name = "objDataGridView"
            Me.objDataGridView.Size = New System.Drawing.Size(261, 153)
            Me.objDataGridView.TabIndex = 0
            '
            'Id
            '
            Me.Id.AllowRowFiltering = False
            Me.Id.CanGroupBy = False
            Me.Id.ClientId = "colId"
            Me.Id.DefaultCellStyle = DataGridViewCellStyle1
            Me.Id.Name = "Id"
            Me.Id.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            Me.Id.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'Value
            '
            Me.Value.AllowRowFiltering = False
            Me.Value.CanGroupBy = False
            Me.Value.ClientId = "colVal"
            Me.Value.DefaultCellStyle = DataGridViewCellStyle2
            Me.Value.Name = "Value"
            Me.Value.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            Me.Value.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'objNumericUpDown
            '
            Me.objNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.objNumericUpDown.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.objNumericUpDown.ClientId = "nud"
            Me.objNumericUpDown.CurrentValue = New Decimal(New Integer() {10, 0, 0, 0})
            Me.objNumericUpDown.Location = New System.Drawing.Point(17, 12)
            Me.objNumericUpDown.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
            Me.objNumericUpDown.Name = "objNumericUpDown"
            Me.objNumericUpDown.Size = New System.Drawing.Size(120, 16)
            Me.objNumericUpDown.TabIndex = 2
            Me.objNumericUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
            '
            'objButton
            '
            Me.objButton.Location = New System.Drawing.Point(17, 49)
            Me.objButton.Name = "objButton"
            Me.objButton.Size = New System.Drawing.Size(120, 26)
            Me.objButton.TabIndex = 1
            Me.objButton.Text = "Fill Grid"
            '
            'objRightPanel
            '
            Me.objRightPanel.Controls.Add(Me.objNumericUpDown)
            Me.objRightPanel.Controls.Add(Me.objButton)
            Me.objRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objRightPanel.Location = New System.Drawing.Point(15, 168)
            Me.objRightPanel.Name = "objRightPanel"
            Me.objRightPanel.Size = New System.Drawing.Size(265, 90)
            Me.objRightPanel.TabIndex = 3
            '
            'FillingDataGridViewPage
            '
            Me.Controls.Add(Me.objDataGridView)
            Me.Controls.Add(Me.objRightPanel)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(295, 273)
            CType(Me.objDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.objNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.objRightPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objDataGridView As Gizmox.WebGUI.Forms.DataGridView
        Private WithEvents Id As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private WithEvents Value As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private WithEvents objNumericUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents objButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objRightPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace
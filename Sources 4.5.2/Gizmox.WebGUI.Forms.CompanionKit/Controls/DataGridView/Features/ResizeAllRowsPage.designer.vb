Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ResizeAllRowsPage
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
            Dim dataGridViewCellStyle4 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle5 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle6 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDGV = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjColumn1 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjColumn2 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjColumn3 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjResizeAllCB = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjStandardTabCB = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjDGV, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(591, 100)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Change the values of ResizeAllRows and StandardTab properties using CheckBoxes:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDGV
            ' 
            Me.mobjDGV.AllowDrag = False
            Me.mobjDGV.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjColumn1, Me.mobjColumn2, Me.mobjColumn3})
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDGV, 2)
            Me.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDGV.Location = New System.Drawing.Point(0, 100)
            Me.mobjDGV.Name = "mobjDGV"
            Me.mobjDGV.Size = New System.Drawing.Size(591, 298)
            Me.mobjDGV.TabIndex = 1
            ' 
            ' mobjColumn1
            ' 
            Me.mobjColumn1.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjColumn1.Name = "mobjColumn1"
            ' 
            ' mobjColumn2
            ' 
            Me.mobjColumn2.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjColumn2.Name = "mobjColumn2"
            ' 
            ' mobjColumn3
            ' 
            Me.mobjColumn3.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjColumn3.Name = "mobjColumn3"
            ' 
            ' mobjResizeAllCB
            ' 
            Me.mobjResizeAllCB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjResizeAllCB.Location = New System.Drawing.Point(0, 398)
            Me.mobjResizeAllCB.Name = "mobjResizeAllCB"
            Me.mobjResizeAllCB.Size = New System.Drawing.Size(295, 60)
            Me.mobjResizeAllCB.TabIndex = 2
            Me.mobjResizeAllCB.Text = "EnforceEqualRowSize"
            ' 
            ' mobjStandardTabCB
            ' 
            Me.mobjStandardTabCB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStandardTabCB.Location = New System.Drawing.Point(295, 398)
            Me.mobjStandardTabCB.Name = "mobjStandardTabCB"
            Me.mobjStandardTabCB.Size = New System.Drawing.Size(296, 60)
            Me.mobjStandardTabCB.TabIndex = 3
            Me.mobjStandardTabCB.Text = "StandardTab"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 2
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjStandardTabCB, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDGV, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjResizeAllCB, 0, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(591, 458)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' ResizeAllRowsPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(591, 458)
            Me.Text = "ResizeAllRowsPage"
            DirectCast(Me.mobjDGV, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDGV As Gizmox.WebGUI.Forms.DataGridView
        Private WithEvents mobjResizeAllCB As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjStandardTabCB As Gizmox.WebGUI.Forms.CheckBox
        Private mobjColumn1 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjColumn2 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjColumn3 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
	End Class

End Namespace
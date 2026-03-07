Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ValidationPage
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
            Dim dataGridViewCellStyle1 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle3 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle4 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle5 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle6 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle7 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle8 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle9 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Me.mobjDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjDataGridViewTextBoxColumn1 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn2 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn3 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn4 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn5 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn6 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn7 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn8 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn9 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjUserDS = New CompanionKit.Controls.DataGridView.UserDS()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDataGridView
            ' 
            Me.mobjDataGridView.AllowDrag = False
            Me.mobjDataGridView.AutoGenerateColumns = False
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjDataGridViewTextBoxColumn1, Me.mobjDataGridViewTextBoxColumn2, Me.mobjDataGridViewTextBoxColumn3, Me.mobjDataGridViewTextBoxColumn4, Me.mobjDataGridViewTextBoxColumn5, Me.mobjDataGridViewTextBoxColumn6, _
             Me.mobjDataGridViewTextBoxColumn7, Me.mobjDataGridViewTextBoxColumn8, Me.mobjDataGridViewTextBoxColumn9})
            Me.mobjDataGridView.DataSource = Me.mobjBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 50)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.Size = New System.Drawing.Size(639, 233)
            Me.mobjDataGridView.TabIndex = 1
            ' 
            ' mobjDataGridViewTextBoxColumn1
            ' 
            Me.mobjDataGridViewTextBoxColumn1.DataPropertyName = "UserId"
            Me.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1
            Me.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn1.HeaderText = "User ID"
            Me.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1"
            Me.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn2
            ' 
            Me.mobjDataGridViewTextBoxColumn2.DataPropertyName = "UserName"
            Me.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2
            Me.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn2.HeaderText = "User Name"
            Me.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2"
            Me.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn3
            ' 
            Me.mobjDataGridViewTextBoxColumn3.DataPropertyName = "UserEmail"
            Me.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3
            Me.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn3.HeaderText = "User Email"
            Me.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3"
            Me.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn4
            ' 
            Me.mobjDataGridViewTextBoxColumn4.DataPropertyName = "UserPhone"
            Me.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn4.HeaderText = "User Phone"
            Me.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4"
            Me.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn5
            ' 
            Me.mobjDataGridViewTextBoxColumn5.DataPropertyName = "UserCity"
            Me.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn5.HeaderText = "User City"
            Me.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5"
            Me.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn6
            ' 
            Me.mobjDataGridViewTextBoxColumn6.DataPropertyName = "UserAddress"
            Me.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn6.HeaderText = "User Address"
            Me.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6"
            Me.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn6.Width = 130
            ' 
            ' mobjDataGridViewTextBoxColumn7
            ' 
            Me.mobjDataGridViewTextBoxColumn7.DataPropertyName = "UserCountry"
            Me.mobjDataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7
            Me.mobjDataGridViewTextBoxColumn7.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn7.HeaderText = "User Country"
            Me.mobjDataGridViewTextBoxColumn7.Name = "mobjDataGridViewTextBoxColumn7"
            Me.mobjDataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn8
            ' 
            Me.mobjDataGridViewTextBoxColumn8.DataPropertyName = "UserState"
            Me.mobjDataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle8
            Me.mobjDataGridViewTextBoxColumn8.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn8.HeaderText = "User State"
            Me.mobjDataGridViewTextBoxColumn8.Name = "mobjDataGridViewTextBoxColumn8"
            Me.mobjDataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn9
            ' 
            Me.mobjDataGridViewTextBoxColumn9.DataPropertyName = "UserZipCode"
            Me.mobjDataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle9
            Me.mobjDataGridViewTextBoxColumn9.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn9.HeaderText = "User ZipCode"
            Me.mobjDataGridViewTextBoxColumn9.Name = "mobjDataGridViewTextBoxColumn9"
            Me.mobjDataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjBindingSource
            ' 
            Me.mobjBindingSource.DataMember = "Users"
            Me.mobjBindingSource.DataSource = Me.mobjUserDS
            ' 
            ' mobjUserDS
            ' 
            Me.mobjUserDS.DataSetName = "UserDS"
            Me.mobjUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(639, 50)
            Me.mobjLabel.TabIndex = 2
            Me.mobjLabel.Text = "DataGridView with validating of entered data"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataGridView, 0, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 2
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(639, 283)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' ValidationPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(639, 283)
            Me.Text = "ValidationPage"
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDataGridView As Global.Gizmox.WebGUI.Forms.DataGridView
        Private mobjDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
        Private mobjBindingSource As BindingSource
        Private mobjUserDS As CompanionKit.Controls.DataGridView.UserDS
        Private mobjLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

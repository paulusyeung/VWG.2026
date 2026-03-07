Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SelectionPage
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
            Dim dataGridViewCellStyle10 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle11 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle12 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle13 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle14 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle15 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle16 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle17 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle18 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
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
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSelectionModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSelectionModeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjComboPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjComboPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDataGridView
            ' 
            Me.mobjDataGridView.AllowDrag = False
            Me.mobjDataGridView.AutoGenerateColumns = False
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjDataGridViewTextBoxColumn1, Me.mobjDataGridViewTextBoxColumn2, Me.mobjDataGridViewTextBoxColumn3, Me.mobjDataGridViewTextBoxColumn4, Me.mobjDataGridViewTextBoxColumn5, Me.mobjDataGridViewTextBoxColumn6, _
             Me.mobjDataGridViewTextBoxColumn7, Me.mobjDataGridViewTextBoxColumn8, Me.mobjDataGridViewTextBoxColumn9})
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDataGridView, 3)
            Me.mobjDataGridView.DataSource = Me.mobjBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 100)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.Size = New System.Drawing.Size(631, 243)
            Me.mobjDataGridView.TabIndex = 1
            ' 
            ' mobjDataGridViewTextBoxColumn1
            ' 
            Me.mobjDataGridViewTextBoxColumn1.DataPropertyName = "UserId"
            Me.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10
            Me.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn1.HeaderText = "User ID"
            Me.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1"
            Me.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn2
            ' 
            Me.mobjDataGridViewTextBoxColumn2.DataPropertyName = "UserName"
            Me.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle11
            Me.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn2.HeaderText = "User Name"
            Me.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2"
            Me.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn3
            ' 
            Me.mobjDataGridViewTextBoxColumn3.DataPropertyName = "UserEmail"
            Me.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle12
            Me.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn3.HeaderText = "User Email"
            Me.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3"
            Me.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn4
            ' 
            Me.mobjDataGridViewTextBoxColumn4.DataPropertyName = "UserPhone"
            Me.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle13
            Me.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn4.HeaderText = "User Phone"
            Me.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4"
            Me.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn5
            ' 
            Me.mobjDataGridViewTextBoxColumn5.DataPropertyName = "UserCity"
            Me.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle14
            Me.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn5.HeaderText = "User City"
            Me.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5"
            Me.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn6
            ' 
            Me.mobjDataGridViewTextBoxColumn6.DataPropertyName = "UserAddress"
            Me.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle15
            Me.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn6.HeaderText = "User Address"
            Me.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6"
            Me.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn6.Width = 130
            ' 
            ' mobjDataGridViewTextBoxColumn7
            ' 
            Me.mobjDataGridViewTextBoxColumn7.DataPropertyName = "UserCountry"
            Me.mobjDataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle16
            Me.mobjDataGridViewTextBoxColumn7.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn7.HeaderText = "User Country"
            Me.mobjDataGridViewTextBoxColumn7.Name = "mobjDataGridViewTextBoxColumn7"
            Me.mobjDataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn8
            ' 
            Me.mobjDataGridViewTextBoxColumn8.DataPropertyName = "UserState"
            Me.mobjDataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle17
            Me.mobjDataGridViewTextBoxColumn8.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn8.HeaderText = "User State"
            Me.mobjDataGridViewTextBoxColumn8.Name = "mobjDataGridViewTextBoxColumn8"
            Me.mobjDataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn9
            ' 
            Me.mobjDataGridViewTextBoxColumn9.DataPropertyName = "UserZipCode"
            Me.mobjDataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle18
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
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDescriptionLabel, 3)
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 50)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(631, 50)
            Me.mobjDescriptionLabel.TabIndex = 2
            Me.mobjDescriptionLabel.Text = "DataGridView demonstrates selection modes"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjSelectionModeLabel
            ' 
            Me.mobjSelectionModeLabel.AutoSize = True
            Me.mobjSelectionModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectionModeLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSelectionModeLabel.Name = "mobjSelectionModeLabel"
            Me.mobjSelectionModeLabel.Size = New System.Drawing.Size(372, 50)
            Me.mobjSelectionModeLabel.TabIndex = 3
            Me.mobjSelectionModeLabel.Text = "Change the selection mode:"
            Me.mobjSelectionModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            ' 
            ' mobjSelectionModeComboBox
            ' 
            Me.mobjSelectionModeComboBox.AllowDrag = False
            Me.mobjSelectionModeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear
            Me.mobjSelectionModeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjSelectionModeComboBox.Location = New System.Drawing.Point(0, 19)
            Me.mobjSelectionModeComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjSelectionModeComboBox.MinimumSize = New System.Drawing.Size(0, 30)
            Me.mobjSelectionModeComboBox.Name = "mobjSelectionModeComboBox"
            Me.mobjSelectionModeComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjSelectionModeComboBox.TabIndex = 4
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataGridView, 0, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSelectionModeLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDescriptionLabel, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboPanel, 2, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(631, 343)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' mobjComboPanel
            ' 
            Me.mobjComboPanel.Controls.Add(Me.mobjSelectionModeComboBox)
            Me.mobjComboPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboPanel.DockPadding.Bottom = 10
            Me.mobjComboPanel.Location = New System.Drawing.Point(382, 0)
            Me.mobjComboPanel.Name = "mobjComboPanel"
            Me.mobjComboPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 0, 10)
            Me.mobjComboPanel.Size = New System.Drawing.Size(249, 50)
            Me.mobjComboPanel.TabIndex = 0
            ' 
            ' SelectionPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(631, 343)
            Me.Text = "SelectionPage"
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjComboPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDataGridView As Global.Gizmox.WebGUI.Forms.DataGridView
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
        Private mobjDescriptionLabel As Label
        Private mobjSelectionModeLabel As Label
        Private WithEvents mobjSelectionModeComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjComboPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

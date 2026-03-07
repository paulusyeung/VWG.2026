Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ResizingPage
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
            Dim dataGridViewCellStyle10 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle11 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle12 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle13 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle14 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle15 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle16 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle17 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle18 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Me.mobjFirstDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjDataGridViewTextBoxColumn1 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn2 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn3 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn4 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn5 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn6 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn7 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn8 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn9 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjFirstBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjUserDS = New CompanionKit.Controls.DataGridView.UserDS()
            Me.mobjSecondDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjUserIdDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserNameDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserEmailDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserPhoneDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserCityDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserAddressDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserCountryDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserStateDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserZipCodeDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjSecondBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjFirstLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSecondLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjFirstDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjFirstBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjSecondDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjSecondBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjFirstDataGridView
            ' 
            Me.mobjFirstDataGridView.AllowDrag = False
            Me.mobjFirstDataGridView.AutoGenerateColumns = False
            Me.mobjFirstDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjFirstDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjDataGridViewTextBoxColumn1, Me.mobjDataGridViewTextBoxColumn2, Me.mobjDataGridViewTextBoxColumn3, Me.mobjDataGridViewTextBoxColumn4, Me.mobjDataGridViewTextBoxColumn5, Me.mobjDataGridViewTextBoxColumn6, _
             Me.mobjDataGridViewTextBoxColumn7, Me.mobjDataGridViewTextBoxColumn8, Me.mobjDataGridViewTextBoxColumn9})
            Me.mobjFirstDataGridView.DataSource = Me.mobjFirstBindingSource
            Me.mobjFirstDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFirstDataGridView.Location = New System.Drawing.Point(0, 50)
            Me.mobjFirstDataGridView.Name = "mobjFirstDataGridView"
            Me.mobjFirstDataGridView.Size = New System.Drawing.Size(831, 210)
            Me.mobjFirstDataGridView.TabIndex = 1
            ' 
            ' mobjDataGridViewTextBoxColumn1
            ' 
            Me.mobjDataGridViewTextBoxColumn1.DataPropertyName = "UserId"
            Me.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1
            Me.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn1.HeaderText = "UserId"
            Me.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1"
            Me.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn2
            ' 
            Me.mobjDataGridViewTextBoxColumn2.DataPropertyName = "UserName"
            Me.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2
            Me.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn2.HeaderText = "UserName"
            Me.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2"
            Me.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn3
            ' 
            Me.mobjDataGridViewTextBoxColumn3.DataPropertyName = "UserEmail"
            Me.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3
            Me.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn3.HeaderText = "UserEmail"
            Me.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3"
            Me.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn4
            ' 
            Me.mobjDataGridViewTextBoxColumn4.DataPropertyName = "UserPhone"
            Me.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn4.HeaderText = "UserPhone"
            Me.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4"
            Me.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn5
            ' 
            Me.mobjDataGridViewTextBoxColumn5.DataPropertyName = "UserCity"
            Me.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn5.HeaderText = "UserCity"
            Me.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5"
            Me.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn6
            ' 
            Me.mobjDataGridViewTextBoxColumn6.DataPropertyName = "UserAddress"
            Me.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn6.HeaderText = "UserAddress"
            Me.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6"
            Me.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn6.Width = 130
            ' 
            ' mobjDataGridViewTextBoxColumn7
            ' 
            Me.mobjDataGridViewTextBoxColumn7.DataPropertyName = "UserCountry"
            Me.mobjDataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7
            Me.mobjDataGridViewTextBoxColumn7.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn7.HeaderText = "UserCountry"
            Me.mobjDataGridViewTextBoxColumn7.Name = "mobjDataGridViewTextBoxColumn7"
            Me.mobjDataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn8
            ' 
            Me.mobjDataGridViewTextBoxColumn8.DataPropertyName = "UserState"
            Me.mobjDataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle8
            Me.mobjDataGridViewTextBoxColumn8.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn8.HeaderText = "UserState"
            Me.mobjDataGridViewTextBoxColumn8.Name = "mobjDataGridViewTextBoxColumn8"
            Me.mobjDataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn9
            ' 
            Me.mobjDataGridViewTextBoxColumn9.DataPropertyName = "UserZipCode"
            Me.mobjDataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle9
            Me.mobjDataGridViewTextBoxColumn9.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn9.HeaderText = "UserZipCode"
            Me.mobjDataGridViewTextBoxColumn9.Name = "mobjDataGridViewTextBoxColumn9"
            Me.mobjDataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjFirstBindingSource
            ' 
            Me.mobjFirstBindingSource.DataMember = "Users"
            Me.mobjFirstBindingSource.DataSource = Me.mobjUserDS
            ' 
            ' mobjUserDS
            ' 
            Me.mobjUserDS.DataSetName = "UserDS"
            Me.mobjUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjSecondDataGridView
            ' 
            Me.mobjSecondDataGridView.AllowDrag = False
            Me.mobjSecondDataGridView.AllowUserToResizeColumns = False
            Me.mobjSecondDataGridView.AllowUserToResizeRows = False
            Me.mobjSecondDataGridView.AutoGenerateColumns = False
            Me.mobjSecondDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjSecondDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjUserIdDataGridViewTextBoxColumn, Me.mobjUserNameDataGridViewTextBoxColumn, Me.mobjUserEmailDataGridViewTextBoxColumn, Me.mobjUserPhoneDataGridViewTextBoxColumn, Me.mobjUserCityDataGridViewTextBoxColumn, Me.mobjUserAddressDataGridViewTextBoxColumn, _
             Me.mobjUserCountryDataGridViewTextBoxColumn, Me.mobjUserStateDataGridViewTextBoxColumn, Me.mobjUserZipCodeDataGridViewTextBoxColumn})
            Me.mobjSecondDataGridView.DataSource = Me.mobjSecondBindingSource
            Me.mobjSecondDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondDataGridView.Location = New System.Drawing.Point(0, 310)
            Me.mobjSecondDataGridView.Name = "mobjSecondDataGridView"
            Me.mobjSecondDataGridView.Size = New System.Drawing.Size(831, 211)
            Me.mobjSecondDataGridView.TabIndex = 2
            ' 
            ' mobjUserIdDataGridViewTextBoxColumn
            ' 
            Me.mobjUserIdDataGridViewTextBoxColumn.DataPropertyName = "UserId"
            Me.mobjUserIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10
            Me.mobjUserIdDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserIdDataGridViewTextBoxColumn.HeaderText = "UserId"
            Me.mobjUserIdDataGridViewTextBoxColumn.Name = "mobjUserIdDataGridViewTextBoxColumn"
            Me.mobjUserIdDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjUserNameDataGridViewTextBoxColumn
            ' 
            Me.mobjUserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
            Me.mobjUserNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11
            Me.mobjUserNameDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserNameDataGridViewTextBoxColumn.HeaderText = "UserName"
            Me.mobjUserNameDataGridViewTextBoxColumn.Name = "mobjUserNameDataGridViewTextBoxColumn"
            Me.mobjUserNameDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjUserEmailDataGridViewTextBoxColumn
            ' 
            Me.mobjUserEmailDataGridViewTextBoxColumn.DataPropertyName = "UserEmail"
            Me.mobjUserEmailDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12
            Me.mobjUserEmailDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserEmailDataGridViewTextBoxColumn.HeaderText = "UserEmail"
            Me.mobjUserEmailDataGridViewTextBoxColumn.Name = "mobjUserEmailDataGridViewTextBoxColumn"
            Me.mobjUserEmailDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjUserPhoneDataGridViewTextBoxColumn
            ' 
            Me.mobjUserPhoneDataGridViewTextBoxColumn.DataPropertyName = "UserPhone"
            Me.mobjUserPhoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13
            Me.mobjUserPhoneDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserPhoneDataGridViewTextBoxColumn.HeaderText = "UserPhone"
            Me.mobjUserPhoneDataGridViewTextBoxColumn.Name = "mobjUserPhoneDataGridViewTextBoxColumn"
            Me.mobjUserPhoneDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjUserCityDataGridViewTextBoxColumn
            ' 
            Me.mobjUserCityDataGridViewTextBoxColumn.DataPropertyName = "UserCity"
            Me.mobjUserCityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14
            Me.mobjUserCityDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserCityDataGridViewTextBoxColumn.HeaderText = "UserCity"
            Me.mobjUserCityDataGridViewTextBoxColumn.Name = "mobjUserCityDataGridViewTextBoxColumn"
            Me.mobjUserCityDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjUserAddressDataGridViewTextBoxColumn
            ' 
            Me.mobjUserAddressDataGridViewTextBoxColumn.DataPropertyName = "UserAddress"
            Me.mobjUserAddressDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15
            Me.mobjUserAddressDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserAddressDataGridViewTextBoxColumn.HeaderText = "UserAddress"
            Me.mobjUserAddressDataGridViewTextBoxColumn.Name = "mobjUserAddressDataGridViewTextBoxColumn"
            Me.mobjUserAddressDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            Me.mobjUserAddressDataGridViewTextBoxColumn.Width = 130
            ' 
            ' mobjUserCountryDataGridViewTextBoxColumn
            ' 
            Me.mobjUserCountryDataGridViewTextBoxColumn.DataPropertyName = "UserCountry"
            Me.mobjUserCountryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16
            Me.mobjUserCountryDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserCountryDataGridViewTextBoxColumn.HeaderText = "UserCountry"
            Me.mobjUserCountryDataGridViewTextBoxColumn.Name = "mobjUserCountryDataGridViewTextBoxColumn"
            Me.mobjUserCountryDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjUserStateDataGridViewTextBoxColumn
            ' 
            Me.mobjUserStateDataGridViewTextBoxColumn.DataPropertyName = "UserState"
            Me.mobjUserStateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17
            Me.mobjUserStateDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserStateDataGridViewTextBoxColumn.HeaderText = "UserState"
            Me.mobjUserStateDataGridViewTextBoxColumn.Name = "mobjUserStateDataGridViewTextBoxColumn"
            Me.mobjUserStateDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjUserZipCodeDataGridViewTextBoxColumn
            ' 
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.DataPropertyName = "UserZipCode"
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.HeaderText = "UserZipCode"
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.Name = "mobjUserZipCodeDataGridViewTextBoxColumn"
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[False]
            ' 
            ' mobjSecondBindingSource
            ' 
            Me.mobjSecondBindingSource.DataMember = "Users"
            Me.mobjSecondBindingSource.DataSource = Me.mobjUserDS
            ' 
            ' mobjFirstLabel
            ' 
            Me.mobjFirstLabel.AutoSize = True
            Me.mobjFirstLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFirstLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFirstLabel.Name = "mobjFirstLabel"
            Me.mobjFirstLabel.Size = New System.Drawing.Size(831, 50)
            Me.mobjFirstLabel.TabIndex = 3
            Me.mobjFirstLabel.Text = "The DataGridView demonstrates resizing of columns and rows"
            Me.mobjFirstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjSecondLabel
            ' 
            Me.mobjSecondLabel.AutoSize = True
            Me.mobjSecondLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondLabel.Location = New System.Drawing.Point(0, 260)
            Me.mobjSecondLabel.Name = "mobjSecondLabel"
            Me.mobjSecondLabel.Size = New System.Drawing.Size(831, 50)
            Me.mobjSecondLabel.TabIndex = 4
            Me.mobjSecondLabel.Text = "The DataGridView demonstrates unallowed resizing of columns and rows"
            Me.mobjSecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFirstLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSecondDataGridView, 0, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSecondLabel, 0, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFirstDataGridView, 0, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(831, 521)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' ResizingPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(831, 521)
            Me.Text = "ResizingPage"
            DirectCast(Me.mobjFirstDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjFirstBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjSecondDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjSecondBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjFirstDataGridView As Global.Gizmox.WebGUI.Forms.DataGridView
        Private mobjDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
        Private mobjFirstBindingSource As BindingSource
        Private mobjUserDS As CompanionKit.Controls.DataGridView.UserDS
        Private mobjSecondDataGridView As Gizmox.WebGUI.Forms.DataGridView
        Private mobjUserIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserEmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserPhoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserCityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserAddressDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserCountryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserStateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserZipCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjSecondBindingSource As BindingSource
        Private mobjFirstLabel As Label
        Private mobjSecondLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

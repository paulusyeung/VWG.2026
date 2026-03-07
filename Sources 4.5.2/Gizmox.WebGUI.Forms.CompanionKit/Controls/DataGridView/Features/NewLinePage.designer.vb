Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class NewLinePage
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
            Me.mobjUserIdDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserNameDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserEmailDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserPhoneDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserCityDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserAddressDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserCountryDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserStateDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserZipCodeDataGridViewTextBoxColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjUserDS = New CompanionKit.Controls.DataGridView.UserDS()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
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
            Me.mobjDataGridView.AllowUserToAddRows = False
            Me.mobjDataGridView.AutoGenerateColumns = False
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjUserIdDataGridViewTextBoxColumn, Me.mobjUserNameDataGridViewTextBoxColumn, Me.mobjUserEmailDataGridViewTextBoxColumn, Me.mobjUserPhoneDataGridViewTextBoxColumn, Me.mobjUserCityDataGridViewTextBoxColumn, Me.mobjUserAddressDataGridViewTextBoxColumn, _
             Me.mobjUserCountryDataGridViewTextBoxColumn, Me.mobjUserStateDataGridViewTextBoxColumn, Me.mobjUserZipCodeDataGridViewTextBoxColumn})
            Me.mobjDataGridView.DataSource = Me.mobjBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 50)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.Size = New System.Drawing.Size(594, 230)
            Me.mobjDataGridView.TabIndex = 0
            ' 
            ' mobjUserIdDataGridViewTextBoxColumn
            ' 
            Me.mobjUserIdDataGridViewTextBoxColumn.DataPropertyName = "UserId"
            Me.mobjUserIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1
            Me.mobjUserIdDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserIdDataGridViewTextBoxColumn.HeaderText = "UserId"
            Me.mobjUserIdDataGridViewTextBoxColumn.Name = "mobjUserIdDataGridViewTextBoxColumn"
            Me.mobjUserIdDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserNameDataGridViewTextBoxColumn
            ' 
            Me.mobjUserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
            Me.mobjUserNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2
            Me.mobjUserNameDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserNameDataGridViewTextBoxColumn.HeaderText = "UserName"
            Me.mobjUserNameDataGridViewTextBoxColumn.Name = "mobjUserNameDataGridViewTextBoxColumn"
            Me.mobjUserNameDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserEmailDataGridViewTextBoxColumn
            ' 
            Me.mobjUserEmailDataGridViewTextBoxColumn.DataPropertyName = "UserEmail"
            Me.mobjUserEmailDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3
            Me.mobjUserEmailDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserEmailDataGridViewTextBoxColumn.HeaderText = "UserEmail"
            Me.mobjUserEmailDataGridViewTextBoxColumn.Name = "mobjUserEmailDataGridViewTextBoxColumn"
            Me.mobjUserEmailDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserPhoneDataGridViewTextBoxColumn
            ' 
            Me.mobjUserPhoneDataGridViewTextBoxColumn.DataPropertyName = "UserPhone"
            Me.mobjUserPhoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjUserPhoneDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserPhoneDataGridViewTextBoxColumn.HeaderText = "UserPhone"
            Me.mobjUserPhoneDataGridViewTextBoxColumn.Name = "mobjUserPhoneDataGridViewTextBoxColumn"
            Me.mobjUserPhoneDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserCityDataGridViewTextBoxColumn
            ' 
            Me.mobjUserCityDataGridViewTextBoxColumn.DataPropertyName = "UserCity"
            Me.mobjUserCityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjUserCityDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserCityDataGridViewTextBoxColumn.HeaderText = "UserCity"
            Me.mobjUserCityDataGridViewTextBoxColumn.Name = "mobjUserCityDataGridViewTextBoxColumn"
            Me.mobjUserCityDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserAddressDataGridViewTextBoxColumn
            ' 
            Me.mobjUserAddressDataGridViewTextBoxColumn.DataPropertyName = "UserAddress"
            Me.mobjUserAddressDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjUserAddressDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserAddressDataGridViewTextBoxColumn.HeaderText = "UserAddress"
            Me.mobjUserAddressDataGridViewTextBoxColumn.Name = "mobjUserAddressDataGridViewTextBoxColumn"
            Me.mobjUserAddressDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserAddressDataGridViewTextBoxColumn.Width = 130
            ' 
            ' mobjUserCountryDataGridViewTextBoxColumn
            ' 
            Me.mobjUserCountryDataGridViewTextBoxColumn.DataPropertyName = "UserCountry"
            Me.mobjUserCountryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7
            Me.mobjUserCountryDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserCountryDataGridViewTextBoxColumn.HeaderText = "UserCountry"
            Me.mobjUserCountryDataGridViewTextBoxColumn.Name = "mobjUserCountryDataGridViewTextBoxColumn"
            Me.mobjUserCountryDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserStateDataGridViewTextBoxColumn
            ' 
            Me.mobjUserStateDataGridViewTextBoxColumn.DataPropertyName = "UserState"
            Me.mobjUserStateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8
            Me.mobjUserStateDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserStateDataGridViewTextBoxColumn.HeaderText = "UserState"
            Me.mobjUserStateDataGridViewTextBoxColumn.Name = "mobjUserStateDataGridViewTextBoxColumn"
            Me.mobjUserStateDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserZipCodeDataGridViewTextBoxColumn
            ' 
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.DataPropertyName = "UserZipCode"
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.HeaderText = "UserZipCode"
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.Name = "mobjUserZipCodeDataGridViewTextBoxColumn"
            Me.mobjUserZipCodeDataGridViewTextBoxColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
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
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(594, 50)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = "DataGridView demonstrates how to add rows"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDescriptionLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataGridView, 0, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 2
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(594, 280)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' NewLinePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(594, 280)
            Me.Text = "NewLinePage"
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDataGridView As Global.Gizmox.WebGUI.Forms.DataGridView
        Private mobjUserIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserEmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserPhoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserCityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserAddressDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserCountryDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserStateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjUserZipCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Private mobjBindingSource As BindingSource
        Private mobjUserDS As CompanionKit.Controls.DataGridView.UserDS
        Private mobjDescriptionLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

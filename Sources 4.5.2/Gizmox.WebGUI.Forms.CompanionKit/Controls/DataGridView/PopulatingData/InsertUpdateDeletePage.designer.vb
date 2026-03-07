Namespace CompanionKit.Controls.DataGridView.PopulatingData

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class InsertUpdateDeletePage
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
            Me.mobjUserIDColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserNameColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserEmailColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserPhoneColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserCityColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserAddressColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserCountryColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserStateColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserZipCodeColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjContextMenu = New Gizmox.WebGUI.Forms.ContextMenu()
            Me.mobjAddRowMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjModifyRowMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjRemoveRowMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
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
            Me.mobjDataGridView.AutoGenerateColumns = False
            Me.mobjDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjUserIDColumn, Me.mobjUserNameColumn, Me.mobjUserEmailColumn, Me.mobjUserPhoneColumn, Me.mobjUserCityColumn, Me.mobjUserAddressColumn, _
             Me.mobjUserCountryColumn, Me.mobjUserStateColumn, Me.mobjUserZipCodeColumn})
            Me.mobjDataGridView.ContextMenu = Me.mobjContextMenu
            Me.mobjDataGridView.DataSource = Me.mobjBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 50)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.mobjDataGridView.Size = New System.Drawing.Size(611, 218)
            Me.mobjDataGridView.TabIndex = 1
            Me.mobjDataGridView.UseInternalPaging = False
            ' 
            ' mobjUserIDColumn
            ' 
            Me.mobjUserIDColumn.DataPropertyName = "UserId"
            Me.mobjUserIDColumn.DefaultCellStyle = dataGridViewCellStyle1
            Me.mobjUserIDColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserIDColumn.HeaderText = "User ID"
            Me.mobjUserIDColumn.Name = "mobjUserIDColumn"
            Me.mobjUserIDColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserIDColumn.Width = 5
            ' 
            ' mobjUserNameColumn
            ' 
            Me.mobjUserNameColumn.DataPropertyName = "UserName"
            Me.mobjUserNameColumn.DefaultCellStyle = dataGridViewCellStyle2
            Me.mobjUserNameColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserNameColumn.HeaderText = "User Name"
            Me.mobjUserNameColumn.Name = "mobjUserNameColumn"
            Me.mobjUserNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserNameColumn.Width = 5
            ' 
            ' mobjUserEmailColumn
            ' 
            Me.mobjUserEmailColumn.DataPropertyName = "UserEmail"
            Me.mobjUserEmailColumn.DefaultCellStyle = dataGridViewCellStyle3
            Me.mobjUserEmailColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserEmailColumn.HeaderText = "User Email"
            Me.mobjUserEmailColumn.Name = "mobjUserEmailColumn"
            Me.mobjUserEmailColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserEmailColumn.Width = 5
            ' 
            ' mobjUserPhoneColumn
            ' 
            Me.mobjUserPhoneColumn.DataPropertyName = "UserPhone"
            Me.mobjUserPhoneColumn.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjUserPhoneColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserPhoneColumn.HeaderText = "User Phone"
            Me.mobjUserPhoneColumn.Name = "mobjUserPhoneColumn"
            Me.mobjUserPhoneColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserPhoneColumn.Width = 5
            ' 
            ' mobjUserCityColumn
            ' 
            Me.mobjUserCityColumn.DataPropertyName = "UserCity"
            Me.mobjUserCityColumn.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjUserCityColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserCityColumn.HeaderText = "User City"
            Me.mobjUserCityColumn.Name = "mobjUserCityColumn"
            Me.mobjUserCityColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserCityColumn.Width = 5
            ' 
            ' mobjUserAddressColumn
            ' 
            Me.mobjUserAddressColumn.DataPropertyName = "UserAddress"
            Me.mobjUserAddressColumn.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjUserAddressColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserAddressColumn.HeaderText = "User Address"
            Me.mobjUserAddressColumn.Name = "mobjUserAddressColumn"
            Me.mobjUserAddressColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserAddressColumn.Width = 5
            ' 
            ' mobjUserCountryColumn
            ' 
            Me.mobjUserCountryColumn.DataPropertyName = "UserCountry"
            Me.mobjUserCountryColumn.DefaultCellStyle = dataGridViewCellStyle7
            Me.mobjUserCountryColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserCountryColumn.HeaderText = "User Country"
            Me.mobjUserCountryColumn.Name = "mobjUserCountryColumn"
            Me.mobjUserCountryColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserCountryColumn.Width = 5
            ' 
            ' mobjUserStateColumn
            ' 
            Me.mobjUserStateColumn.DataPropertyName = "UserState"
            Me.mobjUserStateColumn.DefaultCellStyle = dataGridViewCellStyle8
            Me.mobjUserStateColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserStateColumn.HeaderText = "User State"
            Me.mobjUserStateColumn.Name = "mobjUserStateColumn"
            Me.mobjUserStateColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserStateColumn.Width = 5
            ' 
            ' mobjUserZipCodeColumn
            ' 
            Me.mobjUserZipCodeColumn.DataPropertyName = "UserZipCode"
            Me.mobjUserZipCodeColumn.DefaultCellStyle = dataGridViewCellStyle9
            Me.mobjUserZipCodeColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserZipCodeColumn.HeaderText = "User ZipCode"
            Me.mobjUserZipCodeColumn.Name = "mobjUserZipCodeColumn"
            Me.mobjUserZipCodeColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserZipCodeColumn.Width = 5
            ' 
            ' mobjContextMenu
            ' 
            Me.mobjContextMenu.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.mobjAddRowMenuItem, Me.mobjModifyRowMenuItem, Me.mobjRemoveRowMenuItem})
            ' 
            ' mobjAddRowMenuItem
            ' 
            Me.mobjAddRowMenuItem.Index = 0
            Me.mobjAddRowMenuItem.Text = "Add Row..."
            ' 
            ' mobjModifyRowMenuItem
            ' 
            Me.mobjModifyRowMenuItem.Index = 1
            Me.mobjModifyRowMenuItem.Text = "Modify Row..."
            ' 
            ' mobjRemoveRowMenuItem
            ' 
            Me.mobjRemoveRowMenuItem.Index = 2
            Me.mobjRemoveRowMenuItem.Text = "Remove Row..."
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
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(611, 50)
            Me.mobjDescriptionLabel.TabIndex = 2
            Me.mobjDescriptionLabel.Text = "DataGridView allows inserting, updating and removing rows with context menu"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDescriptionLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataGridView, 0, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 2
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(611, 268)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' InsertUpdateDeletePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(611, 268)
            Me.Text = "InsertUpdateDeletePage"
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjUserDS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDataGridView As Global.Gizmox.WebGUI.Forms.DataGridView
        Private mobjUserIDColumn As DataGridViewTextBoxColumn
        Private mobjUserNameColumn As DataGridViewTextBoxColumn
        Private mobjUserEmailColumn As DataGridViewTextBoxColumn
        Private mobjUserPhoneColumn As DataGridViewTextBoxColumn
        Private mobjUserCityColumn As DataGridViewTextBoxColumn
        Private mobjUserAddressColumn As DataGridViewTextBoxColumn
        Private mobjUserCountryColumn As DataGridViewTextBoxColumn
        Private mobjUserStateColumn As DataGridViewTextBoxColumn
        Private mobjUserZipCodeColumn As DataGridViewTextBoxColumn
        Private mobjBindingSource As BindingSource
        Private mobjUserDS As CompanionKit.Controls.DataGridView.UserDS
        Private WithEvents mobjContextMenu As Gizmox.WebGUI.Forms.ContextMenu
        Private WithEvents mobjAddRowMenuItem As MenuItem
        Private WithEvents mobjModifyRowMenuItem As MenuItem
        Private WithEvents mobjRemoveRowMenuItem As MenuItem
        Private mobjDescriptionLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

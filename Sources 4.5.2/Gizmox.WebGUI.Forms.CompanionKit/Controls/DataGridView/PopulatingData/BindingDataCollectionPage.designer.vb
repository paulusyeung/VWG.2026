Namespace CompanionKit.Controls.DataGridView.PopulatingData

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BindingDataCollectionPage
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
            Me.mobjUserIDColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjFirstNameColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjLastNameColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjFullNameColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjFavoriteColorColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserPhotoColumn = New Gizmox.WebGUI.Forms.DataGridViewImageColumn()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjUserIDColumn
            ' 
            Me.mobjUserIDColumn.DataPropertyName = "ID"
            Me.mobjUserIDColumn.DefaultCellStyle = dataGridViewCellStyle1
            Me.mobjUserIDColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserIDColumn.HeaderText = "ID"
            Me.mobjUserIDColumn.Name = "mobjUserIDColumn"
            Me.mobjUserIDColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjFirstNameColumn
            ' 
            Me.mobjFirstNameColumn.DataPropertyName = "FirstName"
            Me.mobjFirstNameColumn.DefaultCellStyle = dataGridViewCellStyle2
            Me.mobjFirstNameColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjFirstNameColumn.HeaderText = "First Name"
            Me.mobjFirstNameColumn.Name = "mobjFirstNameColumn"
            Me.mobjFirstNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjLastNameColumn
            ' 
            Me.mobjLastNameColumn.DataPropertyName = "LastName"
            Me.mobjLastNameColumn.DefaultCellStyle = dataGridViewCellStyle3
            Me.mobjLastNameColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjLastNameColumn.HeaderText = "Last Name"
            Me.mobjLastNameColumn.Name = "mobjLastNameColumn"
            Me.mobjLastNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjFullNameColumn
            ' 
            Me.mobjFullNameColumn.DataPropertyName = "FullName"
            Me.mobjFullNameColumn.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjFullNameColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjFullNameColumn.HeaderText = "Full Name"
            Me.mobjFullNameColumn.Name = "mobjFullNameColumn"
            Me.mobjFullNameColumn.[ReadOnly] = True
            Me.mobjFullNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjFavoriteColorColumn
            ' 
            Me.mobjFavoriteColorColumn.DataPropertyName = "FavoriteColor"
            Me.mobjFavoriteColorColumn.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjFavoriteColorColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjFavoriteColorColumn.HeaderText = "Favorite Color"
            Me.mobjFavoriteColorColumn.Name = "mobjFavoriteColorColumn"
            Me.mobjFavoriteColorColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjUserPhotoColumn
            ' 
            Me.mobjUserPhotoColumn.DataPropertyName = "Foto"
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter
            dataGridViewCellStyle6.NullValue = Nothing
            Me.mobjUserPhotoColumn.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjUserPhotoColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserPhotoColumn.Description = Nothing
            Me.mobjUserPhotoColumn.HeaderText = "Photo"
            Me.mobjUserPhotoColumn.Name = "mobjUserPhotoColumn"
            Me.mobjUserPhotoColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjBindingSource
            ' 
            Me.mobjBindingSource.DataSource = GetType(Utils.Customer)
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.AutoSize = True
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(655, 50)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = "DataGridView with a collection DataSource"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDataGridView
            ' 
            Me.mobjDataGridView.AllowDrag = False
            Me.mobjDataGridView.AutoGenerateColumns = False
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjUserIDColumn, Me.mobjFirstNameColumn, Me.mobjLastNameColumn, Me.mobjFullNameColumn, Me.mobjFavoriteColorColumn, Me.mobjUserPhotoColumn})
            Me.mobjDataGridView.DataSource = Me.mobjBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 50)
            Me.mobjDataGridView.Name = "dataGridView1"
            Me.mobjDataGridView.RowTemplate.Height = 40
            Me.mobjDataGridView.Size = New System.Drawing.Size(655, 243)
            Me.mobjDataGridView.TabIndex = 0
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataGridView, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDescriptionLabel, 0, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 2
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(655, 293)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' BindingDataCollectionPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(655, 293)
            Me.Text = "BindingDataCollectionPage"
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDataGridView As Gizmox.WebGUI.Forms.DataGridView
        Private mobjUserIDColumn As DataGridViewTextBoxColumn
        Private mobjFirstNameColumn As DataGridViewTextBoxColumn
        Private mobjLastNameColumn As DataGridViewTextBoxColumn
        Private mobjFullNameColumn As DataGridViewTextBoxColumn
        Private mobjFavoriteColorColumn As DataGridViewTextBoxColumn
        Private mobjUserPhotoColumn As DataGridViewImageColumn
        Private mobjBindingSource As BindingSource
        Private mobjDescriptionLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

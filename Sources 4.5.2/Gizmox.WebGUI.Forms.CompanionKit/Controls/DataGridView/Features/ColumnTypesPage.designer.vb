Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ColumnTypesPage
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
            Dim dataGridViewCellStyle1 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle3 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle4 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle5 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle6 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Me.mobjDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjUserIdColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjUserNameColumn = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjEmailColumn = New Gizmox.WebGUI.Forms.DataGridViewLinkColumn()
            Me.mobjPhoneColumn = New Gizmox.WebGUI.Forms.DataGridViewButtonColumn()
            Me.mobjIsLoggedInColumn = New Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn()
            Me.mobjBirthYearColumn = New Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn()
            Me.mobjPhotoColumn = New Gizmox.WebGUI.Forms.DataGridViewImageColumn()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDataGridView
            ' 
            Me.mobjDataGridView.AllowDrag = False
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjUserIdColumn, Me.mobjUserNameColumn, Me.mobjEmailColumn, Me.mobjPhoneColumn, Me.mobjIsLoggedInColumn, Me.mobjBirthYearColumn, _
             Me.mobjPhotoColumn})
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 50)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.RowTemplate.Height = 40
            Me.mobjDataGridView.RowTemplate.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridView.Size = New System.Drawing.Size(782, 249)
            Me.mobjDataGridView.TabIndex = 0
            ' 
            ' mobjUserIdColumn
            ' 
            Me.mobjUserIdColumn.DefaultCellStyle = dataGridViewCellStyle1
            Me.mobjUserIdColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserIdColumn.HeaderText = "User ID"
            Me.mobjUserIdColumn.Name = "mobjUserIdColumn"
            Me.mobjUserIdColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserIdColumn.Width = 50
            ' 
            ' mobjUserNameColumn
            ' 
            Me.mobjUserNameColumn.DefaultCellStyle = dataGridViewCellStyle2
            Me.mobjUserNameColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjUserNameColumn.HeaderText = "User Name"
            Me.mobjUserNameColumn.Name = "mobjUserNameColumn"
            Me.mobjUserNameColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjUserNameColumn.Width = 60
            ' 
            ' mobjEmailColumn
            ' 
            Me.mobjEmailColumn.ActiveLinkColor = System.Drawing.Color.Empty
            Me.mobjEmailColumn.ClientMode = False
            Me.mobjEmailColumn.DefaultCellStyle = dataGridViewCellStyle3
            Me.mobjEmailColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjEmailColumn.HeaderText = "E-mail"
            Me.mobjEmailColumn.LinkColor = System.Drawing.Color.Empty
            Me.mobjEmailColumn.Name = "mobjEmailColumn"
            Me.mobjEmailColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjEmailColumn.TrackVisitedState = False
            Me.mobjEmailColumn.Url = ""
            Me.mobjEmailColumn.VisitedLinkColor = System.Drawing.Color.Empty
            ' 
            ' mobjPhoneColumn
            ' 
            Me.mobjPhoneColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjPhoneColumn.HeaderText = "Phone"
            Me.mobjPhoneColumn.Name = "mobjPhoneColumn"
            Me.mobjPhoneColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjPhoneColumn.Width = 150
            ' 
            ' mobjIsLoggedInColumn
            ' 
            dataGridViewCellStyle4.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter
            dataGridViewCellStyle4.NullValue = False
            Me.mobjIsLoggedInColumn.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjIsLoggedInColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjIsLoggedInColumn.HeaderText = "Is Logged In"
            Me.mobjIsLoggedInColumn.Name = "mobjIsLoggedInColumn"
            Me.mobjIsLoggedInColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjIsLoggedInColumn.Width = 70
            ' 
            ' mobjBirthYearColumn
            ' 
            Me.mobjBirthYearColumn.AutoComplete = False
            Me.mobjBirthYearColumn.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjBirthYearColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjBirthYearColumn.DisplayStyleForCurrentCellOnly = True
            Me.mobjBirthYearColumn.HeaderText = "Birth Year"
            Me.mobjBirthYearColumn.Items.AddRange(New Object() {"1990", "1991", "1992", "1993", "1994", "1995", _
             "1996", "1997", "1998", "1999", "2000", "2001", _
             "2002", "2003", "2004", "2005", "2006", "2007", _
             "2008", "2009", "2010"})
            Me.mobjBirthYearColumn.Name = "mobjBirthYearColumn"
            Me.mobjBirthYearColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjBirthYearColumn.Width = 70
            ' 
            ' mobjPhotoColumn
            ' 
            dataGridViewCellStyle6.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter
            dataGridViewCellStyle6.NullValue = Nothing
            Me.mobjPhotoColumn.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjPhotoColumn.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjPhotoColumn.Description = Nothing
            Me.mobjPhotoColumn.HeaderText = "Photo"
            Me.mobjPhotoColumn.Name = "mobjPhotoColumn"
            Me.mobjPhotoColumn.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjPhotoColumn.Width = 50
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.AutoSize = True
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(782, 50)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = "DataGridView with columns of deferent types"
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
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(782, 299)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' ColumnTypesPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(782, 299)
            Me.Text = "ColumnTypesPage"
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDataGridView As Global.Gizmox.WebGUI.Forms.DataGridView
        Private mobjUserIdColumn As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjUserNameColumn As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjEmailColumn As Gizmox.WebGUI.Forms.DataGridViewLinkColumn
        Private mobjPhoneColumn As Gizmox.WebGUI.Forms.DataGridViewButtonColumn
        Private mobjIsLoggedInColumn As Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn
        Private mobjBirthYearColumn As Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn
        Private mobjPhotoColumn As Gizmox.WebGUI.Forms.DataGridViewImageColumn
        Private mobjDescriptionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace

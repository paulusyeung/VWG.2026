Namespace CompanionKit.Controls.TabControl.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MemoryOptimizedPage
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
            Me.mobjDataGridViewTextBoxColumn10 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn11 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjNorthwindDataSet = New NorthwindDataSet()
            Me.mobjDemoTabControl = New Gizmox.WebGUI.Forms.TabControl()
            Me.mobjTabPage1 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjHtmlBox = New Gizmox.WebGUI.Forms.HtmlBox()
            Me.mobjTabPage2 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCustomersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjDemoTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjDemoTabControl.SuspendLayout()
            Me.mobjTabPage1.SuspendLayout()
            Me.mobjTabPage2.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDataGridView
            ' 
            Me.mobjDataGridView.AllowDrag = False
            Me.mobjDataGridView.AutoGenerateColumns = False
            Me.mobjDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjDataGridViewTextBoxColumn1, Me.mobjDataGridViewTextBoxColumn2, Me.mobjDataGridViewTextBoxColumn3, Me.mobjDataGridViewTextBoxColumn4, Me.mobjDataGridViewTextBoxColumn5, Me.mobjDataGridViewTextBoxColumn6, _
             Me.mobjDataGridViewTextBoxColumn7, Me.mobjDataGridViewTextBoxColumn8, Me.mobjDataGridViewTextBoxColumn9, Me.mobjDataGridViewTextBoxColumn10, Me.mobjDataGridViewTextBoxColumn11})
            Me.mobjDataGridView.DataSource = Me.mobjBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 0)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.Size = New System.Drawing.Size(518, 397)
            Me.mobjDataGridView.TabIndex = 0
            ' 
            ' mobjDataGridViewTextBoxColumn1
            ' 
            Me.mobjDataGridViewTextBoxColumn1.DataPropertyName = "CustomerID"
            Me.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1
            Me.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn1.HeaderText = "Customer ID"
            Me.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1"
            Me.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn1.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn2
            ' 
            Me.mobjDataGridViewTextBoxColumn2.DataPropertyName = "CompanyName"
            Me.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2
            Me.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn2.HeaderText = "Company Name"
            Me.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2"
            Me.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn2.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn3
            ' 
            Me.mobjDataGridViewTextBoxColumn3.DataPropertyName = "ContactName"
            Me.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3
            Me.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn3.HeaderText = "Contact Name"
            Me.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3"
            Me.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn3.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn4
            ' 
            Me.mobjDataGridViewTextBoxColumn4.DataPropertyName = "ContactTitle"
            Me.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4
            Me.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn4.HeaderText = "Contact Title"
            Me.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4"
            Me.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn4.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn5
            ' 
            Me.mobjDataGridViewTextBoxColumn5.DataPropertyName = "Address"
            Me.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5
            Me.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn5.HeaderText = "Address"
            Me.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5"
            Me.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn5.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn6
            ' 
            Me.mobjDataGridViewTextBoxColumn6.DataPropertyName = "City"
            Me.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6
            Me.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn6.HeaderText = "City"
            Me.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6"
            Me.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn6.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn7
            ' 
            Me.mobjDataGridViewTextBoxColumn7.DataPropertyName = "Region"
            Me.mobjDataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7
            Me.mobjDataGridViewTextBoxColumn7.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn7.HeaderText = "Region"
            Me.mobjDataGridViewTextBoxColumn7.Name = "mobjDataGridViewTextBoxColumn7"
            Me.mobjDataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn7.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn8
            ' 
            Me.mobjDataGridViewTextBoxColumn8.DataPropertyName = "PostalCode"
            Me.mobjDataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle8
            Me.mobjDataGridViewTextBoxColumn8.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn8.HeaderText = "Postal Code"
            Me.mobjDataGridViewTextBoxColumn8.Name = "mobjDataGridViewTextBoxColumn8"
            Me.mobjDataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn8.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn9
            ' 
            Me.mobjDataGridViewTextBoxColumn9.DataPropertyName = "Country"
            Me.mobjDataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle9
            Me.mobjDataGridViewTextBoxColumn9.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn9.HeaderText = "Country"
            Me.mobjDataGridViewTextBoxColumn9.Name = "mobjDataGridViewTextBoxColumn9"
            Me.mobjDataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn9.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn10
            ' 
            Me.mobjDataGridViewTextBoxColumn10.DataPropertyName = "Phone"
            Me.mobjDataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle10
            Me.mobjDataGridViewTextBoxColumn10.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn10.HeaderText = "Phone"
            Me.mobjDataGridViewTextBoxColumn10.Name = "mobjDataGridViewTextBoxColumn10"
            Me.mobjDataGridViewTextBoxColumn10.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn10.Width = 5
            ' 
            ' mobjDataGridViewTextBoxColumn11
            ' 
            Me.mobjDataGridViewTextBoxColumn11.DataPropertyName = "Fax"
            Me.mobjDataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle11
            Me.mobjDataGridViewTextBoxColumn11.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn11.HeaderText = "Fax"
            Me.mobjDataGridViewTextBoxColumn11.Name = "mobjDataGridViewTextBoxColumn11"
            Me.mobjDataGridViewTextBoxColumn11.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn11.Width = 5
            ' 
            ' mobjBindingSource
            ' 
            Me.mobjBindingSource.DataMember = "Customers"
            Me.mobjBindingSource.DataSource = Me.mobjNorthwindDataSet
            ' 
            ' mobjNorthwindDataSet
            ' 
            Me.mobjNorthwindDataSet.DataSetName = "NorthwindDataSet"
            Me.mobjNorthwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjDemoTabControl
            ' 
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage1)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage2)
            Me.mobjDemoTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoTabControl.Location = New System.Drawing.Point(0, 60)
            Me.mobjDemoTabControl.Name = "mobjDemoTabControl"
            Me.mobjDemoTabControl.SelectedIndex = 0
            Me.mobjDemoTabControl.Size = New System.Drawing.Size(526, 423)
            Me.mobjDemoTabControl.TabIndex = 0
            ' 
            ' mobjTabPage1
            ' 
            Me.mobjTabPage1.Controls.Add(Me.mobjHtmlBox)
            Me.mobjTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage1.Location = New System.Drawing.Point(4, 22)
            Me.mobjTabPage1.Name = "mobjTabPage1"
            Me.mobjTabPage1.Size = New System.Drawing.Size(518, 397)
            Me.mobjTabPage1.TabIndex = 0
            Me.mobjTabPage1.Text = "HTMLBox"
            ' 
            ' mobjHtmlBox
            ' 
            Me.mobjHtmlBox.ContentType = "text/html"
            Me.mobjHtmlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHtmlBox.Html = ""
            Me.mobjHtmlBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjHtmlBox.Name = "mobjHtmlBox"
            Me.mobjHtmlBox.Size = New System.Drawing.Size(518, 397)
            Me.mobjHtmlBox.TabIndex = 0
            Me.mobjHtmlBox.Url = "http://www.google.com/search?q=visualwebgui"
            ' 
            ' mobjTabPage2
            ' 
            Me.mobjTabPage2.Controls.Add(Me.mobjDataGridView)
            Me.mobjTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage2.Location = New System.Drawing.Point(4, 22)
            Me.mobjTabPage2.Name = "mobjTabPage2"
            Me.mobjTabPage2.Size = New System.Drawing.Size(518, 397)
            Me.mobjTabPage2.TabIndex = 1
            Me.mobjTabPage2.Text = "DataGridView"
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.AutoSize = True
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 27)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(526, 13)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = " MemoryOptimized TabControl"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjCustomersTableAdapter
            ' 
            Me.mobjCustomersTableAdapter.ClearBeforeFill = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDescriptionLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoTabControl, 0, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(526, 483)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' MemoryOptimizedPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(526, 483)
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjDemoTabControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjDemoTabControl.ResumeLayout(False)
            Me.mobjTabPage1.ResumeLayout(False)
            Me.mobjTabPage2.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoTabControl As Gizmox.WebGUI.Forms.TabControl
        Private mobjTabPage1 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage2 As Gizmox.WebGUI.Forms.TabPage

        Private mobjDataGridView As Gizmox.WebGUI.Forms.DataGridView
        Private mobjDataGridViewTextBoxColumn1 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn2 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn3 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn4 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn5 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn6 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn7 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn8 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn9 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn10 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn11 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjNorthwindDataSet As NorthwindDataSet
        Private mobjCustomersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter
        Private mobjDescriptionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjHtmlBox As Gizmox.WebGUI.Forms.HtmlBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
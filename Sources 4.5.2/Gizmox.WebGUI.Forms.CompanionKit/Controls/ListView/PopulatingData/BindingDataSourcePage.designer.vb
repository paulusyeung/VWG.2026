Namespace CompanionKit.Controls.ListView.PopulatingData

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BindingDataSourcePage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.bindingSource1 = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.northwindDataSet = New NorthwindDataSet()
            Me.customersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.columnCustomerID = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnCompanyName = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnContactName = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnContactTitle = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnAddress = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnCity = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnRegion = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnPostalCode = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnCountry = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnPhone = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnFax = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.northwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "ListView with a database DataSource:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListView
            '
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnCustomerID, Me.columnCompanyName, Me.columnContactName, Me.columnContactTitle, Me.columnAddress, Me.columnCity, Me.columnRegion, Me.columnPostalCode, Me.columnCountry, Me.columnPhone, Me.columnFax})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.DataSource = Me.bindingSource1
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(5, 65)
            Me.mobjListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(310, 330)
            Me.mobjListView.TabIndex = 1
            Me.mobjListView.TotalItems = 1
            '
            'bindingSource1
            '
            Me.bindingSource1.DataMember = "Customers"
            Me.bindingSource1.DataSource = Me.northwindDataSet
            '
            'northwindDataSet
            '
            Me.northwindDataSet.DataSetName = "NorthwindDataSet"
            Me.northwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'customersTableAdapter
            '
            Me.customersTableAdapter.ClearBeforeFill = True
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjListView, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 2
            '
            'columnCustomerID
            '
            Me.columnCustomerID.Tag = "CustomerID"
            Me.columnCustomerID.Text = "CustomerID"
            Me.columnCustomerID.Width = 100
            '
            'columnCompanyName
            '
            Me.columnCompanyName.Tag = "CompanyName"
            Me.columnCompanyName.Text = "CompanyName"
            Me.columnCompanyName.Width = 100
            '
            'columnContactName
            '
            Me.columnContactName.Tag = "ContactName"
            Me.columnContactName.Text = "ContactName"
            Me.columnContactName.Width = 100
            '
            'columnContactTitle
            '
            Me.columnContactTitle.Tag = "ContactTitle"
            Me.columnContactTitle.Text = "ContactTitle"
            Me.columnContactTitle.Width = 100
            '
            'columnAddress
            '
            Me.columnAddress.Tag = "Address"
            Me.columnAddress.Text = "Address"
            Me.columnAddress.Width = 100
            '
            'columnCity
            '
            Me.columnCity.Tag = "City"
            Me.columnCity.Text = "City"
            Me.columnCity.Width = 100
            '
            'columnRegion
            '
            Me.columnRegion.Tag = "Region"
            Me.columnRegion.Text = "Region"
            Me.columnRegion.Width = 100
            '
            'columnPostalCode
            '
            Me.columnPostalCode.Tag = "PostalCode"
            Me.columnPostalCode.Text = "PostalCode"
            Me.columnPostalCode.Width = 100
            '
            'columnCountry
            '
            Me.columnCountry.Tag = "Country"
            Me.columnCountry.Text = "Country"
            Me.columnCountry.Width = 100
            '
            'columnPhone
            '
            Me.columnPhone.Tag = "Phone"
            Me.columnPhone.Text = "Phone"
            Me.columnPhone.Width = 100
            '
            'columnFax
            '
            Me.columnFax.Tag = "Fax"
            Me.columnFax.Text = "Fax"
            Me.columnFax.Width = 100
            '
            'BindingDataSourcePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "BindingDataSourcePage"
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.northwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents bindingSource1 As Gizmox.WebGUI.Forms.BindingSource
        Friend WithEvents northwindDataSet As Global.NorthwindDataSet
        Friend WithEvents customersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter
        Friend WithEvents columnCustomerID As ColumnHeader
        Friend WithEvents columnCompanyName As ColumnHeader
        Friend WithEvents columnContactName As ColumnHeader
        Friend WithEvents columnContactTitle As ColumnHeader
        Friend WithEvents columnAddress As ColumnHeader
        Friend WithEvents columnCity As ColumnHeader
        Friend WithEvents columnRegion As ColumnHeader
        Friend WithEvents columnPostalCode As ColumnHeader
        Friend WithEvents columnCountry As ColumnHeader
        Friend WithEvents columnPhone As ColumnHeader
        Friend WithEvents columnFax As ColumnHeader
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace

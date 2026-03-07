Namespace CompanionKit.Controls.DataGridView.PopulatingData

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class HierarchiesPage
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
            Me.dataGridViewTextBoxColumn1 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn2 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn3 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn4 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn5 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn6 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn7 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn8 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn9 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn10 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn11 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn12 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn13 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.dataGridViewTextBoxColumn14 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDGV = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjOrdersSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjDS = New NorthwindDataSet()
            Me.hierarchicInfo1 = New Gizmox.WebGUI.Forms.HierarchicInfo()
            Me.mobjOrderDetailsSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjOrderIDFilter = New Gizmox.WebGUI.Forms.FilterRelation()
            Me.hierarchicInfo2 = New Gizmox.WebGUI.Forms.HierarchicInfo()
            Me.mobjProductsSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjProductIDFilter = New Gizmox.WebGUI.Forms.FilterRelation()
            Me.ordersAdapter = New NorthwindDataSetTableAdapters.OrdersTableAdapter()
            Me.orderDetailsAdapter = New NorthwindDataSetTableAdapters.Order_DetailsTableAdapter()
            Me.productsAdapter = New NorthwindDataSetTableAdapters.ProductsTableAdapter()
            DirectCast(Me.mobjDGV, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjOrdersSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjDS, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjOrderDetailsSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjProductsSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AccessibleDescription = ""
            Me.mobjInfoLabel.AccessibleName = ""
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(451, 66)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Use ColumnChooser to show or hide columns in HierarchicalDataGridView:"
            ' 
            ' mobjDGV
            ' 
            Me.mobjDGV.AccessibleDescription = "Orders"
            Me.mobjDGV.AccessibleName = "Orders"
            Me.mobjDGV.AllowDrag = False
            Me.mobjDGV.AutoGenerateColumns = False
            Me.mobjDGV.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDGV.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.dataGridViewTextBoxColumn1, Me.dataGridViewTextBoxColumn2, Me.dataGridViewTextBoxColumn3, Me.dataGridViewTextBoxColumn4, Me.dataGridViewTextBoxColumn5, Me.dataGridViewTextBoxColumn6, _
             Me.dataGridViewTextBoxColumn7, Me.dataGridViewTextBoxColumn8, Me.dataGridViewTextBoxColumn9, Me.dataGridViewTextBoxColumn10, Me.dataGridViewTextBoxColumn11, Me.dataGridViewTextBoxColumn12, _
             Me.dataGridViewTextBoxColumn13, Me.dataGridViewTextBoxColumn14})
            Me.mobjDGV.DataSource = Me.mobjOrdersSource
            Me.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDGV.ExpansionIndicator = Gizmox.WebGUI.Forms.ShowExpansionIndicator.Always
            Me.mobjDGV.HierarchicInfos.Add(Me.hierarchicInfo1)
            Me.mobjDGV.HierarchicInfos.Add(Me.hierarchicInfo2)
            Me.mobjDGV.Location = New System.Drawing.Point(0, 66)
            Me.mobjDGV.Name = "mobjDGV"
            Me.mobjDGV.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
            Me.mobjDGV.ShowColumnChooser = True
            Me.mobjDGV.Size = New System.Drawing.Size(451, 272)
            Me.mobjDGV.TabIndex = 1
            ' 
            ' dataGridViewTextBoxColumn1
            ' 
            Me.dataGridViewTextBoxColumn1.DataPropertyName = "OrderID"
            Me.dataGridViewTextBoxColumn1.HeaderText = "OrderID"
            Me.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
            Me.dataGridViewTextBoxColumn1.[ReadOnly] = True
            ' 
            ' dataGridViewTextBoxColumn2
            ' 
            Me.dataGridViewTextBoxColumn2.DataPropertyName = "CustomerID"
            Me.dataGridViewTextBoxColumn2.HeaderText = "CustomerID"
            Me.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2"
            ' 
            ' dataGridViewTextBoxColumn3
            ' 
            Me.dataGridViewTextBoxColumn3.DataPropertyName = "EmployeeID"
            Me.dataGridViewTextBoxColumn3.HeaderText = "EmployeeID"
            Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
            ' 
            ' dataGridViewTextBoxColumn4
            ' 
            Me.dataGridViewTextBoxColumn4.DataPropertyName = "OrderDate"
            Me.dataGridViewTextBoxColumn4.HeaderText = "OrderDate"
            Me.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4"
            ' 
            ' dataGridViewTextBoxColumn5
            ' 
            Me.dataGridViewTextBoxColumn5.DataPropertyName = "RequiredDate"
            Me.dataGridViewTextBoxColumn5.HeaderText = "RequiredDate"
            Me.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5"
            ' 
            ' dataGridViewTextBoxColumn6
            ' 
            Me.dataGridViewTextBoxColumn6.DataPropertyName = "ShippedDate"
            Me.dataGridViewTextBoxColumn6.HeaderText = "ShippedDate"
            Me.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6"
            ' 
            ' dataGridViewTextBoxColumn7
            ' 
            Me.dataGridViewTextBoxColumn7.DataPropertyName = "ShipVia"
            Me.dataGridViewTextBoxColumn7.HeaderText = "ShipVia"
            Me.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7"
            ' 
            ' dataGridViewTextBoxColumn8
            ' 
            Me.dataGridViewTextBoxColumn8.DataPropertyName = "Freight"
            Me.dataGridViewTextBoxColumn8.HeaderText = "Freight"
            Me.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8"
            ' 
            ' dataGridViewTextBoxColumn9
            ' 
            Me.dataGridViewTextBoxColumn9.DataPropertyName = "ShipName"
            Me.dataGridViewTextBoxColumn9.HeaderText = "ShipName"
            Me.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9"
            ' 
            ' dataGridViewTextBoxColumn10
            ' 
            Me.dataGridViewTextBoxColumn10.DataPropertyName = "ShipAddress"
            Me.dataGridViewTextBoxColumn10.HeaderText = "ShipAddress"
            Me.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10"
            ' 
            ' dataGridViewTextBoxColumn11
            ' 
            Me.dataGridViewTextBoxColumn11.DataPropertyName = "ShipCity"
            Me.dataGridViewTextBoxColumn11.HeaderText = "ShipCity"
            Me.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11"
            ' 
            ' dataGridViewTextBoxColumn12
            ' 
            Me.dataGridViewTextBoxColumn12.DataPropertyName = "ShipRegion"
            Me.dataGridViewTextBoxColumn12.HeaderText = "ShipRegion"
            Me.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12"
            ' 
            ' dataGridViewTextBoxColumn13
            ' 
            Me.dataGridViewTextBoxColumn13.DataPropertyName = "ShipPostalCode"
            Me.dataGridViewTextBoxColumn13.HeaderText = "ShipPostalCode"
            Me.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13"
            ' 
            ' dataGridViewTextBoxColumn14
            ' 
            Me.dataGridViewTextBoxColumn14.DataPropertyName = "ShipCountry"
            Me.dataGridViewTextBoxColumn14.HeaderText = "ShipCountry"
            Me.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14"
            ' 
            ' mobjOrdersSource
            ' 
            Me.mobjOrdersSource.DataMember = "Orders"
            Me.mobjOrdersSource.DataSource = Me.mobjDS
            ' 
            ' mobjDS
            ' 
            Me.mobjDS.DataSetName = "NorthwindDataSet"
            Me.mobjDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' hierarchicInfo1
            ' 
            Me.hierarchicInfo1.BindedSource = Me.mobjOrderDetailsSource
            Me.hierarchicInfo1.FilteringDataMembers.Add(Me.mobjOrderIDFilter)
            Me.hierarchicInfo1.HierarchyName = "Order Details"
            ' 
            ' mobjOrderDetailsSource
            ' 
            Me.mobjOrderDetailsSource.DataMember = "Order Details"
            Me.mobjOrderDetailsSource.DataSource = Me.mobjDS
            ' 
            ' mobjOrderIDFilter
            ' 
            Me.mobjOrderIDFilter.SourceColumnDataName = "OrderID"
            Me.mobjOrderIDFilter.TargetColumnDataName = "OrderID"
            ' 
            ' hierarchicInfo2
            ' 
            Me.hierarchicInfo2.BindedSource = Me.mobjProductsSource
            Me.hierarchicInfo2.FilteringDataMembers.Add(Me.mobjProductIDFilter)
            Me.hierarchicInfo2.HierarchyName = "Product Info"
            ' 
            ' mobjProductsSource
            ' 
            Me.mobjProductsSource.DataMember = "Products"
            Me.mobjProductsSource.DataSource = Me.mobjDS
            ' 
            ' mobjProductIDFilter
            ' 
            Me.mobjProductIDFilter.SourceColumnDataName = "ProductID"
            Me.mobjProductIDFilter.TargetColumnDataName = "ProductID"
            ' 
            ' ordersAdapter
            ' 
            Me.ordersAdapter.ClearBeforeFill = True
            ' 
            ' orderDetailsAdapter
            ' 
            Me.orderDetailsAdapter.ClearBeforeFill = True
            ' 
            ' productsAdapter
            ' 
            Me.productsAdapter.ClearBeforeFill = True
            ' 
            ' HierarchiesPage
            ' 
            Me.Controls.Add(Me.mobjDGV)
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Size = New System.Drawing.Size(451, 390)
            Me.Text = "HierarchiesPage"
            DirectCast(Me.mobjDGV, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjOrdersSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjDS, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjOrderDetailsSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjProductsSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub
        Private mobjDGV As Gizmox.WebGUI.Forms.DataGridView
        Private mobjOrdersSource As Gizmox.WebGUI.Forms.BindingSource
        Private hierarchicInfo1 As Gizmox.WebGUI.Forms.HierarchicInfo
        Private mobjOrderDetailsSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjOrderIDFilter As Gizmox.WebGUI.Forms.FilterRelation
        Private dataGridViewTextBoxColumn1 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn2 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn3 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn4 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn5 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn6 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn7 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn8 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn9 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn10 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn11 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn12 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn13 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private dataGridViewTextBoxColumn14 As Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn
        Private mobjProductsSource As Gizmox.WebGUI.Forms.BindingSource
        Private hierarchicInfo2 As Gizmox.WebGUI.Forms.HierarchicInfo
        Private mobjProductIDFilter As Gizmox.WebGUI.Forms.FilterRelation
        Private mobjDS As NorthwindDataSet
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label

        Private ordersAdapter As NorthwindDataSetTableAdapters.OrdersTableAdapter
        Private orderDetailsAdapter As NorthwindDataSetTableAdapters.Order_DetailsTableAdapter
        Private productsAdapter As NorthwindDataSetTableAdapters.ProductsTableAdapter
    End Class

End Namespace
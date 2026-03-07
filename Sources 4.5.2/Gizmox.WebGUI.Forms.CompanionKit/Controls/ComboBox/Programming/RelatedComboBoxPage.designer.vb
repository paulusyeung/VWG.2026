Namespace CompanionKit.Controls.ComboBox.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class RelatedComboBoxPage
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
            Me.mobjCustomerComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjFirstBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjNorthwindDataSet = New NorthwindDataSet()
            Me.mobjIDComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjSecondBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjPriceComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjThirdBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.customersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.ordersTableAdapter = New NorthwindDataSetTableAdapters.OrdersTableAdapter()
            Me.order_DetailsTableAdapter = New NorthwindDataSetTableAdapters.Order_DetailsTableAdapter()
            Me.mobjCustomersLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjIdLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPriceLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDataPriceLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDataIdLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDataCustomersLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCustomersTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjIDTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPricesTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjFifthPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjFourthPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjThirdPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSecondPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjFirstPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjFirstBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjSecondBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjThirdBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjFifthPanel.SuspendLayout()
            Me.mobjFourthPanel.SuspendLayout()
            Me.mobjThirdPanel.SuspendLayout()
            Me.mobjSecondPanel.SuspendLayout()
            Me.mobjFirstPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjCustomerComboBox
            ' 
            Me.mobjCustomerComboBox.AllowDrag = False
            Me.mobjCustomerComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjCustomerComboBox.DataSource = Me.mobjFirstBindingSource
            Me.mobjCustomerComboBox.DisplayMember = "ContactName"
            Me.mobjCustomerComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCustomerComboBox.Location = New System.Drawing.Point(331, 29)
            Me.mobjCustomerComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjCustomerComboBox.Name = "mobjCustomerComboBox"
            Me.mobjCustomerComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjCustomerComboBox.TabIndex = 0
            Me.mobjCustomerComboBox.ValueMember = "CustomerID"
            ' 
            ' mobjFirstBindingSource
            ' 
            Me.mobjFirstBindingSource.DataMember = "Customers"
            Me.mobjFirstBindingSource.DataSource = Me.mobjNorthwindDataSet
            ' 
            ' mobjNorthwindDataSet
            ' 
            Me.mobjNorthwindDataSet.DataSetName = "NorthwindDataSet"
            Me.mobjNorthwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjIDComboBox
            ' 
            Me.mobjIDComboBox.AllowDrag = False
            Me.mobjIDComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjIDComboBox.DataSource = Me.mobjSecondBindingSource
            Me.mobjIDComboBox.DisplayMember = "OrderID"
            Me.mobjIDComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjIDComboBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjIDComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjIDComboBox.Name = "mobjIDComboBox"
            Me.mobjIDComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjIDComboBox.TabIndex = 1
            Me.mobjIDComboBox.ValueMember = "OrderID"
            ' 
            ' mobjSecondBindingSource
            ' 
            Me.mobjSecondBindingSource.DataMember = "Orders"
            Me.mobjSecondBindingSource.DataSource = Me.mobjNorthwindDataSet
            ' 
            ' mobjPriceComboBox
            ' 
            Me.mobjPriceComboBox.AllowDrag = False
            Me.mobjPriceComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjPriceComboBox.DataSource = Me.mobjThirdBindingSource
            Me.mobjPriceComboBox.DisplayMember = "UnitPrice"
            Me.mobjPriceComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPriceComboBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjPriceComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjPriceComboBox.Name = "mobjPriceComboBox"
            Me.mobjPriceComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjPriceComboBox.TabIndex = 2
            Me.mobjPriceComboBox.ValueMember = "OrderID"
            ' 
            ' mobjThirdBindingSource
            ' 
            Me.mobjThirdBindingSource.DataMember = "Order Details"
            Me.mobjThirdBindingSource.DataSource = Me.mobjNorthwindDataSet
            ' 
            ' customersTableAdapter
            ' 
            Me.customersTableAdapter.ClearBeforeFill = True
            ' 
            ' ordersTableAdapter
            ' 
            Me.ordersTableAdapter.ClearBeforeFill = True
            ' 
            ' order_DetailsTableAdapter
            ' 
            Me.order_DetailsTableAdapter.ClearBeforeFill = True
            ' 
            ' mobjCustomersLabel
            ' 
            Me.mobjCustomersLabel.AutoSize = True
            Me.mobjCustomersLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCustomersLabel.Location = New System.Drawing.Point(10, 29)
            Me.mobjCustomersLabel.Name = "mobjCustomersLabel"
            Me.mobjCustomersLabel.Size = New System.Drawing.Size(321, 30)
            Me.mobjCustomersLabel.TabIndex = 3
            Me.mobjCustomersLabel.Text = "Customers"
            Me.mobjCustomersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjIdLabel
            ' 
            Me.mobjIdLabel.AutoSize = True
            Me.mobjIdLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjIdLabel.Location = New System.Drawing.Point(10, 69)
            Me.mobjIdLabel.Name = "mobjIdLabel"
            Me.mobjIdLabel.Size = New System.Drawing.Size(321, 50)
            Me.mobjIdLabel.TabIndex = 4
            Me.mobjIdLabel.Text = "Customer order IDs"
            Me.mobjIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjPriceLabel
            ' 
            Me.mobjPriceLabel.AutoSize = True
            Me.mobjPriceLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPriceLabel.Location = New System.Drawing.Point(10, 129)
            Me.mobjPriceLabel.Name = "mobjPriceLabel"
            Me.mobjPriceLabel.Size = New System.Drawing.Size(321, 50)
            Me.mobjPriceLabel.TabIndex = 5
            Me.mobjPriceLabel.Text = "Customer order prices"
            Me.mobjPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDataPriceLabel
            ' 
            Me.mobjDataPriceLabel.AutoSize = True
            Me.mobjDataPriceLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataPriceLabel.Location = New System.Drawing.Point(10, 309)
            Me.mobjDataPriceLabel.Name = "mobjDataPriceLabel"
            Me.mobjDataPriceLabel.Size = New System.Drawing.Size(321, 50)
            Me.mobjDataPriceLabel.TabIndex = 5
            Me.mobjDataPriceLabel.Text = "Data of 'Order prices'"
            Me.mobjDataPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDataIdLabel
            ' 
            Me.mobjDataIdLabel.AutoSize = True
            Me.mobjDataIdLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataIdLabel.Location = New System.Drawing.Point(10, 249)
            Me.mobjDataIdLabel.Name = "mobjDataIdLabel"
            Me.mobjDataIdLabel.Size = New System.Drawing.Size(321, 50)
            Me.mobjDataIdLabel.TabIndex = 4
            Me.mobjDataIdLabel.Text = "Data of 'Order IDs'"
            Me.mobjDataIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDataCustomersLabel
            ' 
            Me.mobjDataCustomersLabel.AutoSize = True
            Me.mobjDataCustomersLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataCustomersLabel.Location = New System.Drawing.Point(10, 189)
            Me.mobjDataCustomersLabel.Name = "mobjDataCustomersLabel"
            Me.mobjDataCustomersLabel.Size = New System.Drawing.Size(321, 50)
            Me.mobjDataCustomersLabel.TabIndex = 3
            Me.mobjDataCustomersLabel.Text = "Data of 'Customers'"
            Me.mobjDataCustomersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjCustomersTextBox
            ' 
            Me.mobjCustomersTextBox.AllowDrag = False
            Me.mobjCustomersTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCustomersTextBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjCustomersTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjCustomersTextBox.Name = "mobjCustomersTextBox"
            Me.mobjCustomersTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjCustomersTextBox.TabIndex = 6
            Me.mobjCustomersTextBox.Text = "Maria Anders"
            ' 
            ' mobjIDTextBox
            ' 
            Me.mobjIDTextBox.AllowDrag = False
            Me.mobjIDTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjIDTextBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjIDTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjIDTextBox.Name = "mobjIDTextBox"
            Me.mobjIDTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjIDTextBox.TabIndex = 7
            Me.mobjIDTextBox.Text = "10643"
            ' 
            ' mobjPricesTextBox
            ' 
            Me.mobjPricesTextBox.AllowDrag = False
            Me.mobjPricesTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPricesTextBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjPricesTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjPricesTextBox.Name = "mobjPricesTextBox"
            Me.mobjPricesTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjPricesTextBox.TabIndex = 8
            Me.mobjPricesTextBox.Text = "45.6"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCustomersLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCustomerComboBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataPriceLabel, 1, 11)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjIdLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataIdLabel, 1, 9)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataCustomersLabel, 1, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPriceLabel, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFifthPanel, 2, 11)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFourthPanel, 2, 9)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjThirdPanel, 2, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSecondPanel, 2, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFirstPanel, 2, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 13
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(663, 388)
            Me.mobjLayoutPanel.TabIndex = 9
            ' 
            ' mobjFifthPanel
            ' 
            Me.mobjFifthPanel.Controls.Add(Me.mobjPricesTextBox)
            Me.mobjFifthPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFifthPanel.DockPadding.Bottom = 10
            Me.mobjFifthPanel.DockPadding.Top = 10
            Me.mobjFifthPanel.Location = New System.Drawing.Point(331, 309)
            Me.mobjFifthPanel.Name = "mobjFifthPanel"
            Me.mobjFifthPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjFifthPanel.Size = New System.Drawing.Size(321, 50)
            Me.mobjFifthPanel.TabIndex = 0
            ' 
            ' mobjFourthPanel
            ' 
            Me.mobjFourthPanel.Controls.Add(Me.mobjIDTextBox)
            Me.mobjFourthPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFourthPanel.DockPadding.Bottom = 10
            Me.mobjFourthPanel.DockPadding.Top = 10
            Me.mobjFourthPanel.Location = New System.Drawing.Point(331, 249)
            Me.mobjFourthPanel.Name = "mobjFourthPanel"
            Me.mobjFourthPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjFourthPanel.Size = New System.Drawing.Size(321, 50)
            Me.mobjFourthPanel.TabIndex = 0
            ' 
            ' mobjThirdPanel
            ' 
            Me.mobjThirdPanel.Controls.Add(Me.mobjCustomersTextBox)
            Me.mobjThirdPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjThirdPanel.DockPadding.Bottom = 10
            Me.mobjThirdPanel.DockPadding.Top = 10
            Me.mobjThirdPanel.Location = New System.Drawing.Point(331, 189)
            Me.mobjThirdPanel.Name = "mobjThirdPanel"
            Me.mobjThirdPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjThirdPanel.Size = New System.Drawing.Size(321, 50)
            Me.mobjThirdPanel.TabIndex = 0
            ' 
            ' mobjSecondPanel
            ' 
            Me.mobjSecondPanel.Controls.Add(Me.mobjPriceComboBox)
            Me.mobjSecondPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondPanel.DockPadding.Bottom = 10
            Me.mobjSecondPanel.DockPadding.Top = 10
            Me.mobjSecondPanel.Location = New System.Drawing.Point(331, 129)
            Me.mobjSecondPanel.Name = "mobjSecondPanel"
            Me.mobjSecondPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjSecondPanel.Size = New System.Drawing.Size(321, 50)
            Me.mobjSecondPanel.TabIndex = 0
            ' 
            ' mobjFirstPanel
            ' 
            Me.mobjFirstPanel.Controls.Add(Me.mobjIDComboBox)
            Me.mobjFirstPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFirstPanel.DockPadding.Bottom = 10
            Me.mobjFirstPanel.DockPadding.Top = 10
            Me.mobjFirstPanel.Location = New System.Drawing.Point(331, 69)
            Me.mobjFirstPanel.Name = "mobjFirstPanel"
            Me.mobjFirstPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjFirstPanel.Size = New System.Drawing.Size(321, 50)
            Me.mobjFirstPanel.TabIndex = 0
            ' 
            ' RelatedComboBoxPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(663, 388)
            Me.Text = "RelatedComboBoxPage"
            DirectCast(Me.mobjFirstBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjSecondBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjThirdBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjFifthPanel.ResumeLayout(False)
            Me.mobjFourthPanel.ResumeLayout(False)
            Me.mobjThirdPanel.ResumeLayout(False)
            Me.mobjSecondPanel.ResumeLayout(False)
            Me.mobjFirstPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjCustomerComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjIDComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjNorthwindDataSet As NorthwindDataSet
        Private WithEvents mobjPriceComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private customersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter
        Private mobjFirstBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjSecondBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjThirdBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private ordersTableAdapter As NorthwindDataSetTableAdapters.OrdersTableAdapter
        Private order_DetailsTableAdapter As NorthwindDataSetTableAdapters.Order_DetailsTableAdapter
        Private mobjCustomersLabel As Gizmox.WebGUI.Forms.Label
        Private mobjIdLabel As Gizmox.WebGUI.Forms.Label
        Private mobjPriceLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDataPriceLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDataIdLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDataCustomersLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCustomersTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjIDTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjPricesTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjFifthPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFourthPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjThirdPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjSecondPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFirstPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

Namespace CompanionKit.Controls.DataGridView.PopulatingData

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FilteringPage
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
            Me.mobjDGV = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjBS = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.northwindDataSet = New Global.NorthwindDataSet()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjFilterHeadersRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjFilterRowRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjMaxFilterLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjMaxFilterNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.customersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDGV, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBS, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.northwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjGroupBox.SuspendLayout()
            DirectCast(Me.mobjMaxFilterNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDGV
            ' 
            Me.mobjDGV.AccessibleDescription = ""
            Me.mobjDGV.AccessibleName = ""
            Me.mobjDGV.AllowDrag = False
            Me.mobjDGV.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.mobjDGV.DataSource = Me.mobjBS
            Me.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDGV.Location = New System.Drawing.Point(0, 120)
            Me.mobjDGV.MaxFilterOptions = 10
            Me.mobjDGV.Name = "mobjDGV"
            Me.mobjDGV.ShowFilterRow = True
            Me.mobjDGV.Size = New System.Drawing.Size(809, 228)
            Me.mobjDGV.TabIndex = 0
            ' 
            ' mobjBS
            ' 
            Me.mobjBS.DataMember = "Customers"
            Me.mobjBS.DataSource = Me.northwindDataSet
            ' 
            ' northwindDataSet
            ' 
            Me.northwindDataSet.DataSetName = "NorthwindDataSet"
            Me.northwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.AccessibleDescription = ""
            Me.mobjGroupBox.AccessibleName = ""
            Me.mobjGroupBox.Controls.Add(Me.mobjFilterHeadersRB)
            Me.mobjGroupBox.Controls.Add(Me.mobjFilterRowRB)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(201, 120)
            Me.mobjGroupBox.TabIndex = 2
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "Filtering"
            ' 
            ' mobjFilterHeadersRB
            ' 
            Me.mobjFilterHeadersRB.AccessibleDescription = ""
            Me.mobjFilterHeadersRB.AccessibleName = ""
            Me.mobjFilterHeadersRB.Location = New System.Drawing.Point(18, 64)
            Me.mobjFilterHeadersRB.Name = "mobjFilterHeadersRB"
            Me.mobjFilterHeadersRB.Size = New System.Drawing.Size(145, 23)
            Me.mobjFilterHeadersRB.TabIndex = 1
            Me.mobjFilterHeadersRB.Text = "In Headers"
            ' 
            ' mobjFilterRowRB
            ' 
            Me.mobjFilterRowRB.AccessibleDescription = ""
            Me.mobjFilterRowRB.AccessibleName = ""
            Me.mobjFilterRowRB.Checked = True
            Me.mobjFilterRowRB.Location = New System.Drawing.Point(18, 30)
            Me.mobjFilterRowRB.Name = "mobjFilterRowRB"
            Me.mobjFilterRowRB.Size = New System.Drawing.Size(145, 23)
            Me.mobjFilterRowRB.TabIndex = 0
            Me.mobjFilterRowRB.Text = "Filter Row"
            ' 
            ' mobjMaxFilterLbl
            ' 
            Me.mobjMaxFilterLbl.AccessibleDescription = ""
            Me.mobjMaxFilterLbl.AccessibleName = ""
            Me.mobjMaxFilterLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMaxFilterLbl.Location = New System.Drawing.Point(201, 0)
            Me.mobjMaxFilterLbl.Name = "mobjMaxFilterLbl"
            Me.mobjMaxFilterLbl.Padding = New Gizmox.WebGUI.Forms.Padding(25, 0, 0, 0)
            Me.mobjMaxFilterLbl.Size = New System.Drawing.Size(608, 64)
            Me.mobjMaxFilterLbl.TabIndex = 3
            Me.mobjMaxFilterLbl.Text = "Max Filter Options"
            Me.mobjMaxFilterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjMaxFilterNUD
            ' 
            Me.mobjMaxFilterNUD.AccessibleDescription = ""
            Me.mobjMaxFilterNUD.AccessibleName = ""
            Me.mobjMaxFilterNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjMaxFilterNUD.CurrentValue = New Decimal(New Integer() {10, 0, 0, 0})
            Me.mobjMaxFilterNUD.Location = New System.Drawing.Point(204, 67)
            Me.mobjMaxFilterNUD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjMaxFilterNUD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.mobjMaxFilterNUD.Name = "mobjMaxFilterNUD"
            Me.mobjMaxFilterNUD.Size = New System.Drawing.Size(132, 21)
            Me.mobjMaxFilterNUD.TabIndex = 4
            Me.mobjMaxFilterNUD.Value = New Decimal(New Integer() {10, 0, 0, 0})
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AccessibleDescription = ""
            Me.mobjInfoLabel.AccessibleName = ""
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 348)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Padding = New Gizmox.WebGUI.Forms.Padding(20, 20, 0, 0)
            Me.mobjInfoLabel.Size = New System.Drawing.Size(809, 95)
            Me.mobjInfoLabel.TabIndex = 5
            Me.mobjInfoLabel.Text = "Use FilterRow to filter values by column in DataGridView."
            ' 
            ' customersTableAdapter
            ' 
            Me.customersTableAdapter.ClearBeforeFill = True
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.AccessibleDescription = ""
            Me.mobjPanel.AccessibleName = ""
            Me.mobjPanel.Controls.Add(Me.mobjMaxFilterLbl)
            Me.mobjPanel.Controls.Add(Me.mobjGroupBox)
            Me.mobjPanel.Controls.Add(Me.mobjMaxFilterNUD)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(809, 120)
            Me.mobjPanel.TabIndex = 6
            ' 
            ' FilteringPage
            ' 
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Controls.Add(Me.mobjDGV)
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(809, 480)
            Me.Text = "FilteringPage"
            DirectCast(Me.mobjDGV, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBS, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.northwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjGroupBox.ResumeLayout(False)
            DirectCast(Me.mobjMaxFilterNUD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjDGV As Gizmox.WebGUI.Forms.DataGridView
        Private WithEvents mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjFilterHeadersRB As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjFilterRowRB As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjMaxFilterLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjMaxFilterNUD As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label

        Private WithEvents mobjBS As Gizmox.WebGUI.Forms.BindingSource
        Private WithEvents northwindDataSet As Global.NorthwindDataSet
        Private WithEvents customersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter

        Private WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
    End Class

End Namespace
Namespace CompanionKit.Controls.DockingManager.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddingWindowsPage
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
            Me.mobjDockingManager = New Gizmox.WebGUI.Forms.DockingManager()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjWindowsTypeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjShowButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjCloseButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjPositionComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjPositionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNorthwindDataSet = New NorthwindDataSet()
            Me.mobjCustomersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.mobjCommonLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjCommonLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDockingManager
            ' 
            Me.mobjDockingManager.AllowTabbedDocuments = False
            Me.mobjDockingManager.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDockingManager.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjDockingManager.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjCommonLayoutPanel.SetColumnSpan(Me.mobjDockingManager, 3)
            Me.mobjDockingManager.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDockingManager.Location = New System.Drawing.Point(0, 0)
            Me.mobjDockingManager.Name = "objDockingManager"
            Me.mobjDockingManager.PinAnimationSpeed = 500
            Me.mobjDockingManager.Size = New System.Drawing.Size(472, 239)
            Me.mobjDockingManager.TabIndex = 0
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjComboBox.FormattingEnabled = True
            Me.mobjComboBox.Items.AddRange(New Object() {"AutoHidden", "Docked", "Float", "Tabbed"})
            Me.mobjComboBox.Location = New System.Drawing.Point(0, 284)
            Me.mobjComboBox.Name = "objComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(226, 21)
            Me.mobjComboBox.TabIndex = 1
            Me.mobjComboBox.Text = "Float"
            ' 
            ' mobjWindowsTypeLabel
            ' 
            Me.mobjWindowsTypeLabel.AutoSize = True
            Me.mobjWindowsTypeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWindowsTypeLabel.Location = New System.Drawing.Point(0, 249)
            Me.mobjWindowsTypeLabel.Name = "objWindowsTypeLabel"
            Me.mobjWindowsTypeLabel.Size = New System.Drawing.Size(226, 25)
            Me.mobjWindowsTypeLabel.TabIndex = 2
            Me.mobjWindowsTypeLabel.Text = "Windows Type"
            ' 
            ' mobjAddButton
            ' 
            Me.mobjCommonLayoutPanel.SetColumnSpan(Me.mobjAddButton, 3)
            Me.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddButton.Location = New System.Drawing.Point(0, 324)
            Me.mobjAddButton.Name = "objAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(472, 50)
            Me.mobjAddButton.TabIndex = 3
            Me.mobjAddButton.Text = "Add"
            ' 
            ' mobjShowButton
            ' 
            Me.mobjShowButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowButton.Location = New System.Drawing.Point(0, 384)
            Me.mobjShowButton.Name = "objShowButton"
            Me.mobjShowButton.Size = New System.Drawing.Size(226, 50)
            Me.mobjShowButton.TabIndex = 4
            Me.mobjShowButton.Text = "Show All"
            ' 
            ' mobjCloseButton
            ' 
            Me.mobjCloseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCloseButton.Location = New System.Drawing.Point(246, 384)
            Me.mobjCloseButton.Name = "objCloseButton"
            Me.mobjCloseButton.Size = New System.Drawing.Size(226, 50)
            Me.mobjCloseButton.TabIndex = 5
            Me.mobjCloseButton.Text = "Close All"
            ' 
            ' mobjPositionComboBox
            ' 
            Me.mobjPositionComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPositionComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjPositionComboBox.FormattingEnabled = True
            Me.mobjPositionComboBox.Items.AddRange(New Object() {"Top", "Bottom", "Left", "Right"})
            Me.mobjPositionComboBox.Location = New System.Drawing.Point(246, 284)
            Me.mobjPositionComboBox.Name = "objPositionComboBox"
            Me.mobjPositionComboBox.Size = New System.Drawing.Size(226, 21)
            Me.mobjPositionComboBox.TabIndex = 6
            Me.mobjPositionComboBox.Text = "Top"
            Me.mobjPositionComboBox.Visible = False
            ' 
            ' mobjPositionLabel
            ' 
            Me.mobjPositionLabel.AutoSize = True
            Me.mobjPositionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPositionLabel.Location = New System.Drawing.Point(246, 249)
            Me.mobjPositionLabel.Name = "objPoitionLabel"
            Me.mobjPositionLabel.Size = New System.Drawing.Size(226, 25)
            Me.mobjPositionLabel.TabIndex = 7
            Me.mobjPositionLabel.Text = "Position"
            Me.mobjPositionLabel.Visible = False
            ' 
            ' mobjNorthwindDataSet
            ' 
            Me.mobjNorthwindDataSet.DataSetName = "NorthwindDataSet"
            Me.mobjNorthwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjCustomersTableAdapter
            ' 
            Me.mobjCustomersTableAdapter.ClearBeforeFill = True
            ' 
            ' mobjCommonLayoutPanel
            ' 
            Me.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjCommonLayoutPanel.ColumnCount = 3
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjShowButton, 0, 8)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjAddButton, 0, 6)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjComboBox, 0, 4)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjCloseButton, 2, 8)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjPositionComboBox, 2, 4)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjPositionLabel, 2, 2)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjWindowsTypeLabel, 0, 2)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjDockingManager, 0, 0)
            Me.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCommonLayoutPanel.Location = New System.Drawing.Point(15, 15)
            Me.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel"
            Me.mobjCommonLayoutPanel.RowCount = 10
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 25.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjCommonLayoutPanel.Size = New System.Drawing.Size(472, 444)
            Me.mobjCommonLayoutPanel.TabIndex = 9
            ' 
            ' AddingWindowsPage
            ' 
            Me.Controls.Add(Me.mobjCommonLayoutPanel)
            Me.DockPadding.All = 15
            Me.Location = New System.Drawing.Point(0, -120)
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(502, 474)
            Me.Text = "AddingWindowsPage"
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjCommonLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private mobjDockingManager As Gizmox.WebGUI.Forms.DockingManager
        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjWindowsTypeLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjShowButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjCloseButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjPositionComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjPositionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjNorthwindDataSet As NorthwindDataSet
        Private mobjCustomersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter
        Private mobjCommonLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
Namespace CompanionKit.Controls.DockingManager.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class WindowButtonsPage
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
            Me.mobjCloseCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjDropDownCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjMaximizeCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjMinimizeCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjPinCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjNorthwindDataSet = New NorthwindDataSet()
            Me.mobjCustomersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjDockingPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjDockingPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDockingManager
            ' 
            Me.mobjDockingManager.AllowTabbedDocuments = False
            Me.mobjDockingManager.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDockingManager.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjDockingManager.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjDockingManager.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDockingManager.Location = New System.Drawing.Point(0, 0)
            Me.mobjDockingManager.Name = "objDockingManager"
            Me.mobjDockingManager.PinAnimationSpeed = 500
            Me.mobjDockingManager.Size = New System.Drawing.Size(413, 299)
            Me.mobjDockingManager.TabIndex = 0
            ' 
            ' mobjCloseCheckBox
            ' 
            Me.mobjCloseCheckBox.AutoSize = True
            Me.mobjCloseCheckBox.Checked = True
            Me.mobjCloseCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjCloseCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCloseCheckBox.Location = New System.Drawing.Point(0, 309)
            Me.mobjCloseCheckBox.Name = "objCloseCheckBox"
            Me.mobjCloseCheckBox.Size = New System.Drawing.Size(413, 30)
            Me.mobjCloseCheckBox.TabIndex = 6
            Me.mobjCloseCheckBox.Text = "ShowCloseButton"
            ' 
            ' mobjDropDownCheckBox
            ' 
            Me.mobjDropDownCheckBox.AutoSize = True
            Me.mobjDropDownCheckBox.Checked = True
            Me.mobjDropDownCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjDropDownCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDropDownCheckBox.Location = New System.Drawing.Point(0, 339)
            Me.mobjDropDownCheckBox.Name = "objDropDownCheckBox"
            Me.mobjDropDownCheckBox.Size = New System.Drawing.Size(413, 30)
            Me.mobjDropDownCheckBox.TabIndex = 7
            Me.mobjDropDownCheckBox.Text = "ShowDropDownButton"
            ' 
            ' mobjMaximizeCheckBox
            ' 
            Me.mobjMaximizeCheckBox.AutoSize = True
            Me.mobjMaximizeCheckBox.Checked = True
            Me.mobjMaximizeCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjMaximizeCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMaximizeCheckBox.Location = New System.Drawing.Point(0, 369)
            Me.mobjMaximizeCheckBox.Name = "objMaximizeCheckBox"
            Me.mobjMaximizeCheckBox.Size = New System.Drawing.Size(413, 30)
            Me.mobjMaximizeCheckBox.TabIndex = 8
            Me.mobjMaximizeCheckBox.Text = "ShowMaximizeButton"
            ' 
            ' mobjMinimizeCheckBox
            ' 
            Me.mobjMinimizeCheckBox.AutoSize = True
            Me.mobjMinimizeCheckBox.Checked = True
            Me.mobjMinimizeCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjMinimizeCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMinimizeCheckBox.Location = New System.Drawing.Point(0, 399)
            Me.mobjMinimizeCheckBox.Name = "objMinimizeCheckBox"
            Me.mobjMinimizeCheckBox.Size = New System.Drawing.Size(413, 30)
            Me.mobjMinimizeCheckBox.TabIndex = 9
            Me.mobjMinimizeCheckBox.Text = "ShowMinimizeButton"
            ' 
            ' mobjPinCheckBox
            ' 
            Me.mobjPinCheckBox.AutoSize = True
            Me.mobjPinCheckBox.Checked = True
            Me.mobjPinCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjPinCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPinCheckBox.Location = New System.Drawing.Point(0, 429)
            Me.mobjPinCheckBox.Name = "objPinCheckBox"
            Me.mobjPinCheckBox.Size = New System.Drawing.Size(413, 30)
            Me.mobjPinCheckBox.TabIndex = 10
            Me.mobjPinCheckBox.Text = "ShowPinButton"
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
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPinCheckBox, 0, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCloseCheckBox, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMinimizeCheckBox, 0, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDropDownCheckBox, 0, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjMaximizeCheckBox, 0, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDockingPanel, 0, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(15, 15)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(413, 459)
            Me.mobjLayoutPanel.TabIndex = 12
            ' 
            ' mobjDockingPanel
            ' 
            Me.mobjDockingPanel.Controls.Add(Me.mobjDockingManager)
            Me.mobjDockingPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDockingPanel.DockPadding.Bottom = 10
            Me.mobjDockingPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDockingPanel.Name = "mobjDockingPanel"
            Me.mobjDockingPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 0, 10)
            Me.mobjDockingPanel.Size = New System.Drawing.Size(413, 309)
            Me.mobjDockingPanel.TabIndex = 13
            ' 
            ' WindowButtonsPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.DockPadding.All = 15
            Me.Location = New System.Drawing.Point(0, -77)
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(443, 489)
            Me.Text = "WindowButtonsPage"
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjDockingPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDockingManager As Gizmox.WebGUI.Forms.DockingManager
        Private WithEvents mobjCloseCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjDropDownCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjMaximizeCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjMinimizeCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjPinCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjNorthwindDataSet As NorthwindDataSet
        Private mobjCustomersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjDockingPanel As Gizmox.WebGUI.Forms.Panel
	End Class

End Namespace
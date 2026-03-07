Namespace CompanionKit.Controls.DockingManager.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SaveAndLoadDataPage
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
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjSaveButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLoadButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjNorthwindDataSet = New NorthwindDataSet()
            Me.mobjCustomersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.mobInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjBottomLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLoadPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjAddPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSavePanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjCommonLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjDockingPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjBottomLayoutPanel.SuspendLayout()
            Me.mobjLoadPanel.SuspendLayout()
            Me.mobjAddPanel.SuspendLayout()
            Me.mobjSavePanel.SuspendLayout()
            Me.mobjCommonLayoutPanel.SuspendLayout()
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
            Me.mobjDockingManager.Location = New System.Drawing.Point(15, 15)
            Me.mobjDockingManager.Name = "mobjDockingManager"
            Me.mobjDockingManager.PinAnimationSpeed = 500
            Me.mobjDockingManager.Size = New System.Drawing.Size(494, 229)
            Me.mobjDockingManager.TabIndex = 0
            ' 
            ' mobjAddButton
            ' 
            Me.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddButton.Location = New System.Drawing.Point(15, 15)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(179, 71)
            Me.mobjAddButton.TabIndex = 1
            Me.mobjAddButton.Text = "Add Window"
            ' 
            ' mobjSaveButton
            ' 
            Me.mobjSaveButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSaveButton.Location = New System.Drawing.Point(15, 15)
            Me.mobjSaveButton.Name = "mobjSaveButton"
            Me.mobjSaveButton.Size = New System.Drawing.Size(127, 71)
            Me.mobjSaveButton.TabIndex = 2
            Me.mobjSaveButton.Text = "Save"
            ' 
            ' mobjLoadButton
            ' 
            Me.mobjLoadButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLoadButton.Location = New System.Drawing.Point(15, 15)
            Me.mobjLoadButton.Name = "mobjLoadButton"
            Me.mobjLoadButton.Size = New System.Drawing.Size(128, 71)
            Me.mobjLoadButton.TabIndex = 3
            Me.mobjLoadButton.Text = "Load"
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
            ' mobInfoLabel
            ' 
            Me.mobInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobInfoLabel.Location = New System.Drawing.Point(10, 10)
            Me.mobInfoLabel.Name = "mobInfoLabel"
            Me.mobInfoLabel.Size = New System.Drawing.Size(524, 50)
            Me.mobInfoLabel.TabIndex = 4
            Me.mobInfoLabel.Text = "Note: SaveData saves only DockingWindow's layout"
            Me.mobInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjBottomLayoutPanel
            ' 
            Me.mobjBottomLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjBottomLayoutPanel.ColumnCount = 3
            Me.mobjBottomLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjBottomLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjBottomLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjBottomLayoutPanel.Controls.Add(Me.mobjLoadPanel, 2, 0)
            Me.mobjBottomLayoutPanel.Controls.Add(Me.mobjAddPanel, 1, 0)
            Me.mobjBottomLayoutPanel.Controls.Add(Me.mobjSavePanel, 0, 0)
            Me.mobjBottomLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomLayoutPanel.Location = New System.Drawing.Point(10, 319)
            Me.mobjBottomLayoutPanel.Name = "mobjBottomLayoutPanel"
            Me.mobjBottomLayoutPanel.RowCount = 1
            Me.mobjBottomLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjBottomLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjBottomLayoutPanel.Size = New System.Drawing.Size(524, 101)
            Me.mobjBottomLayoutPanel.TabIndex = 5
            ' 
            ' mobjLoadPanel
            ' 
            Me.mobjLoadPanel.Controls.Add(Me.mobjLoadButton)
            Me.mobjLoadPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLoadPanel.DockPadding.All = 15
            Me.mobjLoadPanel.Location = New System.Drawing.Point(366, 0)
            Me.mobjLoadPanel.Name = "mobjLoadPanel"
            Me.mobjLoadPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjLoadPanel.Size = New System.Drawing.Size(158, 101)
            Me.mobjLoadPanel.TabIndex = 7
            ' 
            ' mobjAddPanel
            ' 
            Me.mobjAddPanel.Controls.Add(Me.mobjAddButton)
            Me.mobjAddPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddPanel.DockPadding.All = 15
            Me.mobjAddPanel.Location = New System.Drawing.Point(157, 0)
            Me.mobjAddPanel.Name = "mobjAddPanel"
            Me.mobjAddPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjAddPanel.Size = New System.Drawing.Size(209, 101)
            Me.mobjAddPanel.TabIndex = 7
            ' 
            ' mobjSavePanel
            ' 
            Me.mobjSavePanel.Controls.Add(Me.mobjSaveButton)
            Me.mobjSavePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSavePanel.DockPadding.All = 15
            Me.mobjSavePanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSavePanel.Name = "mobjSavePanel"
            Me.mobjSavePanel.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjSavePanel.Size = New System.Drawing.Size(157, 101)
            Me.mobjSavePanel.TabIndex = 7
            ' 
            ' mobjCommonLayoutPanel
            ' 
            Me.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjCommonLayoutPanel.ColumnCount = 1
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjDockingPanel, 0, 1)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobInfoLabel, 0, 0)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjBottomLayoutPanel, 0, 2)
            Me.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCommonLayoutPanel.Location = New System.Drawing.Point(20, 20)
            Me.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel"
            Me.mobjCommonLayoutPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjCommonLayoutPanel.RowCount = 3
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 72.22222F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.77778F))
            Me.mobjCommonLayoutPanel.Size = New System.Drawing.Size(544, 430)
            Me.mobjCommonLayoutPanel.TabIndex = 6
            ' 
            ' mobjDockingPanel
            ' 
            Me.mobjDockingPanel.Controls.Add(Me.mobjDockingManager)
            Me.mobjDockingPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDockingPanel.DockPadding.All = 15
            Me.mobjDockingPanel.Location = New System.Drawing.Point(10, 60)
            Me.mobjDockingPanel.Name = "mobjDockingPanel"
            Me.mobjDockingPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjDockingPanel.Size = New System.Drawing.Size(524, 259)
            Me.mobjDockingPanel.TabIndex = 7
            ' 
            ' SaveAndLoadDataPage
            ' 
            Me.Controls.Add(Me.mobjCommonLayoutPanel)
            Me.DockPadding.All = 20
            Me.Location = New System.Drawing.Point(0, -15)
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(20)
            Me.Size = New System.Drawing.Size(584, 470)
            Me.Text = "SaveAndLoadDataPage"
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjBottomLayoutPanel.ResumeLayout(False)
            Me.mobjLoadPanel.ResumeLayout(False)
            Me.mobjAddPanel.ResumeLayout(False)
            Me.mobjSavePanel.ResumeLayout(False)
            Me.mobjCommonLayoutPanel.ResumeLayout(False)
            Me.mobjDockingPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDockingManager As Gizmox.WebGUI.Forms.DockingManager
        Private WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjSaveButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjLoadButton As Gizmox.WebGUI.Forms.Button
        Private mobjNorthwindDataSet As NorthwindDataSet
        Private mobjCustomersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter
        Private mobInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjBottomLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjCommonLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjSavePanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLoadPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjAddPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjDockingPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
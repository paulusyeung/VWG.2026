Namespace CompanionKit.Controls.DockingManager.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PinWindowsPage
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
            Me.mobjPinButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjUnpinButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjNorthwindDataSet = New NorthwindDataSet()
            Me.mobjCustomersTableAdapter = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDockingManager
            ' 
            Me.mobjDockingManager.AllowTabbedDocuments = False
            Me.mobjDockingManager.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjDockingManager.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjDockingManager.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjDockingManager.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDockingManager.Location = New System.Drawing.Point(20, 20)
            Me.mobjDockingManager.Name = "objDockingManager"
            Me.mobjDockingManager.PinAnimationSpeed = 500
            Me.mobjDockingManager.Size = New System.Drawing.Size(261, 207)
            Me.mobjDockingManager.TabIndex = 0
            ' 
            ' mobjPinButton
            ' 
            Me.mobjPinButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPinButton.Location = New System.Drawing.Point(0, 267)
            Me.mobjPinButton.Name = "objPinButton"
            Me.mobjPinButton.Size = New System.Drawing.Size(140, 50)
            Me.mobjPinButton.TabIndex = 2
            Me.mobjPinButton.Text = "Pin All"
            ' 
            ' mobjUnpinButton
            ' 
            Me.mobjUnpinButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjUnpinButton.Location = New System.Drawing.Point(160, 267)
            Me.mobjUnpinButton.Name = "objUnpinButton"
            Me.mobjUnpinButton.Size = New System.Drawing.Size(141, 50)
            Me.mobjUnpinButton.TabIndex = 3
            Me.mobjUnpinButton.Text = "Unpin All"
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
            ' mobjTopPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjTopPanel, 3)
            Me.mobjTopPanel.Controls.Add(Me.mobjDockingManager)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.DockPadding.All = 20
            Me.mobjTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(20)
            Me.mobjTopPanel.Size = New System.Drawing.Size(301, 247)
            Me.mobjTopPanel.TabIndex = 6
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjUnpinButton, 2, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPinButton, 0, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(30, 30)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(301, 317)
            Me.mobjLayoutPanel.TabIndex = 7
            ' 
            ' PinWindowsPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.DockPadding.All = 30
            Me.Location = New System.Drawing.Point(0, -23)
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(30)
            Me.Size = New System.Drawing.Size(361, 377)
            Me.Text = "PinWindowsPage"
            DirectCast(Me.mobjNorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDockingManager As Gizmox.WebGUI.Forms.DockingManager
        Private WithEvents mobjPinButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjUnpinButton As Gizmox.WebGUI.Forms.Button
        Private mobjNorthwindDataSet As NorthwindDataSet
        Private mobjCustomersTableAdapter As NorthwindDataSetTableAdapters.CustomersTableAdapter
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace
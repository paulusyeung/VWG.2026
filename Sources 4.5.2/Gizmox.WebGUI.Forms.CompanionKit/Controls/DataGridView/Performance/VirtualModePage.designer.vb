Namespace CompanionKit.Controls.DataGridView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class VirtualModePage
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
            Me.mobjDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjDGVBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjDGVUserDS = New CompanionKit.Controls.DataGridView.UserDS()
            Me.mobjVirtualDataGridView = New Gizmox.WebGUI.Forms.VirtualDataGridView()
            Me.mobjVDGVBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjVDGVUserDS = New CompanionKit.Controls.DataGridView.UserDS()
            Me.mobjFillDGVButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDVGLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFillVDGVButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjVDGVLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjDGVBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjDGVUserDS, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjVirtualDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjVDGVBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjVDGVUserDS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDataGridView
            ' 
            Me.mobjDataGridView.AllowDrag = False
            Me.mobjDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.mobjDataGridView.DataSource = Me.mobjDGVBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 90)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.Size = New System.Drawing.Size(686, 116)
            Me.mobjDataGridView.TabIndex = 0
            Me.mobjDataGridView.UseInternalPaging = False
            Me.mobjDataGridView.VirtualMode = True
            ' 
            ' mobjDGVBindingSource
            ' 
            Me.mobjDGVBindingSource.DataMember = "Users"
            Me.mobjDGVBindingSource.DataSource = Me.mobjDGVUserDS
            ' 
            ' mobjDGVUserDS
            ' 
            Me.mobjDGVUserDS.DataSetName = "UserDS"
            Me.mobjDGVUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjVirtualDataGridView
            ' 
            Me.mobjVirtualDataGridView.AllowDrag = False
            Me.mobjVirtualDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.mobjVirtualDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.mobjVirtualDataGridView.CustomStyle = "V"
            Me.mobjVirtualDataGridView.DataSource = Me.mobjVDGVBindingSource
            Me.mobjVirtualDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjVirtualDataGridView.Location = New System.Drawing.Point(0, 281)
            Me.mobjVirtualDataGridView.Name = "mobjVirtualDataGridView"
            Me.mobjVirtualDataGridView.Size = New System.Drawing.Size(686, 116)
            Me.mobjVirtualDataGridView.TabIndex = 1
            ' 
            ' mobjVDGVBindingSource
            ' 
            Me.mobjVDGVBindingSource.DataMember = "Users"
            Me.mobjVDGVBindingSource.DataSource = Me.mobjVDGVUserDS
            ' 
            ' mobjVDGVUserDS
            ' 
            Me.mobjVDGVUserDS.DataSetName = "UserDS"
            Me.mobjVDGVUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' mobjFillDGVButton
            ' 
            Me.mobjFillDGVButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFillDGVButton.Location = New System.Drawing.Point(701, 90)
            Me.mobjFillDGVButton.Name = "mobjFillDGVButton"
            Me.mobjFillDGVButton.Size = New System.Drawing.Size(75, 75)
            Me.mobjFillDGVButton.TabIndex = 0
            Me.mobjFillDGVButton.Text = "Fill data"
            ' 
            ' mobjDVGLabel
            ' 
            Me.mobjDVGLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDVGLabel, 4)
            Me.mobjDVGLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDVGLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDVGLabel.Name = "mobjDVGLabel"
            Me.mobjDVGLabel.Size = New System.Drawing.Size(791, 90)
            Me.mobjDVGLabel.TabIndex = 2
            Me.mobjDVGLabel.Text = "DataGridView: " & vbCr & vbLf & "Press ""Fill data"" button to fill DGV with 3000 items " & vbCr & vbLf & "(Caution: " + "It may cause page fault )"
            Me.mobjDVGLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjFillVDGVButton
            ' 
            Me.mobjFillVDGVButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFillVDGVButton.Location = New System.Drawing.Point(701, 281)
            Me.mobjFillVDGVButton.Name = "mobjFillVDGVButton"
            Me.mobjFillVDGVButton.Size = New System.Drawing.Size(75, 75)
            Me.mobjFillVDGVButton.TabIndex = 0
            Me.mobjFillVDGVButton.Text = "Fill data"
            ' 
            ' mobjVDGVLabel
            ' 
            Me.mobjVDGVLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjVDGVLabel, 4)
            Me.mobjVDGVLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjVDGVLabel.Location = New System.Drawing.Point(0, 206)
            Me.mobjVDGVLabel.Name = "mobjVDGVLabel"
            Me.mobjVDGVLabel.Size = New System.Drawing.Size(791, 75)
            Me.mobjVDGVLabel.TabIndex = 2
            Me.mobjVDGVLabel.Text = "VirtualDataGridView: " & vbCr & vbLf & "Press ""Fill data"" button to fill VDGV with 3000 items"
            Me.mobjVDGVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 75.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjVDGVLabel, 0, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDVGLabel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFillDGVButton, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFillVDGVButton, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataGridView, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjVirtualDataGridView, 0, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(15, 15)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 90.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 75.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(791, 397)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' VirtualModePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.DockPadding.Bottom = 15
            Me.DockPadding.Left = 15
            Me.DockPadding.Top = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15, 15, 0, 15)
            Me.Size = New System.Drawing.Size(806, 427)
            Me.Text = "VirtualModePage"
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjDGVBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjDGVUserDS, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjVirtualDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjVDGVBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjVDGVUserDS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjDGVBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjDGVUserDS As CompanionKit.Controls.DataGridView.UserDS
        Private mobjDataGridView As Gizmox.WebGUI.Forms.DataGridView
        Private mobjVirtualDataGridView As Gizmox.WebGUI.Forms.VirtualDataGridView
        Private WithEvents mobjFillDGVButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjFillVDGVButton As Gizmox.WebGUI.Forms.Button
        Private mobjVDGVBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjVDGVUserDS As CompanionKit.Controls.DataGridView.UserDS
        Private mobjDVGLabel As Gizmox.WebGUI.Forms.Label
        Private mobjVDGVLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
	End Class

End Namespace
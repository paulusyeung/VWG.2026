Namespace CompanionKit.Controls.TreeView.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class EnsureVisiblePage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTreeView = New Gizmox.WebGUI.Forms.TreeView()
            Me.mobjTreeNode1 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode12 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode2 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode13 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode3 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode14 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode4 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode15 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode5 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode16 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode6 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode17 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode7 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode18 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode8 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode19 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode9 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode20 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode10 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode21 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode11 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjNodeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTreeViewPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjInfoLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTreeViewPanel.SuspendLayout()
            Me.mobjInfoLabelPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AutoSize = True
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(116, 13)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "A TreeView with nodes"
            ' 
            ' mobjTreeView
            ' 
            Me.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeView.Location = New System.Drawing.Point(0, 0)
            Me.mobjTreeView.Name = "mobjTreeView"
            Me.mobjTreeView.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode1, Me.mobjTreeNode2, Me.mobjTreeNode3, Me.mobjTreeNode4, Me.mobjTreeNode5, Me.mobjTreeNode6, _
             Me.mobjTreeNode7, Me.mobjTreeNode8, Me.mobjTreeNode9, Me.mobjTreeNode10, Me.mobjTreeNode11})
            Me.mobjTreeView.Size = New System.Drawing.Size(404, 70)
            Me.mobjTreeView.TabIndex = 1
            ' 
            ' mobjTreeNode1
            ' 
            Me.mobjTreeNode1.Name = "treeNode1"
            Me.mobjTreeNode1.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode12})
            Me.mobjTreeNode1.Text = "Tree Node 01"
            ' 
            ' mobjTreeNode12
            ' 
            Me.mobjTreeNode12.Name = "treeNode12"
            Me.mobjTreeNode12.Text = "Tree Node 12"
            ' 
            ' mobjTreeNode2
            ' 
            Me.mobjTreeNode2.Name = "treeNode2"
            Me.mobjTreeNode2.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode13})
            Me.mobjTreeNode2.Text = "Tree Node 02"
            ' 
            ' mobjTreeNode13
            ' 
            Me.mobjTreeNode13.Name = "treeNode13"
            Me.mobjTreeNode13.Text = "Tree Node 13"
            ' 
            ' mobjTreeNode3
            ' 
            Me.mobjTreeNode3.Name = "treeNode3"
            Me.mobjTreeNode3.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode14})
            Me.mobjTreeNode3.Text = "Tree Node 03"
            ' 
            ' mobjTreeNode14
            ' 
            Me.mobjTreeNode14.Name = "treeNode14"
            Me.mobjTreeNode14.Text = "Tree Node 14"
            ' 
            ' mobjTreeNode4
            ' 
            Me.mobjTreeNode4.Name = "treeNode4"
            Me.mobjTreeNode4.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode15})
            Me.mobjTreeNode4.Text = "Tree Node 04"
            ' 
            ' mobjTreeNode15
            ' 
            Me.mobjTreeNode15.Name = "treeNode15"
            Me.mobjTreeNode15.Text = "Tree Node 15"
            ' 
            ' mobjTreeNode5
            ' 
            Me.mobjTreeNode5.Name = "treeNode5"
            Me.mobjTreeNode5.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode16})
            Me.mobjTreeNode5.Text = "Tree Node 05"
            ' 
            ' mobjTreeNode16
            ' 
            Me.mobjTreeNode16.Name = "treeNode16"
            Me.mobjTreeNode16.Text = "Tree Node 16"
            ' 
            ' mobjTreeNode6
            ' 
            Me.mobjTreeNode6.Name = "treeNode6"
            Me.mobjTreeNode6.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode17})
            Me.mobjTreeNode6.Text = "Tree Node 06"
            ' 
            ' mobjTreeNode17
            ' 
            Me.mobjTreeNode17.Name = "treeNode17"
            Me.mobjTreeNode17.Text = "Tree Node 17"
            ' 
            ' mobjTreeNode7
            ' 
            Me.mobjTreeNode7.Name = "treeNode7"
            Me.mobjTreeNode7.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode18})
            Me.mobjTreeNode7.Text = "Tree Node 07"
            ' 
            ' mobjTreeNode18
            ' 
            Me.mobjTreeNode18.Name = "treeNode18"
            Me.mobjTreeNode18.Text = "Tree Node 18"
            ' 
            ' mobjTreeNode8
            ' 
            Me.mobjTreeNode8.Name = "treeNode8"
            Me.mobjTreeNode8.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode19})
            Me.mobjTreeNode8.Text = "Tree Node 08"
            ' 
            ' mobjTreeNode19
            ' 
            Me.mobjTreeNode19.Name = "treeNode19"
            Me.mobjTreeNode19.Text = "Tree Node 19"
            ' 
            ' mobjTreeNode9
            ' 
            Me.mobjTreeNode9.Name = "treeNode9"
            Me.mobjTreeNode9.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode20})
            Me.mobjTreeNode9.Text = "Tree Node 09"
            ' 
            ' mobjTreeNode20
            ' 
            Me.mobjTreeNode20.Name = "treeNode20"
            Me.mobjTreeNode20.Text = "Tree Node 20"
            ' 
            ' mobjTreeNode10
            ' 
            Me.mobjTreeNode10.Name = "treeNode10"
            Me.mobjTreeNode10.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode21})
            Me.mobjTreeNode10.Text = "Tree Node 10"
            ' 
            ' mobjTreeNode21
            ' 
            Me.mobjTreeNode21.Name = "treeNode21"
            Me.mobjTreeNode21.Text = "Tree Node 21"
            ' 
            ' mobjTreeNode11
            ' 
            Me.mobjTreeNode11.Name = "treeNode11"
            Me.mobjTreeNode11.Text = "Tree Node 11"
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjComboBox.Location = New System.Drawing.Point(260, 131)
            Me.mobjComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(192, 30)
            Me.mobjComboBox.TabIndex = 2
            ' 
            ' mobjNodeLabel
            ' 
            Me.mobjNodeLabel.AutoSize = True
            Me.mobjNodeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNodeLabel.Location = New System.Drawing.Point(48, 131)
            Me.mobjNodeLabel.Name = "mobjNodeLabel"
            Me.mobjNodeLabel.Size = New System.Drawing.Size(192, 50)
            Me.mobjNodeLabel.TabIndex = 3
            Me.mobjNodeLabel.Text = "Select a node"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 3, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNodeLabel, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeViewPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoLabelPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(502, 217)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjTreeViewPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjTreeViewPanel, 3)
            Me.mobjTreeViewPanel.Controls.Add(Me.mobjTreeView)
            Me.mobjTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewPanel.Location = New System.Drawing.Point(48, 41)
            Me.mobjTreeViewPanel.Name = "mobjTreeViewPanel"
            Me.mobjTreeViewPanel.Size = New System.Drawing.Size(404, 70)
            Me.mobjTreeViewPanel.TabIndex = 0
            ' 
            ' mobjInfoLabelPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjInfoLabelPanel, 3)
            Me.mobjInfoLabelPanel.Controls.Add(Me.mobjInfoLabel)
            Me.mobjInfoLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabelPanel.Location = New System.Drawing.Point(48, 11)
            Me.mobjInfoLabelPanel.Name = "mobjInfoLabelPanel"
            Me.mobjInfoLabelPanel.Size = New System.Drawing.Size(404, 20)
            Me.mobjInfoLabelPanel.TabIndex = 0
            ' 
            ' EnsureVisiblePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(502, 217)
            Me.Text = "EnsureVisiblePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTreeViewPanel.ResumeLayout(False)
            Me.mobjInfoLabelPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjInfoLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTreeView As Global.Gizmox.WebGUI.Forms.TreeView
        Private mobjTreeNode1 As TreeNode
        Private mobjTreeNode2 As TreeNode
        Private mobjTreeNode3 As TreeNode
        Private mobjTreeNode4 As TreeNode
        Private mobjTreeNode5 As TreeNode
        Private mobjTreeNode6 As TreeNode
        Private mobjTreeNode7 As TreeNode
        Private mobjTreeNode8 As TreeNode
        Private mobjTreeNode9 As TreeNode
        Private mobjTreeNode10 As TreeNode
        Private mobjTreeNode11 As TreeNode
        Private mobjTreeNode12 As TreeNode
        Private mobjTreeNode13 As TreeNode
        Private mobjTreeNode14 As TreeNode
        Private mobjTreeNode15 As TreeNode
        Private mobjTreeNode16 As TreeNode
        Private mobjTreeNode17 As TreeNode
        Private mobjTreeNode18 As TreeNode
        Private mobjTreeNode19 As TreeNode
        Private mobjTreeNode20 As TreeNode
        Private mobjTreeNode21 As TreeNode
        Private WithEvents mobjComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private mobjNodeLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTreeViewPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjInfoLabelPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

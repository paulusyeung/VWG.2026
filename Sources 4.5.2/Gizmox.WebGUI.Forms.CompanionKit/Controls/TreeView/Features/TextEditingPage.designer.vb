Namespace CompanionKit.Controls.TreeView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextEditingPage
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
            Me.mobjAllowedLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTreeViewallowedlabelEditing = New Gizmox.WebGUI.Forms.TreeView()
            Me.mobjTreeNode1 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode4 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode2 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode5 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode6 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode3 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode7 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode8 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode9 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjUnallowedLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTreeViewUnallowedlabelEditing = New Gizmox.WebGUI.Forms.TreeView()
            Me.mobjTreeNode10 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode13 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode11 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode14 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode15 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode12 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode16 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode17 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode18 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjAllowedLabel
            ' 
            Me.mobjAllowedLabel.AutoSize = True
            Me.mobjAllowedLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAllowedLabel.Location = New System.Drawing.Point(57, 16)
            Me.mobjAllowedLabel.Name = "mobjAllowedLabel"
            Me.mobjAllowedLabel.Size = New System.Drawing.Size(228, 50)
            Me.mobjAllowedLabel.TabIndex = 0
            Me.mobjAllowedLabel.Text = "Editing is allowed "
            Me.mobjAllowedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjTreeViewallowedlabelEditing
            ' 
            Me.mobjTreeViewallowedlabelEditing.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewallowedlabelEditing.LabelEdit = True
            Me.mobjTreeViewallowedlabelEditing.Location = New System.Drawing.Point(57, 76)
            Me.mobjTreeViewallowedlabelEditing.Name = "mobjTreeViewallowedlabelEditing"
            Me.mobjTreeViewallowedlabelEditing.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode1, Me.mobjTreeNode2, Me.mobjTreeNode3})
            Me.mobjTreeViewallowedlabelEditing.Size = New System.Drawing.Size(228, 100)
            Me.mobjTreeViewallowedlabelEditing.TabIndex = 1
            ' 
            ' mobjTreeNode1
            ' 
            Me.mobjTreeNode1.Name = "treeNode1"
            Me.mobjTreeNode1.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode4})
            Me.mobjTreeNode1.Text = "Tree Node1"
            ' 
            ' mobjTreeNode4
            ' 
            Me.mobjTreeNode4.Name = "treeNode4"
            Me.mobjTreeNode4.Text = "Tree Node4"
            ' 
            ' mobjTreeNode2
            ' 
            Me.mobjTreeNode2.Name = "treeNode2"
            Me.mobjTreeNode2.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode5, Me.mobjTreeNode6})
            Me.mobjTreeNode2.Text = "Tree Node2"
            ' 
            ' mobjTreeNode5
            ' 
            Me.mobjTreeNode5.Name = "treeNode5"
            Me.mobjTreeNode5.Text = "Tree Node5"
            ' 
            ' mobjTreeNode6
            ' 
            Me.mobjTreeNode6.Name = "treeNode6"
            Me.mobjTreeNode6.Text = "Tree Node6"
            ' 
            ' mobjTreeNode3
            ' 
            Me.mobjTreeNode3.Name = "treeNode3"
            Me.mobjTreeNode3.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode7, Me.mobjTreeNode8, Me.mobjTreeNode9})
            Me.mobjTreeNode3.Text = "Tree Node3"
            ' 
            ' mobjTreeNode7
            ' 
            Me.mobjTreeNode7.Name = "treeNode7"
            Me.mobjTreeNode7.Text = "Tree Node7"
            ' 
            ' mobjTreeNode8
            ' 
            Me.mobjTreeNode8.Name = "treeNode8"
            Me.mobjTreeNode8.Text = "Tree Node8"
            ' 
            ' mobjTreeNode9
            ' 
            Me.mobjTreeNode9.Name = "treeNode9"
            Me.mobjTreeNode9.Text = "Tree Node9"
            ' 
            ' mobjUnallowedLabel
            ' 
            Me.mobjUnallowedLabel.AutoSize = True
            Me.mobjUnallowedLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjUnallowedLabel.Location = New System.Drawing.Point(305, 16)
            Me.mobjUnallowedLabel.Name = "mobjUnallowedLabel"
            Me.mobjUnallowedLabel.Size = New System.Drawing.Size(228, 50)
            Me.mobjUnallowedLabel.TabIndex = 2
            Me.mobjUnallowedLabel.Text = "Editing is unallowed"
            Me.mobjUnallowedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjTreeViewUnallowedlabelEditing
            ' 
            Me.mobjTreeViewUnallowedlabelEditing.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewUnallowedlabelEditing.Location = New System.Drawing.Point(305, 76)
            Me.mobjTreeViewUnallowedlabelEditing.Name = "mobjTreeViewUnallowedlabelEditing"
            Me.mobjTreeViewUnallowedlabelEditing.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode10, Me.mobjTreeNode11, Me.mobjTreeNode12})
            Me.mobjTreeViewUnallowedlabelEditing.Size = New System.Drawing.Size(228, 100)
            Me.mobjTreeViewUnallowedlabelEditing.TabIndex = 3
            ' 
            ' mobjTreeNode10
            ' 
            Me.mobjTreeNode10.Name = "treeNode10"
            Me.mobjTreeNode10.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode13})
            Me.mobjTreeNode10.Text = "Tree Node1"
            ' 
            ' mobjTreeNode13
            ' 
            Me.mobjTreeNode13.Name = "treeNode13"
            Me.mobjTreeNode13.Text = "Tree Node4"
            ' 
            ' mobjTreeNode11
            ' 
            Me.mobjTreeNode11.Name = "treeNode11"
            Me.mobjTreeNode11.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode14, Me.mobjTreeNode15})
            Me.mobjTreeNode11.Text = "Tree Node2"
            ' 
            ' mobjTreeNode14
            ' 
            Me.mobjTreeNode14.Name = "treeNode14"
            Me.mobjTreeNode14.Text = "Tree Node5"
            ' 
            ' mobjTreeNode15
            ' 
            Me.mobjTreeNode15.Name = "treeNode15"
            Me.mobjTreeNode15.Text = "Tree Node6"
            ' 
            ' mobjTreeNode12
            ' 
            Me.mobjTreeNode12.Name = "treeNode12"
            Me.mobjTreeNode12.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode16, Me.mobjTreeNode17, Me.mobjTreeNode18})
            Me.mobjTreeNode12.Text = "Tree Node3"
            ' 
            ' mobjTreeNode16
            ' 
            Me.mobjTreeNode16.Name = "treeNode16"
            Me.mobjTreeNode16.Text = "Tree Node7"
            ' 
            ' mobjTreeNode17
            ' 
            Me.mobjTreeNode17.Name = "treeNode17"
            Me.mobjTreeNode17.Text = "Tree Node8"
            ' 
            ' mobjTreeNode18
            ' 
            Me.mobjTreeNode18.Name = "treeNode18"
            Me.mobjTreeNode18.Text = "Tree Node9"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjUnallowedLabel, 3, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeViewallowedlabelEditing, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeViewUnallowedlabelEditing, 3, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAllowedLabel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(590, 228)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' TextEditingPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(590, 228)
            Me.Text = "TextEditingPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjAllowedLabel As Gizmox.WebGUI.Forms.Label
        Private mobjTreeViewallowedlabelEditing As Global.Gizmox.WebGUI.Forms.TreeView
        Private mobjTreeNode1 As TreeNode
        Private mobjTreeNode4 As TreeNode
        Private mobjTreeNode2 As TreeNode
        Private mobjTreeNode5 As TreeNode
        Private mobjTreeNode6 As TreeNode
        Private mobjTreeNode3 As TreeNode
        Private mobjTreeNode7 As TreeNode
        Private mobjTreeNode8 As TreeNode
        Private mobjTreeNode9 As TreeNode
        Private mobjUnallowedLabel As Label
        Private mobjTreeViewUnallowedlabelEditing As Gizmox.WebGUI.Forms.TreeView
        Private mobjTreeNode10 As TreeNode
        Private mobjTreeNode13 As TreeNode
        Private mobjTreeNode11 As TreeNode
        Private mobjTreeNode14 As TreeNode
        Private mobjTreeNode15 As TreeNode
        Private mobjTreeNode12 As TreeNode
        Private mobjTreeNode16 As TreeNode
        Private mobjTreeNode17 As TreeNode
        Private mobjTreeNode18 As TreeNode
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace

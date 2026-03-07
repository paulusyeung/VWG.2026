Namespace CompanionKit.Controls.TreeView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddAndRemoveNodesPage
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
            Me.mobjTreeView = New Gizmox.WebGUI.Forms.TreeView()
            Me.mobjTreeNode1 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode2 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode3 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeViewLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNodeNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjRemoveButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobLabelPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTreeView
            ' 
            Me.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeView.Location = New System.Drawing.Point(0, 0)
            Me.mobjTreeView.Name = "mobjTreeView"
            Me.mobjTreeView.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode1, Me.mobjTreeNode2, Me.mobjTreeNode3})
            Me.mobjTreeView.Size = New System.Drawing.Size(434, 63)
            Me.mobjTreeView.TabIndex = 0
            ' 
            ' mobjTreeNode1
            ' 
            Me.mobjTreeNode1.Name = "treeNode1"
            Me.mobjTreeNode1.Text = "Tree Node1"
            ' 
            ' mobjTreeNode2
            ' 
            Me.mobjTreeNode2.Name = "treeNode2"
            Me.mobjTreeNode2.Text = "Tree Node2"
            ' 
            ' mobjTreeNode3
            ' 
            Me.mobjTreeNode3.Name = "treeNode3"
            Me.mobjTreeNode3.Text = "Tree Node3"
            ' 
            ' mobjTreeViewLabel
            ' 
            Me.mobjTreeViewLabel.AutoSize = True
            Me.mobjTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTreeViewLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTreeViewLabel.Name = "mobjTreeViewLabel"
            Me.mobjTreeViewLabel.Size = New System.Drawing.Size(100, 13)
            Me.mobjTreeViewLabel.TabIndex = 1
            Me.mobjTreeViewLabel.Text = "Extended TreeView"
            ' 
            ' mobjNodeNameLabel
            ' 
            Me.mobjNodeNameLabel.AutoSize = True
            Me.mobjNodeNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjNodeNameLabel.Location = New System.Drawing.Point(88, 126)
            Me.mobjNodeNameLabel.Name = "mobjNodeNameLabel"
            Me.mobjNodeNameLabel.Size = New System.Drawing.Size(207, 13)
            Me.mobjNodeNameLabel.TabIndex = 2
            Me.mobjNodeNameLabel.Text = "Added node name"
            ' 
            ' mobjAddButton
            ' 
            Me.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjAddButton.Location = New System.Drawing.Point(88, 186)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(207, 50)
            Me.mobjAddButton.TabIndex = 3
            Me.mobjAddButton.Text = "Add a new node"
            Me.mobjAddButton.UseVisualStyleBackColor = True
            ' 
            ' mobjRemoveButton
            ' 
            Me.mobjRemoveButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjRemoveButton.Location = New System.Drawing.Point(315, 186)
            Me.mobjRemoveButton.Name = "mobjRemoveButton"
            Me.mobjRemoveButton.Size = New System.Drawing.Size(207, 50)
            Me.mobjRemoveButton.TabIndex = 4
            Me.mobjRemoveButton.Text = "Remove selected node"
            Me.mobjRemoveButton.UseVisualStyleBackColor = True
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTextBox.Location = New System.Drawing.Point(318, 129)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(201, 30)
            Me.mobjTextBox.TabIndex = 5
            Me.mobjTextBox.Text = "Added Node"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjRemoveButton, 3, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTextBox, 3, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAddButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNodeNameLabel, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobLabelPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(612, 251)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' mobjPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel, 3)
            Me.mobjPanel.Controls.Add(Me.mobjTreeView)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(88, 43)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(434, 63)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobLabelPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobLabelPanel, 3)
            Me.mobLabelPanel.Controls.Add(Me.mobjTreeViewLabel)
            Me.mobLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobLabelPanel.Location = New System.Drawing.Point(88, 13)
            Me.mobLabelPanel.Name = "mobLabelPanel"
            Me.mobLabelPanel.Size = New System.Drawing.Size(434, 30)
            Me.mobLabelPanel.TabIndex = 0
            ' 
            ' AddAndRemoveNodesPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(612, 251)
            Me.Text = "AddAndRemoveNodesPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobLabelPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjTreeView As Global.Gizmox.WebGUI.Forms.TreeView
        Private mobjTreeViewLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjNodeNameLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjAddButton As Global.Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjRemoveButton As Global.Gizmox.WebGUI.Forms.Button
        Private mobjTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Private mobjTreeNode1 As TreeNode
        Private mobjTreeNode2 As TreeNode
        Private mobjTreeNode3 As TreeNode
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobLabelPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace

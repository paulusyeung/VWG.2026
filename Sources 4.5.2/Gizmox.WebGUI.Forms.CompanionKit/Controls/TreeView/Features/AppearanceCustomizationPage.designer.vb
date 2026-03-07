Namespace CompanionKit.Controls.TreeView.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AppearanceCustomizationPage
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
            Me.mobjTreeNode6 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode7 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode2 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode8 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode9 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode3 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode10 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode11 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode4 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode12 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode13 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode5 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode14 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode15 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjLinesCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjPlusMinusCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTreeView
            ' 
            Me.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeView.Location = New System.Drawing.Point(74, 26)
            Me.mobjTreeView.Name = "mobjTreeView"
            Me.mobjTreeView.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode1, Me.mobjTreeNode2, Me.mobjTreeNode3, Me.mobjTreeNode4, Me.mobjTreeNode5})
            Me.mobjTreeView.Size = New System.Drawing.Size(200, 121)
            Me.mobjTreeView.TabIndex = 0
            ' 
            ' mobjTreeNode1
            ' 
            Me.mobjTreeNode1.Name = ""
            Me.mobjTreeNode1.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode6, Me.mobjTreeNode7})
            Me.mobjTreeNode1.Text = "treeNode1"
            ' 
            ' mobjTreeNode6
            ' 
            Me.mobjTreeNode6.Name = ""
            Me.mobjTreeNode6.Text = "treeNode6"
            ' 
            ' mobjTreeNode7
            ' 
            Me.mobjTreeNode7.Name = ""
            Me.mobjTreeNode7.Text = "treeNode7"
            ' 
            ' mobjTreeNode2
            ' 
            Me.mobjTreeNode2.Name = ""
            Me.mobjTreeNode2.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode8, Me.mobjTreeNode9})
            Me.mobjTreeNode2.Text = "treeNode2"
            ' 
            ' mobjTreeNode8
            ' 
            Me.mobjTreeNode8.Name = ""
            Me.mobjTreeNode8.Text = "treeNode8"
            ' 
            ' mobjTreeNode9
            ' 
            Me.mobjTreeNode9.Name = ""
            Me.mobjTreeNode9.Text = "treeNode9"
            ' 
            ' mobjTreeNode3
            ' 
            Me.mobjTreeNode3.Name = ""
            Me.mobjTreeNode3.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode10, Me.mobjTreeNode11})
            Me.mobjTreeNode3.Text = "treeNode3"
            ' 
            ' mobjTreeNode10
            ' 
            Me.mobjTreeNode10.Name = ""
            Me.mobjTreeNode10.Text = "treeNode10"
            ' 
            ' mobjTreeNode11
            ' 
            Me.mobjTreeNode11.Name = ""
            Me.mobjTreeNode11.Text = "treeNode11"
            ' 
            ' mobjTreeNode4
            ' 
            Me.mobjTreeNode4.Name = ""
            Me.mobjTreeNode4.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode12, Me.mobjTreeNode13})
            Me.mobjTreeNode4.Text = "treeNode4"
            ' 
            ' mobjTreeNode12
            ' 
            Me.mobjTreeNode12.Name = ""
            Me.mobjTreeNode12.Text = "treeNode12"
            ' 
            ' mobjTreeNode13
            ' 
            Me.mobjTreeNode13.Name = ""
            Me.mobjTreeNode13.Text = "treeNode13"
            ' 
            ' mobjTreeNode5
            ' 
            Me.mobjTreeNode5.Name = ""
            Me.mobjTreeNode5.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode14, Me.mobjTreeNode15})
            Me.mobjTreeNode5.Text = "treeNode5"
            ' 
            ' mobjTreeNode14
            ' 
            Me.mobjTreeNode14.Name = ""
            Me.mobjTreeNode14.Text = "treeNode14"
            ' 
            ' mobjTreeNode15
            ' 
            Me.mobjTreeNode15.Name = ""
            Me.mobjTreeNode15.Text = "treeNode15"
            ' 
            ' mobjLinesCheckBox
            ' 
            Me.mobjLinesCheckBox.AutoSize = True
            Me.mobjLinesCheckBox.Checked = True
            Me.mobjLinesCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjLinesCheckBox.Location = New System.Drawing.Point(74, 167)
            Me.mobjLinesCheckBox.Name = "mobjLinesCheckBox"
            Me.mobjLinesCheckBox.Size = New System.Drawing.Size(76, 17)
            Me.mobjLinesCheckBox.TabIndex = 1
            Me.mobjLinesCheckBox.Text = "ShowLines"
            ' 
            ' mobjPlusMinusCheckBox
            ' 
            Me.mobjPlusMinusCheckBox.AutoSize = True
            Me.mobjPlusMinusCheckBox.Checked = True
            Me.mobjPlusMinusCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjPlusMinusCheckBox.Location = New System.Drawing.Point(74, 207)
            Me.mobjPlusMinusCheckBox.Name = "mobjPlusMinusCheckBox"
            Me.mobjPlusMinusCheckBox.Size = New System.Drawing.Size(98, 17)
            Me.mobjPlusMinusCheckBox.TabIndex = 2
            Me.mobjPlusMinusCheckBox.Text = "ShowPlusMinus"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeView, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPlusMinusCheckBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLinesCheckBox, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(349, 264)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' AppearanceCustomizationPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(349, 264)
            Me.Text = "ShowLinesPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTreeView As Gizmox.WebGUI.Forms.TreeView
        Private mobjTreeNode1 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode6 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode7 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode2 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode8 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode9 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode3 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode10 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode11 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode4 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode12 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode13 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode5 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode14 As Gizmox.WebGUI.Forms.TreeNode
        Private mobjTreeNode15 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents mobjLinesCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjPlusMinusCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace
Namespace CompanionKit.Controls.WorkspaceTabs.PopulatingData

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TabPagesCollectionPage
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
            Me.mobjWorkspaceTabs = New Gizmox.WebGUI.Forms.WorkspaceTabs()
            Me.mobjWorkspaceTab1 = New Gizmox.WebGUI.Forms.WorkspaceTab()
            Me.mobjWorkspaceTab2 = New Gizmox.WebGUI.Forms.WorkspaceTab()
            Me.mobjWorkspaceTab3 = New Gizmox.WebGUI.Forms.WorkspaceTab()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjWorkspaceTabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjWorkspaceTabs.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjWorkspaceTabs
            ' 
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab1)
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab2)
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab3)
            Me.mobjWorkspaceTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTabs.Location = New System.Drawing.Point(0, 90)
            Me.mobjWorkspaceTabs.Name = "mobjWorkspaceTabs"
            Me.mobjWorkspaceTabs.SelectedIndex = 0
            Me.mobjWorkspaceTabs.Size = New System.Drawing.Size(535, 171)
            Me.mobjWorkspaceTabs.TabIndex = 0
            ' 
            ' mobjWorkspaceTab1
            ' 
            Me.mobjWorkspaceTab1.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(255)), CInt(CByte(192)))
            Me.mobjWorkspaceTab1.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab1.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab1.Name = "mobjWorkspaceTab1"
            Me.mobjWorkspaceTab1.Size = New System.Drawing.Size(527, 145)
            Me.mobjWorkspaceTab1.TabIndex = 0
            Me.mobjWorkspaceTab1.Text = "workspaceTab1"
            ' 
            ' mobjWorkspaceTab2
            ' 
            Me.mobjWorkspaceTab2.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(255)), CInt(CByte(192)))
            Me.mobjWorkspaceTab2.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab2.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab2.Name = "mobjWorkspaceTab2"
            Me.mobjWorkspaceTab2.Size = New System.Drawing.Size(696, 145)
            Me.mobjWorkspaceTab2.TabIndex = 1
            Me.mobjWorkspaceTab2.Text = "workspaceTab2"
            ' 
            ' mobjWorkspaceTab3
            ' 
            Me.mobjWorkspaceTab3.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(255)), CInt(CByte(192)))
            Me.mobjWorkspaceTab3.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab3.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab3.Name = "mobjWorkspaceTab3"
            Me.mobjWorkspaceTab3.Size = New System.Drawing.Size(527, 145)
            Me.mobjWorkspaceTab3.TabIndex = 2
            Me.mobjWorkspaceTab3.Text = "workspaceTab3"
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjAddButton)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.DockPadding.Bottom = 10
            Me.mobjTopPanel.DockPadding.Top = 10
            Me.mobjTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjTopPanel.Size = New System.Drawing.Size(535, 70)
            Me.mobjTopPanel.TabIndex = 1
            ' 
            ' mobjAddButton
            ' 
            Me.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddButton.Location = New System.Drawing.Point(0, 10)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(535, 50)
            Me.mobjAddButton.TabIndex = 0
            Me.mobjAddButton.Text = "Add item"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjWorkspaceTabs, 0, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(15, 15)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(535, 261)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' TabPagesCollectionPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(565, 291)
            Me.Text = "TabPagesCollectionPage"
            DirectCast(Me.mobjWorkspaceTabs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjWorkspaceTabs.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjWorkspaceTabs As Gizmox.WebGUI.Forms.WorkspaceTabs
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Private mobjWorkspaceTab1 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjWorkspaceTab2 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjWorkspaceTab3 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace
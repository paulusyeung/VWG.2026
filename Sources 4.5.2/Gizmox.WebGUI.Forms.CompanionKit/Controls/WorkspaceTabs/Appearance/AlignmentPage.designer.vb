Namespace CompanionKit.Controls.WorkspaceTabs.Appearance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AlignmentPage
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
            Me.mobjWorkspaceTab4 = New Gizmox.WebGUI.Forms.WorkspaceTab()
            Me.mobjWorkspaceTab5 = New Gizmox.WebGUI.Forms.WorkspaceTab()
            Me.mobjTopRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjBottomRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjAlignmentGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjWorkspaceTabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjWorkspaceTabs.SuspendLayout()
            Me.mobjAlignmentGroupBox.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjWorkspaceTabs
            ' 
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab1)
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab2)
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab3)
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab4)
            Me.mobjWorkspaceTabs.Controls.Add(Me.mobjWorkspaceTab5)
            Me.mobjWorkspaceTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTabs.Location = New System.Drawing.Point(72, 37)
            Me.mobjWorkspaceTabs.Name = "mobjWorkspaceTabs"
            Me.mobjWorkspaceTabs.SelectedIndex = 0
            Me.mobjWorkspaceTabs.Size = New System.Drawing.Size(339, 176)
            Me.mobjWorkspaceTabs.TabIndex = 0
            ' 
            ' mobjWorkspaceTab1
            ' 
            Me.mobjWorkspaceTab1.BackColor = System.Drawing.Color.LightGreen
            Me.mobjWorkspaceTab1.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab1.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab1.Name = "mobjWorkspaceTab1"
            Me.mobjWorkspaceTab1.Size = New System.Drawing.Size(331, 150)
            Me.mobjWorkspaceTab1.TabIndex = 0
            Me.mobjWorkspaceTab1.Text = "workspaceTab1"
            ' 
            ' mobjWorkspaceTab2
            ' 
            Me.mobjWorkspaceTab2.BackColor = System.Drawing.Color.LightGreen
            Me.mobjWorkspaceTab2.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab2.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab2.Name = "mobjWorkspaceTab2"
            Me.mobjWorkspaceTab2.Size = New System.Drawing.Size(331, 150)
            Me.mobjWorkspaceTab2.TabIndex = 1
            Me.mobjWorkspaceTab2.Text = "workspaceTab2"
            ' 
            ' mobjWorkspaceTab3
            ' 
            Me.mobjWorkspaceTab3.BackColor = System.Drawing.Color.LightGreen
            Me.mobjWorkspaceTab3.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab3.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab3.Name = "mobjWorkspaceTab3"
            Me.mobjWorkspaceTab3.Size = New System.Drawing.Size(331, 150)
            Me.mobjWorkspaceTab3.TabIndex = 2
            Me.mobjWorkspaceTab3.Text = "workspaceTab3"
            ' 
            ' mobjWorkspaceTab4
            ' 
            Me.mobjWorkspaceTab4.BackColor = System.Drawing.Color.LightGreen
            Me.mobjWorkspaceTab4.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab4.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab4.Name = "mobjWorkspaceTab4"
            Me.mobjWorkspaceTab4.Size = New System.Drawing.Size(331, 150)
            Me.mobjWorkspaceTab4.TabIndex = 3
            Me.mobjWorkspaceTab4.Text = "workspaceTab4"
            ' 
            ' mobjWorkspaceTab5
            ' 
            Me.mobjWorkspaceTab5.BackColor = System.Drawing.Color.LightGreen
            Me.mobjWorkspaceTab5.CustomStyle = "Workspace"
            Me.mobjWorkspaceTab5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWorkspaceTab5.Location = New System.Drawing.Point(0, 0)
            Me.mobjWorkspaceTab5.Name = "mobjWorkspaceTab5"
            Me.mobjWorkspaceTab5.Size = New System.Drawing.Size(331, 150)
            Me.mobjWorkspaceTab5.TabIndex = 4
            Me.mobjWorkspaceTab5.Text = "workspaceTab5"
            ' 
            ' mobjTopRadioButton
            ' 
            Me.mobjTopRadioButton.AutoSize = True
            Me.mobjTopRadioButton.Checked = True
            Me.mobjTopRadioButton.Location = New System.Drawing.Point(16, 28)
            Me.mobjTopRadioButton.Name = "mobjTopRadioButton"
            Me.mobjTopRadioButton.Size = New System.Drawing.Size(43, 17)
            Me.mobjTopRadioButton.TabIndex = 2
            Me.mobjTopRadioButton.Text = "Top"
            ' 
            ' mobjBottomRadioButton
            ' 
            Me.mobjBottomRadioButton.AutoSize = True
            Me.mobjBottomRadioButton.Location = New System.Drawing.Point(16, 55)
            Me.mobjBottomRadioButton.Name = "mobjBottomRadioButton"
            Me.mobjBottomRadioButton.Size = New System.Drawing.Size(59, 17)
            Me.mobjBottomRadioButton.TabIndex = 3
            Me.mobjBottomRadioButton.Text = "Bottom"
            ' 
            ' mobjAlignmentGroupBox
            ' 
            Me.mobjAlignmentGroupBox.Controls.Add(Me.mobjTopRadioButton)
            Me.mobjAlignmentGroupBox.Controls.Add(Me.mobjBottomRadioButton)
            Me.mobjAlignmentGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAlignmentGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjAlignmentGroupBox.Location = New System.Drawing.Point(72, 233)
            Me.mobjAlignmentGroupBox.MaximumSize = New System.Drawing.Size(150, 0)
            Me.mobjAlignmentGroupBox.Name = "mobjAlignmentGroupBox"
            Me.mobjAlignmentGroupBox.Size = New System.Drawing.Size(150, 90)
            Me.mobjAlignmentGroupBox.TabIndex = 5
            Me.mobjAlignmentGroupBox.TabStop = False
            Me.mobjAlignmentGroupBox.Text = "Alignment"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAlignmentGroupBox, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjWorkspaceTabs, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 90.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(485, 362)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' AlignmentPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(485, 362)
            Me.Text = "MultilineAndAlignmentPage"
            DirectCast(Me.mobjWorkspaceTabs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjWorkspaceTabs.ResumeLayout(False)
            Me.mobjAlignmentGroupBox.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjWorkspaceTabs As Gizmox.WebGUI.Forms.WorkspaceTabs
        Private WithEvents mobjTopRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjBottomRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private mobjAlignmentGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private mobjWorkspaceTab1 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjWorkspaceTab2 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjWorkspaceTab3 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjWorkspaceTab4 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjWorkspaceTab5 As Gizmox.WebGUI.Forms.WorkspaceTab
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


    End Class

End Namespace
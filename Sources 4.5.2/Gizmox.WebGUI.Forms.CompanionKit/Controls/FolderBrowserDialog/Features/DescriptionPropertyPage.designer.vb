Namespace CompanionKit.Controls.FolderBrowserDialog.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DescriptionPropertyPage
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
            Me.mobjFolderBrowserDialog = New Gizmox.WebGUI.Forms.FolderBrowserDialog()
            Me.mobjBrowseButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDescriptionTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjSelectedDirectoryLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPathPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjPathPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjBrowseButton
            ' 
            Me.mobjBrowseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBrowseButton.Location = New System.Drawing.Point(348, 39)
            Me.mobjBrowseButton.Name = "mobjBrowseButton"
            Me.mobjBrowseButton.Size = New System.Drawing.Size(136, 50)
            Me.mobjBrowseButton.TabIndex = 0
            Me.mobjBrowseButton.Text = "Browse"
            Me.mobjBrowseButton.UseVisualStyleBackColor = True
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.AutoSize = True
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(161, 13)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = "Write your own description here"
            ' 
            ' mobjDescriptionTextBox
            ' 
            Me.mobjDescriptionTextBox.AllowDrag = False
            Me.mobjDescriptionTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjDescriptionTextBox.Location = New System.Drawing.Point(0, 20)
            Me.mobjDescriptionTextBox.Name = "mobjDescriptionTextBox"
            Me.mobjDescriptionTextBox.Size = New System.Drawing.Size(246, 30)
            Me.mobjDescriptionTextBox.TabIndex = 2
            Me.mobjDescriptionTextBox.Text = "Select a folder please"
            ' 
            ' mobjSelectedDirectoryLabel
            ' 
            Me.mobjSelectedDirectoryLabel.AutoSize = True
            Me.mobjSelectedDirectoryLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectedDirectoryLabel.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
            Me.mobjSelectedDirectoryLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSelectedDirectoryLabel.Name = "mobjSelectedDirectoryLabel"
            Me.mobjSelectedDirectoryLabel.Size = New System.Drawing.Size(0, 13)
            Me.mobjSelectedDirectoryLabel.TabIndex = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBrowseButton, 3, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPathPanel, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(567, 189)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjDescriptionLabel)
            Me.mobjPanel.Controls.Add(Me.mobjDescriptionTextBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(82, 39)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(246, 50)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjPathPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPathPanel, 3)
            Me.mobjPathPanel.Controls.Add(Me.mobjSelectedDirectoryLabel)
            Me.mobjPathPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPathPanel.Location = New System.Drawing.Point(82, 109)
            Me.mobjPathPanel.Name = "mobjPathPanel"
            Me.mobjPathPanel.Size = New System.Drawing.Size(402, 40)
            Me.mobjPathPanel.TabIndex = 0
            ' 
            ' DescriptionPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(567, 189)
            Me.Text = "DescriptionPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjPathPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjFolderBrowserDialog As Gizmox.WebGUI.Forms.FolderBrowserDialog
        Private WithEvents mobjBrowseButton As Gizmox.WebGUI.Forms.Button
        Private mobjDescriptionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDescriptionTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjSelectedDirectoryLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjPathPanel As Gizmox.WebGUI.Forms.Panel

    End Class

End Namespace
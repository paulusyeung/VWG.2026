Namespace CompanionKit.Controls.FolderBrowserDialog.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ShowNewFolderButtonPropertyPage
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
            Me.mobjPathTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjBrowseButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjShowNewFolderButtonCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjFolderBrowserDialog = New Gizmox.WebGUI.Forms.FolderBrowserDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjCheckBoxPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjCheckBoxPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjPathTextBox
            ' 
            Me.mobjPathTextBox.AllowDrag = False
            Me.mobjPathTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjPathTextBox.Location = New System.Drawing.Point(0, 20)
            Me.mobjPathTextBox.Name = "mobjPathTextBox"
            Me.mobjPathTextBox.Size = New System.Drawing.Size(241, 30)
            Me.mobjPathTextBox.TabIndex = 2
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.AutoSize = True
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(77, 13)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = "Selected path:"
            ' 
            ' mobjBrowseButton
            ' 
            Me.mobjBrowseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBrowseButton.Location = New System.Drawing.Point(341, 21)
            Me.mobjBrowseButton.Name = "mobjBrowseButton"
            Me.mobjBrowseButton.Size = New System.Drawing.Size(134, 50)
            Me.mobjBrowseButton.TabIndex = 0
            Me.mobjBrowseButton.Text = "Browse"
            ' 
            ' mobjShowNewFolderButtonCheckBox
            ' 
            Me.mobjShowNewFolderButtonCheckBox.AutoSize = True
            Me.mobjShowNewFolderButtonCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowNewFolderButtonCheckBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjShowNewFolderButtonCheckBox.Name = "mobjShowNewFolderButtonCheckBox"
            Me.mobjShowNewFolderButtonCheckBox.Size = New System.Drawing.Size(395, 40)
            Me.mobjShowNewFolderButtonCheckBox.TabIndex = 3
            Me.mobjShowNewFolderButtonCheckBox.Text = "Show New Folder Button"
            Me.mobjShowNewFolderButtonCheckBox.UseVisualStyleBackColor = True
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
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCheckBoxPanel, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(557, 153)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjDescriptionLabel)
            Me.mobjPanel.Controls.Add(Me.mobjPathTextBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(80, 21)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(241, 50)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjCheckBoxPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjCheckBoxPanel, 3)
            Me.mobjCheckBoxPanel.Controls.Add(Me.mobjShowNewFolderButtonCheckBox)
            Me.mobjCheckBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckBoxPanel.Location = New System.Drawing.Point(80, 91)
            Me.mobjCheckBoxPanel.Name = "mobjCheckBoxPanel"
            Me.mobjCheckBoxPanel.Size = New System.Drawing.Size(395, 40)
            Me.mobjCheckBoxPanel.TabIndex = 0
            ' 
            ' ShowNewFolderButtonPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(557, 153)
            Me.Text = "ShowNewFolderButtonPropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjCheckBoxPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjPathTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjDescriptionLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjBrowseButton As Gizmox.WebGUI.Forms.Button
        Private mobjShowNewFolderButtonCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjFolderBrowserDialog As Gizmox.WebGUI.Forms.FolderBrowserDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjCheckBoxPanel As Gizmox.WebGUI.Forms.Panel


    End Class

End Namespace
Imports System.Drawing

Namespace CompanionKit.Controls.ComboBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CustomComboBoxPage
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
            Me.mobjFormComboBox = New CompanionKit.Controls.ComboBox.Features.FormComboBox()
            Me.mobjTreeViewComboBox = New CompanionKit.Controls.ComboBox.Features.TreeViewComboBox()
            Me.mobjTreeViewLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFormLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjFormComboBox
            ' 
            Me.mobjFormComboBox.AllowDrag = False
            Me.mobjFormComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjFormComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFormComboBox.Location = New System.Drawing.Point(71, 160)
            Me.mobjFormComboBox.Name = "formComboBox1"
            Me.mobjFormComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjFormComboBox.TabIndex = 0
            Me.mobjFormComboBox.Text = "DropDown Form"
            ' 
            ' mobjTreeViewComboBox
            ' 
            Me.mobjTreeViewComboBox.AllowDrag = False
            Me.mobjTreeViewComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjTreeViewComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewComboBox.Location = New System.Drawing.Point(71, 60)
            Me.mobjTreeViewComboBox.Name = "treeViewComboBox1"
            Me.mobjTreeViewComboBox.SelectedItem = Nothing
            Me.mobjTreeViewComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjTreeViewComboBox.TabIndex = 1
            Me.mobjTreeViewComboBox.Text = "Select TreeView Node"
            ' 
            ' mobjTreeViewLabel
            ' 
            Me.mobjTreeViewLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjTreeViewLabel, 3)
            Me.mobjTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewLabel.Location = New System.Drawing.Point(0, 10)
            Me.mobjTreeViewLabel.Name = "label1"
            Me.mobjTreeViewLabel.Size = New System.Drawing.Size(342, 50)
            Me.mobjTreeViewLabel.TabIndex = 2
            Me.mobjTreeViewLabel.Text = "Custom TreeView ComboBox"
            Me.mobjTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjFormLabel
            ' 
            Me.mobjFormLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjFormLabel, 3)
            Me.mobjFormLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFormLabel.Location = New System.Drawing.Point(0, 110)
            Me.mobjFormLabel.Name = "label2"
            Me.mobjFormLabel.Size = New System.Drawing.Size(342, 50)
            Me.mobjFormLabel.TabIndex = 3
            Me.mobjFormLabel.Text = "Custom Form ComboBox"
            Me.mobjFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFormComboBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeViewComboBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeViewLabel, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFormLabel, 0, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(342, 200)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' CustomComboBoxPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(342, 200)
            Me.Text = "CustomComboBoxPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjFormComboBox As FormComboBox
        Private mobjTreeViewComboBox As TreeViewComboBox
        Private mobjTreeViewLabel As Gizmox.WebGUI.Forms.Label
        Private mobjFormLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
    End Class

End Namespace

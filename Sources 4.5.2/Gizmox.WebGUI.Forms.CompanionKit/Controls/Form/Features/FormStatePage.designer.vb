Namespace CompanionKit.Controls.Form.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class FormStatePage
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
            Me.mobjMaximizeBtnCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjMinimizeBtnCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjOpenFormWindowState = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjAdditionalLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjFirstPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSecondPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjAdditionalLayoutPanel.SuspendLayout()
            Me.mobjFirstPanel.SuspendLayout()
            Me.mobjSecondPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjMaximizeBtnCheckBox
            ' 
            Me.mobjMaximizeBtnCheckBox.AutoSize = True
            Me.mobjMaximizeBtnCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMaximizeBtnCheckBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjMaximizeBtnCheckBox.Name = "maximizeBtnCheckBox"
            Me.mobjMaximizeBtnCheckBox.Size = New System.Drawing.Size(348, 17)
            Me.mobjMaximizeBtnCheckBox.TabIndex = 1
            Me.mobjMaximizeBtnCheckBox.Text = "Maximize button"
            Me.mobjMaximizeBtnCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjMinimizeBtnCheckBox
            ' 
            Me.mobjMinimizeBtnCheckBox.AutoSize = True
            Me.mobjMinimizeBtnCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjMinimizeBtnCheckBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjMinimizeBtnCheckBox.Name = "minimizeBtnCheckBox"
            Me.mobjMinimizeBtnCheckBox.Size = New System.Drawing.Size(348, 17)
            Me.mobjMinimizeBtnCheckBox.TabIndex = 2
            Me.mobjMinimizeBtnCheckBox.Text = "Minimize button"
            Me.mobjMinimizeBtnCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(0, 66)
            Me.mobjLabel.Name = "label2"
            Me.mobjLabel.Size = New System.Drawing.Size(121, 13)
            Me.mobjLabel.TabIndex = 3
            Me.mobjLabel.Text = "Form state"
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjComboBox.Location = New System.Drawing.Point(121, 66)
            Me.mobjComboBox.Name = "comboBox1"
            Me.mobjComboBox.Size = New System.Drawing.Size(227, 30)
            Me.mobjComboBox.TabIndex = 4
            ' 
            ' mobjOpenFormWindowState
            ' 
            Me.mobjOpenFormWindowState.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFormWindowState.Location = New System.Drawing.Point(116, 148)
            Me.mobjOpenFormWindowState.Name = "openFormWindowState"
            Me.mobjOpenFormWindowState.Size = New System.Drawing.Size(348, 60)
            Me.mobjOpenFormWindowState.TabIndex = 5
            Me.mobjOpenFormWindowState.Text = "Open form with selected window state"
            Me.mobjOpenFormWindowState.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFormWindowState, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(581, 257)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjAdditionalLayoutPanel)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(116, 48)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(348, 100)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjAdditionalLayoutPanel
            ' 
            Me.mobjAdditionalLayoutPanel.ColumnCount = 2
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0F))
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjFirstPanel, 0, 0)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 2)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjSecondPanel, 0, 1)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjLabel, 0, 2)
            Me.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAdditionalLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel"
            Me.mobjAdditionalLayoutPanel.RowCount = 3
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjAdditionalLayoutPanel.Size = New System.Drawing.Size(348, 100)
            Me.mobjAdditionalLayoutPanel.TabIndex = 5
            ' 
            ' mobjFirstPanel
            ' 
            Me.mobjAdditionalLayoutPanel.SetColumnSpan(Me.mobjFirstPanel, 2)
            Me.mobjFirstPanel.Controls.Add(Me.mobjMaximizeBtnCheckBox)
            Me.mobjFirstPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFirstPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFirstPanel.Name = "mobjFirstPanel"
            Me.mobjFirstPanel.Size = New System.Drawing.Size(348, 33)
            Me.mobjFirstPanel.TabIndex = 0
            ' 
            ' mobjSecondPanel
            ' 
            Me.mobjAdditionalLayoutPanel.SetColumnSpan(Me.mobjSecondPanel, 2)
            Me.mobjSecondPanel.Controls.Add(Me.mobjMinimizeBtnCheckBox)
            Me.mobjSecondPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondPanel.Location = New System.Drawing.Point(0, 33)
            Me.mobjSecondPanel.Name = "mobjSecondPanel"
            Me.mobjSecondPanel.Size = New System.Drawing.Size(348, 33)
            Me.mobjSecondPanel.TabIndex = 0
            ' 
            ' FormStatePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(581, 257)
            Me.Text = "FormStatePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjAdditionalLayoutPanel.ResumeLayout(False)
            Me.mobjFirstPanel.ResumeLayout(False)
            Me.mobjSecondPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjMaximizeBtnCheckBox As Global.Gizmox.WebGUI.Forms.CheckBox
        Private mobjMinimizeBtnCheckBox As Global.Gizmox.WebGUI.Forms.CheckBox
        Private mobjLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjOpenFormWindowState As Global.Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjAdditionalLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjFirstPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjSecondPanel As Gizmox.WebGUI.Forms.Panel



	End Class

End Namespace

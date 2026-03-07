Namespace CompanionKit.Controls.StackPanel.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class StackPanelDemonstrationPage
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
            Me.mobjStackPanel = New Gizmox.WebGUI.Forms.StackPanel()
            Me.mobjOrienationGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjVerticalRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjHorizontalRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjRemoveButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjStackContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjOrientationPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjAddPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjRemovePanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjOrienationGroupBox.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjStackContainerPanel.SuspendLayout()
            Me.mobjOrientationPanel.SuspendLayout()
            Me.mobjAddPanel.SuspendLayout()
            Me.mobjRemovePanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjStackPanel
            ' 
            Me.mobjStackPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjStackPanel.CustomStyle = "StackPanel"
            Me.mobjStackPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStackPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjStackPanel.Name = "mobjStackPanel"
            Me.mobjStackPanel.Size = New System.Drawing.Size(508, 99)
            Me.mobjStackPanel.TabIndex = 0
            ' 
            ' mobjOrienationGroupBox
            ' 
            Me.mobjOrienationGroupBox.Controls.Add(Me.mobjVerticalRadioButton)
            Me.mobjOrienationGroupBox.Controls.Add(Me.mobjHorizontalRadioButton)
            Me.mobjOrienationGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOrienationGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjOrienationGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjOrienationGroupBox.MaximumSize = New System.Drawing.Size(250, 100)
            Me.mobjOrienationGroupBox.Name = "mobjOrienationGroupBox"
            Me.mobjOrienationGroupBox.Size = New System.Drawing.Size(244, 98)
            Me.mobjOrienationGroupBox.TabIndex = 1
            Me.mobjOrienationGroupBox.TabStop = False
            Me.mobjOrienationGroupBox.Text = "Orienation"
            ' 
            ' mobjVerticalRadioButton
            ' 
            Me.mobjVerticalRadioButton.AutoSize = True
            Me.mobjVerticalRadioButton.Checked = True
            Me.mobjVerticalRadioButton.Location = New System.Drawing.Point(19, 26)
            Me.mobjVerticalRadioButton.Name = "mobjVerticalRadioButton"
            Me.mobjVerticalRadioButton.Size = New System.Drawing.Size(60, 17)
            Me.mobjVerticalRadioButton.TabIndex = 3
            Me.mobjVerticalRadioButton.Text = "Vertical"
            ' 
            ' mobjHorizontalRadioButton
            ' 
            Me.mobjHorizontalRadioButton.AutoSize = True
            Me.mobjHorizontalRadioButton.Location = New System.Drawing.Point(19, 54)
            Me.mobjHorizontalRadioButton.Name = "mobjHorizontalRadioButton"
            Me.mobjHorizontalRadioButton.Size = New System.Drawing.Size(73, 17)
            Me.mobjHorizontalRadioButton.TabIndex = 2
            Me.mobjHorizontalRadioButton.Text = "Horizontal"
            ' 
            ' mobjAddButton
            ' 
            Me.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddButton.Location = New System.Drawing.Point(5, 5)
            Me.mobjAddButton.Name = "mobjAddButton"
            Me.mobjAddButton.Size = New System.Drawing.Size(234, 39)
            Me.mobjAddButton.TabIndex = 2
            Me.mobjAddButton.Text = "Add item"
            ' 
            ' mobjRemoveButton
            ' 
            Me.mobjRemoveButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRemoveButton.Location = New System.Drawing.Point(5, 5)
            Me.mobjRemoveButton.Name = "mobjRemoveButton"
            Me.mobjRemoveButton.Size = New System.Drawing.Size(234, 39)
            Me.mobjRemoveButton.TabIndex = 3
            Me.mobjRemoveButton.Text = "Remove item"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 38.46154F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 38.46154F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjStackContainerPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOrientationPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAddPanel, 3, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjRemovePanel, 3, 4)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 38.46154F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 19.23077F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 19.23077F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(655, 280)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjStackContainerPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjStackContainerPanel, 3)
            Me.mobjStackContainerPanel.Controls.Add(Me.mobjStackPanel)
            Me.mobjStackContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStackContainerPanel.Location = New System.Drawing.Point(73, 29)
            Me.mobjStackContainerPanel.Name = "mobjStackContainerPanel"
            Me.mobjStackContainerPanel.Size = New System.Drawing.Size(508, 99)
            Me.mobjStackContainerPanel.TabIndex = 0
            ' 
            ' mobjOrientationPanel
            ' 
            Me.mobjOrientationPanel.Controls.Add(Me.mobjOrienationGroupBox)
            Me.mobjOrientationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOrientationPanel.Location = New System.Drawing.Point(73, 148)
            Me.mobjOrientationPanel.Name = "mobjOrientationPanel"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjOrientationPanel, 2)
            Me.mobjOrientationPanel.Size = New System.Drawing.Size(244, 98)
            Me.mobjOrientationPanel.TabIndex = 0
            ' 
            ' mobjAddPanel
            ' 
            Me.mobjAddPanel.Controls.Add(Me.mobjAddButton)
            Me.mobjAddPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddPanel.DockPadding.All = 5
            Me.mobjAddPanel.Location = New System.Drawing.Point(337, 148)
            Me.mobjAddPanel.Name = "mobjAddPanel"
            Me.mobjAddPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjAddPanel.Size = New System.Drawing.Size(244, 49)
            Me.mobjAddPanel.TabIndex = 0
            ' 
            ' mobjRemovePanel
            ' 
            Me.mobjRemovePanel.Controls.Add(Me.mobjRemoveButton)
            Me.mobjRemovePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRemovePanel.DockPadding.All = 5
            Me.mobjRemovePanel.Location = New System.Drawing.Point(337, 197)
            Me.mobjRemovePanel.Name = "mobjRemovePanel"
            Me.mobjRemovePanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjRemovePanel.Size = New System.Drawing.Size(244, 49)
            Me.mobjRemovePanel.TabIndex = 0
            ' 
            ' StackPanelDemonstrationPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(655, 280)
            Me.Text = "StackPanelDemonstrationPage"
            Me.mobjOrienationGroupBox.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjStackContainerPanel.ResumeLayout(False)
            Me.mobjOrientationPanel.ResumeLayout(False)
            Me.mobjAddPanel.ResumeLayout(False)
            Me.mobjRemovePanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjStackPanel As Gizmox.WebGUI.Forms.StackPanel
        Private mobjOrienationGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjVerticalRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjHorizontalRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjAddButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjRemoveButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjStackContainerPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjOrientationPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjAddPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjRemovePanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
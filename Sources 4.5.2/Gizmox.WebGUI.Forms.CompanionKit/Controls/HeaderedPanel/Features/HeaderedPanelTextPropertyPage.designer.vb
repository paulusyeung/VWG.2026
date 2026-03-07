Namespace CompanionKit.Controls.HeaderedPanel.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HeaderedPanelTextPropertyPage
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
            Me.mobjContentLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjHeaderedPanel = New Gizmox.WebGUI.Forms.HeaderedPanel()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjHeaderedPanel.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjContainerPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjContentLabel
            ' 
            Me.mobjContentLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjContentLabel.AutoSize = True
            Me.mobjContentLabel.Location = New System.Drawing.Point(142, 54)
            Me.mobjContentLabel.Name = "mobjContentLabel"
            Me.mobjContentLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjContentLabel.TabIndex = 0
            Me.mobjContentLabel.Text = "Panel content"
            ' 
            ' mobjHeaderedPanel
            ' 
            Me.mobjHeaderedPanel.Controls.Add(Me.mobjContentLabel)
            Me.mobjHeaderedPanel.CustomStyle = "HeaderedPanel"
            Me.mobjHeaderedPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHeaderedPanel.Location = New System.Drawing.Point(122, 30)
            Me.mobjHeaderedPanel.Name = "mobjHeaderedPanel"
            Me.mobjHeaderedPanel.Size = New System.Drawing.Size(367, 122)
            Me.mobjHeaderedPanel.TabIndex = 0
            ' 
            ' mobjButton
            ' 
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjButton.Location = New System.Drawing.Point(122, 229)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(367, 45)
            Me.mobjButton.TabIndex = 1
            Me.mobjButton.Text = "Set text"
            Me.mobjButton.UseVisualStyleBackColor = True
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjTextBox.Location = New System.Drawing.Point(0, 41)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(367, 30)
            Me.mobjTextBox.TabIndex = 2
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AutoSize = True
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 10)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(69, 13)
            Me.mobjInfoLabel.TabIndex = 3
            Me.mobjInfoLabel.Text = "Header text:"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjHeaderedPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjButton, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjContainerPanel, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(613, 306)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjContainerPanel
            ' 
            Me.mobjContainerPanel.Controls.Add(Me.mobjInfoLabel)
            Me.mobjContainerPanel.Controls.Add(Me.mobjTextBox)
            Me.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContainerPanel.DockPadding.Top = 10
            Me.mobjContainerPanel.Location = New System.Drawing.Point(122, 152)
            Me.mobjContainerPanel.Name = "mobjContainerPanel"
            Me.mobjContainerPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0)
            Me.mobjContainerPanel.Size = New System.Drawing.Size(367, 61)
            Me.mobjContainerPanel.TabIndex = 0
            ' 
            ' HeaderedPanelTextPropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(613, 306)
            Me.Text = "HeaderedPanelTextPropertyPage"
            Me.mobjHeaderedPanel.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjContainerPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjContentLabel As Gizmox.WebGUI.Forms.Label
        Private mobjHeaderedPanel As Gizmox.WebGUI.Forms.HeaderedPanel
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjContainerPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
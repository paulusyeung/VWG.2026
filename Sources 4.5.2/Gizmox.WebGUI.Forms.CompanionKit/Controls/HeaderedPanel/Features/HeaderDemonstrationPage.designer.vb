Namespace CompanionKit.Controls.HeaderedPanel.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HeaderDemonstrationPage
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
            Me.mobjHeaderedPanel = New Gizmox.WebGUI.Forms.HeaderedPanel()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjButtonRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjCheckBoxRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTextIconRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTextRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjContainerPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjHeaderedPanel
            ' 
            Me.mobjHeaderedPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjHeaderedPanel.CustomStyle = "HeaderedPanel"
            Me.mobjHeaderedPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHeaderedPanel.Location = New System.Drawing.Point(106, 37)
            Me.mobjHeaderedPanel.Name = "mobjHeaderedPanel"
            Me.mobjHeaderedPanel.Size = New System.Drawing.Size(212, 167)
            Me.mobjHeaderedPanel.TabIndex = 0
            Me.mobjHeaderedPanel.Text = "Text"
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjButtonRadioButton)
            Me.mobjGroupBox.Controls.Add(Me.mobjCheckBoxRadioButton)
            Me.mobjGroupBox.Controls.Add(Me.mobjTextIconRadioButton)
            Me.mobjGroupBox.Controls.Add(Me.mobjTextRadioButton)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 15)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(212, 133)
            Me.mobjGroupBox.TabIndex = 1
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "HeaderType"
            ' 
            ' mobjButtonRadioButton
            ' 
            Me.mobjButtonRadioButton.AutoSize = True
            Me.mobjButtonRadioButton.Location = New System.Drawing.Point(44, 108)
            Me.mobjButtonRadioButton.Name = "mobjButtonRadioButton"
            Me.mobjButtonRadioButton.Size = New System.Drawing.Size(57, 17)
            Me.mobjButtonRadioButton.TabIndex = 3
            Me.mobjButtonRadioButton.Text = "Button"
            ' 
            ' mobjCheckBoxRadioButton
            ' 
            Me.mobjCheckBoxRadioButton.AutoSize = True
            Me.mobjCheckBoxRadioButton.Location = New System.Drawing.Point(44, 80)
            Me.mobjCheckBoxRadioButton.Name = "mobjCheckBoxRadioButton"
            Me.mobjCheckBoxRadioButton.Size = New System.Drawing.Size(72, 17)
            Me.mobjCheckBoxRadioButton.TabIndex = 2
            Me.mobjCheckBoxRadioButton.Text = "CheckBox"
            ' 
            ' mobjTextIconRadioButton
            ' 
            Me.mobjTextIconRadioButton.AutoSize = True
            Me.mobjTextIconRadioButton.Location = New System.Drawing.Point(44, 53)
            Me.mobjTextIconRadioButton.Name = "mobjTextIconRadioButton"
            Me.mobjTextIconRadioButton.Size = New System.Drawing.Size(82, 17)
            Me.mobjTextIconRadioButton.TabIndex = 1
            Me.mobjTextIconRadioButton.Text = "Text + Icon"
            ' 
            ' mobjTextRadioButton
            ' 
            Me.mobjTextRadioButton.AutoSize = True
            Me.mobjTextRadioButton.Checked = True
            Me.mobjTextRadioButton.Location = New System.Drawing.Point(44, 26)
            Me.mobjTextRadioButton.Name = "mobjTextRadioButton"
            Me.mobjTextRadioButton.Size = New System.Drawing.Size(47, 17)
            Me.mobjTextRadioButton.TabIndex = 0
            Me.mobjTextRadioButton.Text = "Text"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjHeaderedPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjContainerPanel, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(425, 372)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' mobjContainerPanel
            ' 
            Me.mobjContainerPanel.Controls.Add(Me.mobjGroupBox)
            Me.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContainerPanel.DockPadding.Bottom = 20
            Me.mobjContainerPanel.DockPadding.Top = 15
            Me.mobjContainerPanel.Location = New System.Drawing.Point(106, 204)
            Me.mobjContainerPanel.Name = "mobjContainerPanel"
            Me.mobjContainerPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 15, 0, 20)
            Me.mobjContainerPanel.Size = New System.Drawing.Size(212, 168)
            Me.mobjContainerPanel.TabIndex = 0
            ' 
            ' HeaderDemonstrationPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(425, 372)
            Me.Text = "HeaderDemonstrationPage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjContainerPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjHeaderedPanel As Gizmox.WebGUI.Forms.HeaderedPanel
        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjButtonRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjCheckBoxRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjTextIconRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjTextRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjContainerPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace
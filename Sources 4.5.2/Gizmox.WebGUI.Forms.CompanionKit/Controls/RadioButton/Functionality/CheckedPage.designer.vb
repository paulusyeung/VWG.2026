Namespace CompanionKit.Controls.RadioButton.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckedPage
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
            Me.mobjRadioButton1 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButton2 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjRadioPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjInfoPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjRadioPanel.SuspendLayout()
            Me.mobjInfoPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjRadioButton1
            ' 
            Me.mobjRadioButton1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioButton1.AutoSize = True
            Me.mobjRadioButton1.Location = New System.Drawing.Point(45, 18)
            Me.mobjRadioButton1.Name = "mobjRadioButton1"
            Me.mobjRadioButton1.Size = New System.Drawing.Size(90, 17)
            Me.mobjRadioButton1.TabIndex = 0
            Me.mobjRadioButton1.Text = "RadioButton1"
            ' 
            ' mobjRadioButton2
            ' 
            Me.mobjRadioButton2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioButton2.AutoSize = True
            Me.mobjRadioButton2.Location = New System.Drawing.Point(45, 48)
            Me.mobjRadioButton2.Name = "mobjRadioButton2"
            Me.mobjRadioButton2.Size = New System.Drawing.Size(90, 17)
            Me.mobjRadioButton2.TabIndex = 1
            Me.mobjRadioButton2.Text = "RadioButton2"
            ' 
            ' mobjButton
            ' 
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton.Location = New System.Drawing.Point(301, 64)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(150, 80)
            Me.mobjButton.TabIndex = 2
            Me.mobjButton.Text = "Check the state of the RB1"
            Me.mobjButton.UseVisualStyleBackColor = True
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Font = New System.Drawing.Font("Tahoma", 15.25F)
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(401, 60)
            Me.mobjInfoLabel.TabIndex = 3
            Me.mobjInfoLabel.Text = "label1"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjButton, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjRadioPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoPanel, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(503, 268)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjRadioPanel
            ' 
            Me.mobjRadioPanel.Controls.Add(Me.mobjRadioButton1)
            Me.mobjRadioPanel.Controls.Add(Me.mobjRadioButton2)
            Me.mobjRadioPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRadioPanel.Location = New System.Drawing.Point(50, 64)
            Me.mobjRadioPanel.Name = "mobjRadioPanel"
            Me.mobjRadioPanel.Size = New System.Drawing.Size(251, 80)
            Me.mobjRadioPanel.TabIndex = 0
            ' 
            ' mobjInfoPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjInfoPanel, 2)
            Me.mobjInfoPanel.Controls.Add(Me.mobjInfoLabel)
            Me.mobjInfoPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoPanel.Location = New System.Drawing.Point(50, 144)
            Me.mobjInfoPanel.Name = "mobjInfoPanel"
            Me.mobjInfoPanel.Size = New System.Drawing.Size(401, 60)
            Me.mobjInfoPanel.TabIndex = 0
            ' 
            ' CheckedPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(503, 268)
            Me.Text = "CheckedPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjRadioPanel.ResumeLayout(False)
            Me.mobjInfoPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjRadioButton1 As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRadioButton2 As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjRadioPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjInfoPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
